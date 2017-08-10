namespace Ostara {
	partial class FormMain {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lblInspUnixTime = new System.Windows.Forms.Label();
			this.inspDouble = new System.Windows.Forms.Label();
			this.lblInspDouble = new System.Windows.Forms.Label();
			this.inspFloat = new System.Windows.Forms.Label();
			this.inspULong = new System.Windows.Forms.Label();
			this.inspUShort = new System.Windows.Forms.Label();
			this.inspLong = new System.Windows.Forms.Label();
			this.inspShort = new System.Windows.Forms.Label();
			this.inspUInt = new System.Windows.Forms.Label();
			this.inspInt = new System.Windows.Forms.Label();
			this.lblInspFloat = new System.Windows.Forms.Label();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.cbBytesPerLine = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblInspShort = new System.Windows.Forms.Label();
			this.lblInspUShort = new System.Windows.Forms.Label();
			this.lblInspSByte = new System.Windows.Forms.Label();
			this.lblInspUInt = new System.Windows.Forms.Label();
			this.lblInspInt = new System.Windows.Forms.Label();
			this.lblInspLong = new System.Windows.Forms.Label();
			this.lblInspULong = new System.Windows.Forms.Label();
			this.inspByte = new System.Windows.Forms.Label();
			this.lblInspByte = new System.Windows.Forms.Label();
			this.lblInspDosTime = new System.Windows.Forms.Label();
			this.lblInspGuid = new System.Windows.Forms.Label();
			this.hexView = new Be.Windows.Forms.HexBox();
			this.flvPackets = new BrightIdeasSoftware.FastObjectListView();
			this.olvTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvLen = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvSrc = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvDst = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvOp = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvComment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.tlvStructure = new BrightIdeasSoftware.TreeListView();
			this.olvType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvEntryComment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.cmsStructure = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmseStructureEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.autoExpandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.noneToolStripMenuItem = new Ostara.Controls.ToolStripRadioButtonMenuItem();
			this.bitfieldsOnlyToolStripMenuItem = new Ostara.Controls.ToolStripRadioButtonMenuItem();
			this.allToolStripMenuItem = new Ostara.Controls.ToolStripRadioButtonMenuItem();
			this.inspSByte = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbOpen = new System.Windows.Forms.ToolStripButton();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.tsbClear = new System.Windows.Forms.ToolStripButton();
			this.tsbIgnore = new System.Windows.Forms.ToolStripButton();
			this.tsbOptions = new System.Windows.Forms.ToolStripButton();
			this.tsbAbout = new System.Windows.Forms.ToolStripButton();
			this.tsbStop = new System.Windows.Forms.ToolStripButton();
			this.tsbPause = new System.Windows.Forms.ToolStripButton();
			this.tsbStart = new System.Windows.Forms.ToolStripButton();
			this.txtPort = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.txtIp = new System.Windows.Forms.ToolStripTextBox();
			this.tslServerIP = new System.Windows.Forms.ToolStripLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flvPackets)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tlvStructure)).BeginInit();
			this.cmsStructure.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 755F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.hexView, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.flvPackets, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tlvStructure, 1, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1348, 646);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 6;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Controls.Add(this.lblInspUnixTime, 0, 4);
			this.tableLayoutPanel2.Controls.Add(this.inspDouble, 5, 3);
			this.tableLayoutPanel2.Controls.Add(this.lblInspDouble, 4, 3);
			this.tableLayoutPanel2.Controls.Add(this.inspFloat, 5, 2);
			this.tableLayoutPanel2.Controls.Add(this.inspULong, 3, 3);
			this.tableLayoutPanel2.Controls.Add(this.inspUShort, 1, 3);
			this.tableLayoutPanel2.Controls.Add(this.inspLong, 3, 2);
			this.tableLayoutPanel2.Controls.Add(this.inspShort, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.inspUInt, 3, 1);
			this.tableLayoutPanel2.Controls.Add(this.inspInt, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblInspFloat, 4, 2);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 5, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblInspShort, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.lblInspUShort, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.lblInspSByte, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblInspUInt, 2, 2);
			this.tableLayoutPanel2.Controls.Add(this.lblInspInt, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.lblInspLong, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.lblInspULong, 2, 3);
			this.tableLayoutPanel2.Controls.Add(this.inspByte, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblInspByte, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblInspDosTime, 2, 4);
			this.tableLayoutPanel2.Controls.Add(this.lblInspGuid, 4, 4);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(593, 276);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 5;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(755, 94);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// lblInspUnixTime
			// 
			this.lblInspUnixTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspUnixTime.AutoSize = true;
			this.lblInspUnixTime.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspUnixTime.Location = new System.Drawing.Point(4, 75);
			this.lblInspUnixTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspUnixTime.Name = "lblInspUnixTime";
			this.lblInspUnixTime.Size = new System.Drawing.Size(63, 15);
			this.lblInspUnixTime.TabIndex = 24;
			this.lblInspUnixTime.Text = "Unix Time:";
			this.lblInspUnixTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// inspDouble
			// 
			this.inspDouble.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspDouble.AutoSize = true;
			this.inspDouble.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspDouble.Location = new System.Drawing.Point(582, 55);
			this.inspDouble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspDouble.Name = "inspDouble";
			this.inspDouble.Size = new System.Drawing.Size(0, 15);
			this.inspDouble.TabIndex = 19;
			this.inspDouble.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblInspDouble
			// 
			this.lblInspDouble.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspDouble.AutoSize = true;
			this.lblInspDouble.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspDouble.Location = new System.Drawing.Point(526, 55);
			this.lblInspDouble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspDouble.Name = "lblInspDouble";
			this.lblInspDouble.Size = new System.Drawing.Size(48, 15);
			this.lblInspDouble.TabIndex = 18;
			this.lblInspDouble.Text = "Double:";
			this.lblInspDouble.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// inspFloat
			// 
			this.inspFloat.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspFloat.AutoSize = true;
			this.inspFloat.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspFloat.Location = new System.Drawing.Point(582, 37);
			this.inspFloat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspFloat.Name = "inspFloat";
			this.inspFloat.Size = new System.Drawing.Size(0, 15);
			this.inspFloat.TabIndex = 17;
			this.inspFloat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inspULong
			// 
			this.inspULong.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspULong.AutoSize = true;
			this.inspULong.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspULong.Location = new System.Drawing.Point(350, 55);
			this.inspULong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspULong.Name = "inspULong";
			this.inspULong.Size = new System.Drawing.Size(0, 15);
			this.inspULong.TabIndex = 15;
			this.inspULong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inspUShort
			// 
			this.inspUShort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspUShort.AutoSize = true;
			this.inspUShort.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspUShort.Location = new System.Drawing.Point(75, 55);
			this.inspUShort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspUShort.Name = "inspUShort";
			this.inspUShort.Size = new System.Drawing.Size(0, 15);
			this.inspUShort.TabIndex = 13;
			this.inspUShort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inspLong
			// 
			this.inspLong.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspLong.AutoSize = true;
			this.inspLong.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspLong.Location = new System.Drawing.Point(350, 37);
			this.inspLong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspLong.Name = "inspLong";
			this.inspLong.Size = new System.Drawing.Size(0, 15);
			this.inspLong.TabIndex = 11;
			this.inspLong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inspShort
			// 
			this.inspShort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspShort.AutoSize = true;
			this.inspShort.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspShort.Location = new System.Drawing.Point(75, 37);
			this.inspShort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspShort.Name = "inspShort";
			this.inspShort.Size = new System.Drawing.Size(0, 15);
			this.inspShort.TabIndex = 9;
			this.inspShort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inspUInt
			// 
			this.inspUInt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspUInt.AutoSize = true;
			this.inspUInt.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspUInt.Location = new System.Drawing.Point(350, 19);
			this.inspUInt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspUInt.Name = "inspUInt";
			this.inspUInt.Size = new System.Drawing.Size(0, 15);
			this.inspUInt.TabIndex = 7;
			this.inspUInt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inspInt
			// 
			this.inspInt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspInt.AutoSize = true;
			this.inspInt.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspInt.Location = new System.Drawing.Point(350, 1);
			this.inspInt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspInt.Name = "inspInt";
			this.inspInt.Size = new System.Drawing.Size(0, 15);
			this.inspInt.TabIndex = 3;
			this.inspInt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblInspFloat
			// 
			this.lblInspFloat.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspFloat.AutoSize = true;
			this.lblInspFloat.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspFloat.Location = new System.Drawing.Point(538, 37);
			this.lblInspFloat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspFloat.Name = "lblInspFloat";
			this.lblInspFloat.Size = new System.Drawing.Size(36, 15);
			this.lblInspFloat.TabIndex = 16;
			this.lblInspFloat.Text = "Float:";
			this.lblInspFloat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.tableLayoutPanel4.ColumnCount = 2;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
			this.tableLayoutPanel4.Controls.Add(this.cbBytesPerLine, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(582, 4);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel2.SetRowSpan(this.tableLayoutPanel4, 2);
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(169, 28);
			this.tableLayoutPanel4.TabIndex = 23;
			// 
			// cbBytesPerLine
			// 
			this.cbBytesPerLine.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.cbBytesPerLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBytesPerLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbBytesPerLine.FormattingEnabled = true;
			this.cbBytesPerLine.Items.AddRange(new object[] {
            "8",
            "16",
            "24",
            "32"});
			this.cbBytesPerLine.Location = new System.Drawing.Point(117, 1);
			this.cbBytesPerLine.Margin = new System.Windows.Forms.Padding(0);
			this.cbBytesPerLine.Name = "cbBytesPerLine";
			this.cbBytesPerLine.Size = new System.Drawing.Size(52, 24);
			this.cbBytesPerLine.TabIndex = 22;
			this.cbBytesPerLine.SelectedIndexChanged += new System.EventHandler(this.cbBytesPerLine_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(4, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 28);
			this.label1.TabIndex = 23;
			this.label1.Text = "Bytes per line:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInspShort
			// 
			this.lblInspShort.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspShort.AutoSize = true;
			this.lblInspShort.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspShort.Location = new System.Drawing.Point(29, 19);
			this.lblInspShort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspShort.Name = "lblInspShort";
			this.lblInspShort.Size = new System.Drawing.Size(38, 15);
			this.lblInspShort.TabIndex = 8;
			this.lblInspShort.Text = "Short:";
			this.lblInspShort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInspUShort
			// 
			this.lblInspUShort.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspUShort.AutoSize = true;
			this.lblInspUShort.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspUShort.Location = new System.Drawing.Point(251, 19);
			this.lblInspUShort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspUShort.Name = "lblInspUShort";
			this.lblInspUShort.Size = new System.Drawing.Size(91, 15);
			this.lblInspUShort.TabIndex = 12;
			this.lblInspUShort.Text = "Unsigned Short:";
			this.lblInspUShort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInspSByte
			// 
			this.lblInspSByte.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspSByte.AutoSize = true;
			this.lblInspSByte.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspSByte.Location = new System.Drawing.Point(270, 1);
			this.lblInspSByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspSByte.Name = "lblInspSByte";
			this.lblInspSByte.Size = new System.Drawing.Size(72, 15);
			this.lblInspSByte.TabIndex = 4;
			this.lblInspSByte.Text = "Signed Byte:";
			this.lblInspSByte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInspUInt
			// 
			this.lblInspUInt.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspUInt.AutoSize = true;
			this.lblInspUInt.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspUInt.Location = new System.Drawing.Point(265, 37);
			this.lblInspUInt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspUInt.Name = "lblInspUInt";
			this.lblInspUInt.Size = new System.Drawing.Size(77, 15);
			this.lblInspUInt.TabIndex = 6;
			this.lblInspUInt.Text = "Unsigned Int:";
			this.lblInspUInt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInspInt
			// 
			this.lblInspInt.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspInt.AutoSize = true;
			this.lblInspInt.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspInt.Location = new System.Drawing.Point(43, 37);
			this.lblInspInt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspInt.Name = "lblInspInt";
			this.lblInspInt.Size = new System.Drawing.Size(24, 15);
			this.lblInspInt.TabIndex = 2;
			this.lblInspInt.Text = "Int:";
			this.lblInspInt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInspLong
			// 
			this.lblInspLong.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspLong.AutoSize = true;
			this.lblInspLong.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspLong.Location = new System.Drawing.Point(30, 55);
			this.lblInspLong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspLong.Name = "lblInspLong";
			this.lblInspLong.Size = new System.Drawing.Size(37, 15);
			this.lblInspLong.TabIndex = 10;
			this.lblInspLong.Text = "Long:";
			this.lblInspLong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInspULong
			// 
			this.lblInspULong.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspULong.AutoSize = true;
			this.lblInspULong.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspULong.Location = new System.Drawing.Point(252, 55);
			this.lblInspULong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspULong.Name = "lblInspULong";
			this.lblInspULong.Size = new System.Drawing.Size(90, 15);
			this.lblInspULong.TabIndex = 14;
			this.lblInspULong.Text = "Unsigned Long:";
			this.lblInspULong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// inspByte
			// 
			this.inspByte.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspByte.AutoSize = true;
			this.inspByte.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspByte.Location = new System.Drawing.Point(75, 1);
			this.inspByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspByte.Name = "inspByte";
			this.inspByte.Size = new System.Drawing.Size(0, 15);
			this.inspByte.TabIndex = 1;
			this.inspByte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblInspByte
			// 
			this.lblInspByte.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspByte.AutoSize = true;
			this.lblInspByte.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspByte.Location = new System.Drawing.Point(34, 1);
			this.lblInspByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspByte.Name = "lblInspByte";
			this.lblInspByte.Size = new System.Drawing.Size(33, 15);
			this.lblInspByte.TabIndex = 0;
			this.lblInspByte.Text = "Byte:";
			this.lblInspByte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInspDosTime
			// 
			this.lblInspDosTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspDosTime.AutoSize = true;
			this.lblInspDosTime.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspDosTime.Location = new System.Drawing.Point(282, 75);
			this.lblInspDosTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspDosTime.Name = "lblInspDosTime";
			this.lblInspDosTime.Size = new System.Drawing.Size(60, 15);
			this.lblInspDosTime.TabIndex = 25;
			this.lblInspDosTime.Text = "Dos Time:";
			this.lblInspDosTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblInspGuid
			// 
			this.lblInspGuid.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lblInspGuid.AutoSize = true;
			this.lblInspGuid.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInspGuid.Location = new System.Drawing.Point(539, 75);
			this.lblInspGuid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblInspGuid.Name = "lblInspGuid";
			this.lblInspGuid.Size = new System.Drawing.Size(35, 15);
			this.lblInspGuid.TabIndex = 26;
			this.lblInspGuid.Text = "Guid:";
			this.lblInspGuid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// hexView
			// 
			// 
			// 
			// 
			this.hexView.BuiltInContextMenu.CopyMenuItemText = "";
			this.hexView.ColumnInfoVisible = true;
			this.hexView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hexView.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.hexView.LineInfoVisible = true;
			this.hexView.Location = new System.Drawing.Point(597, 4);
			this.hexView.Margin = new System.Windows.Forms.Padding(4);
			this.hexView.Name = "hexView";
			this.hexView.ReadOnly = true;
			this.hexView.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
			this.hexView.Size = new System.Drawing.Size(747, 268);
			this.hexView.StringViewVisible = true;
			this.hexView.TabIndex = 1;
			this.hexView.UseFixedBytesPerLine = true;
			this.hexView.VScrollBarVisible = true;
			this.hexView.SelectionStartChanged += new System.EventHandler(this.hexView_SelectionStartChanged);
			this.hexView.Copied += new System.EventHandler(this.hexView_Copied);
			// 
			// flvPackets
			// 
			this.flvPackets.AllColumns.Add(this.olvTime);
			this.flvPackets.AllColumns.Add(this.olvLen);
			this.flvPackets.AllColumns.Add(this.olvSrc);
			this.flvPackets.AllColumns.Add(this.olvDst);
			this.flvPackets.AllColumns.Add(this.olvOp);
			this.flvPackets.AllColumns.Add(this.olvComment);
			this.flvPackets.AutoArrange = false;
			this.flvPackets.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
			this.flvPackets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvTime,
            this.olvLen,
            this.olvSrc,
            this.olvDst,
            this.olvOp,
            this.olvComment});
			this.flvPackets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flvPackets.EmptyListMsg = "No packets!";
			this.flvPackets.FullRowSelect = true;
			this.flvPackets.HasCollapsibleGroups = false;
			this.flvPackets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.flvPackets.HeaderUsesThemes = true;
			this.flvPackets.HideSelection = false;
			this.flvPackets.LabelWrap = false;
			this.flvPackets.Location = new System.Drawing.Point(4, 4);
			this.flvPackets.Margin = new System.Windows.Forms.Padding(4);
			this.flvPackets.MultiSelect = false;
			this.flvPackets.Name = "flvPackets";
			this.tableLayoutPanel1.SetRowSpan(this.flvPackets, 3);
			this.flvPackets.ShowGroups = false;
			this.flvPackets.ShowItemToolTips = true;
			this.flvPackets.Size = new System.Drawing.Size(585, 638);
			this.flvPackets.TabIndex = 2;
			this.flvPackets.UseCompatibleStateImageBehavior = false;
			this.flvPackets.UseExplorerTheme = true;
			this.flvPackets.View = System.Windows.Forms.View.Details;
			this.flvPackets.VirtualMode = true;
			this.flvPackets.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.flvPackets_CellRightClick);
			this.flvPackets.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.flvPackets_FormatRow);
			this.flvPackets.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.flvPackets_ItemsChanged);
			this.flvPackets.SelectedIndexChanged += new System.EventHandler(this.flvPackets_SelectedIndexChanged);
			this.flvPackets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.flvPackets_KeyPress);
			// 
			// olvTime
			// 
			this.olvTime.AspectName = "Time";
			this.olvTime.AspectToStringFormat = "{0:MM/dd/yy H:mm:ss}";
			this.olvTime.IsEditable = false;
			this.olvTime.Text = "Time";
			this.olvTime.Width = 108;
			// 
			// olvLen
			// 
			this.olvLen.AspectName = "Length";
			this.olvLen.IsEditable = false;
			this.olvLen.Text = "Len";
			this.olvLen.Width = 40;
			// 
			// olvSrc
			// 
			this.olvSrc.AspectName = "Source";
			this.olvSrc.IsEditable = false;
			this.olvSrc.Text = "Source";
			// 
			// olvDst
			// 
			this.olvDst.AspectName = "Destination";
			this.olvDst.IsEditable = false;
			this.olvDst.Text = "Dest";
			// 
			// olvOp
			// 
			this.olvOp.AspectName = "Opcode";
			this.olvOp.IsEditable = false;
			this.olvOp.Text = "Opcode";
			this.olvOp.Width = 64;
			// 
			// olvComment
			// 
			this.olvComment.AspectName = "Comment";
			this.olvComment.AutoCompleteEditor = false;
			this.olvComment.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.olvComment.FillsFreeSpace = true;
			this.olvComment.Groupable = false;
			this.olvComment.Text = "Comment";
			this.olvComment.Width = 120;
			// 
			// tlvStructure
			// 
			this.tlvStructure.AllColumns.Add(this.olvType);
			this.tlvStructure.AllColumns.Add(this.olvName);
			this.tlvStructure.AllColumns.Add(this.olvValue);
			this.tlvStructure.AllColumns.Add(this.olvEntryComment);
			this.tlvStructure.CheckedAspectName = "";
			this.tlvStructure.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvType,
            this.olvName,
            this.olvValue,
            this.olvEntryComment});
			this.tlvStructure.ContextMenuStrip = this.cmsStructure;
			this.tlvStructure.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tlvStructure.FullRowSelect = true;
			this.tlvStructure.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.tlvStructure.Location = new System.Drawing.Point(597, 374);
			this.tlvStructure.Margin = new System.Windows.Forms.Padding(4);
			this.tlvStructure.MultiSelect = false;
			this.tlvStructure.Name = "tlvStructure";
			this.tlvStructure.OwnerDraw = true;
			this.tlvStructure.ShowFilterMenuOnRightClick = false;
			this.tlvStructure.ShowGroups = false;
			this.tlvStructure.ShowItemToolTips = true;
			this.tlvStructure.ShowSortIndicators = false;
			this.tlvStructure.Size = new System.Drawing.Size(747, 268);
			this.tlvStructure.TabIndex = 3;
			this.tlvStructure.UseCompatibleStateImageBehavior = false;
			this.tlvStructure.View = System.Windows.Forms.View.Details;
			this.tlvStructure.VirtualMode = true;
			this.tlvStructure.Expanded += new System.EventHandler<BrightIdeasSoftware.TreeBranchExpandedEventArgs>(this.tlvStructure_Expanded);
			this.tlvStructure.Collapsed += new System.EventHandler<BrightIdeasSoftware.TreeBranchCollapsedEventArgs>(this.tlvStructure_Collapsed);
			this.tlvStructure.SelectedIndexChanged += new System.EventHandler(this.tlvStructure_SelectedIndexChanged);
			this.tlvStructure.DoubleClick += new System.EventHandler(this.tlvStructure_DoubleClick);
			// 
			// olvType
			// 
			this.olvType.AspectName = "TypeName";
			this.olvType.AutoCompleteEditor = false;
			this.olvType.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.olvType.Hideable = false;
			this.olvType.IsEditable = false;
			this.olvType.Text = "Type";
			// 
			// olvName
			// 
			this.olvName.AspectName = "Name";
			this.olvName.AutoCompleteEditor = false;
			this.olvName.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.olvName.Hideable = false;
			this.olvName.IsEditable = false;
			this.olvName.Text = "Name";
			this.olvName.Width = 100;
			// 
			// olvValue
			// 
			this.olvValue.AspectName = "Value";
			this.olvValue.AutoCompleteEditor = false;
			this.olvValue.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.olvValue.Hideable = false;
			this.olvValue.IsEditable = false;
			this.olvValue.Text = "Value";
			this.olvValue.Width = 140;
			// 
			// olvEntryComment
			// 
			this.olvEntryComment.AspectName = "Comment";
			this.olvEntryComment.AutoCompleteEditor = false;
			this.olvEntryComment.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
			this.olvEntryComment.FillsFreeSpace = true;
			this.olvEntryComment.IsEditable = false;
			this.olvEntryComment.Text = "Comment";
			// 
			// cmsStructure
			// 
			this.cmsStructure.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.cmsStructure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmseStructureEdit,
            this.toolStripSeparator5,
            this.autoExpandToolStripMenuItem});
			this.cmsStructure.Name = "cmsStructure";
			this.cmsStructure.Size = new System.Drawing.Size(168, 58);
			// 
			// cmseStructureEdit
			// 
			this.cmseStructureEdit.Name = "cmseStructureEdit";
			this.cmseStructureEdit.Size = new System.Drawing.Size(167, 24);
			this.cmseStructureEdit.Text = "Edit Structure";
			this.cmseStructureEdit.Click += new System.EventHandler(this.cmseStructureEdit_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(164, 6);
			// 
			// autoExpandToolStripMenuItem
			// 
			this.autoExpandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.bitfieldsOnlyToolStripMenuItem,
            this.allToolStripMenuItem});
			this.autoExpandToolStripMenuItem.Name = "autoExpandToolStripMenuItem";
			this.autoExpandToolStripMenuItem.Size = new System.Drawing.Size(167, 24);
			this.autoExpandToolStripMenuItem.Text = "Auto-Expand";
			// 
			// noneToolStripMenuItem
			// 
			this.noneToolStripMenuItem.CheckOnClick = true;
			this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
			this.noneToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.noneToolStripMenuItem.Text = "None";
			this.noneToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.autoExpandCheckStateChanged);
			// 
			// bitfieldsOnlyToolStripMenuItem
			// 
			this.bitfieldsOnlyToolStripMenuItem.CheckOnClick = true;
			this.bitfieldsOnlyToolStripMenuItem.Name = "bitfieldsOnlyToolStripMenuItem";
			this.bitfieldsOnlyToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.bitfieldsOnlyToolStripMenuItem.Text = "Bitfields Only";
			this.bitfieldsOnlyToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.autoExpandCheckStateChanged);
			// 
			// allToolStripMenuItem
			// 
			this.allToolStripMenuItem.CheckOnClick = true;
			this.allToolStripMenuItem.Name = "allToolStripMenuItem";
			this.allToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
			this.allToolStripMenuItem.Text = "All";
			this.allToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.autoExpandCheckStateChanged);
			// 
			// inspSByte
			// 
			this.inspSByte.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.inspSByte.AutoSize = true;
			this.inspSByte.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.inspSByte.Location = new System.Drawing.Point(112, 19);
			this.inspSByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.inspSByte.Name = "inspSByte";
			this.inspSByte.Size = new System.Drawing.Size(0, 15);
			this.inspSByte.TabIndex = 5;
			this.inspSByte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave,
            this.tsbClear,
            this.tsbIgnore,
            this.tsbOptions,
            this.tsbAbout,
            this.tsbStop,
            this.tsbPause,
            this.tsbStart,
            this.txtPort,
            this.toolStripLabel1,
            this.txtIp,
            this.tslServerIP});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1348, 27);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbOpen
			// 
			this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbOpen.Name = "tsbOpen";
			this.tsbOpen.Size = new System.Drawing.Size(49, 24);
			this.tsbOpen.Text = "&Open";
			this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
			// 
			// tsbSave
			// 
			this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSave.Margin = new System.Windows.Forms.Padding(0, 1, 16, 2);
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Size = new System.Drawing.Size(44, 24);
			this.tsbSave.Text = "&Save";
			this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
			// 
			// tsbClear
			// 
			this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbClear.Name = "tsbClear";
			this.tsbClear.Size = new System.Drawing.Size(57, 24);
			this.tsbClear.Text = "Delete";
			this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
			// 
			// tsbIgnore
			// 
			this.tsbIgnore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbIgnore.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbIgnore.Margin = new System.Windows.Forms.Padding(0, 1, 16, 2);
			this.tsbIgnore.Name = "tsbIgnore";
			this.tsbIgnore.Size = new System.Drawing.Size(56, 24);
			this.tsbIgnore.Text = "Ignore";
			// 
			// tsbOptions
			// 
			this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbOptions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbOptions.Name = "tsbOptions";
			this.tsbOptions.Size = new System.Drawing.Size(65, 24);
			this.tsbOptions.Text = "Options";
			this.tsbOptions.Click += new System.EventHandler(this.tsbColours_Click);
			// 
			// tsbAbout
			// 
			this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAbout.Name = "tsbAbout";
			this.tsbAbout.Size = new System.Drawing.Size(54, 24);
			this.tsbAbout.Text = "About";
			this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
			// 
			// tsbStop
			// 
			this.tsbStop.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbStop.Enabled = false;
			this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbStop.Name = "tsbStop";
			this.tsbStop.Size = new System.Drawing.Size(44, 24);
			this.tsbStop.Text = "Stop";
			this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
			// 
			// tsbPause
			// 
			this.tsbPause.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbPause.Enabled = false;
			this.tsbPause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPause.Name = "tsbPause";
			this.tsbPause.Size = new System.Drawing.Size(50, 24);
			this.tsbPause.Text = "Pause";
			this.tsbPause.Click += new System.EventHandler(this.tsbPause_Click);
			// 
			// tsbStart
			// 
			this.tsbStart.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbStart.Name = "tsbStart";
			this.tsbStart.Size = new System.Drawing.Size(44, 24);
			this.tsbStart.Text = "Start";
			this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
			// 
			// txtPort
			// 
			this.txtPort.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.txtPort.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.txtPort.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
			this.txtPort.MaxLength = 5;
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(60, 27);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(12, 24);
			this.toolStripLabel1.Text = ":";
			// 
			// txtIp
			// 
			this.txtIp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.txtIp.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.txtIp.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
			this.txtIp.MaxLength = 15;
			this.txtIp.Name = "txtIp";
			this.txtIp.Size = new System.Drawing.Size(120, 27);
			// 
			// tslServerIP
			// 
			this.tslServerIP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tslServerIP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tslServerIP.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.tslServerIP.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
			this.tslServerIP.Name = "tslServerIP";
			this.tslServerIP.Size = new System.Drawing.Size(66, 24);
			this.tslServerIP.Text = "Server IP:";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1348, 673);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ostara - Stopped";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.flvPackets)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tlvStructure)).EndInit();
			this.cmsStructure.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		System.Windows.Forms.ToolStrip toolStrip1;
		System.Windows.Forms.ToolStripButton tsbOpen;
		System.Windows.Forms.ToolStripButton tsbSave;
		System.Windows.Forms.ToolStripButton tsbAbout;
		System.Windows.Forms.ToolStripButton tsbStop;
		System.Windows.Forms.ToolStripButton tsbPause;
		System.Windows.Forms.ToolStripButton tsbStart;
		System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		System.Windows.Forms.Label inspDouble;
		System.Windows.Forms.Label inspFloat;
		System.Windows.Forms.Label inspULong;
		System.Windows.Forms.Label lblInspULong;
		System.Windows.Forms.Label inspUShort;
		System.Windows.Forms.Label lblInspUShort;
		System.Windows.Forms.Label inspLong;
		System.Windows.Forms.Label lblInspLong;
		System.Windows.Forms.Label inspShort;
		System.Windows.Forms.Label inspUInt;
		System.Windows.Forms.Label lblInspUInt;
		System.Windows.Forms.Label inspSByte;
		System.Windows.Forms.Label lblInspSByte;
		System.Windows.Forms.Label inspInt;
		System.Windows.Forms.Label lblInspInt;
		System.Windows.Forms.Label inspByte;
		System.Windows.Forms.Label lblInspByte;
		System.Windows.Forms.Label lblInspFloat;
		Be.Windows.Forms.HexBox hexView;
		BrightIdeasSoftware.FastObjectListView flvPackets;
		BrightIdeasSoftware.OLVColumn olvTime;
		BrightIdeasSoftware.OLVColumn olvLen;
		BrightIdeasSoftware.OLVColumn olvSrc;
		BrightIdeasSoftware.OLVColumn olvDst;
		BrightIdeasSoftware.OLVColumn olvOp;
		BrightIdeasSoftware.OLVColumn olvComment;
		System.Windows.Forms.ToolStripButton tsbOptions;
		System.Windows.Forms.ToolStripButton tsbClear;
		BrightIdeasSoftware.TreeListView tlvStructure;
		BrightIdeasSoftware.OLVColumn olvType;
		BrightIdeasSoftware.OLVColumn olvValue;
		BrightIdeasSoftware.OLVColumn olvName;
		System.Windows.Forms.ContextMenuStrip cmsStructure;
		System.Windows.Forms.ToolStripMenuItem cmseStructureEdit;
		private BrightIdeasSoftware.OLVColumn olvEntryComment;
		private System.Windows.Forms.Label lblInspDouble;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ComboBox cbBytesPerLine;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem autoExpandToolStripMenuItem;
		private Controls.ToolStripRadioButtonMenuItem noneToolStripMenuItem;
		private Controls.ToolStripRadioButtonMenuItem bitfieldsOnlyToolStripMenuItem;
		private Controls.ToolStripRadioButtonMenuItem allToolStripMenuItem;
		private System.Windows.Forms.Label lblInspShort;
		private System.Windows.Forms.ToolStripTextBox txtPort;
		private System.Windows.Forms.ToolStripTextBox txtIp;
		private System.Windows.Forms.Label lblInspUnixTime;
		private System.Windows.Forms.Label lblInspDosTime;
		private System.Windows.Forms.Label lblInspGuid;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripLabel tslServerIP;
		private System.Windows.Forms.ToolStripButton tsbIgnore;
	}
}