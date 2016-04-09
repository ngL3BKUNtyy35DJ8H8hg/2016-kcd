Imports System
Imports System.IO
Imports System.Xml

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Math

Imports DBiGraphicObjs.DBiGraphicObjects
Imports System.Windows.Forms

Public Structure MAPPOINT
    Dim X As Double
    Dim Y As Double
End Structure

Public Class CBanDo

#Region " Define Components "
    Friend WithEvents CxtMnuLineStyle As System.Windows.Forms.ContextMenu


    Friend WithEvents CxtMnuKyHieu As System.Windows.Forms.ContextMenu
    'Friend WithEvents MnuKHMoveByLonLat As System.Windows.Forms.MenuItem
    'Friend WithEvents MnuKHBar0 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuKHMove As System.Windows.Forms.MenuItem
    Friend WithEvents MnuKHBar1 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuScale As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuRotate As System.Windows.Forms.MenuItem
    Friend WithEvents MnuKHBar3 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuVFlip As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuEditNodes As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuChangeRoot As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuChangeDesc As System.Windows.Forms.MenuItem
    Friend WithEvents MnuKHBar2 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuBlinking As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuDeleteKH As System.Windows.Forms.MenuItem
    Friend WithEvents MnuPartsBar As System.Windows.Forms.MenuItem
    Friend WithEvents MnuParts As System.Windows.Forms.MenuItem

    Friend WithEvents MnuCopyKHprev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuCopyKH As System.Windows.Forms.MenuItem

    Friend WithEvents MnuCopyToVeKHprev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuCopyToVeKH As System.Windows.Forms.MenuItem
    'SendBack
    Friend WithEvents MnuSendBackprev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuSendBack As System.Windows.Forms.MenuItem

    Friend WithEvents MnuSendFrontprev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuSendFront As System.Windows.Forms.MenuItem

    Friend WithEvents MnuCutPrev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuCut As System.Windows.Forms.MenuItem

    Friend WithEvents MnuToCurvePrev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuToCurve As System.Windows.Forms.MenuItem

    Friend WithEvents MnuToPhanRaPrev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuToPhanRa As System.Windows.Forms.MenuItem

    Friend WithEvents MnuClosed2Curveprev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuClosed2Curve As System.Windows.Forms.MenuItem
    Friend WithEvents MnuCurve2Closedprev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuCurve2Closed As System.Windows.Forms.MenuItem

    Friend WithEvents MnuTo1stNodeprev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuTo1stNode As System.Windows.Forms.MenuItem

    Friend WithEvents MnuTo1ObjectPrev As System.Windows.Forms.MenuItem
    Friend WithEvents MnuTo1Object As System.Windows.Forms.MenuItem

    Friend WithEvents CxtMnuGroup As System.Windows.Forms.ContextMenu
    Friend WithEvents MnuGrMove As System.Windows.Forms.MenuItem
    Friend WithEvents MnuGrBar1 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuGrCopy As System.Windows.Forms.MenuItem
    Friend WithEvents MnuGrBar2 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuGrCut As System.Windows.Forms.MenuItem
    Friend WithEvents MnuGrBar3 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuGrChangeColor As System.Windows.Forms.MenuItem
    Friend WithEvents MnuGrBar4 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuGrNhom As System.Windows.Forms.MenuItem

    Friend WithEvents CxtMnuPart As System.Windows.Forms.ContextMenu
    Friend WithEvents MnuChangeColor As System.Windows.Forms.MenuItem
    Friend WithEvents MnuPartBar1 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuDeleteShape As System.Windows.Forms.MenuItem
    Friend WithEvents MnuPartBar2 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuPartSendBack As System.Windows.Forms.MenuItem
    Friend WithEvents MnuPartBar3 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuPartSendFront As System.Windows.Forms.MenuItem
    Friend WithEvents MnuPartBar4 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuPartTachObject As System.Windows.Forms.MenuItem

    Friend WithEvents CxtMnuNodeEdit As System.Windows.Forms.ContextMenu
    Friend WithEvents MnXoaNode As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuAddNode As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuChangeNodeType As System.Windows.Forms.MenuItem

    Friend WithEvents CxtMnuMap As System.Windows.Forms.ContextMenu
    Friend WithEvents MnuPastKH As System.Windows.Forms.MenuItem
    'Friend WithEvents MnuMapBar1 As System.Windows.Forms.MenuItem
    'Friend WithEvents MnuMapKHsFromFile As System.Windows.Forms.MenuItem
    'Friend WithEvents MnuMapBar2 As System.Windows.Forms.MenuItem
    'Friend WithEvents MnuMapKHsFromTT As System.Windows.Forms.MenuItem

    Private Sub InitializeComponent()
        'CxtMnuKyHieu = New System.Windows.Forms.ContextMenu()
        'MnuCopyKH = New System.Windows.Forms.MenuItem()
        'CxtMnuKyHieu.MenuItems.Add(MnuCopyKH)
        'MnuCopyKH.Text = "Copy Ky hieu"

        Me.CxtMnuGroup = New System.Windows.Forms.ContextMenu
        Me.MnuGrMove = New System.Windows.Forms.MenuItem
        Me.MnuGrBar1 = New System.Windows.Forms.MenuItem
        Me.MnuGrCopy = New System.Windows.Forms.MenuItem
        Me.MnuGrBar2 = New System.Windows.Forms.MenuItem
        Me.MnuGrCut = New System.Windows.Forms.MenuItem
        Me.MnuGrBar3 = New System.Windows.Forms.MenuItem
        Me.MnuGrChangeColor = New System.Windows.Forms.MenuItem
        Me.MnuGrBar4 = New System.Windows.Forms.MenuItem
        Me.MnuGrNhom = New System.Windows.Forms.MenuItem

        Me.CxtMnuPart = New System.Windows.Forms.ContextMenu
        Me.MnuChangeColor = New System.Windows.Forms.MenuItem
        Me.MnuPartBar1 = New System.Windows.Forms.MenuItem
        Me.MnuDeleteShape = New System.Windows.Forms.MenuItem
        Me.MnuPartBar2 = New System.Windows.Forms.MenuItem
        Me.MnuPartSendBack = New System.Windows.Forms.MenuItem
        Me.MnuPartBar3 = New System.Windows.Forms.MenuItem
        Me.MnuPartSendFront = New System.Windows.Forms.MenuItem
        Me.MnuPartBar4 = New System.Windows.Forms.MenuItem
        Me.MnuPartTachObject = New System.Windows.Forms.MenuItem

        Me.CxtMnuNodeEdit = New System.Windows.Forms.ContextMenu
        Me.MnXoaNode = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MnuAddNode = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MnuChangeNodeType = New System.Windows.Forms.MenuItem

        Me.CxtMnuKyHieu = New System.Windows.Forms.ContextMenu
        'Me.MnuKHMoveByLonLat = New System.Windows.Forms.MenuItem
        'Me.MnuKHBar0 = New System.Windows.Forms.MenuItem
        Me.MnuKHMove = New System.Windows.Forms.MenuItem
        Me.MnuKHBar1 = New System.Windows.Forms.MenuItem
        Me.MnuScale = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MnuRotate = New System.Windows.Forms.MenuItem
        Me.MnuKHBar3 = New System.Windows.Forms.MenuItem
        Me.MnuVFlip = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MnuEditNodes = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MnuChangeRoot = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MnuChangeDesc = New System.Windows.Forms.MenuItem
        Me.MnuKHBar2 = New System.Windows.Forms.MenuItem
        Me.MnuBlinking = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MnuDeleteKH = New System.Windows.Forms.MenuItem

        Me.CxtMnuMap = New System.Windows.Forms.ContextMenu
        Me.MnuPastKH = New System.Windows.Forms.MenuItem
        'Me.MnuMapBar1 = New System.Windows.Forms.MenuItem
        'Me.MnuMapKHsFromFile = New System.Windows.Forms.MenuItem
        'Me.MnuMapBar2 = New System.Windows.Forms.MenuItem
        'Me.MnuMapKHsFromTT = New System.Windows.Forms.MenuItem

        Me.CxtMnuGroup.MenuItems.AddRange(New System.Windows.Forms.MenuItem() { _
        Me.MnuGrMove, Me.MnuGrBar1, _
        Me.MnuGrCopy, Me.MnuGrBar2, Me.MnuGrCut, _
        Me.MnuGrBar3, Me.MnuGrChangeColor, _
        Me.MnuGrBar4, Me.MnuGrNhom})

        Me.MnuGrMove.Text = "Di chuyển Nhóm Ký hiệu"
        Me.MnuGrBar1.Text = "-"
        Me.MnuGrCopy.Text = "Copy Nhóm Ký hiệu"
        Me.MnuGrBar2.Text = "-"
        Me.MnuGrCut.Text = "Xoá cả Nhóm Ký hiệu"
        Me.MnuGrBar3.Text = "-"
        Me.MnuGrChangeColor.Text = "Thay Mầu,Nét,Kiểu Nét"
        Me.MnuGrBar4.Text = "-"
        Me.MnuGrNhom.Text = "Nhóm thành 1 Ký hiệu"

        Me.CxtMnuPart.MenuItems.AddRange(New System.Windows.Forms.MenuItem() { _
        Me.MnuChangeColor, Me.MnuPartBar1, Me.MnuDeleteShape, _
        Me.MnuPartBar2, Me.MnuPartSendBack, Me.MnuPartBar3, Me.MnuPartSendFront, _
        Me.MnuPartBar4, Me.MnuPartTachObject})
        Me.MnuChangeColor.Text = "Đổi chi tiết"
        Me.MnuPartBar1.Text = "-"
        Me.MnuDeleteShape.Text = "Xóa chi tiết"
        Me.MnuPartBar2.Text = "-"
        Me.MnuPartSendBack.Text = "Chi tiết Xuống dưới"
        Me.MnuPartBar3.Text = "-"
        Me.MnuPartSendFront.Text = "Chi tiết Lên trên"
        Me.MnuPartBar4.Text = "-"
        Me.MnuPartTachObject.Text = "Tách thành KH riêng"

        Me.CxtMnuNodeEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnXoaNode, Me.MenuItem5, Me.MnuAddNode, Me.MenuItem7, Me.MnuChangeNodeType})
        Me.MnXoaNode.Text = "Xóa nút"
        Me.MenuItem5.Text = "-"
        Me.MnuAddNode.Text = "Thêm nút"
        Me.MenuItem7.Text = "-"
        Me.MnuChangeNodeType.Text = "Đổi Kiểu nút"

        MnuTo1stNodeprev = New System.Windows.Forms.MenuItem
        MnuTo1stNode = New System.Windows.Forms.MenuItem
        Me.CxtMnuNodeEdit.MenuItems.Add(MnuTo1stNodeprev)
        Me.CxtMnuNodeEdit.MenuItems.Add(MnuTo1stNode)
        MnuTo1stNodeprev.Text = "-"
        MnuTo1stNode.Text = "Thành nút đầu"

        MnuTo1ObjectPrev = New System.Windows.Forms.MenuItem
        MnuTo1Object = New System.Windows.Forms.MenuItem
        Me.CxtMnuNodeEdit.MenuItems.Add(MnuTo1ObjectPrev)
        Me.CxtMnuNodeEdit.MenuItems.Add(MnuTo1Object)
        MnuTo1ObjectPrev.Text = "-"
        MnuTo1Object.Text = "Nối chi tiết"

        '
        MnuCutPrev = New System.Windows.Forms.MenuItem
        MnuCut = New System.Windows.Forms.MenuItem

        MnuToCurvePrev = New System.Windows.Forms.MenuItem
        MnuToCurve = New System.Windows.Forms.MenuItem

        MnuToPhanRaPrev = New System.Windows.Forms.MenuItem
        MnuToPhanRa = New System.Windows.Forms.MenuItem

        Me.CxtMnuKyHieu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() _
        {Me.MnuKHMove, Me.MnuKHBar1, Me.MnuScale, Me.MenuItem8, Me.MnuRotate, _
        Me.MnuKHBar3, Me.MnuVFlip, Me.MnuCutPrev, Me.MnuCut, Me.MnuToCurvePrev, Me.MnuToCurve, _
        Me.MnuToPhanRaPrev, Me.MnuToPhanRa, _
        Me.MenuItem10, Me.MnuEditNodes, Me.MenuItem11, Me.MnuChangeRoot, _
        Me.MenuItem13, Me.MnuChangeDesc, Me.MnuKHBar2, Me.MnuBlinking, _
        Me.MenuItem9, Me.MnuDeleteKH})
        'Me.MnuKHMoveByLonLat.Text = "Nhẩy Ký hiệu đến toạ độ"
        'Me.MnuKHBar0.Text = "-"
        Me.MnuKHMove.Text = "Dời Ký hiệu"
        Me.MnuKHBar1.Text = "-"
        Me.MnuScale.Text = "Thu-Phóng Ký hiệu"
        Me.MenuItem8.Text = "-"
        Me.MnuRotate.Text = "Quay Ký hiệu"
        Me.MnuKHBar3.Text = "-"
        Me.MnuVFlip.Text = "Lật Ký hiệu"
        Me.MnuCutPrev.Text = "-"
        Me.MnuCut.Text = "Cắt đôi Ký hiệu"
        Me.MnuToCurvePrev.Text = "-"
        Me.MnuToCurve.Text = "Đổi thành đường cong"
        Me.MnuToPhanRaPrev.Text = "-"
        Me.MnuToPhanRa.Text = "Tách tất cả các chi tiết"
        Me.MenuItem10.Text = "-"
        Me.MnuEditNodes.Text = "Tinh chỉnh"
        Me.MenuItem11.Text = "-"
        Me.MnuChangeRoot.Text = "Thay đổi gốc KH"
        Me.MenuItem13.Text = "-"
        Me.MnuChangeDesc.Text = "Đổi ghi chú"
        Me.MnuKHBar2.Text = "-"
        Me.MnuBlinking.Text = "Nhấp nháy"
        Me.MenuItem9.Text = "-"
        Me.MnuDeleteKH.Text = "Xóa Ký Hiệu"
        '
        Me.CxtMnuMap.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuPastKH})
        Me.MnuPastKH.Text = "Dán Ký hiệu"
        'Me.MnuMapBar1.Text = "-"
        'Me.MnuMapKHsFromFile.Text = "Lấy các Ký Hiệu từ tệp .TBD"
        'Me.MnuMapBar2.Text = "-"
        'Me.MnuMapKHsFromTT.Text = "Lấy các Ký Hiệu từ Tin tức"

        MnuCopyKHprev = New System.Windows.Forms.MenuItem
        MnuCopyKH = New System.Windows.Forms.MenuItem
        CxtMnuKyHieu.MenuItems.Add(MnuCopyKHprev)
        CxtMnuKyHieu.MenuItems.Add(MnuCopyKH)
        MnuCopyKHprev.Text = "-"
        MnuCopyKH.Text = "Copy Ký hiệu"

        MnuCopyToVeKHprev = New System.Windows.Forms.MenuItem
        MnuCopyToVeKH = New System.Windows.Forms.MenuItem
        CxtMnuKyHieu.MenuItems.Add(MnuCopyToVeKHprev)
        CxtMnuKyHieu.MenuItems.Add(MnuCopyToVeKH)
        MnuCopyToVeKHprev.Text = "-"
        MnuCopyToVeKH.Text = "Copy sang Các Ký hiệu"

        MnuSendBackprev = New System.Windows.Forms.MenuItem
        MnuSendBack = New System.Windows.Forms.MenuItem
        CxtMnuKyHieu.MenuItems.Add(MnuSendBackprev)
        CxtMnuKyHieu.MenuItems.Add(MnuSendBack)
        MnuSendBackprev.Text = "-"
        MnuSendBack.Text = "Cho xuống dưới"

        MnuSendFrontprev = New System.Windows.Forms.MenuItem
        MnuSendFront = New System.Windows.Forms.MenuItem
        CxtMnuKyHieu.MenuItems.Add(MnuSendFrontprev)
        CxtMnuKyHieu.MenuItems.Add(MnuSendFront)
        MnuSendFrontprev.Text = "-"
        MnuSendFront.Text = "Cho lên trên"

        Me.MnuPartsBar = New System.Windows.Forms.MenuItem
        Me.MnuParts = New System.Windows.Forms.MenuItem
        CxtMnuKyHieu.MenuItems.Add(MnuPartsBar)
        CxtMnuKyHieu.MenuItems.Add(MnuParts)
        MnuPartsBar.Text = "-"
        MnuParts.Text = "Thay đổi chi tiết"
        Me.MnuParts.MenuItems.AddRange(New System.Windows.Forms.MenuItem() _
        {Me.MnuChangeColor, Me.MnuPartBar1, Me.MnuDeleteShape, _
        Me.MnuPartBar2, Me.MnuPartSendBack, Me.MnuPartBar3, Me.MnuPartSendFront, _
        Me.MnuPartBar4, Me.MnuPartTachObject})

        MnuClosed2Curveprev = New System.Windows.Forms.MenuItem
        MnuClosed2Curve = New System.Windows.Forms.MenuItem
        MnuParts.MenuItems.Add(MnuClosed2Curveprev)
        MnuParts.MenuItems.Add(MnuClosed2Curve)
        MnuClosed2Curveprev.Text = "-"
        MnuClosed2Curve.Text = "Mở đường kép kín"

        MnuCurve2Closedprev = New System.Windows.Forms.MenuItem
        MnuCurve2Closed = New System.Windows.Forms.MenuItem
        MnuParts.MenuItems.Add(MnuCurve2Closedprev)
        MnuParts.MenuItems.Add(MnuCurve2Closed)
        MnuCurve2Closedprev.Text = "-"
        MnuCurve2Closed.Text = "Kép kín đường mở"

    End Sub
#End Region

    Private Structure SPLITSYMBOLS
        Dim Symbol1 As CSymbol
        Dim Symbol2 As CSymbol
    End Structure

    Public Enum MapTools
        None

        Polygon
        Line
        Curve
        ClosedCurve
        Bezier
        Cycle
        Rectangle
        arc

        Text
        Table

        MuiTenDon
        MuiTen
        MuiTenDac
        MuiTenHo
        SongSong
        SongSongKin
        'KHMoi
        ChonKH

        Move
        DangMove
        Scale
        DangScale
        Rotate
        DangRotate

        GrMove
        GrDangMove

        Split
        DangSplit

        DangLayKH

        NodesEdit
        ChangeRoot

        'ObjNodesEdit

        Ruler

        GetTarget
        GetObjName
        'AddKH
    End Enum

    Private iUndo As Integer = -1
    Private iRedo As Integer = -1

    Private myMapScreenWidth As Single = 677
    Public myMapCurrTool

    'Private BlinkProcess1 As BlinkProcess

    Public myMapTool As MapTools

    Private myPts() As PointF
    Private myfromPt, mytoPt, myrootPt As PointF

    Private m_SelectedSymbol As CSymbol
    Private m_CopySymbol As CSymbol
    Private m_KHfromVeKH As CSymbol = Nothing

    Private m_DrawingSymbols As New CSymbols
    Private m_SelectedSymbols As New CSymbols
    Private m_CopySymbols As New CSymbols

    Private m_SelectedObject As GraphicObject

    Private m_drawingObjects As New CGraphicObjs
    Private m_selectedObjects As New CGraphicObjs

    Private NodeDragging As Boolean = False
    Private RootDragging As Boolean = False
    'Private SymbolAdding As Boolean = False

    Private selectionDragging As Boolean = False
    Private selectionRect As RectangleF

    Private DrawingDragging As Boolean = False
    Private DrawingRect As Rectangle
    Private DrawingPicking As Boolean = False

    Private EditObj As GraphicObject
    Private iEditNode As Integer
    Private FoundNode As CFOUNDNODE

    Private FoundObject As CFOUNDOBJECT

    Public bBanDo2Loaded As Boolean

    Private bSnap As Boolean = False
    Private bGrid As Boolean = False
    Public myGridWidth As Integer = 8
    Private myWidth As Integer = 200
    Private myHeight As Integer = 160
    Private GridSize As Size = New Size(myGridWidth, myGridWidth)
    Private GridRect As Rectangle = New Rectangle(0, 0, myWidth, myHeight)


    Private WithEvents m_Map As AxMapXLib.AxMap
    'Private m_ParentForm As frmMain 'Form
    Private m_Panel As Panel

    Public dtDiaDanhTable As DataTable

    Private myDistanceUnit As Integer = MapXLib.MapUnitConstants.miUnitMeter
    Private strDistanceUnit As String = "m"
    Private strDistanceKQ As String
    Private DistanceKQ As Integer


    Public myZoom, myCX, myCY As Double


    Dim toolTip1 As ToolTip

    Dim mousePos As PointF

    Public ReadOnly Property myMap() As AxMapXLib.AxMap
        Get
            Return m_Map
        End Get
    End Property

    Public Overridable ReadOnly Property drawingObjects() As CGraphicObjs  'GraphicObjectCollection
        Get
            Return m_drawingObjects
        End Get
    End Property

    Public Property SelectedObject() As GraphicObject
        Get
            Return m_SelectedObject
        End Get
        Set(ByVal Value As GraphicObject)
            If Not Value Is m_SelectedObject Then
                If m_drawingObjects.Contains(Value) OrElse Value Is Nothing Then
                    m_SelectedObject = Value
                    m_Map.CenterX = m_Map.CenterX
                End If
            End If
        End Set
    End Property

    Public Overridable Property drawingSymbols() As CSymbols
        Get
            Return m_DrawingSymbols
        End Get
        Set(ByVal Value As CSymbols)
            m_DrawingSymbols = Value
        End Set
    End Property

    Public Property SelectedSymbol() As CSymbol
        Get
            Return m_SelectedSymbol
        End Get
        Set(ByVal Value As CSymbol)
            If Not Value Is m_SelectedSymbol Then
                If m_DrawingSymbols.Contains(Value) OrElse Value Is Nothing Then
                    m_SelectedSymbol = Value
                    m_Map.CenterX = m_Map.CenterX
                End If
            End If
        End Set
    End Property

    Public Overridable ReadOnly Property selectedObjects() As CGraphicObjs 'GraphicObjectCollection
        Get
            Return m_selectedObjects
        End Get
    End Property


    Public Sub New(ByVal pMap As AxMapXLib.AxMap, ByVal pForm As Form, _
        ByVal pPanel As Panel)

        'MyOtherLineStyle = New COtherLineStyle

        'CreateMyMenu()

        m_ParentForm = pForm
        m_Map = pMap
        m_Panel = pPanel

        InitializeComponent()

        m_Map.GeoSet = myMapGst 'Application.StartupPath & "\\bando.gst"
        m_Map.Title.Visible = False

        m_Map.MapUnit = myDistanceUnit

        Dim mydcs As MapXLib.CoordSys

        mydcs = m_Map.DisplayCoordSys

        m_Map.NumericCoordSys = mydcs
        m_Map.InfotipSupport = False

        'moi them
        m_Map.NumericCoordSys.Set(myCoordSysType, mydcs.Datum, _
        m_Map.NumericCoordSys.Units, m_Map.NumericCoordSys.OriginLongitude, m_Map.NumericCoordSys.OriginLatitude, _
        m_Map.NumericCoordSys.StandardParallelOne, m_Map.NumericCoordSys.StandardParallelTwo, _
        m_Map.NumericCoordSys.Azimuth, m_Map.NumericCoordSys.ScaleFactor, _
        m_Map.NumericCoordSys.FalseEasting, m_Map.NumericCoordSys.FalseNorthing, _
        m_Map.NumericCoordSys.Range)

        'm_Map.PaperUnit = MapXLib.PaperUnitConstants.miPaperUnitPoint
        m_Map.PaperUnit = MapXLib.PaperUnitConstants.miPaperUnitMeter

        'm_Statusbar.Panels(0).Text = ""

        m_Map.Layers.AddUserDrawLayer("LopVeKyHieu", 1)

        'colKHs = New CKyHieus()

        CreateMyToolTip()

        myMapTool = MapTools.None
        myZoom = m_Map.Zoom
        myCX = m_Map.CenterX
        myCY = m_Map.CenterY

        'InitializeComponent()

        m_Map.CreateCustomTool(myToolInfo, MapXLib.ToolTypeConstants.miToolTypePoint, MapXLib.CursorConstants.miArrowQuestionCursor)

        AddDataSets()

        bBanDo2Loaded = False

        XoaUndoStack()
    End Sub

    Public Sub New(ByVal pMap As AxMapXLib.AxMap, ByVal pForm As Form)
        m_ParentForm = pForm
        m_Map = pMap

        m_Map.GeoSet = myMapGst 'Application.StartupPath & "\\bando.gst"
        m_Map.Title.Visible = False

        m_Map.MapUnit = myDistanceUnit

        Dim mydcs As MapXLib.CoordSys

        mydcs = m_Map.DisplayCoordSys

        m_Map.NumericCoordSys = mydcs
        m_Map.InfotipSupport = False

        'moi them
        m_Map.NumericCoordSys.Set(myCoordSysType, mydcs.Datum, _
        m_Map.NumericCoordSys.Units, m_Map.NumericCoordSys.OriginLongitude, m_Map.NumericCoordSys.OriginLatitude, _
        m_Map.NumericCoordSys.StandardParallelOne, m_Map.NumericCoordSys.StandardParallelTwo, _
        m_Map.NumericCoordSys.Azimuth, m_Map.NumericCoordSys.ScaleFactor, _
        m_Map.NumericCoordSys.FalseEasting, m_Map.NumericCoordSys.FalseNorthing, _
        m_Map.NumericCoordSys.Range)

        'm_Map.PaperUnit = MapXLib.PaperUnitConstants.miPaperUnitPoint
        m_Map.PaperUnit = MapXLib.PaperUnitConstants.miPaperUnitMeter

        m_Map.Layers.AddUserDrawLayer("LopVeKyHieu", 1)

        CreateMyToolTip()

        myMapTool = MapTools.None
        myZoom = m_Map.Zoom
        myCX = m_Map.CenterX
        myCY = m_Map.CenterY

        m_Map.CreateCustomTool(myToolInfo, MapXLib.ToolTypeConstants.miToolTypePoint, MapXLib.CursorConstants.miArrowQuestionCursor)

        AddDataSets()

        bBanDo2Loaded = False

    End Sub

    Private Sub CreateMyToolTip()
        toolTip1 = New ToolTip
        toolTip1.AutoPopDelay = 5000 '5000
        toolTip1.InitialDelay = 500  '1000
        toolTip1.ReshowDelay = 100  '500
        toolTip1.ShowAlways = True
        toolTip1.Active = False
        toolTip1.SetToolTip(m_Map, "My Ban do")
    End Sub

    Private Sub UpdateTB(ByVal index As Integer)
        'For Each mButton As ToolBarButton In m_ToolBar.Buttons
        'mButton.Pushed = False
        'Next
        'With m_ToolBar
        '.Buttons(index).Pushed = True
        'End With
    End Sub

    Private Sub UpdateTB(ByVal pTag As String)
        'For Each mButton As ToolBarButton In m_ToolBar.Buttons
        'If mButton.Tag = pTag Then
        'mButton.Pushed = True
        'Else
        'mButton.Pushed = False
        'End If
        'Next
    End Sub

    Public Sub OnNodesEdit()
        If Not m_SelectedSymbol Is Nothing Then
            'EditObj = m_SelectedSymbol.GObjs(0)
            'EditObj.Reset()
            iEditNode = -1
            'SelectedSymbol = Nothing
            myMapTool = MapTools.NodesEdit
            'Me.Invalidate()
            m_Map.CenterX = m_Map.CenterX
        Else
            MsgBox("ko co selEditsymbol")
        End If
    End Sub

    Public Sub OnChangeRoot()
        If Not m_SelectedSymbol Is Nothing Then
            PopUndo()
            myMapTool = MapTools.ChangeRoot
            m_Map.CenterX = m_Map.CenterX
        Else
            MsgBox("ko co selesymbol")
        End If
    End Sub

    Public Sub OnDoKhoangCach()
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        myMapTool = MapTools.Ruler

        m_SelectedSymbol = Nothing
        m_Map.CenterX = m_Map.CenterX


        strDistanceKQ = ""
        ReDim myPts(-1)
        DrawingPicking = False
        m_ParentForm.ToolStripStatusLabel3.Text = "Đo khoảng cách: Click để chọn các Vị trí, RightClick để xem Kết quả."

    End Sub

    Private myDoCao As Single = 0
    Private txtKQ As TextBox
    Private txtObjType As TextBox

    Public Sub OnGetTarget(ByVal ptxtKQ As TextBox, ByVal pDoCao As Single)
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        myMapTool = MapTools.GetTarget

        m_SelectedSymbol = Nothing
        m_Map.CenterX = m_Map.CenterX

        myDoCao = pDoCao
        txtKQ = ptxtKQ

        ReDim myPts(-1)
        DrawingPicking = False
        m_ParentForm.ToolStripStatusLabel3.Text = "Lay Vị trí: Click để chọn các Vị trí, RightClick để xem Kết quả."

    End Sub

    Private Sub GetTargets()
        Dim mLon1, mLat1 As Double
        Dim i As Integer
        Dim m_OWidth As Double = CDbl(mySurf2X * 1000D) / (myGRID_WIDTH - 1) / 1000
        Dim m_OHeight As Double = CDbl(mySurf2Y * 1000D) / (myGRID_HEIGHT - 1) / 1000
        Dim mSurfPos As System.Drawing.PointF
        Dim mSX As Single
        Dim mSY As Single
        If myPts.GetUpperBound(0) <= 1 Then
            For i = 0 To myPts.GetUpperBound(0)
                m_Map.ConvertCoord(myPts(i).X, myPts(i).Y, mLon1, mLat1, MapXLib.ConversionConstants.miScreenToMap)
                mSurfPos = GetSurfPosition(mLon1, mLat1)
                mSX = CDbl(mSurfPos.X) / m_OWidth
                mSY = CDbl(myGRID_HEIGHT - 1) - CDbl(mSurfPos.Y) / m_OHeight
                txtKQ.Text &= "<Target X=""" & mSX.ToString & """ Y=""" & mSY.ToString & """ Z=""" & (myDoCao).ToString & """>" & (i + 1).ToString() & "</Target>" & vbCrLf
            Next
        Else
            Dim mPath As New GraphicsPath
            mPath.AddCurve(myPts)
            mPath.Flatten(New Matrix, 0.25)
            Dim mPts() As PointF = mPath.PathPoints
            For i = 0 To mPts.GetUpperBound(0)
                m_Map.ConvertCoord(mPts(i).X, mPts(i).Y, mLon1, mLat1, MapXLib.ConversionConstants.miScreenToMap)
                mSurfPos = GetSurfPosition(mLon1, mLat1)
                mSX = CDbl(mSurfPos.X) / m_OWidth
                mSY = CDbl(myGRID_HEIGHT - 1) - CDbl(mSurfPos.Y) / m_OHeight
                txtKQ.Text &= "<Target X=""" & mSX.ToString & """ Y=""" & mSY.ToString & """ Z=""" & (myDoCao).ToString & """>" & (i + 1).ToString() & "</Target>" & vbCrLf
            Next
        End If

    End Sub

    Private Sub GetTargets1()
        Dim mLon1, mLat1 As Double
        Dim i As Integer
        Dim m_OWidth As Double = CDbl(mySurf2X * 1000D) / (myGRID_WIDTH - 1) / 1000
        Dim m_OHeight As Double = CDbl(mySurf2Y * 1000D) / (myGRID_HEIGHT - 1) / 1000
        Dim mSurfPos As System.Drawing.PointF
        Dim mSX As Single
        Dim mSY As Single
        For i = 0 To myPts.GetUpperBound(0)
            m_Map.ConvertCoord(myPts(i).X, myPts(i).Y, mLon1, mLat1, MapXLib.ConversionConstants.miScreenToMap)
            mSurfPos = GetSurfPosition(mLon1, mLat1)
            mSX = CDbl(mSurfPos.X) / m_OWidth
            mSY = CDbl(myGRID_HEIGHT - 1) - CDbl(mSurfPos.Y) / m_OHeight
            txtKQ.Text &= "<Target X=""" & mSX.ToString & """ Y=""" & mSY.ToString & """ Z=""" & (myDoCao).ToString & """>" & (i + 1).ToString() & "</Target>" & vbCrLf
        Next

    End Sub

    Public Sub OnGetObjName(ByVal ptxtKQ As TextBox, ByVal ptxtObjType As TextBox)
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        myMapTool = MapTools.GetObjName

        m_SelectedSymbol = Nothing
        m_Map.CenterX = m_Map.CenterX

        txtKQ = ptxtKQ
        txtObjType = ptxtObjType

        m_ParentForm.ToolStripStatusLabel3.Text = "Lay Ten DT: Click để chọn DT."
    End Sub

    Private Sub GetObjName(ByVal pSymbol As CSymbol)
        m_ParentForm.lstCacKyHieu.SelectedIndex = m_ParentForm.lstCacKyHieu.Items.IndexOf(pSymbol)
        m_ParentForm.ChangeDesc(pSymbol, txtKQ.Parent)

        txtKQ.Text = pSymbol.Description
        txtObjType.Text = m_ParentForm.GetSymbolType(pSymbol)

        m_ParentForm.ToolStripStatusLabel3.Text = ""
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        myMapTool = MapTools.None
    End Sub

    Public Sub OnXoa()
        If Not m_SelectedSymbol Is Nothing Then
            PopUndo()

            Dim mIndex As Integer = m_DrawingSymbols.IndexOf(m_SelectedSymbol)

            m_DrawingSymbols.Remove(m_SelectedSymbol)

            If mIndex >= m_DrawingSymbols.ListCount Then
                mIndex -= 1
            End If
            If mIndex >= 0 Then
                m_SelectedSymbol = m_DrawingSymbols.Item(mIndex)
            Else
                m_SelectedSymbol = Nothing
            End If
            m_Map.CenterX = m_Map.CenterX

            m_ParentForm.PopulateListKH(m_SelectedSymbol)
        End If
    End Sub

    Public Function String2KHs(ByVal pstrKyHieu As String) As CSymbols
        Dim nt As NameTable = New NameTable
        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(nt)
        nsmgr.AddNamespace("bk", "urn:sample")

        'Create the XmlParserContext.
        Dim context As XmlParserContext = New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.None)
        'Create the reader. 
        Dim rr As XmlTextReader = New XmlTextReader(pstrKyHieu, XmlNodeType.Element, context)

        'Dim mKyHieus As CKyHieus = xml2khs(rr)
        Dim mKyHieus As CSymbols = XML2Symbols(rr)
        rr.Close()

        Return mKyHieus
    End Function

    Public Sub KHsFromString(ByVal strKyHieus As String)
        KHsFromString0(strKyHieus)
        XoaUndoStack()
    End Sub

    Public Sub KHsFromString1(ByVal strKyHieus As String)
        KHsFromString0(strKyHieus)
    End Sub

    Private Sub KHsFromString0(ByVal strKyHieus As String)
        Dim nt As NameTable = New NameTable
        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(nt)
        nsmgr.AddNamespace("bk", "urn:sample")

        'Create the XmlParserContext.
        Dim context As XmlParserContext = New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.None)
        'Create the reader. 
        Dim rr As XmlTextReader = New XmlTextReader(strKyHieus, XmlNodeType.Element, context)

        'Dim mKyHieus As CKyHieus = xml2khs(rr)
        Dim mKyHieus As CSymbols = XML2Symbols(rr)
        rr.Close()

        SyncLock m_DrawingSymbols
            m_DrawingSymbols.Clear()
            'XoaUndoStack()

            'Dim mSymbol As CSymbol
            For Each mSymbol As CSymbol In mKyHieus
                've 1 chuan:
                If (mSymbol.Zoom <> myKHQSZoom) Or (mSymbol.MWidth <> (myKHQSMWidth)) Then
                    mSymbol.ChangeZoomMWidtht(myKHQSZoom, (myKHQSMWidth))
                End If

                m_DrawingSymbols.Add(mSymbol)
            Next
        End SyncLock
    End Sub

    Public Sub AppendKHsFromString(ByVal strKyHieus As String)
        Dim nt As NameTable = New NameTable
        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(nt)
        nsmgr.AddNamespace("bk", "urn:sample")

        'Create the XmlParserContext.
        Dim context As XmlParserContext = New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.None)
        'Create the reader. 
        Dim rr As XmlTextReader = New XmlTextReader(strKyHieus, XmlNodeType.Element, context)

        Dim mKyHieus As CSymbols = XML2Symbols(rr)
        rr.Close()

        'Dim mFstSymbolZoom As Long = m_Map.Zoom
        'Dim mFstSymbolMWidth As Long = m_Map.MapScreenWidth
        'If m_DrawingSymbols.Count > 0 Then
        'mFstSymbolZoom = m_DrawingSymbols(0).Zoom
        'mFstSymbolMWidth = m_DrawingSymbols(0).MWidth
        'End If

        SyncLock m_DrawingSymbols
            For Each mSymbol As CSymbol In mKyHieus
                'If (mSymbol.Zoom <> mFstSymbolZoom) Or (mSymbol.MWidth <> mFstSymbolMWidth) Then
                'mSymbol.ChangeZoomMWidtht(mFstSymbolZoom, mFstSymbolMWidth)
                'End If
                m_DrawingSymbols.Add(mSymbol)
            Next
        End SyncLock
    End Sub

    Public Function File2KHs(ByVal pFileName As String) As CSymbols 'CKyHieus
        Dim rr As XmlTextReader = New XmlTextReader(pFileName)

        'Dim mKyHieus As CKyHieus = xml2khs(rr)
        Dim mKyHieus As CSymbols = XML2Symbols(rr)
        rr.Close()
        Return mKyHieus

    End Function

    Public Sub LoadKHs(ByVal pFileName As String)
        Dim rr As XmlTextReader = New XmlTextReader(pFileName)
        Dim mKyHieus As CSymbols = XML2Symbols(rr)
        rr.Close()

        'Dim mFstSymbolZoom As Long = m_Map.Zoom
        'Dim mFstSymbolMWidth As Long = m_Map.MapScreenWidth
        'If m_DrawingSymbols.Count > 0 Then
        'mFstSymbolZoom = m_DrawingSymbols(0).Zoom
        'mFstSymbolMWidth = m_DrawingSymbols(0).MWidth
        'End If

        'm_DrawingSymbols.Clear()
        For Each mSymbol As CSymbol In mKyHieus
            'If (mSymbol.Zoom <> mFstSymbolZoom) Or (mSymbol.MWidth <> mFstSymbolMWidth) Then
            'mSymbol.ChangeZoomMWidtht(mFstSymbolZoom, mFstSymbolMWidth)
            'End If
            m_DrawingSymbols.Add(mSymbol)
        Next
        mKyHieus = Nothing
    End Sub

    Private Function GetDouble(ByVal str1 As String) As Double
        Dim strDouble As String
        strDouble = str1
        strDouble = strDouble.Replace(cGrpSepa, cDecSepa)
        Return CDbl(strDouble)
    End Function

    Private Function GetSingle(ByVal str1 As String) As Single
        Dim strDouble As String
        strDouble = str1
        strDouble = strDouble.Replace(cGrpSepa, cDecSepa)
        Return CSng(strDouble)
    End Function

    Private Function XML2Symbols(ByVal rr As XmlTextReader) As CSymbols
        Dim strResult As String = ""

        Dim oNodeType As XmlNodeType

        Dim mKyHieus As New CSymbols   'CKyHieus()

        Dim mMapParts As New CGraphicObjs   'CMAPPARTS()
        'Dim mMapNode As CNODE 'CMAPNODE

        Dim mDesc As String
        Dim mBlinking As Boolean = False
        Dim mMapZoom As Long
        Dim mMWidth As Single
        Dim mGocX, mGocY As Double

        Dim mPartType As OBJECTTYPE 'PARTTYPE
        Dim mColor, mColor2, mFillColor, mHColor As Color
        Dim mWidth, mWidth2, mHStyle As Integer
        Dim mLineStyle As Integer
        Dim mStyleWidth As Single

        Dim mFill As Boolean
        Dim mDValues As String

        'Dim mMapPtX, mMapPtY As Double
        Dim mbControl As Boolean

        Dim mNodes As New CNODES

        Dim mPtX, mPtY, mW, mH, mA, mST, mSW As Single
        Dim mIsArc As Boolean = False
        Dim mDrawingRect As RectangleF
        Dim mRotation As Single

        Dim mText As String
        Dim mFName As String
        Dim mFSize As Integer
        Dim mFStyle As String   'FontStyle
        Dim mFColor As Color

        Dim strTYPE As String = "bmp"
        Dim mIMAGEW As Integer = 0
        Dim mIMAGEH As Integer = 0
        Dim strIMAGE As String = ""

        Dim mCols As Integer
        Dim mRows As Integer
        Dim mBColor As Color
        Dim mBWidth As Integer
        Dim mLColor As Color
        Dim mLWidth As Integer
        Dim mFiColor As Color

        'Dim mTFName As String
        'Dim mTFSize As Integer
        'Dim mTFStyle As String   'FontStyle
        'Dim mTFColor As Color

        Dim mAWS, mAHS As String
        'Dim mTABPtX, mTABPtY, mTABW, mTABH As Single
        Dim mCells As New CCells
        Dim miC, miR, mCNo, mRNo As Integer
        Dim mCText As String
        Try
            Do While rr.Read
                oNodeType = rr.NodeType
                Select Case oNodeType
                    Case XmlNodeType.Element
                        Select Case rr.Name
                            Case "KyHieus"
                                If rr.AttributeCount > 0 Then
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "CX"
                                                'myCX = GetDouble(rr.Value)
                                            Case "CY"
                                                'myCY = GetDouble(rr.Value)
                                            Case "Zoom"
                                                'myZoom = GetDouble(rr.Value)
                                        End Select
                                    Loop
                                End If

                            Case "KyHieu"
                                mMapParts.Clear()
                                mMWidth = 0
                                mDesc = ""
                                mBlinking = False
                                If rr.AttributeCount > 0 Then
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "Desc"
                                                mDesc = rr.Value
                                            Case "Blink"
                                                mBlinking = IIf(rr.Value = "True", True, False)
                                            Case "Zoom"
                                                mMapZoom = rr.Value
                                            Case "MWi"
                                                mMWidth = GetSingle(rr.Value)
                                            Case "GocX"
                                                mGocX = GetDouble(rr.Value)
                                            Case "GocY"
                                                mGocY = GetDouble(rr.Value)
                                        End Select
                                    Loop
                                End If
                            Case "Part"
                                mNodes.Clear()
                                mCells.Clear()

                                mPartType = OBJECTTYPE.Line 'toObjectType("Line")
                                mColor = Color.Black  'Color.FromArgb(0)
                                mWidth = 1
                                mLineStyle = 0
                                mStyleWidth = 0
                                mColor2 = Color.Black  'Color.FromArgb(0)
                                mWidth2 = 0
                                mDValues = ""
                                mFill = False
                                mFillColor = Color.Black  'Color.FromArgb(0)
                                mHColor = Color.Black  'Color.FromArgb(0)
                                mHStyle = 0
                                mW = 10
                                mH = 10
                                mA = 0
                                mST = 0
                                mSW = 90
                                mIsArc = False
                                mText = "text"
                                mFName = "Tahoma"
                                mFSize = 10
                                mFStyle = "Regular" 'FontStyle.Regular
                                mFColor = Color.Black

                                strTYPE = "bmp"
                                mIMAGEW = 0
                                mIMAGEH = 0
                                strIMAGE = ""

                                mCols = 2
                                mRows = 2
                                mBColor = Color.Blue
                                mBWidth = 1
                                mLColor = Color.Gray
                                mLWidth = 1
                                mFiColor = Color.Blue
                                mAWS = ""
                                mAHS = ""
                                'mATS = ""
                                If rr.AttributeCount > 0 Then
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "Type"
                                                mPartType = CGraphicObjs.toObjectType(rr.Value) 'toObjectType(rr.Value)
                                            Case "Color"
                                                mColor = Color.FromArgb(rr.Value)
                                            Case "Width"
                                                mWidth = rr.Value
                                            Case "Style"
                                                mLineStyle = rr.Value
                                            Case "SWidth"
                                                mStyleWidth = GetSingle(rr.Value)
                                            Case "Color2"
                                                mColor2 = Color.FromArgb(rr.Value)
                                            Case "Width2"
                                                mWidth2 = rr.Value
                                            Case "DV"
                                                mDValues = rr.Value.ToString
                                            Case "Fill"
                                                mFill = IIf(rr.Value = "False", False, True)
                                            Case "FColor"
                                                mFillColor = Color.FromArgb(rr.Value)
                                            Case "HColor"
                                                mHColor = Color.FromArgb(rr.Value)
                                            Case "HStyle"
                                                mHStyle = rr.Value
                                            Case "FName"
                                                mFName = rr.Value
                                            Case "FSize"
                                                mFSize = rr.Value
                                            Case "FStyle"
                                                mFStyle = rr.Value
                                            Case "Text"
                                                mText = rr.Value
                                            Case "ITYPE"
                                                strTYPE = rr.Value
                                            Case "IMAGEW"
                                                mIMAGEW = Int(rr.Value)
                                            Case "IMAGEH"
                                                mIMAGEH = Int(rr.Value)
                                            Case "IMAGE"
                                                strIMAGE = rr.Value
                                        End Select
                                    Loop
                                End If
                            Case "Node"
                                If rr.AttributeCount > 0 Then
                                    mbControl = False
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "X"
                                                mPtX = GetSingle(rr.Value)
                                            Case "Y"
                                                mPtY = GetSingle(rr.Value)
                                            Case "Type"
                                                mbControl = CBool(rr.Value)
                                        End Select
                                    Loop

                                End If
                            Case "Cell"
                                If rr.AttributeCount > 0 Then
                                    miC = 0
                                    miR = 0
                                    mCNo = 1
                                    mRNo = 1
                                    mCText = ""
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "iR"
                                                miR = CInt(rr.Value)
                                            Case "iC"
                                                miC = CInt(rr.Value)
                                            Case "RNo"
                                                mRNo = CInt(rr.Value)
                                            Case "CNo"
                                                mCNo = CInt(rr.Value)
                                            Case "Text"
                                                mCText = rr.Value
                                            Case "FName"
                                                mFName = rr.Value
                                            Case "FSize"
                                                mFSize = rr.Value
                                            Case "FStyle"
                                                mFStyle = rr.Value
                                            Case "Color"
                                                mFColor = Color.FromArgb(rr.Value)

                                        End Select
                                    Loop

                                End If
                            Case "Rect"
                                If rr.AttributeCount > 0 Then
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "X"
                                                mPtX = GetSingle(rr.Value)
                                            Case "Y"
                                                mPtY = GetSingle(rr.Value)
                                            Case "W"
                                                mW = GetSingle(rr.Value)
                                            Case "H"
                                                mH = GetSingle(rr.Value)
                                            Case "A"
                                                mA = GetSingle(rr.Value)
                                        End Select
                                    Loop
                                End If
                            Case "Pie"
                                If rr.AttributeCount > 0 Then
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "X"
                                                mPtX = GetSingle(rr.Value)
                                            Case "Y"
                                                mPtY = GetSingle(rr.Value)
                                            Case "W"
                                                mW = GetSingle(rr.Value)
                                            Case "H"
                                                mH = GetSingle(rr.Value)
                                            Case "ST"
                                                mST = GetSingle(rr.Value)
                                            Case "SW"
                                                mSW = GetSingle(rr.Value)
                                            Case "ARC"
                                                mIsArc = IIf(rr.Value = "False", False, True)
                                            Case "A"
                                                mA = GetSingle(rr.Value)
                                        End Select
                                    Loop
                                End If
                            Case "Pos"
                                If rr.AttributeCount > 0 Then
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "X"
                                                mPtX = GetSingle(rr.Value)
                                            Case "Y"
                                                mPtY = GetSingle(rr.Value)
                                            Case "A"
                                                mA = GetSingle(rr.Value)
                                        End Select
                                    Loop

                                End If

                            Case "TBL"
                                If rr.AttributeCount > 0 Then
                                    Do While rr.MoveToNextAttribute
                                        Select Case rr.Name
                                            Case "FiColor"
                                                mFiColor = Color.FromArgb(rr.Value)
                                            Case "X"
                                                mPtX = GetSingle(rr.Value)
                                            Case "Y"
                                                mPtY = GetSingle(rr.Value)
                                            Case "W"
                                                mW = GetSingle(rr.Value)
                                            Case "H"
                                                mH = GetSingle(rr.Value)
                                            Case "A"
                                                mA = GetSingle(rr.Value)
                                            Case "Cols"
                                                mCols = CInt(rr.Value)
                                            Case "Rows"
                                                mRows = CInt(rr.Value)
                                            Case "BColor"
                                                mBColor = Color.FromArgb(rr.Value)
                                            Case "BWidth"
                                                mBWidth = CInt(rr.Value)
                                            Case "LColor"
                                                mLColor = Color.FromArgb(rr.Value)
                                            Case "LWidth"
                                                mLWidth = CInt(rr.Value)
                                            Case "AWS"
                                                mAWS = rr.Value
                                            Case "AHS"
                                                mAHS = rr.Value
                                            Case "FiColor"
                                                mFiColor = Color.FromArgb(rr.Value)

                                        End Select
                                    Loop
                                End If

                        End Select
                    Case XmlNodeType.EndElement
                        Select Case rr.Name
                            Case "Node"
                                mNodes.Add(New CNODE(New PointF(mPtX, mPtY), mbControl))
                            Case "Cell"
                                Dim mFontStyle As FontStyle
                                Select Case mFStyle
                                    Case "Bold"
                                        mFontStyle = FontStyle.Bold
                                    Case "Italic"
                                        mFontStyle = FontStyle.Italic
                                    Case "Regular"
                                        mFontStyle = FontStyle.Regular
                                    Case "Strikeout"
                                        mFontStyle = FontStyle.Strikeout
                                    Case "Underline"
                                        mFontStyle = FontStyle.Underline
                                    Case "Bold, Italic"
                                        mFontStyle = FontStyle.Bold + FontStyle.Italic
                                End Select
                                Dim mFont As New Font(mFName, mFSize, _
                                    mFontStyle, GraphicsUnit.Point)

                                mCells.Add(New CCell(miR, miC, mRNo, mCNo, mCText, mFont, mFColor))
                            Case "Part"
                                Dim gObj As GraphicObject

                                Select Case mPartType
                                    Case OBJECTTYPE.Curve
                                        Dim myCurve As New CurveGraphic(mNodes, mWidth, mColor, mLineStyle, mStyleWidth, mWidth2, _
                                         mColor2, mDValues, mFill, mFillColor, mHColor, mHStyle)
                                        myCurve.Rotation = 0
                                        gObj = myCurve
                                    Case OBJECTTYPE.ClosedCurve
                                        Dim myClosedCurve As New ClosedCurveGraphic(mNodes, mWidth, mColor, mLineStyle, mStyleWidth, mWidth2, _
                                         mColor2, mDValues, mFill, mFillColor, mHColor, mHStyle)
                                        myClosedCurve.Rotation = 0
                                        gObj = myClosedCurve
                                    Case OBJECTTYPE.Line
                                        Dim myLine As New LinesGraphic(mNodes, mWidth, mColor, mLineStyle, mStyleWidth, mWidth2, _
                                         mColor2, mDValues, mFill, mFillColor, mHColor, mHStyle)
                                        myLine.Rotation = 0
                                        gObj = myLine
                                    Case OBJECTTYPE.Polygon
                                        Dim myPolygon As New PolygonGraphic(mNodes, mWidth, mColor, mLineStyle, mStyleWidth, mWidth2, _
                                         mColor2, mDValues, mFill, mFillColor, mHColor, mHStyle)
                                        myPolygon.Rotation = 0
                                        gObj = myPolygon
                                    Case OBJECTTYPE.Cycle
                                        Dim x1, y1, dk As Integer
                                        dk = Sqrt((mNodes(1).X - mNodes(0).X) * _
                                        (mNodes(1).X - mNodes(0).X) + _
                                        (mNodes(1).Y - mNodes(0).Y) * _
                                        (mNodes(1).Y - mNodes(0).Y))
                                        x1 = ((mNodes(0).X + mNodes(1).X) - dk) / 2
                                        y1 = ((mNodes(0).Y + mNodes(1).Y) - dk) / 2
                                        Dim mRect As RectangleF = New RectangleF(x1, y1, dk, dk)
                                        Dim myEllipse As New EllipseGraphic(mRect, mWidth, mColor, mLineStyle, mStyleWidth, mWidth2, _
                                         mColor2, mDValues, mFill, mFillColor, mHColor, mHStyle, mRotation)
                                        gObj = myEllipse
                                    Case OBJECTTYPE.Ellipse
                                        mDrawingRect = New RectangleF(mPtX, mPtY, mW, mH)
                                        mRotation = mA
                                        Dim myEllipse As New EllipseGraphic(mDrawingRect, mWidth, mColor, mLineStyle, mStyleWidth, mWidth2, _
                                         mColor2, mDValues, mFill, mFillColor, mHColor, mHStyle, mRotation)
                                        gObj = myEllipse
                                    Case OBJECTTYPE.Pie
                                        mDrawingRect = New RectangleF(mPtX, mPtY, mW, mH)
                                        mRotation = mA
                                        Dim myPie As New PieGraphic(mDrawingRect, mWidth, mColor, mLineStyle, mStyleWidth, mWidth2, _
                                         mColor2, mDValues, mFill, mFillColor, mHColor, mHStyle, mRotation)
                                        myPie.StartAngle = mST
                                        myPie.SweepAngle = mSW
                                        myPie.IsArc = mIsArc
                                        gObj = myPie
                                    Case OBJECTTYPE.Text
                                        Dim mFontStyle As FontStyle
                                        Select Case mFStyle
                                            Case "Bold"
                                                mFontStyle = FontStyle.Bold
                                            Case "Italic"
                                                mFontStyle = FontStyle.Italic
                                            Case "Regular"
                                                mFontStyle = FontStyle.Regular
                                            Case "Strikeout"
                                                mFontStyle = FontStyle.Strikeout
                                            Case "Underline"
                                                mFontStyle = FontStyle.Underline
                                            Case "Bold, Italic"
                                                mFontStyle = FontStyle.Bold + FontStyle.Italic
                                        End Select
                                        Dim StringFont As New Font(mFName, mFSize, _
                                            mFontStyle, GraphicsUnit.Point)
                                        Dim myText As New TextGraphic(mPtX, mPtY, mText, StringFont, mFillColor, mA)
                                        gObj = myText

                                    Case OBJECTTYPE.EmbeddedImage
                                        If strIMAGE.Length > 0 Then
                                            Dim mImage As Image
                                            Dim arrImage As Byte()
                                            arrImage = Convert.FromBase64String(strIMAGE)

                                            Dim memStream As New MemoryStream(arrImage)
                                            mImage = Image.FromStream(memStream)

                                            Dim mEmbeddedImage As New EmbeddedImageGraphic(strTYPE, CInt(mPtX), CInt(mPtY), mImage)
                                            mEmbeddedImage.Transparent = True
                                            mEmbeddedImage.TransparentColor = Color.White
                                            gObj = mEmbeddedImage
                                            With gObj
                                                .Rotation = mA
                                                .AutoSize = False 'True
                                                .Width = mIMAGEW
                                                .Height = mIMAGEH
                                            End With
                                            'gObj = Nothing
                                        End If

                                    Case OBJECTTYPE.Table
                                        Dim strData() As String
                                        strData = mAWS.Split("|")
                                        Dim mAWidth(mCols - 1) As Integer
                                        For i As Integer = 0 To mCols - 1
                                            Try
                                                mAWidth(i) = Val(strData(i))
                                            Catch ex As Exception
                                                mAWidth(i) = 80
                                            End Try
                                        Next

                                        strData = mAHS.Split("|")
                                        Dim mAHeight(mRows - 1) As Integer
                                        For i As Integer = 0 To mRows - 1
                                            Try
                                                mAHeight(i) = Val(strData(i))
                                            Catch ex As Exception
                                                mAHeight(i) = 20
                                            End Try
                                        Next

                                        Dim myTable As New TableGraphic( _
                                        mPtX, mPtY, _
                                        mCols, mRows, _
                                        mAWidth, mAHeight, mCells, _
                                        mBColor, mBWidth, _
                                        mLColor, mLWidth, _
                                        mFiColor, mA)

                                        gObj = myTable
                                End Select

                                If Not gObj Is Nothing Then
                                    mMapParts.Add(gObj)
                                End If
                            Case "KyHieu"
                                Dim mKyHieu As CSymbol = New CSymbol(mDesc, mBlinking, mMapZoom, mMWidth, mGocX, mGocY, mMapParts)
                                'mKyHieus.Add(mKyHieu.Clone(m_Map))
                                mKyHieus.Add(mKyHieu)
                        End Select
                End Select
            Loop

        Catch ex As Exception
            'MsgBox(ex.Source & ": " & ex.Message)
            MsgBox("Khong doc duoc XML Nay")
        End Try
        Return mKyHieus
    End Function

    Private Sub OnChangeColor()
        Dim f As New dlgChangeColor
        'fCallForm = m_ParentForm 'm_ParentForm
        'f.ShowDialog(m_ParentForm)
        'm_Map.CenterX = m_Map.CenterX
        Dim myObj As ShapeGraphic = m_SelectedObject
        With myObj
            f.txtColor.BackColor = .LineColor
            f.txtColor2.BackColor = .Line2Color
            f.txtDashValues.Text = .DValues

            f.nudPenWidth.Value = .LineWidth
            f.nudPenWidth2.Value = .Line2Width
            f.nudLineStyle.Value = .LineStyle
            f.nudStyleWidth.Value = .StyleWidth

            f.chkBrush.Checked = myObj.Fill
            If f.chkBrush.Checked Then
                f.txtBrushColor.BackColor = Color.FromArgb(255, .FillColor.R, .FillColor.G, .FillColor.B)
                f.nudAlpha.Value = .FillColor.A
                f.txtHatchColor.BackColor = Color.FromArgb(255, .HatchColor.R, .HatchColor.G, .HatchColor.B)
                f.nudHStyle.Value = .HatchStyle
            End If

        End With

        If f.ShowDialog(m_ParentForm) = Windows.Forms.DialogResult.OK Then
            With myObj
                .LineColor = f.txtColor.BackColor
                .LineWidth = f.nudPenWidth.Value
                .Line2Color = f.txtColor2.BackColor
                .Line2Width = f.nudPenWidth2.Value
                .DValues = f.txtDashValues.Text
                .LineStyle = f.nudLineStyle.Value
                .StyleWidth = f.nudStyleWidth.Value

                If f.chkBrush.Checked Then
                    .Fill = True
                    .FillColor = Color.FromArgb(f.nudAlpha.Value, f.txtBrushColor.BackColor)
                    .HatchColor = f.txtHatchColor.BackColor
                    .HatchStyle = f.nudHStyle.Value

                Else
                    .Fill = False
                End If
            End With
            RefreshMap()
        End If

    End Sub

    Private Sub OnChangePie()
        Dim f As New dlgChangePie
        'fCallForm = Me
        Dim myObj As PieGraphic = m_SelectedObject
        f.nudStartAngle.Value = myObj.StartAngle
        f.nudSweepAngle.Value = myObj.SweepAngle
        f.chkArc.Checked = myObj.IsArc

        f.txtColor.BackColor = myObj.LineColor
        f.txtColor2.BackColor = myObj.Line2Color
        f.txtDashValues.Text = myObj.DValues

        f.nudPenWidth.Value = myObj.LineWidth
        f.nudPenWidth2.Value = myObj.Line2Width

        f.chkBrush.Checked = myObj.Fill
        If f.chkBrush.Checked Then
            f.txtBrushColor.BackColor = Color.FromArgb(255, myObj.FillColor.R, myObj.FillColor.G, myObj.FillColor.B)
            f.nudAlpha.Value = myObj.FillColor.A
            f.txtHatchColor.BackColor = Color.FromArgb(255, myObj.HatchColor.R, myObj.HatchColor.G, myObj.HatchColor.B) 'myObj.HatchColor
            f.txtHStyle.Text = myObj.HatchStyle
        End If

        If f.ShowDialog(m_ParentForm) = Windows.Forms.DialogResult.OK Then
            myObj.StartAngle = f.nudStartAngle.Value
            myObj.SweepAngle = f.nudSweepAngle.Value
            If f.chkArc.Checked = True Then
                myObj.IsArc = True
            Else
                myObj.IsArc = False
            End If
            myObj.LineColor = f.txtColor.BackColor
            myObj.LineWidth = f.nudPenWidth.Value
            myObj.Line2Color = f.txtColor2.BackColor
            myObj.Line2Width = f.nudPenWidth2.Value
            myObj.DValues = f.txtDashValues.Text

            If f.chkBrush.Checked Then
                myObj.Fill = True
                myObj.FillColor = Color.FromArgb(f.nudAlpha.Value, f.txtBrushColor.BackColor)
                myObj.HatchColor = f.txtHatchColor.BackColor
                myObj.HatchStyle = Val(f.txtHStyle.Text)

            Else
                myObj.Fill = False
            End If
            RefreshMap()
        End If
    End Sub

    Private Sub OnChangeTable()
        Dim f As Form = New dlgChangeTable
        fCallForm = m_ParentForm
        f.ShowDialog(m_ParentForm)
        m_Map.CenterX = m_Map.CenterX
    End Sub

    Private Sub OnChangeText()
        Dim f As New dlgChangeLabel
        'fCallForm = Me
        Dim myObj As TextGraphic = m_SelectedObject
        f.txtLabel.Text = myObj.Text
        f.txtLabel.Font = myObj.Font 'StringFont
        f.txtLabel.ForeColor = myObj.Color

        If f.ShowDialog(m_ParentForm) = Windows.Forms.DialogResult.OK Then
            myObj.Text = f.txtLabel.Text
            myObj.Font = f.txtLabel.Font
            myObj.Color = f.txtLabel.ForeColor
            RefreshMap()
        End If
        'm_Map.CenterX = m_Map.CenterX
    End Sub

    Public Sub OnTimDiaDanh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim f As Form = New frmSearchDiaDanh
        'fCallForm = m_ParentForm
        'f.ShowDialog(m_ParentForm)
    End Sub

    Public Sub OnDeleteShape()
        If FoundObject.FoundSymbol.GObjs.Count > 1 Then
            FoundObject.FoundSymbol.GObjs.Remove(FoundObject.FoundObject)
        Else
            m_DrawingSymbols.Remove(FoundObject.FoundSymbol)
        End If
        m_Map.CenterX = m_Map.CenterX
    End Sub

    Public Sub OnAddNode()
        If Not FoundNode Is Nothing Then
            FoundNode.FoundObject.InsertNode(FoundNode.NodeIndex)
            m_Map.CenterX = m_Map.CenterX
        End If
    End Sub

    Public Sub OnXoaNode()
        If Not FoundNode Is Nothing Then
            FoundNode.FoundObject.RemoveNode(FoundNode.NodeIndex)
            m_Map.CenterX = m_Map.CenterX
        End If
    End Sub

    Public Sub OnChangeNodeType()
        If Not FoundNode Is Nothing Then
            FoundNode.FoundObject.ChangeNodeType(FoundNode.NodeIndex)
            m_Map.CenterX = m_Map.CenterX
        End If
    End Sub

    Public Sub OnChangeDesc(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim f As Form = New frmChangeDesc
        'fCallForm = m_ParentForm
        'f.ShowDialog(m_ParentForm)
        'm_Map.CenterX = m_Map.CenterX

        If Not m_SelectedSymbol Is Nothing Then
            PopUndo()
            m_ParentForm.ChangeDesc(m_SelectedSymbol, m_ParentForm)
            m_SelectedSymbol = Nothing
        End If

    End Sub

    Public Sub NhapNhayKH(ByVal iKH As Integer, ByVal pLan As Integer)
        Dim seleBrush1 As New HatchBrush( _
           HatchStyle.DiagonalCross, _
           Color.Red, Color.Transparent)
        Dim seleBrush2 As New HatchBrush( _
           HatchStyle.DiagonalCross, _
           Color.White, Color.Transparent)

        Dim mPen1 As New Pen(Color.White, 4)
        mPen1.Brush = seleBrush1
        Dim mPen2 As New Pen(Color.Black, 4)
        mPen2.Brush = seleBrush2

        Try
            Dim j As Integer
            Dim g As Graphics = m_Map.CreateGraphics
            For j = 0 To pLan
                m_DrawingSymbols(iKH).DanhDau(m_Map, g, mPen1) '   colKHs.Item(iKH).ToKH(g, seleBrush2)
                System.Threading.Thread.Sleep(NHAPNHAYDELAY)
                Application.DoEvents()

                m_DrawingSymbols(iKH).DanhDau(m_Map, g, mPen2)   'colKHs.Item(iKH).ToKH(g, seleBrush1)
                System.Threading.Thread.Sleep(NHAPNHAYDELAY)
                Application.DoEvents()
            Next
        Catch
        Finally
            seleBrush1.Dispose()
            seleBrush2.Dispose()
            mPen1.Dispose()
            mPen2.Dispose()
        End Try
        m_Map.Refresh()
        'm_Map.CenterX = m_Map.CenterX
    End Sub

    Public Sub NhapNhaySymbol(ByVal pSymbol As CSymbol, ByVal pLan As Integer)
        Dim seleBrush1 As New HatchBrush(HatchStyle.DiagonalCross, Color.Red, Color.Transparent)
        Dim seleBrush2 As New HatchBrush(HatchStyle.DiagonalCross, Color.White, Color.Transparent)

        Dim mPen1 As New Pen(Color.White, 2)
        mPen1.Brush = seleBrush1
        Dim mPen2 As New Pen(Color.Red, 2)
        mPen2.Brush = seleBrush2

        Try
            Dim j As Integer
            Dim g As Graphics = m_Map.CreateGraphics
            For j = 0 To pLan
                pSymbol.DanhDau(m_Map, g, mPen1)
                System.Threading.Thread.Sleep(NHAPNHAYDELAY / 2)
                System.Threading.Thread.Sleep(NHAPNHAYDELAY / 2)
                pSymbol.DanhDau(m_Map, g, mPen2)
                System.Threading.Thread.Sleep(NHAPNHAYDELAY / 2)
                m_Map.Refresh()
            Next
        Catch
        Finally
            seleBrush1.Dispose()
            seleBrush2.Dispose()
            mPen1.Dispose()
            mPen2.Dispose()
        End Try
    End Sub

    Public Sub LuuGeoSet()
        Try
            m_Map.Layers.Remove("LopVeKyHieu")
            'm_Map.SaveMapAsGeoset("BanDo", Application.StartupPath & "\\bando.gst")
            m_Map.SaveMapAsGeoset("BanDo", myMapGst)
            m_Map.Layers.AddUserDrawLayer("LopVeKyHieu", 1)

            myZoom = m_Map.Zoom
            myCX = m_Map.CenterX
            myCY = m_Map.CenterY
        Catch
        End Try
    End Sub

    Private Sub AddDataSets()
        m_Map.DataSets.RemoveAll()

        Dim lyr As MapXLib.Layer
        Dim i, j As Integer
        For i = 2 To m_Map.Layers.Count
            lyr = m_Map.Layers.Item(i)
            Try
                m_Map.DataSets.Add(MapXLib.DatasetTypeConstants.miDataSetLayer, lyr) 'miDataSetLayer, lyr)
            Catch ex As Exception
            End Try
        Next
    End Sub

    Public Sub NhapNhay(ByVal pObj As MapXLib.Feature, ByVal pSoLan As Integer)
        Dim i As Integer
        Dim lyr As MapXLib.Layer
        Dim f As New MapXLib.Feature
        Dim myStyle As New MapXLib.Style
        Dim myStyle2 As New MapXLib.Style
        Dim mTempNode As MapXLib.Feature
        Dim mColor As New UInt32

        On Error GoTo Err_NhapNhay

        lyr = m_Map.Layers.CreateLayer("tempAnimate", , 1)
        m_Map.Layers.AnimationLayer = lyr

        myStyle.SymbolFont.Name = "MapInfo Cartographic"
        myStyle.SymbolFont.Size = 18
        myStyle.SymbolCharacter = 72
        myStyle.SymbolFontColor = mColor.Parse(MapXLib.ColorConstants.miColorMagenta)

        myStyle2.SymbolFont.Name = "MapInfo Cartographic"
        myStyle2.SymbolFont.Size = 18
        myStyle2.SymbolCharacter = 72
        myStyle2.SymbolFontColor = mColor.Parse(MapXLib.ColorConstants.miColorWhite)

        Dim pt As New MapXLib.Point
        pt.Set(pObj.Point.X, pObj.Point.Y)
        mTempNode = lyr.AddFeature(m_Map.FeatureFactory.CreateSymbol(pt, myStyle))

        For i = 1 To pSoLan
            'DeLay(0.1)
            System.Threading.Thread.Sleep(NHAPNHAYDELAY)
            Application.DoEvents()
            mTempNode.Style = myStyle
            lyr.UpdateFeature(mTempNode, mTempNode)

            'DeLay(0.1)
            System.Threading.Thread.Sleep(NHAPNHAYDELAY)
            Application.DoEvents()
            mTempNode.Style = myStyle2
            lyr.UpdateFeature(mTempNode, mTempNode)

            'DoEvents()
        Next i

        myStyle = Nothing
        myStyle2 = Nothing
        f = Nothing
        mTempNode = Nothing

        On Error Resume Next
        m_Map.Layers.Remove("tempAnimate")

Exit_NhapNhay:
        Exit Sub
Err_NhapNhay:
        Resume Exit_NhapNhay

    End Sub

    Public Sub NhapNhayDT(ByVal pLop As String, ByVal pFKey As String, ByVal pSoLan As Integer)
        Dim i As Integer
        Dim lyr, lyr2 As MapXLib.Layer
        Dim f As MapXLib.Feature
        Dim fs As MapXLib.Features

        Dim myStyle As New MapXLib.Style
        Dim mColor As New UInt32

        Dim strSelect As String

        On Error GoTo Err_NhapNhay

        lyr2 = m_Map.Layers.Item(pLop)
        f = lyr2.GetFeatureByKey(pFKey)
        If Not m_Map.IsPointVisible(f.CenterX, f.CenterY) Then
            m_Map.CenterX = f.CenterX
            m_Map.CenterY = f.CenterY
        End If

        If (f.Type = MapXLib.FeatureTypeConstants.miFeatureTypeSymbol) Then
            NhapNhay(f, pSoLan)
        Else
            myStyle = f.Style
            If f.Type = MapXLib.FeatureTypeConstants.miFeatureTypeLine Then
                myStyle.LineColor = mColor.Parse(MapXLib.ColorConstants.miColorRed)
                myStyle.LineStyle = 46
            ElseIf f.Type = MapXLib.FeatureTypeConstants.miFeatureTypeRegion Then
                myStyle.RegionBorderColor = mColor.Parse(MapXLib.ColorConstants.miColorWhite)
                myStyle.RegionPattern = MapXLib.FillPatternConstants.miPatternDiagCross
                myStyle.RegionColor = mColor.Parse(MapXLib.ColorConstants.miColorRed)
            ElseIf (f.Type = MapXLib.FeatureTypeConstants.miFeatureTypeText) Then
                myStyle.TextFontColor = mColor.Parse(MapXLib.ColorConstants.miColorWhite)
            End If
            f.Style = myStyle
            lyr = m_Map.Layers.CreateLayer("tempAnimate", , 1)
            m_Map.Layers.AnimationLayer = lyr

            lyr.AddFeature(f)

            For i = 1 To pSoLan
                lyr.Visible = True
                System.Threading.Thread.Sleep(120)
                Application.DoEvents()
                lyr.Visible = False
                System.Threading.Thread.Sleep(120)
                Application.DoEvents()
            Next i
            f = Nothing

            On Error Resume Next
            m_Map.Layers.Remove("tempAnimate")

        End If
        'End If
Exit_NhapNhay:
        Exit Sub
Err_NhapNhay:
        MsgBox("Khong tim thay.")
        Resume Exit_NhapNhay
    End Sub

    Public Sub DiaDanhTrenBD()
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        'UpdateTB(4)
        'Dim f As Form = New frmSearchDiaDanh
        'fCallForm = m_ParentForm
        'f.Show()
    End Sub

    Private Sub m_Map_DrawUserLayer(ByVal sender As Object, ByVal e As AxMapXLib.CMapXEvents_DrawUserLayerEvent) Handles m_Map.DrawUserLayer

        Dim seleBrush As New HatchBrush( _
           HatchStyle.DiagonalCross, _
           Color.White, Color.Transparent)

        Dim mPen1 As New Pen(Color.Blue, 4)
        mPen1.Brush = seleBrush

        Dim myGraphics As Graphics = Graphics.FromHdc(New IntPtr(e.hOutputDC))

        Try
            m_DrawingSymbols.DrawSymbols(m_Map, myGraphics)
            If Not m_SelectedSymbol Is Nothing Then
                If myMapTool = MapTools.NodesEdit Then
                    m_SelectedSymbol.DrawNodes(m_Map, myGraphics)
                ElseIf myMapTool = MapTools.ChangeRoot Then
                    m_SelectedSymbol.DrawRoot(m_Map, myGraphics)
                Else
                    m_SelectedSymbol.DanhDau(m_Map, myGraphics, DanhDauColor)
                    m_SelectedSymbol.DanhDau(m_Map, myGraphics, mPen1)
                End If
            End If

            If m_SelectedSymbols.Count > 0 Then
                For Each mSymbol As CSymbol In m_SelectedSymbols
                    mSymbol.VeBound(m_Map, myGraphics, VeBoundColor)
                Next
            End If

        Catch ex As System.Exception
            Debug.WriteLine(ex.ToString)
            Throw New System.ApplicationException("Error Drawing Graphics Surface", ex)
        Finally
            mPen1.Dispose()
            seleBrush.Dispose()
        End Try

        If bGrid Then
            GridSize.Width = myGridWidth
            GridSize.Height = myGridWidth
            'GridRect = New Rectangle(0, 0, myWidth, myHeight)
            GridRect.Width = m_Map.MapScreenWidth 'm_Map.Width 'myWidth
            GridRect.Height = m_Map.MapScreenHeight 'm_Map.Height 'myHeight
            ControlPaint.DrawGrid(myGraphics, GridRect, GridSize, Color.Red)
        End If
    End Sub

    Private Sub DrawDrawingLine(ByVal pPts() As PointF)
        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 2)

        Dim gCon As Drawing2D.GraphicsContainer
        Dim myOriginalMatrix As Drawing2D.Matrix
        myOriginalMatrix = g.Transform()
        gCon = g.BeginContainer
        g.PageUnit = GraphicsUnit.Pixel
        g.ScaleTransform(1, 1)

        Dim mPtsCount As Integer = pPts.GetUpperBound(0)
        Dim mPts(mPtsCount) As Point
        Dim i As Integer
        For i = 0 To mPtsCount
            'm_Map.ConvertCoord(mPts(i).X, mPts(i).Y, pPts(i).X, pPts(i).Y, MapXLib.ConversionConstants.miMapToScreen)
            mPts(i).X = pPts(i).X
            mPts(i).Y = pPts(i).Y
        Next

        Select Case myMapTool
            Case MapTools.Line, MapTools.Ruler, MapTools.MuiTenDon, MapTools.MuiTen, MapTools.MuiTenHo, MapTools.MuiTenDac
                g.DrawLines(DrawingPen, mPts)
            Case MapTools.Curve, MapTools.SongSong, MapTools.GetTarget
                g.DrawCurve(DrawingPen, mPts)
            Case MapTools.ClosedCurve, MapTools.SongSongKin
                If pPts.GetUpperBound(0) > 1 Then
                    g.DrawClosedCurve(DrawingPen, mPts)
                Else
                    g.DrawLines(DrawingPen, mPts)
                End If
            Case MapTools.Polygon
                If pPts.GetUpperBound(0) > 1 Then
                    g.DrawPolygon(DrawingPen, mPts)
                Else
                    g.DrawLines(DrawingPen, mPts)
                End If
        End Select
        g.EndContainer(gCon)
        g.Transform = myOriginalMatrix

        DrawingPen.Dispose()
    End Sub

    Private Sub DrawMovingSymbol(ByVal seleSymbol As CSymbol)
        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        seleSymbol.Draw(m_Map, g)
    End Sub

    Private Sub DrawMovingSymbols(ByVal seleSymbols As CSymbols)
        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        For Each mSymbol As CSymbol In seleSymbols
            mSymbol.Draw(m_Map, g)
        Next
    End Sub

    Private Sub DrawMovingNode(ByVal seleSymbol As CSymbol)
        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        seleSymbol.Draw(m_Map, g)
        seleSymbol.DrawNodes(m_Map, g)
    End Sub

    Private Sub DrawMovingRoot(ByVal seleSymbol As CSymbol)
        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        seleSymbol.Draw(m_Map, g)
        seleSymbol.DrawRoot(m_Map, g)
    End Sub

    Private Sub DrawRotatingSymbol(ByRef seleSymbol As CSymbol, ByVal dragPoint As PointF)

        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 3)

        seleSymbol.Draw(m_Map, g)

        Dim mPts(1) As PointF
        mPts(0).X = myrootPt.X
        mPts(0).Y = myrootPt.Y
        mPts(1).X = dragPoint.X
        mPts(1).Y = dragPoint.Y

        DrawingPen.EndCap = LineCap.ArrowAnchor
        DrawingPen.StartCap = LineCap.RoundAnchor
        g.DrawLine(DrawingPen, mPts(0), mPts(1))

        DrawingPen.Dispose()
    End Sub

    Private Sub DrawSplittingLine(ByVal dragPoint As PointF)

        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 3)

        'seleSymbol.Draw(m_Map, g)

        Dim mPts(1) As PointF
        mPts(0).X = myfromPt.X
        mPts(0).Y = myfromPt.Y
        mPts(1).X = dragPoint.X
        mPts(1).Y = dragPoint.Y

        'DrawingPen.EndCap = LineCap.ArrowAnchor
        'DrawingPen.StartCap = LineCap.RoundAnchor
        g.DrawLine(DrawingPen, mPts(0), mPts(1))

        DrawingPen.Dispose()
    End Sub

    Private Sub DrawSelectionRectangle(ByVal selectionRect As RectangleF)
        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()

        Dim selectionBrush As New SolidBrush(Color.FromArgb(75, Color.Gray))
        Dim normalizedRectangle As RectangleF

        'make sure the rectangle's upper left point is
        'up and to the left relative to the other points of the rectangle by
        'ensuring that it has a positive width and height.
        normalizedRectangle.Size = selectionRect.Size
        If selectionRect.Width < 0 Then
            normalizedRectangle.X = selectionRect.X - normalizedRectangle.Width
        Else
            normalizedRectangle.X = selectionRect.X
        End If

        If selectionRect.Height < 0 Then
            normalizedRectangle.Y = selectionRect.Y - normalizedRectangle.Height
        Else
            normalizedRectangle.Y = selectionRect.Y
        End If

        g.FillRectangle(selectionBrush, normalizedRectangle)
    End Sub

    Private Sub DrawDrawingRectangle(ByVal DrawingRect As Rectangle)

        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        'Dim selectionBrush As New SolidBrush(Color.FromArgb(75, Color.Gray))
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 2)
        Dim normalizedRectangle As Rectangle

        'make sure the rectangle's upper left point is
        'up and to the left relative to the other points of the rectangle by
        'ensuring that it has a positive width and height.
        normalizedRectangle.Size = DrawingRect.Size
        If DrawingRect.Width < 0 Then
            normalizedRectangle.X = DrawingRect.X - normalizedRectangle.Width
        Else
            normalizedRectangle.X = DrawingRect.X
        End If

        If DrawingRect.Height < 0 Then
            normalizedRectangle.Y = DrawingRect.Y - normalizedRectangle.Height
        Else
            normalizedRectangle.Y = DrawingRect.Y
        End If

        'g.FillRectangle(selectionBrush, normalizedRectangle)
        g.DrawRectangle(DrawingPen, normalizedRectangle)

        DrawingPen.Dispose()
    End Sub

    Private Sub DrawDrawingArc(ByVal DrawingRect As Rectangle)
        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()

        Dim mPt0 As New PointF
        Dim i As Integer

        Dim myPts2(3) As PointF
        myPts2(1).X = DrawingRect.X
        myPts2(1).Y = DrawingRect.Y
        myPts2(2).X = DrawingRect.X + DrawingRect.Width
        myPts2(2).Y = DrawingRect.Y
        myPts2(3).X = DrawingRect.X + DrawingRect.Width
        myPts2(3).Y = DrawingRect.Y + DrawingRect.Height
        myPts2(0).X = DrawingRect.X
        myPts2(0).Y = DrawingRect.Y + DrawingRect.Height

        'Dim gp As New Drawing2D.GraphicsPath
        'gp.AddCurve(myPts2)
        'Dim rf As RectangleF = gp.GetBounds
        'mPt0.X = (rf.Left + rf.Right) / 2
        'mPt0.Y = (rf.Top + rf.Bottom) / 2
        'For i = 0 To myPts2.GetUpperBound(0)
        'myPts2(i).X -= mPt0.X
        'myPts2(i).Y -= mPt0.Y
        'Next
        Dim myCurve As NodesShapeGraphic  'GraphicObject
        myCurve = New LinesGraphic(myPts2, 1, Color.Red)
        myCurve.Fill = False  'defaGenFill
        myCurve.FillColor = defaGenFillC
        myCurve.Rotation = 0
        myCurve.LineWidth = defaGenPen1W
        myCurve.LineColor = defaGenPen1C
        myCurve.Line2Width = defaGenPen2W
        myCurve.Line2Color = defaGenPen2C
        myCurve.LineStyle = defaGenLineStyle
        myCurve.StyleWidth = 8
        'gObj = myCurve
        myCurve.Nodes(1).IsControl = True
        myCurve.Nodes(2).IsControl = True

        myCurve.Draw(g)
    End Sub

    Private Sub DrawDrawingEllipse(ByVal DrawingRect As Rectangle)
        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 2)
        g.DrawEllipse(DrawingPen, DrawingRect)
        DrawingPen.Dispose()
    End Sub

    Private Function DrawDrawingPie(ByVal DrawingRect As Rectangle) As Boolean
        Try
            Dim g As Graphics = m_Map.CreateGraphics
            m_Map.Refresh()
            Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 2)
            Dim mRect As Rectangle = New Rectangle(DrawingRect.Left - DrawingRect.Width, _
            DrawingRect.Top - DrawingRect.Height, _
            DrawingRect.Width * 2, DrawingRect.Height * 2)
            g.DrawPie(DrawingPen, mRect, 0, 90)
            DrawingPen.Dispose()
            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub DrawDrawingRectangle0(ByVal DrawingRect As RectangleF)

        Dim g As Graphics = m_Map.CreateGraphics
        m_Map.Refresh()
        'Dim selectionBrush As New SolidBrush(Color.FromArgb(75, Color.Gray))
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 2)
        'Dim normalizedRectangle As Rectangle

        'make sure the rectangle's upper left point is
        'up and to the left relative to the other points of the rectangle by
        'ensuring that it has a positive width and height.
        'normalizedRectangle.Size = DrawingRect.Size
        'If DrawingRect.Width < 0 Then
        'normalizedRectangle.X = DrawingRect.X - normalizedRectangle.Width
        'Else
        '    normalizedRectangle.X = DrawingRect.X
        'End If

        'If DrawingRect.Height < 0 Then
        'normalizedRectangle.Y = DrawingRect.Y - normalizedRectangle.Height
        'Else
        '    normalizedRectangle.Y = DrawingRect.Y
        'End If

        'g.FillRectangle(selectionBrush, normalizedRectangle)
        'g.DrawRectangle(DrawingPen, normalizedRectangle)
        Dim gCon As Drawing2D.GraphicsContainer
        Dim myOriginalMatrix As Drawing2D.Matrix
        myOriginalMatrix = g.Transform()
        gCon = g.BeginContainer
        g.PageUnit = GraphicsUnit.Pixel
        g.ScaleTransform(1, 1)

        Dim pPts(1) As PointF
        pPts(0).X = DrawingRect.X
        pPts(0).Y = DrawingRect.Y
        pPts(1).X = DrawingRect.X + DrawingRect.Width
        pPts(1).Y = DrawingRect.Y + DrawingRect.Height

        Dim mPtsCount As Integer = pPts.GetUpperBound(0)
        Dim mPts(mPtsCount) As Point
        Dim i As Integer
        For i = 0 To mPtsCount
            m_Map.ConvertCoord(mPts(i).X, mPts(i).Y, pPts(i).X, pPts(i).Y, MapXLib.ConversionConstants.miMapToScreen)
        Next
        Dim rect As New Rectangle(mPts(0).X, mPts(0).Y, mPts(1).X - mPts(0).X, mPts(1).Y - mPts(0).Y)
        g.DrawRectangle(DrawingPen, rect)
        g.EndContainer(gCon)
        g.Transform = myOriginalMatrix

        DrawingPen.Dispose()
    End Sub

    Private Sub m_Map_MapViewChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_Map.MapViewChanged
        m_ParentForm.ToolStripStatusLabel2.Text = Format(m_Map.Zoom, "#,# m") & " | " & Format(m_Map.Width, "#,#")
        'm_Statusbar.Panels.Item(2).Text = Format(m_Map.MapPaperWidth, "#,# mm")
        'm_Statusbar.Panels.Item(3).Text = "1:" & (m_Map.Zoom * 1000 / m_Map.MapPaperWidth).ToString("#,#")
    End Sub

    Private Sub m_Map_MouseDownEvent(ByVal sender As Object, ByVal e As AxMapXLib.CMapXEvents_MouseDownEvent) Handles m_Map.MouseDownEvent
        Dim mousePT As Point '= gscTogoc(e.x, e.y)
        If bSnap Then
            mousePT = Snap(e.x, e.y)
        Else
            mousePT = New Point(e.x, e.y)
        End If
        'm_Statusbar.Panels(2).Text = "Shift: " & e.shift.ToString & ", " & Keys.Shift
        Select Case myMapTool
            Case MapTools.GetObjName
                Dim mSymbolObj As CSymbol = m_DrawingSymbols.FindSymbolAtPoint(m_Map, New PointF(e.x, e.y))
                If Not mSymbolObj Is Nothing Then
                    GetObjName(mSymbolObj)
                End If
            Case MapTools.ChonKH
                'm_ParentForm.ToolStripStatusLabel3.Text = "chon"
                If e.button = 1 Then 'left button
                    'm_SelectedSymbols.Clear()
                    If e.shift = 1 Then 'Shift
                        'm_SelectedSymbols.Clear()
                        selectionDragging = True
                        selectionRect.X = e.x
                        selectionRect.Y = e.y
                        selectionRect.Height = 0
                        selectionRect.Width = 0
                    ElseIf e.shift = 3 Then
                        Dim mSymbolObj As CSymbol = m_DrawingSymbols.FindSymbolAtPoint(m_Map, New PointF(e.x, e.y))
                        If Not mSymbolObj Is Nothing Then
                            Dim bCoRoi As Boolean = False
                            For Each mSObj As CSymbol In m_SelectedSymbols
                                If mSObj Is mSymbolObj Then
                                    bCoRoi = True
                                End If
                            Next
                            If bCoRoi = True Then
                                m_SelectedSymbols.Remove(mSymbolObj)
                            Else
                                m_SelectedSymbols.Add(mSymbolObj)
                            End If
                            m_Map.CenterX = m_Map.CenterX
                        End If
                    Else
                        m_SelectedSymbols.Clear()
                        Me.SelectedSymbol = m_DrawingSymbols.FindSymbolAtPoint(m_Map, New PointF(e.x, e.y))
                        If Not m_SelectedSymbol Is Nothing Then
                            'm_ParentForm.ToolStripStatusLabel3.Text = e.shift.ToString & " Thay :" & m_SelectedSymbol.GObjs.Item(0).X.ToString & ", " & m_SelectedSymbol.GObjs.Item(0).Y.ToString & ", " & m_SelectedSymbol.GObjs.Item(0).Width.ToString & ", " & m_SelectedSymbol.GObjs.Item(0).Height.ToString
                            m_ParentForm.lstCacKyHieu.SelectedIndex = m_ParentForm.lstCacKyHieu.Items.IndexOf(m_SelectedSymbol)

                            Select Case e.shift
                                Case 2 'Ctrl
                                    PopUndo()
                                    myMapTool = MapTools.DangMove
                                    myfromPt = New PointF(mousePT.X, mousePT.Y)
                                    mytoPt = New PointF(mousePT.X, mousePT.Y)
                                Case 4 'Alter
                                    PopUndo()
                                    myMapTool = MapTools.DangRotate
                                    myfromPt = New PointF(mousePT.X, mousePT.Y)
                                    mytoPt = New PointF(mousePT.X, mousePT.Y)
                                    myrootPt = New PointF
                                    m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)

                                    DrawRotatingSymbol(m_SelectedSymbol, New PointF(mousePT.X, mousePT.Y))
                                Case 6 ' Ctrl + Alter
                                    PopUndo()
                                    myMapTool = MapTools.DangScale
                                    myfromPt = New PointF(mousePT.X, mousePT.Y)
                                    mytoPt = New PointF(mousePT.X, mousePT.Y)
                                    myrootPt = New PointF
                                    m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)

                                    DrawRotatingSymbol(m_SelectedSymbol, New PointF(mousePT.X, mousePT.Y))
                                    'Case Else
                                    'MsgBox(e.shift)
                            End Select
                        Else
                            'm_ParentForm.ToolStripStatusLabel3.Text = "" '"Khong SelectedObject"
                        End If

                    End If
                Else
                    Select Case myMapTool
                        Case MapTools.ChonKH
                            If m_SelectedSymbols.Count > 0 Then
                                Me.CxtMnuGroup.Show(m_Panel, New Point(e.x, e.y))
                            Else
                                'm_SelectedSymbol = Nothing
                                FoundObject = m_DrawingSymbols.FindObjectAtPoint(m_Map, New PointF(e.x, e.y))
                                If Not FoundObject Is Nothing Then
                                    m_Map.Refresh()
                                    m_SelectedObject = FoundObject.FoundObject
                                    m_SelectedSymbol = FoundObject.FoundSymbol
                                    FoundObject.FoundSymbol.DanhDau(m_Map, m_Map.CreateGraphics, DanhDauColor)
                                    FoundObject.FoundSymbol.VeBound(m_Map, m_Map.CreateGraphics, VeBoundColor)
                                    FoundObject.FoundSymbol.VeBound(m_Map, m_Map.CreateGraphics, m_SelectedObject, VeBoundColor)
                                    FoundObject.FoundSymbol.DanhDau(m_Map, m_Map.CreateGraphics, m_SelectedObject, DanhDauColor2)
                                    CxtMnuKyHieu.Show(m_Panel, New Point(e.x, e.y))
                                Else
                                    mousePos = New PointF(mousePT.X, mousePT.Y)
                                    CxtMnuMap.Show(m_Panel, New Point(e.x, e.y))
                                End If
                            End If
                    End Select
                End If
            Case MapTools.NodesEdit
                FoundNode = m_SelectedSymbol.FindNodeAtPoint(m_Map, New PointF(e.x, e.y))
                If Not FoundNode Is Nothing Then
                    PopUndo()
                    If e.button = 1 Then
                        NodeDragging = True
                        myfromPt = New PointF(mousePT.X, mousePT.Y)
                        mytoPt = New PointF(mousePT.X, mousePT.Y)
                    Else
                        Me.CxtMnuNodeEdit.Show(m_Panel, New Point(e.x, e.y))
                    End If
                Else
                    'myMapTool = MapTools.ChonKH
                    'm_Map.CenterX = m_Map.CenterX
                    OnCapNhatKH()
                End If
            Case MapTools.ChangeRoot
                If m_SelectedSymbol.RootHitTest(m_Map, New PointF(e.x, e.y)) Then
                    PopUndo()

                    RootDragging = True
                    myfromPt = New PointF(mousePT.X, mousePT.Y)
                    mytoPt = New PointF(mousePT.X, mousePT.Y)
                Else
                    'myMapTool = MapTools.ChonKH
                    'm_Map.CenterX = m_Map.CenterX
                    OnCapNhatKH()
                End If
            Case MapTools.Move
                PopUndo()
                myMapTool = MapTools.DangMove
                myfromPt = New PointF(mousePT.X, mousePT.Y)
                mytoPt = New PointF(mousePT.X, mousePT.Y)
            Case MapTools.GrMove
                PopUndo()
                myMapTool = MapTools.GrDangMove
                myfromPt = New PointF(mousePT.X, mousePT.Y)
                mytoPt = New PointF(mousePT.X, mousePT.Y)
            Case MapTools.Scale
                PopUndo()
                myMapTool = MapTools.DangScale
                myfromPt = New PointF(mousePT.X, mousePT.Y)
                mytoPt = New PointF(mousePT.X, mousePT.Y)
                myrootPt = New PointF
                m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)

                DrawRotatingSymbol(m_SelectedSymbol, New PointF(mousePT.X, mousePT.Y))
            Case MapTools.Rotate
                PopUndo()
                myMapTool = MapTools.DangRotate
                myfromPt = New PointF(mousePT.X, mousePT.Y)
                mytoPt = New PointF(mousePT.X, mousePT.Y)
                myrootPt = New PointF
                m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)

                DrawRotatingSymbol(m_SelectedSymbol, New PointF(mousePT.X, mousePT.Y))
            Case MapTools.Split
                PopUndo()
                myMapTool = MapTools.DangSplit
                myfromPt = New PointF(mousePT.X, mousePT.Y)
                mytoPt = New PointF(mousePT.X, mousePT.Y)
                myrootPt = New PointF
                m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)

                DrawSplittingLine(New PointF(mousePT.X, mousePT.Y))
            Case MapTools.Line, MapTools.Curve, MapTools.ClosedCurve, MapTools.Polygon, MapTools.Ruler, MapTools.GetTarget, MapTools.MuiTenDon, MapTools.MuiTen, MapTools.MuiTenHo, MapTools.MuiTenDac, MapTools.SongSong, MapTools.SongSongKin
                If e.button = 1 Then
                    If Not DrawingPicking Then
                        DrawingPicking = True
                        ReDim myPts(1)
                        myPts(0) = New PointF(mousePT.X, mousePT.Y) 'mousePT
                        myPts(1) = New PointF(mousePT.X, mousePT.Y) 'mousePT
                    Else
                        Dim i As Integer = myPts.GetUpperBound(0)
                        i += 1
                        ReDim Preserve myPts(i)
                        myPts(i) = New PointF(mousePT.X, mousePT.Y) 'mousePT
                        'm_Statusbar.Panels(2).Text = myPts(i).ToString
                    End If
                Else
                    If Not DrawingPicking Then
                        If myMapTool = MapTools.GetTarget Then
                            ReDim myPts(0)
                            myPts(0) = New PointF(mousePT.X, mousePT.Y)
                            GetTargets()
                        End If
                    End If

                    If myPts.GetUpperBound(0) > 0 Then
                        If myMapTool = MapTools.Ruler Then
                            Dim mLon1, mLat1, mLon2, mLat2 As Double
                            Dim mDist, i As Integer
                            If myPts.GetUpperBound(0) > 0 Then
                                For i = 1 To myPts.GetUpperBound(0)
                                    'Dim mptsCount As Integer = myPts.GetLowerBound(0) + 1
                                    m_Map.ConvertCoord(myPts(i - 1).X, myPts(i - 1).Y, mLon1, mLat1, MapXLib.ConversionConstants.miScreenToMap)
                                    m_Map.ConvertCoord(myPts(i).X, myPts(i).Y, mLon2, mLat2, MapXLib.ConversionConstants.miScreenToMap)
                                    mDist = m_Map.Distance(mLon1, mLat1, mLon2, mLat2)
                                    If strDistanceKQ.Length > 0 Then
                                        DistanceKQ += mDist
                                        strDistanceKQ &= " + " & Format(mDist, "#,###")
                                    Else
                                        DistanceKQ = mDist
                                        strDistanceKQ = Format(mDist, "#,###")
                                    End If
                                Next
                            End If

                            If strDistanceKQ.IndexOf("+") > -1 Then
                                strDistanceKQ &= " = " & Format(DistanceKQ, "#,###") & " " & strDistanceUnit
                            Else
                                strDistanceKQ = Format(DistanceKQ, "#,###") & " " & strDistanceUnit
                            End If
                            MessageBox.Show(m_ParentForm, strDistanceKQ, "Kết quả đo:", MessageBoxButtons.OK)

                        ElseIf myMapTool = MapTools.GetTarget Then
                            GetTargets()
                        Else
                            AddNewObj(e.shift)
                        End If
                        'm_Statusbar.Panels(2).Text = "ve xong: " & m_DrawingSymbols.Count.ToString
                    End If
                    DrawingPicking = False
                    'myMapTool = MapTools.ChonKH
                    'UpdateTB("UpdateKH")
                    If myMapTool = MapTools.Ruler Then
                        strDistanceKQ = ""
                        ReDim myPts(-1)
                        m_ParentForm.ToolStripStatusLabel3.Text = "Đo khoảng cách: Click để chọn các Vị trí, RightClick để xem Kết quả."
                    ElseIf myMapTool = MapTools.GetTarget Then
                        ReDim myPts(-1)
                        m_ParentForm.ToolStripStatusLabel3.Text = ""
                        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
                        myMapTool = MapTools.None
                    Else
                        OnCapNhatKH()
                    End If
                End If

            Case MapTools.Cycle, MapTools.Rectangle, MapTools.arc
                If e.button = 1 Then 'MouseButtons.Left
                    DrawingDragging = True
                    DrawingRect.X = mousePT.X
                    DrawingRect.Y = mousePT.Y
                    DrawingRect.Height = 0
                    DrawingRect.Width = 0
                End If
            Case MapTools.Text
                ReDim myPts(0)
                myPts(0) = New PointF(mousePT.X, mousePT.Y) 'mousePT

                AddNewObj(e.shift)
                Dim f As New dlgChangeText
                f.TextObj = m_DrawingSymbols(m_DrawingSymbols.Count - 1).GObjs(0)
                f.Pos = New Point(m_ParentForm.Location.X + m_Panel.Left + mousePT.X, m_ParentForm.Location.Y + m_Panel.Top + mousePT.Y)
                'f.Location = New Point(0, 0)
                fCallForm = m_ParentForm
                f.ShowDialog(m_ParentForm)
                m_Map.CenterX = m_Map.CenterX

                'myMapTool = MapTools.ChonKH
                'UpdateTB("UpdateKH")
                OnCapNhatKH()
            Case MapTools.Table
                ReDim myPts(0)
                myPts(0) = New PointF(mousePT.X, mousePT.Y) 'mousePT
                AddNewObj(e.shift)
                'myMapTool = MapTools.ChonKH
                'UpdateTB("UpdateKH")
                OnCapNhatKH()
        End Select

    End Sub

    Private Sub m_Map_MouseMoveEvent(ByVal sender As Object, ByVal e As AxMapXLib.CMapXEvents_MouseMoveEvent) Handles m_Map.MouseMoveEvent
        Dim mousePT As Point '= gscTogoc(e.x, e.y)
        If bSnap Then
            mousePT = Snap(e.x, e.y)
        Else
            mousePT = New Point(e.x, e.y)
        End If

        Dim dragPoint As MAPPOINT = gscTogoc(e.x, e.y)
        m_ParentForm.ToolStripStatusLabel1.Text = dragPoint.X.ToString("0.000000000") & ", " & dragPoint.Y.ToString("0.000000000")

        If selectionDragging Then
            selectionRect.Width = e.x - selectionRect.X
            selectionRect.Height = e.y - selectionRect.Y
            DrawSelectionRectangle(selectionRect)
        End If

        If m_SelectedSymbols.Count > 0 Then
            If myMapTool = MapTools.GrDangMove Then
                mytoPt = New PointF(mousePT.X, mousePT.Y) 'dragPoint
                For Each mSymbol As CSymbol In m_SelectedSymbols
                    mSymbol.Move(m_Map, myfromPt, mytoPt)
                Next
                myfromPt = mytoPt
                DrawMovingSymbols(m_SelectedSymbols)
            End If
        End If

        If Not IsNothing(fCacKyHieu) Then
            If myMapTool = MapTools.DangLayKH Then
                If IsNothing(m_KHfromVeKH) Then
                    myfromPt = New PointF(mousePT.X, mousePT.Y)
                    'm_KHfromVeKH = GetKHfromVeKH(fCacKyHieu.OdrawingObjects, fCacKyHieu.myORootX, fCacKyHieu.myORootY, mTyLe, myfromPt)
                    m_KHfromVeKH = GetKHfromVeKH(myfromPt)
                    'fCacKyHieu.Visible = False
                End If
                mytoPt = New PointF(mousePT.X, mousePT.Y) 'dragPoint
                m_KHfromVeKH.Move(m_Map, myfromPt, mytoPt)
                myfromPt = mytoPt
                DrawMovingSymbol(m_KHfromVeKH)
            End If
        End If

        If Not m_SelectedSymbol Is Nothing Then
            If myMapTool = MapTools.DangMove Then
                mytoPt = New PointF(mousePT.X, mousePT.Y) 'dragPoint
                m_SelectedSymbol.Move(m_Map, myfromPt, mytoPt)
                myfromPt = mytoPt
                DrawMovingSymbol(m_SelectedSymbol)
            ElseIf myMapTool = MapTools.DangRotate Then
                mytoPt = New PointF(mousePT.X, mousePT.Y) 'dragPoint
                m_SelectedSymbol.Rotate(m_Map, myrootPt, myfromPt, mytoPt)
                myfromPt = mytoPt
                DrawRotatingSymbol(m_SelectedSymbol, mytoPt)
            ElseIf myMapTool = MapTools.DangScale Then
                mytoPt = New PointF(mousePT.X, mousePT.Y) 'dragPoint
                m_SelectedSymbol.Rotate(m_Map, myrootPt, myfromPt, mytoPt)
                m_SelectedSymbol.Scale(m_Map, myrootPt, myfromPt, mytoPt)
                myfromPt = mytoPt
                DrawRotatingSymbol(m_SelectedSymbol, mytoPt)
            ElseIf myMapTool = MapTools.DangSplit Then
                mytoPt = New PointF(mousePT.X, mousePT.Y) 'dragPoint
                'm_SelectedSymbol.Scale(m_Map, myrootPt, myfromPt, mytoPt)
                'myfromPt = mytoPt
                DrawSplittingLine(mytoPt)
            ElseIf myMapTool = MapTools.NodesEdit Then
                mytoPt = New PointF(mousePT.X, mousePT.Y)
                If NodeDragging Then
                    Dim mFoundNode As CFOUNDNODE = m_SelectedSymbol.FindNodeAtPoint(m_Map, New PointF(e.x, e.y))
                    If Not mFoundNode Is Nothing Then
                        If mFoundNode.FoundObject Is FoundNode.FoundObject Then
                            If mFoundNode.NodeIndex = FoundNode.NodeIndex Then
                                'fMain.ToolStripStatusLabel5.Text = FoundNode.NodeIndex.ToString & " = " & mFoundNode.NodeIndex.ToString
                            Else
                                'fMain.ToolStripStatusLabel5.Text = FoundNode.NodeIndex.ToString & " <> " & mFoundNode.NodeIndex.ToString
                                Dim mPts() As PointF = mFoundNode.FoundObject.GetPoints()
                                Dim mPt As PointF = mPts(mFoundNode.NodeIndex)
                                FoundNode.FoundObject.MoveNodeTo(FoundNode.NodeIndex, mPt)
                                DrawMovingNode(m_SelectedSymbol)
                            End If
                        Else
                            'fMain.ToolStripStatusLabel5.Text = FoundNode.NodeIndex.ToString & " <> " & mFoundNode.NodeIndex.ToString
                            Dim mPts() As PointF = mFoundNode.FoundObject.GetPoints()
                            Dim mPt As PointF = mPts(mFoundNode.NodeIndex)
                            FoundNode.FoundObject.MoveNodeTo(FoundNode.NodeIndex, mPt)
                            DrawMovingNode(m_SelectedSymbol)
                        End If
                    Else
                        'fMain.ToolStripStatusLabel5.Text = ""
                        m_SelectedSymbol.MoveNodeTo(m_Map, FoundNode, mytoPt)
                        DrawMovingNode(m_SelectedSymbol)
                    End If
                End If
            ElseIf myMapTool = MapTools.ChangeRoot Then
                mytoPt = New PointF(mousePT.X, mousePT.Y)
                If RootDragging Then
                    Dim mRootX, mRootY As Double
                    m_Map.ConvertCoord(mytoPt.X, mytoPt.Y, mRootX, mRootY, MapXLib.ConversionConstants.miScreenToMap)
                    m_SelectedSymbol.ChangeRoot(m_Map, mRootX, mRootY)
                    DrawMovingRoot(m_SelectedSymbol)
                    'm_Map.CenterX = m_Map.CenterX
                End If
            End If
        Else

            If DrawingPicking Then
                Dim i = myPts.GetUpperBound(0)
                myPts(i).X = mousePT.X '- Me.AutoScrollPosition.X
                myPts(i).Y = mousePT.Y '- Me.AutoScrollPosition.Y
                DrawDrawingLine(myPts)
                If (myMapTool = MapTools.Ruler) Then
                    Dim mLon1, mLat1, mLon2, mLat2 As Double
                    Dim mDist As Integer
                    m_Map.ConvertCoord(myPts(i - 1).X, myPts(i - 1).Y, mLon1, mLat1, MapXLib.ConversionConstants.miScreenToMap)
                    m_Map.ConvertCoord(myPts(i).X, myPts(i).Y, mLon2, mLat2, MapXLib.ConversionConstants.miScreenToMap)
                    mDist = m_Map.Distance(mLon1, mLat1, mLon2, mLat2)
                    m_ParentForm.ToolStripStatusLabel3.Text = "Đo: " & mDist.ToString("#,###")
                End If
            End If

            If DrawingDragging Then
                DrawingRect.Width = mousePT.X - DrawingRect.X
                DrawingRect.Height = mousePT.Y - DrawingRect.Y
                'DrawDrawingRectangle(DrawingRect)
                If myMapTool = MapTools.Cycle Then
                    DrawDrawingEllipse(DrawingRect)
                ElseIf myMapTool = MapTools.Rectangle Then
                    DrawDrawingRectangle(DrawingRect)
                ElseIf myMapTool = MapTools.arc Then
                    DrawDrawingArc(DrawingRect)
                End If
            End If

        End If

        If myMapTool = MapTools.None Then
            If (m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool) Then
                'Dim iTmpPath As Integer = colKHs.isVisible(e.x, e.y)
                Dim mSymbol As CSymbol = m_DrawingSymbols.FindSymbolAtPoint(m_Map, New PointF(e.x, e.y))
                If Not mSymbol Is Nothing Then
                    toolTip1.Active = True
                    toolTip1.SetToolTip(m_Map, mSymbol.Description)
                Else
                    toolTip1.Active = False
                End If
            End If
        End If
    End Sub

    Private Sub m_Map_MouseUpEvent(ByVal sender As Object, ByVal e As AxMapXLib.CMapXEvents_MouseUpEvent) Handles m_Map.MouseUpEvent
        Dim mousePT As Point '= gscTogoc(e.x, e.y)
        If bSnap Then
            mousePT = Snap(e.x, e.y)
        Else
            mousePT = New Point(e.x, e.y)
        End If
        'Dim dragPoint As PointF = gscTogoc(e.x, e.y)

        If Not IsNothing(fCacKyHieu) Then
            'If (m_Map.MousePointer = MapXLib.CursorConstants.miCrossCursor) Then
            If myMapTool = MapTools.DangLayKH Then
                If e.button = 1 Then
                    PopUndo()
                    m_ParentForm.ToolStripStatusLabel3.Text &= ". Shift=" & e.shift.ToString
                    'Dim mTyLe As Single = 1
                    'Try
                    'mTyLe = CSng(fCacKyHieu.txtTyLe.Text)
                    'Catch ex As Exception
                    'End Try
                    'AddFromVeKH(fCacKyHieu.OdrawingObjects, fCacKyHieu.myORootX, fCacKyHieu.myORootY, mTyLe, New PointF(e.x, e.y))
                    AddFromVeKH()
                    NhanKHXong()
                    'fCacKyHieu.Visible = True
                End If
            End If
        End If

        If e.button = 1 Then 'MouseButtons.left
            If m_SelectedSymbols.Count > 0 Then
                If myMapTool = MapTools.GrDangMove Then
                    OnCapNhatKH()
                    m_SelectedSymbols.Clear()
                End If
            End If

            If Not m_SelectedSymbol Is Nothing Then
                If myMapTool = MapTools.DangMove Then
                    OnCapNhatKH()
                    'm_SelectedSymbol = Nothing
                ElseIf myMapTool = MapTools.DangRotate Then
                    OnCapNhatKH()
                    'm_SelectedSymbol = Nothing
                ElseIf myMapTool = MapTools.DangScale Then
                    OnCapNhatKH()
                ElseIf myMapTool = MapTools.DangSplit Then
                    Dim mSPLITSYMBOLS As SPLITSYMBOLS = To2Symbols(m_SelectedSymbol, myfromPt, mytoPt)
                    m_DrawingSymbols.Remove(m_SelectedSymbol)
                    If Not IsNothing(mSPLITSYMBOLS.Symbol1) Then
                        m_DrawingSymbols.Add(mSPLITSYMBOLS.Symbol1)
                        m_SelectedSymbol = mSPLITSYMBOLS.Symbol1
                    End If
                    If Not IsNothing(mSPLITSYMBOLS.Symbol2) Then
                        m_DrawingSymbols.Add(mSPLITSYMBOLS.Symbol2)
                        m_SelectedSymbol = mSPLITSYMBOLS.Symbol2
                    End If
                    OnCapNhatKH()
                End If
            Else
                'If (myMapTool = MapTools.NodesEdit) AndAlso (iEditNode >= 0) Then
                'EditObj.Reset()
                'iEditNode = -1
                'End If
            End If

            If selectionDragging Then
                selectionDragging = False
                'Dim mSymbol As CSymbol
                'm_SelectedSymbols.Clear()
                If Not m_SelectedSymbol Is Nothing Then
                    m_SelectedSymbols.Add(m_SelectedSymbol)
                    m_SelectedSymbol = Nothing
                    For Each mSymbol As CSymbol In Me.drawingSymbols
                        If mSymbol.HitTest(m_Map, selectionRect) Then
                            'Me.SelectedObject = graphicObj
                            'Exit For
                            If Not mSymbol Is m_SelectedSymbols(0) Then
                                m_SelectedSymbols.Add(mSymbol)
                            End If
                        End If
                    Next
                Else
                    For Each mSymbol As CSymbol In Me.drawingSymbols
                        If mSymbol.HitTest(m_Map, selectionRect) Then
                            m_SelectedSymbols.Add(mSymbol)
                        End If
                    Next
                End If


                'selectionDragging = False
                m_Map.CenterX = m_Map.CenterX
                If m_SelectedSymbols.Count > 1 Then
                    'For Each mSymbol In m_SelectedSymbols
                    'mSymbol.VeBound(m_Map, m_Map.CreateGraphics, Color.Black)
                    'Next

                    'If MessageBox.Show(m_ParentForm, "Nhom thanh 1 Ky Hieu?", "Nhom", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    'NhomSymbols(m_SelectedSymbols)
                    'End If
                    'CxtMnuKyHieu.Show(m_Panel, New Point(e.x, e.y))
                    'm_SelectedSymbols.Clear()
                    'm_Map.CenterX = m_Map.CenterX
                End If
            End If

            If DrawingDragging Then
                DrawingDragging = False
                m_Map.CenterX = m_Map.CenterX
            End If

            If NodeDragging Then
                NodeDragging = False
                m_Map.CenterX = m_Map.CenterX
            End If

            If RootDragging Then
                RootDragging = False
                m_Map.CenterX = m_Map.CenterX
            End If

            Select Case myMapTool
                Case MapTools.Cycle, MapTools.Rectangle, MapTools.arc
                    DrawingPicking = False
                    AddNewObj(e.shift)
                    'myMapTool = MapTools.ChonKH
                    'UpdateTB("UpdateKH")
                    OnCapNhatKH()
            End Select
        Else

        End If

        'm_SelectedSymbols.Clear()
    End Sub

    Public Sub OnUndoClick()
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        Try
            'StopBlinking()
            Dim mUndoItem As UNDOITEM = PushUndo()
            If Not IsNothing(mUndoItem) Then
                m_DrawingSymbols = mUndoItem.UndoSymbols
                m_Map.CenterX = mUndoItem.MapX
                m_Map.CenterY = mUndoItem.MapY
                m_SelectedSymbol = mUndoItem.SeleSymbol
            End If
            'StartBlinking()
        Catch
        End Try

        'E.Button.Pushed = False
        OnCapNhatKH()
    End Sub

    Public Sub OnRedoClick()
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        Try
            'StopBlinking()
            Dim mRedoItem As UNDOITEM = PushRedo()
            If Not IsNothing(mRedoItem) Then
                m_DrawingSymbols = mRedoItem.UndoSymbols
                m_Map.CenterX = mRedoItem.MapX
                m_Map.CenterY = mRedoItem.MapY
                m_SelectedSymbol = mRedoItem.SeleSymbol
            End If
            'StartBlinking()
        Catch
        End Try

        'E.Button.Pushed = False
        OnCapNhatKH()
    End Sub

    Private Sub MnuCopyKH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuCopyKH.Click
        'copyParts = GetCopyParts()
        m_CopySymbol = m_SelectedSymbol '.Clone(m_Map)
        m_CopySymbols.Clear()
        m_CopySymbols.Add(m_CopySymbol)

    End Sub

    Private Sub MnuEditNodes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuEditNodes.Click
        'PopUndo(m_DrawingSymbols)
        OnNodesEdit()
    End Sub

    Private Sub MnuRotate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuRotate.Click
        'OnRotate(sender, e)
        myMapTool = MapTools.Rotate
        m_ParentForm.ToolStripStatusLabel3.Text = "Rotate: di chuột để quay."
    End Sub

    Private Sub MnuChangeRoot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuChangeRoot.Click
        'OnAddLabel(sender, e)
        'PopUndo(m_DrawingSymbols)
        OnChangeRoot()
    End Sub

    Private Sub MnuChangeDesc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuChangeDesc.Click
        'PopUndo()
        OnChangeDesc(sender, e)
    End Sub

    Private Sub MnuDeleteKH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuDeleteKH.Click
        'PopUndo()
        OnXoa()
    End Sub

    Private Sub MnuChangeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuChangeColor.Click
        'PopUndo(m_DrawingSymbols)
        Select Case m_SelectedObject.GetObjType
            Case OBJECTTYPE.Curve, OBJECTTYPE.ClosedCurve, OBJECTTYPE.Cycle, OBJECTTYPE.Line, OBJECTTYPE.Polygon, OBJECTTYPE.Ellipse
                OnChangeColor()
            Case OBJECTTYPE.Text
                OnChangeText()
            Case OBJECTTYPE.Pie
                OnChangePie()
            Case OBJECTTYPE.Table
                OnChangeTable()
        End Select
    End Sub

    Private Sub MnuDeleteShape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuDeleteShape.Click
        PopUndo()
        OnDeleteShape()
    End Sub

    Private Sub MnXoaNode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnXoaNode.Click
        PopUndo()
        OnXoaNode()
    End Sub

    Private Sub MnuAddNode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuAddNode.Click
        PopUndo()
        OnAddNode()
    End Sub

    Private Sub MnuChangeNodeType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuChangeNodeType.Click
        PopUndo()
        OnChangeNodeType()
    End Sub

    Private Sub MnuSendBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuSendBack.Click
        PopUndo()
        m_DrawingSymbols.SendBack(m_SelectedSymbol)
        m_Map.CenterX = m_Map.CenterX
    End Sub


    Private Sub MnuPastKH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuPastKH.Click
        Try
            Dim mSymbol As CSymbol
            Dim mSymbol2 As CSymbol
            Dim mPt0X, mPt0Y, mPtX, mPtY As Single
            Dim i As Integer

            If m_CopySymbols.Count > 0 Then

                PopUndo()

                mSymbol = m_CopySymbols(0)
                m_Map.ConvertCoord(mPt0X, mPt0Y, mSymbol.GocX, mSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                mSymbol2 = PastSymbolAt(mSymbol, New PointF(mousePos.X, mousePos.Y))
                If m_CopySymbols.Count > 1 Then
                    For i = 1 To m_CopySymbols.Count - 1
                        mSymbol = m_CopySymbols(i)
                        m_Map.ConvertCoord(mPtX, mPtY, mSymbol.GocX, mSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                        mSymbol2 = PastSymbolAt(mSymbol, New PointF(mousePos.X - mPt0X + mPtX, mousePos.Y - mPt0Y + mPtY))
                    Next
                End If
                m_ParentForm.PopulateListKH(mSymbol2)
            End If
            m_Map.CenterX = m_Map.CenterX
        Catch
        End Try

    End Sub

    Private Sub m_Map_ToolUsed(ByVal sender As Object, ByVal e As AxMapXLib.CMapXEvents_ToolUsedEvent) Handles m_Map.ToolUsed
        If e.toolNum = myToolInfo Then
            procThongTin(e.x1, e.y1)
        End If
    End Sub

    Public Sub procThongTin(ByVal x1 As Double, ByVal y1 As Double)
        Dim p As MapXLib.Point
        Dim fs As MapXLib.Features
        Dim f As MapXLib.Feature

        'Dim mTenLop As String
        Dim mBD_ID As Long

        Dim lyr As MapXLib.Layer

        p = New MapXLib.Point
        p.Set(x1, y1)

        mBD_ID = 0

        Dim i As Integer
        'For Each lyr In m_Map.Layers
        For i = 2 To m_Map.Layers.Count
            lyr = m_Map.Layers.Item(i)
            'MsgBox("LType: " & lyr.Type.ToString)
            'If lyr.Type = 0 Then
            Try
                If mBD_ID = 0 Then
                    fs = lyr.SearchAtPoint(p)
                    If fs.Count > 0 Then
                        f = fs.Item(1)
                        lyr.Selection.SelectByID(f.FeatureID, MapXLib.SelectionTypeConstants.miSelectionNew)
                        mBD_ID = f.FeatureID
                    End If
                Else
                    lyr.Selection.ClearSelection()
                End If
            Catch ex As Exception

            End Try
            'End If

        Next

        If mBD_ID > 0 Then
            ThongTinKhac(f)
        End If
    End Sub

    Private Sub ThongTinKhac(ByVal pf As MapXLib.Feature)
        Dim rv As MapXLib.RowValue
        Dim rvs As MapXLib.RowValues
        Dim ds As MapXLib.Dataset
        Dim strOutput As String

        Dim lyr As MapXLib.Layer
        lyr = pf.Layer
        Dim i As Integer
        strOutput = ""
        For i = 1 To m_Map.DataSets.Count
            ds = m_Map.DataSets.Item(i)
            If ds.Layer.Name = lyr.Name Then Exit For
        Next

        rvs = ds.RowValues(pf)
        'strOutput = "== Lớp: " & lyr.Name & " ==" & vbCrLf & vbCrLf

        'For Each rv In rvs
        For i = 1 To rvs.Count
            rv = rvs.Item(i)
            Dim mField As MapXLib.Field = rv.Field
            strOutput = strOutput & toUnicode(mField.Name) & ": " & toUnicode(rv.Value) & vbCrLf
        Next

        strOutput = Left(strOutput, Len(strOutput) - 2) ' strip off trailing comma
        'MsgBox(strOutput)
        MessageBox.Show(m_ParentForm, strOutput, "Lớp: " & lyr.Name)

        lyr.Selection.ClearSelection()

    End Sub

    Public Function PastSymbolAt(ByVal pSymbol As CSymbol, ByVal pt1 As PointF) As CSymbol
        Dim mSymbolObj As CSymbol = Nothing
        If Not pSymbol Is Nothing Then
            mSymbolObj = New CSymbol(m_Map, pt1, pSymbol.GObjs, pSymbol.Zoom, pSymbol.MWidth)
            mSymbolObj.Description = pSymbol.Description
            m_DrawingSymbols.Add(mSymbolObj)
        End If
        Return mSymbolObj
    End Function

    Public Sub PastSymbol(ByVal pSymbol As CSymbol)
        If Not pSymbol Is Nothing Then
            'Dim mSymbol As CSymbol = pSymbol.Clone(m_Map)
            Dim mSymbolObj As New CSymbol(pSymbol.Description, pSymbol.Blinking, pSymbol.Zoom, pSymbol.MWidth, pSymbol.GocX, pSymbol.GocY, pSymbol.GObjs)
            mSymbolObj.Description = pSymbol.Description
            m_DrawingSymbols.Add(mSymbolObj)
        End If
    End Sub

    Private Function Snap(ByVal px As Single, ByVal py As Single) As Point
        Return New Point(Round(px / myGridWidth, 0) * myGridWidth, Round(py / myGridWidth, 0) * myGridWidth)
    End Function

    Public Sub OnCapNhatKH()
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        myMapTool = MapTools.ChonKH
        UpdateTB("UpdateKH")
        m_Map.CenterX = m_Map.CenterX

        m_ParentForm.PopulateListKH(m_SelectedSymbol)
    End Sub

    Private Sub m_Map_KeyUpEvent(ByVal sender As Object, ByVal e As AxMapXLib.CMapXEvents_KeyUpEvent) Handles m_Map.KeyUpEvent
        'MsgBox(e.keyCode)83,71, 46
        'If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
        'End If
        'e.shift = 4 

        Select Case e.keyCode
            Case 83 'S
                bSnap = Not bSnap
                If bSnap Then
                    fMain.ToolStripStatusLabel5.Text = "SNAP"
                Else
                    fMain.ToolStripStatusLabel5.Text = ""
                End If
            Case 71 'G
                bGrid = Not bGrid
                m_Map.CenterX = m_Map.CenterX
            Case Keys.Delete '46 'Del
                OnXoa()
            Case Keys.Up
                If Not m_SelectedSymbol Is Nothing Then
                    Select Case e.shift
                        Case 2 'Ctrl
                            m_SelectedSymbol.Shift(m_Map, 0, -1)
                            m_Map.CenterX = m_Map.CenterX
                        Case 4 'Alter
                        Case 6 ' Ctrl + Alter
                            myrootPt = New PointF
                            m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                            m_SelectedSymbol.Scale2(m_Map, myrootPt, 0, 1)
                            m_Map.CenterX = m_Map.CenterX
                    End Select
                End If
            Case Keys.Down
                If Not m_SelectedSymbol Is Nothing Then
                    Select Case e.shift
                        Case 2 'Ctrl
                            m_SelectedSymbol.Shift(m_Map, 0, 1)
                            m_Map.CenterX = m_Map.CenterX
                        Case 4 'Alter
                        Case 6 ' Ctrl + Alter
                            myrootPt = New PointF
                            m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                            m_SelectedSymbol.Scale2(m_Map, myrootPt, 0, -1)
                            m_Map.CenterX = m_Map.CenterX
                    End Select
                End If
            Case Keys.Right
                If Not m_SelectedSymbol Is Nothing Then
                    Select Case e.shift
                        Case 2 'Ctrl
                            m_SelectedSymbol.Shift(m_Map, 1, 0)
                            m_Map.CenterX = m_Map.CenterX
                        Case 4 'Alter
                            myrootPt = New PointF
                            m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                            m_SelectedSymbol.Rotate2(m_Map, myrootPt, myTinhChinhGocQuay)
                            m_Map.CenterX = m_Map.CenterX
                        Case 6 ' Ctrl + Alter
                            myrootPt = New PointF
                            m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                            m_SelectedSymbol.Scale2(m_Map, myrootPt, 1, 0)
                            m_Map.CenterX = m_Map.CenterX
                    End Select
                End If
            Case Keys.Left
                If Not m_SelectedSymbol Is Nothing Then
                    Select Case e.shift
                        Case 2 'Ctrl
                            m_SelectedSymbol.Shift(m_Map, -1, 0)
                            m_Map.CenterX = m_Map.CenterX
                        Case 4 'Alter
                            myrootPt = New PointF
                            m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                            m_SelectedSymbol.Rotate2(m_Map, myrootPt, -myTinhChinhGocQuay)
                            m_Map.CenterX = m_Map.CenterX
                        Case 6 ' Ctrl + Alter
                            myrootPt = New PointF
                            m_Map.ConvertCoord(myrootPt.X, myrootPt.Y, m_SelectedSymbol.GocX, m_SelectedSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                            m_SelectedSymbol.Scale2(m_Map, myrootPt, -1, 0)
                            m_Map.CenterX = m_Map.CenterX
                    End Select
                End If
        End Select

    End Sub

    Private Sub MnuCacLopBD_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If m_Map.Layers.LayersDlg() = True Then
            AddDataSets()
        End If
    End Sub

    Public Sub CacLopBD()
        If m_Map.Layers.LayersDlg() = True Then
            AddDataSets()
        End If
    End Sub

    Private Sub MnuLuuGeoSet_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LuuGeoSet()
    End Sub

    Public Sub UnseleKH()
        m_SelectedSymbol = Nothing
        m_SelectedSymbols.Clear()

        myMapTool = MapTools.None
        UpdateTB("None")

        m_ParentForm.ToolStripStatusLabel3.Text = ""
        'm_Map.CenterX = m_Map.CenterX
        'Dim mButton As ToolBarButton
        'For Each mButton As ToolBarButton In m_ToolBar.Buttons
        'Select Case mButton.Tag
        '    Case "UpdateKH"
        'mButton.Enabled = True
        '    Case "Line", "Polygon", "Curve", "ClosedCurve", _
        '    "Cycle", "Ellipse", "Text", "Table", "Past", _
        '    "AddKH", "FindKH", "MuiTenDon", "MuiTen", "MuiTenHo", "SongSong", "SongSongKin", "DuongKhac"
        'mButton.Enabled = False
        'End Select
        'Next

    End Sub

    Public Sub ResetToolbar()
        myMapTool = MapTools.None
        UpdateTB("None")

        m_ParentForm.ToolStripStatusLabel3.Text = ""
        'For Each mButton As ToolBarButton In m_ToolBar.Buttons
        'Select Case mButton.Tag
        '    Case "UpdateKH", "Line", "Polygon", "Curve", "ClosedCurve", _
        '    "Cycle", "Ellipse", "Text", "Table", "Past", _
        '    "AddKH", "FindKH", "MuiTenDon", "MuiTen", "MuiTenHo", "SongSong", "SongSongKin", "DuongKhac"
        'mButton.Enabled = False
        'End Select
        'Next
    End Sub

    Private Overloads Function gscTogoc(ByVal gsPT As Point) As MAPPOINT
        Dim myNewPoint As New MAPPOINT
        Dim mLon, mLat As Double
        m_Map.ConvertCoord(gsPT.X, gsPT.Y, mLon, mLat, MapXLib.ConversionConstants.miScreenToMap)
        myNewPoint.X = mLon
        myNewPoint.Y = mLat
        Return myNewPoint
    End Function

    Private Overloads Function gscTogoc( _
            ByVal X As Integer, ByVal Y As Integer) As MAPPOINT
        Dim myNewPoint As New MAPPOINT
        Dim mLon, mLat As Double
        m_Map.ConvertCoord(X, Y, mLon, mLat, MapXLib.ConversionConstants.miScreenToMap)
        myNewPoint.X = mLon
        myNewPoint.Y = mLat
        Return myNewPoint
    End Function

    Private Function GetTyLeGObjs(ByVal pGObjs As CGraphicObjs, ByVal pTyle As Single) As CGraphicObjs
        Dim mGObjects As New CGraphicObjs
        Dim i As Integer = -1
        For Each aGObj As GraphicObject In pGObjs
            Dim oGObj As GraphicObject = aGObj.Clone
            Select Case oGObj.GetObjType
                Case OBJECTTYPE.Text
                    Dim mShape As TextGraphic = CType(oGObj, TextGraphic)
                    With mShape
                        .Width *= pTyle
                        .Height *= pTyle
                        .X *= pTyle
                        .Y *= pTyle
                        Dim StringFont As New Font(.Font.Name, .Font.Size * pTyle, .Font.Style, .Font.Unit)
                        .Font = StringFont
                    End With
                Case OBJECTTYPE.EmbeddedImage
                    Dim mShape As EmbeddedImageGraphic = CType(oGObj, EmbeddedImageGraphic)
                    With mShape
                        .Width *= pTyle
                        .Height *= pTyle
                        .X *= pTyle
                        .Y *= pTyle
                    End With
                Case OBJECTTYPE.Table
                Case OBJECTTYPE.Ellipse, OBJECTTYPE.Pie
                    Dim mShape As ShapeGraphic = CType(oGObj, ShapeGraphic)
                    With mShape
                        .Width *= pTyle
                        .Height *= pTyle
                        .X *= pTyle
                        .Y *= pTyle
                    End With
                Case Else
                    Try
                        Dim mShape As NodesShapeGraphic = CType(oGObj, NodesShapeGraphic)
                        With mShape
                            .Width *= pTyle
                            .Height *= pTyle
                            .X *= pTyle
                            .Y *= pTyle
                        End With
                        For Each aNode As CNODE In mShape.Nodes
                            aNode.X *= pTyle
                            aNode.Y *= pTyle
                        Next
                    Catch ex As Exception

                    End Try

            End Select
            'i += 1
            'ReDim Preserve mGObjects(i)
            mGObjects.Add(oGObj)
        Next

        Return mGObjects
    End Function

    Private Sub AddFromVeKH0(ByVal pGObjs0 As CGraphicObjs, ByVal pCX As Integer, ByVal pCY As Integer, _
    ByVal pTyLe As Single, ByVal pPt As PointF)
        'Dim mSymbolObj As CSymbol = GetKHfromVeKH(pGObjs0, pCX, pCY, pTyLe, pPt) 'GetKHfromVeKH(pTyLe, pPt)
        Dim mSymbolObj As CSymbol = m_KHfromVeKH
        m_DrawingSymbols.Add(mSymbolObj)
        'm_DrawingSymbols.Add(mSymbolObj.Clone(m_Map))
        myDaLayKH = True

        m_CopySymbol = mSymbolObj '.Clone(m_Map)
        m_CopySymbols.Clear()
        m_CopySymbols.Add(m_CopySymbol)

        m_Map.CenterX = m_Map.CenterX
        'MsgBox("gocX=" & mSymbolObj.GocX & ", gocY=" & mSymbolObj.GocY & " \ X=" & mRootX & ", Y=" & mRootY)
        'm_ParentForm.lstCacKyHieu.Items.Add(mSymbolObj)
        'm_ParentForm.lstCacKyHieu.SelectedIndex = m_ParentForm.lstCacKyHieu.Items.IndexOf(mSymbolObj)
        m_SelectedSymbol = mSymbolObj

    End Sub

    Private Sub AddFromVeKH()
        Dim mSymbolObj As CSymbol = m_KHfromVeKH
        m_DrawingSymbols.Add(mSymbolObj)
        myDaLayKH = True

        m_CopySymbol = mSymbolObj
        m_CopySymbols.Clear()
        m_CopySymbols.Add(m_CopySymbol)

        m_Map.CenterX = m_Map.CenterX
        m_SelectedSymbol = mSymbolObj
    End Sub

    Private Sub DoiMau(ByVal pGObjs As CGraphicObjs, ByVal pMau As Color)
        'Dim mGObjects As New CGraphicObjs
        'Dim i As Integer = -1
        For Each aGObj As GraphicObject In pGObjs
            'Dim oGObj As GraphicObject = aGObj.Clone
            Select Case aGObj.GetObjType
                Case OBJECTTYPE.Text
                    Dim mShape As TextGraphic = CType(aGObj, TextGraphic)
                    With mShape
                        'If .Color = Color.Red Then
                        .Color = pMau
                        'End If
                    End With
                Case OBJECTTYPE.EmbeddedImage
                Case OBJECTTYPE.Table
                Case OBJECTTYPE.Ellipse, OBJECTTYPE.Pie
                    Dim mShape As ShapeGraphic = CType(aGObj, ShapeGraphic)
                    With mShape
                        'If .LineColor = Color.Red Then
                        .LineColor = pMau
                        'End If
                        'If .FillColor = Color.FromArgb(.FillColor.A, Color.Red) Then
                        .FillColor = Color.FromArgb(.FillColor.A, pMau) 'pMau
                        'End If
                    End With
                Case Else
                    Try
                        Dim mShape As NodesShapeGraphic = CType(aGObj, NodesShapeGraphic)
                        With mShape
                            'If .LineColor = Color.Red Then
                            .LineColor = pMau
                            'End If
                            'If .FillColor = Color.FromArgb(.FillColor.A, Color.Red) Then
                            .FillColor = Color.FromArgb(.FillColor.A, pMau)
                            'End If
                        End With
                    Catch ex As Exception

                    End Try

            End Select
            'i += 1
            'ReDim Preserve mGObjects(i)
            'mGObjects.Add(oGObj)
        Next

        'Return mGObjects
    End Sub

    Private Sub TraoMau(ByVal pGObjs As CGraphicObjs)
        For Each aGObj As GraphicObject In pGObjs
            Select Case aGObj.GetObjType
                Case OBJECTTYPE.Text
                    Dim mShape As TextGraphic = CType(aGObj, TextGraphic)
                    With mShape
                        If .Color = QuanDoColor Then
                            .Color = QuanXanhColor
                        ElseIf .Color = QuanXanhColor Then
                            .Color = QuanDoColor
                        End If
                    End With
                Case OBJECTTYPE.EmbeddedImage
                Case OBJECTTYPE.Table
                Case OBJECTTYPE.Ellipse, OBJECTTYPE.Pie
                    Dim mShape As ShapeGraphic = CType(aGObj, ShapeGraphic)
                    With mShape
                        If .LineColor = QuanDoColor Then
                            .LineColor = QuanXanhColor
                        ElseIf .LineColor = QuanXanhColor Then
                            .LineColor = QuanDoColor
                        End If
                        If .FillColor = Color.FromArgb(.FillColor.A, QuanDoColor) Then
                            .FillColor = Color.FromArgb(.FillColor.A, QuanXanhColor)
                        ElseIf .FillColor = Color.FromArgb(.FillColor.A, QuanXanhColor) Then
                            .FillColor = Color.FromArgb(.FillColor.A, QuanDoColor)
                        End If
                    End With
                Case Else
                    Try
                        Dim mShape As NodesShapeGraphic = CType(aGObj, NodesShapeGraphic)
                        With mShape
                            If .LineColor = QuanDoColor Then
                                .LineColor = QuanXanhColor
                            ElseIf .LineColor = QuanXanhColor Then
                                .LineColor = QuanDoColor
                            End If
                            If .FillColor = Color.FromArgb(.FillColor.A, QuanDoColor) Then
                                .FillColor = Color.FromArgb(.FillColor.A, QuanXanhColor)
                            ElseIf .FillColor = Color.FromArgb(.FillColor.A, QuanXanhColor) Then
                                .FillColor = Color.FromArgb(.FillColor.A, QuanDoColor)
                            End If
                        End With
                    Catch ex As Exception

                    End Try

            End Select
        Next
    End Sub

    Private Function GetKHfromVeKH0(ByVal pGObjs0 As CGraphicObjs, ByVal pCX As Integer, ByVal pCY As Integer, ByVal pTyLe As Single, ByVal pPt As PointF) As CSymbol
        Dim pGObjs As CGraphicObjs = GetTyLeGObjs(pGObjs0, pTyLe)
        If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
            DoiMau(pGObjs, QuanXanhColor)
        End If

        Dim mSymbolObj As New CSymbol(m_Map, pPt, pGObjs, m_Map.Zoom, m_Map.MapScreenWidth)
        mSymbolObj.Description = fCacKyHieu.txtTenKH.Text

        Dim mRec As Rectangle = mSymbolObj.GetBounds(m_Map)
        Dim fromPt As New PointF(pPt.X, pPt.Y)
        Dim toPt As New PointF(pPt.X - pCX * pTyLe, pPt.Y - pCY * pTyLe)

        Dim mRootX, mRootY As Double
        toPt.X = pPt.X + pCX * pTyLe
        toPt.Y = pPt.Y + pCY * pTyLe
        m_Map.ConvertCoord(toPt.X, toPt.Y, mRootX, mRootY, MapXLib.ConversionConstants.miScreenToMap)
        mSymbolObj.ChangeRoot(m_Map, mRootX, mRootY)
        fromPt.X = toPt.X
        fromPt.Y = toPt.Y
        toPt.X = pPt.X
        toPt.Y = pPt.Y
        mSymbolObj.Move(m_Map, fromPt, toPt)

        If m_DrawingSymbols.Count > 0 Then
            mSymbolObj.Zoom = m_DrawingSymbols(0).Zoom
            mSymbolObj.MWidth = m_DrawingSymbols(0).MWidth
        Else
            'myKHQSMWidth *= myTyLeLayKH
            mSymbolObj.Zoom = myKHQSZoom
            mSymbolObj.MWidth = myKHQSMWidth '* myTyLeLayKH
        End If

        Return mSymbolObj
    End Function

    Private Function GetKHfromVeKH(ByVal pPt As PointF) As CSymbol
        Dim mTyLe As Single = 1
        Try
            mTyLe = CSng(fCacKyHieu.txtTyLe.Text)
        Catch ex As Exception
        End Try

        Dim pGObjs As CGraphicObjs = GetTyLeGObjs(fCacKyHieu.OdrawingObjects, mTyLe)
        If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
            DoiMau(pGObjs, QuanXanhColor)
        End If

        Dim mSymbolObj As New CSymbol(m_Map, pPt, pGObjs, m_Map.Zoom, m_Map.MapScreenWidth)
        mSymbolObj.Description = fCacKyHieu.txtTenKH.Text

        Dim mRec As Rectangle = mSymbolObj.GetBounds(m_Map)
        Dim fromPt As New PointF(pPt.X, pPt.Y)
        Dim toPt As New PointF(pPt.X - fCacKyHieu.myORootX * mTyLe, pPt.Y - fCacKyHieu.myORootY * mTyLe)

        Dim mRootX, mRootY As Double
        toPt.X = pPt.X + fCacKyHieu.myORootX * mTyLe
        toPt.Y = pPt.Y + fCacKyHieu.myORootY * mTyLe
        m_Map.ConvertCoord(toPt.X, toPt.Y, mRootX, mRootY, MapXLib.ConversionConstants.miScreenToMap)
        mSymbolObj.ChangeRoot(m_Map, mRootX, mRootY)
        fromPt.X = toPt.X
        fromPt.Y = toPt.Y
        toPt.X = pPt.X
        toPt.Y = pPt.Y
        mSymbolObj.Move(m_Map, fromPt, toPt)

        If m_DrawingSymbols.Count > 0 Then
            mSymbolObj.Zoom = m_DrawingSymbols(0).Zoom
            mSymbolObj.MWidth = m_DrawingSymbols(0).MWidth
        Else
            'myKHQSMWidth *= myTyLeLayKH
            mSymbolObj.Zoom = myKHQSZoom
            mSymbolObj.MWidth = myKHQSMWidth '* myTyLeLayKH
        End If

        Return mSymbolObj
    End Function

    Public Sub ChuanBiNhanKH()
        myMapCurrTool = m_Map.CurrentTool
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        'm_Map.MousePointer = MapXLib.CursorConstants.miCrossCursor
        m_ParentForm.ToolStripStatusLabel3.Text = "Click vào bản đồ để vẽ KH."

        m_KHfromVeKH = Nothing
        myMapTool = MapTools.DangLayKH
    End Sub

    Public Sub NhanKHXong()
        m_Map.MousePointer = MapXLib.CursorConstants.miDefaultCursor
        m_ParentForm.ToolStripStatusLabel3.Text = ""
        Try
            m_Map.CurrentTool = myMapCurrTool
        Catch ex As Exception
            m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        End Try
        m_KHfromVeKH = Nothing

        OnCapNhatKH()

    End Sub

    Private Sub AddNewObj(ByVal pShift As Short)
        Dim gObjs() As GraphicObject

        Dim mPt0 As New PointF
        Dim i As Integer

        Select Case myMapTool
            Case MapTools.Curve
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 1)
                If myPts2.GetUpperBound(0) > 0 Then
                    Dim gp As New Drawing2D.GraphicsPath
                    gp.AddCurve(myPts2)
                    Dim rf As RectangleF = gp.GetBounds
                    mPt0.X = (rf.Left + rf.Right) / 2
                    mPt0.Y = (rf.Top + rf.Bottom) / 2
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next
                    If defaMyLineStyle = 0 Then
                        Dim myCurve As New CurveGraphic(myPts2, 1, Color.Red)
                        myCurve.Rotation = 0
                        myCurve.LineWidth = defaGenPen1W
                        myCurve.LineColor = defaGenPen1C
                        myCurve.Line2Width = defaGenPen2W
                        myCurve.Line2Color = defaGenPen2C
                        'myCurve.Fill = defaGenFill
                        myCurve.FillColor = defaGenFillC
                        myCurve.LineStyle = defaGenLineStyle
                        myCurve.StyleWidth = 8
                        'gObj = myCurve
                        ReDim gObjs(0)
                        gObjs(0) = myCurve
                    Else
                        gObjs = MyOtherLineStyle.GetGraphicObjs(defaMyLineStyle, myPts2)
                        'If Not (pShift = 2) Then
                        'ChangeAccordingToOption(gObjs)
                        'End If
                    End If
                End If
            Case MapTools.ClosedCurve
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 1)
                If myPts2.GetUpperBound(0) > 1 Then
                    Dim gp As New Drawing2D.GraphicsPath
                    gp.AddClosedCurve(myPts2)
                    Dim rf As RectangleF = gp.GetBounds
                    mPt0.X = (rf.Left + rf.Right) / 2
                    mPt0.Y = (rf.Top + rf.Bottom) / 2
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next

                    Dim myClosedCurve As New ClosedCurveGraphic(myPts2, 1, Color.Red)
                    myClosedCurve.Rotation = 0
                    myClosedCurve.LineWidth = defaGenPen1W
                    myClosedCurve.LineColor = defaGenPen1C
                    myClosedCurve.Line2Width = defaGenPen2W
                    myClosedCurve.Line2Color = defaGenPen2C
                    myClosedCurve.Fill = defaGenFill
                    myClosedCurve.FillColor = defaGenFillC
                    myClosedCurve.LineStyle = defaGenLineStyle

                    'gObj = myClosedCurve
                    ReDim gObjs(0)
                    gObjs(0) = myClosedCurve

                End If
            Case MapTools.Polygon
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 1)
                If myPts2.GetUpperBound(0) > 1 Then
                    Dim gp As New Drawing2D.GraphicsPath
                    gp.AddPolygon(myPts2)
                    Dim rf As RectangleF = gp.GetBounds
                    mPt0.X = (rf.Left + rf.Right) / 2
                    mPt0.Y = (rf.Top + rf.Bottom) / 2
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next

                    Dim myPolygon As New PolygonGraphic(myPts2, 1, Color.Red)
                    myPolygon.Rotation = 0
                    myPolygon.LineWidth = defaGenPen1W
                    myPolygon.LineColor = defaGenPen1C
                    myPolygon.Line2Width = defaGenPen2W
                    myPolygon.Line2Color = defaGenPen2C
                    myPolygon.Fill = defaGenFill
                    myPolygon.FillColor = defaGenFillC
                    myPolygon.LineStyle = defaGenLineStyle

                    'gObj = myPolygon
                    ReDim gObjs(0)
                    gObjs(0) = myPolygon

                End If
            Case MapTools.Line
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 1)
                If myPts2.GetUpperBound(0) > 0 Then
                    Dim gp As New Drawing2D.GraphicsPath
                    gp.AddLines(myPts2)
                    Dim rf As RectangleF = gp.GetBounds
                    mPt0.X = (rf.Left + rf.Right) / 2
                    mPt0.Y = (rf.Top + rf.Bottom) / 2
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next

                    Dim myLine As New LinesGraphic(myPts2, 1, Color.Red)
                    myLine.Rotation = 0
                    myLine.LineWidth = defaGenPen1W
                    myLine.LineColor = defaGenPen1C
                    myLine.Line2Width = defaGenPen2W
                    myLine.Line2Color = defaGenPen2C
                    'myLine.Fill = defaGenFill
                    myLine.FillColor = defaGenFillC
                    myLine.LineStyle = defaGenLineStyle

                    'gObj = myLine
                    ReDim gObjs(0)
                    gObjs(0) = myLine

                End If
            Case MapTools.SongSong
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 1)
                'XemGoc(mypts2)
                If myPts2.GetUpperBound(0) > 0 Then
                    Dim gp As New Drawing2D.GraphicsPath
                    gp.AddCurve(myPts2)
                    Dim rf As RectangleF = gp.GetBounds
                    mPt0.X = (rf.Left + rf.Right) / 2
                    mPt0.Y = (rf.Top + rf.Bottom) / 2
                    'mPt0.X = myPts2(0).X
                    'mPt0.Y = myPts2(0).Y
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next

                    gObjs = COtherLineStyle.GetSongSong(myPts2, defaSongSongSize, defaSongSongLinesNo)
                    For j As Integer = 0 To gObjs.GetUpperBound(0)
                        Dim myCurve As New CurveGraphic(myPts2, 1, Color.Red)
                        myCurve.LineWidth = defaSongSongPen1W
                        myCurve.LineColor = defaSongSongPen1C
                        myCurve.Line2Width = defaSongSongPen2W
                        myCurve.Line2Color = defaSongSongPen2C
                        myCurve.LineStyle = defaSongSongLineStyle
                        myCurve.Rotation = 0
                    Next

                End If
            Case MapTools.SongSongKin
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 1)
                If myPts2.GetUpperBound(0) > 1 Then
                    Dim gp As New Drawing2D.GraphicsPath
                    gp.AddClosedCurve(myPts2)
                    Dim rf As RectangleF = gp.GetBounds
                    mPt0.X = (rf.Left + rf.Right) / 2
                    mPt0.Y = (rf.Top + rf.Bottom) / 2
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next

                    gObjs = COtherLineStyle.GetSongSongKin(myPts2, defaSongSongSize, defaSongSongLinesNo)
                    For j As Integer = 0 To gObjs.GetUpperBound(0)
                        Dim myClosedCurve As ClosedCurveGraphic = gObjs(j)
                        myClosedCurve.LineWidth = defaSongSongPen1W
                        myClosedCurve.LineColor = defaSongSongPen1C
                        myClosedCurve.Line2Width = defaSongSongPen2W
                        myClosedCurve.Line2Color = defaSongSongPen2C
                        myClosedCurve.LineStyle = defaSongSongLineStyle
                        myClosedCurve.Rotation = 0
                    Next

                End If

            Case MapTools.MuiTen
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 16)
                If myPts2.GetUpperBound(0) > 0 Then
                    mPt0.X = myPts2(myPts2.GetUpperBound(0)).X
                    mPt0.Y = myPts2(myPts2.GetUpperBound(0)).Y
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next

                    'gObjs = MyOtherLineStyle.GetMuiTen(mypts2, defaMuiTenDoRong)
                    gObjs = COtherLineStyle.GetMuiTen(myPts2, myMuiTenDoRong)

                    Dim myCurve As ClosedCurveGraphic = gObjs(0)
                    myCurve.LineWidth = defaMuiTenPen1W
                    myCurve.LineColor = defaMuiTenPen1C
                    myCurve.Line2Width = defaMuiTenPen2W
                    myCurve.Line2Color = defaMuiTenPen2C
                    myCurve.Fill = defaMuiTenFill
                    myCurve.FillColor = defaMuiTenFillC

                    myCurve.Rotation = 0
                End If
            Case MapTools.MuiTenHo
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 16)
                If myPts2.GetUpperBound(0) > 0 Then
                    'mPt0.X = myPts2(0).X
                    'mPt0.Y = myPts2(0).Y
                    mPt0.X = myPts2(myPts2.GetUpperBound(0)).X
                    mPt0.Y = myPts2(myPts2.GetUpperBound(0)).Y
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next

                    'gObjs = MyOtherLineStyle.GetMuiTenHo(mypts2, defaMuiTenDoRong)
                    gObjs = COtherLineStyle.GetMuiTenHo(myPts2, myMuiTenDoRong)

                    Dim myCurve As CurveGraphic = gObjs(0)
                    myCurve.LineWidth = defaMuiTenPen1W
                    myCurve.LineColor = defaMuiTenPen1C
                    myCurve.Line2Width = defaMuiTenPen2W
                    myCurve.Line2Color = defaMuiTenPen2C
                    myCurve.Fill = defaMuiTenFill
                    myCurve.FillColor = defaMuiTenFillC

                    myCurve.Rotation = 0
                End If
            Case MapTools.MuiTenDac
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 16)
                If myPts2.GetUpperBound(0) > 0 Then
                    mPt0.X = myPts2(myPts2.GetUpperBound(0)).X
                    mPt0.Y = myPts2(myPts2.GetUpperBound(0)).Y
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next

                    'gObjs = COtherLineStyle.GetMuiTenDac(myPts2, defaMuiTenDacDoRong, defaMuiTenDacDoDai)
                    gObjs = COtherLineStyle.GetMuiTenDac(myPts2, defaMuiTenDacDoRong * myZoom / m_Map.Zoom, defaMuiTenDacDoDai * myZoom / m_Map.Zoom)

                    Dim myCurve As CurveGraphic = gObjs(0)
                    myCurve.LineWidth = defaMuiTenDacPen1W
                    myCurve.LineColor = defaMuiTenDacPen1C
                    myCurve.Line2Width = defaMuiTenDacPen2W
                    myCurve.Line2Color = defaMuiTenDacPen2C
                    myCurve.Fill = defaMuiTenDacFill
                    myCurve.FillColor = defaMuiTenDacFillC

                    myCurve.Rotation = 0
                End If
            Case MapTools.MuiTenDon
                Dim myPts2() As PointF = COtherLineStyle.GetNormalPts(myPts, 1)
                If myPts2.GetUpperBound(0) > 0 Then
                    Dim gp As New Drawing2D.GraphicsPath
                    gp.AddCurve(myPts2)
                    mPt0.X = myPts2(myPts2.GetUpperBound(0)).X
                    mPt0.Y = myPts2(myPts2.GetUpperBound(0)).Y
                    For i = 0 To myPts2.GetUpperBound(0)
                        myPts2(i).X -= mPt0.X
                        myPts2(i).Y -= mPt0.Y
                    Next

                    'gObjs = COtherLineStyle.GetMuiTenDon(myPts2, defaGenPen1W * 1.5)
                    gObjs = COtherLineStyle.GetMuiTenDon(myPts2, defaGenPen1W * 1.5 * myZoom / m_Map.Zoom)

                    Dim myCurve As CurveGraphic = gObjs(0)
                    myCurve.Rotation = 0
                    myCurve.LineWidth = defaGenPen1W
                    myCurve.LineColor = defaMuiTenPen1C
                    myCurve.Line2Width = defaGenPen2W
                    myCurve.Line2Color = defaGenPen2C
                    myCurve.LineStyle = defaGenLineStyle

                    Dim myPolygon As PolygonGraphic = gObjs(1)
                    myPolygon.Rotation = 0
                    myPolygon.LineWidth = defaGenPen1W
                    myPolygon.LineColor = defaMuiTenPen1C
                    'myPolygon.Line2Width = defaGenPen2W
                    'myPolygon.Line2Color = defaGenPen2C
                    myPolygon.Fill = True 'defaGenFill
                    myPolygon.FillColor = defaMuiTenPen1C
                    myPolygon.LineStyle = defaGenLineStyle

                End If
            Case MapTools.Cycle
                mPt0.X = (DrawingRect.Left + DrawingRect.Right) / 2
                mPt0.Y = (DrawingRect.Top + DrawingRect.Bottom) / 2
                Dim myPts2(1) As PointF
                myPts2(0).X = mPt0.X - Math.Abs(DrawingRect.Width / 2)
                myPts2(0).Y = mPt0.Y - Math.Abs(DrawingRect.Height / 2)
                myPts2(1).X = mPt0.X + Math.Abs(DrawingRect.Width / 2)
                myPts2(1).Y = mPt0.Y + Math.Abs(DrawingRect.Height / 2)

                For i = 0 To myPts2.GetUpperBound(0)
                    myPts2(i).X -= mPt0.X
                    myPts2(i).Y -= mPt0.Y
                Next

                Dim myEllipse As New EllipseGraphic( _
                myPts2(0).X, _
                myPts2(0).Y, _
                myPts2(1).X - myPts2(0).X, _
                myPts2(1).Y - myPts2(0).Y, 0)

                myEllipse.LineWidth = defaGenPen1W
                myEllipse.LineColor = defaGenPen1C
                myEllipse.Line2Width = defaGenPen2W
                myEllipse.Line2Color = defaGenPen2C
                myEllipse.Fill = defaGenFill
                myEllipse.FillColor = defaGenFillC
                myEllipse.LineStyle = defaGenLineStyle

                'gObj = myEllipse
                ReDim gObjs(0)
                gObjs(0) = myEllipse

            Case MapTools.Rectangle
                Dim myPts2(3) As PointF
                myPts2(0).X = DrawingRect.X
                myPts2(0).Y = DrawingRect.Y
                myPts2(1).X = DrawingRect.X + DrawingRect.Width
                myPts2(1).Y = DrawingRect.Y
                myPts2(2).X = DrawingRect.X + DrawingRect.Width
                myPts2(2).Y = DrawingRect.Y + DrawingRect.Height
                myPts2(3).X = DrawingRect.X
                myPts2(3).Y = DrawingRect.Y + DrawingRect.Height

                Dim gp As New Drawing2D.GraphicsPath
                gp.AddCurve(myPts2)
                Dim rf As RectangleF = gp.GetBounds
                mPt0.X = (rf.Left + rf.Right) / 2
                mPt0.Y = (rf.Top + rf.Bottom) / 2
                For i = 0 To myPts2.GetUpperBound(0)
                    myPts2(i).X -= mPt0.X
                    myPts2(i).Y -= mPt0.Y
                Next
                'For i = 0 To myPts2.GetUpperBound(0)
                'myPts2(i).X /= m_Surface.Zoom
                'myPts2(i).Y /= m_Surface.Zoom
                'Next
                Dim myCurve As NodesShapeGraphic  'GraphicObject
                myCurve = New PolygonGraphic(myPts2, 1, Color.Red)
                myCurve.Fill = False  'defaGenFill
                myCurve.FillColor = defaGenFillC
                myCurve.Rotation = 0
                myCurve.LineWidth = defaGenPen1W
                myCurve.LineColor = defaGenPen1C
                myCurve.Line2Width = defaGenPen2W
                myCurve.Line2Color = defaGenPen2C
                myCurve.LineStyle = defaGenLineStyle
                myCurve.StyleWidth = 8
                'gObj = myCurve
                ReDim gObjs(0)
                gObjs(0) = myCurve

            Case MapTools.arc
                Dim myPts2(3) As PointF
                myPts2(1).X = DrawingRect.X
                myPts2(1).Y = DrawingRect.Y
                myPts2(2).X = DrawingRect.X + DrawingRect.Width
                myPts2(2).Y = DrawingRect.Y
                myPts2(3).X = DrawingRect.X + DrawingRect.Width
                myPts2(3).Y = DrawingRect.Y + DrawingRect.Height
                myPts2(0).X = DrawingRect.X
                myPts2(0).Y = DrawingRect.Y + DrawingRect.Height

                Dim gp As New Drawing2D.GraphicsPath
                gp.AddCurve(myPts2)
                Dim rf As RectangleF = gp.GetBounds
                mPt0.X = (rf.Left + rf.Right) / 2
                mPt0.Y = (rf.Top + rf.Bottom) / 2
                For i = 0 To myPts2.GetUpperBound(0)
                    myPts2(i).X -= mPt0.X
                    myPts2(i).Y -= mPt0.Y
                Next
                'For i = 0 To myPts2.GetUpperBound(0)
                'myPts2(i).X /= m_Surface.Zoom
                'myPts2(i).Y /= m_Surface.Zoom
                'Next
                Dim myCurve As NodesShapeGraphic  'GraphicObject
                myCurve = New LinesGraphic(myPts2, 1, Color.Red)
                myCurve.Fill = False  'defaGenFill
                myCurve.FillColor = defaGenFillC
                myCurve.Rotation = 0
                myCurve.LineWidth = defaGenPen1W
                myCurve.LineColor = defaGenPen1C
                myCurve.Line2Width = defaGenPen2W
                myCurve.Line2Color = defaGenPen2C
                myCurve.LineStyle = defaGenLineStyle
                myCurve.StyleWidth = 8
                'gObj = myCurve
                myCurve.Nodes(1).IsControl = True
                myCurve.Nodes(2).IsControl = True
                ReDim gObjs(0)
                gObjs(0) = myCurve
            Case MapTools.Text
                mPt0.X = myPts(0).X
                mPt0.Y = myPts(0).Y
                Dim myTextObject As New TextGraphic(myPts(0).X - mPt0.X, _
                                            myPts(0).Y - mPt0.Y, _
                                            "", _
                                            defaTextFont, _
                                            defaTextC)

                myTextObject.Rotation = 0

                myTextObject.Rotation = 0
                myTextObject.AutoSize = True
                ReDim gObjs(0)
                gObjs(0) = myTextObject

            Case MapTools.Table
                mPt0.X = myPts(0).X
                mPt0.Y = myPts(0).Y
                Dim mySize As SizeF = m_Map.CreateGraphics.MeasureString("TEXT", defaTableTFont)
                Dim mW As Integer = CInt(mySize.Width * 10 / 4)
                Dim mH As Integer = CInt(mySize.Height) + 2

                Dim myTableObject As New TableGraphic(myPts(0).X - mPt0.X, myPts(0).Y - mPt0.Y, defaTableColsNo * mW, defaTableRowsNo * mH, defaTableColsNo, defaTableRowsNo, defaTableFillC)

                ReDim gObjs(0)
                gObjs(0) = myTableObject
                gObjs(0).Rotation = 0
                gObjs(0).AutoSize = True
        End Select

        If gObjs.GetUpperBound(0) > -1 Then
            Dim mGObjs As New CGraphicObjs
            For Each gObj As GraphicObject In gObjs
                mGObjs.Add(gObj)
            Next
            If (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                TraoMau(mGObjs)
            End If

            PopUndo()

            Dim mSymbolObj As New CSymbol(m_Map, mPt0, mGObjs)

            If m_DrawingSymbols.Count > 0 Then
                Dim mFstSymbolZoom As Long = m_DrawingSymbols(0).Zoom
                Dim mFstSymbolMWidth As Long = m_DrawingSymbols(0).MWidth
                If (m_Map.Zoom <> mFstSymbolZoom) Or (m_Map.MapScreenWidth <> mFstSymbolMWidth) Then
                    mSymbolObj.ChangeZoomMWidtht(mFstSymbolZoom, mFstSymbolMWidth)
                End If
            Else
                If (m_Map.Zoom <> myKHQSZoom) Or (m_Map.MapScreenWidth <> (myKHQSMWidth)) Then
                    mSymbolObj.ChangeZoomMWidtht(myKHQSZoom, (myKHQSMWidth))
                End If
            End If

            mSymbolObj.Description = "Ký hiệu mới"
            m_DrawingSymbols.Add(mSymbolObj)
            m_Map.CenterX = m_Map.CenterX

            'm_ParentForm.lstCacKyHieu.Items.Add(mSymbolObj)
            'm_ParentForm.lstCacKyHieu.SelectedIndex = m_ParentForm.lstCacKyHieu.Items.IndexOf(mSymbolObj)
            'm_ParentForm.PopulateListKH(mSymbolObj)

            m_SelectedSymbol = mSymbolObj
            m_ParentForm.ToolStripStatusLabel3.Text = ""
        End If
    End Sub

    Private Sub TraoMau0(ByVal pGObjs As CGraphicObjs)
        Try
            For Each aGObj As GraphicObject In pGObjs
                Select Case aGObj.GetObjType
                    Case OBJECTTYPE.Text
                        Dim mShape As TextGraphic = CType(aGObj, TextGraphic)
                        With mShape
                            If .Color = Color.Red Then
                                .Color = Color.Blue
                            ElseIf .Color = Color.Blue Then
                                .Color = Color.Red
                            End If
                        End With
                    Case OBJECTTYPE.EmbeddedImage
                    Case OBJECTTYPE.Table
                    Case OBJECTTYPE.Ellipse, OBJECTTYPE.Pie
                        Dim mShape As ShapeGraphic = CType(aGObj, ShapeGraphic)
                        With mShape
                            If .LineColor = Color.Red Then
                                .LineColor = Color.Blue
                            ElseIf .LineColor = Color.Blue Then
                                .LineColor = Color.Red
                            End If
                            If .FillColor = Color.FromArgb(.FillColor.A, Color.Red) Then
                                .FillColor = Color.FromArgb(.FillColor.A, Color.Blue)
                            ElseIf .FillColor = Color.FromArgb(.FillColor.A, Color.Blue) Then
                                .FillColor = Color.FromArgb(.FillColor.A, Color.Red)
                            End If
                        End With
                    Case Else
                        Try
                            Dim mShape As NodesShapeGraphic = CType(aGObj, NodesShapeGraphic)
                            With mShape
                                If .LineColor = Color.Red Then
                                    .LineColor = Color.Blue
                                ElseIf .LineColor = Color.Blue Then
                                    .LineColor = Color.Red
                                End If
                                If .FillColor = Color.FromArgb(.FillColor.A, Color.Red) Then
                                    .FillColor = Color.FromArgb(.FillColor.A, Color.Blue)
                                ElseIf .FillColor = Color.FromArgb(.FillColor.A, Color.Blue) Then
                                    .FillColor = Color.FromArgb(.FillColor.A, Color.Red)
                                End If
                            End With
                        Catch ex As Exception

                        End Try

                End Select
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Function TachObject(ByVal pFObj As CFOUNDOBJECT) As CSymbol
        Dim KQ As CSymbol = Nothing
        If Not pFObj Is Nothing Then
            'If FoundObject.FoundSymbol.GObjs.Count > 1 Then
            If pFObj.FoundSymbol.GObjs.Count > 1 Then
                Dim mObj As GraphicObject = pFObj.FoundObject.Clone
                Dim mPt0 As New PointF
                m_Map.ConvertCoord(mPt0.X, mPt0.Y, pFObj.FoundSymbol.GocX, pFObj.FoundSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                Dim mGObjs As New CGraphicObjs
                mGObjs.Add(mObj)
                Dim mSymbolObj As New CSymbol(m_Map, mPt0, mGObjs, pFObj.FoundSymbol.Zoom, pFObj.FoundSymbol.MWidth)

                Dim mGocX, mGocY As Double
                Dim mRect As Rectangle = mSymbolObj.GetBounds(m_Map)
                m_Map.ConvertCoord((mRect.Left + mRect.Right) / 2, (mRect.Top + mRect.Bottom) / 2, mGocX, mGocY, MapXLib.ConversionConstants.miScreenToMap)
                mSymbolObj.ChangeRoot(m_Map, mGocX, mGocY)

                mSymbolObj.Description = pFObj.FoundSymbol.Description
                m_DrawingSymbols.Add(mSymbolObj)
                KQ = mSymbolObj
                pFObj.FoundSymbol.GObjs.Remove(pFObj.FoundObject)
                'm_Map.CenterX = m_Map.CenterX
            End If
        End If
        Return KQ
    End Function

    Private Sub TachAllObject(ByVal pSymbol As CSymbol)
        Dim KQ As Boolean = False
        If Not pSymbol Is Nothing Then
            Try
                If pSymbol.GObjs.Count > 1 Then
                    For Each mObj As GraphicObject In pSymbol.GObjs
                        Dim mPt0 As New PointF
                        m_Map.ConvertCoord(mPt0.X, mPt0.Y, pSymbol.GocX, pSymbol.GocY, MapXLib.ConversionConstants.miMapToScreen)
                        Dim mGObjs As New CGraphicObjs
                        mGObjs.Add(mObj)
                        Dim mSymbolObj As New CSymbol(m_Map, mPt0, mGObjs, pSymbol.Zoom, pSymbol.MWidth)

                        Dim mGocX, mGocY As Double
                        Dim mRect As Rectangle = mSymbolObj.GetBounds(m_Map)
                        m_Map.ConvertCoord((mRect.Left + mRect.Right) / 2, (mRect.Top + mRect.Bottom) / 2, mGocX, mGocY, MapXLib.ConversionConstants.miScreenToMap)
                        mSymbolObj.ChangeRoot(m_Map, mGocX, mGocY)

                        mSymbolObj.Description = pSymbol.Description
                        m_DrawingSymbols.Add(mSymbolObj)
                    Next
                    KQ = True
                End If
            Catch ex As Exception

            End Try
            If KQ Then
                m_DrawingSymbols.Remove(pSymbol)
                'm_Map.CenterX = m_Map.CenterX
            End If
        End If
    End Sub

    Private Sub NhomSymbols(ByVal SelectedSymbols As CSymbols)
        If SelectedSymbols.Count > 1 Then
            'Dim gObj As GraphicObject
            'Dim mGocX, mGocY As Double
            Dim i As Integer

            Dim mGObjs As New CGraphicObjs
            Dim mSymbol As CSymbol = SelectedSymbols(0)
            'mGocX = mSymbol.GocX
            'mGocY = mSymbol.GocY
            For i = 1 To SelectedSymbols.Count - 1
                SelectedSymbols(i).ChangeZoomMWidtht(mSymbol.Zoom, mSymbol.MWidth)
                SelectedSymbols(i).ChangeRoot(m_Map, mSymbol.GocX, mSymbol.GocY)
                For Each gObj As GraphicObject In SelectedSymbols(i).GObjs
                    mSymbol.GObjs.Add(gObj)
                Next
                m_DrawingSymbols.Remove(SelectedSymbols(i))
            Next
        End If
    End Sub

    Private Sub CopySymbols(ByVal SelectedSymbols As CSymbols)
        If SelectedSymbols.Count > 0 Then
            m_CopySymbols.Clear()
            'Dim mSymbol As CSymbol
            For Each mSymbol As CSymbol In SelectedSymbols
                'm_CopySymbols.Add(mSymbol.Clone(m_Map))
                m_CopySymbols.Add(mSymbol)
            Next
        End If
    End Sub

    Private Sub CutSymbols(ByVal SelectedSymbols As CSymbols)
        If SelectedSymbols.Count > 0 Then
            m_CopySymbols.Clear()
            Dim mSymbol As CSymbol
            For Each mSymbol In SelectedSymbols
                'm_CopySymbols.Add(mSymbol.Clone(m_Map))
                m_CopySymbols.Add(mSymbol)
                m_DrawingSymbols.Remove(mSymbol)
            Next
        End If
    End Sub

    Public Sub OnDrawObj(ByVal pType As String)
        m_SelectedSymbol = Nothing
        m_SelectedObject = Nothing
        'm_Surface.SurfaceTool = SurfaceCtrl.enumSurfaceTool.None   'CMap.enumMapTool.SymbolsUpdate
        'm_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
        Select Case pType
            Case "Line"
                myMapTool = MapTools.Line
            Case "Polygon"
                myMapTool = MapTools.Polygon
            Case "Curve"
                myMapTool = MapTools.Curve
            Case "ClosedCurve"
                myMapTool = MapTools.ClosedCurve
            Case "Ellipse", "Cycle"
                myMapTool = MapTools.Cycle
            Case "Arc"
                myMapTool = MapTools.arc
            Case "Rectangle"
                myMapTool = MapTools.Rectangle
            Case "Text"
                myMapTool = MapTools.Text
            Case "Table"
                myMapTool = MapTools.Table
            Case "MuiTenDon"
                myMapTool = MapTools.MuiTenDon
            Case "MuiTen"
                myMapTool = MapTools.MuiTen
            Case "MuiTenDac"
                myMapTool = MapTools.MuiTenDac
            Case "MuiTenHo"
                myMapTool = MapTools.MuiTenHo
            Case "SongSong"
                myMapTool = MapTools.SongSong
            Case "SongSongKin"
                myMapTool = MapTools.SongSongKin
        End Select
        If pType = "Ellipse" Then
            m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " & pType & ": kéo theo đường chéo (ấn Alt để có mầu quân Xanh)."
        ElseIf pType = "Rectangle" Then
            m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " & pType & ": kéo theo đường chéo (ấn Alt để có mầu quân Xanh)."
        ElseIf pType = "Arc" Then
            m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " & pType & ": kéo theo đường chéo (ấn Alt để có mầu quân Xanh)."
        ElseIf pType = "Text" Then
            m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " & pType & ": Click để chọn vị trí Text (ấn Alt để có mầu quân Xanh)."
        ElseIf pType = "Table" Then
            m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " & pType & ": Click để chọn vị trí Table (ấn Alt để có mầu quân Xanh)."
        Else
            m_ParentForm.ToolStripStatusLabel3.Text = "vẽ " & pType & ": Click để chọn các điểm, RightClick để kết thúc (ấn Alt để có mầu quân Xanh)."
        End If

        m_Map.CenterX = m_Map.CenterX
    End Sub

    Private Sub MnuPartSendBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuPartSendBack.Click
        FoundObject.FoundSymbol.GObjs.SendBack(FoundObject.FoundObject)
        m_Map.CenterX = m_Map.CenterX
    End Sub

    Private Sub MnuPartTachObject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuPartTachObject.Click
        PopUndo()
        Dim mSymbol As CSymbol = TachObject(FoundObject)
        If Not IsNothing(mSymbol) Then
            m_Map.CenterX = m_Map.CenterX
            m_ParentForm.PopulateListKH(mSymbol)
        End If
    End Sub

    Private Sub MnuScale_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuScale.Click
        myMapTool = MapTools.Scale
        m_ParentForm.ToolStripStatusLabel3.Text = "Zoom: di chuột để thay đổi kích thước KH."
    End Sub

    Private Sub MnuKHMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuKHMove.Click
        myMapTool = MapTools.Move
        m_ParentForm.ToolStripStatusLabel3.Text = "Move: di chuột để thay đổi vi trí KH."

    End Sub

    Private Sub MnuBlinking_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuBlinking.Click
        If Not m_SelectedSymbol Is Nothing Then
            m_SelectedSymbol.Blinking = Not m_SelectedSymbol.Blinking
        End If
    End Sub

    Protected Overrides Sub Finalize()
        'BlinkProcess1.StopThread()
        'm_Map.Layers.Remove("LopVeKyHieu")

        MyBase.Finalize()
    End Sub

    Public Sub Dispose()
        Try
            'StopBlinking()
            m_Map.Layers.Remove("LopVeKyHieu")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MnuGrNhom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuGrNhom.Click
        If m_SelectedSymbols.Count > 1 Then
            PopUndo()
            Dim mSymbol As CSymbol = m_SelectedSymbols(0)
            NhomSymbols(m_SelectedSymbols)
            m_SelectedSymbols.Clear()

            m_Map.CenterX = m_Map.CenterX

            m_ParentForm.PopulateListKH(mSymbol)
        End If
    End Sub

    Private Sub MnuGrCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuGrCopy.Click
        CopySymbols(m_SelectedSymbols)
        m_SelectedSymbols.Clear()
        m_Map.CenterX = m_Map.CenterX
    End Sub

    Private Sub MnuGrCut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuGrCut.Click
        PopUndo()
        CutSymbols(m_SelectedSymbols)
        m_SelectedSymbols.Clear()
        m_Map.CenterX = m_Map.CenterX
    End Sub

    Public Sub RefreshMap()
        m_Map.CenterX = m_Map.CenterX
    End Sub

    Public Sub CenterTo(ByVal pLon As Double, ByVal pLat As Double)
        m_Map.CenterX = pLon
        m_Map.CenterY = pLat
    End Sub

    Private Sub MnuMapKHsFromFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles MnuMapKHsFromFile.Click
        Dim mFileName As String
        Dim openFileDialog1 As New OpenFileDialog

        openFileDialog1.InitialDirectory = Application.StartupPath
        openFileDialog1.Filter = "TrangBĐ files (*.TBD)|*.TBD|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            mFileName = openFileDialog1.FileName
            If mFileName.Length > 0 Then
                PopUndo()
                'StopBlinking()
                LoadKHs(mFileName)
                If drawingSymbols.Count > 0 Then
                    m_Map.ZoomTo(myZoom, myCX, myCY)
                Else
                    RefreshMap()
                End If

                'StartBlinking()
                'myDirty = True
            End If
        End If

    End Sub

    Private Sub MnuMapKHsFromTT_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles MnuMapKHsFromTT.Click
        'Dim f As New frmInsertFromTT
        'f.ShowDialog()
    End Sub

    Private Sub MnuVFlip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuVFlip.Click
        PopUndo()
        m_SelectedSymbol.VFlip()
        m_Map.CenterX = m_Map.CenterX
    End Sub

    Private Sub MnuClosed2Curve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuClosed2Curve.Click
        If (FoundObject.FoundObject.GetObjType = OBJECTTYPE.ClosedCurve) Or (FoundObject.FoundObject.GetObjType = OBJECTTYPE.Polygon) Then
            PopUndo()
            FoundObject.FoundSymbol.GObjs.MoClosedCurve(FoundObject.FoundObject)
            m_Map.CenterX = m_Map.CenterX
        Else
            MsgBox("Chi lam duoc voi Duong kin thoi")
        End If
    End Sub

    Private Sub MnuCurve2Closed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuCurve2Closed.Click
        If (FoundObject.FoundObject.GetObjType = OBJECTTYPE.Curve) Or (FoundObject.FoundObject.GetObjType = OBJECTTYPE.Line) Then
            Dim mCurve As NodesShapeGraphic = CType(FoundObject.FoundObject, NodesShapeGraphic)
            If mCurve.Nodes.Count > 2 Then
                PopUndo()
                FoundObject.FoundSymbol.GObjs.DongCurve(FoundObject.FoundObject)
                m_Map.CenterX = m_Map.CenterX
            Else
                MsgBox("Khong kep kin duoc")
            End If
        Else
            MsgBox("Chi lam duoc voi duong mo thoi")
        End If
    End Sub

    Private Sub MnuTo1stNode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuTo1stNode.Click
        If Not FoundNode Is Nothing Then
            'FoundNode.FoundObject.ChangeNodeType(FoundNode.NodeIndex)
            If FoundNode.FoundObject.GetObjType = OBJECTTYPE.ClosedCurve Then
                Dim mCCurve As ClosedCurveGraphic = CType(FoundNode.FoundObject, ClosedCurveGraphic)
                mCCurve.To1stNode(FoundNode.NodeIndex)
                m_Map.CenterX = m_Map.CenterX
            ElseIf FoundNode.FoundObject.GetObjType = OBJECTTYPE.Polygon Then
                Dim mPolygon As PolygonGraphic = CType(FoundNode.FoundObject, PolygonGraphic)
                mPolygon.To1stNode(FoundNode.NodeIndex)
                m_Map.CenterX = m_Map.CenterX
            ElseIf (FoundNode.FoundObject.GetObjType = OBJECTTYPE.Curve) Or (FoundNode.FoundObject.GetObjType = OBJECTTYPE.Line) Then
                Dim mNShape As NodesShapeGraphic = CType(FoundNode.FoundObject, NodesShapeGraphic)
                If FoundNode.NodeIndex = mNShape.Nodes.Count - 1 Then
                    mNShape.ReverseNodes()
                    m_Map.CenterX = m_Map.CenterX
                Else
                    MsgBox("Chi lam duoc voi node cuoi thoi")
                End If
            Else
                MsgBox("Chi lam duoc voi ClosedCurve thoi")
            End If
        End If

    End Sub

    Private Sub MnuCut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuCut.Click
        myMapTool = MapTools.Split
        m_ParentForm.ToolStripStatusLabel3.Text = "Cắt: di chuột để vẽ đường cắt."
    End Sub

    Private Function To2Symbols(ByVal pSymbol As CSymbol, ByVal pPT0 As PointF, ByVal pPT1 As PointF) As SPLITSYMBOLS
        Dim mSPLITSYMBOLS As New SPLITSYMBOLS

        Dim mGObjs1 As New CGraphicObjs
        Dim mGObjs2 As New CGraphicObjs
        Dim mA0 As Single

        Dim mPTs2(1) As PointF
        mPTs2(0) = pPT0 'myfromPt
        mPTs2(1) = pPT1 'mytoPt

        Dim Scale As Single = pSymbol.Zoom / m_Map.Zoom
        Scale *= IIf(pSymbol.MWidth > 0, (m_Map.MapScreenWidth / pSymbol.MWidth), 1)

        Dim mMatrix As New Matrix
        mMatrix.Translate(-myrootPt.X, -myrootPt.Y, MatrixOrder.Append)
        mMatrix.Scale(1 / Scale, 1 / Scale, MatrixOrder.Append)
        mMatrix.TransformPoints(mPTs2)

        mA0 = AngleToPoint(mPTs2(0), mPTs2(1))

        For Each mObj1 As GraphicObject In pSymbol.GObjs
            Dim mObj As GraphicObject
            'If (mObj1.GetObjType = OBJECTTYPE.Curve) Or (mObj1.GetObjType = OBJECTTYPE.ClosedCurve) Then
            'mObj = mObj1
            'Else
            'mObj = ObjToCurve(mObj1)
            'End If
            mObj = ObjToCurve(mObj1)
            If mObj.GetObjType = OBJECTTYPE.Curve Then
                Dim mPTs() As PointF = mObj.GetPoints  'mCurve.GetPoints
                Dim mINTERSECTNODEs() As INTERSECTNODE
                mINTERSECTNODEs = GetIntersectPoints(mPTs2(0), mPTs2(1), mPTs)
                If mINTERSECTNODEs.GetUpperBound(0) > -1 Then
                    'Insert Node
                    Dim mPts1(mPTs.GetUpperBound(0) + mINTERSECTNODEs.GetUpperBound(0) + 1) As PointF
                    Dim k As Integer = 0
                    For i As Integer = 0 To mINTERSECTNODEs.GetUpperBound(0)
                        For j As Integer = k To mINTERSECTNODEs(i).NodeIndex
                            mPts1(j + i) = mPTs(j)
                        Next
                        mPts1(mINTERSECTNODEs(i).NodeIndex + i + 1) = mINTERSECTNODEs(i).PT
                        k = mINTERSECTNODEs(i).NodeIndex + 1
                        mINTERSECTNODEs(i).NodeIndex = mINTERSECTNODEs(i).NodeIndex + i + 1
                    Next
                    For j As Integer = k To mPTs.GetUpperBound(0)
                        mPts1(j + mINTERSECTNODEs.GetUpperBound(0) + 1) = mPTs(j)
                    Next
                    'Cat
                    Dim mPTS4O1() As PointF
                    Dim mPTS4O2() As PointF
                    ReDim mPTS4O1(-1)
                    ReDim mPTS4O2(-1)

                    Dim k1 As Integer = 0
                    For i As Integer = 0 To mINTERSECTNODEs.GetUpperBound(0)
                        Dim mPts4(mINTERSECTNODEs(i).NodeIndex - k1) As PointF
                        For j As Integer = k1 To mINTERSECTNODEs(i).NodeIndex
                            mPts4(j - k1) = mPts1(j)
                        Next
                        k1 = mINTERSECTNODEs(i).NodeIndex
                        If AngleToPoint(mPTs2(0), mPts4(mPts4.GetUpperBound(0) - 1)) > mA0 Then
                            'mGObjs1.Add(mObject)
                            Dim l As Integer = mPTS4O1.GetUpperBound(0)
                            ReDim Preserve mPTS4O1(l + mPts4.GetUpperBound(0) + 1)
                            For j As Integer = 0 To mPts4.GetUpperBound(0)
                                mPTS4O1(j + l + 1) = mPts4(j)
                            Next
                        Else
                            'mGObjs2.Add(mObject)
                            Dim l As Integer = mPTS4O2.GetUpperBound(0)
                            ReDim Preserve mPTS4O2(l + mPts4.GetUpperBound(0) + 1)
                            For j As Integer = 0 To mPts4.GetUpperBound(0)
                                mPTS4O2(j + l + 1) = mPts4(j)
                            Next
                        End If
                    Next
                    Dim mPts41(mPts1.GetUpperBound(0) - k1) As PointF
                    For j As Integer = k1 To mPts1.GetUpperBound(0)
                        mPts41(j - k1) = mPts1(j)
                    Next

                    If AngleToPoint(mPTs2(0), mPts41(1)) > mA0 Then
                        Dim l As Integer = mPTS4O1.GetUpperBound(0)
                        ReDim Preserve mPTS4O1(l + mPts41.GetUpperBound(0) + 1)
                        For j As Integer = 0 To mPts41.GetUpperBound(0)
                            mPTS4O1(j + l + 1) = mPts41(j)
                        Next
                    Else
                        Dim l As Integer = mPTS4O2.GetUpperBound(0)
                        ReDim Preserve mPTS4O2(l + mPts41.GetUpperBound(0) + 1)
                        For j As Integer = 0 To mPts41.GetUpperBound(0)
                            mPTS4O2(j + l + 1) = mPts41(j)
                        Next
                    End If

                    Dim mObject As CurveGraphic = mObj.Clone 'CType(mObj, CurveGraphic)
                    mObject.Nodes.Clear()
                    For j As Integer = 0 To mPTS4O1.GetUpperBound(0)
                        Dim mNode As New CNODE(mPTS4O1(j))
                        mNode.IsControl = True
                        mObject.Nodes.Add(mNode)
                    Next
                    mGObjs1.Add(mObject)

                    Dim mObject1 As CurveGraphic = mObj.Clone 'CType(mObj, CurveGraphic)
                    mObject1.Nodes.Clear()
                    For j As Integer = 0 To mPTS4O2.GetUpperBound(0)
                        Dim mNode As New CNODE(mPTS4O2(j))
                        mNode.IsControl = True
                        mObject1.Nodes.Add(mNode)
                    Next

                    mGObjs2.Add(mObject1)
                Else
                    If AngleToPoint(mPTs2(0), mPTs(0)) > mA0 Then
                        mGObjs1.Add(mObj1)
                    Else
                        mGObjs2.Add(mObj1)
                    End If
                End If
            ElseIf mObj.GetObjType = OBJECTTYPE.ClosedCurve Then
                Dim mPTs() As PointF = mObj.GetPoints
                Dim iDim As Integer = mPTs.GetUpperBound(0)
                ReDim Preserve mPTs(iDim + 1)
                mPTs(iDim + 1) = mPTs(0)

                Dim mINTERSECTNODEs() As INTERSECTNODE
                mINTERSECTNODEs = GetIntersectPoints(mPTs2(0), mPTs2(1), mPTs)

                ReDim Preserve mPTs(iDim)

                If mINTERSECTNODEs.GetUpperBound(0) > 0 Then
                    Dim mPTS4O1() As PointF
                    Dim mPTS4O2() As PointF
                    ReDim mPTS4O1(-1)
                    ReDim mPTS4O2(-1)

                    For i As Integer = 0 To mINTERSECTNODEs.GetUpperBound(0) - 1
                        Dim k1 As Integer = mINTERSECTNODEs(i).NodeIndex
                        Dim mPts4(mINTERSECTNODEs(i + 1).NodeIndex - k1 + 1) As PointF
                        mPts4(0) = mINTERSECTNODEs(i).PT
                        For j As Integer = 1 To mINTERSECTNODEs(i + 1).NodeIndex - k1
                            mPts4(j) = mPTs(k1 + j)
                        Next
                        mPts4(mINTERSECTNODEs(i + 1).NodeIndex - k1 + 1) = mINTERSECTNODEs(i + 1).PT

                        If AngleToPoint(mPTs2(0), mPts4(1)) > mA0 Then
                            'mGObjs1.Add(mObject)
                            Dim l As Integer = mPTS4O1.GetUpperBound(0)
                            ReDim Preserve mPTS4O1(l + mPts4.GetUpperBound(0) + 1)
                            For j As Integer = 0 To mPts4.GetUpperBound(0)
                                mPTS4O1(j + l + 1) = mPts4(j)
                            Next
                        Else
                            Dim l As Integer = mPTS4O2.GetUpperBound(0)
                            ReDim Preserve mPTS4O2(l + mPts4.GetUpperBound(0) + 1)
                            For j As Integer = 0 To mPts4.GetUpperBound(0)
                                mPTS4O2(j + l + 1) = mPts4(j)
                            Next
                        End If
                    Next
                    Dim i1 As Integer = mINTERSECTNODEs.GetUpperBound(0)
                    Dim l1 As Integer = iDim - mINTERSECTNODEs(i1).NodeIndex
                    Dim l2 As Integer = mINTERSECTNODEs(0).NodeIndex + 1
                    Dim mPts42(l1 + l2 + 1) As PointF

                    mPts42(0) = mINTERSECTNODEs(i1).PT
                    Dim k2 As Integer = mINTERSECTNODEs(i1).NodeIndex
                    For j As Integer = 1 To l1
                        mPts42(j) = mPTs(k2 + j)
                    Next
                    For j As Integer = 0 To l2 - 1
                        mPts42(j + l1 + 1) = mPTs(j)
                    Next
                    mPts42(l1 + l2 + 1) = mINTERSECTNODEs(0).PT

                    If AngleToPoint(mPTs2(0), mPts42(1)) > mA0 Then
                        Dim l As Integer = mPTS4O1.GetUpperBound(0)
                        ReDim Preserve mPTS4O1(l + mPts42.GetUpperBound(0) + 1)
                        For j As Integer = 0 To mPts42.GetUpperBound(0)
                            mPTS4O1(j + l + 1) = mPts42(j)
                        Next
                    Else
                        Dim l As Integer = mPTS4O2.GetUpperBound(0)
                        ReDim Preserve mPTS4O2(l + mPts42.GetUpperBound(0) + 1)
                        For j As Integer = 0 To mPts42.GetUpperBound(0)
                            mPTS4O2(j + l + 1) = mPts42(j)
                        Next
                    End If

                    Dim mObject As ClosedCurveGraphic = mObj.Clone 'New ClosedCurveGraphic(mPTS4O1, 1, Color.Blue)
                    mObject.Nodes.Clear()
                    For j As Integer = 0 To mPTS4O1.GetUpperBound(0)
                        Dim mNode As New CNODE(mPTS4O1(j))
                        mNode.IsControl = True
                        mObject.Nodes.Add(mNode)
                    Next
                    mGObjs1.Add(mObject)

                    Dim mObject1 As ClosedCurveGraphic = mObj.Clone 'New ClosedCurveGraphic(mPTS4O2, 1, Color.Blue)
                    mObject1.Nodes.Clear()
                    For j As Integer = 0 To mPTS4O2.GetUpperBound(0)
                        Dim mNode As New CNODE(mPTS4O2(j))
                        mNode.IsControl = True
                        mObject1.Nodes.Add(mNode)
                    Next
                    mGObjs2.Add(mObject1)
                Else
                    If AngleToPoint(mPTs2(0), mPTs(0)) > mA0 Then
                        mGObjs1.Add(mObj1)
                    Else
                        mGObjs2.Add(mObj1)
                    End If
                End If
            Else
                Dim mPTs() As PointF = mObj1.GetPoints
                If AngleToPoint(mPTs2(0), mPTs(0)) > mA0 Then
                    mGObjs1.Add(mObj1)
                Else
                    mGObjs2.Add(mObj1)
                End If
            End If
        Next

        Dim objSymbol1, objSymbol2 As CSymbol

        If mGObjs1.Count > 0 Then
            objSymbol1 = New CSymbol(pSymbol.Description, False, pSymbol.Zoom, pSymbol.MWidth, pSymbol.GocX, pSymbol.GocY, mGObjs1)
        Else
            objSymbol1 = Nothing
        End If
        If mGObjs2.Count > 0 Then
            objSymbol2 = New CSymbol(pSymbol.Description, False, pSymbol.Zoom, pSymbol.MWidth, pSymbol.GocX, pSymbol.GocY, mGObjs2)
        Else
            objSymbol2 = Nothing
        End If
        mSPLITSYMBOLS.Symbol1 = objSymbol1
        mSPLITSYMBOLS.Symbol2 = objSymbol2

        Return mSPLITSYMBOLS
    End Function

    Private Function ToCurve(ByVal pSymbol As CSymbol) As CSymbol
        Dim mGObjs As New CGraphicObjs

        For Each mObj As GraphicObject In pSymbol.GObjs
            If (mObj.GetObjType = OBJECTTYPE.Curve) Or (mObj.GetObjType = OBJECTTYPE.ClosedCurve) Then
                mGObjs.Add(mObj)
            Else
                mGObjs.Add(ObjToCurve(mObj))
            End If
        Next

        Dim objSymbol As CSymbol

        If mGObjs.Count > 0 Then
            objSymbol = New CSymbol("", False, pSymbol.Zoom, pSymbol.MWidth, pSymbol.GocX, pSymbol.GocY, mGObjs)
        Else
            objSymbol = Nothing
        End If
        Return objSymbol
    End Function

    Private Sub MnuToCurve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuToCurve.Click
        PopUndo()

        Dim mSymbol As CSymbol = ToCurve(m_SelectedSymbol)
        If Not IsNothing(mSymbol) Then
            m_DrawingSymbols.Remove(m_SelectedSymbol)
            m_DrawingSymbols.Add(mSymbol)
            m_SelectedSymbol = mSymbol
        End If

        OnCapNhatKH()
    End Sub

    Public Sub PopUndo()
        If m_ParentForm Is m_ParentForm Then
            m_ParentForm.myDirty = True
        End If

        PopUndo0()
        XoaRedoStack()
    End Sub

    Public Sub PopUndo0()
        Dim mSymbols As New CSymbols
        Dim mSeleSymbol As CSymbol
        For Each mSymbol As CSymbol In m_DrawingSymbols
            Dim mCloneSymbol As CSymbol = New CSymbol(mSymbol.Description, mSymbol.Blinking, mSymbol.Zoom, mSymbol.MWidth, mSymbol.GocX, mSymbol.GocY, mSymbol.GObjs)  'mSymbol.Clone(m_Map)
            mSymbols.Add(mCloneSymbol)
            If mSymbol Is m_SelectedSymbol Then
                mSeleSymbol = mCloneSymbol
            End If
        Next

        If iUndo < (defaUndosNo - 1) Then
            iUndo += 1
        Else
            For i As Integer = 0 To defaUndosNo - 2
                stackUnDos(i) = stackUnDos(i + 1)
            Next
            iUndo = defaUndosNo - 1
        End If
        stackUnDos(iUndo).UndoSymbols = mSymbols
        stackUnDos(iUndo).MapX = m_Map.CenterX
        stackUnDos(iUndo).MapY = m_Map.CenterY
        stackUnDos(iUndo).SeleSymbol = mSeleSymbol

        m_ParentForm.UndoToolStripButton.Enabled = True

    End Sub

    Private Function PushUndo() As UNDOITEM
        If (iUndo > -1) And (iUndo < defaUndosNo) Then
            PopRedo()

            Dim mUndoItem As UNDOITEM = stackUnDos(iUndo)
            iUndo -= 1
            If iUndo < 0 Then m_ParentForm.UndoToolStripButton.Enabled = False
            Return mUndoItem
        Else
            If iUndo < 0 Then m_ParentForm.UndoToolStripButton.Enabled = False
            Return Nothing
        End If
    End Function

    Private Sub PopRedo()
        Dim mSymbols As New CSymbols
        Dim mSeleSymbol As CSymbol
        For Each mSymbol As CSymbol In m_DrawingSymbols
            Dim mCloneSymbol As CSymbol = New CSymbol(mSymbol.Description, mSymbol.Blinking, mSymbol.Zoom, mSymbol.MWidth, mSymbol.GocX, mSymbol.GocY, mSymbol.GObjs)  'mSymbol.Clone(m_Map)
            mSymbols.Add(mCloneSymbol)
            If mSymbol Is m_SelectedSymbol Then
                mSeleSymbol = mCloneSymbol
            End If
        Next

        If iRedo < (defaUndosNo - 1) Then
            iRedo += 1
        Else
            For i As Integer = 0 To defaUndosNo - 2
                stackReDos(i) = stackReDos(i + 1)
            Next
            iRedo = defaUndosNo - 1
        End If

        stackReDos(iRedo).UndoSymbols = mSymbols
        stackReDos(iRedo).MapX = m_Map.CenterX
        stackReDos(iRedo).MapY = m_Map.CenterY
        stackReDos(iRedo).SeleSymbol = mSeleSymbol

        m_ParentForm.RedoToolStripButton.Enabled = True

    End Sub

    Private Function PushRedo() As UNDOITEM
        If (iRedo > -1) And (iRedo < defaUndosNo) Then
            PopUndo0()

            Dim mRedoItem As UNDOITEM = stackReDos(iRedo)
            iRedo -= 1
            If iRedo < 0 Then m_ParentForm.RedoToolStripButton.Enabled = False
            Return mRedoItem
        Else
            If iRedo < 0 Then m_ParentForm.RedoToolStripButton.Enabled = False
            Return Nothing
        End If
    End Function

    Public Sub XoaUndoStack()
        ReDim stackUnDos(defaUndosNo - 1)
        ReDim stackReDos(defaUndosNo - 1)
        iUndo = -1
        m_ParentForm.UndoToolStripButton.Enabled = False
        iRedo = -1
        m_ParentForm.RedoToolStripButton.Enabled = False
    End Sub

    Private Sub XoaRedoStack()
        iRedo = -1
        m_ParentForm.RedoToolStripButton.Enabled = False
    End Sub

    Private Sub MnuGrChangeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuGrChangeColor.Click
        Dim f As New dlgChangeSymbol
        f.Symbols = m_SelectedSymbols
        f.ShowDialog(m_ParentForm)
    End Sub

    Private Sub MnuGrMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuGrMove.Click
        myMapTool = MapTools.GrMove
        m_ParentForm.ToolStripStatusLabel3.Text = "Move: di chuột để di chuyển nhóm KH."
    End Sub

    Public Sub Zoom1X()
        m_Map.ZoomTo(myZoom, myCX, myCY)
    End Sub

    Private Sub CxtMnuKyHieu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles CxtMnuKyHieu.Popup
        m_Map.CurrentTool = MapXLib.ToolConstants.miArrowTool
    End Sub

    Private Sub MnuCopyToVeKH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuCopyToVeKH.Click
        If Not IsNothing(fCacKyHieu) Then
            If Not IsNothing(m_SelectedSymbol) Then
                'Dim mObjs As CGraphicObjs = Me.GetTyLeGObjs(m_SelectedSymbol.GObjs, 1 / myTyLeLayKH)
                'Dim mTyLe As Single = (m_SelectedSymbol.Zoom * myKHQSMWidth) / (m_SelectedSymbol.MWidth * myKHQSZoom * myTyLeLayKH)
                Dim mTyLe As Single = 1 / myTyLeLayKH
                Dim mObjs As CGraphicObjs = Me.GetTyLeGObjs(m_SelectedSymbol.GObjs, mTyLe)

                Dim mSymbol As CSymbol = New CSymbol(m_Map, mObjs)
                mSymbol.Description = m_SelectedSymbol.Description

                fCacKyHieu.CopyFromMap(mSymbol)
            End If
        Else
            MsgBox("Phải mở form Các ký hiệu mới copy được...")
        End If
    End Sub

    Private Sub MnuToPhanRa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuToPhanRa.Click
        PopUndo()

        Me.TachAllObject(m_SelectedSymbol)
        OnCapNhatKH()
    End Sub

    Private Sub MnuTo1Object_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuTo1Object.Click
        If Not FoundNode Is Nothing Then
            If m_SelectedSymbol.Noi2Objs(FoundNode) Then
                m_Map.CenterX = m_Map.CenterX
            Else
                MsgBox("Khong noi duoc.")
            End If
        End If
    End Sub

    Private Sub MnuSendFront_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuSendFront.Click
        PopUndo()
        m_DrawingSymbols.SendFront(m_SelectedSymbol)
        m_Map.CenterX = m_Map.CenterX
    End Sub

    Private Sub MnuPartSendFront_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuPartSendFront.Click
        FoundObject.FoundSymbol.GObjs.SendFront(FoundObject.FoundObject)
        m_Map.CenterX = m_Map.CenterX
    End Sub
End Class
