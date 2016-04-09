using System;
namespace HuanLuyen
{
    [Serializable]
    public class CKhuatPt
    {
        public int Stt;
        public double PosX;
        public double PosY;
        public CKhuatPt()
        {
            this.Stt = 0;
            this.PosX = 0.0;
            this.PosY = 0.0;
        }
    }
}