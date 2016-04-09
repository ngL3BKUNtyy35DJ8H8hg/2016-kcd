namespace HuanLuyen
{
    partial class dlgBaiTap
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
			this.txtBaiTap = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.nudPhut = new System.Windows.Forms.NumericUpDown();
			this.nudGio = new System.Windows.Forms.NumericUpDown();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.cboLoaiBaiTap = new System.Windows.Forms.ComboBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
			this.Label3 = new System.Windows.Forms.Label();
			this.TableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.nudPhut).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.nudGio).BeginInit();
			this.SuspendLayout();
			this.TableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.TableLayoutPanel1.ColumnCount = 2;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
			this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
			this.TableLayoutPanel1.Location = new System.Drawing.Point(169, 180);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
			this.TableLayoutPanel1.TabIndex = 5;
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
			this.txtBaiTap.Location = new System.Drawing.Point(90, 101);
			this.txtBaiTap.Name = "txtBaiTap";
			this.txtBaiTap.Size = new System.Drawing.Size(191, 21);
			this.txtBaiTap.TabIndex = 2;
			this.txtBaiTap.Text = "BT mới";
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(40, 104);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(44, 13);
			this.Label6.TabIndex = 24;
			this.Label6.Text = "Bài tập:";
			this.nudPhut.Location = new System.Drawing.Point(163, 128);
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
			this.nudGio.Location = new System.Drawing.Point(90, 128);
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
            this.nudGio.Value = new decimal(new int[]
			{
				8,
				0,
				0,
				0
			});
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(206, 131);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(29, 13);
			this.Label5.TabIndex = 30;
			this.Label5.Text = "phút";
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(136, 131);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(21, 13);
			this.Label4.TabIndex = 29;
			this.Label4.Text = "giờ";
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(20, 131);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(64, 13);
			this.Label2.TabIndex = 28;
			this.Label2.Text = "Bắt đầu lúc:";
			this.cboLoaiBaiTap.FormattingEnabled = true;
			this.cboLoaiBaiTap.Location = new System.Drawing.Point(90, 21);
			this.cboLoaiBaiTap.Name = "cboLoaiBaiTap";
			this.cboLoaiBaiTap.Size = new System.Drawing.Size(222, 21);
			this.cboLoaiBaiTap.TabIndex = 0;
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(18, 24);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(66, 13);
			this.Label1.TabIndex = 32;
			this.Label1.Text = "Loại bài tập:";
			this.dtpNgayTao.CustomFormat = "dd/MM/yyyy";
			this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpNgayTao.Location = new System.Drawing.Point(90, 53);
			this.dtpNgayTao.Name = "dtpNgayTao";
			this.dtpNgayTao.Size = new System.Drawing.Size(113, 21);
			this.dtpNgayTao.TabIndex = 1;
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(29, 59);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(55, 13);
			this.Label3.TabIndex = 34;
			this.Label3.Text = "Ngày tạo:";
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel_Button;
			this.ClientSize = new System.Drawing.Size(327, 221);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.dtpNgayTao);
			this.Controls.Add(this.cboLoaiBaiTap);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.nudPhut);
			this.Controls.Add(this.nudGio);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.txtBaiTap);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.TableLayoutPanel1);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgBaiTap";
			this.ShowInTaskbar = false;
			this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Bài tập";
			this.TableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.nudPhut).EndInit();
			((System.ComponentModel.ISupportInitialize)this.nudGio).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}


        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.TextBox txtBaiTap;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.NumericUpDown nudPhut;
        private System.Windows.Forms.NumericUpDown nudGio;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox cboLoaiBaiTap;
        private System.Windows.Forms.Label Label1;
    }
}