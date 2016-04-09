Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.Xml

Imports System.Drawing.Drawing2D
Imports System.Math
Imports System.Data.OleDb

Imports DBiGraphicObjs.DBiGraphicObjects
Imports System.Drawing

Public Class dlgCacKyHieu
    'Public Event KeyUp As KeyEventHandler

    Private Structure SPLITOBJECTS
        Dim Obj1 As GraphicObject
        Dim Obj2 As GraphicObject
    End Structure

    Private Enum VeTools
        None = 0

        Edit

        Polygon
        Line
        Curve
        ClosedCurve
        Cycle
        Pie
        Text
        Image

        Move
        MoveShape
        Scale
        ScaleShape
        Rotate
        RotateShape

        GroupMove
        GroupMoveShape
        GroupScale
        GroupScaleShape

        Split
        DangSplit

        ChangeRoot
    End Enum

    Private myKHConnStr As String

    Friend WithEvents myThumbNails As CThumbNails

    Private myRootX As Integer = 0
    Private myRootY As Integer = 0
    Public myORootX As Integer = 0
    Public myORootY As Integer = 0

    Private RootDragging As Boolean = False

    Private dragOffset As New PointF(0, 0)

    Private selectionDragging As Boolean = False
    Private selectionRect As RectangleF
    Private DrawingDragging As Boolean = False
    Private DrawingRect As Rectangle
    Private DrawingPicking As Boolean = False
    Private myPts() As PointF

    Private myfromPt, mytoPt, myrootPt As PointF

    Private EditObj As GraphicObject
    Private iEditNode, iEditNode2 As Integer

    Private m_SelectedObject As GraphicObject
    Private m_CopyObject As GraphicObject

    Private m_drawingObjects As New CGraphicObjs
    Private m_OdrawingObjects As New CGraphicObjs
    Public ReadOnly Property OdrawingObjects() As CGraphicObjs
        Get
            Return m_OdrawingObjects
        End Get
    End Property

    Private m_selectedObjects As New CGraphicObjs
    Public Property SelectedObject() As GraphicObject
        Get
            Return m_SelectedObject
        End Get
        Set(ByVal Value As GraphicObject)
            If Not Value Is m_SelectedObject Then
                If m_drawingObjects.Contains(Value) OrElse Value Is Nothing Then
                    m_SelectedObject = Value
                    'RaiseEvent SelectionChanged(Me, New SelectionChangedEventArgs(Value))
                    If Value Is Nothing Then
                        'RaiseEvent StatusUpdate(Me, _
                        '    New StatusUpdateEventArgs(StatusUpdateType.SelectionChanged, _
                        '        Value, "No Object Selected", _
                        '        Nothing, 0))
                    Else
                        'RaiseEvent StatusUpdate(Me, _
                        '    New StatusUpdateEventArgs(StatusUpdateType.SelectionChanged, _
                        '        Value, "Selected Object Changed", _
                        '        Value.GetPosition, 0))
                    End If
                    Me.Invalidate()
                End If
            End If
        End Set
    End Property

    Private m_EditingObjects As New CGraphicObjs
    Private m_CopyObjects As New CGraphicObjs

    Private m_DrawTool As VeTools

    '*********************************

    'Const MinW As Integer = 16 '100
    'Const MinH As Integer = 16

    Const MinW As Integer = 40 '100
    Const MinH As Integer = 40
    Const MaxW As Integer = 1500
    Const MaxH As Integer = 1500

    Private pointTL As Point

    Private bSnap As Boolean = True

    Public myScale As Integer = 4
    Public myGridWidth As Integer = 2
    Public myWidth As Integer = MinW
    Public myHeight As Integer = MinH

    Private GridSize As Drawing.Size = New Size(myGridWidth * myScale, myGridWidth * myScale)
    Private GridRect As Rectangle = New Rectangle(0, 0, myWidth * myScale, myHeight * myScale)

    Private myDataTable As DataTable

    Private bLoadXong As Boolean = False

    Private GridPen As New Pen(Color.Black, 1)

    Private dvLoaiKH As DataView

    Private Mode As String = "Update"


    Private Sub dlgCacKyHieu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myTyLeKH2Map = 1
        Try
            myTyLeKH2Map = CSng(Me.txtTyLe.Text)
        Catch ex As Exception
        End Try

        myThumbNails = Nothing
        fCacKyHieu = Nothing
        fMain.myBando.NhanKHXong()
    End Sub

    Private Sub dlgCacKyHieu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Location = fCallForm.Location
            Me.Height = fCallForm.Height - 20
            'Me.Width = defaImageWidth * 3 + defaHorizontalSpacing * 4
            Me.Panel1.Width = defaImageWidth * 3 + defaHorizontalSpacing * 10

            Me.HScrollBar1.Visible = False
            Me.VScrollBar1.Visible = False
            Me.StatusBar1.Visible = False
            Me.ToolBar1.Visible = False
            Me.PictureBox1.Visible = False
            Me.Splitter1.Visible = False
            Me.Panel2.Visible = False
            Me.Width = Me.Panel2.Left
            Me.Panel1.Dock = DockStyle.Fill

            Me.picThumbNails.Left = 0
            Me.picThumbNails.Width = Me.Panel3.Width

            Me.Panel4.Height = 0

            myKHConnStr = "File Name = " & myCacKyHieuUDL

            myThumbNails = New CThumbNails(Me.picThumbNails)

            'bLoadXong = True
            'fCacKyHieu = Me

            'myKHConnStr = "File Name = " & Application.StartupPath & "\KHdata.udl"
            'myKHConnStr = "File Name = KHdata.udl"

            Me.btnEdit.Enabled = False
            'Me.btnToMap.Enabled = False

            EditNodesCount = 0
            ReDim EditNodes(EditNodesCount - 1)
            iEditNode = 0

            'If myLoaiKH_ID = 0 Then
            'myLoaiKH_ID = GetFirstLoaiKH()
            'End If

            Me.DBiCombo1.ConnStr = myKHConnStr
            Me.DBiCombo1.KhoiDong(myLoaiKH_ID)

            If m_drawingObjects.Count > 0 Then
                EditFromMap()
            End If

            PopulateList(myLoaiKH_ID)
            PopulateForm()

            Me.txtTyLe.Text = myTyLeKH2Map
        Catch
            Me.Close()
        End Try

        fCacKyHieu = Me
        bLoadXong = True

        'AddHandler PictureBox1.KeyUp, AddressOf PictureBox1_KeyUp

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If btnEdit.Text = "Edit" Then
            OnEdit()
        Else
            OnUnEdit()
        End If
    End Sub

    Private Sub OnUnEdit()
        Me.HScrollBar1.Visible = False
        Me.VScrollBar1.Visible = False
        Me.StatusBar1.Visible = False
        Me.ToolBar1.Visible = False
        Me.PictureBox1.Visible = False
        Me.Splitter1.Visible = False
        Me.Panel2.Visible = False
        Me.Width = Me.Panel2.Left

        Me.Panel1.Dock = DockStyle.Fill

        Me.btnNew.Enabled = True
        Me.DBiCombo1.Enabled = True
        Me.picThumbNails.Enabled = True
        Me.btnDelete.Enabled = True
        Me.btnSave.Enabled = True

        btnEdit.Text = "Edit"

    End Sub

    Private Sub OnEdit()

        Me.Width = Me.Panel2.Left + Me.Panel2.Width
        Me.Panel1.Dock = DockStyle.Left
        Me.Panel2.Visible = True
        Me.Splitter1.Visible = True

        Me.ToolBar1.Visible = True
        Me.StatusBar1.Visible = True

        Me.HScrollBar1.Visible = True
        Me.VScrollBar1.Visible = True

        m_SelectedObject = Nothing

        Dim mPicSize As Size = m_drawingObjects.GetSize  'New Size(0, 0) 'Parts.GetSize

        'If mPicSize.Width > myWidth Then
        'myWidth = mPicSize.Width
        'End If
        'If mPicSize.Height > myHeight Then
        'myHeight = mPicSize.Height
        'End If
        If Mode = "Add" Then
            myWidth = 50 'mPicSize.Width
            myHeight = 50 'mPicSize.Height
        Else
            myWidth = mPicSize.Width
            myHeight = mPicSize.Height
        End If

        ThayDoiGrid()

        pointTL = New Point(0, 0)
        Me.PictureBox1.Location = pointTL
        Me.PictureBox1.Size = New Size(myWidth * myScale, myHeight * myScale)
        Me.PictureBox1.Visible = True

        Me.btnNew.Enabled = False
        Me.btnDelete.Enabled = False
        Me.btnSave.Enabled = False
        Me.DBiCombo1.Enabled = False
        Me.picThumbNails.Enabled = False


        DisplayScrollBars()

        btnEdit.Enabled = True
        btnEdit.Text = "UnEdit"

        OnCapNhatCT()
    End Sub

    Friend Sub OnCapNhatCT()
        m_DrawTool = VeTools.None
        UpdateTB("")
        Me.StatusBarPanel1.Text = "Chọn"
        Me.StatusBarPanel2.Text = "RightClick để chọn Menu. (ấn Shift và kéo chuột để chọn nhiều chi tiết)"

        Me.PictureBox1.Invalidate()
        Me.PictureBox2.Invalidate()
    End Sub

    Private Sub PopulateForm()
        Dim strKyHieu As String = ""
        Dim objListItem As CThumbNail

        'Try
        If myThumbNails.SelectedIndex > -1 Then
            objListItem = myThumbNails.Item(myThumbNails.SelectedIndex)

            Me.txtTenKH.Text = objListItem.Value
            Me.txtKyHieu_ID.Text = objListItem.ID
            strKyHieu = objListItem.Symbols

            GetSize(strKyHieu)
            'MsgBox("W=" & myWidth & ", H=" & myHeight)

            m_drawingObjects = CGraphicObjs.Str2Objects(strKyHieu, 0, 0) 'CThumbNails.Str2Objects(strKyHieu)  

            PictureBox2.Invalidate()

            btnDelete.Enabled = True
            btnNew.Enabled = True

            Me.btnEdit.Enabled = True
            'Me.btnToMap.Enabled = True

            Mode = "Update"
        Else
            m_drawingObjects = CGraphicObjs.Str2Objects("", 0, 0) 'CThumbNails.Str2Objects("") 'Str2Objects("")

            PictureBox2.Invalidate()

            btnDelete.Enabled = False
            btnNew.Enabled = True

            Me.btnEdit.Enabled = False
            'Me.btnToMap.Enabled = True
            Me.btnSave.Enabled = False
            Mode = "None"

        End If
        'Catch e As OleDbException
        'MsgBox(e.Message, MsgBoxStyle.Critical, "Pop SQL Error")

        'Catch e As Exception
        'MsgBox(E.Message, MsgBoxStyle.Critical, "Pop General Error")
        'End Try
        Me.Label2.Text = (myThumbNails.SelectedIndex + 1).ToString & " / " & myThumbNails.GetCount.ToString
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        OnCapNhatCT()
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Dim dragPoint As PointF = gscTogoc(e.X, e.Y)
        If bSnap Then
            dragPoint = Snap(dragPoint.X, dragPoint.Y)
        End If
        Me.StatusBarPanel4.Text = dragPoint.X.ToString & ", " & dragPoint.Y.ToString

        If Not m_SelectedObject Is Nothing Then
            If m_DrawTool = VeTools.RotateShape Then
                mytoPt = dragPoint 'New PointF(e.X, e.Y)
                m_SelectedObject.Rotate(myrootPt, myfromPt, mytoPt)
                myfromPt = mytoPt
                Me.PictureBox1.Invalidate()
            ElseIf m_DrawTool = VeTools.ScaleShape Then
                mytoPt = dragPoint
                m_SelectedObject.Zoom(myrootPt, myfromPt, mytoPt)
                myfromPt = mytoPt
                Me.PictureBox1.Invalidate()
            ElseIf m_DrawTool = VeTools.DangSplit Then
                mytoPt = dragPoint
                'm_SelectedObject.Zoom(myrootPt, myfromPt, mytoPt)
                'myfromPt = mytoPt
                Me.PictureBox1.Invalidate()
            ElseIf m_DrawTool = VeTools.MoveShape Then
                mytoPt = dragPoint
                m_SelectedObject.Move(myfromPt, mytoPt)
                myfromPt = mytoPt
                Me.PictureBox1.Invalidate()
            ElseIf m_DrawTool = VeTools.GroupMoveShape Then
                mytoPt = dragPoint
                'Dim mObj As GraphicObject
                For Each mObj As GraphicObject In m_EditingObjects
                    mObj.Move(myfromPt, mytoPt)
                Next
                myfromPt = mytoPt
                Me.PictureBox1.Invalidate()
            ElseIf m_DrawTool = VeTools.GroupScaleShape Then
                mytoPt = dragPoint
                'm_SelectedObject.Zoom(myrootPt, myfromPt, mytoPt)
                For Each mObj As GraphicObject In m_EditingObjects
                    mObj.Zoom(myrootPt, myfromPt, mytoPt)
                Next

                myfromPt = mytoPt
                Me.PictureBox1.Invalidate()
            End If
        Else
            If m_DrawTool = VeTools.GroupMoveShape Then
                mytoPt = dragPoint
                'Dim mObj As GraphicObject
                For Each mObj As GraphicObject In m_EditingObjects
                    mObj.Move(myfromPt, mytoPt)
                Next
                myfromPt = mytoPt
                Me.PictureBox1.Invalidate()
            ElseIf m_DrawTool = VeTools.GroupScaleShape Then
                mytoPt = dragPoint
                'm_SelectedObject.Zoom(myrootPt, myfromPt, mytoPt)
                For Each mObj As GraphicObject In m_EditingObjects
                    mObj.Zoom(myrootPt, myfromPt, mytoPt)
                Next

                myfromPt = mytoPt
                Me.PictureBox1.Invalidate()
            ElseIf m_DrawTool = VeTools.ChangeRoot Then
                If RootDragging Then
                    myRootX = dragPoint.X
                    If myRootX < 0 Then myRootX = 0
                    If myRootX > myWidth Then myRootX = myWidth
                    myRootY = dragPoint.Y
                    If myRootY < 0 Then myRootY = 0
                    If myRootY > myHeight Then myRootY = myHeight
                    Me.PictureBox1.Invalidate()

                    Me.StatusBarPanel1.Text = "Root"
                    Me.StatusBarPanel2.Text = "Gốc=(" & myRootX & "," & myRootY & ") Kéo gốc đến vị trí mới..."

                End If
            End If

            If (m_DrawTool = VeTools.Edit) AndAlso (iEditNode > -1) Then
                EditObj.MoveNodeTo(iEditNode, dragPoint)
                Me.PictureBox1.Invalidate()
            End If

            If DrawingDragging Then
                DrawingRect.Width = dragPoint.X - DrawingRect.X
                DrawingRect.Height = dragPoint.Y - DrawingRect.Y
                Me.PictureBox1.Invalidate()
            End If
            If DrawingPicking Then
                Dim i = myPts.GetUpperBound(0)
                myPts(i) = dragPoint
                Me.PictureBox1.Invalidate()
            End If
            If selectionDragging Then
                selectionRect.Width = e.X - Me.AutoScrollPosition.X - selectionRect.X
                selectionRect.Height = e.Y - Me.AutoScrollPosition.Y - selectionRect.Y
                Me.PictureBox1.Invalidate()
            End If

        End If
    End Sub

    Private Function Snap(ByVal px As Single, ByVal py As Single) As Point
        Return New Point(Round(px / myGridWidth, 0) * myGridWidth, Round(py / myGridWidth, 0) * myGridWidth)
    End Function

    Private Sub UpdateTB(ByVal pTag As String)
        'Dim mButton As ToolBarButton
        For Each mButton As ToolBarButton In Me.ToolBar1.Buttons
            If mButton.Tag = pTag Then
                mButton.Pushed = True
            Else
                mButton.Pushed = False
            End If
        Next
    End Sub

    Public Sub PastObjectAt(ByVal pObj As GraphicObject, ByVal pt1 As PointF)
        If Not pObj Is Nothing Then
            Dim mObj As GraphicObject = pObj.Clone()
            'Dim mSymbolObj As New CSymbol(m_Map, pt1, mSymbol.GObjs)
            mObj.Move(New PointF(mObj.X, mObj.Y), pt1)
            m_drawingObjects.Add(mObj)
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        Me.PictureBox1.Select()

        Dim selePT As PointF = gscTogoc(e.X, e.Y)
        Dim mousePT As PointF = gscTogoc(e.X, e.Y)
        If bSnap Then
            mousePT = Snap(mousePT.X, mousePT.Y)
        End If

        Select Case m_DrawTool
            Case VeTools.ChangeRoot
                If RootHitTest(mousePT) Then
                    RootDragging = True
                Else
                    OnCapNhatCT()
                    RootDragging = False
                End If
            Case VeTools.Edit
                iEditNode = EditObj.FindNodeAtPoint(selePT)
                If iEditNode > -1 Then
                    '    MsgBox(i)
                    If e.Button And MouseButtons.Right Then
                        Me.StatusBarPanel3.Text = (iEditNode.ToString & "/" & EditObj.GetPoints.GetUpperBound(0).ToString)
                        iEditNode2 = iEditNode
                        Me.ContextMenu1.Show(Me.PictureBox1, New Point(e.X, e.Y))
                    End If
                Else
                    OnCapNhatCT()
                End If
            Case VeTools.GroupMove
                m_DrawTool = VeTools.GroupMoveShape
                myfromPt = mousePT
                mytoPt = mousePT

                m_selectedObjects.Clear()
                m_SelectedObject = Nothing

            Case VeTools.GroupScale
                m_DrawTool = VeTools.GroupScaleShape
                myfromPt = mousePT
                mytoPt = mousePT
                myrootPt = New PointF(0, 0)
                'myrootPt = m_SelectedObject.GetCenter
                m_selectedObjects.Clear()
                m_SelectedObject = Nothing
            Case VeTools.Move
                m_DrawTool = VeTools.MoveShape
                myfromPt = mousePT
                mytoPt = mousePT
            Case VeTools.Rotate
                Me.StatusBarPanel1.Text = "dang Rotate"

                m_DrawTool = VeTools.RotateShape
                myfromPt = mousePT
                mytoPt = mousePT
                myrootPt = New PointF
                myrootPt = m_SelectedObject.GetCenter
            Case VeTools.Scale
                m_DrawTool = VeTools.ScaleShape
                myfromPt = mousePT
                mytoPt = mousePT
                myrootPt = New PointF(100, 100)
                myrootPt = m_SelectedObject.GetCenter
            Case VeTools.Split
                m_DrawTool = VeTools.DangSplit
                myfromPt = mousePT
                mytoPt = mousePT
                'myrootPt = New PointF(100, 100)
                'myrootPt = m_SelectedObject.GetCenter
            Case VeTools.None
                If ((Control.ModifierKeys And Keys.Control) = Keys.Control) And _
                    ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then
                    m_SelectedObject = m_drawingObjects.FindObjectAtPoint(selePT)
                    If Not m_SelectedObject Is Nothing Then
                        Dim bCoRoi As Boolean = False
                        For Each mSObj As GraphicObject In m_selectedObjects
                            If mSObj Is m_SelectedObject Then
                                bCoRoi = True
                            End If
                        Next
                        If bCoRoi = True Then
                            m_selectedObjects.Remove(m_SelectedObject)
                        Else
                            m_selectedObjects.Add(m_SelectedObject)
                        End If
                        Me.PictureBox1.Invalidate()
                    End If
                Else
                    If m_selectedObjects.Count > 0 Then
                        m_EditingObjects.Clear()
                        'Dim mObj As GraphicObject
                        For Each mObj As GraphicObject In m_selectedObjects
                            m_EditingObjects.Add(mObj)
                        Next

                        If e.Button And MouseButtons.Right Then
                            Me.MnuGroup.Show(Me.PictureBox1, New Point(e.X, e.Y))
                        End If
                        m_selectedObjects.Clear()
                    Else
                        If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
                            If e.Button And MouseButtons.Left Then
                                selectionDragging = True
                                selectionRect.X = e.X - Me.AutoScrollPosition.X
                                selectionRect.Y = e.Y - Me.AutoScrollPosition.Y
                                selectionRect.Height = 0
                                selectionRect.Width = 0
                            End If
                        Else
                            m_SelectedObject = m_drawingObjects.FindObjectAtPoint(selePT)
                            m_selectedObjects.Clear()
                            Me.PictureBox1.Invalidate()

                            If Not m_SelectedObject Is Nothing Then
                                If e.Button And MouseButtons.Left Then
                                    If ((Control.ModifierKeys And Keys.Control) = Keys.Control) And _
                                    ((Control.ModifierKeys And Keys.Alt) = Keys.Alt) Then
                                        m_DrawTool = VeTools.ScaleShape
                                        myfromPt = mousePT
                                        mytoPt = mousePT
                                        myrootPt = New PointF(100, 100)
                                        myrootPt = m_SelectedObject.GetCenter
                                    ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                                        m_DrawTool = VeTools.MoveShape
                                        myfromPt = mousePT
                                        mytoPt = mousePT
                                    ElseIf (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                                        m_DrawTool = VeTools.RotateShape
                                        myfromPt = mousePT
                                        mytoPt = mousePT
                                        myrootPt = New PointF
                                        myrootPt = m_SelectedObject.GetCenter
                                    Else
                                    End If
                                Else
                                    Me.ContextMenu2.Show(Me.PictureBox1, New Point(e.X, e.Y))
                                End If
                            Else
                                If e.Button And MouseButtons.Right Then
                                    Me.mnuGroupAll.Show(Me.PictureBox1, New Point(e.X, e.Y))
                                End If
                            End If
                        End If

                    End If
                End If

            Case VeTools.Line, VeTools.Curve, VeTools.ClosedCurve, VeTools.Polygon
                If e.Button And MouseButtons.Left Then
                    If Not DrawingPicking Then
                        DrawingPicking = True
                        ReDim myPts(1)
                        myPts(0) = mousePT
                        myPts(1) = mousePT
                    Else
                        Dim i As Integer = myPts.GetUpperBound(0)
                        'If (i > 0) AndAlso ((mousePT.X <> myPts(i - 1).X) Or (mousePT.Y <> myPts(i - 1).Y)) Then
                        i += 1
                        ReDim Preserve myPts(i)
                        myPts(i) = mousePT
                        'End If
                    End If
                    'RaiseEvent StatusUpdate(Me, _
                    '    New StatusUpdateEventArgs(StatusUpdateType.ObjectMoved, _
                    '    Me.SelectedObject, "Dang Ve", mousePT, myPts.GetUpperBound(0) + 1))
                Else
                    If myPts.GetUpperBound(0) > 0 Then
                        AddNewObj()
                    End If
                    OnCapNhatCT()

                    DrawingPicking = False
                End If

            Case VeTools.Cycle
                If e.Button And MouseButtons.Left Then
                    DrawingDragging = True
                    DrawingRect.X = mousePT.X
                    DrawingRect.Y = mousePT.Y
                    DrawingRect.Height = 0
                    DrawingRect.Width = 0
                End If
            Case VeTools.Pie
                If e.Button And MouseButtons.Left Then
                    DrawingDragging = True
                    DrawingRect.X = mousePT.X
                    DrawingRect.Y = mousePT.Y
                    DrawingRect.Height = 0
                    DrawingRect.Width = 0
                End If
            Case VeTools.Text
                ReDim myPts(0)
                myPts(0) = mousePT
                AddNewObj()
                OnCapNhatCT()
            Case VeTools.Image
                ReDim myPts(0)
                myPts(0) = mousePT
                AddNewObj()
                OnCapNhatCT()
        End Select

    End Sub

    Private Sub AddNewObj()
        Dim gObj As GraphicObject

        Select Case m_DrawTool
            Case VeTools.Curve
                Dim myCurve As New CurveGraphic(myPts, 1, Color.Red)
                myCurve.Rotation = 0
                myCurve.LineWidth = defaGenPen1W
                myCurve.LineColor = defaGenPen1C
                myCurve.Line2Width = defaGenPen2W
                myCurve.Line2Color = defaGenPen2C
                'myCurve.Fill = defaGenFill
                myCurve.FillColor = defaGenFillC
                myCurve.LineStyle = defaGenLineStyle

                gObj = myCurve
            Case VeTools.ClosedCurve
                If myPts.GetUpperBound(0) > 1 Then
                    Dim myClosedCurve As New ClosedCurveGraphic(myPts, 1, Color.Red)
                    myClosedCurve.Rotation = 0
                    myClosedCurve.LineWidth = defaGenPen1W
                    myClosedCurve.LineColor = defaGenPen1C
                    myClosedCurve.Line2Width = defaGenPen2W
                    myClosedCurve.Line2Color = defaGenPen2C
                    myClosedCurve.Fill = defaGenFill
                    myClosedCurve.FillColor = defaGenFillC
                    myClosedCurve.LineStyle = defaGenLineStyle

                    gObj = myClosedCurve
                End If
            Case VeTools.Line
                Dim myLine As New LinesGraphic(myPts, 1, Color.Red)
                myLine.Rotation = 0
                myLine.LineWidth = defaGenPen1W
                myLine.LineColor = defaGenPen1C
                myLine.Line2Width = defaGenPen2W
                myLine.Line2Color = defaGenPen2C
                'myLine.Fill = defaGenFill
                myLine.FillColor = defaGenFillC
                myLine.LineStyle = defaGenLineStyle

                gObj = myLine
            Case VeTools.Polygon
                Dim myPolygon As New PolygonGraphic(myPts, 1, Color.Red)
                myPolygon.Rotation = 0
                myPolygon.LineWidth = defaGenPen1W
                myPolygon.LineColor = defaGenPen1C
                myPolygon.Line2Width = defaGenPen2W
                myPolygon.Line2Color = defaGenPen2C
                myPolygon.Fill = defaGenFill
                myPolygon.FillColor = defaGenFillC
                myPolygon.LineStyle = defaGenLineStyle
                gObj = myPolygon
            Case VeTools.Cycle
                Dim myEllipse As New EllipseGraphic( _
                DrawingRect.Left, _
                DrawingRect.Top, _
                DrawingRect.Width, _
                DrawingRect.Height, 0)

                'myEllipse.LineWidth = 1
                'myEllipse.LineColor = Color.Red
                myEllipse.LineWidth = defaGenPen1W
                myEllipse.LineColor = defaGenPen1C
                myEllipse.Line2Width = defaGenPen2W
                myEllipse.Line2Color = defaGenPen2C
                myEllipse.Fill = defaGenFill
                myEllipse.FillColor = defaGenFillC
                myEllipse.LineStyle = defaGenLineStyle

                gObj = myEllipse
            Case VeTools.Pie
                If DrawDrawingPie(PictureBox1.CreateGraphics, DrawingRect) Then
                    Dim myPie As New PieGraphic( _
                    DrawingRect.Left, _
                    DrawingRect.Top, _
                    DrawingRect.Width, _
                    DrawingRect.Height, 0)

                    myPie.LineWidth = defaPiePen1W
                    myPie.Fill = defaPieFill
                    myPie.FillColor = defaPieFillC 'Color.FromArgb(100, Color.Red) 'Color.Blue
                    myPie.LineColor = defaPiePen1C 'Color.Red
                    myPie.IsArc = defaPieArc
                    myPie.StartAngle = defaPieStartA '0
                    myPie.SweepAngle = defaPieSweepA '90

                    gObj = myPie
                End If
            Case VeTools.Text
                'Dim StringFont As New Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point)
                Dim myTextObject As New TextGraphic(myPts(0).X, _
                                            myPts(0).Y, _
                                            "Text", _
                                            defaTextFont, _
                                            defaTextC)
                myTextObject.Rotation = 0
                myTextObject.AutoSize = True
                gObj = myTextObject
                gObj.Rotation = 0
                'gObj.AutoSize = True

            Case VeTools.Image
                Dim mFileName As String
                Dim openFileDialog1 As New OpenFileDialog
                With openFileDialog1
                    .CheckFileExists = True
                    .CheckPathExists = True
                    .Title = "Select Image File"
                    '.Filter = "Bitmap Files (*.bmp)|*.bmp|JPEG Files (*.jpg)|*.jpg;*.jpeg|All files (*.*)|*.*"
                    .Filter = "Image Files (*.bmp)|*.bmp;*.gif;*.wmf;*.emf;*.jpg;*.jpeg|All files (*.*)|*.*"
                    .AddExtension = True
                    .Multiselect = False
                    .RestoreDirectory = True
                End With

                If openFileDialog1.ShowDialog() = DialogResult.OK Then
                    'Dim gObj As GraphicObject
                    mFileName = openFileDialog1.FileName

                    If mFileName.Length > 0 Then
                        Try
                            Dim mImage As Image = New Bitmap(mFileName)
                            'Dim mImage As Image = Image.FromFile(mFileName)
                            fCacKyHieu.myScale = 1
                            fCacKyHieu.myGridWidth = 4
                            myWidth = mImage.Width
                            myHeight = mImage.Height
                            ThayDoiGrid()
                            DisplayScrollBars()
                            PictureBox1.Invalidate()

                            Dim mType As String = "bmp"
                            If mImage.RawFormat.Equals(Imaging.ImageFormat.MemoryBmp) Then
                                mType = "kro"
                            End If

                            Dim mEmbeddedImage As New EmbeddedImageGraphic(mType, CInt(myPts(0).X), CInt(myPts(0).Y), mImage)
                            mEmbeddedImage.Transparent = True
                            mEmbeddedImage.TransparentColor = Color.White
                            gObj = mEmbeddedImage
                            With gObj
                                .Rotation = 0
                                .AutoSize = False 'True
                                .X = myPts(0).X
                                .Y = myPts(0).Y
                                .Width = mImage.Width
                                .Height = mImage.Height

                                If .Width > MaxW Then .Width = MaxW
                                If .Height > MaxH Then .Height = MaxH

                            End With

                        Catch ex As Exception

                        End Try
                    End If
                End If
        End Select

        If Not gObj Is Nothing Then
            m_drawingObjects.Add(gObj)
        End If

    End Sub


    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        Dim dragPoint As PointF = gscTogoc(e.X, e.Y)
        If bSnap Then
            dragPoint = Snap(dragPoint.X, dragPoint.Y)
        End If

        If m_EditingObjects.Count > 0 Then
            If m_DrawTool = VeTools.GroupMoveShape Then
                m_EditingObjects.Clear()
                OnCapNhatCT()
            ElseIf m_DrawTool = VeTools.GroupScaleShape Then
                m_EditingObjects.Clear()
                OnCapNhatCT()
            End If
        End If
        If Not m_SelectedObject Is Nothing Then
            If m_DrawTool = VeTools.RotateShape Then
                OnCapNhatCT()
            ElseIf m_DrawTool = VeTools.ScaleShape Then
                OnCapNhatCT()
            ElseIf m_DrawTool = VeTools.DangSplit Then
                Dim mSplitObjects As SPLITOBJECTS = To2Objects(m_SelectedObject, myfromPt, mytoPt)
                m_drawingObjects.Remove(m_SelectedObject)
                If Not IsNothing(mSplitObjects.Obj1) Then
                    m_drawingObjects.Add(mSplitObjects.Obj1)
                    m_SelectedObject = mSplitObjects.Obj1
                End If
                If Not IsNothing(mSplitObjects.Obj2) Then
                    m_drawingObjects.Add(mSplitObjects.Obj2)
                    m_SelectedObject = mSplitObjects.Obj2
                End If

                OnCapNhatCT()
            ElseIf m_DrawTool = VeTools.MoveShape Then
                OnCapNhatCT()
            ElseIf m_DrawTool = VeTools.GroupMoveShape Then
                OnCapNhatCT()
            End If
        Else
            If (m_DrawTool = VeTools.Edit) AndAlso (iEditNode >= 0) Then
                EditObj.Reset()
                iEditNode = -1
                Me.PictureBox2.Invalidate()
            End If

        End If

        If selectionDragging Then
            Dim zoomedSelection As RectangleF = DeZoomRectangle(selectionRect)
            'Dim graphicObj As GraphicObject
            m_selectedObjects.Clear()
            For Each graphicObj As GraphicObject In m_drawingObjects
                If graphicObj.HitTest(zoomedSelection) Then
                    m_SelectedObject = graphicObj
                    'Exit For
                    m_selectedObjects.Add(graphicObj)
                End If
            Next
            selectionDragging = False

            Me.PictureBox1.Invalidate()
        End If

        If DrawingDragging Then
            DrawingDragging = False
            Me.PictureBox1.Invalidate()
            Me.PictureBox2.Invalidate()
        End If

        Select Case m_DrawTool
            Case VeTools.Cycle, VeTools.Pie
                AddNewObj()
                OnCapNhatCT()
            Case VeTools.Line, VeTools.Curve, VeTools.ClosedCurve

        End Select

        RootDragging = False
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        'm_Statusbar.Panels(3).Text = ""
        Dim mTag As String = e.Button.Tag
        UpdateTB(mTag)
        Select Case mTag
            Case "Line"
                m_DrawTool = VeTools.Line
                m_SelectedObject = Nothing
                Me.StatusBarPanel1.Text = "Line"
                Me.StatusBarPanel2.Text = "Click để chọn các điểm, RightClick để kết thúc."
            Case "Polygon"
                m_DrawTool = VeTools.Polygon
                m_SelectedObject = Nothing
                Me.StatusBarPanel1.Text = "Polygon"
                Me.StatusBarPanel2.Text = "Click để chọn các điểm, RightClick để kết thúc."
            Case "Curve"
                m_DrawTool = VeTools.Curve
                m_SelectedObject = Nothing
                Me.StatusBarPanel1.Text = "Curve"
                Me.StatusBarPanel2.Text = "Click để chọn các điểm, RightClick để kết thúc."
            Case "ClosedCurve"
                m_DrawTool = VeTools.ClosedCurve
                m_SelectedObject = Nothing
                Me.StatusBarPanel1.Text = "ClosedCurve"
                Me.StatusBarPanel2.Text = "Click để chọn các điểm, RightClick để kết thúc."
            Case "Text"
                m_DrawTool = VeTools.Text
                m_SelectedObject = Nothing
                Me.StatusBarPanel1.Text = "Text"
                Me.StatusBarPanel2.Text = "Click để chọn vị trí Text."
            Case "Ellipse"
                m_DrawTool = VeTools.Cycle
                m_SelectedObject = Nothing
                Me.StatusBarPanel1.Text = "Elippse"
                Me.StatusBarPanel2.Text = "Kéo chuột dọc theo đường kính để vẽ Ellipse"
            Case "Pie"
                m_DrawTool = VeTools.Pie
                m_SelectedObject = Nothing
                Me.StatusBarPanel1.Text = "Pie"
                Me.StatusBarPanel2.Text = "Kéo chuột dọc theo đường kính để vẽ Pie"
            Case "Edit"
                'm_DrawTool = VeTools.Edit
                OnNodesEdit()
            Case "Past"
                If Not m_CopyObject Is Nothing Then
                    PastObjectAt(m_CopyObject, New PointF(m_CopyObject.X + 5, m_CopyObject.Y + 5))
                    PictureBox1.Invalidate()
                    PictureBox2.Invalidate()
                End If
            Case "Option"
                Dim f As New dlgOption 'frmOption
                f.nudScale.Value = myScale
                f.nudGrid.Value = myGridWidth
                f.nudWidth.Value = myWidth
                f.nudHeight.Value = myHeight
                f.chkSnap.Checked = bSnap
                If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    myScale = f.nudScale.Value
                    myGridWidth = f.nudGrid.Value
                    myWidth = f.nudWidth.Value
                    myHeight = f.nudHeight.Value
                    ThayDoiGrid()
                    bSnap = f.chkSnap.Checked
                End If
                'Parts.Update(myScale)

                DisplayScrollBars()
                PictureBox1.Invalidate()
            Case "Root"
                m_DrawTool = VeTools.ChangeRoot
                'myRootX = dragPoint.X
                If myRootX < 0 Then myRootX = 0
                If myRootX > myWidth Then myRootX = myWidth
                'myRootY = dragPoint.Y
                If myRootY < 0 Then myRootY = 0
                If myRootY > myHeight Then myRootY = myHeight
                Dim g As Graphics = Me.PictureBox1.CreateGraphics

                Me.PictureBox1.Invalidate()

                Me.StatusBarPanel1.Text = "Root"
                Me.StatusBarPanel2.Text = "Gốc=(" & myRootX & "," & myRootY & ") Kéo gốc đến vị trí mới..."
            Case "Image"
                m_DrawTool = VeTools.Image
                m_SelectedObject = Nothing
                Me.StatusBarPanel1.Text = "Image"
                Me.StatusBarPanel2.Text = "Click để chọn vị trí Image."

        End Select

    End Sub

    Private Sub MnuAddNode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuAddNode.Click
        'AddNode()
        EditObj.InsertNode(iEditNode2)
        If (m_DrawTool = VeTools.Edit) AndAlso (iEditNode >= 0) Then
            EditObj.Reset()
            iEditNode = -1
            Me.PictureBox2.Invalidate()
        End If
        Me.PictureBox1.Invalidate()
    End Sub

    Private Sub MnuChangeNodeType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuChangeNodeType.Click
        EditObj.ChangeNodeType(iEditNode2)
        If (m_DrawTool = VeTools.Edit) AndAlso (iEditNode >= 0) Then
            EditObj.Reset()
            iEditNode = -1
            Me.PictureBox2.Invalidate()
        End If
        PictureBox1.Invalidate()
        'PictureBox2.Invalidate()
    End Sub

    Private Sub MnXoaNode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnXoaNode.Click
        EditObj.RemoveNode(iEditNode2)
        If (m_DrawTool = VeTools.Edit) AndAlso (iEditNode >= 0) Then
            EditObj.Reset()
            iEditNode = -1
            Me.PictureBox2.Invalidate()
        End If
        PictureBox1.Invalidate()
    End Sub

    Private Sub MnuChangeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuChangeColor.Click
        Select Case m_SelectedObject.GetObjType
            Case OBJECTTYPE.Curve, OBJECTTYPE.ClosedCurve, OBJECTTYPE.Cycle, OBJECTTYPE.Line, OBJECTTYPE.Polygon, OBJECTTYPE.Ellipse
                Dim f As New dlgChangeColor
                'fCallForm = Me
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

                If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
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
                End If
                PictureBox1.Invalidate()
                PictureBox2.Invalidate()
            Case OBJECTTYPE.Text
                Dim f As New dlgChangeLabel
                'fCallForm = Me
                Dim myObj As TextGraphic = m_SelectedObject
                f.txtLabel.Text = myObj.Text
                f.txtLabel.Font = myObj.Font 'StringFont
                f.txtLabel.ForeColor = myObj.Color

                If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    myObj.Text = f.txtLabel.Text
                    myObj.Font = f.txtLabel.Font
                    myObj.Color = f.txtLabel.ForeColor
                End If
                PictureBox1.Invalidate()
                PictureBox2.Invalidate()
            Case OBJECTTYPE.Pie
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

                If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
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

                End If
                PictureBox1.Invalidate()
                PictureBox2.Invalidate()
            Case OBJECTTYPE.EmbeddedImage
                Dim mImage As EmbeddedImageGraphic = m_SelectedObject
                Dim f As New dlgChangeImage
                f.chkTransparent.Checked = mImage.Transparent
                f.txtTransparentColor.BackColor = mImage.TransparentColor
                If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    mImage.Transparent = f.chkTransparent.Checked
                    mImage.TransparentColor = f.txtTransparentColor.BackColor
                End If
        End Select

    End Sub

    Private Sub MnuDeleteShape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuDeleteShape.Click
        m_drawingObjects.Remove(m_SelectedObject)
        PictureBox1.Invalidate()
        PictureBox2.Invalidate()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        OnAddNew()
    End Sub

    Private Sub EditFromMap()
        Me.txtKyHieu_ID.Text = "-1"
        Me.txtTenKH.Text = ""
        PictureBox2.Invalidate()
        'Me.ListBox1.ClearSelected()

        Mode = "Add"

        btnDelete.Enabled = False
        btnNew.Enabled = False
        OnEdit()
    End Sub

    Private Sub OnAddNew()
        ClearForm()

        Mode = "Add"

        btnDelete.Enabled = False
        btnNew.Enabled = False

        OnEdit()
    End Sub


    Private Sub ClearForm()
        Me.txtKyHieu_ID.Text = "-1"
        Me.txtTenKH.Text = ""

        'Parts = New CParts()
        m_drawingObjects.Clear()

        PictureBox2.Invalidate()
        'Me.ListBox1.ClearSelected()

    End Sub

    Public Sub OnUpdate()
        Dim mPicSize As Size = m_drawingObjects.GetSize  'New Size(0, 0) 'Parts.GetSize
        myWidth = mPicSize.Width
        myHeight = mPicSize.Height
        If (myRootX < 0) Or (myRootX > myWidth) Then
            myRootX = myWidth / 2
        End If
        If (myRootY < 0) Or (myRootY > myHeight) Then
            myRootY = myHeight / 2
        End If
        If Mode = "Add" Then
            If AddKyHieu() = True Then
                myThumbNails.SelectedIndex = myThumbNails.Count - 1
            End If
        Else
            If UpdateKyHieu() = True Then
                Me.picThumbNails.Invalidate()
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        OnUpdate()
        'PopulateForm()
        myThumbNails_SelectedIndexChanged(Nothing)
    End Sub

    Private Function CreateKHTable() As DataTable
        Dim mDataTable As DataTable = New DataTable("MyDataTable")
        Dim mDataColumn As DataColumn

        mDataColumn = New DataColumn
        mDataColumn.DataType = System.Type.GetType("System.Int32")
        mDataColumn.ColumnName = "KH_ID"
        mDataTable.Columns.Add(mDataColumn)

        mDataColumn = New DataColumn
        mDataColumn.DataType = Type.GetType("System.String")
        mDataColumn.ColumnName = "TenKH"
        mDataTable.Columns.Add(mDataColumn)

        Return mDataTable
    End Function


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If myThumbNails.SelectedIndex > -1 Then
            Dim mIndex As Integer = myThumbNails.SelectedIndex
            DeleteKyHieu(myThumbNails.Item(mIndex))
            If mIndex >= myThumbNails.Count Then
                myThumbNails.SelectedIndex = mIndex - 1
            End If
            myThumbNails_SelectedIndexChanged(Nothing)
        End If
    End Sub

    Private Sub MnuSendBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuSendBack.Click
        m_drawingObjects.SendBack(m_SelectedObject)
        PictureBox1.Invalidate()
        PictureBox2.Invalidate()
    End Sub

    Private Sub MnuScaleShape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuScaleShape.Click
        m_DrawTool = VeTools.Scale
        'PictureBox1.Invalidate()
        Me.StatusBarPanel1.Text = "Scale"
        Me.StatusBarPanel2.Text = "Zoom: di chuột để thu, phóng"
    End Sub

    Private Sub MnuRotateShape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuRotateShape.Click
        m_DrawTool = VeTools.Rotate
        Me.StatusBarPanel1.Text = "Rotate"
        Me.StatusBarPanel2.Text = "Rotate: di chuột để quay"
    End Sub

    Private Sub MnuCopyShape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuCopyShape.Click
        m_CopyObject = m_SelectedObject.Clone()
    End Sub

    Private Sub ThayDoiGrid()
        GridRect.Width = myWidth * myScale
        GridRect.Height = myHeight * myScale
        GridSize = New Size(myGridWidth * myScale, myGridWidth * myScale)

    End Sub

    Private Function AddKyHieu() As Boolean
        Dim bKQ As Boolean = False
        If Not IsValidForm() Then
            'Exit Function
            Return False
        End If
        'Dim mStt As Integer = myThumbNails.Count + 1
        Dim mStt = GetMaxStt(myLoaiKH_ID) + 1
        Dim mKyHieu As String = Objects2String(myWidth, myHeight, myRootX, myRootY, m_drawingObjects)

        'Return bKQ
        Return AddKyHieu(mKyHieu, Me.txtTenKH.Text, myLoaiKH_ID, mStt)
    End Function

    Private Function AddKyHieu(ByVal pKH As String, ByVal pTenKH As String, ByVal pLoaiKH_ID As Integer, ByVal pStt As Integer) As Boolean
        Dim bKQ As Boolean = False

        Dim cnSQL As OleDbConnection
        Dim cmSQL As OleDbCommand
        Dim strSQL As String

        Dim mLastKH_ID As Integer

        Try
            strSQL = "INSERT INTO tblKyHieu "
            strSQL &= "(LoaiKH_ID"
            strSQL &= ", TenKH"
            strSQL &= ", KyHieu, Stt)"
            strSQL &= " VALUES (?, ?, ?, ?)"

            cnSQL = New OleDbConnection(myKHConnStr)
            cnSQL.Open()

            cmSQL = New OleDbCommand(strSQL, cnSQL)
            'cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("LoaiKH_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "PhanMuc_ID", System.Data.DataRowVersion.Current, Nothing))
            cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("LoaiKH_ID", System.Data.OleDb.OleDbType.Integer, 0, "LoaiKH_ID"))
            cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("TenKH", System.Data.OleDb.OleDbType.VarWChar, 50, "TenKH"))
            cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("KyHieu", System.Data.OleDb.OleDbType.VarWChar, 0, "KyHieu"))
            cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("Stt", System.Data.OleDb.OleDbType.Integer, 0, "Stt"))

            cmSQL.Parameters("LoaiKH_ID").Value = pLoaiKH_ID
            cmSQL.Parameters("TenKH").Value = pTenKH
            cmSQL.Parameters("KyHieu").Value = pKH
            cmSQL.Parameters("Stt").Value = pStt

            If cmSQL.ExecuteNonQuery() = 1 Then
                cmSQL.CommandText = "SELECT @@IDENTITY AS 'Identity'"
                mLastKH_ID = cmSQL.ExecuteScalar
            End If

            ' Close and Clean up objects
            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

            'FindTinTucByName(lstTinTucs, TinTucName)
            bKQ = True
        Catch Exp As OleDbException
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")
        End Try

        If bKQ Then
            If (pLoaiKH_ID = myLoaiKH_ID) Then
                Dim aThumbnail As CThumbNail = New CThumbNail(pTenKH, mLastKH_ID, pKH)
                Me.myThumbNails.Add(aThumbnail)
                Me.myThumbNails.CalculateRowsAndColumns()
                Me.picThumbNails.Invalidate()
            End If
        End If

        Return bKQ

    End Function

    Private Function IsValidForm() As Boolean
        ' Check to make sure each field has a valid value
        If Me.txtTenKH.Text.Length > 0 Then
            Return True
        Else
            MsgBox("Ten Ky Hieu Sai.", _
                    MsgBoxStyle.Exclamation, Me.Text)
            Return False
        End If
    End Function

    Private Function UpdateKyHieu() As Boolean
        Dim bKQ As Boolean = False
        If Not IsValidForm() Then
            Return False
        End If

        Dim mKyHieu As String = Objects2String(myWidth, myHeight, myRootX, myRootY, m_drawingObjects) 'm_drawingObjects.Objects2String()  'Parts.Parts2String()

        'Dim aThumbNail As CThumbNail = myThumbNails.Item(myThumbNails.SelectedIndex)
        myThumbNails.Item(myThumbNails.SelectedIndex).Symbols = mKyHieu
        myThumbNails.Item(myThumbNails.SelectedIndex).Value = Me.txtTenKH.Text

        Dim cnSQL As OleDbConnection
        Dim cmSQL As OleDbCommand
        Dim strSQL As String = ""
        Dim intRowsAffected As Integer

        Try
            strSQL = "UPDATE tblKyHieu SET"
            strSQL &= " TenKH = ?"
            strSQL &= ", KyHieu = ?"
            strSQL &= " WHERE KH_ID = ?"

            cnSQL = New OleDbConnection(myKHConnStr)
            cnSQL.Open()

            cmSQL = New OleDbCommand(strSQL, cnSQL)
            cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("TenKH", System.Data.OleDb.OleDbType.VarWChar, 50, "TenKH"))
            cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("KyHieu", System.Data.OleDb.OleDbType.VarWChar, 0, "KyHieu"))

            cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_KH_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "KH_ID", System.Data.DataRowVersion.Original, Nothing))

            cmSQL.Parameters("TenKH").Value = Me.txtTenKH.Text
            cmSQL.Parameters("KyHieu").Value = mKyHieu

            cmSQL.Parameters("Original_KH_ID").Value = myThumbNails.Item(myThumbNails.SelectedIndex).ID

            intRowsAffected = cmSQL.ExecuteNonQuery()

            If intRowsAffected <> 1 Then
                MsgBox("Update Failed.", MsgBoxStyle.Critical, "Update")
            End If

            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

            bKQ = True
        Catch e As OleDbException
            MsgBox(strSQL)
            MsgBox(e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try

        Return bKQ

    End Function

    Public Sub DeleteKyHieu(ByVal aThumbNail As CThumbNail)
        Dim bKQ As Boolean = False
        Dim cnSQL As OleDbConnection
        Dim cmSQL As OleDbCommand
        Dim strSQL As String
        Dim intRowsAffected As Integer

        Try
            strSQL = "DELETE FROM tblKyHieu " & _
                     "WHERE KH_ID = " & aThumbNail.ID

            cnSQL = New OleDbConnection(myKHConnStr)
            cnSQL.Open()

            cmSQL = New OleDbCommand(strSQL, cnSQL)
            intRowsAffected = cmSQL.ExecuteNonQuery()

            If intRowsAffected <> 1 Then
                MsgBox("Delete Failed. KyHieu ID " & aThumbNail.ID & _
                       " not found.", MsgBoxStyle.Critical, "Delete")
            Else
                bKQ = True
            End If

            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

        Catch e As OleDbException
            MsgBox(e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try

        If bKQ Then
            Me.myThumbNails.Remove(aThumbNail)
            Me.myThumbNails.CalculateRowsAndColumns()
            Me.picThumbNails.Invalidate()
        End If

    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        Try
            Dim g As Graphics = e.Graphics
            'g.SmoothingMode = SmoothingMode.AntiAlias

            ControlPaint.DrawGrid(g, GridRect, GridSize, Color.Red)

            With m_drawingObjects
                .DrawObjects(g, myScale)
                .DrawSelectedObject(g, m_SelectedObject, myScale)
            End With

            If m_DrawTool = VeTools.RotateShape Then
                DrawMuiTen(g)
            End If

            If m_DrawTool = VeTools.ScaleShape Then
                DrawMuiTen(g)
            End If

            If m_DrawTool = VeTools.DangSplit Then
                DrawSplitLine(g)
            End If

            If selectionDragging Then
                DrawSelectionRectangle(g, selectionRect)
            End If

            If DrawingDragging Then
                'DrawDrawingRectangle(g, DrawingRect)
                If m_DrawTool = VeTools.Cycle Then
                    DrawDrawingEllipse(g, DrawingRect)
                ElseIf m_DrawTool = VeTools.Pie Then
                    DrawDrawingPie(g, DrawingRect)
                End If
            End If

            If DrawingPicking Then
                If myPts.GetUpperBound(0) > 0 Then
                    DrawDrawingLine(g, myPts)
                End If
            End If

            If m_selectedObjects.Count > 0 Then
                'Dim mObj As GraphicObject
                For Each mObj As GraphicObject In m_selectedObjects
                    m_selectedObjects.DrawSelectedObject(g, mObj, myScale)
                Next
            End If

            If m_DrawTool = VeTools.Edit Then
                DrawEditNodes(g)
            End If

            If m_DrawTool = VeTools.ChangeRoot Then
                DrawDrawingRoot(g, New PointF(myRootX, myRootY))
            End If

        Catch ex As System.Exception
            Debug.WriteLine(ex.ToString)
            Throw New System.ApplicationException("Error Drawing Graphics Surface", ex)
        End Try
    End Sub

    Private Sub PictureBox2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox2.Paint
        'Try
        Dim g As Graphics = e.Graphics
        'g.SmoothingMode = SmoothingMode.AntiAlias

        m_drawingObjects.DrawObjects(g, 1)

        'Catch ex As System.Exception
        '    Debug.WriteLine(ex.ToString)
        '    Throw New System.ApplicationException("Error Drawing Graphics Surface", ex)
        'End Try

    End Sub

    Public Sub SetScrollBarValues(ByVal pImageSize As Size)
        ' Set the Maximum, Minimum, LargeChange and SmallChange properties.
        Me.VScrollBar1.Minimum = 0
        Me.HScrollBar1.Minimum = 0
        Me.VScrollBar1.Maximum = 0
        Me.HScrollBar1.Maximum = 0

        ' If the offset does not make the Maximum less than zero, set its value.
        If pImageSize.Width - Me.Panel2.ClientSize.Width > 0 Then
            Me.HScrollBar1.Maximum = pImageSize.Width - Me.Panel2.ClientSize.Width
        End If
        ' If the VScrollBar is visible, adjust the Maximum of the 
        ' HSCrollBar to account for the width of the VScrollBar.
        If Me.VScrollBar1.Visible Then
            Me.HScrollBar1.Maximum += Me.VScrollBar1.Width
        End If
        Me.HScrollBar1.LargeChange = Me.HScrollBar1.Maximum * Me.Panel2.ClientSize.Width / pImageSize.Width '/ 2
        Me.HScrollBar1.SmallChange = Me.HScrollBar1.Maximum / 20
        ' Adjust the Maximum value to make the raw Maximum value attainable by user interaction.
        Me.HScrollBar1.Maximum += Me.HScrollBar1.LargeChange

        ' If the offset does not make the Maximum less than zero, set its value.
        If pImageSize.Height - Me.Panel2.ClientSize.Height > 0 Then
            Me.VScrollBar1.Maximum = pImageSize.Height - Me.Panel2.ClientSize.Height
        End If
        ' If the HScrollBar is visible, adjust the Maximum of the 
        ' VSCrollBar to account for the width of the HScrollBar.
        If Me.HScrollBar1.Visible Then
            Me.VScrollBar1.Maximum += Me.HScrollBar1.Height
        End If
        Me.VScrollBar1.LargeChange = Me.VScrollBar1.Maximum * Me.Panel2.ClientSize.Height / pImageSize.Height '/ 2
        Me.VScrollBar1.SmallChange = Me.VScrollBar1.Maximum / 20
        ' Adjust the Maximum value to make the raw Maximum value attainable by user interaction.
        Me.VScrollBar1.Maximum += Me.VScrollBar1.LargeChange
    End Sub

    Private Sub VScrollBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VScrollBar1.ValueChanged
        'Me.StatusBarPanel2.Text = "vScrollBar Value:(OnValueChanged Event) " & VScrollBar1.Value.ToString()
        pointTL.Y = -VScrollBar1.Value
        Me.PictureBox1.Location = pointTL
    End Sub

    Public Sub DisplayScrollBars()
        HScrollBar1.Value = 0
        VScrollBar1.Value = 0
        pointTL.X = 0
        pointTL.Y = 0

        ' Display or hide the scroll bars based upon  
        ' whether the image is larger than the PictureBox.
        If PictureBox1.Visible = True Then
            Me.PictureBox1.Location = pointTL
            Me.PictureBox1.Size = New Size(myWidth * myScale, myHeight * myScale)

            If Me.Panel2.Width > PictureBox1.Width Then
                HScrollBar1.Visible = False
            Else
                HScrollBar1.Visible = True
            End If

            If Me.Panel2.Height > PictureBox1.Height Then
                VScrollBar1.Visible = False
            Else
                VScrollBar1.Visible = True
            End If

            If VScrollBar1.Visible = True Then
                HScrollBar1.Width = Me.Panel2.ClientSize.Width - Me.VScrollBar1.Width
            Else
                HScrollBar1.Width = Me.Panel2.ClientSize.Width
            End If
            If HScrollBar1.Visible = True Then
                VScrollBar1.Height = Me.Panel2.ClientSize.Height - Me.HScrollBar1.Height
            Else
                VScrollBar1.Height = Me.Panel2.ClientSize.Height
            End If
        End If

        SetScrollBarValues(New Size(myWidth * myScale, myHeight * myScale))
    End Sub 'DisplayScrollBars


    Private Sub HScrollBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
        'Me.StatusBarPanel2.Text = "hScrollBar Value:(OnValueChanged Event) " & HScrollBar1.Value.ToString()
        pointTL.X = -HScrollBar1.Value
        Me.PictureBox1.Location = pointTL

    End Sub

    Private Sub Panel2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Resize
        DisplayScrollBars()
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dragOffset.Y += m_drawingObjects.GetSize.Height
    End Sub

    Public Overloads Function gscTogoc(ByVal gsPT As Point) As PointF
        Dim myNewPoint As PointF
        myNewPoint.X = CInt((gsPT.X) / myScale)
        myNewPoint.Y = CInt((gsPT.Y) / myScale)
        Return myNewPoint
    End Function

    Private Overloads Function gscTogoc( _
            ByVal X As Integer, ByVal Y As Integer) As PointF
        Dim myNewPoint As PointF
        myNewPoint.X = CInt((X) / myScale)
        myNewPoint.Y = CInt((Y) / myScale)
        Return myNewPoint
    End Function

    Private Sub DrawSelectionRectangle(ByVal g As Graphics, _
            ByVal selectionRect As RectangleF)

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

    Private Sub DrawDrawingRectangle(ByVal g As Graphics, _
            ByVal DrawingRect As Rectangle)

        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 1)
        Dim normalizedRectangle As Rectangle

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

        Dim gCon As Drawing2D.GraphicsContainer
        Dim myOriginalMatrix As Drawing2D.Matrix
        myOriginalMatrix = g.Transform()
        gCon = g.BeginContainer
        g.PageUnit = GraphicsUnit.Pixel
        g.ScaleTransform(myScale, myScale)
        g.DrawRectangle(DrawingPen, normalizedRectangle)

        DrawingPen.Dispose()

        g.EndContainer(gCon)
        g.Transform = myOriginalMatrix

    End Sub

    Private Function DrawDrawingPie(ByVal g As Graphics, _
            ByVal DrawingRect As Rectangle) As Boolean
        Dim mKQ As Boolean = False
        'Dim selectionBrush As New SolidBrush(Color.FromArgb(75, Color.Gray))
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 1)

        Dim mRect As Rectangle = New Rectangle(DrawingRect.Left - DrawingRect.Width, _
        DrawingRect.Top - DrawingRect.Height, _
        DrawingRect.Width * 2, DrawingRect.Height * 2)

        Dim gCon As Drawing2D.GraphicsContainer
        Dim myOriginalMatrix As Drawing2D.Matrix
        myOriginalMatrix = g.Transform()
        gCon = g.BeginContainer
        g.PageUnit = GraphicsUnit.Pixel
        g.ScaleTransform(myScale, myScale)
        Try
            If defaPieArc = True Then
                g.DrawArc(DrawingPen, mRect, defaPieStartA, defaPieSweepA)
            Else
                g.DrawPie(DrawingPen, mRect, defaPieStartA, defaPieSweepA)
            End If
            mKQ = True
        Catch
        End Try
        DrawingPen.Dispose()

        g.EndContainer(gCon)
        g.Transform = myOriginalMatrix

        Return mKQ
    End Function

    Private Sub DrawDrawingEllipse(ByVal g As Graphics, _
            ByVal DrawingRect As Rectangle)

        'Dim selectionBrush As New SolidBrush(Color.FromArgb(75, Color.Gray))
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 1)

        Dim gCon As Drawing2D.GraphicsContainer
        Dim myOriginalMatrix As Drawing2D.Matrix

        myOriginalMatrix = g.Transform()
        gCon = g.BeginContainer
        g.PageUnit = GraphicsUnit.Pixel
        g.ScaleTransform(myScale, myScale)
        g.DrawEllipse(DrawingPen, DrawingRect)

        DrawingPen.Dispose()

        g.EndContainer(gCon)
        g.Transform = myOriginalMatrix

    End Sub

    Private Sub DrawDrawingLine(ByVal g As Graphics, _
            ByVal pPts() As PointF)

        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 1)

        Dim gCon As Drawing2D.GraphicsContainer
        Dim myOriginalMatrix As Drawing2D.Matrix
        myOriginalMatrix = g.Transform()
        gCon = g.BeginContainer
        'g.PageUnit = GraphicsUnit.Pixel
        g.ScaleTransform(myScale, myScale)
        Select Case m_DrawTool
            Case VeTools.Line
                g.DrawLines(DrawingPen, pPts)
            Case VeTools.Polygon
                g.DrawPolygon(DrawingPen, pPts)
            Case VeTools.Curve
                g.DrawCurve(DrawingPen, pPts)
            Case VeTools.ClosedCurve
                If pPts.GetUpperBound(0) > 1 Then
                    g.DrawClosedCurve(DrawingPen, pPts)
                Else
                    g.DrawLines(DrawingPen, pPts)
                End If
        End Select

        DrawingPen.Dispose()

        g.EndContainer(gCon)
        g.Transform = myOriginalMatrix

    End Sub

    Private Sub DrawEditNodes(ByVal g As Graphics)
        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer

        Try
            g.ScaleTransform(myScale, myScale)

            EditObj.DrawNodes(g)
        Catch
        End Try

        g.EndContainer(gCon)
    End Sub

    Private Sub DrawMuiTen(ByVal g As Graphics)
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 1)
        DrawingPen.EndCap = LineCap.ArrowAnchor
        DrawingPen.StartCap = LineCap.RoundAnchor

        Dim gCon As Drawing2D.GraphicsContainer
        Dim myOriginalMatrix As Drawing2D.Matrix
        myOriginalMatrix = g.Transform()
        gCon = g.BeginContainer
        g.ScaleTransform(myScale, myScale)

        g.DrawLine(DrawingPen, myrootPt, mytoPt)

        DrawingPen.Dispose()

        g.EndContainer(gCon)
        g.Transform = myOriginalMatrix
    End Sub

    Private Sub DrawSplitLine(ByVal g As Graphics)
        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Gray), 1)
        DrawingPen.EndCap = LineCap.ArrowAnchor
        DrawingPen.StartCap = LineCap.RoundAnchor

        Dim gCon As Drawing2D.GraphicsContainer
        Dim myOriginalMatrix As Drawing2D.Matrix
        myOriginalMatrix = g.Transform()
        gCon = g.BeginContainer
        g.ScaleTransform(myScale, myScale)

        g.DrawLine(DrawingPen, myfromPt, mytoPt)

        DrawingPen.Dispose()

        g.EndContainer(gCon)
        g.Transform = myOriginalMatrix
    End Sub


    Protected Function DeZoomRectangle(ByVal originalRect As RectangleF) As RectangleF
        Dim myNewRect As New RectangleF(originalRect.X / myScale, _
                originalRect.Y / myScale, _
                originalRect.Width / myScale, _
                originalRect.Height / myScale)
        Return myNewRect
    End Function

    Public Sub OnNodesEdit()
        If Not m_SelectedObject Is Nothing Then
            EditObj = m_SelectedObject
            EditObj.Reset()
            iEditNode = -1
            m_SelectedObject = Nothing
            m_DrawTool = VeTools.Edit
            Me.StatusBarPanel1.Text = "Nodes Edit"
            Me.StatusBarPanel2.Text = "Kéo các nút nhỏ để tinh chỉnh. (RightClick để chọn Menu)"

            Me.PictureBox1.Invalidate()
        Else
            'm_DrawTool = VeTools.None
            'UpdateTB("")
            OnCapNhatCT()

            EditObj = Nothing
            iEditNode = -1
            MsgBox("ko co selEditObj")
        End If
    End Sub

    Private Sub MnuNodesEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuNodesEdit.Click
        'm_DrawTool = VeTools.Edit
        OnNodesEdit()
    End Sub

    Private Sub MnuMoveShape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuMoveShape.Click
        m_DrawTool = VeTools.Move
        Me.StatusBarPanel1.Text = "Move"
        Me.StatusBarPanel2.Text = "Move: di chuột để di chuyển"
    End Sub

    Private Sub MnuGroupMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuGroupMove.Click
        m_DrawTool = VeTools.GroupMove
        Me.StatusBarPanel1.Text = "GroupMove"
        Me.StatusBarPanel2.Text = "GroupMove: di chuột để di chuyển"
    End Sub

    Private Sub myThumbNails_SelectedIndexChanged(ByVal e As System.EventArgs) Handles myThumbNails.SelectedIndexChanged
        PopulateForm()

        Dim mTyle As Single = fMain.GetTyleLayKH()
        m_OdrawingObjects = GetTyLeGObjs(m_drawingObjects, mTyle)
        myORootX = myRootX * mTyle
        myORootY = myRootY * mTyle
    End Sub

    Private Sub DBiCombo1_DaChon1(ByVal IdValue As Long, ByVal TxtValue As String) Handles DBiCombo1.DaChon
        myLoaiKH_ID = IdValue
        PopulateList(myLoaiKH_ID)
        PopulateForm()
    End Sub

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

    Private Sub mnuFlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFlip.Click
        Dim mRect As RectangleF = m_SelectedObject.GetBounds
        Dim mX0 As Single = (mRect.Left + mRect.Right) / 2
        m_SelectedObject.VFlip(mX0)
        PictureBox1.Invalidate()
        PictureBox2.Invalidate()
    End Sub

    Private Sub mnuClosedCurveToCurve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClosedCurveToCurve.Click
        If m_SelectedObject.GetObjType = OBJECTTYPE.ClosedCurve Then
            m_drawingObjects.MoClosedCurve(m_SelectedObject)
            PictureBox1.Invalidate()
            PictureBox2.Invalidate()
        Else
            MsgBox("Chi lam duoc voi ClosedCurve thoi")
        End If
    End Sub

    Private Sub mnuCurveToClosedCurve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCurveToClosedCurve.Click
        If m_SelectedObject.GetObjType = OBJECTTYPE.Curve Then
            m_drawingObjects.DongCurve(m_SelectedObject)
            PictureBox1.Invalidate()
            PictureBox2.Invalidate()
        Else
            MsgBox("Chi lam duoc voi Curve thoi")
        End If
    End Sub

    Private Sub mnu1stNode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu1stNode.Click
        'EditObj.ChangeNodeType(iEditNode2)
        If EditObj.GetObjType = OBJECTTYPE.ClosedCurve Then
            Dim mCCurve As ClosedCurveGraphic = CType(EditObj, ClosedCurveGraphic)
            mCCurve.To1stNode(iEditNode2)
            PictureBox1.Invalidate()
            PictureBox2.Invalidate()
        Else
            MsgBox("Chi lam duoc voi ClosedCurve thoi")
        End If

    End Sub

    Private Sub cmnuKichThuoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuKichThuoc.Click
        Dim f As New dlgThumbnailOption
        f.txtImageWidth.Text = myThumbNails.ImageWidth
        f.txtImageHeight.Text = myThumbNails.ImageHeight
        f.txtHorizontalSpacing.Text = myThumbNails.HorizontalSpacing
        f.txtVerticalSpacing.Text = myThumbNails.VerticalSpacing

        If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Try
                myThumbNails.ImageWidth = f.txtImageWidth.Text
                myThumbNails.ImageHeight = f.txtImageHeight.Text
                myThumbNails.HorizontalSpacing = f.txtHorizontalSpacing.Text
                myThumbNails.VerticalSpacing = f.txtVerticalSpacing.Text

                PopulateList(myLoaiKH_ID)

                defaImageWidth = myThumbNails.ImageWidth
                defaImageHeight = myThumbNails.ImageHeight
                defaHorizontalSpacing = myThumbNails.HorizontalSpacing
                defaVerticalSpacing = myThumbNails.VerticalSpacing
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub MnuGroupScale_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuGroupScale.Click
        m_DrawTool = VeTools.GroupScale
        Me.StatusBarPanel1.Text = "GroupScale"
        Me.StatusBarPanel2.Text = "GroupScale: di chuột để thu, phóng"

    End Sub

    Private Sub mnuGroupAllMove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGroupAllMove.Click
        m_EditingObjects.Clear()
        'Dim mObj As GraphicObject
        For Each mObj As GraphicObject In m_drawingObjects
            m_EditingObjects.Add(mObj)
        Next

        m_DrawTool = VeTools.GroupMove
        Me.StatusBarPanel1.Text = "GroupMove"
        Me.StatusBarPanel2.Text = "GroupMove: di chuột để di chuyển"

    End Sub

    Private Sub mnuGroupAllScale_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGroupAllScale.Click
        m_EditingObjects.Clear()
        'Dim mObj As GraphicObject
        For Each mObj As GraphicObject In m_drawingObjects
            m_EditingObjects.Add(mObj)
        Next

        m_DrawTool = VeTools.GroupScale
        Me.StatusBarPanel1.Text = "GroupScale"
        Me.StatusBarPanel2.Text = "GroupScale: di chuột để thu, phóng"
    End Sub

    Private Sub GetSize(ByVal xmlFrag As String)
        Dim nt As NameTable = New NameTable
        Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(nt)
        nsmgr.AddNamespace("bk", "urn:sample")

        'Create the XmlParserContext.
        Dim context As XmlParserContext = New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.None)

        'Create the reader. 
        Dim rr As XmlTextReader = New XmlTextReader(xmlFrag, XmlNodeType.Element, context)

        'Dim strResult As String = ""
        Dim oNodeType As XmlNodeType

        Dim mWidth As Integer = MinW
        Dim mHeight As Integer = MinH
        Dim mCX As Integer = 0
        Dim mCY As Integer = 0

        Do While rr.Read
            oNodeType = rr.NodeType
            Select Case oNodeType
                Case XmlNodeType.Element
                    Select Case rr.Name
                        Case "KyHieu"
                            If rr.AttributeCount > 0 Then
                                Do While rr.MoveToNextAttribute
                                    Select Case rr.Name
                                        Case "W"
                                            mWidth = CInt(rr.Value)
                                        Case "H"
                                            mHeight = CInt(rr.Value)
                                        Case "CX"
                                            mCX = CInt(rr.Value)
                                        Case "CY"
                                            mCY = CInt(rr.Value)
                                    End Select
                                Loop

                            End If
                    End Select
            End Select
        Loop

        rr.Close()

        myWidth = mWidth
        myHeight = mHeight
        myRootX = mCX
        myRootY = mCY
    End Sub

    Private Function Objects2String(ByVal pWidth As Integer, ByVal pHeight As Integer, ByVal pRootX As Integer, ByVal pRootY As Integer, ByVal pGObjs As CGraphicObjs) As String
        Dim i As Integer
        Dim sw As New StringWriter

        Dim mType As OBJECTTYPE  'String
        Dim mShapeObj As ShapeGraphic
        Dim mTextObj As TextGraphic
        Dim mImageObj As EmbeddedImageGraphic

        'Dim mNode As CNODE
        Dim wr As XmlTextWriter = New XmlTextWriter(sw)

        wr.WriteStartElement("KyHieu")
        wr.WriteAttributeString("W", pWidth.ToString)
        wr.WriteAttributeString("H", pHeight.ToString)
        wr.WriteAttributeString("CX", pRootX.ToString)
        wr.WriteAttributeString("CY", pRootY.ToString)

        For Each mPart As GraphicObject In pGObjs
            wr.WriteStartElement("Part")
            mType = mPart.GetObjType
            wr.WriteAttributeString("Type", mType.ToString)
            If mType = OBJECTTYPE.Text Then
                mTextObj = CType(mPart, TextGraphic)
                wr.WriteAttributeString("Text", mTextObj.Text)
                wr.WriteAttributeString("FName", mTextObj.Font.Name)
                wr.WriteAttributeString("FSize", mTextObj.Font.Size.ToString)
                wr.WriteAttributeString("FStyle", mTextObj.Font.Style.ToString)
                wr.WriteAttributeString("FColor", mTextObj.Color.ToArgb)

                wr.WriteStartElement("Pos")
                wr.WriteAttributeString("X", mTextObj.X.ToString)
                wr.WriteAttributeString("Y", mTextObj.Y.ToString)
                wr.WriteAttributeString("A", mTextObj.Rotation.ToString)
                wr.WriteEndElement()
            ElseIf mType = OBJECTTYPE.EmbeddedImage Then
                mImageObj = CType(mPart, EmbeddedImageGraphic)
                wr.WriteAttributeString("ITYPE", mImageObj.ImageType)
                wr.WriteAttributeString("IMAGEW", mImageObj.Width.ToString)
                wr.WriteAttributeString("IMAGEH", mImageObj.Height.ToString)
                If mImageObj.Transparent = True Then
                    wr.WriteAttributeString("Transparent", mImageObj.Transparent.ToString)
                    wr.WriteAttributeString("TransparentColor", mImageObj.TransparentColor.ToArgb)
                End If

                Dim strImage As String = ""
                Select Case mImageObj.ImageType
                    Case "wmf", "emf", "kro"
                        Try
                            Dim mFileName = "tmp.kro"
                            Dim mMetaFile As Image = mImageObj.Image
                            mMetaFile.Save(mFileName)
                            Dim arrImageByte As Byte() = GetarrImage(mFileName)
                            strImage = Convert.ToBase64String(arrImageByte)
                        Catch ex As Exception
                            MsgBox("kro sai: " & ex.Message)
                        End Try
                    Case Else
                        Dim memStream As New MemoryStream '(1024)
                        mImageObj.Image.Save(memStream, Imaging.ImageFormat.Bmp)
                        strImage = Convert.ToBase64String(memStream.ToArray)
                End Select
                wr.WriteAttributeString("IMAGE", strImage)

                wr.WriteStartElement("Pos")
                wr.WriteAttributeString("X", mImageObj.X.ToString)
                wr.WriteAttributeString("Y", mImageObj.Y.ToString)
                wr.WriteAttributeString("A", mImageObj.Rotation.ToString)
                wr.WriteEndElement()
            Else
                mShapeObj = CType(mPart, ShapeGraphic)
                wr.WriteAttributeString("Color", mShapeObj.LineColor.ToArgb)
                wr.WriteAttributeString("Width", mShapeObj.LineWidth.ToString)
                If mShapeObj.LineStyle > 0 Then
                    wr.WriteAttributeString("Style", mShapeObj.LineStyle.ToString)
                    wr.WriteAttributeString("SWidth", mShapeObj.StyleWidth.ToString)
                End If

                If mShapeObj.Line2Width > 0 Then
                    wr.WriteAttributeString("Color2", mShapeObj.Line2Color.ToArgb)
                    wr.WriteAttributeString("Width2", mShapeObj.Line2Width.ToString)
                End If

                'If Not mPart.DValues Is Nothing Then
                If mShapeObj.DValues.Length > 0 Then
                    wr.WriteAttributeString("DV", mShapeObj.DValues)
                End If
                If mShapeObj.Fill = True Then
                    wr.WriteAttributeString("Fill", mShapeObj.Fill.ToString)
                    wr.WriteAttributeString("FColor", mShapeObj.FillColor.ToArgb)
                    wr.WriteAttributeString("HColor", mShapeObj.HatchColor.ToArgb)
                    wr.WriteAttributeString("HStyle", mShapeObj.HatchStyle.ToString)
                End If

                If mType = OBJECTTYPE.Ellipse Then
                    Dim mEllipseObj As EllipseGraphic = CType(mShapeObj, EllipseGraphic)

                    wr.WriteStartElement("Rect")
                    wr.WriteAttributeString("X", mEllipseObj.X.ToString)
                    wr.WriteAttributeString("Y", mEllipseObj.Y.ToString)
                    wr.WriteAttributeString("W", mEllipseObj.Width.ToString)
                    wr.WriteAttributeString("H", mEllipseObj.Height.ToString)
                    wr.WriteAttributeString("A", mEllipseObj.Rotation.ToString)
                    wr.WriteEndElement()
                ElseIf mType = OBJECTTYPE.Pie Then
                    Dim mPieObj As PieGraphic = CType(mShapeObj, PieGraphic)

                    wr.WriteStartElement("Pie")
                    wr.WriteAttributeString("X", mPieObj.X.ToString)
                    wr.WriteAttributeString("Y", mPieObj.Y.ToString)
                    wr.WriteAttributeString("W", mPieObj.Width.ToString)
                    wr.WriteAttributeString("H", mPieObj.Height.ToString)
                    wr.WriteAttributeString("ST", mPieObj.StartAngle.ToString)
                    wr.WriteAttributeString("SW", mPieObj.SweepAngle.ToString)
                    If mPieObj.IsArc = True Then
                        wr.WriteAttributeString("ARC", mPieObj.IsArc.ToString)
                    End If
                    wr.WriteAttributeString("A", mPieObj.Rotation.ToString)
                    wr.WriteEndElement()
                Else
                    i = 0
                    Dim mNodesShapeObj As NodesShapeGraphic = CType(mShapeObj, NodesShapeGraphic)

                    For Each mNode As CNODE In mNodesShapeObj.Nodes
                        i += 1
                        wr.WriteStartElement("Node")
                        wr.WriteAttributeString("X", mNode.Pt.X.ToString)
                        wr.WriteAttributeString("Y", mNode.Pt.Y.ToString)
                        If mNode.IsControl = True Then
                            wr.WriteAttributeString("Type", mNode.IsControl.ToString)
                        End If
                        wr.WriteElementString("i", i.ToString)
                        wr.WriteEndElement()
                    Next
                End If
            End If
            wr.WriteEndElement()
        Next mPart

        wr.WriteEndElement()

        wr.Close()

        Return sw.ToString()
    End Function

    Private Function GetarrImage(ByVal mFileName As String) As Byte()
        Dim arrByte() As Byte = Nothing

        If mFileName.Length > 0 Then

            Dim fs As New FileStream(mFileName, FileMode.Open)
            Dim r As New BinaryReader(fs)
            Dim fsCount As Integer = fs.Length

            arrByte = r.ReadBytes(fsCount)

            fs.Close()

        End If

        Return arrByte
    End Function

    Private Sub DrawDrawingRoot(ByVal g As Graphics, ByVal pPt As PointF)

        Dim DrawingPen As New Pen(Color.FromArgb(75, Color.Black), 1)

        Dim gCon As Drawing2D.GraphicsContainer
        Dim myOriginalMatrix As Drawing2D.Matrix
        myOriginalMatrix = g.Transform()
        gCon = g.BeginContainer
        g.ScaleTransform(myScale, myScale)

        g.DrawLine(DrawingPen, pPt.X - 2, pPt.Y - 2, pPt.X + 2, pPt.Y + 2)
        g.DrawLine(DrawingPen, pPt.X - 2, pPt.Y + 2, pPt.X + 2, pPt.Y - 2)

        DrawingPen.Dispose()

        g.EndContainer(gCon)
        g.Transform = myOriginalMatrix

    End Sub

    Private Function RootHitTest(ByVal pt As PointF) As Boolean
        Dim r As New RectangleF(myRootX - 3, myRootY - 3, 7, 7)
        Return r.Contains(pt)
    End Function

    Private Function GetMaxStt(ByVal pLoaiKH_ID As Integer) As Integer
        Dim kq As Integer = 0
        Dim cnSQL As OleDbConnection
        Dim cmSQL As OleDbCommand
        Dim drSQL As OleDbDataReader
        Dim strSQL As String

        Try
            strSQL = "SELECT Stt"
            strSQL &= " FROM tblKyHieu"
            strSQL &= " WHERE tblKyHieu.LoaiKH_ID = " & pLoaiKH_ID
            strSQL &= " ORDER BY tblKyHieu.Stt"
            cnSQL = New OleDbConnection(myKHConnStr)
            cnSQL.Open()

            cmSQL = New OleDbCommand(strSQL, cnSQL)
            drSQL = cmSQL.ExecuteReader()

            Do While drSQL.Read()
                'Me.myThumbNails.Add(New CThumbNail(drSQL.Item("TenKH").ToString(), CInt(drSQL.Item("KH_ID")), drSQL.Item("KyHieu")))
                kq = CInt(drSQL.Item(0))
            Loop

            drSQL.Close()
            cmSQL.Dispose()
            cnSQL.Close()
            cnSQL.Dispose()

        Catch e As OleDbException
            MsgBox(e.ErrorCode & ":" & e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try

        Return kq
    End Function

    Private Sub PopulateList(ByVal pLoaiKH_ID As Integer)
        'Try
        'RemoveHandler m_PicBox.Paint, AddressOf m_PicBox_Paint
        'Catch ex As Exception
        'End Try

        Dim cnSQL As OleDbConnection
        Dim cmSQL As OleDbCommand
        Dim drSQL As OleDbDataReader
        Dim strSQL As String

        Try
            'SELECT tblKyHieu.KH_ID, tblKyHieu.TenKH, tblKyHieu.KyHieu
            'FROM tblKyHieu LEFT JOIN tblLoaiKH ON tblKyHieu.LoaiKH_ID = tblLoaiKH.LoaiKH_ID
            'ORDER BY tblLoaiKH.MaLoaiKH, tblKyHieu.Stt;
            strSQL = "SELECT tblKyHieu.KH_ID, tblKyHieu.TenKH, tblKyHieu.KyHieu"
            strSQL &= " FROM tblKyHieu LEFT JOIN tblLoaiKH ON tblKyHieu.LoaiKH_ID = tblLoaiKH.LoaiKH_ID"
            If pLoaiKH_ID > 0 Then
                strSQL &= " WHERE tblKyHieu.LoaiKH_ID = " & pLoaiKH_ID
            End If
            strSQL &= " ORDER BY tblLoaiKH.MaLoaiKH, tblKyHieu.Stt"
            cnSQL = New OleDbConnection(myKHConnStr)
            cnSQL.Open()

            cmSQL = New OleDbCommand(strSQL, cnSQL)
            drSQL = cmSQL.ExecuteReader()

            Me.myThumbNails.Clear()

            Do While drSQL.Read()
                'objListItem = New CThumbNail(drSQL.Item("TenKH").ToString(), CInt(drSQL.Item("KH_ID")), drSQL.Item("KyHieu"))
                Me.myThumbNails.Add(New CThumbNail(drSQL.Item("TenKH").ToString(), CInt(drSQL.Item("KH_ID")), drSQL.Item("KyHieu")))
            Loop

            drSQL.Close()
            cmSQL.Dispose()
            cnSQL.Close()
            cnSQL.Dispose()

        Catch e As OleDbException
            MsgBox(e.ErrorCode & ":" & e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try


        'AddHandler m_PicBox.Paint, AddressOf m_PicBox_Paint
        'AddHandler m_PicBox.Resize, AddressOf m_PicBox_Resize
        If Me.myThumbNails.Count > 0 Then
            Me.myThumbNails.SelectedIndex = Me.myThumbNails.Count - 1
            Me.myThumbNails.SelectedIndex = 0
        Else
            Me.myThumbNails.SelectedIndex = -1
        End If
        Me.picThumbNails.Invalidate()
    End Sub

    Private Function UpdateSoTT(ByVal pKH_ID As Integer, ByVal pStt As Integer) As Boolean
        Dim bKQ As Boolean = False
        If Not IsValidForm() Then
            Return False
        End If

        Dim cnSQL As OleDbConnection
        Dim cmSQL As OleDbCommand
        Dim strSQL As String = ""
        Dim intRowsAffected As Integer

        Try
            strSQL = "UPDATE tblKyHieu SET"
            strSQL &= " Stt = ?"
            strSQL &= " WHERE KH_ID = ?"

            cnSQL = New OleDbConnection(myKHConnStr)
            cnSQL.Open()

            cmSQL = New OleDbCommand(strSQL, cnSQL)
            cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("Stt", System.Data.OleDb.OleDbType.Integer, 0, "Stt"))

            cmSQL.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_KH_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "KH_ID", System.Data.DataRowVersion.Original, Nothing))

            cmSQL.Parameters("Stt").Value = pStt

            cmSQL.Parameters("Original_KH_ID").Value = pKH_ID

            intRowsAffected = cmSQL.ExecuteNonQuery()

            If intRowsAffected <> 1 Then
                MsgBox("Update Failed.", MsgBoxStyle.Critical, "Update")
            End If

            cnSQL.Close()
            cmSQL.Dispose()
            cnSQL.Dispose()

            bKQ = True
        Catch e As OleDbException
            MsgBox(strSQL)
            MsgBox(e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try

        Return bKQ

    End Function

    Private Function SoTTisOK(ByVal pLoaiKH_ID As Integer) As Boolean
        Dim kq As Boolean = True

        Dim cnSQL As OleDbConnection
        Dim cmSQL As OleDbCommand
        Dim drSQL As OleDbDataReader
        Dim strSQL As String

        Try
            strSQL = "SELECT tblKyHieu.KH_ID, tblKyHieu.TenKH, tblKyHieu.Stt"
            strSQL &= " FROM tblKyHieu LEFT JOIN tblLoaiKH ON tblKyHieu.LoaiKH_ID = tblLoaiKH.LoaiKH_ID"
            If pLoaiKH_ID > 0 Then
                strSQL &= " WHERE tblKyHieu.LoaiKH_ID = " & pLoaiKH_ID
            End If
            strSQL &= " ORDER BY tblLoaiKH.MaLoaiKH, tblKyHieu.Stt"
            cnSQL = New OleDbConnection(myKHConnStr)
            cnSQL.Open()

            cmSQL = New OleDbCommand(strSQL, cnSQL)
            drSQL = cmSQL.ExecuteReader()

            'Me.myThumbNails.Clear()
            Dim mStt As Integer = 0
            Dim mPrevStt As Integer = 0
            Do While drSQL.Read()
                'Me.myThumbNails.Add(New CThumbNail(drSQL.Item("TenKH").ToString(), CInt(drSQL.Item("KH_ID")), drSQL.Item("KyHieu")))
                mStt = CInt(drSQL.Item("Stt"))
                If mStt = mPrevStt Then
                    kq = False
                    Exit Do
                End If
                mPrevStt = mStt
            Loop

            drSQL.Close()
            cmSQL.Dispose()
            cnSQL.Close()
            cnSQL.Dispose()

        Catch e As OleDbException
            MsgBox(e.ErrorCode & ":" & e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try

        Return kq

    End Function

    Private Function GetSoTT(ByVal pKH_ID As Integer) As Integer
        Dim kq As Integer = -1

        Dim cnSQL As OleDbConnection
        Dim cmSQL As OleDbCommand
        Dim drSQL As OleDbDataReader
        Dim strSQL As String

        Try
            strSQL = "SELECT tblKyHieu.Stt  FROM tblKyHieu"
            strSQL &= " WHERE tblKyHieu.KH_ID = " & pKH_ID
            cnSQL = New OleDbConnection(myKHConnStr)
            cnSQL.Open()

            cmSQL = New OleDbCommand(strSQL, cnSQL)
            drSQL = cmSQL.ExecuteReader()

            Do While drSQL.Read()
                kq = CInt(drSQL.Item("Stt"))
            Loop

            drSQL.Close()
            cmSQL.Dispose()
            cnSQL.Close()
            cnSQL.Dispose()

        Catch e As OleDbException
            MsgBox(e.ErrorCode & ":" & e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try

        Return kq

    End Function

    Private Sub DanhSoTT(ByVal pLoaiKH_ID As Integer)

        Dim cnSQL As OleDbConnection
        Dim cmSQL As OleDbCommand
        Dim drSQL As OleDbDataReader
        Dim strSQL As String

        Try
            strSQL = "SELECT tblKyHieu.KH_ID, tblKyHieu.TenKH, tblKyHieu.KyHieu"
            strSQL &= " FROM tblKyHieu LEFT JOIN tblLoaiKH ON tblKyHieu.LoaiKH_ID = tblLoaiKH.LoaiKH_ID"
            If pLoaiKH_ID > 0 Then
                strSQL &= " WHERE tblKyHieu.LoaiKH_ID = " & pLoaiKH_ID
            End If
            strSQL &= " ORDER BY tblLoaiKH.MaLoaiKH, tblKyHieu.Stt"
            cnSQL = New OleDbConnection(myKHConnStr)
            cnSQL.Open()

            cmSQL = New OleDbCommand(strSQL, cnSQL)
            drSQL = cmSQL.ExecuteReader()

            'Me.myThumbNails.Clear()
            Dim mStt As Integer = 0
            Do While drSQL.Read()
                'Me.myThumbNails.Add(New CThumbNail(drSQL.Item("TenKH").ToString(), CInt(drSQL.Item("KH_ID")), drSQL.Item("KyHieu")))
                mStt += 1
                UpdateSoTT(CInt(drSQL.Item("KH_ID")), mStt)
            Loop

            drSQL.Close()
            cmSQL.Dispose()
            cnSQL.Close()
            cnSQL.Dispose()

        Catch e As OleDbException
            MsgBox(e.ErrorCode & ":" & e.Message, MsgBoxStyle.Critical, "SQL Error")

        Catch e As Exception
            MsgBox(e.Message, MsgBoxStyle.Critical, "General Error")
        End Try

    End Sub

    Private Function GetFirstLoaiKH() As Long
        Dim lngKQ As Long = 0
        Dim strSQL As String
        strSQL = "SELECT LoaiKH_ID FROM tblLoaiKH"
        strSQL &= " WHERE Cuoi <> 0"
        strSQL &= " ORDER BY MaLoaiKH;"

        Try
            Dim myConn As New OleDbConnection(myKHConnStr)
            myConn.Open()

            Dim mCommand As New OleDbCommand(strSQL, myConn)
            Dim mReader As OleDbDataReader
            mReader = mCommand.ExecuteReader()

            While mReader.Read()
                lngKQ = mReader.GetValue(0)
                Exit While
            End While

            mReader.Close()
            myConn.Close()
            myConn = Nothing
        Catch
            'Finally
        End Try

        Return lngKQ
    End Function

    Private Sub MnuSplitShape_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuSplitShape.Click
        m_DrawTool = VeTools.Split
        Me.StatusBarPanel1.Text = "Split"
        Me.StatusBarPanel2.Text = "Cắt: di chuột để vẽ đường cắt."
    End Sub

    Private Function To2Objects(ByVal pObject As GraphicObject, ByVal pPT0 As PointF, ByVal pPT1 As PointF) As SPLITOBJECTS
        Dim mSPLITSYMBOLS As New SPLITOBJECTS
        mSPLITSYMBOLS.Obj1 = Nothing
        mSPLITSYMBOLS.Obj2 = Nothing

        Dim mA0 As Single

        Dim mPTs2(1) As PointF
        mPTs2(0) = pPT0 'myfromPt
        mPTs2(1) = pPT1 'mytoPt

        mA0 = AngleToPoint(mPTs2(0), mPTs2(1))

        Dim mObj As GraphicObject = ObjToCurve(pObject)
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
                'mGObjs1.Add(mObject)
                mSPLITSYMBOLS.Obj1 = mObject

                Dim mObject1 As CurveGraphic = mObj.Clone 'CType(mObj, CurveGraphic)
                mObject1.Nodes.Clear()
                For j As Integer = 0 To mPTS4O2.GetUpperBound(0)
                    Dim mNode As New CNODE(mPTS4O2(j))
                    mNode.IsControl = True
                    mObject1.Nodes.Add(mNode)
                Next
                'mGObjs2.Add(mObject1)
                mSPLITSYMBOLS.Obj2 = mObject1
            Else
                If AngleToPoint(mPTs2(0), mPTs(0)) > mA0 Then
                    'mGObjs1.Add(mObj1)
                    mSPLITSYMBOLS.Obj1 = pObject
                Else
                    'mGObjs2.Add(mObj1)
                    mSPLITSYMBOLS.Obj2 = pObject
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
                'mGObjs1.Add(mObject)
                mSPLITSYMBOLS.Obj1 = mObject

                Dim mObject1 As ClosedCurveGraphic = mObj.Clone 'New ClosedCurveGraphic(mPTS4O2, 1, Color.Blue)
                mObject1.Nodes.Clear()
                For j As Integer = 0 To mPTS4O2.GetUpperBound(0)
                    Dim mNode As New CNODE(mPTS4O2(j))
                    mNode.IsControl = True
                    mObject1.Nodes.Add(mNode)
                Next
                'mGObjs2.Add(mObject1)
                mSPLITSYMBOLS.Obj2 = mObject1
            Else
                If AngleToPoint(mPTs2(0), mPTs(0)) > mA0 Then
                    'mGObjs1.Add(mObj1)
                    mSPLITSYMBOLS.Obj1 = pObject
                Else
                    'mGObjs2.Add(mObj1)
                    mSPLITSYMBOLS.Obj2 = pObject
                End If
            End If
        Else
            Dim mPTs() As PointF = pObject.GetPoints
            If AngleToPoint(mPTs2(0), mPTs(0)) > mA0 Then
                'mGObjs1.Add(mObj1)
                mSPLITSYMBOLS.Obj1 = pObject
            Else
                'mGObjs2.Add(mObj1)
                mSPLITSYMBOLS.Obj2 = pObject
            End If
        End If

        Return mSPLITSYMBOLS
    End Function

    Private Sub PictureBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PictureBox1.KeyUp
        Select Case e.KeyCode
            Case Keys.Delete  '46 'Del
                'OnXoa()
                If Not IsNothing(m_SelectedObject) Then
                    m_drawingObjects.Remove(m_SelectedObject)
                    PictureBox1.Invalidate()
                    PictureBox2.Invalidate()
                End If
            Case Keys.Right
                If Not IsNothing(m_SelectedObject) Then
                    If ((Control.ModifierKeys And Keys.Control) = Keys.Control) And _
                    ((Control.ModifierKeys And Keys.Alt) = Keys.Alt) Then
                        Dim rect As RectangleF = m_SelectedObject.GetBounds
                        Dim dX As Single = (rect.Width + 1) / rect.Width
                        Dim dY As Single = 1 '(rect.Height + deltaY) / rect.Height
                        myrootPt = m_SelectedObject.GetCenter
                        m_SelectedObject.Zoom2(myrootPt, dX, dY)
                        Me.PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                        myfromPt = m_SelectedObject.GetCenter
                        mytoPt = myfromPt
                        mytoPt.X += 1
                        m_SelectedObject.Move(myfromPt, mytoPt)
                        Me.PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    ElseIf (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                        myrootPt = m_SelectedObject.GetCenter
                        m_SelectedObject.Rotate2(myrootPt, myTinhChinhGocQuay)
                        PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    End If
                End If
            Case Keys.Left
                If Not IsNothing(m_SelectedObject) Then
                    If ((Control.ModifierKeys And Keys.Control) = Keys.Control) And _
                    ((Control.ModifierKeys And Keys.Alt) = Keys.Alt) Then
                        Dim rect As RectangleF = m_SelectedObject.GetBounds
                        Dim dX As Single = (rect.Width - 1) / rect.Width
                        Dim dY As Single = 1 '(rect.Height + deltaY) / rect.Height
                        myrootPt = m_SelectedObject.GetCenter
                        m_SelectedObject.Zoom2(myrootPt, dX, dY)
                        Me.PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                        myfromPt = m_SelectedObject.GetCenter
                        mytoPt = myfromPt
                        mytoPt.X -= 1
                        m_SelectedObject.Move(myfromPt, mytoPt)
                        Me.PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    ElseIf (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                        myrootPt = m_SelectedObject.GetCenter
                        m_SelectedObject.Rotate2(myrootPt, -myTinhChinhGocQuay)
                        PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    End If
                End If
            Case Keys.Up
                If Not IsNothing(m_SelectedObject) Then
                    If ((Control.ModifierKeys And Keys.Control) = Keys.Control) And _
                    ((Control.ModifierKeys And Keys.Alt) = Keys.Alt) Then
                        Dim rect As RectangleF = m_SelectedObject.GetBounds
                        Dim dX As Single = 1
                        Dim dY As Single = (rect.Height + 1) / rect.Height
                        myrootPt = m_SelectedObject.GetCenter
                        m_SelectedObject.Zoom2(myrootPt, dX, dY)
                        Me.PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                        myfromPt = m_SelectedObject.GetCenter
                        mytoPt = myfromPt
                        mytoPt.Y -= 1
                        m_SelectedObject.Move(myfromPt, mytoPt)
                        Me.PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    ElseIf (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                    End If
                End If
            Case Keys.Down
                If Not IsNothing(m_SelectedObject) Then
                    If ((Control.ModifierKeys And Keys.Control) = Keys.Control) And _
                    ((Control.ModifierKeys And Keys.Alt) = Keys.Alt) Then
                        Dim rect As RectangleF = m_SelectedObject.GetBounds
                        Dim dX As Single = 1
                        Dim dY As Single = (rect.Height - 1) / rect.Height
                        myrootPt = m_SelectedObject.GetCenter
                        m_SelectedObject.Zoom2(myrootPt, dX, dY)
                        Me.PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    ElseIf (Control.ModifierKeys And Keys.Control) = Keys.Control Then
                        myfromPt = m_SelectedObject.GetCenter
                        mytoPt = myfromPt
                        mytoPt.Y += 1
                        m_SelectedObject.Move(myfromPt, mytoPt)
                        Me.PictureBox1.Invalidate()
                        PictureBox2.Invalidate()
                    ElseIf (Control.ModifierKeys And Keys.Alt) = Keys.Alt Then
                    End If
                End If
        End Select
    End Sub

    Private Sub mnuGroupAllPast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGroupAllPast.Click
        If Not IsNothing(fMain.myBando.SelectedSymbol) Then
            m_drawingObjects.Clear()
            Dim mLeft As Single = 0
            Dim mTop As Single = 0
            Dim mWidth As Single = 0
            Dim mHeight As Single = 0
            For Each obj As GraphicObject In fMain.myBando.SelectedSymbol.GObjs
                Dim mRect As RectangleF = obj.GetBounds
                If mRect.Left < mLeft Then mLeft = mRect.Left
                If mRect.Top < mTop Then mTop = mRect.Top
                If mRect.Width > mWidth Then mWidth = mRect.Width
                If mRect.Height > mHeight Then mHeight = mRect.Height
            Next
            myRootX = -mLeft
            myRootY = -mTop
            myWidth = mWidth
            myHeight = mHeight
            For Each obj As GraphicObject In fMain.myBando.SelectedSymbol.GObjs
                Dim oobj As GraphicObject = obj.Clone
                oobj.Move(New PointF(0, 0), New PointF(myRootX, myRootY))
                m_drawingObjects.Add(oobj)
            Next

            ThayDoiGrid()
            DisplayScrollBars()
            Me.PictureBox1.Invalidate()
            Me.PictureBox2.Invalidate()

        End If
    End Sub

    Public Sub CopyFromMap(ByVal pSymbol As CSymbol)
        If Not IsNothing(pSymbol) Then
            Dim mObjects As New CGraphicObjs
            Dim mLeft As Single = 0
            Dim mTop As Single = 0
            Dim mWidth As Single = 10
            Dim mHeight As Single = 10
            For Each obj As GraphicObject In pSymbol.GObjs
                Dim mRect As RectangleF = obj.GetBounds
                If mRect.Left < mLeft Then mLeft = mRect.Left
                If mRect.Top < mTop Then mTop = mRect.Top
                If mRect.Width > mWidth Then mWidth = mRect.Width
                If mRect.Height > mHeight Then mHeight = mRect.Height
            Next
            Dim mRootX As Integer = -mLeft
            Dim mRootY As Integer = -mTop
            For Each obj As GraphicObject In pSymbol.GObjs
                Dim oobj As GraphicObject = obj.Clone
                oobj.Move(New PointF(0, 0), New PointF(mRootX, mRootY))
                mObjects.Add(oobj)
            Next

            Dim mKyHieu As String = Objects2String(mWidth, mHeight, mRootX, mRootY, mObjects)
            'Dim mStt As Integer = myThumbNails.Count + 1
            Dim mStt = GetMaxStt(myLoaiKH_ID) + 1

            If AddKyHieu(mKyHieu, pSymbol.Description, myLoaiKH_ID, mStt) Then
                myThumbNails.SelectedIndex = myThumbNails.Count - 1
            End If
        End If
    End Sub

    Private Sub Panel3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel3.MouseUp
        fMain.myBando.NhanKHXong()
    End Sub

    Private Sub cmnuDeleteKH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuDeleteKH.Click
        If MessageBox.Show("Xóa ký hiệu này?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'DeleteKyHieu(myThumbNails.Item(myThumbNails.SelectedIndex))
            'myThumbNails_SelectedIndexChanged(Nothing)
            btnDelete_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmnuCopyTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmnuCopyTo.Click
        Dim f As New dlgCopyKH
        With f.DBiTraDM1
            .ConnStr = myKHConnStr
            .TableName = "tblLoaiKH"
            .MaFieldName = "MaLoaiKH"
            .TenFieldName = "TenLoaiKH"
            .CuoiFieldName = "Cuoi"
        End With

        If f.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim mKyHieu As String = Objects2String(myWidth, myHeight, myRootX, myRootY, m_drawingObjects)
            Dim mStt = GetMaxStt(f.txtLoaiKH_ID.Text) + 1
            AddKyHieu(mKyHieu, Me.txtTenKH.Text, f.txtLoaiKH_ID.Text, mStt)
        End If
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub btnUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUp.Click
        If myLoaiKH_ID > 0 Then
            If myThumbNails.SelectedIndex > 0 Then
                Dim mIndex As Integer = myThumbNails.SelectedIndex
                If Me.SoTTisOK(myLoaiKH_ID) = False Then
                    Me.DanhSoTT(myLoaiKH_ID)
                    'MsgBox("Danh Stt xong.")
                End If

                Dim mcurrKH_ID As Integer = myThumbNails.Item(myThumbNails.SelectedIndex).ID
                Dim mprevKH_ID As Integer = -1
                mprevKH_ID = myThumbNails.Item(myThumbNails.SelectedIndex - 1).ID
                Dim prevSoTT As Integer = GetSoTT(mprevKH_ID)
                Dim currSoTT As Integer = GetSoTT(mcurrKH_ID)
                Me.UpdateSoTT(mprevKH_ID, currSoTT)
                Me.UpdateSoTT(mcurrKH_ID, prevSoTT)
                PopulateList(myLoaiKH_ID)
                myThumbNails.SelectedIndex = mIndex - 1
                Me.myThumbNails.CalculateRowsAndColumns()
                Me.picThumbNails.Invalidate()
            End If
        Else
            MsgBox("Chỉ sắp xếp thứ tự trong từng nhóm!")
        End If
    End Sub

    Private Sub MnuGroupCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuGroupCopy.Click
        If m_EditingObjects.Count > 0 Then
            m_CopyObjects.Clear()
            For Each mObj As GraphicObject In m_EditingObjects
                Dim oobj As GraphicObject = mObj.Clone
                m_CopyObjects.Add(oobj)
            Next
        End If
        'MsgBox("m_CopyObjects=" & m_CopyObjects.Count.ToString)
    End Sub

    Private Sub mnuGroupPast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuGroupPast.Click
        'MsgBox("m_CopyObjects2=" & m_CopyObjects.Count.ToString)
        If m_CopyObjects.Count > 0 Then
            m_selectedObjects.Clear()
            For Each obj As GraphicObject In m_CopyObjects
                Dim oobj As GraphicObject = obj.Clone
                m_drawingObjects.Add(oobj)
                m_selectedObjects.Add(oobj)
            Next
            Me.PictureBox1.Invalidate()
            Me.PictureBox2.Invalidate()
        End If
    End Sub

    Private Sub MnuSendFront_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuSendFront.Click
        m_drawingObjects.SendFront(m_SelectedObject)
        PictureBox1.Invalidate()
        PictureBox2.Invalidate()
    End Sub

    Private Sub btnDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDown.Click
        If myLoaiKH_ID > 0 Then
            If myThumbNails.SelectedIndex < (myThumbNails.Count - 1) Then
                Dim mIndex As Integer = myThumbNails.SelectedIndex
                If Me.SoTTisOK(myLoaiKH_ID) = False Then
                    Me.DanhSoTT(myLoaiKH_ID)
                    'MsgBox("Danh Stt xong.")
                End If

                Dim mcurrKH_ID As Integer = myThumbNails.Item(myThumbNails.SelectedIndex).ID
                Dim mnextKH_ID As Integer = -1
                mnextKH_ID = myThumbNails.Item(myThumbNails.SelectedIndex + 1).ID
                Dim nextSoTT As Integer = GetSoTT(mnextKH_ID)
                Dim currSoTT As Integer = GetSoTT(mcurrKH_ID)
                Me.UpdateSoTT(mnextKH_ID, currSoTT)
                Me.UpdateSoTT(mcurrKH_ID, nextSoTT)
                PopulateList(myLoaiKH_ID)
                myThumbNails.SelectedIndex = mIndex + 1
                Me.myThumbNails.CalculateRowsAndColumns()
                Me.picThumbNails.Invalidate()
            End If
        Else
            MsgBox("Chỉ sắp xếp thứ tự trong từng nhóm!")
        End If
    End Sub
End Class
