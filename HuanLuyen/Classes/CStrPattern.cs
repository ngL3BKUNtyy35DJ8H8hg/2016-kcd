using System;
namespace HuanLuyen
{
    [Serializable]
    public class CStrPattern
    {
        public int PattNo;
        public int CX;
        public int CY;
        public string StrPattern;
        public CStrPattern()
        {
            this.PattNo = 0;
            this.CX = 0;
            this.CY = 0;
            this.StrPattern = "";
        }
    }
}