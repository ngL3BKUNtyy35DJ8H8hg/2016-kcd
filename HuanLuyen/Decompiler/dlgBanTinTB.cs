using AxMapXLib;
using Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace HuanLuyen
{

    public partial class dlgBanTinTB : Form
    {
        private DateTime TdBatDau;
        private DateTime TdKetThuc;
        private List<CFlight> m_Flights;
        private List<CRada> m_BaiTapRadas;
        private CRadaFlight[,] m_RadaFlights;
        private System.Data.DataTable dtGan;
        private System.Data.DataTable dt55;
        private System.Data.DataTable dt99;
        private string myApplPath;

        public dlgBanTinTB()
        {
            this.InitializeComponent();
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
        private void PopulateRadas()
        {
            if (this.m_BaiTapRadas.Count > 0)
            {
                CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fBaiTapHinhThai.cboBaiTap.SelectedItem;
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

            foreach (CTop pTop in (IEnumerable)modHuanLuyen.fBaiTapHinhThai.Tops)
            {
                try
                {
                    CFlight cFlight = new CFlight(pTop);
                    if (cFlight != null)
                    {
                        num++;
                        cFlight.Flight_ID = num;
                        this.Tinh2Flight(cFlight);
                        list.Add(cFlight);
                    }
                }
                catch (Exception expr_5E)
                {
                    throw expr_5E;

                }
            }
            return list;
        }

        private void Tinh2Flight(CFlight pFlight)
        {
            CBasePath.TinhSecs(modHuanLuyen.fBaiTapHinhThai.AxMap1, pFlight.Path[0].node, pFlight.Path[1].node);
            DateTime pTd = pFlight.Departure.AddSeconds(pFlight.Path[0].node.t2next + pFlight.Path[0].node.tspeed);
            pFlight.TinhYToLuonVong(modHuanLuyen.fBaiTapHinhThai.AxMap1, 1);
            pFlight.UpdateTd(1, pTd);
        }
        public DialogResult ShowDialog(Form parent, List<CRada> pRadas)
        {
            this.m_Flights = this.GetFlights();
            this.m_BaiTapRadas = pRadas;
            return this.ShowDialog(parent);
        }

        private void dlgBanTinTB_Load(object sender, EventArgs e)
        {
            this.PopulateRadas();
            this.CreateRadaFlights();
            this.SetUpGridView(this.grdTBGan);
            this.SetUpGridView(this.grdTB55);
            this.SetUpGridView(this.grdTB99);
            this.btnBT55ToExcel.Enabled = false;
            this.btnBT99ToExcel.Enabled = false;
            this.btnBTGanToExcel.Enabled = false;
            this.myApplPath = Directory.GetCurrentDirectory();
            DateTime now = DateTime.Now;
            this.TdBatDau = checked(new DateTime(now.Year, now.Month, now.Day, (int)Math.Round(double.Parse(modHuanLuyen.fBaiTapHinhThai.txtGioBatDau.Text)), (int)Math.Round(double.Parse(modHuanLuyen.fBaiTapHinhThai.txtPhutBatDau.Text)), 0));
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
        private void SetUpGridView(DataGridView grd)
        {
            DataGridViewCellStyle columnHeadersDefaultCellStyle = grd.ColumnHeadersDefaultCellStyle;
            columnHeadersDefaultCellStyle.BackColor = Color.Navy;
            columnHeadersDefaultCellStyle.ForeColor = Color.White;
            columnHeadersDefaultCellStyle.Font = new System.Drawing.Font(this.grdTBGan.Font, FontStyle.Bold);
            grd.RowHeadersVisible = false;
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grd.MultiSelect = false;
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
        }
        private void PopulateRadaGridView(DataGridView grd, System.Data.DataTable dt)
        {
            grd.DataSource = null;
            DataView defaultView = dt.DefaultView;
            defaultView.Sort = "ThoiGian, DauTop";
            grd.DataSource = defaultView;
            int num = 0;
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grd.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn2.DataPropertyName = "XH";
            dataGridViewTextBoxColumn2.Name = "XH";
            dataGridViewTextBoxColumn2.HeaderText = "XH";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 40;
            dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grd.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn3.DataPropertyName = "DauTop";
            dataGridViewTextBoxColumn3.Name = "DauTop";
            dataGridViewTextBoxColumn3.HeaderText = "Đầu tốp";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 60;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grd.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn4 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn4.DataPropertyName = "ToaDo";
            dataGridViewTextBoxColumn4.Name = "ToaDo";
            dataGridViewTextBoxColumn4.HeaderText = "Tọa độ";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 80;
            dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grd.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn5 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn5.DataPropertyName = "SoLuong";
            dataGridViewTextBoxColumn5.Name = "SoLuong";
            dataGridViewTextBoxColumn5.HeaderText = "SL";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 40;
            dataGridViewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grd.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn6 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn6.DataPropertyName = "KieuLoai";
            dataGridViewTextBoxColumn6.Name = "KieuLoai";
            dataGridViewTextBoxColumn6.HeaderText = "KL";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 40;
            dataGridViewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grd.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn7 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn7.DataPropertyName = "DoCao";
            dataGridViewTextBoxColumn7.Name = "DoCao";
            dataGridViewTextBoxColumn7.HeaderText = "Độ cao";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 60;
            dataGridViewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grd.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn8 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn8.DataPropertyName = "ThoiGian";
            dataGridViewTextBoxColumn8.Name = "ThoiGian";
            dataGridViewTextBoxColumn8.HeaderText = "Thời gian";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.Width = 80;
            dataGridViewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)grd.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn9 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn9.DataPropertyName = "TopID";
            dataGridViewTextBoxColumn9.Name = "TopID";
            dataGridViewTextBoxColumn9.HeaderText = "";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            dataGridViewTextBoxColumn9.Width = 0;
            dataGridViewTextBoxColumn9.Visible = false;
        }
        private System.Data.DataTable Creatdt()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            DataColumnCollection columns = dataTable.Columns;
            columns.Add("XH", Type.GetType("System.String"));
            columns.Add("DauTop", Type.GetType("System.String"));
            columns.Add("ToaDo", Type.GetType("System.String"));
            columns.Add("SoLuong", Type.GetType("System.String"));
            columns.Add("KieuLoai", Type.GetType("System.String"));
            columns.Add("DoCao", Type.GetType("System.String"));
            columns.Add("ThoiGian", Type.GetType("System.String"));
            columns.Add("TopID", Type.GetType("System.Int32"));
            return dataTable;
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
        private int GetRadaStt(CRada pRada, CFlight pFlight)
        {
            int num = 0;
            int num2 = this.m_BaiTapRadas.IndexOf(pRada);
            int num3 = this.m_Flights.IndexOf(pFlight);
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
        private void SetRadaStatus(DateTime mLuc)
        {
            foreach (CFlight current in this.m_Flights)
            {
                current.GetMayBay2(modHuanLuyen.fBaiTapHinhThai.AxMap1, mLuc);
            }

            foreach (CRada current2 in this.m_BaiTapRadas)
            {
                foreach (CFlight current3 in this.m_Flights)
                {
                    if (!current3.isBusy)
                    {
                        this.SetRadaStatus(current2, current3, mLuc, modHuanLuyen.fBaiTapHinhThai.AxMap1);
                    }
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
        private void btnTaoBT_Click(object sender, EventArgs e)
        {
            this.btnTaoBT.Enabled = false;
            this.btnTaoBT.Click += new EventHandler(this.btnTaoBT_Click);
            this.dtGan = this.Creatdt();
            this.dt55 = this.Creatdt();
            this.dt99 = this.Creatdt();
            int num = (int)Math.Round(double.Parse(this.txtSoPhut.Text));
            if (num > 0)
            {
                int num2 = num;
                for (int i = 0; i < num2; i++)
                {
                    DateTime dateTime = this.TdBatDau.AddMinutes((double)i);
                    this.SetRadaStatus(dateTime);
                    this.GetTinhBaoGan(dateTime);
                    this.GetTinhBao55(dateTime);
                    this.GetTinhBao99(dateTime);
                }
            }
            this.PopulateRadaGridView(this.grdTBGan, this.dtGan);
            this.PopulateRadaGridView(this.grdTB55, this.dt55);
            this.PopulateRadaGridView(this.grdTB99, this.dt99);
            this.btnBT55ToExcel.Enabled = true;
            this.btnBT55ToExcel.Click += new EventHandler(this.btnBT55ToExcel_Click);
            this.btnBT99ToExcel.Enabled = true;
            this.btnBT99ToExcel.Click += new EventHandler(this.btnBT99ToExcel_Click);
            this.btnBTGanToExcel.Enabled = true;
            this.btnBTGanToExcel.Click += new EventHandler(this.btnBTGanToExcel_Click);

        }
        private void GetTinhBaoGan(DateTime pLuc)
        {
            foreach (CRada current in this.m_BaiTapRadas)
            {
                if (current.LoaiRadaID == 3)
                {
                    int num = this.m_BaiTapRadas.IndexOf(current);
                    foreach (CFlight current2 in this.m_Flights)
                    {
                        int num2 = this.m_Flights.IndexOf(current2);
                        CRadaFlight mRadaFlight = this.m_RadaFlights[num, num2];
                        DataRow mTgan = this.GetMTgan(pLuc, mRadaFlight);
                        if (mTgan != null)
                        {
                            this.dtGan.Rows.Add(mTgan);
                        }
                    }

                }
            }

        }
        private void GetTinhBao55(DateTime pLuc)
        {
            foreach (CRada current in this.m_BaiTapRadas)
            {
                if (current.LoaiRadaID == 2)
                {
                    int num = this.m_BaiTapRadas.IndexOf(current);
                    foreach (CFlight current2 in this.m_Flights)
                    {
                        int num2 = this.m_Flights.IndexOf(current2);
                        CRadaFlight mRadaFlight = this.m_RadaFlights[num, num2];
                        DataRow mT = this.GetMT55(pLuc, mRadaFlight);
                        if (mT != null)
                        {
                            this.dt55.Rows.Add(mT);
                        }
                    }

                }
            }

        }
        private void GetTinhBao99(DateTime pLuc)
        {
            foreach (CRada current in this.m_BaiTapRadas)
            {
                if (current.LoaiRadaID == 1)
                {
                    int num = this.m_BaiTapRadas.IndexOf(current);
                    foreach (CFlight current2 in this.m_Flights)
                    {
                        int num2 = this.m_Flights.IndexOf(current2);
                        CRadaFlight mRadaFlight = this.m_RadaFlights[num, num2];
                        DataRow mT = this.GetMT99(pLuc, mRadaFlight);
                        if (mT != null)
                        {
                            this.dt99.Rows.Add(mT);
                        }
                    }

                }
            }

        }
        private DataRow GetMTgan(DateTime pLuc, CRadaFlight mRadaFlight)
        {
            DataRow dataRow = null;
            if (mRadaFlight.RadaFlightMTs.Count > 0)
            {
                int num = 0;
                if (mRadaFlight.RadaFlightMTs.Count > 1)
                {
                    CRadaFlightMT cRadaFlightMT = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 2];
                    num = (int)Math.Round(cRadaFlightMT.Pos.h / 100.0);
                }
                CRadaFlightMT cRadaFlightMT2 = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 1];
                int num2 = (int)Math.Round(cRadaFlightMT2.Pos.h / 100.0);
                if (cRadaFlightMT2.Gio == pLuc.Hour & cRadaFlightMT2.Phut == pLuc.Minute)
                {
                    CRada rada = mRadaFlight.Rada;
                    CFlight flight = mRadaFlight.Flight;
                    string soHieuTop = this.GetSoHieuTop(rada, flight);
                    struPhuongVi phuongVi = modHuanLuyen.GetPhuongVi(modHuanLuyen.fBaiTapHinhThai.AxMap1, rada.PosX, rada.PosY, cRadaFlightMT2.Pos.x, cRadaFlightMT2.Pos.y);
                    string value = phuongVi.PhuongVi.ToString("000") + "-" + phuongVi.CuLy.ToString("000");
                    dataRow = this.dtGan.NewRow();
                    switch (cRadaFlightMT2.Status)
                    {
                        case enRadaStatus.XuatHien:
                            dataRow["XH"] = "XH";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = value;
                            dataRow["SoLuong"] = mRadaFlight.Flight.SoLuong.ToString("00");
                            dataRow["KieuLoai"] = mRadaFlight.Flight.ObjLoaiMB.KL;
                            dataRow["DoCao"] = num2.ToString("000");
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                        case enRadaStatus.Thay:
                            dataRow["XH"] = "";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = value;
                            if (num2 == num)
                            {
                                dataRow["SoLuong"] = "";
                                dataRow["KieuLoai"] = "";
                                dataRow["DoCao"] = "";
                            }
                            else
                            {
                                dataRow["SoLuong"] = mRadaFlight.Flight.SoLuong.ToString("00");
                                dataRow["KieuLoai"] = mRadaFlight.Flight.ObjLoaiMB.KL;
                                dataRow["DoCao"] = num2.ToString("000");
                            }
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                        case enRadaStatus.TamMatMT:
                            dataRow["XH"] = "TMT";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = value;
                            dataRow["SoLuong"] = "";
                            dataRow["KieuLoai"] = "";
                            dataRow["DoCao"] = "";
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                        case enRadaStatus.MatMT:
                            dataRow["XH"] = "MT";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = value;
                            dataRow["SoLuong"] = "";
                            dataRow["KieuLoai"] = "";
                            dataRow["DoCao"] = "";
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                    }
                }
            }
            return dataRow;
        }
        private DataRow GetMT55(DateTime pLuc, CRadaFlight mRadaFlight)
        {
            DataRow dataRow = null;
            if (mRadaFlight.RadaFlightMTs.Count > 0)
            {
                int num = 0;
                if (mRadaFlight.RadaFlightMTs.Count > 1)
                {
                    CRadaFlightMT cRadaFlightMT = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 2];
                    num = (int)Math.Round(cRadaFlightMT.Pos.h / 100.0);
                }
                CRadaFlightMT cRadaFlightMT2 = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 1];
                int num2 = (int)Math.Round(cRadaFlightMT2.Pos.h / 100.0);
                if (cRadaFlightMT2.Gio == pLuc.Hour & cRadaFlightMT2.Phut == pLuc.Minute)
                {
                    CRada rada = mRadaFlight.Rada;
                    CFlight flight = mRadaFlight.Flight;
                    string soHieuTop = this.GetSoHieuTop(rada, flight);
                    string text = modHuanLuyen.fBaiTapHinhThai.GetToaDo55(cRadaFlightMT2.Pos.x, cRadaFlightMT2.Pos.y);
                    text = Convert.ToString(text.Length > 0 ? text : "000000");
                    dataRow = this.dt55.NewRow();
                    switch (cRadaFlightMT2.Status)
                    {
                        case enRadaStatus.XuatHien:
                            dataRow["XH"] = "XH";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = text;
                            dataRow["SoLuong"] = mRadaFlight.Flight.SoLuong.ToString("00");
                            dataRow["KieuLoai"] = mRadaFlight.Flight.ObjLoaiMB.KL;
                            dataRow["DoCao"] = num2.ToString("000");
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                        case enRadaStatus.Thay:
                            dataRow["XH"] = "";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = text;
                            if (num2 == num)
                            {
                                dataRow["SoLuong"] = "";
                                dataRow["KieuLoai"] = "";
                                dataRow["DoCao"] = "";
                            }
                            else
                            {
                                dataRow["SoLuong"] = mRadaFlight.Flight.SoLuong.ToString("00");
                                dataRow["KieuLoai"] = mRadaFlight.Flight.ObjLoaiMB.KL;
                                dataRow["DoCao"] = num2.ToString("000");
                            }
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                        case enRadaStatus.TamMatMT:
                            dataRow["XH"] = "TMMT";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = text;
                            dataRow["SoLuong"] = "";
                            dataRow["KieuLoai"] = "";
                            dataRow["DoCao"] = "";
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                        case enRadaStatus.MatMT:
                            dataRow["XH"] = "MMT";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = text;
                            dataRow["SoLuong"] = "";
                            dataRow["KieuLoai"] = "";
                            dataRow["DoCao"] = "";
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                    }
                }
            }
            return dataRow;
        }
        private DataRow GetMT99(DateTime pLuc, CRadaFlight mRadaFlight)
        {
            DataRow dataRow = null;
            if (mRadaFlight.RadaFlightMTs.Count > 0)
            {
                int num = 0;
                if (mRadaFlight.RadaFlightMTs.Count > 1)
                {
                    CRadaFlightMT cRadaFlightMT = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 2];
                    num = (int)Math.Round(cRadaFlightMT.Pos.h / 100.0);
                }
                CRadaFlightMT cRadaFlightMT2 = mRadaFlight.RadaFlightMTs[mRadaFlight.RadaFlightMTs.Count - 1];
                int num2 = (int)Math.Round(cRadaFlightMT2.Pos.h / 100.0);
                if (cRadaFlightMT2.Gio == pLuc.Hour & cRadaFlightMT2.Phut == pLuc.Minute)
                {
                    CRada rada = mRadaFlight.Rada;
                    CFlight flight = mRadaFlight.Flight;
                    string soHieuTop = this.GetSoHieuTop(rada, flight);
                    string text = modHuanLuyen.fBaiTapHinhThai.GetToaDo99(cRadaFlightMT2.Pos.x, cRadaFlightMT2.Pos.y);
                    text = Convert.ToString(text.Length > 0 ? text : "0 0000");
                    dataRow = this.dt99.NewRow();
                    switch (cRadaFlightMT2.Status)
                    {
                        case enRadaStatus.XuatHien:
                            dataRow["XH"] = "XH";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = text;
                            dataRow["SoLuong"] = mRadaFlight.Flight.SoLuong.ToString("00");
                            dataRow["KieuLoai"] = mRadaFlight.Flight.ObjLoaiMB.KL;
                            dataRow["DoCao"] = num2.ToString("000");
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                        case enRadaStatus.Thay:
                            dataRow["XH"] = "";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = text;
                            if (num2 == num)
                            {
                                dataRow["SoLuong"] = "";
                                dataRow["KieuLoai"] = "";
                                dataRow["DoCao"] = "";
                            }
                            else
                            {
                                dataRow["SoLuong"] = mRadaFlight.Flight.SoLuong.ToString("00");
                                dataRow["KieuLoai"] = mRadaFlight.Flight.ObjLoaiMB.KL;
                                dataRow["DoCao"] = num2.ToString("000");
                            }
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                        case enRadaStatus.TamMatMT:
                            dataRow["XH"] = "TMMT";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = text;
                            dataRow["SoLuong"] = "";
                            dataRow["KieuLoai"] = "";
                            dataRow["DoCao"] = "";
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                        case enRadaStatus.MatMT:
                            dataRow["XH"] = "MMT";
                            dataRow["DauTop"] = soHieuTop;
                            dataRow["ToaDo"] = text;
                            dataRow["SoLuong"] = "";
                            dataRow["KieuLoai"] = "";
                            dataRow["DoCao"] = "";
                            dataRow["ThoiGian"] = cRadaFlightMT2.Gio.ToString("00") + cRadaFlightMT2.Phut.ToString("00");
                            break;
                    }
                }
            }
            return dataRow;
        }
        private string GetSoHieuTop(CRada pRada, CFlight pFlight)
        {
            int num = this.m_BaiTapRadas.IndexOf(pRada);
            int num2 = this.m_Flights.IndexOf(pFlight);
            int stt = this.m_RadaFlights[num, num2].Stt;
            string result;
            if (pRada.LoaiRadaID == 2)
            {
                result = Convert.ToString(stt > -1 ? pRada.SoHieu + stt.ToString("00") : "Chưa XH");
            }
            else
            {
                result = Convert.ToString(stt > -1 ? stt.ToString("000") : "Chưa XH");
            }
            return result;
        }
        private void ToEXCEL(string mFileName2, string pTieuDe2, System.Data.DataTable pdt)
        {
            //string sourceFileName = "..\\Data\\MauBanTin.xls";
            //File.Copy(sourceFileName, mFileName2, true);
            //Excel.Application application = (Excel.Application)CreateObject("Excel.Application", "");
            //Workbook workbook = application.Workbooks.Open(mFileName2, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            //Worksheet worksheet = (Worksheet)workbook.Worksheets[1];
            //worksheet.Activate();
            //worksheet.Application.Visible = true;
            //int num = 7;
            //int num2 = 1;
            //CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fBaiTapHinhThai.cboBaiTap.SelectedItem;
            //worksheet.Cells[num2, 1] = "Bài tập: " + cBaiTap.BaiTap;
            //    worksheet.Cells[num2 + 1, 1] = pTieuDe2;
            //    num2 = 4;
            //    int num3 = 0;
            //    DataView defaultView = pdt.DefaultView;
            //    int count = defaultView.Count;
            //    Range range = worksheet.get_Range(worksheet.Cells[num2, 1], worksheet.Cells[num2 + count, num]);
            //    Excel.Font font = range.Font;
            //    font.Name = "Arial";
            //    font.Size = 10;
            //    Border border = range.Borders[XlBordersIndex.xlEdgeLeft];
            //    border.LineStyle = XlLineStyle.xlContinuous;
            //    border.Weight = XlBorderWeight.xlThin;
            //    Border border2 = range.Borders[XlBordersIndex.xlEdgeTop];
            //    border2.LineStyle = XlLineStyle.xlContinuous;
            //    border2.Weight = XlBorderWeight.xlThin;
            //    Border border3 = range.Borders[XlBordersIndex.xlEdgeBottom];
            //    border3.LineStyle = XlLineStyle.xlContinuous;
            //    border3.Weight = XlBorderWeight.xlThin;
            //    Border border4 = range.Borders[XlBordersIndex.xlEdgeRight];
            //    border4.LineStyle = XlLineStyle.xlContinuous;
            //    border4.Weight = XlBorderWeight.xlThin;
            //    Border border5 = range.Borders[XlBordersIndex.xlInsideVertical];
            //    border5.LineStyle = XlLineStyle.xlContinuous;
            //    border5.Weight = XlBorderWeight.xlThin;
            //    Border border6 = range.Borders[XlBordersIndex.xlInsideHorizontal];
            //    border6.LineStyle = XlLineStyle.xlDash;
            //    border6.Weight = XlBorderWeight.xlThin;
            //    range.VerticalAlignment = XlVAlign.xlVAlignCenter;
            //    range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            //    range.NumberFormat = "@";
            //    foreach(DataRowView dataRowView in defaultView){
            //            num3++;
            //            worksheet.Cells[num2 + num3, 1] = dataRowView["XH"];
            //            worksheet.Cells[num2 + num3, 2] = dataRowView["DauTop"];
            //            worksheet.Cells[num2 + num3, 3] = dataRowView["ToaDo"];
            //            worksheet.Cells[num2 + num3, 4] = dataRowView["SoLuong"];
            //            worksheet.Cells[num2 + num3, 5] = dataRowView["KieuLoai"];
            //            worksheet.Cells[num2 + num3, 6] = dataRowView["DoCao"];
            //            worksheet.Cells[num2 + num3, 7] = dataRowView["ThoiGian"];
            //        }

            //    application.ActiveWindow.Visible = false;
            //    application.Windows[1].Activate();

        }
        private void btnBTGanToExcel_Click(object sender, EventArgs e)
        {
            string mFileName = this.myApplPath + "\\BanTinGan.xls";
            this.ToEXCEL(mFileName, "Bản tin gần", this.dtGan);
        }
        private void btnBT55ToExcel_Click(object sender, EventArgs e)
        {
            string mFileName = this.myApplPath + "\\BanTin55.xls";
            this.ToEXCEL(mFileName, "Bản tin 5x5", this.dt55);
        }
        private void btnBT99ToExcel_Click(object sender, EventArgs e)
        {
            string mFileName = this.myApplPath + "\\BanTin99.xls";
            this.ToEXCEL(mFileName, "Bản tin 9x9", this.dt99);
        }


    }
}