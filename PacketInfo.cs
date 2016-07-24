using System;

using static Ostara.Daemon;

namespace Ostara {
	class PacketInfo {
		public readonly byte[] Data;
		public readonly ushort Sig;
		public readonly uint Length;
		public readonly uint CRC;
		public readonly ushort Opcode;
		public readonly DateTime Time;
		public readonly Daemon Source;
		public readonly Daemon Destination;

		public bool IsExt => Sig == 0xC8F3;
		public bool IsIncoming => Destination == Client;

		public string Comment {
			get {
				if (Source == Client) {
					if (Destination == Login && Comments.I.OutgoingL.ContainsKey(Opcode))
						return Comments.I.OutgoingL[Opcode];
					else if (Destination == World && Comments.I.OutgoingW.ContainsKey(Opcode))
						return Comments.I.OutgoingW[Opcode];
					else if (Destination == Chat && Comments.I.OutgoingC.ContainsKey(Opcode))
						return Comments.I.OutgoingC[Opcode];
					else if (Destination == Auction && Comments.I.OutgoingA.ContainsKey(Opcode))
						return Comments.I.OutgoingA[Opcode];
				}
				else {
					if (Source == Login && Comments.I.IncomingL.ContainsKey(Opcode))
						return Comments.I.IncomingL[Opcode];
					else if (Source == World && Comments.I.IncomingW.ContainsKey(Opcode))
						return Comments.I.IncomingW[Opcode];
					else if (Source == Chat && Comments.I.IncomingC.ContainsKey(Opcode))
						return Comments.I.IncomingC[Opcode];
					else if (Source == Auction && Comments.I.IncomingA.ContainsKey(Opcode))
						return Comments.I.IncomingA[Opcode];
				}

				return "";
			}
			set {
				if (Source == Client) {
					switch (Destination) {
						case Login:
							Comments.I.OutgoingL[Opcode] = value;
							break;
						case World:
							Comments.I.OutgoingW[Opcode] = value;
							break;
						case Chat:
							Comments.I.OutgoingC[Opcode] = value;
							break;
						default:
							Comments.I.OutgoingA[Opcode] = value;
							break;
					}
				}
				else {
					switch (Source) {
						case Login:
							Comments.I.IncomingL[Opcode] = value;
							break;
						case World:
							Comments.I.IncomingW[Opcode] = value;
							break;
						case Chat:
							Comments.I.IncomingC[Opcode] = value;
							break;
						default:
							Comments.I.IncomingA[Opcode] = value;
							break;
					}
				}

				Comments.I.Save(this);
			}
		}

		PacketInfo(DateTime time, ushort opcode, uint length, Daemon source, Daemon destination) {
			Time = time;
			Opcode = opcode;
			Length = length;
			Source = source;
			Destination = destination;
		}

		public PacketInfo(byte[] data, DateTime time, Daemon source, Daemon destination) {
			Data = data;
			Time = time;
			Source = source;
			Destination = destination;

			var inc = Destination == Daemon.Client;

			unsafe
			{
				fixed (byte* pd = data)
				{
					Sig = *(ushort*)&pd[0];

					if (IsExt)
						Length = *(uint*)&pd[2];
					else
						Length = *(ushort*)&pd[2];

					Opcode = *(ushort*)&pd[(IsExt) ? 6 : (inc) ? 4 : 8];

					if (!inc)
						CRC = *(uint*)&pd[4];
				}
			}
		}

		public static PacketInfo Fake(DateTime time, ushort opcode, uint length, Daemon source, Daemon destination) =>
			new PacketInfo(time, opcode, length, source, destination);
	}
}