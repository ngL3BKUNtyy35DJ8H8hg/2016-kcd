using AxMapXLib;
using System;
namespace HuanLuyen
{
    public class modBanDo
    {
        public static string myMapGst = "BanDo\\BanDo.gst";
        public static string myMapGstLuu = "BanDo\\BanDo.gst";
        public static string myMapNhoGst = "BanDo\\BanDoNho.gst";
        public const int myToolNewDoiTuong = 2;
        public const int myToolInfo = 3;
        public const int NHAPNHAYDELAY = 40;
        public static int myCoordSysType = 1;
        public static double BDSaiSo = 1.0;
        public static int BDTyLeBanDo = 100000;
        public static double BDKinhDo = 104.255;
        public static double BDViDo = 17.0;
        public static double GetZoomLevel(AxMap pMap, int pTyLeBanDo)
        {
            return (double)pTyLeBanDo * pMap.MapPaperWidth * modBanDo.BDSaiSo / 100.0;
        }
        public static int GetTyLeBD(AxMap pMap, double pZoom)
        {
            return checked((int)Math.Round(unchecked(pMap.Zoom * 100.0 / (pMap.MapPaperWidth * modBanDo.BDSaiSo))));
        }
    }
}