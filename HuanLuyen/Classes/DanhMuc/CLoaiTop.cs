using System;
namespace HuanLuyen
{
    public class CLoaiTop
    {
        public int LoaiTopID;
        public string LoaiTop;
        public int SoHieu;
        public override string ToString()
        {
            return this.LoaiTop;
        }
    }
}