using System.IO;

using static System.IO.File;
using static System.Windows.Forms.Application;

namespace Ostara {
	class Settings : Singleton<Settings> {
		public enum AutoExpandType { None, Bitfields, All }

		public int NetworkInterface;
		public string ServerIP;
		public ushort ServerPort;
		public bool ClearOnStart;
		public byte BytesPerLine;
		public AutoExpandType AutoExpand;

		public void Load() {
			var file = $"{UserAppDataPath}/settings.op";

			if (!Exists(file)) {
				NetworkInterface = 0;
				ServerIP = "85.93.218.34";  // EU server address
				ServerPort = 38101;
				ClearOnStart = true;
				BytesPerLine = 1;
				AutoExpand = AutoExpandType.None;
				return;
			}

			var f = OpenRead(file);
			var r = new BinaryReader(f);

			NetworkInterface = r.ReadInt32();
			ServerIP = r.ReadString();
			ServerPort = r.ReadUInt16();
			ClearOnStart = r.ReadByte() == 1;
			BytesPerLine = r.ReadByte();
			AutoExpand = (AutoExpandType)r.ReadByte();

			r.Dispose();
		}

		public void Save() {
			var file = $"{UserAppDataPath}/settings.op";

			var f = Create(file);
			var w = new BinaryWriter(f);

			w.Write(NetworkInterface);
			w.Write(ServerIP);
			w.Write(ServerPort);
			w.Write(ClearOnStart ? (byte)1 : (byte)0);
			w.Write(BytesPerLine);
			w.Write((byte)AutoExpand);

			w.Flush();
			w.Close();
			w.Dispose();
		}
	}
}