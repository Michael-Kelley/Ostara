using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

using BrightIdeasSoftware;

using static System.Drawing.Color;
using static System.IO.File;
using static System.Windows.Forms.Application;
using static Ostara.Daemon;

using Key = System.Tuple<Ostara.Daemon, Ostara.Daemon>;
using Val = System.Tuple<System.Drawing.Color, System.Drawing.Color>;

namespace Ostara {
	class Colours : Singleton<Colours> {
		public Dictionary<Key, Val> Pairs;

		public void Load() {
			var file = $"{UserAppDataPath}/colours.op";

			if (!Exists(file)) {
				SetDefault();
				return;
			}

			var f = OpenRead(file);
			var b = new BinaryFormatter();
			Pairs = (Dictionary<Key, Val>)b.Deserialize(f);

			f.Dispose();
		}

		public void Save() {
			var file = $"{UserAppDataPath}/colours.op";

			var f = Create(file);
			var b = new BinaryFormatter();
			b.Serialize(f, Pairs);

			f.Flush();
			f.Close();
			f.Dispose();
		}

		public void FormatRow(OLVListItem r, Daemon src, Daemon dst) {
			var p = Pairs[new Key(src, dst)];
			r.ForeColor = p.Item1;
			r.BackColor = p.Item2;
		}

		void SetDefault() {
			Pairs = new Dictionary<Key, Val>();

			Pairs[new Key(Client, Login)] = new Val(OrangeRed, White);
			Pairs[new Key(Client, World)] = new Val(CadetBlue, White);
			Pairs[new Key(Client, Chat)] = new Val(SeaGreen, White);
			Pairs[new Key(Client, Auction)] = new Val(MediumPurple, White);
			Pairs[new Key(Login, Client)] = new Val(White, OrangeRed);
			Pairs[new Key(World, Client)] = new Val(White, CadetBlue);
			Pairs[new Key(Chat, Client)] = new Val(White, SeaGreen);
			Pairs[new Key(Auction, Client)] = new Val(White, MediumPurple);

			Save();
		}
	}
}