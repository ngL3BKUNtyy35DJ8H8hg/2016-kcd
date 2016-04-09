using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace HuanLuyen
{
	
	public partial class dlgBaiTap : Form
	{
		
		private DateTimePicker dtpNgayTao;
		private System.Windows.Forms.Label Label3;
		private CBaiTap myBaiTap;
		private List<CLoaiBaiTap> myLoaiBaiTaps;
		public dlgBaiTap()
		{
			base.Load += new EventHandler(this.dlgBaiTapNew_Load);
			this.InitializeComponent();
		}
						private void PopulateLoaiBaiTap()
		{
			this.myLoaiBaiTaps = CLoaiBaiTaps.GetList();
			this.cboLoaiBaiTap.DataSource = this.myLoaiBaiTaps;
		}
		private int GetIndexOf(int pLoaiBaiTap_ID)
		{
			int result = -1;
				int num = this.cboLoaiBaiTap.Items.Count - 1;
				for (int i = 0; i < num; i++)
				{
					CLoaiBaiTap cLoaiBaiTap = (CLoaiBaiTap)this.cboLoaiBaiTap.Items[i];
					if (cLoaiBaiTap.LoaiBaiTapID == pLoaiBaiTap_ID)
					{
						result = i;
						break;
					}
				}
				return result;
        }
		private void OK_Button_Click(object sender, EventArgs e)
		{
			if (this.cboLoaiBaiTap.SelectedItem == null)
			{
				MessageBox.Show("Chưa chọn loại bài tập, chọn lại...", "Thông báo", MessageBoxButtons.OK);
				return;
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		public DialogResult ShowDialog(Form parent, CBaiTap pBaiTap)
		{
			this.myBaiTap = pBaiTap;
			return this.ShowDialog(parent);
		}
		private void dlgBaiTapNew_Load(object sender, EventArgs e)
		{
			this.PopulateLoaiBaiTap();
			this.cboLoaiBaiTap.SelectedIndex = this.GetIndexOf(this.myBaiTap.LoaiBaiTapID);
		}
	}
}