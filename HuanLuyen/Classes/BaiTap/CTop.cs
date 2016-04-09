using AxMapXLib;
using MapXLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HuanLuyen
{
    public class CTop : CBasePath
    {
        public int TopID = 0;
        public int BaiTapID = 0;
        public int LoaiTopID = 0;
        public string FlightNo;
        public int SoLuong = 0;
        public int GioBatDau = 0;
        public int PhutBatDau = 0;
        public int GiayBatDau = 0;
        public int MilliGiayBatDau = 0;
        public string Name;
        public int LblDeltaX = 0;
        public int LblDeltaY = 0;
        public bool visible;

        public override string ToString()
        {
            return string.Concat(new string[] { CLoaiMBs.GetLoaiMB(this.LoaiMB).LoaiMB, ": ", this.FlightNo, " - ", this.GioBatDau.ToString("00"), ":", this.PhutBatDau.ToString("00") });
        }

        public CTop()
        {
            this.TopID = 0;
            this.BaiTapID = 0;
            this.LoaiTopID = 0;
            this.FlightNo = "";
            this.SoLuong = 0;
            this.GioBatDau = 0;
            this.PhutBatDau = 0;
            this.GiayBatDau = 0;
            this.MilliGiayBatDau = 0;
            this.Name = "";
            this.LblDeltaX = 0;
            this.LblDeltaY = 0;
            this.visible = true;
            this.LoaiMB = 0;
            this.PosFrom = default(MapPoint);
            this.SpeedFrom = 0.0;
            this.PosTo = default(MapPoint);
            this.SpeedTo = 0.0;
            this.Path = new List<PathNode>();
        }

        public CTop(CFlight pFlight)
        {
            this.TopID = 0;
            this.BaiTapID = 0;
            this.LoaiTopID = 0;
            this.FlightNo = "";
            this.SoLuong = 0;
            this.GioBatDau = 0;
            this.PhutBatDau = 0;
            this.GiayBatDau = 0;
            this.MilliGiayBatDau = 0;
            this.Name = "";
            this.LblDeltaX = 0;
            this.LblDeltaY = 0;
            this.visible = true;
            this.LoaiTopID = pFlight.LoaiTopID;
            this.FlightNo = pFlight.FlightNo;
            this.SoLuong = pFlight.SoLuong;
            this.GioBatDau = pFlight.Departure.Hour;
            this.PhutBatDau = pFlight.Departure.Minute;
            this.GiayBatDau = pFlight.Departure.Second;
            this.MilliGiayBatDau = pFlight.Departure.Millisecond;
            this.Name = pFlight.FlightNo;
            this.LoaiMB = pFlight.LoaiMBID;
            this.PosFrom = default(MapPoint);
            this.PosFrom.x = pFlight.Path[0].node.D.x;
            this.PosFrom.y = pFlight.Path[0].node.D.y;
            this.PosFrom.h = pFlight.Path[0].node.D.h;
            this.SpeedFrom = pFlight.Path[0].node.Speed;
            int count = pFlight.Path.Count;
            this.PosTo = default(MapPoint);
            checked
            {
                this.PosTo.x = pFlight.Path[count - 1].node.D.x;
                this.PosTo.y = pFlight.Path[count - 1].node.D.y;
                this.PosTo.h = pFlight.Path[count - 1].node.D.h;
                this.SpeedTo = pFlight.Path[count - 1].node.Speed;
                this.Path = new List<PathNode>();
                if (count > 2)
                {
                    int arg_245_0 = 1;
                    int num = count - 2;
                    for (int i = arg_245_0; i <= num; i++)
                    {
                        this.Path.Add(pFlight.Path[i].node);
                    }
                }
            }
        }

        public void DrawNameNode(AxMap pMap, Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1f);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, Color.White));
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, 7, 7);
            Matrix transform = g.Transform;
            GraphicsContainer container = g.BeginContainer();
            try
            {
                PointF pointF = default(PointF);
                float x = pointF.X;
                float y = pointF.Y;
                pMap.ConvertCoord(ref x, ref y, ref this.PosFrom.x, ref this.PosFrom.y, ConversionConstants.miMapToScreen);
                pointF.Y = y;
                pointF.X = x;
                pointF.X += (float)this.LblDeltaX;
                pointF.Y += (float)this.LblDeltaY;
                checked
                {
                    rect.X = (int)Math.Round((double)unchecked(pointF.X - 3f));
                    rect.Y = (int)Math.Round((double)unchecked(pointF.Y - 3f));
                    g.FillEllipse(solidBrush, rect);
                    g.DrawEllipse(pen, rect);
                }
            }
            catch (Exception arg_103_0)
            {
                throw arg_103_0;
            }
            finally
            {
                pen.Dispose();
                solidBrush.Dispose();
            }
            g.EndContainer(container);
            g.Transform = transform;
        }

        public bool FindNameNodeAtPoint(AxMap pMap, PointF pt)
        {
            PointF pointF = default(PointF);
            float x = pointF.X;
            float y = pointF.Y;
            pMap.ConvertCoord(ref x, ref y, ref this.PosFrom.x, ref this.PosFrom.y, ConversionConstants.miMapToScreen);
            pointF.Y = y;
            pointF.X = x;
            pointF.X += (float)this.LblDeltaX;
            pointF.Y += (float)this.LblDeltaY;
            RectangleF rectangleF = new RectangleF(pointF.X - 3f, pointF.Y - 3f, 7f, 7f);
            return rectangleF.Contains(pt);
        }
        public void MoveNameNodeTo(AxMap pMap, PointF pt)
        {
            PointF pointF = default(PointF);
            float x = pointF.X;
            float y = pointF.Y;
            pMap.ConvertCoord(ref x, ref y, ref this.PosFrom.x, ref this.PosFrom.y, ConversionConstants.miMapToScreen);
            pointF.Y = y;
            pointF.X = x;
            checked
            {
                this.LblDeltaX = (int)Math.Round((double)unchecked(pt.X - pointF.X));
                this.LblDeltaY = (int)Math.Round((double)unchecked(pt.Y - pointF.Y));
            }
        }

        protected override void DrawDiemDau(AxMap pMap, Graphics g, Pen pPen)
        {
            PointF pointF = default(PointF);
            PointF pPT = default(PointF);
            float num = pointF.X;
            float num2 = pointF.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.PosFrom.x, ref this.PosFrom.y, ConversionConstants.miMapToScreen);
            pointF.Y = num2;
            pointF.X = num;
            Pen pen = new Pen(Color.Black, 1f);
            Pen arg_A7_1 = pen;
            PointF arg_A7_2 = pointF;
            System.Drawing.Point p = checked(new System.Drawing.Point((int)Math.Round((double)unchecked(pointF.X + (float)this.LblDeltaX)), (int)Math.Round((double)unchecked(pointF.Y + (float)this.LblDeltaY))));
            g.DrawLine(arg_A7_1, arg_A7_2, p);
            pointF.X += (float)this.LblDeltaX;
            pointF.Y += (float)this.LblDeltaY;
            if (this.Path.Count > 0)
            {
                num2 = pPT.X;
                num = pPT.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[0].D.x, ref this.Path[0].D.y, ConversionConstants.miMapToScreen);
                pPT.Y = num;
                pPT.X = num2;
            }
            else
            {
                num2 = pPT.X;
                num = pPT.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.PosTo.x, ref this.PosTo.y, ConversionConstants.miMapToScreen);
                pPT.Y = num;
                pPT.X = num2;
            }
            float num3 = (float)modHuanLuyen.GetHDG(pointF, pPT);
            CLoaiMB loaiMB = CLoaiMBs.GetLoaiMB(this.LoaiMB);
            int num4 = checked((int)Math.Round(this.PosFrom.h / 100.0));
            string text = string.Concat(new string[] { this.FlightNo, "(", this.GioBatDau.ToString("00"), ":", this.PhutBatDau.ToString("00"), ")" });
            string text2 = this.SoLuong.ToString("00") + loaiMB.KL;
            string s = num4.ToString("000");
            Font font = new Font("Arial Narrow", modHuanLuyen.defaSoHieuFontSize, FontStyle.Regular, GraphicsUnit.Point);
            SizeF sizeF = g.MeasureString(text, font);
            SizeF sizeF2 = g.MeasureString(text2, font);
            Pen pen2 = new Pen(Color.Black, pPen.Width);
            float num5 = sizeF2.Width / 4f;
            float num6 = sizeF2.Height * 2f;
            if (num3 > 180f)
            {
                System.Drawing.Point p2 = checked(new System.Drawing.Point((int)Math.Round((double)unchecked(pointF.X + num5 + sizeF2.Width + 3f)), (int)Math.Round((double)pointF.Y)));
                g.DrawLine(pen2, pointF, p2);
                g.DrawString(text2, font, new SolidBrush(pen2.Color), pointF.X + num5, pointF.Y - (sizeF.Height + 3f));
                g.DrawString(s, font, new SolidBrush(pen2.Color), pointF.X + num5 + sizeF2.Width / 4f, pointF.Y + 3f);
                g.DrawString(text, font, new SolidBrush(pen2.Color), (float)checked(p2.X + 3), pointF.Y - sizeF.Height / 2f);
                RectangleF rect = new RectangleF((float)p2.X, pointF.Y - sizeF2.Height, num6, num6);
                g.DrawArc(pen2, rect, 90f, 180f);
            }
            else
            {
                System.Drawing.Point p3 = checked(new System.Drawing.Point((int)Math.Round((double)unchecked(pointF.X - (num5 + sizeF2.Width + 3f))), (int)Math.Round((double)pointF.Y)));
                g.DrawLine(pen2, pointF, p3);
                g.DrawString(text2, font, new SolidBrush(pen2.Color), pointF.X - num5 - sizeF2.Width, pointF.Y - (sizeF.Height + 3f));
                g.DrawString(s, font, new SolidBrush(pen2.Color), pointF.X - num5 - sizeF2.Width, pointF.Y + 3f);
                g.DrawString(text, font, new SolidBrush(pen2.Color), (float)checked(p3.X - 3) - sizeF.Width, pointF.Y - sizeF.Height / 2f);
                RectangleF rect2 = new RectangleF((float)p3.X - num6, pointF.Y - sizeF2.Height, num6, num6);
                g.DrawArc(pen2, rect2, -90f, 180f);
            }
        }

        public void DrawPhutNodes(AxMap pMap, Graphics g, Pen pPen)
        {
            CFlight flight = this.GetFlight(pMap);
            if (flight == null)
            {
                return;
            }
            DateTime dateTime = flight.Departure;
            string text = "";
            Font font = new Font("Arial Narrow", modHuanLuyen.defaSoHieuFontSize, FontStyle.Regular, GraphicsUnit.Point);
            SizeF sizeF = g.MeasureString(text, font);
            checked
            {
                while (DateTime.Compare(dateTime, flight.Path[flight.Path.Count - 1].td) < 0)
                {
                    dateTime = dateTime.AddMinutes(1.0);
                    if (DateTime.Compare(dateTime, flight.Departure) > 0 & DateTime.Compare(dateTime, flight.Path[flight.Path.Count - 1].td) < 0)
                    {
                        CMayBay mayBay = flight.getMayBay(pMap, dateTime);
                        float rotation = mayBay.Rotation;
                        int num = (int)Math.Round(mayBay.Pos.h / 100.0);
                        PointF point = default(PointF);
                        float x = point.X;
                        float y = point.Y;
                        pMap.ConvertCoord(ref x, ref y, ref mayBay.Pos.x, ref mayBay.Pos.y, ConversionConstants.miMapToScreen);
                        point.Y = y;
                        point.X = x;
                        PointF[] array = new PointF[2];
                        unchecked
                        {
                            array[0].X = point.X - (float)modHuanLuyen.defaPathDauCuoiSize;
                            array[0].Y = point.Y;
                            array[1].X = point.X + (float)modHuanLuyen.defaPathDauCuoiSize;
                            array[1].Y = point.Y;
                            Matrix matrix = new Matrix();
                            matrix.RotateAt(rotation, point, MatrixOrder.Prepend);
                            matrix.TransformPoints(array);
                            g.DrawLine(pPen, array[0], array[1]);
                            text = string.Concat(new string[] { dateTime.Hour.ToString("00"), ":", dateTime.Minute.ToString("00"), "(", num.ToString("000"), ")" });
                            sizeF = g.MeasureString(text, font);
                            if (rotation < 90f)
                            {
                                g.DrawString(text, font, new SolidBrush(pPen.Color), array[1].X, array[1].Y);
                            }
                            else if (rotation < 180f)
                            {
                                g.DrawString(text, font, new SolidBrush(pPen.Color), array[0].X, array[0].Y - sizeF.Height);
                            }
                            else if (rotation < 270f)
                            {
                                g.DrawString(text, font, new SolidBrush(pPen.Color), array[0].X, array[0].Y);
                            }
                            else
                            {
                                g.DrawString(text, font, new SolidBrush(pPen.Color), array[1].X, array[1].Y - sizeF.Height);
                            }
                        }
                    }
                }
            }
        }

        private CFlight GetFlight(AxMap pMap)
        {
            CFlight cFlight = new CFlight(this);
            if (cFlight == null)
            {
                return null;
            }
            cFlight.Flight_ID = 0;
            CBasePath.TinhSecs(pMap, cFlight.Path[0].node, cFlight.Path[1].node);
            DateTime pTd = cFlight.Departure.AddSeconds(cFlight.Path[0].node.t2next + cFlight.Path[0].node.tspeed);
            cFlight.TinhYToLuonVong(pMap, 1);
            cFlight.UpdateTd(1, pTd);
            return cFlight;
        }

        public void TinhTien(double pDx, double pDy)
        {
            this.PosFrom.x = this.PosFrom.x + pDx;
            this.PosFrom.y = this.PosFrom.y + pDy;
            checked
            {
                if (this.Path.Count > 0)
                {
                    int arg_50_0 = 0;
                    int num = this.Path.Count - 1;
                    for (int i = arg_50_0; i <= num; i++)
                    {
                        PathNode pathNode = this.Path[i];
                        PathNode pathNode2 = pathNode;
                        unchecked
                        {
                            pathNode2.C.x = pathNode2.C.x + pDx;
                            pathNode2 = pathNode;
                            pathNode2.C.y = pathNode2.C.y + pDy;
                            pathNode2 = pathNode;
                            pathNode2.D.x = pathNode2.D.x + pDx;
                            pathNode2 = pathNode;
                            pathNode2.D.y = pathNode2.D.y + pDy;
                            pathNode2 = pathNode;
                            pathNode2.Dp.x = pathNode2.Dp.x + pDx;
                            pathNode2 = pathNode;
                            pathNode2.Dp.y = pathNode2.Dp.y + pDy;
                        }
                    }
                }
            }
            this.PosTo.x = this.PosTo.x + pDx;
            this.PosTo.y = this.PosTo.y + pDy;
        }
    }
}