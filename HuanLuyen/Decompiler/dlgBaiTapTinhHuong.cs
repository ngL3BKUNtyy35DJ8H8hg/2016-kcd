using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace HuanLuyen
{
	
	public partial class dlgBaiTapTinhHuong : Form
	{
		private int m_BaiTapID = 0;
		private IDbDataAdapter daDM;
		private DataSet dsDM;
		private DataView dvDM;
		private int currow = 0;
		private int curcol = 0;
		public dlgBaiTapTinhHuong()
		{
			base.Load += new EventHandler(this.dlgBaiTapTinhHuong_Load);
			base.FormClosing += new FormClosingEventHandler(this.dlgBaiTapTinhHuong_FormClosing);
			this.currow = 0;
			this.curcol = 0;
			this.InitializeComponent();
		}
						private void UpdateDS(DataSet inDS, int pBaiTapID)
		{
			if (inDS == null)
			{
				return;
			}
			try
			{
				if (this.daDM == null)
				{
					this.daDM = modHuanLuyen.g_objConnFactory.CreateAdapter();
					this.dsDM = CTinhHuongs.CreateDS(ref this.daDM, pBaiTapID);
				}
				inDS.EnforceConstraints = false;
				this.daDM.Update(inDS);
			}
			catch (Exception expr_44)
			{
				throw expr_44;
				Exception ex = expr_44;
				MessageBox.Show("UpdateDS: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
				this.RefreshDM(pBaiTapID);
							}
		}
		private void RefreshDM(int pBaiTapID)
		{
				try
				{
					this.dsDM = CTinhHuongs.CreateDS(ref this.daDM, pBaiTapID);
					this.dvDM = this.dsDM.Tables[0].DefaultView;
					this.dvDM.Sort = "Phut";
					DataGridView grdDM = this.grdDM;
					grdDM.DataSource = null;
					grdDM.Columns.Clear();
					grdDM.DataSource = this.dvDM;
					grdDM.AllowUserToAddRows = false;
					grdDM.AllowUserToResizeRows = false;
					grdDM.RowHeadersWidth = 30;
					grdDM.MultiSelect = false;
					int num = 0;
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grdDM.Columns[num];
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = dataGridViewTextBoxColumn;
					dataGridViewTextBoxColumn2.DataPropertyName = "Phut";
					dataGridViewTextBoxColumn2.Name = "Phut";
					dataGridViewTextBoxColumn2.HeaderText = "Phút";
					dataGridViewTextBoxColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
					dataGridViewTextBoxColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dataGridViewTextBoxColumn2.Width = 40;
					dataGridViewTextBoxColumn2.Visible = true;
					dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
					num++;
					dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grdDM.Columns[num];
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = dataGridViewTextBoxColumn;
					dataGridViewTextBoxColumn3.DataPropertyName = "TinhHuong";
					dataGridViewTextBoxColumn3.Name = "TinhHuong";
					dataGridViewTextBoxColumn3.HeaderText = "Tình huống";
					dataGridViewTextBoxColumn3.Width = 400;
					dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
					num++;
					dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grdDM.Columns[num];
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn4 = dataGridViewTextBoxColumn;
					dataGridViewTextBoxColumn4.DataPropertyName = "BaiTapID";
					dataGridViewTextBoxColumn4.Name = "BaiTapID";
					dataGridViewTextBoxColumn4.ReadOnly = true;
					dataGridViewTextBoxColumn4.Visible = false;
					num++;
					dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grdDM.Columns[num];
					DataGridViewTextBoxColumn dataGridViewTextBoxColumn5 = dataGridViewTextBoxColumn;
					dataGridViewTextBoxColumn5.DataPropertyName = "Stt";
					dataGridViewTextBoxColumn5.Name = "Stt";
					dataGridViewTextBoxColumn5.ReadOnly = true;
					dataGridViewTextBoxColumn5.Visible = false;
					this.btnUpdate.Enabled = true;
			this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
				}
				catch (Exception expr_1E4)
				{
					throw expr_1E4;
					Exception ex = expr_1E4;
					MessageBox.Show("RefreshTinhHuong: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
									}
					}
		private void AddNewRow(DataView dv)
		{
			int num = dv.Count;
			int num2 = num;
				if (dv.Count > 0)
				{
					num = Convert.ToInt32(dv[dv.Count - 1]["Stt"]);
					num2 = Convert.ToInt32(dv[dv.Count - 1]["Phut"]);
				}
				DataRowView dataRowView = dv.AddNew();
				dataRowView["Phut"] = num2 + 1;
				dataRowView["TinhHuong"] = "Tình huống ...";
				dataRowView["BaiTapID"] = this.m_BaiTapID;
				dataRowView["Stt"] = num + 1;
				dataRowView.EndEdit();
					}
		private void btnNew_Click(object sender, EventArgs e)
		{
			this.AddNewRow(this.dvDM);
		}
		private void dlgBaiTapTinhHuong_FormClosing(object sender, FormClosingEventArgs e)
		{
		}
		private void dlgBaiTapTinhHuong_Load(object sender, EventArgs e)
		{
			this.Text = "Các Tình huống";
			CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fBaiTapHinhThai.cboBaiTap.SelectedItem;
			this.m_BaiTapID = cBaiTap.BaiTapID;
			try
			{
				this.daDM = modHuanLuyen.g_objConnFactory.CreateAdapter();
				this.RefreshDM(this.m_BaiTapID);
			}
			catch (Exception expr_4A)
			{
				throw expr_4A;
				MessageBox.Show("Khong duoc.", "Thông báo", MessageBoxButtons.OK);
				this.Close();
							}
		}
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			this.UpdateDS(this.dsDM.GetChanges(), this.m_BaiTapID);
			this.Close();
		}
	}
}