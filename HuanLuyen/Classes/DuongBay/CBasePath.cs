using AxMapXLib;
using MapXLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace HuanLuyen
{
    public class CBasePath
    {
        public int LoaiMB;
        public MapPoint PosFrom;
        public double SpeedFrom;
        public MapPoint PosTo;
        public double SpeedTo;
        public List<PathNode> Path;
        private PointF[] GetPoints(AxMap pMap)
        {
            int count = this.Path.Count;
            checked
            {
                PointF[] array = new PointF[count + 1 + 1];
                PointF[] array2 = array;
                PointF[] arg_22_0 = array2;
                int num = 0;
                float num2 = arg_22_0[num].X;
                PointF[] array3 = array;
                PointF[] arg_3A_0 = array3;
                int num3 = 0;
                float num4 = arg_3A_0[num3].Y;
                pMap.ConvertCoord(ref num2, ref num4, ref this.PosFrom.x, ref this.PosFrom.y, ConversionConstants.miMapToScreen);
                array3[num3].Y = num4;
                array2[num].X = num2;
                array3 = array;
                PointF[] arg_91_0 = array3;
                num3 = count + 1;
                num4 = arg_91_0[num3].X;
                array2 = array;
                PointF[] arg_AB_0 = array2;
                num = count + 1;
                num2 = arg_AB_0[num].Y;
                pMap.ConvertCoord(ref num4, ref num2, ref this.PosTo.x, ref this.PosTo.y, ConversionConstants.miMapToScreen);
                array2[num].Y = num2;
                array3[num3].X = num4;
                int num5 = 0;
                foreach (PathNode current in this.Path)
                {
                    num5++;
                    array3 = array;
                    PointF[] arg_11E_0 = array3;
                    num3 = num5;
                    num4 = arg_11E_0[num3].X;
                    array2 = array;
                    PointF[] arg_136_0 = array2;
                    num = num5;
                    num2 = arg_136_0[num].Y;
                    pMap.ConvertCoord(ref num4, ref num2, ref current.D.x, ref current.D.y, ConversionConstants.miMapToScreen);
                    array2[num].Y = num2;
                    array3[num3].X = num4;
                }

                return array;
            }
        }
        public void Draw(AxMap pMap, Graphics g, Pen pPen)
        {
            PointF[] points = this.GetPoints(pMap);
            g.DrawLines(pPen, points);
        }
        public void DrawDuongBay(AxMap pMap, Graphics g, Pen pPen, bool bnodelbl)
        {
            checked
            {
                if (this.Path.Count > 0)
                {
                    this.DrawDuongThangDau(pMap, g, pPen);
                    int arg_26_0 = 0;
                    int num = this.Path.Count - 1;
                    for (int i = arg_26_0; i <= num; i++)
                    {
                        this.DrawVongLuon(pMap, g, pPen, i, bnodelbl);
                        this.DrawDuongThang(pMap, g, pPen, i);
                    }
                }
                else
                {
                    this.DrawDuongThangDau(pMap, g, pPen);
                }
                this.DrawDiemCuoi(pMap, g, pPen);
                this.DrawDiemDau(pMap, g, pPen);
            }
        }
        private void DrawDiemCuoi(AxMap pMap, Graphics g, Pen pPen)
        {
            PointF pPT = default(PointF);
            PointF pointF = default(PointF);
            float num;
            float num2;
            if (this.Path.Count > 0)
            {
                int index = checked(this.Path.Count - 1);
                num = pPT.X;
                num2 = pPT.Y;
                pMap.ConvertCoord(ref num, ref num2, ref this.Path[index].Dp.x, ref this.Path[index].Dp.y, ConversionConstants.miMapToScreen);
                pPT.Y = num2;
                pPT.X = num;
            }
            else
            {
                num2 = pPT.X;
                num = pPT.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.PosFrom.x, ref this.PosFrom.y, ConversionConstants.miMapToScreen);
                pPT.Y = num;
                pPT.X = num2;
            }
            num2 = pointF.X;
            num = pointF.Y;
            pMap.ConvertCoord(ref num2, ref num, ref this.PosTo.x, ref this.PosTo.y, ConversionConstants.miMapToScreen);
            pointF.Y = num;
            pointF.X = num2;
            float angle = (float)modHuanLuyen.GetHDG(pPT, pointF);
            PointF[] array = new PointF[4];
            array[0].X = pointF.X - (float)modHuanLuyen.defaPathDauCuoiSize;
            array[0].Y = pointF.Y;
            array[1].X = pointF.X + (float)modHuanLuyen.defaPathDauCuoiSize;
            array[1].Y = pointF.Y;
            array[2].X = pointF.X - (float)modHuanLuyen.defaPathDauCuoiSize;
            array[2].Y = pointF.Y - (float)modHuanLuyen.defaPathCach;
            array[3].X = pointF.X + (float)modHuanLuyen.defaPathDauCuoiSize;
            array[3].Y = pointF.Y - (float)modHuanLuyen.defaPathCach;
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, pointF, MatrixOrder.Prepend);
            matrix.TransformPoints(array);
            g.DrawLine(pPen, array[0], array[1]);
            g.DrawLine(pPen, array[2], array[3]);
        }
        protected virtual void DrawDiemDau(AxMap pMap, Graphics g, Pen pPen)
        {
            PointF pointF = default(PointF);
            PointF pPT = default(PointF);
            float num = pointF.X;
            float num2 = pointF.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.PosFrom.x, ref this.PosFrom.y, ConversionConstants.miMapToScreen);
            pointF.Y = num2;
            pointF.X = num;
            if (this.Path.Count > 0)
            {
                num2 = pPT.X;
                num = pPT.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[0].D.x, ref this.Path[0].D.y, ConversionConstants.miMapToScreen);
                pPT.Y = num;
                pPT.X = num2;
            }
            else
            {
                num2 = pPT.X;
                num = pPT.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.PosTo.x, ref this.PosTo.y, ConversionConstants.miMapToScreen);
                pPT.Y = num;
                pPT.X = num2;
            }
            float angle = (float)modHuanLuyen.GetHDG(pointF, pPT);
            PointF[] array = new PointF[3];
            array[0].X = pointF.X - (float)modHuanLuyen.defaPathDauCuoiSize;
            array[0].Y = pointF.Y + (float)modHuanLuyen.defaPathDauCuoiSize;
            array[1].X = pointF.X;
            array[1].Y = pointF.Y;
            array[2].X = pointF.X + (float)modHuanLuyen.defaPathDauCuoiSize;
            array[2].Y = pointF.Y + (float)modHuanLuyen.defaPathDauCuoiSize;
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, pointF, MatrixOrder.Prepend);
            matrix.TransformPoints(array);
            g.DrawLines(pPen, array);
        }
        private void DrawVongLuon(AxMap pMap, Graphics g, Pen pPen, int index, bool blabel)
        {
            PointF pointF = default(PointF);
            float num = pointF.X;
            float num2 = pointF.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.Path[index].D.x, ref this.Path[index].D.y, ConversionConstants.miMapToScreen);
            pointF.Y = num2;
            pointF.X = num;
            if (this.Path[index].R > 0.0)
            {
                PointF pPt = default(PointF);
                num2 = pPt.X;
                num = pPt.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].C.x, ref this.Path[index].C.y, ConversionConstants.miMapToScreen);
                pPt.Y = num;
                pPt.X = num2;
                double num3 = CBasePath.getdistance(pPt, pointF);
                RectangleF rect = new RectangleF((float)((double)pPt.X - num3), (float)((double)pPt.Y - num3), (float)(2.0 * num3), (float)(2.0 * num3));
                if (blabel)
                {
                    g.DrawEllipse(Pens.LightGray, rect);
                }
                float startAngle;
                if (this.Path[index].Turn == TurnValue.Left)
                {
                    startAngle = (float)(this.Path[index].hdgCD - this.Path[index].yp);
                }
                else
                {
                    startAngle = (float)this.Path[index].hdgCD;
                }
                g.DrawArc(pPen, rect, startAngle, (float)this.Path[index].yp);
            }
            if (blabel)
            {
                this.Path[index].DrawNodeLbl(pMap, g, pPen, pointF);
            }
        }
        private void DrawDuongThang(AxMap pMap, Graphics g, Pen pPen, int index)
        {
            PathNode nextNode = this.getNextNode(index);
            PointF pt = default(PointF);
            float num = pt.X;
            float num2 = pt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref nextNode.D.x, ref nextNode.D.y, ConversionConstants.miMapToScreen);
            pt.Y = num2;
            pt.X = num;
            PointF pt2 = default(PointF);
            num2 = pt2.X;
            num = pt2.Y;
            pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].Dp.x, ref this.Path[index].Dp.y, ConversionConstants.miMapToScreen);
            pt2.Y = num;
            pt2.X = num2;
            g.DrawLine(pPen, pt2, pt);
        }
        private void DrawDuongThangDau(AxMap pMap, Graphics g, Pen pPen)
        {
            PointF pt = default(PointF);
            float num = pt.X;
            float num2 = pt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.PosFrom.x, ref this.PosFrom.y, ConversionConstants.miMapToScreen);
            pt.Y = num2;
            pt.X = num;
            PointF pt2 = default(PointF);
            if (this.Path.Count > 0)
            {
                num2 = pt2.X;
                num = pt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[0].D.x, ref this.Path[0].D.y, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
            }
            else
            {
                num2 = pt2.X;
                num = pt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.PosTo.x, ref this.PosTo.y, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
            }
            g.DrawLine(pPen, pt, pt2);
        }
        public bool HitTest(AxMap pMap, PointF pt)
        {
            Matrix matrix = new Matrix();
            GraphicsPath graphicsPath = new GraphicsPath();
            checked
            {
                if (this.Path.Count > 0)
                {
                    this.AddDuongThangDau(pMap, ref graphicsPath);
                    int arg_35_0 = 0;
                    int num = this.Path.Count - 1;
                    for (int i = arg_35_0; i <= num; i++)
                    {
                        this.AddVongLuon(pMap, i, ref graphicsPath);
                        this.AddDuongThang(pMap, i, ref graphicsPath);
                    }
                }
                else
                {
                    this.AddDuongThangDau(pMap, ref graphicsPath);
                }
                Pen pen = new Pen(Color.Black, 4f);
                return graphicsPath.IsOutlineVisible(pt, pen);
            }
        }
        private void AddDuongThangDau(AxMap pMap, ref GraphicsPath gPath)
        {
            PointF pt = default(PointF);
            float num = pt.X;
            float num2 = pt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.PosFrom.x, ref this.PosFrom.y, ConversionConstants.miMapToScreen);
            pt.Y = num2;
            pt.X = num;
            PointF pt2 = default(PointF);
            if (this.Path.Count > 0)
            {
                num2 = pt2.X;
                num = pt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[0].D.x, ref this.Path[0].D.y, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
            }
            else
            {
                num2 = pt2.X;
                num = pt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.PosTo.x, ref this.PosTo.y, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
            }
            gPath.AddLine(pt, pt2);
        }
        private void AddDuongThang(AxMap pMap, int index, ref GraphicsPath gPath)
        {
            PathNode nextNode = this.getNextNode(index);
            PointF pt = default(PointF);
            float num = pt.X;
            float num2 = pt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref nextNode.D.x, ref nextNode.D.y, ConversionConstants.miMapToScreen);
            pt.Y = num2;
            pt.X = num;
            PointF pt2 = default(PointF);
            num2 = pt2.X;
            num = pt2.Y;
            pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].Dp.x, ref this.Path[index].Dp.y, ConversionConstants.miMapToScreen);
            pt2.Y = num;
            pt2.X = num2;
            gPath.AddLine(pt2, pt);
        }
        private void AddVongLuon(AxMap pMap, int index, ref GraphicsPath gPath)
        {
            PointF pPt = default(PointF);
            float num = pPt.X;
            float num2 = pPt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.Path[index].D.x, ref this.Path[index].D.y, ConversionConstants.miMapToScreen);
            pPt.Y = num2;
            pPt.X = num;
            if (this.Path[index].R > 0.0)
            {
                PointF pPt2 = default(PointF);
                num2 = pPt2.X;
                num = pPt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref this.Path[index].C.x, ref this.Path[index].C.y, ConversionConstants.miMapToScreen);
                pPt2.Y = num;
                pPt2.X = num2;
                double num3 = CBasePath.getdistance(pPt2, pPt);
                RectangleF rect = new RectangleF((float)((double)pPt2.X - num3), (float)((double)pPt2.Y - num3), (float)(2.0 * num3), (float)(2.0 * num3));
                float startAngle;
                if (this.Path[index].Turn == TurnValue.Left)
                {
                    startAngle = (float)(this.Path[index].hdgCD - this.Path[index].yp);
                }
                else
                {
                    startAngle = (float)this.Path[index].hdgCD;
                }
                gPath.AddArc(rect, startAngle, (float)this.Path[index].yp);
            }
        }
        public void DrawNodes(AxMap pMap, Graphics g, int isele)
        {
            Matrix transform = g.Transform;
            GraphicsContainer container = g.BeginContainer();
            checked
            {
                try
                {
                    PointF[] points = this.GetPoints(pMap);
                    if (points.GetUpperBound(0) > 0)
                    {
                        int arg_30_0 = 0;
                        int upperBound = points.GetUpperBound(0);
                        for (int i = arg_30_0; i <= upperBound; i++)
                        {
                            if (i == isele - 1)
                            {
                                PointF mPt = new PointF();
                                float num = mPt.X;
                                float num2 = mPt.Y;
                                pMap.ConvertCoord(ref num, ref num2, ref this.Path[i].C.x, ref this.Path[i].C.y, ConversionConstants.miMapToScreen);
                                mPt.Y = num2;
                                mPt.X = num;
                                PointF mPt2 = new PointF();
                                num2 = mPt2.X;
                                num = mPt2.Y;
                                pMap.ConvertCoord(ref num2, ref num, ref this.Path[i].Dp.x, ref this.Path[i].Dp.y, ConversionConstants.miMapToScreen);
                                mPt2.Y = num;
                                mPt2.X = num2;
                                if (this.Path[i].CachVong == enCachVong.QuanhDiem)
                                {
                                    CBasePath.Draw1Node(pMap, g, points[i + 1], false);
                                    CBasePath.Draw1Node(pMap, g, mPt2, false);
                                    CBasePath.Draw1Node(pMap, g, mPt, true);
                                }
                                else if (this.Path[i].CachVong == enCachVong.HuongDiem)
                                {
                                    CBasePath.Draw1Node(pMap, g, points[i + 1], false);
                                    CBasePath.Draw1Node(pMap, g, mPt, false);
                                    CBasePath.Draw1Node(pMap, g, mPt2, true);
                                }
                                else
                                {
                                    CBasePath.Draw1Node(pMap, g, mPt, false);
                                    CBasePath.Draw1Node(pMap, g, mPt2, false);
                                    CBasePath.Draw1Node(pMap, g, points[i + 1], true);
                                }
                            }
                            else
                            {
                                CBasePath.Draw1Node(pMap, g, points[i + 1], false);
                            }
                        }
                    }
                }
                catch (Exception arg_1D5_0)
                {
                    throw arg_1D5_0;
                }
                finally
                {
                }
                g.EndContainer(container);
                g.Transform = transform;
            }
        }
        public static void Draw1Node(AxMap pMap, Graphics g, PointF mPt, bool bDanhDau)
        {
            Pen pen = new Pen(Color.Black, 1f);
            Pen pen2 = new Pen(Color.OrangeRed, 2f);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, Color.White));
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, 7, 7);
            checked
            {
                try
                {
                    rect.X = (int)Math.Round((double)unchecked(mPt.X - 3f));
                    rect.Y = (int)Math.Round((double)unchecked(mPt.Y - 3f));
                    g.FillEllipse(solidBrush, rect);
                    g.DrawEllipse(pen, rect);
                    if (bDanhDau)
                    {
                        g.DrawLine(pen2, rect.Left - 5, rect.Top - 5, rect.Right + 5, rect.Bottom + 5);
                        g.DrawLine(pen2, rect.Left - 5, rect.Bottom + 5, rect.Right + 5, rect.Top - 5);
                    }
                }
                catch (Exception arg_E3_0)
                {
                    throw arg_E3_0;
                }
                finally
                {
                    pen.Dispose();
                    pen2.Dispose();
                    solidBrush.Dispose();
                }
            }
        }
        public void MoveNodeTo(AxMap pMap, int index, PointF pt)
        {
            if (index > 0)
            {
                PathNode pathNode = this.GetPathNode(index);
                float x = pt.X;
                float y = pt.Y;
                pMap.ConvertCoord(ref x, ref y, ref pathNode.D.x, ref pathNode.D.y, ConversionConstants.miScreenToMap);
                pt.Y = y;
                pt.X = x;
                this.Path[checked(index - 1)] = pathNode;
            }
        }
        public void MoveNodeTo(int index, double pLon, double pLat)
        {
            if (index > 0)
            {
                PathNode pathNode = this.GetPathNode(index);
                pathNode.D.x = pLon;
                pathNode.D.y = pLat;
                this.Path[checked(index - 1)] = pathNode;
            }
        }
        public int FindNodeAtPoint(AxMap pMap, PointF pt)
        {
            PointF[] points = this.GetPoints(pMap);
            int result = -1;
            RectangleF rectangleF = new RectangleF(0f, 0f, 7f, 7f);
            int arg_2F_0 = 0;
            int upperBound = points.GetUpperBound(0);
            for (int i = arg_2F_0; i <= upperBound; i = checked(i + 1))
            {
                rectangleF.X = points[i].X - 3f;
                rectangleF.Y = points[i].Y - 3f;
                if (rectangleF.Contains(pt))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public bool HitTest0(AxMap pMap, PointF pt)
        {
            PointF[] points = this.GetPoints(pMap);
            Matrix matrix = new Matrix();
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(points);
            Pen pen = new Pen(Color.Black, 4f);
            return graphicsPath.IsOutlineVisible(pt, pen);
        }
        public PathNode GetPathNode(int index)
        {
            checked
            {
                int num = this.Path.Count + 1;
                if (index > num)
                {
                    return null;
                }
                PathNode pathNode = null;
                if (index == 0)
                {
                    pathNode = new PathNode(this.PosFrom);
                    pathNode.Speed = this.SpeedFrom;
                }
                else if (index == num)
                {
                    pathNode = new PathNode(this.PosTo);
                    pathNode.Speed = this.SpeedTo;
                }
                else if (this.Path.Count > 0)
                {
                    pathNode = this.Path[index - 1];
                }
                return pathNode;
            }
        }
        private PathNode getPrevNode(int index)
        {
            return this.GetPathNode(index);
        }
        private PathNode getNextNode(int index)
        {
            return this.GetPathNode(checked(index + 2));
        }
        public static TurnValue getTurn(PointF pt1, PointF pt2, PointF pt3)
        {
            double num = (double)((pt2.Y - pt1.Y) * (pt3.X - pt1.X) - (pt2.X - pt1.X) * (pt3.Y - pt1.Y));
            TurnValue result;
            if (num > 0.0)
            {
                result = TurnValue.Left;
            }
            else if (num < 0.0)
            {
                result = TurnValue.Right;
            }
            else
            {
                result = TurnValue.None;
            }
            return result;
        }
        public TurnValue getTurn(AxMap pMap, int Index)
        {
            PathNode prevNode = this.getPrevNode(Index);
            PathNode nextNode = this.getNextNode(Index);
            PointF pt = default(PointF);
            float num = pt.X;
            float num2 = pt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref prevNode.Dp.x, ref prevNode.Dp.y, ConversionConstants.miMapToScreen);
            pt.Y = num2;
            pt.X = num;
            PointF pt2 = default(PointF);
            num2 = pt2.X;
            num = pt2.Y;
            pMap.ConvertCoord(ref num2, ref num, ref this.Path[Index].D.x, ref this.Path[Index].D.y, ConversionConstants.miMapToScreen);
            pt2.Y = num;
            pt2.X = num2;
            PointF pt3 = default(PointF);
            num2 = pt3.X;
            num = pt3.Y;
            pMap.ConvertCoord(ref num2, ref num, ref nextNode.D.x, ref nextNode.D.y, ConversionConstants.miMapToScreen);
            pt3.Y = num;
            pt3.X = num2;
            return CBasePath.getTurn(pt, pt2, pt3);
        }
        public static void TinhYToVong1Node(AxMap pMap, PathNode node1, PathNode node3, PathNode node2)
        {
            if (node2.CachVong == enCachVong.QuanhDiem)
            {
                CBasePath.TinhYToVong1NodeQuanhDiem(pMap, node1, node3, node2);
            }
            else if (node2.CachVong == enCachVong.HuongDiem)
            {
                CBasePath.TinhYToVong1NodeHuongDiem(pMap, node1, node3, node2);
            }
            else
            {
                CBasePath.TinhYToVong1NodeDenDiem(pMap, node1, node3, node2);
            }
        }
        public static void TinhYToVong1NodeDenDiem(AxMap pMap, PathNode pnode1, PathNode pnode3, PathNode node2)
        {
            try
            {
                MapPoint d = node2.D;
                MapPoint dp = pnode1.Dp;
                MapPoint d2 = pnode3.D;
                PointF pt = default(PointF);
                float num = pt.X;
                float num2 = pt.Y;
                pMap.ConvertCoord(ref num, ref num2, ref dp.x, ref dp.y, ConversionConstants.miMapToScreen);
                pt.Y = num2;
                pt.X = num;
                PointF pointF = default(PointF);
                num2 = pointF.X;
                num = pointF.Y;
                pMap.ConvertCoord(ref num2, ref num, ref d.x, ref d.y, ConversionConstants.miMapToScreen);
                pointF.Y = num;
                pointF.X = num2;
                PointF pointF2 = default(PointF);
                num2 = pointF2.X;
                num = pointF2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref d2.x, ref d2.y, ConversionConstants.miMapToScreen);
                pointF2.Y = num;
                pointF2.X = num2;
                if (node2.Turn == TurnValue.None)
                {
                    node2.Turn = CBasePath.getTurn(pt, pointF, pointF2);
                }
                node2.R = 0.0;
                node2.yp = 0.0;
                node2.Dp.x = node2.D.x;
                node2.Dp.y = node2.D.y;
                if (node2.Roll != 0f)
                {
                    node2.R = CBasePath.GetRadius(node2.Speed, node2.Roll);
                    double num3 = pMap.Distance(dp.x, dp.y, node2.D.x, node2.D.y);
                    if (num3 > 1.0)
                    {
                        double num4 = node2.R / num3;
                        PointF[] array = new PointF[1];
                        array[0].X = (float)((1.0 + num4) * (double)pointF.X - num4 * (double)pt.X);
                        array[0].Y = (float)((1.0 + num4) * (double)pointF.Y - num4 * (double)pt.Y);
                        double num5;
                        if (node2.Turn == TurnValue.Left)
                        {
                            num5 = -90.0;
                        }
                        else if (node2.Turn == TurnValue.Right)
                        {
                            num5 = 90.0;
                        }
                        else
                        {
                            num5 = 0.0;
                        }
                        Matrix matrix = new Matrix();
                        matrix.RotateAt((float)num5, pointF, MatrixOrder.Prepend);
                        matrix.TransformPoints(array);
                        PointF[] array2 = array;
                        PointF[] arg_287_0 = array2;
                        int num6 = 0;
                        num2 = arg_287_0[num6].X;
                        PointF[] array3 = array;
                        PointF[] arg_2A0_0 = array3;
                        int num7 = 0;
                        num = arg_2A0_0[num7].Y;
                        pMap.ConvertCoord(ref num2, ref num, ref node2.C.x, ref node2.C.y, ConversionConstants.miScreenToMap);
                        array3[num7].Y = num;
                        array2[num6].X = num2;
                        node2.hdgCD = modHuanLuyen.GetHDG2(array[0], pointF);
                        double num8 = pMap.Distance(d2.x, d2.y, node2.C.x, node2.C.y);
                        if (num8 >= node2.R)
                        {
                            double d3 = node2.R / num8;
                            if (node2.Turn == TurnValue.Left)
                            {
                                node2.yp = modHuanLuyen.HieuChinhGoc(node2.hdgCD - modHuanLuyen.GetHDG2(array[0], pointF2) - Math.Acos(d3) * 57.29578);
                                if (node2.yp > 359.0)
                                {
                                    node2.yp = 0.0;
                                }
                                num5 = -node2.yp;
                            }
                            else if (node2.Turn == TurnValue.Right)
                            {
                                node2.yp = modHuanLuyen.HieuChinhGoc(modHuanLuyen.GetHDG2(array[0], pointF2) - node2.hdgCD - Math.Acos(d3) * 57.29578);
                                if (node2.yp > 359.0)
                                {
                                    node2.yp = 0.0;
                                }
                                num5 = node2.yp;
                            }
                            else
                            {
                                num5 = 0.0;
                            }
                            PointF[] array4 = new PointF[1];
                            array4[0].X = pointF.X;
                            array4[0].Y = pointF.Y;
                            matrix = new Matrix();
                            matrix.RotateAt((float)num5, array[0], MatrixOrder.Prepend);
                            matrix.TransformPoints(array4);
                            array3 = array4;
                            PointF[] arg_4A0_0 = array3;
                            num7 = 0;
                            num2 = arg_4A0_0[num7].X;
                            array2 = array4;
                            PointF[] arg_4B9_0 = array2;
                            num6 = 0;
                            num = arg_4B9_0[num6].Y;
                            pMap.ConvertCoord(ref num2, ref num, ref node2.Dp.x, ref node2.Dp.y, ConversionConstants.miScreenToMap);
                            array2[num6].Y = num;
                            array3[num7].X = num2;
                        }
                    }
                }
                CBasePath.TinhSecs(pMap, node2, pnode3);
            }
            catch (Exception expr_50D)
            {
                throw expr_50D;
            }
        }
        private static void TinhYToVong1NodeQuanhDiem(AxMap pMap, PathNode pnode1, PathNode pnode3, PathNode node2)
        {
            node2.yp = 0.0;
            node2.D.x = node2.C.x;
            node2.D.y = node2.C.y;
            node2.Dp.x = node2.C.x;
            node2.Dp.y = node2.C.y;
            node2.R = CBasePath.GetRadius(node2.Speed, node2.Roll);
            PointF pointF = default(PointF);
            float num = pointF.X;
            float num2 = pointF.Y;
            pMap.ConvertCoord(ref num, ref num2, ref node2.C.x, ref node2.C.y, ConversionConstants.miMapToScreen);
            pointF.Y = num2;
            pointF.X = num;
            MapPoint mapPoint = new MapPoint(node2.C.x, node2.C.y);
            mapPoint.h = node2.C.h;
            double num3 = pMap.Distance(pnode1.C.x, pnode1.C.y, node2.C.x, node2.C.y);
            double num4;
            if (pnode1.Turn == node2.Turn)
            {
                num4 = (node2.R - pnode1.R) / num3;
            }
            else
            {
                num4 = (node2.R + pnode1.R) / num3;
            }
            if (num4 <= 1.0)
            {
                double num5 = modHuanLuyen.HieuChinhGoc(Math.Asin(num4) * 57.29578 + 90.0);
                double num6;
                if (node2.Turn == TurnValue.Left)
                {
                    num6 = num5;
                }
                else if (node2.Turn == TurnValue.Right)
                {
                    num6 = -num5;
                }
                else
                {
                    num6 = 0.0;
                }
                PointF pointF2 = default(PointF);
                double num7 = node2.R / num3;
                pointF2.X = (float)((1.0 + num7) * node2.C.x - num7 * pnode1.C.x);
                pointF2.Y = (float)((1.0 + num7) * node2.C.y - num7 * pnode1.C.y);
                PointF[] array = new PointF[1];
                PointF[] array2 = array;
                PointF[] arg_25F_0 = array2;
                int num8 = 0;
                num2 = arg_25F_0[num8].X;
                PointF[] array3 = array;
                PointF[] arg_278_0 = array3;
                int num9 = 0;
                num = arg_278_0[num9].Y;
                double num10 = (double)pointF2.X;
                double num11 = (double)pointF2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref num10, ref num11, ConversionConstants.miMapToScreen);
                pointF2.Y = (float)num11;
                pointF2.X = (float)num10;
                array3[num9].Y = num;
                array2[num8].X = num2;
                Matrix matrix = new Matrix();
                matrix.RotateAt((float)num6, pointF, MatrixOrder.Prepend);
                matrix.TransformPoints(array);
                array3 = array;
                PointF[] arg_300_0 = array3;
                num9 = 0;
                num2 = arg_300_0[num9].X;
                array2 = array;
                PointF[] arg_319_0 = array2;
                num8 = 0;
                num = arg_319_0[num8].Y;
                pMap.ConvertCoord(ref num2, ref num, ref mapPoint.x, ref mapPoint.y, ConversionConstants.miScreenToMap);
                array2[num8].Y = num;
                array3[num9].X = num2;
            }
            node2.D.x = mapPoint.x;
            node2.D.y = mapPoint.y;
            node2.D.h = mapPoint.h;
            try
            {
                MapPoint d = node2.D;
                MapPoint dp = pnode1.Dp;
                MapPoint d2 = pnode3.D;
                PointF pt = default(PointF);
                num2 = pt.X;
                num = pt.Y;
                pMap.ConvertCoord(ref num2, ref num, ref dp.x, ref dp.y, ConversionConstants.miMapToScreen);
                pt.Y = num;
                pt.X = num2;
                PointF pointF3 = default(PointF);
                num2 = pointF3.X;
                num = pointF3.Y;
                pMap.ConvertCoord(ref num2, ref num, ref d.x, ref d.y, ConversionConstants.miMapToScreen);
                pointF3.Y = num;
                pointF3.X = num2;
                PointF pointF4 = default(PointF);
                num2 = pointF4.X;
                num = pointF4.Y;
                pMap.ConvertCoord(ref num2, ref num, ref d2.x, ref d2.y, ConversionConstants.miMapToScreen);
                pointF4.Y = num;
                pointF4.X = num2;
                if (node2.Turn == TurnValue.None)
                {
                    node2.Turn = CBasePath.getTurn(pt, pointF3, pointF4);
                }
                node2.hdgCD = modHuanLuyen.GetHDG2(pointF, pointF3);
                node2.Dp.x = node2.D.x;
                node2.Dp.y = node2.D.y;
                double num12 = pMap.Distance(d2.x, d2.y, node2.C.x, node2.C.y);
                if (num12 >= node2.R)
                {
                    double d3 = node2.R / num12;
                    double num13;
                    if (node2.Turn == TurnValue.Left)
                    {
                        node2.yp = modHuanLuyen.HieuChinhGoc(node2.hdgCD - modHuanLuyen.GetHDG2(pointF, pointF4) - Math.Acos(d3) * 57.29578);
                        if (node2.yp > 359.0)
                        {
                            node2.yp = 0.0;
                        }
                        num13 = -node2.yp;
                    }
                    else if (node2.Turn == TurnValue.Right)
                    {
                        node2.yp = modHuanLuyen.HieuChinhGoc(modHuanLuyen.GetHDG2(pointF, pointF4) - node2.hdgCD - Math.Acos(d3) * 57.29578);
                        if (node2.yp > 359.0)
                        {
                            node2.yp = 0.0;
                        }
                        num13 = node2.yp;
                    }
                    else
                    {
                        num13 = 0.0;
                    }
                    PointF[] array4 = new PointF[1];
                    array4[0].X = pointF3.X;
                    array4[0].Y = pointF3.Y;
                    Matrix matrix2 = new Matrix();
                    matrix2.RotateAt((float)num13, pointF, MatrixOrder.Prepend);
                    matrix2.TransformPoints(array4);
                    PointF[] array3 = array4;
                    PointF[] arg_64E_0 = array3;
                    int num9 = 0;
                    num2 = arg_64E_0[num9].X;
                    PointF[] array2 = array4;
                    PointF[] arg_667_0 = array2;
                    int num8 = 0;
                    num = arg_667_0[num8].Y;
                    pMap.ConvertCoord(ref num2, ref num, ref node2.Dp.x, ref node2.Dp.y, ConversionConstants.miScreenToMap);
                    array2[num8].Y = num;
                    array3[num9].X = num2;
                }
                CBasePath.TinhSecs(pMap, node2, pnode3);
            }
            catch (Exception expr_6BB)
            {
                throw expr_6BB;
            }
        }
        private static void TinhYToVong1NodeHuongDiem(AxMap pMap, PathNode pnode1, PathNode pnode3, PathNode node2)
        {
            node2.yp = 0.0;
            node2.D.x = node2.Dp.x;
            node2.D.y = node2.Dp.y;
            node2.C.x = node2.Dp.x;
            node2.C.y = node2.Dp.y;
            node2.R = CBasePath.GetRadius(node2.Speed, node2.Roll);
            MapPoint mapPoint = new MapPoint(node2.Dp.x, node2.Dp.y);
            PointF pointF = default(PointF);
            float num = pointF.X;
            float num2 = pointF.Y;
            pMap.ConvertCoord(ref num, ref num2, ref node2.Dp.x, ref node2.Dp.y, ConversionConstants.miMapToScreen);
            pointF.Y = num2;
            pointF.X = num;
            PointF pt = default(PointF);
            num2 = pt.X;
            num = pt.Y;
            pMap.ConvertCoord(ref num2, ref num, ref pnode3.D.x, ref pnode3.D.y, ConversionConstants.miMapToScreen);
            pt.Y = num;
            pt.X = num2;
            double num3 = pMap.Distance(pnode3.D.x, pnode3.D.y, node2.Dp.x, node2.Dp.y);
            double num4 = node2.R / num3;
            PointF[] array = new PointF[1];
            array[0].X = (float)((1.0 + num4) * (double)pointF.X - num4 * (double)pt.X);
            array[0].Y = (float)((1.0 + num4) * (double)pointF.Y - num4 * (double)pt.Y);
            double num5;
            if (node2.Turn == TurnValue.Left)
            {
                num5 = 90.0;
            }
            else if (node2.Turn == TurnValue.Right)
            {
                num5 = -90.0;
            }
            else
            {
                num5 = 0.0;
            }
            Matrix matrix = new Matrix();
            matrix.RotateAt((float)num5, pointF, MatrixOrder.Prepend);
            matrix.TransformPoints(array);
            PointF[] array2 = array;
            PointF[] arg_243_0 = array2;
            int num6 = 0;
            num2 = arg_243_0[num6].X;
            PointF[] array3 = array;
            PointF[] arg_25C_0 = array3;
            int num7 = 0;
            num = arg_25C_0[num7].Y;
            pMap.ConvertCoord(ref num2, ref num, ref mapPoint.x, ref mapPoint.y, ConversionConstants.miScreenToMap);
            array3[num7].Y = num;
            array2[num6].X = num2;
            node2.C.x = mapPoint.x;
            node2.C.y = mapPoint.y;
            MapPoint mapPoint2 = new MapPoint(node2.Dp.x, node2.Dp.y);
            mapPoint2.h = node2.Dp.h;
            double num8 = pMap.Distance(pnode1.C.x, pnode1.C.y, node2.C.x, node2.C.y);
            double num9;
            if (pnode1.Turn == node2.Turn)
            {
                num9 = (node2.R - pnode1.R) / num8;
            }
            else
            {
                num9 = (node2.R + pnode1.R) / num8;
            }
            if (num9 <= 1.0)
            {
                double num10 = modHuanLuyen.HieuChinhGoc(Math.Asin(num9) * 57.29578 + 90.0);
                if (node2.Turn == TurnValue.Left)
                {
                    num5 = num10;
                }
                else if (node2.Turn == TurnValue.Right)
                {
                    num5 = -num10;
                }
                else
                {
                    num5 = 0.0;
                }
                PointF pointF2 = default(PointF);
                double num11 = node2.R / num8;
                pointF2.X = (float)((1.0 + num11) * node2.C.x - num11 * pnode1.C.x);
                pointF2.Y = (float)((1.0 + num11) * node2.C.y - num11 * pnode1.C.y);
                PointF[] array4 = new PointF[1];
                array3 = array4;
                PointF[] arg_439_0 = array3;
                num7 = 0;
                num2 = arg_439_0[num7].X;
                array2 = array4;
                PointF[] arg_452_0 = array2;
                num6 = 0;
                num = arg_452_0[num6].Y;
                double num12 = (double)pointF2.X;
                double num13 = (double)pointF2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref num12, ref num13, ConversionConstants.miMapToScreen);
                pointF2.Y = (float)num13;
                pointF2.X = (float)num12;
                array2[num6].Y = num;
                array3[num7].X = num2;
                matrix = new Matrix();
                matrix.RotateAt((float)num5, array[0], MatrixOrder.Prepend);
                matrix.TransformPoints(array4);
                array3 = array4;
                PointF[] arg_4E5_0 = array3;
                num7 = 0;
                num2 = arg_4E5_0[num7].X;
                array2 = array4;
                PointF[] arg_4FE_0 = array2;
                num6 = 0;
                num = arg_4FE_0[num6].Y;
                pMap.ConvertCoord(ref num2, ref num, ref mapPoint2.x, ref mapPoint2.y, ConversionConstants.miScreenToMap);
                array2[num6].Y = num;
                array3[num7].X = num2;
            }
            node2.D.x = mapPoint2.x;
            node2.D.y = mapPoint2.y;
            node2.D.h = mapPoint2.h;
            try
            {
                MapPoint d = node2.D;
                MapPoint dp = pnode1.Dp;
                PointF pt2 = default(PointF);
                num2 = pt2.X;
                num = pt2.Y;
                pMap.ConvertCoord(ref num2, ref num, ref dp.x, ref dp.y, ConversionConstants.miMapToScreen);
                pt2.Y = num;
                pt2.X = num2;
                PointF pointF3 = default(PointF);
                num2 = pointF3.X;
                num = pointF3.Y;
                pMap.ConvertCoord(ref num2, ref num, ref d.x, ref d.y, ConversionConstants.miMapToScreen);
                pointF3.Y = num;
                pointF3.X = num2;
                if (node2.Turn == TurnValue.None)
                {
                    node2.Turn = CBasePath.getTurn(pt2, pointF3, pt);
                }
                node2.hdgCD = modHuanLuyen.GetHDG2(array[0], pointF3);
                if (node2.Turn == TurnValue.Left)
                {
                    node2.yp = modHuanLuyen.HieuChinhGoc(node2.hdgCD - modHuanLuyen.GetHDG2(array[0], pointF));
                }
                else if (node2.Turn == TurnValue.Right)
                {
                    node2.yp = modHuanLuyen.HieuChinhGoc(modHuanLuyen.GetHDG2(array[0], pointF) - node2.hdgCD);
                }
                CBasePath.TinhSecs(pMap, node2, pnode3);
            }
            catch (Exception expr_6BA)
            {
                throw expr_6BA;
            }
        }
        public void TinhYToLuonVong(AxMap pMap)
        {
            int arg_0F_0 = 0;
            checked
            {
                int num = this.Path.Count - 1;
                for (int i = arg_0F_0; i <= num; i++)
                {
                    PathNode prevNode = this.getPrevNode(i);
                    PathNode nextNode = this.getNextNode(i);
                    CBasePath.TinhYToVong1Node(pMap, prevNode, nextNode, this.Path[i]);
                }
            }
        }
        public void TinhYToVong1Node(AxMap pMap, int ibutnode)
        {
            PathNode prevNode = this.getPrevNode(ibutnode);
            PathNode nextNode = this.getNextNode(ibutnode);
            CBasePath.TinhYToVong1Node(pMap, prevNode, nextNode, this.Path[ibutnode]);
        }
        private static double GetRadius(double pSpeed, float pRoll)
        {
            double result = 0.0;
            double num = Math.Tan((double)pRoll * 0.0174532925);
            if (num != 0.0)
            {
                double num2 = pSpeed / 10.0 * (0.89 / num);
                result = num2 * 0.09 * pSpeed;
            }
            return result;
        }
        public static MapPoint GetFromHeading(AxMap pMap, MapPoint MapPt2, double heading, double mBanKinh)
        {
            MapPoint result = new MapPoint(0.0, 0.0);
            try
            {
                PointF point = default(PointF);
                float num = point.X;
                float num2 = point.Y;
                pMap.ConvertCoord(ref num, ref num2, ref MapPt2.x, ref MapPt2.y, ConversionConstants.miMapToScreen);
                point.Y = num2;
                point.X = num;
                double num3 = pMap.Distance(MapPt2.x, MapPt2.y, MapPt2.x, MapPt2.y + 10.0) / 1000.0;
                MapPoint mapPoint = new MapPoint(MapPt2.x, MapPt2.y + mBanKinh * 10.0 / num3);
                PointF[] array = new PointF[1];
                PointF[] array2 = array;
                PointF[] arg_CC_0 = array2;
                int num4 = 0;
                num2 = arg_CC_0[num4].X;
                PointF[] array3 = array;
                PointF[] arg_E4_0 = array3;
                int num5 = 0;
                num = arg_E4_0[num5].Y;
                pMap.ConvertCoord(ref num2, ref num, ref mapPoint.x, ref mapPoint.y, ConversionConstants.miMapToScreen);
                array3[num5].Y = num;
                array2[num4].X = num2;
                Matrix matrix = new Matrix();
                matrix.RotateAt((float)heading, point, MatrixOrder.Prepend);
                matrix.TransformPoints(array);
                array3 = array;
                PointF[] arg_14C_0 = array3;
                num5 = 0;
                num2 = arg_14C_0[num5].X;
                array2 = array;
                PointF[] arg_164_0 = array2;
                num4 = 0;
                num = arg_164_0[num4].Y;
                pMap.ConvertCoord(ref num2, ref num, ref result.x, ref result.y, ConversionConstants.miScreenToMap);
                array2[num4].Y = num;
                array3[num5].X = num2;
            }
            catch (Exception expr_1A8)
            {
                throw expr_1A8;
            }
            return result;
        }
        public static void TinhSecs(AxMap pMap, PathNode fromNode, PathNode toNode)
        {
            double num = (fromNode.Speed + toNode.Speed) / 7.2;
            if (num > 0.0)
            {
                double num2 = 3.1415926535897931 * fromNode.R * fromNode.yp / 180.0;
                double num3 = pMap.Distance(fromNode.Dp.x, fromNode.Dp.y, toNode.D.x, toNode.D.y);
                double num4 = toNode.D.h - fromNode.D.h;
                double num5 = fromNode.Speed / 3.6;
                double num6 = toNode.Speed / 3.6;
                double num7 = Math.Sqrt(num3 * num3 + num4 * num4);
                if (num5 > 0.0 & num6 > 0.0)
                {
                    double num8;
                    if (num5 != num6)
                    {
                        if (fromNode.tspeed <= 0.0)
                        {
                            fromNode.tspeed = (double)modHuanLuyen.TgThayDoiTocDo;
                        }
                        num8 = fromNode.tspeed * num;
                    }
                    else
                    {
                        fromNode.tspeed = 0.0;
                        num8 = 0.0;
                    }
                    double num9 = num7 - num8;
                    if (num9 < 0.0)
                    {
                        num9 = 0.0;
                    }
                    fromNode.typ = num2 / num5;
                    fromNode.t2next = num9 / num6;
                }
                else if (num6 == 0.0)
                {
                    double num8 = num7;
                    if (num8 < 0.0)
                    {
                        num8 = 0.0;
                    }
                    fromNode.typ = num2 / num5;
                    fromNode.tspeed = num8 / num;
                    fromNode.t2next = 0.0;
                }
                else
                {
                    fromNode.typ = 0.0;
                    fromNode.tspeed = num7 / num;
                    fromNode.t2next = 0.0;
                }
            }
        }
        public static double getdistance(PointF pPt1, PointF pPt2)
        {
            double num = (double)(pPt2.X - pPt1.X);
            double num2 = (double)(pPt2.Y - pPt1.Y);
            return Math.Sqrt(num * num + num2 * num2);
        }
    }
}