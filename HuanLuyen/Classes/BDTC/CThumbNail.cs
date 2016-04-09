using System;
namespace HuanLuyen
{
    public class CThumbNail
    {
        private string mValue;
        private int mID = 0;
        private string mSymbols;
        private int mSymbolStyle = 0;
        public int ID
        {
            get
            {
                return this.mID;
            }
            set
            {
                this.mID = value;
            }
        }
        public string Value
        {
            get
            {
                return this.mValue;
            }
            set
            {
                this.mValue = value;
            }
        }
        public string Symbols
        {
            get
            {
                return this.mSymbols;
            }
            set
            {
                this.mSymbols = value;
            }
        }
        public int SymbolStyle
        {
            get
            {
                return this.mSymbolStyle;
            }
            set
            {
                this.mSymbolStyle = value;
            }
        }
        public CThumbNail(string strValue, int intID, string strSymbols, int intSymbolStyle)
        {
            this.mValue = strValue;
            this.mID = intID;
            this.mSymbols = strSymbols;
            this.mSymbolStyle = intSymbolStyle;
        }
        public CThumbNail(string strValue, int intID, string strSymbols)
        {
            this.mValue = strValue;
            this.mID = intID;
            this.mSymbols = strSymbols;
            this.mSymbolStyle = 0;
        }
        public CThumbNail()
        {
            this.mValue = "";
            this.mID = 0;
            this.mSymbols = "";
            this.mSymbolStyle = 0;
        }
        public override string ToString()
        {
            return this.mValue;
        }
    }
}