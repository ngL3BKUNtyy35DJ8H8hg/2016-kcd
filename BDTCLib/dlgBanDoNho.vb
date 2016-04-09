Imports System.Windows.Forms
Imports System.Drawing

Public Class dlgBanDoNho

    Dim fHinhChuNhat As MapXLib.Feature

    Private Sub InitHinhChuNhat()
        Dim lyr As MapXLib.Layer

        lyr = AxMap1.Layers.CreateLayer("tempAnimate", , 1)
        AxMap1.Layers.AnimationLayer = lyr

        Dim mStyle As New MapXLib.Style()

        mStyle.LineWidth = 1
        mStyle.LineColor = UInteger.Parse(MapXLib.ColorConstants.miColorRed) 'mColor.Parse(MapXLib.ColorConstants.miColorRed)
        Dim pts As New MapXLib.Points()
        Dim pt As New MapXLib.Point()
        pt.Set(fMain.AxMap1.CtlBounds.XMin, fMain.AxMap1.CtlBounds.YMin)
        pts.Add(pt)
        pt.Set(fMain.AxMap1.CtlBounds.XMax, fMain.AxMap1.CtlBounds.YMin)
        pts.Add(pt)
        pt.Set(fMain.AxMap1.CtlBounds.XMax, fMain.AxMap1.CtlBounds.YMax)
        pts.Add(pt)
        pt.Set(fMain.AxMap1.CtlBounds.XMin, fMain.AxMap1.CtlBounds.YMax)
        pts.Add(pt)
        pt.Set(fMain.AxMap1.CtlBounds.XMin, fMain.AxMap1.CtlBounds.YMin)
        pts.Add(pt)

        'f.Parts.Add(pts)
        fHinhChuNhat = AxMap1.Layers.Item("tempAnimate").AddFeature(AxMap1.FeatureFactory.CreateLine(pts, mStyle))
        pt = Nothing
        pts = Nothing
        'f = Nothing

    End Sub

    Public Sub UpdateHinhChuNhat()
        Dim pts As MapXLib.Points
        Dim pt As MapXLib.Point
        pts = fHinhChuNhat.Parts.Item(1)
        pt = pts.Item(1)
        pt.Set(fMain.AxMap1.CtlBounds.XMin, fMain.AxMap1.CtlBounds.YMin)
        pt = pts.Item(2)
        pt.Set(fMain.AxMap1.CtlBounds.XMax, fMain.AxMap1.CtlBounds.YMin)
        pt = pts.Item(3)
        pt.Set(fMain.AxMap1.CtlBounds.XMax, fMain.AxMap1.CtlBounds.YMax)
        pt = pts.Item(4)
        pt.Set(fMain.AxMap1.CtlBounds.XMin, fMain.AxMap1.CtlBounds.YMax)
        pt = pts.Item(5)
        pt.Set(fMain.AxMap1.CtlBounds.XMin, fMain.AxMap1.CtlBounds.YMin)
        pt = Nothing
        pts = Nothing
        fHinhChuNhat.Update()
    End Sub

    Private Sub dlgBanDoNho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fBanDoNho = Me

        Dim mL, mT As Integer
        mL = CInt(GetSetting(Application.ProductName, "Settings", "BDNhoLeft", "0"))
        mT = CInt(GetSetting(Application.ProductName, "Settings", "BDNhoTop", "0"))
        If mL > intMonitorW Then mL = 0
        If mT > intMonitorH Then mT = 0
        Me.Left = mL
        Me.Top = mT
        Me.Width = CInt(GetSetting(Application.ProductName, "Settings", "BDNhoWidth", Me.Width.ToString))
        Me.Height = CInt(GetSetting(Application.ProductName, "Settings", "BDNhoHeight", Me.Height.ToString))

        Try
            Me.AxMap1.GeoSet = myMapNhoGst 'Application.StartupPath & "\\BanDoNho.gst"
            Me.AxMap1.Title.Visible = False
            Me.AxMap1.InfotipSupport = False

            Dim mydcs As MapXLib.CoordSys
            mydcs = Me.AxMap1.DisplayCoordSys
            Me.AxMap1.NumericCoordSys = mydcs
            'moi them
            Me.AxMap1.NumericCoordSys.Set(myCoordSysType, Me.AxMap1.NumericCoordSys.Datum, _
            Me.AxMap1.NumericCoordSys.Units, Me.AxMap1.NumericCoordSys.OriginLongitude, Me.AxMap1.NumericCoordSys.OriginLatitude, _
            Me.AxMap1.NumericCoordSys.StandardParallelOne, Me.AxMap1.NumericCoordSys.StandardParallelTwo, _
            Me.AxMap1.NumericCoordSys.Azimuth, Me.AxMap1.NumericCoordSys.ScaleFactor, _
        Me.AxMap1.NumericCoordSys.FalseEasting, Me.AxMap1.NumericCoordSys.FalseNorthing, _
        Me.AxMap1.NumericCoordSys.Range)

            Me.AxMap1.PaperUnit = MapXLib.PaperUnitConstants.miPaperUnitPoint
        Catch
        End Try

        fMain.myBando.bBanDo2Loaded = True
        fMain.ToolStripMenuBDView.Checked = True

        InitHinhChuNhat()

    End Sub

    Private Sub frmBanDoNho_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (Me.WindowState <> FormWindowState.Minimized) Or (Me.WindowState <> FormWindowState.Maximized) Then
            SaveSetting(Application.ProductName, "Settings", "BDNhoLeft", Me.Left.ToString)
            SaveSetting(Application.ProductName, "Settings", "BDNhoTop", Me.Top.ToString)
            SaveSetting(Application.ProductName, "Settings", "BDNhoWidth", Me.Width.ToString)
            SaveSetting(Application.ProductName, "Settings", "BDNhoHeight", Me.Height.ToString)
        End If
        fMain.myBando.bBanDo2Loaded = False
        fMain.ToolStripMenuBDView.Checked = False
        fBanDoNho = Nothing
    End Sub

    Private Sub AxMap1_MouseDownEvent(ByVal sender As Object, ByVal e As AxMapXLib.CMapXEvents_MouseDownEvent) Handles AxMap1.MouseDownEvent
        Dim mLon, mLat As Double
        If (e.button = 1) And (AxMap1.CurrentTool = MapXLib.ToolConstants.miArrowTool) Then
            AxMap1.ConvertCoord(e.x, e.y, mLon, mLat, MapXLib.ConversionConstants.miScreenToMap)
            fMain.AxMap1.ZoomTo(fMain.AxMap1.Zoom, mLon, mLat)
        End If
    End Sub

    Private Sub AxMap1_MouseMoveEvent(ByVal sender As Object, ByVal e As AxMapXLib.CMapXEvents_MouseMoveEvent) Handles AxMap1.MouseMoveEvent
        Dim mLon, mLat As Double
        AxMap1.ConvertCoord(e.x, e.y, mLon, mLat, MapXLib.ConversionConstants.miScreenToMap)
        Me.Text = "X:" & Format(mLon, "000.000") & " Y:" & Format(mLat, "00.000")

        If (e.button = 1) And (AxMap1.CurrentTool = MapXLib.ToolConstants.miArrowTool) Then
            fMain.AxMap1.ZoomTo(fMain.AxMap1.Zoom, mLon, mLat)
        End If
    End Sub

    Private Sub AxMap1_MouseUpEvent(ByVal sender As Object, ByVal e As AxMapXLib.CMapXEvents_MouseUpEvent) Handles AxMap1.MouseUpEvent
        If e.button = 2 Then
            Dim pt As New Point(e.x, e.y)
            ContextMenu1.Show(Me, pt)
        End If
    End Sub

    Private Sub MnuZoomIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuZoomIn.Click
        AxMap1.CurrentTool = MapXLib.ToolConstants.miZoomInTool
    End Sub

    Private Sub MnuZoomOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuZoomOut.Click
        AxMap1.CurrentTool = MapXLib.ToolConstants.miZoomOutTool
    End Sub

    Private Sub MnuPan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuPan.Click
        AxMap1.CurrentTool = MapXLib.ToolConstants.miPanTool
    End Sub

    Private Sub MnuArrow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuArrow.Click
        AxMap1.CurrentTool = MapXLib.ToolConstants.miArrowTool
    End Sub

    Private Sub MnuLayers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuLayers.Click
        AxMap1.Layers.LayersDlg()
    End Sub

    Private Sub MnuSaveGeoSet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuSaveGeoSet.Click
        Try
            AxMap1.SaveMapAsGeoset("BanDoNho", myMapNhoGst)
        Catch
        End Try
    End Sub

End Class
