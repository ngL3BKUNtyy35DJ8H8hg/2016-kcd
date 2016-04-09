using AxMapXLib;
using DBiGraphicObjs.DBiGraphicObjects;
using MapXLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
namespace HuanLuyen
{
    public partial class CBdTC
    {
        public struct SPLITSYMBOLS
        {
            public CSymbol Symbol1;
            public CSymbol Symbol2;
        }

        public enum MapTools
        {
            None,
            Polygon,
            Line,
            Curve,
            ClosedCurve,
            Bezier,
            Cycle,
            Rectangle,
            arc,
            Text,
            Table,
            MuiTenDon,
            MuiTen,
            MuiTenDac,
            MuiTenHo,
            SongSong,
            SongSongKin,
            Move,
            DangMove,
            Scale,
            DangScale,
            Rotate,
            DangRotate,
            GrMove,
            GrDangMove,
            Split,
            DangSplit,
            DangLayKH,
            NodesEdit,
            ChangeRoot
        }

        public delegate void SelectedSymbolChangedEventHandler(CSymbol seleSymbol);
        public delegate void ListKHChangedEventHandler(CSymbol seleSymbol);
        private CBdTC.SelectedSymbolChangedEventHandler SelectedSymbolChangedEvent;
        private CBdTC.ListKHChangedEventHandler ListKHChangedEvent;
        private ContextMenu CxtMnuLineStyle;
        private ContextMenu CxtMnuKyHieu;
        private MenuItem MnuKHMove;
        private MenuItem MnuKHBar1;
        private MenuItem MnuScale;
        private MenuItem MenuItem8;
        private MenuItem MnuRotate;
        private MenuItem MnuKHBar3;
        private MenuItem MnuHeading;
        private MenuItem MnuKHBar4;
        private MenuItem MnuVFlip;
        private MenuItem MenuItem10;
        private MenuItem MnuEditNodes;
        private MenuItem MenuItem11;
        private MenuItem MnuChangeRoot;
        private MenuItem MenuItem13;
        private MenuItem MnuChangeDesc;
        private MenuItem MnuKHBar2;
        private MenuItem MnuBlinking;
        private MenuItem MenuItem9;
        private MenuItem MnuDeleteKH;
        private MenuItem MnuPartsBar;
        private MenuItem MnuParts;
        private MenuItem MnuCopyKHprev;
        private MenuItem MnuCopyKH;
        private MenuItem MnuCopyToVeKHprev;
        private MenuItem MnuCopyToVeKH;
        private MenuItem MnuSendBackprev;
        private MenuItem MnuSendBack;
        private MenuItem MnuSendFrontprev;
        private MenuItem MnuSendFront;
        private MenuItem MnuCutPrev;
        private MenuItem MnuCut;
        private MenuItem MnuToCurvePrev;
        private MenuItem MnuToCurve;
        private MenuItem MnuToPhanRaPrev;
        private MenuItem MnuToPhanRa;
        private MenuItem MnuClosed2Curveprev;
        private MenuItem MnuClosed2Curve;
        private MenuItem MnuCurve2Closedprev;
        private MenuItem MnuCurve2Closed;
        private MenuItem MnuTo1stNodeprev;
        private MenuItem MnuTo1stNode;
        private MenuItem MnuTo1ObjectPrev;
        private MenuItem MnuTo1Object;
        private ContextMenu CxtMnuGroup;
        private MenuItem MnuGrMove;
        private MenuItem MnuGrBar1;
        private MenuItem MnuGrCopy;
        private MenuItem MnuGrBar2;
        private MenuItem MnuGrCut;
        private MenuItem MnuGrBar3;
        private MenuItem MnuGrChangeColor;
        private MenuItem MnuGrBar4;
        private MenuItem MnuGrNhom;
        private ContextMenu CxtMnuPart;
        private MenuItem MnuChangeColor;
        private MenuItem MnuPartBar1;
        private MenuItem MnuDeleteShape;
        private MenuItem MnuPartBar2;
        private MenuItem MnuPartSendBack;
        private MenuItem MnuPartBar3;
        private MenuItem MnuPartSendFront;
        private MenuItem MnuPartBar4;
        private MenuItem MnuPartTachObject;
        private ContextMenu CxtMnuNodeEdit;
        private MenuItem MnXoaNode;
        private MenuItem MenuItem5;
        private MenuItem MnuAddNode;
        private MenuItem MenuItem7;
        private MenuItem MnuChangeNodeType;
        private ContextMenu CxtMnuMap;
        private MenuItem MnuPastKH;
        private AxMap m_Map;
        protected dlgBaiTapHinhThai m_ParentForm;
        private Panel m_Panel;
        private ToolStrip m_ToolStrip;
        private ToolTip toolTip1;
        private int iUndo = 0;
        private int iRedo = 0;
        private double SymbolZoom = 0;
        private float SymbolMapScreenWidth = 0;
        private CSymbol m_SelectedSymbol;
        private GraphicObject m_SelectedObject;
        private CSymbol m_CopySymbol;
        private CSymbol m_KHfromVeKH;
        private CSymbols m_DrawingSymbols;
        private CSymbols m_SelectedSymbols;
        private CSymbols m_CopySymbols;
        public object myMapCurrTool;
        public CBdTC.MapTools myMapTool;
        private PointF[] myPts;
        private PointF myfromPt = new PointF();
        private PointF mytoPt = new PointF();
        private PointF myrootPt = new PointF();
        private bool NodeDragging;
        private bool RootDragging;
        private bool selectionDragging;
        private RectangleF selectionRect;
        private bool DrawingDragging;
        private System.Drawing.Rectangle DrawingRect;
        private bool DrawingPicking;
        private GraphicObject EditObj;
        private int iEditNode = 0;
        private CFOUNDNODE FoundNode;
        private CFOUNDOBJECT FoundObject;
        private bool bSnap;
        private bool bGrid;
        public int myGridWidth = 0;
        private int myWidth = 0;
        private int myHeight = 0;
        private Size GridSize;
        private System.Drawing.Rectangle GridRect;
        private PointF mousePos = new PointF();
        private CSymbol lastTTSymbol;
        public event CBdTC.SelectedSymbolChangedEventHandler SelectedSymbolChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.SelectedSymbolChangedEvent = (CBdTC.SelectedSymbolChangedEventHandler)Delegate.Combine(this.SelectedSymbolChangedEvent, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.SelectedSymbolChangedEvent = (CBdTC.SelectedSymbolChangedEventHandler)Delegate.Remove(this.SelectedSymbolChangedEvent, value);
            }
        }
        public event CBdTC.ListKHChangedEventHandler ListKHChanged
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                this.ListKHChangedEvent = (CBdTC.ListKHChangedEventHandler)Delegate.Combine(this.ListKHChangedEvent, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                this.ListKHChangedEvent = (CBdTC.ListKHChangedEventHandler)Delegate.Remove(this.ListKHChangedEvent, value);
            }
        }
        public virtual CSymbols drawingSymbols
        {
            get
            {
                return this.m_DrawingSymbols;
            }
            set
            {
                this.m_DrawingSymbols = value;
            }
        }
        public CSymbol SelectedSymbol
        {
            get
            {
                return this.m_SelectedSymbol;
            }
            set
            {
                if (value != this.m_SelectedSymbol && (this.m_DrawingSymbols.Contains(value) || value == null))
                {
                    this.m_SelectedSymbol = value;
                    this.RefreshMap();
                }
            }
        }
        private void InitializeComponent()
        {
            this.CxtMnuGroup = new ContextMenu();
            this.MnuGrMove = new MenuItem();
            this.MnuGrBar1 = new MenuItem();
            this.MnuGrCopy = new MenuItem();
            this.MnuGrBar2 = new MenuItem();
            this.MnuGrCut = new MenuItem();
            this.MnuGrBar3 = new MenuItem();
            this.MnuGrChangeColor = new MenuItem();
            this.MnuGrBar4 = new MenuItem();
            this.MnuGrNhom = new MenuItem();
            this.CxtMnuPart = new ContextMenu();
            this.MnuChangeColor = new MenuItem();
            this.MnuPartBar1 = new MenuItem();
            this.MnuDeleteShape = new MenuItem();
            this.MnuPartBar2 = new MenuItem();
            this.MnuPartSendBack = new MenuItem();
            this.MnuPartBar3 = new MenuItem();
            this.MnuPartSendFront = new MenuItem();
            this.MnuPartBar4 = new MenuItem();
            this.MnuPartTachObject = new MenuItem();
            this.CxtMnuNodeEdit = new ContextMenu();
            this.MnXoaNode = new MenuItem();
            this.MenuItem5 = new MenuItem();
            this.MnuAddNode = new MenuItem();
            this.MenuItem7 = new MenuItem();
            this.MnuChangeNodeType = new MenuItem();
            this.CxtMnuKyHieu = new ContextMenu();
            this.MnuKHMove = new MenuItem();
            this.MnuKHBar1 = new MenuItem();
            this.MnuScale = new MenuItem();
            this.MenuItem8 = new MenuItem();
            this.MnuRotate = new MenuItem();
            this.MnuKHBar3 = new MenuItem();
            this.MnuHeading = new MenuItem();
            this.MnuKHBar4 = new MenuItem();
            this.MnuVFlip = new MenuItem();
            this.MenuItem10 = new MenuItem();
            this.MnuEditNodes = new MenuItem();
            this.MenuItem11 = new MenuItem();
            this.MnuChangeRoot = new MenuItem();
            this.MenuItem13 = new MenuItem();
            this.MnuChangeDesc = new MenuItem();
            this.MnuKHBar2 = new MenuItem();
            this.MnuBlinking = new MenuItem();
            this.MenuItem9 = new MenuItem();
            this.MnuDeleteKH = new MenuItem();
            this.CxtMnuMap = new ContextMenu();
            this.MnuPastKH = new MenuItem();
            this.CxtMnuGroup.MenuItems.AddRange(new MenuItem[]
			{
				this.MnuGrMove,
				this.MnuGrBar1,
				this.MnuGrCopy,
				this.MnuGrBar2,
				this.MnuGrCut,
				this.MnuGrBar3,
				this.MnuGrChangeColor,
				this.MnuGrBar4,
				this.MnuGrNhom
			});
            this.MnuGrMove.Text = "Di chuyển Nhóm Ký hiệu";
            this.MnuGrBar1.Text = "-";
            this.MnuGrCopy.Text = "Copy Nhóm Ký hiệu";
            this.MnuGrBar2.Text = "-";
            this.MnuGrCut.Text = "Xoá cả Nhóm Ký hiệu";
            this.MnuGrBar3.Text = "-";
            this.MnuGrChangeColor.Text = "Thay Mầu,Nét,Kiểu Nét";
            this.MnuGrBar4.Text = "-";
            this.MnuGrNhom.Text = "Nhóm thành 1 Ký hiệu";
            this.CxtMnuPart.MenuItems.AddRange(new MenuItem[]
			{
				this.MnuChangeColor,
				this.MnuPartBar1,
				this.MnuDeleteShape,
				this.MnuPartBar2,
				this.MnuPartSendBack,
				this.MnuPartBar3,
				this.MnuPartSendFront,
				this.MnuPartBar4,
				this.MnuPartTachObject
			});
            this.MnuChangeColor.Text = "Đổi chi tiết";
            this.MnuPartBar1.Text = "-";
            this.MnuDeleteShape.Text = "Xóa chi tiết";
            this.MnuPartBar2.Text = "-";
            this.MnuPartSendBack.Text = "Chi tiết Xuống dưới";
            this.MnuPartBar3.Text = "-";
            this.MnuPartSendFront.Text = "Chi tiết Lên trên";
            this.MnuPartBar4.Text = "-";
            this.MnuPartTachObject.Text = "Tách thành KH riêng";
            this.CxtMnuNodeEdit.MenuItems.AddRange(new MenuItem[]
			{
				this.MnXoaNode,
				this.MenuItem5,
				this.MnuAddNode,
				this.MenuItem7,
				this.MnuChangeNodeType
			});
            this.MnXoaNode.Text = "Xóa nút";
            this.MenuItem5.Text = "-";
            this.MnuAddNode.Text = "Thêm nút";
            this.MenuItem7.Text = "-";
            this.MnuChangeNodeType.Text = "Đổi Kiểu nút";
            this.MnuTo1stNodeprev = new MenuItem();
            this.MnuTo1stNode = new MenuItem();
            this.CxtMnuNodeEdit.MenuItems.Add(this.MnuTo1stNodeprev);
            this.CxtMnuNodeEdit.MenuItems.Add(this.MnuTo1stNode);
            this.MnuTo1stNodeprev.Text = "-";
            this.MnuTo1stNode.Text = "Thành nút đầu";
            this.MnuTo1ObjectPrev = new MenuItem();
            this.MnuTo1Object = new MenuItem();
            this.CxtMnuNodeEdit.MenuItems.Add(this.MnuTo1ObjectPrev);
            this.CxtMnuNodeEdit.MenuItems.Add(this.MnuTo1Object);
            this.MnuTo1ObjectPrev.Text = "-";
            this.MnuTo1Object.Text = "Nối chi tiết";
            this.MnuCutPrev = new MenuItem();
            this.MnuCut = new MenuItem();
            this.MnuToCurvePrev = new MenuItem();
            this.MnuToCurve = new MenuItem();
            this.MnuToPhanRaPrev = new MenuItem();
            this.MnuToPhanRa = new MenuItem();
            this.CxtMnuKyHieu.MenuItems.AddRange(new MenuItem[]
			{
				this.MnuKHMove,
				this.MnuKHBar1,
				this.MnuScale,
				this.MenuItem8,
				this.MnuRotate,
				this.MnuKHBar3,
				this.MnuHeading,
				this.MnuKHBar4,
				this.MnuVFlip,
				this.MnuCutPrev,
				this.MnuCut,
				this.MnuToCurvePrev,
				this.MnuToCurve,
				this.MnuToPhanRaPrev,
				this.MnuToPhanRa,
				this.MenuItem10,
				this.MnuEditNodes,
				this.MenuItem11,
				this.MnuChangeRoot,
				this.MenuItem13,
				this.MnuChangeDesc,
				this.MnuKHBar2,
				this.MnuBlinking,
				this.MenuItem9,
				this.MnuDeleteKH
			});
            this.MnuKHMove.Text = "Dời Ký hiệu";
            this.MnuKHBar1.Text = "-";
            this.MnuScale.Text = "Thu-Phóng Ký hiệu";
            this.MenuItem8.Text = "-";
            this.MnuRotate.Text = "Quay Ký hiệu";
            this.MnuKHBar3.Text = "-";
            this.MnuHeading.Text = "Hướng Ký hiệu";
            this.MnuKHBar4.Text = "-";
            this.MnuVFlip.Text = "Lật Ký hiệu";
            this.MnuCutPrev.Text = "-";
            this.MnuCut.Text = "Cắt đôi Ký hiệu";
            this.MnuToCurvePrev.Text = "-";
            this.MnuToCurve.Text = "Đổi thành đường cong";
            this.MnuToPhanRaPrev.Text = "-";
            this.MnuToPhanRa.Text = "Tách tất cả các chi tiết";
            this.MenuItem10.Text = "-";
            this.MnuEditNodes.Text = "Tinh chỉnh";
            this.MenuItem11.Text = "-";
            this.MnuChangeRoot.Text = "Thay đổi gốc KH";
            this.MenuItem13.Text = "-";
            this.MnuChangeDesc.Text = "Đổi ghi chú";
            this.MnuKHBar2.Text = "-";
            this.MnuBlinking.Text = "Nhấp nháy";
            this.MenuItem9.Text = "-";
            this.MnuDeleteKH.Text = "Xóa Ký Hiệu";
            this.CxtMnuMap.MenuItems.AddRange(new MenuItem[]
			{
				this.MnuPastKH
			});
            this.MnuPastKH.Text = "Dán Ký hiệu";
            this.MnuCopyKHprev = new MenuItem();
            this.MnuCopyKH = new MenuItem();
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuCopyKHprev);
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuCopyKH);
            this.MnuCopyKHprev.Text = "-";
            this.MnuCopyKH.Text = "Copy Ký hiệu";
            this.MnuCopyToVeKHprev = new MenuItem();
            this.MnuCopyToVeKH = new MenuItem();
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuCopyToVeKHprev);
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuCopyToVeKH);
            this.MnuCopyToVeKHprev.Text = "-";
            this.MnuCopyToVeKH.Text = "Copy sang Các Ký hiệu";
            this.MnuSendBackprev = new MenuItem();
            this.MnuSendBack = new MenuItem();
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuSendBackprev);
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuSendBack);
            this.MnuSendBackprev.Text = "-";
            this.MnuSendBack.Text = "Cho xuống dưới";
            this.MnuSendFrontprev = new MenuItem();
            this.MnuSendFront = new MenuItem();
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuSendFrontprev);
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuSendFront);
            this.MnuSendFrontprev.Text = "-";
            this.MnuSendFront.Text = "Cho lên trên";
            this.MnuPartsBar = new MenuItem();
            this.MnuParts = new MenuItem();
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuPartsBar);
            this.CxtMnuKyHieu.MenuItems.Add(this.MnuParts);
            this.MnuPartsBar.Text = "-";
            this.MnuParts.Text = "Thay đổi chi tiết";
            this.MnuParts.MenuItems.AddRange(new MenuItem[]
			{
				this.MnuChangeColor,
				this.MnuPartBar1,
				this.MnuDeleteShape,
				this.MnuPartBar2,
				this.MnuPartSendBack,
				this.MnuPartBar3,
				this.MnuPartSendFront,
				this.MnuPartBar4,
				this.MnuPartTachObject
			});
            this.MnuClosed2Curveprev = new MenuItem();
            this.MnuClosed2Curve = new MenuItem();
            this.MnuParts.MenuItems.Add(this.MnuClosed2Curveprev);
            this.MnuParts.MenuItems.Add(this.MnuClosed2Curve);
            this.MnuClosed2Curveprev.Text = "-";
            this.MnuClosed2Curve.Text = "Mở đường kép kín";
            this.MnuCurve2Closedprev = new MenuItem();
            this.MnuCurve2Closed = new MenuItem();
            this.MnuParts.MenuItems.Add(this.MnuCurve2Closedprev);
            this.MnuParts.MenuItems.Add(this.MnuCurve2Closed);
            this.MnuCurve2Closedprev.Text = "-";
            this.MnuCurve2Closed.Text = "Kép kín đường mở";
        }
        private void CreateMyToolTip()
        {
            this.toolTip1 = new ToolTip();
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.Active = false;
            this.toolTip1.SetToolTip(this.m_Map, "My Ban do");
        }
        private void CalcSymbolZoom()
        {
            int num = (int)Math.Round(modBanDo.GetZoomLevel(this.m_Map, modBanDo.BDTyLeBanDo));
            this.SymbolZoom = (double)(num * modBdTC.BDTyLeLayKH) / 100.0;
            this.SymbolMapScreenWidth = this.m_Map.MapScreenWidth;
        }
        public CBdTC(AxMap pMap, Form pForm, Panel pPanel, ToolStrip pToolStrip)
        {
            this.iUndo = -1;
            this.iRedo = -1;
            this.m_KHfromVeKH = null;
            this.m_DrawingSymbols = new CSymbols();
            this.m_SelectedSymbols = new CSymbols();
            this.m_CopySymbols = new CSymbols();
            this.NodeDragging = false;
            this.RootDragging = false;
            this.selectionDragging = false;
            this.DrawingDragging = false;
            this.DrawingPicking = false;
            this.bSnap = false;
            this.bGrid = false;
            this.myGridWidth = 8;
            this.myWidth = 200;
            this.myHeight = 160;
            this.GridSize = new Size(this.myGridWidth, this.myGridWidth);
            this.GridRect = new System.Drawing.Rectangle(0, 0, this.myWidth, this.myHeight);
            this.lastTTSymbol = null;
            this.m_ParentForm = (dlgBaiTapHinhThai)pForm;
            this.m_Map = pMap;
            this.m_Panel = pPanel;
            this.m_ToolStrip = pToolStrip;
            this.InitializeComponent();
            this.myMapTool = CBdTC.MapTools.None;
            modBdTC.MyOtherLineStyle = new COtherLineStyle();
            this.CreateMyMenu();
            this.XoaUndoStack();
            this.CreateMyToolTip();
        }
        public static Region getRegion(CSymbol psymbol)
        {
            Region region = new Region();
            region.MakeEmpty();
            foreach (GraphicObject graphicObject in psymbol.GObjs)
            {
                if (graphicObject.GetObjType() == OBJECTTYPE.Region)
                {
                    RegionGraphic regionGraphic = (RegionGraphic)graphicObject;
                    region.Union(regionGraphic.myRegion);
                }
                else if (graphicObject.GetObjType() == OBJECTTYPE.Text)
                {
                    TextGraphic textGraphic = (TextGraphic)graphicObject;
                    region.Union(textGraphic.GetPath());
                }
                else
                {
                    try
                    {
                        ShapeGraphic shapeGraphic = (ShapeGraphic)graphicObject;
                        region.Union(shapeGraphic.GetPath());
                    }
                    catch (Exception expr_7F)
                    {
                        throw expr_7F;
                    }
                }
            }

            return region;
        }
        private CSymbol GetRadaRSymbol(AxMap pMap, CRada pRada)
        {
            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            PointF point = pRada.GetPoint(pMap);
            PointF endPoint = pRada.GetEndPoint(pMap);
            float num = point.X - endPoint.X;
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(-num, -num, num * 2f + 1f, num * 2f + 1f);
            Color fillColor = Color.FromArgb(50, modHuanLuyen.defaRadaHLPenC);
            if (pRada.LoaiRadaID == 3)
            {
                fillColor = Color.FromArgb(50, modHuanLuyen.defaRadaDDPenC);
            }
            RegionGraphic aGObj = new RegionGraphic(graphicsPath, fillColor);
            cGraphicObjs.Add(aGObj);
            return new CSymbol(pMap, point, cGraphicObjs)
            {
                Description = "VeThemRada-" + pRada.Ten
            };
        }
        private CSymbol GetRadaSymbol(AxMap pMap, CRada pRada)
        {
            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            PointF point = pRada.GetPoint(pMap);
            PointF endPoint = pRada.GetEndPoint(pMap);
            float num = point.X - endPoint.X;
            EllipseGraphic ellipseGraphic = new EllipseGraphic(-num, -num, num * 2f + 1f, num * 2f + 1f, 0f);
            EllipseGraphic ellipseGraphic2 = ellipseGraphic;
            ellipseGraphic2.Fill = false;
            ellipseGraphic2.FillColor = modHuanLuyen.defaRadaHLPenC;
            if (pRada.LoaiRadaID == 2)
            {
                ellipseGraphic2.LineWidth = (float)modHuanLuyen.defaRadaHLPenW;
                ellipseGraphic2.LineColor = modHuanLuyen.defaRadaHLPenC;
            }
            else
            {
                ellipseGraphic2.LineWidth = (float)modHuanLuyen.defaRadaDDPenW;
                ellipseGraphic2.LineColor = modHuanLuyen.defaRadaDDPenC;
            }
            ellipseGraphic2.Line2Width = 0f;
            ellipseGraphic2.Line2Color = modHuanLuyen.defaRadaHLPenC;
            cGraphicObjs.Add(ellipseGraphic);
            return new CSymbol(pMap, point, cGraphicObjs)
            {
                Description = "VeThemRada-" + pRada.Ten
            };
        }
        private CSymbol KhoetRada(AxMap pMap, CRada pRada)
        {
            CSymbol cSymbol = this.GetRadaRSymbol(pMap, pRada);
            List<CSymbol> khuatSymbols = this.GetKhuatSymbols(pMap, pRada);
            List<CSymbol> list = new List<CSymbol>();
            list.Add(cSymbol);
            foreach (CSymbol current in khuatSymbols)
            {
                list.Add(current);
            }

            if (list.Count > 1)
            {
                Graphics graphics = this.m_Map.CreateGraphics();
                CGraphicObjs cGraphicObjs = new CGraphicObjs();
                Color fillColor = Color.FromArgb(50, modHuanLuyen.defaRadaHLPenC);
                if (pRada.LoaiRadaID == 3)
                {
                    fillColor = Color.FromArgb(50, modHuanLuyen.defaRadaDDPenC);
                }
                RegionGraphic regionGraphic = new RegionGraphic(CBdTC.getRegion(list[0]), fillColor);
                cSymbol = list[0];
                int num = list.Count - 1;
                for (int i = -1; i < num; i++)
                {
                    list[i].ChangeZoomMWidtht(cSymbol.Zoom, cSymbol.MWidth);
                    list[i].ChangeRoot(this.m_Map, cSymbol.GocX, cSymbol.GocY);
                    regionGraphic.myRegion.Exclude(CBdTC.getRegion(list[i]));
                }
                cGraphicObjs.Add(regionGraphic);
                cSymbol = new CSymbol(this.m_Map, cGraphicObjs);
                cSymbol.Description = "VeThamVungRada";
                cSymbol.ChangeZoomMWidtht(list[0].Zoom, list[0].MWidth);
                cSymbol.GocX = list[0].GocX;
                cSymbol.GocY = list[0].GocY;
            }
            return cSymbol;
        }
        public void AddRadaRegion(AxMap pMap, List<CRada> pRadas, Color mFillC)
        {
            this.PopUndo();
            CSymbols cSymbols = new CSymbols();
            foreach (CRada current in pRadas)
            {
                CSymbol aSymbol = this.KhoetRada(pMap, current);
                cSymbols.Add(aSymbol);
            }

            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            RegionGraphic regionGraphic = new RegionGraphic(CBdTC.getRegion(cSymbols[0]), mFillC);
            CSymbol cSymbol = cSymbols[0];
            if (cSymbols.Count > 1)
            {
                int num = cSymbols.Count - 1;
                for (int i = -1; i < num; i++)
                {
                    cSymbols[i].ChangeZoomMWidtht(cSymbol.Zoom, cSymbol.MWidth);
                    cSymbols[i].ChangeRoot(this.m_Map, cSymbol.GocX, cSymbol.GocY);
                    regionGraphic.myRegion.Union(CBdTC.getRegion(cSymbols[i]));
                }
            }
            cGraphicObjs.Add(regionGraphic);
            cSymbol = new CSymbol(this.m_Map, cGraphicObjs);
            cSymbol.Description = "VeThemVungRada";
            cSymbol.ChangeZoomMWidtht(cSymbols[0].Zoom, cSymbols[0].MWidth);
            cSymbol.GocX = cSymbols[0].GocX;
            cSymbol.GocY = cSymbols[0].GocY;
            this.m_DrawingSymbols.Add(cSymbol);
        }
        private List<CSymbol> GetRadas(AxMap pMap, List<CRada> pRadas)
        {
            List<CSymbol> list = new List<CSymbol>();
            foreach (CRada current in pRadas)
            {
                CSymbol radaSymbol = this.GetRadaSymbol(pMap, current);
                if (radaSymbol != null)
                {
                    list.Add(radaSymbol);
                }
            }

            return list;
        }
        public void AddRada(AxMap pMap, List<CRada> pRadas)
        {
            this.PopUndo();
            List<CSymbol> radas = this.GetRadas(pMap, pRadas);
            this.CalcSymbolZoom();
            foreach (CSymbol current in radas)
            {
                current.ChangeZoomMWidtht(this.SymbolZoom, this.SymbolMapScreenWidth);
                this.m_DrawingSymbols.Add(current);
            }

        }
        private CSymbol GetKhuatSymbol(AxMap pMap, CKhuat aKhuat, Color pColor)
        {
            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            PointF[] points = aKhuat.GetPoints(pMap);
            PointF pt = new PointF(points[0].X, points[0].Y);
            int upperBound = points.GetUpperBound(0);
            for (int i = 0; i <= upperBound; i = checked(i + 1))
            {
                PointF[] array = points;
                int num = i;
                array[num].X = array[num].X - pt.X;
                array = points;
                num = i;
                array[num].Y = array[num].Y - pt.Y;
            }
            PolygonGraphic aGObj = new PolygonGraphic(points, 1f, pColor);
            cGraphicObjs.Add(aGObj);
            return new CSymbol(pMap, pt, cGraphicObjs)
            {
                Description = "VeThemKhuat"
            };
        }
        private List<CSymbol> GetKhuatSymbols(AxMap pMap, CRada pRada)
        {
            List<CSymbol> list = new List<CSymbol>();
            List<CKhuat> khuats = pRada.Khuats;
            Color pColor = modHuanLuyen.defaRadaHLPenC;
            if (pRada.LoaiRadaID == 3)
            {
                pColor = modHuanLuyen.defaRadaDDPenC;
            }
            foreach (CKhuat current in khuats)
            {
                CSymbol khuatSymbol = this.GetKhuatSymbol(pMap, current, pColor);
                list.Add(khuatSymbol);
            }

            return list;
        }
        public void AddKhuat(AxMap pMap, List<CRada> pRadas)
        {
            this.PopUndo();
            foreach (CRada current in pRadas)
            {
                List<CSymbol> khuatSymbols = this.GetKhuatSymbols(pMap, current);
                CSymbol cSymbol = khuatSymbols[0];
                this.m_DrawingSymbols.Add(khuatSymbols[0]);
                if (khuatSymbols.Count > 1)
                {
                    int num = khuatSymbols.Count - 1;
                    for (int i = -1; i < num; i++)
                    {
                        this.m_DrawingSymbols.Add(khuatSymbols[i]);
                    }
                }
            }

        }
        public void AddKhuat(AxMap pMap, List<CKhuat> pKhuats)
        {
            this.PopUndo();
            Color defaRadaHLPenC = modHuanLuyen.defaRadaHLPenC;
            List<CSymbol> list = new List<CSymbol>();
            foreach (CKhuat current in pKhuats)
            {
                CSymbol khuatSymbol = this.GetKhuatSymbol(pMap, current, defaRadaHLPenC);
                list.Add(khuatSymbol);
            }

            CSymbol cSymbol = list[0];
            this.m_DrawingSymbols.Add(list[0]);
            if (list.Count > 1)
            {
                int num = list.Count - 1;
                for (int i = -1; i < num; i++)
                {
                    this.m_DrawingSymbols.Add(list[i]);
                }
            }
        }
        public void AddDuongBay(AxMap pMap, CFlight pFlight)
        {
            this.PopUndo();
            List<CSymbol> duongBay = this.GetDuongBay(pMap, pFlight);
            this.CalcSymbolZoom();
            foreach (CSymbol current in duongBay)
            {
                current.ChangeZoomMWidtht(this.SymbolZoom, this.SymbolMapScreenWidth);
                this.m_DrawingSymbols.Add(current);
            }

        }
        private CSymbol GetVongLuon(AxMap pMap, CFlight pFlight, int index)
        {
            CSymbol cSymbol = null;
            if (pFlight.Path[index].node.R > 0.0 & pFlight.Path[index].node.typ > 0.9)
            {
                PointF pPt = default(PointF);
                float num = pPt.X;
                float num2 = pPt.Y;
                pMap.ConvertCoord(ref num, ref num2, ref pFlight.Path[index].node.D.x, ref pFlight.Path[index].node.D.y, ConversionConstants.miMapToScreen);
                pPt.Y = num2;
                pPt.X = num;
                PointF pointF = default(PointF);
                num2 = pointF.X;
                num = pointF.Y;
                pMap.ConvertCoord(ref num2, ref num, ref pFlight.Path[index].node.C.x, ref pFlight.Path[index].node.C.y, ConversionConstants.miMapToScreen);
                pointF.Y = num;
                pointF.X = num2;
                double num3 = CBasePath.getdistance(pointF, pPt);
                RectangleF rectangleF = new RectangleF((float)((double)pointF.X - num3), (float)((double)pointF.Y - num3), (float)(2.0 * num3), (float)(2.0 * num3));
                float startAngle = 0;
                if (pFlight.Path[index].node.Turn == TurnValue.Left)
                {
                    startAngle = (float)(pFlight.Path[index].node.hdgCD - pFlight.Path[index].node.yp);
                }
                else
                {
                    startAngle = (float)pFlight.Path[index].node.hdgCD;
                }
                CGraphicObjs cGraphicObjs = new CGraphicObjs();
                Color color = modHuanLuyen.defaTopTaColor;
                switch (pFlight.LoaiTopID)
                {
                    case 1:
                        color = modHuanLuyen.defaTopDichColor;
                        break;
                    case 2:
                        color = modHuanLuyen.defaTopTaColor;
                        break;
                    case 3:
                        color = modHuanLuyen.defaTopQuocTeColor;
                        break;
                    case 4:
                        color = modHuanLuyen.defaTopQuaCanhColor;
                        break;
                    default: //Bổ sung
                        color = modHuanLuyen.defaTopTaColor;
                        break;
                }

                PieGraphic pieGraphic = new PieGraphic(0f, 0f, rectangleF.Width / 2f, rectangleF.Height / 2f, 0f);
                PieGraphic pieGraphic2 = pieGraphic;
                pieGraphic2.Fill = false;
                pieGraphic2.FillColor = color;
                pieGraphic2.LineWidth = (float)modHuanLuyen.defaPathWidth;
                pieGraphic2.LineColor = color;
                pieGraphic2.Line2Width = 0f;
                pieGraphic2.Line2Color = color;
                pieGraphic2.IsArc = true;
                pieGraphic2.StartAngle = startAngle;
                pieGraphic2.SweepAngle = (float)pFlight.Path[index].node.yp;
                cGraphicObjs.Add(pieGraphic);
                cSymbol = new CSymbol(pMap, pointF, cGraphicObjs);
                cSymbol.Description = "VeThem VL" + index.ToString("00");
            }
            return cSymbol;
        }
        private CSymbol GetDuongThang(AxMap pMap, CFlight pFlight, int index)
        {
            CSymbol cSymbol = null;
            if (pFlight.Path[index].node.t2next + pFlight.Path[index].node.tspeed > 0.0)
            {
                PointF[] array = new PointF[2];
                PathNode node = pFlight.Path[checked(index + 1)].node;
                PointF[] array2 = array;
                int num = 1;
                float num2 = array2[num].X;
                PointF[] array3 = array;
                int num3 = 1;
                float num4 = array3[num3].Y;
                pMap.ConvertCoord(ref num2, ref num4, ref node.D.x, ref node.D.y, ConversionConstants.miMapToScreen);
                array3[num3].Y = num4;
                array2[num].X = num2;
                array3 = array;
                num3 = 0;
                num4 = array3[num3].X;
                array2 = array;
                num = 0;
                num2 = array2[num].Y;
                pMap.ConvertCoord(ref num4, ref num2, ref pFlight.Path[index].node.Dp.x, ref pFlight.Path[index].node.Dp.y, ConversionConstants.miMapToScreen);
                array2[num].Y = num2;
                array3[num3].X = num4;
                PointF pt = default(PointF);
                if (array.GetUpperBound(0) > 0)
                {
                    GraphicsPath graphicsPath = new GraphicsPath();
                    graphicsPath.AddLines(array);
                    RectangleF bounds = graphicsPath.GetBounds();
                    pt.X = (bounds.Left + bounds.Right) / 2f;
                    pt.Y = (bounds.Top + bounds.Bottom) / 2f;
                    int upperBound = array.GetUpperBound(0);
                    for (int i = 0; i <= upperBound; i = checked(i + 1))
                    {
                        array3 = array;
                        num3 = i;
                        array3[num3].X = array3[num3].X - pt.X;
                        array3 = array;
                        num3 = i;
                        array3[num3].Y = array3[num3].Y - pt.Y;
                    }
                    LinesGraphic linesGraphic = new LinesGraphic(array, 1f, Color.Red);
                    Color color = modHuanLuyen.defaTopTaColor;
                    switch (pFlight.LoaiTopID)
                    {
                        case 1:
                            color = modHuanLuyen.defaTopDichColor;
                            break;
                        case 2:
                            color = modHuanLuyen.defaTopTaColor;
                            break;
                        case 3:
                            color = modHuanLuyen.defaTopQuocTeColor;
                            break;
                        case 4:
                            color = modHuanLuyen.defaTopQuaCanhColor;
                            break;
                    }
                    LinesGraphic linesGraphic2 = linesGraphic;
                    linesGraphic2.Rotation = 0f;
                    linesGraphic2.LineWidth = (float)modHuanLuyen.defaPathWidth;
                    linesGraphic2.LineColor = color;
                    linesGraphic2.Line2Width = 0f;
                    linesGraphic2.Line2Color = color;
                    linesGraphic2.Fill = false;
                    linesGraphic2.FillColor = color;
                    linesGraphic2.LineStyle = modBdTC.defaGenLineStyle;
                    CGraphicObjs cGraphicObjs = new CGraphicObjs();
                    cGraphicObjs.Add(linesGraphic);
                    cSymbol = new CSymbol(pMap, pt, cGraphicObjs);
                    cSymbol.Description = "VeThem DT" + index.ToString("00");
                }
            }
            return cSymbol;
        }
        private List<CSymbol> GetDuongBay(AxMap pMap, CFlight pFlight)
        {
            List<CSymbol> list = new List<CSymbol>();
            if (pFlight.Path.Count > 0)
            {
                CSymbol cSymbol = this.GetDuongThang(pMap, pFlight, 0);
                if (cSymbol != null)
                {
                    list.Add(cSymbol);
                }
                //int 0 = 1;
                int num = pFlight.Path.Count - 2;
                for (int i = 0; i < num; i++)
                {
                    cSymbol = this.GetVongLuon(pMap, pFlight, i);
                    if (cSymbol != null)
                    {
                        list.Add(cSymbol);
                    }
                    cSymbol = this.GetDuongThang(pMap, pFlight, i);
                    if (cSymbol != null)
                    {
                        list.Add(cSymbol);
                    }
                }
            }
            return list;
        }
        private CSymbol GetTTDoan(AxMap pMap, int index, CFlight pFlight)
        {
            FlightNode flightNode = pFlight.Path[index];
            FlightNode flightNode2 = pFlight.Path[checked(index + 1)];
            PointF pPT = default(PointF);
            float num = pPT.X;
            float num2 = pPT.Y;
            pMap.ConvertCoord(ref num, ref num2, ref flightNode.node.Dp.x, ref flightNode.node.Dp.y, ConversionConstants.miMapToScreen);
            pPT.Y = num2;
            pPT.X = num;
            PointF pPT2 = default(PointF);
            num2 = pPT2.X;
            num = pPT2.Y;
            pMap.ConvertCoord(ref num2, ref num, ref flightNode2.node.D.x, ref flightNode2.node.D.y, ConversionConstants.miMapToScreen);
            pPT2.Y = num;
            pPT2.X = num2;
            PointF pt = default(PointF);
            pt.X = (pPT.X + pPT2.X) / 2f;
            pt.Y = (pPT.Y + pPT2.Y) / 2f;
            TimeSpan timeSpan = flightNode2.td.Subtract(flightNode.td);
            double num3 = 0.0;
            double hDG = modHuanLuyen.GetHDG(pPT, pPT2);
            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            Graphics graphics = pMap.CreateGraphics();
            Font font = new Font("Tahoma", 12f, FontStyle.Regular, GraphicsUnit.Point);
            float num4 = (float)((double)modBdTC.BDTyLeLayKH / 100.0);
            string text = (num3 / 1000.0).ToString("#.#");
            SizeF sizeF = graphics.MeasureString(text, font);
            string text2;
            SizeF sizeF2;
            float num7 = 0;
            int num5 = (int)Math.Round(timeSpan.TotalSeconds);
            int num6 = (int)Math.Round(Math.Floor(timeSpan.TotalSeconds / 60.0));
            int value = num5 - num6 * 60;
            text2 = string.Concat(new string[]
				{
					"",
					num6.ToString(),
					"'",
					value.ToString(),
					"\""
				});
            sizeF2 = graphics.MeasureString(text2, font);
            num7 = Convert.ToSingle(sizeF.Width > sizeF2.Width ? sizeF.Width : sizeF2.Width);
            float posX = ((num7 - sizeF.Width) / 2f + 1f) * num4;
            cGraphicObjs.Add(new TextGraphic(posX, -10f * num4, text, font, Color.Black)
            {
                Rotation = 0f,
                AutoSize = true
            });
            PointF[] array = new PointF[2];
            array[0].X = 0f;
            array[0].Y = 10f * num4;
            array[1].X = num7 * num4;
            array[1].Y = 10f * num4;
            cGraphicObjs.Add(new LinesGraphic(array, 1f, Color.Red)
            {
                Rotation = 0f,
                LineWidth = 1f,
                LineColor = Color.Black,
                Line2Width = 0f,
                Line2Color = Color.Black
            });
            text = hDG.ToString("#0");
            cGraphicObjs.Add(new TextGraphic(num7 * num4, 0f, text, font, Color.Red)
            {
                Rotation = 0f,
                AutoSize = true
            });
            posX = ((num7 - sizeF2.Width) / 2f + 1f) * num4;
            cGraphicObjs.Add(new TextGraphic(posX, 11f * num4, text2, font, Color.Black)
            {
                Rotation = 0f,
                AutoSize = true
            });
            return new CSymbol(pMap, pt, cGraphicObjs)
            {
                Description = "TTDoan " + index.ToString(),
                Heading = (float)hDG
            };
        }
        private List<CSymbol> GetTTDoans(AxMap pMap, CFlight pFlight)
		{
			List<CSymbol> list = new List<CSymbol>();
				if (pFlight.Path.Count > 0)
				{
					CSymbol tTDoan = this.GetTTDoan(pMap, 0, pFlight);
					if (tTDoan != null)
					{
						list.Add(tTDoan);
					}
					int 0 = 1;
					int num = pFlight.Path.Count - 2;
					for (int i = 0; i < num; i++)
					{
						if (pFlight.Path[i].nodetype == 0 & pFlight.Path[i + 1].nodetype == 0)
						{
							tTDoan = this.GetTTDoan(pMap, i, pFlight);
							if (tTDoan != null)
							{
								list.Add(tTDoan);
							}
						}
					}
				}
				return list;
					}
        public void AddTTDoans(AxMap pMap, CFlight pFlight)
        {
            this.PopUndo();
            List<CSymbol> tTDoans = this.GetTTDoans(pMap, pFlight);
            this.CalcSymbolZoom();
            foreach (CSymbol current in tTDoans)
            {
                current.ChangeZoomMWidtht(this.SymbolZoom, this.SymbolMapScreenWidth);
                this.m_DrawingSymbols.Add(current);
            }

            this.RefreshMap();
            this.m_ParentForm.ToolStripStatusLabel3.Text = "";
            CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
            if (listKHChangedEvent != null)
            {
                listKHChangedEvent(this.m_SelectedSymbol);
            }
        }
        private List<CSymbol> GetTGNodes(AxMap pMap, CFlight pFlight)
        {
            List<CSymbol> list = new List<CSymbol>();
            DateTime dateTime = pFlight.Departure;
            PointF[] array = new PointF[2];
            PointF pt = default(PointF);
            int num = 0;
            while (DateTime.Compare(dateTime, pFlight.Path[checked(pFlight.Path.Count - 1)].td) < 0)
            {
                dateTime = dateTime.AddMinutes(1.0);
                CMayBay mayBay;
                LinesGraphic linesGraphic;
                if (!(DateTime.Compare(dateTime, pFlight.Departure) > 0 & DateTime.Compare(dateTime, pFlight.Path[pFlight.Path.Count - 1].td) < 0))
                {
                    break;
                }
                mayBay = pFlight.getMayBay(pMap, dateTime);
                float x = pt.X;
                float y = pt.Y;
                pMap.ConvertCoord(ref x, ref y, ref mayBay.Pos.x, ref mayBay.Pos.y, ConversionConstants.miMapToScreen);
                pt.Y = y;
                pt.X = x;
                array[0].X = -3f;
                array[0].Y = 0f;
                array[1].X = 3f;
                array[1].Y = 0f;
                linesGraphic = new LinesGraphic(array, 1f, modBdTC.defaGenPen1C);
                num++;
                linesGraphic.Rotation = 0f;
                linesGraphic.LineColor = modBdTC.defaGenPen1C;
                linesGraphic.Line2Color = modBdTC.defaGenPen2C;
                linesGraphic.FillColor = modBdTC.defaGenFillC;
                linesGraphic.LineStyle = modBdTC.defaGenLineStyle;
                linesGraphic.LineWidth = (float)modBdTC.defaGenPen1W;
                linesGraphic.Line2Width = (float)modBdTC.defaGenPen2W;
                if (num % 3 == 0)
                {
                    LinesGraphic linesGraphic2 = linesGraphic;
                    linesGraphic2.LineWidth *= 3f;
                    linesGraphic2 = linesGraphic;
                    linesGraphic2.Line2Width *= 3f;
                }
                CGraphicObjs cGraphicObjs = new CGraphicObjs();
                cGraphicObjs.Add(linesGraphic);
                list.Add(new CSymbol(pMap, pt, cGraphicObjs)
                {
                    Description = "Phút " + num.ToString(),
                    Heading = mayBay.Rotation
                });
            }
            return list;
        }
        public void AddTGNode(AxMap pMap, CFlight pFlight)
        {
            //this.PopUndo();
            //List<CSymbol> tGNodes = this.GetTGNodes(pMap, pFlight);
            //this.CalcSymbolZoom();
            //foreach (CSymbol current in tGNodes)
            //{
            //    current.ChangeZoomMWidtht(this.SymbolZoom, this.SymbolMapScreenWidth);
            //    this.m_DrawingSymbols.Add(current);
            //}

            //this.RefreshMap();
            //this.m_ParentForm.ToolStripStatusLabel3.Text = "";
        }
        private void XoaSymbol(CSymbol pSymbol)
        {
            //if (pSymbol != null)
            //{
            //    int num = this.m_DrawingSymbols.get_IndexOf(pSymbol);
            //    this.m_DrawingSymbols.Remove(pSymbol);
            //    if (num >= this.m_DrawingSymbols.ListCount)
            //    {
            //        num--;
            //    }
            //    if (num >= 0)
            //    {
            //        pSymbol = this.m_DrawingSymbols[num];
            //    }
            //    else
            //    {
            //        pSymbol = null;
            //    }
            //}
        }
        public void XoaVeThem()
        {
            List<CSymbol> list = new List<CSymbol>();
            foreach (CSymbol cSymbol in this.m_DrawingSymbols)
            {
                if (cSymbol.Description.Contains("VeThem") | cSymbol.Description.Contains("Phút "))
                {
                    list.Add(cSymbol);
                }
            }

            this.PopUndo();
            foreach (CSymbol current in list)
            {
                this.XoaSymbol(current);
            }

        }
        public void OnXoa()
        {
            if (this.m_SelectedSymbol != null)
            {
                this.PopUndo();
                int num = this.m_DrawingSymbols.get_IndexOf(this.m_SelectedSymbol);
                this.m_DrawingSymbols.Remove(this.m_SelectedSymbol);
                if (num >= this.m_DrawingSymbols.ListCount)
                {
                    num--;
                }
                if (num >= 0)
                {
                    this.m_SelectedSymbol = this.m_DrawingSymbols[num];
                }
                else
                {
                    this.m_SelectedSymbol = null;
                }
                this.RefreshMap();
                CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
                if (listKHChangedEvent != null)
                {
                    listKHChangedEvent(this.m_SelectedSymbol);
                }
            }
        }
        public void OnXoaTat()
        {
            this.PopUndo();
            this.m_SelectedSymbol = null;
            this.m_DrawingSymbols.Clear();
            this.RefreshMap();
            CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
            if (listKHChangedEvent != null)
            {
                listKHChangedEvent(this.m_SelectedSymbol);
            }
        }
        public void KHsFromString(string strKyHieus)
        {
            CSymbols cSymbols = CSymbols.String2KHs(strKyHieus);
            CSymbols drawingSymbols = this.m_DrawingSymbols;
            lock (drawingSymbols)
            {
                this.m_DrawingSymbols.Clear();
                foreach (CSymbol aSymbol in cSymbols)
                {
                    this.m_DrawingSymbols.Add(aSymbol);
                }

            }
            this.XoaUndoStack();
            CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
            if (listKHChangedEvent != null)
            {
                listKHChangedEvent(this.m_SelectedSymbol);
            }
        }
        public void NhapNhaySymbol(CSymbol pSymbol, int pLan)
        {
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.DiagonalCross, Color.Red, Color.Transparent);
            HatchBrush hatchBrush2 = new HatchBrush(HatchStyle.DiagonalCross, Color.White, Color.Transparent);
            Pen pen = new Pen(Color.White, 2f);
            pen.Brush = hatchBrush;
            Pen pen2 = new Pen(Color.Red, 2f);
            pen2.Brush = hatchBrush2;
            try
            {
                Graphics g = this.m_Map.CreateGraphics();
                for (int i = 0; i < pLan; i++)
                {
                    pSymbol.DanhDau(this.m_Map, g, pen);
                    Thread.Sleep(40);
                    Application.DoEvents();
                    pSymbol.DanhDau(this.m_Map, g, pen2);
                    Thread.Sleep(40);
                    Application.DoEvents();
                    this.m_Map.Refresh();
                }
            }
            catch (Exception arg_B4_0)
            {
                throw arg_B4_0;
            }
            finally
            {
                hatchBrush.Dispose();
                hatchBrush2.Dispose();
                pen.Dispose();
                pen2.Dispose();
            }
        }
        private void DrawDrawingLine(PointF[] pPts)
        {
            Graphics graphics = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            Pen pen = new Pen(Color.FromArgb(75, Color.Gray), 2f);
            int upperBound = pPts.GetUpperBound(0);
            System.Drawing.Point[] array = new System.Drawing.Point[upperBound + 1];
            int num = upperBound;
            for (int i = 0; i < num; i++)
            {
                array[i].X = (int)Math.Round((double)pPts[i].X);
                array[i].Y = (int)Math.Round((double)pPts[i].Y);
            }
            switch (this.myMapTool)
            {
                case CBdTC.MapTools.Polygon:
                    if (pPts.GetUpperBound(0) > 1)
                    {
                        graphics.DrawPolygon(pen, array);
                        goto IL_12D;
                    }
                    graphics.DrawLines(pen, array);
                    goto IL_12D;
                case CBdTC.MapTools.Curve:
                case CBdTC.MapTools.SongSong:
                    graphics.DrawCurve(pen, array);
                    goto IL_12D;
                case CBdTC.MapTools.ClosedCurve:
                case CBdTC.MapTools.SongSongKin:
                    if (pPts.GetUpperBound(0) > 1)
                    {
                        graphics.DrawClosedCurve(pen, array);
                        goto IL_12D;
                    }
                    graphics.DrawLines(pen, array);
                    goto IL_12D;
            }
            graphics.DrawLines(pen, array);
        IL_12D:
            pen.Dispose();
        }
        private void DrawMovingSymbol(CSymbol seleSymbol)
        {
            Graphics g = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            seleSymbol.Draw(this.m_Map, g);
        }
        private void DrawMovingSymbols(CSymbols seleSymbols)
        {
            Graphics g = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            foreach (CSymbol cSymbol in seleSymbols)
            {
                cSymbol.Draw(this.m_Map, g);
            }

        }
        private void DrawMovingNode(CSymbol seleSymbol)
        {
            Graphics g = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            seleSymbol.Draw(this.m_Map, g);
            seleSymbol.DrawNodes(this.m_Map, g);
        }
        private void DrawMovingRoot(CSymbol seleSymbol)
        {
            Graphics g = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            seleSymbol.Draw(this.m_Map, g);
            seleSymbol.DrawRoot(this.m_Map, g);
        }
        private void DrawRotatingSymbol(ref CSymbol seleSymbol, PointF dragPoint)
        {
            Graphics graphics = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            Pen pen = new Pen(Color.FromArgb(75, Color.Gray), 3f);
            seleSymbol.Draw(this.m_Map, graphics);
            PointF[] array = new PointF[2];
            array[0].X = this.myrootPt.X;
            array[0].Y = this.myrootPt.Y;
            array[1].X = dragPoint.X;
            array[1].Y = dragPoint.Y;
            pen.EndCap = LineCap.ArrowAnchor;
            pen.StartCap = LineCap.RoundAnchor;
            graphics.DrawLine(pen, array[0], array[1]);
            pen.Dispose();
        }
        private void DrawSplittingLine(PointF dragPoint)
        {
            Graphics graphics = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            Pen pen = new Pen(Color.FromArgb(75, Color.Gray), 3f);
            PointF[] array = new PointF[2];
            array[0].X = this.myfromPt.X;
            array[0].Y = this.myfromPt.Y;
            array[1].X = dragPoint.X;
            array[1].Y = dragPoint.Y;
            graphics.DrawLine(pen, array[0], array[1]);
            pen.Dispose();
        }
        private void DrawSelectionRectangle(RectangleF selectionRect)
        {
            Graphics graphics = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            SolidBrush brush = new SolidBrush(Color.FromArgb(75, Color.Gray));
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF();
            //rect.Size = selectionRect.Size;
            //rect.Size = new SizeF(selectionRect.Size.Width, selectionRect.Size.Height);
            rect.Size = new SizeF(selectionRect.Size);
            if (selectionRect.Width < 0f)
            {
                rect.X = selectionRect.X - rect.Width;
            }
            else
            {
                rect.X = selectionRect.X;
            }
            if (selectionRect.Height < 0f)
            {
                rect.Y = selectionRect.Y - rect.Height;
            }
            else
            {
                rect.Y = selectionRect.Y;
            }
            graphics.FillRectangle(brush, rect);
        }
        private void DrawDrawingRectangle(System.Drawing.Rectangle DrawingRect)
        {
            Graphics graphics = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            Pen pen = new Pen(Color.FromArgb(75, Color.Gray), 2f);
            Rectangle rect = new Rectangle();
            rect.Size = DrawingRect.Size;
            if (DrawingRect.Width < 0)
            {
                rect.X = DrawingRect.X - rect.Width;
            }
            else
            {
                rect.X = DrawingRect.X;
            }
            if (DrawingRect.Height < 0)
            {
                rect.Y = DrawingRect.Y - rect.Height;
            }
            else
            {
                rect.Y = DrawingRect.Y;
            }
            graphics.DrawRectangle(pen, rect);
            pen.Dispose();
        }
        private void DrawDrawingArc(System.Drawing.Rectangle DrawingRect)
        {
            Graphics g = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            PointF pointF = default(PointF);
            PointF[] array = new PointF[4];
            array[1].X = (float)DrawingRect.X;
            array[1].Y = (float)DrawingRect.Y;
            array[2].X = (float)(DrawingRect.X + DrawingRect.Width);
            array[2].Y = (float)DrawingRect.Y;
            array[3].X = (float)(DrawingRect.X + DrawingRect.Width);
            array[3].Y = (float)(DrawingRect.Y + DrawingRect.Height);
            array[0].X = (float)DrawingRect.X;
            array[0].Y = (float)(DrawingRect.Y + DrawingRect.Height);
            NodesShapeGraphic nodesShapeGraphic = new LinesGraphic(array, 1f, Color.Red);
            nodesShapeGraphic.Fill = false;
            nodesShapeGraphic.FillColor = modBdTC.defaGenFillC;
            nodesShapeGraphic.Rotation = 0f;
            nodesShapeGraphic.LineWidth = (float)modBdTC.defaGenPen1W;
            nodesShapeGraphic.LineColor = modBdTC.defaGenPen1C;
            nodesShapeGraphic.Line2Width = (float)modBdTC.defaGenPen2W;
            nodesShapeGraphic.Line2Color = modBdTC.defaGenPen2C;
            nodesShapeGraphic.LineStyle = modBdTC.defaGenLineStyle;
            nodesShapeGraphic.StyleWidth = 8f;
            nodesShapeGraphic.Nodes[1].IsControl = true;
            nodesShapeGraphic.Nodes[2].IsControl = true;
            nodesShapeGraphic.Draw(g);
        }
        private void DrawDrawingEllipse(System.Drawing.Rectangle DrawingRect)
        {
            Graphics graphics = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            Pen pen = new Pen(Color.FromArgb(75, Color.Gray), 2f);
            graphics.DrawEllipse(pen, DrawingRect);
            pen.Dispose();
        }
        private bool DrawDrawingPie(System.Drawing.Rectangle DrawingRect)
        {
            bool result;
            try
            {
                Graphics graphics = this.m_Map.CreateGraphics();
                this.m_Map.Refresh();
                Pen pen = new Pen(Color.FromArgb(75, Color.Gray), 2f);
                System.Drawing.Rectangle rect = checked(new System.Drawing.Rectangle(DrawingRect.Left - DrawingRect.Width, DrawingRect.Top - DrawingRect.Height, DrawingRect.Width * 2, DrawingRect.Height * 2));
                graphics.DrawPie(pen, rect, 0f, 90f);
                pen.Dispose();
                result = true;
            }
            catch (Exception arg_81_0)
            {
                throw arg_81_0;
                result = false;
            }
            return result;
        }
        public void m_Map_DrawUserLayer(object sender, CMapXEvents_DrawUserLayerEvent e)
        {
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.DiagonalCross, Color.White, Color.Transparent);
            Pen pen = new Pen(Color.Blue, 4f);
            pen.Brush = hatchBrush;
            IntPtr hdc = new IntPtr(e.hOutputDC);
            Graphics graphics = Graphics.FromHdc(hdc);
            try
            {
                this.m_DrawingSymbols.DrawSymbols(this.m_Map, graphics);
                if (this.m_SelectedSymbol != null)
                {
                    if (this.myMapTool == CBdTC.MapTools.NodesEdit)
                    {
                        this.m_SelectedSymbol.DrawNodes(this.m_Map, graphics);
                    }
                    else if (this.myMapTool == CBdTC.MapTools.ChangeRoot)
                    {
                        this.m_SelectedSymbol.DrawRoot(this.m_Map, graphics);
                    }
                    else
                    {
                        this.m_SelectedSymbol.DanhDau(this.m_Map, graphics, modBdTC.DanhDauColor);
                        this.m_SelectedSymbol.DanhDau(this.m_Map, graphics, pen);
                    }
                }
                if (this.m_SelectedSymbols.Count > 0)
                {
                    foreach (CSymbol cSymbol in this.m_SelectedSymbols)
                    {
                        cSymbol.VeBound(this.m_Map, graphics, modBdTC.VeBoundColor);
                    }

                }
            }
            catch (Exception expr_11C)
            {
                throw expr_11C;
                Exception innerException = expr_11C;
                throw new ApplicationException("Error Drawing Graphics Surface", innerException);
            }
            finally
            {
                pen.Dispose();
                hatchBrush.Dispose();
            }
            if (this.bGrid)
            {
                this.GridSize.Width = this.myGridWidth;
                this.GridSize.Height = this.myGridWidth;
                this.GridRect.Width = (int)Math.Round((double)this.m_Map.MapScreenWidth);
                this.GridRect.Height = (int)Math.Round((double)this.m_Map.MapScreenHeight);
                ControlPaint.DrawGrid(graphics, this.GridRect, this.GridSize, Color.Red);
            }
        }
        public void m_Map_MouseDownEvent(object sender, CMapXEvents_MouseDownEvent e)
        {
            System.Drawing.Point point = 0;
            if (this.bSnap)
            {
                point = this.Snap(e.x, e.y);
            }
            else
            {
                point = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
            }
            switch (this.myMapTool)
            {
                case CBdTC.MapTools.None:
                    if (e.button == 1)
                    {
                        if (e.shift == 1)
                        {
                            this.selectionDragging = true;
                            this.selectionRect.X = e.x;
                            this.selectionRect.Y = e.y;
                            this.selectionRect.Height = 0f;
                            this.selectionRect.Width = 0f;
                        }
                        else if (e.shift == 3)
                        {
                            PointF pointF = new PointF(e.x, e.y);
                            CSymbol cSymbol = this.m_DrawingSymbols.FindSymbolAtPoint(this.m_Map, pointF);
                            if (cSymbol != null)
                            {
                                bool flag = false;
                                foreach (CSymbol cSymbol2 in this.m_SelectedSymbols)
                                {
                                    if (cSymbol2 == cSymbol)
                                    {
                                        flag = true;
                                    }
                                }

                                if (flag)
                                {
                                    this.m_SelectedSymbols.Remove(cSymbol);
                                }
                                else
                                {
                                    this.m_SelectedSymbols.Add(cSymbol);
                                }
                                this.RefreshMap();
                            }
                        }
                        else
                        {
                            this.m_SelectedSymbols.Clear();
                            PointF pointF = new PointF(e.x, e.y);
                            this.SelectedSymbol = this.m_DrawingSymbols.FindSymbolAtPoint(this.m_Map, pointF);
                            if (this.m_SelectedSymbol != null)
                            {
                                CBdTC.SelectedSymbolChangedEventHandler selectedSymbolChangedEvent = this.SelectedSymbolChangedEvent;
                                if (selectedSymbolChangedEvent != null)
                                {
                                    selectedSymbolChangedEvent(this.m_SelectedSymbol);
                                }
                                switch (e.shift)
                                {
                                    case 2:
                                        this.PopUndo();
                                        this.myMapTool = CBdTC.MapTools.DangMove;
                                        this.myfromPt = new PointF((float)point.X, (float)point.Y);
                                        this.mytoPt = new PointF((float)point.X, (float)point.Y);
                                        break;
                                    case 4:
                                        {
                                            this.PopUndo();
                                            this.myMapTool = CBdTC.MapTools.DangRotate;
                                            this.myfromPt = new PointF((float)point.X, (float)point.Y);
                                            this.mytoPt = new PointF((float)point.X, (float)point.Y);
                                            this.myrootPt = default(PointF);
                                            float num = this.myrootPt.X;
                                            float num2 = this.myrootPt.Y;
                                            CSymbol selectedSymbol = this.m_SelectedSymbol;
                                            double num3 = selectedSymbol.GocX;
                                            CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                                            double num4 = selectedSymbol2.GocY;
                                            this.m_Map.ConvertCoord(ref num, ref num2, ref num3, ref num4, ConversionConstants.miMapToScreen);
                                            selectedSymbol2.GocY = num4;
                                            selectedSymbol.GocX = num3;
                                            this.myrootPt.Y = num2;
                                            this.myrootPt.X = num;
                                            pointF = new PointF((float)point.X, (float)point.Y);
                                            this.DrawRotatingSymbol(ref this.m_SelectedSymbol, pointF);
                                            break;
                                        }
                                    case 6:
                                        {
                                            this.PopUndo();
                                            this.myMapTool = CBdTC.MapTools.DangScale;
                                            this.myfromPt = new PointF((float)point.X, (float)point.Y);
                                            this.mytoPt = new PointF((float)point.X, (float)point.Y);
                                            this.myrootPt = default(PointF);
                                            float num2 = this.myrootPt.X;
                                            float num = this.myrootPt.Y;
                                            CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                                            double num4 = selectedSymbol2.GocX;
                                            CSymbol selectedSymbol = this.m_SelectedSymbol;
                                            double num3 = selectedSymbol.GocY;
                                            this.m_Map.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                                            selectedSymbol.GocY = num3;
                                            selectedSymbol2.GocX = num4;
                                            this.myrootPt.Y = num;
                                            this.myrootPt.X = num2;
                                            pointF = new PointF((float)point.X, (float)point.Y);
                                            this.DrawRotatingSymbol(ref this.m_SelectedSymbol, pointF);
                                            break;
                                        }
                                }
                            }
                        }
                    }
                    else
                    {
                        CBdTC.MapTools mapTools = this.myMapTool;
                        if (mapTools == CBdTC.MapTools.None)
                        {
                            if (this.m_SelectedSymbols.Count > 0)
                            {
                                System.Drawing.Point location = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                this.CxtMnuGroup.Show(this.m_Panel, location);
                            }
                            else
                            {
                                PointF pointF = new PointF(e.x, e.y);
                                this.FoundObject = this.m_DrawingSymbols.FindObjectAtPoint(this.m_Map, pointF);
                                if (this.FoundObject != null)
                                {
                                    this.m_Map.Refresh();
                                    this.m_SelectedObject = this.FoundObject.FoundObject;
                                    this.m_SelectedSymbol = this.FoundObject.FoundSymbol;
                                    this.FoundObject.FoundSymbol.DanhDau(this.m_Map, this.m_Map.CreateGraphics(), modBdTC.DanhDauColor);
                                    this.FoundObject.FoundSymbol.VeBound(this.m_Map, this.m_Map.CreateGraphics(), modBdTC.VeBoundColor);
                                    this.FoundObject.FoundSymbol.VeBound(this.m_Map, this.m_Map.CreateGraphics(), this.m_SelectedObject, modBdTC.VeBoundColor);
                                    this.FoundObject.FoundSymbol.DanhDau(this.m_Map, this.m_Map.CreateGraphics(), this.m_SelectedObject, modBdTC.DanhDauColor2);
                                    System.Drawing.Point location = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                    this.CxtMnuKyHieu.Show(this.m_Panel, location);
                                }
                                else
                                {
                                    this.mousePos = new PointF((float)point.X, (float)point.Y);
                                    System.Drawing.Point location = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                    this.CxtMnuMap.Show(this.m_Panel, location);
                                }
                            }
                        }
                    }
                    break;
                case CBdTC.MapTools.Polygon:
                case CBdTC.MapTools.Line:
                case CBdTC.MapTools.Curve:
                case CBdTC.MapTools.ClosedCurve:
                case CBdTC.MapTools.MuiTenDon:
                case CBdTC.MapTools.MuiTen:
                case CBdTC.MapTools.MuiTenDac:
                case CBdTC.MapTools.MuiTenHo:
                case CBdTC.MapTools.SongSong:
                case CBdTC.MapTools.SongSongKin:
                    if (e.button == 1)
                    {
                        if (!this.DrawingPicking)
                        {
                            this.DrawingPicking = true;
                            this.myPts = new PointF[2];
                            this.myPts[0] = new PointF((float)point.X, (float)point.Y);
                            this.myPts[1] = new PointF((float)point.X, (float)point.Y);
                        }
                        else
                        {
                            //int num5 = this.myPts.GetUpperBound(0);
                            //num5++;
                            //this.myPts = (PointF[])Utils.CopyArray((Array)this.myPts, new PointF[num5 + 1]);
                            //this.myPts[num5] = new PointF((float)point.X, (float)point.Y);
                        }
                    }
                    else
                    {
                        if (this.myPts.GetUpperBound(0) > 0)
                        {
                            this.AddNewObj(e.shift);
                        }
                        this.DrawingPicking = false;
                        this.OnCapNhatKH();
                    }
                    break;
                case CBdTC.MapTools.Cycle:
                case CBdTC.MapTools.Rectangle:
                case CBdTC.MapTools.arc:
                    if (e.button == 1)
                    {
                        this.DrawingDragging = true;
                        this.DrawingRect.X = point.X;
                        this.DrawingRect.Y = point.Y;
                        this.DrawingRect.Height = 0;
                        this.DrawingRect.Width = 0;
                    }
                    break;
                case CBdTC.MapTools.Text:
                    {
                        //this.myPts = new PointF[1];
                        //this.myPts[0] = new PointF((float)point.X, (float)point.Y);
                        //this.AddNewObj(e.shift);
                        //dlgChangeText dlgChangeText = new dlgChangeText();
                        //dlgChangeText.myObj = (TextGraphic)this.m_DrawingSymbols[this.m_DrawingSymbols.Count - 1].GObjs[0];
                        //System.Drawing.Point location = this.m_ParentForm.Location;
                        //System.Drawing.Point pos = new System.Drawing.Point(location.X + this.m_Panel.Left + point.X, this.m_ParentForm.Location.Y + this.m_Panel.Top + point.Y);
                        //dlgChangeText.Pos = pos;
                        //dlgChangeText.ShowDialog(this.m_ParentForm);
                        //this.RefreshMap();
                        //this.OnCapNhatKH();
                        break;
                    }
                case CBdTC.MapTools.Table:
                    this.myPts = new PointF[1];
                    this.myPts[0] = new PointF((float)point.X, (float)point.Y);
                    this.AddNewObj(e.shift);
                    this.OnCapNhatKH();
                    break;
                case CBdTC.MapTools.Move:
                    this.PopUndo();
                    this.myMapTool = CBdTC.MapTools.DangMove;
                    this.myfromPt = new PointF((float)point.X, (float)point.Y);
                    this.mytoPt = new PointF((float)point.X, (float)point.Y);
                    break;
                case CBdTC.MapTools.Scale:
                    {
                        this.PopUndo();
                        this.myMapTool = CBdTC.MapTools.DangScale;
                        this.myfromPt = new PointF((float)point.X, (float)point.Y);
                        this.mytoPt = new PointF((float)point.X, (float)point.Y);
                        this.myrootPt = default(PointF);
                        float num2 = this.myrootPt.X;
                        float num = this.myrootPt.Y;
                        CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                        double num4 = selectedSymbol2.GocX;
                        CSymbol selectedSymbol = this.m_SelectedSymbol;
                        double num3 = selectedSymbol.GocY;
                        this.m_Map.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                        selectedSymbol.GocY = num3;
                        selectedSymbol2.GocX = num4;
                        this.myrootPt.Y = num;
                        this.myrootPt.X = num2;
                        PointF pointF = new PointF((float)point.X, (float)point.Y);
                        this.DrawRotatingSymbol(ref this.m_SelectedSymbol, pointF);
                        break;
                    }
                case CBdTC.MapTools.Rotate:
                    {
                        this.PopUndo();
                        this.myMapTool = CBdTC.MapTools.DangRotate;
                        this.myfromPt = new PointF((float)point.X, (float)point.Y);
                        this.mytoPt = new PointF((float)point.X, (float)point.Y);
                        this.myrootPt = default(PointF);
                        float num2 = this.myrootPt.X;
                        float num = this.myrootPt.Y;
                        CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                        double num4 = selectedSymbol2.GocX;
                        CSymbol selectedSymbol = this.m_SelectedSymbol;
                        double num3 = selectedSymbol.GocY;
                        this.m_Map.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                        selectedSymbol.GocY = num3;
                        selectedSymbol2.GocX = num4;
                        this.myrootPt.Y = num;
                        this.myrootPt.X = num2;
                        PointF pointF = new PointF((float)point.X, (float)point.Y);
                        this.DrawRotatingSymbol(ref this.m_SelectedSymbol, pointF);
                        break;
                    }
                case CBdTC.MapTools.GrMove:
                    this.PopUndo();
                    this.myMapTool = CBdTC.MapTools.GrDangMove;
                    this.myfromPt = new PointF((float)point.X, (float)point.Y);
                    this.mytoPt = new PointF((float)point.X, (float)point.Y);
                    break;
                case CBdTC.MapTools.Split:
                    {
                        this.PopUndo();
                        this.myMapTool = CBdTC.MapTools.DangSplit;
                        this.myfromPt = new PointF((float)point.X, (float)point.Y);
                        this.mytoPt = new PointF((float)point.X, (float)point.Y);
                        this.myrootPt = default(PointF);
                        float num2 = this.myrootPt.X;
                        float num = this.myrootPt.Y;
                        CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                        double num4 = selectedSymbol2.GocX;
                        CSymbol selectedSymbol = this.m_SelectedSymbol;
                        double num3 = selectedSymbol.GocY;
                        this.m_Map.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                        selectedSymbol.GocY = num3;
                        selectedSymbol2.GocX = num4;
                        this.myrootPt.Y = num;
                        this.myrootPt.X = num2;
                        PointF pointF = new PointF((float)point.X, (float)point.Y);
                        this.DrawSplittingLine(pointF);
                        break;
                    }
                case CBdTC.MapTools.NodesEdit:
                    {
                        PointF pointF = new PointF(e.x, e.y);
                        this.FoundNode = this.m_SelectedSymbol.FindNodeAtPoint(this.m_Map, pointF);
                        if (this.FoundNode != null)
                        {
                            this.PopUndo();
                            if (e.button == 1)
                            {
                                this.NodeDragging = true;
                                this.myfromPt = new PointF((float)point.X, (float)point.Y);
                                this.mytoPt = new PointF((float)point.X, (float)point.Y);
                            }
                            else
                            {
                                System.Drawing.Point location = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                this.CxtMnuNodeEdit.Show(this.m_Panel, location);
                            }
                        }
                        else
                        {
                            this.OnCapNhatKH();
                        }
                        break;
                    }
                case CBdTC.MapTools.ChangeRoot:
                    {
                        PointF pointF = new PointF(e.x, e.y);
                        if (this.m_SelectedSymbol.RootHitTest(this.m_Map, pointF))
                        {
                            this.PopUndo();
                            this.RootDragging = true;
                            this.myfromPt = new PointF((float)point.X, (float)point.Y);
                            this.mytoPt = new PointF((float)point.X, (float)point.Y);
                        }
                        else
                        {
                            this.OnCapNhatKH();
                        }
                        break;
                    }
            }
        }
        public void m_Map_MouseMoveEvent(object sender, CMapXEvents_MouseMoveEvent e)
        {
            System.Drawing.Point point = 0;
            if (this.bSnap)
            {
                point = this.Snap(e.x, e.y);
            }
            else
            {
                point = checked(new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y)));
            }
            if (this.selectionDragging)
            {
                this.selectionRect.Width = e.x - this.selectionRect.X;
                this.selectionRect.Height = e.y - this.selectionRect.Y;
                this.DrawSelectionRectangle(this.selectionRect);
            }
            if (this.m_SelectedSymbols.Count > 0 && this.myMapTool == CBdTC.MapTools.GrDangMove)
            {
                this.mytoPt = new PointF((float)point.X, (float)point.Y);
                foreach (CSymbol cSymbol in this.m_SelectedSymbols)
                {
                    cSymbol.Move(this.m_Map, this.myfromPt, this.mytoPt);
                }

                this.myfromPt = this.mytoPt;
                this.DrawMovingSymbols(this.m_SelectedSymbols);
            }
            if (modBdTC.fCacKyHieu != null && this.myMapTool == CBdTC.MapTools.DangLayKH)
            {
                if (this.m_KHfromVeKH == null)
                {
                    this.myfromPt = new PointF((float)point.X, (float)point.Y);
                    float pTyLe = 1f;
                    try
                    {
                        pTyLe = Convert.ToSingle(modBdTC.fCacKyHieu.txtTyLe.Text);
                    }
                    catch (Exception expr_196)
                    {
                        throw expr_196;
                    }
                    this.m_KHfromVeKH = this.GetKHfromVeKH(modBdTC.fCacKyHieu.txtTenKH.Text, modBdTC.fCacKyHieu.OdrawingObjects, modBdTC.fCacKyHieu.myORootX, modBdTC.fCacKyHieu.myORootY, this.myfromPt, pTyLe);
                }
                this.mytoPt = new PointF((float)point.X, (float)point.Y);
                this.m_KHfromVeKH.Move(this.m_Map, this.myfromPt, this.mytoPt);
                this.myfromPt = this.mytoPt;
                this.DrawMovingSymbol(this.m_KHfromVeKH);
            }
            if (this.m_SelectedSymbol != null)
            {
                if (this.myMapTool == CBdTC.MapTools.DangMove)
                {
                    this.mytoPt = new PointF((float)point.X, (float)point.Y);
                    this.m_SelectedSymbol.Move(this.m_Map, this.myfromPt, this.mytoPt);
                    this.myfromPt = this.mytoPt;
                    this.DrawMovingSymbol(this.m_SelectedSymbol);
                }
                else if (this.myMapTool == CBdTC.MapTools.DangRotate)
                {
                    this.mytoPt = new PointF((float)point.X, (float)point.Y);
                    this.m_SelectedSymbol.Rotate(this.m_Map, this.myrootPt, this.myfromPt, this.mytoPt);
                    this.myfromPt = this.mytoPt;
                    this.DrawRotatingSymbol(ref this.m_SelectedSymbol, this.mytoPt);
                }
                else if (this.myMapTool == CBdTC.MapTools.DangScale)
                {
                    this.mytoPt = new PointF((float)point.X, (float)point.Y);
                    this.m_SelectedSymbol.Rotate(this.m_Map, this.myrootPt, this.myfromPt, this.mytoPt);
                    this.m_SelectedSymbol.Scale(this.m_Map, this.myrootPt, this.myfromPt, this.mytoPt);
                    this.myfromPt = this.mytoPt;
                    this.DrawRotatingSymbol(ref this.m_SelectedSymbol, this.mytoPt);
                }
                else if (this.myMapTool == CBdTC.MapTools.DangSplit)
                {
                    this.mytoPt = new PointF((float)point.X, (float)point.Y);
                    this.DrawSplittingLine(this.mytoPt);
                }
                else if (this.myMapTool == CBdTC.MapTools.NodesEdit)
                {
                    this.mytoPt = new PointF((float)point.X, (float)point.Y);
                    if (this.NodeDragging)
                    {
                        PointF pt = new PointF(e.x, e.y);
                        CFOUNDNODE cFOUNDNODE = this.m_SelectedSymbol.FindNodeAtPoint(this.m_Map, pt);
                        if (cFOUNDNODE != null)
                        {
                            if (cFOUNDNODE.FoundObject == this.FoundNode.FoundObject)
                            {
                                if (cFOUNDNODE.NodeIndex != this.FoundNode.NodeIndex)
                                {
                                    PointF[] points = cFOUNDNODE.FoundObject.GetPoints();
                                    PointF pt2 = points[cFOUNDNODE.NodeIndex];
                                    this.FoundNode.FoundObject.MoveNodeTo(this.FoundNode.NodeIndex, pt2);
                                    this.DrawMovingNode(this.m_SelectedSymbol);
                                }
                            }
                            else
                            {
                                PointF[] points2 = cFOUNDNODE.FoundObject.GetPoints();
                                PointF pt3 = points2[cFOUNDNODE.NodeIndex];
                                this.FoundNode.FoundObject.MoveNodeTo(this.FoundNode.NodeIndex, pt3);
                                this.DrawMovingNode(this.m_SelectedSymbol);
                            }
                        }
                        else
                        {
                            this.m_SelectedSymbol.MoveNodeTo(this.m_Map, this.FoundNode, this.mytoPt);
                            this.DrawMovingNode(this.m_SelectedSymbol);
                        }
                    }
                }
                else if (this.myMapTool == CBdTC.MapTools.ChangeRoot)
                {
                    this.mytoPt = new PointF((float)point.X, (float)point.Y);
                    if (this.RootDragging)
                    {
                        float x = this.mytoPt.X;
                        float y = this.mytoPt.Y;
                        double newGocX = 0;
                        double newGocY = 0;
                        this.m_Map.ConvertCoord(ref x, ref y, ref newGocX, ref newGocY, ConversionConstants.miScreenToMap);
                        this.mytoPt.Y = y;
                        this.mytoPt.X = x;
                        this.m_SelectedSymbol.ChangeRoot(this.m_Map, newGocX, newGocY);
                        this.DrawMovingRoot(this.m_SelectedSymbol);
                    }
                }
            }
            else
            {
                if (this.DrawingPicking)
                {
                    int upperBound = this.myPts.GetUpperBound(0);
                    this.myPts[upperBound].X = (float)point.X;
                    this.myPts[upperBound].Y = (float)point.Y;
                    this.DrawDrawingLine(this.myPts);
                }
                if (this.DrawingDragging)
                {
                    this.DrawingRect.Width = point.X - this.DrawingRect.X;
                    this.DrawingRect.Height = point.Y - this.DrawingRect.Y;
                    if (this.myMapTool == CBdTC.MapTools.Cycle)
                    {
                        this.DrawDrawingEllipse(this.DrawingRect);
                    }
                    else if (this.myMapTool == CBdTC.MapTools.Rectangle)
                    {
                        this.DrawDrawingRectangle(this.DrawingRect);
                    }
                    else if (this.myMapTool == CBdTC.MapTools.arc)
                    {
                        this.DrawDrawingArc(this.DrawingRect);
                    }
                }
            }
        }
        public void m_Map_MouseUpEvent(object sender, CMapXEvents_MouseUpEvent e)
        {
            if (this.bSnap)
            {
                System.Drawing.Point point = this.Snap(e.x, e.y);
            }
            else
            {
                System.Drawing.Point point = checked(new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y)));
            }
            if (modBdTC.fCacKyHieu != null && this.myMapTool == CBdTC.MapTools.DangLayKH && e.button == 1)
            {
                this.PopUndo();
                ToolStripStatusLabel toolStripStatusLabel = this.m_ParentForm.ToolStripStatusLabel3;
                toolStripStatusLabel.Text = toolStripStatusLabel.Text + ". Shift=" + e.shift.ToString();
                this.AddFromVeKH();
                this.NhanKHXong();
            }
            if (e.button == 1)
            {
                if (this.m_SelectedSymbols.Count > 0 && this.myMapTool == CBdTC.MapTools.GrDangMove)
                {
                    this.OnCapNhatKH();
                    this.m_SelectedSymbols.Clear();
                }
                if (this.m_SelectedSymbol != null)
                {
                    if (this.myMapTool == CBdTC.MapTools.DangMove)
                    {
                        this.OnCapNhatKH();
                    }
                    else if (this.myMapTool == CBdTC.MapTools.DangRotate)
                    {
                        this.OnCapNhatKH();
                    }
                    else if (this.myMapTool == CBdTC.MapTools.DangScale)
                    {
                        this.OnCapNhatKH();
                    }
                    else if (this.myMapTool == CBdTC.MapTools.DangSplit)
                    {
                        CBdTC.SPLITSYMBOLS sPLITSYMBOLS = this.To2Symbols(this.m_SelectedSymbol, this.myfromPt, this.mytoPt);
                        this.m_DrawingSymbols.Remove(this.m_SelectedSymbol);
                        if (sPLITSYMBOLS.Symbol1 != null)
                        {
                            this.m_DrawingSymbols.Add(sPLITSYMBOLS.Symbol1);
                            this.m_SelectedSymbol = sPLITSYMBOLS.Symbol1;
                        }
                        if (sPLITSYMBOLS.Symbol2 != null)
                        {
                            this.m_DrawingSymbols.Add(sPLITSYMBOLS.Symbol2);
                            this.m_SelectedSymbol = sPLITSYMBOLS.Symbol2;
                        }
                        this.OnCapNhatKH();
                    }
                }
                if (this.selectionDragging)
                {
                    this.selectionDragging = false;
                    if (this.m_SelectedSymbol != null)
                    {
                        this.m_SelectedSymbols.Add(this.m_SelectedSymbol);
                        this.m_SelectedSymbol = null;
                        foreach (CSymbol cSymbol in this.drawingSymbols)
                        {
                            if (cSymbol.HitTest(this.m_Map, this.selectionRect) && cSymbol != this.m_SelectedSymbols[0])
                            {
                                this.m_SelectedSymbols.Add(cSymbol);
                            }
                        }
                        goto IL_2B5;

                    }
                    foreach (CSymbol cSymbol2 in this.drawingSymbols)
                    {
                        if (cSymbol2.HitTest(this.m_Map, this.selectionRect))
                        {
                            this.m_SelectedSymbols.Add(cSymbol2);
                        }
                    }

                IL_2B5:
                    this.RefreshMap();
                    if (this.m_SelectedSymbols.Count > 1)
                    {
                    }
                }
                if (this.DrawingDragging)
                {
                    this.DrawingDragging = false;
                    this.RefreshMap();
                }
                if (this.NodeDragging)
                {
                    this.NodeDragging = false;
                    this.RefreshMap();
                }
                if (this.RootDragging)
                {
                    this.RootDragging = false;
                    this.RefreshMap();
                }
                switch (this.myMapTool)
                {
                    case CBdTC.MapTools.Cycle:
                    case CBdTC.MapTools.Rectangle:
                    case CBdTC.MapTools.arc:
                        this.DrawingPicking = false;
                        this.AddNewObj(e.shift);
                        this.OnCapNhatKH();
                        break;
                }
            }
        }
        public void ShowTooltip(CMapXEvents_MouseMoveEvent e)
        {
            if (this.m_Map.CurrentTool == ToolConstants.miArrowTool)
            {
                PointF pt = new PointF(e.x, e.y);
                CSymbol cSymbol = this.m_DrawingSymbols.FindSymbolAtPoint(this.m_Map, pt);
                if (cSymbol != null)
                {
                    if (cSymbol != this.lastTTSymbol)
                    {
                        this.toolTip1.Active = true;
                        this.toolTip1.SetToolTip(this.m_Map, cSymbol.Description);
                    }
                }
                else
                {
                    this.toolTip1.Active = false;
                }
                this.lastTTSymbol = cSymbol;
            }
        }
        private void OnUndoClick()
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            try
            {
                modBdTC.UNDOITEM uNDOITEM = this.PushUndo();
                if (uNDOITEM != null)
                {
                    this.m_DrawingSymbols = uNDOITEM.UndoSymbols;
                    this.m_Map.CenterX = uNDOITEM.MapX;
                    this.m_Map.CenterY = uNDOITEM.MapY;
                    this.m_SelectedSymbol = uNDOITEM.SeleSymbol;
                }
            }
            catch (Exception array2)
            {
                throw array2;
            }
            CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
            if (listKHChangedEvent != null)
            {
                listKHChangedEvent(this.m_SelectedSymbol);
            }
        }
        private void OnRedoClick()
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            try
            {
                modBdTC.UNDOITEM uNDOITEM = this.PushRedo();
                if (uNDOITEM != null)
                {
                    this.m_DrawingSymbols = uNDOITEM.UndoSymbols;
                    this.m_Map.CenterX = uNDOITEM.MapX;
                    this.m_Map.CenterY = uNDOITEM.MapY;
                    this.m_SelectedSymbol = uNDOITEM.SeleSymbol;
                }
            }
            catch (Exception array2)
            {
                throw array2;
            }
            CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
            if (listKHChangedEvent != null)
            {
                listKHChangedEvent(this.m_SelectedSymbol);
            }
        }
        private void MnuCopyKH_Click(object sender, EventArgs e)
        {
            this.m_CopySymbol = this.m_SelectedSymbol;
            this.m_CopySymbols.Clear();
            this.m_CopySymbols.Add(this.m_CopySymbol);
        }
        private void MnuEditNodes_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedSymbol != null)
            {
                this.iEditNode = -1;
                this.myMapTool = CBdTC.MapTools.NodesEdit;
                this.RefreshMap();
            }
            else
            {
                MessageBox.Show("ko co selEditsymbol", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void MnuRotate_Click(object sender, EventArgs e)
        {
            this.myMapTool = CBdTC.MapTools.Rotate;
            this.m_ParentForm.ToolStripStatusLabel3.Text = "Rotate: di chuột để quay.";
        }
        private void MnuChangeRoot_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedSymbol != null)
            {
                this.PopUndo();
                this.myMapTool = CBdTC.MapTools.ChangeRoot;
                this.RefreshMap();
            }
            else
            {
                MessageBox.Show("ko co selesymbol", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void MnuChangeDesc_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedSymbol != null)
            {
                this.ChangeDesc(this.m_SelectedSymbol, this.m_ParentForm);
                this.m_SelectedSymbol = null;
            }
        }
        public void ChangeDesc(CSymbol pSymbol, Form pParent)
        {
            //dlgInputBox dlgInputBox = new dlgInputBox();
            //dlgInputBox.Label1.Text = "Ghi chú:";
            //dlgInputBox.TextBox1.Text = pSymbol.Description;
            //if (dlgInputBox.ShowDialog(pParent) == DialogResult.OK)
            //{
            //    this.PopUndo();
            //    pSymbol.Description = dlgInputBox.TextBox1.Text;
            //}
            //CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
            //if (listKHChangedEvent != null)
            //{
            //    listKHChangedEvent(pSymbol);
            //}
        }
        private void MnuDeleteKH_Click(object sender, EventArgs e)
        {
            this.OnXoa();
        }
        private void MnuChangeColor_Click(object sender, EventArgs e)
        {
            this.PopUndo();
            switch (this.m_SelectedObject.GetObjType())
            {
                case OBJECTTYPE.Pie:
                    //if (new dlgChangePie
                    //{
                    //    myObj = (PieGraphic)this.m_SelectedObject
                    //}.ShowDialog(this.m_ParentForm) == DialogResult.OK)
                    //{
                    //    this.RefreshMap();
                    //}
                    break;
                case OBJECTTYPE.Text:
                    //if (new dlgChangeLabel
                    //{
                    //    myObj = (TextGraphic)this.m_SelectedObject
                    //}.ShowDialog(this.m_ParentForm) == DialogResult.OK)
                    //{
                    //    this.RefreshMap();
                    //}
                    break;
                case OBJECTTYPE.Table:
                    //if (new dlgChangeTable
                    //{
                    //    myObj = (TableGraphic)this.m_SelectedObject
                    //}.ShowDialog(this.m_ParentForm) == DialogResult.OK)
                    //{
                    //    this.RefreshMap();
                    //}
                    break;
                case OBJECTTYPE.EmbeddedImage:
                    {
                        //EmbeddedImageGraphic embeddedImageGraphic = (EmbeddedImageGraphic)this.m_SelectedObject;
                        //dlgChangeImage dlgChangeImage = new dlgChangeImage();
                        //dlgChangeImage.chkTransparent.Checked = embeddedImageGraphic.Transparent;
                        //dlgChangeImage.txtTransparentColor.BackColor = embeddedImageGraphic.TransparentColor;
                        //if (dlgChangeImage.ShowDialog(this.m_ParentForm) == DialogResult.OK)
                        //{
                        //    embeddedImageGraphic.Transparent = dlgChangeImage.chkTransparent.Checked;
                        //    embeddedImageGraphic.TransparentColor = dlgChangeImage.txtTransparentColor.BackColor;
                        //}
                        break;
                    }
                default:
                    //if (new dlgChangeColor
                    //{
                    //    myObj = (ShapeGraphic)this.m_SelectedObject
                    //}.ShowDialog(this.m_ParentForm) == DialogResult.OK)
                    //{
                    //    this.RefreshMap();
                    //}
                    break;
            }
        }
        private void MnuDeleteShape_Click(object sender, EventArgs e)
        {
            if (this.FoundObject.FoundSymbol != null)
            {
                this.PopUndo();
                if (this.FoundObject.FoundSymbol.GObjs.Count > 1)
                {
                    this.FoundObject.FoundSymbol.GObjs.Remove(this.FoundObject.FoundObject);
                }
                else
                {
                    this.m_DrawingSymbols.Remove(this.FoundObject.FoundSymbol);
                }
                this.RefreshMap();
            }
        }
        private void MnXoaNode_Click(object sender, EventArgs e)
        {
            if (this.FoundNode != null)
            {
                this.PopUndo();
                this.FoundNode.FoundObject.RemoveNode(this.FoundNode.NodeIndex);
                this.RefreshMap();
            }
        }
        private void MnuAddNode_Click(object sender, EventArgs e)
        {
            if (this.FoundNode != null)
            {
                this.PopUndo();
                this.FoundNode.FoundObject.InsertNode(this.FoundNode.NodeIndex);
                this.RefreshMap();
            }
        }
        private void MnuChangeNodeType_Click(object sender, EventArgs e)
        {
            if (this.FoundNode != null)
            {
                this.PopUndo();
                this.FoundNode.FoundObject.ChangeNodeType(this.FoundNode.NodeIndex);
                this.RefreshMap();
            }
        }
        private void MnuSendBack_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedSymbol != null)
            {
                this.PopUndo();
                this.m_DrawingSymbols.SendBack(this.m_SelectedSymbol);
                this.RefreshMap();
            }
        }
        private void MnuPastKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_CopySymbols.Count > 0)
                {
                    this.PopUndo();
                    CSymbol cSymbol = this.m_CopySymbols[0];
                    CSymbol cSymbol2 = cSymbol;
                    double num = cSymbol2.GocX;
                    CSymbol cSymbol3 = cSymbol;
                    double num2 = cSymbol3.GocY;
                    float num3 = 0;
                    float num4 = 0;
                    this.m_Map.ConvertCoord(ref num3, ref num4, ref num, ref num2, ConversionConstants.miMapToScreen);
                    cSymbol3.GocY = num2;
                    cSymbol2.GocX = num;
                    PointF pt = new PointF(this.mousePos.X, this.mousePos.Y);
                    CSymbol seleSymbol = this.PastSymbolAt(cSymbol, pt);
                    if (this.m_CopySymbols.Count > 1)
                    {
                        int num5 = this.m_CopySymbols.Count - 1;
                        for (int i = -1; i < num5; i++)
                        {
                            cSymbol = this.m_CopySymbols[i];
                            cSymbol3 = cSymbol;
                            num2 = cSymbol3.GocX;
                            cSymbol2 = cSymbol;
                            num = cSymbol2.GocY;
                            float num6 = 0;
                            float num7 = 0;
                            this.m_Map.ConvertCoord(ref num6, ref num7, ref num2, ref num, ConversionConstants.miMapToScreen);
                            cSymbol2.GocY = num;
                            cSymbol3.GocX = num2;
                            pt = unchecked(new PointF(this.mousePos.X - num3 + num6, this.mousePos.Y - num4 + num7));
                            seleSymbol = this.PastSymbolAt(cSymbol, pt);
                        }
                    }
                    CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
                    if (listKHChangedEvent != null)
                    {
                        listKHChangedEvent(seleSymbol);
                    }
                }
                this.RefreshMap();
            }
            catch (Exception arg_15E_0)
            {
                throw arg_15E_0;
            }
        }
        public CSymbol PastSymbolAt(CSymbol pSymbol, PointF pt1)
        {
            CSymbol cSymbol = null;
            if (pSymbol != null)
            {
                cSymbol = new CSymbol(this.m_Map, pt1, pSymbol.GObjs, pSymbol.Zoom, pSymbol.MWidth);
                cSymbol.Description = pSymbol.Description;
                this.m_DrawingSymbols.Add(cSymbol);
            }
            return cSymbol;
        }
        public void PastSymbol(CSymbol pSymbol)
        {
            if (pSymbol != null)
            {
                CSymbol cSymbol = new CSymbol(pSymbol.Description, pSymbol.Blinking, pSymbol.Zoom, pSymbol.MWidth, pSymbol.GocX, pSymbol.GocY, pSymbol.GObjs, pSymbol.Heading);
                cSymbol.Description = pSymbol.Description;
                this.m_DrawingSymbols.Add(cSymbol);
            }
        }
        private System.Drawing.Point Snap(float px, float py)
        {
            System.Drawing.Point result = checked(new System.Drawing.Point((int)Math.Round(unchecked(Math.Round((double)(px / (float)this.myGridWidth), 0) * (double)this.myGridWidth)), (int)Math.Round(unchecked(Math.Round((double)(py / (float)this.myGridWidth), 0) * (double)this.myGridWidth))));
            return result;
        }
        public void m_Map_KeyUpEvent(object sender, CMapXEvents_KeyUpEvent e)
        {
            short keyCode = e.keyCode;
            if (keyCode == 83)
            {
                this.bSnap = !this.bSnap;
                if (this.bSnap)
                {
                    this.m_ParentForm.ToolStripStatusLabel5.Text = "SNAP";
                }
                else
                {
                    this.m_ParentForm.ToolStripStatusLabel5.Text = "";
                }
            }
            else if (keyCode == 71)
            {
                this.bGrid = !this.bGrid;
                this.RefreshMap();
            }
            else if (keyCode == 46)
            {
                this.OnXoa();
            }
            else if (keyCode == 38)
            {
                if (this.m_SelectedSymbol != null)
                {
                    switch (e.shift)
                    {
                        case 2:
                            this.m_SelectedSymbol.Shift(this.m_Map, 0f, -1f);
                            this.RefreshMap();
                            break;
                        case 6:
                            {
                                this.myrootPt = default(PointF);
                                float num = this.myrootPt.X;
                                float num2 = this.myrootPt.Y;
                                CSymbol selectedSymbol = this.m_SelectedSymbol;
                                double num3 = selectedSymbol.GocX;
                                CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                                double num4 = selectedSymbol2.GocY;
                                this.m_Map.ConvertCoord(ref num, ref num2, ref num3, ref num4, ConversionConstants.miMapToScreen);
                                selectedSymbol2.GocY = num4;
                                selectedSymbol.GocX = num3;
                                this.myrootPt.Y = num2;
                                this.myrootPt.X = num;
                                this.m_SelectedSymbol.Scale2(this.m_Map, this.myrootPt, 0f, 1f);
                                this.RefreshMap();
                                break;
                            }
                    }
                }
            }
            else if (keyCode == 40)
            {
                if (this.m_SelectedSymbol != null)
                {
                    switch (e.shift)
                    {
                        case 2:
                            this.m_SelectedSymbol.Shift(this.m_Map, 0f, 1f);
                            this.RefreshMap();
                            break;
                        case 6:
                            {
                                this.myrootPt = default(PointF);
                                float num2 = this.myrootPt.X;
                                float num = this.myrootPt.Y;
                                CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                                double num4 = selectedSymbol2.GocX;
                                CSymbol selectedSymbol = this.m_SelectedSymbol;
                                double num3 = selectedSymbol.GocY;
                                this.m_Map.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                                selectedSymbol.GocY = num3;
                                selectedSymbol2.GocX = num4;
                                this.myrootPt.Y = num;
                                this.myrootPt.X = num2;
                                this.m_SelectedSymbol.Scale2(this.m_Map, this.myrootPt, 0f, -1f);
                                this.RefreshMap();
                                break;
                            }
                    }
                }
            }
            else if (keyCode == 39)
            {
                if (this.m_SelectedSymbol != null)
                {
                    switch (e.shift)
                    {
                        case 2:
                            this.m_SelectedSymbol.Shift(this.m_Map, 1f, 0f);
                            this.RefreshMap();
                            break;
                        case 4:
                            {
                                this.myrootPt = default(PointF);
                                float num2 = this.myrootPt.X;
                                float num = this.myrootPt.Y;
                                CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                                double num4 = selectedSymbol2.GocX;
                                CSymbol selectedSymbol = this.m_SelectedSymbol;
                                double num3 = selectedSymbol.GocY;
                                this.m_Map.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                                selectedSymbol.GocY = num3;
                                selectedSymbol2.GocX = num4;
                                this.myrootPt.Y = num;
                                this.myrootPt.X = num2;
                                this.m_SelectedSymbol.Rotate2(this.m_Map, this.myrootPt, modBdTC.myTinhChinhGocQuay);
                                this.RefreshMap();
                                break;
                            }
                        case 6:
                            {
                                this.myrootPt = default(PointF);
                                float num2 = this.myrootPt.X;
                                float num = this.myrootPt.Y;
                                CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                                double num4 = selectedSymbol2.GocX;
                                CSymbol selectedSymbol = this.m_SelectedSymbol;
                                double num3 = selectedSymbol.GocY;
                                this.m_Map.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                                selectedSymbol.GocY = num3;
                                selectedSymbol2.GocX = num4;
                                this.myrootPt.Y = num;
                                this.myrootPt.X = num2;
                                this.m_SelectedSymbol.Scale2(this.m_Map, this.myrootPt, 1f, 0f);
                                this.RefreshMap();
                                break;
                            }
                    }
                }
            }
            else if (keyCode == 37 && this.m_SelectedSymbol != null)
            {
                switch (e.shift)
                {
                    case 2:
                        this.m_SelectedSymbol.Shift(this.m_Map, -1f, 0f);
                        this.RefreshMap();
                        break;
                    case 4:
                        {
                            this.myrootPt = default(PointF);
                            float num2 = this.myrootPt.X;
                            float num = this.myrootPt.Y;
                            CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                            double num4 = selectedSymbol2.GocX;
                            CSymbol selectedSymbol = this.m_SelectedSymbol;
                            double num3 = selectedSymbol.GocY;
                            this.m_Map.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                            selectedSymbol.GocY = num3;
                            selectedSymbol2.GocX = num4;
                            this.myrootPt.Y = num;
                            this.myrootPt.X = num2;
                            this.m_SelectedSymbol.Rotate2(this.m_Map, this.myrootPt, -modBdTC.myTinhChinhGocQuay);
                            this.RefreshMap();
                            break;
                        }
                    case 6:
                        {
                            this.myrootPt = default(PointF);
                            float num2 = this.myrootPt.X;
                            float num = this.myrootPt.Y;
                            CSymbol selectedSymbol2 = this.m_SelectedSymbol;
                            double num4 = selectedSymbol2.GocX;
                            CSymbol selectedSymbol = this.m_SelectedSymbol;
                            double num3 = selectedSymbol.GocY;
                            this.m_Map.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                            selectedSymbol.GocY = num3;
                            selectedSymbol2.GocX = num4;
                            this.myrootPt.Y = num;
                            this.myrootPt.X = num2;
                            this.m_SelectedSymbol.Scale2(this.m_Map, this.myrootPt, -1f, 0f);
                            this.RefreshMap();
                            break;
                        }
                }
            }
        }
        private void AddFromVeKH()
        {
            CSymbol kHfromVeKH = this.m_KHfromVeKH;
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                CBdTC.DoiMau(kHfromVeKH.GObjs, modBdTC.QuanXanhColor);
            }
            this.m_DrawingSymbols.Add(kHfromVeKH);
            this.m_CopySymbol = kHfromVeKH;
            this.m_CopySymbols.Clear();
            this.m_CopySymbols.Add(this.m_CopySymbol);
            this.RefreshMap();
            this.m_SelectedSymbol = kHfromVeKH;
        }
        public static void DoiMau(CGraphicObjs pGObjs, Color pMau)
        {
            foreach (GraphicObject graphicObject in pGObjs)
            {
                switch (graphicObject.GetObjType())
                {
                    case OBJECTTYPE.Ellipse:
                    case OBJECTTYPE.Pie:
                        {
                            ShapeGraphic shapeGraphic = (ShapeGraphic)graphicObject;
                            ShapeGraphic shapeGraphic2 = shapeGraphic;
                            shapeGraphic2.LineColor = pMau;
                            shapeGraphic2.FillColor = Color.FromArgb((int)shapeGraphic2.FillColor.A, pMau);
                            break;
                        }
                    case OBJECTTYPE.Text:
                        {
                            TextGraphic textGraphic = (TextGraphic)graphicObject;
                            TextGraphic textGraphic2 = textGraphic;
                            textGraphic2.Color = pMau;
                            break;
                        }
                    case OBJECTTYPE.Table:
                        break;
                    case OBJECTTYPE.EmbeddedImage:
                        break;
                    default:
                        try
                        {
                            NodesShapeGraphic nodesShapeGraphic = (NodesShapeGraphic)graphicObject;
                            NodesShapeGraphic nodesShapeGraphic2 = nodesShapeGraphic;
                            nodesShapeGraphic2.LineColor = pMau;
                            nodesShapeGraphic2.FillColor = Color.FromArgb((int)nodesShapeGraphic2.FillColor.A, pMau);
                        }
                        catch (Exception expr_C1)
                        {
                            throw expr_C1;
                        }
                        break;
                }
            }

        }
        private void TraoMau(CGraphicObjs pGObjs)
        {
            foreach (GraphicObject graphicObject in pGObjs)
            {
                switch (graphicObject.GetObjType())
                {
                    case OBJECTTYPE.Ellipse:
                    case OBJECTTYPE.Pie:
                        {
                            ShapeGraphic shapeGraphic = (ShapeGraphic)graphicObject;
                            ShapeGraphic shapeGraphic2 = shapeGraphic;
                            if (shapeGraphic2.LineColor == modBdTC.QuanDoColor)
                            {
                                shapeGraphic2.LineColor = modBdTC.QuanXanhColor;
                            }
                            else if (shapeGraphic2.LineColor == modBdTC.QuanXanhColor)
                            {
                                shapeGraphic2.LineColor = modBdTC.QuanDoColor;
                            }
                            if (shapeGraphic2.FillColor == Color.FromArgb((int)shapeGraphic2.FillColor.A, modBdTC.QuanDoColor))
                            {
                                shapeGraphic2.FillColor = Color.FromArgb((int)shapeGraphic2.FillColor.A, modBdTC.QuanXanhColor);
                            }
                            else if (shapeGraphic2.FillColor == Color.FromArgb((int)shapeGraphic2.FillColor.A, modBdTC.QuanXanhColor))
                            {
                                shapeGraphic2.FillColor = Color.FromArgb((int)shapeGraphic2.FillColor.A, modBdTC.QuanDoColor);
                            }
                            break;
                        }
                    case OBJECTTYPE.Text:
                        {
                            TextGraphic textGraphic = (TextGraphic)graphicObject;
                            TextGraphic textGraphic2 = textGraphic;
                            if (textGraphic2.Color == modBdTC.QuanDoColor)
                            {
                                textGraphic2.Color = modBdTC.QuanXanhColor;
                            }
                            else if (textGraphic2.Color == modBdTC.QuanXanhColor)
                            {
                                textGraphic2.Color = modBdTC.QuanDoColor;
                            }
                            break;
                        }
                    case OBJECTTYPE.Table:
                        break;
                    case OBJECTTYPE.EmbeddedImage:
                        break;
                    default:
                        try
                        {
                            NodesShapeGraphic nodesShapeGraphic = (NodesShapeGraphic)graphicObject;
                            NodesShapeGraphic nodesShapeGraphic2 = nodesShapeGraphic;
                            if (nodesShapeGraphic2.LineColor == modBdTC.QuanDoColor)
                            {
                                nodesShapeGraphic2.LineColor = modBdTC.QuanXanhColor;
                            }
                            else if (nodesShapeGraphic2.LineColor == modBdTC.QuanXanhColor)
                            {
                                nodesShapeGraphic2.LineColor = modBdTC.QuanDoColor;
                            }
                            if (nodesShapeGraphic2.FillColor == Color.FromArgb((int)nodesShapeGraphic2.FillColor.A, modBdTC.QuanDoColor))
                            {
                                nodesShapeGraphic2.FillColor = Color.FromArgb((int)nodesShapeGraphic2.FillColor.A, modBdTC.QuanXanhColor);
                            }
                            else if (nodesShapeGraphic2.FillColor == Color.FromArgb((int)nodesShapeGraphic2.FillColor.A, modBdTC.QuanXanhColor))
                            {
                                nodesShapeGraphic2.FillColor = Color.FromArgb((int)nodesShapeGraphic2.FillColor.A, modBdTC.QuanDoColor);
                            }
                        }
                        catch (Exception expr_266)
                        {
                            throw expr_266;
                        }
                        break;
                }
            }

        }
        public CSymbol GetKHfromVeKH(string pDescr, CGraphicObjs pGObjs0, int pCX, int pCY, PointF pPt, float pTyLe)
        {
            CGraphicObjs tyLe1GObjs = this.GetTyLe1GObjs(pGObjs0);
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                CBdTC.DoiMau(tyLe1GObjs, modBdTC.QuanXanhColor);
            }
            CSymbol cSymbol = new CSymbol(this.m_Map, pPt, tyLe1GObjs);
            cSymbol.Description = pDescr;
            System.Drawing.Rectangle bounds = cSymbol.GetBounds(this.m_Map);
            PointF fromPt = new PointF(pPt.X, pPt.Y);
            PointF toPt = new PointF(pPt.X - (float)pCX, pPt.Y - (float)pCY);
            toPt.X = pPt.X + (float)pCX;
            toPt.Y = pPt.Y + (float)pCY;
            float x = toPt.X;
            float y = toPt.Y;
            double newGocX = 0;
            double newGocY = 0;
            this.m_Map.ConvertCoord(ref x, ref y, ref newGocX, ref newGocY, ConversionConstants.miScreenToMap);
            toPt.Y = y;
            toPt.X = x;
            cSymbol.ChangeRoot(this.m_Map, newGocX, newGocY);
            fromPt.X = toPt.X;
            fromPt.Y = toPt.Y;
            toPt.X = pPt.X;
            toPt.Y = pPt.Y;
            cSymbol.Move(this.m_Map, fromPt, toPt);
            this.CalcSymbolZoom();
            cSymbol.Zoom = this.SymbolZoom * (double)pTyLe;
            cSymbol.MWidth = this.SymbolMapScreenWidth;
            return cSymbol;
        }
        public CSymbol GetKHfromVeKH0(PointF pPt, float pTyLe)
        {
            CGraphicObjs tyLe1GObjs = this.GetTyLe1GObjs(modBdTC.fCacKyHieu.OdrawingObjects);
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                CBdTC.DoiMau(tyLe1GObjs, modBdTC.QuanXanhColor);
            }
            CSymbol cSymbol = new CSymbol(this.m_Map, pPt, tyLe1GObjs);
            cSymbol.Description = modBdTC.fCacKyHieu.txtTenKH.Text;
            System.Drawing.Rectangle bounds = cSymbol.GetBounds(this.m_Map);
            PointF fromPt = new PointF(pPt.X, pPt.Y);
            PointF toPt = new PointF(pPt.X - (float)modBdTC.fCacKyHieu.myORootX, pPt.Y - (float)modBdTC.fCacKyHieu.myORootY);
            toPt.X = pPt.X + (float)modBdTC.fCacKyHieu.myORootX;
            toPt.Y = pPt.Y + (float)modBdTC.fCacKyHieu.myORootY;
            float x = toPt.X;
            float y = toPt.Y;
            double newGocX = 0;
            double newGocY = 0;
            this.m_Map.ConvertCoord(ref x, ref y, ref newGocX, ref newGocY, ConversionConstants.miScreenToMap);
            toPt.Y = y;
            toPt.X = x;
            cSymbol.ChangeRoot(this.m_Map, newGocX, newGocY);
            fromPt.X = toPt.X;
            fromPt.Y = toPt.Y;
            toPt.X = pPt.X;
            toPt.Y = pPt.Y;
            cSymbol.Move(this.m_Map, fromPt, toPt);
            this.CalcSymbolZoom();
            cSymbol.Zoom = this.SymbolZoom * (double)pTyLe;
            cSymbol.MWidth = this.SymbolMapScreenWidth;
            return cSymbol;
        }
        private CGraphicObjs GetTyLe1GObjs(CGraphicObjs pGObjs)
        {
            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            foreach (GraphicObject graphicObject in pGObjs)
            {
                GraphicObject aGObj = graphicObject.Clone();
                cGraphicObjs.Add(aGObj);
            }

            return cGraphicObjs;
        }
        public void ChuanBiNhanKH()
        {
            this.myMapCurrTool = this.m_Map.CurrentTool;
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.m_ParentForm.ToolStripStatusLabel3.Text = "Click vào bản đồ để vẽ KH.";
            this.m_KHfromVeKH = null;
            this.myMapTool = CBdTC.MapTools.DangLayKH;
        }
        public void NhanKHXong()
        {
            this.m_Map.MousePointer = CursorConstants.miDefaultCursor;
            this.m_ParentForm.ToolStripStatusLabel3.Text = "";
            try
            {
                this.m_Map.CurrentTool = (ToolConstants)Convert.ToInt32(this.myMapCurrTool);
            }
            catch (Exception expr_39)
            {
                throw expr_39;
                this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            }
            this.m_KHfromVeKH = null;
            this.OnCapNhatKH();
        }

        /// <summary>
        /// [EDITING]
        /// </summary>
        /// <param name="pShift"></param>
        private void AddNewObj(short pShift)
        {
            GraphicObject[] array = null;
            string description = "Ký hiệu mới";
            PointF pt = default(PointF);
            checked
            {
                switch (this.myMapTool)
                {
                    case CBdTC.MapTools.Polygon:
                        {
                            PointF[] normalPts = COtherLineStyle.GetNormalPts(this.myPts, 1);
                            if (normalPts.GetUpperBound(0) > 1)
                            {
                                GraphicsPath graphicsPath = new GraphicsPath();
                                graphicsPath.AddPolygon(normalPts);
                                RectangleF bounds = graphicsPath.GetBounds();
                                int arg_3B9_0;
                                int upperBound;
                                unchecked
                                {
                                    pt.X = (bounds.Left + bounds.Right) / 2f;
                                    pt.Y = (bounds.Top + bounds.Bottom) / 2f;
                                    arg_3B9_0 = 0;
                                    upperBound = normalPts.GetUpperBound(0);
                                }
                                for (int i = arg_3B9_0; i <= upperBound; i++)
                                {
                                    PointF[] array2 = normalPts;
                                    PointF[] arg_3C7_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_3C7_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts;
                                        PointF[] arg_3F2_0 = array2;
                                        num = i;
                                        arg_3F2_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                array = new GraphicObject[]
						{
							new PolygonGraphic(normalPts, 1f, Color.Red)
							{
								Rotation = 0f,
								LineWidth = (float)modBdTC.defaGenPen1W,
								LineColor = modBdTC.defaGenPen1C,
								Line2Width = (float)modBdTC.defaGenPen2W,
								Line2Color = modBdTC.defaGenPen2C,
								Fill = modBdTC.defaGenFill,
								FillColor = modBdTC.defaGenFillC,
								LineStyle = modBdTC.defaGenLineStyle
							}
						};
                            }
                            break;
                        }
                    case CBdTC.MapTools.Line:
                        {
                            PointF[] normalPts2 = COtherLineStyle.GetNormalPts(this.myPts, 1);
                            if (normalPts2.GetUpperBound(0) > 0)
                            {
                                GraphicsPath graphicsPath2 = new GraphicsPath();
                                graphicsPath2.AddLines(normalPts2);
                                RectangleF bounds2 = graphicsPath2.GetBounds();
                                int arg_519_0;
                                int upperBound2;
                                unchecked
                                {
                                    pt.X = (bounds2.Left + bounds2.Right) / 2f;
                                    pt.Y = (bounds2.Top + bounds2.Bottom) / 2f;
                                    arg_519_0 = 0;
                                    upperBound2 = normalPts2.GetUpperBound(0);
                                }
                                for (int i = arg_519_0; i <= upperBound2; i++)
                                {
                                    PointF[] array2 = normalPts2;
                                    PointF[] arg_527_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_527_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts2;
                                        PointF[] arg_552_0 = array2;
                                        num = i;
                                        arg_552_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                array = new GraphicObject[]
						{
							new LinesGraphic(normalPts2, 1f, Color.Red)
							{
								Rotation = 0f,
								LineWidth = (float)modBdTC.defaGenPen1W,
								LineColor = modBdTC.defaGenPen1C,
								Line2Width = (float)modBdTC.defaGenPen2W,
								Line2Color = modBdTC.defaGenPen2C,
								FillColor = modBdTC.defaGenFillC,
								LineStyle = modBdTC.defaGenLineStyle
							}
						};
                            }
                            break;
                        }
                    case CBdTC.MapTools.Curve:
                        {
                            PointF[] normalPts3 = COtherLineStyle.GetNormalPts(this.myPts, 1);
                            if (normalPts3.GetUpperBound(0) > 0)
                            {
                                GraphicsPath graphicsPath3 = new GraphicsPath();
                                graphicsPath3.AddCurve(normalPts3);
                                RectangleF bounds3 = graphicsPath3.GetBounds();
                                int arg_DA_0;
                                int upperBound3;
                                unchecked
                                {
                                    pt.X = (bounds3.Left + bounds3.Right) / 2f;
                                    pt.Y = (bounds3.Top + bounds3.Bottom) / 2f;
                                    arg_DA_0 = 0;
                                    upperBound3 = normalPts3.GetUpperBound(0);
                                }
                                for (int i = arg_DA_0; i <= upperBound3; i++)
                                {
                                    PointF[] array2 = normalPts3;
                                    PointF[] arg_E8_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_E8_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts3;
                                        PointF[] arg_113_0 = array2;
                                        num = i;
                                        arg_113_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                if (modBdTC.defaMyLineStyle == 0)
                                {
                                    array = new GraphicObject[]
							{
								new CurveGraphic(normalPts3, 1f, Color.Red)
								{
									Rotation = 0f,
									LineWidth = (float)modBdTC.defaGenPen1W,
									LineColor = modBdTC.defaGenPen1C,
									Line2Width = (float)modBdTC.defaGenPen2W,
									Line2Color = modBdTC.defaGenPen2C,
									FillColor = modBdTC.defaGenFillC,
									LineStyle = modBdTC.defaGenLineStyle,
									StyleWidth = 8f
								}
							};
                                }
                                else
                                {
                                    array = modBdTC.MyOtherLineStyle.GetGraphicObjs(modBdTC.defaMyLineStyle, normalPts3);
                                }
                            }
                            break;
                        }
                    case CBdTC.MapTools.ClosedCurve:
                        {
                            PointF[] normalPts4 = COtherLineStyle.GetNormalPts(this.myPts, 1);
                            if (normalPts4.GetUpperBound(0) > 1)
                            {
                                GraphicsPath graphicsPath4 = new GraphicsPath();
                                graphicsPath4.AddClosedCurve(normalPts4);
                                RectangleF bounds4 = graphicsPath4.GetBounds();
                                int arg_259_0;
                                int upperBound4;
                                unchecked
                                {
                                    pt.X = (bounds4.Left + bounds4.Right) / 2f;
                                    pt.Y = (bounds4.Top + bounds4.Bottom) / 2f;
                                    arg_259_0 = 0;
                                    upperBound4 = normalPts4.GetUpperBound(0);
                                }
                                for (int i = arg_259_0; i <= upperBound4; i++)
                                {
                                    PointF[] array2 = normalPts4;
                                    PointF[] arg_267_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_267_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts4;
                                        PointF[] arg_292_0 = array2;
                                        num = i;
                                        arg_292_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                array = new GraphicObject[]
						{
							new ClosedCurveGraphic(normalPts4, 1f, Color.Red)
							{
								Rotation = 0f,
								LineWidth = (float)modBdTC.defaGenPen1W,
								LineColor = modBdTC.defaGenPen1C,
								Line2Width = (float)modBdTC.defaGenPen2W,
								Line2Color = modBdTC.defaGenPen2C,
								Fill = modBdTC.defaGenFill,
								FillColor = modBdTC.defaGenFillC,
								LineStyle = modBdTC.defaGenLineStyle
							}
						};
                            }
                            break;
                        }
                    case CBdTC.MapTools.Cycle:
                        {
                            pt.X = (float)((double)(this.DrawingRect.Left + this.DrawingRect.Right) / 2.0);
                            pt.Y = (float)((double)(this.DrawingRect.Top + this.DrawingRect.Bottom) / 2.0);
                            PointF[] array3 = new PointF[2];
                            unchecked
                            {
                                array3[0].X = (float)((double)pt.X - Math.Abs((double)this.DrawingRect.Width / 2.0));
                                array3[0].Y = (float)((double)pt.Y - Math.Abs((double)this.DrawingRect.Height / 2.0));
                                array3[1].X = (float)((double)pt.X + Math.Abs((double)this.DrawingRect.Width / 2.0));
                                array3[1].Y = (float)((double)pt.Y + Math.Abs((double)this.DrawingRect.Height / 2.0));
                                int arg_F7B_0 = 0;
                                int upperBound5 = array3.GetUpperBound(0);
                                for (int i = arg_F7B_0; i <= upperBound5; i = checked(i + 1))
                                {
                                    PointF[] array2 = array3;
                                    PointF[] arg_F89_0 = array2;
                                    int num = i;
                                    arg_F89_0[num].X = array2[num].X - pt.X;
                                    array2 = array3;
                                    PointF[] arg_FB4_0 = array2;
                                    num = i;
                                    arg_FB4_0[num].Y = array2[num].Y - pt.Y;
                                }
                                array = new GraphicObject[]
						{
							new EllipseGraphic(array3[0].X, array3[0].Y, array3[1].X - array3[0].X, array3[1].Y - array3[0].Y, 0f)
							{
								LineWidth = (float)modBdTC.defaGenPen1W,
								LineColor = modBdTC.defaGenPen1C,
								Line2Width = (float)modBdTC.defaGenPen2W,
								Line2Color = modBdTC.defaGenPen2C,
								Fill = modBdTC.defaGenFill,
								FillColor = modBdTC.defaGenFillC,
								LineStyle = modBdTC.defaGenLineStyle
							}
						};
                                break;
                            }
                        }
                    case CBdTC.MapTools.Rectangle:
                        {
                            PointF[] array4 = new PointF[4];
                            array4[0].X = (float)this.DrawingRect.X;
                            array4[0].Y = (float)this.DrawingRect.Y;
                            array4[1].X = (float)(this.DrawingRect.X + this.DrawingRect.Width);
                            array4[1].Y = (float)this.DrawingRect.Y;
                            array4[2].X = (float)(this.DrawingRect.X + this.DrawingRect.Width);
                            array4[2].Y = (float)(this.DrawingRect.Y + this.DrawingRect.Height);
                            array4[3].X = (float)this.DrawingRect.X;
                            array4[3].Y = (float)(this.DrawingRect.Y + this.DrawingRect.Height);
                            GraphicsPath graphicsPath5 = new GraphicsPath();
                            graphicsPath5.AddCurve(array4);
                            RectangleF bounds5 = graphicsPath5.GetBounds();
                            int arg_11FC_0;
                            int upperBound6;
                            unchecked
                            {
                                pt.X = (bounds5.Left + bounds5.Right) / 2f;
                                pt.Y = (bounds5.Top + bounds5.Bottom) / 2f;
                                arg_11FC_0 = 0;
                                upperBound6 = array4.GetUpperBound(0);
                            }
                            for (int i = arg_11FC_0; i <= upperBound6; i++)
                            {
                                PointF[] array2 = array4;
                                PointF[] arg_120A_0 = array2;
                                int num = i;
                                unchecked
                                {
                                    arg_120A_0[num].X = array2[num].X - pt.X;
                                    array2 = array4;
                                    PointF[] arg_1235_0 = array2;
                                    num = i;
                                    arg_1235_0[num].Y = array2[num].Y - pt.Y;
                                }
                            }
                            array = new GraphicObject[]
					{
						new PolygonGraphic(array4, 1f, Color.Red)
						{
							Fill = false,
							FillColor = modBdTC.defaGenFillC,
							Rotation = 0f,
							LineWidth = (float)modBdTC.defaGenPen1W,
							LineColor = modBdTC.defaGenPen1C,
							Line2Width = (float)modBdTC.defaGenPen2W,
							Line2Color = modBdTC.defaGenPen2C,
							LineStyle = modBdTC.defaGenLineStyle,
							StyleWidth = 8f
						}
					};
                            break;
                        }
                    case CBdTC.MapTools.arc:
                        {
                            PointF[] array5 = new PointF[4];
                            array5[1].X = (float)this.DrawingRect.X;
                            array5[1].Y = (float)this.DrawingRect.Y;
                            array5[2].X = (float)(this.DrawingRect.X + this.DrawingRect.Width);
                            array5[2].Y = (float)this.DrawingRect.Y;
                            array5[3].X = (float)(this.DrawingRect.X + this.DrawingRect.Width);
                            array5[3].Y = (float)(this.DrawingRect.Y + this.DrawingRect.Height);
                            array5[0].X = (float)this.DrawingRect.X;
                            array5[0].Y = (float)(this.DrawingRect.Y + this.DrawingRect.Height);
                            GraphicsPath graphicsPath6 = new GraphicsPath();
                            graphicsPath6.AddCurve(array5);
                            RectangleF bounds6 = graphicsPath6.GetBounds();
                            int arg_1448_0;
                            int upperBound7;
                            unchecked
                            {
                                pt.X = (bounds6.Left + bounds6.Right) / 2f;
                                pt.Y = (bounds6.Top + bounds6.Bottom) / 2f;
                                arg_1448_0 = 0;
                                upperBound7 = array5.GetUpperBound(0);
                            }
                            for (int i = arg_1448_0; i <= upperBound7; i++)
                            {
                                PointF[] array2 = array5;
                                PointF[] arg_1456_0 = array2;
                                int num = i;
                                unchecked
                                {
                                    arg_1456_0[num].X = array2[num].X - pt.X;
                                    array2 = array5;
                                    PointF[] arg_1481_0 = array2;
                                    num = i;
                                    arg_1481_0[num].Y = array2[num].Y - pt.Y;
                                }
                            }
                            NodesShapeGraphic nodesShapeGraphic = new LinesGraphic(array5, 1f, Color.Red);
                            nodesShapeGraphic.Fill = false;
                            nodesShapeGraphic.FillColor = modBdTC.defaGenFillC;
                            nodesShapeGraphic.Rotation = 0f;
                            nodesShapeGraphic.LineWidth = (float)modBdTC.defaGenPen1W;
                            nodesShapeGraphic.LineColor = modBdTC.defaGenPen1C;
                            nodesShapeGraphic.Line2Width = (float)modBdTC.defaGenPen2W;
                            nodesShapeGraphic.Line2Color = modBdTC.defaGenPen2C;
                            nodesShapeGraphic.LineStyle = modBdTC.defaGenLineStyle;
                            nodesShapeGraphic.StyleWidth = 8f;
                            nodesShapeGraphic.Nodes[1].IsControl = true;
                            nodesShapeGraphic.Nodes[2].IsControl = true;
                            array = new GraphicObject[]
					{
						nodesShapeGraphic
					};
                            break;
                        }
                    case CBdTC.MapTools.Text:
                        pt.X = this.myPts[0].X;
                        pt.Y = this.myPts[0].Y;
                        array = new GraphicObject[]
					{
						unchecked(new TextGraphic(this.myPts[0].X - pt.X, this.myPts[0].Y - pt.Y, "", modBdTC.defaTextFont, modBdTC.defaTextC)
						{
							Rotation = 0f,
							AutoSize = true
						})
					};
                        break;
                    case CBdTC.MapTools.Table:
                        {
                            pt.X = this.myPts[0].X;
                            pt.Y = this.myPts[0].Y;
                            SizeF sizeF = this.m_Map.CreateGraphics().MeasureString("TEXT", modBdTC.defaTableTFont);
                            int num2 = (int)Math.Round((double)(unchecked(sizeF.Width * 10f) / 4f));
                            int num3 = (int)Math.Round((double)sizeF.Height) + 2;
                            TableGraphic tableGraphic = new TableGraphic(unchecked(this.myPts[0].X - pt.X), unchecked(this.myPts[0].Y - pt.Y), modBdTC.defaTableColsNo * num2, modBdTC.defaTableRowsNo * num3, modBdTC.defaTableColsNo, modBdTC.defaTableRowsNo, modBdTC.defaTableFillC);
                            array = new GraphicObject[]
					{
						tableGraphic
					};
                            array[0].Rotation = 0f;
                            array[0].AutoSize = true;
                            break;
                        }
                    case CBdTC.MapTools.MuiTenDon:
                        {
                            PointF[] normalPts5 = COtherLineStyle.GetNormalPts(this.myPts, 1);
                            if (normalPts5.GetUpperBound(0) > 0)
                            {
                                GraphicsPath graphicsPath7 = new GraphicsPath();
                                graphicsPath7.AddCurve(normalPts5);
                                pt.X = normalPts5[normalPts5.GetUpperBound(0)].X;
                                pt.Y = normalPts5[normalPts5.GetUpperBound(0)].Y;
                                int arg_D01_0 = 0;
                                int upperBound8 = normalPts5.GetUpperBound(0);
                                for (int i = arg_D01_0; i <= upperBound8; i++)
                                {
                                    PointF[] array2 = normalPts5;
                                    PointF[] arg_D0F_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_D0F_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts5;
                                        PointF[] arg_D3A_0 = array2;
                                        num = i;
                                        arg_D3A_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                int num4 = (int)Math.Round(modBanDo.GetZoomLevel(this.m_Map, modBanDo.BDTyLeBanDo));
                                array = COtherLineStyle.GetMuiTenDon(normalPts5, (float)(unchecked((double)modBdTC.defaGenPen1W * 1.5 * (double)num4) / this.m_Map.Zoom));
                                CurveGraphic curveGraphic = (CurveGraphic)array[0];
                                curveGraphic.Rotation = 0f;
                                curveGraphic.LineWidth = (float)modBdTC.defaGenPen1W;
                                curveGraphic.LineColor = modBdTC.defaMuiTenPen1C;
                                curveGraphic.Line2Width = (float)modBdTC.defaGenPen2W;
                                curveGraphic.Line2Color = modBdTC.defaGenPen2C;
                                curveGraphic.LineStyle = modBdTC.defaGenLineStyle;
                                PolygonGraphic polygonGraphic = (PolygonGraphic)array[1];
                                polygonGraphic.Rotation = 0f;
                                polygonGraphic.LineWidth = (float)modBdTC.defaGenPen1W;
                                polygonGraphic.LineColor = modBdTC.defaMuiTenPen1C;
                                polygonGraphic.Fill = true;
                                polygonGraphic.FillColor = modBdTC.defaMuiTenPen1C;
                                polygonGraphic.LineStyle = modBdTC.defaGenLineStyle;
                            }
                            break;
                        }
                    case CBdTC.MapTools.MuiTen:
                        {
                            PointF[] normalPts6 = COtherLineStyle.GetNormalPts(this.myPts, 16);
                            if (normalPts6.GetUpperBound(0) > 0)
                            {
                                pt.X = normalPts6[normalPts6.GetUpperBound(0)].X;
                                pt.Y = normalPts6[normalPts6.GetUpperBound(0)].Y;
                                int arg_91B_0 = 0;
                                int upperBound9 = normalPts6.GetUpperBound(0);
                                for (int i = arg_91B_0; i <= upperBound9; i++)
                                {
                                    PointF[] array2 = normalPts6;
                                    PointF[] arg_929_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_929_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts6;
                                        PointF[] arg_954_0 = array2;
                                        num = i;
                                        arg_954_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                array = COtherLineStyle.GetMuiTen(normalPts6, modBdTC.myMuiTenDoRong);
                                ClosedCurveGraphic closedCurveGraphic = (ClosedCurveGraphic)array[0];
                                closedCurveGraphic.LineWidth = (float)modBdTC.defaMuiTenPen1W;
                                closedCurveGraphic.LineColor = modBdTC.defaMuiTenPen1C;
                                closedCurveGraphic.Line2Width = (float)modBdTC.defaMuiTenPen2W;
                                closedCurveGraphic.Line2Color = modBdTC.defaMuiTenPen2C;
                                closedCurveGraphic.Fill = modBdTC.defaMuiTenFill;
                                closedCurveGraphic.FillColor = modBdTC.defaMuiTenFillC;
                                closedCurveGraphic.Rotation = 0f;
                            }
                            break;
                        }
                    case CBdTC.MapTools.MuiTenDac:
                        {
                            PointF[] normalPts7 = COtherLineStyle.GetNormalPts(this.myPts, 16);
                            if (normalPts7.GetUpperBound(0) > 0)
                            {
                                pt.X = normalPts7[normalPts7.GetUpperBound(0)].X;
                                pt.Y = normalPts7[normalPts7.GetUpperBound(0)].Y;
                                int arg_B7F_0 = 0;
                                int upperBound10 = normalPts7.GetUpperBound(0);
                                for (int i = arg_B7F_0; i <= upperBound10; i++)
                                {
                                    PointF[] array2 = normalPts7;
                                    PointF[] arg_B8D_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_B8D_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts7;
                                        PointF[] arg_BB8_0 = array2;
                                        num = i;
                                        arg_BB8_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                int num5 = (int)Math.Round(modBanDo.GetZoomLevel(this.m_Map, modBanDo.BDTyLeBanDo));
                                array = unchecked(COtherLineStyle.GetMuiTenDac(normalPts7, (float)((double)(modBdTC.defaMuiTenDacDoRong * (float)num5) / this.m_Map.Zoom), (float)((double)(modBdTC.defaMuiTenDacDoDai * (float)num5) / this.m_Map.Zoom)));
                                CurveGraphic curveGraphic2 = (CurveGraphic)array[0];
                                curveGraphic2.LineWidth = (float)modBdTC.defaMuiTenDacPen1W;
                                curveGraphic2.LineColor = modBdTC.defaMuiTenDacPen1C;
                                curveGraphic2.Line2Width = (float)modBdTC.defaMuiTenDacPen2W;
                                curveGraphic2.Line2Color = modBdTC.defaMuiTenDacPen2C;
                                curveGraphic2.Fill = modBdTC.defaMuiTenDacFill;
                                curveGraphic2.FillColor = modBdTC.defaMuiTenDacFillC;
                                curveGraphic2.Rotation = 0f;
                            }
                            break;
                        }
                    case CBdTC.MapTools.MuiTenHo:
                        {
                            PointF[] normalPts8 = COtherLineStyle.GetNormalPts(this.myPts, 16);
                            if (normalPts8.GetUpperBound(0) > 0)
                            {
                                pt.X = normalPts8[normalPts8.GetUpperBound(0)].X;
                                pt.Y = normalPts8[normalPts8.GetUpperBound(0)].Y;
                                int arg_A4D_0 = 0;
                                int upperBound11 = normalPts8.GetUpperBound(0);
                                for (int i = arg_A4D_0; i <= upperBound11; i++)
                                {
                                    PointF[] array2 = normalPts8;
                                    PointF[] arg_A5B_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_A5B_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts8;
                                        PointF[] arg_A86_0 = array2;
                                        num = i;
                                        arg_A86_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                array = COtherLineStyle.GetMuiTenHo(normalPts8, modBdTC.myMuiTenDoRong);
                                CurveGraphic curveGraphic3 = (CurveGraphic)array[0];
                                curveGraphic3.LineWidth = (float)modBdTC.defaMuiTenPen1W;
                                curveGraphic3.LineColor = modBdTC.defaMuiTenPen1C;
                                curveGraphic3.Line2Width = (float)modBdTC.defaMuiTenPen2W;
                                curveGraphic3.Line2Color = modBdTC.defaMuiTenPen2C;
                                curveGraphic3.Fill = modBdTC.defaMuiTenFill;
                                curveGraphic3.FillColor = modBdTC.defaMuiTenFillC;
                                curveGraphic3.Rotation = 0f;
                            }
                            break;
                        }
                    case CBdTC.MapTools.SongSong:
                        {
                            PointF[] normalPts9 = COtherLineStyle.GetNormalPts(this.myPts, 1);
                            if (normalPts9.GetUpperBound(0) > 0)
                            {
                                GraphicsPath graphicsPath8 = new GraphicsPath();
                                graphicsPath8.AddCurve(normalPts9);
                                RectangleF bounds7 = graphicsPath8.GetBounds();
                                int arg_66D_0;
                                int upperBound12;
                                unchecked
                                {
                                    pt.X = (bounds7.Left + bounds7.Right) / 2f;
                                    pt.Y = (bounds7.Top + bounds7.Bottom) / 2f;
                                    arg_66D_0 = 0;
                                    upperBound12 = normalPts9.GetUpperBound(0);
                                }
                                for (int i = arg_66D_0; i <= upperBound12; i++)
                                {
                                    PointF[] array2 = normalPts9;
                                    PointF[] arg_67B_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_67B_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts9;
                                        PointF[] arg_6A6_0 = array2;
                                        num = i;
                                        arg_6A6_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                array = COtherLineStyle.GetSongSong(normalPts9, modBdTC.defaSongSongSize, modBdTC.defaSongSongLinesNo);
                                int arg_6EB_0 = 0;
                                int upperBound13 = array.GetUpperBound(0);
                                for (int j = arg_6EB_0; j <= upperBound13; j++)
                                {
                                    CurveGraphic curveGraphic4 = new CurveGraphic(normalPts9, 1f, Color.Red);
                                    curveGraphic4.LineWidth = (float)modBdTC.defaSongSongPen1W;
                                    curveGraphic4.LineColor = modBdTC.defaSongSongPen1C;
                                    curveGraphic4.Line2Width = (float)modBdTC.defaSongSongPen2W;
                                    curveGraphic4.Line2Color = modBdTC.defaSongSongPen2C;
                                    curveGraphic4.LineStyle = modBdTC.defaSongSongLineStyle;
                                    curveGraphic4.Rotation = 0f;
                                }
                            }
                            break;
                        }
                    case CBdTC.MapTools.SongSongKin:
                        {
                            PointF[] normalPts10 = COtherLineStyle.GetNormalPts(this.myPts, 1);
                            if (normalPts10.GetUpperBound(0) > 1)
                            {
                                GraphicsPath graphicsPath9 = new GraphicsPath();
                                graphicsPath9.AddClosedCurve(normalPts10);
                                RectangleF bounds8 = graphicsPath9.GetBounds();
                                int arg_7D5_0;
                                int upperBound14;
                                unchecked
                                {
                                    pt.X = (bounds8.Left + bounds8.Right) / 2f;
                                    pt.Y = (bounds8.Top + bounds8.Bottom) / 2f;
                                    arg_7D5_0 = 0;
                                    upperBound14 = normalPts10.GetUpperBound(0);
                                }
                                for (int i = arg_7D5_0; i <= upperBound14; i++)
                                {
                                    PointF[] array2 = normalPts10;
                                    PointF[] arg_7E3_0 = array2;
                                    int num = i;
                                    unchecked
                                    {
                                        arg_7E3_0[num].X = array2[num].X - pt.X;
                                        array2 = normalPts10;
                                        PointF[] arg_80E_0 = array2;
                                        num = i;
                                        arg_80E_0[num].Y = array2[num].Y - pt.Y;
                                    }
                                }
                                array = COtherLineStyle.GetSongSongKin(normalPts10, modBdTC.defaSongSongSize, modBdTC.defaSongSongLinesNo);
                                int arg_853_0 = 0;
                                int upperBound15 = array.GetUpperBound(0);
                                for (int k = arg_853_0; k <= upperBound15; k++)
                                {
                                    ClosedCurveGraphic closedCurveGraphic2 = (ClosedCurveGraphic)array[k];
                                    closedCurveGraphic2.LineWidth = (float)modBdTC.defaSongSongPen1W;
                                    closedCurveGraphic2.LineColor = modBdTC.defaSongSongPen1C;
                                    closedCurveGraphic2.Line2Width = (float)modBdTC.defaSongSongPen2W;
                                    closedCurveGraphic2.Line2Color = modBdTC.defaSongSongPen2C;
                                    closedCurveGraphic2.LineStyle = modBdTC.defaSongSongLineStyle;
                                    closedCurveGraphic2.Rotation = 0f;
                                }
                            }
                            break;
                        }
                }
                if (array.GetUpperBound(0) > -1)
                {
                    CGraphicObjs cGraphicObjs = new CGraphicObjs();
                    GraphicObject[] array6 = array;
                    for (int l = 0; l < array6.Length; l++)
                    {
                        GraphicObject aGObj = array6[l];
                        cGraphicObjs.Add(aGObj);
                    }
                    if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                    {
                        this.TraoMau(cGraphicObjs);
                    }
                    this.PopUndo();
                    CSymbol cSymbol = new CSymbol(this.m_Map, pt, cGraphicObjs);
                    this.CalcSymbolZoom();
                    cSymbol.ChangeZoomMWidtht(this.SymbolZoom, this.SymbolMapScreenWidth);
                    cSymbol.Description = description;
                    this.m_DrawingSymbols.Add(cSymbol);
                    this.RefreshMap();
                    this.m_SelectedSymbol = cSymbol;
                    this.m_ParentForm.ToolStripStatusLabel3.Text = "";
                    CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
                    if (listKHChangedEvent != null)
                    {
                        listKHChangedEvent(this.m_SelectedSymbol);
                    }
                }
            }
        }

        private CSymbol TachObject(CFOUNDOBJECT pFObj)
        {
            CSymbol result = null;
            if (pFObj != null && pFObj.FoundSymbol.GObjs.Count > 1)
            {
                GraphicObject aGObj = pFObj.FoundObject.Clone();
                PointF pt = default(PointF);
                float x = pt.X;
                float y = pt.Y;
                CSymbol foundSymbol = pFObj.FoundSymbol;
                double gocX = foundSymbol.GocX;
                CSymbol foundSymbol2 = pFObj.FoundSymbol;
                double gocY = foundSymbol2.GocY;
                this.m_Map.ConvertCoord(ref x, ref y, ref gocX, ref gocY, ConversionConstants.miMapToScreen);
                foundSymbol2.GocY = gocY;
                foundSymbol.GocX = gocX;
                pt.Y = y;
                pt.X = x;
                CGraphicObjs cGraphicObjs = new CGraphicObjs();
                cGraphicObjs.Add(aGObj);
                CSymbol cSymbol = new CSymbol(this.m_Map, pt, cGraphicObjs, pFObj.FoundSymbol.Zoom, pFObj.FoundSymbol.MWidth);
                System.Drawing.Rectangle bounds = cSymbol.GetBounds(this.m_Map);
                y = (float)((double)(bounds.Left + bounds.Right) / 2.0);
                x = (float)((double)(bounds.Top + bounds.Bottom) / 2.0);
                double newGocX = 0;
                double newGocY = 0;
                this.m_Map.ConvertCoord(ref y, ref x, ref newGocX, ref newGocY, ConversionConstants.miScreenToMap);
                cSymbol.ChangeRoot(this.m_Map, newGocX, newGocY);
                cSymbol.Description = pFObj.FoundSymbol.Description;
                this.m_DrawingSymbols.Add(cSymbol);
                result = cSymbol;
                pFObj.FoundSymbol.GObjs.Remove(pFObj.FoundObject);
            }
            return result;
        }
        private void TachAllObject(CSymbol pSymbol)
        {
            bool flag = false;
            if (pSymbol != null)
            {
                try
                {
                    if (pSymbol.GObjs.Count > 1)
                    {
                        foreach (GraphicObject aGObj in pSymbol.GObjs)
                        {
                            PointF pt = default(PointF);
                            float x = pt.X;
                            float y = pt.Y;
                            double gocX = pSymbol.GocX;
                            double gocY = pSymbol.GocY;
                            this.m_Map.ConvertCoord(ref x, ref y, ref gocX, ref gocY, ConversionConstants.miMapToScreen);
                            pSymbol.GocY = gocY;
                            pSymbol.GocX = gocX;
                            pt.Y = y;
                            pt.X = x;
                            CGraphicObjs cGraphicObjs = new CGraphicObjs();
                            cGraphicObjs.Add(aGObj);
                            CSymbol cSymbol = new CSymbol(this.m_Map, pt, cGraphicObjs, pSymbol.Zoom, pSymbol.MWidth);
                            System.Drawing.Rectangle bounds = cSymbol.GetBounds(this.m_Map);
                            y = (float)((double)(bounds.Left + bounds.Right) / 2.0);
                            x = (float)((double)(bounds.Top + bounds.Bottom) / 2.0);
                            double newGocX = 0;
                            double newGocY = 0;
                            this.m_Map.ConvertCoord(ref y, ref x, ref newGocX, ref newGocY, ConversionConstants.miScreenToMap);
                            cSymbol.ChangeRoot(this.m_Map, newGocX, newGocY);
                            cSymbol.Description = pSymbol.Description;
                            this.m_DrawingSymbols.Add(cSymbol);
                        }

                        flag = true;
                    }
                }
                catch (Exception expr_17B)
                {
                    throw expr_17B;
                }
                if (flag)
                {
                    this.m_DrawingSymbols.Remove(pSymbol);
                }
            }
        }
        private void NhomSymbols(CSymbols SelectedSymbols)
        {
            if (SelectedSymbols.Count > 1)
            {
                CGraphicObjs cGraphicObjs = new CGraphicObjs();
                CSymbol cSymbol = SelectedSymbols[0];
                int num = SelectedSymbols.Count - 1;
                for (int i = -1; i < num; i++)
                {
                    SelectedSymbols[i].ChangeZoomMWidtht(cSymbol.Zoom, cSymbol.MWidth);
                    SelectedSymbols[i].ChangeRoot(this.m_Map, cSymbol.GocX, cSymbol.GocY);
                    foreach (GraphicObject aGObj in SelectedSymbols[i].GObjs)
                    {
                        cSymbol.GObjs.Add(aGObj);
                    }

                    this.m_DrawingSymbols.Remove(SelectedSymbols[i]);
                }
            }
        }
        private void CopySymbols(CSymbols SelectedSymbols)
        {
            if (SelectedSymbols.Count > 0)
            {
                this.m_CopySymbols.Clear();
                foreach (CSymbol aSymbol in SelectedSymbols)
                {
                    this.m_CopySymbols.Add(aSymbol);
                }

            }
        }
        private void CutSymbols(CSymbols SelectedSymbols)
        {
            if (SelectedSymbols.Count > 0)
            {
                this.m_CopySymbols.Clear();
                foreach (CSymbol aSymbol in SelectedSymbols)
                {
                    this.m_CopySymbols.Add(aSymbol);
                    this.m_DrawingSymbols.Remove(aSymbol);
                }

            }
        }
        private void OnDrawObj(string pType)
        {
            this.m_SelectedSymbol = null;
            this.m_SelectedObject = null;
            if (pType == "Line")
            {
                this.myMapTool = CBdTC.MapTools.Line;
            }
            else if (pType == "Polygon")
            {
                this.myMapTool = CBdTC.MapTools.Polygon;
            }
            else if (pType == "Curve")
            {
                this.myMapTool = CBdTC.MapTools.Curve;
            }
            else if (pType == "ClosedCurve")
            {
                this.myMapTool = CBdTC.MapTools.ClosedCurve;
            }
            else if (pType == "Ellipse" || pType == "Cycle")
            {
                this.myMapTool = CBdTC.MapTools.Cycle;
            }
            else if (pType == "Arc")
            {
                this.myMapTool = CBdTC.MapTools.arc;
            }
            else if (pType == "Rectangle")
            {
                this.myMapTool = CBdTC.MapTools.Rectangle;
            }
            else if (pType == "Text")
            {
                this.myMapTool = CBdTC.MapTools.Text;
            }
            else if (pType == "Table")
            {
                this.myMapTool = CBdTC.MapTools.Table;
            }
            else if (pType == "MuiTenDon")
            {
                this.myMapTool = CBdTC.MapTools.MuiTenDon;
            }
            else if (pType == "MuiTen")
            {
                this.myMapTool = CBdTC.MapTools.MuiTen;
            }
            else if (pType == "MuiTenDac")
            {
                this.myMapTool = CBdTC.MapTools.MuiTenDac;
            }
            else if (pType == "MuiTenHo")
            {
                this.myMapTool = CBdTC.MapTools.MuiTenHo;
            }
            else if (pType == "SongSong")
            {
                this.myMapTool = CBdTC.MapTools.SongSong;
            }
            else if (pType == "SongSongKin")
            {
                this.myMapTool = CBdTC.MapTools.SongSongKin;
            }
            if (pType == "Ellipse")
            {
                this.m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " + pType + ": kéo theo đường chéo (ấn Alt để có mầu quân Xanh).";
            }
            else if (pType == "Rectangle")
            {
                this.m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " + pType + ": kéo theo đường chéo (ấn Alt để có mầu quân Xanh).";
            }
            else if (pType == "Arc")
            {
                this.m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " + pType + ": kéo theo đường chéo (ấn Alt để có mầu quân Xanh).";
            }
            else if (pType == "Text")
            {
                this.m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " + pType + ": Click để chọn vị trí Text (ấn Alt để có mầu quân Xanh).";
            }
            else if (pType == "Table")
            {
                this.m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " + pType + ": Click để chọn vị trí Table (ấn Alt để có mầu quân Xanh).";
            }
            else
            {
                this.m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " + pType + ": Click để chọn các điểm, RightClick để kết thúc (ấn Alt để có mầu quân Xanh).";
            }
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.RefreshMap();
        }
        private void MnuPartSendBack_Click(object sender, EventArgs e)
        {
            this.FoundObject.FoundSymbol.GObjs.SendBack(this.FoundObject.FoundObject);
            this.RefreshMap();
        }
        private void MnuPartTachObject_Click(object sender, EventArgs e)
        {
            this.PopUndo();
            CSymbol cSymbol = this.TachObject(this.FoundObject);
            if (cSymbol != null)
            {
                this.RefreshMap();
                CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
                if (listKHChangedEvent != null)
                {
                    listKHChangedEvent(cSymbol);
                }
            }
        }
        private void MnuScale_Click(object sender, EventArgs e)
        {
            this.myMapTool = CBdTC.MapTools.Scale;
            this.m_ParentForm.ToolStripStatusLabel3.Text = "Zoom: di chuột để thay đổi kích thước KH.";
        }
        private void MnuKHMove_Click(object sender, EventArgs e)
        {
            this.myMapTool = CBdTC.MapTools.Move;
            this.m_ParentForm.ToolStripStatusLabel3.Text = "Move: di chuột để thay đổi vi trí KH.";
        }
        private void MnuBlinking_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedSymbol != null)
            {
                this.PopUndo();
                this.m_SelectedSymbol.Blinking = !this.m_SelectedSymbol.Blinking;
            }
        }

        public void Dispose()
        {
            try
            {
                this.m_Map.Layers.Remove("LopVeKyHieu");
            }
            catch (Exception expr_17)
            {
                throw expr_17;
            }
        }
        private void MnuGrNhom_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedSymbols.Count > 1)
            {
                this.PopUndo();
                CSymbol seleSymbol = this.m_SelectedSymbols[0];
                this.NhomSymbols(this.m_SelectedSymbols);
                this.m_SelectedSymbols.Clear();
                this.RefreshMap();
                CBdTC.ListKHChangedEventHandler listKHChangedEvent = this.ListKHChangedEvent;
                if (listKHChangedEvent != null)
                {
                    listKHChangedEvent(seleSymbol);
                }
            }
        }
        private void MnuGrCopy_Click(object sender, EventArgs e)
        {
            this.CopySymbols(this.m_SelectedSymbols);
            this.m_SelectedSymbols.Clear();
            this.RefreshMap();
        }
        private void MnuGrCut_Click(object sender, EventArgs e)
        {
            this.PopUndo();
            this.CutSymbols(this.m_SelectedSymbols);
            this.m_SelectedSymbols.Clear();
            this.RefreshMap();
        }
        private void RefreshMap()
        {
            this.m_ParentForm.lyrCacKyHieu.Invalidate(Missing.Value);
        }
        private void MnuVFlip_Click(object sender, EventArgs e)
        {
            this.PopUndo();
            this.m_SelectedSymbol.VFlip();
            this.RefreshMap();
        }
        private void MnuClosed2Curve_Click(object sender, EventArgs e)
        {
            if (this.FoundObject.FoundObject.GetObjType() == OBJECTTYPE.ClosedCurve | this.FoundObject.FoundObject.GetObjType() == OBJECTTYPE.Polygon)
            {
                this.PopUndo();
                this.FoundObject.FoundSymbol.GObjs.MoClosedCurve(this.FoundObject.FoundObject);
                this.RefreshMap();
            }
            else
            {
                MessageBox.Show("Chi lam duoc voi Duong kin thoi", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void MnuCurve2Closed_Click(object sender, EventArgs e)
        {
            if (this.FoundObject.FoundObject.GetObjType() == OBJECTTYPE.Curve | this.FoundObject.FoundObject.GetObjType() == OBJECTTYPE.Line)
            {
                NodesShapeGraphic nodesShapeGraphic = (NodesShapeGraphic)this.FoundObject.FoundObject;
                if (nodesShapeGraphic.Nodes.Count > 2)
                {
                    this.PopUndo();
                    this.FoundObject.FoundSymbol.GObjs.DongCurve(this.FoundObject.FoundObject);
                    this.RefreshMap();
                }
                else
                {
                    MessageBox.Show("Khong kep kin duoc", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Chi lam duoc voi duong mo thoi", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void MnuTo1stNode_Click(object sender, EventArgs e)
        {
            if (this.FoundNode != null)
            {
                if (this.FoundNode.FoundObject.GetObjType() == OBJECTTYPE.ClosedCurve)
                {
                    ClosedCurveGraphic closedCurveGraphic = (ClosedCurveGraphic)this.FoundNode.FoundObject;
                    closedCurveGraphic.To1stNode(this.FoundNode.NodeIndex);
                    this.RefreshMap();
                }
                else if (this.FoundNode.FoundObject.GetObjType() == OBJECTTYPE.Polygon)
                {
                    PolygonGraphic polygonGraphic = (PolygonGraphic)this.FoundNode.FoundObject;
                    polygonGraphic.To1stNode(this.FoundNode.NodeIndex);
                    this.RefreshMap();
                }
                else if (this.FoundNode.FoundObject.GetObjType() == OBJECTTYPE.Curve | this.FoundNode.FoundObject.GetObjType() == OBJECTTYPE.Line)
                {
                    NodesShapeGraphic nodesShapeGraphic = (NodesShapeGraphic)this.FoundNode.FoundObject;
                    if (this.FoundNode.NodeIndex == checked(nodesShapeGraphic.Nodes.Count - 1))
                    {
                        nodesShapeGraphic.ReverseNodes();
                        this.RefreshMap();
                    }
                    else
                    {
                        MessageBox.Show("Chi lam duoc voi node cuoi thoi", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Chi lam duoc voi ClosedCurve thoi", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }
        private void MnuCut_Click(object sender, EventArgs e)
        {
            this.myMapTool = CBdTC.MapTools.Split;
            this.m_ParentForm.ToolStripStatusLabel3.Text = "Cắt: di chuột để vẽ đường cắt.";
        }
        private CBdTC.SPLITSYMBOLS To2Symbols(CSymbol pSymbol, PointF pPT0, PointF pPT1)
        {
            CBdTC.SPLITSYMBOLS result = default(CBdTC.SPLITSYMBOLS);
            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            CGraphicObjs cGraphicObjs2 = new CGraphicObjs();
            PointF[] array = new PointF[]
			{
				pPT0,
				pPT1
			};
            float num = (float)(pSymbol.Zoom / this.m_Map.Zoom);
            //num = Convert.ToSingle(Operators.MultiplyObject(num, pSymbol.MWidth > 0f ? this.m_Map.MapScreenWidth / pSymbol.MWidth : 1));
            Matrix matrix = new Matrix();
            matrix.Translate(-this.myrootPt.X, -this.myrootPt.Y, MatrixOrder.Append);
            matrix.Scale(1f / num, 1f / num, MatrixOrder.Append);
            matrix.TransformPoints(array);
            float num2 = modBdTC.AngleToPoint(array[0], array[1]);
            foreach (GraphicObject graphicObject in pSymbol.GObjs)
            {
                GraphicObject graphicObject2 = modBdTC.ObjToCurve(graphicObject);
                if (graphicObject2.GetObjType() == OBJECTTYPE.Curve)
                {
                    PointF[] points = graphicObject2.GetPoints();
                    modBdTC.INTERSECTNODE[] intersectPoints = modBdTC.GetIntersectPoints(array[0], array[1], points);
                    if (intersectPoints.GetUpperBound(0) > -1)
                    {
                        PointF[] array2 = new PointF[points.GetUpperBound(0) + intersectPoints.GetUpperBound(0) + 1 + 1];
                        int num3 = 0;
                        int upperBound = intersectPoints.GetUpperBound(0);
                        for (int i = 0; i < upperBound; i++)
                        {
                            int nodeIndex = intersectPoints[i].NodeIndex;
                            for (int j = num3; j <= nodeIndex; j++)
                            {
                                array2[j + i] = points[j];
                            }
                            array2[intersectPoints[i].NodeIndex + i + 1] = intersectPoints[i].PT;
                            num3 = intersectPoints[i].NodeIndex + 1;
                            intersectPoints[i].NodeIndex = intersectPoints[i].NodeIndex + i + 1;
                        }
                        int upperBound2 = points.GetUpperBound(0);
                        for (int k = num3; k <= upperBound2; k++)
                        {
                            array2[k + intersectPoints.GetUpperBound(0) + 1] = points[k];
                        }
                        PointF[] array3 = new PointF[0];
                        PointF[] array4 = new PointF[0];
                        int num4 = 0;
                        int upperBound3 = intersectPoints.GetUpperBound(0);
                        for (int l = 0; l <= upperBound3; l++)
                        {
                            PointF[] array5 = new PointF[intersectPoints[l].NodeIndex - num4 + 1];
                            int nodeIndex2 = intersectPoints[l].NodeIndex;
                            for (int m = num4; m <= nodeIndex2; m++)
                            {
                                array5[m - num4] = array2[m];
                            }
                            num4 = intersectPoints[l].NodeIndex;
                            if (modBdTC.AngleToPoint(array[0], array5[array5.GetUpperBound(0) - 1]) > num2)
                            {
                                int upperBound4 = array3.GetUpperBound(0);
                                ///array3 = (PointF[])Utils.CopyArray((Array)array3, new PointF[upperBound4 + array5.GetUpperBound(0) + 1 + 1]);
                                int upperBound5 = array5.GetUpperBound(0);
                                for (int n = 0; n <= upperBound5; n++)
                                {
                                    array3[n + upperBound4 + 1] = array5[n];
                                }
                            }
                            else
                            {
                                int upperBound6 = array4.GetUpperBound(0);
                                //array4 = (PointF[])Utils.CopyArray((Array)array4, new PointF[upperBound6 + array5.GetUpperBound(0) + 1 + 1]);
                                int upperBound7 = array5.GetUpperBound(0);
                                for (int num5 = 0; num5 <= upperBound7; num5++)
                                {
                                    array4[num5 + upperBound6 + 1] = array5[num5];
                                }
                            }
                        }
                        PointF[] array6 = new PointF[array2.GetUpperBound(0) - num4 + 1];
                        int upperBound8 = array2.GetUpperBound(0);
                        for (int num6 = num4; num6 <= upperBound8; num6++)
                        {
                            array6[num6 - num4] = array2[num6];
                        }
                        if (modBdTC.AngleToPoint(array[0], array6[1]) > num2)
                        {
                            int upperBound9 = array3.GetUpperBound(0);
                            //array3 = (PointF[])Utils.CopyArray((Array)array3, new PointF[upperBound9 + array6.GetUpperBound(0) + 1 + 1]);
                            int upperBound10 = array6.GetUpperBound(0);
                            for (int num7 = 0; num7 <= upperBound10; num7++)
                            {
                                array3[num7 + upperBound9 + 1] = array6[num7];
                            }
                        }
                        else
                        {
                            //int upperBound11 = array4.GetUpperBound(0);
                            //array4 = (PointF[])Utils.CopyArray((Array)array4, new PointF[upperBound11 + array6.GetUpperBound(0) + 1 + 1]);
                            //int upperBound12 = array6.GetUpperBound(0);
                            //for (int num8 = 0; num8 <= upperBound12; num8++)
                            //{
                            //    array4[num8 + upperBound11 + 1] = array6[num8];
                            //}
                        }
                        CurveGraphic curveGraphic = (CurveGraphic)graphicObject2.Clone();
                        curveGraphic.Nodes.Clear();
                        int upperBound13 = array3.GetUpperBound(0);
                        for (int num9 = 0; num9 <= upperBound13; num9++)
                        {
                            CNODE cNODE = new CNODE(array3[num9]);
                            cNODE.IsControl = true;
                            curveGraphic.Nodes.Add(cNODE);
                        }
                        cGraphicObjs.Add(curveGraphic);
                        CurveGraphic curveGraphic2 = (CurveGraphic)graphicObject2.Clone();
                        curveGraphic2.Nodes.Clear();
                        int upperBound14 = array4.GetUpperBound(0);
                        for (int num10 = 0; num10 <= upperBound14; num10++)
                        {
                            CNODE cNODE2 = new CNODE(array4[num10]);
                            cNODE2.IsControl = true;
                            curveGraphic2.Nodes.Add(cNODE2);
                        }
                        cGraphicObjs2.Add(curveGraphic2);
                    }
                    else if (modBdTC.AngleToPoint(array[0], points[0]) > num2)
                    {
                        cGraphicObjs.Add(graphicObject);
                    }
                    else
                    {
                        cGraphicObjs2.Add(graphicObject);
                    }
                }
                else if (graphicObject2.GetObjType() == OBJECTTYPE.ClosedCurve)
                {
                    PointF[] array7 = graphicObject2.GetPoints();
                    int upperBound15 = array7.GetUpperBound(0);
                    //array7 = (PointF[])Utils.CopyArray((Array)array7, new PointF[upperBound15 + 1 + 1]);
                    array7[upperBound15 + 1] = array7[0];
                    modBdTC.INTERSECTNODE[] intersectPoints2 = modBdTC.GetIntersectPoints(array[0], array[1], array7);
                    //array7 = (PointF[])Utils.CopyArray((Array)array7, new PointF[upperBound15 + 1]);
                    if (intersectPoints2.GetUpperBound(0) > 0)
                    {
                        PointF[] array8 = new PointF[0];
                        PointF[] array9 = new PointF[0];
                        int num11 = intersectPoints2.GetUpperBound(0) - 1;
                        for (int num12 = 0; num12 <= num11; num12++)
                        {
                            int nodeIndex3 = intersectPoints2[num12].NodeIndex;
                            PointF[] array10 = new PointF[intersectPoints2[num12 + 1].NodeIndex - nodeIndex3 + 1 + 1];
                            array10[0] = intersectPoints2[num12].PT;
                            int num13 = intersectPoints2[num12 + 1].NodeIndex - nodeIndex3;
                            for (int num14 = 1; num14 <= num13; num14++)
                            {
                                array10[num14] = array7[nodeIndex3 + num14];
                            }
                            array10[intersectPoints2[num12 + 1].NodeIndex - nodeIndex3 + 1] = intersectPoints2[num12 + 1].PT;
                            if (modBdTC.AngleToPoint(array[0], array10[1]) > num2)
                            {
                                //int upperBound16 = array8.GetUpperBound(0);
                                //array8 = (PointF[])Utils.CopyArray((Array)array8, new PointF[upperBound16 + array10.GetUpperBound(0) + 1 + 1]);
                                //int upperBound17 = array10.GetUpperBound(0);
                                //for (int num15 = 0; num15 <= upperBound17; num15++)
                                //{
                                //    array8[num15 + upperBound16 + 1] = array10[num15];
                                //}
                            }
                            else
                            {
                                //int upperBound18 = array9.GetUpperBound(0);
                                //array9 = (PointF[])Utils.CopyArray((Array)array9, new PointF[upperBound18 + array10.GetUpperBound(0) + 1 + 1]);
                                //int upperBound19 = array10.GetUpperBound(0);
                                //for (int num16 = 0; num16 <= upperBound19; num16++)
                                //{
                                //    array9[num16 + upperBound18 + 1] = array10[num16];
                                //}
                            }
                        }
                        int upperBound20 = intersectPoints2.GetUpperBound(0);
                        int num17 = upperBound15 - intersectPoints2[upperBound20].NodeIndex;
                        int num18 = intersectPoints2[0].NodeIndex + 1;
                        PointF[] array11 = new PointF[num17 + num18 + 1 + 1];
                        array11[0] = intersectPoints2[upperBound20].PT;
                        int nodeIndex4 = intersectPoints2[upperBound20].NodeIndex;
                        int num19 = num17;
                        for (int num20 = 1; num20 <= num19; num20++)
                        {
                            array11[num20] = array7[nodeIndex4 + num20];
                        }
                        int num21 = num18 - 1;
                        for (int num22 = 0; num22 <= num21; num22++)
                        {
                            array11[num22 + num17 + 1] = array7[num22];
                        }
                        array11[num17 + num18 + 1] = intersectPoints2[0].PT;
                        if (modBdTC.AngleToPoint(array[0], array11[1]) > num2)
                        {
                            //int upperBound21 = array8.GetUpperBound(0);
                            //array8 = (PointF[])Utils.CopyArray((Array)array8, new PointF[upperBound21 + array11.GetUpperBound(0) + 1 + 1]);
                            //int upperBound22 = array11.GetUpperBound(0);
                            //for (int num23 = 0; num23 <= upperBound22; num23++)
                            //{
                            //    array8[num23 + upperBound21 + 1] = array11[num23];
                            //}
                        }
                        else
                        {
                            //int upperBound23 = array9.GetUpperBound(0);
                            //array9 = (PointF[])Utils.CopyArray((Array)array9, new PointF[upperBound23 + array11.GetUpperBound(0) + 1 + 1]);
                            //int upperBound24 = array11.GetUpperBound(0);
                            //for (int num24 = 0; num24 <= upperBound24; num24++)
                            //{
                            //    array9[num24 + upperBound23 + 1] = array11[num24];
                            //}
                        }
                        ClosedCurveGraphic closedCurveGraphic = (ClosedCurveGraphic)graphicObject2.Clone();
                        closedCurveGraphic.Nodes.Clear();
                        int upperBound25 = array8.GetUpperBound(0);
                        for (int num25 = 0; num25 <= upperBound25; num25++)
                        {
                            CNODE cNODE3 = new CNODE(array8[num25]);
                            cNODE3.IsControl = true;
                            closedCurveGraphic.Nodes.Add(cNODE3);
                        }
                        cGraphicObjs.Add(closedCurveGraphic);
                        ClosedCurveGraphic closedCurveGraphic2 = (ClosedCurveGraphic)graphicObject2.Clone();
                        closedCurveGraphic2.Nodes.Clear();
                        int upperBound26 = array9.GetUpperBound(0);
                        for (int num26 = 0; num26 <= upperBound26; num26++)
                        {
                            CNODE cNODE4 = new CNODE(array9[num26]);
                            cNODE4.IsControl = true;
                            closedCurveGraphic2.Nodes.Add(cNODE4);
                        }
                        cGraphicObjs2.Add(closedCurveGraphic2);
                    }
                    else if (modBdTC.AngleToPoint(array[0], array7[0]) > num2)
                    {
                        cGraphicObjs.Add(graphicObject);
                    }
                    else
                    {
                        cGraphicObjs2.Add(graphicObject);
                    }
                }
                else
                {
                    PointF[] points2 = graphicObject.GetPoints();
                    if (modBdTC.AngleToPoint(array[0], points2[0]) > num2)
                    {
                        cGraphicObjs.Add(graphicObject);
                    }
                    else
                    {
                        cGraphicObjs2.Add(graphicObject);
                    }
                }
            }

            CSymbol symbol;
            if (cGraphicObjs.Count > 0)
            {
                symbol = new CSymbol(pSymbol.Description, false, pSymbol.Zoom, pSymbol.MWidth, pSymbol.GocX, pSymbol.GocY, cGraphicObjs, pSymbol.Heading);
            }
            else
            {
                symbol = null;
            }
            CSymbol symbol2;
            if (cGraphicObjs2.Count > 0)
            {
                symbol2 = new CSymbol(pSymbol.Description, false, pSymbol.Zoom, pSymbol.MWidth, pSymbol.GocX, pSymbol.GocY, cGraphicObjs2, pSymbol.Heading);
            }
            else
            {
                symbol2 = null;
            }
            result.Symbol1 = symbol;
            result.Symbol2 = symbol2;
            return result;
        }
        private CSymbol ToCurve(CSymbol pSymbol)
        {
            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            foreach (GraphicObject graphicObject in pSymbol.GObjs)
            {
                if (graphicObject.GetObjType() == OBJECTTYPE.Curve | graphicObject.GetObjType() == OBJECTTYPE.ClosedCurve)
                {
                    cGraphicObjs.Add(graphicObject);
                }
                else
                {
                    cGraphicObjs.Add(modBdTC.ObjToCurve(graphicObject));
                }
            }

            CSymbol result;
            if (cGraphicObjs.Count > 0)
            {
                result = new CSymbol("", false, pSymbol.Zoom, pSymbol.MWidth, pSymbol.GocX, pSymbol.GocY, cGraphicObjs, pSymbol.Heading);
            }
            else
            {
                result = null;
            }
            return result;
        }
        private void MnuToCurve_Click(object sender, EventArgs e)
        {
            this.PopUndo();
            CSymbol cSymbol = this.ToCurve(this.m_SelectedSymbol);
            if (cSymbol != null)
            {
                this.m_DrawingSymbols.Remove(this.m_SelectedSymbol);
                this.m_DrawingSymbols.Add(cSymbol);
                this.m_SelectedSymbol = cSymbol;
            }
            this.OnCapNhatKH();
        }
        public void PopUndo()
        {
            this.m_ParentForm.myDirty = true;
            this.PopUndo0();
            this.XoaRedoStack();
        }
        private void PopUndo0()
        {
            //CSymbols cSymbols = new CSymbols();
            //CSymbol seleSymbol = null;
            //foreach (CSymbol cSymbol in this.m_DrawingSymbols)
            //{
            //    CSymbol cSymbol2 = new CSymbol(cSymbol.Description, cSymbol.Blinking, cSymbol.Zoom, cSymbol.MWidth, cSymbol.GocX, cSymbol.GocY, cSymbol.GObjs, cSymbol.Heading);
            //    cSymbols.Add(cSymbol2);
            //    if (cSymbol == this.m_SelectedSymbol)
            //    {
            //        seleSymbol = cSymbol2;
            //    }
            //}

            //if (this.iUndo < modBdTC.defaUndosNo - 1)
            //{
            //    this.iUndo++;
            //}
            //else
            //{
            //    int num = modBdTC.defaUndosNo - 2;
            //    for (int i = 0; i < num; i++)
            //    {
            //        modBdTC.stackUnDos[i] = modBdTC.stackUnDos[i + 1];
            //    }
            //    this.iUndo = modBdTC.defaUndosNo - 1;
            //}
            //modBdTC.stackUnDos[this.iUndo].UndoSymbols = cSymbols;
            //modBdTC.stackUnDos[this.iUndo].MapX = this.m_Map.CenterX;
            //modBdTC.stackUnDos[this.iUndo].MapY = this.m_Map.CenterY;
            //modBdTC.stackUnDos[this.iUndo].SeleSymbol = seleSymbol;
            //this.m_ParentForm.UndoToolStripButton.Enabled = true;
        }
        private modBdTC.UNDOITEM PushUndo()
        {
            //if (this.iUndo > -1 & this.iUndo < modBdTC.defaUndosNo)
            //{
            //    this.PopRedo();
            //    modBdTC.UNDOITEM result = modBdTC.stackUnDos[this.iUndo];
            //    this.iUndo--;
            //    if (this.iUndo < 0)
            //    {
            //        this.m_ParentForm.UndoToolStripButton.Enabled = false;
            //    }
            //    return result;
            //}
            //if (this.iUndo < 0)
            //{
            //    this.m_ParentForm.UndoToolStripButton.Enabled = false;
            //}
            //modBdTC.UNDOITEM result2;
            //return result2;

            modBdTC.UNDOITEM result2 = new modBdTC.UNDOITEM();
            return result2;
        }
        private void PopRedo()
        {
            CSymbols cSymbols = new CSymbols();
            CSymbol seleSymbol = null;
            foreach (CSymbol cSymbol in this.m_DrawingSymbols)
            {
                CSymbol cSymbol2 = new CSymbol(cSymbol.Description, cSymbol.Blinking, cSymbol.Zoom, cSymbol.MWidth, cSymbol.GocX, cSymbol.GocY, cSymbol.GObjs, cSymbol.Heading);
                cSymbols.Add(cSymbol2);
                if (cSymbol == this.m_SelectedSymbol)
                {
                    seleSymbol = cSymbol2;
                }
            }

            if (this.iRedo < modBdTC.defaUndosNo - 1)
            {
                this.iRedo++;
            }
            else
            {
                int num = modBdTC.defaUndosNo - 2;
                for (int i = 0; i < num; i++)
                {
                    modBdTC.stackReDos[i] = modBdTC.stackReDos[i + 1];
                }
                this.iRedo = modBdTC.defaUndosNo - 1;
            }
            //modBdTC.stackReDos[this.iRedo].UndoSymbols = cSymbols;
            //modBdTC.stackReDos[this.iRedo].MapX = this.m_Map.CenterX;
            //modBdTC.stackReDos[this.iRedo].MapY = this.m_Map.CenterY;
            //modBdTC.stackReDos[this.iRedo].SeleSymbol = seleSymbol;
            this.m_ParentForm.RedoToolStripButton.Enabled = true;
        }
        private modBdTC.UNDOITEM PushRedo()
        {
            //if (this.iRedo > -1 & this.iRedo < modBdTC.defaUndosNo)
            //{
            //    this.PopUndo0();
            //    modBdTC.UNDOITEM result = modBdTC.stackReDos[this.iRedo];
            //    this.iRedo--;
            //    if (this.iRedo < 0)
            //    {
            //        this.m_ParentForm.RedoToolStripButton.Enabled = false;
            //    }
            //    return result;
            //}
            //if (this.iRedo < 0)
            //{
            //    this.m_ParentForm.RedoToolStripButton.Enabled = false;
            //}
            //modBdTC.UNDOITEM result2;
            //return result2;
            return null;
        }
        public void XoaUndoStack()
        {
            modBdTC.stackUnDos = new modBdTC.UNDOITEM[modBdTC.defaUndosNo - 1 + 1];
            modBdTC.stackReDos = new modBdTC.UNDOITEM[modBdTC.defaUndosNo - 1 + 1];
            this.iUndo = -1;
            this.m_ParentForm.UndoToolStripButton.Enabled = false;
            this.iRedo = -1;
            this.m_ParentForm.RedoToolStripButton.Enabled = false;
        }
        private void XoaRedoStack()
        {
            this.iRedo = -1;
            this.m_ParentForm.RedoToolStripButton.Enabled = false;
        }
        private void MnuGrChangeColor_Click(object sender, EventArgs e)
        {
            //if (new dlgChangeSymbol
            //{
            //    Symbols = this.m_SelectedSymbols
            //}.ShowDialog(this.m_ParentForm) == DialogResult.OK)
            //{
            //    this.PopUndo();
            //    this.RefreshMap();
            //}
        }
        private void MnuGrMove_Click(object sender, EventArgs e)
        {
            //this.myMapTool = CBdTC.MapTools.GrMove;
            //this.m_ParentForm.ToolStripStatusLabel3.Text = "Move: di chuột để di chuyển nhóm KH.";
        }
        private void CxtMnuKyHieu_Popup(object sender, EventArgs e)
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
        }
        private void MnuCopyToVeKH_Click(object sender, EventArgs e)
        {
            //if (modBdTC.fCacKyHieu != null)
            //{
            //    if (this.m_SelectedSymbol != null)
            //    {
            //        float num = 1f;
            //        CGraphicObjs tyLe1GObjs = this.GetTyLe1GObjs(this.m_SelectedSymbol.GObjs);
            //        CSymbol cSymbol = new CSymbol(this.m_Map, tyLe1GObjs);
            //        cSymbol.Description = this.m_SelectedSymbol.Description;
            //        CSymbol cSymbol2 = cSymbol;
            //        cSymbol2.Zoom *= (double)num;
            //        float num2 = (float)(cSymbol.Zoom / this.m_Map.Zoom);
            //        num2 = Convert.ToSingle(Operators.MultiplyObject(num2, cSymbol.MWidth > 0f ? this.m_Map.MapScreenWidth / cSymbol.MWidth : 1));
            //        modBdTC.fCacKyHieu.CopyFromMap(cSymbol, num2);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Phải mở form Các ký hiệu mới copy được...", "Thông báo", MessageBoxButtons.OK);
            //}
        }
        private void MnuToPhanRa_Click(object sender, EventArgs e)
        {
            this.PopUndo();
            this.TachAllObject(this.m_SelectedSymbol);
            this.OnCapNhatKH();
        }
        private void MnuTo1Object_Click(object sender, EventArgs e)
        {
            if (this.FoundNode != null)
            {
                if (this.m_SelectedSymbol.Noi2Objs(this.FoundNode))
                {
                    this.RefreshMap();
                }
                else
                {
                    MessageBox.Show("Khong noi duoc.", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }
        private void MnuSendFront_Click(object sender, EventArgs e)
        {
            this.PopUndo();
            this.m_DrawingSymbols.SendFront(this.m_SelectedSymbol);
            this.RefreshMap();
        }
        private void MnuPartSendFront_Click(object sender, EventArgs e)
        {
            this.FoundObject.FoundSymbol.GObjs.SendFront(this.FoundObject.FoundObject);
            this.RefreshMap();
        }
        private void MnuHeading_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedSymbol != null)
            {
                this.PopUndo();
                this.ChangeHeading(this.m_SelectedSymbol, this.m_ParentForm);
                this.m_SelectedSymbol = null;
                this.RefreshMap();
            }
        }
        public void ChangeHeading(CSymbol pSymbol, Form pParent)
        {
            //dlgInputBox dlgInputBox = new dlgInputBox();
            //dlgInputBox.Label1.Text = "Hướng Ký Hiệu:";
            //dlgInputBox.TextBox1.Text = pSymbol.Heading.ToString();
            //if (dlgInputBox.ShowDialog(pParent) == DialogResult.OK)
            //{
            //    pSymbol.Heading = Convert.ToSingle(dlgInputBox.TextBox1.Text);
            //}
        }
        private void MenuItemFileClick(object sender, EventArgs e)
        {
            //ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            //string text = toolStripMenuItem.Tag.ToString();
            //string[] array = text.Split(new char[]
            //{
            //    '|'
            //});
            //if (array.GetUpperBound(0) > 0)
            //{
            //    int iNhom = Convert.ToInt32(array[0]);
            //    int indexInNhom = Convert.ToInt32(array[1]);
            //    int styleIndex = modBdTC.MyOtherLineStyle.GetStyleIndex(iNhom, indexInNhom);
            //    modBdTC.defaMyLineStyle = checked(styleIndex + 1);
            //    this.OnDrawObj("Curve");
            //    this.m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " + modBdTC.MyOtherLineStyle.StyleName(styleIndex) + ": Click để chọn các điểm, RightClick để kết thúc.";
            //}
        }
        private void CreateMyMenu()
        {
            //EventHandler onClick = new EventHandler(this.MenuItemFileClick);
            //int nhomCount = modBdTC.MyOtherLineStyle.NhomCount;
            //ToolStripMenuItem[] array = new ToolStripMenuItem[nhomCount - 1 + 1];
            //int num = nhomCount - 1;
            //for (int i = 0; i < num; i++)
            //{
            //    array[i] = new ToolStripMenuItem(modBdTC.MyOtherLineStyle.NhomName(i));
            //    this.m_ParentForm.CurveToolStripSplitButton.DropDownItems.Add(array[i]);
            //    if (modBdTC.MyOtherLineStyle.StyleCount(i) > 0)
            //    {
            //        int num2 = modBdTC.MyOtherLineStyle.StyleCount(i) - 1;
            //        for (int j = 0; j <= num2; j++)
            //        {
            //            int styleIndex = modBdTC.MyOtherLineStyle.GetStyleIndex(i, j);
            //            Bitmap image = this.getImage(styleIndex + 1);
            //            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(modBdTC.MyOtherLineStyle.StyleName(styleIndex) + " ", image, onClick);
            //            toolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            //            toolStripMenuItem.Tag = i.ToString("00") + "|" + j.ToString("00");
            //            array[i].DropDownItems.Add(toolStripMenuItem);
            //        }
            //    }
            //}
        }
        private Bitmap getImage(int StyleIndex)
        {
            Bitmap bitmap = new Bitmap(64, 24);
            Graphics g = Graphics.FromImage(bitmap);
            this.VeLineStyle(g, StyleIndex, 0f, 0f);
            return bitmap;
        }
        private void VeLineStyle(Graphics g, int StyleIndex, float pLeft, float pTop)
        {
            PointF[] array = new PointF[2];
            array[0].X = 8f;
            array[0].Y = 12f;
            array[1].X = 64f;
            array[1].Y = 12f;
            GraphicObject[] graphicObjs = modBdTC.MyOtherLineStyle.GetGraphicObjs(StyleIndex, array);
            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            GraphicObject[] array2 = graphicObjs;
            for (int i = 0; i < array2.Length; i++)
            {
                GraphicObject aGObj = array2[i];
                cGraphicObjs.Add(aGObj);
            }
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(pLeft, pTop);
            cGraphicObjs.DrawObjects(g, 0.8f);
            g.EndContainer(container);
        }
        public void UnseleKH()
        {
            //this.m_SelectedSymbol = null;
            //this.m_SelectedSymbols.Clear();
            //this.selectionDragging = false;
            //this.DrawingDragging = false;
            //this.DrawingPicking = false;
            //this.myMapTool = CBdTC.MapTools.None;
            //this.m_ParentForm.ToolStripStatusLabel3.Text = "";
            //this.RefreshMap();
        }
        private void OnCapNhatKH()
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.myMapTool = CBdTC.MapTools.None;
            this.RefreshMap();
        }
        public void HideDrawTools()
        {
            //if (modBdTC.fCacKyHieu != null)
            //{
            //    try
            //    {
            //        modBdTC.fCacKyHieu.Close();
            //    }
            //    catch (Exception expr_18)
            //    {
            //        throw expr_18;
            //    }
            //}
            //int num = this.m_ToolStrip.Items.IndexOf(this.m_ParentForm.CNToolStripButton);
            //int num2 = this.m_ToolStrip.Items.Count - 1;
            //for (int i = num + 1; i <= num2; i++)
            //{
            //    this.m_ToolStrip.Items[i].Enabled = false;
            //}
            //this.m_ParentForm.CNToolStripButton.Checked = false;
            //this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            //this.myMapTool = CBdTC.MapTools.None;
            //this.m_ParentForm.ToolStripStatusLabel3.Text = "";
        }
        private void changechedo()
        {
            //if (this.m_ParentForm.CNToolStripButton.Checked)
            //{
            //    int num = this.m_ToolStrip.Items.IndexOf(this.m_ParentForm.CNToolStripButton);
            //    int array = num + 1;
            //    int num2 = this.m_ParentForm.ToolStrip1.Items.Count - 1;
            //    for (int i = array; i <= num2; i++)
            //    {
            //        this.m_ToolStrip.Items[i].Enabled = true;
            //    }
            //    int index = this.m_ToolStrip.Items.IndexOf(this.m_ParentForm.UndoToolStripButton);
            //    int index2 = this.m_ToolStrip.Items.IndexOf(this.m_ParentForm.RedoToolStripButton);
            //    if (this.iUndo > -1)
            //    {
            //        this.m_ToolStrip.Items[index].Enabled = true;
            //    }
            //    else
            //    {
            //        this.m_ToolStrip.Items[index].Enabled = false;
            //    }
            //    if (this.iRedo > -1)
            //    {
            //        this.m_ToolStrip.Items[index2].Enabled = true;
            //    }
            //    else
            //    {
            //        this.m_ToolStrip.Items[index2].Enabled = false;
            //    }
            //    this.OnCapNhatKH();
            //}
            //else
            //{
            //    this.HideDrawTools();
            //}
            //this.m_ParentForm.ToolStripStatusLabel3.Text = "";
        }
        public void ResetToolbar()
        {
            this.myMapTool = CBdTC.MapTools.None;
            this.m_ParentForm.ToolStripStatusLabel3.Text = "";
            this.m_ParentForm.CNToolStripButton.Checked = false;
            this.changechedo();
        }
        public void m_ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.m_ParentForm.CNToolStripButton)
            {
                if (this.m_ParentForm.myPages.Count > 0)
                {
                    this.m_ParentForm.CNToolStripButton.Checked = !this.m_ParentForm.CNToolStripButton.Checked;
                }
                else
                {
                    this.m_ParentForm.CNToolStripButton.Checked = false;
                }
                this.changechedo();
            }
            else if (e.ClickedItem == this.m_ParentForm.SymbolToolStripButton)
            {
                //this.m_Map.CurrentTool = ToolConstants.miArrowTool;
                //if (modBdTC.fCacKyHieu == null)
                //{
                //    this.myMapCurrTool = this.m_Map.CurrentTool;
                //    dlgCacKyHieu dlgCacKyHieu = new dlgCacKyHieu();
                //    this.m_ParentForm.ToolStripStatusLabel3.Text = "AddKH: Click để chọn vi tri ky hieu.";
                //    dlgCacKyHieu.TopMost = true;
                //    dlgCacKyHieu.Show(this.m_ParentForm);
                //}
                //this.OnCapNhatKH();
            }
            else if (e.ClickedItem == this.m_ParentForm.UndoToolStripButton)
            {
                this.OnUndoClick();
            }
            else if (e.ClickedItem == this.m_ParentForm.RedoToolStripButton)
            {
                this.OnRedoClick();
            }
            else if (e.ClickedItem == this.m_ParentForm.MuiTenDonToolStripButton)
            {
                this.OnDrawObj("MuiTenDon");
            }
            else if (e.ClickedItem == this.m_ParentForm.MuiTenDacToolStripButton)
            {
                this.OnDrawObj("MuiTenDac");
            }
            else if (e.ClickedItem == this.m_ParentForm.ClosedCurveToolStripButton)
            {
                modBdTC.defaMyLineStyle = 0;
                this.OnDrawObj("ClosedCurve");
            }
            else if (e.ClickedItem == this.m_ParentForm.CurveToolStripSplitButton)
            {
                modBdTC.defaMyLineStyle = 0;
                this.OnDrawObj("Curve");
            }
            else if (e.ClickedItem == this.m_ParentForm.SongSongKinToolStripButton)
            {
                modBdTC.defaMyLineStyle = 0;
                this.OnDrawObj("SongSongKin");
            }
            else if (e.ClickedItem == this.m_ParentForm.LineToolStripButton)
            {
                modBdTC.defaMyLineStyle = 0;
                this.OnDrawObj("Line");
            }
            else if (e.ClickedItem == this.m_ParentForm.PolygonToolStripButton)
            {
                modBdTC.defaMyLineStyle = 0;
                this.OnDrawObj("Polygon");
            }
            else if (e.ClickedItem == this.m_ParentForm.RectangleToolStripButton)
            {
                modBdTC.defaMyLineStyle = 0;
                this.OnDrawObj("Rectangle");
            }
            else if (e.ClickedItem == this.m_ParentForm.ArcToolStripButton)
            {
                modBdTC.defaMyLineStyle = 0;
                this.OnDrawObj("Arc");
            }
            else if (e.ClickedItem == this.m_ParentForm.EllipseToolStripButton)
            {
                modBdTC.defaMyLineStyle = 0;
                this.OnDrawObj("Ellipse");
            }
            else if (e.ClickedItem == this.m_ParentForm.TextToolStripButton)
            {
                this.OnDrawObj("Text");
            }
            else if (e.ClickedItem == this.m_ParentForm.TableToolStripButton)
            {
                modBdTC.defaMyLineStyle = 0;
                this.OnDrawObj("Table");
            }
            else if (e.ClickedItem == this.m_ParentForm.OptionsToolStripButton)
            {
                //dlgOptions dlgOptions = new dlgOptions();
                //if (dlgOptions.ShowDialog(this.m_ParentForm) == DialogResult.OK)
                //{
                //    modBdTC.Defa2File(modBdTC.myBdTCDefaFile);
                //}
            }
        }
    }
}