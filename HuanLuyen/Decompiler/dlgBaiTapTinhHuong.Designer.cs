namespace HuanLuyen
{
    partial class dlgBaiTapTinhHuong
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
			this.btnNew = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.grdDM = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)this.grdDM).BeginInit();
			this.SuspendLayout();
			//
			// btnNew
			//
			this.btnNew.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.btnNew.Location = new System.Drawing.Point(12, 314);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(89, 23);
			this.btnNew.TabIndex = 5;
			this.btnNew.Text = "Tình huống mới";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			//
			// btnUpdate
			//
			this.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnUpdate.Location = new System.Drawing.Point(418, 314);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(89, 23);
			this.btnUpdate.TabIndex = 4;
			this.btnUpdate.Text = "Cập nhật";
			this.grdDM.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.grdDM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdDM.Location = new System.Drawing.Point(11, 12);
			this.grdDM.Name = "grdDM";
			this.grdDM.Size = new System.Drawing.Size(497, 288);
			this.grdDM.TabIndex = 11;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(519, 349);
			this.Controls.Add(this.grdDM);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnUpdate);
			this.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle  = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "dlgBaiTapTinhHuong";
			this.ShowInTaskbar = false;
			this.StartPosition  = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Các loại";
			((System.ComponentModel.ISupportInitialize)this.grdDM).EndInit();
			this.ResumeLayout(false);
		}
        #endregion


        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView grdDM;
		
    }
}