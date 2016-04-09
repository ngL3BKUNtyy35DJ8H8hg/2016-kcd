using System;
namespace HuanLuyen
{
    public struct DPGFormat
    {
        public int ido;
        public int iphut;
        public int igiay;
        public DPGFormat(int ido, int iphut, int igiay)
        {
            this = default(DPGFormat);
            this.ido = ido;
            this.iphut = iphut;
            this.igiay = igiay;
        }
    }
}