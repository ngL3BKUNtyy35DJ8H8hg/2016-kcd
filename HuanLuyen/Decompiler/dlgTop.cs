using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace HuanLuyen
{
	
	public partial class dlgTop : Form
	{
		
		private CTop m_EditingTop;
		private bool isnew;
		public dlgTop()
		{
			base.Load += new EventHandler(this.dlgTop_Load);
			this.isnew = true;
			this.InitializeComponent();
		}
						private bool IsValidForm()
		{
			if (!this.isnew)
			{
				return true;
			}
			if (this.txtFlightNo.Text.Length == 0)
			{
				MessageBox.Show("Chưa cho biết Mã chuyến bay.");//, "Thông báo", MessageBoxButtons.Exclamation, this.Text);
				return false;
			}
			return true;
		}
		private void OK_Button_Click(object sender, EventArgs e)
		{
			if (!this.IsValidForm())
			{
				return;
			}
			if (this.cboLoaiTop.SelectedItem != null)
			{
				CTop editingTop = this.m_EditingTop;
				editingTop.FlightNo = this.txtFlightNo.Text;
				editingTop.GioBatDau = Convert.ToInt32(this.nudGio.Value);
				editingTop.PhutBatDau = Convert.ToInt32(this.nudPhut.Value);
				editingTop.GiayBatDau = Convert.ToInt32(this.nudGiay.Value);
				editingTop.SoLuong = checked((int)Math.Round(double.Parse(this.txtSoLuong.Text)));
				CLoaiTop cLoaiTop = (CLoaiTop)this.cboLoaiTop.SelectedItem;
				editingTop.LoaiTopID = cLoaiTop.LoaiTopID;
				if (!this.isnew)
				{
					CTops.Update(this.m_EditingTop);
				}
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}
		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		public void PopulateLoaiTops()
		{
			List<CLoaiTop> list = CLoaiTops.GetList();
			this.cboLoaiTop.DataSource = list;
		}
		private int GetIndexOf(int pLoaiTopID)
		{
			int result = -1;
				int num = this.cboLoaiTop.Items.Count - 1;
				for (int i = 0; i < num; i++)
				{
					CLoaiTop cLoaiTop = (CLoaiTop)this.cboLoaiTop.Items[i];
					if (cLoaiTop.LoaiTopID == pLoaiTopID)
					{
						result = i;
						break;
					}
				}
				return result;
					}
		public DialogResult ShowDialog(Form parent, CTop pEditingTop)
		{
			this.m_EditingTop = pEditingTop;
			return this.ShowDialog(parent);
		}
		private void dlgTop_Load(object sender, EventArgs e)
		{
			this.PopulateLoaiTops();
			CTop editingTop = this.m_EditingTop;
			this.nudGio.Value = new decimal(editingTop.GioBatDau);
			this.nudPhut.Value = new decimal(editingTop.PhutBatDau);
			this.nudGiay.Value = new decimal(editingTop.GiayBatDau);
			this.txtFlightNo.Text = editingTop.FlightNo;
			this.txtSoLuong.Text = editingTop.SoLuong.ToString();
			this.cboLoaiTop.SelectedIndex = this.GetIndexOf(editingTop.LoaiTopID);
			if (this.m_EditingTop.TopID > 0)
			{
				this.isnew = false;
				this.OK_Button.Text = "Cập nhật";
			}
			else
			{
				this.isnew = true;
				this.OK_Button.Text = "Thêm tốp";
			}
		}
	}
}