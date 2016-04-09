using MapXLib;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace HuanLuyen
{

    public partial class dlgBaiTapRada : Form
    {
        private bool bloaded;
        public dlgBaiTapRada()
        {
            base.FormClosing += new FormClosingEventHandler(this.dlgBaiTapRada_FormClosing);
            base.Load += new EventHandler(this.dlgBaiTapRada_Load);
            this.bloaded = false;
            this.InitializeComponent();
        }
        
        private void OK_Button_Click(object sender, EventArgs e)
        {
            CRada newRada = modHuanLuyen.fBaiTapHinhThai.NewRada;
            newRada.SoHieu = this.txtSoHieu.Text;
            newRada.Ten = this.txtTen.Text;
            if (this.txtMod.Text == "New")
            {
                CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fBaiTapHinhThai.cboBaiTap.SelectedItem;
                int num = checked(CBaiTapRadas.GetMaxID(cBaiTap.BaiTapID) + 1);
                modHuanLuyen.fBaiTapHinhThai.NewRada.RadaID = num;
                CBaiTapRadas.Insert(cBaiTap.BaiTapID, modHuanLuyen.fBaiTapHinhThai.NewRada);
                modHuanLuyen.fBaiTapHinhThai.PopulateBaiTapRadas(cBaiTap.BaiTapID, num);
            }
            else
            {
                CBaiTapRadas.Update(modHuanLuyen.fBaiTapHinhThai.NewRada);
                modHuanLuyen.fBaiTapHinhThai.RefreshRadaList(modHuanLuyen.fBaiTapHinhThai.NewRada);
            }
            modHuanLuyen.fBaiTapHinhThai.lyrCacKyHieu.Invalidate(Missing.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void dlgBaiTapRada_FormClosing(object sender, FormClosingEventArgs e)
        {
            modHuanLuyen.fBaiTapHinhThai.AxMap1.CurrentTool = ToolConstants.miArrowTool;
            modHuanLuyen.fBaiTapHinhThai.NewRada = null;
            modHuanLuyen.fBaiTapRada = null;
        }
        private void dlgBaiTapRada_Load(object sender, EventArgs e)
        {
            modHuanLuyen.fBaiTapRada = this;
            CRada newRada = modHuanLuyen.fBaiTapHinhThai.NewRada;
            this.txtPosX.Text = newRada.PosX.ToString("#.00000000");
            this.txtPosY.Text = newRada.PosY.ToString("#.00000000");
            this.txtR.Text = newRada.R.ToString();
            this.txtR.TextChanged += new EventHandler(this.txtR_TextChanged);
            this.txtSoHieu.Text = newRada.SoHieu;
            this.txtTen.Text = newRada.Ten;
            this.bloaded = true;
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            modHuanLuyen.fBaiTapHinhThai.AxMap1.CurrentTool = (ToolConstants)4;
        }
        private void txtR_TextChanged(object sender, EventArgs e)
        {
            if (this.bloaded)
            {
                try
                {
                    float num = Convert.ToSingle(this.txtR.Text);
                    if (num > 0f)
                    {
                        modHuanLuyen.fBaiTapHinhThai.NewRada.R = num;
                        modHuanLuyen.fBaiTapHinhThai.lyrAnimation.Invalidate(Missing.Value);
                    }
                }
                catch (Exception expr_47)
                {
                    throw expr_47;
                }
            }
        }
    }
}