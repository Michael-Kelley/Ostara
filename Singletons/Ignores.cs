using System.Collections.Generic;
using System.IO;

using static System.IO.File;
using static System.Text.Encoding;
using static System.Windows.Forms.Application;

namespace Ostara {
	class Ignores : Singleton<Ignores> {
		public List<ushort> Values;

		public void Load() {
			Values = new List<ushort>();

			var file = $"{UserAppDataPath}/ignores.op";

			if (!Exists(file))
				return;

			var f = OpenRead(file);
			var r = new BinaryReader(f, ASCII);

			while (r.PeekChar() != -1)
				Values.Add(r.ReadUInt16());

			r.Dispose();
		}

		public void Save() {
			if (Values.Count == 0)
				return;

			var file = $"{UserAppDataPath}/ignores.op";

			var f = Create(file);
			var w = new BinaryWriter(f, ASCII);

			foreach (var v in Values)
				w.Write(v);

			w.Flush();
			w.Close();
			w.Dispose();
		}
	}
}