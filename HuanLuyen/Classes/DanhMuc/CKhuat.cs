using AxMapXLib;
using MapXLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace HuanLuyen
{
    [Serializable]
    public class CKhuat
    {
        public int KhuatID;
        public int RadaID;
        public int Stt;
        public List<CKhuatPt> KhuatPts;
        public CKhuat()
        {
            this.KhuatID = 0;
            this.RadaID = 0;
            this.Stt = 0;
            this.KhuatPts = null;
        }
        public override string ToString()
        {
            return this.Stt.ToString();
        }
        public PointF[] GetPoints(AxMap pMap)
        {
            int count = this.KhuatPts.Count;
            checked
            {
                PointF[] array = new PointF[count - 1 + 1];
                int num = -1;
                foreach (CKhuatPt current in KhuatPts)
                {
                    num++;
                    PointF[] array2 = array;
                    PointF[] arg_40_0 = array2;
                    int num2 = num;
                    float x = arg_40_0[num2].X;
                    PointF[] array3 = array;
                    PointF[] arg_58_0 = array3;
                    int num3 = num;
                    float y = arg_58_0[num3].Y;
                    pMap.ConvertCoord(ref x, ref y, ref current.PosX, ref current.PosY, ConversionConstants.miMapToScreen);
                    array3[num3].Y = y;
                    array2[num2].X = x;
                }
                return array;
            }
        }
        public void Draw(AxMap pMap, Graphics g, Color pColor)
        {
            PointF[] points = this.GetPoints(pMap);
            SolidBrush brush = new SolidBrush(pColor);
            g.FillPolygon(brush, points);
        }
        public void DrawSele(AxMap pMap, Graphics g, Color pColor)
        {
            PointF[] points = this.GetPoints(pMap);
            g.DrawPolygon(new Pen(pColor), points);
        }
        public bool HitTest(AxMap pMap, PointF pt)
        {
            PointF[] points = this.GetPoints(pMap);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddPolygon(points);
            return graphicsPath.IsVisible(pt);
        }
        public bool Contains(AxMap pMap, double pPosX, double pPosY)
        {
            PointF point = default(PointF);
            float x = point.X;
            float y = point.Y;
            pMap.ConvertCoord(ref x, ref y, ref pPosX, ref pPosY, ConversionConstants.miMapToScreen);
            point.Y = y;
            point.X = x;
            PointF[] points = this.GetPoints(pMap);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddPolygon(points);
            return graphicsPath.IsVisible(point);
        }
    }
}