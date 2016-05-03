using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

using BeeSchema;
using Be.Windows.Forms;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using System.IO;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Ostara {
	partial class FormMain : Form {
		class PacketClass {
			public TcpDatagram Tcp;
			public bool IsIncoming;
			public PacketInfo.Daemon Daemon;
			public ushort Port;

			public PacketClass(TcpDatagram tcp, bool inc, PacketInfo.Daemon daemon, ushort port) {
				Tcp = tcp;
				IsIncoming = inc;
				Daemon = daemon;
				Port = port;
			}
		}

		LivePacketDevice device;
		PacketCommunicator comm;
		uint address;

		byte[] partil, partiw, partic, partia,
			   partol, partow, partoc, partoa;

		Dictionary<ushort, Cryption.Client> clientCrypt;
		Dictionary<ushort, Cryption.Server> serverCrypt;

		ushort[] ports = { 0, 0, 0, 0 };

		bool paused, stop;
		Queue<PacketClass> packets;

		public FormMain() {
			InitializeComponent();

			Settings.I.Load();
			Ports.I.Load();
			Colours.I.Load();
			Ignores.I.Load();
			Comments.I.Load();

			tsbClearOnStart.Checked = Settings.I.ClearOnStart;
			hexView.BytesPerLine = (Settings.I.BytesPerLine + 1) * 8;
			tableLayoutPanel1.ColumnStyles[1].Width = hexView.RequiredWidth + 17;
			cbBytesPerLine.SelectedIndex = Settings.I.BytesPerLine;

			foreach (var d in LivePacketDevice.AllLocalMachine)
				tscbNet.Items.Add(GetFriendlyDeviceName(d));

			tscbNet.SelectedIndex = 0;

			tlvStructure.CanExpandGetter = (e) => { return ((Result)e).Value is OrderedDictionary; };
			tlvStructure.ChildrenGetter = (e) => { return ((OrderedDictionary)(((Result)e).Value)).Values; };
			olvValue.AspectToStringConverter = (x) => {
				if (x is OrderedDictionary)
					return string.Empty;
				else
					return $"{x}";
			};
		}

		string GetFriendlyDeviceName(PacketDevice d) {
			var nics = NetworkInterface.GetAllNetworkInterfaces();

			foreach (var n in nics) {
				if (d.Name.EndsWith(n.Id))
					return n.Name;
			}

			return d.Name;
		}

		void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			if (comm != null) {
				comm.Break();
				comm.Dispose();
				comm = null;
			}

			Ignores.I.Save();
			Settings.I.Save();
			stop = true;
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

			Colours.I.Pairs = new Dictionary<Tuple<PacketInfo.Daemon, PacketInfo.Daemon>, Tuple<Color, Color>>(dlg.Pairs);
			Colours.I.Save();
			flvPackets.Refresh();

			dlg.Dispose();
		}

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
			stop = false;

			tsbStart.Enabled = tscbNet.Enabled = false;
			tsbPause.Enabled = tsbStop.Enabled = true;

			this.Text = "Ostara - Logging";

			if (paused) {
				paused = false;
				return;
			}

			if (Settings.I.ClearOnStart)
				flvPackets.ClearObjects();

			packets = new Queue<PacketClass>();
			clientCrypt = new Dictionary<ushort, Cryption.Client>();
			serverCrypt = new Dictionary<ushort, Cryption.Server>();

			int ni = tscbNet.SelectedIndex;

			device = LivePacketDevice.AllLocalMachine[ni];
			comm = device.Open(65536, PacketDeviceOpenAttributes.None, 500);
			comm.SetFilter(Ports.I.Filter);

			foreach (var a in device.Addresses) {
				if (a.Address.Family == SocketAddressFamily.Internet) {
					address = ((IpV4SocketAddress)a.Address).Address.ToValue();
					break;
				}
			}

			Task.Run(() => { GetPackets(); });
		}

		void GetPackets() {
			Packet p;

			try {
				while (!stop) {
					var succ = comm.ReceivePacket(out p);

					if (succ == PacketCommunicatorReceiveResult.Timeout) {
						DumpPackets();
						continue;
					}
					else if (succ == PacketCommunicatorReceiveResult.BreakLoop)
						break;

					var ip = p.Ethernet.IpV4;
					var tcp = ip.Tcp;
					var data = tcp.Payload.ToMemoryStream();

					if (data.Length == 0) {
#if DEBUG
						//Console.WriteLine("Dropped packet of length 0");
#endif
						continue;
					}

#if DEBUG
					//Console.WriteLine($"Caught packet of length {data.Length} from {ip.Source}");
					//Console.WriteLine($"SEQ: {tcp.SequenceNumber}, ACK: {tcp.AcknowledgmentNumber}, Time: {p.Timestamp.Ticks}");
#endif

					var inc = IsIncoming(ip);
					var isl = IsLogin(tcp, inc);
					var isw = IsWorld(tcp, inc);
					var isc = IsChat(tcp, inc);
					var isa = IsAuction(tcp, inc);

					ushort port = (inc)
						? tcp.SourcePort
						: tcp.DestinationPort;

					ushort lport = (inc)
						? tcp.DestinationPort
						: tcp.SourcePort;

					if (!clientCrypt.ContainsKey(port) || ((isl && lport != ports[0]) || (isw && lport != ports[1]) || (isc && lport != ports[2] || (isa && lport != ports[3])))) {
#if DEBUG
						Console.WriteLine($"Creating new encryption instances for [{ip.Source} - {ip.Destination}]");
#endif
						clientCrypt[port] = new Cryption.Client();
						serverCrypt[port] = new Cryption.Server();

						if (isl) {
							ports[0] = lport;
							partil = null;
							partol = null;
						}
						else if (isw) {
							ports[1] = lport;
							partiw = null;
							partow = null;
						}
						else if (isc) {
							ports[2] = lport;
							partic = null;
							partoc = null;
						}
						else {
							ports[3] = lport;
							partia = null;
							partoa = null;
						}
					}

					var daemon =
						(isl) ? PacketInfo.Daemon.Login :
						(isw) ? PacketInfo.Daemon.World :
						(isc) ? PacketInfo.Daemon.Chat :
						PacketInfo.Daemon.Auction;

					AddPacket(tcp, inc, daemon, port);
				}
			}
			catch (Exception) { }
		}

		void AddPacket(TcpDatagram tcp, bool inc, PacketInfo.Daemon daemon, ushort port) {
			foreach (var p in packets) {
				if (p.Tcp.SequenceNumber == tcp.SequenceNumber) {
#if DEBUG
					Console.WriteLine("Dropping duplicate packet...");
#endif
					return;
				}
			}

			packets.Enqueue(new PacketClass(tcp, inc, daemon, port));

			if (packets.Count > 10) {
				var p = packets.Dequeue();
				var data = p.Tcp.Payload.ToMemoryStream();
				ProcessPacket(data.ToArray(), p.IsIncoming, p.Daemon, p.Port);
			}
		}

		void DumpPackets() {
			while (packets.Count > 0) {
				var p = packets.Dequeue();
				var data = p.Tcp.Payload.ToMemoryStream();
				ProcessPacket(data.ToArray(), p.IsIncoming, p.Daemon, p.Port);
			}
		}

		void ProcessPacket(byte[] data, bool inc, PacketInfo.Daemon daemon, ushort port) {
			int s;
			byte[] tmp;

			if (inc) {
				switch (daemon) {
					case PacketInfo.Daemon.Login:
						if (partil == null)
							break;

						s = partil.Length + data.Length;
						tmp = new byte[s];
						Array.ConstrainedCopy(partil, 0, tmp, 0, partil.Length);
						Array.ConstrainedCopy(data, 0, tmp, partil.Length, data.Length);
						data = tmp;
						partil = null;
						break;
					case PacketInfo.Daemon.World:
						if (partiw == null)
							break;

						s = partiw.Length + data.Length;
						tmp = new byte[s];
						Array.ConstrainedCopy(partiw, 0, tmp, 0, partiw.Length);
						Array.ConstrainedCopy(data, 0, tmp, partiw.Length, data.Length);
						data = tmp;
						partiw = null;
						break;
					case PacketInfo.Daemon.Chat:
						if (partic == null)
							break;

						s = partic.Length + data.Length;
						tmp = new byte[s];
						Array.ConstrainedCopy(partic, 0, tmp, 0, partic.Length);
						Array.ConstrainedCopy(data, 0, tmp, partic.Length, data.Length);
						data = tmp;
						partic = null;
						break;
					case PacketInfo.Daemon.Auction:
						if (partia == null)
							break;

						s = partia.Length + data.Length;
						tmp = new byte[s];
						Array.ConstrainedCopy(partia, 0, tmp, 0, partia.Length);
						Array.ConstrainedCopy(data, 0, tmp, partia.Length, data.Length);
						data = tmp;
						partia = null;
						break;
				}
			}
			else {
				switch (daemon) {
					case PacketInfo.Daemon.Login:
						if (partol == null)
							break;

						s = partol.Length + data.Length;
						tmp = new byte[s];
						Array.ConstrainedCopy(partol, 0, tmp, 0, partol.Length);
						Array.ConstrainedCopy(data, 0, tmp, partol.Length, data.Length);
						data = tmp;
						partol = null;
						break;
					case PacketInfo.Daemon.World:
						if (partow == null)
							break;

						s = partow.Length + data.Length;
						tmp = new byte[s];
						Array.ConstrainedCopy(partow, 0, tmp, 0, partow.Length);
						Array.ConstrainedCopy(data, 0, tmp, partow.Length, data.Length);
						data = tmp;
						partow = null;
						break;
					case PacketInfo.Daemon.Chat:
						if (partoc == null)
							break;

						s = partoc.Length + data.Length;
						tmp = new byte[s];
						Array.ConstrainedCopy(partoc, 0, tmp, 0, partoc.Length);
						Array.ConstrainedCopy(data, 0, tmp, partoc.Length, data.Length);
						data = tmp;
						partoc = null;
						break;
					case PacketInfo.Daemon.Auction:
						if (partoa == null)
							break;

						s = partoa.Length + data.Length;
						tmp = new byte[s];
						Array.ConstrainedCopy(partoa, 0, tmp, 0, partoa.Length);
						Array.ConstrainedCopy(data, 0, tmp, partoa.Length, data.Length);
						data = tmp;
						partoa = null;
						break;
				}
			}

			var size = (inc)
				? serverCrypt[port].GetPacketSize(data)
				: clientCrypt[port].GetPacketSize(data);

			if (size > data.Length) {
#if DEBUG
				//Console.WriteLine("Found partial packet. Storing...");
#endif

				if (inc) {
					if (daemon == PacketInfo.Daemon.Login) {
						partil = new byte[data.Length];
						Array.ConstrainedCopy(data, 0, partil, 0, data.Length);
					}
					else if (daemon == PacketInfo.Daemon.World) {
						partiw = new byte[data.Length];
						Array.ConstrainedCopy(data, 0, partiw, 0, data.Length);
					}
					else if (daemon == PacketInfo.Daemon.Chat) {
						partic = new byte[data.Length];
						Array.ConstrainedCopy(data, 0, partic, 0, data.Length);
					}
					else if (daemon == PacketInfo.Daemon.Auction) {
						partia = new byte[data.Length];
						Array.ConstrainedCopy(data, 0, partia, 0, data.Length);
					}
				}
				else {
					if (daemon == PacketInfo.Daemon.Login) {
						partol = new byte[data.Length];
						Array.ConstrainedCopy(data, 0, partol, 0, data.Length);
					}
					else if (daemon == PacketInfo.Daemon.World) {
						partow = new byte[data.Length];
						Array.ConstrainedCopy(data, 0, partow, 0, data.Length);
					}
					else if (daemon == PacketInfo.Daemon.Chat) {
						partoc = new byte[data.Length];
						Array.ConstrainedCopy(data, 0, partoc, 0, data.Length);
					}
					else if (daemon == PacketInfo.Daemon.Auction) {
						partoa = new byte[data.Length];
						Array.ConstrainedCopy(data, 0, partoa, 0, data.Length);
					}
				}

				return;
			}

			if (size < data.Length) {
				// Process the first subpacket
				var sub = new byte[size];
				Array.ConstrainedCopy(data, 0, sub, 0, size);
				ProcessPacket(sub, inc, daemon, port);

				// Process the rest of the data.  May contain further subpackets, or a partial packet.  We don't care
				sub = new byte[data.Length - size];
				Array.ConstrainedCopy(data, size, sub, 0, data.Length - size);
				ProcessPacket(sub, inc, daemon, port);

				return;
			}

			if (inc)
				serverCrypt[port].Decrypt(data);
			else
				clientCrypt[port].Decrypt(data);

			var ppkt = new PacketInfo(data, DateTime.Now, inc, daemon);

			if (inc && ((ppkt.Opcode == 101 && daemon == PacketInfo.Daemon.Login) ||
						(ppkt.Opcode == 140 && daemon == PacketInfo.Daemon.World) ||
						(ppkt.Opcode == 401 && daemon == PacketInfo.Daemon.Chat) ||
						(ppkt.Opcode == 101 && daemon == PacketInfo.Daemon.Auction))) {
				unsafe
				{
					fixed (byte* pp = data)
					{
						var key = *(uint*)&pp[6];
						var step = *(ushort*)&pp[16];

						serverCrypt[port].ChangeKey(key, step);
						clientCrypt[port].ChangeKey(key, step);
					}
				}
			}

			if (!paused) {
				if (flvPackets.InvokeRequired)
					this.Invoke(new AddPacketDel(AddPacket), new object[] { ppkt });
				else
					AddPacket(ppkt);
			}
		}

		void tsbPause_Click(object sender, EventArgs e) {
			paused = true;
			tsbPause.Enabled = false;
			tsbStart.Enabled = true;

			this.Text = "Ostara - Paused";
		}

		void tsbStop_Click(object sender, EventArgs e) {
			stop = true;
			paused = false;

			comm.Break();
			comm.Dispose();
			device = null;
			comm = null;

			tsbStart.Enabled = tscbNet.Enabled = true;
			tsbPause.Enabled = tsbStop.Enabled = false;

			this.Text = "Ostara - Stopped";
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
				tlvStructure.SetObjects(ParsePacketData(pi));
				tlvStructure.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
			}
		}

		ICollection ParsePacketData(PacketInfo packet) {
			var filename = $"cfg\\structs\\{GetSchemaFilename(packet)}";

			if (!File.Exists(filename))
				return null;

			var schema = Schema.FromFile(filename);
			var parsed = schema.Parse(packet.Data);

			return parsed.Values;
		}

		string GetSchemaFilename(PacketInfo packet) {
			PacketInfo.Daemon daemon;
			var opcode = packet.Opcode;

			if (packet.IsIncoming)
				daemon = packet.Source;
			else
				daemon = packet.Destination;

			var dchar =
				(daemon == PacketInfo.Daemon.Auction) ? 'a' :
				(daemon == PacketInfo.Daemon.Chat) ? 'c' :
				(daemon == PacketInfo.Daemon.Login) ? 'l' :
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

			fixed (byte* p = ((PacketInfo)flvPackets.SelectedObject).Data)
			{
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

		void AddPacket(PacketInfo p) {
			if (!Ignores.I.Values.Contains(p.Opcode))
				flvPackets.AddObject(p);
		}

		delegate void AddPacketDel(PacketInfo p);

		void ClearInspector() {
			inspByte.Text = inspSByte.Text = inspShort.Text = inspUShort.Text =
			inspInt.Text = inspUInt.Text = inspLong.Text = inspULong.Text =
			inspFloat.Text = inspDouble.Text = "";
		}

		bool IsIncoming(IpV4Datagram ip)
			=> address == ip.Destination.ToValue();

		bool IsLogin(TcpDatagram tcp, bool inc)
			=> Ports.I.LoginPorts.Contains(inc ? tcp.SourcePort : tcp.DestinationPort);

		bool IsWorld(TcpDatagram tcp, bool inc) {
			for (int i = 0; i < Ports.I.WorldPortsStart.Count; i++) {
				if (inc) {
					if (tcp.SourcePort >= Ports.I.WorldPortsStart[i] && tcp.SourcePort <= Ports.I.WorldPortsEnd[i])
						return true;
				}
				else {
					if (tcp.DestinationPort >= Ports.I.WorldPortsStart[i] && tcp.DestinationPort <= Ports.I.WorldPortsEnd[i])
						return true;
				}
			}

			return false;
		}

		bool IsChat(TcpDatagram tcp, bool inc)
			=> Ports.I.ChatPorts.Contains(inc ? tcp.SourcePort : tcp.DestinationPort);

		bool IsAuction(TcpDatagram tcp, bool inc)
			=> Ports.I.AuctionPorts.Contains(inc ? tcp.SourcePort : tcp.DestinationPort);

		void EditStructure() {
			var packet = (PacketInfo)flvPackets.SelectedObject;
			var filename = GetSchemaFilename(packet);
			var path = $"{Environment.CurrentDirectory}\\cfg\\structs\\";

			if (!File.Exists(path + filename)) {
				var file = File.CreateText(path + filename);
				file.WriteLine("include header.bee;");
				file.WriteLine();
				file.WriteLine("schema {");
				file.WriteLine("}");
				file.Close();
			}

			var watcher = new FileSystemWatcher(path, filename);
			watcher.NotifyFilter = NotifyFilters.LastWrite;
			watcher.EnableRaisingEvents = true;
			watcher.Changed += async (s, e) => {
				await Task.Delay(500);
				Action a = () => tlvStructure.SetObjects(ParsePacketData(packet));
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
	}
}