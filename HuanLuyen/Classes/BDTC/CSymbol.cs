using AxMapXLib;
using DBiGraphicObjs.DBiGraphicObjects;
using MapXLib;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace HuanLuyen
{
    [Serializable]
    public class CSymbol
    {
        private double m_GocX = 0;
        private double m_GocY = 0;
        private double m_Zoom = 0;
        private float m_MWidth = 0;
        private CGraphicObjs m_GObjs;
        private string m_Description;
        private bool m_Blinking;
        public float Heading = 0;
        public bool Blinking
        {
            get
            {
                return this.m_Blinking;
            }
            set
            {
                this.m_Blinking = value;
            }
        }
        public string Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }
        public double GocX
        {
            get
            {
                return this.m_GocX;
            }
            set
            {
                this.m_GocX = value;
            }
        }
        public double GocY
        {
            get
            {
                return this.m_GocY;
            }
            set
            {
                this.m_GocY = value;
            }
        }
        public CGraphicObjs GObjs
        {
            get
            {
                return this.m_GObjs;
            }
            set
            {
                this.m_GObjs = value;
            }
        }
        public double Zoom
        {
            get
            {
                return this.m_Zoom;
            }
            set
            {
                this.m_Zoom = value;
            }
        }
        public float MWidth
        {
            get
            {
                return this.m_MWidth;
            }
            set
            {
                this.m_MWidth = value;
            }
        }
        public override string ToString()
        {
            return this.m_Description;
        }
        public void Draw(AxMap pMap, Graphics g)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float dx = 0;
            float dy = 0;
            pMap.ConvertCoord(ref dx, ref dy, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(dx, dy);
            g.RotateTransform(this.Heading);
            g.ScaleTransform(num, num);
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                graphicObject.Draw(g);
            }

            g.EndContainer(container);
        }
        public void DanhDau(AxMap pMap, Graphics g, Color Color)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1);
            float dx = 0;
            float dy = 0;
            pMap.ConvertCoord(ref dx, ref dy, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(dx, dy);
            g.RotateTransform(this.Heading);
            g.ScaleTransform(num, num);
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                graphicObject.DanhDau(g, Color);
            }

            g.EndContainer(container);
        }
        public void DanhDau(AxMap pMap, Graphics g, Pen Pen)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float dx = 0;
            float dy = 0;
            pMap.ConvertCoord(ref dx, ref dy, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(dx, dy);
            g.RotateTransform(this.Heading);
            g.ScaleTransform(num, num);
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                graphicObject.DanhDau(g, Pen);
            }

            g.EndContainer(container);
        }
        public void DanhDau(AxMap pMap, Graphics g, GraphicObject pObj, Color Color)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1);
            float dx = 0;
            float dy = 0;
            pMap.ConvertCoord(ref dx, ref dy, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(dx, dy);
            g.RotateTransform(this.Heading);
            g.ScaleTransform(num, num);
            pObj.DanhDau(g, Color);
            g.EndContainer(container);
        }
        public System.Drawing.Rectangle GetBounds(AxMap pMap)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float offsetX = 0;
            float offsetY = 0;
            pMap.ConvertCoord(ref offsetX, ref offsetY, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            Matrix matrix = new Matrix();
            matrix.Translate(offsetX, offsetY);
            matrix.Rotate(this.Heading);
            matrix.Scale(num, num);
            float left = 0;
            float top = 0;
            float right = 0;
            float bottom = 0;
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                RectangleF bounds = graphicObject.GetBounds();
                if (bounds.Left < left)
                {
                    left = bounds.Left;
                }
                if (bounds.Top < top)
                {
                    top = bounds.Top;
                }
                if (bounds.Right > right)
                {
                    right = bounds.Right;
                }
                if (bounds.Bottom > bottom)
                {
                    bottom = bounds.Bottom;
                }
            }

            PointF[] array = new PointF[4];
            array[0] = new PointF(left, top);
            array[1] = new PointF(right, top);
            array[2] = new PointF(right, bottom);
            array[3] = new PointF(left, bottom);
            matrix.TransformPoints(array);
            matrix.Dispose();
            PointF[] array2 = new PointF[2];
            array2[0].X = Math.Min(Math.Min(Math.Min(array[0].X, array[1].X), array[2].X), array[3].X);
            array2[0].Y = Math.Min(Math.Min(Math.Min(array[0].Y, array[1].Y), array[2].Y), array[3].Y);
            array2[1].X = Math.Max(Math.Max(Math.Max(array[0].X, array[1].X), array[2].X), array[3].X);
            array2[1].Y = Math.Max(Math.Max(Math.Max(array[0].Y, array[1].Y), array[2].Y), array[3].Y);
            System.Drawing.Rectangle result = checked(new System.Drawing.Rectangle((int)Math.Round((double)array2[0].X), (int)Math.Round((double)array2[0].Y), (int)Math.Round((double)unchecked(array2[1].X - array2[0].X)), (int)Math.Round((double)unchecked(array2[1].Y - array2[0].Y))));
            return result;
        }
        public void VeBound(AxMap pMap, Graphics g, Color Color)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float dx = 0;
            float dy = 0;
            pMap.ConvertCoord(ref dx, ref dy, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(dx, dy);
            g.RotateTransform(this.Heading);
            g.ScaleTransform(num, num);
            float left = 0;
            float top = 0;
            float right = 0;
            float bottom = 0;
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                RectangleF bounds = graphicObject.GetBounds();
                if (bounds.Left < left)
                {
                    left = bounds.Left;
                }
                if (bounds.Top < top)
                {
                    top = bounds.Top;
                }
                if (bounds.Right > right)
                {
                    right = bounds.Right;
                }
                if (bounds.Bottom > bottom)
                {
                    bottom = bounds.Bottom;
                }
            }

            Pen pen = new Pen(Color.Black);
            pen.DashStyle = DashStyle.Dot;
            pen.Width = 2f;
            pen.Color = Color.White;
            Pen arg_181_1 = pen;
            checked
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle((int)Math.Round((double)left), (int)Math.Round((double)top), (int)Math.Round((double)unchecked(right - left)), (int)Math.Round((double)unchecked(bottom - top)));
                g.DrawRectangle(arg_181_1, rect);
                pen.Width = 1f;
                pen.Color = Color;
                Pen arg_1D1_1 = pen;
                rect = new System.Drawing.Rectangle((int)Math.Round((double)left), (int)Math.Round((double)top), (int)Math.Round((double)unchecked(right - left)), (int)Math.Round((double)unchecked(bottom - top)));
                g.DrawRectangle(arg_1D1_1, rect);
                pen.Dispose();
                g.EndContainer(container);
            }
        }
        public void VeBound(AxMap pMap, Graphics g, GraphicObject pObj, Color Color)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float dx = 0;
            float dy = 0;
            pMap.ConvertCoord(ref dx, ref dy, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(dx, dy);
            g.RotateTransform(this.Heading);
            g.ScaleTransform(num, num);
            pObj.VeBound(g, Color);
            g.EndContainer(container);
        }
        public void DrawNodes(AxMap pMap, Graphics g)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float dx = 0;
            float dy = 0;
            pMap.ConvertCoord(ref dx, ref dy, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            GraphicsContainer container = g.BeginContainer();
            g.TranslateTransform(dx, dy);
            g.RotateTransform(this.Heading);
            g.ScaleTransform(num, num);
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                PointF[] points = graphicObject.GetPoints();
                modBdTC.DrawNodes(g, points, 3f);
            }

            g.EndContainer(container);
        }
        public void DrawRoot(AxMap pMap, Graphics g)
        {
            float num = 0;
            float num2 = 0;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            Pen pen = new Pen(Color.Black, 2f);
            System.Drawing.Rectangle rect = checked(new System.Drawing.Rectangle((int)Math.Round((double)unchecked(num - 3f)), (int)Math.Round((double)unchecked(num2 - 3f)), 7, 7));
            g.DrawRectangle(pen, rect);
            pen.Dispose();
        }
        public bool HitTest(AxMap pMap, PointF pt)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float num2 = 0;
            float num3 = 0;
            pMap.ConvertCoord(ref num2, ref num3, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            Matrix matrix = new Matrix();
            matrix.Translate(-num2, -num3, MatrixOrder.Append);
            matrix.Rotate(-this.Heading, MatrixOrder.Append);
            matrix.Scale(1f / num, 1f / num, MatrixOrder.Append);
            PointF[] array = new PointF[]
{
pt
};
            matrix.TransformPoints(array);
            PointF pt2 = new PointF(array[0].X, array[0].Y);
            checked
            {
                if (this.m_GObjs.Count > 0)
                {
                    for (int i = this.m_GObjs.Count - 1; i >= 0; i += -1)
                    {
                        GraphicObject graphicObject = this.m_GObjs[i];
                        if (graphicObject.HitTest(pt2))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        public bool HitTest(AxMap pMap, RectangleF rect)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float num2 = 0;
            float num3 = 0;
            pMap.ConvertCoord(ref num2, ref num3, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            Matrix matrix = new Matrix();
            matrix.Translate(-num2, -num3, MatrixOrder.Append);
            matrix.Rotate(-this.Heading, MatrixOrder.Append);
            matrix.Scale(1f / num, 1f / num, MatrixOrder.Append);
            PointF[] array = new PointF[2];
            array[0] = new PointF(rect.Left, rect.Top);
            array[1] = new PointF(rect.Left + rect.Width, rect.Top + rect.Height);
            matrix.TransformPoints(array);
            RectangleF rect2 = new RectangleF(array[0].X, array[0].Y, array[1].X - array[0].X, array[1].Y - array[0].Y);
            checked
            {
                if (this.m_GObjs.Count > 0)
                {
                    for (int i = this.m_GObjs.Count - 1; i >= 0; i += -1)
                    {
                        GraphicObject graphicObject = this.m_GObjs[i];
                        if (!graphicObject.HitTest(rect2))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        public GraphicObject FindObjectAtPoint(AxMap pMap, PointF pt)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float num2 = 0;
            float num3 = 0;
            pMap.ConvertCoord(ref num2, ref num3, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            Matrix matrix = new Matrix();
            matrix.Translate(-num2, -num3, MatrixOrder.Append);
            matrix.Rotate(-this.Heading, MatrixOrder.Append);
            matrix.Scale(1f / num, 1f / num, MatrixOrder.Append);
            PointF[] array = new PointF[]
{
pt
};
            matrix.TransformPoints(array);
            PointF pt2 = new PointF(array[0].X, array[0].Y);
            return this.m_GObjs.FindObjectAtPoint(pt2);
        }
        public void MoveNodeTo(AxMap pMap, CFOUNDNODE ENode, PointF pt)
        {
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float num2 = 0;
            float num3 = 0;
            pMap.ConvertCoord(ref num2, ref num3, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            Matrix matrix = new Matrix();
            GraphicObject foundObject = ENode.FoundObject;
            matrix.Translate(-num2, -num3, MatrixOrder.Append);
            matrix.Rotate(-this.Heading, MatrixOrder.Append);
            matrix.Scale(1f / num, 1f / num, MatrixOrder.Append);
            PointF[] array = new PointF[]
{
pt
};
            matrix.TransformPoints(array);
            PointF pt2 = new PointF(array[0].X, array[0].Y);
            foundObject.MoveNodeTo(ENode.NodeIndex, pt2);
        }
        public bool Noi2Objs(CFOUNDNODE pFoundNode)
        {
            bool result = false;
            checked
            {
                if (pFoundNode.FoundObject.GetObjType() == OBJECTTYPE.Curve | pFoundNode.FoundObject.GetObjType() == OBJECTTYPE.Line)
                {
                    NodesShapeGraphic nodesShapeGraphic = (NodesShapeGraphic)pFoundNode.FoundObject;
                    if (pFoundNode.NodeIndex == 0 | pFoundNode.NodeIndex == nodesShapeGraphic.Nodes.Count - 1)
                    {
                        CFOUNDNODE cFOUNDNODE = this.Tim2ndNode(pFoundNode);
                        if (pFoundNode.NodeIndex == 0)
                        {
                            nodesShapeGraphic.ReverseNodes();
                        }
                        if (cFOUNDNODE.NodeIndex == 0)
                        {
                            NodesShapeGraphic nodesShapeGraphic2 = (NodesShapeGraphic)cFOUNDNODE.FoundObject;
                            if (nodesShapeGraphic2.Nodes.Count > 1)
                            {
                                int arg_A1_0 = 1;
                                int num = nodesShapeGraphic2.Nodes.Count - 1;
                                for (int i = arg_A1_0; i <= num; i++)
                                {
                                    nodesShapeGraphic.Nodes.Add(nodesShapeGraphic2.Nodes[i]);
                                }
                            }
                            this.m_GObjs.Remove(cFOUNDNODE.FoundObject);
                            result = true;
                        }
                        else if (cFOUNDNODE.NodeIndex > 0)
                        {
                            NodesShapeGraphic nodesShapeGraphic3 = (NodesShapeGraphic)cFOUNDNODE.FoundObject;
                            if (nodesShapeGraphic3.Nodes.Count > 1)
                            {
                                for (int j = nodesShapeGraphic3.Nodes.Count - 2; j >= 0; j += -1)
                                {
                                    nodesShapeGraphic.Nodes.Add(nodesShapeGraphic3.Nodes[j]);
                                }
                            }
                            this.m_GObjs.Remove(cFOUNDNODE.FoundObject);
                            result = true;
                        }
                    }
                }
                return result;
            }
        }
        private CFOUNDNODE Tim2ndNode(CFOUNDNODE pFoundNode)
        {
            CFOUNDNODE cFOUNDNODE = new CFOUNDNODE();
            cFOUNDNODE.NodeIndex = -1;
            checked
            {
                foreach (GraphicObject graphicObject in this.m_GObjs)
                {
                    if ((graphicObject.GetObjType() == OBJECTTYPE.Curve | graphicObject.GetObjType() == OBJECTTYPE.Line) && graphicObject != pFoundNode.FoundObject)
                    {
                        NodesShapeGraphic nodesShapeGraphic = (NodesShapeGraphic)graphicObject;
                        NodesShapeGraphic nodesShapeGraphic2 = (NodesShapeGraphic)pFoundNode.FoundObject;
                        if (nodesShapeGraphic.Nodes[0].X == nodesShapeGraphic2.Nodes[pFoundNode.NodeIndex].X & nodesShapeGraphic.Nodes[0].Y == nodesShapeGraphic2.Nodes[pFoundNode.NodeIndex].Y)
                        {
                            cFOUNDNODE.FoundObject = graphicObject;
                            cFOUNDNODE.NodeIndex = 0;
                        }
                        else if (nodesShapeGraphic.Nodes[nodesShapeGraphic.Nodes.Count - 1].X == nodesShapeGraphic2.Nodes[pFoundNode.NodeIndex].X & nodesShapeGraphic.Nodes[nodesShapeGraphic.Nodes.Count - 1].Y == nodesShapeGraphic2.Nodes[pFoundNode.NodeIndex].Y)
                        {
                            cFOUNDNODE.FoundObject = graphicObject;
                            cFOUNDNODE.NodeIndex = nodesShapeGraphic.Nodes.Count - 1;
                        }
                    }
                }

                return cFOUNDNODE;
            }
        }
        public CFOUNDNODE FindNodeAtPoint(AxMap pMap, PointF pt)
        {
            CFOUNDNODE cFOUNDNODE = new CFOUNDNODE();
            float num = (float)(this.m_Zoom / pMap.Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? pMap.MapScreenWidth / this.m_MWidth : 1));
            float num2 = 0;
            float num3 = 0;
            pMap.ConvertCoord(ref num2, ref num3, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            Matrix matrix = new Matrix();
            matrix.Translate(-num2, -num3, MatrixOrder.Append);
            matrix.Rotate(-this.Heading, MatrixOrder.Append);
            matrix.Scale(1f / num, 1f / num, MatrixOrder.Append);
            PointF[] array = new PointF[]
{
pt
};
            matrix.TransformPoints(array);
            PointF pt2 = new PointF(array[0].X, array[0].Y);
            checked
            {
                for (int i = this.m_GObjs.Count - 1; i >= 0; i += -1)
                {
                    GraphicObject graphicObject = this.m_GObjs[i];
                    int num4 = graphicObject.FindNodeAtPoint(pt2, 4f);
                    if (num4 > -1)
                    {
                        int nodeIndex = num4;
                        cFOUNDNODE.FoundObject = graphicObject;
                        cFOUNDNODE.NodeIndex = nodeIndex;
                        return cFOUNDNODE;
                    }
                }
                return null;
            }
        }
        public bool RootHitTest(AxMap pMap, PointF pt)
        {
            float num = 0;
            float num2 = 0;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            RectangleF rectangleF = new RectangleF(num - 3f, num2 - 3f, 7f, 7f);
            return rectangleF.Contains(pt);
        }
        public void Move(AxMap pMap, PointF fromPt, PointF toPt)
        {
            float num = 0;
            float num2 = 0;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            num += toPt.X - fromPt.X;
            num2 += toPt.Y - fromPt.Y;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miScreenToMap);
        }
        public void Shift(AxMap pMap, float deltaX, float deltaY)
        {
            float num = 0;
            float num2 = 0;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            num += deltaX;
            num2 += deltaY;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miScreenToMap);
        }
        public void ChangeRoot(AxMap pMap, double newGocX, double newGocY)
        {
            float num = (float)(pMap.Zoom / this.m_Zoom);
            num = Convert.ToSingle(num * (this.m_MWidth > 0f ? this.m_MWidth / pMap.MapScreenWidth : 1));
            float num2 = 0;
            float num3 = 0;
            pMap.ConvertCoord(ref num2, ref num3, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            float num4 = 0;
            float num5 = 0;
            pMap.ConvertCoord(ref num4, ref num5, ref newGocX, ref newGocY, ConversionConstants.miMapToScreen);
            this.m_GocX = newGocX;
            this.m_GocY = newGocY;
            PointF toPt = new PointF(num2 * num, num3 * num);
            PointF fromPt = new PointF(num4 * num, num5 * num);
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                graphicObject.Move(fromPt, toPt);
            }

        }
        public void ChangeZoomMWidtht(double newZoom, float newMWidth)
        {
            checked
            {
                foreach (GraphicObject graphicObject in this.m_GObjs)
                {
                    PointF[] points = graphicObject.GetPoints();
                    float num = (float)(this.m_Zoom / newZoom);
                    num = Convert.ToSingle(num * (this.m_MWidth > 0f ? newMWidth / this.m_MWidth : 1));
                    Matrix matrix = new Matrix();
                    matrix.Reset();
                    matrix.Scale(num, num, MatrixOrder.Append);
                    matrix.TransformPoints(points);
                    int arg_8C_0 = 0;
                    int upperBound = points.GetUpperBound(0);
                    for (int i = arg_8C_0; i <= upperBound; i++)
                    {
                        graphicObject.MoveNodeTo(i, points[i]);
                    }
                }

                this.m_Zoom = newZoom;
                this.m_MWidth = newMWidth;
            }
        }
        public void Rotate(AxMap pMap, PointF rootPt, PointF fromPt, PointF toPt)
        {
            float num = 0;
            float num2 = 0;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            num -= rootPt.X;
            num2 -= rootPt.Y;
            PointF rootPt2 = default(PointF);
            rootPt2.X = num;
            rootPt2.Y = num2;
            fromPt.X -= rootPt.X;
            fromPt.Y -= rootPt.Y;
            toPt.X -= rootPt.X;
            toPt.Y -= rootPt.Y;
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                graphicObject.Rotate(rootPt2, fromPt, toPt);
            }

        }
        public void Rotate2(AxMap pMap, PointF rootPt, double degree)
        {
            float num = 0;
            float num2 = 0;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            num -= rootPt.X;
            num2 -= rootPt.Y;
            PointF rootPt2 = default(PointF);
            rootPt2.X = num;
            rootPt2.Y = num2;
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                graphicObject.Rotate2(rootPt2, degree);
            }

        }
        public void Scale(AxMap pMap, PointF rootPt, PointF fromPt, PointF toPt)
        {
            float num = 0;
            float num2 = 0;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            num -= rootPt.X;
            num2 -= rootPt.Y;
            PointF rootPt2 = default(PointF);
            rootPt2.X = num;
            rootPt2.Y = num2;
            fromPt.X -= rootPt.X;
            fromPt.Y -= rootPt.Y;
            toPt.X -= rootPt.X;
            toPt.Y -= rootPt.Y;
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                graphicObject.Zoom(rootPt2, fromPt, toPt);
            }

        }
        public void Scale2(AxMap pMap, PointF rootPt, float deltaX, float deltaY)
        {
            float num = 0;
            float num2 = 0;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            num -= rootPt.X;
            num2 -= rootPt.Y;
            PointF rootPt2 = default(PointF);
            rootPt2.X = num;
            rootPt2.Y = num2;
            System.Drawing.Rectangle bounds = this.GetBounds(pMap);
            float deltaX2 = ((float)bounds.Width + deltaX) / (float)bounds.Width;
            float deltaY2 = ((float)bounds.Height + deltaY) / (float)bounds.Height;
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                graphicObject.Zoom2(rootPt2, deltaX2, deltaY2);
            }

        }
        public void Scale3(AxMap pMap, PointF rootPt, float deltaX, float deltaY)
        {
            float num = 0;
            float num2 = 0;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miMapToScreen);
            num -= rootPt.X;
            num2 -= rootPt.Y;
            PointF rootPt2 = default(PointF);
            rootPt2.X = num;
            rootPt2.Y = num2;
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                graphicObject.Zoom2(rootPt2, deltaX, deltaY);
            }

        }
        public void VFlip()
        {
            RectangleF bounds = new RectangleF();
            foreach (GraphicObject graphicObject in this.m_GObjs)
            {
                bounds = graphicObject.GetBounds();
                float left = 0;
                if (bounds.Left < left)
                {
                    left = bounds.Left;
                }
                float top = 0;
                if (bounds.Top < top)
                {
                    top = bounds.Top;
                }
                float right = 0;
                if (bounds.Right > right)
                {
                    right = bounds.Right;
                }
                float bottom = 0;
                if (bounds.Bottom > bottom)
                {
                    bottom = bounds.Bottom;
                }
            }

            float pX = (bounds.Left + bounds.Right) / 2f;
            foreach (GraphicObject graphicObject2 in this.m_GObjs)
            {
                graphicObject2.VFlip(pX);
            }

        }
        protected CSymbol()
        {
            this.Heading = 0f;
        }
        public CSymbol(AxMap pMap, CGraphicObjs pGObjs)
            : this()
        {
            float num = 0f;
            float num2 = 0f;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miScreenToMap);
            this.m_Zoom = pMap.Zoom;
            this.m_MWidth = pMap.MapScreenWidth;
            this.m_GObjs = new CGraphicObjs();
            foreach (GraphicObject graphicObject in pGObjs)
            {
                this.m_GObjs.Add(graphicObject.Clone());
            }

            this.m_Description = "";
            this.m_Blinking = false;
        }
        public CSymbol(AxMap pMap, CGraphicObjs pGObjs, double pZoom, float pMWidth)
            : this()
        {
            float num = 0f;
            float num2 = 0f;
            pMap.ConvertCoord(ref num, ref num2, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miScreenToMap);
            this.m_Zoom = pZoom;
            this.m_MWidth = pMWidth;
            this.m_GObjs = new CGraphicObjs();
            foreach (GraphicObject graphicObject in pGObjs)
            {
                this.m_GObjs.Add(graphicObject.Clone());
            }

            this.m_Description = "";
            this.m_Blinking = false;
        }
        public CSymbol(AxMap pMap, PointF pt0, CGraphicObjs pGObjs)
            : this()
        {
            float x = pt0.X;
            float y = pt0.Y;
            pMap.ConvertCoord(ref x, ref y, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miScreenToMap);
            pt0.Y = y;
            pt0.X = x;
            this.m_Zoom = pMap.Zoom;
            this.m_MWidth = pMap.MapScreenWidth;
            this.m_GObjs = new CGraphicObjs();
            foreach (GraphicObject graphicObject in pGObjs)
            {
                this.m_GObjs.Add(graphicObject.Clone());
            }

            this.m_Description = "";
            this.m_Blinking = false;
        }
        public CSymbol(AxMap pMap, PointF pt0, CGraphicObjs pGObjs, float pMapScreenWidth)
            : this()
        {
            float x = pt0.X;
            float y = pt0.Y;
            pMap.ConvertCoord(ref x, ref y, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miScreenToMap);
            pt0.Y = y;
            pt0.X = x;
            this.m_Zoom = pMap.Zoom;
            this.m_MWidth = pMapScreenWidth;
            this.m_GObjs = new CGraphicObjs();
            foreach (GraphicObject graphicObject in pGObjs)
            {
                this.m_GObjs.Add(graphicObject.Clone());
            }

            this.m_Description = "";
            this.m_Blinking = false;
        }
        public CSymbol(AxMap pMap, PointF pt0, CGraphicObjs pGObjs, double pZoom, float pMWidth)
            : this()
        {
            float x = pt0.X;
            float y = pt0.Y;
            pMap.ConvertCoord(ref x, ref y, ref this.m_GocX, ref this.m_GocY, ConversionConstants.miScreenToMap);
            pt0.Y = y;
            pt0.X = x;
            this.m_Zoom = pZoom;
            this.m_MWidth = pMWidth;
            this.m_GObjs = new CGraphicObjs();
            foreach (GraphicObject graphicObject in pGObjs)
            {
                this.m_GObjs.Add(graphicObject.Clone());
            }

            this.m_Description = "";
            this.m_Blinking = false;
        }
        public CSymbol(string pDesc, double pZoom, float pMWidth, double pGocX, double pGocY, CGraphicObjs pGObjs)
            : this()
        {
            this.m_GocX = pGocX;
            this.m_GocY = pGocY;
            this.m_Zoom = pZoom;
            this.m_MWidth = pMWidth;
            this.m_GObjs = new CGraphicObjs();
            foreach (GraphicObject graphicObject in pGObjs)
            {
                this.m_GObjs.Add(graphicObject.Clone());
            }

            this.m_Description = pDesc;
            this.m_Blinking = false;
        }
        public CSymbol(string pDesc, bool pBlinking, double pZoom, float pMWidth, double pGocX, double pGocY, CGraphicObjs pGObjs, float pHeading)
            : this()
        {
            this.m_GocX = pGocX;
            this.m_GocY = pGocY;
            this.m_Zoom = pZoom;
            this.m_MWidth = pMWidth;
            this.m_GObjs = new CGraphicObjs();
            foreach (GraphicObject graphicObject in pGObjs)
            {
                this.m_GObjs.Add(graphicObject.Clone());
            }

            this.m_Description = pDesc;
            this.m_Blinking = pBlinking;
            this.Heading = pHeading;
        }
    }
}