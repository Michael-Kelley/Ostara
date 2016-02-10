using System.Collections.Generic;

namespace Ostara
{
	class Ports : Singleton<Ports> {
		public List<ushort> LoginPorts, WorldPortsStart, WorldPortsEnd, ChatPorts, AuctionPorts;

		public string Filter { get; private set; }

		public void Load() {
			LoginPorts = new List<ushort>();
			WorldPortsStart = new List<ushort>();
			WorldPortsEnd = new List<ushort>();
			ChatPorts = new List<ushort>();
			AuctionPorts = new List<ushort>();

			var ini = new IniReader("cfg/ports.ini");

			ini.Select("Ports");

			string[] login = ini.ReadString("Login").Split(',');
			string[] worldStart = ini.ReadString("WorldStart").Split(',');
			string[] worldEnd = ini.ReadString("WorldEnd").Split(',');
			string[] chat = ini.ReadString("Chat").Split(',');
			string[] auction = ini.ReadString("Auction").Split(',');

			foreach (var s in login)
				LoginPorts.Add(ushort.Parse(s));
			foreach (var s in worldStart)
				WorldPortsStart.Add(ushort.Parse(s));
			foreach (var s in worldEnd)
				WorldPortsEnd.Add(ushort.Parse(s));
			foreach (var s in chat)
				ChatPorts.Add(ushort.Parse(s));
			foreach (var s in auction)
				AuctionPorts.Add(ushort.Parse(s));

			GenerateFilter();
		}

		void GenerateFilter() {
			Filter = "ip and tcp and (";

			for (int i = 0; i < LoginPorts.Count; i++)
				Filter += $"port {LoginPorts[i]} or ";

			for (int i = 0; i < WorldPortsStart.Count; i++)
				for (int j = WorldPortsStart[i]; j <= WorldPortsEnd[i]; j++)
					Filter += $"port {j} or ";

			for (int i = 0; i < ChatPorts.Count; i++)
				Filter += $"port {ChatPorts[i]} or ";

			for (int i = 0; i < AuctionPorts.Count; i++) {
				Filter += $"port {AuctionPorts[i]}";

				if (i < AuctionPorts.Count - 1)
					Filter += " or ";
			}

			Filter += ")";
		}
	}
}