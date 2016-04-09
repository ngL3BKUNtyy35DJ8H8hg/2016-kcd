using AxMapXLib;
using MapXLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace HuanLuyen
{
    [Serializable]
    public class CFlight
    {
        public int Flight_ID;
        public int TopID;
        public int LoaiTopID;
        public string FlightNo;
        public int LoaiMBID;
        public DateTime Departure;
        public int SoLuong;
        public CLoaiMB ObjLoaiMB;
        public CMayBay MayBay;
        public List<FlightNode> Path;
        public bool visible;
        public bool isBusy;
        public List<CMayBay> MayBays;
        public override string ToString()
        {
            string str = "";
            return this.FlightNo + ": " + this.Departure.ToString("HH:mm ") + str;
        }
        public CFlight()
        {
            this.Flight_ID = 0;
            this.LoaiTopID = 0;
            this.FlightNo = "";
            this.LoaiMBID = 0;
            this.SoLuong = 0;
            this.visible = true;
            this.isBusy = false;
            this.Departure = DateTime.Today;
            this.MayBay = new CMayBay(0);
            this.Path = new List<FlightNode>();
            this.MayBays = new List<CMayBay>();
        }
        public CFlight(CTop pTop)
        {
            this.Flight_ID = 0;
            this.LoaiTopID = 0;
            this.FlightNo = "";
            this.LoaiMBID = 0;
            this.SoLuong = 0;
            this.visible = true;
            this.isBusy = false;
            try
            {
                DateTime now = DateTime.Now;
                this.Departure = new DateTime(now.Year, now.Month, now.Day, pTop.GioBatDau, pTop.PhutBatDau, pTop.GiayBatDau, pTop.MilliGiayBatDau);
                this.TopID = pTop.TopID;
                this.LoaiTopID = pTop.LoaiTopID;
                this.FlightNo = pTop.FlightNo;
                this.LoaiMBID = pTop.LoaiMB;
                this.SoLuong = pTop.SoLuong;
                this.Path = new List<FlightNode>();
                FlightNode flightNode = new FlightNode();
                flightNode.td = this.Departure;
                PathNode node = flightNode.node;
                node.D.x = pTop.PosFrom.x;
                node.D.y = pTop.PosFrom.y;
                node.D.h = pTop.PosFrom.h;
                node.Dp.x = pTop.PosFrom.x;
                node.Dp.y = pTop.PosFrom.y;
                node.Dp.h = pTop.PosFrom.h;
                node.C.x = pTop.PosFrom.x;
                node.C.y = pTop.PosFrom.y;
                node.C.h = pTop.PosFrom.h;
                node.Speed = pTop.SpeedFrom;
                this.Path.Add(flightNode);
                foreach (PathNode current in pTop.Path)
                {
                    flightNode = new FlightNode(current);
                    flightNode.isPlan = true;
                    flightNode.td = this.Departure;
                    this.Path.Add(flightNode);
                }

                flightNode = new FlightNode();
                flightNode.td = this.Departure;
                PathNode node2 = flightNode.node;
                node2.D.x = pTop.PosTo.x;
                node2.D.y = pTop.PosTo.y;
                node2.D.h = pTop.PosTo.h;
                node2.Dp.x = pTop.PosTo.x;
                node2.Dp.y = pTop.PosTo.y;
                node2.Dp.h = pTop.PosTo.h;
                node2.C.x = pTop.PosTo.x;
                node2.C.y = pTop.PosTo.y;
                node2.C.h = pTop.PosTo.h;
                node2.Speed = pTop.SpeedTo;
                this.Path.Add(flightNode);
                this.ObjLoaiMB = CLoaiMBs.GetLoaiMB(this.LoaiMBID);
                this.MayBay = new CMayBay(this.ObjLoaiMB.SymbolID);
                CMayBay mayBay = this.MayBay;
                mayBay.Pos.x = pTop.PosFrom.x;
                mayBay.Pos.y = pTop.PosFrom.y;
                mayBay.Pos.h = pTop.PosFrom.h;
                mayBay.Visible = false;
                mayBay.Pattern = CNodePatterns.GetPattern(mayBay.m_SymbolID);
                this.MayBays = new List<CMayBay>();
            }
            catch (Exception expr_3BF)
            {
                throw expr_3BF;
            }
        }
        public CFlight(CTop pTop, DateTime pDeparture)
        {
            this.Flight_ID = 0;
            this.LoaiTopID = 0;
            this.FlightNo = "";
            this.LoaiMBID = 0;
            this.SoLuong = 0;
            this.visible = true;
            this.isBusy = false;
            try
            {
                this.Departure = pDeparture;
                this.TopID = pTop.TopID;
                this.LoaiTopID = pTop.LoaiTopID;
                this.FlightNo = pTop.FlightNo;
                this.LoaiMBID = pTop.LoaiMB;
                this.SoLuong = pTop.SoLuong;
                this.Path = new List<FlightNode>();
                FlightNode flightNode = new FlightNode();
                flightNode.td = this.Departure;
                PathNode node = flightNode.node;
                node.D.x = pTop.PosFrom.x;
                node.D.y = pTop.PosFrom.y;
                node.D.h = pTop.PosFrom.h;
                node.Dp.x = pTop.PosFrom.x;
                node.Dp.y = pTop.PosFrom.y;
                node.Dp.h = pTop.PosFrom.h;
                node.C.x = pTop.PosFrom.x;
                node.C.y = pTop.PosFrom.y;
                node.C.h = pTop.PosFrom.h;
                node.Speed = pTop.SpeedFrom;
                this.Path.Add(flightNode);
                foreach (PathNode current in pTop.Path)
                {
                    flightNode = new FlightNode(current);
                    flightNode.isPlan = true;
                    flightNode.td = this.Departure;
                    this.Path.Add(flightNode);
                }

                flightNode = new FlightNode();
                flightNode.td = this.Departure;
                PathNode node2 = flightNode.node;
                node2.D.x = pTop.PosTo.x;
                node2.D.y = pTop.PosTo.y;
                node2.D.h = pTop.PosTo.h;
                node2.Dp.x = pTop.PosTo.x;
                node2.Dp.y = pTop.PosTo.y;
                node2.Dp.h = pTop.PosTo.h;
                node2.C.x = pTop.PosTo.x;
                node2.C.y = pTop.PosTo.y;
                node2.C.h = pTop.PosTo.h;
                node2.Speed = pTop.SpeedTo;
                this.Path.Add(flightNode);
                this.ObjLoaiMB = CLoaiMBs.GetLoaiMB(this.LoaiMBID);
                this.MayBay = new CMayBay(this.ObjLoaiMB.SymbolID);
                CMayBay mayBay = this.MayBay;
                mayBay.Pos.x = pTop.PosFrom.x;
                mayBay.Pos.y = pTop.PosFrom.y;
                mayBay.Pos.h = pTop.PosFrom.h;
                mayBay.Visible = false;
                mayBay.Pattern = CNodePatterns.GetPattern(mayBay.m_SymbolID);
                this.MayBays = new List<CMayBay>();
            }
            catch (Exception expr_37C)
            {
                throw expr_37C;
            }
        }
        public int GetCurrIndex(DateTime pLuc)
        {
            checked
            {
                int num = this.Path.Count - 1;
                int result = -1;
                if (DateTime.Compare(pLuc, this.Departure) >= 0)
                {
                    int arg_23_0 = 0;
                    int num2 = num;
                    for (int i = arg_23_0; i <= num2; i++)
                    {
                        FlightNode flightNode = this.Path[i];
                        if (flightNode.td.Subtract(pLuc).TotalMilliseconds > 0.0)
                        {
                            result = i - 1;
                            break;
                        }
                    }
                }
                return result;
            }
        }
        public void TinhYToLuonVong(AxMap pMap, int fromIndex)
        {
            checked
            {
                if (fromIndex <= this.Path.Count - 2)
                {
                    int num = this.Path.Count - 2;
                    for (int i = fromIndex; i <= num; i++)
                    {
                        PathNode node = this.Path[i - 1].node;
                        PathNode node2 = this.Path[i + 1].node;
                        CBasePath.TinhYToVong1Node(pMap, node, node2, this.Path[i].node);
                    }
                }
            }
        }
        public void TinhYToVong1Node(AxMap pMap, int ibutnode)
        {
            checked
            {
                PathNode node = this.Path[ibutnode - 1].node;
                PathNode node2 = this.Path[ibutnode + 1].node;
                CBasePath.TinhYToVong1Node(pMap, node, node2, this.Path[ibutnode].node);
            }
        }
        public void UpdateTd(int fromIndex, DateTime pTd)
        {
            checked
            {
                if (fromIndex <= this.Path.Count - 1)
                {
                    DateTime dateTime = new DateTime(pTd.Year, pTd.Month, pTd.Day, pTd.Hour, pTd.Minute, pTd.Second);
                    int num = this.Path.Count - 1;
                    for (int i = fromIndex; i <= num; i++)
                    {
                        FlightNode flightNode = this.Path[i];
                        flightNode.td = dateTime;
                        dateTime = dateTime.AddSeconds(unchecked(flightNode.node.typ + flightNode.node.tspeed + flightNode.node.t2next));
                    }
                }
            }
        }
        public void UpdateTd(int fromIndex)
        {
            DateTime td = this.Path[fromIndex].td;
            DateTime dateTime = new DateTime(td.Year, td.Month, td.Day, td.Hour, td.Minute, td.Second);
            checked
            {
                int arg_54_0 = fromIndex + 1;
                int num = this.Path.Count - 1;
                for (int i = arg_54_0; i <= num; i++)
                {
                    dateTime = dateTime.AddSeconds(unchecked(this.Path[checked(i - 1)].node.typ + this.Path[checked(i - 1)].node.tspeed + this.Path[checked(i - 1)].node.t2next));
                    this.Path[i].td = dateTime;
                }
            }
        }
        public TurnValue GetTurn(AxMap pMap, int Index)
        {
            checked
            {
                FlightNode flightNode = this.Path[Index - 1];
                FlightNode flightNode2 = this.Path[Index + 1];
                PointF pt = default(PointF);
                float num = pt.X;
                float num2 = pt.Y;
                pMap.ConvertCoord(ref num, ref num2, ref flightNode.node.Dp.x, ref flightNode.node.Dp.y, ConversionConstants.miMapToScreen);
                pt.Y = num2;
                pt.X = num;
                PointF pt2 = default(PointF);
                num2 = pt2.X;
                num = pt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[Index].node.D.x, ref this.Path[Index].node.D.y, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                PointF pt3 = default(PointF);
                num2 = pt3.X;
                num = pt3.Y;
                pMap.ConvertCoord(ref num2, ref num, ref flightNode2.node.D.x, ref flightNode2.node.D.y, ConversionConstants.miMapToScreen);
                pt3.Y = num;
                pt3.X = num2;
                return CBasePath.getTurn(pt, pt2, pt3);
            }
        }
        public void DrawDuongBay(AxMap pMap, Graphics g, Pen pPen, bool bnodelbl)
        {
            checked
            {
                if (this.Path.Count > 1)
                {
                    this.DrawDuongThangDau(pMap, g, pPen, bnodelbl);
                    int arg_2C_0 = 1;
                    int num = this.Path.Count - 2;
                    for (int i = arg_2C_0; i <= num; i++)
                    {
                        this.DrawVongLuon(pMap, g, pPen, i, bnodelbl);
                        this.DrawDuongThang(pMap, g, pPen, i);
                    }
                    if (bnodelbl)
                    {
                        string lblText = "Kết thúc: " + this.Path[this.Path.Count - 1].td.ToString("HH:mm:ss");
                        PointF ptC = default(PointF);
                        PathNode node = this.Path[this.Path.Count - 1].node;
                        float x = ptC.X;
                        float y = ptC.Y;
                        pMap.ConvertCoord(ref x, ref y, ref node.D.x, ref node.D.y, ConversionConstants.miMapToScreen);
                        ptC.Y = y;
                        ptC.X = x;
                        PathNode.DrawNodeLbl(pMap, g, pPen, ptC, lblText);
                    }
                    this.DrawPhutNodes(pMap, g, pPen, bnodelbl);
                    this.DrawDiemCuoi(pMap, g, pPen);
                    this.DrawDiemDau(pMap, g, pPen);
                }
            }
        }
        private void DrawPhutNodes(AxMap pMap, Graphics g, Pen pPen, bool bnodelbl)
        {
            Pen pen = new Pen(Color.Black, pPen.Width);
            foreach (CMayBay current in this.MayBays)
            {
                float rotation = current.Rotation;
                int num = checked((int)Math.Round(current.Pos.h / 100.0));
                PointF point = default(PointF);
                float x = point.X;
                float y = point.Y;
                pMap.ConvertCoord(ref x, ref y, ref current.Pos.x, ref current.Pos.y, ConversionConstants.miMapToScreen);
                point.Y = y;
                point.X = x;
                PointF[] array = new PointF[2];
                array[0].X = point.X - (float)modHuanLuyen.defaPathDauCuoiSize;
                array[0].Y = point.Y;
                array[1].X = point.X + (float)modHuanLuyen.defaPathDauCuoiSize;
                array[1].Y = point.Y;
                Matrix matrix = new Matrix();
                matrix.RotateAt(rotation, point, MatrixOrder.Prepend);
                matrix.TransformPoints(array);
                g.DrawLine(pen, array[0], array[1]);
                if (bnodelbl)
                {
                    Font font = new Font("Arial Narrow", modHuanLuyen.defaSoHieuFontSize, FontStyle.Regular, GraphicsUnit.Point);
                    string text = string.Concat(new string[]
{
current.Luc.Hour.ToString("00"),
":",
current.Luc.Minute.ToString("00"),
"(",
num.ToString("000"),
")"
});
                    SizeF sizeF = g.MeasureString(text, font);
                    if (rotation < 90f)
                    {
                        g.DrawString(text, font, new SolidBrush(pen.Color), array[1].X, array[1].Y);
                    }
                    else if (rotation < 180f)
                    {
                        g.DrawString(text, font, new SolidBrush(pen.Color), array[0].X, array[0].Y - sizeF.Height);
                    }
                    else if (rotation < 270f)
                    {
                        g.DrawString(text, font, new SolidBrush(pen.Color), array[0].X, array[0].Y);
                    }
                    else
                    {
                        g.DrawString(text, font, new SolidBrush(pen.Color), array[1].X, array[1].Y - sizeF.Height);
                    }
                }
            }

        }
        private void DrawDiemCuoi(AxMap pMap, Graphics g, Pen pPen)
        {
            PointF pPT = default(PointF);
            PointF pointF = default(PointF);
            if (this.Path.Count > 1)
            {
                float angle;
                PointF[] array;
                checked
                {
                    int index = this.Path.Count - 2;
                    float num = pPT.X;
                    float num2 = pPT.Y;
                    pMap.ConvertCoord(ref num, ref num2, ref this.Path[index].node.Dp.x, ref this.Path[index].node.Dp.y, ConversionConstants.miMapToScreen);
                    pPT.Y = num2;
                    pPT.X = num;
                    index = this.Path.Count - 1;
                    num2 = pointF.X;
                    num = pointF.Y;
                    pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].node.D.x, ref this.Path[index].node.D.y, ConversionConstants.miMapToScreen);
                    pointF.Y = num;
                    pointF.X = num2;
                    angle = (float)modHuanLuyen.GetHDG(pPT, pointF);
                    array = new PointF[4];
                }
                array[0].X = pointF.X - 5f;
                array[0].Y = pointF.Y;
                array[1].X = pointF.X + 5f;
                array[1].Y = pointF.Y;
                array[2].X = pointF.X - 5f;
                array[2].Y = pointF.Y - 3f;
                array[3].X = pointF.X + 5f;
                array[3].Y = pointF.Y - 3f;
                Matrix matrix = new Matrix();
                matrix.RotateAt(angle, pointF, MatrixOrder.Prepend);
                matrix.TransformPoints(array);
                g.DrawLine(pPen, array[0], array[1]);
                g.DrawLine(pPen, array[2], array[3]);
            }
        }
        protected virtual void DrawDiemDau(AxMap pMap, Graphics g, Pen pPen)
        {
            PointF pointF = default(PointF);
            PointF pPT = default(PointF);
            if (this.Path.Count > 1)
            {
                int index = 0;
                float num = pointF.X;
                float num2 = pointF.Y;
                pMap.ConvertCoord(ref num, ref num2, ref this.Path[index].node.D.x, ref this.Path[index].node.D.y, ConversionConstants.miMapToScreen);
                pointF.Y = num2;
                pointF.X = num;
                index = 1;
                num2 = pPT.X;
                num = pPT.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].node.D.x, ref this.Path[index].node.D.y, ConversionConstants.miMapToScreen);
                pPT.Y = num;
                pPT.X = num2;
                float angle = (float)modHuanLuyen.GetHDG(pointF, pPT);
                PointF[] array = new PointF[3];
                array[0].X = pointF.X - 5f;
                array[0].Y = pointF.Y + 5f;
                array[1].X = pointF.X;
                array[1].Y = pointF.Y;
                array[2].X = pointF.X + 5f;
                array[2].Y = pointF.Y + 5f;
                Matrix matrix = new Matrix();
                matrix.RotateAt(angle, pointF, MatrixOrder.Prepend);
                matrix.TransformPoints(array);
                g.DrawLines(pPen, array);
                string flightNo = this.FlightNo;
                Font defaSoHieuFont = modHuanLuyen.defaSoHieuFont;
                Color color = Color.FromArgb(50, pPen.Color);
                Pen pen = new Pen(color, 1f);
                SizeF sizeF = g.MeasureString(flightNo, defaSoHieuFont);
                if (array[2].X >= array[1].X)
                {
                    checked
                    {
                        g.DrawRectangle(pen, array[2].X, array[2].Y, (float)((int)Math.Round((double)sizeF.Width) + 6), (float)((int)Math.Round((double)sizeF.Height) + 6));
                    }
                    g.DrawString(flightNo, defaSoHieuFont, new SolidBrush(pPen.Color), array[2].X + 3f, array[2].Y + 3f);
                }
                else
                {
                    g.DrawRectangle(pen, array[2].X - (float)checked((int)Math.Round((double)sizeF.Width) + 6), array[2].Y, (float)checked((int)Math.Round((double)sizeF.Width) + 6), (float)checked((int)Math.Round((double)sizeF.Height) + 6));
                    g.DrawString(flightNo, defaSoHieuFont, new SolidBrush(pPen.Color), array[2].X + 3f - (float)checked((int)Math.Round((double)sizeF.Width) + 6), array[2].Y + 3f);
                }
            }
        }
        private void DrawDuongThang(AxMap pMap, Graphics g, Pen pPen, int index)
        {
            if (this.Path[index].node.t2next + this.Path[index].node.tspeed > 0.0)
            {
                PathNode node = this.Path[checked(index + 1)].node;
                PointF pt = default(PointF);
                float num = pt.X;
                float num2 = pt.Y;
                pMap.ConvertCoord(ref num, ref num2, ref node.D.x, ref node.D.y, ConversionConstants.miMapToScreen);
                pt.Y = num2;
                pt.X = num;
                PointF pt2 = default(PointF);
                num2 = pt2.X;
                num = pt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].node.Dp.x, ref this.Path[index].node.Dp.y, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(pPen, pt2, pt);
            }
        }
        private void DrawDuongThangDau(AxMap pMap, Graphics g, Pen pPen, bool bnodelbl)
        {
            PointF pointF = default(PointF);
            PathNode node = this.Path[0].node;
            float num = pointF.X;
            float num2 = pointF.Y;
            pMap.ConvertCoord(ref num, ref num2, ref node.D.x, ref node.D.y, ConversionConstants.miMapToScreen);
            pointF.Y = num2;
            pointF.X = num;
            PointF pt = default(PointF);
            num2 = pt.X;
            num = pt.Y;
            pMap.ConvertCoord(ref num2, ref num, ref this.Path[1].node.D.x, ref this.Path[1].node.D.y, ConversionConstants.miMapToScreen);
            pt.Y = num;
            pt.X = num2;
            g.DrawLine(pPen, pointF, pt);
            if (bnodelbl)
            {
                string lblText = "Bắt đầu: " + this.Departure.ToString("HH:mm:ss");
                PathNode.DrawNodeLbl2(pMap, g, pPen, pointF, lblText);
            }
        }
        private void DrawVongLuon(AxMap pMap, Graphics g, Pen pPen, int index, bool blabel)
        {
            PointF pointF = default(PointF);
            float num = pointF.X;
            float num2 = pointF.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.Path[index].node.D.x, ref this.Path[index].node.D.y, ConversionConstants.miMapToScreen);
            pointF.Y = num2;
            pointF.X = num;
            if (this.Path[index].node.R > 0.0 & this.Path[index].node.typ > 0.9)
            {
                PointF pPt = default(PointF);
                num2 = pPt.X;
                num = pPt.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].node.C.x, ref this.Path[index].node.C.y, ConversionConstants.miMapToScreen);
                pPt.Y = num;
                pPt.X = num2;
                double num3 = CBasePath.getdistance(pPt, pointF);
                RectangleF rect = new RectangleF((float)((double)pPt.X - num3), (float)((double)pPt.Y - num3), (float)(2.0 * num3), (float)(2.0 * num3));
                if (blabel)
                {
                    g.DrawEllipse(Pens.LightGray, rect);
                }
                float startAngle;
                if (this.Path[index].node.Turn == TurnValue.Left)
                {
                    startAngle = (float)(this.Path[index].node.hdgCD - this.Path[index].node.yp);
                }
                else
                {
                    startAngle = (float)this.Path[index].node.hdgCD;
                }
                g.DrawArc(pPen, rect, startAngle, (float)this.Path[index].node.yp);
            }
            if (blabel & this.Path[index].nodetype == 0)
            {
                string lblText = string.Concat(new string[]
{
this.Path[index].td.ToString("HH:mm:ss"),
"; ",
this.Path[index].node.Speed.ToString("#0.##km/h"),
"; ",
this.Path[index].node.Roll.ToString("#0°"),
"; ",
this.Path[index].node.typ.ToString("#0s")
});
                PathNode.DrawNodeLbl(pMap, g, pPen, pointF, lblText);
            }
        }
        public bool HitTest(AxMap pMap, PointF pt)
        {
            Matrix matrix = new Matrix();
            GraphicsPath graphicsPath = new GraphicsPath();
            checked
            {
                if (this.Path.Count > 0)
                {
                    this.AddDuongThangDau(pMap, ref graphicsPath);
                    int arg_35_0 = 0;
                    int num = this.Path.Count - 1;
                    for (int i = arg_35_0; i <= num; i++)
                    {
                        this.AddVongLuon(pMap, i, ref graphicsPath);
                        this.AddDuongThang(pMap, i, ref graphicsPath);
                    }
                }
                else
                {
                    this.AddDuongThangDau(pMap, ref graphicsPath);
                }
                Pen pen = new Pen(Color.Black, 4f);
                return graphicsPath.IsOutlineVisible(pt, pen);
            }
        }
        private void AddDuongThangDau(AxMap pMap, ref GraphicsPath gPath)
        {
            PointF pt = default(PointF);
            PathNode node = this.Path[0].node;
            float num = pt.X;
            float num2 = pt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref node.D.x, ref node.D.y, ConversionConstants.miMapToScreen);
            pt.Y = num2;
            pt.X = num;
            PointF pt2 = default(PointF);
            num2 = pt2.X;
            num = pt2.Y;
            pMap.ConvertCoord(ref num2, ref num, ref this.Path[1].node.D.x, ref this.Path[1].node.D.y, ConversionConstants.miMapToScreen);
            pt2.Y = num;
            pt2.X = num2;
            gPath.AddLine(pt, pt2);
        }
        private void AddDuongThang(AxMap pMap, int index, ref GraphicsPath gPath)
        {
            if (this.Path[index].node.t2next + this.Path[index].node.tspeed > 0.0)
            {
                PathNode node = this.Path[checked(index + 1)].node;
                PointF pt = default(PointF);
                float num = pt.X;
                float num2 = pt.Y;
                pMap.ConvertCoord(ref num, ref num2, ref node.D.x, ref node.D.y, ConversionConstants.miMapToScreen);
                pt.Y = num2;
                pt.X = num;
                PointF pt2 = default(PointF);
                num2 = pt2.X;
                num = pt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].node.Dp.x, ref this.Path[index].node.Dp.y, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                gPath.AddLine(pt2, pt);
            }
        }
        private void AddVongLuon(AxMap pMap, int index, ref GraphicsPath gPath)
        {
            PointF pPt = default(PointF);
            float num = pPt.X;
            float num2 = pPt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.Path[index].node.D.x, ref this.Path[index].node.D.y, ConversionConstants.miMapToScreen);
            pPt.Y = num2;
            pPt.X = num;
            if (this.Path[index].node.R > 0.0 & this.Path[index].node.typ > 0.9)
            {
                PointF pPt2 = default(PointF);
                num2 = pPt2.X;
                num = pPt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].node.C.x, ref this.Path[index].node.C.y, ConversionConstants.miMapToScreen);
                pPt2.Y = num;
                pPt2.X = num2;
                double num3 = CBasePath.getdistance(pPt2, pPt);
                RectangleF rect = new RectangleF((float)((double)pPt2.X - num3), (float)((double)pPt2.Y - num3), (float)(2.0 * num3), (float)(2.0 * num3));
                float startAngle;
                if (this.Path[index].node.Turn == TurnValue.Left)
                {
                    startAngle = (float)(this.Path[index].node.hdgCD - this.Path[index].node.yp);
                }
                else
                {
                    startAngle = (float)this.Path[index].node.hdgCD;
                }
                gPath.AddArc(rect, startAngle, (float)this.Path[index].node.yp);
            }
        }
        public double getspeedAt(double secs, int mLastIndex)
        {
            FlightNode flightNode = this.Path[checked(mLastIndex + 1)];
            FlightNode flightNode2 = this.Path[mLastIndex];
            double result;
            if (secs < flightNode2.node.typ)
            {
                result = flightNode2.node.Speed;
            }
            else if (secs < flightNode2.node.typ + flightNode2.node.tspeed)
            {
                double num = 0.0;
                if (flightNode2.node.tspeed > 1.0)
                {
                    num = (flightNode.node.Speed - flightNode2.node.Speed) / (flightNode2.node.tspeed - 1.0);
                }
                result = flightNode2.node.Speed + (secs - flightNode2.node.typ) * num;
            }
            else
            {
                result = flightNode.node.Speed;
            }
            return result;
        }
        public double getspeedAt2(double secs, double speed1, double speed2, double mtyp, double mtspeed)
        {
            double result;
            if (secs < mtyp)
            {
                result = speed1;
            }
            else if (secs < mtyp + mtspeed)
            {
                double num = 0.0;
                if (mtspeed > 0.0)
                {
                    num = (speed2 - speed1) / mtspeed;
                }
                result = speed1 + (secs - mtyp) * num;
            }
            else
            {
                result = speed2;
            }
            return result;
        }
        public double getquangduong2(double misecs, double speed1, double speed2, double mtyp, double mtspeed)
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3;
            if (misecs < mtyp * 1000.0)
            {
                num3 = misecs;
            }
            else if (misecs < (mtyp + mtspeed) * 1000.0)
            {
                num3 = mtyp * 1000.0;
                num = misecs - num3;
            }
            else
            {
                num3 = mtyp * 1000.0;
                num = mtspeed * 1000.0;
                num2 = misecs - (num3 + num);
            }
            double num4 = speed1 * num3 / 1000.0;
            double num5 = num / 1000.0;
            int num6 = checked((int)Math.Round(Math.Floor(num5)));
            double num7 = 0.0;
            if (mtspeed > 0.0)
            {
                num7 = (speed2 - speed1) / mtspeed;
            }
            double num8 = (double)checked(num6 - 1) * (speed1 + num7 * (double)num6 / 2.0);
            num8 += (speed1 + num7 * (double)num6) * (num5 - (double)num6);
            double num9 = speed2 * num2 / 1000.0;
            return num4 + num8 + num9;
        }
        public void UpdateMB(AxMap pMap)
        {
            DateTime now = DateTime.Now;
            checked
            {
                if (DateTime.Compare(now, this.Departure) > 0)
                {
                    if (DateTime.Compare(now, this.Path[this.Path.Count - 1].td) < 0)
                    {
                        CMayBay mayBay = this.getMayBay(pMap, now);
                        CMayBay mayBay2 = this.MayBay;
                        mayBay2.Pos.x = mayBay.Pos.x;
                        mayBay2.Pos.y = mayBay.Pos.y;
                        mayBay2.Pos.h = mayBay.Pos.h;
                        mayBay2.Rotation = mayBay.Rotation;
                        mayBay2.Speed = mayBay.Speed;
                    }
                    else
                    {
                        CMayBay mayBay3 = this.MayBay;
                        mayBay3.Pos.x = this.Path[this.Path.Count - 1].node.D.x;
                        mayBay3.Pos.y = this.Path[this.Path.Count - 1].node.D.y;
                        mayBay3.Pos.h = this.Path[this.Path.Count - 1].node.D.h;
                        this.MayBay.Visible = false;
                    }
                }
            }
        }
        public void GetMayBay2(AxMap pMap, DateTime pLuc)
        {
            checked
            {
                if (DateTime.Compare(pLuc, this.Departure) >= 0)
                {
                    if (DateTime.Compare(pLuc, this.Path[this.Path.Count - 1].td) < 0)
                    {
                        CMayBay mayBay = this.getMayBay(pMap, pLuc);
                        CMayBay mayBay2 = this.MayBay;
                        mayBay2.Pos.x = mayBay.Pos.x;
                        mayBay2.Pos.y = mayBay.Pos.y;
                        mayBay2.Pos.h = mayBay.Pos.h;
                        mayBay2.Rotation = mayBay.Rotation;
                        mayBay2.Speed = mayBay.Speed;
                        mayBay2.Status = enTopStatus.DangBay;
                        mayBay2.Visible = true;
                    }
                    else
                    {
                        CMayBay mayBay3 = this.MayBay;
                        mayBay3.Pos.x = this.Path[this.Path.Count - 1].node.D.x;
                        mayBay3.Pos.y = this.Path[this.Path.Count - 1].node.D.y;
                        mayBay3.Pos.h = this.Path[this.Path.Count - 1].node.D.h;
                        mayBay3.Status = enTopStatus.DungBay;
                        mayBay3.Visible = false;
                    }
                }
                else
                {
                    CMayBay mayBay4 = this.MayBay;
                    mayBay4.Pos.x = this.Path[0].node.D.x;
                    mayBay4.Pos.y = this.Path[0].node.D.y;
                    mayBay4.Pos.h = this.Path[0].node.D.h;
                    mayBay4.Status = enTopStatus.ChuaBay;
                    mayBay4.Visible = false;
                }
            }
        }
        public void GetMayBay2From(CFlight pFlight)
        {
            CMayBay mayBay = pFlight.MayBay;
            CMayBay mayBay2 = this.MayBay;
            mayBay2.Pos.x = mayBay.Pos.x;
            mayBay2.Pos.y = mayBay.Pos.y;
            mayBay2.Pos.h = mayBay.Pos.h;
            mayBay2.Rotation = mayBay.Rotation;
            mayBay2.Speed = mayBay.Speed;
            mayBay2.Status = mayBay.Status;
            mayBay2.Visible = mayBay.Visible;
        }
        public void updateLastNode(int mCurrIndex)
        {
            if (this.Path.Count > checked(mCurrIndex + 1))
            {
                FlightNode flightNode = this.Path[checked(mCurrIndex + 1)];
                FlightNode flightNode2 = this.Path[mCurrIndex];
                double num = flightNode2.node.typ + flightNode2.node.tspeed + flightNode2.node.t2next;
                double speed = flightNode2.node.Speed / 3.6;
                double speed2 = flightNode.node.Speed / 3.6;
                double num2 = this.getquangduong2(num * 1000.0, speed, speed2, flightNode2.node.typ, flightNode2.node.tspeed);
                double misecs = flightNode2.node.typ * 1000.0;
                double num3 = this.getquangduong2(misecs, speed, speed2, flightNode2.node.typ, flightNode2.node.tspeed);
                misecs = (flightNode2.node.typ + flightNode2.node.tspeed) * 1000.0;
                double num4 = this.getquangduong2(misecs, speed, speed2, flightNode2.node.typ, flightNode2.node.tspeed);
                double totalMilliseconds = flightNode.td.Subtract(flightNode2.td).TotalMilliseconds;
                double num5 = this.getquangduong2(totalMilliseconds, speed, speed2, flightNode2.node.typ, flightNode2.node.tspeed);
                double num6 = totalMilliseconds / 1000.0;
                if (num5 >= num4)
                {
                    flightNode2.node.t2next = num6 - (flightNode2.node.typ + flightNode2.node.tspeed);
                }
                else if (num5 >= num3)
                {
                    flightNode2.node.t2next = 0.0;
                    flightNode2.node.tspeed = num6 - flightNode2.node.typ;
                }
                else
                {
                    flightNode2.node.t2next = 0.0;
                    flightNode2.node.tspeed = 0.0;
                    flightNode2.node.typ = num6;
                    double num7 = num5 / num3;
                    flightNode2.node.yp = flightNode2.node.yp * num7;
                }
            }
        }
        public void StopMayBay(DateTime pLuc)
        {
            CMayBay mayBay = this.getMayBay(modHuanLuyen.fMain.AxMap1, pLuc);
            int currIndex = this.GetCurrIndex(pLuc);
            checked
            {
                FlightNode flightNode = this.Path[currIndex + 1];
                FlightNode flightNode2 = this.Path[currIndex];
                int num = this.Path.Count - 1;
                List<FlightNode> list = new List<FlightNode>();
                int arg_52_0 = 0;
                int num2 = currIndex + 1;
                for (int i = arg_52_0; i <= num2; i++)
                {
                    list.Add(this.Path[i]);
                }
                FlightNode flightNode3 = list[currIndex + 1];
                flightNode3.td = pLuc;
                flightNode3.node.typ = 0.0;
                flightNode3.node.tspeed = 0.0;
                flightNode3.node.t2next = 0.0;
                PathNode node = flightNode3.node;
                node.D.x = mayBay.Pos.x;
                node.D.y = mayBay.Pos.y;
                node.D.h = mayBay.Pos.h;
                node.Dp.x = mayBay.Pos.x;
                node.Dp.y = mayBay.Pos.y;
                node.Dp.h = mayBay.Pos.h;
                node.C.x = mayBay.Pos.x;
                node.C.y = mayBay.Pos.y;
                node.C.h = mayBay.Pos.h;
                this.Path = list;
                this.updateLastNode(currIndex);
            }
        }
        public void DoiHuongBay(DateTime pLuc, CTop pTop)
        {
            int currIndex = this.GetCurrIndex(pLuc);
            checked
            {
                FlightNode flightNode = this.Path[currIndex + 1];
                FlightNode flightNode2 = this.Path[currIndex];
                int num = this.Path.Count - 1;
                List<FlightNode> list = new List<FlightNode>();
                int arg_3D_0 = 0;
                int num2 = currIndex;
                for (int i = arg_3D_0; i <= num2; i++)
                {
                    list.Add(this.Path[i]);
                }
                FlightNode flightNode3 = new FlightNode();
                flightNode3.td = pLuc;
                PathNode node = flightNode3.node;
                node.D.x = pTop.PosFrom.x;
                node.D.y = pTop.PosFrom.y;
                node.D.h = pTop.PosFrom.h;
                node.Dp.x = pTop.PosFrom.x;
                node.Dp.y = pTop.PosFrom.y;
                node.Dp.h = pTop.PosFrom.h;
                node.C.x = pTop.PosFrom.x;
                node.C.y = pTop.PosFrom.y;
                node.C.h = pTop.PosFrom.h;
                node.Speed = pTop.SpeedFrom;
                list.Add(flightNode3);
                foreach (PathNode current in pTop.Path)
                {
                    list.Add(new FlightNode(current)
                    {
                        isPlan = true,
                        td = pLuc
                    });
                }

                flightNode3 = new FlightNode();
                flightNode3.td = pLuc;
                PathNode node2 = flightNode3.node;
                node2.D.x = pTop.PosTo.x;
                node2.D.y = pTop.PosTo.y;
                node2.D.h = pTop.PosTo.h;
                node2.Dp.x = pTop.PosTo.x;
                node2.Dp.y = pTop.PosTo.y;
                node2.Dp.h = pTop.PosTo.h;
                node2.C.x = pTop.PosTo.x;
                node2.C.y = pTop.PosTo.y;
                node2.C.h = pTop.PosTo.h;
                node2.Speed = pTop.SpeedTo;
                list.Add(flightNode3);
                this.Path = list;
                this.updateLastNode(currIndex);
                this.TinhYToLuonVong(modHuanLuyen.fMain.AxMap1, currIndex + 1);
                this.UpdateTd(currIndex);
            }
        }
        public CMayBay getMayBay(AxMap pMap, DateTime pLuc)
        {
            int currIndex = this.GetCurrIndex(pLuc);
            FlightNode flightNode = this.Path[checked(currIndex + 1)];
            FlightNode flightNode2 = this.Path[currIndex];
            CMayBay cMayBay = new CMayBay(0);
            double num = flightNode2.node.typ + flightNode2.node.tspeed + flightNode2.node.t2next;
            double speed = flightNode2.node.Speed / 3.6;
            double speed2 = flightNode.node.Speed / 3.6;
            double num2 = this.getquangduong2(num * 1000.0, speed, speed2, flightNode2.node.typ, flightNode2.node.tspeed);
            double misecs = flightNode2.node.typ * 1000.0;
            double num3 = this.getquangduong2(misecs, speed, speed2, flightNode2.node.typ, flightNode2.node.tspeed);
            double totalMilliseconds = pLuc.Subtract(flightNode2.td).TotalMilliseconds;
            double num4 = this.getquangduong2(totalMilliseconds, speed, speed2, flightNode2.node.typ, flightNode2.node.tspeed);
            double totalSeconds = pLuc.Subtract(flightNode2.td).TotalSeconds;
            cMayBay.Speed = this.getspeedAt2(totalSeconds, flightNode2.node.Speed, flightNode.node.Speed, flightNode2.node.typ, flightNode2.node.tspeed);
            cMayBay.Pos.h = flightNode2.node.D.h;
            if (num4 >= num3)
            {
                PointF pPT = default(PointF);
                float num5 = pPT.X;
                float num6 = pPT.Y;
                pMap.ConvertCoord(ref num5, ref num6, ref flightNode2.node.Dp.x, ref flightNode2.node.Dp.y, ConversionConstants.miMapToScreen);
                pPT.Y = num6;
                pPT.X = num5;
                PointF pPT2 = default(PointF);
                num6 = pPT2.X;
                num5 = pPT2.Y;
                pMap.ConvertCoord(ref num6, ref num5, ref flightNode.node.D.x, ref flightNode.node.D.y, ConversionConstants.miMapToScreen);
                pPT2.Y = num5;
                pPT2.X = num6;
                double num7 = (num4 - num3) / (num2 - num3);
                CMayBay cMayBay2 = cMayBay;
                cMayBay2.Rotation = (float)modHuanLuyen.GetHDG(pPT, pPT2);
                cMayBay2.Pos.x = num7 * (flightNode.node.D.x - flightNode2.node.Dp.x) + flightNode2.node.Dp.x;
                cMayBay2.Pos.y = num7 * (flightNode.node.D.y - flightNode2.node.Dp.y) + flightNode2.node.Dp.y;
                cMayBay2.Pos.h = num7 * (flightNode.node.D.h - flightNode2.node.D.h) + flightNode2.node.D.h;
            }
            else
            {
                PointF pointF = default(PointF);
                float num6 = pointF.X;
                float num5 = pointF.Y;
                pMap.ConvertCoord(ref num6, ref num5, ref flightNode2.node.C.x, ref flightNode2.node.C.y, ConversionConstants.miMapToScreen);
                pointF.Y = num5;
                pointF.X = num6;
                PointF pointF2 = default(PointF);
                num6 = pointF2.X;
                num5 = pointF2.Y;
                pMap.ConvertCoord(ref num6, ref num5, ref flightNode2.node.D.x, ref flightNode2.node.D.y, ConversionConstants.miMapToScreen);
                pointF2.Y = num5;
                pointF2.X = num6;
                double num8 = num4 / num3;
                double num9 = flightNode2.node.yp * num8;
                double num10 = 0.0;
                if (flightNode2.node.Turn == TurnValue.Left)
                {
                    num10 = -num9;
                }
                else if (flightNode2.node.Turn == TurnValue.Right)
                {
                    num10 = num9;
                }
                PointF[] array = new PointF[1];
                array[0].X = pointF2.X;
                array[0].Y = pointF2.Y;
                Matrix matrix = new Matrix();
                matrix.RotateAt((float)num10, pointF, MatrixOrder.Prepend);
                matrix.TransformPoints(array);
                PointF[] array2 = array;
                PointF[] arg_48D_0 = array2;
                int num11 = 0;
                num6 = arg_48D_0[num11].X;
                PointF[] array3 = array;
                PointF[] arg_4A6_0 = array3;
                int num12 = 0;
                num5 = arg_4A6_0[num12].Y;
                pMap.ConvertCoord(ref num6, ref num5, ref cMayBay.Pos.x, ref cMayBay.Pos.y, ConversionConstants.miScreenToMap);
                array3[num12].Y = num5;
                array2[num11].X = num6;
                if (flightNode2.node.Turn == TurnValue.Left)
                {
                    cMayBay.Rotation = (float)modHuanLuyen.HieuChinhGoc(modHuanLuyen.GetHDG(pointF, array[0]) - 90.0);
                }
                else if (flightNode2.node.Turn == TurnValue.Right)
                {
                    cMayBay.Rotation = (float)modHuanLuyen.HieuChinhGoc(modHuanLuyen.GetHDG(pointF, array[0]) + 90.0);
                }
            }
            return cMayBay;
        }
        public CMayBay getMayBay20(AxMap pMap, DateTime pLuc)
        {
            checked
            {
                CMayBay cMayBay;
                if (DateTime.Compare(pLuc, this.Departure) >= 0)
                {
                    if (DateTime.Compare(pLuc, this.Path[this.Path.Count - 1].td) < 0)
                    {
                        cMayBay = this.getMayBay(pMap, pLuc);
                        CMayBay cMayBay2 = cMayBay;
                        cMayBay2.Status = enTopStatus.DangBay;
                        cMayBay2.Visible = true;
                    }
                    else
                    {
                        cMayBay = new CMayBay(0);
                        CMayBay cMayBay3 = cMayBay;
                        cMayBay3.Pos.x = this.Path[this.Path.Count - 1].node.D.x;
                        cMayBay3.Pos.y = this.Path[this.Path.Count - 1].node.D.y;
                        cMayBay3.Pos.h = this.Path[this.Path.Count - 1].node.D.h;
                        cMayBay3.Status = enTopStatus.DungBay;
                        cMayBay3.Visible = false;
                    }
                }
                else
                {
                    cMayBay = new CMayBay(0);
                    CMayBay cMayBay4 = cMayBay;
                    cMayBay4.Pos.x = this.Path[0].node.D.x;
                    cMayBay4.Pos.y = this.Path[0].node.D.y;
                    cMayBay4.Pos.h = this.Path[0].node.D.h;
                    cMayBay4.Status = enTopStatus.ChuaBay;
                    cMayBay4.Visible = false;
                }
                return cMayBay;
            }
        }
        private static double GetCuLy(AxMap pMap, PathNode fromNode, PathNode toNode)
        {
            double num = pMap.Distance(fromNode.Dp.x, fromNode.Dp.y, toNode.D.x, toNode.D.y);
            double num2 = 3.1415926535897931 * fromNode.R * fromNode.yp / 180.0;
            double num3 = num + num2;
            double num4 = toNode.D.h - fromNode.D.h;
            return Math.Sqrt(num3 * num3 + num4 * num4);
        }
        public double GetCuLyConLai(AxMap pMap, DateTime pLuc, int iNode)
        {
            int currIndex = this.GetCurrIndex(pLuc);
            FlightNode flightNode = this.Path[checked(currIndex + 1)];
            FlightNode flightNode2 = this.Path[currIndex];
            double speed = flightNode2.node.Speed / 3.6;
            double speed2 = flightNode.node.Speed / 3.6;
            double totalMilliseconds = pLuc.Subtract(flightNode2.td).TotalMilliseconds;
            double num = this.getquangduong2(totalMilliseconds, speed, speed2, flightNode2.node.typ, flightNode2.node.tspeed);
            double num2 = -num;
            checked
            {
                if (currIndex < iNode)
                {
                    int arg_A1_0 = currIndex;
                    int num3 = iNode - 1;
                    for (int i = arg_A1_0; i <= num3; i++)
                    {
                        unchecked
                        {
                            num2 += CFlight.GetCuLy(pMap, this.Path[i].node, this.Path[checked(i + 1)].node);
                        }
                    }
                }
                return num2;
            }
        }
        public void DrawMB(AxMap pMap, Graphics g)
        {
            if (this.MayBay.Visible)
            {
                this.MayBay.Draw(pMap, g);
            }
        }
        public void DrawMB2(AxMap pMap, Graphics g)
        {
            if (this.MayBay.Visible)
            {
                this.MayBay.Draw2(pMap, g);
            }
        }
        public void DrawMB(AxMap pMap, Graphics g, CNodePattern pPattern)
        {
            if (this.MayBay.Visible)
            {
                this.MayBay.Draw(pMap, g, pPattern);
            }
        }
        private PointF[] GetPoints(AxMap pMap)
        {
            int count = this.Path.Count;
            checked
            {
                PointF[] array = new PointF[count - 1 + 1];
                int num = -1;
                foreach (FlightNode current in this.Path)
                {
                    num++;
                    PointF[] array2 = array;
                    PointF[] arg_43_0 = array2;
                    int num2 = num;
                    float x = arg_43_0[num2].X;
                    PointF[] array3 = array;
                    PointF[] arg_5B_0 = array3;
                    int num3 = num;
                    float y = arg_5B_0[num3].Y;
                    pMap.ConvertCoord(ref x, ref y, ref current.node.D.x, ref current.node.D.y, ConversionConstants.miMapToScreen);
                    array3[num3].Y = y;
                    array2[num2].X = x;
                }

                return array;
            }
        }
        public void Draw(AxMap pMap, Graphics g, Pen pPen)
        {
            PointF[] points = this.GetPoints(pMap);
            g.DrawLines(pPen, points);
        }
        public void DrawNodes(AxMap pMap, Graphics g, int isele)
        {
            Matrix transform = g.Transform;
            GraphicsContainer container = g.BeginContainer();
            checked
            {
                try
                {
                    PointF[] points = this.GetPoints(pMap);
                    if (points.GetUpperBound(0) > 0)
                    {
                        int arg_30_0 = 0;
                        int upperBound = points.GetUpperBound(0);
                        for (int i = arg_30_0; i <= upperBound; i++)
                        {
                            if (i == isele)
                            {
                                PointF mPt = new PointF();
                                float num = mPt.X;
                                float num2 = mPt.Y;
                                pMap.ConvertCoord(ref num, ref num2, ref this.Path[isele].node.C.x, ref this.Path[isele].node.C.y, ConversionConstants.miMapToScreen);
                                mPt.Y = num2;
                                mPt.X = num;
                                PointF mPt2 = new PointF();
                                num2 = mPt2.X;
                                num = mPt2.Y;
                                pMap.ConvertCoord(ref num2, ref num, ref this.Path[isele].node.Dp.x, ref this.Path[isele].node.Dp.y, ConversionConstants.miMapToScreen);
                                mPt2.Y = num;
                                mPt2.X = num2;
                                if (this.Path[isele].node.CachVong == enCachVong.QuanhDiem)
                                {
                                    CBasePath.Draw1Node(pMap, g, points[i], false);
                                    CBasePath.Draw1Node(pMap, g, mPt2, false);
                                    CBasePath.Draw1Node(pMap, g, mPt, true);
                                }
                                else if (this.Path[isele].node.CachVong == enCachVong.HuongDiem)
                                {
                                    CBasePath.Draw1Node(pMap, g, points[i], false);
                                    CBasePath.Draw1Node(pMap, g, mPt, false);
                                    CBasePath.Draw1Node(pMap, g, mPt2, true);
                                }
                                else
                                {
                                    CBasePath.Draw1Node(pMap, g, mPt, false);
                                    CBasePath.Draw1Node(pMap, g, mPt2, false);
                                    CBasePath.Draw1Node(pMap, g, points[i], true);
                                }
                            }
                            else
                            {
                                CBasePath.Draw1Node(pMap, g, points[i], false);
                            }
                        }
                    }
                }
                catch (Exception arg_1E3_0)
                {
                    throw arg_1E3_0;
                }
                finally
                {
                }
                g.EndContainer(container);
                g.Transform = transform;
            }
        }
        public void DrawNodes(AxMap pMap, Graphics g)
        {
            Matrix transform = g.Transform;
            GraphicsContainer container = g.BeginContainer();
            checked
            {
                try
                {
                    PointF[] points = this.GetPoints(pMap);
                    if (points.GetUpperBound(0) > 0)
                    {
                        int arg_2A_0 = 0;
                        int upperBound = points.GetUpperBound(0);
                        for (int i = arg_2A_0; i <= upperBound; i++)
                        {
                            CBasePath.Draw1Node(pMap, g, points[i], false);
                        }
                    }
                }
                catch (Exception arg_4C_0)
                {
                    throw arg_4C_0;
                }
                finally
                {
                }
                g.EndContainer(container);
                g.Transform = transform;
            }
        }
        public int FindNodeAtPoint(AxMap pMap, PointF pt)
        {
            PointF[] points = this.GetPoints(pMap);
            int result = -1;
            RectangleF rectangleF = new RectangleF(0f, 0f, 7f, 7f);
            for (int i = points.GetUpperBound(0); i >= 0; i = checked(i + -1))
            {
                rectangleF.X = points[i].X - 3f;
                rectangleF.Y = points[i].Y - 3f;
                if (rectangleF.Contains(pt))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}