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
using DoiToaDo;

namespace DoiToaDo99
{
    public partial class dlgMaHoaToaDo : Form
    {
        public string m_mod;
        public int m_LastMaHoaID = 0;
        private List<CMaHoa> m_MaHoas;
        private CMaHoa m_SeleMaHoa;
        private bool bLoaded;
        private string[] strMaHoaCoBan;
        private int m_SeleCoBanIndex = 0;
        private static int cantimMaHoaID = 0;
        public CMaHoa SeLeMaHoa
        {
            get
            {
                return this.m_SeleMaHoa;
            }
        }

        public dlgMaHoaToaDo()
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
            catch (Exception expr_62)
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

        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void dlgMaHoaToaDo_Load(object sender, EventArgs e)
        {
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
            dlgMaHoaToaDo.cantimMaHoaID = pMaHoaID;
            return this.m_MaHoas.Find(new Predicate<CMaHoa>(dlgMaHoaToaDo.MaHoaIDequal));
        }
        private static bool MaHoaIDequal(CMaHoa pMaHoa)
        {
            return pMaHoa.MaHoaID == dlgMaHoaToaDo.cantimMaHoaID;
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
        private void Populate99OLonChuan()
        {
            this.Populate99OLon(modMaHoa.str99OLonChuan);
        }
        private void Populate99CoBanChuan()
        {
            string strCoBanChuan = modMaHoa.GetStrCoBanChuan();
            this.Populate99CoBan(strCoBanChuan);
        }
        private void Populate55OChinhChuan()
        {
            this.Populate55OChinh(modMaHoa.str55OChinhChuan);
        }
        private void Populate55OLonChuan()
        {
            string strChuan = modMaHoa.GetStrChuan();
            this.Populate55OLon(strChuan);
        }
        private void Populate99OLon(string strMaHoa)
        {
            string[] array = strMaHoa.Split(new char[]
			{
				','
			});
            if (array.GetUpperBound(0) == 9)
            {
                object obj = this.TabControl1.TabPages[0];
                int num = 0;
                do
                {
                    int num2 = 0;
                    do
                    {
                        int num3 = num * 2 + num2;
                        string name = "txtOLon" + num.ToString("0") + num2.ToString("0");
                        TextBox textBoxFromName = this.getTextBoxFromName(ref obj, name);
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
            object obj = this.TabControl1.TabPages[0];
            int num = 0;
            do
            {
                int num2 = 0;
                do
                {
                    string name = "txtOLon" + num.ToString("0") + num2.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(ref obj, name);
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
            object obj = this.TabControl1.TabPages[0];
            int num = -1;
            int num2 = 0;
            do
            {
                int num3 = 0;
                do
                {
                    string name = "txtOLon" + num2.ToString("0") + num3.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(ref obj, name);
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
                object gBox = this.GBox99;
                int num = 0;
                do
                {
                    int num2 = 0;
                    do
                    {
                        int num3 = num * 10 + num2;
                        string name = "txtCoBan" + num.ToString("0") + num2.ToString("0");
                        TextBox textBoxFromName = this.getTextBoxFromName(ref gBox, name);
                        textBoxFromName.Text = double.Parse(array[num3]).ToString("00");
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
                for (int i = 0; i < num2; i++)
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
            object gBox = this.GBox99;
            int num = 0;
            do
            {
                int num2 = 0;
                do
                {
                    string name = "txtCoBan" + num.ToString("0") + num2.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(ref gBox, name);
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
        private void Populate55OChinh(string strOChinh)
        {
            string[] array = strOChinh.Split(new char[]
			{
				','
			});
            if (array.GetUpperBound(0) == 8)
            {
                object gBox = this.GBox55;
                int num = 0;
                do
                {
                    int num2 = 0;
                    do
                    {
                        int num3 = num * 3 + num2;
                        string name = "txt55Chinh" + num.ToString("0") + num2.ToString("0");
                        TextBox textBoxFromName = this.getTextBoxFromName(ref gBox, name);
                        textBoxFromName.Text = array[num3];
                        num2++;
                    }
                    while (num2 <= 2);
                    num++;
                }
                while (num <= 2);
            }
            else
            {
                MessageBox.Show("strOChinh sai " + array.GetUpperBound(0).ToString(), "Thông báo", MessageBoxButtons.OK);
            }
        }
        private string GetStr55Chinh()
        {
            string text = "";
            object gBox = this.GBox55;
            int num = 0;
            do
            {
                int num2 = 0;
                do
                {
                    int num3 = num * 3 + num2;
                    string name = "txt55Chinh" + num.ToString("0") + num2.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(ref gBox, name);
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
                while (num2 <= 2);
                num++;
            }
            while (num <= 2);
            return text;
        }
        private bool Is55ChinhOK()
        {
            bool result = true;
            string[] array = new string[9];
            object gBox = this.GBox55;
            int num = -1;
            int num2 = 0;
            do
            {
                int num3 = 0;
                do
                {
                    string name = "txt55Chinh" + num2.ToString("0") + num3.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(ref gBox, name);
                    num++;
                    array[num] = double.Parse(textBoxFromName.Text).ToString();
                    num3++;
                }
                while (num3 <= 2);
                num2++;
            }
            while (num2 <= 2);
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
                if (num4 > 8)
                {
                    return result;
                }
            }
            result = false;
            return result;
        }
        private void Populate55OLon(string strMaHoa)
        {
            string[] array = strMaHoa.Split(new char[]
			{
				','
			});
            if (array.GetUpperBound(0) == 99)
            {
                object gBox = this.GBox55;
                int num = 0;
                do
                {
                    int num2 = 0;
                    do
                    {
                        int num3 = num * 10 + num2;
                        string name = "txt55Lon" + num.ToString("0") + num2.ToString("0");
                        TextBox textBoxFromName = this.getTextBoxFromName(ref gBox, name);
                        textBoxFromName.Text = double.Parse(array[num3]).ToString("00");
                        num2++;
                    }
                    while (num2 <= 9);
                    num++;
                }
                while (num <= 9);
            }
        }
        private string GetStr55Lon()
        {
            string text = "";
            object gBox = this.GBox55;
            int num = 0;
            do
            {
                int num2 = 0;
                do
                {
                    int num3 = num * 10 + num2;
                    string name = "txt55Lon" + num.ToString("0") + num2.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(ref gBox, name);
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
        private bool Is55LonOK()
        {
            bool result = true;
            string[] array = new string[100];
            object gBox = this.GBox55;
            int num = -1;
            int num2 = 0;
            do
            {
                int num3 = 0;
                do
                {
                    string name = "txt55Lon" + num2.ToString("0") + num3.ToString("0");
                    TextBox textBoxFromName = this.getTextBoxFromName(ref gBox, name);
                    num++;
                    array[num] = double.Parse(textBoxFromName.Text).ToString();
                    num3++;
                }
                while (num3 <= 9);
                num2++;
            }
            while (num2 <= 9);
            int num4 = 0;
            while (!(Convert.ToDouble(array[num4]) < 0.0 || Convert.ToDouble(array[num4]) > 99.0))
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
            return result;
        }

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

        private void btn99MacDinh_Click(object sender, EventArgs e)
        {
            this.Populate99OLonChuan();
            this.Populate99CoBanChuan();
        }
        private void btn55MacDinh_Click(object sender, EventArgs e)
        {
            this.Populate55OChinhChuan();
            this.Populate55OLonChuan();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            int num = checked((int)Math.Round(double.Parse(this.txtIndex.Text)));
            this.strMaHoaCoBan[num] = this.GetCurrStr99CoBan();
            if (this.Is99LonOK())
            {
                if (this.Is99CoBanOK())
                {
                    if (this.Is55ChinhOK())
                    {
                        if (this.Is55LonOK())
                        {
                            CMaHoa seleMaHoa = this.m_SeleMaHoa;
                            seleMaHoa.Ten = this.txtTen.Text;
                            seleMaHoa.OLon99 = this.GetStr99Lon();
                            seleMaHoa.OCoBan99 = this.GetStr99CoBan();
                            seleMaHoa.OChinh55 = this.GetStr55Chinh();
                            seleMaHoa.OLon55 = this.GetStr55Lon();
                            if (this.btnSave.Text == "Lưu mới")
                            {
                                int maHoaID = CMaHoas.Insert(this.m_SeleMaHoa);
                                this.m_SeleMaHoa.MaHoaID = maHoaID;
                                this.btnSave.Text = "Lưu thay đổi";
                            }
                            else
                            {
                                CMaHoas.Update(this.m_SeleMaHoa);
                            }
                            this.GBoxLst.Enabled = true;
                            this.EnableMaToaDo(false);
                            this.populateLst(this.m_SeleMaHoa.MaHoaID);
                        }
                        else
                        {
                            MessageBox.Show("số liệu mã hóa sai, xem lại các ô lớn 55 ...", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("số liệu mã hóa sai, xem lại các ô chính 55 ...", "Thông báo", MessageBoxButtons.OK);
                    }
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
        }
        private void EnableMaToaDo(bool bChoPhep)
        {
            this.btnSave.Enabled = bChoPhep;
            this.txtTen.Enabled = bChoPhep;
            this.GBox55.Enabled = bChoPhep;
            this.GBox99.Enabled = bChoPhep;
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
                this.Populate55OChinh(seleMaHoa.OChinh55);
                this.Populate55OLon(seleMaHoa.OLon55);
                this.txtTen.Text = seleMaHoa.Ten;
                this.txtOLon00.Focus();
                this.txtOLon00_Enter(this.txtOLon00, null);
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
                this.btnSave.Text = "Lưu thay đổi";
            }
        }
        private void txtOLon00_Enter(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                TextBox textBox = (TextBox)sender;
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
                this.txtIndex.Text = num3.ToString();
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

        

        
    }
}