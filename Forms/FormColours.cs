using System;
using System.Collections.Generic;
using System.Windows.Forms;

using static Ostara.PacketInfo;
using static Ostara.PacketInfo.Daemon;

using Key = System.Tuple<Ostara.PacketInfo.Daemon, Ostara.PacketInfo.Daemon>;
using Val = System.Tuple<System.Drawing.Color, System.Drawing.Color>;

namespace Ostara {
	partial class FormColours : Form {
		public Dictionary<Key, Val> Pairs;

		public FormColours() {
			InitializeComponent();

			Pairs = new Dictionary<Key, Val>(Colours.I.Pairs);
			var data = new PacketInfo[8];

			for (int i = 0; i < 8; i++) {
				data[i] = new PacketInfo(new byte[] { });
				data[i].Time = DateTime.Now;
				data[i].Length = 42;
				data[i].Source = (i < 4) ? Client : (Daemon)(i - 3);
				data[i].Destination = (i < 4) ? (Daemon)(i + 1) : Client;
				data[i].Opcode = 1337;
			}

			olvPreview.SetObjects(data);

			SetComboColours(cpC2LFG, cpC2LBG, Client, Login);
			SetComboColours(cpC2WFG, cpC2WBG, Client, World);
			SetComboColours(cpC2CHFG, cpC2CHBG, Client, Chat);
			SetComboColours(cpC2AFG, cpC2ABG, Client, Auction);
			SetComboColours(cpL2CFG, cpL2CBG, Login, Client);
			SetComboColours(cpW2CFG, cpW2CBG, World, Client);
			SetComboColours(cpCH2CFG, cpCH2CBG, Chat, Client);
			SetComboColours(cpA2CFG, cpA2CBG, Auction, Client);
		}

		void SetComboColours(Owf.Controls.Office2007ColorPicker fg, Owf.Controls.Office2007ColorPicker bg, Daemon src, Daemon dest) {
			var k = new Key(src, dest);
			fg.Color = Pairs[k].Item1;
			bg.Color = Pairs[k].Item2;
		}

		void cp_SelectedColorChanged(object sender, EventArgs e) {
			var ctrl = (Owf.Controls.Office2007ColorPicker)sender;
			var t = ctrl.TabIndex;
			int i = t / 2;
			t &= 1;
			var s = (i < 4) ? Client : (Daemon)(i - 3);
			var d = (i < 4) ? (Daemon)(i + 1) : Client;
			var k = new Key(s, d);

			if (t == 0)
				Pairs[k] = new Val(ctrl.Color, Pairs[k].Item2);
			else
				Pairs[k] = new Val(Pairs[k].Item1, ctrl.Color);

			olvPreview.RedrawItems(i, i, false);
		}

		void olvPreview_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e) {
			var m = (PacketInfo)e.Model;
			var k = new Key(m.Source, m.Destination);
			e.Item.ForeColor = Pairs[k].Item1;
			e.Item.BackColor = Pairs[k].Item2;
		}
	}
}