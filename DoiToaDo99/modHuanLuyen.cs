using ADOConnection;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace HuanLuyen
{
    public static class modHuanLuyen
    {
        public enum enCachNhap
        {
            DiaTieu,
            PhuongVi,
            KinhViDo
        }

        public enum enCachVong
        {
            DenDiem,
            QuanhDiem,
            HuongDiem
        }

        public enum enLoaiRada
        {
            CanhGioi = 1,
            HoaLuc,
            DanDuong
        }

        public enum enLoaiTop
        {
            Dich = 1,
            Ta,
            QuocTe,
            QuaCanh,
            ChienDau
        }

        public enum enRadaStatus
        {
            ChuaThay,
            XuatHien,
            Thay,
            TamMatMT,
            MatMT
        }

        public enum enTopStatus
        {
            ChuaBay,
            DangBay,
            DungBay
        }

        public struct CSDLSECU
        {
            public string User_ID;
            public string Pwd;
        }
        //internal struct EDITNODE
        //{
        //    public System.Drawing.Rectangle r;
        //    public int iPart = 0;
        //    public int iNode = 0;
        //}
        public static int miDelay = 400;
        public static int DichStt = 170;
        public static int TaStt = 1;
        public static int QuocTeStt = 50;
        public static int QuaCanhStt = 100;
        public static int ChuKyPhat55 = 1;
        public static int ChuKyPhat99 = 2;
        public static int DelayPhat99 = 3;
        public const double Y99Big = 0.5;
        public const double Y99Small = 0.16666666666666671;
        public const double X99Big = 1.0;
        public const double X99Small = 0.33333333333333331;
        public static double TieuDo55CX = 106.706772;
        public static double TieuDo55CY = 10.768299;
        public static double GocPvClCX = 106.64555556;
        public static double GocPvClCY = 10.81638889;
        public const double Y55Big = 0.1818181818181818;
        public const double Y55Small = 0.0363636363636364;
        public const double X55Big = 0.1818181818181818;
        public const double X55Small = 0.0363636363636364;
        public static int TgThayDoiTocDo = 10;
        public static string myTenCT = "Huấn luyện";
        public static string myCSDLMK = "";
        public static string myCnnType = "";
        public static string myCnnString = "";
        public static modHuanLuyen.CSDLSECU g_CSDLSecu;
        public static IConnFactory g_objConnFactory = null;
        //public static frmMain fMain;
        public static string myAppPara = "HuanLuyen.para";
        public static string myCurrentDirectory = "";
        //public static dlgGocPvCl fGocPvCl;
        //public static dlgHuanLuyen fHuanLuyen;
        //public static dlgTopChienDauMoi fTopChienDauMoi;
        //public static dlgBaiTapViewer fBaiTapViewer;
        //public static dlgBaiTapViewer2 fBaiTapViewer2;
        //public static dlgBaiTapHinhThai fBaiTapHinhThai;
        //public static dlgBaiTapRada fBaiTapRada;
        //public static dlgTopMoi2 fTopMoi2;
        //public static dlgTopEdit fTopEdit;
        //public static dlgTopNodeEdit fTopNodeEdit;
        //public static dlgFlightNodeEdit fFlightNodeEdit;
        public const int myToolNewTram = 2;
        public const int myToolChonTram = 4;
        //internal static modHuanLuyen.EDITNODE[] EditNodes;
        internal static int EditNodesCount = 0;
        public static Hashtable m_NodePatterns;
        public static int defaMayBayHalfSize = 4;
        public static float defaSoHieuFontSize = 8f;
        public static Font defaSoHieuFont = new Font("Arial Narrow", 8f, FontStyle.Regular, GraphicsUnit.Point);
        public static Color defaSoHieuC = Color.Black;
        public static string myDefaFile = "..\\Data\\HuanLuyen.def";
        public static string myGocPvClFile = "..\\Data\\GocPvCl.def";
        public static int defaPathDauCuoiSize = 5;
        public static int defaPathCach = 3;
        public static int defaPathWidth = 1;
        public static Color defaPathColor = Color.DarkGray;
        public static Color defaTopDichColor = Color.MediumBlue;
        public static Color defaTopTaColor = Color.Red;
        public static Color defaTopQuocTeColor = Color.Gold;
        public static Color defaTopQuaCanhColor = Color.Orange;
        public static Color defaTopChienDauColor = Color.Red;
        public static Color defaKhongVucColor = Color.Red;
        public static int defaRadaHLPenW = 1;
        public static Color defaRadaHLPenC = Color.LightCyan;
        public static int defaRadaDDPenW = 2;
        public static Color defaRadaDDPenC = Color.Orange;
        public static int defaPVPenW = 1;
        public static Color defaPVPenC = Color.Orange;
        public static int defaPVRadius = 50;
        public static int defaPVVongStep = 10;
        public static int defaPVVongDam = 5;
        public static int defaPVTiaStep = 10;
        public static int defaPVTiaDam = 3;
        public static int TimerInterval = 200;
        public static char cDecSepa = Convert.ToChar(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        public static char cGrpSepa = Convert.ToChar(Application.CurrentCulture.NumberFormat.NumberGroupSeparator);
        public const float NotQuiteZero = 1E-05f;
        public const long Ninety = 90L;
        public const long TwoSeventy = 270L;
        public const double RadsToDegs = 57.29578;
        public const double DegsToRads = 0.0174532925;
        public static Color GetTopColor(enLoaiTop pLoaiTopID)
        {
            Color result = modHuanLuyen.defaTopDichColor;
            switch (pLoaiTopID)
            {
                case enLoaiTop.Dich:
                    result = modHuanLuyen.defaTopDichColor;
                    break;
                case enLoaiTop.Ta:
                    result = modHuanLuyen.defaTopTaColor;
                    break;
                case enLoaiTop.QuocTe:
                    result = modHuanLuyen.defaTopQuocTeColor;
                    break;
                case enLoaiTop.QuaCanh:
                    result = modHuanLuyen.defaTopQuaCanhColor;
                    break;
                case enLoaiTop.ChienDau:
                    result = modHuanLuyen.defaTopChienDauColor;
                    break;
            }
            return result;
        }
        //public static struPhuongVi GetPhuongVi(AxMap pMap, double pGocX, double pGocY, double pPosX, double pPosY)
        //{
        //    struPhuongVi result = default(struPhuongVi);
        //    PointF pPT = default(PointF);
        //    PointF pPT2 = default(PointF);
        //    float num = pPT.X;
        //    float num2 = pPT.Y;
        //    pMap.ConvertCoord(ref num, ref num2, ref pGocX, ref pGocY, ConversionConstants.miMapToScreen);
        //    pPT.Y = num2;
        //    pPT.X = num;
        //    num2 = pPT2.X;
        //    num = pPT2.Y;
        //    pMap.ConvertCoord(ref num2, ref num, ref pPosX, ref pPosY, ConversionConstants.miMapToScreen);
        //    pPT2.Y = num;
        //    pPT2.X = num2;
        //    result.CuLy = pMap.Distance(pGocX, pGocY, pPosX, pPosY) / 1000.0;
        //    result.PhuongVi = modHuanLuyen.GetHDG(pPT, pPT2);
        //    return result;
        //}
        public static double GetDouble(string str1)
        {
            string value = str1.Replace(modHuanLuyen.cGrpSepa, modHuanLuyen.cDecSepa);
            return Convert.ToDouble(value);
        }
        public static float GetSingle(string str1)
        {
            string value = str1.Replace(modHuanLuyen.cGrpSepa, modHuanLuyen.cDecSepa);
            return Convert.ToSingle(value);
        }
        public static modHuanLuyen.CSDLSECU GetCSDLSecu(string SecuStr)
        {
            modHuanLuyen.CSDLSECU result = default(modHuanLuyen.CSDLSECU);
            result.User_ID = "Admin";
            result.Pwd = "";
            string[] array = SecuStr.Split(new char[]
			{
				';'
			});
            if (array.Length > 1)
            {
                result.User_ID = array[0];
                result.Pwd = array[1];
            }
            return result;
        }
        public static Color GetMau0(Color pColor)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                return pColor;
            }
            return pColor;
        }
        public static Color GetMau2(Color pColor)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = pColor;
            colorDialog.ShowDialog();
            return colorDialog.Color;
        }
        public static float DirectionOfLine2(float From_X, float From_Y, float To_X, float To_Y)
        {
            if (From_Y == To_Y)
            {
                To_Y = From_Y - 1E-05f;
            }
            float result = 0;
            if (To_Y < From_Y)
            {
                result = (float)(90.0 + Math.Atan((double)((To_X - From_X) / (To_Y - From_Y))) * 57.29578);
            }
            else
            {
                result = (float)(270.0 + Math.Atan((double)((To_X - From_X) / (To_Y - From_Y))) * 57.29578);
            }
            return result;
        }
        public static double GetHDG(PointF pPT1, PointF pPT2)
        {
            return modHuanLuyen.HieuChinhGoc((double)checked((int)Math.Round(unchecked(Math.Atan2((double)(pPT1.Y - pPT2.Y), (double)(pPT1.X - pPT2.X)) * 57.29578 + 270.0))));
        }
        public static double GetHDG2(PointF pPT1, PointF pPT2)
        {
            return modHuanLuyen.HieuChinhGoc((double)checked((int)Math.Round(unchecked(Math.Atan2((double)(pPT1.Y - pPT2.Y), (double)(pPT1.X - pPT2.X)) * 57.29578 + 180.0))));
        }
        public static double HieuChinhGoc(double pGoc)
        {
            double num = 0;
            for (num = pGoc; num < 0.0; num += 360.0)
            {
            }
            while (num >= 360.0)
            {
                num -= 360.0;
            }
            return num;
        }
        public static double GetHDG3(PointF pPT1, PointF pPT2)
        {
            if (pPT1.Y == pPT2.Y)
            {
                pPT2.Y = pPT1.Y - 1E-05f;
            }
            if (pPT2.Y < pPT1.Y)
            {
                return 90.0 + Math.Atan((double)((pPT2.X - pPT1.X) / (pPT2.Y - pPT1.Y))) * 57.29578;
            }
            return 270.0 + Math.Atan((double)((pPT2.X - pPT1.X) / (pPT2.Y - pPT1.Y))) * 57.29578;
        }
        //private static double getMapXformat(DPGFormat pDPG)
        //{
        //    return (double)pDPG.ido + ((double)pDPG.iphut + (double)pDPG.igiay / 60.0) / 60.0;
        //}
        //public static string getDPGstr(double pX)
        //{
        //    DPGFormat dPG = modHuanLuyen.getDPG(pX);
        //    return string.Concat(new string[]
        //    {
        //        dPG.ido.ToString("#0"),
        //        "°",
        //        dPG.iphut.ToString("#0"),
        //        ":",
        //        dPG.igiay.ToString("#0")
        //    });
        //}
        //public static DPGFormat getDPG(double pX)
        //{
        //    DPGFormat result = default(DPGFormat);
        //    result.ido = (int)Math.Round(Math.Floor(pX));
        //    result.iphut = (int)Math.Round(Math.Floor(unchecked((pX - (double)result.ido) * 60.0)));
        //    result.igiay = (int)Math.Round(Math.Floor(unchecked(((pX - (double)result.ido) * 60.0 - (double)result.iphut) * 60.0)));
        //    return result;
        //}
        public static void LoadDefa(string pFileName)
        {
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader(pFileName);
                modHuanLuyen.XML2Defa(xmlTextReader);
                xmlTextReader.Close();
            }
            catch (Exception expr_15)
            {
                throw expr_15;
            }
        }
        private static void XML2Defa(XmlTextReader rr)
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
                                if (name2 == "defaPathColor")
                                {
                                    modHuanLuyen.defaPathColor = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaPathWidth")
                                {
                                    modHuanLuyen.defaPathWidth = Convert.ToInt32(rr.Value);
                                }
                                else if (name2 == "defaTopDichColor")
                                {
                                    modHuanLuyen.defaTopDichColor = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaTopTaColor")
                                {
                                    modHuanLuyen.defaTopTaColor = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaTopQuocTeColor")
                                {
                                    modHuanLuyen.defaTopQuocTeColor = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaTopQuaCanhColor")
                                {
                                    modHuanLuyen.defaTopQuaCanhColor = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaTopChienDauColor")
                                {
                                    modHuanLuyen.defaTopChienDauColor = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaKhongVucColor")
                                {
                                    modHuanLuyen.defaKhongVucColor = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaRadaHLPenC")
                                {
                                    modHuanLuyen.defaRadaHLPenC = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaRadaHLPenW")
                                {
                                    modHuanLuyen.defaRadaHLPenW = Convert.ToInt32(rr.Value);
                                }
                                else if (name2 == "defaRadaDDPenC")
                                {
                                    modHuanLuyen.defaRadaDDPenC = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaRadaDDPenW")
                                {
                                    modHuanLuyen.defaRadaDDPenW = Convert.ToInt32(rr.Value);
                                }
                                else if (name2 == "defaPVRadius")
                                {
                                    modHuanLuyen.defaPVRadius = Convert.ToInt32(rr.Value);
                                }
                                else if (name2 == "defaPVPenC")
                                {
                                    modHuanLuyen.defaPVPenC = Color.FromArgb(Convert.ToInt32(rr.Value));
                                }
                                else if (name2 == "defaPVVongStep")
                                {
                                    modHuanLuyen.defaPVVongStep = Convert.ToInt32(rr.Value);
                                }
                                else if (name2 == "defaPVVongDam")
                                {
                                    modHuanLuyen.defaPVVongDam = Convert.ToInt32(rr.Value);
                                }
                                else if (name2 == "defaPVTiaStep")
                                {
                                    modHuanLuyen.defaPVTiaStep = Convert.ToInt32(rr.Value);
                                }
                                else if (name2 == "defaPVTiaDam")
                                {
                                    modHuanLuyen.defaPVTiaDam = Convert.ToInt32(rr.Value);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception expr_345)
            {
                throw expr_345;
            }
        }
        public static void LoadGocPvCl(string pFileName)
        {
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader(pFileName);
                modHuanLuyen.XML2GocPvCl(xmlTextReader);
                xmlTextReader.Close();
            }
            catch (Exception expr_15)
            {
                throw expr_15;
            }
        }
        private static void XML2GocPvCl(XmlTextReader rr)
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
                                if (name2 == "GocPvClCX")
                                {
                                    modHuanLuyen.GocPvClCX = modHuanLuyen.GetDouble(rr.Value);
                                }
                                else if (name2 == "GocPvClCY")
                                {
                                    modHuanLuyen.GocPvClCY = modHuanLuyen.GetDouble(rr.Value);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception expr_92)
            {
                throw expr_92;
                Exception ex = expr_92;
                throw ex;
            }
        }
        //public static void GocPvCl2File(string pFileName)
        //{
        //    StreamWriter w = new StreamWriter(pFileName);
        //    XmlTextWriter xmlTextWriter = new XmlTextWriter(w);
        //    modHuanLuyen.GocPvCl2xml(ref xmlTextWriter);
        //    xmlTextWriter.Close();
        //}
        //private static void GocPvCl2xml(ref XmlTextWriter wr)
        //{
        //    wr.WriteStartElement("DEFAS");
        //    wr.WriteAttributeString("GocPvClCX", modHuanLuyen.GocPvClCX).ToString();
        //    wr.WriteAttributeString("GocPvClCY", modHuanLuyen.GocPvClCY).ToString();
        //    wr.WriteEndElement();
        //}
        public static bool File2Para(string pFileName)
        {
            bool result = false;
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader(pFileName);
                modHuanLuyen.XML2Para(xmlTextReader);
                xmlTextReader.Close();
                result = true;
            }
            catch (Exception expr_19)
            {
                throw expr_19;
            }
            return result;
        }
        private static void XML2Para(XmlTextReader rr)
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
                        if (name == "PARA" && rr.AttributeCount > 0)
                        {
                            while (rr.MoveToNextAttribute())
                            {
                                string name2 = rr.Name;
                                if (name2 == "myTenCT")
                                {
                                    modHuanLuyen.myTenCT = rr.Value;
                                }
                                else if (name2 == "myCnnType")
                                {
                                    modHuanLuyen.myCnnType = rr.Value;
                                }
                                else if (name2 == "myCSDLMK")
                                {
                                    modHuanLuyen.myCSDLMK = rr.Value;
                                }
                                else if (name2 == "myCnnString")
                                {
                                    modHuanLuyen.myCnnString = rr.Value;
                                }
                                else if (name2 == "myKHCnnString")
                                {
                                    //modBdTC.myKHCnnString = rr.Value;
                                }
                                else if (name2 == "myMapGst")
                                {
                                    //modBanDo.myMapGst = rr.Value;
                                }
                                else if (name2 == "myBdTCDefaFile")
                                {
                                    //modBdTC.myBdTCDefaFile = rr.Value;
                                }
                                else if (name2 == "myDefaFile")
                                {
                                    modHuanLuyen.myDefaFile = rr.Value;
                                }
                                else if (name2 == "myGocPvClFile")
                                {
                                    modHuanLuyen.myGocPvClFile = rr.Value;
                                }
                                else if (name2 == "DichStt")
                                {
                                    modHuanLuyen.DichStt = (int)Math.Round(double.Parse(rr.Value));
                                }
                                else if (name2 == "TaStt")
                                {
                                    modHuanLuyen.TaStt = (int)Math.Round(double.Parse(rr.Value));
                                }
                                else if (name2 == "QuocTeStt")
                                {
                                    modHuanLuyen.QuocTeStt = (int)Math.Round(double.Parse(rr.Value));
                                }
                                else if (name2 == "QuaCanhStt")
                                {
                                    modHuanLuyen.QuaCanhStt = (int)Math.Round(double.Parse(rr.Value));
                                }
                                else if (name2 == "ChuKyPhat55")
                                {
                                    modHuanLuyen.ChuKyPhat55 = (int)Math.Round(double.Parse(rr.Value));
                                }
                                else if (name2 == "ChuKyPhat99")
                                {
                                    modHuanLuyen.ChuKyPhat99 = (int)Math.Round(double.Parse(rr.Value));
                                }
                                else if (name2 == "DelayPhat99")
                                {
                                    modHuanLuyen.DelayPhat99 = (int)Math.Round(double.Parse(rr.Value));
                                }
                                else if (name2 == "TieuDo55CX")
                                {
                                    modHuanLuyen.TieuDo55CX = modHuanLuyen.GetDouble(rr.Value);
                                }
                                else if (name2 == "TieuDo55CY")
                                {
                                    modHuanLuyen.TieuDo55CY = modHuanLuyen.GetDouble(rr.Value);
                                }
                                else if (name2 == "mySaiSo")
                                {
                                    //modBanDo.BDSaiSo = modHuanLuyen.GetDouble(rr.Value);
                                }
                                else if (name2 == "myTinhChinhGocQuay")
                                {
                                    //modBdTC.myTinhChinhGocQuay = modHuanLuyen.GetDouble(rr.Value);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception expr_332)
            {
                throw expr_332;
            }
        }
        public static void LoadLastBdTC(string pFileName)
        {
            try
            {
                XmlTextReader xmlTextReader = new XmlTextReader(pFileName);
                modHuanLuyen.XML2LastBdTC(xmlTextReader);
                xmlTextReader.Close();
            }
            catch (Exception expr_15)
            {
                throw expr_15;
            }
        }
        private static void XML2LastBdTC(XmlTextReader rr)
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
                        if (name == "LAST" && rr.AttributeCount > 0)
                        {
                            while (rr.MoveToNextAttribute())
                            {
                                string name2 = rr.Name;
                                if (name2 == "LastBdTC")
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception expr_5A)
            {
                throw expr_5A;
            }
        }
        public static void LastBdTC2File(string pFileName)
        {
            Directory.SetCurrentDirectory(modHuanLuyen.myCurrentDirectory);
            StreamWriter w = new StreamWriter(pFileName);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(w);
            xmlTextWriter.WriteStartElement("LAST");
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.Close();
        }
        public static string GetCnnStrFromFile(string pFileSpec)
        {
            string result = "";
            try
            {
                StreamReader streamReader = new StreamReader(pFileSpec);
                string text;
                while (true)
                {
                    text = streamReader.ReadLine();
                    if (text != null && text.IndexOf("Provider") > -1)
                    {
                        break;
                    }
                    if (text == null)
                    {
                        goto IL_39;
                    }
                }
                result = text;
            IL_39:
                streamReader.Close();
            }
            catch (Exception expr_42)
            {
                throw expr_42;
            }
            return result;
        }
    }
}