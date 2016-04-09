using System;
using System.Drawing;
namespace HuanLuyen
{
    [Serializable]
    public class CDefaHL
    {
        public double GocPvClCX;
        public double GocPvClCY;
        public Color defaTopDichColor;
        public Color defaTopTaColor;
        public Color defaTopQuocTeColor;
        public Color defaTopQuaCanhColor;
        public int defaRadaHLPenW;
        public Color defaRadaHLPenC;
        public int defaRadaDDPenW;
        public Color defaRadaDDPenC;
        public double BDSaiSo;
        public int BDTyLeBanDo;
        public double BDKinhDo;
        public double BDViDo;
        public CDefaHL()
        {
            this.GocPvClCX = 106.64555556;
            this.GocPvClCY = 10.81638889;
            this.defaTopDichColor = Color.MediumBlue;
            this.defaTopTaColor = Color.Red;
            this.defaTopQuocTeColor = Color.Gold;
            this.defaTopQuaCanhColor = Color.Orange;
            this.defaRadaHLPenW = 1;
            this.defaRadaHLPenC = Color.LightCyan;
            this.defaRadaDDPenW = 2;
            this.defaRadaDDPenC = Color.Orange;
            this.BDSaiSo = 1.0;
            this.BDTyLeBanDo = 100000;
            this.BDKinhDo = 104.255;
            this.BDViDo = 17.0;
        }
    }
}