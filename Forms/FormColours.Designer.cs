namespace Ostara {
	partial class FormColours {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.olvPreview = new BrightIdeasSoftware.FastObjectListView();
			this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.cpCH2CBG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpCH2CFG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpW2CBG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpW2CFG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpL2CBG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpL2CFG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpC2CHBG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpC2CHFG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpC2WBG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpC2WFG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpC2LBG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpC2LFG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpA2CBG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.label7 = new System.Windows.Forms.Label();
			this.cpA2CFG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.cpC2ABG = new Owf.Controls.Office2007ColorPicker(this.components);
			this.label8 = new System.Windows.Forms.Label();
			this.cpC2AFG = new Owf.Controls.Office2007ColorPicker(this.components);
			((System.ComponentModel.ISupportInitialize)(this.olvPreview)).BeginInit();
			this.SuspendLayout();
			// 
			// olvPreview
			// 
			this.olvPreview.AllColumns.Add(this.olvColumn1);
			this.olvPreview.AllColumns.Add(this.olvColumn2);
			this.olvPreview.AllColumns.Add(this.olvColumn3);
			this.olvPreview.AllColumns.Add(this.olvColumn4);
			this.olvPreview.AllColumns.Add(this.olvColumn5);
			this.olvPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.olvPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5});
			this.olvPreview.Location = new System.Drawing.Point(12, 246);
			this.olvPreview.Name = "olvPreview";
			this.olvPreview.ShowGroups = false;
			this.olvPreview.Size = new System.Drawing.Size(336, 166);
			this.olvPreview.TabIndex = 1;
			this.olvPreview.UseCompatibleStateImageBehavior = false;
			this.olvPreview.View = System.Windows.Forms.View.Details;
			this.olvPreview.VirtualMode = true;
			this.olvPreview.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvPreview_FormatRow);
			// 
			// olvColumn1
			// 
			this.olvColumn1.AspectName = "Time";
			this.olvColumn1.IsEditable = false;
			this.olvColumn1.Text = "Time";
			this.olvColumn1.Width = 114;
			// 
			// olvColumn2
			// 
			this.olvColumn2.AspectName = "Length";
			this.olvColumn2.IsEditable = false;
			this.olvColumn2.Text = "Len";
			this.olvColumn2.Width = 40;
			// 
			// olvColumn3
			// 
			this.olvColumn3.AspectName = "Source";
			this.olvColumn3.IsEditable = false;
			this.olvColumn3.Text = "Source";
			// 
			// olvColumn4
			// 
			this.olvColumn4.AspectName = "Destination";
			this.olvColumn4.IsEditable = false;
			this.olvColumn4.Text = "Dest";
			// 
			// olvColumn5
			// 
			this.olvColumn5.AspectName = "Opcode";
			this.olvColumn5.IsEditable = false;
			this.olvColumn5.Text = "Opcode";
			this.olvColumn5.Width = 54;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(192, 418);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(273, 418);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Client -> Login";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Client -> World";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Client -> Chat";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 117);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Login -> Client";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "World -> Client";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 171);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(70, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "Chat -> Client";
			// 
			// cpCH2CBG
			// 
			this.cpCH2CBG.Color = System.Drawing.Color.Black;
			this.cpCH2CBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpCH2CBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpCH2CBG.FormattingEnabled = true;
			this.cpCH2CBG.Items.AddRange(new object[] {
            "Color"});
			this.cpCH2CBG.Location = new System.Drawing.Point(227, 168);
			this.cpCH2CBG.Name = "cpCH2CBG";
			this.cpCH2CBG.Size = new System.Drawing.Size(121, 21);
			this.cpCH2CBG.TabIndex = 13;
			this.cpCH2CBG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpCH2CFG
			// 
			this.cpCH2CFG.Color = System.Drawing.Color.Black;
			this.cpCH2CFG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpCH2CFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpCH2CFG.FormattingEnabled = true;
			this.cpCH2CFG.Items.AddRange(new object[] {
            "Color"});
			this.cpCH2CFG.Location = new System.Drawing.Point(100, 168);
			this.cpCH2CFG.Name = "cpCH2CFG";
			this.cpCH2CFG.Size = new System.Drawing.Size(121, 21);
			this.cpCH2CFG.TabIndex = 12;
			this.cpCH2CFG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpW2CBG
			// 
			this.cpW2CBG.Color = System.Drawing.Color.Black;
			this.cpW2CBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpW2CBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpW2CBG.FormattingEnabled = true;
			this.cpW2CBG.Items.AddRange(new object[] {
            "Color"});
			this.cpW2CBG.Location = new System.Drawing.Point(227, 141);
			this.cpW2CBG.Name = "cpW2CBG";
			this.cpW2CBG.Size = new System.Drawing.Size(121, 21);
			this.cpW2CBG.TabIndex = 11;
			this.cpW2CBG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpW2CFG
			// 
			this.cpW2CFG.Color = System.Drawing.Color.Black;
			this.cpW2CFG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpW2CFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpW2CFG.FormattingEnabled = true;
			this.cpW2CFG.Items.AddRange(new object[] {
            "Color"});
			this.cpW2CFG.Location = new System.Drawing.Point(100, 141);
			this.cpW2CFG.Name = "cpW2CFG";
			this.cpW2CFG.Size = new System.Drawing.Size(121, 21);
			this.cpW2CFG.TabIndex = 10;
			this.cpW2CFG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpL2CBG
			// 
			this.cpL2CBG.Color = System.Drawing.Color.Black;
			this.cpL2CBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpL2CBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpL2CBG.FormattingEnabled = true;
			this.cpL2CBG.Items.AddRange(new object[] {
            "Color"});
			this.cpL2CBG.Location = new System.Drawing.Point(227, 114);
			this.cpL2CBG.Name = "cpL2CBG";
			this.cpL2CBG.Size = new System.Drawing.Size(121, 21);
			this.cpL2CBG.TabIndex = 9;
			this.cpL2CBG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpL2CFG
			// 
			this.cpL2CFG.Color = System.Drawing.Color.Black;
			this.cpL2CFG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpL2CFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpL2CFG.FormattingEnabled = true;
			this.cpL2CFG.Items.AddRange(new object[] {
            "Color"});
			this.cpL2CFG.Location = new System.Drawing.Point(100, 114);
			this.cpL2CFG.Name = "cpL2CFG";
			this.cpL2CFG.Size = new System.Drawing.Size(121, 21);
			this.cpL2CFG.TabIndex = 8;
			this.cpL2CFG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpC2CHBG
			// 
			this.cpC2CHBG.Color = System.Drawing.Color.Black;
			this.cpC2CHBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpC2CHBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpC2CHBG.FormattingEnabled = true;
			this.cpC2CHBG.Items.AddRange(new object[] {
            "Color"});
			this.cpC2CHBG.Location = new System.Drawing.Point(227, 60);
			this.cpC2CHBG.Name = "cpC2CHBG";
			this.cpC2CHBG.Size = new System.Drawing.Size(121, 21);
			this.cpC2CHBG.TabIndex = 5;
			this.cpC2CHBG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpC2CHFG
			// 
			this.cpC2CHFG.Color = System.Drawing.Color.Black;
			this.cpC2CHFG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpC2CHFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpC2CHFG.FormattingEnabled = true;
			this.cpC2CHFG.Items.AddRange(new object[] {
            "Color"});
			this.cpC2CHFG.Location = new System.Drawing.Point(100, 60);
			this.cpC2CHFG.Name = "cpC2CHFG";
			this.cpC2CHFG.Size = new System.Drawing.Size(121, 21);
			this.cpC2CHFG.TabIndex = 4;
			this.cpC2CHFG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpC2WBG
			// 
			this.cpC2WBG.Color = System.Drawing.Color.Black;
			this.cpC2WBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpC2WBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpC2WBG.FormattingEnabled = true;
			this.cpC2WBG.Items.AddRange(new object[] {
            "Color"});
			this.cpC2WBG.Location = new System.Drawing.Point(227, 33);
			this.cpC2WBG.Name = "cpC2WBG";
			this.cpC2WBG.Size = new System.Drawing.Size(121, 21);
			this.cpC2WBG.TabIndex = 3;
			this.cpC2WBG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpC2WFG
			// 
			this.cpC2WFG.Color = System.Drawing.Color.Black;
			this.cpC2WFG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpC2WFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpC2WFG.FormattingEnabled = true;
			this.cpC2WFG.Items.AddRange(new object[] {
            "Color"});
			this.cpC2WFG.Location = new System.Drawing.Point(100, 33);
			this.cpC2WFG.Name = "cpC2WFG";
			this.cpC2WFG.Size = new System.Drawing.Size(121, 21);
			this.cpC2WFG.TabIndex = 2;
			this.cpC2WFG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpC2LBG
			// 
			this.cpC2LBG.Color = System.Drawing.Color.Black;
			this.cpC2LBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpC2LBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpC2LBG.FormattingEnabled = true;
			this.cpC2LBG.Items.AddRange(new object[] {
            "Color"});
			this.cpC2LBG.Location = new System.Drawing.Point(227, 6);
			this.cpC2LBG.Name = "cpC2LBG";
			this.cpC2LBG.Size = new System.Drawing.Size(121, 21);
			this.cpC2LBG.TabIndex = 1;
			this.cpC2LBG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpC2LFG
			// 
			this.cpC2LFG.Color = System.Drawing.Color.Black;
			this.cpC2LFG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpC2LFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpC2LFG.FormattingEnabled = true;
			this.cpC2LFG.Items.AddRange(new object[] {
            "Color"});
			this.cpC2LFG.Location = new System.Drawing.Point(100, 6);
			this.cpC2LFG.Name = "cpC2LFG";
			this.cpC2LFG.Size = new System.Drawing.Size(121, 21);
			this.cpC2LFG.TabIndex = 0;
			this.cpC2LFG.SelectedColorChanged += new System.EventHandler(this.cp_SelectedColorChanged);
			// 
			// cpA2CBG
			// 
			this.cpA2CBG.Color = System.Drawing.Color.Black;
			this.cpA2CBG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpA2CBG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpA2CBG.FormattingEnabled = true;
			this.cpA2CBG.Items.AddRange(new object[] {
            "Color"});
			this.cpA2CBG.Location = new System.Drawing.Point(227, 195);
			this.cpA2CBG.Name = "cpA2CBG";
			this.cpA2CBG.Size = new System.Drawing.Size(121, 21);
			this.cpA2CBG.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 198);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(84, 13);
			this.label7.TabIndex = 22;
			this.label7.Text = "Auction -> Client";
			// 
			// cpA2CFG
			// 
			this.cpA2CFG.Color = System.Drawing.Color.Black;
			this.cpA2CFG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpA2CFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpA2CFG.FormattingEnabled = true;
			this.cpA2CFG.Items.AddRange(new object[] {
            "Color"});
			this.cpA2CFG.Location = new System.Drawing.Point(100, 195);
			this.cpA2CFG.Name = "cpA2CFG";
			this.cpA2CFG.Size = new System.Drawing.Size(121, 21);
			this.cpA2CFG.TabIndex = 14;
			// 
			// cpC2ABG
			// 
			this.cpC2ABG.Color = System.Drawing.Color.Black;
			this.cpC2ABG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpC2ABG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpC2ABG.FormattingEnabled = true;
			this.cpC2ABG.Items.AddRange(new object[] {
            "Color"});
			this.cpC2ABG.Location = new System.Drawing.Point(227, 87);
			this.cpC2ABG.Name = "cpC2ABG";
			this.cpC2ABG.Size = new System.Drawing.Size(121, 21);
			this.cpC2ABG.TabIndex = 7;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 90);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(84, 13);
			this.label8.TabIndex = 25;
			this.label8.Text = "Client -> Auction";
			// 
			// cpC2AFG
			// 
			this.cpC2AFG.Color = System.Drawing.Color.Black;
			this.cpC2AFG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cpC2AFG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cpC2AFG.FormattingEnabled = true;
			this.cpC2AFG.Items.AddRange(new object[] {
            "Color"});
			this.cpC2AFG.Location = new System.Drawing.Point(100, 87);
			this.cpC2AFG.Name = "cpC2AFG";
			this.cpC2AFG.Size = new System.Drawing.Size(121, 21);
			this.cpC2AFG.TabIndex = 6;
			// 
			// FormColours
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(360, 453);
			this.Controls.Add(this.cpC2ABG);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cpC2AFG);
			this.Controls.Add(this.cpA2CBG);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.cpA2CFG);
			this.Controls.Add(this.cpCH2CBG);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cpCH2CFG);
			this.Controls.Add(this.cpW2CBG);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cpW2CFG);
			this.Controls.Add(this.cpL2CBG);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cpL2CFG);
			this.Controls.Add(this.cpC2CHBG);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cpC2CHFG);
			this.Controls.Add(this.cpC2WBG);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cpC2WFG);
			this.Controls.Add(this.cpC2LBG);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.olvPreview);
			this.Controls.Add(this.cpC2LFG);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormColours";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Colour Configuration";
			((System.ComponentModel.ISupportInitialize)(this.olvPreview)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		Owf.Controls.Office2007ColorPicker cpC2LFG;
		BrightIdeasSoftware.FastObjectListView olvPreview;
		BrightIdeasSoftware.OLVColumn olvColumn1;
		BrightIdeasSoftware.OLVColumn olvColumn2;
		BrightIdeasSoftware.OLVColumn olvColumn3;
		BrightIdeasSoftware.OLVColumn olvColumn4;
		BrightIdeasSoftware.OLVColumn olvColumn5;
		System.Windows.Forms.Button btnOK;
		System.Windows.Forms.Button btnCancel;
		System.Windows.Forms.Label label1;
		Owf.Controls.Office2007ColorPicker cpC2LBG;
		Owf.Controls.Office2007ColorPicker cpC2WBG;
		System.Windows.Forms.Label label2;
		Owf.Controls.Office2007ColorPicker cpC2WFG;
		Owf.Controls.Office2007ColorPicker cpC2CHBG;
		System.Windows.Forms.Label label3;
		Owf.Controls.Office2007ColorPicker cpC2CHFG;
		Owf.Controls.Office2007ColorPicker cpL2CBG;
		System.Windows.Forms.Label label4;
		Owf.Controls.Office2007ColorPicker cpL2CFG;
		Owf.Controls.Office2007ColorPicker cpW2CBG;
		System.Windows.Forms.Label label5;
		Owf.Controls.Office2007ColorPicker cpW2CFG;
		Owf.Controls.Office2007ColorPicker cpCH2CBG;
		System.Windows.Forms.Label label6;
		Owf.Controls.Office2007ColorPicker cpCH2CFG;
		private Owf.Controls.Office2007ColorPicker cpA2CBG;
		private System.Windows.Forms.Label label7;
		private Owf.Controls.Office2007ColorPicker cpA2CFG;
		private Owf.Controls.Office2007ColorPicker cpC2ABG;
		private System.Windows.Forms.Label label8;
		private Owf.Controls.Office2007ColorPicker cpC2AFG;
	}
}