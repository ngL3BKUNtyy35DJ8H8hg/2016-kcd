using AxMapXLib;
using MapXLib;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace HuanLuyen
{
    [Serializable]
    public class CTieuDo55
    {
        private double YMin;
        private double YMax;
        private double XMin;
        private double XMax;
        private string[,] ShOChinh;
        private string[,] ShOLon;
        private string[,] ShONho;
        private string[,] ShOTuongTuong;
        private string ShOTuongTuongGiua;
        public CTieuDoIndex getAddress(double pPosX, double pPosY)
        {
            CTieuDoIndex cTieuDoIndex = new CTieuDoIndex();
            CTieuDoIndex cTieuDoIndex2 = cTieuDoIndex;
            checked
            {
                cTieuDoIndex2.i1 = (int)Math.Round(Math.Floor(unchecked(this.YMax - pPosY) / 1.8181818181818179));
                cTieuDoIndex2.j1 = (int)Math.Round(Math.Floor(unchecked(pPosX - this.XMin) / 1.8181818181818179));
                cTieuDoIndex2.i2 = (int)Math.Round(unchecked(Math.Floor((this.YMax - pPosY) / 0.1818181818181818) - (double)checked(cTieuDoIndex2.i1 * 10)));
                cTieuDoIndex2.j2 = (int)Math.Round(unchecked(Math.Floor((pPosX - this.XMin) / 0.1818181818181818) - (double)checked(cTieuDoIndex2.j1 * 10)));
            }
            double num = this.YMax - 0.1818181818181818 * (double)checked(cTieuDoIndex2.i1 * 10 + cTieuDoIndex2.i2);
            double num2 = this.XMin + 0.1818181818181818 * (double)checked(cTieuDoIndex2.j1 * 10 + cTieuDoIndex2.j2);
            checked
            {
                cTieuDoIndex2.i3 = (int)Math.Round(Math.Floor(unchecked(num - pPosY) / 0.0363636363636364));
                cTieuDoIndex2.j3 = (int)Math.Round(Math.Floor(unchecked(pPosX - num2) / 0.0363636363636364));
            }
            num = this.YMax - 0.1818181818181818 * (double)checked(cTieuDoIndex2.i1 * 10 + cTieuDoIndex2.i2) - 0.0363636363636364 * (double)cTieuDoIndex2.i3;
            num2 = this.XMin + 0.1818181818181818 * (double)checked(cTieuDoIndex2.j1 * 10 + cTieuDoIndex2.j2) + 0.0363636363636364 * (double)cTieuDoIndex2.j3;
            checked
            {
                cTieuDoIndex2.i4 = (int)Math.Round(Math.Floor(unchecked(num - pPosY) / 0.0181818181818182));
                cTieuDoIndex2.j4 = (int)Math.Round(Math.Floor(unchecked(pPosX - num2) / 0.0181818181818182));
                return cTieuDoIndex;
            }
        }
        public string getToaDo(AxMap pMap, double pPosX, double pPosY)
        {
            string result = "";
            CTieuDoIndex address = this.getAddress(pPosX, pPosY);
            CTieuDoIndex cTieuDoIndex = address;
            if (cTieuDoIndex.i1 >= 0 & cTieuDoIndex.i1 <= 2 & (cTieuDoIndex.j1 >= 0 & cTieuDoIndex.j1 <= 2))
            {
                result = this.ShOChinh[cTieuDoIndex.i1, cTieuDoIndex.j1] + this.ShOLon[cTieuDoIndex.i2, cTieuDoIndex.j2] + this.ShONho[cTieuDoIndex.i3, cTieuDoIndex.j3] + this.getToaDoOTT(pPosX, pPosY, address, pMap);
            }
            return result;
        }
        private string getToaDoOTT(double pPosX, double pPosY, CTieuDoIndex pTdIndex, AxMap pMap)
        {
            string result;
            if (this.IsInCenter(pPosX, pPosY, pTdIndex, pMap))
            {
                result = "5";
            }
            else
            {
                result = this.ShOTuongTuong[pTdIndex.i4, pTdIndex.j4];
            }
            return result;
        }
        private bool IsInCenter(double pPosX, double pPosY, CTieuDoIndex pTdIndex, AxMap pMap)
        {
            bool result = false;
            double y = this.YMax - 0.1818181818181818 * (double)checked(pTdIndex.i1 * 10 + pTdIndex.i2) - 0.0363636363636364 * (double)pTdIndex.i3 - 0.0181818181818182;
            double x = this.XMin + 0.1818181818181818 * (double)checked(pTdIndex.j1 * 10 + pTdIndex.j2) + 0.0363636363636364 * (double)pTdIndex.j3 + 0.0181818181818182;
            double num = pMap.Distance(x, y, pPosX, pPosY);
            if (num < 1200.0)
            {
                result = true;
            }
            return result;
        }
        public void Populate()
        {
            this.PopulateOLon();
            this.PopulateONho();
            this.PopulateOTuongTuong();
        }
        public void PopulateOPhu(string pFile)
        {
            bool flag = false;
            if (pFile.Length > 0 && File.Exists(pFile))
            {
                flag = this.LoadOPhu(pFile);
            }
            if (!flag)
            {
                this.PopulateOChinh();
            }
        }
        private bool LoadOPhu(string Path)
        {
            bool result = false;
            checked
            {
                try
                {
                    if (File.Exists(Path))
                    {
                        StreamReader streamReader = new StreamReader(Path);
                        int num = -1;
                        while (streamReader.Peek() >= 0)
                        {
                            string text = streamReader.ReadLine();
                            string[] array = text.Split(new char[]{','});
                            if (array.GetUpperBound(0) == 2 && (array[0].Length >= 1 & array[1].Length >= 1 & array[2].Length >= 1))
                            {
                                num++;
                                this.ShOChinh[num, 0] = array[0].ToString();
                                this.ShOChinh[num, 1] = array[1].ToString();
                                this.ShOChinh[num, 2] = array[2].ToString();
                            }
                        }
                        streamReader.Close();
                        if (num == 2)
                        {
                            this.ShOChinh[1, 1] = "";
                            result = true;
                        }
                    }
                    else
                    {
                        //Interaction.MsgBox("Khong thay '" + Path + "' khong load duoc.", MsgBoxStyle.OkOnly, null);
                    }
                }
                catch (Exception expr_11E)
                {
                    throw expr_11E;
                }
                return result;
            }
        }
        private void PopulateOChinh()
        {
            this.ShOChinh[0, 0] = "4";
            this.ShOChinh[0, 1] = "5";
            this.ShOChinh[0, 2] = "6";
            this.ShOChinh[1, 0] = "3";
            this.ShOChinh[1, 1] = "";
            this.ShOChinh[1, 2] = "7";
            this.ShOChinh[2, 0] = "2";
            this.ShOChinh[2, 1] = "1";
            this.ShOChinh[2, 2] = "8";
        }
        private void PopulateOLon()
        {
            int num = 0;
            checked
            {
                do
                {
                    int num2 = 0;
                    do
                    {
                        this.ShOLon[num, num2] = num.ToString() + num2.ToString();
                        num2++;
                    }
                    while (num2 <= 9);
                    num++;
                }
                while (num <= 9);
            }
        }
        private void PopulateONho()
        {
            int num = 0;
            checked
            {
                do
                {
                    int num2 = 0;
                    do
                    {
                        this.ShONho[num, num2] = (num + 1).ToString() + (num2 + 1).ToString();
                        num2++;
                    }
                    while (num2 <= 4);
                    num++;
                }
                while (num <= 4);
            }
        }
        private void PopulateOTuongTuong()
        {
            this.ShOTuongTuongGiua = "5";
            this.ShOTuongTuong[0, 0] = "1";
            this.ShOTuongTuong[0, 1] = "2";
            this.ShOTuongTuong[1, 0] = "4";
            this.ShOTuongTuong[1, 1] = "3";
        }
        public CTieuDo55(double pCX, double pCY)
        {
            this.YMin = 5.0;
            this.YMax = 30.0;
            this.XMin = 97.0;
            this.XMax = 117.0;
            this.ShOChinh = new string[3, 3];
            this.ShOLon = new string[10, 10];
            this.ShONho = new string[5, 5];
            this.ShOTuongTuong = new string[2, 2];
            this.YMin = pCY - 2.7272727272727271;
            this.YMax = pCY + 2.7272727272727271;
            this.XMin = pCX - 2.7272727272727271;
            this.XMax = pCX + 2.7272727272727271;
        }
        public void draw(AxMap pMap, Graphics g)
        {
            Pen pen = new Pen(Color.LightGray);
            Pen pen2 = new Pen(Color.Black);
            Pen pen3 = new Pen(Color.Black, 2f);
            this.drawHlines(pMap, g, pen3, pen2, pen);
            this.drawVlines(pMap, g, pen3, pen2, pen);
            this.drawToaDo(pMap, g);
            pen3.Dispose();
            pen2.Dispose();
            pen.Dispose();
        }
        private void drawToaDo(AxMap pMap, Graphics g)
        {
            Font font = new Font("Arial", 14f, FontStyle.Bold, GraphicsUnit.Point);
            Font font2 = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Point);
            SolidBrush brush = new SolidBrush(Color.White);
            PointF pointF = default(PointF);
            int num = 0;
            checked
            {
                do
                {
                    int num2 = 0;
                    do
                    {
                        float num3 = pointF.X;
                        float num4 = pointF.Y;
                        unchecked
                        {
                            double num5 = this.XMin + 1.8181818181818179 * (double)num2 + 0.909090909090909;
                            double num6 = this.YMax - 1.8181818181818179 * (double)num - 0.909090909090909;
                            pMap.ConvertCoord(ref num3, ref num4, ref num5, ref num6, ConversionConstants.miMapToScreen);
                            pointF.Y = num4;
                            pointF.X = num3;
                            string text = this.ShOChinh[num, num2];
                            if (text.Length > 0)
                            {
                                SizeF sizeF = g.MeasureString(text, font);
                                g.DrawString(text, font, brush, pointF.X - sizeF.Width / 2f, pointF.Y - sizeF.Height / 2f);
                            }
                            int num7 = 0;
                            do
                            {
                                num4 = pointF.X;
                                num3 = pointF.Y;
                                num6 = this.XMin + 1.8181818181818179 * (double)num2 + 0.1818181818181818 * (double)num7;
                                num5 = this.YMax - 1.8181818181818179 * (double)num - 1.8181818181818179;
                                pMap.ConvertCoord(ref num4, ref num3, ref num6, ref num5, ConversionConstants.miMapToScreen);
                                pointF.Y = num3;
                                pointF.X = num4;
                                text = num7.ToString();
                                SizeF sizeF = g.MeasureString(text, font2);
                                g.DrawString(text, font2, brush, pointF.X, pointF.Y - sizeF.Height);
                                checked
                                {
                                    num7++;
                                }
                            }
                            while (num7 <= 9);
                            if (num2 > 0)
                            {
                                int num8 = 0;
                                do
                                {
                                    num4 = pointF.X;
                                    num3 = pointF.Y;
                                    num6 = this.XMin + 1.8181818181818179 * (double)num2;
                                    num5 = this.YMax - 1.8181818181818179 * (double)num - 0.1818181818181818 * (double)num8;
                                    pMap.ConvertCoord(ref num4, ref num3, ref num6, ref num5, ConversionConstants.miMapToScreen);
                                    pointF.Y = num3;
                                    pointF.X = num4;
                                    text = num8.ToString();
                                    SizeF sizeF = g.MeasureString(text, font2);
                                    g.DrawString(text, font2, brush, pointF.X - sizeF.Width, pointF.Y);
                                    num4 = pointF.X;
                                    num3 = pointF.Y;
                                    num6 = this.XMin + 1.8181818181818179 * (double)num2;
                                    num5 = this.YMax - 1.8181818181818179 * (double)num - 0.1818181818181818 * (double)num8;
                                    pMap.ConvertCoord(ref num4, ref num3, ref num6, ref num5, ConversionConstants.miMapToScreen);
                                    pointF.Y = num3;
                                    pointF.X = num4;
                                    text = num8.ToString();
                                    sizeF = g.MeasureString(text, font2);
                                    g.DrawString(text, font2, brush, pointF.X, pointF.Y);
                                    checked
                                    {
                                        num8++;
                                    }
                                }
                                while (num8 <= 9);
                            }
                        }
                        num2++;
                    }
                    while (num2 <= 2);
                    num++;
                }
                while (num <= 2);
            }
        }
        private void drawHlines(AxMap pMap, Graphics g, Pen mPen1, Pen mPen2, Pen mPen3)
        {
            PointF pt = default(PointF);
            PointF pt2 = default(PointF);
            float num = pt.X;
            float num2 = pt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.XMin, ref this.YMin, ConversionConstants.miMapToScreen);
            pt.Y = num2;
            pt.X = num;
            num2 = pt2.X;
            num = pt2.Y;
            pMap.ConvertCoord(ref num2, ref num, ref this.XMax, ref this.YMin, ConversionConstants.miMapToScreen);
            pt2.Y = num;
            pt2.X = num2;
            g.DrawLine(mPen1, pt, pt2);
            int num3 = 1;
            do
            {
                num2 = pt.X;
                num = pt.Y;
                double num4 = this.YMin + 0.1818181818181818 * (double)checked(num3 - 1) + 0.0363636363636364;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMin, ref num4, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.YMin + 0.1818181818181818 * (double)checked(num3 - 1) + 0.0363636363636364;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMax, ref num4, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.YMin + 0.1818181818181818 * (double)checked(num3 - 1) + 0.0727272727272728;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMin, ref num4, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.YMin + 0.1818181818181818 * (double)checked(num3 - 1) + 0.0727272727272728;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMax, ref num4, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.YMin + 0.1818181818181818 * (double)num3 - 0.0727272727272728;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMin, ref num4, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.YMin + 0.1818181818181818 * (double)num3 - 0.0727272727272728;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMax, ref num4, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.YMin + 0.1818181818181818 * (double)num3 - 0.0363636363636364;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMin, ref num4, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.YMin + 0.1818181818181818 * (double)num3 - 0.0363636363636364;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMax, ref num4, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.YMin + 0.1818181818181818 * (double)num3;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMin, ref num4, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.YMin + 0.1818181818181818 * (double)num3;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMax, ref num4, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                if (num3 % 10 == 0)
                {
                    g.DrawLine(mPen1, pt, pt2);
                }
                else
                {
                    g.DrawLine(mPen2, pt, pt2);
                }
                checked
                {
                    num3++;
                }
            }
            while (num3 <= 30);
        }
        private void drawVlines(AxMap pMap, Graphics g, Pen mPen1, Pen mPen2, Pen mPen3)
        {
            PointF pt = default(PointF);
            PointF pt2 = default(PointF);
            float num = pt.X;
            float num2 = pt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.XMin, ref this.YMax, ConversionConstants.miMapToScreen);
            pt.Y = num2;
            pt.X = num;
            num2 = pt2.X;
            num = pt2.Y;
            pMap.ConvertCoord(ref num2, ref num, ref this.XMin, ref this.YMin, ConversionConstants.miMapToScreen);
            pt2.Y = num;
            pt2.X = num2;
            g.DrawLine(mPen1, pt, pt2);
            int num3 = 1;
            do
            {
                num2 = pt.X;
                num = pt.Y;
                double num4 = this.XMin + 0.1818181818181818 * (double)checked(num3 - 1) + 0.0363636363636364;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMax, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.XMin + 0.1818181818181818 * (double)checked(num3 - 1) + 0.0363636363636364;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMin, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.XMin + 0.1818181818181818 * (double)checked(num3 - 1) + 0.0727272727272728;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMax, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.XMin + 0.1818181818181818 * (double)checked(num3 - 1) + 0.0727272727272728;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMin, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.XMin + 0.1818181818181818 * (double)num3 - 0.0727272727272728;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMax, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.XMin + 0.1818181818181818 * (double)num3 - 0.0727272727272728;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMin, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.XMin + 0.1818181818181818 * (double)num3 - 0.0363636363636364;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMax, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.XMin + 0.1818181818181818 * (double)num3 - 0.0363636363636364;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMin, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.XMin + 0.1818181818181818 * (double)num3;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMax, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.XMin + 0.1818181818181818 * (double)num3;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMin, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                if (num3 % 10 == 0)
                {
                    g.DrawLine(mPen1, pt, pt2);
                }
                else
                {
                    g.DrawLine(mPen2, pt, pt2);
                }
                checked
                {
                    num3++;
                }
            }
            while (num3 <= 30);
        }
    }
}