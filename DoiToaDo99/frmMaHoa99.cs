using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using HuanLuyen;
using ADOConnection;
using System.IO;

namespace DoiToaDo
{
    public partial class frmMaHoa99 : Form
    {
        public string m_mod;
        public int m_LastMaHoaID = 0;
        private List<CMaHoa> m_MaHoas;
        private CMaHoa m_SeleMaHoa;
        private bool bLoaded;
        private string[] strMaHoaCoBan;
        private int m_SeleCoBanIndex = 0;
        private static int m_cantimMaHoaID = 0;
        private double m_index;

        public CMaHoa SeLeMaHoa
        {
            get
            {
                return this.m_SeleMaHoa;
            }
        }

        public frmMaHoa99()
        {
            this.m_mod = "";
            this.m_LastMaHoaID = 0;
            this.m_SeleMaHoa = null;
            this.bLoaded = false;
            this.m_SeleCoBanIndex = 0;
            this.InitializeComponent();
        }

        private bool ConnectCSDL()
        {
            bool result = false;
            try
            {
                modHuanLuyen.g_CSDLSecu = modHuanLuyen.GetCSDLSecu(modHuanLuyen.myCSDLMK);
                modHuanLuyen.g_objConnFactory = new CConnFactory(modHuanLuyen.myCnnString, modHuanLuyen.g_CSDLSecu.User_ID, modHuanLuyen.g_CSDLSecu.Pwd);
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                if (connection == null)
                {
                    MessageBox.Show("Không kết nối được với CSDL0.");
                }
                else
                {
                    connection.Close();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được với CSDL.");
            }
            finally
            {
            }
            return result;
        }

        private void LoadPara(string pDefFile)
        {
            if (modHuanLuyen.File2Para(pDefFile))
            {
                modHuanLuyen.myCurrentDirectory = Directory.GetCurrentDirectory();
                this.Text = modHuanLuyen.myTenCT;
                //if (!this.InitMap())
                //{
                //    MessageBox.Show("Init map truc trac, xem lai '*.para'");
                //    return;
                //}
                //modBdTC.LoadDefa(modBdTC.myBdTCDefaFile);
                //this.AxMap1.CreateCustomTool(2, ToolTypeConstants.miToolTypePoint, CursorConstants.miCrossCursor);
                //this.AxMap1.CreateCustomTool(4, ToolTypeConstants.miToolTypePoint, CursorConstants.miArrowQuestionCursor);
                if (File.Exists(modHuanLuyen.myDefaFile))
                {
                    modHuanLuyen.LoadDefa(modHuanLuyen.myDefaFile);
                }
                if (File.Exists(modHuanLuyen.myGocPvClFile))
                {
                    modHuanLuyen.LoadGocPvCl(modHuanLuyen.myGocPvClFile);
                }
                if (this.ConnectCSDL())
                {
                    //this.LoadNodePatterns();
                    //this.myTblName = "tblAirport";
                    //this.PopulateAirports();
                    //this.myTblName = "tblDiaTieu";
                    //this.PopulateAirports();
                    //this.myTblName = "tblTramQS";
                    //this.PopulateAirports();
                    //this.PopulatePattern4Airport();
                }
            }
            else
            {
                MessageBox.Show("Khong load duoc para");
            }
        }

        private void frmMaHoa99_Load(object sender, EventArgs e)
        {
            chkDoiTheoDongCot_CheckedChanged(null, null);

            modHuanLuyen.myAppPara = "HuanLuyen.para";
            if (File.Exists(modHuanLuyen.myAppPara))
            {
                this.LoadPara(modHuanLuyen.myAppPara);
            }

            this.strMaHoaCoBan = new string[10];
            this.bLoaded = true;
            this.EnableMaToaDo(false);
            this.populateLst();
            if (this.m_mod == "Chon")
            {
                CMaHoa maHoa = this.GetMaHoa(this.m_LastMaHoaID);
                this.lstMaHoas.SelectedIndex = this.m_MaHoas.IndexOf(maHoa);
            }
        }

        private CMaHoa GetMaHoa(int pMaHoaID)
        {
            m_cantimMaHoaID = pMaHoaID;
            return this.m_MaHoas.Find(new Predicate<CMaHoa>(frmMaHoa99.MaHoaIDequal));
        }

        private static bool MaHoaIDequal(CMaHoa pMaHoa)
        {
            return pMaHoa.MaHoaID == m_cantimMaHoaID;
        }

        private void populateLst()
        {
            this.lstMaHoas.DataSource = null;
            this.m_MaHoas = CMaHoas.GetList();
            this.lstMaHoas.DataSource = this.m_MaHoas;
            if (this.m_MaHoas.Count > 0)
            {
                this.lstMaHoas.SelectedIndex = checked(this.m_MaHoas.Count - 1);
            }
        }

        private void populateLst(int pMaHoaID)
        {
            this.lstMaHoas.DataSource = null;
            this.m_MaHoas = CMaHoas.GetList();
            this.lstMaHoas.DataSource = this.m_MaHoas;
            int selectedIndex = -1;
            int num = -1;
            foreach (CMaHoa current in this.m_MaHoas)
            {
                num++;
                if (current.MaHoaID == pMaHoaID)
                {
                    selectedIndex = num;
                    break;
                }
            }

            this.lstMaHoas.SelectedIndex = selectedIndex;
        }
        private void RefreshLst()
        {
            this.lstMaHoas.DataSource = null;
            this.lstMaHoas.DataSource = this.m_MaHoas;
            if (this.m_MaHoas.Count > 0)
            {
                this.lstMaHoas.SelectedIndex = checked(this.m_MaHoas.Count - 1);
            }
        }





        #region He toa do 9x9
        private void Populate99OLonChuan()
        {
            this.Populate99OLon(modMaHoa.str99OLonChuan);
        }

        private void Populate99CoBanChuan()
        {
            string strCoBanChuan = modMaHoa.GetStrCoBanChuan();
            this.Populate99CoBan(strCoBanChuan);
        }

        private void Populate99OLon(string strMaHoa)
        {
            string[] array = strMaHoa.Split(new char[]
            {
                ','
            });
            if (array.GetUpperBound(0) == 9)
            {
                int num = 0;
                do
                {
                    int num2 = 0;
                    do
                    {
                        int num3 = num * 2 + num2;
                        string name = "txtOLon" + num.ToString("0") + num2.ToString("0");
                        TextBox textBoxFromName = this.getTextBoxFromName(name);
                        textBoxFromName.Text = array[num3];
                        num2++;
                    }
                    while (num2 <= 1);
                    num++;
                }
                while (num <= 4);
            }
            else
            {
                MessageBox.Show("strMaHoa sai " + array.GetUpperBound(0).ToString(), "Thông báo", MessageBoxButtons.OK);
            }
        }
        private string GetStr99Lon()
        {
            string text = "";
            int num = 0;
            do
            {
                int num2 = 0;
                do
                {
                    string name = "txtOLon" + num.ToString("0") + num2.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(name);
                    if (text.Length > 0)
                    {
                        text = text + "," + double.Parse(textBoxFromName.Text).ToString("0");
                    }
                    else
                    {
                        text += double.Parse(textBoxFromName.Text).ToString("0");
                    }
                    num2++;
                }
                while (num2 <= 1);
                num++;
            }
            while (num <= 4);
            return text;
        }
        private bool Is99LonOK()
        {
            bool result = true;
            string[] array = new string[10];
            int num = -1;
            int num2 = 0;
            do
            {
                int num3 = 0;
                do
                {
                    string name = "txtOLon" + num2.ToString("0") + num3.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(name);
                    num++;
                    array[num] = double.Parse(textBoxFromName.Text).ToString();
                    num3++;
                }
                while (num3 <= 1);
                num2++;
            }
            while (num2 <= 4);
            int num4 = 0;
            while (!(Convert.ToDouble(array[num4]) < 0.0 || Convert.ToDouble(array[num4]) > 9.0))
            {
                if (num4 > 0)
                {
                    int num5 = num4 - 1;
                    for (int i = 0; i < num5; i++)
                    {
                        if (array[num4] == array[i])
                        {
                            result = false;
                            break;
                        }
                    }
                }
                num4++;
                if (num4 > 9)
                {
                    return result;
                }
            }
            result = false;
            return result;
        }

        private void Populate99CoBanCho1OLon(string strMaHoa)
        {
            string[] array = strMaHoa.Split(new char[]
            {
                ','
            });
            if (array.GetUpperBound(0) == 99)
            {
                int num = 0;
                do
                {
                    int num2 = 0;
                    do
                    {
                        int num3 = num * 10 + num2;
                        string value = num.ToString("0") + num2.ToString("0");
                        string name = "txtCoBan" + value;
                        TextBox textBoxFromName = this.getTextBoxFromName(name);
                        textBoxFromName.Text = double.Parse(array[num3]).ToString("00");
                        if (value == array[num3])
                            textBoxFromName.BackColor = Color.White;
                        else
                            textBoxFromName.BackColor = Color.LightYellow;
                        num2++;
                    }
                    while (num2 <= 9);
                    num++;
                }
                while (num <= 9);
            }
        }

        private void Populate99CoBan(string strMaHoa)
        {
            string[] array = strMaHoa.Split(new char[]
            {
                ';'
            });
            int num = array.GetUpperBound(0);
            if (num >= 0)
            {
                int num2 = num;
                for (int i = 0; i <= num2; i++)
                {
                    this.strMaHoaCoBan[i] = array[i];
                }
            }
            else
            {
                num = 0;
                this.strMaHoaCoBan[0] = strMaHoa;
            }
            if (num < 9)
            {
                for (int j = num + 1; j <= 9; j++)
                {
                    this.strMaHoaCoBan[j] = modMaHoa.GetStrChuan();
                }
            }
        }

        private string GetStr99CoBan()
        {
            string text = this.strMaHoaCoBan[0];
            int num = 1;
            do
            {
                text = text + ";" + this.strMaHoaCoBan[num];
                num++;
            }
            while (num <= 9);
            return text;
        }
        private string GetCurrStr99CoBan()
        {
            string text = "";
            int num = 0;
            do
            {
                int num2 = 0;
                do
                {
                    string name = "txtCoBan" + num.ToString("0") + num2.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(name);
                    if (text.Length > 0)
                    {
                        text = text + "," + double.Parse(textBoxFromName.Text).ToString("00");
                    }
                    else
                    {
                        text += double.Parse(textBoxFromName.Text).ToString("00");
                    }
                    num2++;
                }
                while (num2 <= 9);
                num++;
            }
            while (num <= 9);
            return text;
        }
        private bool Is99CoBanOK()
        {
            bool result = true;
            int num = 0;
            while (this.Is99CoBanOK(this.strMaHoaCoBan[num]))
            {
                num++;
                if (num > 9)
                {
                    return result;
                }
            }
            result = false;
            return result;
        }
        private bool Is99CoBanOK(string strMaHoa)
        {
            bool result = true;
            string[] array = new string[100];
            string[] array2 = strMaHoa.Split(new char[]
            {
                ','
            });
            if (array2.GetUpperBound(0) == 99)
            {
                int num = 0;
                do
                {
                    int num2 = 0;
                    do
                    {
                        int num3 = num * 10 + num2;
                        array[num3] = double.Parse(array2[num3]).ToString();
                        num2++;
                    }
                    while (num2 <= 9);
                    num++;
                }
                while (num <= 9);
                int num4 = 0;
                while (!(Convert.ToDouble(array[num4]) < 0.0 | Convert.ToDouble(array[num4]) > 99.0))
                {
                    if (num4 > 0)
                    {
                        int num5 = num4 - 1;
                        for (int i = 0; i < num5; i++)
                        {
                            if (array[num4] == array[i])
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                    num4++;
                    if (num4 > 99)
                    {
                        return result;
                    }
                }
                result = false;
            }
            else
            {
                result = false;
            }
            return result;
        }


        #endregion


        public TextBox getTextBoxFromName(ref object containerObj, string name)
        {
            TextBox result = null;
            try
            {
                foreach (Control control in ((IEnumerable)Microsoft.VisualBasic.CompilerServices.NewLateBinding.LateGet(containerObj, null, "Controls", new object[0], null, null, null)))
                {
                    if (control.Name.ToUpper().Trim() == name.ToUpper().Trim())
                    {
                        result = (TextBox)control;
                    }
                }

            }
            catch (Exception expr_81)
            {
                throw expr_81;
            }
            return result;
        }

        /// <summary>
        /// HT Code: Thêm mới
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TextBox getTextBoxFromName(string name)
        {
            TextBox result = null;
            try
            {
                result = (TextBox)this.Controls.Find(name.ToUpper().Trim(), true)[0];
                //foreach (Control control in this.Controls)
                //{
                //    if (control.Name.ToUpper().Trim() == name.ToUpper().Trim())
                //    {
                //        result = (TextBox)control;
                //    }
                //}

            }
            catch (Exception expr_81)
            {
                throw expr_81;
            }
            return result;
        }

        private void btn99MacDinh_Click(object sender, EventArgs e)
        {
            this.Populate99OLonChuan();
            this.Populate99CoBanChuan();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CMaHoa cMaHoa = new CMaHoa();
            CMaHoa cMaHoa2 = cMaHoa;
            cMaHoa2.Ten = "Ngay " + DateTime.Now.ToShortDateString();
            cMaHoa2.OLon99 = modMaHoa.str99OLonChuan;
            cMaHoa2.OCoBan99 = modMaHoa.GetStrCoBanChuan();
            cMaHoa2.OChinh55 = modMaHoa.str55OChinhChuan;
            cMaHoa2.OLon55 = modMaHoa.GetStrChuan();
            this.m_MaHoas.Add(cMaHoa);
            this.RefreshLst();
            this.btnSave.Text = "Lưu mới";
            this.EnableMaToaDo(true);
            this.GBoxLst.Enabled = false;
        }

        private bool KiemTraGiaTriHopLe()
        {
            bool result = false;
            if (this.Is99LonOK())
            {
                if (this.Is99CoBanOK())
                {
                    result = true;
                }
                else
                {
                    MessageBox.Show("số liệu mã hóa sai, xem lại các cơ bản 99 ...", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("số liệu mã hóa sai, xem lại các ô lớn 99 ...", "Thông báo", MessageBoxButtons.OK);
            }
            return result;
        }

        private void UpdateChange()
        {
            int num = checked((int)Math.Round(m_index));
            this.strMaHoaCoBan[num] = this.GetCurrStr99CoBan();

            CMaHoa seleMaHoa = this.m_SeleMaHoa;
            seleMaHoa.Ten = this.txtTen.Text;
            seleMaHoa.OLon99 = this.GetStr99Lon();
            seleMaHoa.OCoBan99 = this.GetStr99CoBan();
            if (this.btnSave.Text == "Lưu mới")
            {
                int maHoaID = CMaHoas.Insert(this.m_SeleMaHoa);
                this.m_SeleMaHoa.MaHoaID = maHoaID;
                this.btnSave.Text = "Cập nhật";
            }
            else
            {
                CMaHoas.Update(this.m_SeleMaHoa);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!KiemTraGiaTriHopLe())
                return;

            UpdateChange();
        }


        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (!KiemTraGiaTriHopLe())
                return;

            UpdateChange();

            this.GBoxLst.Enabled = true;
            this.EnableMaToaDo(false);
            this.populateLst(this.m_SeleMaHoa.MaHoaID);
        }

        private void EnableMaToaDo(bool bChoPhep)
        {
            this.btnSave.Enabled = bChoPhep;
            this.btnKetThuc.Enabled = bChoPhep;
            this.txtTen.Enabled = bChoPhep;
            //this.GBox99.Enabled = bChoPhep;
            this.btn99MacDinh.Enabled = bChoPhep;
            this.txtOLon00.ReadOnly = !bChoPhep;
            this.txtOLon01.ReadOnly = !bChoPhep;
            this.txtOLon10.ReadOnly = !bChoPhep;
            this.txtOLon11.ReadOnly = !bChoPhep;
            this.txtOLon20.ReadOnly = !bChoPhep;
            this.txtOLon21.ReadOnly = !bChoPhep;
            this.txtOLon30.ReadOnly = !bChoPhep;
            this.txtOLon31.ReadOnly = !bChoPhep;
            this.txtOLon40.ReadOnly = !bChoPhep;
            this.txtOLon41.ReadOnly = !bChoPhep;
            this.btnCancel.Enabled = bChoPhep;
        }

        private void lstMaHoas_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstMaHoas.SelectedItem != null && this.m_mod == "Chon")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void lstMaHoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.bLoaded && this.lstMaHoas.SelectedItem != null)
            {
                this.m_SeleMaHoa = (CMaHoa)this.lstMaHoas.SelectedItem;
                this.lblIndex.Text = "";
                CMaHoa seleMaHoa = this.m_SeleMaHoa;
                this.Populate99OLon(seleMaHoa.OLon99);
                this.Populate99CoBan(seleMaHoa.OCoBan99);
                this.txtTen.Text = seleMaHoa.Ten;
                this.txtOLon00_Enter(this.txtOLon00, null);
                this.txtOLon00.Focus();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.EnableMaToaDo(true);
            this.GBoxLst.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.GBoxLst.Enabled = true;
            this.EnableMaToaDo(false);
            if (this.btnSave.Text == "Lưu mới")
            {
                this.populateLst();
                this.btnSave.Text = "Cập nhật";
            }
        }

        private void txtOLon00_Enter(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                //Reset focus
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Control[] objControls = Controls.Find("txtOLon" + i.ToString() + j.ToString(), true);
                        if (objControls != null)
                        {
                            TextBox objTextBox = (TextBox)objControls[0];
                            objTextBox.BackColor = Color.White;
                        }
                    }
                }

                TextBox textBox = (TextBox)sender;
                textBox.BackColor = Color.LightYellow;
                int num = (int)Math.Round(double.Parse(textBox.Name.Substring(7, 1)));
                int num2 = (int)Math.Round(double.Parse(textBox.Name.Substring(8, 1)));
                int num3 = num * 2 + num2;
                this.lblIndex.Text = string.Concat(new string[]
                    {
                        "- Trong ô lớn (",
                        num.ToString(),
                        ", ",
                        num2.ToString(),
                        ")"
                    });
                m_index = num3;
                if (this.m_SeleCoBanIndex != num3)
                {
                    this.strMaHoaCoBan[this.m_SeleCoBanIndex] = this.GetCurrStr99CoBan();
                }
                this.m_SeleCoBanIndex = num3;
                this.Populate99CoBanCho1OLon(this.strMaHoaCoBan[this.m_SeleCoBanIndex]);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (this.lstMaHoas.SelectedItem != null)
            {
                CMaHoa cMaHoa = (CMaHoa)this.lstMaHoas.SelectedItem;
                CMaHoa cMaHoa2 = new CMaHoa();
                CMaHoa cMaHoa3 = cMaHoa2;
                cMaHoa3.Ten = "Copy " + cMaHoa.Ten;
                cMaHoa3.OLon99 = cMaHoa.OLon99;
                cMaHoa3.OCoBan99 = cMaHoa.OCoBan99;
                cMaHoa3.OChinh55 = cMaHoa.OChinh55;
                cMaHoa3.OLon55 = cMaHoa.OLon55;
                this.m_MaHoas.Add(cMaHoa2);
                this.RefreshLst();
                this.btnSave.Text = "Lưu mới";
                this.EnableMaToaDo(true);
                this.GBoxLst.Enabled = false;
            }
        }

        private void chkDoiTheoDongCot_CheckedChanged(object sender, EventArgs e)
        {
            for (int num = 0; num < 10; num++)
            {
                Control txtCol = this.Controls.Find("col" + num.ToString("0"), true)[0];
                txtCol.Text = num.ToString("0");
                Control txtRow = this.Controls.Find("row" + num.ToString("0"), true)[0];
                txtRow.Text = num.ToString("0");
            }

            //Reset focus
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Control[] objControls = Controls.Find("txtCoBan" + i.ToString() + j.ToString(), true);
                    if (objControls != null)
                    {
                        TextBox objTextBox = (TextBox)objControls[0];
                        objTextBox.Text = i.ToString() + j.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Thay đổi row thì giá trị col cố định
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private void ChangeCol_ToaDo99(int rowIndex, int value)
        {
            int colIndex = 0;
            do
            {
                Control txtCol = this.Controls.Find("col" + colIndex.ToString(), true)[0];
                Control txtRow = this.Controls.Find("row" + rowIndex.ToString(), true)[0];

                string name = "txtCoBan" + rowIndex.ToString("0") + colIndex.ToString("0");
                Control txtCoBan = this.Controls.Find(name, true)[0];
                txtCoBan.Text = txtRow.Text + txtCol.Text;
                colIndex++;
            }
            while (colIndex < 10);
        }

        /// <summary>
        /// Thay đổi row thì giá trị col cố định
        /// Cho biết nhập vào col nào
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private void ChangeRow_ToaDo99(int colIndex, int value)
        {
            int rowIndex = 0;
            do
            {
                Control txtCol = this.Controls.Find("col" + colIndex.ToString(), true)[0];
                Control txtRow = this.Controls.Find("row" + rowIndex.ToString(), true)[0];

                //Đổi các txtCoBan.Text ở vị trí column txtCol sang giá trị mới
                string name = "txtCoBan" + rowIndex.ToString("0") + colIndex.ToString("0");
                Control txtCoBan = this.Controls.Find(name, true)[0];
                txtCoBan.Text = txtRow.Text + txtCol.Text;

                //Tìm column chứa giá trị value và khác colIndex để đổi sang giá trị cũ

                rowIndex++;
            }
            while (rowIndex < 10);
        }

        private void col_KeyUp(object sender, KeyEventArgs e)
        {
            Control obj = (Control)sender;
            if (obj.Text != "")
            {
                int colIndex = int.Parse(obj.Name.Substring(3, 1));
                int newValue = int.Parse(obj.Text);
                ChangeRow_ToaDo99(colIndex, newValue);

                //Xử lý col bị trùng giá trị nhập vào
                for (int num = 0; num < 10; num++)
                {
                    if (num != colIndex)
                    {
                        Control txtCol = this.Controls.Find("col" + num.ToString("0"), true)[0];
                        if (int.Parse(txtCol.Text) == newValue)
                        {
                            txtCol.Text = oldNum.ToString("0");
                            colIndex = int.Parse(txtCol.Name.Substring(3, 1));
                            newValue = int.Parse(txtCol.Text);
                            ChangeRow_ToaDo99(colIndex, newValue);
                        }
                    }
                }
            }
        }

        private void row_KeyUp(object sender, KeyEventArgs e)
        {
            Control obj = (Control)sender;
            if (obj.Text != "")
            {
                int rowIndex = int.Parse(obj.Name.Substring(3, 1));
                int newValue = int.Parse(obj.Text);
                ChangeCol_ToaDo99(rowIndex, newValue);

                //Xử lý col bị trùng giá trị nhập vào
                for (int num = 0; num < 10; num++)
                {
                    if (num != rowIndex)
                    {
                        Control txtRow = this.Controls.Find("row" + num.ToString("0"), true)[0];
                        if (int.Parse(txtRow.Text) == newValue)
                        {
                            txtRow.Text = oldNum.ToString("0");
                            rowIndex = int.Parse(txtRow.Name.Substring(3, 1));
                            newValue = int.Parse(txtRow.Text);
                            ChangeCol_ToaDo99(rowIndex, newValue);
                        }
                    }
                }
            }
        }

        private int oldNum = -1;
        private void row_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            Control obj = (Control)sender;
            if (obj.Text != "")
                oldNum = int.Parse(obj.Text);
        }

        private void col_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            Control obj = (Control)sender;
            if (obj.Text != "")
                oldNum = int.Parse(obj.Text);
        }

        private void txtOLon00_Leave(object sender, EventArgs e)
        {
            //TextBox textBox = (TextBox)sender;
            ////textBox.BackColor = System.Drawing.SystemColors.Control;
            //textBox.BackColor = Color.White;

        }

        private void txtOLon41_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            Control obj = (Control)sender;
            if (obj.Text != "")
                oldNum = int.Parse(obj.Text);
        }

        private void txtOLon41_KeyUp(object sender, KeyEventArgs e)
        {
            Control obj = (Control)sender;
            if (obj.Text != "")
            {
                int newValue = int.Parse(obj.Text);

                //Xử lý col bị trùng giá trị nhập vào
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Control[] objControls = Controls.Find("txtOLon" + i.ToString() + j.ToString(), true);
                        if (objControls != null)
                        {
                            TextBox objTextBox = (TextBox)objControls[0];
                            if (!objTextBox.Equals(obj) && int.Parse(objTextBox.Text) == newValue)
                            {
                                objTextBox.Text = oldNum.ToString("0");
                            }
                        }
                    }
                }
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}