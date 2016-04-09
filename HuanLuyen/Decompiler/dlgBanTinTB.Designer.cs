using System.ComponentModel;
namespace HuanLuyen
{
    partial class dlgBanTinTB
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
            this.btnTaoBT = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtSoPhut = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btnBTGanToExcel = new System.Windows.Forms.Button();
            this.grdTBGan = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.btnBT55ToExcel = new System.Windows.Forms.Button();
            this.grdTB55 = new System.Windows.Forms.DataGridView();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.btnBT99ToExcel = new System.Windows.Forms.Button();
            this.grdTB99 = new System.Windows.Forms.DataGridView();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTBGan)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTB55)).BeginInit();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTB99)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTaoBT
            // 
            this.btnTaoBT.Location = new System.Drawing.Point(238, 12);
            this.btnTaoBT.Name = "btnTaoBT";
            this.btnTaoBT.Size = new System.Drawing.Size(174, 23);
            this.btnTaoBT.TabIndex = 40;
            this.btnTaoBT.Text = "Tạo các bản tin tình báo";
            this.btnTaoBT.UseVisualStyleBackColor = true;
            this.btnTaoBT.Click += new System.EventHandler(this.btnTaoBT_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(176, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(29, 13);
            this.Label1.TabIndex = 44;
            this.Label1.Text = "phút";
            // 
            // txtSoPhut
            // 
            this.txtSoPhut.Location = new System.Drawing.Point(130, 14);
            this.txtSoPhut.Name = "txtSoPhut";
            this.txtSoPhut.Size = new System.Drawing.Size(40, 21);
            this.txtSoPhut.TabIndex = 42;
            this.txtSoPhut.Text = "45";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 17);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(110, 13);
            this.Label2.TabIndex = 41;
            this.Label2.Text = "Thời gian huấn luyện:";
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Location = new System.Drawing.Point(6, 52);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(486, 470);
            this.TabControl1.TabIndex = 45;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.btnBTGanToExcel);
            this.TabPage1.Controls.Add(this.grdTBGan);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(478, 444);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "TB gần";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btnBTGanToExcel
            // 
            this.btnBTGanToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBTGanToExcel.Location = new System.Drawing.Point(378, 11);
            this.btnBTGanToExcel.Name = "btnBTGanToExcel";
            this.btnBTGanToExcel.Size = new System.Drawing.Size(94, 23);
            this.btnBTGanToExcel.TabIndex = 5;
            this.btnBTGanToExcel.Text = "Xuất ra Excel";
            this.btnBTGanToExcel.UseVisualStyleBackColor = true;
            this.btnBTGanToExcel.Click += new System.EventHandler(this.btnBTGanToExcel_Click);
            // 
            // grdTBGan
            // 
            this.grdTBGan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTBGan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTBGan.Location = new System.Drawing.Point(6, 40);
            this.grdTBGan.Name = "grdTBGan";
            this.grdTBGan.Size = new System.Drawing.Size(466, 399);
            this.grdTBGan.TabIndex = 4;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.btnBT55ToExcel);
            this.TabPage2.Controls.Add(this.grdTB55);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(478, 444);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "TB 5x5";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBT55ToExcel
            // 
            this.btnBT55ToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBT55ToExcel.Location = new System.Drawing.Point(378, 11);
            this.btnBT55ToExcel.Name = "btnBT55ToExcel";
            this.btnBT55ToExcel.Size = new System.Drawing.Size(94, 23);
            this.btnBT55ToExcel.TabIndex = 6;
            this.btnBT55ToExcel.Text = "Xuất ra Excel";
            this.btnBT55ToExcel.UseVisualStyleBackColor = true;
            this.btnBT55ToExcel.Click += new System.EventHandler(this.btnBT55ToExcel_Click);
            // 
            // grdTB55
            // 
            this.grdTB55.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTB55.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTB55.Location = new System.Drawing.Point(6, 40);
            this.grdTB55.Name = "grdTB55";
            this.grdTB55.Size = new System.Drawing.Size(466, 432);
            this.grdTB55.TabIndex = 5;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.btnBT99ToExcel);
            this.TabPage3.Controls.Add(this.grdTB99);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new System.Drawing.Size(478, 444);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "TB 9x9";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // btnBT99ToExcel
            // 
            this.btnBT99ToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBT99ToExcel.Location = new System.Drawing.Point(378, 11);
            this.btnBT99ToExcel.Name = "btnBT99ToExcel";
            this.btnBT99ToExcel.Size = new System.Drawing.Size(94, 23);
            this.btnBT99ToExcel.TabIndex = 6;
            this.btnBT99ToExcel.Text = "Xuất ra Excel";
            this.btnBT99ToExcel.UseVisualStyleBackColor = true;
            this.btnBT99ToExcel.Click += new System.EventHandler(this.btnBT99ToExcel_Click);
            // 
            // grdTB99
            // 
            this.grdTB99.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTB99.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTB99.Location = new System.Drawing.Point(6, 40);
            this.grdTB99.Name = "grdTB99";
            this.grdTB99.Size = new System.Drawing.Size(466, 432);
            this.grdTB99.TabIndex = 5;
            // 
            // dlgBanTinTB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 534);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.txtSoPhut);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnTaoBT);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgBanTinTB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Các bản tin tình báo";
            this.Load += new System.EventHandler(this.dlgBanTinTB_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTBGan)).EndInit();
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTB55)).EndInit();
            this.TabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTB99)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.Button btnTaoBT;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtSoPhut;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.TabPage TabPage3;
        private System.Windows.Forms.DataGridView grdTBGan;
        private System.Windows.Forms.DataGridView grdTB55;
        private System.Windows.Forms.DataGridView grdTB99;
        private System.Windows.Forms.Button btnBTGanToExcel;
        private System.Windows.Forms.Button btnBT55ToExcel;
        private System.Windows.Forms.Button btnBT99ToExcel;

        #endregion
    }
}