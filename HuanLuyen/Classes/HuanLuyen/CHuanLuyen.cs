using System;
using System.Collections.Generic;
namespace HuanLuyen
{
    [Serializable]
    public class CHuanLuyen
    {
        public DateTime TdBatDau;
        public DateTime DongHo;
        private List<CFlight> m_Flights;
        public object Flights
        {
            get
            {
                return this.m_Flights;
            }
            set
            {
                this.m_Flights = (List<CFlight>)value;
            }
        }
        public CHuanLuyen()
        {
            this.TdBatDau = DateTime.MinValue;
            this.DongHo = this.TdBatDau;
            this.m_Flights = new List<CFlight>();
        }
    }
}