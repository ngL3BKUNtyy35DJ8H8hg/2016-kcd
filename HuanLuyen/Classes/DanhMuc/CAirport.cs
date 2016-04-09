using AxMapXLib;
using DBiGraphicObjs.DBiGraphicObjects;
using MapXLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace HuanLuyen
{
    [Serializable]
    public class CAirport
    {
        public int SB_ID;
        public string MaSB;
        public string Name;
        public int SymbolID;
        public CNodePattern Pattern;
        public MapPoint Pos;
        public float Rotation;
        public float Scale;
        public int LblDeltaX;
        public int LblDeltaY;
        public string LblText;
        public bool ShowPV;
        public List<CKhongVuc> KhongVucs;
        public override string ToString()
        {
            string result = this.Name;
            if (this.MaSB.Length > 0)
            {
                result = this.Name + " (" + this.MaSB + ")";
            }
            return result;
        }
        public CAirport()
        {
            this.SB_ID = 0;
            this.MaSB = "";
            this.Name = "";
            this.SymbolID = 0;
            this.Rotation = 0f;
            this.Scale = 1f;
            this.LblDeltaX = 0;
            this.LblDeltaY = 0;
            this.LblText = "";
            this.ShowPV = false;
            this.KhongVucs = new List<CKhongVuc>();
        }
        public CAirport(MapPoint pMapPt)
            : this()
        {
            this.Pos = pMapPt;
        }
        public CAirport(MapPoint pMapPt, string pName)
            : this()
        {
            this.Pos = pMapPt;
            this.Name = pName;
        }
        public CAirport(int pSB_ID, string pMaSB, string pName, int pSymbolID, MapPoint pMapPt, float pRotation, float pScale, string pLabel, int pLblDeltaX, int pLblDeltaY)
            : this()
        {
            this.SB_ID = pSB_ID;
            this.Name = pName;
            this.MaSB = pMaSB;
            this.SymbolID = pSymbolID;
            this.Pos = pMapPt;
            this.Rotation = pRotation;
            this.Scale = pScale;
            this.LblText = pLabel;
            this.LblDeltaX = pLblDeltaX;
            this.LblDeltaY = pLblDeltaY;
        }
        private PointF GetPoint(AxMap pMap)
        {
            PointF result = default(PointF);
            float x = result.X;
            float y = result.Y;
            pMap.ConvertCoord(ref x, ref y, ref this.Pos.x, ref this.Pos.y, ConversionConstants.miMapToScreen);
            result.Y = y;
            result.X = x;
            return result;
        }
        private PointF GetEndPoint(AxMap pMap)
        {
            PointF result = default(PointF);
            int num = checked((int)Math.Round(pMap.Distance(this.Pos.x, this.Pos.y, unchecked(this.Pos.x + 10.0), this.Pos.y) / 1000.0));
            MapPoint mapPoint = new MapPoint(this.Pos.x - (double)checked(modHuanLuyen.defaPVRadius * 10) / (double)num, this.Pos.y);
            float x = result.X;
            float y = result.Y;
            pMap.ConvertCoord(ref x, ref y, ref mapPoint.x, ref mapPoint.y, ConversionConstants.miMapToScreen);
            result.Y = y;
            result.X = x;
            return result;
        }
        private void DrawPV(AxMap pMap, Graphics g)
        {
            if (this.ShowPV)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                PointF point = this.GetPoint(pMap);
                PointF endPoint = this.GetEndPoint(pMap);
                Pen pen = new Pen(modHuanLuyen.defaPVPenC, (float)modHuanLuyen.defaPVPenW);
                float num = (point.X - endPoint.X) / (float)modHuanLuyen.defaPVRadius;
                GraphicsContainer container = g.BeginContainer();
                g.TranslateTransform(point.X, point.Y);
                int arg_7A_0 = modHuanLuyen.defaPVVongStep;
                int defaPVRadius = modHuanLuyen.defaPVRadius;
                int defaPVVongStep = modHuanLuyen.defaPVVongStep;
                int num2 = arg_7A_0;
                checked
                {
                    while ((defaPVVongStep >> 31 ^ num2) <= (defaPVVongStep >> 31 ^ defaPVRadius))
                    {
                        if (num2 % (modHuanLuyen.defaPVVongDam * modHuanLuyen.defaPVVongStep) == 0)
                        {
                            pen.Width = (float)(modHuanLuyen.defaPVPenW * 2);
                        }
                        else
                        {
                            pen.Width = (float)modHuanLuyen.defaPVPenW;
                        }
                        float num3 = unchecked(num * (float)num2);
                        System.Drawing.Rectangle rect = new System.Drawing.Rectangle((int)Math.Round((double)unchecked(-num3)), (int)Math.Round((double)unchecked(-num3)), (int)Math.Round((double)unchecked(num3 * 2f + 1f)), (int)Math.Round((double)unchecked(num3 * 2f + 1f)));
                        g.DrawEllipse(pen, rect);
                        num2 += defaPVVongStep;
                    }
                    g.EndContainer(container);
                    PointF[] endPts = this.GetEndPts(point, endPoint);
                    int arg_13D_0 = 0;
                    int defaPVTiaStep = modHuanLuyen.defaPVTiaStep;
                    int num4 = arg_13D_0;
                    while ((defaPVTiaStep >> 31 ^ num4) <= (defaPVTiaStep >> 31 ^ 359))
                    {
                        if (num4 % (modHuanLuyen.defaPVTiaDam * modHuanLuyen.defaPVTiaStep) == 0)
                        {
                            pen.Width = (float)(modHuanLuyen.defaPVPenW * 2);
                        }
                        else
                        {
                            pen.Width = (float)modHuanLuyen.defaPVPenW;
                        }
                        g.DrawLine(pen, point, endPts[num4]);
                        num4 += defaPVTiaStep;
                    }
                    pen.Dispose();
                }
            }
        }
        private PointF[] GetEndPts(PointF mPt, PointF mPt2)
        {
            PointF[] array = new PointF[2];
            array[0].X = mPt.X;
            array[0].Y = mPt.Y;
            PointF[] array2 = new PointF[360];
            int num = 0;
            checked
            {
                do
                {
                    array[1].X = mPt2.X;
                    array[1].Y = mPt2.Y;
                    Matrix matrix = new Matrix();
                    matrix.RotateAt((float)(num + 90), mPt, MatrixOrder.Prepend);
                    matrix.TransformPoints(array);
                    array2[num] = array[1];
                    num++;
                }
                while (num <= 359);
                return array2;
            }
        }
        public void Draw(AxMap pMap, Graphics g)
        {
            this.DrawKhongVuc(pMap, g);
            this.DrawName(pMap, g);
            this.DrawPV(pMap, g);
            CNodePattern pattern = CNodePatterns.GetPattern(this.SymbolID);
            PointF point = this.GetPoint(pMap);
            this.DrawMyNode(g, point, pattern);
        }
        public void Draw2(AxMap pMap, Graphics g)
        {
            this.DrawKhongVuc(pMap, g);
            this.DrawName(pMap, g);
            this.DrawPV(pMap, g);
            PointF point = this.GetPoint(pMap);
            this.DrawMyNode(g, point, this.Pattern);
        }
        public void Draw(AxMap pMap, Graphics g, CNodePattern pPattern)
        {
            this.DrawKhongVuc(pMap, g);
            this.DrawName(pMap, g);
            this.DrawPV(pMap, g);
            PointF point = this.GetPoint(pMap);
            this.DrawMyNode(g, point, pPattern);
        }
        private void DrawMyNode(Graphics g, PointF pPt, CNodePattern pPattern)
        {
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(pPt.X, pPt.Y);
            g.RotateTransform(this.Rotation);
            g.ScaleTransform(this.Scale, this.Scale);
            pPattern.Pattern.DrawObjects(g, 1f);
            g.EndContainer(container);
        }
        public bool HitTest(AxMap pMap, PointF pt)
        {
            bool result = false;
            CNodePattern pattern = CNodePatterns.GetPattern(this.SymbolID);
            PointF point = this.GetPoint(pMap);
            Matrix matrix = new Matrix();
            matrix.Translate(-point.X, -point.Y, MatrixOrder.Append);
            matrix.Rotate(-this.Rotation, MatrixOrder.Append);
            matrix.Scale(1f / this.Scale, 1f / this.Scale, MatrixOrder.Append);
            PointF[] array = new PointF[]
{
pt
};
            matrix.TransformPoints(array);
            matrix.Dispose();
            foreach (GraphicObject graphicObject in pattern.Pattern)
            {
                if (graphicObject.HitTest(array[0]))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        private void DrawName(AxMap pMap, Graphics g)
        {
            if (this.LblText.Length > 0)
            {
                PointF point = this.GetPoint(pMap);
                Font defaSoHieuFont = modHuanLuyen.defaSoHieuFont;
                Pen pen = new Pen(Color.Black, 1f);
                SizeF sizeF = g.MeasureString(this.LblText, defaSoHieuFont);
                g.DrawRectangle(pen, point.X + (float)this.LblDeltaX, point.Y + (float)this.LblDeltaY, (float)checked((int)Math.Round((double)sizeF.Width) + 6), (float)checked((int)Math.Round((double)sizeF.Height) + 6));
                g.DrawString(this.LblText, defaSoHieuFont, new SolidBrush(modHuanLuyen.defaSoHieuC), point.X + (float)this.LblDeltaX + 3f, point.Y + (float)this.LblDeltaY + 3f);
                float[] array = new float[4];
                float[] array2 = new float[4];
                float x = point.X;
                float y = point.Y;
                float num = point.X + (float)this.LblDeltaX;
                float num2 = point.Y + (float)this.LblDeltaY;
                float num3 = point.X + (float)this.LblDeltaX + (float)checked((int)Math.Round((double)sizeF.Width)) + 6f;
                float num4 = point.Y + (float)this.LblDeltaY;
                float num5 = point.X + (float)this.LblDeltaX + (float)checked((int)Math.Round((double)sizeF.Width)) + 6f;
                float num6 = point.Y + (float)this.LblDeltaY + (float)checked((int)Math.Round((double)sizeF.Height)) + 6f;
                float num7 = point.X + (float)this.LblDeltaX;
                float num8 = point.Y + (float)this.LblDeltaY + (float)checked((int)Math.Round((double)sizeF.Height)) + 6f;
                if (x >= num & x <= num3)
                {
                    if (Math.Abs(num2 - y) <= Math.Abs(num8 - y))
                    {
                        array2[0] = num2;
                    }
                    else
                    {
                        array2[0] = num8;
                    }
                    g.DrawLine(pen, point.X, point.Y, point.X, array2[0]);
                }
                else if (y > num2 & y < num8)
                {
                    if (Math.Abs(num - x) <= Math.Abs(num3 - x))
                    {
                        array[0] = num;
                    }
                    else
                    {
                        array[0] = num3;
                    }
                    g.DrawLine(pen, point.X, point.Y, array[0], point.Y);
                }
                else
                {
                    array[0] = (num + num3) / 2f;
                    array2[0] = num2;
                    array[1] = num3;
                    array2[1] = (num4 + num6) / 2f;
                    array[2] = (num5 + num7) / 2f;
                    array2[2] = num6;
                    array[3] = num7;
                    array2[3] = (num8 + num2) / 2f;
                    double num9 = (double)((array[0] - x) * (array[0] - x) + (array2[0] - y) * (array2[0] - y));
                    int num10 = 0;
                    int num11 = 0;
                    do
                    {
                        double num12 = (double)((array[num11] - x) * (array[num11] - x) + (array2[num11] - y) * (array2[num11] - y));
                        if (num12 < num9)
                        {
                            num9 = num12;
                            num10 = num11;
                        }
                        checked
                        {
                            num11++;
                        }
                    }
                    while (num11 <= 3);
                    g.DrawLine(pen, point.X, point.Y, array[num10], array2[num10]);
                }
                pen.Dispose();
            }
        }
        public void DanhDau(AxMap pMap, Graphics g, Pen pPen)
        {
            PointF point = this.GetPoint(pMap);
            g.DrawLine(pPen, point.X - 7f, point.Y - 7f, point.X + 7f, point.Y + 7f);
            g.DrawLine(pPen, point.X - 7f, point.Y + 7f, point.X + 7f, point.Y - 7f);
        }
        public void DrawNode(AxMap pMap, Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1f);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, Color.White));
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, 7, 7);
            Matrix transform = g.Transform;
            GraphicsContainer container = g.BeginContainer();
            checked
            {
                try
                {
                    PointF point = this.GetPoint(pMap);
                    rect.X = (int)Math.Round((double)unchecked(point.X - 3f));
                    rect.Y = (int)Math.Round((double)unchecked(point.Y - 3f));
                    g.FillEllipse(solidBrush, rect);
                    g.DrawEllipse(pen, rect);
                }
                catch (Exception arg_93_0)
                {
                    throw arg_93_0;
                }
                finally
                {
                    pen.Dispose();
                    solidBrush.Dispose();
                }
                g.EndContainer(container);
                g.Transform = transform;
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
                PointF point = this.GetPoint(pMap);
                point.X += (float)this.LblDeltaX;
                point.Y += (float)this.LblDeltaY;
                checked
                {
                    rect.X = (int)Math.Round((double)unchecked(point.X - 3f));
                    rect.Y = (int)Math.Round((double)unchecked(point.Y - 3f));
                    g.FillEllipse(solidBrush, rect);
                    g.DrawEllipse(pen, rect);
                }
            }
            catch (Exception arg_BF_0)
            {
                throw arg_BF_0;
            }
            finally
            {
                pen.Dispose();
                solidBrush.Dispose();
            }
            g.EndContainer(container);
            g.Transform = transform;
        }
        public void DrawKhongVuc(AxMap pMap, Graphics g)
        {
            foreach (CKhongVuc current in this.KhongVucs)
            {
                current.Draw(pMap, g);
            }

        }
        public bool FindNodeAtPoint(AxMap pMap, PointF pt)
        {
            PointF point = this.GetPoint(pMap);
            RectangleF rectangleF = new RectangleF(point.X - 3f, point.Y - 3f, 7f, 7f);
            return rectangleF.Contains(pt);
        }
        public bool FindNameNodeAtPoint(AxMap pMap, PointF pt)
        {
            PointF point = this.GetPoint(pMap);
            point.X += (float)this.LblDeltaX;
            point.Y += (float)this.LblDeltaY;
            RectangleF rectangleF = new RectangleF(point.X - 3f, point.Y - 3f, 7f, 7f);
            return rectangleF.Contains(pt);
        }
        public void MoveTo(double pLon, double pLat)
        {
            this.Pos.x = pLon;
            this.Pos.y = pLat;
        }
        public void MoveNodeTo(AxMap pMap, PointF pt)
        {
            float x = pt.X;
            float y = pt.Y;
            pMap.ConvertCoord(ref x, ref y, ref this.Pos.x, ref this.Pos.y, ConversionConstants.miScreenToMap);
            pt.Y = y;
            pt.X = x;
        }
        public void MoveNameNodeTo(AxMap pMap, PointF pt)
        {
            PointF pointF = default(PointF);
            float x = pointF.X;
            float y = pointF.Y;
            pMap.ConvertCoord(ref x, ref y, ref this.Pos.x, ref this.Pos.y, ConversionConstants.miMapToScreen);
            pointF.Y = y;
            pointF.X = x;
            checked
            {
                this.LblDeltaX = (int)Math.Round((double)unchecked(pt.X - pointF.X));
                this.LblDeltaY = (int)Math.Round((double)unchecked(pt.Y - pointF.Y));
            }
        }
    }
}