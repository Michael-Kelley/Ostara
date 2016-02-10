using System.IO;

using static System.IO.File;
using static System.Windows.Forms.Application;

namespace Ostara {
	class Settings : Singleton<Settings> {
		public bool ClearOnStart;
		public int FormStructureWidth, FormStructureHeight;
		public byte BytesPerLine;

		public void Load() {
			var file = $"{UserAppDataPath}/settings.op";

			if (!Exists(file)) {
				ClearOnStart = true;
				FormStructureWidth = FormStructureHeight = 256;
				BytesPerLine = 0;
				return;
			}

			var f = OpenRead(file);
			var r = new BinaryReader(f);

			ClearOnStart = r.ReadByte() == 1;
			FormStructureWidth = r.ReadInt32();
			FormStructureHeight = r.ReadInt32();
			BytesPerLine = r.ReadByte();

			r.Dispose();
		}

		public void Save() {
			var file = $"{UserAppDataPath}/settings.op";

			var f = Create(file);
			var w = new BinaryWriter(f);

			w.Write(ClearOnStart ? (byte)1 : (byte)0);
			w.Write(FormStructureWidth);
			w.Write(FormStructureHeight);
			w.Write(BytesPerLine);

			w.Flush();
			w.Close();
			w.Dispose();
		}
	}
}