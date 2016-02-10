using System.Collections.Generic;
using System.IO;

using static System.IO.Directory;
using static System.IO.Path;
using static Ostara.PacketInfo.Daemon;

namespace Ostara {
	class Comments : Singleton<Comments> {
		public Dictionary<ushort, string> IncomingL, OutgoingL, IncomingW, OutgoingW, IncomingC, OutgoingC, IncomingA, OutgoingA;

		public void Load() {
			IncomingL = new Dictionary<ushort, string>();
			OutgoingL = new Dictionary<ushort, string>();
			IncomingW = new Dictionary<ushort, string>();
			OutgoingW = new Dictionary<ushort, string>();
			IncomingC = new Dictionary<ushort, string>();
			OutgoingC = new Dictionary<ushort, string>();
			IncomingA = new Dictionary<ushort, string>();
			OutgoingA = new Dictionary<ushort, string>();

			if (!Exists("cfg/comments"))
				return;

			var files = GetFiles("cfg/comments");

			foreach (var file in files) {
				var com = new StreamReader(file).ReadToEnd();
				var arr = GetFileName(file).Split('.');
				var op = ushort.Parse(arr[0]);
				var inc = arr[1] == "i";
				var isl = arr[2] == "l";
				var isw = arr[2] == "w";
				var isc = arr[2] == "c";
				var isa = arr[2] == "a";

				if (inc) {
					if (isl)
						IncomingL[op] = com;
					else if (isw)
						IncomingW[op] = com;
					else if (isc)
						IncomingC[op] = com;
					else
						IncomingA[op] = com;
				} else {
					if (isl)
						OutgoingL[op] = com;
					else if (isw)
						OutgoingW[op] = com;
					else if (isc)
						OutgoingC[op] = com;
					else
						OutgoingA[op] = com;
				}
			}
		}

		public void Save(PacketInfo packet) {
			if (!Exists("cfg/comments"))
				CreateDirectory("cfg/comments");

			var inc = packet.Destination == Client;
			var isl = (inc ? packet.Source : packet.Destination) == Login;
			var isw = (inc ? packet.Source : packet.Destination) == World;
			var isc = (inc ? packet.Source : packet.Destination) == Chat;
			var isa = (inc ? packet.Source : packet.Destination) == Auction;

			var file = $"cfg/comments/{packet.Opcode}.{(inc ? 'i' : 'o')}.{(isl ? 'l' : isw ? 'w' : isc ? 'c' : 'a')}.op";

			var w = new StreamWriter(file);

			if (inc)
				w.Write(isl ? IncomingL[packet.Opcode] : isw ? IncomingW[packet.Opcode] : isc ? IncomingC[packet.Opcode] : IncomingA[packet.Opcode]);
			else
				w.Write(isl ? OutgoingL[packet.Opcode] : isw ? OutgoingW[packet.Opcode] : isc ? OutgoingC[packet.Opcode] : OutgoingA[packet.Opcode]);

			w.Flush();
			w.Close();
			w.Dispose();
		}
	}
}