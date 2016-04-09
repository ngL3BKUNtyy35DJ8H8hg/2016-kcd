using DBiGraphicObjs.DBiGraphicObjects;
using System;
namespace HuanLuyen
{
    public class CFOUNDOBJECT
    {
        private GraphicObject m_FoundObject;
        private CSymbol m_FoundSymbol;
        public GraphicObject FoundObject
        {
            get
            {
                return this.m_FoundObject;
            }
            set
            {
                this.m_FoundObject = value;
            }
        }
        public CSymbol FoundSymbol
        {
            get
            {
                return this.m_FoundSymbol;
            }
            set
            {
                this.m_FoundSymbol = value;
            }
        }
    }
}