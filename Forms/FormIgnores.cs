using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ostara {
	public partial class FormIgnores : Form {
		public BindingList<ushort> Opcodes;

		public FormIgnores() {
			InitializeComponent();

			Opcodes = new BindingList<ushort>(Ignores.I.Values);
			listOpcodes.DataSource = Opcodes;
		}

		void btnAdd_Click(object sender, EventArgs e) {
			var dlg = new FormIgnorePrompt();

			if (dlg.ShowDialog() == DialogResult.Cancel)
				return;

			if (!Opcodes.Contains(dlg.Opcode))
				Opcodes.Add(dlg.Opcode);

			dlg.Dispose();
		}

		void btnRemove_Click(object sender, EventArgs e) {
			if (listOpcodes.SelectedIndex != -1)
				Opcodes.RemoveAt(listOpcodes.SelectedIndex);
		}
	}
}