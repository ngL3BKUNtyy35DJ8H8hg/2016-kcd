using System;
namespace HuanLuyen
{
    [Serializable]
    public class CLoaiMB
    {
        public int ID;
        public string LoaiMB;
        public string KL;
        public int SymbolID;
        public double Altitude;
        public double Speed;
        public float Roll;
        public CLoaiMB()
        {
            this.ID = 0;
            this.LoaiMB = "";
            this.KL = "";
            this.SymbolID = 0;
        }
        public override string ToString()
        {
            return this.LoaiMB;
        }
    }
}