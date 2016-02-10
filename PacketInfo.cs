using System;

using static Ostara.PacketInfo.Daemon;

namespace Ostara {
	class PacketInfo {
		public enum Daemon {
			Client,
			Login,
			World,
			Chat,
			Auction
		}

		public byte[] Data;
		public ushort Sig { get; set; }
		public int Length { get; set; }
		public uint CRC { get; set; }
		public ushort Opcode { get; set; }
		public DateTime Time { get; set; }
		public Daemon Source { get; set; }
		public Daemon Destination { get; set; }
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
				} else {
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
					if (Destination == Login)
						Comments.I.OutgoingL[Opcode] = value;
					else if (Destination == World)
						Comments.I.OutgoingW[Opcode] = value;
					else if (Destination == Chat)
						Comments.I.OutgoingC[Opcode] = value;
					else
						Comments.I.OutgoingA[Opcode] = value;
				} else {
					if (Source == Login)
						Comments.I.IncomingL[Opcode] = value;
					else if (Source == World)
						Comments.I.IncomingW[Opcode] = value;
					else if (Source == Chat)
						Comments.I.IncomingC[Opcode] = value;
					else
						Comments.I.IncomingA[Opcode] = value;
				}

				Comments.I.Save(this);
			}
		}

		public PacketInfo(byte[] data) {
			Data = data;
			Length = data.Length;

			if (Length == 0)
				return;

			unsafe {
				fixed (byte* pd = data) {
					Sig = *(ushort*)&pd[0];
				}
			}
		}

		public PacketInfo(byte[] data, DateTime time, bool inc, Daemon svc) {
			Data = data;
			Time = time;
			Source = inc ? svc : Client;
			Destination = inc ? Client : svc;
			Length = data.Length;

			unsafe {
				fixed (byte* pd = data) {
					Sig = *(ushort*)&pd[0];
					Opcode = *(ushort*)&pd[(IsExt) ? 6 : (inc) ? 4 : 8];

					if (!inc)
						CRC = *(uint*)&pd[4];
				}
			}
		}
	}
}