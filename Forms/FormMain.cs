using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using BeeSchema;
using Be.Windows.Forms;

namespace Ostara {
	partial class FormMain : Form {
		bool paused, gotServerList;
		List<Proxy> proxies;

		public FormMain() {
			InitializeComponent();

			Settings.I.Load();
			Colours.I.Load();
			Ignores.I.Load();
			Comments.I.Load();

			proxies = new List<Proxy>();

			txtIp.Text = Settings.I.ServerIP;
			txtPort.Text = Settings.I.ServerPort.ToString();

			tsbClearOnStart.Checked = Settings.I.ClearOnStart;
			hexView.BytesPerLine = (Settings.I.BytesPerLine + 1) * 8;
			tableLayoutPanel1.ColumnStyles[1].Width = hexView.RequiredWidth + 17;
			cbBytesPerLine.SelectedIndex = Settings.I.BytesPerLine;
			var ae = (Controls.ToolStripRadioButtonMenuItem)autoExpandToolStripMenuItem.DropDownItems[(int)Settings.I.AutoExpand];
			ae.CheckState = CheckState.Checked;

			tlvStructure.CanExpandGetter = e => ((Result)e).HasChildren;
			tlvStructure.ChildrenGetter = e => ((Result)e).Children;
			tlvStructure.Expanded += (s, e) => {
				if (Settings.I.AutoExpand != Settings.AutoExpandType.Bitfields)
					return;

				var r = (Result)e.Model;

				foreach (var v in r)
					if (v.Type == NodeType.Bitfield)
						tlvStructure.Expand(v);
			};
			olvValue.AspectToStringConverter = x => {
				if (x is ResultCollection)
					return string.Empty;
				else
					return $"{x}";
			};
		}

		void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			Ignores.I.Save();

			Settings.I.ServerIP = txtIp.Text;
			Settings.I.ServerPort = ushort.Parse(txtPort.Text);
			Settings.I.Save();
		}

		void tsbOpen_Click(object sender, EventArgs e) {
			var dlg = new OpenFileDialog();
			dlg.Title = "Open packet log file...";
			dlg.Filter = "Packet Log|*.log";

			if (dlg.ShowDialog() == DialogResult.OK)
				flvPackets.SetObjects(PacketLog.Load(dlg.FileName));

			dlg.Dispose();
		}

		void tsbSave_Click(object sender, EventArgs e) {
			if (flvPackets.Objects == null || flvPackets.GetItemCount() == 0)
				return;

			var file = PacketLog.Save(flvPackets.Objects);
			MessageBox.Show($"Packet log saved as {file}");
		}

		void tsbClearOnStart_CheckedChanged(object sender, EventArgs e) {
			Settings.I.ClearOnStart = tsbClearOnStart.Checked;
		}

		void tsbClear_Click(object sender, EventArgs e) {
			flvPackets.ClearObjects();
			hexView.ByteProvider = null;
			ClearInspector();
		}

		void tsbColours_Click(object sender, EventArgs e) {
			var dlg = new FormColours();
			dlg.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);

			if (dlg.ShowDialog() == DialogResult.Cancel) {
				dlg.Dispose();
				return;
			}

			Colours.I.Pairs = new Dictionary<Tuple<Daemon, Daemon>, Tuple<Color, Color>>(dlg.Pairs);
			Colours.I.Save();
			flvPackets.Refresh();

			dlg.Dispose();
		}

		// TODO: Make ignores per-daemon
		void tsmiIgnoreAdd_Click(object sender, EventArgs e) {
			if (flvPackets.SelectedIndex == -1)
				return;

			var p = (PacketInfo)flvPackets.SelectedObject;

			if (!Ignores.I.Values.Contains(p.Opcode))
				Ignores.I.Values.Add(p.Opcode);
		}

		void tsmiIgnoreRemove_Click(object sender, EventArgs e) {
			if (flvPackets.SelectedIndex == -1)
				return;

			var p = (PacketInfo)flvPackets.SelectedObject;
			Ignores.I.Values.Remove(p.Opcode);
		}

		void tsmiIgnoreManage_Click(object sender, EventArgs e) {
			var dlg = new FormIgnores();
			dlg.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);

			if (dlg.ShowDialog() == DialogResult.Cancel) {
				dlg.Dispose();
				return;
			}

			Ignores.I.Values = new List<ushort>(dlg.Opcodes);
			Ignores.I.Save();

			dlg.Dispose();
		}

		void tsbAbout_Click(object sender, EventArgs e) {
			var dlg = new FormAbout();
			dlg.ShowDialog();
			dlg.Dispose();
		}

		void tsbStart_Click(object sender, EventArgs e) {
			txtIp.Enabled = false;
			txtPort.Enabled = false;
			tsbStart.Enabled = false;
			tsbPause.Enabled = tsbStop.Enabled = true;

			this.Text = "Ostara - Logging";

			if (paused) {
				paused = false;
				return;
			}

			if (Settings.I.ClearOnStart)
				flvPackets.ClearObjects();

			Task.Run((Action)StartLoginProxy);
		}

		void StartLoginProxy() {
			var proxy = new Proxy(Daemon.Login, IPAddress.Loopback, 65000, IPAddress.Parse(txtIp.Text), ushort.Parse(txtPort.Text));
			proxy.OnDisconnect += (s, e) => proxy.Start();
			proxy.OnReceivePacket += (s, e) => {
				if (e.Packet.IsIncoming) {
					switch (e.Packet.Opcode) {
						case 101: {     // RSP : Connect2Svr
								var schema = Schema.FromFile("cfg/structs/101.i.l.bee");
								var parsed = schema.Parse(e.Packet.Data);

								uint seed = parsed["new_xor_seed"];
								ushort id = parsed["new_xor_key_id"];

								var ss = (Proxy)s;

								e.OnSend = () => {
									ss.LocalCrypt.ChangeKeychain(seed, id);
									ss.RemoteCrypt.ChangeKeychain(seed, id);
								};
							}
							break;
						case 121: {     // NFY : ServerList
								var schema = Schema.FromFile("cfg/structs/121.i.l.bee");
								var parsed = schema.Parse(e.Packet.Data);

								foreach (var sv in parsed["servers"]) {
									foreach (var ch in sv["channels"]) {
										IPAddress ip = ch["ip"];
										ushort port = ch["port"];

										ushort lport = 64000;
										lport += (ushort)((byte)ch["server"] * 100);
										lport += (byte)ch["id"];

										var pos = ch["ip"].Position;
										e.Packet.Data[pos++] = 127;
										e.Packet.Data[pos++] = 0;
										e.Packet.Data[pos++] = 0;
										e.Packet.Data[pos++] = 1;
										e.Packet.Data[pos++] = (byte)(lport & 0xFF);
										e.Packet.Data[pos] = (byte)(lport >> 8);

										if (!gotServerList)
											new Thread(() => StartWorldProxy(lport, ip, port)).Start();
									}
								}

								if (!gotServerList)
									gotServerList = true;
							}
							break;
					}
				}

				flvPackets.AddObject(e.Packet);
			};

			proxies.Add(proxy);
		}

		void StartWorldProxy(ushort localPort, IPAddress remoteIP, ushort remotePort) {
			Console.WriteLine($"Starting World proxy for {remoteIP}:{remotePort}...");
			var proxy = new Proxy(Daemon.World, IPAddress.Loopback, localPort, remoteIP, remotePort);
			proxy.OnDisconnect += (s, e) => proxy.Start();
			proxy.OnReceivePacket += (s, e) => {
#if DEBUG
				//Console.WriteLine($"Got packet from {e.Packet.Source}: {e.Packet.Opcode}");
#endif
				flvPackets.AddObject(e.Packet);

				if (e.Packet.IsIncoming) {
					switch (e.Packet.Opcode) {
						case 140: {     // RSP : Connect2Svr
								var schema = Schema.FromFile("cfg/structs/140.i.w.bee");
								var parsed = schema.Parse(e.Packet.Data);

								uint seed = parsed["new_xor_seed"];
								ushort id = parsed["new_xor_key_id"];

								var ss = (Proxy)s;

								e.OnSend = () => {
									ss.LocalCrypt.ChangeKeychain(seed, id);
									ss.RemoteCrypt.ChangeKeychain(seed, id);
								};
							}
							break;
						case 142: {     // RSP : Initialised
								var schema = Schema.FromFile("cfg/structs/142.i.w.bee");
								var parsed = schema.Parse(e.Packet.Data);

								// TODO: Change login ip and port in packet

								IPAddress chatIp = parsed["chat_ip"];
								ushort chatPort = parsed["chat_port"];

								var pos = parsed["chat_ip"].Position;
								e.Packet.Data[pos++] = 127;
								e.Packet.Data[pos++] = 0;
								e.Packet.Data[pos++] = 0;
								e.Packet.Data[pos++] = 1;
								e.Packet.Data[pos++] = (byte)(64001 & 0xFF);
								e.Packet.Data[pos] = (byte)(64001 >> 8);

								new Thread(() => StartChatProxy(chatIp, chatPort)).Start();

								IPAddress auctionIp = parsed["agentshop_ip"];
								ushort auctionPort = parsed["agentshop_port"];

								pos = parsed["agentshop_ip"].Position;
								e.Packet.Data[pos++] = 127;
								e.Packet.Data[pos++] = 0;
								e.Packet.Data[pos++] = 0;
								e.Packet.Data[pos++] = 1;
								e.Packet.Data[pos++] = (byte)(64010 & 0xFF);
								e.Packet.Data[pos] = (byte)(64010 >> 8);

								new Thread(() => StartAuctionProxy(auctionIp, auctionPort)).Start();
							}
							break;
					}
				}
			};

			proxies.Add(proxy);
		}

		void StartChatProxy(IPAddress remoteIP, ushort remotePort) {
			Console.WriteLine($"Starting Chat proxy for {remoteIP}:{remotePort}...");
			var proxy = new Proxy(Daemon.Chat, IPAddress.Loopback, 64001, remoteIP, remotePort);
			proxy.OnDisconnect += (s, e) => proxies.Remove(proxy);
			proxy.OnReceivePacket += (s, e) => {
#if DEBUG
				Console.WriteLine($"Got packet from {e.Packet.Source}: {e.Packet.Opcode}");
#endif
				flvPackets.AddObject(e.Packet);

				if (e.Packet.IsIncoming) {
					switch (e.Packet.Opcode) {
						case 401: {     // RSP : Connect2Svr
								var schema = Schema.FromFile("cfg/structs/401.i.c.bee");
								var parsed = schema.Parse(e.Packet.Data);

								uint seed = parsed["new_xor_seed"];
								ushort id = parsed["new_xor_key_id"];

								var ss = (Proxy)s;

								e.OnSend = () => {
									ss.LocalCrypt.ChangeKeychain(seed, id);
									ss.RemoteCrypt.ChangeKeychain(seed, id);
								};
							}
							break;
					}
				}
					};

			proxies.Add(proxy);
		}

		void StartAuctionProxy(IPAddress remoteIP, ushort remotePort) {
			Console.WriteLine($"Starting Auction proxy for {remoteIP}:{remotePort}...");
			var proxy = new Proxy(Daemon.Auction, IPAddress.Loopback, 64010, remoteIP, remotePort);
			proxy.OnDisconnect += (s, e) => proxies.Remove(proxy);
			proxy.OnReceivePacket += (s, e) => {
#if DEBUG
				Console.WriteLine($"Got packet from {e.Packet.Source}: {e.Packet.Opcode}");
#endif
				flvPackets.AddObject(e.Packet);
			};

			proxies.Add(proxy);
		}

		void tsbPause_Click(object sender, EventArgs e) {
			paused = true;
			tsbPause.Enabled = false;
			tsbStart.Enabled = true;

			this.Text = "Ostara - Paused";
		}

		void tsbStop_Click(object sender, EventArgs e) {
			paused = false;

			txtIp.Enabled = true;
			txtPort.Enabled = true;
			tsbStart.Enabled = true;
			tsbPause.Enabled = tsbStop.Enabled = false;

			this.Text = "Ostara - Stopped";

			foreach (var p in proxies)
				p.Stop();
		}

		void flvPackets_CellRightClick(object sender, BrightIdeasSoftware.CellRightClickEventArgs e) {
			if (e.RowIndex == -1)
				return;

			EditStructure();
		}

		void flvPackets_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e) {
			var p = (PacketInfo)e.Model;
			Colours.I.FormatRow(e.Item, p.Source, p.Destination);

			e.Item.ToolTipText = p.Comment;
		}

		void flvPackets_ItemsChanged(object sender, BrightIdeasSoftware.ItemsChangedEventArgs e) {
			if (flvPackets.GetItemCount() == 0)
				return;

			var i = (flvPackets.SelectedIndex != -1) ? flvPackets.SelectedIndex : flvPackets.GetItemCount() - 1;
			flvPackets.EnsureVisible(i);
		}

		void flvPackets_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar != (char)27)
				return;

			flvPackets.SelectedIndex = -1;
			e.Handled = true;
		}

		void flvPackets_SelectedIndexChanged(object sender, EventArgs e) {
			if (flvPackets.SelectedIndex < 0) {
				ClearInspector();
				hexView.ByteProvider = null;
				tlvStructure.ClearObjects();
			}
			else {
				var pi = (PacketInfo)flvPackets.SelectedObject;
				var bytes = new DynamicByteProvider(pi.Data);
				hexView.ByteProvider = bytes;
				SetStructureObjects(ParsePacketData(pi));
				tlvStructure.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
			}
		}

		ResultCollection ParsePacketData(PacketInfo packet) {
			var filename = $"cfg\\structs\\{GetSchemaFilename(packet)}";

			if (!File.Exists(filename))
				return null;

			ResultCollection r = null;

			try {
				r = Schema.FromFile(filename).Parse(packet.Data);
			}
			catch (Exception e) {
#if DEBUG
				Console.WriteLine(e.Message);
#else
				MessageBox.Show(e.Message);
#endif
			}

			return r;
		}

		string GetSchemaFilename(PacketInfo packet) {
			Daemon daemon;
			var opcode = packet.Opcode;

			if (packet.IsIncoming)
				daemon = packet.Source;
			else
				daemon = packet.Destination;

			var dchar =
				(daemon == Daemon.Auction) ? 'a' :
				(daemon == Daemon.Chat) ? 'c' :
				(daemon == Daemon.Login) ? 'l' :
				'w';

			var ichar = (packet.IsIncoming) ? 'i' : 'o';

			return $"{opcode}.{ichar}.{dchar}.bee";
		}

		void hexView_Copied(object sender, EventArgs e) {
			hexView.CopyHex();
		}

		unsafe void hexView_SelectionStartChanged(object sender, EventArgs e) {
			int s = flvPackets.SelectedIndex;
			int i = (int)hexView.SelectionStart;

			if (s < 0 || i < 0) {
				ClearInspector();
				return;
			}

			fixed (byte* p = ((PacketInfo)flvPackets.SelectedObject).Data) {
				inspByte.Text = p[i].ToString();
				inspSByte.Text = ((sbyte)p[i]).ToString();
				inspShort.Text = (*(short*)&p[i]).ToString();
				inspUShort.Text = (*(ushort*)&p[i]).ToString();
				inspInt.Text = (*(int*)&p[i]).ToString();
				inspUInt.Text = (*(uint*)&p[i]).ToString();
				inspLong.Text = (*(long*)&p[i]).ToString();
				inspULong.Text = (*(ulong*)&p[i]).ToString();
				inspFloat.Text = (*(float*)&p[i]).ToString();
				inspDouble.Text = (*(double*)&p[i]).ToString();
			}
		}

		void cbBytesPerLine_SelectedIndexChanged(object sender, EventArgs e) {
			Settings.I.BytesPerLine = (byte)cbBytesPerLine.SelectedIndex;
			hexView.BytesPerLine = (Settings.I.BytesPerLine + 1) * 8;
			tableLayoutPanel1.ColumnStyles[1].Width = hexView.RequiredWidth + 17;
		}

		void tlvStructure_DoubleClick(object sender, EventArgs e) {
			EditStructure();
		}

		void tlvStructure_Collapsed(object sender, BrightIdeasSoftware.TreeBranchCollapsedEventArgs e) {
			tlvStructure.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		void tlvStructure_Expanded(object sender, BrightIdeasSoftware.TreeBranchExpandedEventArgs e) {
			tlvStructure.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		void tlvStructure_SelectedIndexChanged(object sender, EventArgs e) {
			if (tlvStructure.SelectedIndex == -1)
				hexView.Select(0, 0);
			else {
				var se = (Result)tlvStructure.SelectedObject;
				hexView.Select(se.Position, se.Size);
			}
		}

		void cmseStructureEdit_Click(object sender, EventArgs e) {
			EditStructure();
		}

		void autoExpandCheckStateChanged(object sender, EventArgs e) {
			if (noneToolStripMenuItem.CheckState == CheckState.Checked)
				Settings.I.AutoExpand = Settings.AutoExpandType.None;
			else if (bitfieldsOnlyToolStripMenuItem.CheckState == CheckState.Checked)
				Settings.I.AutoExpand = Settings.AutoExpandType.Bitfields;
			else if (allToolStripMenuItem.CheckState == CheckState.Checked)
				Settings.I.AutoExpand = Settings.AutoExpandType.All;
		}

		void ClearInspector() {
			inspByte.Text = inspSByte.Text = inspShort.Text = inspUShort.Text =
			inspInt.Text = inspUInt.Text = inspLong.Text = inspULong.Text =
			inspFloat.Text = inspDouble.Text = "";
		}

		void EditStructure() {
			var packet = (PacketInfo)flvPackets.SelectedObject;
			var filename = GetSchemaFilename(packet);
			var path = $"{Environment.CurrentDirectory}\\cfg\\structs\\";

			if (!File.Exists(path + filename)) {
				var file = File.CreateText(path + filename);
				file.WriteLine("include header.bee;");
				file.WriteLine();
				file.WriteLine("schema {");
				file.Write("\theader:\t\t");

				if (filename.Contains(".i."))
					file.WriteLine("ServerHeader;");
				else
					file.WriteLine("ClientHeader;");

				file.WriteLine("\t");
				file.WriteLine("}");
				file.Close();
			}

			var watcher = new FileSystemWatcher(path, filename);
			watcher.NotifyFilter = NotifyFilters.LastWrite;
			watcher.EnableRaisingEvents = true;
			watcher.Changed += async (s, e) => {
				await Task.Delay(500);
				Action a = () => SetStructureObjects(ParsePacketData(packet));
				tlvStructure.Invoke(a);
				a = () => tlvStructure.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
				tlvStructure.Invoke(a);
			};

			var p = new Process();
			p.EnableRaisingEvents = true;
			p.Exited += (s, e) => {
				watcher.Dispose();
			};
			var pi = new ProcessStartInfo(path + filename);
			p.StartInfo = pi;
			p.Start();
		}

		void SetStructureObjects(ResultCollection collection) {
			tlvStructure.SetObjects(collection);

			switch (Settings.I.AutoExpand) {
				case Settings.AutoExpandType.None:
					break;
				case Settings.AutoExpandType.Bitfields:
					foreach (var v in collection)
						if (v.Type == NodeType.Bitfield)
							tlvStructure.Expand(v);
					break;
				case Settings.AutoExpandType.All:
					tlvStructure.ExpandAll();
					break;
			}
		}
	}
}