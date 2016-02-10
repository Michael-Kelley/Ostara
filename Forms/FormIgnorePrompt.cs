using System;
using System.Windows.Forms;

namespace Ostara {
	public partial class FormIgnorePrompt : Form {
		public ushort Opcode;

		public FormIgnorePrompt() {
			InitializeComponent();
		}

		void txtOpcode_KeyPress(object sender, KeyPressEventArgs e) {
			if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '\b')) {
				e.Handled = true;
				return;
			}

			if (char.IsDigit(e.KeyChar) && int.Parse(txtOpcode.Text + e.KeyChar) > ushort.MaxValue)
				e.Handled = true;					
		}

		void txtOpcode_TextChanged(object sender, EventArgs e) {
			if (txtOpcode.Text == "")
				Opcode = 0;
			else
				Opcode = ushort.Parse(txtOpcode.Text);
		}
	}
}
