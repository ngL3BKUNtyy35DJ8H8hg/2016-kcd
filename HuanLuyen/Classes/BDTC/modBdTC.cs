using DBiGraphicObjs.DBiGraphicObjects;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
namespace HuanLuyen
{
    public sealed class modBdTC
    {
        public struct UNDOITEM
        {
            //public CSymbols UndoSymbols;
            public double MapX;
            public double MapY;
            //public CSymbol SeleSymbol;
        }
        public struct INTERSECTNODE
        {
            public PointF PT;
            public int NodeIndex;
        }
        //public static dlgCacKyHieu fCacKyHieu;
        //public static dlgDefBdTC fDefBDTC;
        //public static dlgChonTyLeKH fChonTyleKH;
        public static int BDTyLeLayKH = 100;
        public static float myTyLeKH2Map = 1f;
        public static long myLoaiKH_ID = 0L;
        public static COtherLineStyle MyOtherLineStyle;
        public static Color DanhDauColor = Color.FromArgb(75, Color.Red);
        public static Color DanhDauColor2 = Color.FromArgb(75, Color.Black);
        public static Color VeBoundColor = Color.FromKnownColor(KnownColor.HotTrack);
        public static int defaUndosNo = 10;
        public static modBdTC.UNDOITEM[] stackUnDos;
        public static modBdTC.UNDOITEM[] stackReDos;
        public static int defaMyLineStyle = 0;
        public static Color QuanDoColor = Color.Red;
        public static Color QuanXanhColor = Color.Blue;
        public static Color[] myColor = new Color[32];
        public static int defaGenPen1W = 1;
        public static Color defaGenPen1C = Color.Red;
        public static int defaGenPen2W = 0;
        public static Color defaGenPen2C = Color.Yellow;
        public static bool defaGenFill = false;
        public static Color defaGenFillC = Color.Red;
        public static int defaGenLineStyle = 0;
        public static int defaSongSongSize = 6;
        public static int defaSongSongLinesNo = 2;
        public static int defaSongSongPen1W = 1;
        public static Color defaSongSongPen1C = Color.Red;
        public static int defaSongSongPen2W = 0;
        public static Color defaSongSongPen2C = Color.Yellow;
        public static int defaSongSongLineStyle = 0;
        public static float myMuiTenDoRong = 30f;
        public static float defaMuiTenDoRong = 30f;
        public static int defaMuiTenPen1W = 1;
        public static Color defaMuiTenPen1C = Color.Red;
        public static int defaMuiTenPen2W = 0;
        public static Color defaMuiTenPen2C = Color.Yellow;
        public static bool defaMuiTenFill = true;
        public static Color defaMuiTenFillC = Color.FromArgb(100, Color.Red);
        public static float defaMuiTenDacDoRong = 6f;
        public static int defaMuiTenDacPen1W = 1;
        public static Color defaMuiTenDacPen1C = Color.Red;
        public static int defaMuiTenDacPen2W = 0;
        public static Color defaMuiTenDacPen2C = Color.Yellow;
        public static bool defaMuiTenDacFill = true;
        public static Color defaMuiTenDacFillC = Color.FromArgb(255, Color.Red);
        public static float defaMuiTenDacDoDai = 100f;
        public static int defaPiePen1W = 1;
        public static Color defaPiePen1C = Color.Red;
        public static int defaPiePen2W = 0;
        public static Color defaPiePen2C = Color.Yellow;
        public static bool defaPieFill = true;
        public static Color defaPieFillC = Color.FromArgb(100, Color.Red);
        public static bool defaPieArc = false;
        public static int defaPieStartA = 0;
        public static int defaPieSweepA = 90;
        public static int defaTableColsNo = 2;
        public static int defaTableRowsNo = 8;
        public static int defaTableBorderW = 1;
        public static Color defaTableBorderC = Color.Blue;
        public static int defaTableLineW = 1;
        public static Color defaTableLineC = Color.Gray;
        public static Color defaTableFillC = Color.FromArgb(100, Color.LightYellow);
        public static Font defaTableTFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point);
        public static string defaTableTFontName = "Tahoma";
        public static float defaTableTFontSize = 10f;
        public static int defaTableTFontStyle = 0;
        public static Color defaTableTextC = Color.Black;
        public static Font defaTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point);
        public static string defaTextFontName = "Tahoma";
        public static float defaTextFontSize = 10f;
        public static float defaTextFontStyle = 0f;
        public static Color defaTextC = Color.Red;
        public static int defaImageWidth = 80;
        public static int defaImageHeight = 40;
        public static int defaHorizontalSpacing = 10;
        public static int defaVerticalSpacing = 32;
        public static string myNewBdTC = "New.bdtc";
        public static string myBdTCDefaFile = "Defas.def";
        public static string myKHCnnString = "";
        public static double myTinhChinhGocQuay = 0.5;
        public static void LoadDefa(string pFileName)
        {
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader(pFileName);
                modBdTC.XML2Defa(xmlTextReader);
                xmlTextReader.Close();
                modBdTC.defaTableTFont = new Font(modBdTC.defaTableTFontName, modBdTC.defaTableTFontSize, (FontStyle)modBdTC.defaTableTFontStyle, GraphicsUnit.Point);
                modBdTC.defaTextFont = new Font(modBdTC.defaTextFontName, modBdTC.defaTextFontSize, checked((FontStyle)Math.Round((double)modBdTC.defaTextFontStyle)), GraphicsUnit.Point);
            }
            catch (Exception expr_50)
            {
                throw expr_50;
                //ProjectData.SetProjectError(expr_50);
                //ProjectData.ClearProjectError();
            }
        }
        private static void XML2Defa(XmlTextReader rr)
        {
            checked
            {
                try
                {
                    while (rr.Read())
                    {
                        XmlNodeType nodeType = rr.NodeType;
                        XmlNodeType xmlNodeType = nodeType;
                        if (xmlNodeType == XmlNodeType.Element)
                        {
                            string name = rr.Name;
                            if (name == "DEFAS" && rr.AttributeCount > 0)
                            {
                                while (rr.MoveToNextAttribute())
                                {
                                    string name2 = rr.Name;
                                    if (name2 == "QuanDoColor")
                                    {
                                        modBdTC.QuanDoColor = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "QuanXanhColor")
                                    {
                                        modBdTC.QuanXanhColor = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaGenPen1W")
                                    {
                                        modBdTC.defaGenPen1W = Convert.ToInt32(rr.Value);
                                    }
                                    else if (name2 == "defaGenPen1C")
                                    {
                                        modBdTC.defaGenPen1C = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaGenPen2W")
                                    {
                                        modBdTC.defaGenPen2W = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaGenPen2C")
                                    {
                                        modBdTC.defaGenPen2C = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaGenFill")
                                    {
                                        modBdTC.defaGenFill = rr.Value == "True" ? true : false;
                                    }
                                    else if (name2 == "defaGenFillC")
                                    {
                                        modBdTC.defaGenFillC = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaGenLineStyle")
                                    {
                                        modBdTC.defaGenLineStyle = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaSongSongSize")
                                    {
                                        modBdTC.defaSongSongSize = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaSongSongLinesNo")
                                    {
                                        modBdTC.defaSongSongLinesNo = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaSongSongPen1W")
                                    {
                                        modBdTC.defaSongSongPen1W = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaSongSongPen1C")
                                    {
                                        modBdTC.defaSongSongPen1C = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaSongSongPen2W")
                                    {
                                        modBdTC.defaSongSongPen2W = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaSongSongPen2C")
                                    {
                                        modBdTC.defaSongSongPen2C = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaSongSongLineStyle")
                                    {
                                        modBdTC.defaSongSongLineStyle = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaMuiTenDoRong")
                                    {
                                        modBdTC.defaMuiTenDoRong = float.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaMuiTenPen1W")
                                    {
                                        modBdTC.defaMuiTenPen1W = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaMuiTenPen1C")
                                    {
                                        modBdTC.defaMuiTenPen1C = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaMuiTenPen2W")
                                    {
                                        modBdTC.defaMuiTenPen2W = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaMuiTenPen2C")
                                    {
                                        modBdTC.defaMuiTenPen2C = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaMuiTenFill")
                                    {
                                        modBdTC.defaMuiTenFill = rr.Value == "True" ? true : false;
                                    }
                                    else if (name2 == "defaMuiTenFillC")
                                    {
                                        modBdTC.defaMuiTenFillC = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaMuiTenDacDoDai")
                                    {
                                        modBdTC.defaMuiTenDacDoDai = float.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaMuiTenDacDoRong")
                                    {
                                        modBdTC.defaMuiTenDacDoRong = float.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaMuiTenDacPen1W")
                                    {
                                        modBdTC.defaMuiTenDacPen1W = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaMuiTenDacPen1C")
                                    {
                                        modBdTC.defaMuiTenDacPen1C = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaMuiTenDacPen2W")
                                    {
                                        modBdTC.defaMuiTenDacPen2W = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaMuiTenDacPen2C")
                                    {
                                        modBdTC.defaMuiTenDacPen2C = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaMuiTenDacFill")
                                    {
                                        modBdTC.defaMuiTenDacFill = rr.Value == "True" ? true : false;
                                    }
                                    else if (name2 == "defaMuiTenDacFillC")
                                    {
                                        modBdTC.defaMuiTenDacFillC = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaTableColsNo")
                                    {
                                        modBdTC.defaTableColsNo = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaTableRowsNo")
                                    {
                                        modBdTC.defaTableRowsNo = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaTableBorderW")
                                    {
                                        modBdTC.defaTableBorderW = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaTableBorderC")
                                    {
                                        modBdTC.defaTableBorderC = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaTableLineW")
                                    {
                                        modBdTC.defaTableLineW = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaTableLineC")
                                    {
                                        modBdTC.defaTableLineC = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaTableFillC")
                                    {
                                        modBdTC.defaTableFillC = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaTableTFontName")
                                    {
                                        modBdTC.defaTableTFontName = rr.Value;
                                    }
                                    else if (name2 == "defaTableTFontSize")
                                    {
                                        modBdTC.defaTableTFontSize = float.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaTableTFontStyle")
                                    {
                                        modBdTC.defaTableTFontStyle = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaTableTextC")
                                    {
                                        modBdTC.defaTableTextC = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaTextFontName")
                                    {
                                        modBdTC.defaTextFontName = rr.Value;
                                    }
                                    else if (name2 == "defaTextFontSize")
                                    {
                                        modBdTC.defaTextFontSize = float.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaTextFontStyle")
                                    {
                                        modBdTC.defaTextFontStyle = float.Parse(rr.Value);
                                    }
                                    else if (name2 == "defaTextC")
                                    {
                                        modBdTC.defaTextC = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "DanhDauColor")
                                    {
                                        modBdTC.DanhDauColor = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "DanhDauColor2")
                                    {
                                        modBdTC.DanhDauColor2 = Color.FromArgb(int.Parse(rr.Value));
                                    }
                                    else if (name2 == "VeBoundColor")
                                    {
                                        modBdTC.VeBoundColor = Color.FromKnownColor((KnownColor)int.Parse(rr.Value));
                                    }
                                    else if (name2 == "defaUndosNo")
                                    {
                                        modBdTC.defaUndosNo = int.Parse(rr.Value);
                                    }
                                    else if (name2 == "ColorsTable")
                                    {
                                        string value = rr.Value;
                                        string[] array = value.Split(new char[]
{
' '
});
                                        if (array.GetUpperBound(0) == 31)
                                        {
                                            int num = 0;
                                            do
                                            {
                                                modBdTC.myColor[num] = Color.FromArgb(Convert.ToInt32(array[num]));
                                                num++;
                                            }
                                            while (num <= 31);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception expr_8BC)
                {
                    //ProjectData.SetProjectError(expr_8BC);
                    Exception ex = expr_8BC;
                    throw ex;
                }
            }
        }
        public static void Defa2File(string pFileName)
        {
            StreamWriter w = new StreamWriter(pFileName);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(w);
            modBdTC.Defa2xml(ref xmlTextWriter);
            xmlTextWriter.Close();
        }
        private static void Defa2xml(ref XmlTextWriter wr)
        {
            wr.WriteStartElement("DEFAS");
            wr.WriteAttributeString("QuanDoColor", modBdTC.QuanDoColor.ToArgb().ToString());
            wr.WriteAttributeString("QuanXanhColor", modBdTC.QuanXanhColor.ToArgb().ToString());
            wr.WriteAttributeString("defaGenPen1W", modBdTC.defaGenPen1W.ToString());
            wr.WriteAttributeString("defaGenPen1C", modBdTC.defaGenPen1C.ToArgb().ToString());
            wr.WriteAttributeString("defaGenPen2W", modBdTC.defaGenPen2W.ToString());
            wr.WriteAttributeString("defaGenPen2C", modBdTC.defaGenPen2C.ToArgb().ToString());
            wr.WriteAttributeString("defaGenFill", modBdTC.defaGenFill.ToString().ToString());
            wr.WriteAttributeString("defaGenFillC", modBdTC.defaGenFillC.ToArgb().ToString());
            wr.WriteAttributeString("defaGenLineStyle", modBdTC.defaGenLineStyle.ToString());
            wr.WriteAttributeString("defaSongSongSize", modBdTC.defaSongSongSize.ToString());
            wr.WriteAttributeString("defaSongSongLinesNo", modBdTC.defaSongSongLinesNo.ToString());
            wr.WriteAttributeString("defaSongSongPen1W", modBdTC.defaSongSongPen1W.ToString());
            wr.WriteAttributeString("defaSongSongPen1C", modBdTC.defaSongSongPen1C.ToArgb().ToString());
            wr.WriteAttributeString("defaSongSongPen2W", modBdTC.defaSongSongPen2W.ToString());
            wr.WriteAttributeString("defaSongSongPen2C", modBdTC.defaSongSongPen2C.ToArgb().ToString());
            wr.WriteAttributeString("defaSongSongLineStyle", modBdTC.defaSongSongLineStyle.ToString());
            wr.WriteAttributeString("defaMuiTenDoRong", modBdTC.defaMuiTenDoRong.ToString());
            wr.WriteAttributeString("defaMuiTenPen1W", modBdTC.defaMuiTenPen1W.ToString());
            wr.WriteAttributeString("defaMuiTenPen1C", modBdTC.defaMuiTenPen1C.ToArgb().ToString());
            wr.WriteAttributeString("defaMuiTenPen2W", modBdTC.defaMuiTenPen2W.ToString());
            wr.WriteAttributeString("defaMuiTenPen2C", modBdTC.defaMuiTenPen2C.ToArgb().ToString());
            wr.WriteAttributeString("defaMuiTenFill", modBdTC.defaMuiTenFill.ToString().ToString());
            wr.WriteAttributeString("defaMuiTenFillC", modBdTC.defaMuiTenFillC.ToArgb().ToString());
            wr.WriteAttributeString("defaMuiTenDacDoDai", modBdTC.defaMuiTenDacDoDai.ToString());
            wr.WriteAttributeString("defaMuiTenDacDoRong", modBdTC.defaMuiTenDacDoRong.ToString());
            wr.WriteAttributeString("defaMuiTenDacPen1W", modBdTC.defaMuiTenDacPen1W.ToString());
            wr.WriteAttributeString("defaMuiTenDacPen1C", modBdTC.defaMuiTenDacPen1C.ToArgb().ToString());
            wr.WriteAttributeString("defaMuiTenDacPen2W", modBdTC.defaMuiTenDacPen2W.ToString());
            wr.WriteAttributeString("defaMuiTenDacPen2C", modBdTC.defaMuiTenDacPen2C.ToArgb().ToString());
            wr.WriteAttributeString("defaMuiTenDacFill", modBdTC.defaMuiTenDacFill.ToString().ToString());
            wr.WriteAttributeString("defaMuiTenDacFillC", modBdTC.defaMuiTenDacFillC.ToArgb().ToString());
            wr.WriteAttributeString("defaTableColsNo", modBdTC.defaTableColsNo.ToString());
            wr.WriteAttributeString("defaTableRowsNo", modBdTC.defaTableRowsNo.ToString());
            wr.WriteAttributeString("defaTableBorderW", modBdTC.defaTableBorderW.ToString());
            wr.WriteAttributeString("defaTableBorderC", modBdTC.defaTableBorderC.ToArgb().ToString());
            wr.WriteAttributeString("defaTableLineW", modBdTC.defaTableLineW.ToString());
            wr.WriteAttributeString("defaTableLineC", modBdTC.defaTableLineC.ToArgb().ToString());
            wr.WriteAttributeString("defaTableFillC", modBdTC.defaTableFillC.ToArgb().ToString());
            wr.WriteAttributeString("defaTableTFontName", modBdTC.defaTableTFontName);
            wr.WriteAttributeString("defaTableTFontSize", modBdTC.defaTableTFontSize.ToString());
            wr.WriteAttributeString("defaTableTFontStyle", modBdTC.defaTableTFontStyle.ToString());
            wr.WriteAttributeString("defaTableTextC", modBdTC.defaTableTextC.ToArgb().ToString());
            wr.WriteAttributeString("defaTextFontName", modBdTC.defaTextFontName);
            wr.WriteAttributeString("defaTextFontSize", modBdTC.defaTextFontSize.ToString());
            wr.WriteAttributeString("defaTextFontStyle", modBdTC.defaTextFontStyle.ToString());
            wr.WriteAttributeString("defaTextC", modBdTC.defaTextC.ToArgb().ToString());
            wr.WriteAttributeString("DanhDauColor", modBdTC.DanhDauColor.ToArgb().ToString());
            wr.WriteAttributeString("DanhDauColor2", modBdTC.DanhDauColor2.ToArgb().ToString());
            wr.WriteAttributeString("VeBoundColor", modBdTC.VeBoundColor.ToString());
            wr.WriteAttributeString("defaUndosNo", modBdTC.defaUndosNo.ToString());
            string text = modBdTC.myColor[0].ToArgb().ToString();
            int num = 1;
            checked
            {
                do
                {
                    text = text + " " + modBdTC.myColor[num].ToArgb().ToString();
                    num++;
                }
                while (num <= 31);
                wr.WriteAttributeString("ColorsTable", text);
                wr.WriteEndElement();
            }
        }
        public static Color GetMau(Color pColor)
        {
            //[CONVERT FAIL]
            //dlgGetColor dlgGetColor = new dlgGetColor();
            //dlgGetColor.SeleColor = pColor;
            //dlgGetColor.TopMost = true;
            //if (dlgGetColor.ShowDialog() == DialogResult.OK)
            //{
            //    return dlgGetColor.SeleColor;
            //}
            //return pColor;
            return Color.Black;
        }
        public static void DrawNodes(Graphics g, PointF[] mPts, float radius)
        {
            Pen pen = new Pen(Color.Black, 1f);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(75, Color.Orange));
            try
            {
                RectangleF rect = new RectangleF(0f, 0f, 1f + radius * 2f, 1f + radius * 2f);
                rect.X = mPts[0].X - radius;
                rect.Y = mPts[0].Y - radius;
                g.FillEllipse(solidBrush, rect);
                g.DrawEllipse(pen, rect);
                g.DrawLine(pen, rect.Left - radius, rect.Top - radius, rect.Right + radius, rect.Bottom + radius);
                g.DrawLine(pen, rect.Left - radius, rect.Bottom + radius, rect.Right + radius, rect.Top - radius);
                if (mPts.GetUpperBound(0) > 0)
                {
                    int arg_F1_0 = 1;
                    int upperBound = mPts.GetUpperBound(0);
                    for (int i = arg_F1_0; i <= upperBound; i = checked(i + 1))
                    {
                        rect.X = mPts[i].X - radius;
                        rect.Y = mPts[i].Y - radius;
                        g.FillEllipse(solidBrush, rect);
                        g.DrawEllipse(pen, rect);
                    }
                }
            }
            catch (Exception arg_139_0)
            {
                //ProjectData.SetProjectError(arg_139_0);
                //ProjectData.ClearProjectError();
                throw arg_139_0;
            }
            finally
            {
                pen.Dispose();
                solidBrush.Dispose();
            }
        }
        private static object GetIntersectPoint(PointF PT1, PointF PT2, PointF PT3, PointF PT4)
        {
            PointF pointF = default(PointF);
            if (PT2.X == PT1.X)
            {
                PT2.X += 1f;
            }
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(PT1, PT2);
            GraphicsPath graphicsPath2 = new GraphicsPath();
            graphicsPath2.AddLine(PT3, PT4);
            pointF = COtherLineStyle.GiaoDiem(PT1, PT2, PT3, PT4);
            if (!graphicsPath.IsOutlineVisible(pointF, new Pen(Color.Black, 2f)))
            {
                return null;
            }
            if (graphicsPath2.IsOutlineVisible(pointF, new Pen(Color.Black, 2f)))
            {
                return pointF;
            }
            return null;
        }
        private static object GetIntersectPoint(PointF PT1, PointF PT2, PointF[] PTs, int index)
        {
            checked
            {
                if (PTs.GetUpperBound(0) >= index + 1)
                {
                    int num = PTs.GetUpperBound(0) - 1;
                    for (int i = index; i <= num; i++)
                    {
                        object objectValue = RuntimeHelpers.GetObjectValue(modBdTC.GetIntersectPoint(PT1, PT2, PTs[i], PTs[i + 1]));
                        if (objectValue != null)
                        {
                            object expr_52 = objectValue;
                            modBdTC.INTERSECTNODE iNTERSECTNODE;
                            PointF pointF = new PointF();
                            iNTERSECTNODE.PT = ((expr_52 != null) ? ((PointF)expr_52) : pointF);
                            iNTERSECTNODE.NodeIndex = i;
                            return iNTERSECTNODE;
                        }
                    }
                    return null;
                }
                return null;
            }
        }
        public static modBdTC.INTERSECTNODE[] GetIntersectPoints(PointF PT1, PointF PT2, PointF[] PTs)
        {
            int num = -1;
            modBdTC.INTERSECTNODE[] array = new modBdTC.INTERSECTNODE[0];
            checked
            {
                for (int i = 0; i <= PTs.GetUpperBound(0); i = array[num].NodeIndex + 1)
                {
                    object objectValue = RuntimeHelpers.GetObjectValue(modBdTC.GetIntersectPoint(PT1, PT2, PTs, i));
                    if (objectValue == null)
                    {
                        break;
                    }
                    num++;
                    //[CONVERT FAIL]
                    //array = (modBdTC.INTERSECTNODE[])Utils.CopyArray((Array)array, new modBdTC.INTERSECTNODE[num + 1]);
                    modBdTC.INTERSECTNODE[] arg_64_0_cp_0 = array;
                    int arg_64_0_cp_1 = num;
                    object expr_52 = objectValue;
                    //[CONVERT FAIL]
                    //modBdTC.INTERSECTNODE iNTERSECTNODE;
                    modBdTC.INTERSECTNODE iNTERSECTNODE = new INTERSECTNODE();
                    arg_64_0_cp_0[arg_64_0_cp_1] = ((expr_52 != null) ? ((modBdTC.INTERSECTNODE)expr_52) : iNTERSECTNODE);
                }
                return array;
            }
        }
        public static float AngleToPoint(PointF Origin, PointF Target)
        {
            Target.X -= Origin.X;
            Target.Y -= Origin.Y;
            return (float)(Math.Atan2((double)Target.Y, (double)Target.X) / 0.017453292519943295);
        }
        public static GraphicObject ObjToCurve(GraphicObject pObj)
        {
            GraphicObject graphicObject = null;
            checked
            {
                switch (pObj.GetObjType())
                {
                    case OBJECTTYPE.Polygon:
                    case OBJECTTYPE.ClosedCurve:
                        {
                            ShapeGraphic shapeGraphic = (ShapeGraphic)pObj;
                            GraphicsPath path = shapeGraphic.GetPath();
                            path.Flatten(new Matrix(), 0.5f);
                            PointF[] pathPoints = path.PathPoints;
                            graphicObject = new ClosedCurveGraphic(pathPoints, 1f, Color.Red)
                            {
                                Rotation = 0f,
                                LineColor = shapeGraphic.LineColor,
                                LineWidth = shapeGraphic.LineWidth,
                                Line2Color = shapeGraphic.Line2Color,
                                Line2Width = shapeGraphic.Line2Width,
                                Fill = shapeGraphic.Fill,
                                FillColor = shapeGraphic.FillColor,
                                LineStyle = shapeGraphic.LineStyle
                            };
                            break;
                        }
                    case OBJECTTYPE.Line:
                    case OBJECTTYPE.Curve:
                        {
                            ShapeGraphic shapeGraphic2 = (ShapeGraphic)pObj;
                            GraphicsPath path2 = shapeGraphic2.GetPath();
                            path2.Flatten(new Matrix(), 0.5f);
                            PointF[] pathPoints2 = path2.PathPoints;
                            graphicObject = new CurveGraphic(pathPoints2, 1f, Color.Red)
                            {
                                Rotation = 0f,
                                LineColor = shapeGraphic2.LineColor,
                                LineWidth = shapeGraphic2.LineWidth,
                                Line2Color = shapeGraphic2.Line2Color,
                                Line2Width = shapeGraphic2.Line2Width,
                                Fill = shapeGraphic2.Fill,
                                FillColor = shapeGraphic2.FillColor,
                                LineStyle = shapeGraphic2.LineStyle
                            };
                            break;
                        }
                    case OBJECTTYPE.Cycle:
                    case OBJECTTYPE.Ellipse:
                        {
                            ShapeGraphic shapeGraphic3 = (ShapeGraphic)pObj;
                            GraphicsPath path3 = shapeGraphic3.GetPath();
                            path3.Flatten(new Matrix(), 0.5f);
                            PointF[] array = path3.PathPoints;
                            int upperBound = array.GetUpperBound(0);
                            //[CONVERT FAIL]
                            //array = (PointF[])Utils.CopyArray((Array)array, new PointF[upperBound - 1 + 1]);
                            graphicObject = new ClosedCurveGraphic(array, 1f, Color.Red)
                            {
                                Rotation = 0f,
                                LineColor = shapeGraphic3.LineColor,
                                LineWidth = shapeGraphic3.LineWidth,
                                Line2Color = shapeGraphic3.Line2Color,
                                Line2Width = shapeGraphic3.Line2Width,
                                Fill = shapeGraphic3.Fill,
                                LineStyle = shapeGraphic3.LineStyle,
                                FillColor = shapeGraphic3.FillColor
                            };
                            break;
                        }
                    case OBJECTTYPE.Pie:
                        {
                            PieGraphic pieGraphic = (PieGraphic)pObj;
                            GraphicsPath path4 = pieGraphic.GetPath();
                            path4.Flatten(new Matrix(), 0.5f);
                            PointF[] pathPoints3 = path4.PathPoints;
                            if (pieGraphic.IsArc)
                            {
                                graphicObject = new CurveGraphic(pathPoints3, 1f, Color.Red)
                                {
                                    Rotation = 0f,
                                    LineColor = pieGraphic.LineColor,
                                    LineWidth = pieGraphic.LineWidth,
                                    Line2Color = pieGraphic.Line2Color,
                                    Line2Width = pieGraphic.Line2Width,
                                    Fill = pieGraphic.Fill,
                                    FillColor = pieGraphic.FillColor,
                                    LineStyle = pieGraphic.LineStyle
                                };
                            }
                            else
                            {
                                graphicObject = new ClosedCurveGraphic(pathPoints3, 1f, Color.Red)
                                {
                                    Rotation = 0f,
                                    LineColor = pieGraphic.LineColor,
                                    LineWidth = pieGraphic.LineWidth,
                                    Line2Color = pieGraphic.Line2Color,
                                    Line2Width = pieGraphic.Line2Width,
                                    Fill = pieGraphic.Fill,
                                    FillColor = pieGraphic.FillColor,
                                    LineStyle = pieGraphic.LineStyle
                                };
                            }
                            break;
                        }
                }
                if (graphicObject != null)
                {
                    NodesShapeGraphic nodesShapeGraphic = (NodesShapeGraphic)graphicObject;
                    int arg_3DA_0 = 0;
                    int num = nodesShapeGraphic.Nodes.Count - 1;
                    for (int i = arg_3DA_0; i <= num; i++)
                    {
                        nodesShapeGraphic.Nodes[i].IsControl = true;
                    }
                    return nodesShapeGraphic;
                }
                return pObj;
            }
        }
    }
}