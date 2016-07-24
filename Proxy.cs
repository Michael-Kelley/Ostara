using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ostara {
	unsafe class Proxy {
		public event EventHandler<EventArgs> OnConnect;
		public event EventHandler<EventArgs> OnDisconnect;
		public event EventHandler<PacketEventArgs> OnReceivePacket;

		readonly Daemon daemon;
		readonly IPAddress localIP, remoteIP;
		readonly ushort localPort, remotePort;

		TcpClient localClient, remoteClient;

		public LocalCryption LocalCrypt;
		public RemoteCryption RemoteCrypt;

		public Proxy(Daemon daemon, IPAddress localIP, ushort localPort, IPAddress remoteIP, ushort remotePort) {
			this.daemon = daemon;
			this.localIP = localIP;
			this.localPort = localPort;
			this.remoteIP = remoteIP;
			this.remotePort = remotePort;

			Start();
		}

		public void Start() {
			var listener = new TcpListener(localIP, localPort);
			listener.Start();

			localClient = listener.AcceptTcpClient();
			var localStream = localClient.GetStream();
			LocalCrypt = new LocalCryption();

			remoteClient = new TcpClient();
			remoteClient.Connect(remoteIP, remotePort);
			var remoteStream = remoteClient.GetStream();
			RemoteCrypt = new RemoteCryption();

			listener.Stop();

			OnConnect?.Invoke(this, EventArgs.Empty);

			Task.Run(() => {
				var data = new byte[256];

				while (true) {
					int read;
#if !DEBUG
					try {
#endif
					read = localStream.Read(data, 0, 8);

					if (read == 0)
						break;

					var size = LocalCrypt.GetPacketSize(data, 0);

					if (size > data.Length) {
						var l = size.NextPow2();
						Array.Resize(ref data, (int)l);
					}

					if (size > 8) {
						read += localStream.Read(data, 8, (int)size - 8);

						while (read < size)
							read += localStream.Read(data, read, (int)size - read);

						if (read == 0)
							break;
					}
#if !DEBUG
					}
					catch (Exception e) {
						break;
					}
#endif

					var packet = new byte[read];

					fixed (byte* ppacket = packet, pdata = data)
						IL.Cpblk(ppacket, pdata, (uint)read);

					LocalCrypt.Decrypt(packet, 0, read);

					var evt = new PacketEventArgs() {
						Packet = new PacketInfo(packet, DateTime.Now, Daemon.Client, daemon)
					};
					OnReceivePacket?.Invoke(this, evt);
					read = (int)evt.Packet.Length;
					packet = new byte[read];

					fixed (byte* ppacket = packet, pdata = evt.Packet.Data)
						IL.Cpblk(ppacket, pdata, (uint)read);

					RemoteCrypt.Encrypt(packet, 0, read);
					remoteStream.Write(packet, 0, read);
					evt.OnSend?.Invoke();
				}

#if DEBUG
				Console.WriteLine("Client disconnected");
#endif

				if (localClient.Connected)
					localClient.Close();

				OnDisconnect?.Invoke(this, EventArgs.Empty);
			});

			Task.Run(() => {
				var data = new byte[256];

				while (true) {
					int read;
#if !DEBUG
					try {
#endif
					read = remoteStream.Read(data, 0, 8);

					if (read == 0)
						break;

					var size = RemoteCrypt.GetPacketSize(data, 0);

					if (size == 0) {
						read += remoteStream.Read(data, read, data.Length - read);
						Console.WriteLine($"Dropping invalid packet from {daemon} of length {read}:");
						var file = System.IO.File.CreateText($"dropped_packet_{DateTime.UtcNow.ToBinary()}.log");

						for (var i = 0; i < read; i++)
							file.Write($"{data[i]}, ");

						file.WriteLine('\n');

						RemoteCrypt.Decrypt(data, 0, read);

						for (var i = 0; i < read; i++)
							file.Write($"{data[i]}, ");

						file.WriteLine('\n');
						file.Flush();
						file.Close();
						file.Dispose();

						continue;
					}

					if (size > data.Length) {
						var l = size.NextPow2();
						Array.Resize(ref data, (int)l);
					}

					if (size > 8) {
						read += remoteStream.Read(data, 8, (int)size - 8);

						while (read < size) {
							Console.WriteLine($"Found partial packet. Read = {read}, Size = {size}");
							read += remoteStream.Read(data, read, (int)size - read);
						}

						if (read == 0)
							break;
					}
#if !DEBUG
					}
					catch (Exception e) {
						break;
					}
#endif

					var packet = new byte[read];

					fixed (byte* ppacket = packet, pdata = data)
						IL.Cpblk(ppacket, pdata, (uint)read);

					RemoteCrypt.Decrypt(packet, 0, read);
					var evt = new PacketEventArgs() {
						Packet = new PacketInfo(packet, DateTime.Now, daemon, Daemon.Client)
					};
					OnReceivePacket?.Invoke(this, evt);
					read = (int)evt.Packet.Length;
					packet = new byte[read];

					fixed (byte* ppacket = packet, pdata = evt.Packet.Data)
						IL.Cpblk(ppacket, pdata, (uint)read);

					LocalCrypt.Encrypt(packet, 0, read);
					localStream.Write(packet, 0, read);
					evt.OnSend?.Invoke();
				}

#if DEBUG
				Console.WriteLine("Server disconnected");
#endif

				if (remoteClient.Connected)
					remoteClient.Close();
			});
		}

		public void Stop() {
			localClient.Close();
			remoteClient.Close();
		}
	}
}