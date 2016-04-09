using AxMapXLib;
using DBiGraphicObjs.DBiGraphicObjects;
using MapXLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using System.Xml;
namespace HuanLuyen
{
    [Serializable]
    public class CSymbols : CollectionBase
    {
        public int IndexOf(CSymbol aSymbol)
        {
            //[CONVERT FAIL]
            return this.List.IndexOf(aSymbol);
        }
        public int ListCount
        {
            get
            {
                return this.List.Count;
            }
        }
        public CSymbol this[int index]
        {
            get
            {
                return (CSymbol)this.List[index];
            }
        }
        public void Add(CSymbol aSymbol)
        {
            this.List.Add(aSymbol);
        }
        public void InsertAt(int index, CSymbol aSymbol)
        {
            if (index > this.Count | index < 0)
            {
                MessageBox.Show("Index not valid!");
            }
            else if (index == this.Count)
            {
                this.List.Add(aSymbol);
            }
            else
            {
                this.List.Insert(index, aSymbol);
            }
        }
        public void Remove(int index)
        {
            if (index > checked(this.Count - 1) | index < 0)
            {
                MessageBox.Show("Index not valid!");
            }
            else
            {
                this.List.RemoveAt(index);
            }
        }
        public void Remove(CSymbol aSymbol)
        {
            this.List.Remove(aSymbol);
        }
        public bool Contains(CSymbol value)
        {
            return this.List.Contains(value);
        }
        public CSymbol FindSymbolAtPoint(AxMap pMap, PointF pt)
        {
            checked
            {
                if (this.List != null && this.List.Count > 0)
                {
                    for (int i = this.List.Count - 1; i >= 0; i += -1)
                    {
                        CSymbol cSymbol = (CSymbol)this.List[i];
                        if (cSymbol.HitTest(pMap, pt))
                        {
                            return cSymbol;
                        }
                    }
                }
                return null;
            }
        }
        public List<CSymbol> FindSymbolsAtPoint(AxMap pMap, PointF pt)
        {
            List<CSymbol> list = new List<CSymbol>();
            checked
            {
                if (this.List != null && this.List.Count > 0)
                {
                    for (int i = this.List.Count - 1; i >= 0; i += -1)
                    {
                        CSymbol cSymbol = (CSymbol)this.List[i];
                        if (cSymbol.HitTest(pMap, pt))
                        {
                            list.Add(cSymbol);
                        }
                    }
                }
                return list;
            }
        }
        public CSymbol GetSymbolByName(string pName)
        {
            CSymbol result = null;
            checked
            {
                if (this.List != null && this.List.Count > 0)
                {
                    for (int i = this.List.Count - 1; i >= 0; i += -1)
                    {
                        CSymbol cSymbol = (CSymbol)this.List[i];
                        if (cSymbol.Description == pName)
                        {
                            result = cSymbol;
                            break;
                        }
                    }
                }
                return result;
            }
        }
        public CFOUNDOBJECT FindObjectAtPoint(AxMap pMap, PointF pt)
        {
            CFOUNDOBJECT cFOUNDOBJECT = new CFOUNDOBJECT();
            checked
            {
                if (this.List != null && this.List.Count > 0)
                {
                    for (int i = this.List.Count - 1; i >= 0; i += -1)
                    {
                        CSymbol cSymbol = (CSymbol)this.List[i];
                        GraphicObject graphicObject = cSymbol.FindObjectAtPoint(pMap, pt);
                        if (graphicObject != null)
                        {
                            cFOUNDOBJECT.FoundObject = graphicObject;
                            cFOUNDOBJECT.FoundSymbol = cSymbol;
                            return cFOUNDOBJECT;
                        }
                    }
                }
                return null;
            }
        }
        public void DrawSymbols(AxMap pMap, Graphics g)
        {
            checked
            {
                if (this.InnerList != null && this.InnerList.Count > 0)
                {
                    int arg_25_0 = 0;
                    int num = this.InnerList.Count - 1;
                    for (int i = arg_25_0; i <= num; i++)
                    {
                        CSymbol cSymbol = (CSymbol)this.InnerList[i];
                        cSymbol.Draw(pMap, g);
                    }
                }
            }
        }
        public void DrawSelectedSymbol(AxMap pMap, Graphics g, CSymbol selectedSymbol, float Scale)
        {
            GraphicObject graphicObject = selectedSymbol.GObjs[0];
            System.Drawing.Point point = default(System.Drawing.Point);
            float num = (float)point.X;
            float num2 = (float)point.Y;
            GraphicObject graphicObject2 = graphicObject;
            double num3 = (double)graphicObject2.X;
            GraphicObject graphicObject3 = graphicObject;
            double num4 = (double)graphicObject3.Y;
            pMap.ConvertCoord(ref num, ref num2, ref num3, ref num4, ConversionConstants.miMapToScreen);
            graphicObject3.Y = (float)num4;
            graphicObject2.X = (float)num3;
            checked
            {
                point.Y = (int)Math.Round((double)num2);
                point.X = (int)Math.Round((double)num);
                GraphicsContainer container = g.BeginContainer();
                g.ScaleTransform(Scale, Scale, MatrixOrder.Append);
                GraphicsContainer container2 = g.BeginContainer();
                g.PageUnit = GraphicsUnit.Pixel;
                if (graphicObject != null)
                {
                    Pen pen = new Pen(Color.FromKnownColor(KnownColor.HotTrack));
                    pen.DashStyle = DashStyle.Dot;
                    pen.Width = 1f;
                    if (graphicObject.Rotation != 0f)
                    {
                        Matrix transform = g.Transform;
                        Matrix arg_105_0 = transform;
                        float arg_105_1 = graphicObject.Rotation;
                        PointF point2 = new PointF((float)point.X, (float)point.Y);
                        arg_105_0.RotateAt(arg_105_1, point2, MatrixOrder.Append);
                        g.Transform = transform;
                    }
                    PointF[] array = new PointF[3];
                    array[0].X = graphicObject.X;
                    array[0].Y = graphicObject.Y;
                    int upperBound = 0;
                    unchecked
                    {
                        array[1].X = graphicObject.X + graphicObject.Width;
                        array[1].Y = graphicObject.Y + graphicObject.Height;
                        upperBound = array.GetUpperBound(0);
                    }
                    System.Drawing.Point[] array2 = new System.Drawing.Point[upperBound + 1];
                    int arg_18E_0 = 0;
                    int num5 = upperBound;
                    for (int i = arg_18E_0; i <= num5; i++)
                    {
                        System.Drawing.Point[] array3 = array2;
                        System.Drawing.Point[] arg_1A2_0 = array3;
                        int num6 = i;
                        num2 = (float)arg_1A2_0[num6].X;
                        System.Drawing.Point[] array4 = array2;
                        System.Drawing.Point[] arg_1BD_0 = array4;
                        int num7 = i;
                        num = (float)arg_1BD_0[num7].Y;
                        PointF[] array5 = array;
                        PointF[] arg_1D8_0 = array5;
                        int num8 = i;
                        num4 = (double)arg_1D8_0[num8].X;
                        PointF[] array6 = array;
                        PointF[] arg_1F3_0 = array6;
                        int num9 = i;
                        num3 = (double)arg_1F3_0[num9].Y;
                        pMap.ConvertCoord(ref num2, ref num, ref num4, ref num3, ConversionConstants.miMapToScreen);
                        array6[num9].Y = (float)num3;
                        array5[num8].X = (float)num4;
                        array4[num7].Y = (int)Math.Round((double)num);
                        array3[num6].X = (int)Math.Round((double)num2);
                    }
                    float num10 = (float)Math.Abs(array2[1].X - array2[0].X);
                    float num11 = (float)Math.Abs(array2[1].Y - array2[0].Y);
                    float num12 = (float)Math.Min(array2[0].X, array2[1].X);
                    float num13 = (float)Math.Min(array2[0].Y, array2[1].Y);
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle((int)Math.Round((double)num12), (int)Math.Round((double)num13), (int)Math.Round((double)num10), (int)Math.Round((double)num11));
                    g.DrawRectangle(pen, rect);
                }
                g.EndContainer(container2);
                g.EndContainer(container);
            }
        }
        public void SendBack(CSymbol aKH)
        {
            this.List.Remove(aKH);
            this.List.Insert(0, aKH);
        }
        public void SendFront(CSymbol aKH)
        {
            this.List.Remove(aKH);
            this.List.Add(aKH);
        }
        public string KH2String(AxMap pMap)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            this.khs2xml(pMap, ref xmlTextWriter);
            xmlTextWriter.Close();
            return stringWriter.ToString();
        }
        public void KH2File(AxMap pMap, string pFileName)
        {
            StreamWriter w = new StreamWriter(pFileName);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(w);
            this.khs2xml(pMap, ref xmlTextWriter);
            xmlTextWriter.Close();
        }
        private void khs2xml(AxMap pMap, ref XmlTextWriter wr)
        {
            wr.WriteStartElement("KyHieus");
            foreach (CSymbol cSymbol in this.List)
            {
                wr.WriteStartElement("KyHieu");
                if (cSymbol.Description.Length > 0)
                {
                    wr.WriteAttributeString("Desc", cSymbol.Description);
                }
                if (cSymbol.Blinking)
                {
                    wr.WriteAttributeString("Blink", cSymbol.Blinking.ToString());
                }
                wr.WriteAttributeString("Zoom", cSymbol.Zoom.ToString());
                wr.WriteAttributeString("MWi", cSymbol.MWidth.ToString());
                wr.WriteAttributeString("GocX", cSymbol.GocX.ToString("#.0000"));
                wr.WriteAttributeString("GocY", cSymbol.GocY.ToString("#.0000"));
                wr.WriteAttributeString("Heading", cSymbol.Heading.ToString());
                cSymbol.GObjs.Objects2String(ref wr);
                wr.WriteEndElement();
            }

            wr.WriteEndElement();
        }
        public static CSymbols String2KHs(string pstrKyHieu)
        {
            NameTable nameTable = new NameTable();
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
            xmlNamespaceManager.AddNamespace("bk", "urn:sample");
            XmlParserContext context = new XmlParserContext(null, xmlNamespaceManager, null, XmlSpace.None);
            XmlTextReader xmlTextReader = new XmlTextReader(pstrKyHieu, XmlNodeType.Element, context);
            CSymbols result = CSymbols.XML2Symbols(xmlTextReader);
            xmlTextReader.Close();
            return result;
        }
        public static CSymbols XML2Symbols(XmlTextReader rr)
        {
            CSymbols cSymbols = new CSymbols();
            CGraphicObjs cGraphicObjs = new CGraphicObjs();
            string pDesc = "";
            bool pBlinking = false;
            try
            {
                while (rr.Read())
                {
                    XmlNodeType nodeType = rr.NodeType;
                    XmlNodeType xmlNodeType = nodeType;
                    if (xmlNodeType == XmlNodeType.Element)
                    {
                        string name = rr.Name;
                        if (name == "KyHieu")
                        {
                            cGraphicObjs.Clear();
                            float pMWidth = 0f;
                            pDesc = "";
                            pBlinking = false;
                            float pHeading = 0f;
                            if (rr.AttributeCount > 0)
                            {
                                while (rr.MoveToNextAttribute())
                                {
                                    string name2 = rr.Name;
                                    if (name2 == "Desc")
                                    {
                                        pDesc = rr.Value;
                                    }
                                    else if (name2 == "Blink")
                                    {
                                        pBlinking = rr.Value == "True" ? true : false;
                                    }
                                    else if (name2 == "Zoom")
                                    {
                                        double @double = modHuanLuyen.GetDouble(rr.Value);
                                    }
                                    else if (name2 == "MWi")
                                    {
                                        pMWidth = modHuanLuyen.GetSingle(rr.Value);
                                    }
                                    else if (name2 == "GocX")
                                    {
                                        double double2 = modHuanLuyen.GetDouble(rr.Value);
                                    }
                                    else if (name2 == "GocY")
                                    {
                                        double double3 = modHuanLuyen.GetDouble(rr.Value);
                                    }
                                    else if (name2 == "Heading")
                                    {
                                        pHeading = modHuanLuyen.GetSingle(rr.Value);
                                    }
                                }
                            }
                        }
                        else if (name == "Part")
                        {
                            string text = rr.ReadOuterXml();
                            while (rr.Name == "Part")
                            {
                                text += rr.ReadOuterXml();
                            }
                            cGraphicObjs = CGraphicObjs.Str2Objects(text, 0, 0, modHuanLuyen.cDecSepa, modHuanLuyen.cGrpSepa);
                            float pMWidth = 0;
                            float pHeading = 0;
                            double @double = 0;
                            double double2 = 0;
                            double double3 = 0;
                            CSymbol aSymbol = new CSymbol(pDesc, pBlinking, @double, pMWidth, double2, double3, cGraphicObjs, pHeading);
                            cSymbols.Add(aSymbol);
                        }
                    }
                    else if (xmlNodeType == XmlNodeType.EndElement)
                    {
                    }
                }
            }
            catch (Exception expr_20A)
            {
                throw expr_20A;
            }
            return cSymbols;
        }
    }
}