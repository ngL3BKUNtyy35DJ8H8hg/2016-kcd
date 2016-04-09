using AxMapXLib;
using MapXLib;
using System;
using System.Drawing;
using System.IO;
namespace HuanLuyen
{
    [Serializable]
    public class CTieuDo99
    {
        private double YMin;
        private double YMax;
        private double XMin;
        private double XMax;
        private string[,] ShOLon;
        private string[,] ShOCoBan;
        private string[,] ShOVua;
        private string[,] ShOTuongTuong;
        public CTieuDo99()
        {
            this.YMin = 5.0;
            this.YMax = 30.0;
            this.XMin = 97.0;
            this.XMax = 117.0;
            this.ShOLon = new string[5, 2];
            this.ShOCoBan = new string[10, 10];
            this.ShOVua = new string[3, 3];
            this.ShOTuongTuong = new string[3, 3];
        }
        public string getToaDo(double pPosX, double pPosY)
        {
            string result = "";
            CTieuDoIndex address = this.getAddress(pPosX, pPosY);
            CTieuDoIndex cTieuDoIndex = address;
            if (cTieuDoIndex.i1 >= 0 & cTieuDoIndex.i1 <= 4 & (cTieuDoIndex.j1 >= 0 & cTieuDoIndex.j1 <= 1))
            {
                result = string.Concat(new string[]{this.ShOLon[cTieuDoIndex.i1, cTieuDoIndex.j1],
                    " ",
                    this.ShOCoBan[cTieuDoIndex.i2, cTieuDoIndex.j2],
                    this.ShOVua[cTieuDoIndex.i3, cTieuDoIndex.j3],
                    this.ShOTuongTuong[cTieuDoIndex.i4, cTieuDoIndex.j4]});
            }
            return result;
        }
        public CTieuDoIndex getAddress(double pPosX, double pPosY)
        {
            CTieuDoIndex cTieuDoIndex = new CTieuDoIndex();
            CTieuDoIndex cTieuDoIndex2 = cTieuDoIndex;
            checked
            {
                cTieuDoIndex2.i1 = (int)Math.Round(Math.Floor(unchecked(this.YMax - pPosY) / 5.0));
                cTieuDoIndex2.j1 = (int)Math.Round(Math.Floor(unchecked(pPosX - this.XMin) / 10.0));
                cTieuDoIndex2.i2 = (int)Math.Round(unchecked(Math.Floor((this.YMax - pPosY) / 0.5) - (double)checked(cTieuDoIndex2.i1 * 10)));
                cTieuDoIndex2.j2 = (int)Math.Round(unchecked(Math.Floor((pPosX - this.XMin) / 1.0) - (double)checked(cTieuDoIndex2.j1 * 10)));
            }
            double num = this.YMax - 0.5 * (double)checked(cTieuDoIndex2.i1 * 10 + cTieuDoIndex2.i2);
            double num2 = this.XMin + 1.0 * (double)checked(cTieuDoIndex2.j1 * 10 + cTieuDoIndex2.j2);
            checked
            {
                cTieuDoIndex2.i3 = (int)Math.Round(Math.Floor(unchecked(num - pPosY) / 0.16666666666666671));
                cTieuDoIndex2.j3 = (int)Math.Round(Math.Floor(unchecked(pPosX - num2) / 0.33333333333333331));
            }
            num = this.YMax - 0.5 * (double)checked(cTieuDoIndex2.i1 * 10 + cTieuDoIndex2.i2) - 0.16666666666666671 * (double)cTieuDoIndex2.i3;
            num2 = this.XMin + 1.0 * (double)checked(cTieuDoIndex2.j1 * 10 + cTieuDoIndex2.j2) + 0.33333333333333331 * (double)cTieuDoIndex2.j3;
            checked
            {
                cTieuDoIndex2.i4 = (int)Math.Round(Math.Floor(unchecked(num - pPosY) / 0.055555555555555573));
                cTieuDoIndex2.j4 = (int)Math.Round(Math.Floor(unchecked(pPosX - num2) / 0.11111111111111111));
                return cTieuDoIndex;
            }
        }
        public void Populate()
        {
            this.PopulateOCoBan();
            this.PopulateOVua();
            this.PopulateOTuongTuong();
        }
        public void PopulateOLon(string pFile)
        {
            bool flag = false;
            if (pFile.Length > 0 && File.Exists(pFile))
            {
                flag = this.LoadOLon(pFile);
            }
            if (!flag)
            {
                this.PopulateOLon();
            }
        }
        private bool LoadOLon(string Path)
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
                            if (array.GetUpperBound(0) == 1 && (array[0].Length >= 1 & array[1].Length >= 1))
                            {
                                num++;
                                this.ShOLon[num, 0] = array[0].ToString();
                                this.ShOLon[num, 1] = array[1].ToString();
                            }
                        }
                        streamReader.Close();
                        if (num == 4)
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        //Interaction.MsgBox("Khong thay '" + Path + "' khong load duoc.", MsgBoxStyle.OkOnly, null);
                    }
                }
                catch (Exception expr_DC)
                {
                    throw expr_DC;
                }
                return result;
            }
        }
        private void PopulateOLon()
        {
            this.ShOLon[0, 0] = "1";
            this.ShOLon[1, 0] = "2";
            this.ShOLon[2, 0] = "3";
            this.ShOLon[3, 0] = "4";
            this.ShOLon[4, 0] = "5";
            this.ShOLon[0, 1] = "6";
            this.ShOLon[1, 1] = "7";
            this.ShOLon[2, 1] = "8";
            this.ShOLon[3, 1] = "9";
            this.ShOLon[4, 1] = "0";
        }
        private void PopulateOCoBan()
        {
            int num = 0;
            checked
            {
                do
                {
                    int num2 = 0;
                    do
                    {
                        this.ShOCoBan[num, num2] = num.ToString() + num2.ToString();
                        num2++;
                    }
                    while (num2 <= 9);
                    num++;
                }
                while (num <= 9);
            }
        }
        private void PopulateOVua()
        {
            this.ShOVua[0, 0] = "1";
            this.ShOVua[0, 1] = "2";
            this.ShOVua[0, 2] = "3";
            this.ShOVua[1, 0] = "8";
            this.ShOVua[1, 1] = "9";
            this.ShOVua[1, 2] = "4";
            this.ShOVua[2, 0] = "7";
            this.ShOVua[2, 1] = "6";
            this.ShOVua[2, 2] = "5";
        }
        private void PopulateOTuongTuong()
        {
            this.ShOTuongTuong[0, 0] = "1";
            this.ShOTuongTuong[0, 1] = "2";
            this.ShOTuongTuong[0, 2] = "3";
            this.ShOTuongTuong[1, 0] = "8";
            this.ShOTuongTuong[1, 1] = "9";
            this.ShOTuongTuong[1, 2] = "4";
            this.ShOTuongTuong[2, 0] = "7";
            this.ShOTuongTuong[2, 1] = "6";
            this.ShOTuongTuong[2, 2] = "5";
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
                            double num5 = this.XMin + 10.0 * (double)num2 + 5.0;
                            double num6 = this.YMax - 5.0 * (double)num - 2.5;
                            pMap.ConvertCoord(ref num3, ref num4, ref num5, ref num6, ConversionConstants.miMapToScreen);
                            pointF.Y = num4;
                            pointF.X = num3;
                            string text = this.ShOLon[num, num2];
                            SizeF sizeF = g.MeasureString(text, font);
                            g.DrawString(text, font, brush, pointF.X - sizeF.Width / 2f, pointF.Y - sizeF.Height / 2f);
                            int num7 = 0;
                            do
                            {
                                num4 = pointF.X;
                                num3 = pointF.Y;
                                num6 = this.XMin + 10.0 * (double)num2 + 1.0 * (double)num7;
                                num5 = this.YMax - 5.0 * (double)num - 5.0;
                                pMap.ConvertCoord(ref num4, ref num3, ref num6, ref num5, ConversionConstants.miMapToScreen);
                                pointF.Y = num3;
                                pointF.X = num4;
                                text = num7.ToString();
                                sizeF = g.MeasureString(text, font2);
                                g.DrawString(text, font2, brush, pointF.X, pointF.Y - sizeF.Height);
                                checked
                                {
                                    num7++;
                                }
                            }
                            while (num7 <= 9);
                            if (num2 == 1)
                            {
                                int num8 = 0;
                                do
                                {
                                    num4 = pointF.X;
                                    num3 = pointF.Y;
                                    num6 = this.XMin + 10.0 * (double)num2;
                                    num5 = this.YMax - 5.0 * (double)num - 0.5 * (double)num8;
                                    pMap.ConvertCoord(ref num4, ref num3, ref num6, ref num5, ConversionConstants.miMapToScreen);
                                    pointF.Y = num3;
                                    pointF.X = num4;
                                    text = num8.ToString();
                                    sizeF = g.MeasureString(text, font2);
                                    g.DrawString(text, font2, brush, pointF.X - sizeF.Width, pointF.Y);
                                    num4 = pointF.X;
                                    num3 = pointF.Y;
                                    num6 = this.XMin + 10.0 * (double)num2;
                                    num5 = this.YMax - 5.0 * (double)num - 0.5 * (double)num8;
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
                    while (num2 <= 1);
                    num++;
                }
                while (num <= 4);
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
                double num4 = this.YMin + 0.5 * (double)checked(num3 - 1) + 0.16666666666666671;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMin, ref num4, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.YMin + 0.5 * (double)checked(num3 - 1) + 0.16666666666666671;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMax, ref num4, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.YMin + 0.5 * (double)num3 - 0.16666666666666671;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMin, ref num4, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.YMin + 0.5 * (double)num3 - 0.16666666666666671;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMax, ref num4, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.YMin + 0.5 * (double)num3;
                pMap.ConvertCoord(ref num2, ref num, ref this.XMin, ref num4, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.YMin + 0.5 * (double)num3;
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
            while (num3 <= 50);
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
                double num4 = this.XMin + 1.0 * (double)checked(num3 - 1) + 0.33333333333333331;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMax, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.XMin + 1.0 * (double)checked(num3 - 1) + 0.33333333333333331;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMin, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.XMin + 1.0 * (double)num3 - 0.33333333333333331;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMax, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.XMin + 1.0 * (double)num3 - 0.33333333333333331;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMin, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                g.DrawLine(mPen3, pt, pt2);
                num2 = pt.X;
                num = pt.Y;
                num4 = this.XMin + 1.0 * (double)num3;
                pMap.ConvertCoord(ref num2, ref num, ref num4, ref this.YMax, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                num2 = pt2.X;
                num = pt2.Y;
                num4 = this.XMin + 1.0 * (double)num3;
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
            while (num3 <= 20);
        }
    }
}