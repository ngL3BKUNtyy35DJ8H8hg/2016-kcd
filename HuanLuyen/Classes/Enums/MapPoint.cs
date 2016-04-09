using System;
namespace HuanLuyen
{
    [Serializable]
    public struct MapPoint
    {
        public double x;
        public double y;
        public double h;
        public MapPoint(double x, double y)
        {
            this = default(MapPoint);
            this.x = x;
            this.y = y;
            this.h = 0.0;
        }
    }
}