using AxMapXLib;
using MapXLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
namespace HuanLuyen
{

    public partial class dlgBaiTapHinhThai : Form
    {
        public enum MapTools
        {
            None,
            NodesEdit,
            FlightEdit,
            DangDoKC,
            DangVeKhuat,
            DangVeTuyen,
            DauTopPos
        }
        public dlgBaiTapHinhThai.MapTools myMapTool;
        private bool bLoaded;
        private CTieuDo99 m_TieuDo99;
        private CTieuDo55 m_TieuDo55;
        private CBanDoNen _myBanDoNen;
        public Layer lyrAnimation;
        public Layer lyrCacKyHieu;
        private List<CAirport> m_DrawingAirports;
        private CAirport m_SelectedAirport;
        private List<CAirport> m_DrawingDiaTieus;
        private List<CAirport> m_DrawingTramQSs;
        public string myTblName;
        private List<CBaiTap> m_BaiTaps;
        private CBaiTap m_SeleBaiTap;
        private List<CTop> m_Tops;
        private CTop m_EditingTop;
        private CTop m_MovingTop;
        private CTop m_NewTop;
        public int iEditNode = 0;
        private CTop m_SeleTop;
        private bool m_dirty;
        private List<CRada> m_BaiTapRadas;
        private CRada m_SeleRada;
        private CRada m_NewRada;
        private List<CKhuat> m_AllKhuats;
        private List<CKhuat> m_Khuats;
        private CKhuat m_SeleKhuat;
        private CKhuat m_SeleKhuat2;
        //private CBdTC _myBando;
        //public CPages myPages;
        //private CPage CurrPage;
        private bool NodeDragging;
        private PointF myfromPt = new PointF();
        private PointF mytoPt = new PointF();
        private System.Drawing.Point myPt = 0;
        public bool myDirty;
        private static int cantimTop_ID = 0;
        private static int cantimRada_ID = 0;
        private static int cantimKhuat_ID = 0;
        private DataView dvTops;
        private DataView dvRadas;
        public CBanDoNen myBanDoNen
        {
            get
            {
                return this._myBanDoNen;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                CBanDoNen.VePolygonXongEventHandler obj = new CBanDoNen.VePolygonXongEventHandler(this.myBanDoNen_VePolygonXong);
                CBanDoNen.VeLineXongEventHandler obj2 = new CBanDoNen.VeLineXongEventHandler(this.myBanDoNen_VeLineXong);
                CBanDoNen.VeLaiPolygonXongEventHandler obj3 = new CBanDoNen.VeLaiPolygonXongEventHandler(this.myBanDoNen_VeLaiPolygonXong);
                CBanDoNen.VePolylineXongEventHandler obj4 = new CBanDoNen.VePolylineXongEventHandler(this.myBanDoNen_VePolylineXong);
                //if (this._myBanDoNen != null)
                //{
                //    this._myBanDoNen.VePolygonXong -= obj;
                //    this._myBanDoNen.VeLineXong -= obj2;
                //    this._myBanDoNen.VeLaiPolygonXong -= obj3;
                //    this._myBanDoNen.VePolylineXong -= obj4;
                //}
                //this._myBanDoNen = value;
                //if (this._myBanDoNen != null)
                //{
                //    this._myBanDoNen.VePolygonXong += obj;
                //    this._myBanDoNen.VeLineXong += obj2;
                //    this._myBanDoNen.VeLaiPolygonXong += obj3;
                //    this._myBanDoNen.VePolylineXong += obj4;
                //}
            }
        }
        public object Tops
        {
            get
            {
                return this.m_Tops;
            }
        }
        public CTop EditingTop
        {
            get
            {
                return this.m_EditingTop;
            }
            set
            {
                this.m_EditingTop = value;
            }
        }
        public CTop NewTop
        {
            get
            {
                return this.m_NewTop;
            }
            set
            {
                this.m_NewTop = value;
            }
        }
        public CTop SeleTop
        {
            get
            {
                return this.m_SeleTop;
            }
            set
            {
                this.m_SeleTop = value;
            }
        }
        public CRada NewRada
        {
            get
            {
                return this.m_NewRada;
            }
            set
            {
                this.m_NewRada = value;
            }
        }
        public virtual CBdTC myBando
        {
            get
            {
                return this._myBando;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                this._myBando = value;
            }
        }
        public dlgBaiTapHinhThai()
        {
            base.FormClosing += new FormClosingEventHandler(this.dlgBaiTapHinhThai_FormClosing);
            base.Load += new EventHandler(this.dlgBaiTapHinhThai_Load);
            this.bLoaded = false;
            this.myTblName = "tblAirport";
            this.m_dirty = false;
            //this.myPages = new CPages();
            this.NodeDragging = false;
            this.myPt = default(System.Drawing.Point);
            this.myDirty = false;
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
        public string GetToaDo99(double mLon, double mLat)
        {
            return this.m_TieuDo99.getToaDo(mLon, mLat);
        }
        public string GetToaDo55(double mLon, double mLat)
        {
            return this.m_TieuDo55.getToaDo(this.AxMap1, mLon, mLat);
        }
        private bool InitMap()
        {
            bool result = false;
            try
            {
                CBanDoNen.LoadGst(this.AxMap1, modBanDo.myMapGstLuu);
                this.lyrCacKyHieu = this.AxMap1.Layers.AddUserDrawLayer("LopVeKyHieu", 1);
                this.lyrAnimation = this.AxMap1.Layers.AddUserDrawLayer("AnimationLayer", 1);
                this.AxMap1.Layers.AnimationLayer = this.lyrAnimation;
                this.myBanDoNen = new CBanDoNen(this.AxMap1, this, this.ToolStripStatusLabel3, this.ToolStripStatusLabel1);
                result = true;
            }
            catch (Exception expr_82)
            {
                throw expr_82;
            }
            return result;
        }
        private void LoadNodePatterns()
        {
            modHuanLuyen.m_NodePatterns.Clear();
            ArrayList allPatterns = CNodePatterns.GetAllPatterns();
            foreach (CNodePattern cNodePattern in allPatterns)
            {
                try
                {
                    modHuanLuyen.m_NodePatterns.Add(cNodePattern.PattNo, cNodePattern);
                }
                catch (Exception expr_3D)
                {
                    throw expr_3D;
                    MessageBox.Show("Có Mã số Kiểu ký hiệu trùng: " + cNodePattern.PattNo.ToString(), "Thông báo", MessageBoxButtons.OK);
                }
            }

        }
        private void PopulateAirports()
        {
            if (this.myTblName == "tblAirport")
            {
                this.m_DrawingAirports = CAirports.GetList(this.myTblName);
            }
            else if (this.myTblName == "tblDiaTieu")
            {
                this.m_DrawingDiaTieus = CAirports.GetList(this.myTblName);
            }
            else if (this.myTblName == "tblTramQS")
            {
                this.m_DrawingTramQSs = CAirports.GetList(this.myTblName);
            }
        }
        private void PopulateBaiTaps(int pBaiTapID)
        {
            this.m_BaiTaps = CBaiTaps.GetList();
            this.cboBaiTap.DataSource = this.m_BaiTaps;
            int selectedIndex = -1;
            int num = -1;
            foreach (CBaiTap current in this.m_BaiTaps)
            {
                num++;
                if (current.BaiTapID == pBaiTapID)
                {
                    selectedIndex = num;
                    break;
                }
            }

            this.cboBaiTap.SelectedIndex = selectedIndex;
            this.cboBaiTap_SelectedIndexChanged(null, null);
        }
        private void RefreshTopsList(CTop pTop)
        {
            int index = this.m_Tops.IndexOf(pTop);
            this.PopulateTopGridView();
            this.grdTops.Rows[index].Selected = true;
        }
        private void RefreshBaiTaps()
        {
            this.cboBaiTap.DataSource = null;
            this.cboBaiTap.DataSource = this.m_BaiTaps;
        }
        private void PopulateTops(int pBaiTapID)
        {
            this.m_SeleTop = null;
            this.m_Tops = CTops.GetList(pBaiTapID);
            foreach (CTop current in this.m_Tops)
            {
                List<PathNode> pathDetails = CTops.GetPathDetails(current.TopID);
                current.Path = pathDetails;
            }

            this.PopulateTopGridView();
            foreach (CTop current2 in this.m_Tops)
            {
                current2.TinhYToLuonVong(this.AxMap1);
            }

        }
        public void PopulateBaiTapRadas(int pBaiTapID)
        {
            this.m_BaiTapRadas = CBaiTapRadas.GetList(pBaiTapID);
            this.PopulateRadaGridView();
        }
        public void PopulateBaiTapRadas(int pBaiTapID, int pRadaID)
        {
            this.m_BaiTapRadas = CBaiTapRadas.GetList(pBaiTapID);
            this.PopulateRadaGridView();
            this.m_SeleRada = this.GetRada(pRadaID);
            int num = this.m_BaiTapRadas.IndexOf(this.m_SeleRada);
            this.grdRadas.Rows[num].Selected = true;
            this.grdRadas.FirstDisplayedScrollingRowIndex = num;
        }
        public void RefreshRadaList(CRada pRada)
        {
            int index = this.m_BaiTapRadas.IndexOf(pRada);
            this.PopulateRadaGridView();
            this.grdRadas.Rows[index].Selected = true;
            pRada == null;
        }
        private void PopulateAllKhuats(int pBaiTapID)
        {
            this.m_AllKhuats = CBaiTapKhuats.GetList(pBaiTapID);
            foreach (CKhuat current in this.m_AllKhuats)
            {
                current.KhuatPts = CBaiTapKhuats.GetKhuatPts(pBaiTapID, current.KhuatID);
            }

        }
        private void PopulateKhuats(int pBaiTapID, int pRadaID)
        {
            this.m_Khuats = CBaiTapKhuats.GetList(pBaiTapID, pRadaID);
            foreach (CKhuat current in this.m_Khuats)
            {
                current.KhuatPts = CBaiTapKhuats.GetKhuatPts(pBaiTapID, current.KhuatID);
            }

            this.lstKhuat.DataSource = this.m_Khuats;
        }
        private void dlgBaiTapHinhThai_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveKyHieu();
            CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
            modHuanLuyen.fMain.PopulateBaiTaps(cBaiTap.BaiTapID);
            modHuanLuyen.fBaiTapHinhThai = null;
        }
        private void UpdatePage()
        {
            if (this.CurrPage != null && this.myBando.drawingSymbols != null)
            {
                string pKHstr = this.myBando.drawingSymbols.KH2String(this.AxMap1);
                this.CurrPage.Update(pKHstr);
            }
        }
        private void SaveUpdate()
        {
            this.UpdatePage();
            try
            {
                CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                string strKyHieu = "";
                try
                {
                    strKyHieu = this.myPages.Pages2String(this.AxMap1);
                }
                catch (Exception expr_31)
                {
                    throw expr_31;
                }
                if (CBaiTaps.UpdateKyHieu(cBaiTap.BaiTapID, strKyHieu) < 0L)
                {
                    MessageBox.Show("UpdateKyHieu Sai. ID = " + cBaiTap.BaiTapID.ToString(), "Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception expr_6E)
            {
                throw expr_6E;
            }
        }
        private void SaveKyHieu()
        {
            if (this.myDirty)
            {
                this.myDirty = false;
                if (MessageBox.Show(this, "Ký hiệu Có thay đổi, Có lưu không?", "Nhắc nhỡ:", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this.myPages.Count == 0)
                    {
                        this.CurrPage = this.myPages.AddNewPage("");
                    }
                    this.SaveUpdate();
                }
            }
        }
        public DialogResult ShowDialog(Form parent, CSymbols pDrawingSymbols)
        {
            return this.ShowDialog(parent);
        }
        private void dlgBaiTapHinhThai_Load(object sender, EventArgs e)
        {
            modHuanLuyen.fBaiTapHinhThai = this;
            this.WindowState = FormWindowState.Maximized;
            if (this.InitMap())
            {
                this.LoadNodePatterns();
                this.m_TieuDo99 = new CTieuDo99();
                this.m_TieuDo99.PopulateOLon(modHuanLuyen.myOLon99File);
                this.m_TieuDo99.Populate();
                this.m_TieuDo55 = new CTieuDo55(modHuanLuyen.TieuDo55CX, modHuanLuyen.TieuDo55CY);
                this.m_TieuDo55.PopulateOPhu(modHuanLuyen.myOPhu55File);
                this.m_TieuDo55.Populate();
                this.myTblName = "tblAirport";
                this.PopulateAirports();
                this.myTblName = "tblDiaTieu";
                this.PopulateAirports();
                this.myTblName = "tblTramQS";
                this.PopulateAirports();
                this.SetUpGridView(this.grdTops);
                this.SetUpGridView(this.grdRadas);
                CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fMain.cboBaiTap.SelectedItem;
                this.PopulateBaiTaps(cBaiTap.BaiTapID);
                this.cboBaiTap.Enabled = false;
                this.myBando = new CBdTC(this.AxMap1, this, this.PanelRight, this.ToolStrip1);
                this.PopulateBdTC(cBaiTap.BaiTapID);
                this.AxMap1.CreateCustomTool(4, ToolTypeConstants.miToolTypePoint, CursorConstants.miArrowQuestionCursor);
                this.bLoaded = true;
                this.rbtn99.Checked = true;
                this.rbtn99.CheckedChanged += new EventHandler(this.rbtn55_CheckedChanged);
            }
            else
            {
                MessageBox.Show("Khong InitMap duoc", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
        }
        private void PopulateBdTC(int pBaiTapID)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string kyHieu = CBaiTaps.GetKyHieu(pBaiTapID);
                this.myPages.Clear();
                if (this.myPages.LoadFromStr(kyHieu))
                {
                    this.RefreshBdTC(0);
                    if (modBanDo.BDTyLeBanDo == 0)
                    {
                        modBanDo.BDTyLeBanDo = modBanDo.GetTyLeBD(this.AxMap1, this.AxMap1.Zoom);
                        modBanDo.BDKinhDo = this.AxMap1.CenterX;
                        modBanDo.BDViDo = this.AxMap1.CenterY;
                        this.myDirty = true;
                    }
                }
            }
            catch (Exception expr_7E)
            {
                throw expr_7E;
                Exception ex = expr_7E;
                //MessageBox.Show(e.Message, "PopulateForm Sai", MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }
        private void PopulateSelePage()
        {
            //try
            //{
            //    if (this.myPages != null)
            //    {
            //        if (this.myPages.Count > 0)
            //        {
            //            this.CurrPage = this.myPages[0];
            //            if (this.CurrPage != null)
            //            {
            //                this.myBando.KHsFromString(this.CurrPage.Symbols);
            //            }
            //            else
            //            {
            //                this.myBando.KHsFromString("");
            //            }
            //        }
            //        else
            //        {
            //            this.myBando.KHsFromString("");
            //            this.CurrPage = this.myPages.AddNewPage("");
            //            modBanDo.BDTyLeBanDo = modBanDo.GetTyLeBD(this.AxMap1, this.AxMap1.Zoom);
            //        }
            //    }
            //    else
            //    {
            //        this.myBando.KHsFromString("");
            //        this.CurrPage = this.myPages.AddNewPage("");
            //        modBanDo.BDTyLeBanDo = modBanDo.GetTyLeBD(this.AxMap1, this.AxMap1.Zoom);
            //    }
            //    this.myBando.HideDrawTools();
            //    double zoomLevel = modBanDo.GetZoomLevel(this.AxMap1, modBanDo.BDTyLeBanDo);
            //    this.AxMap1.ZoomTo(zoomLevel, modBanDo.BDKinhDo, modBanDo.BDViDo);
            //    this.AxMap1.Refresh();
            //}
            //catch (Exception expr_130)
            //{
            //    throw expr_130;
            //    Exception ex = expr_130;
            //    //MessageBox.Show(e.Message, "PopulateSelePage Error", MessageBoxIcon.Information);
            //}
        }
        private void RefreshBdTC(int iPage)
        {
            try
            {
                this.PopulateSelePage();
            }
            catch (Exception expr_08)
            {
                throw expr_08;
            }
        }
        private void NewPage()
        {
            if (this.myPages != null)
            {
                if (this.myPages.Count == 0)
                {
                    this.UpdateBdTCdef();
                }
                this.UpdatePage();
                this.CurrPage = this.myPages.AddNewPage("");
                this.myDirty = true;
                this.RefreshBdTC(checked(this.myPages.Count - 1));
            }
        }
        private void UpdateBdTCdef()
        {
            //if (new dlgDefBdTC
            //{
            //    myMap = this.AxMap1
            //}.ShowDialog(this) == DialogResult.OK)
            //{
            //    this.UnseleKH();
            //    this.myDirty = true;
            //}
        }
        private void AxMap1_DrawUserLayer(object sender, CMapXEvents_DrawUserLayerEvent e)
        {
            if (this.chkHienKyHieu.Checked)
            {
                this.myBando.m_Map_DrawUserLayer(sender, e);
            }
            Layer layer = (Layer)e.layer;
            IntPtr hdc = new IntPtr(e.hOutputDC);
            Graphics g = Graphics.FromHdc(hdc);
            Pen pen = new Pen(Color.Black);
            Pen pen2 = new Pen(Color.Blue, 1f);
            Pen pPen = new Pen(Color.Black);
            if (layer == this.lyrAnimation)
            {
                if (this.m_EditingTop != null)
                {
                    this.m_EditingTop.Draw(this.AxMap1, g, pen2);
                    this.m_EditingTop.DrawNodes(this.AxMap1, g, this.iEditNode);
                    this.m_EditingTop.DrawDuongBay(this.AxMap1, g, pen2, true);
                }
                if (this.m_MovingTop != null && this.myMapTool == dlgBaiTapHinhThai.MapTools.DauTopPos)
                {
                    this.m_MovingTop.DrawNameNode(this.AxMap1, g);
                }
                if (this.m_NewTop != null)
                {
                    this.m_NewTop.Draw(this.AxMap1, g, pen2);
                    this.m_NewTop.DrawNodes(this.AxMap1, g, this.iEditNode);
                    this.m_NewTop.DrawDuongBay(this.AxMap1, g, pen2, true);
                }
                if (this.m_NewRada != null)
                {
                    this.m_NewRada.Draw(this.AxMap1, g, pen);
                }
            }
            else if (layer == this.lyrCacKyHieu)
            {
                if (this.rbtn99.Checked)
                {
                    this.m_TieuDo99.draw(this.AxMap1, g);
                }
                else if (this.rbtn55.Checked)
                {
                    this.m_TieuDo55.draw(this.AxMap1, g);
                }
                foreach (CAirport current in this.m_DrawingTramQSs)
                {
                    current.Draw(this.AxMap1, g);
                }

                foreach (CAirport current2 in this.m_DrawingDiaTieus)
                {
                    current2.Draw(this.AxMap1, g);
                }

                foreach (CAirport current3 in this.m_DrawingAirports)
                {
                    current3.Draw(this.AxMap1, g);
                }

                if (this.chkRadaHien.Checked)
                {
                    foreach (CRada current4 in this.m_BaiTapRadas)
                    {
                        if (current4.visible)
                        {
                            switch (current4.LoaiRadaID)
                            {
                                case 2:
                                    pen.Color = modHuanLuyen.defaRadaHLPenC;
                                    pen.Width = (float)modHuanLuyen.defaRadaHLPenW;
                                    break;
                                case 3:
                                    pen.Color = modHuanLuyen.defaRadaDDPenC;
                                    pen.Width = (float)modHuanLuyen.defaRadaDDPenW;
                                    break;
                            }
                            current4.Draw(this.AxMap1, g, pen);
                        }
                    }

                    if (this.m_SeleRada != null)
                    {
                        switch (this.m_SeleRada.LoaiRadaID)
                        {
                            case 2:
                                pen.Color = modHuanLuyen.defaRadaHLPenC;
                                pen.Width = (float)(modHuanLuyen.defaRadaHLPenW + 1);
                                break;
                            case 3:
                                pen.Color = modHuanLuyen.defaRadaDDPenC;
                                pen.Width = (float)(modHuanLuyen.defaRadaDDPenW + 1);
                                break;
                        }
                        this.m_SeleRada.Draw(this.AxMap1, g, pen);
                    }
                    foreach (CKhuat current5 in this.m_AllKhuats)
                    {
                        current5.Draw(this.AxMap1, g, Color.FromArgb(75, Color.Gray));
                    }

                    if (this.m_SeleKhuat != null)
                    {
                        this.m_SeleKhuat.DrawSele(this.AxMap1, g, Color.Black);
                    }
                }
                if (this.m_Tops.Count > 0)
                {
                    foreach (CTop current6 in this.m_Tops)
                    {
                        if (current6.visible)
                        {
                            switch (current6.LoaiTopID)
                            {
                                case 1:
                                    pen2.Color = modHuanLuyen.defaTopDichColor;
                                    break;
                                case 2:
                                    pen2.Color = modHuanLuyen.defaTopTaColor;
                                    break;
                                case 3:
                                    pen2.Color = modHuanLuyen.defaTopQuocTeColor;
                                    break;
                                case 4:
                                    pen2.Color = modHuanLuyen.defaTopQuaCanhColor;
                                    break;
                            }
                            pen2.Width = (float)modHuanLuyen.defaPathWidth;
                            current6.DrawDuongBay(this.AxMap1, g, pen2, false);
                        }
                    }

                    if (this.m_SeleTop != null)
                    {
                        switch (this.m_SeleTop.LoaiTopID)
                        {
                            case 1:
                                pen2.Color = modHuanLuyen.defaTopDichColor;
                                break;
                            case 2:
                                pen2.Color = modHuanLuyen.defaTopTaColor;
                                break;
                            case 3:
                                pen2.Color = modHuanLuyen.defaTopQuocTeColor;
                                break;
                            case 4:
                                pen2.Color = modHuanLuyen.defaTopQuaCanhColor;
                                break;
                        }
                        pen2.Width = (float)(modHuanLuyen.defaPathWidth + 1);
                        this.m_SeleTop.DrawDuongBay(this.AxMap1, g, pen2, false);
                        this.m_SeleTop.DrawPhutNodes(this.AxMap1, g, pPen);
                    }
                }
                if (modHuanLuyen.fBaiTapViewer != null)
                {
                    foreach (CFlight cFlight in ((IEnumerable)modHuanLuyen.fBaiTapViewer.Flights))
                    {
                        cFlight.DrawMB(this.AxMap1, g);
                    }
                    return;

                }
                if (modHuanLuyen.fBaiTapViewer2 != null)
                {
                    foreach (CFlight cFlight2 in ((IEnumerable)modHuanLuyen.fBaiTapViewer2.Flights))
                    {
                        cFlight2.DrawMB(this.AxMap1, g);
                    }

                }
            }
        }
        private void UnseleKH()
        {
            this.myMapTool = dlgBaiTapHinhThai.MapTools.None;
            this.ToolStripStatusLabel3.Text = "";
        }
        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.SelectorToolStripButton)
            {
                this.AxMap1.CurrentTool = ToolConstants.miArrowTool;
            }
            else if (e.ClickedItem == this.PanToolStripButton)
            {
                this.AxMap1.CurrentTool = ToolConstants.miPanTool;
                this.UnseleKH();
            }
            else if (e.ClickedItem == this.ZoomInToolStripButton)
            {
                this.AxMap1.CurrentTool = ToolConstants.miZoomInTool;
                this.UnseleKH();
            }
            else if (e.ClickedItem == this.ZoomOutToolStripButton)
            {
                this.AxMap1.CurrentTool = ToolConstants.miZoomOutTool;
                this.UnseleKH();
            }
            else if (e.ClickedItem == this.RullerToolStripButton)
            {
                this.myMapTool = dlgBaiTapHinhThai.MapTools.DangDoKC;
                this.myBanDoNen.OnDoKhoangCach();
                this.UnseleKH();
            }
            else if (e.ClickedItem == this.BdTCDefToolStripButton)
            {
                this.UpdateBdTCdef();
            }
            else
            {
                this.myBando.m_ToolStrip_ItemClicked(sender, e);
            }
        }
        public CTop GetTop(int lTop_ID)
        {
            dlgBaiTapHinhThai.cantimTop_ID = lTop_ID;
            return this.m_Tops.Find(new Predicate<CTop>(dlgBaiTapHinhThai.TopIDequal));
        }
        private static bool TopIDequal(CTop pTop)
        {
            return pTop.TopID == dlgBaiTapHinhThai.cantimTop_ID;
        }
        public CRada GetRada(int lRada_ID)
        {
            dlgBaiTapHinhThai.cantimRada_ID = lRada_ID;
            return this.m_BaiTapRadas.Find(new Predicate<CRada>(dlgBaiTapHinhThai.RadaIDequal));
        }
        private static bool RadaIDequal(CRada pRada)
        {
            return pRada.RadaID == dlgBaiTapHinhThai.cantimRada_ID;
        }
        public CKhuat GetKhuat(int lKhuat_ID)
        {
            dlgBaiTapHinhThai.cantimKhuat_ID = lKhuat_ID;
            return this.m_Khuats.Find(new Predicate<CKhuat>(dlgBaiTapHinhThai.KhuatIDequal));
        }
        private static bool KhuatIDequal(CKhuat pKhuat)
        {
            return pKhuat.KhuatID == dlgBaiTapHinhThai.cantimKhuat_ID;
        }
        private void AxMap1_KeyUpEvent(object sender, CMapXEvents_KeyUpEvent e)
        {
            this.myBando.m_Map_KeyUpEvent(sender, e);
        }
        private void AxMap1_MouseDownEvent(object sender, CMapXEvents_MouseDownEvent e)
        {
            this.myBanDoNen.m_Map_MouseDownEvent(sender, e);
            if (this.CNToolStripButton.Checked)
            {
                this.myBando.m_Map_MouseDownEvent(sender, e);
            }
            else
            {
                switch (this.myMapTool)
                {
                    case dlgBaiTapHinhThai.MapTools.None:
                        if (this.AxMap1.CurrentTool == ToolConstants.miArrowTool)
                        {
                            PointF pt = new PointF(e.x, e.y);
                            this.m_SeleKhuat = CKhuats.FindAtPoint(this.AxMap1, pt, this.m_AllKhuats);
                            if (this.m_SeleKhuat != null)
                            {
                                this.m_SeleTop = null;
                                this.m_SeleRada = this.GetRada(this.m_SeleKhuat.RadaID);
                                if (this.m_SeleRada != null)
                                {
                                    int num = this.m_BaiTapRadas.IndexOf(this.m_SeleRada);
                                    this.grdRadas.Rows[num].Selected = true;
                                    this.grdRadas.FirstDisplayedScrollingRowIndex = num;
                                    CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                                    this.PopulateKhuats(cBaiTap.BaiTapID, this.m_SeleRada.RadaID);
                                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                                }
                                this.lyrCacKyHieu.Invalidate(Missing.Value);
                                if (e.button == 2)
                                {
                                    this.m_SeleKhuat2 = this.m_SeleKhuat;
                                    System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                    this.KhuatContextMenuStrip.Show(this.PanelRight, position);
                                }
                                CKhuat khuat = this.GetKhuat(this.m_SeleKhuat.KhuatID);
                                this.lstKhuat.SelectedIndex = this.m_Khuats.IndexOf(khuat);
                            }
                            else
                            {
                                pt = new PointF(e.x, e.y);
                                this.m_SeleRada = CRadas.FindAtPoint(this.AxMap1, pt, this.m_BaiTapRadas);
                                if (this.m_SeleRada != null)
                                {
                                    this.m_SeleTop = null;
                                    int num2 = this.m_BaiTapRadas.IndexOf(this.m_SeleRada);
                                    this.grdRadas.Rows[num2].Selected = true;
                                    this.grdRadas.FirstDisplayedScrollingRowIndex = num2;
                                    CBaiTap cBaiTap2 = (CBaiTap)this.cboBaiTap.SelectedItem;
                                    this.PopulateKhuats(cBaiTap2.BaiTapID, this.m_SeleRada.RadaID);
                                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                                    if (e.button == 2)
                                    {
                                        System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                        this.RadaContextMenuStrip.Show(this.PanelRight, position);
                                    }
                                }
                                else
                                {
                                    pt = new PointF(e.x, e.y);
                                    this.m_SeleTop = CTops.FindAtPoint(this.AxMap1, pt, this.m_Tops);
                                    if (modHuanLuyen.fBaiTapViewer != null)
                                    {
                                        if (this.m_SeleTop != null)
                                        {
                                            this.m_SeleRada = null;
                                            this.m_SeleKhuat = null;
                                            int num3 = this.m_Tops.IndexOf(this.m_SeleTop);
                                            modHuanLuyen.fBaiTapViewer.DataGridView1.Rows[num3].Selected = true;
                                            modHuanLuyen.fBaiTapViewer.DataGridView1.FirstDisplayedScrollingRowIndex = num3;
                                            this.lyrCacKyHieu.Invalidate(Missing.Value);
                                        }
                                    }
                                    else if (modHuanLuyen.fBaiTapViewer2 != null)
                                    {
                                        if (this.m_SeleTop != null)
                                        {
                                            this.m_SeleRada = null;
                                            this.m_SeleKhuat = null;
                                            int num4 = this.m_Tops.IndexOf(this.m_SeleTop);
                                            modHuanLuyen.fBaiTapViewer2.DataGridView1.Rows[num4].Selected = true;
                                            modHuanLuyen.fBaiTapViewer2.DataGridView1.FirstDisplayedScrollingRowIndex = num4;
                                            this.lyrCacKyHieu.Invalidate(Missing.Value);
                                        }
                                    }
                                    else if (this.m_SeleTop != null)
                                    {
                                        this.m_SeleRada = null;
                                        this.m_SeleKhuat = null;
                                        int num5 = this.m_Tops.IndexOf(this.m_SeleTop);
                                        this.grdTops.Rows[num5].Selected = true;
                                        this.grdTops.FirstDisplayedScrollingRowIndex = num5;
                                        this.lyrCacKyHieu.Invalidate(Missing.Value);
                                        if (e.button == 2)
                                        {
                                            System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                            this.TopContextMenuStrip.Show(this.PanelRight, position);
                                        }
                                    }
                                    else
                                    {
                                        pt = new PointF(e.x, e.y);
                                        this.m_SelectedAirport = CAirports.FindAtPoint(this.AxMap1, pt, this.m_DrawingAirports);
                                        if (this.m_SelectedAirport != null)
                                        {
                                            this.myTblName = "tblAirport";
                                            if (e.button == 2)
                                            {
                                                System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                                this.AirportContextMenuStrip.Show(this.PanelRight, position);
                                            }
                                        }
                                        else if (modHuanLuyen.fTopEdit == null)
                                        {
                                            this.m_SeleRada = null;
                                            this.m_SeleKhuat = null;
                                            this.m_SeleTop = null;
                                            this.lyrCacKyHieu.Invalidate(Missing.Value);
                                            if (e.button == 2)
                                            {
                                                this.myPt.X = (int)Math.Round((double)e.x);
                                                this.myPt.Y = (int)Math.Round((double)e.y);
                                                this.NewContextMenuStrip.Show(this.PanelRight, this.myPt);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case dlgBaiTapHinhThai.MapTools.NodesEdit:
                        {
                            System.Drawing.Point point = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                            if (modHuanLuyen.fTopNodeEdit == null)
                            {
                                PointF pt = new PointF(e.x, e.y);
                                this.iEditNode = this.m_EditingTop.FindNodeAtPoint(this.AxMap1, pt);
                                if (this.iEditNode > -1)
                                {
                                    if (this.iEditNode > 0 & this.iEditNode < this.m_EditingTop.Path.Count + 1)
                                    {
                                        modHuanLuyen.fTopEdit.DataGridView1.Rows[this.iEditNode - 1].Selected = true;
                                    }
                                    else
                                    {
                                        modHuanLuyen.fTopEdit.DataGridView1.ClearSelection();
                                    }
                                    if (e.button == 1)
                                    {
                                        if (this.iEditNode > 0 & this.iEditNode < this.m_EditingTop.Path.Count + 1)
                                        {
                                            this.NodeDragging = true;
                                            this.myfromPt = new PointF((float)point.X, (float)point.Y);
                                            this.mytoPt = new PointF((float)point.X, (float)point.Y);
                                        }
                                    }
                                    else
                                    {
                                        System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                        this.NodeContextMenuStrip.Show(this.PanelRight, position);
                                    }
                                }
                            }
                            else if (e.button == 1)
                            {
                                PointF pt = new PointF(e.x, e.y);
                                int num6 = this.m_EditingTop.FindNodeAtPoint(this.AxMap1, pt);
                                if (num6 == this.iEditNode)
                                {
                                    this.NodeDragging = true;
                                    this.myfromPt = new PointF((float)point.X, (float)point.Y);
                                    this.mytoPt = new PointF((float)point.X, (float)point.Y);
                                }
                            }
                            break;
                        }
                    case dlgBaiTapHinhThai.MapTools.DauTopPos:
                        if (e.button == 1)
                        {
                            PointF pt = new PointF(e.x, e.y);
                            if (this.m_MovingTop.FindNameNodeAtPoint(this.AxMap1, pt))
                            {
                                this.NodeDragging = true;
                                this.myfromPt = new PointF(e.x, e.y);
                                this.mytoPt = new PointF(e.x, e.y);
                            }
                        }
                        break;
                }
            }
        }
        private void AxMap1_MouseMoveEvent(object sender, CMapXEvents_MouseMoveEvent e)
        {
            if (this.bLoaded)
            {
                double pPosX = 0;
                double pPosY = 0;
                this.AxMap1.ConvertCoord(ref e.x, ref e.y, ref pPosX, ref pPosY, ConversionConstants.miScreenToMap);
                string text;
                if (this.rbtn55.Checked)
                {
                    text = this.m_TieuDo55.getToaDo(this.AxMap1, pPosX, pPosY);
                    text = Convert.ToString(text.Length > 0 ? "Tọa độ 5x5 = " + text : "Ngoài Tiêu đồ 5x5");
                }
                else
                {
                    text = this.m_TieuDo99.getToaDo(pPosX, pPosY);
                    text = Convert.ToString(text.Length > 0 ? "Tọa độ 9x9 = " + text : "Ngoài Tiêu đồ 9x9");
                }
                struPhuongVi phuongVi = modHuanLuyen.GetPhuongVi(modHuanLuyen.fMain.AxMap1, modHuanLuyen.GocPvClCX, modHuanLuyen.GocPvClCY, pPosX, pPosY);
                text = string.Concat(new string[]
				{
					text,
					"   Ph.Vị-CựLy = ",
					phuongVi.PhuongVi.ToString("0.##"),
					"-",
					phuongVi.CuLy.ToString("0.##")
				});
                this.ToolStripStatusLabel2.Text = text;
            }
            this.myBando.ShowTooltip(e);
            this.myBanDoNen.m_Map_MouseMoveEvent(sender, e);
            if (this.CNToolStripButton.Checked)
            {
                this.myBando.m_Map_MouseMoveEvent(sender, e);
            }
            else if (this.myMapTool == dlgBaiTapHinhThai.MapTools.DauTopPos)
            {
                this.mytoPt = new PointF(e.x, e.y);
                if (this.NodeDragging)
                {
                    this.m_MovingTop.MoveNameNodeTo(this.AxMap1, this.mytoPt);
                    this.lyrAnimation.Invalidate(Missing.Value);
                }
            }
        }
        private void AxMap1_MouseUpEvent(object sender, CMapXEvents_MouseUpEvent e)
        {
            if (this.CNToolStripButton.Checked)
            {
                this.myBando.m_Map_MouseUpEvent(sender, e);
            }
            else if (e.button == 1 && this.NodeDragging)
            {
                if (this.myMapTool == dlgBaiTapHinhThai.MapTools.DauTopPos)
                {
                    CTops.UpdateDauTopPos(this.m_MovingTop);
                }
                this.NodeDragging = false;
                this.myMapTool = dlgBaiTapHinhThai.MapTools.None;
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void cboBaiTap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboBaiTap.SelectedItem != null)
            {
                this.lstKhuat.DataSource = null;
                this.m_SeleBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                CBaiTap seleBaiTap = this.m_SeleBaiTap;
                this.txtBaiTap.Text = seleBaiTap.BaiTap;
                this.txtGioBatDau.Text = seleBaiTap.GioBatDau.ToString();
                this.txtPhutBatDau.Text = seleBaiTap.PhutBatDau.ToString();
                this.PopulateTops(this.m_SeleBaiTap.BaiTapID);
                this.PopulateBaiTapRadas(this.m_SeleBaiTap.BaiTapID);
                this.PopulateAllKhuats(this.m_SeleBaiTap.BaiTapID);
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void lstKhuat_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstKhuat.SelectedItem != null)
            {
                this.m_SeleKhuat = (CKhuat)this.lstKhuat.SelectedItem;
                if (!this.AxMap1.IsPointVisible(this.m_SeleKhuat.KhuatPts[0].PosX, this.m_SeleKhuat.KhuatPts[0].PosY))
                {
                    this.AxMap1.ZoomTo(this.AxMap1.Zoom, this.m_SeleKhuat.KhuatPts[0].PosX, this.m_SeleKhuat.KhuatPts[0].PosY);
                }
                else
                {
                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void KhuatReDrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstKhuat.SelectedItem != null && MessageBox.Show("Vẽ lại vùng Khuất này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.grdRadas.Enabled = false;
                this.lstKhuat.Enabled = false;
                this.myMapTool = dlgBaiTapHinhThai.MapTools.DangVeKhuat;
                this.ToolStripStatusLabel3.Text = "Vẽ lại vùng khuất: Click để chọn đỉnh của đa giác, RightClick để kết thúc.";
                this.myBanDoNen.OnVeLaiPolygon();
            }
        }
        private void myBanDoNen_VeLaiPolygonXong(List<MapPoint> pMapPts)
        {
            this.myMapTool = dlgBaiTapHinhThai.MapTools.None;
            this.ToolStripStatusLabel3.Text = "";
            if (pMapPts.Count > 1)
            {
                if (this.m_SeleKhuat2 != null)
                {
                    int num = this.m_AllKhuats.IndexOf(this.m_SeleKhuat2);
                    if (num > -1)
                    {
                        CKhuat cKhuat = this.m_AllKhuats[num];
                        List<CKhuatPt> list = new List<CKhuatPt>();
                        foreach (MapPoint current in pMapPts)
                        {
                            list.Add(new CKhuatPt
                            {
                                PosX = current.x,
                                PosY = current.y
                            });
                        }

                        CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                        CBaiTapKhuats.DeletePts(cBaiTap.BaiTapID, cKhuat.KhuatID);
                        CBaiTapKhuats.InsertPts(cBaiTap.BaiTapID, cKhuat.KhuatID, list);
                        cKhuat.KhuatPts = list;
                        this.m_SeleKhuat = this.m_SeleKhuat2;
                        this.m_SeleKhuat2 = null;
                    }
                }
                this.lstKhuat.Enabled = true;
                this.lstKhuat.DoubleClick += new EventHandler(this.lstKhuat_DoubleClick);
                this.grdRadas.Enabled = true;
                this.lyrCacKyHieu.Invalidate(Missing.Value);
                SendKeys.Send("{ESC}");
            }
        }
        private void KhuatDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleKhuat2 != null)
            {
                int num = this.m_AllKhuats.IndexOf(this.m_SeleKhuat2);
                if (num > -1)
                {
                    CKhuat cKhuat = this.m_AllKhuats[num];
                    CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                    CBaiTapKhuats.DeletePts(cBaiTap.BaiTapID, cKhuat.KhuatID);
                    CBaiTapKhuats.Delete(cBaiTap.BaiTapID, cKhuat.KhuatID);
                    this.m_AllKhuats.Remove(this.m_SeleKhuat2);
                    this.m_SeleKhuat2 = null;
                    this.m_SeleKhuat = null;
                    CRada seleRada = this.m_SeleRada;
                    this.PopulateKhuats(cBaiTap.BaiTapID, seleRada.RadaID);
                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void RadaNewKhuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleRada != null && MessageBox.Show("Vẽ vùng Khuất mới cho Rada " + this.m_SeleRada.Ten + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.grdRadas.Enabled = false;
                this.myMapTool = dlgBaiTapHinhThai.MapTools.DangVeKhuat;
                this.ToolStripStatusLabel3.Text = "Vẽ vùng Khuất = đa giác: Click để chọn đỉnh, RightClick để kết thúc.";
                this.myBanDoNen.OnVePolygon();
            }
        }
        private int GetNewKhuatID(int pBaiTapID)
        {
            int num = 0;
            foreach (CKhuat current in this.m_AllKhuats)
            {
                if (current.KhuatID > num)
                {
                    num = current.KhuatID;
                }
            }

            num++;
            return num;
        }
        private void myBanDoNen_VeLineXong(List<MapPoint> pMapPts)
        {
            this.myMapTool = dlgBaiTapHinhThai.MapTools.None;
            this.ToolStripStatusLabel3.Text = "";
            if (pMapPts.Count > 1)
            {
                if (MessageBox.Show("Tịnh tiến đường bay?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    double pDx = pMapPts[checked(pMapPts.Count - 1)].x - pMapPts[0].x;
                    double pDy = pMapPts[checked(pMapPts.Count - 1)].y - pMapPts[0].y;
                    this.m_SeleTop.TinhTien(pDx, pDy);
                    CTops.UpdateDauCuoi(this.m_SeleTop);
                    CTops.DeleteNodes((long)this.m_SeleTop.TopID);
                    int num = 0;
                    foreach (PathNode current in this.m_SeleTop.Path)
                    {
                        num++;
                        current.Stt = num;
                        CTops.InsertNode(this.m_SeleTop.TopID, current);
                    }

                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
                SendKeys.Send("{ESC}");
            }
        }
        private void myBanDoNen_VePolygonXong(List<MapPoint> pMapPts)
        {
            this.myMapTool = dlgBaiTapHinhThai.MapTools.None;
            this.ToolStripStatusLabel3.Text = "";
            if (pMapPts.Count > 1)
            {
                CRada seleRada = this.m_SeleRada;
                if (seleRada != null)
                {
                    CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                    CKhuat cKhuat = new CKhuat();
                    cKhuat.RadaID = seleRada.RadaID;
                    int newKhuatID = this.GetNewKhuatID(cBaiTap.BaiTapID);
                    cKhuat.KhuatID = newKhuatID;
                    CBaiTapKhuats.Insert(cBaiTap.BaiTapID, cKhuat);
                    List<CKhuatPt> list = new List<CKhuatPt>();
                    foreach (MapPoint current in pMapPts)
                    {
                        list.Add(new CKhuatPt
                        {
                            PosX = current.x,
                            PosY = current.y
                        });
                    }

                    CBaiTapKhuats.InsertPts(cBaiTap.BaiTapID, newKhuatID, list);
                    cKhuat.KhuatPts = list;
                    this.m_AllKhuats.Add(cKhuat);
                    this.PopulateKhuats(cBaiTap.BaiTapID, seleRada.RadaID);
                }
                this.grdRadas.Enabled = true;
                this.lyrCacKyHieu.Invalidate(Missing.Value);
                SendKeys.Send("{ESC}");
            }
        }
        private void btnBaiTapUpdate_Click(object sender, EventArgs e)
        {
            if (this.cboBaiTap.SelectedItem != null)
            {
                this.m_SeleBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                dlgBaiTap dlgBaiTap = new dlgBaiTap();
                CBaiTap seleBaiTap = this.m_SeleBaiTap;
                dlgBaiTap.txtBaiTap.Text = seleBaiTap.BaiTap;
                dlgBaiTap.nudGio.Value = new decimal(seleBaiTap.GioBatDau);
                dlgBaiTap.nudPhut.Value = new decimal(seleBaiTap.PhutBatDau);
                dlgBaiTap.dtpNgayTao.Value = DateTime.Now;
                try
                {
                    dlgBaiTap.dtpNgayTao.Value = seleBaiTap.NgayTao;
                }
                catch (Exception expr_A2)
                {
                    throw expr_A2;
                }
                if (dlgBaiTap.ShowDialog(this, this.m_SeleBaiTap) == DialogResult.OK)
                {
                    CBaiTap seleBaiTap2 = this.m_SeleBaiTap;
                    seleBaiTap2.BaiTap = dlgBaiTap.txtBaiTap.Text;
                    seleBaiTap2.GioBatDau = Convert.ToInt32(dlgBaiTap.nudGio.Value);
                    seleBaiTap2.PhutBatDau = Convert.ToInt32(dlgBaiTap.nudPhut.Value);
                    seleBaiTap2.NgayTao = dlgBaiTap.dtpNgayTao.Value;
                    CLoaiBaiTap cLoaiBaiTap = (CLoaiBaiTap)dlgBaiTap.cboLoaiBaiTap.SelectedItem;
                    seleBaiTap2.LoaiBaiTapID = cLoaiBaiTap.LoaiBaiTapID;
                    CBaiTaps.Update(this.m_SeleBaiTap);
                    CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fMain.cboBaiTap.SelectedItem;
                    this.PopulateBaiTaps(cBaiTap.BaiTapID);
                    this.m_dirty = true;
                }
                this.m_SeleBaiTap = null;
            }
        }
        private void btnXemTop_Click(object sender, EventArgs e)
        {
            if (this.m_Tops.Count > 0)
            {
                this.m_SeleTop = null;
                new dlgBaiTapViewer
                {
                    TopMost = true
                }.Show(this);
            }
        }
        private void TopUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleTop != null)
            {
                this.m_EditingTop = this.m_SeleTop;
                dlgTop dlgTop = new dlgTop();
                if (dlgTop.ShowDialog(this, this.m_EditingTop) == DialogResult.OK)
                {
                    this.RefreshTopsList(this.m_SeleTop);
                }
                this.m_EditingTop = null;
                this.m_dirty = true;
            }
        }
        private void KhongVucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.m_SelectedAirport == null;
        }
        private void KhongVucHienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedAirport != null)
            {
                this.m_SelectedAirport.KhongVucs = CKhongVucs.GetList(this.m_SelectedAirport.SB_ID);
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void KhongVucAnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedAirport != null)
            {
                this.m_SelectedAirport.KhongVucs.Clear();
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void HienPhuongViToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedAirport != null)
            {
                this.m_SelectedAirport.ShowPV = true;
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void AnPhuongViToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedAirport != null)
            {
                this.m_SelectedAirport.ShowPV = false;
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void rbtn55_CheckedChanged(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void RadaHienPVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleRada != null)
            {
                this.m_SeleRada.ShowPV = true;
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void RadaAnPVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleRada != null)
            {
                this.m_SeleRada.ShowPV = false;
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void btnQuanSatTop_Click(object sender, EventArgs e)
        {
            if (this.m_BaiTapRadas.Count > 0)
            {
                if (this.m_Tops.Count > 0)
                {
                    new dlgBaiTapViewer2
                    {
                        TopMost = true
                    }.Show(this, this.m_BaiTapRadas);
                }
                else
                {
                    MessageBox.Show("Khong co Top nao de quan sat.", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Khong co Rada de quan sat.", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void NewTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Vẽ tốp bay mới?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.myMapTool = dlgBaiTapHinhThai.MapTools.DangVeTuyen;
                this.ToolStripStatusLabel3.Text = "Vẽ tốp: vẽ đường gấp khúc = Click để chọn điểm bay, RightClick để kết thúc.";
                this.myBanDoNen.OnVePolyline(this.myPt);
            }
        }
        private void myBanDoNen_VePolylineXong(List<MapPoint> pMapPts)
        {
            this.myMapTool = dlgBaiTapHinhThai.MapTools.None;
            this.ToolStripStatusLabel3.Text = "";
            if (pMapPts.Count > 1)
            {
                dlgTopMoi2 dlgTopMoi = new dlgTopMoi2();
                MapPoint mapPoint = pMapPts[0];
                dlgTopMoi.txtPosFromX.Text = mapPoint.x.ToString("#.00000000");
                mapPoint = pMapPts[0];
                dlgTopMoi.txtPosFromY.Text = mapPoint.y.ToString("#.00000000");
                mapPoint = pMapPts[pMapPts.Count - 1];
                dlgTopMoi.txtPosToX.Text = mapPoint.x.ToString("#.00000000");
                mapPoint = pMapPts[pMapPts.Count - 1];
                dlgTopMoi.txtPosToY.Text = mapPoint.y.ToString("#.00000000");
                dlgTopMoi.TopMost = true;
                if (dlgTopMoi.ShowDialog(this, pMapPts) == DialogResult.OK)
                {
                    this.m_dirty = true;
                    this.RefreshTopsList(this.m_SeleTop);
                }
                SendKeys.Send("{ESC}");
            }
        }
        private void TopCapNhatDuongBayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleTop != null)
            {
                this.m_EditingTop = this.m_SeleTop;
                this.iEditNode = checked(this.m_EditingTop.Path.Count - 1);
                this.myMapTool = dlgBaiTapHinhThai.MapTools.NodesEdit;
                this.lyrCacKyHieu.Invalidate(Missing.Value);
                new dlgTopEdit
                {
                    TopMost = true
                }.Show(this);
            }
            else
            {
                MessageBox.Show("ko co SeleTop", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void TopDeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleTop != null && MessageBox.Show("Bỏ tốp bay này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int topID = this.m_SeleTop.TopID;
                CTops.Delete((long)topID);
                CTops.DeleteNodes((long)topID);
                CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                this.PopulateTops(cBaiTap.BaiTapID);
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void AxMap1_ToolUsed(object sender, CMapXEvents_ToolUsedEvent e)
        {
            if (e.toolNum == 4)
            {
                if (modHuanLuyen.fTopNodeEdit != null)
                {
                    PointF pt = default(PointF);
                    float num = pt.X;
                    float num2 = pt.Y;
                    this.AxMap1.ConvertCoord(ref num, ref num2, ref e.x1, ref e.y1, ConversionConstants.miMapToScreen);
                    pt.Y = num2;
                    pt.X = num;
                    CAirport cAirport = CAirports.FindAtPoint(this.AxMap1, pt, this.m_DrawingDiaTieus);
                    MapPoint mapPoint = default(MapPoint);
                    if (cAirport != null)
                    {
                        modHuanLuyen.fTopNodeEdit.txtSBTo_ID.Text = cAirport.SB_ID.ToString();
                        modHuanLuyen.fTopNodeEdit.txtName.Text = cAirport.Name;
                        mapPoint.x = cAirport.Pos.x;
                        mapPoint.y = cAirport.Pos.y;
                    }
                    else
                    {
                        modHuanLuyen.fTopNodeEdit.txtSBTo_ID.Text = "-1";
                        modHuanLuyen.fTopNodeEdit.txtName.Text = "";
                        mapPoint.x = e.x1;
                        mapPoint.y = e.y1;
                    }
                    if (modHuanLuyen.fTopNodeEdit.rbtnQuanhDiem.Checked)
                    {
                        modHuanLuyen.fTopNodeEdit.txtCX.Text = mapPoint.x.ToString("#.00000000");
                        modHuanLuyen.fTopNodeEdit.txtCY.Text = mapPoint.y.ToString("#.00000000");
                    }
                    else if (modHuanLuyen.fTopNodeEdit.rbtnHuongDiem.Checked)
                    {
                        modHuanLuyen.fTopNodeEdit.txtDpX.Text = mapPoint.x.ToString("#.00000000");
                        modHuanLuyen.fTopNodeEdit.txtDpY.Text = mapPoint.y.ToString("#.00000000");
                    }
                    else
                    {
                        modHuanLuyen.fTopNodeEdit.txtPosX.Text = mapPoint.x.ToString("#.00000000");
                        modHuanLuyen.fTopNodeEdit.txtPosY.Text = mapPoint.y.ToString("#.00000000");
                    }
                    this.AxMap1.CurrentTool = ToolConstants.miArrowTool;
                }
                else if (modHuanLuyen.fTopEdit != null)
                {
                    PointF pt2 = default(PointF);
                    float num2 = pt2.X;
                    float num = pt2.Y;
                    this.AxMap1.ConvertCoord(ref num2, ref num, ref e.x1, ref e.y1, ConversionConstants.miMapToScreen);
                    pt2.Y = num;
                    pt2.X = num2;
                    CAirport cAirport2 = CAirports.FindAtPoint(this.AxMap1, pt2, this.m_DrawingAirports);
                    if (cAirport2 == null)
                    {
                        CLoaiMB loaiMB = CLoaiMBs.GetLoaiMB(this.m_EditingTop.LoaiMB);
                        if (modHuanLuyen.fTopEdit.iChonBtn == 2)
                        {
                            this.EditingTop.PosTo.x = e.x1;
                            this.EditingTop.PosTo.y = e.y1;
                            modHuanLuyen.fTopEdit.txtPosToX.Text = e.x1.ToString();
                            modHuanLuyen.fTopEdit.txtPosToY.Text = e.y1.ToString();
                            if (loaiMB != null)
                            {
                                this.EditingTop.PosTo.h = loaiMB.Altitude;
                                this.EditingTop.SpeedTo = loaiMB.Speed;
                                modHuanLuyen.fTopEdit.txtPosToH.Text = loaiMB.Altitude.ToString();
                                modHuanLuyen.fTopEdit.txtSpeedTo.Text = loaiMB.Speed.ToString();
                            }
                        }
                        else
                        {
                            this.EditingTop.PosFrom.x = e.x1;
                            this.EditingTop.PosFrom.y = e.y1;
                            modHuanLuyen.fTopEdit.txtPosFromX.Text = e.x1.ToString();
                            modHuanLuyen.fTopEdit.txtPosFromY.Text = e.y1.ToString();
                            if (loaiMB != null)
                            {
                                this.EditingTop.PosFrom.h = loaiMB.Altitude;
                                this.EditingTop.SpeedFrom = loaiMB.Speed;
                                modHuanLuyen.fTopEdit.txtPosFromH.Text = loaiMB.Altitude.ToString();
                                modHuanLuyen.fTopEdit.txtSpeedFrom.Text = loaiMB.Speed.ToString();
                            }
                        }
                    }
                    else if (modHuanLuyen.fTopEdit.iChonBtn == 2)
                    {
                        this.EditingTop.PosTo.x = cAirport2.Pos.x;
                        this.EditingTop.PosTo.y = cAirport2.Pos.y;
                        modHuanLuyen.fTopEdit.txtPosToX.Text = cAirport2.Pos.x.ToString();
                        modHuanLuyen.fTopEdit.txtPosToY.Text = cAirport2.Pos.y.ToString();
                        this.EditingTop.PosTo.h = cAirport2.Pos.h;
                        this.EditingTop.SpeedTo = 0.0;
                        modHuanLuyen.fTopEdit.txtPosToH.Text = cAirport2.Pos.h.ToString();
                        modHuanLuyen.fTopEdit.txtSpeedTo.Text = 0.ToString();
                    }
                    else
                    {
                        this.EditingTop.PosFrom.x = cAirport2.Pos.x;
                        this.EditingTop.PosFrom.y = cAirport2.Pos.y;
                        this.EditingTop.PosFrom.h = cAirport2.Pos.h;
                        this.EditingTop.SpeedFrom = 0.0;
                        modHuanLuyen.fTopEdit.txtPosFromX.Text = cAirport2.Pos.x.ToString();
                        modHuanLuyen.fTopEdit.txtPosFromY.Text = cAirport2.Pos.y.ToString();
                        modHuanLuyen.fTopEdit.txtPosFromH.Text = cAirport2.Pos.h.ToString();
                        modHuanLuyen.fTopEdit.txtSpeedFrom.Text = 0.ToString();
                    }
                    modHuanLuyen.fTopEdit.onNodeChanged();
                    this.AxMap1.CurrentTool = ToolConstants.miArrowTool;
                }
                else if (modHuanLuyen.fBaiTapRada != null)
                {
                    PointF pt3 = default(PointF);
                    float num2 = pt3.X;
                    float num = pt3.Y;
                    this.AxMap1.ConvertCoord(ref num2, ref num, ref e.x1, ref e.y1, ConversionConstants.miMapToScreen);
                    pt3.Y = num;
                    pt3.X = num2;
                    if (this.NewRada.LoaiRadaID == 3)
                    {
                        CAirport cAirport3 = CAirports.FindAtPoint(this.AxMap1, pt3, this.m_DrawingAirports);
                        if (cAirport3 != null)
                        {
                            this.NewRada.PosX = cAirport3.Pos.x;
                            this.NewRada.PosY = cAirport3.Pos.y;
                        }
                        else
                        {
                            this.NewRada.PosX = e.x1;
                            this.NewRada.PosY = e.y1;
                        }
                    }
                    else
                    {
                        this.NewRada.PosX = e.x1;
                        this.NewRada.PosY = e.y1;
                    }
                    modHuanLuyen.fBaiTapRada.txtPosX.Text = this.NewRada.PosX.ToString();
                    modHuanLuyen.fBaiTapRada.txtPosY.Text = this.NewRada.PosY.ToString();
                    this.AxMap1.CurrentTool = ToolConstants.miArrowTool;
                }
                else if (modHuanLuyen.fGocPvCl != null)
                {
                    PointF pt4 = default(PointF);
                    float num2 = pt4.X;
                    float num = pt4.Y;
                    this.AxMap1.ConvertCoord(ref num2, ref num, ref e.x1, ref e.y1, ConversionConstants.miMapToScreen);
                    pt4.Y = num;
                    pt4.X = num2;
                    CAirport cAirport4 = CAirports.FindAtPoint(this.AxMap1, pt4, this.m_DrawingAirports);
                    if (cAirport4 != null)
                    {
                        modHuanLuyen.fGocPvCl.txtGocPvClCX.Text = cAirport4.Pos.x.ToString();
                        modHuanLuyen.fGocPvCl.txtGocPvClCY.Text = cAirport4.Pos.y.ToString();
                    }
                    else
                    {
                        modHuanLuyen.fGocPvCl.txtGocPvClCX.Text = e.x1.ToString();
                        modHuanLuyen.fGocPvCl.txtGocPvClCY.Text = e.y1.ToString();
                    }
                    this.AxMap1.CurrentTool = ToolConstants.miArrowTool;
                }
            }
        }
        private void NodeAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modHuanLuyen.fTopEdit.AddPathNode();
        }
        private void NodeDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modHuanLuyen.fTopEdit.DeleteNote();
        }
        private void btnDoiGocPvCl_Click(object sender, EventArgs e)
        {
            foreach (CRada current in this.m_BaiTapRadas)
            {
                if (current.LoaiRadaID == 3)
                {
                    modHuanLuyen.GocPvClCX = current.PosX;
                    modHuanLuyen.GocPvClCY = current.PosY;
                    break;
                }
            }

            if (MessageBox.Show("Lưu thay đổi gốc phương vị cự ly?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                modHuanLuyen.GocPvCl2File(modHuanLuyen.myGocPvClFile);
            }
        }
        private void RadaHienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRada seleRada = this.m_SeleRada;
            if (seleRada != null)
            {
                seleRada.visible = !seleRada.visible;
            }
        }
        private void SetUpGridView(DataGridView grd)
        {
            DataGridViewCellStyle columnHeadersDefaultCellStyle = grd.ColumnHeadersDefaultCellStyle;
            columnHeadersDefaultCellStyle.BackColor = Color.Navy;
            columnHeadersDefaultCellStyle.ForeColor = Color.White;
            columnHeadersDefaultCellStyle.Font = new Font(this.grdRadas.Font, FontStyle.Bold);
            grd.RowHeadersVisible = false;
            grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grd.MultiSelect = false;
            grd.AllowUserToAddRows = false;
            grd.AllowUserToDeleteRows = false;
        }
        private void PopulateTopGridView()
        {
            this.grdTops.DataSource = null;
            DataTable dataTable = this.GetdtTops();
            this.dvTops = dataTable.DefaultView;
            this.grdTops.DataSource = this.dvTops;
            this.grdTops.CellValueChanged += new DataGridViewCellEventHandler(this.grdTops_CellValueChanged);
            this.grdTops.CellMouseDown += new DataGridViewCellMouseEventHandler(this.grdTops_CellMouseDown);
            this.grdTops.CellDoubleClick += new DataGridViewCellEventHandler(this.grdTops_CellDoubleClick);
            int num = 0;
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdTops.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn2.DataPropertyName = "Top";
            dataGridViewTextBoxColumn2.Name = "Top";
            dataGridViewTextBoxColumn2.HeaderText = "Tốp";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.ContextMenuStrip = this.TopContextMenuStrip;
            dataGridViewTextBoxColumn2.Width = 40;
            dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdTops.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn3.DataPropertyName = "LoaiTop";
            dataGridViewTextBoxColumn3.Name = "LoaiTop";
            dataGridViewTextBoxColumn3.HeaderText = "Loại";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 40;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdTops.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn4 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn4.DataPropertyName = "MayBay";
            dataGridViewTextBoxColumn4.Name = "MayBay";
            dataGridViewTextBoxColumn4.HeaderText = "MB";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 50;
            dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdTops.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn5 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn5.DataPropertyName = "KieuLoai";
            dataGridViewTextBoxColumn5.Name = "KieuLoai";
            dataGridViewTextBoxColumn5.HeaderText = "KL";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 30;
            dataGridViewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdTops.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn6 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn6.DataPropertyName = "BatDau";
            dataGridViewTextBoxColumn6.Name = "BatDau";
            dataGridViewTextBoxColumn6.HeaderText = "Bđầu";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 40;
            dataGridViewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdTops.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn7 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn7.DataPropertyName = "TopID";
            dataGridViewTextBoxColumn7.Name = "TopID";
            dataGridViewTextBoxColumn7.HeaderText = "";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 0;
            dataGridViewTextBoxColumn7.Visible = false;
            num++;
            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = (DataGridViewCheckBoxColumn)this.grdTops.Columns[num];
            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2 = dataGridViewCheckBoxColumn;
            dataGridViewCheckBoxColumn2.Name = "visible";
            dataGridViewCheckBoxColumn2.DataPropertyName = "visible";
            dataGridViewCheckBoxColumn2.HeaderText = "Hiện";
            dataGridViewCheckBoxColumn2.Width = 40;
        }
        private DataTable GetdtTops()
        {
            DataTable dataTable = new DataTable();
            DataColumnCollection columns = dataTable.Columns;
            columns.Add("Top", Type.GetType("System.String"));
            columns.Add("LoaiTop", Type.GetType("System.String"));
            columns.Add("MayBay", Type.GetType("System.String"));
            columns.Add("KieuLoai", Type.GetType("System.String"));
            columns.Add("BatDau", Type.GetType("System.String"));
            columns.Add("TopID", Type.GetType("System.Int32"));
            columns.Add("visible", Type.GetType("System.Boolean"));
            foreach (CTop current in this.m_Tops)
            {
                DataRow dataRow = dataTable.NewRow();
                CTop cTop = current;
                dataRow["Top"] = cTop.FlightNo;
                dataRow["LoaiTop"] = this.GetLoaiTop(cTop.LoaiTopID);
                CLoaiMB loaiMB = CLoaiMBs.GetLoaiMB(cTop.LoaiMB);
                dataRow["MayBay"] = loaiMB.LoaiMB;
                dataRow["KieuLoai"] = loaiMB.KL;
                dataRow["BatDau"] = cTop.GioBatDau.ToString("00") + ":" + cTop.PhutBatDau.ToString("00");
                dataRow["TopID"] = cTop.TopID;
                dataRow["visible"] = cTop.visible;
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
        private string GetLoaiTop(int pLoaiTopID)
        {
            return Convert.ToString(pLoaiTopID == 1 ? "Địch" : pLoaiTopID == 3 ? "Qtế" : pLoaiTopID == 4 ? "QCảnh" : "Ta");
        }
        private void PopulateRadaGridView()
        {
            this.grdRadas.DataSource = null;
            DataTable dataTable = this.GetdtRadas();
            this.dvRadas = dataTable.DefaultView;
            this.grdRadas.DataSource = this.dvRadas;
            this.grdRadas.CellValueChanged += new DataGridViewCellEventHandler(this.grdRadas_CellValueChanged);
            this.grdRadas.CellMouseDown += new DataGridViewCellMouseEventHandler(this.grdRadas_CellMouseDown);
            this.grdRadas.CellDoubleClick += new DataGridViewCellEventHandler(this.grdRadas_CellDoubleClick);
            int num = 0;
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdRadas.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn2.DataPropertyName = "SoHieu";
            dataGridViewTextBoxColumn2.Name = "SoHieu";
            dataGridViewTextBoxColumn2.HeaderText = "SH";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.ContextMenuStrip = this.RadaContextMenuStrip;
            dataGridViewTextBoxColumn2.Width = 40;
            dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdRadas.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn3.DataPropertyName = "LoaiRada";
            dataGridViewTextBoxColumn3.Name = "LoaiRada";
            dataGridViewTextBoxColumn3.HeaderText = "Loại";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 40;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdRadas.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn4 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn4.DataPropertyName = "Ten";
            dataGridViewTextBoxColumn4.Name = "Ten";
            dataGridViewTextBoxColumn4.HeaderText = "Tên";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 80;
            dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdRadas.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn5 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn5.DataPropertyName = "BanKinh";
            dataGridViewTextBoxColumn5.Name = "BanKinh";
            dataGridViewTextBoxColumn5.HeaderText = "R";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 40;
            dataGridViewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
            num++;
            dataGridViewTextBoxColumn = (DataGridViewTextBoxColumn)this.grdRadas.Columns[num];
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn6 = dataGridViewTextBoxColumn;
            dataGridViewTextBoxColumn6.DataPropertyName = "RadaID";
            dataGridViewTextBoxColumn6.Name = "RadaID";
            dataGridViewTextBoxColumn6.HeaderText = "";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 0;
            dataGridViewTextBoxColumn6.Visible = false;
            num++;
            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = (DataGridViewCheckBoxColumn)this.grdRadas.Columns[num];
            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2 = dataGridViewCheckBoxColumn;
            dataGridViewCheckBoxColumn2.Name = "visible";
            dataGridViewCheckBoxColumn2.DataPropertyName = "visible";
            dataGridViewCheckBoxColumn2.HeaderText = "Hiện";
            dataGridViewCheckBoxColumn2.Width = 40;
        }
        private DataTable GetdtRadas()
        {
            DataTable dataTable = new DataTable();
            DataColumnCollection columns = dataTable.Columns;
            columns.Add("SoHieu", Type.GetType("System.String"));
            columns.Add("LoaiRada", Type.GetType("System.String"));
            columns.Add("Ten", Type.GetType("System.String"));
            columns.Add("BanKinh", Type.GetType("System.Single"));
            columns.Add("RadaID", Type.GetType("System.Int32"));
            columns.Add("visible", Type.GetType("System.Boolean"));
            foreach (CRada current in this.m_BaiTapRadas)
            {
                DataRow dataRow = dataTable.NewRow();
                CRada cRada = current;
                dataRow["SoHieu"] = cRada.SoHieu;
                dataRow["LoaiRada"] = this.GetLoaiRada(cRada.LoaiRadaID);
                dataRow["Ten"] = cRada.Ten;
                dataRow["BanKinh"] = cRada.R;
                dataRow["RadaID"] = cRada.RadaID;
                dataRow["visible"] = cRada.visible;
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
        private string GetLoaiRada(int pLoaiRadaID)
        {
            return Convert.ToString(pLoaiRadaID == 3 ? "DĐ" : pLoaiRadaID == 2 ? "HL" : "CG");
        }
        private void grdTops_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.m_SeleTop != null)
            {
                this.AxMap1.ZoomTo(this.AxMap1.Zoom, this.m_SeleTop.PosFrom.x, this.m_SeleTop.PosFrom.y);
            }
        }
        private void grdTops_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.grdTops.Rows[e.RowIndex].Selected = true;
                DataRowView dataRowView = this.dvTops[e.RowIndex];
                int lTop_ID = Convert.ToInt32(dataRowView["TopID"]);
                this.m_SeleTop = this.GetTop(lTop_ID);
                if (this.m_SeleTop != null)
                {
                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void grdTops_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.bLoaded && (e.RowIndex > -1 & e.ColumnIndex == 6))
            {
                DataRowView dataRowView = this.dvTops[e.RowIndex];
                int lTop_ID = Convert.ToInt32(dataRowView["TopID"]);
                CTop top = this.GetTop(lTop_ID);
                if (top != null)
                {
                    top.visible = Convert.ToBoolean(this.grdTops.CurrentCell.Value);
                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void grdTops_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataRowView dataRowView = this.dvTops[e.RowIndex];
                int lTop_ID = Convert.ToInt32(dataRowView["TopID"]);
                this.m_SeleTop = this.GetTop(lTop_ID);
                if (this.m_SeleTop != null)
                {
                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void grdRadas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.m_SeleRada != null)
            {
                this.AxMap1.ZoomTo(this.AxMap1.Zoom, this.m_SeleRada.PosX, this.m_SeleRada.PosY);
            }
        }
        private void grdRadas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.grdRadas.Rows[e.RowIndex].Selected = true;
                DataRowView dataRowView = this.dvRadas[e.RowIndex];
                int lRada_ID = Convert.ToInt32(dataRowView["RadaID"]);
                this.m_SeleRada = this.GetRada(lRada_ID);
                if (this.m_SeleRada != null)
                {
                    CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                    this.PopulateKhuats(cBaiTap.BaiTapID, this.m_SeleRada.RadaID);
                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void grdRadas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.bLoaded && (e.RowIndex > -1 & e.ColumnIndex == 5))
            {
                DataRowView dataRowView = this.dvRadas[e.RowIndex];
                int lRada_ID = Convert.ToInt32(dataRowView["RadaID"]);
                CRada rada = this.GetRada(lRada_ID);
                if (rada != null)
                {
                    rada.visible = Convert.ToBoolean(this.grdRadas.CurrentCell.Value);
                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void grdRadas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataRowView dataRowView = this.dvRadas[e.RowIndex];
                int lRada_ID = Convert.ToInt32(dataRowView["RadaID"]);
                this.m_SeleRada = this.GetRada(lRada_ID);
                if (this.m_SeleRada != null)
                {
                    CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                    this.PopulateKhuats(cBaiTap.BaiTapID, this.m_SeleRada.RadaID);
                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private CRada GetSeleRada()
        {
            DataRowView dataRowView = this.dvRadas[this.grdRadas.CurrentRow.Index];
            int lRada_ID = Convert.ToInt32(dataRowView["RadaID"]);
            return this.GetRada(lRada_ID);
        }
        private void btnXemBT_Click(object sender, EventArgs e)
        {
            if (this.m_BaiTapRadas.Count > 0)
            {
                if (this.m_Tops.Count > 0)
                {
                    dlgBanTinTB dlgBanTinTB = new dlgBanTinTB();
                    dlgBanTinTB.ShowDialog(this, this.m_BaiTapRadas);
                }
                else
                {
                    MessageBox.Show("Khong co Top nao de quan sat.", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Khong co Rada de quan sat.", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void NewRadaHoaLucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapPoint mapPoint = default(MapPoint);
            float num = (float)this.myPt.X;
            float num2 = (float)this.myPt.Y;
            this.AxMap1.ConvertCoord(ref num, ref num2, ref mapPoint.x, ref mapPoint.y, ConversionConstants.miScreenToMap);
            this.myPt.Y = (int)Math.Round((double)num2);
            this.myPt.X = (int)Math.Round((double)num);
            this.NewRada = new CRada();
            CRada newRada = this.NewRada;
            newRada.PosX = mapPoint.x;
            newRada.PosY = mapPoint.y;
            newRada.LoaiRadaID = 2;
            newRada.R = 50f;
            newRada.SoHieu = "00";
            newRada.Ten = "HL00";
            this.lyrAnimation.Invalidate(Missing.Value);
            new dlgBaiTapRada
            {
                txtMod =
                {
                    Text = "New"
                },
                TopMost = true
            }.Show();
        }
        private void RadaUpdateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.m_SeleRada != null)
            {
                this.NewRada = this.m_SeleRada;
                this.lyrAnimation.Invalidate(Missing.Value);
                new dlgBaiTapRada
                {
                    txtMod =
                    {
                        Text = "Update"
                    },
                    TopMost = true
                }.Show();
            }
        }
        private void RadaContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (this.m_SeleRada != null)
            {
                CRada seleRada = this.m_SeleRada;
                if (seleRada.LoaiRadaID != 2)
                {
                }
                if (seleRada.LoaiRadaID == 1)
                {
                    this.RadaUpdateToolStripMenuItem2.Enabled = false;
                    this.RadaDelToolStripMenuItem.Enabled = false;
                    this.RadaAnPVToolStripMenuItem.Visible = false;
                    this.RadaHienPVToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.RadaDelToolStripMenuItem.Enabled = true;
                    this.RadaDelToolStripMenuItem.Click += new EventHandler(this.RadaDelToolStripMenuItem_Click);
                    this.RadaUpdateToolStripMenuItem2.Enabled = true;
                    this.RadaUpdateToolStripMenuItem2.Click += new EventHandler(this.RadaUpdateToolStripMenuItem2_Click);
                    this.RadaAnPVToolStripMenuItem.Visible = true;
                    this.RadaAnPVToolStripMenuItem.Click += new EventHandler(this.RadaAnPVToolStripMenuItem_Click);
                    this.RadaHienPVToolStripMenuItem.Visible = true;
                    this.RadaHienPVToolStripMenuItem.Click += new EventHandler(this.RadaHienPVToolStripMenuItem_Click);
                }
            }
        }
        private void RadaDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleRada != null)
            {
                CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                CRada seleRada = this.m_SeleRada;
                if (MessageBox.Show("Thật sự muốn xoá " + seleRada.Ten + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<CKhuat> list = CBaiTapKhuats.GetList(cBaiTap.BaiTapID, seleRada.RadaID);
                    foreach (CKhuat current in list)
                    {
                        CBaiTapKhuats.DeletePts(cBaiTap.BaiTapID, current.KhuatID);
                        CBaiTapKhuats.Delete(cBaiTap.BaiTapID, current.KhuatID);
                    }

                    this.PopulateAllKhuats(cBaiTap.BaiTapID);
                    CBaiTapRadas.Delete(cBaiTap.BaiTapID, seleRada.RadaID);
                    this.PopulateBaiTapRadas(cBaiTap.BaiTapID);
                    this.m_SeleRada = null;
                    this.lyrCacKyHieu.Invalidate(Missing.Value);
                }
            }
        }
        private void TopTinhTienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleTop != null)
            {
                if (MessageBox.Show("Tịnh tiến đường bay?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.ToolStripStatusLabel3.Text = "Vẽ đoạn tịnh tiến.";
                    System.Drawing.Point mousePT = default(System.Drawing.Point);
                    float num = (float)mousePT.X;
                    float num2 = (float)mousePT.Y;
                    this.AxMap1.ConvertCoord(ref num, ref num2, ref this.m_SeleTop.PosFrom.x, ref this.m_SeleTop.PosFrom.y, ConversionConstants.miMapToScreen);
                    mousePT.Y = (int)Math.Round((double)num2);
                    mousePT.X = (int)Math.Round((double)num);
                    this.myBanDoNen.OnVeLine(mousePT);
                }
            }
            else
            {
                MessageBox.Show("ko co SeleTop", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void LoadKhuats(int pBaiTapID, CRada pRada)
        {
            List<CKhuat> list = CBaiTapKhuats.GetList(pBaiTapID, pRada.RadaID);
            foreach (CKhuat current in list)
            {
                current.KhuatPts = CBaiTapKhuats.GetKhuatPts(pBaiTapID, current.KhuatID);
            }

            pRada.Khuats = list;
        }
        private void VeRadaHLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_BaiTapRadas != null)
            {
                CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                List<CRada> list = new List<CRada>();
                foreach (CRada current in this.m_BaiTapRadas)
                {
                    if (current.LoaiRadaID == 2)
                    {
                        this.LoadKhuats(cBaiTap.BaiTapID, current);
                        list.Add(current);
                    }
                }

                Color mFillC = Color.FromArgb(50, modHuanLuyen.defaRadaHLPenC);
                this.myBando.AddRadaRegion(this.AxMap1, list, mFillC);
                this.myDirty = true;
                this.ToolStripStatusLabel3.Text = "";
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void VeRadaDDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.m_BaiTapRadas != null)
            {
                CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
                List<CRada> list = new List<CRada>();
                foreach (CRada current in this.m_BaiTapRadas)
                {
                    if (current.LoaiRadaID == 3)
                    {
                        this.LoadKhuats(cBaiTap.BaiTapID, current);
                        list.Add(current);
                    }
                }

                Color mFillC = Color.FromArgb(50, modHuanLuyen.defaRadaDDPenC);
                this.myBando.AddRadaRegion(this.AxMap1, list, mFillC);
                this.myDirty = true;
                this.ToolStripStatusLabel3.Text = "";
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void chkRadaHien_CheckedChanged(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void ToJPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dlgToBitmap dlgToBitmap = new dlgToBitmap();
            //dlgToBitmap.ShowDialog(this);
        }
        private void VeVongTronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_BaiTapRadas != null)
            {
                this.myBando.AddRada(this.AxMap1, this.m_BaiTapRadas);
                this.myDirty = true;
                this.ToolStripStatusLabel3.Text = "";
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void VeDaGiacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_BaiTapRadas != null)
            {
                this.myBando.AddKhuat(this.AxMap1, this.m_AllKhuats);
                this.myDirty = true;
                this.ToolStripStatusLabel3.Text = "";
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void VeXoaTatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.myBando.XoaVeThem();
            this.myDirty = true;
            this.ToolStripStatusLabel3.Text = "";
            this.lyrCacKyHieu.Invalidate(Missing.Value);
        }
        private List<CFlight> GetFlights()
        {
            List<CFlight> list = new List<CFlight>();
            int num = 0;
            foreach (CTop current in this.m_Tops)
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
                catch (Exception expr_50)
                {
                    throw expr_50;
                }
            }

            return list;
        }
        private void Tinh2Flight(CFlight pFlight)
        {
            CBasePath.TinhSecs(this.AxMap1, pFlight.Path[0].node, pFlight.Path[1].node);
            DateTime pTd = pFlight.Departure.AddSeconds(pFlight.Path[0].node.t2next + pFlight.Path[0].node.tspeed);
            pFlight.TinhYToLuonVong(this.AxMap1, 1);
            pFlight.UpdateTd(1, pTd);
        }
        private void VeLaiDuongBayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CFlight> flights = this.GetFlights();
            foreach (CFlight current in flights)
            {
                this.myBando.AddDuongBay(this.AxMap1, current);
            }

            this.myDirty = true;
            this.ToolStripStatusLabel3.Text = "";
            this.lyrCacKyHieu.Invalidate(Missing.Value);
        }
        private void VeCacNutChiTietToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CFlight> flights = this.GetFlights();
            foreach (CFlight current in flights)
            {
                this.myBando.AddTGNode(this.AxMap1, current);
            }

            this.myDirty = true;
            this.ToolStripStatusLabel3.Text = "";
            this.lyrCacKyHieu.Invalidate(Missing.Value);
        }
        private void btnMatDoTB_Click(object sender, EventArgs e)
        {
            //if (this.m_BaiTapRadas.Count > 0)
            //{
            //    if (this.m_Tops.Count > 0)
            //    {
            //        dlgBanTinMDTB dlgBanTinMDTB = new dlgBanTinMDTB();
            //        dlgBanTinMDTB.ShowDialog(this, this.m_BaiTapRadas);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Khong co Top nao de quan sat.", "Thông báo", MessageBoxButtons.OK);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Khong co Rada de quan sat.", "Thông báo", MessageBoxButtons.OK);
            //}
        }
        private void chkHienKyHieu_CheckedChanged(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                this.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void btnTinhHuong_Click(object sender, EventArgs e)
        {
            dlgBaiTapTinhHuong dlgBaiTapTinhHuong = new dlgBaiTapTinhHuong();
            dlgBaiTapTinhHuong.ShowDialog(this);
        }
        private void DauTopPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.m_SeleTop != null)
            {
                this.m_MovingTop = this.m_SeleTop;
                this.myMapTool = dlgBaiTapHinhThai.MapTools.DauTopPos;
                this.AxMap1.CenterX = this.AxMap1.CenterX;
                this.AxMap1.DrawUserLayer += new AxMapXLib.CMapXEvents_DrawUserLayerEventHandler(this.AxMap1_DrawUserLayer);
                this.AxMap1.MouseUpEvent += new AxMapXLib.CMapXEvents_MouseUpEventHandler(this.AxMap1_MouseUpEvent);
                this.AxMap1.MouseMoveEvent += new AxMapXLib.CMapXEvents_MouseMoveEventHandler(this.AxMap1_MouseMoveEvent);
                this.AxMap1.MouseDownEvent += new AxMapXLib.CMapXEvents_MouseDownEventHandler(this.AxMap1_MouseDownEvent);
                this.AxMap1.KeyUpEvent += new AxMapXLib.CMapXEvents_KeyUpEventHandler(this.AxMap1_KeyUpEvent);
                this.AxMap1.ToolUsed += new AxMapXLib.CMapXEvents_ToolUsedEventHandler(this.AxMap1_ToolUsed);
                this.myMapTool = dlgBaiTapHinhThai.MapTools.DauTopPos;
            }
        }

        
    }
}