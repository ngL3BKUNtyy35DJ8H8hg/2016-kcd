using System;
namespace HuanLuyen
{
    public class CLoaiBaiTap
    {
        public int LoaiBaiTapID;
        public string LoaiBaiTap;
        public CLoaiBaiTap()
        {
            this.LoaiBaiTapID = 0;
            this.LoaiBaiTap = "";
        }
        public override string ToString()
        {
            return this.LoaiBaiTap;
        }
    }
}