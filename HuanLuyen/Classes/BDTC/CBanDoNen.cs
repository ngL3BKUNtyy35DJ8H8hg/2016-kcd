using AxMapXLib;
using MapXLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
namespace HuanLuyen
{
    public class CBanDoNen
    {
        public delegate void DoXongEventHandler();
        public delegate void VePolygonXongEventHandler(List<MapPoint> pMapPts);
        public delegate void VeLaiPolygonXongEventHandler(List<MapPoint> pMapPts);
        public delegate void VePolylineXongEventHandler(List<MapPoint> pMapPts);
        public delegate void VeTachPolylineXongEventHandler(List<MapPoint> pMapPts);
        public delegate void VeLaiPolylineXongEventHandler(List<MapPoint> pMapPts);
        public delegate void VeLineXongEventHandler(List<MapPoint> pMapPts);
        public enum MapTools
        {
            None,
            Ruller,
            Polygon,
            RePolygon,
            Polyline,
            Line,
            TachPolyline,
            LaiPolyline
        }
        private CBanDoNen.DoXongEventHandler DoXongEvent;
        private CBanDoNen.VePolygonXongEventHandler VePolygonXongEvent;
        private CBanDoNen.VeLaiPolygonXongEventHandler VeLaiPolygonXongEvent;
        private CBanDoNen.VePolylineXongEventHandler VePolylineXongEvent;
        private CBanDoNen.VeTachPolylineXongEventHandler VeTachPolylineXongEvent;
        private CBanDoNen.VeLaiPolylineXongEventHandler VeLaiPolylineXongEvent;
        private CBanDoNen.VeLineXongEventHandler VeLineXongEvent;
        public CBanDoNen.MapTools myMapTool;
        private AxMap m_Map;
        private Form m_ParentForm;
        private ToolStripStatusLabel m_ToolStripStatusLabel3;
        private ToolStripStatusLabel m_ToolStripStatusLabel1;
        private string strDistanceUnit;
        private string strDistanceKQ;
        private int DistanceKQ = 0;
        private PointF[] myPts;
        private PointF myfromPt = new PointF();
        private PointF mytoPt = new PointF();
        private PointF myrootPt = new PointF();
        private bool DrawingPicking;
        //public event CBanDoNen.DoXongEventHandler DoXong
        //{
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //add
        //{
        //this.DoXongEvent = (CBanDoNen.DoXongEventHandler)Delegate.Combine(this.DoXongEvent, value);
        //}
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //remove
        //{
        //this.DoXongEvent = (CBanDoNen.DoXongEventHandler)Delegate.Remove(this.DoXongEvent, value);
        //}
        //}
        //public event CBanDoNen.VePolygonXongEventHandler VePolygonXong
        //{
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //add
        //{
        //this.VePolygonXongEvent = (CBanDoNen.VePolygonXongEventHandler)Delegate.Combine(this.VePolygonXongEvent, value);
        //}
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //remove
        //{
        //this.VePolygonXongEvent = (CBanDoNen.VePolygonXongEventHandler)Delegate.Remove(this.VePolygonXongEvent, value);
        //}
        //}
        //public event CBanDoNen.VeLaiPolygonXongEventHandler VeLaiPolygonXong
        //{
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //add
        //{
        //this.VeLaiPolygonXongEvent = (CBanDoNen.VeLaiPolygonXongEventHandler)Delegate.Combine(this.VeLaiPolygonXongEvent, value);
        //}
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //remove
        //{
        //this.VeLaiPolygonXongEvent = (CBanDoNen.VeLaiPolygonXongEventHandler)Delegate.Remove(this.VeLaiPolygonXongEvent, value);
        //}
        //}
        //public event CBanDoNen.VePolylineXongEventHandler VePolylineXong
        //{
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //add
        //{
        //this.VePolylineXongEvent = (CBanDoNen.VePolylineXongEventHandler)Delegate.Combine(this.VePolylineXongEvent, value);
        //}
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //remove
        //{
        //this.VePolylineXongEvent = (CBanDoNen.VePolylineXongEventHandler)Delegate.Remove(this.VePolylineXongEvent, value);
        //}
        //}
        //public event CBanDoNen.VeTachPolylineXongEventHandler VeTachPolylineXong
        //{
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //add
        //{
        //this.VeTachPolylineXongEvent = (CBanDoNen.VeTachPolylineXongEventHandler)Delegate.Combine(this.VeTachPolylineXongEvent, value);
        //}
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //remove
        //{
        //this.VeTachPolylineXongEvent = (CBanDoNen.VeTachPolylineXongEventHandler)Delegate.Remove(this.VeTachPolylineXongEvent, value);
        //}
        //}
        //public event CBanDoNen.VeLaiPolylineXongEventHandler VeLaiPolylineXong
        //{
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //add
        //{
        //this.VeLaiPolylineXongEvent = (CBanDoNen.VeLaiPolylineXongEventHandler)Delegate.Combine(this.VeLaiPolylineXongEvent, value);
        //}
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //remove
        //{
        //this.VeLaiPolylineXongEvent = (CBanDoNen.VeLaiPolylineXongEventHandler)Delegate.Remove(this.VeLaiPolylineXongEvent, value);
        //}
        //}
        //public event CBanDoNen.VeLineXongEventHandler VeLineXong
        //{
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //add
        //{
        //this.VeLineXongEvent = (CBanDoNen.VeLineXongEventHandler)Delegate.Combine(this.VeLineXongEvent, value);
        //}
        //[MethodImpl(MethodImplOptions.Synchronized)]
        //remove
        //{
        //this.VeLineXongEvent = (CBanDoNen.VeLineXongEventHandler)Delegate.Remove(this.VeLineXongEvent, value);
        //}
        //}
        public CBanDoNen(AxMap pMap, Form pForm, ToolStripStatusLabel pToolStripStatusLabel3, ToolStripStatusLabel pToolStripStatusLabel1)
        {
            this.strDistanceUnit = "m";
            this.DrawingPicking = false;
            this.m_ParentForm = pForm;
            this.m_Map = pMap;
            this.m_ToolStripStatusLabel3 = pToolStripStatusLabel3;
            this.m_ToolStripStatusLabel1 = pToolStripStatusLabel1;
            this.myMapTool = CBanDoNen.MapTools.None;
        }
        public static void AddDataSets(AxMap pMap)
        {
            pMap.DataSets.RemoveAll();
            checked
            {
                if (pMap.Layers.Count > 0)
                {
                    int arg_26_0 = 1;
                    int count = pMap.Layers.Count;
                    for (int i = arg_26_0; i <= count; i++)
                    {
                        Layer layer = pMap.Layers[i];
                        if (layer.Type == LayerTypeConstants.miLayerTypeNormal)
                        {
                            try
                            {
                                pMap.DataSets.Add(DatasetTypeConstants.miDataSetLayer, layer, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                            }
                            catch (Exception expr_72)
                            {
                                throw expr_72;
                            }
                        }
                    }
                }
            }
        }
        public static void LoadGst(AxMap pMap, string pMapGst)
        {
            try
            {
                pMap.GeoSet = pMapGst;
                pMap.Title.Visible = false;
                pMap.MapUnit = MapUnitConstants.miUnitMeter;
                CoordSys displayCoordSys = pMap.DisplayCoordSys;
                pMap.NumericCoordSys = displayCoordSys;
                pMap.InfotipSupport = false;
                pMap.NumericCoordSys.Set((CoordSysTypeConstants)modBanDo.myCoordSysType, displayCoordSys.Datum, pMap.NumericCoordSys.Units, pMap.NumericCoordSys.OriginLongitude, pMap.NumericCoordSys.OriginLatitude, pMap.NumericCoordSys.StandardParallelOne, pMap.NumericCoordSys.StandardParallelTwo, pMap.NumericCoordSys.Azimuth, pMap.NumericCoordSys.ScaleFactor, pMap.NumericCoordSys.FalseEasting, pMap.NumericCoordSys.FalseNorthing, pMap.NumericCoordSys.Range, Missing.Value, Missing.Value);
                pMap.PaperUnit = PaperUnitConstants.miPaperUnitCentimeter;
            }
            catch (Exception expr_F8)
            {
                throw expr_F8;
            }
        }
        public void Zoom1X()
        {
            double zoomLevel = modBanDo.GetZoomLevel(this.m_Map, modBanDo.BDTyLeBanDo);
            this.m_Map.ZoomTo(zoomLevel, modBanDo.BDKinhDo, modBanDo.BDViDo);
        }
        public void OnDoKhoangCach()
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.myMapTool = CBanDoNen.MapTools.Ruller;
            this.strDistanceKQ = "";
            this.myPts = new PointF[0];
            this.DrawingPicking = false;
            this.m_ToolStripStatusLabel3.Text = "Đo khoảng cách: Click để chọn các Vị trí, RightClick để xem Kết quả.";
        }
        public void OnVePolygon()
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.myMapTool = CBanDoNen.MapTools.Polygon;
            this.myPts = new PointF[0];
            this.DrawingPicking = false;
        }
        public void OnVeLaiPolygon()
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.myMapTool = CBanDoNen.MapTools.RePolygon;
            this.myPts = new PointF[0];
            this.DrawingPicking = false;
        }
        public void OnVePolyline(System.Drawing.Point mousePT)
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.myMapTool = CBanDoNen.MapTools.Polyline;
            this.DrawingPicking = true;
            this.myPts = new PointF[2];
            this.myPts[0] = new PointF((float)mousePT.X, (float)mousePT.Y);
            this.myPts[1] = new PointF((float)mousePT.X, (float)mousePT.Y);
        }
        public void OnVeLine(System.Drawing.Point mousePT)
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.myMapTool = CBanDoNen.MapTools.Line;
            this.DrawingPicking = true;
            this.myPts = new PointF[2];
            this.myPts[0] = new PointF((float)mousePT.X, (float)mousePT.Y);
            this.myPts[1] = new PointF((float)mousePT.X, (float)mousePT.Y);
        }
        public void OnVeTachPolyline(System.Drawing.Point mousePT)
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.myMapTool = CBanDoNen.MapTools.TachPolyline;
            this.DrawingPicking = true;
            this.myPts = new PointF[2];
            this.myPts[0] = new PointF((float)mousePT.X, (float)mousePT.Y);
            this.myPts[1] = new PointF((float)mousePT.X, (float)mousePT.Y);
        }
        public void OnVeLaiPolyline(System.Drawing.Point mousePT)
        {
            this.m_Map.CurrentTool = ToolConstants.miArrowTool;
            this.myMapTool = CBanDoNen.MapTools.LaiPolyline;
            this.DrawingPicking = true;
            this.myPts = new PointF[2];
            this.myPts[0] = new PointF((float)mousePT.X, (float)mousePT.Y);
            this.myPts[1] = new PointF((float)mousePT.X, (float)mousePT.Y);
        }
        public void m_Map_MouseDownEvent(object sender, CMapXEvents_MouseDownEvent e)
        {
            checked
            {
                if (this.m_Map.CurrentTool == ToolConstants.miArrowTool)
                {
                    System.Drawing.Point point = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                    if (this.myMapTool == CBanDoNen.MapTools.Ruller)
                    {
                        if (e.button == 1)
                        {
                            if (!this.DrawingPicking)
                            {
                                this.DrawingPicking = true;
                                this.myPts = new PointF[2];
                                this.myPts[0] = new PointF((float)point.X, (float)point.Y);
                                this.myPts[1] = new PointF((float)point.X, (float)point.Y);
                            }
                            else
                            {
                                //[CONVERT FAIL]
                                //int num = this.myPts.GetUpperBound(0);
                                //num++;
                                //this.myPts = (PointF[])Utils.CopyArray((Array)this.myPts, new PointF[num + 1]);
                                //this.myPts[num] = new PointF((float)point.X, (float)point.Y);
                            }
                        }
                        else
                        {
                            if (this.myPts.GetUpperBound(0) > 0)
                            {
                                int i = 0;
                                if (this.myPts.GetUpperBound(0) > 0)
                                {
                                    int arg_13D_0 = 1;
                                    int upperBound = this.myPts.GetUpperBound(0);
                                    for (i = arg_13D_0; i <= upperBound; i++)
                                    {
                                        AxMap arg_18C_0 = this.m_Map;
                                        PointF[] array = this.myPts;
                                        PointF[] arg_15A_0 = array;
                                        int num2 = i - 1;
                                        float num3 = arg_15A_0[num2].X;
                                        PointF[] array2 = this.myPts;
                                        PointF[] arg_179_0 = array2;
                                        int num4 = i - 1;
                                        float num5 = arg_179_0[num4].Y;
                                        double x = 0;
                                        double y = 0;
                                        arg_18C_0.ConvertCoord(ref num3, ref num5, ref x, ref y, ConversionConstants.miScreenToMap);
                                        array2[num4].Y = num5;
                                        array[num2].X = num3;
                                        AxMap arg_1F6_0 = this.m_Map;
                                        array2 = this.myPts;
                                        PointF[] arg_1C6_0 = array2;
                                        num4 = i;
                                        num5 = arg_1C6_0[num4].X;
                                        array = this.myPts;
                                        PointF[] arg_1E3_0 = array;
                                        num2 = i;
                                        num3 = arg_1E3_0[num2].Y;
                                        double x2 = 0;
                                        double y2 = 0;
                                        arg_1F6_0.ConvertCoord(ref num5, ref num3, ref x2, ref y2, ConversionConstants.miScreenToMap);
                                        array[num2].Y = num3;
                                        array2[num4].X = num5;
                                        int num6 = (int)Math.Round(this.m_Map.Distance(x, y, x2, y2));
                                        if (this.strDistanceKQ.Length > 0)
                                        {
                                            this.DistanceKQ += num6;
                                            this.strDistanceKQ = this.strDistanceKQ + " + " + num6.ToString("#,###");
                                        }
                                        else
                                        {
                                            this.DistanceKQ = num6;
                                            this.strDistanceKQ = num6.ToString("#,###");
                                        }
                                    }
                                }
                                if (this.strDistanceKQ.IndexOf("+") > -1)
                                {
                                    this.strDistanceKQ = string.Concat(new string[] { this.strDistanceKQ," = ",this.DistanceKQ.ToString("#,###")," ",this.strDistanceUnit});
                                }
                                else
                                {
                                    this.strDistanceKQ = this.DistanceKQ.ToString("#,###") + " " + this.strDistanceUnit;
                                }
                                i = this.myPts.GetUpperBound(0);
                                double hDG = modHuanLuyen.GetHDG(this.myPts[0], this.myPts[i]);
                                this.strDistanceKQ = this.strDistanceKQ + "\rGóc: " + hDG.ToString("#,###");
                                MessageBox.Show(this.m_ParentForm, this.strDistanceKQ, "Kết quả đo:", MessageBoxButtons.OK);
                                SendKeys.Send("{ESC}");
                            }
                            this.DrawingPicking = false;
                            this.strDistanceKQ = "";
                            this.myPts = new PointF[0];
                            this.myMapTool = CBanDoNen.MapTools.None;
                            CBanDoNen.DoXongEventHandler doXongEvent = this.DoXongEvent;
                            if (doXongEvent != null)
                            {
                                doXongEvent();
                            }
                        }
                    }
                    else if (this.myMapTool == CBanDoNen.MapTools.Polygon | this.myMapTool == CBanDoNen.MapTools.RePolygon)
                    {
                        if (e.button == 1)
                        {
                            if (!this.DrawingPicking)
                            {
                                this.DrawingPicking = true;
                                this.myPts = new PointF[2];
                                this.myPts[0] = new PointF((float)point.X, (float)point.Y);
                                this.myPts[1] = new PointF((float)point.X, (float)point.Y);
                            }
                            else
                            {
                                //[CONVERT FAIL]
                                //int num7 = this.myPts.GetUpperBound(0);
                                //num7++;
                                //this.myPts = (PointF[])Utils.CopyArray((Array)this.myPts, new PointF[num7 + 1]);
                                //this.myPts[num7] = new PointF((float)point.X, (float)point.Y);
                            }
                        }
                        else
                        {
                            List<MapPoint> list = new List<MapPoint>();
                            if (this.myPts.GetUpperBound(0) > 0)
                            {
                                int arg_4FA_0 = 0;
                                int upperBound2 = this.myPts.GetUpperBound(0);
                                for (int j = arg_4FA_0; j <= upperBound2; j++)
                                {
                                    MapPoint item = default(MapPoint);
                                    AxMap arg_55A_0 = this.m_Map;
                                    PointF[] array2 = this.myPts;
                                    PointF[] arg_51F_0 = array2;
                                    int num4 = j;
                                    float num5 = arg_51F_0[num4].X;
                                    PointF[] array = this.myPts;
                                    PointF[] arg_53D_0 = array;
                                    int num2 = j;
                                    float num3 = arg_53D_0[num2].Y;
                                    arg_55A_0.ConvertCoord(ref num5, ref num3, ref item.x, ref item.y, ConversionConstants.miScreenToMap);
                                    array[num2].Y = num3;
                                    array2[num4].X = num5;
                                    list.Add(item);
                                }
                            }
                            if (this.myMapTool == CBanDoNen.MapTools.RePolygon)
                            {
                                CBanDoNen.VeLaiPolygonXongEventHandler veLaiPolygonXongEvent = this.VeLaiPolygonXongEvent;
                                if (veLaiPolygonXongEvent != null)
                                {
                                    veLaiPolygonXongEvent(list);
                                }
                            }
                            else
                            {
                                CBanDoNen.VePolygonXongEventHandler vePolygonXongEvent = this.VePolygonXongEvent;
                                if (vePolygonXongEvent != null)
                                {
                                    vePolygonXongEvent(list);
                                }
                            }
                            this.DrawingPicking = false;
                            this.myMapTool = CBanDoNen.MapTools.None;
                            this.myPts = new PointF[0];
                        }
                    }
                    else if (this.myMapTool == CBanDoNen.MapTools.Polyline | this.myMapTool == CBanDoNen.MapTools.TachPolyline | this.myMapTool == CBanDoNen.MapTools.LaiPolyline)
                    {
                        if (e.button == 1)
                        {
                            if (!this.DrawingPicking)
                            {
                                this.DrawingPicking = true;
                                this.myPts = new PointF[2];
                                this.myPts[0] = new PointF((float)point.X, (float)point.Y);
                                this.myPts[1] = new PointF((float)point.X, (float)point.Y);
                            }
                            else
                            {
                                //[CONVERT FAIL]
                                //int num8 = this.myPts.GetUpperBound(0);
                                //num8++;
                                //this.myPts = (PointF[])Utils.CopyArray((Array)this.myPts, new PointF[num8 + 1]);
                                //this.myPts[num8] = new PointF((float)point.X, (float)point.Y);
                            }
                        }
                        else
                        {
                            List<MapPoint> list2 = new List<MapPoint>();
                            if (this.myPts.GetUpperBound(0) > 0)
                            {
                                int arg_702_0 = 0;
                                int upperBound3 = this.myPts.GetUpperBound(0);
                                for (int k = arg_702_0; k <= upperBound3; k++)
                                {
                                    MapPoint item2 = default(MapPoint);
                                    AxMap arg_762_0 = this.m_Map;
                                    PointF[] array2 = this.myPts;
                                    PointF[] arg_727_0 = array2;
                                    int num4 = k;
                                    float num5 = arg_727_0[num4].X;
                                    PointF[] array = this.myPts;
                                    PointF[] arg_745_0 = array;
                                    int num2 = k;
                                    float num3 = arg_745_0[num2].Y;
                                    arg_762_0.ConvertCoord(ref num5, ref num3, ref item2.x, ref item2.y, ConversionConstants.miScreenToMap);
                                    array[num2].Y = num3;
                                    array2[num4].X = num5;
                                    list2.Add(item2);
                                }
                            }
                            int num9 = 1;
                            if (this.myMapTool == CBanDoNen.MapTools.TachPolyline)
                            {
                                num9 = 2;
                            }
                            else if (this.myMapTool == CBanDoNen.MapTools.LaiPolyline)
                            {
                                num9 = 3;
                            }
                            this.DrawingPicking = false;
                            this.myMapTool = CBanDoNen.MapTools.None;
                            this.myPts = new PointF[0];
                            if (num9 == 1)
                            {
                                CBanDoNen.VePolylineXongEventHandler vePolylineXongEvent = this.VePolylineXongEvent;
                                if (vePolylineXongEvent != null)
                                {
                                    vePolylineXongEvent(list2);
                                }
                            }
                            else if (num9 == 2)
                            {
                                CBanDoNen.VeTachPolylineXongEventHandler veTachPolylineXongEvent = this.VeTachPolylineXongEvent;
                                if (veTachPolylineXongEvent != null)
                                {
                                    veTachPolylineXongEvent(list2);
                                }
                            }
                            else
                            {
                                CBanDoNen.VeLaiPolylineXongEventHandler veLaiPolylineXongEvent = this.VeLaiPolylineXongEvent;
                                if (veLaiPolylineXongEvent != null)
                                {
                                    veLaiPolylineXongEvent(list2);
                                }
                            }
                        }
                    }
                    else if (this.myMapTool == CBanDoNen.MapTools.Line)
                    {
                        List<MapPoint> list3 = new List<MapPoint>();
                        if (this.myPts.GetUpperBound(0) > 0)
                        {
                            int arg_85C_0 = 0;
                            int upperBound4 = this.myPts.GetUpperBound(0);
                            for (int l = arg_85C_0; l <= upperBound4; l++)
                            {
                                MapPoint item3 = default(MapPoint);
                                AxMap arg_8BC_0 = this.m_Map;
                                PointF[] array2 = this.myPts;
                                PointF[] arg_881_0 = array2;
                                int num4 = l;
                                float num5 = arg_881_0[num4].X;
                                PointF[] array = this.myPts;
                                PointF[] arg_89F_0 = array;
                                int num2 = l;
                                float num3 = arg_89F_0[num2].Y;
                                arg_8BC_0.ConvertCoord(ref num5, ref num3, ref item3.x, ref item3.y, ConversionConstants.miScreenToMap);
                                array[num2].Y = num3;
                                array2[num4].X = num5;
                                list3.Add(item3);
                            }
                        }
                        this.DrawingPicking = false;
                        this.myMapTool = CBanDoNen.MapTools.None;
                        this.myPts = new PointF[0];
                        CBanDoNen.VeLineXongEventHandler veLineXongEvent = this.VeLineXongEvent;
                        if (veLineXongEvent != null)
                        {
                            veLineXongEvent(list3);
                        }
                    }
                }
            }
        }
        private PointF gscTogoc(int X, int Y)
        {
            AxMap arg_17_0 = this.m_Map;
            float num = (float)X;
            float num2 = (float)Y;
            double num3 = 0;
            double num4 = 0;
            arg_17_0.ConvertCoord(ref num, ref num2, ref num3, ref num4, ConversionConstants.miScreenToMap);
            checked
            {
                Y = (int)Math.Round((double)num2);
                X = (int)Math.Round((double)num);
                PointF result = new PointF((float)num3, (float)num4);
                return result;
            }
        }
        public void m_Map_MouseMoveEvent(object sender, CMapXEvents_MouseMoveEvent e)
        {
            checked
            {
                PointF pointF = this.gscTogoc((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                ToolStripItem arg_5B_0 = this.m_ToolStripStatusLabel1;
                float x = pointF.X;
                string arg_56_0 = x.ToString("0.0000");
                string arg_56_1 = ", ";
                float y = pointF.Y;
                arg_5B_0.Text = arg_56_0 + arg_56_1 + y.ToString("0.0000");
                if (this.m_Map.CurrentTool == ToolConstants.miArrowTool)
                {
                    System.Drawing.Point point = new System.Drawing.Point((int)Math.Round((double)e.x), (int)Math.Round((double)e.y));
                    if (this.myMapTool == CBanDoNen.MapTools.Ruller)
                    {
                        if (this.DrawingPicking)
                        {
                            int upperBound = this.myPts.GetUpperBound(0);
                            this.myPts[upperBound].X = (float)point.X;
                            this.myPts[upperBound].Y = (float)point.Y;
                            this.DrawDrawingLine(this.myPts);
                            AxMap arg_141_0 = this.m_Map;
                            PointF[] array = this.myPts;
                            PointF[] arg_10F_0 = array;
                            int num = upperBound - 1;
                            x = arg_10F_0[num].X;
                            PointF[] array2 = this.myPts;
                            PointF[] arg_12E_0 = array2;
                            int num2 = upperBound - 1;
                            y = arg_12E_0[num2].Y;
                            double x2 = 0;
                            double y2 = 0;
                            arg_141_0.ConvertCoord(ref x, ref y, ref x2, ref y2, ConversionConstants.miScreenToMap);
                            array2[num2].Y = y;
                            array[num].X = x;
                            AxMap arg_1AB_0 = this.m_Map;
                            array2 = this.myPts;
                            PointF[] arg_17B_0 = array2;
                            num2 = upperBound;
                            x = arg_17B_0[num2].X;
                            array = this.myPts;
                            PointF[] arg_198_0 = array;
                            num = upperBound;
                            y = arg_198_0[num].Y;
                            double x3 = 0;
                            double y3 = 0;
                            arg_1AB_0.ConvertCoord(ref x, ref y, ref x3, ref y3, ConversionConstants.miScreenToMap);
                            array[num].Y = y;
                            array2[num2].X = x;
                            int num3 = (int)Math.Round(this.m_Map.Distance(x2, y2, x3, y3));
                            double hDG = modHuanLuyen.GetHDG(this.myPts[upperBound - 1], this.myPts[upperBound]);
                            this.m_ToolStripStatusLabel3.Text = "Đo: " + num3.ToString("#,###") + "; Góc: " + hDG.ToString("#,###");
                        }
                    }
                    else if (this.myMapTool == CBanDoNen.MapTools.Polygon | this.myMapTool == CBanDoNen.MapTools.RePolygon)
                    {
                        if (this.DrawingPicking)
                        {
                            int upperBound2 = this.myPts.GetUpperBound(0);
                            this.myPts[upperBound2].X = (float)point.X;
                            this.myPts[upperBound2].Y = (float)point.Y;
                            this.DrawPolygon(this.myPts);
                        }
                    }
                    else if ((this.myMapTool == CBanDoNen.MapTools.Polyline | this.myMapTool == CBanDoNen.MapTools.TachPolyline | this.myMapTool == CBanDoNen.MapTools.LaiPolyline | this.myMapTool == CBanDoNen.MapTools.Line) && this.DrawingPicking)
                    {
                        int upperBound3 = this.myPts.GetUpperBound(0);
                        this.myPts[upperBound3].X = (float)point.X;
                        this.myPts[upperBound3].Y = (float)point.Y;
                        this.DrawDrawingLine(this.myPts);
                    }
                }
            }
        }
        private void DrawDrawingLine(PointF[] pPts)
        {
            Graphics graphics = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            Pen pen = new Pen(Color.FromArgb(75, Color.Gray), 2f);
            int upperBound = pPts.GetUpperBound(0);
            checked
            {
                System.Drawing.Point[] array = new System.Drawing.Point[upperBound + 1];
                int arg_46_0 = 0;
                int num = upperBound;
                for (int i = arg_46_0; i <= num; i++)
                {
                    array[i].X = (int)Math.Round((double)pPts[i].X);
                    array[i].Y = (int)Math.Round((double)pPts[i].Y);
                }
                graphics.DrawLines(pen, array);
                pen.Dispose();
            }
        }
        private void DrawPolygon(PointF[] pPts)
        {
            Graphics graphics = this.m_Map.CreateGraphics();
            this.m_Map.Refresh();
            Pen pen = new Pen(Color.FromArgb(75, Color.Gray), 2f);
            int upperBound = pPts.GetUpperBound(0);
            checked
            {
                System.Drawing.Point[] array = new System.Drawing.Point[upperBound + 1];
                int arg_46_0 = 0;
                int num = upperBound;
                for (int i = arg_46_0; i <= num; i++)
                {
                    array[i].X = (int)Math.Round((double)pPts[i].X);
                    array[i].Y = (int)Math.Round((double)pPts[i].Y);
                }
                graphics.DrawPolygon(pen, array);
                pen.Dispose();
            }
        }
        public void procThongTin(double x1, double y1)
        {
            Feature feature = null;
            MapXLib.Point point = new PointClass();
            point.Set(x1, y1);
            long num = 0L;
            int arg_29_0 = 2;
            int count = this.m_Map.Layers.Count;
            checked
            {
                for (int i = arg_29_0; i <= count; i++)
                {
                    Layer layer = this.m_Map.Layers[i];
                    try
                    {
                        if (num == 0L)
                        {
                            Features features = layer.SearchAtPoint(point, Missing.Value);
                            if (features.Count > 0)
                            {
                                feature = features[1];
                                layer.Selection.SelectByID(feature.FeatureID, SelectionTypeConstants.miSelectionNew);
                                num = unchecked((long)feature.FeatureID);
                            }
                        }
                        else
                        {
                            layer.Selection.ClearSelection();
                        }
                    }
                    catch (Exception expr_9F)
                    {
                        throw expr_9F;
                    }
                }
                if (num > 0L)
                {
                    this.ThongTinKhac(feature);
                }
            }
        }
        private void ThongTinKhac(Feature pf)
        {
            Dataset dataset = null;
            Layer layer = pf.Layer;
            string text = "";
            int arg_23_0 = 1;
            int count = this.m_Map.DataSets.Count;
            checked
            {
                for (int i = arg_23_0; i <= count; i++)
                {
                    dataset = this.m_Map.DataSets[i];
                    if (dataset.Layer.Name == layer.Name)
                    {
                        break;
                    }
                }
                RowValues rowValues = dataset.get_RowValues(pf);
                int arg_75_0 = 1;
                int count2 = rowValues.Count;
                for (int i = arg_75_0; i <= count2; i++)
                {
                    RowValue rowValue = rowValues[i];
                    Field field = (Field)rowValue.Field;
                    text = string.Concat(new string[]{text,myModule.toUnicode(field.Name),": ",myModule.toUnicode(rowValue.Value),"\r\n"});
                }
                text = text.Substring(text.Length - 2);
                MessageBox.Show(this.m_ParentForm, text, "Lớp: " + layer.Name);
                layer.Selection.ClearSelection();
            }
        }
        public static void NhapNhayFeature(AxMap m_Map, string pLop, string pFKey, int pSoLan)
        {
            //int num3 = 0;
            //int num4 = 0;
            //try
            //{
            //IL_00:
            //int num = 1;
            //Style style = new StyleClass();
            //IL_0A:
            //num = 2;
            //uint num2 = 0u;
            //IL_15:
            //num3 = 2;
            //IL_1D:
            //num = 4;
            //Layer layer = m_Map.Layers[pLop];
            //IL_2E:
            //num = 5;
            //Feature feature = layer.GetFeatureByKey(pFKey);
            //IL_3A:
            //num = 6;
            //if (m_Map.IsPointVisible(feature.CenterX, feature.CenterY))
            //{
            //goto IL_6F;
            //}
            //IL_51:
            //num = 7;
            //m_Map.CenterX = feature.CenterX;
            //IL_60:
            //num = 8;
            //m_Map.CenterY = feature.CenterY;
            //IL_6F:
            //num = 10;
            //if (feature.Type != FeatureTypeConstants.miFeatureTypeSymbol)
            //{
            //goto IL_8D;
            //}
            //IL_7C:
            //num = 11;
            //CBanDoNen.NhapNhayFeature(m_Map, feature, pSoLan);
            //IL_88:
            //goto IL_226;
            //IL_8D:
            //num = 13;
            //IL_91:
            //num = 14;
            //style = feature.Style;
            //IL_9D:
            //num = 15;
            //if (feature.Type != FeatureTypeConstants.miFeatureTypeLine)
            //{
            //goto IL_D3;
            //}
            //IL_AA:
            //num = 16;
            //style.LineColor = uint.Parse(Convert.ToString(255));
            //IL_C4:
            //num = 17;
            //style.LineStyle = (PenStyleConstants)46;
            //IL_D1:
            //goto IL_149;
            //IL_D3:
            //num = 19;
            //if (feature.Type != FeatureTypeConstants.miFeatureTypeRegion)
            //{
            //goto IL_122;
            //}
            //IL_E0:
            //num = 20;
            //style.RegionBorderColor = uint.Parse(Convert.ToString(16777215));
            //IL_FA:
            //num = 21;
            //style.RegionPattern = FillPatternConstants.miPatternDiagCross;
            //IL_106:
            //num = 22;
            //style.RegionColor = uint.Parse(Convert.ToString(255));
            //IL_120:
            //goto IL_149;
            //IL_122:
            //num = 24;
            //if (feature.Type != FeatureTypeConstants.miFeatureTypeText)
            //{
            //goto IL_149;
            //}
            //IL_12F:
            //num = 25;
            //style.TextFontColor = uint.Parse(Convert.ToString(16777215));
            //IL_149:
            //num = 27;
            //feature.Style = style;
            //IL_155:
            //num = 28;
            //Layer layer2 = m_Map.Layers.CreateLayer("tempAnimate", Missing.Value, 1, Missing.Value, Missing.Value);
            //IL_17F:
            //num = 29;
            //m_Map.Layers.AnimationLayer = layer2;
            //IL_18F:
            //num = 30;
            //layer2.AddFeature(feature, Missing.Value);
            //IL_1A0:
            //num = 31;
            //checked
            //{
            //for (int i = 1; i <= pSoLan; i++)
            //{
            //IL_1AB:
            //num = 32;
            //layer2.Visible = true;
            //IL_1B6:
            //num = 33;
            //Thread.Sleep(120);
            //IL_1C1:
            //num = 34;
            //Application.DoEvents();
            //IL_1CA:
            //num = 35;
            //layer2.Visible = false;
            //IL_1D5:
            //num = 36;
            //Thread.Sleep(120);
            //IL_1E0:
            //num = 37;
            //Application.DoEvents();
            //IL_1E9:
            //num = 38;
            //}
            //IL_1F6:
            //num = 39;
            //Thread.Sleep(200);
            //IL_204:
            //num = 40;
            //feature = null;
            //IL_20A:
            //num3 = 1;
            //IL_212:
            //num = 42;
            //m_Map.Layers.Remove("tempAnimate");
            //IL_226:
            //goto IL_379;
            //IL_22B:
            //num = 45;
            //IL_23C:
            //num = 46;
            //if (num4 != 0)
            //{
            //goto IL_254;
            //}
            //throw ProjectData.CreateProjectError(-2146828268);
            //IL_254:
            //num4 = 0;
            //IL_257:
            //IL_25C:
            //goto IL_379;
            //IL_261:;
            //}
            //int arg_268_0 = num4 + 1;
            //num4 = 0;
            //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], arg_268_0);
            //IL_331:
            //goto IL_36E;
            //num4 = num;
            //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
            //IL_34A:
            //goto IL_36E;
            //}
            //object arg_34C_0;
            //endfilter(arg_34C_0 is Exception & num3 != 0 & num4 == 0);
            //IL_36E:
            //throw ProjectData.CreateProjectError(-2146828237);
            //IL_379:
            //if (num4 != 0)
            //{
            //}
        }
        private static void NhapNhayFeature(AxMap m_Map, Feature pObj, int pSoLan)
        {
            //int num3 = 0;
            //int num4 = 0;
            //try
            //{
            //IL_00:
            //int num = 1;
            //Feature feature = new FeatureClass();
            //IL_09:
            //num = 2;
            //Style style = new StyleClass();
            //IL_13:
            //num = 3;
            //Style style2 = new StyleClass();
            //IL_1D:
            //num = 4;
            //uint num2 = 0u;
            //IL_28:
            //num3 = 2;
            //IL_30:
            //num = 6;
            //Layer layer = m_Map.Layers.CreateLayer("tempAnimate", Missing.Value, 1, Missing.Value, Missing.Value);
            //IL_59:
            //num = 7;
            //m_Map.Layers.AnimationLayer = layer;
            //IL_68:
            //num = 8;
            //style.SymbolFont.Name = "MapInfo Cartographic";
            //IL_7C:
            //num = 9;
            //style.SymbolFont.Size = new decimal(18L);
            //IL_94:
            //num = 10;
            //style.SymbolCharacter = 72;
            //IL_A1:
            //num = 11;
            //style.SymbolFontColor = uint.Parse(Convert.ToString(16711935));
            //IL_BB:
            //num = 12;
            //style2.SymbolFont.Name = "MapInfo Cartographic";
            //IL_D0:
            //num = 13;
            //style2.SymbolFont.Size = new decimal(18L);
            //IL_E8:
            //num = 14;
            //style2.SymbolCharacter = 72;
            //IL_F5:
            //num = 15;
            //style2.SymbolFontColor = uint.Parse(Convert.ToString(16777215));
            //IL_10F:
            //num = 16;
            //MapXLib.Point point = new PointClass();
            //IL_11A:
            //num = 17;
            //point.Set(pObj.Point.X, pObj.Point.Y);
            //IL_13B:
            //num = 18;
            //Feature feature2 = layer.AddFeature(m_Map.FeatureFactory.CreateSymbol(point, style), Missing.Value);
            //IL_15B:
            //num = 19;
            //checked
            //{
            //for (int i = 1; i <= pSoLan; i++)
            //{
            //IL_166:
            //num = 20;
            //Thread.Sleep(40);
            //IL_171:
            //num = 21;
            //Application.DoEvents();
            //IL_17A:
            //num = 22;
            //feature2.Style = style;
            //IL_187:
            //num = 23;
            //layer.UpdateFeature(feature2, feature2, Missing.Value);
            //IL_19A:
            //num = 24;
            //Thread.Sleep(40);
            //IL_1A5:
            //num = 25;
            //Application.DoEvents();
            //IL_1AE:
            //num = 26;
            //feature2.Style = style2;
            //IL_1BB:
            //num = 27;
            //layer.UpdateFeature(feature2, feature2, Missing.Value);
            //IL_1CE:
            //num = 28;
            //}
            //IL_1DB:
            //num = 29;
            //style = null;
            //IL_1E2:
            //num = 30;
            //style2 = null;
            //IL_1E9:
            //num = 31;
            //IL_1EF:
            //num = 32;
            //feature2 = null;
            //IL_1F6:
            //num3 = 1;
            //IL_1FE:
            //num = 34;
            //m_Map.Layers.Remove("tempAnimate");
            //IL_212:
            //goto IL_32C;
            //IL_217:
            //num = 36;
            //if (num4 != 0)
            //{
            //goto IL_22F;
            //}
            //throw ProjectData.CreateProjectError(-2146828268);
            //IL_22F:
            //num4 = 0;
            //IL_232:
            //IL_237:
            //goto IL_32C;
            //IL_23C:;
            //}
            //int arg_243_0 = num4 + 1;
            //num4 = 0;
            //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], arg_243_0);
            //IL_2E4:
            //goto IL_321;
            //num4 = num;
            //@switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3);
            //IL_2FD:
            //goto IL_321;
            //}
            //object arg_2FF_0;
            //endfilter(arg_2FF_0 is Exception & num3 != 0 & num4 == 0);
            //IL_321:
            //throw ProjectData.CreateProjectError(-2146828237);
            //IL_32C:
            //if (num4 != 0)
            //{
            //}
        }
    }
}
