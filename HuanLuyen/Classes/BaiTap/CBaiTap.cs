using System;
namespace HuanLuyen
{
    public class CBaiTap
    {
        public int BaiTapID;
        public int LoaiBaiTapID;
        public DateTime NgayTao;
        public string BaiTap;
        public int GioBatDau;
        public int PhutBatDau;
        public int SoPhut;
        public CBaiTap()
        {
            this.BaiTapID = 0;
            this.LoaiBaiTapID = 0;
            this.NgayTao = DateTime.Now;
            this.BaiTap = "";
            this.GioBatDau = 0;
            this.PhutBatDau = 0;
            this.SoPhut = 0;
        }
        public override string ToString()
        {
            return this.BaiTap;
        }
    }
}