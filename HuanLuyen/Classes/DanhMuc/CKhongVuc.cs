using AxMapXLib;
using MapXLib;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace HuanLuyen
{
    [Serializable]
    public class CKhongVuc
    {
        public int SB_ID;
        public int Stt;
        public MapPoint Pos;
        public float BanKinh;
        public string Name;
        public struPhuongVi PhuongVi;
        public CKhongVuc()
        {
            this.SB_ID = 0;
            this.Stt = 0;
            this.Pos = new MapPoint(0.0, 0.0);
            this.BanKinh = 0f;
            this.Name = "";
        }
        public CKhongVuc(MapPoint pPos, float pBanKinh, string pName)
        {
            this.SB_ID = 0;
            this.Stt = 0;
            this.Pos = pPos;
            this.BanKinh = pBanKinh;
            this.Name = pName;
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
            MapPoint mapPoint = new MapPoint(this.Pos.x - (double)(this.BanKinh * 10f / (float)num), this.Pos.y);
            float x = result.X;
            float y = result.Y;
            pMap.ConvertCoord(ref x, ref y, ref mapPoint.x, ref mapPoint.y, ConversionConstants.miMapToScreen);
            result.Y = y;
            result.X = x;
            return result;
        }
        public void Draw(AxMap pMap, Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            PointF point = this.GetPoint(pMap);
            PointF endPoint = this.GetEndPoint(pMap);
            Pen pen = new Pen(modHuanLuyen.defaKhongVucColor, (float)modHuanLuyen.defaPVPenW);
            float num = point.X - endPoint.X;
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(point.X, point.Y);
            g.DrawLine(pen, -5, 0, 5, 0);
            g.DrawLine(pen, 0, -5, 0, 5);
            if (this.Name.Length <= 0)
            {
                this.Name = "00";
            }
            Font defaSoHieuFont = modHuanLuyen.defaSoHieuFont;
            SizeF sizeF = g.MeasureString(this.Name, defaSoHieuFont);
            g.DrawString(this.Name, defaSoHieuFont, new SolidBrush(modHuanLuyen.defaKhongVucColor), 2f, 2f);
            System.Drawing.Rectangle r = checked(new System.Drawing.Rectangle((int)Math.Round((double)unchecked(-num)), (int)Math.Round((double)unchecked(-num)), (int)Math.Round((double)unchecked(num * 2f + 1f)), (int)Math.Round((double)unchecked(num * 2f + 1f))));
            RectangleF rect = r;
            g.DrawEllipse(pen, rect);
            g.EndContainer(container);
            pen.Dispose();
        }
    }
}