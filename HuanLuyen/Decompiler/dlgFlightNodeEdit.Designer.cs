namespace HuanLuyen
{
    partial class dlgFlightNodeEdit
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTheoDiaTieu = new System.Windows.Forms.RadioButton();
            this.rbtnTheoLonLat = new System.Windows.Forms.RadioButton();
            this.rbtnTheoPhuongVi = new System.Windows.Forms.RadioButton();
            this.nudYDo = new System.Windows.Forms.NumericUpDown();
            this.nudXDo = new System.Windows.Forms.NumericUpDown();
            this.nudYGiay = new System.Windows.Forms.NumericUpDown();
            this.nudXGiay = new System.Windows.Forms.NumericUpDown();
            this.nudYPhut = new System.Windows.Forms.NumericUpDown();
            this.nudXPhut = new System.Windows.Forms.NumericUpDown();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.txtBanKinh = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPhuongVi = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnChon = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.txtSBTo_ID = new System.Windows.Forms.TextBox();
            this.txtStt = new System.Windows.Forms.TextBox();
            this.txtPath_ID = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtAltitude = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.nudRoll = new System.Windows.Forms.NumericUpDown();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.nudTspeed = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboTurn = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnHuongDiem = new System.Windows.Forms.RadioButton();
            this.rbtnQuanhDiem = new System.Windows.Forms.RadioButton();
            this.rbtnDenDiem = new System.Windows.Forms.RadioButton();
            this.txtCX = new System.Windows.Forms.TextBox();
            this.txtCY = new System.Windows.Forms.TextBox();
            this.txtDpX = new System.Windows.Forms.TextBox();
            this.txtDpY = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudYDo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudXDo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudYGiay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudXGiay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudYPhut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudXPhut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudRoll).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudTspeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpeed).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Controls.Add(this.rbtnTheoDiaTieu);
            this.GroupBox1.Controls.Add(this.rbtnTheoLonLat);
            this.GroupBox1.Controls.Add(this.rbtnTheoPhuongVi);
            this.GroupBox1.Controls.Add(this.nudYDo);
            this.GroupBox1.Controls.Add(this.nudXDo);
            this.GroupBox1.Controls.Add(this.nudYGiay);
            this.GroupBox1.Controls.Add(this.nudXGiay);
            this.GroupBox1.Controls.Add(this.nudYPhut);
            this.GroupBox1.Controls.Add(this.nudXPhut);
            this.GroupBox1.Controls.Add(this.Label13);
            this.GroupBox1.Controls.Add(this.Label16);
            this.GroupBox1.Controls.Add(this.txtBanKinh);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtPhuongVi);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.btnChon);
            this.GroupBox1.Controls.Add(this.txtName);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Location = new System.Drawing.Point(12, 115);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(215, 240);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Vòng đến điểm:";
            //
            // rbtnTheoDiaTieu
            //
            this.rbtnTheoDiaTieu.AutoSize = true;
            this.rbtnTheoDiaTieu.Location = new System.Drawing.Point(16, 20);
            this.rbtnTheoDiaTieu.Name = "rbtnTheoDiaTieu";
            this.rbtnTheoDiaTieu.Size = new System.Drawing.Size(113, 17);
            this.rbtnTheoDiaTieu.TabIndex = 0;
            this.rbtnTheoDiaTieu.Text = "Nhập theo địa tiêu";
            this.rbtnTheoDiaTieu.UseVisualStyleBackColor = true;
            this.rbtnTheoDiaTieu.CheckedChanged += new System.EventHandler(this.rbtnTheoPhuongVi_CheckedChanged);
            //
            // rbtnTheoLonLat
            //
            this.rbtnTheoLonLat.AutoSize = true;
            this.rbtnTheoLonLat.Checked = true;
            this.rbtnTheoLonLat.Location = new System.Drawing.Point(15, 66);
            this.rbtnTheoLonLat.Name = "rbtnTheoLonLat";
            this.rbtnTheoLonLat.Size = new System.Drawing.Size(127, 17);
            this.rbtnTheoLonLat.TabIndex = 2;
            this.rbtnTheoLonLat.TabStop = true;
            this.rbtnTheoLonLat.Text = "Nhập theo kinh, vĩ độ";
            this.rbtnTheoLonLat.UseVisualStyleBackColor = true;
            this.rbtnTheoLonLat.CheckedChanged += new System.EventHandler(this.rbtnTheoPhuongVi_CheckedChanged);
            //
            // rbtnTheoPhuongVi
            //
            this.rbtnTheoPhuongVi.AutoSize = true;
            this.rbtnTheoPhuongVi.Location = new System.Drawing.Point(16, 43);
            this.rbtnTheoPhuongVi.Name = "rbtnTheoPhuongVi";
            this.rbtnTheoPhuongVi.Size = new System.Drawing.Size(126, 17);
            this.rbtnTheoPhuongVi.TabIndex = 1;
            this.rbtnTheoPhuongVi.Text = "Nhập theo phương vị";
            this.rbtnTheoPhuongVi.UseVisualStyleBackColor = true;
            this.rbtnTheoPhuongVi.CheckedChanged += new System.EventHandler(this.rbtnTheoPhuongVi_CheckedChanged);
            this.nudYDo.Location = new System.Drawing.Point(64, 209);
            this.nudYDo.Maximum = new decimal(new int[]
			{
				359,
				0,
				0,
				0
			});
            //
            // nudYDo
            //
            this.nudYDo.Name = "nudYDo";
            this.nudYDo.Size = new System.Drawing.Size(45, 21);
            this.nudYDo.TabIndex = 9;
            this.nudYDo.ValueChanged += new System.EventHandler(this.nudXDo_ValueChanged);
            this.nudXDo.Location = new System.Drawing.Point(64, 183);
            this.nudXDo.Maximum = new decimal(new int[]
			{
				359,
				0,
				0,
				0
			});
            //
            // nudXDo
            //
            this.nudXDo.Name = "nudXDo";
            this.nudXDo.Size = new System.Drawing.Size(45, 21);
            this.nudXDo.TabIndex = 6;
            this.nudXDo.ValueChanged += new System.EventHandler(this.nudXDo_ValueChanged);
            this.nudYGiay.Location = new System.Drawing.Point(163, 209);
            this.nudYGiay.Maximum = new decimal(new int[]
			{
				59,
				0,
				0,
				0
			});
            //
            // nudYGiay
            //
            this.nudYGiay.Name = "nudYGiay";
            this.nudYGiay.Size = new System.Drawing.Size(42, 21);
            this.nudYGiay.TabIndex = 11;
            this.nudYGiay.ValueChanged += new System.EventHandler(this.nudXDo_ValueChanged);
            this.nudXGiay.Location = new System.Drawing.Point(163, 183);
            this.nudXGiay.Maximum = new decimal(new int[]
			{
				59,
				0,
				0,
				0
			});
            //
            // nudXGiay
            //
            this.nudXGiay.Name = "nudXGiay";
            this.nudXGiay.Size = new System.Drawing.Size(42, 21);
            this.nudXGiay.TabIndex = 8;
            this.nudXGiay.ValueChanged += new System.EventHandler(this.nudXDo_ValueChanged);
            this.nudYPhut.Location = new System.Drawing.Point(115, 209);
            this.nudYPhut.Maximum = new decimal(new int[]
			{
				59,
				0,
				0,
				0
			});
            //
            // nudYPhut
            //
            this.nudYPhut.Name = "nudYPhut";
            this.nudYPhut.Size = new System.Drawing.Size(42, 21);
            this.nudYPhut.TabIndex = 10;
            this.nudYPhut.ValueChanged += new System.EventHandler(this.nudXDo_ValueChanged);
            this.nudXPhut.Location = new System.Drawing.Point(115, 183);
            this.nudXPhut.Maximum = new decimal(new int[]
			{
				59,
				0,
				0,
				0
			});
            //
            // nudXPhut
            //
            this.nudXPhut.Name = "nudXPhut";
            this.nudXPhut.Size = new System.Drawing.Size(42, 21);
            this.nudXPhut.TabIndex = 7;
            this.nudXPhut.ValueChanged += new System.EventHandler(this.nudXDo_ValueChanged);
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(24, 211);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(34, 13);
            this.Label13.TabIndex = 79;
            this.Label13.Text = "Vĩ độ:";
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(12, 185);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(46, 13);
            this.Label16.TabIndex = 76;
            this.Label16.Text = "Kinh độ:";
            this.txtBanKinh.Location = new System.Drawing.Point(106, 151);
            //
            // txtBanKinh
            //
            this.txtBanKinh.Name = "txtBanKinh";
            this.txtBanKinh.Size = new System.Drawing.Size(63, 21);
            this.txtBanKinh.TabIndex = 5;
            this.txtBanKinh.Validating += new System.ComponentModel.CancelEventHandler(this.txtBanKinh_Validating);
            this.txtBanKinh.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPhuongVi_KeyUp);
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(49, 154);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(51, 13);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "Bán kính:";
            this.txtPhuongVi.Location = new System.Drawing.Point(106, 127);
            //
            // txtPhuongVi
            //
            this.txtPhuongVi.Name = "txtPhuongVi";
            this.txtPhuongVi.Size = new System.Drawing.Size(63, 21);
            this.txtPhuongVi.TabIndex = 4;
            this.txtPhuongVi.Validating += new System.ComponentModel.CancelEventHandler(this.txtBanKinh_Validating);
            this.txtPhuongVi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPhuongVi_KeyUp);
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(41, 130);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 13);
            this.Label2.TabIndex = 20;
            this.Label2.Text = "Phương vị:";
            //
            // btnChon
            //
            this.btnChon.Image = Properties.Resources.arrow;
            this.btnChon.Location = new System.Drawing.Point(175, 98);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(23, 23);
            this.btnChon.TabIndex = 5;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            this.txtName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtName.Location = new System.Drawing.Point(64, 100);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(105, 21);
            this.txtName.TabIndex = 3;
            this.txtName.TabStop = false;
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(13, 103);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(48, 13);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "Địa tiêu:";
            this.txtPosX.Location = new System.Drawing.Point(12, 517);
            //
            // txtPosX
            //
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.ReadOnly = true;
            this.txtPosX.Size = new System.Drawing.Size(18, 21);
            this.txtPosX.TabIndex = 5;
            this.txtPosX.Visible = false;
            this.txtPosX.TextChanged += new System.EventHandler(this.txtPosX_TextChanged);
            this.txtPosY.Location = new System.Drawing.Point(28, 517);
            //
            // txtPosY
            //
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.ReadOnly = true;
            this.txtPosY.Size = new System.Drawing.Size(18, 21);
            this.txtPosY.TabIndex = 6;
            this.txtPosY.Visible = false;
            this.txtPosY.TextChanged += new System.EventHandler(this.txtPosY_TextChanged);
            this.txtSBTo_ID.Location = new System.Drawing.Point(182, 77);
            this.txtSBTo_ID.Name = "txtSBTo_ID";
            this.txtSBTo_ID.Size = new System.Drawing.Size(20, 21);
            this.txtSBTo_ID.TabIndex = 19;
            this.txtSBTo_ID.Text = "-1";
            this.txtSBTo_ID.Visible = false;
            this.txtStt.Location = new System.Drawing.Point(182, 23);
            this.txtStt.Name = "txtStt";
            this.txtStt.Size = new System.Drawing.Size(20, 21);
            this.txtStt.TabIndex = 25;
            this.txtStt.Text = "-1";
            this.txtStt.Visible = false;
            this.txtPath_ID.Location = new System.Drawing.Point(182, 50);
            this.txtPath_ID.Name = "txtPath_ID";
            this.txtPath_ID.Size = new System.Drawing.Size(20, 21);
            this.txtPath_ID.TabIndex = 24;
            this.txtPath_ID.Text = "-1";
            this.txtPath_ID.Visible = false;
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(45, 44);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(43, 13);
            this.Label6.TabIndex = 12;
            this.Label6.Text = "Tốc độ:";
            this.txtAltitude.Location = new System.Drawing.Point(94, 15);
            //
            // txtAltitude
            //
            this.txtAltitude.Name = "txtAltitude";
            this.txtAltitude.Size = new System.Drawing.Size(63, 21);
            this.txtAltitude.TabIndex = 0;
            this.txtAltitude.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPhuongVi_KeyUp);
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(46, 18);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(45, 13);
            this.Label7.TabIndex = 10;
            this.Label7.Text = "Độ cao:";
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(22, 93);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(66, 13);
            this.Label9.TabIndex = 14;
            this.Label9.Text = "Độ nghiêng:";
            this.nudRoll.Increment = new decimal(new int[]
			{
				5,
				0,
				0,
				0
			});
            this.nudRoll.Location = new System.Drawing.Point(94, 91);
            this.nudRoll.Maximum = new decimal(new int[]
			{
				90,
				0,
				0,
				0
			});
            //
            // nudRoll
            //
            this.nudRoll.Name = "nudRoll";
            this.nudRoll.Size = new System.Drawing.Size(63, 21);
            this.nudRoll.TabIndex = 3;
            this.nudRoll.ValueChanged += new System.EventHandler(this.nudRoll_ValueChanged);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.nudTspeed);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.cboTurn);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.nudSpeed);
            this.GroupBox2.Controls.Add(this.txtStt);
            this.GroupBox2.Controls.Add(this.nudRoll);
            this.GroupBox2.Controls.Add(this.txtPath_ID);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.txtSBTo_ID);
            this.GroupBox2.Controls.Add(this.txtAltitude);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Location = new System.Drawing.Point(12, 361);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(215, 150);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(164, 66);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(12, 13);
            this.Label5.TabIndex = 30;
            this.Label5.Text = "s";
            this.nudTspeed.Location = new System.Drawing.Point(94, 64);
            this.nudTspeed.Maximum = new decimal(new int[]
			{
				999999999,
				0,
				0,
				0
			});
            //
            // nudTspeed
            //
            this.nudTspeed.Name = "nudTspeed";
            this.nudTspeed.Size = new System.Drawing.Size(63, 21);
            this.nudTspeed.TabIndex = 2;
            this.nudTspeed.ValueChanged += new System.EventHandler(this.nudRoll_ValueChanged);
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(13, 66);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(78, 13);
            this.Label4.TabIndex = 29;
            this.Label4.Text = "Tg thay đổi tđ:";
            //
            // cboTurn
            //
            this.cboTurn.FormattingEnabled = true;
            this.cboTurn.Items.AddRange(new object[]
			{
				"Không",
				"Phải",
				"Trái"
			});
            this.cboTurn.Location = new System.Drawing.Point(94, 118);
            this.cboTurn.Name = "cboTurn";
            this.cboTurn.Size = new System.Drawing.Size(63, 21);
            this.cboTurn.TabIndex = 4;
            this.cboTurn.Text = "Không";
            this.cboTurn.SelectedIndexChanged += new System.EventHandler(this.nudRoll_ValueChanged);
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(53, 121);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(35, 13);
            this.Label8.TabIndex = 27;
            this.Label8.Text = "Vòng:";
            this.nudSpeed.Increment = new decimal(new int[]
			{
				10,
				0,
				0,
				0
			});
            this.nudSpeed.Location = new System.Drawing.Point(94, 42);
            this.nudSpeed.Maximum = new decimal(new int[]
			{
				6000,
				0,
				0,
				0
			});
            //
            // nudSpeed
            //
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(63, 21);
            this.nudSpeed.TabIndex = 1;
            this.nudSpeed.ValueChanged += new System.EventHandler(this.nudRoll_ValueChanged);
            this.GroupBox3.Controls.Add(this.rbtnHuongDiem);
            this.GroupBox3.Controls.Add(this.rbtnQuanhDiem);
            this.GroupBox3.Controls.Add(this.rbtnDenDiem);
            this.GroupBox3.Location = new System.Drawing.Point(12, 12);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(215, 97);
            this.GroupBox3.TabIndex = 8;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Cách thực hiện vòng:";
            //
            // rbtnHuongDiem
            //
            this.rbtnHuongDiem.AutoSize = true;
            this.rbtnHuongDiem.Location = new System.Drawing.Point(46, 66);
            this.rbtnHuongDiem.Name = "rbtnHuongDiem";
            this.rbtnHuongDiem.Size = new System.Drawing.Size(108, 17);
            this.rbtnHuongDiem.TabIndex = 3;
            this.rbtnHuongDiem.Text = "Vòng hướng điểm";
            this.rbtnHuongDiem.UseVisualStyleBackColor = true;
            this.rbtnHuongDiem.CheckedChanged += new System.EventHandler(this.rbtnQuanhDiem_CheckedChanged);
            //
            // rbtnQuanhDiem
            //
            this.rbtnQuanhDiem.AutoSize = true;
            this.rbtnQuanhDiem.Location = new System.Drawing.Point(46, 43);
            this.rbtnQuanhDiem.Name = "rbtnQuanhDiem";
            this.rbtnQuanhDiem.Size = new System.Drawing.Size(107, 17);
            this.rbtnQuanhDiem.TabIndex = 2;
            this.rbtnQuanhDiem.Text = "Vòng quanh điểm";
            this.rbtnQuanhDiem.UseVisualStyleBackColor = true;
            this.rbtnQuanhDiem.CheckedChanged += new System.EventHandler(this.rbtnQuanhDiem_CheckedChanged);
            //
            // rbtnDenDiem
            //
            this.rbtnDenDiem.AutoSize = true;
            this.rbtnDenDiem.Checked = true;
            this.rbtnDenDiem.Location = new System.Drawing.Point(46, 20);
            this.rbtnDenDiem.Name = "rbtnDenDiem";
            this.rbtnDenDiem.Size = new System.Drawing.Size(95, 17);
            this.rbtnDenDiem.TabIndex = 1;
            this.rbtnDenDiem.TabStop = true;
            this.rbtnDenDiem.Text = "Vòng đến điểm";
            this.rbtnDenDiem.UseVisualStyleBackColor = true;
            this.rbtnDenDiem.CheckedChanged += new System.EventHandler(this.rbtnQuanhDiem_CheckedChanged);
            this.txtCX.Location = new System.Drawing.Point(103, 517);
            //
            // txtCX
            //
            this.txtCX.Name = "txtCX";
            this.txtCX.ReadOnly = true;
            this.txtCX.Size = new System.Drawing.Size(18, 21);
            this.txtCX.TabIndex = 14;
            this.txtCX.Visible = false;
            this.txtCX.TextChanged += new System.EventHandler(this.txtCX_TextChanged);
            this.txtCY.Location = new System.Drawing.Point(124, 517);
            //
            // txtCY
            //
            this.txtCY.Name = "txtCY";
            this.txtCY.ReadOnly = true;
            this.txtCY.Size = new System.Drawing.Size(18, 21);
            this.txtCY.TabIndex = 15;
            this.txtCY.Visible = false;
            this.txtCY.TextChanged += new System.EventHandler(this.txtCY_TextChanged);
            this.txtDpX.Location = new System.Drawing.Point(57, 517);
            //
            // txtDpX
            //
            this.txtDpX.Name = "txtDpX";
            this.txtDpX.ReadOnly = true;
            this.txtDpX.Size = new System.Drawing.Size(18, 21);
            this.txtDpX.TabIndex = 12;
            this.txtDpX.Visible = false;
            this.txtDpX.TextChanged += new System.EventHandler(this.txtDpX_TextChanged);
            this.txtDpY.Location = new System.Drawing.Point(76, 517);
            //
            // txtDpY
            //
            this.txtDpY.Name = "txtDpY";
            this.txtDpY.ReadOnly = true;
            this.txtDpY.Size = new System.Drawing.Size(18, 21);
            this.txtDpY.TabIndex = 13;
            this.txtDpY.Visible = false;
            this.txtDpY.TextChanged += new System.EventHandler(this.txtDpY_TextChanged);
            this.TableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(82, 517);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
            this.TableLayoutPanel1.TabIndex = 16;
            //
            // OK_Button
            //
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(67, 23);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "Nhập";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            //
            // Cancel_Button
            //
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(76, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Bỏ qua";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 552);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Controls.Add(this.txtCX);
            this.Controls.Add(this.txtCY);
            this.Controls.Add(this.txtDpX);
            this.Controls.Add(this.txtDpY);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.txtPosX);
            this.Controls.Add(this.txtPosY);
            this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgFlightNodeEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgNodeDef";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudYDo).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudXDo).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudYGiay).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudXGiay).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudYPhut).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudXPhut).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudRoll).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudTspeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpeed).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox txtPosY;
        private System.Windows.Forms.TextBox txtPosX;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.TextBox txtSBTo_ID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtBanKinh;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtPhuongVi;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtAltitude;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.NumericUpDown nudRoll;
        private System.Windows.Forms.TextBox txtStt;
        private System.Windows.Forms.TextBox txtPath_ID;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.NumericUpDown nudYDo;
        private System.Windows.Forms.NumericUpDown nudXDo;
        private System.Windows.Forms.NumericUpDown nudYGiay;
        private System.Windows.Forms.NumericUpDown nudXGiay;
        private System.Windows.Forms.NumericUpDown nudYPhut;
        private System.Windows.Forms.NumericUpDown nudXPhut;
        private System.Windows.Forms.Label Label13;
        private System.Windows.Forms.Label Label16;
        private System.Windows.Forms.ComboBox cboTurn;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.RadioButton rbtnTheoLonLat;
        private System.Windows.Forms.RadioButton rbtnTheoPhuongVi;
        private System.Windows.Forms.RadioButton rbtnTheoDiaTieu;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.NumericUpDown nudTspeed;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.RadioButton rbtnHuongDiem;
        private System.Windows.Forms.RadioButton rbtnQuanhDiem;
        private System.Windows.Forms.RadioButton rbtnDenDiem;
        private System.Windows.Forms.TextBox txtCX;
        private System.Windows.Forms.TextBox txtCY;
        private System.Windows.Forms.TextBox txtDpX;
        private System.Windows.Forms.TextBox txtDpY;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
    }
}