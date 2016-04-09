using AxMapXLib;
using System;
using System.Drawing;
namespace HuanLuyen
{
    [Serializable]
    public class PathNode
    {
        public int Stt;
        public MapPoint D;
        public double Speed;
        public float Roll;
        public TurnValue Turn;
        public double R;
        public MapPoint C;
        public double yp;
        public MapPoint Dp;
        public double hdgCD;
        public double typ;
        public double tspeed;
        public double t2next;
        public enCachVong CachVong;
        public enCachNhap CachNhap;
        public PathNode()
        {
            this.CachVong = enCachVong.DenDiem;
            this.CachNhap = enCachNhap.DiaTieu;
            this.Stt = 0;
            this.D = new MapPoint(0.0, 0.0);
            this.Speed = 0.0;
            this.Roll = 0f;
            this.Turn = TurnValue.None;
            this.R = 0.0;
            this.C = new MapPoint(0.0, 0.0);
            this.yp = 0.0;
            this.Dp = new MapPoint(0.0, 0.0);
            this.hdgCD = 0.0;
            this.typ = 0.0;
            this.tspeed = 0.0;
            this.t2next = 0.0;
        }
        public PathNode(MapPoint pMapPt)
        {
            this.CachVong = enCachVong.DenDiem;
            this.CachNhap = enCachNhap.DiaTieu;
            this.Stt = 0;
            this.D = pMapPt;
            this.Speed = 0.0;
            this.Roll = 0f;
            this.Turn = TurnValue.None;
            this.R = 0.0;
            this.C = pMapPt;
            this.yp = 0.0;
            this.Dp = pMapPt;
            this.hdgCD = 0.0;
            this.typ = 0.0;
            this.tspeed = 0.0;
            this.t2next = 0.0;
        }
        public void DrawNodeLbl(AxMap pMap, Graphics g, Pen pPen, PointF ptC)
        {
            string lblText = string.Concat(new string[]
{
this.Stt.ToString(),
": ",
this.D.h.ToString("#0.##m"),
"; ",
this.Speed.ToString("#0.##km/h"),
"; ",
this.Roll.ToString("#0°"),
"\n\r => ",
this.yp.ToString("#0.##°"),
"; ",
this.typ.ToString("#0s"),
"; ",
this.tspeed.ToString("#0s"),
"; ",
this.t2next.ToString("#0s")
});
            PathNode.DrawNodeLbl(pMap, g, pPen, ptC, lblText);
        }
        public static void DrawNodeLbl(AxMap pMap, Graphics g, Pen pPen, PointF ptC, string LblText)
        {
            Font defaSoHieuFont = modHuanLuyen.defaSoHieuFont;
            Color color = Color.FromArgb(50, pPen.Color);
            Pen pen = new Pen(color, 1f);
            SizeF sizeF = g.MeasureString(LblText, defaSoHieuFont);
            checked
            {
                g.DrawRectangle(pen, ptC.X, ptC.Y, (float)((int)Math.Round((double)sizeF.Width) + 6), (float)((int)Math.Round((double)sizeF.Height) + 6));
            }
            g.DrawString(LblText, defaSoHieuFont, new SolidBrush(pPen.Color), ptC.X + 3f, ptC.Y + 3f);
        }
        public static void DrawNodeLbl2(AxMap pMap, Graphics g, Pen pPen, PointF ptC, string LblText)
        {
            Font defaSoHieuFont = modHuanLuyen.defaSoHieuFont;
            Color color = Color.FromArgb(50, pPen.Color);
            Pen pen = new Pen(color, 1f);
            SizeF sizeF = g.MeasureString(LblText, defaSoHieuFont);
            checked
            {
                Rectangle rect = new Rectangle((int)Math.Round((double)unchecked(ptC.X - (float)checked((int)Math.Round((double)sizeF.Width) + 6))), (int)Math.Round((double)unchecked(ptC.Y - (float)checked((int)Math.Round((double)sizeF.Height) + 6))), (int)Math.Round((double)sizeF.Width) + 6, (int)Math.Round((double)sizeF.Height) + 6);
                g.DrawRectangle(pen, rect);
                g.DrawString(LblText, defaSoHieuFont, new SolidBrush(pPen.Color), (float)(rect.Left + 3), (float)(rect.Top + 3));
            }
        }
    }
}