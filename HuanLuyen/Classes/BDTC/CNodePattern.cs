using DBiGraphicObjs.DBiGraphicObjects;
using System;
namespace HuanLuyen
{
    [Serializable]
    public class CNodePattern
    {
        private int m_PattNo;
        private int m_CX;
        private int m_CY;
        private CGraphicObjs m_Pattern;
        public int PattNo
        {
            get
            {
                return this.m_PattNo;
            }
            set
            {
                this.m_PattNo = value;
            }
        }
        public int CX
        {
            get
            {
                return this.m_CX;
            }
            set
            {
                this.m_CX = value;
            }
        }
        public int CY
        {
            get
            {
                return this.m_CY;
            }
            set
            {
                this.m_CY = value;
            }
        }
        public CGraphicObjs Pattern
        {
            get
            {
                return this.m_Pattern;
            }
            set
            {
                this.m_Pattern = value;
            }
        }
        protected CNodePattern()
        {
        }
        public CNodePattern(int pPattNo, int pCX, int pCY, CGraphicObjs pPattern)
            : this()
        {
            this.m_PattNo = pPattNo;
            this.m_CX = pCX;
            this.m_CY = pCY;
            this.m_Pattern = pPattern;
        }
    }
}