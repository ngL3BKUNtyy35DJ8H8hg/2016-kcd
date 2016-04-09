using AxMapXLib;
using MapXLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace HuanLuyen
{
    [Serializable]
    public class CRada
    {
        public int RadaID;
        public int LoaiRadaID;
        public string Ten;
        public string SoHieu;
        public double PosX;
        public double PosY;
        public float R;
        public List<CKhuat> Khuats;
        public bool ShowPV;
        public bool visible;
        public CRada()
        {
            this.ShowPV = false;
            this.visible = true;
            this.RadaID = 0;
            this.LoaiRadaID = 0;
            this.Ten = "";
            this.SoHieu = "";
            this.PosX = 0.0;
            this.PosY = 0.0;
            this.R = 50f;
            this.Khuats = new List<CKhuat>();
        }
        public override string ToString()
        {
            return string.Concat(new string[]{this.LoaiRadaID.ToString("0"),": ",this.SoHieu," ",this.Ten});
        }
        public PointF GetPoint(AxMap pMap)
        {
            PointF result = default(PointF);
            float x = result.X;
            float y = result.Y;
            pMap.ConvertCoord(ref x, ref y, ref this.PosX, ref this.PosY, ConversionConstants.miMapToScreen);
            result.Y = y;
            result.X = x;
            return result;
        }
        public PointF GetEndPoint(AxMap pMap)
        {
            PointF result = default(PointF);
            int num = checked((int)Math.Round(pMap.Distance(this.PosX, this.PosY, unchecked(this.PosX + 10.0), this.PosY) / 1000.0));
            MapPoint mapPoint = new MapPoint(this.PosX - (double)(this.R * 10f / (float)num), this.PosY);
            float x = result.X;
            float y = result.Y;
            pMap.ConvertCoord(ref x, ref y, ref mapPoint.x, ref mapPoint.y, ConversionConstants.miMapToScreen);
            result.Y = y;
            result.X = x;
            return result;
        }
        public bool TrongVung(AxMap pMap, double pPosX, double pPosY)
        {
            bool result;
            if (this.LoaiRadaID == 1)
            {
                result = true;
            }
            else
            {
                double num = pMap.Distance(this.PosX, this.PosY, pPosX, pPosY);
                result = (num <= (double)(this.R * 1000f));
            }
            return result;
        }
        public void Draw(AxMap pMap, Graphics g, Pen pPen)
        {
            if (this.LoaiRadaID != 1)
            {
                this.DrawPV(pMap, g);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                PointF point = this.GetPoint(pMap);
                PointF endPoint = this.GetEndPoint(pMap);
                float num = point.X - endPoint.X;
                GraphicsContainer container = g.BeginContainer();
                g.TranslateTransform(point.X, point.Y);
                g.DrawLine(pPen, -5, 0, 5, 0);
                g.DrawLine(pPen, 0, -5, 0, 5);
                if (this.SoHieu.Length <= 0)
                {
                    this.SoHieu = "00";
                }
                string s = "";
                if (this.LoaiRadaID == 2)
                {
                    s = this.SoHieu;
                }
                Font defaSoHieuFont = modHuanLuyen.defaSoHieuFont;
                SizeF sizeF = g.MeasureString(this.SoHieu, defaSoHieuFont);
                g.DrawString(s, defaSoHieuFont, new SolidBrush(pPen.Color), 2f, 2f);
                System.Drawing.Rectangle r = checked(new System.Drawing.Rectangle((int)Math.Round((double)unchecked(-num)), (int)Math.Round((double)unchecked(-num)), (int)Math.Round((double)unchecked(num * 2f + 1f)), (int)Math.Round((double)unchecked(num * 2f + 1f))));
                RectangleF rect = r;
                g.DrawEllipse(pPen, rect);
                g.EndContainer(container);
            }
        }
        private void DrawPV(AxMap pMap, Graphics g)
        {
            if (this.ShowPV)
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                PointF point = this.GetPoint(pMap);
                PointF endPoint = this.GetEndPoint(pMap);
                Pen pen = new Pen(modHuanLuyen.defaPVPenC, (float)modHuanLuyen.defaPVPenW);
                switch (this.LoaiRadaID)
                {
                    case 2:
                        pen.Color = modHuanLuyen.defaRadaHLPenC;
                        break;
                    case 3:
                        pen.Color = modHuanLuyen.defaRadaDDPenC;
                        break;
                }
                float num = (point.X - endPoint.X) / (float)modHuanLuyen.defaPVRadius;
                GraphicsContainer container = g.BeginContainer();
                g.TranslateTransform(point.X, point.Y);
                int arg_A9_0 = modHuanLuyen.defaPVVongStep;
                int defaPVRadius = modHuanLuyen.defaPVRadius;
                int defaPVVongStep = modHuanLuyen.defaPVVongStep;
                int num2 = arg_A9_0;
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
                    int arg_16C_0 = 0;
                    int defaPVTiaStep = modHuanLuyen.defaPVTiaStep;
                    int num4 = arg_16C_0;
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
        public bool HitTest(AxMap pMap, PointF pt)
        {
            GraphicsPath gPath = this.GetGPath(pMap);
            Pen pen = new Pen(Color.Black, 4f);
            return gPath.IsOutlineVisible(pt, pen);
        }
        private GraphicsPath GetGPath(AxMap pMap)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            Matrix matrix = new Matrix();
            PointF point = this.GetPoint(pMap);
            PointF endPoint = this.GetEndPoint(pMap);
            float num = point.X - endPoint.X;
            matrix.Translate(point.X, point.Y);
            graphicsPath.AddLine(-5, 0, 5, 0);
            graphicsPath.AddLine(0, -5, 0, 5);
            System.Drawing.Rectangle r = checked(new System.Drawing.Rectangle((int)Math.Round((double)unchecked(-num)), (int)Math.Round((double)unchecked(-num)), (int)Math.Round((double)unchecked(num * 2f + 1f)), (int)Math.Round((double)unchecked(num * 2f + 1f))));
            RectangleF rect = r;
            graphicsPath.AddEllipse(rect);
            graphicsPath.Transform(matrix);
            return graphicsPath;
        }
    }
}