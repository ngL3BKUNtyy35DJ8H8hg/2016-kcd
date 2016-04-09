using System;
using System.Collections.Generic;
namespace HuanLuyen
{
    [Serializable]
    public class CPath : CBasePath
    {
        public int Path_ID;
        public string Name;
        public bool visible;
        public override string ToString()
        {
            return CLoaiMBs.GetLoaiMB(this.LoaiMB).LoaiMB + ": " + this.Name;
        }
        public CPath()
        {
            this.Path_ID = 0;
            this.Name = "";
            this.visible = false;
            this.LoaiMB = 0;
            this.PosFrom = default(MapPoint);
            this.SpeedFrom = 0.0;
            this.PosTo = default(MapPoint);
            this.SpeedTo = 0.0;
            this.Path = new List<PathNode>();
        }
    }
}