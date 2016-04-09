using AxMapXLib;
using DBiGraphicObjs.DBiGraphicObjects;
using MapXLib;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace HuanLuyen
{
    [Serializable]
    public class CMayBay
    {
        public MapPoint Pos;
        public double Speed;
        public float Rotation;
        public bool Visible;
        public enTopStatus Status;
        public DateTime Luc;
        public int m_SymbolID;
        public CNodePattern Pattern;
        public CMayBay(int pSymbolID)
        {
            this.Status = enTopStatus.ChuaBay;
            this.m_SymbolID = pSymbolID;
            this.Pos = new MapPoint(0.0, 0.0);
            this.Rotation = 0f;
            this.Visible = true;
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
        public void Draw(AxMap pMap, Graphics g)
        {
            CNodePattern pattern = CNodePatterns.GetPattern(this.m_SymbolID);
            PointF point = this.GetPoint(pMap);
            this.DrawMyNode(g, point, pattern);
        }
        public void Draw2(AxMap pMap, Graphics g)
        {
            PointF point = this.GetPoint(pMap);
            this.DrawMyNode(g, point, this.Pattern);
        }
        public void Draw(AxMap pMap, Graphics g, CNodePattern pPattern)
        {
            PointF point = this.GetPoint(pMap);
            this.DrawMyNode(g, point, pPattern);
        }
        private void DrawMyNode(Graphics g, PointF pPt, CNodePattern pPattern)
        {
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(pPt.X, pPt.Y);
            g.RotateTransform(this.Rotation);
            pPattern.Pattern.DrawObjects(g, 1f);
            g.EndContainer(container);
        }
        public bool HitTest(AxMap pMap, PointF pt)
        {
            bool result = false;
            CNodePattern pattern = CNodePatterns.GetPattern(this.m_SymbolID);
            PointF point = this.GetPoint(pMap);
            Matrix matrix = new Matrix();
            matrix.Translate(-point.X, -point.Y, MatrixOrder.Append);
            matrix.Rotate(-this.Rotation, MatrixOrder.Append);
            PointF[] array = new PointF[]{pt};
            matrix.TransformPoints(array);
            matrix.Dispose();
            IEnumerator enumerator = pattern.Pattern.GetEnumerator();
            while (enumerator.MoveNext())
            {
                GraphicObject graphicObject = (GraphicObject)enumerator.Current;
                if (graphicObject.HitTest(array[0]))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}