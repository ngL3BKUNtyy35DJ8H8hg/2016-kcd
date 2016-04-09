using System;
namespace HuanLuyen
{
    [Serializable]
    public class CTinhHuong
    {
        public int BaiTapID;
        public int Stt;
        public int Phut;
        public string TinhHuong;
        public CTinhHuong()
        {
            this.BaiTapID = 0;
            this.Stt = 0;
            this.Phut = 0;
            this.TinhHuong = "";
        }
    }
}