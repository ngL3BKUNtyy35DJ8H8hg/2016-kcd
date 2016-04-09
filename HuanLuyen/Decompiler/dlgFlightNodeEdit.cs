using AxMapXLib;
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
    public partial class dlgFlightNodeEdit : Form
    {
        private bool bLoaded;
        private bool bDirty;
        private CAirport m_SelectedAirport;
        private FlightNode m_NextNode;
        private FlightNode m_NextNode0;
        private FlightNode m_LuuNode;

        public dlgFlightNodeEdit()
        {
            this.bLoaded = false;
            this.bDirty = false;
            this.InitializeComponent();
        }
        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (modHuanLuyen.fHuanLuyen.iEditNode == 0)
            {
                DateTime dongHo = modHuanLuyen.fHuanLuyen.GetDongHo();
                if (DateTime.Compare(dongHo, modHuanLuyen.fHuanLuyen.EditingFlight.Departure) >= 0)
                {
                    this.CancelUpdate();
                    MessageBox.Show("Không cập nhật được. Bỏ qua.", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                this.onNodeChanged();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void CancelUpdate()
        {
            modHuanLuyen.fHuanLuyen.EditingFlight.Path[modHuanLuyen.fHuanLuyen.iEditNode] = this.m_LuuNode;
            DateTime dongHo = modHuanLuyen.fHuanLuyen.GetDongHo();
            if (DateTime.Compare(modHuanLuyen.fHuanLuyen.EditingFlight.Departure, dongHo) <= 0)
            {
                modHuanLuyen.fHuanLuyen.EditingFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, 1);
                modHuanLuyen.fHuanLuyen.EditingFlight.UpdateTd(0);
            }
            else
            {
                this.Tinh2Flight(modHuanLuyen.fHuanLuyen.EditingFlight);
            }
            modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
        }
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.CancelUpdate();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private FlightNode LuuNode(FlightNode pNode)
        {
            FlightNode flightNode = new FlightNode();
            if (!this.rbtnQuanhDiem.Checked)
            {
                if (this.rbtnHuongDiem.Checked)
                {
                }
            }
            flightNode.td = pNode.td;
            PathNode node = flightNode.node;
            node.CachVong = pNode.node.CachVong;
            node.CachNhap = pNode.node.CachNhap;
            node.D.x = pNode.node.D.x;
            node.D.y = pNode.node.D.y;
            node.D.h = pNode.node.D.h;
            node.C.x = pNode.node.C.x;
            node.C.y = pNode.node.C.y;
            node.C.h = pNode.node.C.h;
            node.Dp.x = pNode.node.Dp.x;
            node.Dp.y = pNode.node.Dp.y;
            node.Dp.h = pNode.node.Dp.h;
            node.Speed = pNode.node.Speed;
            node.tspeed = pNode.node.tspeed;
            node.Roll = pNode.node.Roll;
            node.Turn = pNode.node.Turn;
            node.t2next = pNode.node.t2next;
            node.typ = pNode.node.typ;
            return flightNode;
        }
        private void GetUpdateValue(FlightNode pNextNode)
        {
            enCachVong cachVong;
            if (this.rbtnQuanhDiem.Checked)
            {
                cachVong = enCachVong.QuanhDiem;
            }
            else if (this.rbtnHuongDiem.Checked)
            {
                cachVong = enCachVong.HuongDiem;
            }
            else
            {
                cachVong = enCachVong.DenDiem;
            }
            PathNode node = pNextNode.node;
            node.CachVong = cachVong;
            node.D.x = Convert.ToDouble(this.txtPosX.Text);
            node.D.y = Convert.ToDouble(this.txtPosY.Text);
            node.D.h = Convert.ToDouble(this.txtAltitude.Text);
            node.C.x = Convert.ToDouble(this.txtCX.Text);
            node.C.y = Convert.ToDouble(this.txtCY.Text);
            node.C.h = Convert.ToDouble(this.txtAltitude.Text);
            node.Dp.x = Convert.ToDouble(this.txtDpX.Text);
            node.Dp.y = Convert.ToDouble(this.txtDpY.Text);
            node.Dp.h = Convert.ToDouble(this.txtAltitude.Text);
            node.Speed = Convert.ToDouble(this.nudSpeed.Value);
            node.tspeed = Convert.ToDouble(this.nudTspeed.Value);
            node.Roll = Convert.ToSingle(this.nudRoll.Value);
            node.Turn = (TurnValue)this.cboTurn.SelectedIndex;
        }
        private void onNodeChanged()
        {
            DateTime dongHo = modHuanLuyen.fHuanLuyen.GetDongHo();
            int num = modHuanLuyen.fHuanLuyen.EditingFlight.GetCurrIndex(dongHo);
            if (num < 0)
            {
                return;
            }
            CMayBay mayBay = modHuanLuyen.fHuanLuyen.EditingFlight.getMayBay20(modHuanLuyen.fMain.AxMap1, dongHo);
            if (num > -1 & num < modHuanLuyen.fHuanLuyen.EditingFlight.Path.Count - 1)
            {
                this.cboTurn.SelectedIndex = 0;
                this.GetUpdateValue(modHuanLuyen.fHuanLuyen.EditingFlight.Path[modHuanLuyen.fHuanLuyen.iEditNode]);
                if (modHuanLuyen.fHuanLuyen.iEditNode < modHuanLuyen.fHuanLuyen.EditingFlight.Path.Count - 1 & modHuanLuyen.fHuanLuyen.iEditNode > 0)
                {
                    modHuanLuyen.fHuanLuyen.EditingFlight.TinhYToVong1Node(modHuanLuyen.fMain.AxMap1, modHuanLuyen.fHuanLuyen.iEditNode);
                }
                if (num == modHuanLuyen.fHuanLuyen.iEditNode - 1)
                {
                    if (modHuanLuyen.fHuanLuyen.EditingFlight.Path[modHuanLuyen.fHuanLuyen.iEditNode].node.D.x != this.m_NextNode0.node.D.x | modHuanLuyen.fHuanLuyen.EditingFlight.Path[modHuanLuyen.fHuanLuyen.iEditNode].node.D.y != this.m_NextNode0.node.D.y)
                    {
                        FlightNode flightNode = modHuanLuyen.fHuanLuyen.EditingFlight.Path[num];
                        FlightNode flightNode2 = new FlightNode(modHuanLuyen.fHuanLuyen.EditingFlight.Path[num + 1].node);
                        FlightNode flightNode3 = new FlightNode(new MapPoint(0.0, 0.0)
                        {
                            x = mayBay.Pos.x,
                            y = mayBay.Pos.y,
                            h = mayBay.Pos.h
                        });
                        PathNode node = flightNode3.node;
                        node.Speed = mayBay.Speed;
                        node.Roll = 0f;
                        node.Turn = TurnValue.None;
                        flightNode3.td = dongHo;
                        flightNode3.nodetype = 1;
                        modHuanLuyen.fHuanLuyen.EditingFlight.Path.Insert(num + 1, flightNode3);
                        num++;
                        modHuanLuyen.fHuanLuyen.EditingFlight.updateLastNode(num - 1);
                        dlgHuanLuyen fHuanLuyen = modHuanLuyen.fHuanLuyen;
                        fHuanLuyen.iEditNode++;
                        int num2 = 1;
                        if (modHuanLuyen.fHuanLuyen.iEditNode > 1)
                        {
                            num2 = modHuanLuyen.fHuanLuyen.iEditNode - 1;
                        }
                        modHuanLuyen.fHuanLuyen.EditingFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, num2);
                        modHuanLuyen.fHuanLuyen.EditingFlight.UpdateTd(num2 - 1);
                        this.nudTspeed.Value = new decimal(this.m_NextNode.node.tspeed);
                        modHuanLuyen.fHuanLuyen.AddNode(dongHo, mayBay);
                    }
                    else
                    {
                        int num3 = 1;
                        if (modHuanLuyen.fHuanLuyen.iEditNode > 1)
                        {
                            num3 = modHuanLuyen.fHuanLuyen.iEditNode - 1;
                        }
                        modHuanLuyen.fHuanLuyen.EditingFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, num3);
                        modHuanLuyen.fHuanLuyen.EditingFlight.UpdateTd(num3 - 1);
                        this.nudTspeed.Value = new decimal(this.m_NextNode.node.tspeed);
                    }
                }
                else
                {
                    int num4 = 1;
                    if (modHuanLuyen.fHuanLuyen.iEditNode > 1)
                    {
                        num4 = modHuanLuyen.fHuanLuyen.iEditNode - 1;
                    }
                    modHuanLuyen.fHuanLuyen.EditingFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, num4);
                    modHuanLuyen.fHuanLuyen.EditingFlight.UpdateTd(num4 - 1);
                    this.nudTspeed.Value = new decimal(this.m_NextNode.node.tspeed);
                }
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }
            else
            {
                MessageBox.Show("UpdateNode Không được.", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void onNodeChanged2()
        {
            DateTime dongHo = modHuanLuyen.fHuanLuyen.GetDongHo();
            if (DateTime.Compare(dongHo, modHuanLuyen.fHuanLuyen.EditingFlight.Departure) >= 0)
            {
                int currIndex = modHuanLuyen.fHuanLuyen.EditingFlight.GetCurrIndex(dongHo);
                if (currIndex > -1 & currIndex < modHuanLuyen.fHuanLuyen.EditingFlight.Path.Count - 1)
                {
                    if (currIndex < modHuanLuyen.fHuanLuyen.iEditNode - 1)
                    {
                        this.onNodeChange20();
                    }
                }
                else
                {
                    MessageBox.Show("UpdateNode Không được.", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                this.GetUpdateValue(modHuanLuyen.fHuanLuyen.EditingFlight.Path[modHuanLuyen.fHuanLuyen.iEditNode]);
                if (modHuanLuyen.fHuanLuyen.iEditNode == 0)
                {
                    PathNode node = modHuanLuyen.fHuanLuyen.EditingFlight.Path[modHuanLuyen.fHuanLuyen.iEditNode].node;
                    node.Dp.x = node.D.x;
                    node.Dp.y = node.D.y;
                    node.Dp.h = node.D.h;
                    node.C.x = node.D.x;
                    node.C.y = node.D.y;
                    node.C.h = node.D.h;
                }
                this.Tinh2Flight(modHuanLuyen.fHuanLuyen.EditingFlight);
                modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
            }
        }
        private void Tinh2Flight(CFlight pFlight)
        {
            CBasePath.TinhSecs(modHuanLuyen.fMain.AxMap1, pFlight.Path[0].node, pFlight.Path[1].node);
            DateTime pTd = pFlight.Departure.AddSeconds(pFlight.Path[0].node.t2next + pFlight.Path[0].node.tspeed);
            pFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, 1);
            pFlight.UpdateTd(1, pTd);
        }
        private void onNodeChange20()
        {
            this.cboTurn.SelectedIndex = 0;
            this.GetUpdateValue(modHuanLuyen.fHuanLuyen.EditingFlight.Path[modHuanLuyen.fHuanLuyen.iEditNode]);
            int num = 1;
            if (modHuanLuyen.fHuanLuyen.iEditNode > 1)
            {
                num = modHuanLuyen.fHuanLuyen.iEditNode - 1;
            }
            modHuanLuyen.fHuanLuyen.EditingFlight.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, num);
            modHuanLuyen.fHuanLuyen.EditingFlight.UpdateTd(num - 1);
            modHuanLuyen.fMain.lyrCacKyHieu.Invalidate(Missing.Value);
        }
        private void dlgFlightNodeEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            modHuanLuyen.fHuanLuyen.SetBusy(modHuanLuyen.fHuanLuyen.EditingFlight, false);
            modHuanLuyen.fHuanLuyen.iEditNode = -1;
            modHuanLuyen.fHuanLuyen.grdTops.Enabled = true;
            modHuanLuyen.fMain.AxMap1.CurrentTool = ToolConstants.miArrowTool;
            modHuanLuyen.fFlightNodeEdit = null;
        }
        private void dlgFlightNodeEdit_Load(object sender, EventArgs e)
        {
            System.Drawing.Point location = new System.Drawing.Point(0, 100);
            this.Location = location;
            this.m_LuuNode = this.LuuNode(modHuanLuyen.fHuanLuyen.EditingFlight.Path[modHuanLuyen.fHuanLuyen.iEditNode]);
            modHuanLuyen.fHuanLuyen.SetBusy(modHuanLuyen.fHuanLuyen.EditingFlight, true);
            modHuanLuyen.fFlightNodeEdit = this;
            modHuanLuyen.fHuanLuyen.grdTops.Enabled = false;
            FlightNode flightNode = new FlightNode(modHuanLuyen.fHuanLuyen.EditingFlight.Path[modHuanLuyen.fHuanLuyen.iEditNode].node);
            this.m_NextNode = flightNode;
            this.m_NextNode0 = new FlightNode(flightNode.node);
            if (flightNode.node.CachVong == enCachVong.QuanhDiem)
            {
                this.rbtnQuanhDiem.Checked = true;
                this.rbtnQuanhDiem.CheckedChanged += new EventHandler(this.rbtnQuanhDiem_CheckedChanged);
            }
            else if (flightNode.node.CachVong == enCachVong.HuongDiem)
            {
                this.rbtnHuongDiem.Checked = true;
                this.rbtnHuongDiem.CheckedChanged += new EventHandler(this.rbtnQuanhDiem_CheckedChanged);
            }
            else
            {
                this.rbtnDenDiem.Checked = true;
            }
            if (flightNode.node.CachNhap == enCachNhap.PhuongVi)
            {
                this.rbtnTheoPhuongVi.Checked = true;
                this.rbtnTheoPhuongVi.CheckedChanged += new EventHandler(this.rbtnTheoPhuongVi_CheckedChanged);
            }
            else if (flightNode.node.CachNhap == enCachNhap.KinhViDo)
            {
                this.rbtnTheoLonLat.Checked = true;
            }
            else
            {
                this.rbtnTheoDiaTieu.Checked = true;
                this.rbtnTheoDiaTieu.CheckedChanged += new EventHandler(this.rbtnTheoPhuongVi_CheckedChanged);
            }
            this.reset();
            this.bLoaded = true;
            modHuanLuyen.fMain.AxMap1.CurrentTool = (ToolConstants)4;
        }
        private void reset()
        {
            PathNode node = this.m_NextNode.node;
            this.txtPosX.Text = node.D.x.ToString("#.00000000");
            this.txtPosY.Text = node.D.y.ToString("#.00000000");
            this.txtDpX.Text = node.Dp.x.ToString("#.00000000");
            this.txtDpY.Text = node.Dp.y.ToString("#.00000000");
            this.txtCX.Text = node.C.x.ToString("#.00000000");
            this.txtCY.Text = node.C.y.ToString("#.00000000");
            this.txtAltitude.Text = node.D.h.ToString();
            this.txtAltitude.KeyUp += new KeyEventHandler(this.txtPhuongVi_KeyUp);
            this.nudSpeed.Value = new decimal(node.Speed);
            this.nudSpeed.ValueChanged += new EventHandler(this.nudRoll_ValueChanged);
            this.nudTspeed.Value = new decimal(node.tspeed);
            this.nudTspeed.ValueChanged += new EventHandler(this.nudRoll_ValueChanged);
            this.nudRoll.Value = new decimal(node.Roll);
            this.nudRoll.ValueChanged += new EventHandler(this.nudRoll_ValueChanged);
            this.cboTurn.SelectedIndex = (int)node.Turn;
            MapPoint mapPoint = default(MapPoint);
            PathNode node2 = this.m_NextNode.node;
            if (this.rbtnQuanhDiem.Checked)
            {
                mapPoint.x = node2.C.x;
                mapPoint.y = node2.C.y;
                this.GroupBox1.Text = "Vòng quanh điểm:";
            }
            else if (this.rbtnHuongDiem.Checked)
            {
                mapPoint.x = node2.Dp.x;
                mapPoint.y = node2.Dp.y;
                this.GroupBox1.Text = "Vòng hướng điểm:";
            }
            else
            {
                mapPoint.x = node2.D.x;
                mapPoint.y = node2.D.y;
                this.GroupBox1.Text = "Vòng đến điểm:";
            }
            DPGFormat dPG = modHuanLuyen.getDPG(mapPoint.x);
            this.nudXDo.Value = new decimal(dPG.ido);
            this.nudXDo.ValueChanged += new EventHandler(this.nudXDo_ValueChanged);
            this.nudXPhut.Value = new decimal(dPG.iphut);
            this.nudXPhut.ValueChanged += new EventHandler(this.nudXDo_ValueChanged);
            this.nudXGiay.Value = new decimal(dPG.igiay);
            this.nudXGiay.ValueChanged += new EventHandler(this.nudXDo_ValueChanged);
            dPG = modHuanLuyen.getDPG(mapPoint.y);
            this.nudYDo.Value = new decimal(dPG.ido);
            this.nudYDo.ValueChanged += new EventHandler(this.nudXDo_ValueChanged);
            this.nudYPhut.Value = new decimal(dPG.iphut);
            this.nudYPhut.ValueChanged += new EventHandler(this.nudXDo_ValueChanged);
            this.nudYGiay.Value = new decimal(dPG.igiay);
            this.nudYGiay.ValueChanged += new EventHandler(this.nudXDo_ValueChanged);
            struPhuongVi phuongVi = modHuanLuyen.GetPhuongVi(modHuanLuyen.fMain.AxMap1, modHuanLuyen.GocPvClCX, modHuanLuyen.GocPvClCY, mapPoint.x, mapPoint.y);
            this.txtPhuongVi.Text = phuongVi.PhuongVi.ToString("0.##");
            this.txtBanKinh.Text = phuongVi.CuLy.ToString("0.##");
            this.DoiCachNhap();
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            modHuanLuyen.fMain.AxMap1.CurrentTool = (ToolConstants)4;
        }
        private void setTurn()
        {
            this.bLoaded = false;
            if (this.cboTurn.SelectedIndex == 0)
            {
                this.cboTurn.SelectedIndex = (int)modHuanLuyen.fHuanLuyen.EditingFlight.GetTurn(modHuanLuyen.fMain.AxMap1, modHuanLuyen.fHuanLuyen.iEditNode);
                this.cboTurn.SelectedIndexChanged += new EventHandler(this.nudRoll_ValueChanged);
            }
            this.bLoaded = true;
        }
        private MapPoint getMapXformat()
        {
            return new MapPoint
            {
                x = Convert.ToDouble(decimal.Add(this.nudXDo.Value, decimal.Divide(decimal.Add(this.nudXPhut.Value, decimal.Divide(this.nudXGiay.Value, new decimal(60L))), new decimal(60L)))),
                y = Convert.ToDouble(decimal.Add(this.nudYDo.Value, decimal.Divide(decimal.Add(this.nudYPhut.Value, decimal.Divide(this.nudYGiay.Value, new decimal(60L))), new decimal(60L))))
            };
        }
        private void nudXDo_ValueChanged(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                MapPoint mapXformat = this.getMapXformat();
                if (this.rbtnQuanhDiem.Checked)
                {
                    this.txtCX.Text = mapXformat.x.ToString("#.00000000");
                    this.txtCY.Text = mapXformat.y.ToString("#.00000000");
                }
                else if (this.rbtnHuongDiem.Checked)
                {
                    this.txtDpX.Text = mapXformat.x.ToString("#.00000000");
                    this.txtDpY.Text = mapXformat.y.ToString("#.00000000");
                }
                else
                {
                    this.txtPosX.Text = mapXformat.x.ToString("#.00000000");
                    this.txtPosY.Text = mapXformat.y.ToString("#.00000000");
                }
                if (!this.rbtnTheoPhuongVi.Checked)
                {
                    struPhuongVi phuongVi = modHuanLuyen.GetPhuongVi(modHuanLuyen.fMain.AxMap1, modHuanLuyen.GocPvClCX, modHuanLuyen.GocPvClCY, mapXformat.x, mapXformat.y);
                    this.txtPhuongVi.Text = phuongVi.PhuongVi.ToString("0.##");
                    this.txtBanKinh.Text = phuongVi.CuLy.ToString("0.##");
                }
                this.onNodeChanged2();
            }
        }
        private void rbtnTheoPhuongVi_CheckedChanged(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                this.DoiCachNhap();
            }
        }
        private void DoiCachNhap()
        {
            modHuanLuyen.fMain.AxMap1.CurrentTool = ToolConstants.miArrowTool;
            if (this.rbtnTheoPhuongVi.Checked)
            {
                this.txtPhuongVi.Enabled = true;
                this.txtBanKinh.Enabled = true;
                this.btnChon.Enabled = false;
                this.nudXDo.Enabled = false;
                this.nudXPhut.Enabled = false;
                this.nudXGiay.Enabled = false;
                this.nudYDo.Enabled = false;
                this.nudYPhut.Enabled = false;
                this.nudYGiay.Enabled = false;
                this.txtPhuongVi.Select();
            }
            else if (this.rbtnTheoLonLat.Checked)
            {
                this.txtPhuongVi.Enabled = false;
                this.txtPhuongVi.Validating += new CancelEventHandler(this.txtBanKinh_Validating);
                this.txtPhuongVi.KeyUp += new KeyEventHandler(this.txtPhuongVi_KeyUp);
                this.txtBanKinh.Enabled = false;
                this.txtBanKinh.Validating += new CancelEventHandler(this.txtBanKinh_Validating);
                this.txtBanKinh.KeyUp += new KeyEventHandler(this.txtPhuongVi_KeyUp);
                this.btnChon.Enabled = true;
                this.btnChon.Click += new EventHandler(this.btnChon_Click);
                this.nudXDo.Enabled = true;
                this.nudXPhut.Enabled = true;
                this.nudXGiay.Enabled = true;
                this.nudYDo.Enabled = true;
                this.nudYPhut.Enabled = true;
                this.nudYGiay.Enabled = true;
                this.nudXPhut.Select();
            }
            else
            {
                this.txtPhuongVi.Enabled = false;
                this.txtBanKinh.Enabled = false;
                this.btnChon.Enabled = true;
                this.nudXDo.Enabled = false;
                this.nudXPhut.Enabled = false;
                this.nudXGiay.Enabled = false;
                this.nudYDo.Enabled = false;
                this.nudYPhut.Enabled = false;
                this.nudYGiay.Enabled = false;
                this.btnChon.Select();
            }
        }
        private void txtPhuongVi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtBanKinh_Validating(object sender, CancelEventArgs e)
        {
            if (!this.GetPosFromPhVi())
            {
                e.Cancel = true;
            }
        }
        private bool GetPosFromPhVi()
        {
            bool result = false;
            try
            {
                double mBanKinh = Convert.ToDouble(this.txtBanKinh.Text);
                double heading = Convert.ToDouble(this.txtPhuongVi.Text);
                MapPoint mapPt = new MapPoint(modHuanLuyen.GocPvClCX, modHuanLuyen.GocPvClCY);
                MapPoint fromHeading = CBasePath.GetFromHeading(modHuanLuyen.fMain.AxMap1, mapPt, heading, mBanKinh);
                if (this.rbtnQuanhDiem.Checked)
                {
                    this.txtCX.Text = fromHeading.x.ToString("#.00000000");
                    this.txtCX.TextChanged += new EventHandler(this.txtCX_TextChanged);
                    this.txtCY.Text = fromHeading.y.ToString("#.00000000");
                    this.txtCY.TextChanged += new EventHandler(this.txtCY_TextChanged);
                }
                else if (this.rbtnHuongDiem.Checked)
                {
                    this.txtDpX.Text = fromHeading.x.ToString("#.00000000");
                    this.txtDpX.TextChanged += new EventHandler(this.txtDpX_TextChanged);
                    this.txtDpY.Text = fromHeading.y.ToString("#.00000000");
                    this.txtDpY.TextChanged += new EventHandler(this.txtDpY_TextChanged);
                }
                else
                {
                    this.txtPosX.Text = fromHeading.x.ToString("#.00000000");
                    this.txtPosX.TextChanged += new EventHandler(this.txtPosX_TextChanged);
                    this.txtPosY.Text = fromHeading.y.ToString("#.00000000");
                    this.txtPosY.TextChanged += new EventHandler(this.txtPosY_TextChanged);
                }
                result = true;
            }
            catch (Exception expr_128)
            {
                throw expr_128;
                MessageBox.Show("Nhập phương vị, bán kính không hợp lý. Nhập lại...", "Thông báo", MessageBoxButtons.OK);
            }
            return result;
        }
        private void rbtnQuanhDiem_CheckedChanged(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                this.bLoaded = false;
                this.reset();
                this.bLoaded = true;
            }
        }
        private void txtPosX_TextChanged(object sender, EventArgs e)
        {
            if (this.bLoaded && this.rbtnDenDiem.Checked && !this.rbtnTheoLonLat.Checked)
            {
                DPGFormat dPG = modHuanLuyen.getDPG(Convert.ToDouble(this.txtPosX.Text));
                this.nudXDo.Value = new decimal(dPG.ido);
                this.nudXPhut.Value = new decimal(dPG.iphut);
                this.nudXGiay.Value = new decimal(dPG.igiay);
            }
        }
        private void txtPosY_TextChanged(object sender, EventArgs e)
        {
            if (this.bLoaded && this.rbtnDenDiem.Checked && !this.rbtnTheoLonLat.Checked)
            {
                DPGFormat dPG = modHuanLuyen.getDPG(Convert.ToDouble(this.txtPosY.Text));
                this.nudYDo.Value = new decimal(dPG.ido);
                this.nudYPhut.Value = new decimal(dPG.iphut);
                this.nudYGiay.Value = new decimal(dPG.igiay);
            }
        }
        private void txtDpX_TextChanged(object sender, EventArgs e)
        {
            if (this.bLoaded && this.rbtnHuongDiem.Checked && !this.rbtnTheoLonLat.Checked)
            {
                DPGFormat dPG = modHuanLuyen.getDPG(Convert.ToDouble(this.txtDpX.Text));
                this.nudXDo.Value = new decimal(dPG.ido);
                this.nudXPhut.Value = new decimal(dPG.iphut);
                this.nudXGiay.Value = new decimal(dPG.igiay);
            }
        }
        private void txtDpY_TextChanged(object sender, EventArgs e)
        {
            if (this.bLoaded && this.rbtnHuongDiem.Checked && !this.rbtnTheoLonLat.Checked)
            {
                DPGFormat dPG = modHuanLuyen.getDPG(Convert.ToDouble(this.txtDpY.Text));
                this.nudYDo.Value = new decimal(dPG.ido);
                this.nudYPhut.Value = new decimal(dPG.iphut);
                this.nudYGiay.Value = new decimal(dPG.igiay);
            }
        }
        private void txtCX_TextChanged(object sender, EventArgs e)
        {
            if (this.bLoaded && this.rbtnQuanhDiem.Checked && !this.rbtnTheoLonLat.Checked)
            {
                DPGFormat dPG = modHuanLuyen.getDPG(Convert.ToDouble(this.txtCX.Text));
                this.nudXDo.Value = new decimal(dPG.ido);
                this.nudXPhut.Value = new decimal(dPG.iphut);
                this.nudXGiay.Value = new decimal(dPG.igiay);
            }
        }
        private void txtCY_TextChanged(object sender, EventArgs e)
        {
            if (this.bLoaded && this.rbtnQuanhDiem.Checked && !this.rbtnTheoLonLat.Checked)
            {
                DPGFormat dPG = modHuanLuyen.getDPG(Convert.ToDouble(this.txtCY.Text));
                this.nudYDo.Value = new decimal(dPG.ido);
                this.nudYPhut.Value = new decimal(dPG.iphut);
                this.nudYGiay.Value = new decimal(dPG.igiay);
            }
        }
        public void DrawPos(AxMap pMap, Graphics g)
        {
            double num = Convert.ToDouble(this.txtPosX.Text);
            double num2 = Convert.ToDouble(this.txtPosY.Text);
            if (this.rbtnQuanhDiem.Checked)
            {
                num = Convert.ToDouble(this.txtCX.Text);
                num2 = Convert.ToDouble(this.txtCY.Text);
            }
            else if (modHuanLuyen.fFlightNodeEdit.rbtnHuongDiem.Checked)
            {
                num = Convert.ToDouble(this.txtDpX.Text);
                num2 = Convert.ToDouble(this.txtDpY.Text);
            }
            else
            {
                num = Convert.ToDouble(this.txtPosX.Text);
                num2 = Convert.ToDouble(this.txtPosY.Text);
            }
            Pen pen = new Pen(Color.Red, 2f);
            try
            {
                PointF pointF = default(PointF);
                float x = pointF.X;
                float y = pointF.Y;
                pMap.ConvertCoord(ref x, ref y, ref num, ref num2, ConversionConstants.miMapToScreen);
                pointF.Y = y;
                pointF.X = x;
                g.DrawLine(pen, pointF.X - 5f, pointF.Y - 5f, pointF.X + 5f, pointF.Y + 5f);
                g.DrawLine(pen, pointF.X - 5f, pointF.Y + 5f, pointF.X + 5f, pointF.Y - 5f);
            }
            catch (Exception arg_16D_0)
            {
                throw arg_16D_0;
            }
            finally
            {
                pen.Dispose();
            }
        }
        private void nudRoll_ValueChanged(object sender, EventArgs e)
        {
            if (this.bLoaded)
            {
                this.onNodeChanged2();
            }
        }

    }
}