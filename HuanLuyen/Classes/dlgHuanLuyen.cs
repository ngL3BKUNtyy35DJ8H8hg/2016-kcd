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
public class dlgHuanLuyen : Form
{
private IContainer components;
[AccessedThroughProperty("GroupBox1")]
private GroupBox _GroupBox1;
[AccessedThroughProperty("btnStart")]
private Button _btnStart;
[AccessedThroughProperty("lblDongHo")]
private System.Windows.Forms.Label _lblDongHo;
[AccessedThroughProperty("NewContextMenuStrip")]
private ContextMenuStrip _NewContextMenuStrip;
[AccessedThroughProperty("NewTopToolStripMenuItem")]
private ToolStripMenuItem _NewTopToolStripMenuItem;
[AccessedThroughProperty("MayBayContextMenuStrip")]
private ContextMenuStrip _MayBayContextMenuStrip;
[AccessedThroughProperty("MayBayStopToolStripMenuItem")]
private ToolStripMenuItem _MayBayStopToolStripMenuItem;
[AccessedThroughProperty("ToolStripSeparator1")]
private ToolStripSeparator _ToolStripSeparator1;
[AccessedThroughProperty("MayBayAddNodeToolStripMenuItem")]
private ToolStripMenuItem _MayBayAddNodeToolStripMenuItem;
[AccessedThroughProperty("FlightNodeContextMenuStrip")]
private ContextMenuStrip _FlightNodeContextMenuStrip;
[AccessedThroughProperty("FlightNodeAddToolStripMenuItem")]
private ToolStripMenuItem _FlightNodeAddToolStripMenuItem;
[AccessedThroughProperty("ToolStripSeparator3")]
private ToolStripSeparator _ToolStripSeparator3;
[AccessedThroughProperty("FlightNodeDeleteToolStripMenuItem")]
private ToolStripMenuItem _FlightNodeDeleteToolStripMenuItem;
[AccessedThroughProperty("ToolStripSeparator4")]
private ToolStripSeparator _ToolStripSeparator4;
[AccessedThroughProperty("FlightNodeUpdateToolStripMenuItem")]
private ToolStripMenuItem _FlightNodeUpdateToolStripMenuItem;
[AccessedThroughProperty("Panel1")]
private Panel _Panel1;
[AccessedThroughProperty("Splitter1")]
private Splitter _Splitter1;
[AccessedThroughProperty("Panel2")]
private Panel _Panel2;
[AccessedThroughProperty("Label4")]
private System.Windows.Forms.Label _Label4;
[AccessedThroughProperty("rbtThuc")]
private RadioButton _rbtThuc;
[AccessedThroughProperty("rbtBaiTap")]
private RadioButton _rbtBaiTap;
[AccessedThroughProperty("lblThoiGianBT")]
private System.Windows.Forms.Label _lblThoiGianBT;
[AccessedThroughProperty("txtBanTinGan")]
private TextBox _txtBanTinGan;
[AccessedThroughProperty("TabControl1")]
private TabControl _TabControl1;
[AccessedThroughProperty("TabPage1")]
private TabPage _TabPage1;
[AccessedThroughProperty("TabPage2")]
private TabPage _TabPage2;
[AccessedThroughProperty("txtBanTin55")]
private TextBox _txtBanTin55;
[AccessedThroughProperty("TabPage3")]
private TabPage _TabPage3;
[AccessedThroughProperty("txtBanTin99")]
private TextBox _txtBanTin99;
[AccessedThroughProperty("lblTdBatDau")]
private System.Windows.Forms.Label _lblTdBatDau;
[AccessedThroughProperty("grdTops")]
private DataGridView _grdTops;
[AccessedThroughProperty("ToolStripSeparator2")]
private ToolStripSeparator _ToolStripSeparator2;
[AccessedThroughProperty("MayBayTachTopToolStripMenuItem")]
private ToolStripMenuItem _MayBayTachTopToolStripMenuItem;
[AccessedThroughProperty("ToolStripSeparator5")]
private ToolStripSeparator _ToolStripSeparator5;
[AccessedThroughProperty("MayBayDoiHuongToolStripMenuItem")]
private ToolStripMenuItem _MayBayDoiHuongToolStripMenuItem;
[AccessedThroughProperty("chkHienKyHieu")]
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
private CFlight m_SeleFlight;
private CFlight m_EditingFlight;
private CFlight m_TachFlight;
private CFlight m_DoiHuongFlight;
public DateTime newDeparture;
public CMayBay newMayBay;
public int iEditNode = 0;
private System.Drawing.Point myPt = 0;
private List<CRada> m_BaiTapRadas;
private CRada m_SeleRada;
private CRadaFlight[,] m_RadaFlights;
private bool bLoaded;
[AccessedThroughProperty("HLProcess1")]
private CHLProcess _HLProcess1;
private DataView dvTops;
private static int cantimFlight_ID = 0;

public List<CTinhHuong> TinhHuongs
{
get
{
return this.m_TinhHuongs;
}
}
public object Flights
{
get
{
return this.m_Flights;
}
set
{
this.m_Flights = (List<CFlight>)value;
}
}
public CFlight EditingFlight
{
get
{
return this.m_EditingFlight;
}
set
{
this.m_EditingFlight = value;
}
}
public CFlight TachFlight
{
get
{
return this.m_TachFlight;
}
set
{
this.m_TachFlight = value;
}
}
public CFlight DoiHuongFlight
{
get
{
return this.m_DoiHuongFlight;
}
set
{
this.m_DoiHuongFlight = value;
}
}
private virtual CHLProcess HLProcess1
{
get
{
return this._HLProcess1;
}
[MethodImpl(MethodImplOptions.Synchronized)]
set
{
CHLProcess.UpdateXongEventHandler obj = new CHLProcess.UpdateXongEventHandler(this.HLProcess1_UpdateXong);
if (this._HLProcess1 != null)
{
this._HLProcess1.UpdateXong -= obj;
}
this._HLProcess1 = value;
if (this._HLProcess1 != null)
{
this._HLProcess1.UpdateXong += obj;
}
}
}
public dlgHuanLuyen()
{
base.FormClosing += new FormClosingEventHandler(this.dlgHuanLuyen_FormClosing);
base.Load += new EventHandler(this.dlgHuanLuyen_Load);
this.m_Phut = 0;
this.myPt = default(System.Drawing.Point);
this.bLoaded = false;
this.InitializeComponent();
}
[DebuggerNonUserCode]
protected override void Dispose(bool disposing)
{
try
{
if (disposing && this.components != null)
{
this.components.Dispose();
}
}
finally
{
base.Dispose(disposing);
}
}
[DebuggerStepThrough]
private void InitializeComponent()
{
this.components = new Container();
this.GroupBox1 = new GroupBox();
this.lblThoiGianBT = new System.Windows.Forms.Label();
this.rbtThuc = new RadioButton();
this.rbtBaiTap = new RadioButton();
this.lblDongHo = new System.Windows.Forms.Label();
this.btnStart = new Button();
this.NewContextMenuStrip = new ContextMenuStrip(this.components);
this.NewTopToolStripMenuItem = new ToolStripMenuItem();
this.MayBayContextMenuStrip = new ContextMenuStrip(this.components);
this.MayBayStopToolStripMenuItem = new ToolStripMenuItem();
this.ToolStripSeparator1 = new ToolStripSeparator();
this.MayBayAddNodeToolStripMenuItem = new ToolStripMenuItem();
this.ToolStripSeparator2 = new ToolStripSeparator();
this.MayBayTachTopToolStripMenuItem = new ToolStripMenuItem();
this.ToolStripSeparator5 = new ToolStripSeparator();
this.MayBayDoiHuongToolStripMenuItem = new ToolStripMenuItem();
this.FlightNodeContextMenuStrip = new ContextMenuStrip(this.components);
this.FlightNodeAddToolStripMenuItem = new ToolStripMenuItem();
this.ToolStripSeparator3 = new ToolStripSeparator();
this.FlightNodeDeleteToolStripMenuItem = new ToolStripMenuItem();
this.ToolStripSeparator4 = new ToolStripSeparator();
this.FlightNodeUpdateToolStripMenuItem = new ToolStripMenuItem();
this.Panel1 = new Panel();
this.lblTdBatDau = new System.Windows.Forms.Label();
this.TabControl1 = new TabControl();
this.TabPage1 = new TabPage();
this.txtBanTinGan = new TextBox();
this.TabPage2 = new TabPage();
this.txtBanTin55 = new TextBox();
this.TabPage3 = new TabPage();
this.txtBanTin99 = new TextBox();
this.Label4 = new System.Windows.Forms.Label();
this.Splitter1 = new Splitter();
this.Panel2 = new Panel();
this.grdTops = new DataGridView();
this.chkHienKyHieu = new CheckBox();
this.GroupBox1.SuspendLayout();
this.NewContextMenuStrip.SuspendLayout();
this.MayBayContextMenuStrip.SuspendLayout();
this.FlightNodeContextMenuStrip.SuspendLayout();
this.Panel1.SuspendLayout();
this.TabControl1.SuspendLayout();
this.TabPage1.SuspendLayout();
this.TabPage2.SuspendLayout();
this.TabPage3.SuspendLayout();
this.Panel2.SuspendLayout();
((ISupportInitialize)this.grdTops).BeginInit();
this.SuspendLayout();
this.GroupBox1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
this.GroupBox1.Controls.Add(this.lblThoiGianBT);
this.GroupBox1.Controls.Add(this.rbtThuc);
this.GroupBox1.Controls.Add(this.rbtBaiTap);
Control arg_289_0 = this.GroupBox1;
System.Drawing.Point location = new System.Drawing.Point(9, 10);
arg_289_0.Location = location;
this.GroupBox1.Name = "GroupBox1";
Control arg_2B3_0 = this.GroupBox1;
Size size = new Size(244, 73);
arg_2B3_0.Size = size;
this.GroupBox1.TabIndex = 0;
this.GroupBox1.TabStop = false;
this.GroupBox1.Text = "Huấn luyện theo: ";
this.lblThoiGianBT.AutoSize = true;
Control arg_301_0 = this.lblThoiGianBT;
location = new System.Drawing.Point(138, 22);
arg_301_0.Location = location;
this.lblThoiGianBT.Name = "lblThoiGianBT";
Control arg_328_0 = this.lblThoiGianBT;
size = new Size(38, 13);
arg_328_0.Size = size;
this.lblThoiGianBT.TabIndex = 16;
this.lblThoiGianBT.Text = "Label2";
this.rbtThuc.AutoSize = true;
Control arg_368_0 = this.rbtThuc;
location = new System.Drawing.Point(28, 43);
arg_368_0.Location = location;
this.rbtThuc.Name = "rbtThuc";
Control arg_38F_0 = this.rbtThuc;
size = new Size(93, 17);
arg_38F_0.Size = size;
this.rbtThuc.TabIndex = 1;
this.rbtThuc.Text = "Thời gian thực";
this.rbtThuc.UseVisualStyleBackColor = true;
this.rbtBaiTap.AutoSize = true;
this.rbtBaiTap.Checked = true;
Control arg_3E6_0 = this.rbtBaiTap;
location = new System.Drawing.Point(28, 20);
arg_3E6_0.Location = location;
this.rbtBaiTap.Name = "rbtBaiTap";
Control arg_40D_0 = this.rbtBaiTap;
size = new Size(104, 17);
arg_40D_0.Size = size;
this.rbtBaiTap.TabIndex = 0;
this.rbtBaiTap.TabStop = true;
this.rbtBaiTap.Text = "Thời gian Bài tập";
this.rbtBaiTap.UseVisualStyleBackColor = true;
this.lblDongHo.AutoSize = true;
this.lblDongHo.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
this.lblDongHo.ForeColor = Color.Blue;
Control arg_491_0 = this.lblDongHo;
location = new System.Drawing.Point(19, 119);
arg_491_0.Location = location;
this.lblDongHo.Name = "lblDongHo";
Control arg_4B8_0 = this.lblDongHo;
size = new Size(121, 16);
arg_4B8_0.Size = size;
this.lblDongHo.TabIndex = 60;
this.lblDongHo.Text = "Dong ho huan luyen";
this.btnStart.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
Control arg_4FC_0 = this.btnStart;
location = new System.Drawing.Point(132, 89);
arg_4FC_0.Location = location;
this.btnStart.Name = "btnStart";
Control arg_523_0 = this.btnStart;
size = new Size(121, 23);
arg_523_0.Size = size;
this.btnStart.TabIndex = 61;
this.btnStart.Text = "Bắt đầu huấn luyện";
this.btnStart.UseVisualStyleBackColor = true;
this.NewContextMenuStrip.Items.AddRange(new ToolStripItem[]
{
this.NewTopToolStripMenuItem
});
this.NewContextMenuStrip.Name = "NewContextMenuStrip";
Control arg_59A_0 = this.NewContextMenuStrip;
size = new Size(142, 26);
arg_59A_0.Size = size;
this.NewTopToolStripMenuItem.Name = "NewTopToolStripMenuItem";
ToolStripItem arg_5C4_0 = this.NewTopToolStripMenuItem;
size = new Size(141, 22);
arg_5C4_0.Size = size;
this.NewTopToolStripMenuItem.Text = "Tốp bay mới";
this.MayBayContextMenuStrip.Items.AddRange(new ToolStripItem[]
{
this.MayBayStopToolStripMenuItem,
this.ToolStripSeparator1,
this.MayBayAddNodeToolStripMenuItem,
this.ToolStripSeparator2,
this.MayBayTachTopToolStripMenuItem,
this.ToolStripSeparator5,
this.MayBayDoiHuongToolStripMenuItem
});
this.MayBayContextMenuStrip.Name = "SanBayContextMenuStrip";
Control arg_65E_0 = this.MayBayContextMenuStrip;
size = new Size(153, 110);
arg_65E_0.Size = size;
this.MayBayStopToolStripMenuItem.Name = "MayBayStopToolStripMenuItem";
ToolStripItem arg_688_0 = this.MayBayStopToolStripMenuItem;
size = new Size(152, 22);
arg_688_0.Size = size;
this.MayBayStopToolStripMenuItem.Text = "Dừng bay";
this.ToolStripSeparator1.Name = "ToolStripSeparator1";
ToolStripItem arg_6C1_0 = this.ToolStripSeparator1;
size = new Size(149, 6);
arg_6C1_0.Size = size;
this.MayBayAddNodeToolStripMenuItem.Name = "MayBayAddNodeToolStripMenuItem";
ToolStripItem arg_6EB_0 = this.MayBayAddNodeToolStripMenuItem;
size = new Size(152, 22);
arg_6EB_0.Size = size;
this.MayBayAddNodeToolStripMenuItem.Text = "Thêm điểm";
this.ToolStripSeparator2.Name = "ToolStripSeparator2";
ToolStripItem arg_724_0 = this.ToolStripSeparator2;
size = new Size(149, 6);
arg_724_0.Size = size;
this.MayBayTachTopToolStripMenuItem.Name = "MayBayTachTopToolStripMenuItem";
ToolStripItem arg_74E_0 = this.MayBayTachTopToolStripMenuItem;
size = new Size(152, 22);
arg_74E_0.Size = size;
this.MayBayTachTopToolStripMenuItem.Text = "Tách tốp";
this.ToolStripSeparator5.Name = "ToolStripSeparator5";
ToolStripItem arg_787_0 = this.ToolStripSeparator5;
size = new Size(149, 6);
arg_787_0.Size = size;
this.MayBayDoiHuongToolStripMenuItem.Name = "MayBayDoiHuongToolStripMenuItem";
ToolStripItem arg_7B1_0 = this.MayBayDoiHuongToolStripMenuItem;
size = new Size(152, 22);
arg_7B1_0.Size = size;
this.MayBayDoiHuongToolStripMenuItem.Text = "Đổi hướng bay";
this.FlightNodeContextMenuStrip.Items.AddRange(new ToolStripItem[]
{
this.FlightNodeAddToolStripMenuItem,
this.ToolStripSeparator3,
this.FlightNodeDeleteToolStripMenuItem,
this.ToolStripSeparator4,
this.FlightNodeUpdateToolStripMenuItem
});
this.FlightNodeContextMenuStrip.Name = "SanBayContextMenuStrip";
Control arg_837_0 = this.FlightNodeContextMenuStrip;
size = new Size(153, 82);
arg_837_0.Size = size;
this.FlightNodeAddToolStripMenuItem.Name = "FlightNodeAddToolStripMenuItem";
ToolStripItem arg_861_0 = this.FlightNodeAddToolStripMenuItem;
size = new Size(152, 22);
arg_861_0.Size = size;
this.FlightNodeAddToolStripMenuItem.Text = "Thêm điểm";
this.ToolStripSeparator3.Name = "ToolStripSeparator3";
ToolStripItem arg_89A_0 = this.ToolStripSeparator3;
size = new Size(149, 6);
arg_89A_0.Size = size;
this.FlightNodeDeleteToolStripMenuItem.Name = "FlightNodeDeleteToolStripMenuItem";
ToolStripItem arg_8C4_0 = this.FlightNodeDeleteToolStripMenuItem;
size = new Size(152, 22);
arg_8C4_0.Size = size;
this.FlightNodeDeleteToolStripMenuItem.Text = "Xóa điểm";
this.ToolStripSeparator4.Name = "ToolStripSeparator4";
ToolStripItem arg_8FD_0 = this.ToolStripSeparator4;
size = new Size(149, 6);
arg_8FD_0.Size = size;
this.FlightNodeUpdateToolStripMenuItem.Name = "FlightNodeUpdateToolStripMenuItem";
ToolStripItem arg_927_0 = this.FlightNodeUpdateToolStripMenuItem;
size = new Size(152, 22);
arg_927_0.Size = size;
this.FlightNodeUpdateToolStripMenuItem.Text = "Cập nhật điểm";
this.Panel1.BorderStyle = BorderStyle.Fixed3D;
this.Panel1.Controls.Add(this.chkHienKyHieu);
this.Panel1.Controls.Add(this.lblTdBatDau);
this.Panel1.Controls.Add(this.GroupBox1);
this.Panel1.Controls.Add(this.TabControl1);
this.Panel1.Controls.Add(this.btnStart);
this.Panel1.Controls.Add(this.lblDongHo);
this.Panel1.Dock = DockStyle.Top;
Control arg_9E8_0 = this.Panel1;
location = new System.Drawing.Point(0, 0);
arg_9E8_0.Location = location;
this.Panel1.Name = "Panel1";
Control arg_A15_0 = this.Panel1;
size = new Size(269, 351);
arg_A15_0.Size = size;
this.Panel1.TabIndex = 64;
this.lblTdBatDau.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
this.lblTdBatDau.AutoSize = true;
Control arg_A55_0 = this.lblTdBatDau;
location = new System.Drawing.Point(161, 121);
arg_A55_0.Location = location;
this.lblTdBatDau.Name = "lblTdBatDau";
Control arg_A7C_0 = this.lblTdBatDau;
size = new Size(92, 13);
arg_A7C_0.Size = size;
this.lblTdBatDau.TabIndex = 17;
this.lblTdBatDau.Text = "Thời điểm bắt đầu";
this.lblTdBatDau.TextAlign = ContentAlignment.MiddleRight;
this.TabControl1.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
this.TabControl1.Controls.Add(this.TabPage1);
this.TabControl1.Controls.Add(this.TabPage2);
this.TabControl1.Controls.Add(this.TabPage3);
Control arg_B0E_0 = this.TabControl1;
location = new System.Drawing.Point(3, 147);
arg_B0E_0.Location = location;
this.TabControl1.Name = "TabControl1";
this.TabControl1.SelectedIndex = 0;
Control arg_B47_0 = this.TabControl1;
size = new Size(261, 196);
arg_B47_0.Size = size;
this.TabControl1.TabIndex = 65;
this.TabPage1.Controls.Add(this.txtBanTinGan);
TabPage arg_B80_0 = this.TabPage1;
location = new System.Drawing.Point(4, 22);
arg_B80_0.Location = location;
this.TabPage1.Name = "TabPage1";
Control arg_BA5_0 = this.TabPage1;
Padding padding = new Padding(3);
arg_BA5_0.Padding = padding;
Control arg_BC2_0 = this.TabPage1;
size = new Size(253, 170);
arg_BC2_0.Size = size;
this.TabPage1.TabIndex = 0;
this.TabPage1.Text = "TB gần";
this.TabPage1.UseVisualStyleBackColor = true;
this.txtBanTinGan.Dock = DockStyle.Fill;
Control arg_C0B_0 = this.txtBanTinGan;
location = new System.Drawing.Point(3, 3);
arg_C0B_0.Location = location;
this.txtBanTinGan.Multiline = true;
this.txtBanTinGan.Name = "txtBanTinGan";
this.txtBanTinGan.ScrollBars = ScrollBars.Vertical;
Control arg_C50_0 = this.txtBanTinGan;
size = new Size(247, 164);
arg_C50_0.Size = size;
this.txtBanTinGan.TabIndex = 64;
this.TabPage2.Controls.Add(this.txtBanTin55);
TabPage arg_C89_0 = this.TabPage2;
location = new System.Drawing.Point(4, 22);
arg_C89_0.Location = location;
this.TabPage2.Name = "TabPage2";
Control arg_CAE_0 = this.TabPage2;
padding = new Padding(3);
arg_CAE_0.Padding = padding;
Control arg_CCB_0 = this.TabPage2;
size = new Size(253, 170);
arg_CCB_0.Size = size;
this.TabPage2.TabIndex = 1;
this.TabPage2.Text = "TB 5x5";
this.TabPage2.UseVisualStyleBackColor = true;
this.txtBanTin55.Dock = DockStyle.Fill;
Control arg_D14_0 = this.txtBanTin55;
location = new System.Drawing.Point(3, 3);
arg_D14_0.Location = location;
this.txtBanTin55.Multiline = true;
this.txtBanTin55.Name = "txtBanTin55";
this.txtBanTin55.ScrollBars = ScrollBars.Vertical;
Control arg_D59_0 = this.txtBanTin55;
size = new Size(247, 164);
arg_D59_0.Size = size;
this.txtBanTin55.TabIndex = 65;
this.TabPage3.Controls.Add(this.txtBanTin99);
TabPage arg_D92_0 = this.TabPage3;
location = new System.Drawing.Point(4, 22);
arg_D92_0.Location = location;
this.TabPage3.Name = "TabPage3";
Control arg_DBF_0 = this.TabPage3;
size = new Size(253, 170);
arg_DBF_0.Size = size;
this.TabPage3.TabIndex = 2;
this.TabPage3.Text = "TB 9x9";
this.TabPage3.UseVisualStyleBackColor = true;
this.txtBanTin99.Dock = DockStyle.Fill;
Control arg_E08_0 = this.txtBanTin99;
location = new System.Drawing.Point(0, 0);
arg_E08_0.Location = location;
this.txtBanTin99.Multiline = true;
this.txtBanTin99.Name = "txtBanTin99";
this.txtBanTin99.ScrollBars = ScrollBars.Vertical;
Control arg_E4D_0 = this.txtBanTin99;
size = new Size(253, 170);
arg_E4D_0.Size = size;
this.txtBanTin99.TabIndex = 66;
this.Label4.AutoSize = true;
Control arg_E7C_0 = this.Label4;
location = new System.Drawing.Point(10, 8);
arg_E7C_0.Location = location;
this.Label4.Name = "Label4";
Control arg_EA3_0 = this.Label4;
size = new Size(69, 13);
arg_EA3_0.Size = size;
this.Label4.TabIndex = 65;
this.Label4.Text = "Các tốp bay:";
this.Splitter1.Dock = DockStyle.Top;
Control arg_EE5_0 = this.Splitter1;
location = new System.Drawing.Point(0, 351);
arg_EE5_0.Location = location;
this.Splitter1.Name = "Splitter1";
Control arg_F0E_0 = this.Splitter1;
size = new Size(269, 3);
arg_F0E_0.Size = size;
this.Splitter1.TabIndex = 65;
this.Splitter1.TabStop = false;
this.Panel2.BorderStyle = BorderStyle.Fixed3D;
this.Panel2.Controls.Add(this.grdTops);
this.Panel2.Controls.Add(this.Label4);
this.Panel2.Dock = DockStyle.Fill;
Control arg_F84_0 = this.Panel2;
location = new System.Drawing.Point(0, 354);
arg_F84_0.Location = location;
this.Panel2.Name = "Panel2";
Control arg_FB1_0 = this.Panel2;
size = new Size(269, 250);
arg_FB1_0.Size = size;
this.Panel2.TabIndex = 66;
this.grdTops.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
this.grdTops.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
Control arg_FED_0 = this.grdTops;
location = new System.Drawing.Point(3, 24);
arg_FED_0.Location = location;
this.grdTops.Name = "grdTops";
Control arg_101A_0 = this.grdTops;
size = new Size(261, 219);
arg_101A_0.Size = size;
this.grdTops.TabIndex = 66;
this.chkHienKyHieu.AutoSize = true;
this.chkHienKyHieu.Checked = true;
this.chkHienKyHieu.CheckState = CheckState.Checked;
Control arg_1062_0 = this.chkHienKyHieu;
location = new System.Drawing.Point(9, 93);
arg_1062_0.Location = location;
this.chkHienKyHieu.Name = "chkHienKyHieu";
Control arg_1089_0 = this.chkHienKyHieu;
size = new Size(103, 17);
arg_1089_0.Size = size;
this.chkHienKyHieu.TabIndex = 66;
this.chkHienKyHieu.Text = "Hiện các ký hiệu";
this.chkHienKyHieu.UseVisualStyleBackColor = true;
SizeF autoScaleDimensions = new SizeF(6f, 13f);
this.AutoScaleDimensions = autoScaleDimensions;
this.AutoScaleMode = AutoScaleMode.Font;
size = new Size(269, 604);
this.ClientSize = size;
this.Controls.Add(this.Panel2);
this.Controls.Add(this.Splitter1);
this.Controls.Add(this.Panel1);
this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
this.MaximizeBox = false;
this.MinimizeBox = false;
this.Name = "dlgHuanLuyen";
this.ShowInTaskbar = false;
this.StartPosition = FormStartPosition.CenterParent;
this.Text = "dlgHuanLuyen";
this.GroupBox1.ResumeLayout(false);
this.GroupBox1.PerformLayout();
this.NewContextMenuStrip.ResumeLayout(false);
this.MayBayContextMenuStrip.ResumeLayout(false);
this.FlightNodeContextMenuStrip.ResumeLayout(false);
this.Panel1.ResumeLayout(false);
this.Panel1.PerformLayout();
this.TabControl1.ResumeLayout(false);
this.TabPage1.ResumeLayout(false);
this.TabPage1.PerformLayout();
this.TabPage2.ResumeLayout(false);
this.TabPage2.PerformLayout();
this.TabPage3.ResumeLayout(false);
this.TabPage3.PerformLayout();
this.Panel2.ResumeLayout(false);
this.Panel2.PerformLayout();
((ISupportInitialize)this.grdTops).EndInit();
this.ResumeLayout(false);
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
this.m_SeleFlight = null;
this.iEditNode = -1;
this.PopulateTopGridView();
}
public void SetSeleFlight(CFlight pFlight)
{
this.m_EditingFlight = pFlight;
this.m_SeleFlight = pFlight;
}
private void PopulateRadas()
{
if (this.m_BaiTapRadas.Count > 0)
{
CBaiTap cBaiTap = (CBaiTap)modHuanLuyen.fMain.cboBaiTap.SelectedItem;
foreach(CRada current in this.m_BaiTapRadas){
this.PopulateKhuats(cBaiTap.BaiTapID, current);
}

}
}
private void PopulateKhuats(int pBaiTapID, CRada pRada)
{
List<CKhuat> list = CBaiTapKhuats.GetList(pBaiTapID, pRada.RadaID);
foreach(CKhuat current in list){
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
foreach(CTop current in modHuanLuyen.fMain.Tops){
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
DateTime pTd =  pFlight.Departure.AddSeconds( pFlight.Path[0].node.t2next + pFlight.Path[0].node.tspeed);
pFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, 1);
pFlight.UpdateTd(1, pTd);
}
private void CreateRadaFlights()
{
this.m_RadaFlights = checked(new CRadaFlight[this.m_BaiTapRadas.Count - 1 + 1, this.m_Flights.Count - 1 + 1]);
foreach(CRada current in this.m_BaiTapRadas){
int num = this.m_BaiTapRadas.IndexOf(current);
foreach(CFlight current2 in this.m_Flights){
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
foreach(CRada current in this.m_BaiTapRadas){
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
foreach(CRada current in this.m_BaiTapRadas){
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
this.m_DoiHuongFlight.isBusy = true;
this.m_DoiHuongFlight.DoiHuongBay(pDeparture, aTop);
this.m_DoiHuongFlight.isBusy = false;
this.SetSeleFlight(this.m_DoiHuongFlight);
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
foreach(CFlight current in this.m_Flights){
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
foreach(CFlight current in this.m_Flights){
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
foreach(CRada current in this.m_BaiTapRadas){
if (current.LoaiRadaID == 3)
{
int num = this.m_BaiTapRadas.IndexOf(current);
foreach(CFlight current2 in this.m_Flights){
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
foreach(CRada current in this.m_BaiTapRadas){
if (current.LoaiRadaID == 2)
{
int num = this.m_BaiTapRadas.IndexOf(current);
foreach(CFlight current2 in this.m_Flights){
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
foreach(CRada current in this.m_BaiTapRadas){
if (current.LoaiRadaID == 1)
{
int num = this.m_BaiTapRadas.IndexOf(current);
foreach(CFlight current2 in this.m_Flights){
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
private void btnStart_Click(object sender, EventArgs e)
{
if (this.btnStart.Text.IndexOf("Bắt đầu") >= 0)
{
this.btnStart.Text = "Kết thúc huấn luyện";
this.GroupBox1.Enabled = false;
this.StartHL();
}
else
{
this.Close();
}
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
DateTime dateTime =  this.TdBatDau.AddMinutes( (double)this.m_Phut);
checked
{
if (DateTime.Compare(dongHo, dateTime) >= 0)
{
DateTime now = DateTime.Now;
this.SetRadaStatus(dateTime);
DateTime mLuc =  dateTime.AddMinutes( (double)(0 - modHuanLuyen.DelayPhat99));
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
foreach(CFlight current in this.m_Flights){
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
foreach(CFlight current in this.m_Flights){
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
foreach(CRada current2 in this.m_BaiTapRadas){
foreach(CFlight current3 in this.m_Flights){
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
int num = this.m_EditingFlight.GetCurrIndex(dateTime);
checked
{
if (num > -1 & num < this.m_EditingFlight.Path.Count - 1)
{
FlightNode flightNode = this.m_EditingFlight.Path[num];
FlightNode flightNode2 = this.m_EditingFlight.Path[num + 1];
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
this.m_EditingFlight.Path.Insert(num + 1, flightNode3);
num++;
this.m_EditingFlight.updateLastNode(num - 1);
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
this.m_EditingFlight.Path.Insert(num + 1, flightNode4);
num++;
double mBanKinh = unchecked(num2 * pLastMaybay.Speed) / 3600.0;
MapPoint fromHeading = CBasePath.GetFromHeading(modHuanLuyen.fMain.AxMap1, flightNode4.node.D, (double)pLastMaybay.Rotation, mBanKinh);
fromHeading.h = pLastMaybay.Pos.h;
FlightNode flightNode5 = new FlightNode(fromHeading);
PathNode node3 = flightNode5.node;
node3.Speed = pLastMaybay.Speed;
node3.Roll = this.m_EditingFlight.ObjLoaiMB.Roll;
node3.Turn = TurnValue.None;
flightNode5.td = dongHo;
flightNode5.nodetype = 0;
this.m_EditingFlight.Path.Insert(num + 1, flightNode4);
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
this.m_EditingFlight.updateLastNode(i);
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
this.m_EditingFlight = pFlight;
DateTime dongHo = this.GetDongHo();
int currIndex = this.m_EditingFlight.GetCurrIndex(dongHo);
checked
{
if (currIndex > -1 & currIndex < this.m_EditingFlight.Path.Count - 1)
{
if (currIndex == this.iEditNode - 1)
{
CMayBay mayBay = pFlight.MayBay;
this.m_EditingFlight.Path.Remove(this.m_EditingFlight.Path[this.iEditNode]);
this.m_EditingFlight.Path[this.iEditNode].node.Turn = TurnValue.None;
this.AddNode(dongHo, mayBay);
}
else
{
this.m_EditingFlight.Path.Remove(this.m_EditingFlight.Path[this.iEditNode]);
this.m_EditingFlight.Path[this.iEditNode].node.Turn = TurnValue.None;
int num = 1;
if (this.iEditNode > 2)
{
num = this.iEditNode - 1;
}
this.m_EditingFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, num);
this.m_EditingFlight.UpdateTd(num - 1);
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
foreach(CFlight current in this.m_Flights){
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
if (current == this.m_SeleFlight)
{
pen.Width = 2f;
this.m_SeleFlight.DrawDuongBay(modHuanLuyen.fMain.AxMap1, g, pen, true);
}
else
{
pen.Width = 1f;
current.DrawDuongBay(modHuanLuyen.fMain.AxMap1, g, pen, false);
}
}

if (this.m_EditingFlight != null && this.m_EditingFlight.visible)
{
this.m_EditingFlight.DrawNodes(modHuanLuyen.fMain.AxMap1, g, this.iEditNode);
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
this.m_SeleFlight = CFlights.FindAtPoint(arg_2D_0, pointF, this.m_Flights);
checked
{
if (this.m_SeleFlight != null)
{
int num = this.m_Flights.IndexOf(this.m_SeleFlight);
this.grdTops.Rows[num].Selected = true;
this.grdTops.FirstDisplayedScrollingRowIndex = num;
this.m_EditingFlight = this.m_SeleFlight;
modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
if (e.button == 2)
{
ToolStripDropDown arg_D6_0 = this.MayBayContextMenuStrip;
Control arg_D6_1 = modHuanLuyen.fMain.PanelRight;
System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
arg_D6_0.Show(arg_D6_1, position);
}
}
else
{
this.iEditNode = -1;
AxMap arg_10D_0 = modHuanLuyen.fMain.AxMap1;
pointF = new PointF(e.x, e.y);
this.m_SeleFlight = CFlights.FindAtPoint2(arg_10D_0, pointF, this.m_Flights);
if (this.m_SeleFlight != null)
{
int num2 = this.m_Flights.IndexOf(this.m_SeleFlight);
this.grdTops.Rows[num2].Selected = true;
this.grdTops.FirstDisplayedScrollingRowIndex = num2;
this.m_EditingFlight = this.m_SeleFlight;
modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
CFlight arg_19C_0 = this.m_EditingFlight;
AxMap arg_19C_1 = modHuanLuyen.fMain.AxMap1;
pointF = new PointF(e.x, e.y);
int num3 = arg_19C_0.FindNodeAtPoint(arg_19C_1, pointF);
if (num3 > -1)
{
if (e.button == 2)
{
DateTime dongHo = this.GetDongHo();
if (DateTime.Compare(this.m_EditingFlight.Path[num3].td, dongHo) > 0)
{
this.iEditNode = num3;
ToolStripDropDown arg_212_0 = this.FlightNodeContextMenuStrip;
Control arg_212_1 = modHuanLuyen.fMain.PanelRight;
System.Drawing.Point position = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
arg_212_0.Show(arg_212_1, position);
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
this.m_EditingFlight = this.m_SeleFlight;
modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
}
}
}
}
public void m_Map_MouseDownEvent(object sender, CMapXEvents_MouseDownEvent e)
{
if (modHuanLuyen.fFlightNodeEdit == null)
{
if (this.m_EditingFlight != null)
{
CFlight arg_3E_0 = this.m_EditingFlight;
AxMap arg_3E_1 = modHuanLuyen.fMain.AxMap1;
PointF pt = new PointF(e.x, e.y);
int num = arg_3E_0.FindNodeAtPoint(arg_3E_1, pt);
if (num > -1)
{
if (e.button == 2)
{
DateTime dongHo = this.GetDongHo();
if (DateTime.Compare(this.m_EditingFlight.Path[num].td, dongHo) > 0)
{
this.iEditNode = num;
ToolStripDropDown arg_B3_0 = this.FlightNodeContextMenuStrip;
Control arg_B3_1 = modHuanLuyen.fMain.PanelRight;
System.Drawing.Point position = checked(new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y)));
arg_B3_0.Show(arg_B3_1, position);
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
if (Interaction.MsgBox("Vẽ tốp bay mới?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
{
modHuanLuyen.fMain.VeTopMoi(this.myPt);
}
}
private void FlightNodeAddToolStripMenuItem_Click(object sender, EventArgs e)
{
if (this.m_EditingFlight != null)
{
int num = this.iEditNode;
FlightNode flightNode = this.m_EditingFlight.Path[num];
this.AddNodeAt2(this.m_EditingFlight, num, flightNode.td);
this.m_SeleFlight = this.m_EditingFlight;
modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
}
}
private void FlightNodeDeleteToolStripMenuItem_Click(object sender, EventArgs e)
{
if (this.m_EditingFlight != null && MessageBox.Show("Thật sự muốn bỏ điểm này?", "Xóa điểm", MessageBoxButtons.YesNo) == DialogResult.Yes)
{
this.DeleteNode(this.m_EditingFlight);
}
}
private void FlightNodeUpdateToolStripMenuItem_Click(object sender, EventArgs e)
{
if (this.m_EditingFlight != null)
{
new dlgFlightNodeEdit
{
Text = "Cập nhật điểm " + this.iEditNode.ToString(),
OK_Button =
{
Text = "Update"
},
txtPath_ID =
{
Text = this.m_EditingFlight.TopID.ToString()
},
txtStt =
{
Text = this.iEditNode.ToString()
},
TopMost = true
}.Show(this);
}
else
{
}
}
private void MayBayStopToolStripMenuItem_Click(object sender, EventArgs e)
{
if (this.m_SeleFlight != null)
{
DateTime dongHo = this.GetDongHo();
this.m_SeleFlight.StopMayBay(dongHo);
modHuanLuyen.fMain.lyrAnimation.Invalidate(Missing.Value);
modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
}
}
private void MayBayAddNodeToolStripMenuItem_Click(object sender, EventArgs e)
{
if (this.m_SeleFlight != null)
{
DateTime dongHo = this.GetDongHo();
int currIndex = this.m_SeleFlight.GetCurrIndex(dongHo);
this.AddNodeAt2(this.m_SeleFlight, currIndex, dongHo);
modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
}
}
private void FlightNodeContextMenuStrip_Opening(object sender, CancelEventArgs e)
{
if (this.iEditNode < checked(this.m_EditingFlight.Path.Count - 1))
{
this.FlightNodeAddToolStripMenuItem.Enabled = true;
this.FlightNodeDeleteToolStripMenuItem.Enabled = true;
this.FlightNodeUpdateToolStripMenuItem.Enabled = true;
}
else
{
this.FlightNodeAddToolStripMenuItem.Enabled = false;
this.FlightNodeDeleteToolStripMenuItem.Enabled = false;
this.FlightNodeUpdateToolStripMenuItem.Enabled = true;
}
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
foreach(CFlight current in this.m_Flights){
DataRow dataRow = dataTable.NewRow();
CFlight cFlight = current;
dataRow["Top"] = cFlight.FlightNo;
dataRow["LoaiTop"] = this.GetLoaiTop(cFlight.LoaiTopID);
CLoaiMB objLoaiMB = cFlight.ObjLoaiMB;
dataRow["MayBay"] = objLoaiMB.LoaiMB;
dataRow["KieuLoai"] = objLoaiMB.KL;
dataRow["BatDau"] = cFlight.Departure.Hour.ToString("00") + ":" + cFlight.Departure.Minute.ToString("00");
dataRow["TopID"] = cFlight.Flight_ID;
dataRow["visible"] = cFlight.visible;
dataTable.Rows.Add(dataRow);
}

return dataTable;
}
private string GetLoaiTop(int pLoaiTopID)
{
return Convert.ToString(Interaction.IIf(pLoaiTopID == 1, "Địch", RuntimeHelpers.GetObjectValue(Interaction.IIf(pLoaiTopID == 3, "Qtế", RuntimeHelpers.GetObjectValue(Interaction.IIf(pLoaiTopID == 4, "QCảnh", "Ta"))))));
}
private void lstBaiTapTop_SelectedIndexChanged(object sender, EventArgs e)
{
if (this.m_SeleFlight != null)
{
this.m_EditingFlight = this.m_SeleFlight;
modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
}
}
private CFlight GetFlight(int lFlight_ID)
{
dlgHuanLuyen.cantimFlight_ID = lFlight_ID;
return this.m_Flights.Find(new Predicate<CFlight>(dlgHuanLuyen.FlightIDequal));
}
private static bool FlightIDequal(CFlight pFlight)
{
return pFlight.Flight_ID == dlgHuanLuyen.cantimFlight_ID;
}
private void grdTops_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
{
if (this.m_SeleFlight != null)
{
modHuanLuyen.fMain.AxMap1.ZoomTo(modHuanLuyen.fMain.AxMap1.Zoom, this.m_SeleFlight.MayBay.Pos.x, this.m_SeleFlight.MayBay.Pos.y);
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
this.m_SeleFlight = this.GetFlight(lFlight_ID);
if (this.m_SeleFlight != null)
{
modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
}
}
}
private void MayBayTachTopToolStripMenuItem_Click(object sender, EventArgs e)
{
if (this.m_SeleFlight != null && Interaction.MsgBox("Tách tốp '" + this.m_SeleFlight.FlightNo + "'?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
{
this.m_TachFlight = this.m_SeleFlight;
this.newDeparture = this.GetDongHo();
this.m_TachFlight.GetMayBay2(modHuanLuyen.fMain.AxMap1, this.newDeparture);
this.newMayBay = this.m_TachFlight.MayBay;
modHuanLuyen.fMain.VeTopTach(this.newMayBay.Pos);
}
}
private void MayBayContextMenuStrip_Opening(object sender, CancelEventArgs e)
{
if (this.m_SeleFlight != null)
{
if (this.m_SeleFlight.SoLuong > 1)
{
this.MayBayTachTopToolStripMenuItem.Enabled = true;
}
else
{
this.MayBayTachTopToolStripMenuItem.Enabled = false;
}
}
}
private void MayBayDoiHuongToolStripMenuItem_Click(object sender, EventArgs e)
{
if (this.m_SeleFlight != null && Interaction.MsgBox("Đổi hướng tốp '" + this.m_SeleFlight.FlightNo + "'?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
{
this.m_DoiHuongFlight = this.m_SeleFlight;
this.newDeparture = this.GetDongHo();
this.m_DoiHuongFlight.GetMayBay2(modHuanLuyen.fMain.AxMap1, this.newDeparture);
this.newMayBay = this.m_DoiHuongFlight.MayBay;
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