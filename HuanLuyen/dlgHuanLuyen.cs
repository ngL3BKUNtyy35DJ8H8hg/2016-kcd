using AxMapXLib;
using MapXLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace HuanLuyen
{
    public partial class dlgHuanLuyen : Form
    {
        private CheckBox _chkHienKyHieu;
        private Dictionary<string, string> BT99DataDict;
        private Dictionary<string, string> BT55DataDict;
        private Dictionary<string, string> BTGanDataDict;
        public DateTime TdBatDau;
        public DateTime DongHoHL;
        private DateTime DongHoBatDau;
        private DateTime DongHoThuc;
        private int m_Phut = 0;
        private List<CTinhHuong> m_TinhHuongs;
        private List<CFlight> m_Flights;
        public CFlight SeleFlight;
        public CFlight EditingFlight;
        public CFlight TachFlight;
        public CFlight DoiHuongFlight;
        public DateTime newDeparture;
        public CMayBay newMayBay;
        public int iEditNode = 0;
        private System.Drawing.Point myPt = 0;
        private List<CRada> m_BaiTapRadas;
        private CRada m_SeleRada;
        private CRadaFlight[,] m_RadaFlights;
        private bool bLoaded;
        private CHLProcess HLProcess1;
        private DataView dvTops;
        private static int cantimFlight_ID = 0;

        public dlgHuanLuyen()
        {
            InitializeComponent();
        }


        
        private void StartHL()
        {
            if (this.HLProcess1 == null)
            {
                this.HLProcess1 = new CHLProcess();
                this.HLProcess1.StartThread();
            }
        }
        private void StopHL()
        {
            if (this.HLProcess1 != null)
            {
                this.HLProcess1.StopThread();
                this.HLProcess1 = null;
            }
        }
        private void PopulateTops()
        {
            this.SeleFlight = null;
            this.iEditNode = -1;
            this.PopulateTopGridView();
        }
        public void SetSeleFlight(CFlight pFlight)
        {
            this.EditingFlight = pFlight;
            this.SeleFlight = pFlight;
        }
        private void PopulateRadas()
        {
            if (this.m_BaiTapRadas.Count > 0)
            {
                CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fMain.cboBaiTap.SelectedItem;
                foreach (CRada current in this.m_BaiTapRadas)
                {
                    this.PopulateKhuats(cBaiTap.BaiTapID, current);
                }

            }
        }
        private void PopulateKhuats(int pBaiTapID, CRada pRada)
        {
            List<CKhuat> list = CBaiTapKhuats.GetList(pBaiTapID, pRada.RadaID);
            foreach (CKhuat current in list)
            {
                current.KhuatPts = CBaiTapKhuats.GetKhuatPts(pBaiTapID, current.KhuatID);
            }

            pRada.Khuats = list;
        }
        private List<CFlight> GetFlights()
        {
            List<CFlight> list = new List<CFlight>();
            int num = 0;
            checked
            {
                foreach (CTop current in modHuanLuyen.fMain.Tops)
                {
                    try
                    {
                        CFlight cFlight = new CFlight(current);
                        if (cFlight != null)
                        {
                            num++;
                            cFlight.Flight_ID = num;
                            this.Tinh2Flight(cFlight);
                            list.Add(cFlight);
                        }
                    }
                    catch (Exception expr_54)
                    {
                        throw expr_54;
                    }
                }

                return list;
            }
        }
        private void Tinh2Flight(CFlight pFlight)
        {
            CBasePath.TinhSecs(modHuanLuyen.fMain.AxMap1, pFlight.Path[0].node, pFlight.Path[1].node);
            DateTime pTd = pFlight.Departure.AddSeconds(pFlight.Path[0].node.t2next + pFlight.Path[0].node.tspeed);
            pFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, 1);
            pFlight.UpdateTd(1, pTd);
        }
        private void CreateRadaFlights()
        {
            this.m_RadaFlights = checked(new CRadaFlight[this.m_BaiTapRadas.Count - 1 + 1, this.m_Flights.Count - 1 + 1]);
            foreach (CRada current in this.m_BaiTapRadas)
            {
                int num = this.m_BaiTapRadas.IndexOf(current);
                foreach (CFlight current2 in this.m_Flights)
                {
                    int num2 = this.m_Flights.IndexOf(current2);
                    CRadaFlight cRadaFlight = new CRadaFlight(current, current2);
                    this.m_RadaFlights[num, num2] = cRadaFlight;
                }

            }

        }
        public void AddNewFlight(CTop aTop)
        {
            CFlight cFlight = new CFlight(aTop);
            checked
            {
                cFlight.Flight_ID = this.m_Flights.Count + 1;
                this.Tinh2Flight(cFlight);
                cFlight.isBusy = true;
                this.m_Flights.Add(cFlight);
                this.PopulateTops();
                int num = this.m_Flights.IndexOf(cFlight);
                this.grdTops.Rows[num].Selected = true;
                this.grdTops.FirstDisplayedScrollingRowIndex = num;
                this.m_RadaFlights = (CRadaFlight[,])Utils.CopyArray((Array)this.m_RadaFlights, new CRadaFlight[this.m_BaiTapRadas.Count - 1 + 1, this.m_Flights.Count - 1 + 1]);
                foreach (CRada current in this.m_BaiTapRadas)
                {
                    int num2 = this.m_BaiTapRadas.IndexOf(current);
                    int num3 = this.m_Flights.IndexOf(cFlight);
                    CRadaFlight cRadaFlight = new CRadaFlight(current, cFlight);
                    this.m_RadaFlights[num2, num3] = cRadaFlight;
                }

                cFlight.isBusy = false;
                this.SetSeleFlight(cFlight);
                modHuanLuyen.fMain.lyrAnimation.Invalidate(Missing.Value);
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        public void AddNewFlight(CTop aTop, DateTime pDeparture)
        {
            CFlight cFlight = new CFlight(aTop, pDeparture);
            checked
            {
                cFlight.Flight_ID = this.m_Flights.Count + 1;
                this.Tinh2Flight(cFlight);
                cFlight.isBusy = true;
                this.m_Flights.Add(cFlight);
                this.PopulateTops();
                int num = this.m_Flights.IndexOf(cFlight);
                this.grdTops.Rows[num].Selected = true;
                this.grdTops.FirstDisplayedScrollingRowIndex = num;
                this.m_RadaFlights = (CRadaFlight[,])Utils.CopyArray((Array)this.m_RadaFlights, new CRadaFlight[this.m_BaiTapRadas.Count - 1 + 1, this.m_Flights.Count - 1 + 1]);
                foreach (CRada current in this.m_BaiTapRadas)
                {
                    int num2 = this.m_BaiTapRadas.IndexOf(current);
                    int num3 = this.m_Flights.IndexOf(cFlight);
                    CRadaFlight cRadaFlight = new CRadaFlight(current, cFlight);
                    this.m_RadaFlights[num2, num3] = cRadaFlight;
                }

                cFlight.isBusy = false;
                this.SetSeleFlight(cFlight);
                modHuanLuyen.fMain.lyrAnimation.Invalidate(Missing.Value);
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        public void DoiHuong(CTop aTop, DateTime pDeparture)
        {
            this.DoiHuongFlight.isBusy = true;
            this.DoiHuongFlight.DoiHuongBay(pDeparture, aTop);
            this.DoiHuongFlight.isBusy = false;
            this.SetSeleFlight(this.DoiHuongFlight);
            modHuanLuyen.fMain.lyrAnimation.Invalidate(Missing.Value);
            modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
        }
        public void UpdateSoLuong(CFlight pFlight, int pSoLuong)
        {
            int index = this.m_Flights.IndexOf(pFlight);
            this.m_Flights[index].SoLuong = pSoLuong;
        }
        private int GetStt(CRada pRada, CFlight pFlight)
        {
            int result = 0;
            switch (pRada.LoaiRadaID)
            {
                case 1:
                    result = this.GetCanhGioStt(pRada, pFlight);
                    break;
                case 2:
                    result = this.GetRadaStt(pRada, pFlight);
                    break;
                case 3:
                    result = this.GetRadaStt(pRada, pFlight);
                    break;
            }
            return result;
        }
        private int GetCanhGioStt(CRada pRada, CFlight pFlight)
        {
            int num = 0;
            int num2 = 0;
            int num3 = this.m_BaiTapRadas.IndexOf(pRada);
            int num4 = this.m_Flights.IndexOf(pFlight);
            switch (pFlight.LoaiTopID)
            {
                case 1:
                    num = modHuanLuyen.DichStt;
                    break;
                case 2:
                    num = modHuanLuyen.TaStt;
                    break;
                case 3:
                    num = modHuanLuyen.QuocTeStt;
                    break;
                case 4:
                    num = modHuanLuyen.QuaCanhStt;
                    break;
            }
            checked
            {
                foreach (CFlight current in this.m_Flights)
                {
                    int num5 = this.m_Flights.IndexOf(current);
                    if (this.m_RadaFlights[num3, num5].Flight.LoaiTopID == pFlight.LoaiTopID && this.m_RadaFlights[num3, num5].Stt > -1)
                    {
                        num2++;
                    }
                }

                num += num2;
                return num;
            }
        }
        private int GetRadaStt(CRada pRada, CFlight pFlight)
        {
            int num = 0;
            int num2 = this.m_BaiTapRadas.IndexOf(pRada);
            int num3 = this.m_Flights.IndexOf(pFlight);
            checked
            {
                foreach (CFlight current in this.m_Flights)
                {
                    int num4 = this.m_Flights.IndexOf(current);
                    if (this.m_RadaFlights[num2, num4].Stt > -1)
                    {
                        num++;
                    }
                }

                return num + 1;
            }
        }
        private string GetStrMTgan(DateTime pLuc, CRadaFlight mRadaFlight)
        {
            string result = "";
            checked
            {
                if (mRadaFlight.RadaFlightMTs.Count > 0)
                {
                    int num = 0;
                    int num2 = 0;
                    if (mRadaFlight.RadaFlightMTs.Count > 1)
                    {
                        CRadaFlightMT cRadaFlightMT = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 2];
                        num = (int)Math.Round(cRadaFlightMT.Pos.h / 100.0);
                        num2 = cRadaFlightMT.SoLuong;
                    }
                    CRadaFlightMT cRadaFlightMT2 = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 1];
                    int num3 = (int)Math.Round(cRadaFlightMT2.Pos.h / 100.0);
                    int soLuong = cRadaFlightMT2.SoLuong;
                    if (cRadaFlightMT2.Gio == pLuc.Hour & cRadaFlightMT2.Phut == pLuc.Minute)
                    {
                        CRada rada = mRadaFlight.Rada;
                        CFlight flight = mRadaFlight.Flight;
                        string soHieuTop = this.GetSoHieuTop(rada, flight);
                        struPhuongVi phuongVi = modHuanLuyen.GetPhuongVi(modHuanLuyen.fMain.AxMap1, rada.PosX, rada.PosY, cRadaFlightMT2.Pos.x, cRadaFlightMT2.Pos.y);
                        string text = phuongVi.PhuongVi.ToString("000") + "-" + phuongVi.CuLy.ToString("000");
                        switch (cRadaFlightMT2.Status)
                        {
                            case enRadaStatus.XuatHien:
                                result = string.Concat(new string[]
{
"XH=",
soHieuTop,
",",
text,
",",
mRadaFlight.Flight.SoLuong.ToString(),
",",
mRadaFlight.Flight.ObjLoaiMB.KL,
",",
((int)Math.Round(cRadaFlightMT2.Pos.h / 100.0)).ToString("000")
});
                                break;
                            case enRadaStatus.Thay:
                                if (num3 == num & soLuong == num2)
                                {
                                    result = "RG=" + soHieuTop + "," + text;
                                }
                                else
                                {
                                    result = string.Concat(new string[]
{
"DD=",
soHieuTop,
",",
text,
",",
soLuong.ToString(),
",",
mRadaFlight.Flight.ObjLoaiMB.KL,
",",
num3.ToString("000")
});
                                }
                                break;
                            case enRadaStatus.TamMatMT:
                                result = "TM=" + soHieuTop + "," + text;
                                break;
                            case enRadaStatus.MatMT:
                                result = "MT=" + soHieuTop + "," + text;
                                break;
                        }
                    }
                }
                return result;
            }
        }
        private string GetTinhBaoGan(DateTime pLuc)
        {
            string text = "";
            foreach (CRada current in this.m_BaiTapRadas)
            {
                if (current.LoaiRadaID == 3)
                {
                    int num = this.m_BaiTapRadas.IndexOf(current);
                    foreach (CFlight current2 in this.m_Flights)
                    {
                        int num2 = this.m_Flights.IndexOf(current2);
                        CRadaFlight mRadaFlight = this.m_RadaFlights[num, num2];
                        string strMTgan = this.GetStrMTgan(pLuc, mRadaFlight);
                        if (strMTgan.Length > 0)
                        {
                            if (text.Length == 0)
                            {
                                text = pLuc.Hour.ToString("00") + pLuc.Minute.ToString("00") + ":" + strMTgan;
                            }
                            else
                            {
                                text = text + "+" + strMTgan;
                            }
                        }
                    }

                }
            }

            return text;
        }
        private string GetStrMT55(DateTime pLuc, CRadaFlight mRadaFlight)
        {
            string result = "";
            checked
            {
                if (mRadaFlight.RadaFlightMTs.Count > 0)
                {
                    int num = 0;
                    int num2 = 0;
                    if (mRadaFlight.RadaFlightMTs.Count > 1)
                    {
                        CRadaFlightMT cRadaFlightMT = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 2];
                        num = (int)Math.Round(cRadaFlightMT.Pos.h / 100.0);
                        num2 = cRadaFlightMT.SoLuong;
                    }
                    CRadaFlightMT cRadaFlightMT2 = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 1];
                    int num3 = (int)Math.Round(cRadaFlightMT2.Pos.h / 100.0);
                    int soLuong = cRadaFlightMT2.SoLuong;
                    if (cRadaFlightMT2.Gio == pLuc.Hour & cRadaFlightMT2.Phut == pLuc.Minute)
                    {
                        CRada rada = mRadaFlight.Rada;
                        CFlight flight = mRadaFlight.Flight;
                        string soHieuTop = this.GetSoHieuTop(rada, flight);
                        string text = modHuanLuyen.fMain.GetToaDo55(cRadaFlightMT2.Pos.x, cRadaFlightMT2.Pos.y);
                        text = Convert.ToString(Interaction.IIf(text.Length > 0, text, "000000"));
                        switch (cRadaFlightMT2.Status)
                        {
                            case enRadaStatus.XuatHien:
                                result = string.Concat(new string[]
{
"XH=",
soHieuTop,
",",
text,
",",
mRadaFlight.Flight.SoLuong.ToString(),
",",
mRadaFlight.Flight.ObjLoaiMB.KL,
",",
((int)Math.Round(cRadaFlightMT2.Pos.h / 100.0)).ToString("000")
});
                                break;
                            case enRadaStatus.Thay:
                                if (num3 == num & soLuong == num2)
                                {
                                    result = "RG=" + soHieuTop + "," + text;
                                }
                                else
                                {
                                    result = string.Concat(new string[]
{
"DD=",
soHieuTop,
",",
text,
",",
soLuong.ToString(),
",",
mRadaFlight.Flight.ObjLoaiMB.KL,
",",
num3.ToString("000")
});
                                }
                                break;
                            case enRadaStatus.TamMatMT:
                                result = "TM=" + soHieuTop + "," + text;
                                break;
                            case enRadaStatus.MatMT:
                                result = "MT=" + soHieuTop + "," + text;
                                break;
                        }
                    }
                }
                return result;
            }
        }
        private string GetTinhBao55(DateTime pLuc)
        {
            string text = "";
            foreach (CRada current in this.m_BaiTapRadas)
            {
                if (current.LoaiRadaID == 2)
                {
                    int num = this.m_BaiTapRadas.IndexOf(current);
                    foreach (CFlight current2 in this.m_Flights)
                    {
                        int num2 = this.m_Flights.IndexOf(current2);
                        CRadaFlight mRadaFlight = this.m_RadaFlights[num, num2];
                        string strMT = this.GetStrMT55(pLuc, mRadaFlight);
                        if (strMT.Length > 0)
                        {
                            if (text.Length == 0)
                            {
                                text = pLuc.Hour.ToString("00") + pLuc.Minute.ToString("00") + ":" + strMT;
                            }
                            else
                            {
                                text = text + "+" + strMT;
                            }
                        }
                    }

                }
            }

            return text;
        }
        private string GetStrMT99(DateTime pLuc, CRadaFlight mRadaFlight)
        {
            string result = "";
            checked
            {
                if (mRadaFlight.RadaFlightMTs.Count > 0)
                {
                    int num = 0;
                    int num2 = 0;
                    if (mRadaFlight.RadaFlightMTs.Count > 1)
                    {
                        CRadaFlightMT cRadaFlightMT = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 2];
                        num = (int)Math.Round(cRadaFlightMT.Pos.h / 100.0);
                        num2 = cRadaFlightMT.SoLuong;
                    }
                    CRadaFlightMT cRadaFlightMT2 = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 1];
                    int num3 = (int)Math.Round(cRadaFlightMT2.Pos.h / 100.0);
                    int soLuong = cRadaFlightMT2.SoLuong;
                    if (cRadaFlightMT2.Gio == pLuc.Hour & cRadaFlightMT2.Phut == pLuc.Minute)
                    {
                        CRada rada = mRadaFlight.Rada;
                        CFlight flight = mRadaFlight.Flight;
                        string soHieuTop = this.GetSoHieuTop(rada, flight);
                        string text = modHuanLuyen.fMain.GetToaDo99(cRadaFlightMT2.Pos.x, cRadaFlightMT2.Pos.y);
                        text = Convert.ToString(Interaction.IIf(text.Length > 0, text, "0 0000"));
                        switch (cRadaFlightMT2.Status)
                        {
                            case enRadaStatus.XuatHien:
                                result = string.Concat(new string[]
{
"XH=",
soHieuTop,
",",
text,
",",
mRadaFlight.Flight.SoLuong.ToString(),
",",
mRadaFlight.Flight.ObjLoaiMB.KL,
",",
((int)Math.Round(cRadaFlightMT2.Pos.h / 100.0)).ToString("000")
});
                                break;
                            case enRadaStatus.Thay:
                                if (num3 == num & soLuong == num2)
                                {
                                    result = "RG=" + soHieuTop + "," + text;
                                }
                                else
                                {
                                    result = string.Concat(new string[]
{
"DD=",
soHieuTop,
",",
text,
",",
soLuong.ToString(),
",",
mRadaFlight.Flight.ObjLoaiMB.KL,
",",
num3.ToString("000")
});
                                }
                                break;
                            case enRadaStatus.TamMatMT:
                                result = "TM=" + soHieuTop + "," + text;
                                break;
                            case enRadaStatus.MatMT:
                                result = "MT=" + soHieuTop + "," + text;
                                break;
                        }
                    }
                }
                return result;
            }
        }
        private string GetTinhBao99(DateTime pLuc)
        {
            string text = "";
            foreach (CRada current in this.m_BaiTapRadas)
            {
                if (current.LoaiRadaID == 1)
                {
                    int num = this.m_BaiTapRadas.IndexOf(current);
                    foreach (CFlight current2 in this.m_Flights)
                    {
                        int num2 = this.m_Flights.IndexOf(current2);
                        CRadaFlight mRadaFlight = this.m_RadaFlights[num, num2];
                        string strMT = this.GetStrMT99(pLuc, mRadaFlight);
                        if (strMT.Length > 0)
                        {
                            if (text.Length == 0)
                            {
                                text = pLuc.Hour.ToString("00") + pLuc.Minute.ToString("00") + ":" + strMT;
                            }
                            else
                            {
                                text = text + "+" + strMT;
                            }
                        }
                    }

                }
            }

            return text;
        }
        private string GetSoHieuTop(CRada pRada, CFlight pFlight)
        {
            int num = this.m_BaiTapRadas.IndexOf(pRada);
            int num2 = this.m_Flights.IndexOf(pFlight);
            int stt = this.m_RadaFlights[num, num2].Stt;
            string result;
            if (pRada.LoaiRadaID == 2)
            {
                result = Convert.ToString(Interaction.IIf(stt > -1, pRada.SoHieu + stt.ToString("00"), "Chưa XH"));
            }
            else
            {
                result = Convert.ToString(Interaction.IIf(stt > -1, stt.ToString("000"), "Chưa XH"));
            }
            return result;
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
        private void dlgHuanLuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Thật sự muốn kết thúc huấn luyện?", "Huấn luyện", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.StopHL();
                Thread.Sleep(200);
                if (MessageBox.Show("Lưu huấn luyện thành 1 Bài tập?", "Huấn luyện", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    modHuanLuyen.fMain.Cursor = Cursors.WaitCursor;
                    CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fMain.cboBaiTap.SelectedItem;
                    CBaiTaps.HuanLuyen2BaiTap(cBaiTap, this.m_Flights);
                    modHuanLuyen.fMain.PopulateBaiTaps(cBaiTap.BaiTapID);
                    modHuanLuyen.fMain.Cursor = Cursors.Default;
                }
                modHuanLuyen.fMain.PanelLeft.Enabled = true;
                modHuanLuyen.fHuanLuyen = null;
                modHuanLuyen.fMain.lyrAnimation.Invalidate(Missing.Value);
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }
            else
            {
                e.Cancel = true;
            }
        }
        public void Show(Form parent, List<CRada> pRadas)
        {
            this.m_Flights = this.GetFlights();
            this.m_BaiTapRadas = pRadas;
            this.Show(parent);
        }
        private void dlgHuanLuyen_Load(object sender, EventArgs e)
        {
            this.Text = "Huấn luyện KCĐ";
            System.Drawing.Point location = new System.Drawing.Point(0, modHuanLuyen.fMain.Panel2.Top);
            this.Location = location;
            modHuanLuyen.fHuanLuyen = this;
            this.chkHienKyHieu.Checked = modHuanLuyen.fMain.chkHienKyHieu.Checked;
            modHuanLuyen.fMain.PanelLeft.Enabled = false;
            this.lblThoiGianBT.Text = string.Concat(new string[]
{
"(",
double.Parse(modHuanLuyen.fMain.txtGioBatDau.Text).ToString("00"),
":",
double.Parse(modHuanLuyen.fMain.txtPhutBatDau.Text).ToString("00"),
")"
});
            this.SetUpGridView(this.grdTops);
            this.PopulateRadas();
            this.initHuanLuyen();
        }
        private int getPhut()
        {
            int result = 0;
            if (DateTime.Compare(this.DongHoBatDau, this.TdBatDau) > 0)
            {
                result = checked((int)Math.Round(Math.Floor(this.DongHoBatDau.Subtract(this.TdBatDau).TotalMinutes)));
            }
            return result;
        }
        private void initHuanLuyen()
        {
            this.bLoaded = false;
            DateTime now = DateTime.Now;
            if (this.rbtBaiTap.Checked)
            {
                this.TdBatDau = checked(new DateTime(now.Year, now.Month, now.Day, (int)Math.Round(double.Parse(modHuanLuyen.fMain.txtGioBatDau.Text)), (int)Math.Round(double.Parse(modHuanLuyen.fMain.txtPhutBatDau.Text)), 0));
            }
            else
            {
                this.TdBatDau = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            }
            this.lblDongHo.Text = "Đồng hồ: " + this.TdBatDau.ToString("HH:mm:ss");
            this.lblTdBatDau.Text = "(" + this.TdBatDau.ToString("HH:mm:ss") + ")";
            this.DongHoBatDau = this.TdBatDau;
            this.DongHoHL = this.TdBatDau;
            this.DongHoThuc = now;
            this.PopulateTops();
            this.CreateRadaFlights();
            this.m_Phut = this.getPhut();
            this.BT99DataDict = new Dictionary<string, string>();
            this.BT55DataDict = new Dictionary<string, string>();
            this.BTGanDataDict = new Dictionary<string, string>();
            this.txtBanTinGan.Text = "";
            CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fMain.cboBaiTap.SelectedItem;
            this.m_TinhHuongs = CTinhHuongs.GetList(cBaiTap.BaiTapID);
            this.bLoaded = true;
        }
        
        public DateTime GetDongHo()
        {
            return this.DongHoBatDau.Add(DateTime.Now.Subtract(this.DongHoThuc));
        }
        public int UpdateFlights()
        {
            DateTime dongHo = this.GetDongHo();
            this.DongHoHL = dongHo;
            this.lblDongHo.Text = "Đồng hồ: " + dongHo.ToString("HH:mm:ss");
            DateTime dateTime = this.TdBatDau.AddMinutes((double)this.m_Phut);
            checked
            {
                if (DateTime.Compare(dongHo, dateTime) >= 0)
                {
                    DateTime now = DateTime.Now;
                    this.SetRadaStatus(dateTime);
                    DateTime mLuc = dateTime.AddMinutes((double)(0 - modHuanLuyen.DelayPhat99));
                    this.SendBanTin99(mLuc);
                    this.m_Phut++;
                    TimeSpan timeSpan = DateTime.Now.Subtract(now);
                    int num = 50;
                    if (timeSpan.Milliseconds < modHuanLuyen.miDelay)
                    {
                        num += modHuanLuyen.miDelay - timeSpan.Milliseconds;
                    }
                    return num;
                }
                foreach (CFlight current in this.m_Flights)
                {
                    if (!current.isBusy)
                    {
                        current.GetMayBay2(modHuanLuyen.fMain.AxMap1, dongHo);
                    }
                }

                return modHuanLuyen.miDelay;
            }
        }
        private void SetRadaStatus(DateTime mLuc)
        {
            foreach (CFlight current in this.m_Flights)
            {
                current.GetMayBay2(modHuanLuyen.fMain.AxMap1, mLuc);
                if (current.MayBay.Status == enTopStatus.DangBay)
                {
                    CMayBay cMayBay = new CMayBay(0);
                    CMayBay cMayBay2 = cMayBay;
                    cMayBay2.Pos.x = current.MayBay.Pos.x;
                    cMayBay2.Pos.y = current.MayBay.Pos.y;
                    cMayBay2.Pos.h = current.MayBay.Pos.h;
                    cMayBay2.Rotation = current.MayBay.Rotation;
                    cMayBay2.Speed = current.MayBay.Speed;
                    cMayBay2.Status = current.MayBay.Status;
                    cMayBay2.Visible = current.MayBay.Visible;
                    cMayBay2.Luc = mLuc;
                    current.MayBays.Add(cMayBay);
                }
            }

            modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            foreach (CRada current2 in this.m_BaiTapRadas)
            {
                foreach (CFlight current3 in this.m_Flights)
                {
                    if (!current3.isBusy)
                    {
                        this.SetRadaStatus(current2, current3, mLuc, modHuanLuyen.fMain.AxMap1);
                    }
                }

            }

            string key = mLuc.Hour.ToString("00") + mLuc.Minute.ToString("00");
            string text = this.GetTinhBaoGan(mLuc);
            if (text.Length > 0)
            {
                this.BTGanDataDict.Add(key, text);
                this.SendBanTinGan(mLuc);
            }
            if (this.m_Phut % modHuanLuyen.ChuKyPhat55 == 0)
            {
                text = this.GetTinhBao55(mLuc);
                if (text.Length > 0)
                {
                    this.BT55DataDict.Add(key, text);
                    this.SendBanTin55(mLuc);
                }
            }
            if (this.m_Phut % modHuanLuyen.ChuKyPhat99 == 0)
            {
                text = this.GetTinhBao99(mLuc);
                if (text.Length > 0)
                {
                    this.BT99DataDict.Add(key, text);
                }
            }
        }
        private void SetRadaStatus(CRada pRada, CFlight pFlight, DateTime pLuc, AxMap pMap)
        {
            try
            {
                int num = this.m_BaiTapRadas.IndexOf(pRada);
                int num2 = this.m_Flights.IndexOf(pFlight);
                this.m_RadaFlights[num, num2].SetStatus(pMap, pLuc, this.m_Flights[num2]);
                if (this.m_RadaFlights[num, num2].Status == enRadaStatus.XuatHien)
                {
                    this.m_RadaFlights[num, num2].Stt = this.GetStt(pRada, pFlight);
                }
                else if (this.m_RadaFlights[num, num2].Status == enRadaStatus.MatMT)
                {
                    pFlight.visible = false;
                }
            }
            catch (Exception expr_8A)
            {
                throw expr_8A;
            }
        }
        private void SendBanTinGan(DateTime mLuc)
        {
            try
            {
                string key = mLuc.Hour.ToString("00") + mLuc.Minute.ToString("00");
                string text = this.BTGanDataDict[key];
                if (text != null)
                {
                    if (text.Length > 0)
                    {
                        int length = this.txtBanTinGan.Text.Length;
                        int length2 = text.Length;
                        TextBox txtBanTinGan = this.txtBanTinGan;
                        txtBanTinGan.Text = txtBanTinGan.Text + text + "\r\n";
                        this.txtBanTinGan.SelectionStart = length;
                        this.txtBanTinGan.SelectionLength = length2;
                        this.txtBanTinGan.ScrollToCaret();
                    }
                    modHuanLuyen.fMain.SendBanTinGan(text);
                }
            }
            catch (Exception expr_B9)
            {
                throw expr_B9;
            }
        }
        private void SendBanTin55(DateTime mLuc)
        {
            try
            {
                string key = mLuc.Hour.ToString("00") + mLuc.Minute.ToString("00");
                string text = this.BT55DataDict[key];
                if (text != null)
                {
                    if (text.Length > 0)
                    {
                        int length = this.txtBanTin55.Text.Length;
                        int length2 = text.Length;
                        TextBox txtBanTin = this.txtBanTin55;
                        txtBanTin.Text = txtBanTin.Text + text + "\r\n";
                        this.txtBanTin55.SelectionStart = length;
                        this.txtBanTin55.SelectionLength = length2;
                        this.txtBanTin55.ScrollToCaret();
                    }
                    modHuanLuyen.fMain.SendBanTin55(text);
                }
            }
            catch (Exception expr_B9)
            {
                throw expr_B9;
            }
        }
        private void SendBanTin99(DateTime mLuc)
        {
            try
            {
                string key = mLuc.Hour.ToString("00") + mLuc.Minute.ToString("00");
                string text = this.BT99DataDict[key];
                if (text != null && text.Length > 0)
                {
                    int length = this.txtBanTin99.Text.Length;
                    int length2 = text.Length;
                    TextBox txtBanTin = this.txtBanTin99;
                    txtBanTin.Text = txtBanTin.Text + text + "\r\n";
                    this.txtBanTin99.SelectionStart = length;
                    this.txtBanTin99.SelectionLength = length2;
                    this.txtBanTin99.ScrollToCaret();
                    modHuanLuyen.fMain.SendBanTin99(text);
                }
            }
            catch (Exception expr_B9)
            {
                throw expr_B9;
            }
        }
        public void SetBusy(CFlight pFlight, bool pBusy)
        {
            pFlight.isBusy = pBusy;
        }
        public void AddNode(DateTime pTd, CMayBay pLastMaybay)
        {
            DateTime dateTime = new DateTime(pTd.Year, pTd.Month, pTd.Day, pTd.Hour, pTd.Minute, pTd.Second);
            int num = this.EditingFlight.GetCurrIndex(dateTime);
            checked
            {
                if (num > -1 & num < this.EditingFlight.Path.Count - 1)
                {
                    FlightNode flightNode = this.EditingFlight.Path[num];
                    FlightNode flightNode2 = this.EditingFlight.Path[num + 1];
                    FlightNode flightNode3 = new FlightNode(new MapPoint(0.0, 0.0)
                    {
                        x = pLastMaybay.Pos.x,
                        y = pLastMaybay.Pos.y,
                        h = pLastMaybay.Pos.h
                    });
                    PathNode node = flightNode3.node;
                    node.Speed = pLastMaybay.Speed;
                    node.Roll = 0f;
                    node.Turn = TurnValue.None;
                    flightNode3.td = dateTime;
                    flightNode3.nodetype = 1;
                    this.EditingFlight.Path.Insert(num + 1, flightNode3);
                    num++;
                    this.EditingFlight.updateLastNode(num - 1);
                    MapPoint pMapPt = new MapPoint(0.0, 0.0);
                    pMapPt.x = pLastMaybay.Pos.x;
                    pMapPt.y = pLastMaybay.Pos.y;
                    pMapPt.h = pLastMaybay.Pos.h;
                    DateTime dongHo = this.GetDongHo();
                    double num2 = dongHo.Subtract(dateTime).TotalMilliseconds / 1000.0;
                    FlightNode flightNode4 = new FlightNode(pMapPt);
                    PathNode node2 = flightNode4.node;
                    node2.Speed = pLastMaybay.Speed;
                    node2.Roll = 0f;
                    node2.Turn = TurnValue.None;
                    node2.t2next = num2;
                    flightNode4.td = dateTime;
                    flightNode4.nodetype = 1;
                    this.EditingFlight.Path.Insert(num + 1, flightNode4);
                    num++;
                    double mBanKinh = unchecked(num2 * pLastMaybay.Speed) / 3600.0;
                    MapPoint fromHeading = CBasePath.GetFromHeading(modHuanLuyen.fMain.AxMap1, flightNode4.node.D, (double)pLastMaybay.Rotation, mBanKinh);
                    fromHeading.h = pLastMaybay.Pos.h;
                    FlightNode flightNode5 = new FlightNode(fromHeading);
                    PathNode node3 = flightNode5.node;
                    node3.Speed = pLastMaybay.Speed;
                    node3.Roll = this.EditingFlight.ObjLoaiMB.Roll;
                    node3.Turn = TurnValue.None;
                    flightNode5.td = dongHo;
                    flightNode5.nodetype = 0;
                    this.EditingFlight.Path.Insert(num + 1, flightNode4);
                    num++;
                    this.iEditNode = num;
                    new dlgLuonVong
                    {
                        nudSpeedChange =
                        {
                            Value = new decimal((int)Math.Round(pLastMaybay.Speed))
                        },
                        nudTspeed =
                        {
                            Value = decimal.Zero
                        },
                        TopMost = true
                    }.ShowDialog(this, dongHo, (double)pLastMaybay.Rotation, flightNode5);
                    int arg_32C_0 = num;
                    int num3 = num - 2;
                    for (int i = arg_32C_0; i >= num3; i += -1)
                    {
                        this.EditingFlight.updateLastNode(i);
                    }
                }
                else
                {
                }
            }
        }
        private void AddNodeAt2(CFlight pSeleFlight, int iLastNode, DateTime lastTd)
        {
            FlightNode flightNode = pSeleFlight.Path[iLastNode];
            checked
            {
                FlightNode flightNode2 = pSeleFlight.Path[iLastNode + 1];
                int num = (int)Math.Round(flightNode2.td.Subtract(lastTd).TotalSeconds / 2.0);
                if (num > 30)
                {
                    DateTime dateTime = lastTd.AddSeconds((double)num);
                    CMayBay mayBay = pSeleFlight.getMayBay(modHuanLuyen.fMain.AxMap1, dateTime);
                    FlightNode flightNode3 = new FlightNode(mayBay.Pos);
                    PathNode node = flightNode3.node;
                    node.Speed = mayBay.Speed;
                    node.Roll = 40f;
                    node.Turn = TurnValue.None;
                    flightNode3.td = dateTime;
                    flightNode3.nodetype = 0;
                    pSeleFlight.Path.Insert(iLastNode + 1, flightNode3);
                    pSeleFlight.updateLastNode(iLastNode);
                    this.iEditNode = iLastNode + 1;
                    int num2 = 1;
                    if (this.iEditNode > 0)
                    {
                        num2 = this.iEditNode;
                    }
                    pSeleFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, num2);
                    pSeleFlight.UpdateTd(num2 - 1);
                }
                else
                {
                }
            }
        }
        private void resumeflying()
        {
            if (this.btnStart.Text.IndexOf("Kết thúc") >= 0)
            {
                try
                {
                    this.StartHL();
                }
                catch (Exception expr_20)
                {
                    throw expr_20;
                }
            }
        }
        public void saveflight(CFlight pFlight)
        {
            CFlights.InsertNode("tblFlight", pFlight);
        }
        public void DeleteNode(CFlight pFlight)
        {
            this.EditingFlight = pFlight;
            DateTime dongHo = this.GetDongHo();
            int currIndex = this.EditingFlight.GetCurrIndex(dongHo);
            checked
            {
                if (currIndex > -1 & currIndex < this.EditingFlight.Path.Count - 1)
                {
                    if (currIndex == this.iEditNode - 1)
                    {
                        CMayBay mayBay = pFlight.MayBay;
                        this.EditingFlight.Path.Remove(this.EditingFlight.Path[this.iEditNode]);
                        this.EditingFlight.Path[this.iEditNode].node.Turn = TurnValue.None;
                        this.AddNode(dongHo, mayBay);
                    }
                    else
                    {
                        this.EditingFlight.Path.Remove(this.EditingFlight.Path[this.iEditNode]);
                        this.EditingFlight.Path[this.iEditNode].node.Turn = TurnValue.None;
                        int num = 1;
                        if (this.iEditNode > 2)
                        {
                            num = this.iEditNode - 1;
                        }
                        this.EditingFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, num);
                        this.EditingFlight.UpdateTd(num - 1);
                    }
                    modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
                }
                else
                {
                }
            }
        }
        public void m_Map_DrawUserLayer(object sender, CMapXEvents_DrawUserLayerEvent e)
        {
            List<CFlight> flights = this.m_Flights;
            lock (flights)
            {
                try
                {
                    Pen pen = new Pen(Color.Blue, 1f);
                    IntPtr hdc = new IntPtr(e.hOutputDC);
                    Graphics g = Graphics.FromHdc(hdc);
                    foreach (CFlight current in this.m_Flights)
                    {
                        switch (current.LoaiTopID)
                        {
                            case 1:
                                pen.Color = modHuanLuyen.defaTopDichColor;
                                break;
                            case 2:
                                pen.Color = modHuanLuyen.defaTopTaColor;
                                break;
                            case 3:
                                pen.Color = modHuanLuyen.defaTopQuocTeColor;
                                break;
                            case 4:
                                pen.Color = modHuanLuyen.defaTopQuaCanhColor;
                                break;
                        }
                        if (current == this.SeleFlight)
                        {
                            pen.Width = 2f;
                            this.SeleFlight.DrawDuongBay(modHuanLuyen.fMain.AxMap1, g, pen, true);
                        }
                        else
                        {
                            pen.Width = 1f;
                            current.DrawDuongBay(modHuanLuyen.fMain.AxMap1, g, pen, false);
                        }
                    }

                    if (this.EditingFlight != null && this.EditingFlight.visible)
                    {
                        this.EditingFlight.DrawNodes(modHuanLuyen.fMain.AxMap1, g, this.iEditNode);
                    }
                    if (modHuanLuyen.fFlightNodeEdit != null)
                    {
                        modHuanLuyen.fFlightNodeEdit.DrawPos(modHuanLuyen.fMain.AxMap1, g);
                    }
                }
                catch (Exception expr_15B)
                {
                    throw expr_15B;
                }
            }
        }
        private void m_Map_MouseDownEvent2(object sender, CMapXEvents_MouseDownEvent e)
        {
            this.iEditNode = -1;
            AxMap arg_2D_0 = modHuanLuyen.fMain.AxMap1;
            PointF pointF = new PointF(e.x, e.y);
            this.SeleFlight = CFlights.FindAtPoint(arg_2D_0, pointF, this.m_Flights);
            checked
            {
                if (this.SeleFlight != null)
                {
                    int num = this.m_Flights.IndexOf(this.SeleFlight);
                    this.grdTops.Rows[num].Selected = true;
                    this.grdTops.FirstDisplayedScrollingRowIndex = num;
                    this.EditingFlight = this.SeleFlight;
                    modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
                    if (e.button == 2)
                    {
                        //ToolStripDropDown arg_D6_0 = this.MayBayContextMenuStrip;
                        //Control arg_D6_1 = modHuanLuyen.fMain.PanelRight;
                        //System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                        //arg_D6_0.Show(arg_D6_1, position);
                    }
                }
                else
                {
                    this.iEditNode = -1;
                    AxMap arg_10D_0 = modHuanLuyen.fMain.AxMap1;
                    pointF = new PointF(e.x, e.y);
                    this.SeleFlight = CFlights.FindAtPoint2(arg_10D_0, pointF, this.m_Flights);
                    if (this.SeleFlight != null)
                    {
                        int num2 = this.m_Flights.IndexOf(this.SeleFlight);
                        this.grdTops.Rows[num2].Selected = true;
                        this.grdTops.FirstDisplayedScrollingRowIndex = num2;
                        this.EditingFlight = this.SeleFlight;
                        modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
                        CFlight arg_19C_0 = this.EditingFlight;
                        AxMap arg_19C_1 = modHuanLuyen.fMain.AxMap1;
                        pointF = new PointF(e.x, e.y);
                        int num3 = arg_19C_0.FindNodeAtPoint(arg_19C_1, pointF);
                        if (num3 > -1)
                        {
                            if (e.button == 2)
                            {
                                DateTime dongHo = this.GetDongHo();
                                if (DateTime.Compare(this.EditingFlight.Path[num3].td, dongHo) > 0)
                                {
                                    //this.iEditNode = num3;
                                    //ToolStripDropDown arg_212_0 = this.FlightNodeContextMenuStrip;
                                    //Control arg_212_1 = modHuanLuyen.fMain.PanelRight;
                                    //System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                    //arg_212_0.Show(arg_212_1, position);
                                }
                            }
                        }
                    }
                    else if (e.button == 2)
                    {
                        frmMain arg_247_0 = modHuanLuyen.fMain;
                        pointF = new PointF(e.x, e.y);
                        CAirport cAirport = arg_247_0.FindAirportAt(pointF);
                        if (cAirport != null)
                        {
                            AxMap arg_29A_0 = modHuanLuyen.fMain.AxMap1;
                            float num4 = (float)this.myPt.X;
                            float num5 = (float)this.myPt.Y;
                            arg_29A_0.ConvertCoord(ref num4, ref num5, ref cAirport.Pos.x, ref cAirport.Pos.y, ConversionConstants.miMapToScreen);
                            this.myPt.Y = (int)Math.Round((double)num5);
                            this.myPt.X = (int)Math.Round((double)num4);
                        }
                        else
                        {
                            this.myPt.X = (int)Math.Round((double)e.x);
                            this.myPt.Y = (int)Math.Round((double)e.y);
                        }
                        this.NewContextMenuStrip.Show(modHuanLuyen.fMain.PanelRight, this.myPt);
                    }
                    else
                    {
                        this.EditingFlight = this.SeleFlight;
                        modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
                    }
                }
            }
        }
        public void m_Map_MouseDownEvent(object sender, CMapXEvents_MouseDownEvent e)
        {
            if (modHuanLuyen.fFlightNodeEdit == null)
            {
                if (this.EditingFlight != null)
                {
                    CFlight arg_3E_0 = this.EditingFlight;
                    AxMap arg_3E_1 = modHuanLuyen.fMain.AxMap1;
                    PointF pt = new PointF(e.x, e.y);
                    int num = arg_3E_0.FindNodeAtPoint(arg_3E_1, pt);
                    if (num > -1)
                    {
                        if (e.button == 2)
                        {
                            DateTime dongHo = this.GetDongHo();
                            if (DateTime.Compare(this.EditingFlight.Path[num].td, dongHo) > 0)
                            {
                                //this.iEditNode = num;
                                //ToolStripDropDown arg_B3_0 = this.FlightNodeContextMenuStrip;
                                //Control arg_B3_1 = modHuanLuyen.fMain.PanelRight;
                                //System.Drawing.Point position = checked(new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y)));
                                //arg_B3_0.Show(arg_B3_1, position);
                            }
                        }
                    }
                    else
                    {
                        this.m_Map_MouseDownEvent2(sender, e);
                    }
                }
                else
                {
                    this.m_Map_MouseDownEvent2(sender, e);
                }
            }
        }
        private void NewTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vẽ tốp bay mới?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                modHuanLuyen.fMain.VeTopMoi(this.myPt);
            }
        }
        private void FlightNodeAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.EditingFlight != null)
            {
                int num = this.iEditNode;
                FlightNode flightNode = this.EditingFlight.Path[num];
                this.AddNodeAt2(this.EditingFlight, num, flightNode.td);
                this.SeleFlight = this.EditingFlight;
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void FlightNodeDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.EditingFlight != null && MessageBox.Show("Thật sự muốn bỏ điểm này?", "Xóa điểm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DeleteNode(this.EditingFlight);
            }
        }
        private void FlightNodeUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (this.m_EditingFlight != null)
            //{
            //    new dlgFlightNodeEdit
            //    {
            //        Text = "Cập nhật điểm " + this.iEditNode.ToString(),
            //        OK_Button =
            //        {
            //            Text = "Update"
            //        },
            //        txtPath_ID =
            //        {
            //            Text = this.m_EditingFlight.TopID.ToString()
            //        },
            //        txtStt =
            //        {
            //            Text = this.iEditNode.ToString()
            //        },
            //        TopMost = true
            //    }.Show(this);
            //}
            //else
            //{
            //}
        }
        private void MayBayStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SeleFlight != null)
            {
                DateTime dongHo = this.GetDongHo();
                this.SeleFlight.StopMayBay(dongHo);
                modHuanLuyen.fMain.lyrAnimation.Invalidate(Missing.Value);
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void MayBayAddNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SeleFlight != null)
            {
                DateTime dongHo = this.GetDongHo();
                int currIndex = this.SeleFlight.GetCurrIndex(dongHo);
                this.AddNodeAt2(this.SeleFlight, currIndex, dongHo);
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void FlightNodeContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            //if (this.iEditNode < checked(this.EditingFlight.Path.Count - 1))
            //{
            //    this.FlightNodeAddToolStripMenuItem.Enabled = true;
            //    this.FlightNodeDeleteToolStripMenuItem.Enabled = true;
            //    this.FlightNodeUpdateToolStripMenuItem.Enabled = true;
            //}
            //else
            //{
            //    this.FlightNodeAddToolStripMenuItem.Enabled = false;
            //    this.FlightNodeDeleteToolStripMenuItem.Enabled = false;
            //    this.FlightNodeUpdateToolStripMenuItem.Enabled = true;
            //}
        }
        public void updateLastNode(CFlight pEditingFlight, FlightNode lastnode, FlightNode nextnode, DateTime mTd)
        {
            double num = lastnode.node.typ + lastnode.node.tspeed + lastnode.node.t2next;
            double speed = lastnode.node.Speed / 3.6;
            double speed2 = nextnode.node.Speed / 3.6;
            double num2 = pEditingFlight.getquangduong2(num * 1000.0, speed, speed2, lastnode.node.typ, lastnode.node.tspeed);
            double misecs = lastnode.node.typ * 1000.0;
            double num3 = pEditingFlight.getquangduong2(misecs, speed, speed2, lastnode.node.typ, lastnode.node.tspeed);
            misecs = (lastnode.node.typ + lastnode.node.tspeed) * 1000.0;
            double num4 = pEditingFlight.getquangduong2(misecs, speed, speed2, lastnode.node.typ, lastnode.node.tspeed);
            double totalMilliseconds = mTd.Subtract(lastnode.td).TotalMilliseconds;
            double num5 = pEditingFlight.getquangduong2(totalMilliseconds, speed, speed2, lastnode.node.typ, lastnode.node.tspeed);
            double num6 = totalMilliseconds / 1000.0;
            if (num5 >= num4)
            {
                lastnode.node.t2next = num6 - (lastnode.node.typ + lastnode.node.tspeed);
            }
            else if (num5 >= num3)
            {
                lastnode.node.t2next = 0.0;
                lastnode.node.tspeed = num6 - lastnode.node.typ;
            }
            else
            {
                lastnode.node.t2next = 0.0;
                lastnode.node.tspeed = 0.0;
                lastnode.node.typ = num6;
                double num7 = num5 / num3;
                lastnode.node.yp = lastnode.node.yp * num7;
            }
        }
        private void btnResume_Click(object sender, EventArgs e)
        {
        }
        private void HLProcess1_UpdateXong(int pDelay)
        {
            try
            {
                modHuanLuyen.fMain.lyrAnimation.Invalidate(Missing.Value);
            }
            catch (Exception expr_16)
            {
                throw expr_16;
            }
        }
        private void SetUpGridView(DataGridView grd)
        {
            DataGridViewCellStyle columnHeadersDefaultCellStyle = grd.ColumnHeadersDefaultCellStyle;
            columnHeadersDefaultCellStyle.BackColor = Color.Navy;
            columnHeadersDefaultCellStyle.ForeColor = Color.White;
            columnHeadersDefaultCellStyle.Font = new Font(this.grdTops.Font, FontStyle.Bold);
            grd.RowHeadersVisible = false;
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grd.MultiSelect = false;
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
        }

        private void lstBaiTapTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SeleFlight != null)
            {
                this.EditingFlight = this.SeleFlight;
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private CFlight GetFlight(int lFlight_ID)
        {
            cantimFlight_ID = lFlight_ID;
            return this.m_Flights.Find(new Predicate<CFlight>(FlightIDequal));
        }
        private static bool FlightIDequal(CFlight pFlight)
        {
            return pFlight.Flight_ID == cantimFlight_ID;
        }
        private void grdTops_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.SeleFlight != null)
            {
                modHuanLuyen.fMain.AxMap1.ZoomTo(modHuanLuyen.fMain.AxMap1.Zoom, this.SeleFlight.MayBay.Pos.x, this.SeleFlight.MayBay.Pos.y);
            }
        }
        private void grdTops_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.bLoaded && (e.RowIndex > -1 & e.ColumnIndex == 6))
            {
                DataRowView dataRowView = this.dvTops[e.RowIndex];
                int lFlight_ID = Convert.ToInt32(dataRowView["TopID"]);
                CFlight flight = this.GetFlight(lFlight_ID);
                if (flight != null)
                {
                    flight.visible = Convert.ToBoolean(this.grdTops.CurrentCell.Value);
                    modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void grdTops_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.bLoaded && e.RowIndex > -1)
            {
                DataRowView dataRowView = this.dvTops[e.RowIndex];
                int lFlight_ID = Convert.ToInt32(dataRowView["TopID"]);
                this.SeleFlight = this.GetFlight(lFlight_ID);
                if (this.SeleFlight != null)
                {
                    modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void MayBayTachTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SeleFlight != null && MessageBox.Show("Tách tốp '" + this.SeleFlight.FlightNo + "'?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.TachFlight = this.SeleFlight;
                this.newDeparture = this.GetDongHo();
                this.TachFlight.GetMayBay2(modHuanLuyen.fMain.AxMap1, this.newDeparture);
                this.newMayBay = this.TachFlight.MayBay;
                modHuanLuyen.fMain.VeTopTach(this.newMayBay.Pos);
            }
        }
        private void MayBayContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            //if (this.SeleFlight != null)
            //{
            //    if (this.SeleFlight.SoLuong > 1)
            //    {
            //        this.MayBayTachTopToolStripMenuItem.Enabled = true;
            //    }
            //    else
            //    {
            //        this.MayBayTachTopToolStripMenuItem.Enabled = false;
            //    }
            //}
        }
        private void MayBayDoiHuongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SeleFlight != null && MessageBox.Show("Đổi hướng tốp '" + this.SeleFlight.FlightNo + "'?", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.DoiHuongFlight = this.SeleFlight;
                this.newDeparture = this.GetDongHo();
                this.DoiHuongFlight.GetMayBay2(modHuanLuyen.fMain.AxMap1, this.newDeparture);
                this.newMayBay = this.DoiHuongFlight.MayBay;
                modHuanLuyen.fMain.VeTopLai(this.newMayBay.Pos);
            }
        }

        private void chkHienKyHieu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                modHuanLuyen.fMain.chkHienKyHieu.Checked = this.chkHienKyHieu.Checked;
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }

        }

    }
}
