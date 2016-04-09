using DBiGraphicObjs.DBiGraphicObjects;
using System;
namespace HuanLuyen
{
    public class CFOUNDNODE
    {
        private GraphicObject m_FoundObject;
        private int m_NodeIndex = 0;
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
        public int NodeIndex
        {
            get
            {
                return this.m_NodeIndex;
            }
            set
            {
                this.m_NodeIndex = value;
            }
        }
    }
}