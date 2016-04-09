namespace HuanLuyen
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cboBaiTap = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chkHienKyHieu = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBaiTap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtn55 = new System.Windows.Forms.RadioButton();
            this.rbtn99 = new System.Windows.Forms.RadioButton();
            this.rbtnNone = new System.Windows.Forms.RadioButton();
            this.txtGioBatDau = new System.Windows.Forms.TextBox();
            this.txtPhutBatDau = new System.Windows.Forms.TextBox();
            this.btnHuanLuyen = new System.Windows.Forms.Button();
            this.btnBaiTapUpdate = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControlTop = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdTops = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.grdRadas = new System.Windows.Forms.DataGridView();
            this.lstKhuat = new System.Windows.Forms.ListBox();
            this.AxMap1 = new AxMapXLib.AxMap();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControlTop.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTops)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxMap1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboBaiTap
            // 
            this.cboBaiTap.FormattingEnabled = true;
            this.cboBaiTap.Location = new System.Drawing.Point(16, 120);
            this.cboBaiTap.Name = "cboBaiTap";
            this.cboBaiTap.Size = new System.Drawing.Size(245, 21);
            this.cboBaiTap.TabIndex = 2;
            this.cboBaiTap.SelectedIndexChanged += new System.EventHandler(this.cboBaiTap_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.AxMap1);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1107, 574);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.chkHienKyHieu);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.txtBaiTap);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.rbtn55);
            this.splitContainer2.Panel1.Controls.Add(this.rbtn99);
            this.splitContainer2.Panel1.Controls.Add(this.rbtnNone);
            this.splitContainer2.Panel1.Controls.Add(this.txtGioBatDau);
            this.splitContainer2.Panel1.Controls.Add(this.txtPhutBatDau);
            this.splitContainer2.Panel1.Controls.Add(this.btnHuanLuyen);
            this.splitContainer2.Panel1.Controls.Add(this.btnBaiTapUpdate);
            this.splitContainer2.Panel1.Controls.Add(this.listBox1);
            this.splitContainer2.Panel1.Controls.Add(this.cboBaiTap);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControlTop);
            this.splitContainer2.Size = new System.Drawing.Size(366, 574);
            this.splitContainer2.SplitterDistance = 249;
            this.splitContainer2.TabIndex = 5;
            // 
            // chkHienKyHieu
            // 
            this.chkHienKyHieu.AutoSize = true;
            this.chkHienKyHieu.Checked = true;
            this.chkHienKyHieu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHienKyHieu.Location = new System.Drawing.Point(12, 88);
            this.chkHienKyHieu.Name = "chkHienKyHieu";
            this.chkHienKyHieu.Size = new System.Drawing.Size(106, 17);
            this.chkHienKyHieu.TabIndex = 12;
            this.chkHienKyHieu.Text = "Hiện các ký hiệu";
            this.chkHienKyHieu.UseVisualStyleBackColor = true;
            this.chkHienKyHieu.CheckedChanged += new System.EventHandler(this.chkHienKyHieu_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Bắt đầu lúc";
            // 
            // txtBaiTap
            // 
            this.txtBaiTap.Location = new System.Drawing.Point(80, 152);
            this.txtBaiTap.Name = "txtBaiTap";
            this.txtBaiTap.Size = new System.Drawing.Size(181, 20);
            this.txtBaiTap.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Bài tập";
            // 
            // rbtn55
            // 
            this.rbtn55.AutoSize = true;
            this.rbtn55.Location = new System.Drawing.Point(156, 65);
            this.rbtn55.Name = "rbtn55";
            this.rbtn55.Size = new System.Drawing.Size(42, 17);
            this.rbtn55.TabIndex = 8;
            this.rbtn55.TabStop = true;
            this.rbtn55.Text = "5x5";
            this.rbtn55.UseVisualStyleBackColor = true;
            // 
            // rbtn99
            // 
            this.rbtn99.AutoSize = true;
            this.rbtn99.Location = new System.Drawing.Point(92, 65);
            this.rbtn99.Name = "rbtn99";
            this.rbtn99.Size = new System.Drawing.Size(42, 17);
            this.rbtn99.TabIndex = 7;
            this.rbtn99.TabStop = true;
            this.rbtn99.Text = "9x9";
            this.rbtn99.UseVisualStyleBackColor = true;
            // 
            // rbtnNone
            // 
            this.rbtnNone.AutoSize = true;
            this.rbtnNone.Location = new System.Drawing.Point(12, 65);
            this.rbtnNone.Name = "rbtnNone";
            this.rbtnNone.Size = new System.Drawing.Size(74, 17);
            this.rbtnNone.TabIndex = 6;
            this.rbtnNone.TabStop = true;
            this.rbtnNone.Text = "Ẩn tiêu đồ";
            this.rbtnNone.UseVisualStyleBackColor = true;
            // 
            // txtGioBatDau
            // 
            this.txtGioBatDau.Location = new System.Drawing.Point(80, 178);
            this.txtGioBatDau.Name = "txtGioBatDau";
            this.txtGioBatDau.Size = new System.Drawing.Size(70, 20);
            this.txtGioBatDau.TabIndex = 5;
            // 
            // txtPhutBatDau
            // 
            this.txtPhutBatDau.Location = new System.Drawing.Point(160, 178);
            this.txtPhutBatDau.Name = "txtPhutBatDau";
            this.txtPhutBatDau.Size = new System.Drawing.Size(72, 20);
            this.txtPhutBatDau.TabIndex = 4;
            // 
            // btnHuanLuyen
            // 
            this.btnHuanLuyen.Location = new System.Drawing.Point(160, 213);
            this.btnHuanLuyen.Name = "btnHuanLuyen";
            this.btnHuanLuyen.Size = new System.Drawing.Size(101, 23);
            this.btnHuanLuyen.TabIndex = 3;
            this.btnHuanLuyen.Text = "Huấn luyện KCĐ";
            this.btnHuanLuyen.UseVisualStyleBackColor = true;
            this.btnHuanLuyen.Click += new System.EventHandler(this.btnHuanLuyen_Click);
            // 
            // btnBaiTapUpdate
            // 
            this.btnBaiTapUpdate.Location = new System.Drawing.Point(16, 213);
            this.btnBaiTapUpdate.Name = "btnBaiTapUpdate";
            this.btnBaiTapUpdate.Size = new System.Drawing.Size(102, 23);
            this.btnBaiTapUpdate.TabIndex = 1;
            this.btnBaiTapUpdate.Text = "Cập nhật bài tập";
            this.btnBaiTapUpdate.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(245, 56);
            this.listBox1.TabIndex = 0;
            // 
            // tabControlTop
            // 
            this.tabControlTop.Controls.Add(this.tabPage2);
            this.tabControlTop.Controls.Add(this.tabPage3);
            this.tabControlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTop.Location = new System.Drawing.Point(0, 0);
            this.tabControlTop.Name = "tabControlTop";
            this.tabControlTop.SelectedIndex = 0;
            this.tabControlTop.Size = new System.Drawing.Size(366, 321);
            this.tabControlTop.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdTops);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(358, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tốp bay";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdTops
            // 
            this.grdTops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTops.Location = new System.Drawing.Point(3, 3);
            this.grdTops.Name = "grdTops";
            this.grdTops.Size = new System.Drawing.Size(352, 289);
            this.grdTops.TabIndex = 0;
            this.grdTops.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTops_CellDoubleClick);
            this.grdTops.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdTops_CellMouseDown);
            this.grdTops.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTops_CellValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(267, 291);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rada";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.grdRadas);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lstKhuat);
            this.splitContainer3.Size = new System.Drawing.Size(261, 285);
            this.splitContainer3.SplitterDistance = 139;
            this.splitContainer3.TabIndex = 0;
            // 
            // grdRadas
            // 
            this.grdRadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRadas.Location = new System.Drawing.Point(0, 0);
            this.grdRadas.Name = "grdRadas";
            this.grdRadas.Size = new System.Drawing.Size(261, 139);
            this.grdRadas.TabIndex = 2;
            this.grdRadas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRadas_CellDoubleClick);
            this.grdRadas.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdRadas_CellMouseDown);
            this.grdRadas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRadas_CellValueChanged);
            // 
            // lstKhuat
            // 
            this.lstKhuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstKhuat.FormattingEnabled = true;
            this.lstKhuat.Location = new System.Drawing.Point(0, 0);
            this.lstKhuat.Name = "lstKhuat";
            this.lstKhuat.Size = new System.Drawing.Size(261, 142);
            this.lstKhuat.TabIndex = 1;
            // 
            // AxMap1
            // 
            this.AxMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AxMap1.Enabled = true;
            this.AxMap1.Location = new System.Drawing.Point(0, 25);
            this.AxMap1.Name = "AxMap1";
            this.AxMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxMap1.OcxState")));
            this.AxMap1.Size = new System.Drawing.Size(737, 527);
            this.AxMap1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1,
            this.ToolStripStatusLabel2,
            this.ToolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(737, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.ToolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.ToolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // ToolStripStatusLabel3
            // 
            this.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3";
            this.ToolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
            this.ToolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(737, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 574);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControlTop.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTops)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxMap1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cboBaiTap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnBaiTapUpdate;
        private System.Windows.Forms.ListBox listBox1;
        public AxMapXLib.AxMap AxMap1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtGioBatDau;
        private System.Windows.Forms.TextBox txtPhutBatDau;
        private System.Windows.Forms.Button btnHuanLuyen;
        private System.Windows.Forms.TabControl tabControlTop;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rbtn55;
        private System.Windows.Forms.RadioButton rbtn99;
        private System.Windows.Forms.RadioButton rbtnNone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBaiTap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView grdTops;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkHienKyHieu;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView grdRadas;
        private System.Windows.Forms.ListBox lstKhuat;
    }
}