namespace HuanLuyen
{
    partial class dlgBaiTapRada
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
            this.txtTen = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtR = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtSoHieu = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnChon = new System.Windows.Forms.Button();
            this.txtMod = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            this.TableLayoutPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(91, 208);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
            this.TableLayoutPanel1.TabIndex = 0;
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
            this.txtTen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTen.Location = new System.Drawing.Point(91, 12);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(113, 21);
            this.txtTen.TabIndex = 0;
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(39, 15);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(29, 13);
            this.Label6.TabIndex = 22;
            this.Label6.Text = "Tên:";
            //
            // txtR
            //
            this.txtR.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtR.Location = new System.Drawing.Point(91, 84);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(113, 21);
            this.txtR.TabIndex = 2;
            this.txtR.Text = "50";
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(39, 87);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(51, 13);
            this.Label5.TabIndex = 21;
            this.Label5.Text = "Bán kính:";
            this.txtPosY.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPosY.Location = new System.Drawing.Point(91, 153);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.ReadOnly = true;
            this.txtPosY.Size = new System.Drawing.Size(113, 21);
            this.txtPosY.TabIndex = 4;
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(39, 156);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(34, 13);
            this.Label3.TabIndex = 20;
            this.Label3.Text = "Vĩ độ:";
            this.txtPosX.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPosX.Location = new System.Drawing.Point(91, 126);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.ReadOnly = true;
            this.txtPosX.Size = new System.Drawing.Size(113, 21);
            this.txtPosX.TabIndex = 3;
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(39, 129);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Kinh độ:";
            this.txtSoHieu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSoHieu.Location = new System.Drawing.Point(91, 39);
            this.txtSoHieu.MaxLength = 2;
            this.txtSoHieu.Name = "txtSoHieu";
            this.txtSoHieu.Size = new System.Drawing.Size(35, 21);
            this.txtSoHieu.TabIndex = 1;
            this.txtSoHieu.Text = "00";
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(39, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(46, 13);
            this.Label2.TabIndex = 24;
            this.Label2.Text = "Số hiệu:";
            //
            // btnChon
            //
            this.btnChon.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            //this.btnChon.Image = Properties.Resources.arrow;
            this.btnChon.Location = new System.Drawing.Point(214, 129);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(23, 23);
            this.btnChon.TabIndex = 5;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            this.txtMod.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMod.Location = new System.Drawing.Point(12, 208);
            this.txtMod.MaxLength = 2;
            this.txtMod.Name = "txtMod";
            this.txtMod.Size = new System.Drawing.Size(35, 21);
            this.txtMod.TabIndex = 25;
            this.txtMod.Text = "New";
            this.txtMod.Visible = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 249);
            this.Controls.Add(this.txtMod);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.txtSoHieu);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtR);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtPosY);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtPosX);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgRada";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "dlgRada";
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtPosY;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtPosX;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtSoHieu;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.TextBox txtMod;

        #endregion
    }
}