namespace HuanLuyen
{
    partial class dlgTop
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
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.OK_Button = new System.Windows.Forms.Button();
			this.Cancel_Button = new System.Windows.Forms.Button();
			this.txtPath_ID = new System.Windows.Forms.TextBox();
			this.txtFlightNo = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtSoLuong = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.nudGio = new System.Windows.Forms.NumericUpDown();
			this.nudPhut = new System.Windows.Forms.NumericUpDown();
			this.cboLoaiTop = new System.Windows.Forms.ComboBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.nudGiay = new System.Windows.Forms.NumericUpDown();
			this.Label7 = new System.Windows.Forms.Label();
			this.TableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.nudGio).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nudPhut).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nudGiay).BeginInit();
			this.SuspendLayout();
			this.TableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point(93, 162);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
			this.TableLayoutPanel1.TabIndex = 4;
			//
			// OK_Button
			//
			this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.OK_Button.Location = new System.Drawing.Point(3, 3);
			this.OK_Button.Name = "OK_Button";
			this.OK_Button.Size = new System.Drawing.Size(67, 23);
			this.OK_Button.TabIndex = 0;
			this.OK_Button.Text = "OK";
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
			this.Cancel_Button.Text = "Cancel";
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
			this.txtPath_ID.Location = new System.Drawing.Point(210, 40);
			this.txtPath_ID.Name = "txtPath_ID";
			this.txtPath_ID.Size = new System.Drawing.Size(28, 21);
			this.txtPath_ID.TabIndex = 10;
			this.txtPath_ID.Visible = false;
			this.txtFlightNo.Location = new System.Drawing.Point(93, 40);
			this.txtFlightNo.Name = "txtFlightNo";
			this.txtFlightNo.Size = new System.Drawing.Size(100, 21);
			this.txtFlightNo.TabIndex = 1;
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(22, 43);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(65, 13);
			this.Label1.TabIndex = 8;
			this.Label1.Text = "Số hiệu tốp:";
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(24, 98);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(64, 13);
			this.Label2.TabIndex = 11;
			this.Label2.Text = "Bắt đầu lúc:";
			this.txtSoLuong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.txtSoLuong.ForeColor = System.Drawing.SystemColors.ControlText;
			this.txtSoLuong.Location = new System.Drawing.Point(94, 67);
			this.txtSoLuong.Name = "txtSoLuong";
			this.txtSoLuong.Size = new System.Drawing.Size(42, 21);
			this.txtSoLuong.TabIndex = 2;
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(34, 70);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(53, 13);
			this.Label3.TabIndex = 13;
			this.Label3.Text = "Số lượng:";
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(69, 116);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(21, 13);
			this.Label4.TabIndex = 15;
			this.Label4.Text = "giờ";
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(139, 117);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(29, 13);
			this.Label5.TabIndex = 17;
			this.Label5.Text = "phút";
			this.nudGio.Location = new System.Drawing.Point(26, 114);
			this.nudGio.Maximum = new decimal(new int[]
			{
				23,
				0,
				0,
				0
			});
			this.nudGio.Name = "nudGio";
			this.nudGio.Size = new System.Drawing.Size(40, 21);
			this.nudGio.TabIndex = 3;
			this.nudPhut.Location = new System.Drawing.Point(96, 114);
            this.nudPhut.Maximum = new decimal(new int[]
			{
				59,
				0,
				0,
				0
			});
			this.nudPhut.Name = "nudPhut";
			this.nudPhut.Size = new System.Drawing.Size(40, 21);
			this.nudPhut.TabIndex = 4;
			this.cboLoaiTop.FormattingEnabled = true;
			this.cboLoaiTop.Location = new System.Drawing.Point(93, 12);
			this.cboLoaiTop.Name = "cboLoaiTop";
			this.cboLoaiTop.Size = new System.Drawing.Size(143, 21);
			this.cboLoaiTop.TabIndex = 0;
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(36, 15);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(51, 13);
			this.Label6.TabIndex = 31;
			this.Label6.Text = "Loại Tốp:";
			this.nudGiay.Location = new System.Drawing.Point(174, 114);
            this.nudGiay.Maximum = new decimal(new int[]
			{
				59,
				0,
				0,
				0
			});
			this.nudGiay.Name = "nudGiay";
			this.nudGiay.Size = new System.Drawing.Size(40, 21);
			this.nudGiay.TabIndex = 58;
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(217, 117);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(27, 13);
			this.Label7.TabIndex = 59;
			this.Label7.Text = "giây";
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(251, 203);
			this.Controls.Add(this.nudGiay);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.cboLoaiTop);
			this.Controls.Add(this.nudPhut);
			this.Controls.Add(this.nudGio);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.txtSoLuong);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.txtPath_ID);
			this.Controls.Add(this.txtFlightNo);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.TableLayoutPanel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgTop";
			this.ShowInTaskbar = false;
			this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tốp bay";
			this.TableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.nudGio).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nudPhut).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nudGiay).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}


        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.TextBox txtPath_ID;
        private System.Windows.Forms.TextBox txtFlightNo;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.NumericUpDown nudGio;
        private System.Windows.Forms.NumericUpDown nudPhut;
        private System.Windows.Forms.ComboBox cboLoaiTop;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.NumericUpDown nudGiay;
        private System.Windows.Forms.Label Label7;
    }
}