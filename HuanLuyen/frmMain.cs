using ADOConnection;
using AxMapXLib;
using MapXLib;
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
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
namespace HuanLuyen
{
	public partial class frmMain : Form
	{
		public enum MapTools
		{
			None,
			NodesEdit,
			FlightEdit,
			DangDoKC,
			DangVeKhuat,
			DangVeTuyen
		}
		private const int PORT_NUM = 10062;
		public ListenerProcess ListenerProcess1;
		private int myMaxLstCount = 0;
		private List<CStrPattern> m_StrPatterns;
		public frmMain.MapTools myMapTool;
		private CSymbols m_DrawingSymbols;
        //private CPages myPages;
        //private CPage CurrPage;
		private bool bLoaded;
		private CTieuDo99 m_TieuDo99;
		private CTieuDo55 m_TieuDo55;
		public CBanDoNen myBanDoNen;
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
		private CTop m_SeleTop;
		private bool m_dirty;
		private List<CRada> m_BaiTapRadas;
		private CRada m_SeleRada;
		private List<CKhuat> m_AllKhuats;
		private List<CKhuat> m_Khuats;
		private CKhuat m_SeleKhuat;
		private CKhuat m_SeleKhuat2;
		private CTop m_EditingTop;
		private CTop m_NewTop;
		private static int cantimTop_ID = 0;
		private static int cantimRada_ID = 0;
		private static int cantimKhuat_ID = 0;
		private DataView dvTops;
		private DataView dvRadas;
		public List<CStrPattern> StrPatterns
		{
			get
			{
				return this.m_StrPatterns;
			}
		}
		public CSymbols DrawingSymbols
		{
			get
			{
				return this.m_DrawingSymbols;
			}
		}
		public CTieuDo99 TieuDo99
		{
			get
			{
				return this.m_TieuDo99;
			}
		}
		public CTieuDo55 TieuDo55
		{
			get
			{
				return this.m_TieuDo55;
			}
		}
		public List<CTop> Tops
		{
			get
			{
				return this.m_Tops;
			}
		}
		public List<CRada> BaiTapRadas
		{
			get
			{
				return this.m_BaiTapRadas;
			}
		}
		public List<CKhuat> AllKhuats
		{
			get
			{
				return this.m_AllKhuats;
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
		public frmMain()
		{
			base.FormClosing += new FormClosingEventHandler(this.frmMain_FormClosing);
			base.Load += new EventHandler(this.frmMain_Load);
			this.myMaxLstCount = 200;
			this.m_DrawingSymbols = new CSymbols();
			//this.myPages = new CPages();
			this.bLoaded = false;
			this.myTblName = "tblAirport";
			this.m_dirty = false;
			this.InitializeComponent();
		}
		
        private void RemConfig()
		{
            //TcpServerChannel chnl = new TcpServerChannel(13340);
            //ChannelServices.RegisterChannel(chnl, false);
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemHuanLuyen), "RemHuanLuyen", WellKnownObjectMode.SingleCall);
		}
		
        private void AddMsg(string statusMessage)
		{
            //if (this.lstStatus.Items.Count > this.myMaxLstCount)
            //{
            //    this.lstStatus.Items.RemoveAt(0);
            //}
            //this.lstStatus.Items.Add(statusMessage);
            //this.lstStatus.SelectedIndex = checked(this.lstStatus.Items.Count - 1);
		}

		private void StartListener()
		{
			this.ListenerProcess1 = new ListenerProcess(10062);
			this.ListenerProcess1.StartThread();
		}
		private void StopListener()
		{
			try
			{
				this.ListenerProcess1.StopThread();
			}
			catch (Exception expr_0D)
			{
				throw expr_0D;
							}
		}
		public List<CAirport> GetAirports()
		{
			return this.m_DrawingAirports;
		}
		public List<CAirport> GetDiaTieus()
		{
			return this.m_DrawingDiaTieus;
		}
		public List<CAirport> GetTramQSs()
		{
			return this.m_DrawingTramQSs;
		}
		private void PopulateKyHieuQS(int pBaiTapID)
		{
            //this.Cursor = Cursors.WaitCursor;
            //this.myPages.Clear();
            //this.m_DrawingSymbols.Clear();
            //try
            //{
            //    string kyHieu = CBaiTaps.GetKyHieu(pBaiTapID);
            //    if (this.myPages.LoadFromStr(kyHieu) && this.myPages.Count > 0)
            //    {
            //        this.CurrPage = this.myPages[0];
            //        CSymbols cSymbols = CSymbols.String2KHs(this.CurrPage.Symbols);
            //        CSymbols drawingSymbols = this.m_DrawingSymbols;
            //        lock (drawingSymbols)
            //        {
            //            this.m_DrawingSymbols.Clear();
            //            foreach(CSymbol aSymbol in cSymbols){
            //                    this.m_DrawingSymbols.Add(aSymbol);
            //                }
						
            //        }
            //        double zoomLevel = modBanDo.GetZoomLevel(this.AxMap1, modBanDo.BDTyLeBanDo);
            //        this.AxMap1.ZoomTo(zoomLevel, modBanDo.BDKinhDo, modBanDo.BDViDo);
            //    }
            //}
            //catch (Exception expr_104)
            //{
            //    throw expr_104;
            //    Exception ex = expr_104;
            //    MessageBox.Show(e.Message,"PopulateKyHieuQS Sai", MessageBoxIcon.Information);
            //                }
            //this.Cursor = Cursors.Default;
            //this.ToolStripStatusLabel2.Text = "m_DrawingSymbolsCount=" + this.m_DrawingSymbols.Count.ToString();
		}
		private bool InitMap()
		{
			bool result = false;
			modBanDo.myMapGstLuu = Path.GetFullPath(modBanDo.myMapGst);
			try
			{
				CBanDoNen.LoadGst(this.AxMap1, modBanDo.myMapGst);
				this.lyrCacKyHieu = this.AxMap1.Layers.AddUserDrawLayer("LopVeKyHieu", 1);
				this.lyrAnimation = this.AxMap1.Layers.AddUserDrawLayer("AnimationLayer", 1);
				this.AxMap1.Layers.AnimationLayer = this.lyrAnimation;
				this.myBanDoNen = new CBanDoNen(this.AxMap1, this, this.ToolStripStatusLabel3, this.ToolStripStatusLabel1);
				result = true;
			}
			catch (Exception expr_91)
			{
				throw expr_91;
							}
			return result;
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
					MessageBox.Show("Không kết nối được với CSDL0.", "Thông báo", MessageBoxButtons.OK);
				}
				else
				{
					connection.Close();
					result = true;
				}
			}
			catch (Exception expr_62)
			{
				throw expr_62;
				MessageBox.Show("Không kết nối được với CSDL.", "Thông báo", MessageBoxButtons.OK);
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
				if (!this.InitMap())
				{
					MessageBox.Show("Init map truc trac, xem lai '*.para'", "Thông báo", MessageBoxButtons.OK);
					//ProjectData.EndApp();
				}
				modBdTC.LoadDefa(modBdTC.myBdTCDefaFile);
				this.AxMap1.CreateCustomTool(2, ToolTypeConstants.miToolTypePoint, CursorConstants.miCrossCursor);
				this.AxMap1.CreateCustomTool(4, ToolTypeConstants.miToolTypePoint, CursorConstants.miArrowQuestionCursor);
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
					this.LoadNodePatterns();
					this.myTblName = "tblAirport";
					this.PopulateAirports();
					this.myTblName = "tblDiaTieu";
					this.PopulateAirports();
					this.myTblName = "tblTramQS";
					this.PopulateAirports();
					this.PopulatePattern4Airport();
				}
			}
			else
			{
				MessageBox.Show("Khong load duoc para", "Thông báo", MessageBoxButtons.OK);
			}
		}
		private void LoadNodePatterns0()
		{
			modHuanLuyen.m_NodePatterns = new Hashtable();
			ArrayList allPatterns = CNodePatterns.GetAllPatterns();
			foreach(CNodePattern cNodePattern in allPatterns){
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
		private void LoadNodePatterns()
		{
			modHuanLuyen.m_NodePatterns = new Hashtable();
			this.m_StrPatterns = CNodePatterns.GetAllStrPatterns();
			foreach(CStrPattern current in this.m_StrPatterns){
					try
					{
						CNodePattern value = CNodePatterns.Str2Pattern(current.StrPattern);
						modHuanLuyen.m_NodePatterns.Add(current.PattNo, value);
					}
					catch (Exception expr_4F)
					{
						throw expr_4F;
						MessageBox.Show("Có Mã số Kiểu ký hiệu trùng: " + current.PattNo.ToString(), "Thông báo", MessageBoxButtons.OK);
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
		private void PopulatePattern4Airport()
		{
			foreach(CAirport current in this.m_DrawingAirports){
					current.Pattern = CNodePatterns.GetPattern(current.SymbolID);
				}
			
			foreach(CAirport current2 in this.m_DrawingDiaTieus){
					current2.Pattern = CNodePatterns.GetPattern(current2.SymbolID);
				}
			
			foreach(CAirport current3 in this.m_DrawingTramQSs){
					current3.Pattern = CNodePatterns.GetPattern(current3.SymbolID);
				}
			
		}
		private void PopulateBaiTaps()
		{
			this.m_BaiTaps = CBaiTaps.GetList();
			this.cboBaiTap.DataSource = this.m_BaiTaps;
			if (this.m_BaiTaps.Count > 0)
			{
				this.cboBaiTap.SelectedIndex = checked(this.m_BaiTaps.Count - 1);
			}
		}
		public void PopulateBaiTaps(int pBaiTapID)
		{
			this.m_BaiTaps = CBaiTaps.GetList();
			this.cboBaiTap.DataSource = this.m_BaiTaps;
			int selectedIndex = -1;
			int num = -1;
			checked
			{
				foreach(CBaiTap current in this.m_BaiTaps){
						num++;
						if (current.BaiTapID == pBaiTapID)
						{
							selectedIndex = num;
							break;
						}
					}
				
				this.cboBaiTap.SelectedIndex = selectedIndex;
			}
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
			foreach(CTop current in this.m_Tops){
					List<PathNode> pathDetails = CTops.GetPathDetails(current.TopID);
					current.Path = pathDetails;
				}
			
			this.PopulateTopGridView();
			foreach(CTop current2 in this.m_Tops){
					current2.TinhYToLuonVong(this.AxMap1);
				}
			
		}
		public void RefreshTopsList(CTop pTop)
		{
			int index = this.m_Tops.IndexOf(pTop);
			this.PopulateTopGridView();
			this.grdTops.Rows[index].Selected = true;
		}
		private void PopulateBaiTapRadas(int pBaiTapID)
		{
			this.m_BaiTapRadas = CBaiTapRadas.GetList(pBaiTapID);
			this.PopulateRadaGridView();
		}
		private void PopulateAllKhuats(int pBaiTapID)
		{
			this.m_AllKhuats = CBaiTapKhuats.GetList(pBaiTapID);
			foreach(CKhuat current in this.m_AllKhuats){
					current.KhuatPts = CBaiTapKhuats.GetKhuatPts(pBaiTapID, current.KhuatID);
				}
			
		}
		private void PopulateKhuats(int pBaiTapID, int pRadaID)
		{
			this.m_Khuats = CBaiTapKhuats.GetList(pBaiTapID, pRadaID);
			foreach(CKhuat current in this.m_Khuats){
					current.KhuatPts = CBaiTapKhuats.GetKhuatPts(pBaiTapID, current.KhuatID);
				}
			
			this.lstKhuat.DataSource = this.m_Khuats;
		}
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.StopListener();
		}
		
        private void frmMain_Load(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
			modHuanLuyen.fMain = this;
			modHuanLuyen.myAppPara = Settings.myAppPara;
			if (File.Exists(modHuanLuyen.myAppPara))
			{
				this.LoadPara(modHuanLuyen.myAppPara);
				this.m_TieuDo99 = new CTieuDo99();
				this.m_TieuDo99.PopulateOLon(modHuanLuyen.myOLon99File);
				this.m_TieuDo99.Populate();
				this.m_TieuDo55 = new CTieuDo55(modHuanLuyen.TieuDo55CX, modHuanLuyen.TieuDo55CY);
				this.m_TieuDo55.PopulateOPhu(modHuanLuyen.myOPhu55File);
				this.m_TieuDo55.Populate();
				this.SetUpGridView(this.grdTops);
				this.SetUpGridView(this.grdRadas);
				this.PopulateBaiTaps();
				this.bLoaded = true;
				this.rbtn99.Checked = true;
				string computerName = myModule.GetComputerName();
				this.StartListener();
				this.RemConfig();
			}
			else
			{
				MessageBox.Show("Khong thay '" + modHuanLuyen.myAppPara + "'. Stop.", "Thông báo", MessageBoxButtons.OK);
			}
		}
		private void AxMap1_DrawUserLayer(object sender, CMapXEvents_DrawUserLayerEvent e)
		{
			Layer layer = (Layer)e.layer;
			IntPtr hdc = new IntPtr(e.hOutputDC);
			Graphics g = Graphics.FromHdc(hdc);
			Pen pen = new Pen(Color.Black);
			Pen pen2 = new Pen(Color.Blue, 1f);
			checked
			{
				if (layer == this.lyrAnimation)
				{
					if (this.m_NewTop != null)
					{
						this.m_NewTop.Draw(this.AxMap1, g, pen2);
						this.m_NewTop.DrawNodes(this.AxMap1, g, modHuanLuyen.fHuanLuyen.iEditNode);
						this.m_NewTop.DrawDuongBay(this.AxMap1, g, pen2, true);
					}
					if (modHuanLuyen.fHuanLuyen != null)
					{
                        IEnumerator enumerator = ((IEnumerable)modHuanLuyen.fHuanLuyen.Flights).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            CFlight cFlight = (CFlight)enumerator.Current;
                            cFlight.DrawMB2(this.AxMap1, g);
                        }
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
					if (this.chkHienKyHieu.Checked)
					{
						this.m_DrawingSymbols.DrawSymbols(this.AxMap1, g);
					}
					foreach(CAirport current in this.m_DrawingTramQSs){
							current.Draw2(this.AxMap1, g);
						}
					
					foreach(CAirport current2 in this.m_DrawingDiaTieus){
							current2.Draw2(this.AxMap1, g);
						}
					
					foreach(CAirport current3 in this.m_DrawingAirports){
							current3.Draw2(this.AxMap1, g);
						}
					
					foreach(CRada current4 in this.m_BaiTapRadas){
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
					foreach(CKhuat current5 in this.m_AllKhuats){
							current5.Draw(this.AxMap1, g, Color.FromArgb(75, Color.Gray));
						}
					
					if (this.m_SeleKhuat != null)
					{
						this.m_SeleKhuat.DrawSele(this.AxMap1, g, Color.Black);
					}
					if (modHuanLuyen.fHuanLuyen != null)
					{
						modHuanLuyen.fHuanLuyen.m_Map_DrawUserLayer(sender, e);
					}
					else if (this.m_Tops.Count > 0)
					{
						foreach(CTop current6 in this.m_Tops){
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
						}
					}
				}
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
				this.PopulateKyHieuQS(this.m_SeleBaiTap.BaiTapID);
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
		public CTop GetTop(int lTop_ID)
		{
			frmMain.cantimTop_ID = lTop_ID;
			return this.m_Tops.Find(new Predicate<CTop>(frmMain.TopIDequal));
		}
		private static bool TopIDequal(CTop pTop)
		{
			return pTop.TopID == frmMain.cantimTop_ID;
		}
		public CRada GetRada(int lRada_ID)
		{
			frmMain.cantimRada_ID = lRada_ID;
			return this.m_BaiTapRadas.Find(new Predicate<CRada>(frmMain.RadaIDequal));
		}
		private static bool RadaIDequal(CRada pRada)
		{
			return pRada.RadaID == frmMain.cantimRada_ID;
		}
		public CKhuat GetKhuat(int lKhuat_ID)
		{
			frmMain.cantimKhuat_ID = lKhuat_ID;
			return this.m_Khuats.Find(new Predicate<CKhuat>(frmMain.KhuatIDequal));
		}
		private static bool KhuatIDequal(CKhuat pKhuat)
		{
			return pKhuat.KhuatID == frmMain.cantimKhuat_ID;
		}
		public CAirport FindAirportAt(PointF pPt)
		{
			return CAirports.FindAtPoint(this.AxMap1, pPt, this.m_DrawingAirports);
		}
		private void AxMap1_MouseDownEvent(object sender, CMapXEvents_MouseDownEvent e)
		{
			this.myBanDoNen.m_Map_MouseDownEvent(sender, e);
			checked
			{
				if (this.AxMap1.CurrentTool == ToolConstants.miArrowTool)
				{
					if (modHuanLuyen.fHuanLuyen != null)
					{
						modHuanLuyen.fHuanLuyen.m_Map_MouseDownEvent(sender, e);
					}
					else
					{
						AxMap arg_66_0 = this.AxMap1;
						PointF pt = new PointF(e.x, e.y);
						this.m_SeleKhuat = CKhuats.FindAtPoint(arg_66_0, pt, this.m_AllKhuats);
						if (this.m_SeleKhuat != null)
						{
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
							if (e.button == 2)
							{
                                //this.m_SeleKhuat2 = this.m_SeleKhuat;
                                //ToolStripDropDown arg_14B_0 = this.KhuatContextMenuStrip;
                                //Control arg_14B_1 = this.PanelRight;
                                //System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                //arg_14B_0.Show(arg_14B_1, position);
							}
							CKhuat khuat = this.GetKhuat(this.m_SeleKhuat.KhuatID);
							this.lstKhuat.SelectedIndex = this.m_Khuats.IndexOf(khuat);
						}
						else
						{
							AxMap arg_1A0_0 = this.AxMap1;
							pt = new PointF(e.x, e.y);
							this.m_SeleRada = CRadas.FindAtPoint(arg_1A0_0, pt, this.m_BaiTapRadas);
							if (this.m_SeleRada != null)
							{
								int num2 = this.m_BaiTapRadas.IndexOf(this.m_SeleRada);
								this.grdRadas.Rows[num2].Selected = true;
								this.grdRadas.FirstDisplayedScrollingRowIndex = num2;
								CBaiTap cBaiTap2 = (CBaiTap)this.cboBaiTap.SelectedItem;
								this.PopulateKhuats(cBaiTap2.BaiTapID, this.m_SeleRada.RadaID);
								this.lyrCacKyHieu.Invalidate(Missing.Value);
								if (e.button == 2)
								{
                                    //ToolStripDropDown arg_260_0 = this.RadaContextMenuStrip;
                                    //Control arg_260_1 = this.PanelRight;
                                    //System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                    //arg_260_0.Show(arg_260_1, position);
								}
							}
							else
							{
								AxMap arg_28C_0 = this.AxMap1;
								pt = new PointF(e.x, e.y);
								this.m_SeleTop = CTops.FindAtPoint(arg_28C_0, pt, this.m_Tops);
								if (this.m_SeleTop != null)
								{
									int num3 = this.m_Tops.IndexOf(this.m_SeleTop);
									this.grdTops.Rows[num3].Selected = true;
									this.grdTops.FirstDisplayedScrollingRowIndex = num3;
									this.lyrCacKyHieu.Invalidate(Missing.Value);
									if (e.button == 2)
									{
                                        //ToolStripDropDown arg_324_0 = this.TopContextMenuStrip;
                                        //Control arg_324_1 = this.PanelRight;
                                        //System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                        //arg_324_0.Show(arg_324_1, position);
									}
								}
								else
								{
									AxMap arg_34D_0 = this.AxMap1;
									pt = new PointF(e.x, e.y);
									this.m_SelectedAirport = CAirports.FindAtPoint(arg_34D_0, pt, this.m_DrawingAirports);
									if (this.m_SelectedAirport != null)
									{
										this.myTblName = "tblAirport";
										if (e.button == 2)
										{
                                            //ToolStripDropDown arg_3A2_0 = this.AirportContextMenuStrip;
                                            //Control arg_3A2_1 = this.PanelRight;
                                            //System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                                            //arg_3A2_0.Show(arg_3A2_1, position);
										}
									}
								}
							}
						}
					}
				}
			}
		}
		public string GetToaDo99(double mLon, double mLat)
		{
			return this.m_TieuDo99.getToaDo(mLon, mLat);
		}
		public string GetToaDo55(double mLon, double mLat)
		{
			return this.m_TieuDo55.getToaDo(this.AxMap1, mLon, mLat);
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
					text = Convert.ToString(Interaction.IIf(text.Length > 0, "Tọa độ 5x5 = " + text, "Ngoài Tiêu đồ 5x5"));
				}
				else
				{
					text = this.m_TieuDo99.getToaDo(pPosX, pPosY);
					text = Convert.ToString(Interaction.IIf(text.Length > 0, "Tọa độ 9x9 = " + text, "Ngoài Tiêu đồ 9x9"));
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
			this.myBanDoNen.m_Map_MouseMoveEvent(sender, e);
		}
		private void UnseleKH()
		{
			this.myMapTool = frmMain.MapTools.None;
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
				this.myMapTool = frmMain.MapTools.DangDoKC;
				this.myBanDoNen.OnDoKhoangCach();
				this.UnseleKH();
			}
		}
		private void btnBaiTapUpdate_Click(object sender, EventArgs e)
		{
			if (this.cboBaiTap.SelectedItem != null)
			{
				dlgBaiTapHinhThai dlgBaiTapHinhThai = new dlgBaiTapHinhThai();
				dlgBaiTapHinhThai.ShowDialog(this);
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
		private void RadaNewKhuatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.m_SeleRada != null && MessageBox.Show("Vẽ vùng Khuất mới cho Rada " + this.m_SeleRada.Ten + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.grdRadas.Enabled = false;
				this.myMapTool = frmMain.MapTools.DangVeKhuat;
				this.ToolStripStatusLabel3.Text = "Vẽ vùng Khuất = đa giác: Click để chọn đỉnh, RightClick để kết thúc.";
				this.myBanDoNen.OnVePolygon();
			}
		}
		private void myBanDoNen_VeLaiPolygonXong(List<MapPoint> pMapPts)
		{
			this.myMapTool = frmMain.MapTools.None;
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
						foreach(MapPoint current in pMapPts){
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
				this.grdRadas.Enabled = true;
				this.lyrCacKyHieu.Invalidate(Missing.Value);
				SendKeys.Send("{ESC}");
			}
		}
		private int GetNewKhuatID(int pBaiTapID)
		{
			int num = 0;
			foreach(CKhuat current in this.m_AllKhuats){
					if (current.KhuatID > num)
					{
						num = current.KhuatID;
					}
				}
			
			checked
			{
				num++;
				return num;
			}
		}
		private void myBanDoNen_VeLaiPolylineXong(List<MapPoint> pMapPts)
		{
            //this.myMapTool = frmMain.MapTools.None;
            //this.ToolStripStatusLabel3.Text = "";
            //if (pMapPts.Count > 1)
            //{
            //    if (new dlgFlightDoiHuong
            //    {
            //        TopMost = true
            //    }.ShowDialog(this, pMapPts) == DialogResult.OK)
            //    {
            //    }
            //    SendKeys.Send("{ESC}");
            //}
		}
		private void myBanDoNen_VePolygonXong(List<MapPoint> pMapPts)
		{
			this.myMapTool = frmMain.MapTools.None;
			this.ToolStripStatusLabel3.Text = "";
			if (pMapPts.Count > 1)
			{
				if (this.m_SeleRada != null)
				{
					CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
					CRada seleRada = this.m_SeleRada;
					CKhuat cKhuat = new CKhuat();
					cKhuat.RadaID = seleRada.RadaID;
					int newKhuatID = this.GetNewKhuatID(cBaiTap.BaiTapID);
					cKhuat.KhuatID = newKhuatID;
					CBaiTapKhuats.Insert(cBaiTap.BaiTapID, cKhuat);
					List<CKhuatPt> list = new List<CKhuatPt>();
					foreach(MapPoint current in pMapPts){
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
		private void KhuatReDrawToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.lstKhuat.SelectedItem != null && MessageBox.Show("Vẽ lại vùng Khuất này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.grdRadas.Enabled = false;
				this.lstKhuat.Enabled = false;
				this.myMapTool = frmMain.MapTools.DangVeKhuat;
				this.ToolStripStatusLabel3.Text = "Vẽ lại vùng khuất: Click để chọn đỉnh của đa giác, RightClick để kết thúc.";
				this.myBanDoNen.OnVeLaiPolygon();
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
		private void btnXemBaiTap_Click(object sender, EventArgs e)
		{
			if (this.cboBaiTap.SelectedItem != null)
			{
				dlgBaiTapHinhThai dlgBaiTapHinhThai = new dlgBaiTapHinhThai();
				dlgBaiTapHinhThai.ShowDialog(this);
			}
		}
		private void rbtn55_CheckedChanged(object sender, EventArgs e)
		{
			if (this.bLoaded)
			{
				this.lyrCacKyHieu.Invalidate(Missing.Value);
			}
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
		private void myBanDoNen_VePolylineXong(List<MapPoint> pMapPts)
		{
            //this.myMapTool = frmMain.MapTools.None;
            //this.ToolStripStatusLabel3.Text = "";
            //checked
            //{
            //    if (pMapPts.Count > 1)
            //    {
            //        dlgFlightMoi dlgFlightMoi = new dlgFlightMoi();
            //        TextBox arg_48_0 = dlgFlightMoi.txtPosFromX;
            //        MapPoint mapPoint = pMapPts[0];
            //        arg_48_0.Text = mapPoint.x.ToString("#.00000000");
            //        TextBox arg_6C_0 = dlgFlightMoi.txtPosFromY;
            //        mapPoint = pMapPts[0];
            //        arg_6C_0.Text = mapPoint.y.ToString("#.00000000");
            //        TextBox arg_97_0 = dlgFlightMoi.txtPosToX;
            //        mapPoint = pMapPts[pMapPts.Count - 1];
            //        arg_97_0.Text = mapPoint.x.ToString("#.00000000");
            //        TextBox arg_C2_0 = dlgFlightMoi.txtPosToY;
            //        mapPoint = pMapPts[pMapPts.Count - 1];
            //        arg_C2_0.Text = mapPoint.y.ToString("#.00000000");
            //        dlgFlightMoi.TopMost = true;
            //        if (dlgFlightMoi.ShowDialog(this, pMapPts) == DialogResult.OK)
            //        {
            //            this.RefreshTopsList(this.m_SeleTop);
            //        }
            //        SendKeys.Send("{ESC}");
            //    }
            //}
		}
		public void VeTopMoi(System.Drawing.Point pPt)
		{
			this.myMapTool = frmMain.MapTools.DangVeTuyen;
			this.ToolStripStatusLabel3.Text = "Vẽ tốp: vẽ đường gấp khúc = Click để chọn điểm bay, RightClick để kết thúc.";
			this.myBanDoNen.OnVePolyline(pPt);
		}
		public void VeTopTach(MapPoint pMapPt)
		{
			this.myMapTool = frmMain.MapTools.DangVeTuyen;
			this.ToolStripStatusLabel3.Text = "Vẽ tốp: vẽ đường gấp khúc = Click để chọn điểm bay, RightClick để kết thúc.";
			System.Drawing.Point mousePT = default(System.Drawing.Point);
			AxMap arg_4A_0 = this.AxMap1;
			float num = (float)mousePT.X;
			float num2 = (float)mousePT.Y;
			arg_4A_0.ConvertCoord(ref num, ref num2, ref pMapPt.x, ref pMapPt.y, ConversionConstants.miMapToScreen);
			checked
			{
				mousePT.Y = (int)Math.Round((double)num2);
				mousePT.X = (int)Math.Round((double)num);
				this.myBanDoNen.OnVeTachPolyline(mousePT);
			}
		}
		public void VeTopLai(MapPoint pMapPt)
		{
			this.myMapTool = frmMain.MapTools.DangVeTuyen;
			this.ToolStripStatusLabel3.Text = "Vẽ tốp: vẽ đường gấp khúc = Click để chọn điểm bay, RightClick để kết thúc.";
			System.Drawing.Point mousePT = default(System.Drawing.Point);
			AxMap arg_4A_0 = this.AxMap1;
			float num = (float)mousePT.X;
			float num2 = (float)mousePT.Y;
			arg_4A_0.ConvertCoord(ref num, ref num2, ref pMapPt.x, ref pMapPt.y, ConversionConstants.miMapToScreen);
			checked
			{
				mousePT.Y = (int)Math.Round((double)num2);
				mousePT.X = (int)Math.Round((double)num);
				this.myBanDoNen.OnVeLaiPolyline(mousePT);
			}
		}
		private void btnHuanLuyen_Click(object sender, EventArgs e)
		{
			if (this.m_Tops.Count > 0)
			{
				new dlgHuanLuyen
				{
					TopMost = true
				}.Show(this, this.m_BaiTapRadas);
				this.lyrCacKyHieu.Invalidate(Missing.Value);
			}
		}
		private void AxMap1_ToolUsed(object sender, CMapXEvents_ToolUsedEvent e)
		{
			if (e.toolNum == 4 && modHuanLuyen.fFlightNodeEdit != null)
			{
				PointF pt = default(PointF);
				AxMap arg_4B_0 = this.AxMap1;
				float x = pt.X;
				float y = pt.Y;
				arg_4B_0.ConvertCoord(ref x, ref y, ref e.x1, ref e.y1, ConversionConstants.miMapToScreen);
				pt.Y = y;
				pt.X = x;
				MapPoint mapPoint = default(MapPoint);
				if (modHuanLuyen.fFlightNodeEdit.rbtnTheoDiaTieu.Checked)
				{
					CAirport cAirport = CAirports.FindAtPoint(this.AxMap1, pt, this.m_DrawingDiaTieus);
					if (cAirport != null)
					{
						modHuanLuyen.fFlightNodeEdit.txtSBTo_ID.Text = cAirport.SB_ID.ToString();
						modHuanLuyen.fFlightNodeEdit.txtName.Text = cAirport.Name;
						mapPoint.x = cAirport.Pos.x;
						mapPoint.y = cAirport.Pos.y;
					}
					else
					{
						modHuanLuyen.fFlightNodeEdit.txtSBTo_ID.Text = "-1";
						modHuanLuyen.fFlightNodeEdit.txtName.Text = "";
						mapPoint.x = e.x1;
						mapPoint.y = e.y1;
					}
				}
				else if (modHuanLuyen.fFlightNodeEdit.rbtnTheoLonLat.Checked)
				{
					mapPoint.x = e.x1;
					mapPoint.y = e.y1;
				}
				if (modHuanLuyen.fFlightNodeEdit.rbtnQuanhDiem.Checked)
				{
					modHuanLuyen.fFlightNodeEdit.txtCX.Text = mapPoint.x.ToString("#.00000000");
					modHuanLuyen.fFlightNodeEdit.txtCY.Text = mapPoint.y.ToString("#.00000000");
				}
				else if (modHuanLuyen.fFlightNodeEdit.rbtnHuongDiem.Checked)
				{
					modHuanLuyen.fFlightNodeEdit.txtDpX.Text = mapPoint.x.ToString("#.00000000");
					modHuanLuyen.fFlightNodeEdit.txtDpY.Text = mapPoint.y.ToString("#.00000000");
				}
				else
				{
					modHuanLuyen.fFlightNodeEdit.txtPosX.Text = mapPoint.x.ToString("#.00000000");
					modHuanLuyen.fFlightNodeEdit.txtPosY.Text = mapPoint.y.ToString("#.00000000");
				}
				this.lyrCacKyHieu.Invalidate(Missing.Value);
				this.AxMap1.CurrentTool = ToolConstants.miArrowTool;
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
		private void ListenerProcess1_Connected(ListenerProcess sender, string userName, UserConnection userconnection)
		{
			this.AddMsg(userconnection.Name + " đã kết nối");
		}
		private void ListenerProcess1_Disconnected(ListenerProcess sender, UserConnection userconnection)
		{
			this.AddMsg(userconnection.Name + " ngắt kết nối");
		}
		private void ListenerProcess1_UnknownMessage(ListenerProcess sender, string msg, UserConnection userconnection)
		{
			this.AddMsg("Unknown message:" + msg);
		}
		public void SendBanTinGan(string pTinhBao)
		{
			if (pTinhBao.Length > 0)
			{
				this.ListenerProcess1.Broadcast("TBGan", "BROAD|" + pTinhBao);
			}
		}
		public void SendBanTin55(string pTinhBao)
		{
			if (pTinhBao.Length > 0)
			{
				this.ListenerProcess1.Broadcast("TB5x5", "BROAD|" + pTinhBao);
			}
		}
		public void SendBanTin99(string pTinhBao)
		{
			if (pTinhBao.Length > 0)
			{
				this.ListenerProcess1.Broadcast("TB9x9", "BROAD|" + pTinhBao);
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
			checked
			{
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
			foreach(CTop current in this.m_Tops){
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
			return Convert.ToString(pLoaiTopID == 1 ? "Địch" : pLoaiTopID == 3 ? "Qtế" : pLoaiTopID == 4 ? "QCảnh": "Ta");
		}
		private void PopulateRadaGridView()
		{
			this.grdRadas.DataSource = null;
			DataTable dataTable = this.GetdtRadas();
			this.dvRadas = dataTable.DefaultView;
			this.grdRadas.DataSource = this.dvRadas;
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
			checked
			{
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
			foreach(CRada current in this.m_BaiTapRadas){
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

			return Convert.ToString(Interaction.IIf(pLoaiRadaID == 3, "DĐ", RuntimeHelpers.GetObjectValue(Interaction.IIf(pLoaiRadaID == 2, "HL", "CG"))));
		}
		private void lstBaiTapTop_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.m_SeleTop != null)
			{
				this.m_SeleTop = this.m_SeleTop;
				if (!this.AxMap1.IsPointVisible((this.m_SeleTop.PosFrom.x + this.m_SeleTop.PosTo.x) / 2.0, (this.m_SeleTop.PosFrom.y + this.m_SeleTop.PosTo.y) / 2.0))
				{
					this.AxMap1.ZoomTo(this.AxMap1.Zoom, this.m_SeleTop.PosFrom.x, this.m_SeleTop.PosFrom.y);
				}
				else
				{
					this.lyrCacKyHieu.Invalidate(Missing.Value);
				}
			}
		}
		private void lstBaiTapRada_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.m_SeleRada != null)
			{
				this.m_SeleRada = this.m_SeleRada;
				CBaiTap cBaiTap = (CBaiTap)this.cboBaiTap.SelectedItem;
				this.PopulateKhuats(cBaiTap.BaiTapID, this.m_SeleRada.RadaID);
				this.lyrCacKyHieu.Invalidate(Missing.Value);
			}
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
		private void myBanDoNen_TachPolylineXong(List<MapPoint> pMapPts)
		{
            //this.myMapTool = frmMain.MapTools.None;
            //this.ToolStripStatusLabel3.Text = "";
            //if (pMapPts.Count > 1)
            //{
            //    if (new dlgFlightTach
            //    {
            //        txtFlightNo = 
            //        {
            //            Text = modHuanLuyen.fHuanLuyen.TachFlight.FlightNo + " (tach)"
            //        },
            //        TopMost = true
            //    }.ShowDialog(this, pMapPts) == DialogResult.OK)
            //    {
            //    }
            //    SendKeys.Send("{ESC}");
            //}
		}
		
		private void chkHienKyHieu_CheckedChanged(object sender, EventArgs e)
		{
			if (this.bLoaded)
			{
				this.lyrCacKyHieu.Invalidate(Missing.Value);
			}
		}
	}
}