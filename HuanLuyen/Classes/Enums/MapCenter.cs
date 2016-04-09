using System;
namespace HuanLuyen
{
    [Serializable]
    public struct MapCenter
    {
        public double CenterX;
        public double CenterY;
        public double Zoom;
        public MapCenter(double x, double y)
        {
            this = default(MapCenter);
            this.CenterX = x;
            this.CenterY = y;
            this.Zoom = 0.0;
        }
    }
}