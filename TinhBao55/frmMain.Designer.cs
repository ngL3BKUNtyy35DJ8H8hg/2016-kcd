using System.Drawing;
using System;
using System.Windows.Forms;
namespace TinhBao55
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
            this.lblLine = new System.Windows.Forms.Label();
            this.lblLoi = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnReRead = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnNgatKetNoi = new System.Windows.Forms.Button();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLine
            // 
            this.lblLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine.Location = new System.Drawing.Point(12, 69);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(658, 43);
            this.lblLine.TabIndex = 2;
            this.lblLine.Text = "Label1Label1Label1Label1Label1 Label1Label1Label1Label1 Label1Label1Label1Label1 " +
                "Label1Label1Label1Label1 Label1Label1Label1Label1 Label1 Label1 Label1 Label1";
            // 
            // lblLoi
            // 
            this.lblLoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoi.Location = new System.Drawing.Point(12, 255);
            this.lblLoi.Name = "lblLoi";
            this.lblLoi.Size = new System.Drawing.Size(658, 148);
            this.lblLoi.TabIndex = 3;
            this.lblLoi.Text = "Label1Label1Label1Label1Label1 Label1Label1Label1Label1 Label1Label1Label1Label1 " +
                "Label1Label1Label1Label1 Label1Label1Label1Label1 Label1 Label1 Label1 Label1";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 214);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(51, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Lời thoại:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 47);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(98, 13);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Bản tin nhận được:";
            // 
            // btnReRead
            // 
            this.btnReRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReRead.Location = new System.Drawing.Point(593, 210);
            this.btnReRead.Name = "btnReRead";
            this.btnReRead.Size = new System.Drawing.Size(75, 23);
            this.btnReRead.TabIndex = 9;
            this.btnReRead.Text = "Đọc lại";
            this.btnReRead.UseVisualStyleBackColor = true;
            this.btnReRead.Click += new System.EventHandler(this.btnReRead_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 15);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(109, 13);
            this.Label3.TabIndex = 31;
            this.Label3.Text = "Tên máy Huấn luyện:";
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(127, 12);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(381, 21);
            this.txtServer.TabIndex = 30;
            // 
            // btnNgatKetNoi
            // 
            this.btnNgatKetNoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNgatKetNoi.Enabled = false;
            this.btnNgatKetNoi.Location = new System.Drawing.Point(595, 10);
            this.btnNgatKetNoi.Name = "btnNgatKetNoi";
            this.btnNgatKetNoi.Size = new System.Drawing.Size(75, 23);
            this.btnNgatKetNoi.TabIndex = 29;
            this.btnNgatKetNoi.Text = "Ngắt kết nối";
            this.btnNgatKetNoi.UseVisualStyleBackColor = true;
            this.btnNgatKetNoi.Click += new System.EventHandler(this.btnNgatKetNoi_Click);
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKetNoi.Location = new System.Drawing.Point(514, 10);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(75, 23);
            this.btnKetNoi.TabIndex = 28;
            this.btnKetNoi.Text = "Kết nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 415);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnNgatKetNoi);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.btnReRead);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblLoi);
            this.Controls.Add(this.lblLine);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblLoi;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Button btnReRead;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnNgatKetNoi;
        private System.Windows.Forms.Button btnKetNoi;
    }
}

