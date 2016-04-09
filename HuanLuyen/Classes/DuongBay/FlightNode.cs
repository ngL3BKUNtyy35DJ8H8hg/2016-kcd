using System;
namespace HuanLuyen
{
    [Serializable]
    public class FlightNode
    {
        public int Stt;
        public DateTime td;
        public PathNode node;
        public int nodetype;
        public bool isPlan;
        public FlightNode()
        {
            this.isPlan = false;
            this.Stt = 0;
            this.td = DateTime.Now;
            this.node = new PathNode();
            this.nodetype = 0;
        }
        public FlightNode(MapPoint pMapPt)
        {
            this.isPlan = false;
            this.Stt = 0;
            this.td = DateTime.Now;
            this.node = new PathNode(pMapPt);
            this.nodetype = 0;
        }
        public FlightNode(PathNode pNode)
        {
            this.isPlan = false;
            this.Stt = 0;
            this.td = DateTime.Now;
            this.node = new PathNode();
            PathNode pathNode = this.node;
            pathNode.Stt = pNode.Stt;
            pathNode.D = pNode.D;
            pathNode.Speed = pNode.Speed;
            pathNode.Roll = pNode.Roll;
            pathNode.Turn = pNode.Turn;
            pathNode.R = pNode.R;
            pathNode.C = pNode.C;
            pathNode.yp = pNode.yp;
            pathNode.Dp = pNode.Dp;
            pathNode.hdgCD = pNode.hdgCD;
            pathNode.typ = pNode.typ;
            pathNode.tspeed = pNode.tspeed;
            pathNode.t2next = pNode.t2next;
            pathNode.CachVong = pNode.CachVong;
            pathNode.CachNhap = pNode.CachNhap;
            this.nodetype = 0;
        }
    }
}