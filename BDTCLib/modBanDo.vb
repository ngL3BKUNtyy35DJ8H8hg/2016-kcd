Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Math

Imports System.IO
Imports System.Xml
Imports DBiGraphicObjs.DBiGraphicObjects
Imports System.Windows.Forms

Module modBanDo
    Public cDecSepa As Char = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Public cGrpSepa As Char = Application.CurrentCulture.NumberFormat.NumberGroupSeparator

    Public Structure UNDOITEM
        Dim UndoSymbols As CSymbols
        Dim MapX As Double
        Dim MapY As Double
        Dim SeleSymbol As CSymbol
    End Structure

    Public Structure INTERSECTNODE
        Dim PT As PointF
        Dim NodeIndex As Integer
    End Structure

    Public Structure EDITNODE
        Dim r As Rectangle
        Dim iPart As Integer
        Dim iNode As Integer
    End Structure

    Public EditNodes() As EDITNODE
    Public EditNodesCount, iEditNode As Integer

    Public Const myToolInfo As Integer = 3
    Public Const NHAPNHAYDELAY As Integer = 100

    Public myDefaFileName As String = "Defas.def"
    Public myNewBdTC As String = "New.bdtc"
    Public LastBdTC As String = "New.bdtc"

    Public myTyLeKH2Map As Single = 1
    Public mySoPixelsPer1000m As Integer = 312
    Public myTyLeLayKH As Single = 1
    Public myDaLayKH As Boolean = False

    Public myKHQSMWidth As Integer = 1436
    Public myKHQSZoom As Integer = 3357
    'Public myFirstZoomLevel As Double = 5000
    'Public myFirstMapWidth As Single = 600

    Public myTinhChinhGocQuay As Double = 0.5

    Public fCacKyHieu As dlgCacKyHieu
    'Public fSearchKyHieu As frmSearchKyHieu

    'Public fTerrain As dlgTerrain
    Public myTextureFile As String = "LongThanh.jpg"
    Public myGridDataFile As String = "GridData.txt"
    Public myGRID_WIDTH As Integer = 101 '79
    Public myGRID_HEIGHT As Integer = 119 '88
    Public mySCALE_FACTOR As Single = 2 '20
    Public myFlag3DsFile As String = "Flag3Ds.xml"
    Public myResourcePath As String
    'Public myEffectFile As String
    Public mySaBanDir As String = "SaBan1"
    Public mySaBanDefFileName As String = "LastSaBan.def"

    Public myCacKyHieuUDL As String = "KHData.udl"
    Public myLoaiKH_ID As Long = 0

    Public MyOtherLineStyle As COtherLineStyle

    Public BDTyLeBanDo As Integer = 100000

    Public BDKinhDo As Double = 104.255
    Public BDViDo As Double = 17.0
    Public BDZoomLevel As Double = 4000

    Public DanhDauColor As Color = Color.FromArgb(75, Color.Red)
    Public DanhDauColor2 As Color = Color.FromArgb(75, Color.Black)
    Public VeBoundColor As Color = Color.FromKnownColor(KnownColor.HotTrack)


    Public defaUndosNo As Integer = 10
    Public stackUnDos() As UNDOITEM
    Public stackReDos() As UNDOITEM

    Public MaxStyle As Integer = 8
    Public ADStyles() As Integer

    Public defaMyLineStyle As Integer = 0

    Public QuanDoColor As Color = Color.Red
    Public QuanXanhColor As Color = Color.Blue
    Public myColor(31) As Color

    Public defaGenPen1W As Integer = 1
    Public defaGenPen1C As Color = Color.Red
    Public defaGenPen2W As Integer = 0
    Public defaGenPen2C As Color = Color.Yellow
    Public defaGenFill As Boolean = False
    Public defaGenFillC As Color = Color.Red
    Public defaGenLineStyle As Integer = 0

    Public defaSongSongSize As Integer = 6
    Public defaSongSongLinesNo As Integer = 2
    Public defaSongSongPen1W As Integer = 1
    Public defaSongSongPen1C As Color = Color.Red
    Public defaSongSongPen2W As Integer = 0
    Public defaSongSongPen2C As Color = Color.Yellow
    Public defaSongSongLineStyle As Integer = 0

    Public myMuiTenDoRong As Single = 30
    Public defaMuiTenDoRong As Single = 30
    Public defaMuiTenPen1W As Integer = 1
    Public defaMuiTenPen1C As Color = Color.Red
    Public defaMuiTenPen2W As Integer = 0
    Public defaMuiTenPen2C As Color = Color.Yellow
    Public defaMuiTenFill As Boolean = True
    Public defaMuiTenFillC As Color = Color.FromArgb(100, Color.Red) 'Color.Red

    Public defaMuiTenDacDoRong As Single = 6
    Public defaMuiTenDacPen1W As Integer = 1
    Public defaMuiTenDacPen1C As Color = Color.Red
    Public defaMuiTenDacPen2W As Integer = 0
    Public defaMuiTenDacPen2C As Color = Color.Yellow
    Public defaMuiTenDacFill As Boolean = True
    Public defaMuiTenDacFillC As Color = Color.FromArgb(255, Color.Red)
    Public defaMuiTenDacDoDai As Single = 100

    Public defaPiePen1W As Integer = 1
    Public defaPiePen1C As Color = Color.Red
    Public defaPiePen2W As Integer = 0
    Public defaPiePen2C As Color = Color.Yellow
    Public defaPieFill As Boolean = True
    Public defaPieFillC As Color = Color.FromArgb(100, Color.Red) 'Color.Red
    Public defaPieArc As Boolean = False
    Public defaPieStartA As Integer = 0
    Public defaPieSweepA As Integer = 90

    Public defaTableColsNo As Integer = 2
    Public defaTableRowsNo As Integer = 8
    Public defaTableBorderW As Integer = 1
    Public defaTableBorderC As Color = Color.Blue
    Public defaTableLineW As Integer = 1
    Public defaTableLineC As Color = Color.Gray
    Public defaTableFillC As Color = Color.FromArgb(100, Color.LightYellow)

    Public defaTableTFont As Font = New Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point)
    Public defaTableTFontName As String = "Tahoma"
    Public defaTableTFontSize As Single = 10
    Public defaTableTFontStyle As Integer = 0
    Public defaTableTextC As Color = Color.Black

    Public defaTextFont As Font = New Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point)
    Public defaTextFontName As String = "Tahoma"
    Public defaTextFontSize As Single = 10
    Public defaTextFontStyle As Single = 0
    Public defaTextC As Color = Color.Red

    Public defaImageWidth As Integer = 80 '40
    Public defaImageHeight As Integer = 40
    Public defaHorizontalSpacing As Integer = 10
    Public defaVerticalSpacing As Integer = 32 '16

    Public myMap1X As Double = 106.941953898199D
    Public myMap1Y As Double = 10.844428647015D
    Public mySurf1X As Double = 0D
    Public mySurf1Y As Double = 0D

    Public myMap2X As Double = 107.00178D
    Public myMap2Y As Double = 10.77494D
    Public mySurf2X As Double = 2047D
    Public mySurf2Y As Double = 2405D

    Public my3DSoPixelsPer1000m As Integer = 312

    Public Function GetSurfPosition(ByVal pMapX As Double, ByVal pMapY As Double) As PointF
        Dim kq As New PointF(0, 0)
        Dim mdX, mdY As Double

        mdX = (pMapX - myMap1X) * (mySurf2X - mySurf1X) / (myMap2X - myMap1X) + mySurf1X
        mdY = (myMap1Y - pMapY) * (mySurf2Y - mySurf1Y) / (myMap1Y - myMap2Y) + mySurf1Y
        kq.X = mdX '* myTyleTextureX
        kq.Y = mdY '* myTyleTextureY
        Return kq
    End Function

    Private Function GetIntersectPoint(ByVal PT1 As PointF, ByVal PT2 As PointF, ByVal PT3 As PointF, ByVal PT4 As PointF) As Object
        Dim mPT As PointF = Nothing

        Dim mPath1, mPath2 As GraphicsPath
        If PT2.X = PT1.X Then
            PT2.X += 1
        End If
        mPath1 = New GraphicsPath
        mPath1.AddLine(PT1, PT2)
        mPath2 = New GraphicsPath
        mPath2.AddLine(PT3, PT4)
        mPT = COtherLineStyle.GiaoDiem(PT1, PT2, PT3, PT4)
        If mPath1.IsOutlineVisible(mPT, New Pen(Color.Black, 2)) = True Then
            If mPath2.IsOutlineVisible(mPT, New Pen(Color.Black, 2)) = True Then
                Return mPT
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Private Function GetIntersectPoint(ByVal PT1 As PointF, ByVal PT2 As PointF, ByVal PTs() As PointF, ByVal index As Integer) As Object
        Dim mPT As Object
        Dim mINTERSECTNODE As INTERSECTNODE
        If PTs.GetUpperBound(0) >= index + 1 Then
            For i As Integer = index To PTs.GetUpperBound(0) - 1
                mPT = GetIntersectPoint(PT1, PT2, PTs(i), PTs(i + 1))
                If Not IsNothing(mPT) Then
                    mINTERSECTNODE.PT = CType(mPT, PointF)
                    mINTERSECTNODE.NodeIndex = i
                    Return mINTERSECTNODE
                End If
            Next

            Return Nothing
        Else
            Return Nothing
        End If
    End Function

    Public Function GetIntersectPoints(ByVal PT1 As PointF, ByVal PT2 As PointF, ByVal PTs() As PointF) As INTERSECTNODE()
        Dim mINTERSECTNODEs() As INTERSECTNODE
        Dim mINTERSECTNODE As Object
        Dim j As Integer = -1
        ReDim mINTERSECTNODEs(-1)
        Dim i As Integer = 0
        Do While i <= PTs.GetUpperBound(0)
            mINTERSECTNODE = GetIntersectPoint(PT1, PT2, PTs, i)
            If Not IsNothing(mINTERSECTNODE) Then
                j += 1
                ReDim Preserve mINTERSECTNODEs(j)
                mINTERSECTNODEs(j) = CType(mINTERSECTNODE, INTERSECTNODE)
                i = mINTERSECTNODEs(j).NodeIndex + 1
            Else
                Exit Do
            End If
        Loop
        Return mINTERSECTNODEs
    End Function

    Public Function AngleToPoint(ByVal Origin As PointF, ByVal Target As PointF) As Single
        Dim Angle As Single
        Target.X = Target.X - Origin.X
        Target.Y = Target.Y - Origin.Y
        Angle = Math.Atan2(Target.Y, Target.X) / (Math.PI / 180)
        Return Angle
    End Function

    Public Function ObjToCurve(ByVal pObj As GraphicObject) As GraphicObject
        Dim gObj As GraphicObject = Nothing

        Select Case pObj.GetObjType
            Case OBJECTTYPE.Line, OBJECTTYPE.Curve
                Dim mObj As ShapeGraphic = CType(pObj, ShapeGraphic)
                Dim mPath As GraphicsPath = mObj.GetPath()
                mPath.Flatten(New Matrix, 0.5)
                Dim pPts() As PointF = mPath.PathPoints
                Dim myCurve As New CurveGraphic(pPts, 1, Color.Red)
                myCurve.Rotation = 0
                myCurve.LineColor = mObj.LineColor
                myCurve.LineWidth = mObj.LineWidth
                myCurve.Line2Color = mObj.Line2Color
                myCurve.Line2Width = mObj.Line2Width
                myCurve.Fill = mObj.Fill
                myCurve.FillColor = mObj.FillColor
                myCurve.LineStyle = mObj.LineStyle
                gObj = myCurve

            Case OBJECTTYPE.Polygon, OBJECTTYPE.ClosedCurve
                Dim mObj As ShapeGraphic = CType(pObj, ShapeGraphic)
                Dim mPath As GraphicsPath = mObj.GetPath()
                mPath.Flatten(New Matrix, 0.5)
                Dim pPts() As PointF = mPath.PathPoints
                Dim myCurve As New ClosedCurveGraphic(pPts, 1, Color.Red)
                myCurve.Rotation = 0
                myCurve.LineColor = mObj.LineColor
                myCurve.LineWidth = mObj.LineWidth
                myCurve.Line2Color = mObj.Line2Color
                myCurve.Line2Width = mObj.Line2Width
                myCurve.Fill = mObj.Fill
                myCurve.FillColor = mObj.FillColor
                myCurve.LineStyle = mObj.LineStyle
                gObj = myCurve
            Case OBJECTTYPE.Ellipse, OBJECTTYPE.Cycle
                Dim mObj As ShapeGraphic = CType(pObj, ShapeGraphic)
                Dim mPath As GraphicsPath = mObj.GetPath()
                mPath.Flatten(New Matrix, 0.5)
                Dim pPts() As PointF = mPath.PathPoints
                Dim j As Integer = pPts.GetUpperBound(0)
                ReDim Preserve pPts(j - 1)
                Dim myCurve As New ClosedCurveGraphic(pPts, 1, Color.Red)
                myCurve.Rotation = 0
                myCurve.LineColor = mObj.LineColor
                myCurve.LineWidth = mObj.LineWidth
                myCurve.Line2Color = mObj.Line2Color
                myCurve.Line2Width = mObj.Line2Width
                myCurve.Fill = mObj.Fill
                myCurve.LineStyle = mObj.LineStyle
                myCurve.FillColor = mObj.FillColor
                gObj = myCurve
            Case OBJECTTYPE.Pie
                Dim mObj As PieGraphic = CType(pObj, PieGraphic)
                Dim mPath As GraphicsPath = mObj.GetPath()
                mPath.Flatten(New Matrix, 0.5)
                Dim pPts() As PointF = mPath.PathPoints
                If mObj.IsArc = True Then
                    Dim myCurve As New CurveGraphic(pPts, 1, Color.Red)
                    myCurve.Rotation = 0
                    myCurve.LineColor = mObj.LineColor
                    myCurve.LineWidth = mObj.LineWidth
                    myCurve.Line2Color = mObj.Line2Color
                    myCurve.Line2Width = mObj.Line2Width
                    myCurve.Fill = mObj.Fill
                    myCurve.FillColor = mObj.FillColor
                    myCurve.LineStyle = mObj.LineStyle
                    gObj = myCurve
                Else
                    Dim myCurve As New ClosedCurveGraphic(pPts, 1, Color.Red)
                    myCurve.Rotation = 0
                    myCurve.LineColor = mObj.LineColor
                    myCurve.LineWidth = mObj.LineWidth
                    myCurve.Line2Color = mObj.Line2Color
                    myCurve.Line2Width = mObj.Line2Width
                    myCurve.Fill = mObj.Fill
                    myCurve.FillColor = mObj.FillColor
                    myCurve.LineStyle = mObj.LineStyle
                    gObj = myCurve
                End If
        End Select

        If Not gObj Is Nothing Then
            Dim gObj2 As NodesShapeGraphic = CType(gObj, NodesShapeGraphic)
            For i As Integer = 0 To gObj2.Nodes.Count - 1
                gObj2.Nodes.Item(i).IsControl = True
            Next
            Return gObj2
        Else
            Return pObj
        End If
    End Function

    Public Sub LoadDefa(ByVal pFileName As String)
        Try
            Dim rr As XmlTextReader = New XmlTextReader(pFileName)
            XML2Defa(rr)
            rr.Close()

            defaTableTFont = New Font(defaTableTFontName, defaTableTFontSize, defaTableTFontStyle, GraphicsUnit.Point)
            defaTextFont = New Font(defaTextFontName, defaTextFontSize, defaTextFontStyle, GraphicsUnit.Point)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub XML2Defa(ByVal rr As XmlTextReader)

        Dim oNodeType As XmlNodeType
        Try
            Do While rr.Read
                oNodeType = rr.NodeType
                Select Case oNodeType
                    Case XmlNodeType.Element
                        Select Case rr.Name
                            Case "DEFAS"
                                If rr.AttributeCount > 0 Then
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "QuanDoColor"
                                                QuanDoColor = Color.FromArgb(rr.Value)
                                            Case "QuanXanhColor"
                                                QuanXanhColor = Color.FromArgb(rr.Value)
                                            Case "defaGenPen1W"
                                                defaGenPen1W = Int(rr.Value)
                                            Case "defaGenPen1C"
                                                defaGenPen1C = Color.FromArgb(rr.Value)
                                            Case "defaGenPen2W"
                                                defaGenPen2W = rr.Value
                                            Case "defaGenPen2C"
                                                defaGenPen2C = Color.FromArgb(rr.Value)
                                            Case "defaGenFill"
                                                defaGenFill = IIf(rr.Value = "True", True, False)
                                            Case "defaGenFillC"
                                                defaGenFillC = Color.FromArgb(rr.Value)
                                            Case "defaGenLineStyle"
                                                defaGenLineStyle = rr.Value
                                            Case "defaSongSongSize"
                                                defaSongSongSize = rr.Value
                                            Case "defaSongSongLinesNo"
                                                defaSongSongLinesNo = rr.Value
                                            Case "defaSongSongPen1W"
                                                defaSongSongPen1W = rr.Value
                                            Case "defaSongSongPen1C"
                                                defaSongSongPen1C = Color.FromArgb(rr.Value)
                                            Case "defaSongSongPen2W"
                                                defaSongSongPen2W = rr.Value
                                            Case "defaSongSongPen2C"
                                                defaSongSongPen2C = Color.FromArgb(rr.Value)
                                            Case "defaSongSongLineStyle"
                                                defaSongSongLineStyle = rr.Value

                                            Case "defaMuiTenDoRong"
                                                defaMuiTenDoRong = rr.Value
                                            Case "defaMuiTenPen1W"
                                                defaMuiTenPen1W = rr.Value
                                            Case "defaMuiTenPen1C"
                                                defaMuiTenPen1C = Color.FromArgb(rr.Value)
                                            Case "defaMuiTenPen2W"
                                                defaMuiTenPen2W = rr.Value
                                            Case "defaMuiTenPen2C"
                                                defaMuiTenPen2C = Color.FromArgb(rr.Value)
                                            Case "defaMuiTenFill"
                                                defaMuiTenFill = IIf(rr.Value = "True", True, False)
                                            Case "defaMuiTenFillC"
                                                defaMuiTenFillC = Color.FromArgb(rr.Value)

                                            Case "defaMuiTenDacDoDai"
                                                defaMuiTenDacDoDai = rr.Value
                                            Case "defaMuiTenDacDoRong"
                                                defaMuiTenDacDoRong = rr.Value
                                            Case "defaMuiTenDacPen1W"
                                                defaMuiTenDacPen1W = rr.Value
                                            Case "defaMuiTenDacPen1C"
                                                defaMuiTenDacPen1C = Color.FromArgb(rr.Value)
                                            Case "defaMuiTenDacPen2W"
                                                defaMuiTenDacPen2W = rr.Value
                                            Case "defaMuiTenDacPen2C"
                                                defaMuiTenDacPen2C = Color.FromArgb(rr.Value)
                                            Case "defaMuiTenDacFill"
                                                defaMuiTenDacFill = IIf(rr.Value = "True", True, False)
                                            Case "defaMuiTenDacFillC"
                                                defaMuiTenDacFillC = Color.FromArgb(rr.Value)

                                            Case "defaTableColsNo"
                                                defaTableColsNo = rr.Value
                                            Case "defaTableRowsNo"
                                                defaTableRowsNo = rr.Value
                                            Case "defaTableBorderW"
                                                defaTableBorderW = rr.Value
                                            Case "defaTableBorderC"
                                                defaTableBorderC = Color.FromArgb(rr.Value)
                                            Case "defaTableLineW"
                                                defaTableLineW = rr.Value
                                            Case "defaTableLineC"
                                                defaTableLineC = Color.FromArgb(rr.Value)
                                            Case "defaTableFillC"
                                                defaTableFillC = Color.FromArgb(rr.Value)

                                            Case "defaTableTFontName"
                                                defaTableTFontName = rr.Value
                                            Case "defaTableTFontSize"
                                                defaTableTFontSize = rr.Value
                                            Case "defaTableTFontStyle"
                                                defaTableTFontStyle = rr.Value
                                            Case "defaTableTextC"
                                                defaTableTextC = Color.FromArgb(rr.Value)

                                            Case "defaTextFontName"
                                                defaTextFontName = rr.Value
                                            Case "defaTextFontSize"
                                                defaTextFontSize = rr.Value
                                            Case "defaTextFontStyle"
                                                defaTextFontStyle = rr.Value
                                            Case "defaTextC"
                                                defaTextC = Color.FromArgb(rr.Value)
                                            Case "DanhDauColor"
                                                DanhDauColor = Color.FromArgb(rr.Value)
                                            Case "DanhDauColor2"
                                                DanhDauColor2 = Color.FromArgb(rr.Value)
                                            Case "VeBoundColor"
                                                VeBoundColor = Color.FromKnownColor(rr.Value) ' Color.FromKnownColor(KnownColor.HotTrack)

                                            Case "defaUndosNo"
                                                defaUndosNo = rr.Value
                                            Case "ColorsTable"
                                                Dim strColors As String = rr.Value
                                                Dim data() As String = strColors.Split(" "c)
                                                If data.GetUpperBound(0) = 31 Then
                                                    For i As Integer = 0 To 31
                                                        myColor(i) = Color.FromArgb(data(i))
                                                    Next
                                                End If

                                        End Select
                                    Loop
                                End If
                        End Select
                End Select
            Loop
        Catch e As Exception
            'MsgBox("Khong doc duoc Defa.")
            Throw e
        End Try
    End Sub

    Public Sub Defa2File(ByVal pFileName As String)
        Dim sw As New StreamWriter(pFileName)
        Dim wr As XmlTextWriter = New XmlTextWriter(sw)

        Defa2xml(wr)

        wr.Close()

    End Sub

    Private Sub Defa2xml(ByRef wr As XmlTextWriter)
        wr.WriteStartElement("DEFAS")

        wr.WriteAttributeString("QuanDoColor", QuanDoColor.ToArgb)
        wr.WriteAttributeString("QuanXanhColor", QuanXanhColor.ToArgb)

        wr.WriteAttributeString("defaGenPen1W", defaGenPen1W)
        wr.WriteAttributeString("defaGenPen1C", defaGenPen1C.ToArgb)
        wr.WriteAttributeString("defaGenPen2W", defaGenPen2W)
        wr.WriteAttributeString("defaGenPen2C", defaGenPen2C.ToArgb)
        wr.WriteAttributeString("defaGenFill", defaGenFill.ToString)
        wr.WriteAttributeString("defaGenFillC", defaGenFillC.ToArgb)
        wr.WriteAttributeString("defaGenLineStyle", defaGenLineStyle)

        wr.WriteAttributeString("defaSongSongSize", defaSongSongSize)
        wr.WriteAttributeString("defaSongSongLinesNo", defaSongSongLinesNo)
        wr.WriteAttributeString("defaSongSongPen1W", defaSongSongPen1W)
        wr.WriteAttributeString("defaSongSongPen1C", defaSongSongPen1C.ToArgb)
        wr.WriteAttributeString("defaSongSongPen2W", defaSongSongPen2W)
        wr.WriteAttributeString("defaSongSongPen2C", defaSongSongPen2C.ToArgb)
        wr.WriteAttributeString("defaSongSongLineStyle", defaSongSongLineStyle)

        wr.WriteAttributeString("defaMuiTenDoRong", defaMuiTenDoRong)
        wr.WriteAttributeString("defaMuiTenPen1W", defaMuiTenPen1W)
        wr.WriteAttributeString("defaMuiTenPen1C", defaMuiTenPen1C.ToArgb)
        wr.WriteAttributeString("defaMuiTenPen2W", defaMuiTenPen2W)
        wr.WriteAttributeString("defaMuiTenPen2C", defaMuiTenPen2C.ToArgb)
        wr.WriteAttributeString("defaMuiTenFill", defaMuiTenFill.ToString)
        wr.WriteAttributeString("defaMuiTenFillC", defaMuiTenFillC.ToArgb) 'Color.Red

        wr.WriteAttributeString("defaMuiTenDacDoDai", defaMuiTenDacDoDai)
        wr.WriteAttributeString("defaMuiTenDacDoRong", defaMuiTenDacDoRong)
        wr.WriteAttributeString("defaMuiTenDacPen1W", defaMuiTenDacPen1W)
        wr.WriteAttributeString("defaMuiTenDacPen1C", defaMuiTenDacPen1C.ToArgb)
        wr.WriteAttributeString("defaMuiTenDacPen2W", defaMuiTenDacPen2W)
        wr.WriteAttributeString("defaMuiTenDacPen2C", defaMuiTenDacPen2C.ToArgb)
        wr.WriteAttributeString("defaMuiTenDacFill", defaMuiTenDacFill.ToString)
        wr.WriteAttributeString("defaMuiTenDacFillC", defaMuiTenDacFillC.ToArgb) 'Color.Red

        wr.WriteAttributeString("defaTableColsNo", defaTableColsNo)
        wr.WriteAttributeString("defaTableRowsNo", defaTableRowsNo)
        wr.WriteAttributeString("defaTableBorderW", defaTableBorderW)
        wr.WriteAttributeString("defaTableBorderC", defaTableBorderC.ToArgb)
        wr.WriteAttributeString("defaTableLineW", defaTableLineW)
        wr.WriteAttributeString("defaTableLineC", defaTableLineC.ToArgb)
        wr.WriteAttributeString("defaTableFillC", defaTableFillC.ToArgb)

        'wr.WriteAttributeString("defaTableTFont As Font = New Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point)
        wr.WriteAttributeString("defaTableTFontName", defaTableTFontName)
        wr.WriteAttributeString("defaTableTFontSize", defaTableTFontSize)
        wr.WriteAttributeString("defaTableTFontStyle", defaTableTFontStyle)
        wr.WriteAttributeString("defaTableTextC", defaTableTextC.ToArgb)

        'wr.WriteAttributeString("defaTextFont As Font = New Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point)
        wr.WriteAttributeString("defaTextFontName", defaTextFontName)
        wr.WriteAttributeString("defaTextFontSize", defaTextFontSize)
        wr.WriteAttributeString("defaTextFontStyle", defaTextFontStyle)
        wr.WriteAttributeString("defaTextC", defaTextC.ToArgb)

        wr.WriteAttributeString("DanhDauColor", DanhDauColor.ToArgb)
        wr.WriteAttributeString("DanhDauColor2", DanhDauColor2.ToArgb)
        wr.WriteAttributeString("VeBoundColor", VeBoundColor.ToKnownColor) ' Color.FromKnownColor(KnownColor.HotTrack)

        wr.WriteAttributeString("defaUndosNo", defaUndosNo)

        Dim strColors As String = myColor(0).ToArgb
        For i As Integer = 1 To 31
            strColors &= " " & myColor(i).ToArgb
        Next
        wr.WriteAttributeString("ColorsTable", strColors)

        wr.WriteEndElement()
    End Sub

    Public Function GetMauGoc(ByVal pColor As Color) As Color
        Dim MyDialog As New ColorDialog
        MyDialog.AllowFullOpen = True
        MyDialog.ShowHelp = True
        MyDialog.Color = pColor
        If MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return MyDialog.Color
        Else
            Return pColor
        End If
    End Function

    Public Function GetMau(ByVal pColor As Color) As Color
        Dim MyDialog As New dlgGetColor
        MyDialog.SeleColor = pColor
        MyDialog.TopMost = True
        If MyDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Return MyDialog.SeleColor
        Else
            Return pColor
        End If
    End Function

End Module
