Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Xml

Imports DBiGraphicObjs.DBiGraphicObjects

Public Class CFOUNDNODE
    Private m_FoundObject As GraphicObject
    Private m_NodeIndex As Integer
    'Private m_IsRoot As Boolean
    Property FoundObject() As GraphicObject
        Get
            Return m_FoundObject
        End Get
        Set(ByVal Value As GraphicObject)
            m_FoundObject = Value
        End Set
    End Property

    Property NodeIndex() As Integer
        Get
            Return m_NodeIndex
        End Get
        Set(ByVal Value As Integer)
            m_NodeIndex = Value
        End Set
    End Property
    'Property IsRoot() As Boolean
    '    Get
    '        Return m_IsRoot
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        m_IsRoot = Value
    '    End Set
    'End Property
End Class

Public Class CFOUNDOBJECT
    Private m_FoundObject As GraphicObject
    Private m_FoundSymbol As CSymbol
    Property FoundObject() As GraphicObject
        Get
            Return m_FoundObject
        End Get
        Set(ByVal Value As GraphicObject)
            m_FoundObject = Value
        End Set
    End Property

    Property FoundSymbol() As CSymbol
        Get
            Return m_FoundSymbol
        End Get
        Set(ByVal Value As CSymbol)
            m_FoundSymbol = Value
        End Set
    End Property
End Class

Public Class CSymbol
    Private m_GocX As Double
    Private m_GocY As Double
    Private m_Zoom As Double
    Private m_MWidth As Single
    Private m_GObjs As CGraphicObjs
    Private m_Description As String
    Private m_Blinking As Boolean
    Public Xfile As String = ""

    Property Blinking() As Boolean
        Get
            Return m_Blinking
        End Get
        Set(ByVal Value As Boolean)
            m_Blinking = Value
        End Set
    End Property

    Property Description() As String
        Get
            Return m_Description
        End Get
        Set(ByVal Value As String)
            m_Description = Value
        End Set
    End Property

    Property GocX() As Double
        Get
            Return m_GocX
        End Get
        Set(ByVal Value As Double)
            m_GocX = Value
        End Set
    End Property

    Property GocY() As Double
        Get
            Return m_GocY
        End Get
        Set(ByVal Value As Double)
            m_GocY = Value
        End Set
    End Property

    Property GObjs() As CGraphicObjs
        Get
            Return m_GObjs
        End Get
        Set(ByVal Value As CGraphicObjs)
            m_GObjs = Value
        End Set
    End Property

    Property Zoom() As Double
        Get
            Return m_Zoom
        End Get
        Set(ByVal Value As Double)
            m_Zoom = Value
        End Set
    End Property

    Property MWidth() As Single
        Get
            Return m_MWidth
        End Get
        Set(ByVal Value As Single)
            m_MWidth = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return m_Description
    End Function

    Public Sub Draw(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics)
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(mX, mY)
        g.ScaleTransform(Scale, Scale)

        For Each mGObj As GraphicObject In m_GObjs
            mGObj.Draw(g)
        Next

        g.EndContainer(gCon)
    End Sub

    Public Sub DanhDau(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics, ByVal Color As Color)
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(mX, mY)
        g.ScaleTransform(Scale, Scale)

        'Dim mGObj As GraphicObject
        For Each mGObj As GraphicObject In m_GObjs
            mGObj.DanhDau(g, Color)
        Next

        g.EndContainer(gCon)
    End Sub

    Public Sub DanhDau(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics, ByVal Pen As Pen)
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(mX, mY)
        g.ScaleTransform(Scale, Scale)

        'Dim mGObj As GraphicObject
        For Each mGObj As GraphicObject In m_GObjs
            mGObj.DanhDau(g, Pen)
        Next

        g.EndContainer(gCon)
    End Sub

    Public Function GetBounds(ByVal pMap As AxMapXLib.AxMap) As Rectangle
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        'Dim gCon As Drawing2D.GraphicsContainer
        'gCon = g.BeginContainer
        'g.TranslateTransform(mX, mY)
        'g.ScaleTransform(Scale, Scale)
        Dim mMatrix As New Matrix
        mMatrix.Translate(mX, mY)
        mMatrix.Scale(Scale, Scale)

        Dim myL, myT, myR, myB As Single
        'Dim mGObj As GraphicObject
        Dim myRect As RectangleF
        For Each mGObj As GraphicObject In m_GObjs
            'mGObj.VeBound(g, Color)
            myRect = mGObj.GetBounds
            If myRect.Left < myL Then
                myL = myRect.Left
            End If
            If myRect.Top < myT Then
                myT = myRect.Top
            End If
            If myRect.Right > myR Then
                myR = myRect.Right
            End If
            If myRect.Bottom > myB Then
                myB = myRect.Bottom
            End If
        Next
        Dim mPts(1) As PointF
        mPts(0) = New PointF(myL, myT)
        mPts(1) = New PointF(myR, myB)
        mMatrix.TransformPoints(mPts)
        mMatrix.Dispose()

        Return New Rectangle(mPts(0).X, mPts(0).Y, mPts(1).X - mPts(0).X, mPts(1).Y - mPts(0).Y)

    End Function

    Public Sub VeBound(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics, ByVal Color As Color)
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(mX, mY)
        g.ScaleTransform(Scale, Scale)
        Dim myL, myT, myR, myB As Single
        'Dim mGObj As GraphicObject
        Dim myRect As RectangleF
        For Each mGObj As GraphicObject In m_GObjs
            'mGObj.VeBound(g, Color)
            myRect = mGObj.GetBounds
            If myRect.Left < myL Then
                myL = myRect.Left
            End If
            If myRect.Top < myT Then
                myT = myRect.Top
            End If
            If myRect.Right > myR Then
                myR = myRect.Right
            End If
            If myRect.Bottom > myB Then
                myB = myRect.Bottom
            End If
        Next

        Dim myPen As New Pen(Color.Black)
        myPen.DashStyle = Drawing2D.DashStyle.Dot
        myPen.Width = 2
        myPen.Color = Color.White
        g.DrawRectangle(myPen, New Rectangle(myL, myT, myR - myL, myB - myT))
        myPen.Width = 1
        myPen.Color = Color
        g.DrawRectangle(myPen, New Rectangle(myL, myT, myR - myL, myB - myT))

        myPen.Dispose()

        g.EndContainer(gCon)
    End Sub

    Public Sub VeBound(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics, ByVal pObj As GraphicObject, ByVal Color As Color)
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(mX, mY)
        g.ScaleTransform(Scale, Scale)

        pObj.VeBound(g, Color)

        g.EndContainer(gCon)
    End Sub

    Public Sub DanhDau(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics, ByVal pObj As GraphicObject, ByVal Color As Color)
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(mX, mY)
        g.ScaleTransform(Scale, Scale)

        pObj.DanhDau(g, Color)

        g.EndContainer(gCon)
    End Sub

    Public Sub DrawNodes(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics)
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(mX, mY)
        g.ScaleTransform(Scale, Scale)

        For Each mGObj As GraphicObject In m_GObjs
            mGObj.DrawNodes(g)
        Next

        g.EndContainer(gCon)
    End Sub

    Public Sub DrawNodes1(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics)
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        'Dim mBrush As New SolidBrush(Color.FromArgb(255, Color.Red))
        Dim mBrush As New SolidBrush(Color.FromArgb(75, Color.Orange))
        Dim mPen As New Pen(Color.Black, 2)

        Dim r As New Rectangle(0, 0, 5, 5)
        r.X = mX - 2
        r.Y = mY - 2
        'g.FillRectangle(mBrush, r)

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(mX, mY)
        g.ScaleTransform(Scale, Scale)

        'Dim mGObj As GraphicObject
        For Each mGObj As GraphicObject In m_GObjs
            'mGObj.DrawNodes(g)
            'mGObj.DrawNodes(g, 1 / Scale)
            Dim mPts() As PointF = mGObj.GetPoints()
            r.X = mPts(0).X - 2
            r.Y = mPts(0).Y - 2
            g.FillEllipse(mBrush, r)
            g.DrawEllipse(mPen, r)
            g.DrawLine(mPen, r.Left - 1, r.Top - 1, r.Right + 1, r.Bottom + 1)
            g.DrawLine(mPen, r.Left - 1, r.Bottom + 1, r.Right + 1, r.Top - 1)
            If mPts.GetUpperBound(0) > 0 Then
                For i As Integer = 1 To mPts.GetUpperBound(0)
                    r.X = mPts(i).X - 2
                    r.Y = mPts(i).Y - 2
                    g.FillEllipse(mBrush, r)
                    g.DrawEllipse(mPen, r)
                Next
            End If

        Next

        g.EndContainer(gCon)
    End Sub

    Public Sub DrawRoot(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics)
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)

        'Dim mBrush As New SolidBrush(Color.FromArgb(255, Color.Red))
        Dim mPen As New Pen(Color.Black, 2)
        Dim r As New Rectangle(mX - 3, mY - 3, 7, 7)
        'g.FillRectangle(mBrush, r)
        g.DrawRectangle(mPen, r)

        mPen.Dispose()
    End Sub

    Public Function HitTest(ByVal pMap As AxMapXLib.AxMap, ByVal pt As PointF) As Boolean

        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        Dim mMatrix As New Drawing2D.Matrix
        Dim drawObj As GraphicObject
        Dim j As Integer
        mMatrix.Translate(-mX, -mY, MatrixOrder.Append)
        mMatrix.Scale(1 / Scale, 1 / Scale, MatrixOrder.Append)
        Dim mPts(0) As PointF
        mPts(0) = pt
        mMatrix.TransformPoints(mPts)
        Dim mPt As New PointF(mPts(0).X, mPts(0).Y)

        If m_GObjs.Count > 0 Then
            For j = m_GObjs.Count - 1 To 0 Step -1
                drawObj = m_GObjs(j)
                If drawObj.HitTest(mPt) Then
                    Return True
                    Exit For
                End If
            Next
        End If
        Return False
    End Function

    Public Function HitTest(ByVal pMap As AxMapXLib.AxMap, ByVal rect As RectangleF) As Boolean
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        Dim mMatrix As New Drawing2D.Matrix
        Dim drawObj As GraphicObject
        Dim j As Integer
        mMatrix.Translate(-mX, -mY, MatrixOrder.Append)
        mMatrix.Scale(1 / Scale, 1 / Scale, MatrixOrder.Append)
        Dim mPts(1) As PointF
        mPts(0) = New PointF(rect.Left, rect.Top)
        mPts(1) = New PointF(rect.Left + rect.Width, rect.Top + rect.Height)
        mMatrix.TransformPoints(mPts)
        'Dim mPt As New PointF(mPts(0).X, mPts(0).Y)
        Dim mrect As New RectangleF(mPts(0).X, mPts(0).Y, mPts(1).X - mPts(0).X, mPts(1).Y - mPts(0).Y)
        If m_GObjs.Count > 0 Then
            For j = m_GObjs.Count - 1 To 0 Step -1
                drawObj = m_GObjs(j)
                If Not drawObj.HitTest(mrect) Then
                    Return False
                    Exit For
                End If
            Next
        End If
        Return True
    End Function

    Public Function FindObjectAtPoint(ByVal pMap As AxMapXLib.AxMap, ByVal pt As PointF) As GraphicObject
        'Dim drawObj As GraphicObject
        'Dim j As Integer
        'Dim mPt As New PointF()
        'Dim mX, mY As Single
        'pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        'mPt.X = pt.X - mX
        'mPt.Y = pt.Y - mY
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        Dim mMatrix As New Drawing2D.Matrix
        Dim drawObj As GraphicObject
        Dim j As Integer
        mMatrix.Translate(-mX, -mY, MatrixOrder.Append)
        mMatrix.Scale(1 / Scale, 1 / Scale, MatrixOrder.Append)
        Dim mPts(0) As PointF
        mPts(0) = pt
        mMatrix.TransformPoints(mPts)
        Dim mPt As New PointF(mPts(0).X, mPts(0).Y)
        drawObj = m_GObjs.FindObjectAtPoint(mPt)
        Return drawObj
    End Function

    Public Sub MoveNodeTo(ByVal pMap As AxMapXLib.AxMap, ByVal ENode As CFOUNDNODE, ByVal pt As System.Drawing.PointF)
        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        Dim mMatrix As New Drawing2D.Matrix
        Dim drawObj As GraphicObject = ENode.FoundObject
        Dim j As Integer
        mMatrix.Translate(-mX, -mY, MatrixOrder.Append)
        mMatrix.Scale(1 / Scale, 1 / Scale, MatrixOrder.Append)
        Dim mPts(0) As PointF
        mPts(0) = pt
        mMatrix.TransformPoints(mPts)
        Dim mPt As New PointF(mPts(0).X, mPts(0).Y)
        drawObj.MoveNodeTo(ENode.NodeIndex, mPt)
    End Sub

    Public Function Noi2Objs(ByVal pFoundNode As CFOUNDNODE) As Boolean
        Dim kq As Boolean = False
        If (pFoundNode.FoundObject.GetObjType = OBJECTTYPE.Curve) Or (pFoundNode.FoundObject.GetObjType = OBJECTTYPE.Line) Then
            Dim mNShape As NodesShapeGraphic = CType(pFoundNode.FoundObject, NodesShapeGraphic)
            If (pFoundNode.NodeIndex = 0) Or (pFoundNode.NodeIndex = mNShape.Nodes.Count - 1) Then
                Dim mFoundNode2 As CFOUNDNODE = Tim2ndNode(pFoundNode)
                If pFoundNode.NodeIndex = 0 Then
                    mNShape.ReverseNodes()
                End If
                If mFoundNode2.NodeIndex = 0 Then
                    Dim mNShape2 As NodesShapeGraphic = CType(mFoundNode2.FoundObject, NodesShapeGraphic)
                    If mNShape2.Nodes.Count > 1 Then
                        For i As Integer = 1 To mNShape2.Nodes.Count - 1
                            mNShape.Nodes.Add(mNShape2.Nodes(i))
                        Next
                    End If
                    m_GObjs.Remove(mFoundNode2.FoundObject)
                    kq = True
                ElseIf mFoundNode2.NodeIndex > 0 Then
                    Dim mNShape2 As NodesShapeGraphic = CType(mFoundNode2.FoundObject, NodesShapeGraphic)
                    'mNShape2.ReverseNodes()
                    If mNShape2.Nodes.Count > 1 Then
                        For i As Integer = mNShape2.Nodes.Count - 2 To 0 Step -1
                            mNShape.Nodes.Add(mNShape2.Nodes(i))
                        Next
                    End If
                    m_GObjs.Remove(mFoundNode2.FoundObject)
                    kq = True
                End If
                'm_Map.CenterX = m_Map.CenterX
                'Else
                'MsgBox("khong phai diem dau, khong noi duoc.")
            End If
            'Else
            'MsgBox("khong noi duoc.")
        End If
        Return kq
    End Function

    Private Function Tim2ndNode(ByVal pFoundNode As CFOUNDNODE) As CFOUNDNODE
        Dim kq As New CFOUNDNODE
        kq.NodeIndex = -1
        For Each aObj As GraphicObject In m_GObjs
            If (aObj.GetObjType = OBJECTTYPE.Curve) Or (aObj.GetObjType = OBJECTTYPE.Line) Then
                If Not aObj Is pFoundNode.FoundObject Then
                    Dim mNShape As NodesShapeGraphic = CType(aObj, NodesShapeGraphic)
                    Dim mNShape0 As NodesShapeGraphic = CType(pFoundNode.FoundObject, NodesShapeGraphic)
                    If (mNShape.Nodes(0).X = mNShape0.Nodes(pFoundNode.NodeIndex).X) And (mNShape.Nodes(0).Y = mNShape0.Nodes(pFoundNode.NodeIndex).Y) Then
                        kq.FoundObject = aObj
                        kq.NodeIndex = 0
                    ElseIf (mNShape.Nodes(mNShape.Nodes.Count - 1).X = mNShape0.Nodes(pFoundNode.NodeIndex).X) And (mNShape.Nodes(mNShape.Nodes.Count - 1).Y = mNShape0.Nodes(pFoundNode.NodeIndex).Y) Then
                        kq.FoundObject = aObj
                        kq.NodeIndex = mNShape.Nodes.Count - 1
                    End If
                End If
            End If
        Next
        Return kq
    End Function

    Public Function FindNodeAtPoint(ByVal pMap As AxMapXLib.AxMap, ByVal pt As PointF) As CFOUNDNODE
        Dim KQ As New CFOUNDNODE
        Dim drawObj As GraphicObject
        'Dim foundNode As CNODE

        Dim Scale As Single = m_Zoom / pMap.Zoom
        Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)

        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        Dim mMatrix As New Drawing2D.Matrix
        Dim i, j, iNode As Integer
        mMatrix.Translate(-mX, -mY, MatrixOrder.Append)
        mMatrix.Scale(1 / Scale, 1 / Scale, MatrixOrder.Append)
        Dim mPts(0) As PointF
        mPts(0) = pt
        mMatrix.TransformPoints(mPts)
        Dim mPt As New PointF(mPts(0).X, mPts(0).Y)
        'drawObj = m_GObjs.FindObjectAtPoint(mPt)
        'Return drawObj
        For i = m_GObjs.Count - 1 To 0 Step -1
            drawObj = m_GObjs(i)
            j = drawObj.FindNodeAtPoint(mPt)
            If j > -1 Then
                iNode = j
                KQ.FoundObject = drawObj
                KQ.NodeIndex = iNode
                'KQ.IsRoot = False
                Return KQ
                Exit For
            End If
        Next

        'Dim r As New RectangleF(mX - 3, mY - 3, 7, 7)
        'If r.Contains(pt) Then
        'KQ.IsRoot = True
        'Return KQ
        'End If

        Return Nothing
    End Function

    Public Function RootHitTest(ByVal pMap As AxMapXLib.AxMap, ByVal pt As PointF) As Boolean
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        Dim r As New RectangleF(mX - 3, mY - 3, 7, 7)
        Return r.Contains(pt)
    End Function

    Public Sub Move(ByVal pMap As AxMapXLib.AxMap, ByVal fromPt As System.Drawing.PointF, ByVal toPt As System.Drawing.PointF)
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        mX += toPt.X - fromPt.X
        mY += toPt.Y - fromPt.Y
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miScreenToMap)
    End Sub

    Public Sub Shift(ByVal pMap As AxMapXLib.AxMap, ByVal deltaX As Single, ByVal deltaY As Single)
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        mX += deltaX
        mY += deltaY
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miScreenToMap)
    End Sub

    Public Sub ChangeRoot(ByVal pMap As AxMapXLib.AxMap, ByVal newGocX As Double, ByVal newGocY As Double)
        Dim mX, mY As Single
        Dim mX2, mY2 As Single
        'pMap.Zoom = m_Zoom
        Dim mScale As Single = pMap.Zoom / m_Zoom
        'Dim Scale As Single = m_Zoom / pMap.Zoom
        mScale *= IIf(m_MWidth > 0, (m_MWidth / pMap.MapScreenWidth), 1)

        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        pMap.ConvertCoord(mX2, mY2, newGocX, newGocY, MapXLib.ConversionConstants.miMapToScreen)
        m_GocX = newGocX
        m_GocY = newGocY
        Dim mPt As PointF = New PointF(mX * mScale, mY * mScale)
        Dim mPt2 As PointF = New PointF(mX2 * mScale, mY2 * mScale)
        'Dim mObj As GraphicObject
        For Each mObj As GraphicObject In m_GObjs
            mObj.Move(mPt2, mPt)
        Next
    End Sub

    Public Sub ChangeZoomMWidtht(ByVal newZoom As Double, ByVal newMWidth As Single)
        For Each mObj As GraphicObject In m_GObjs
            Dim mPts() As PointF = mObj.GetPoints
            Dim mScale As Single = m_Zoom / newZoom
            mScale *= IIf(m_MWidth > 0, (newMWidth / m_MWidth), 1)

            Dim mMatrix As New Matrix
            mMatrix.Reset()
            mMatrix.Scale(mScale, mScale, MatrixOrder.Append)
            mMatrix.TransformPoints(mPts)
            For i As Integer = 0 To mPts.GetUpperBound(0)
                mObj.MoveNodeTo(i, mPts(i))
            Next
        Next
        m_Zoom = newZoom
        m_MWidth = newMWidth
    End Sub

    Public Sub Rotate(ByVal pMap As AxMapXLib.AxMap, ByVal rootPt As System.Drawing.PointF, _
    ByVal fromPt As System.Drawing.PointF, ByVal toPt As System.Drawing.PointF)
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        mX -= rootPt.X
        mY -= rootPt.Y
        Dim mRoot As New PointF
        mRoot.X = mX
        mRoot.Y = mY
        fromPt.X -= rootPt.X
        fromPt.Y -= rootPt.Y
        toPt.X -= rootPt.X
        toPt.Y -= rootPt.Y
        'Dim mObj As GraphicObject
        For Each mObj As GraphicObject In m_GObjs
            mObj.Rotate(mRoot, fromPt, toPt)
        Next
    End Sub

    Public Sub Rotate2(ByVal pMap As AxMapXLib.AxMap, ByVal rootPt As System.Drawing.PointF, _
    ByVal degree As Double)
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        mX -= rootPt.X
        mY -= rootPt.Y
        Dim mRoot As New PointF
        mRoot.X = mX
        mRoot.Y = mY
        'Dim mObj As GraphicObject
        For Each mObj As GraphicObject In m_GObjs
            mObj.Rotate2(mRoot, degree)
        Next
    End Sub

    Public Sub Scale(ByVal pMap As AxMapXLib.AxMap, ByVal rootPt As System.Drawing.PointF, _
    ByVal fromPt As System.Drawing.PointF, ByVal toPt As System.Drawing.PointF)
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        mX -= rootPt.X
        mY -= rootPt.Y
        Dim mRoot As New PointF
        mRoot.X = mX
        mRoot.Y = mY
        fromPt.X -= rootPt.X
        fromPt.Y -= rootPt.Y
        toPt.X -= rootPt.X
        toPt.Y -= rootPt.Y
        'Dim mObj As GraphicObject
        For Each mObj As GraphicObject In m_GObjs
            mObj.Zoom(mRoot, fromPt, toPt)
        Next
    End Sub

    Public Sub Scale2(ByVal pMap As AxMapXLib.AxMap, ByVal rootPt As System.Drawing.PointF, _
    ByVal deltaX As Single, ByVal deltaY As Single)
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        mX -= rootPt.X
        mY -= rootPt.Y
        Dim mRoot As New PointF
        mRoot.X = mX
        mRoot.Y = mY
        Dim rect As Rectangle = GetBounds(pMap)
        Dim dX As Single = (rect.Width + deltaX) / rect.Width
        Dim dY As Single = (rect.Height + deltaY) / rect.Height
        For Each mObj As GraphicObject In m_GObjs
            mObj.Zoom2(mRoot, dX, dY)
        Next
    End Sub

    Public Sub VFlip()
        Dim myL, myT, myR, myB As Single
        'Dim mGObj As GraphicObject
        Dim myRect As RectangleF
        For Each mGObj As GraphicObject In m_GObjs
            myRect = mGObj.GetBounds
            If myRect.Left < myL Then
                myL = myRect.Left
            End If
            If myRect.Top < myT Then
                myT = myRect.Top
            End If
            If myRect.Right > myR Then
                myR = myRect.Right
            End If
            If myRect.Bottom > myB Then
                myB = myRect.Bottom
            End If
        Next
        Dim mX0 As Single = (myRect.Left + myRect.Right) / 2
        For Each mGObj As GraphicObject In m_GObjs
            mGObj.VFlip(mX0)
        Next
    End Sub

    Public Sub VFlip(ByVal pMap As AxMapXLib.AxMap)
        Dim mX, mY As Single
        pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        Dim mX0 As Single = mX '(myRect.Left + myRect.Right) / 2
        For Each mGObj As GraphicObject In m_GObjs
            mGObj.VFlip(mX0)
        Next
    End Sub

    Protected Sub New()
    End Sub

    Public Sub New(ByVal pMap As AxMapXLib.AxMap, ByVal pGObjs As CGraphicObjs)
        Me.New()
        pMap.ConvertCoord(0, 0, m_GocX, m_GocY, MapXLib.ConversionConstants.miScreenToMap)
        m_Zoom = pMap.Zoom
        m_MWidth = pMap.MapScreenWidth
        'm_GObjs = pGObjs
        m_GObjs = New CGraphicObjs
        For Each aGObj As GraphicObject In pGObjs
            m_GObjs.Add(aGObj.Clone)
        Next
        m_Description = ""
        m_Blinking = False
    End Sub

    Public Sub New(ByVal pMap As AxMapXLib.AxMap, ByVal pGObjs As CGraphicObjs, ByVal pZoom As Double, ByVal pMWidth As Single)
        Me.New()
        pMap.ConvertCoord(0, 0, m_GocX, m_GocY, MapXLib.ConversionConstants.miScreenToMap)
        m_Zoom = pZoom
        m_MWidth = pMWidth
        'm_GObjs = pGObjs
        m_GObjs = New CGraphicObjs
        For Each aGObj As GraphicObject In pGObjs
            m_GObjs.Add(aGObj.Clone)
        Next
        m_Description = ""
        m_Blinking = False
    End Sub

    Public Sub New(ByVal pMap As AxMapXLib.AxMap, ByVal pt0 As PointF, ByVal pGObjs As CGraphicObjs)
        Me.New()
        pMap.ConvertCoord(pt0.X, pt0.Y, m_GocX, m_GocY, MapXLib.ConversionConstants.miScreenToMap)
        m_Zoom = pMap.Zoom
        m_MWidth = pMap.MapScreenWidth
        'm_GObjs = pGObjs
        m_GObjs = New CGraphicObjs
        For Each aGObj As GraphicObject In pGObjs
            m_GObjs.Add(aGObj.Clone)
        Next
        m_Description = ""
        m_Blinking = False
    End Sub

    Public Sub New(ByVal pMap As AxMapXLib.AxMap, ByVal pt0 As PointF, ByVal pGObjs As CGraphicObjs, ByVal pMapScreenWidth As Single)
        Me.New()
        pMap.ConvertCoord(pt0.X, pt0.Y, m_GocX, m_GocY, MapXLib.ConversionConstants.miScreenToMap)
        m_Zoom = pMap.Zoom
        m_MWidth = pMapScreenWidth

        'm_GObjs = pGObjs
        m_GObjs = New CGraphicObjs
        For Each aGObj As GraphicObject In pGObjs
            m_GObjs.Add(aGObj.Clone)
        Next
        m_Description = ""
        m_Blinking = False
    End Sub

    Public Sub New(ByVal pMap As AxMapXLib.AxMap, ByVal pt0 As PointF, ByVal pGObjs As CGraphicObjs, ByVal pZoom As Double, ByVal pMWidth As Single)
        Me.New()
        pMap.ConvertCoord(pt0.X, pt0.Y, m_GocX, m_GocY, MapXLib.ConversionConstants.miScreenToMap)
        m_Zoom = pZoom
        m_MWidth = pMWidth
        'm_GObjs = pGObjs
        m_GObjs = New CGraphicObjs
        For Each aGObj As GraphicObject In pGObjs
            m_GObjs.Add(aGObj.Clone)
        Next
        m_Description = ""
        m_Blinking = False
    End Sub

    Public Sub New(ByVal pDesc As String, ByVal pZoom As Double, ByVal pMWidth As Single, ByVal pGocX As Double, ByVal pGocY As Double, ByVal pGObjs As CGraphicObjs)
        Me.New()
        m_GocX = pGocX
        m_GocY = pGocY
        m_Zoom = pZoom
        m_MWidth = pMWidth
        'm_GObjs = pGObjs
        m_GObjs = New CGraphicObjs
        For Each aGObj As GraphicObject In pGObjs
            m_GObjs.Add(aGObj.Clone)
        Next
        m_Description = pDesc
        m_Blinking = False
    End Sub

    Public Sub New(ByVal pDesc As String, ByVal pBlinking As Boolean, ByVal pZoom As Double, ByVal pMWidth As Single, ByVal pGocX As Double, ByVal pGocY As Double, ByVal pGObjs As CGraphicObjs)
        Me.New()
        m_GocX = pGocX
        m_GocY = pGocY
        m_Zoom = pZoom
        m_MWidth = pMWidth
        'm_GObjs = pGObjs
        m_GObjs = New CGraphicObjs
        For Each aGObj As GraphicObject In pGObjs
            m_GObjs.Add(aGObj.Clone)
        Next
        m_Description = pDesc
        m_Blinking = pBlinking
    End Sub
End Class

Public Class CSymbols
    Inherits System.Collections.CollectionBase

    Public Sub Add(ByVal aSymbol As CSymbol)
        List.Add(aSymbol)
    End Sub

    Public Sub InsertAt(ByVal index As Integer, ByVal aSymbol As CSymbol)
        If index > Count Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        ElseIf index = Count Then
            List.Add(aSymbol)
        Else
            List.Insert(index, aSymbol)
        End If
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        Else
            List.RemoveAt(index)
        End If
    End Sub

    Public Sub Remove(ByVal aSymbol As CSymbol)
        Me.List.Remove(aSymbol)
    End Sub

    Public ReadOnly Property IndexOf(ByVal aSymbol As CSymbol) As Integer
        Get
            Return List.IndexOf(aSymbol)
        End Get
    End Property

    Public ReadOnly Property ListCount() As Integer
        Get
            Return List.Count()
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal index As Integer) As CSymbol
        Get
            Return CType(List.Item(index), CSymbol)
        End Get
    End Property

    Public Function Contains(ByVal value As CSymbol) As Boolean
        Return List.Contains(value)
    End Function

    Public Function FindSymbolAtPoint(ByVal pMap As AxMapXLib.AxMap, ByVal pt As PointF) As CSymbol
        Dim drawObj As GraphicObject
        Dim drawSymbol As CSymbol
        Dim i As Integer
        If Not Me.List Is Nothing AndAlso Me.List.Count > 0 Then
            For i = Me.List.Count - 1 To 0 Step -1
                drawSymbol = CType(Me.List(i), CSymbol)
                If drawSymbol.HitTest(pMap, pt) Then
                    'drawObj = drawSymbol.FindObjectAtPoint(pMap, pt)
                    'If Not drawObj Is Nothing Then
                    Return drawSymbol
                    Exit For
                End If
            Next
        End If
        Return Nothing
    End Function

    Public Function FindObjectAtPoint(ByVal pMap As AxMapXLib.AxMap, ByVal pt As PointF) As CFOUNDOBJECT
        Dim foundObj As New CFOUNDOBJECT
        Dim drawObj As GraphicObject
        Dim drawSymbol As CSymbol
        Dim i As Integer
        If Not Me.List Is Nothing AndAlso Me.List.Count > 0 Then
            For i = Me.List.Count - 1 To 0 Step -1
                drawSymbol = CType(Me.List(i), CSymbol)
                drawObj = drawSymbol.FindObjectAtPoint(pMap, pt)
                If Not drawObj Is Nothing Then
                    foundObj.FoundObject = drawObj
                    foundObj.FoundSymbol = drawSymbol
                    Return foundObj
                    Exit For
                End If
            Next
        End If
        Return Nothing
    End Function

    Public Sub DrawSymbols(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics)
        Dim drawSymbol As CSymbol
        Dim i As Integer
        If Not Me.InnerList Is Nothing AndAlso Me.InnerList.Count > 0 Then
            For i = 0 To Me.InnerList.Count - 1
                drawSymbol = CType(Me.InnerList(i), CSymbol)
                drawSymbol.Draw(pMap, g)
            Next
        End If
    End Sub

    Public Sub DrawSelectedSymbol(ByVal pMap As AxMapXLib.AxMap, ByVal g As Graphics, _
        ByVal selectedSymbol As CSymbol, _
        ByVal Scale As Single)

        Dim selectedObject As GraphicObject = selectedSymbol.GObjs(0)
        Dim ltPt As New Point
        pMap.ConvertCoord(ltPt.X, ltPt.Y, selectedObject.X, selectedObject.Y, MapXLib.ConversionConstants.miMapToScreen)

        Dim gCon1, gCon2 As Drawing2D.GraphicsContainer
        gCon1 = g.BeginContainer
        g.ScaleTransform(Scale, Scale, _
            Drawing.Drawing2D.MatrixOrder.Append)
        gCon2 = g.BeginContainer
        g.PageUnit = GraphicsUnit.Pixel

        If Not selectedObject Is Nothing Then

            Dim selectionPen As New _
                Pen(Color.FromKnownColor(KnownColor.HotTrack))
            selectionPen.DashStyle = Drawing2D.DashStyle.Dot
            selectionPen.Width = 1

            If selectedObject.Rotation <> 0 Then
                Dim myMatrix As Drawing2D.Matrix
                myMatrix = g.Transform()
                myMatrix.RotateAt(selectedObject.Rotation, _
                    New PointF(ltPt.X, ltPt.Y), _
                    Drawing.Drawing2D.MatrixOrder.Append)
                g.Transform = myMatrix
            End If

            'g.DrawRectangle(selectionPen, _
            '    selectedObject.X, selectedObject.Y, _
            '    selectedObject.Width, selectedObject.Height)
            'Dim mPtfs() As PointF = selectedObject.GetPoints()
            Dim mPtfs(2) As PointF
            mPtfs(0).X = selectedObject.X
            mPtfs(0).Y = selectedObject.Y
            mPtfs(1).X = selectedObject.X + selectedObject.Width
            mPtfs(1).Y = selectedObject.Y + selectedObject.Height
            Dim mPtsCount As Integer = mPtfs.GetUpperBound(0)
            Dim mPts(mPtsCount) As Point
            Dim i As Integer
            For i = 0 To mPtsCount
                pMap.ConvertCoord(mPts(i).X, mPts(i).Y, mPtfs(i).X, mPtfs(i).Y, MapXLib.ConversionConstants.miMapToScreen)
            Next
            Dim mW As Single = Math.Abs(mPts(1).X - mPts(0).X)
            Dim mH As Single = Math.Abs(mPts(1).Y - mPts(0).Y)
            Dim mPtX, mPtY As Single
            mPtX = Math.Min(mPts(0).X, mPts(1).X)
            mPtY = Math.Min(mPts(0).Y, mPts(1).Y)
            Dim rect As Rectangle = New Rectangle(mPtX, mPtY, mW, mH)

            g.DrawRectangle(selectionPen, rect)
        End If
        g.EndContainer(gCon2)
        g.EndContainer(gCon1)
    End Sub

    Public Sub SendBack(ByVal aKH As CSymbol)
        Me.List.Remove(aKH)
        list.Insert(0, aKH)
    End Sub

    Public Sub SendFront(ByVal aKH As CSymbol)
        Me.List.Remove(aKH)
        List.Add(aKH)
    End Sub

    Public Function KH2String(ByVal pMap As AxMapXLib.AxMap) As String

        Dim sw As New StringWriter
        Dim wr As XmlTextWriter = New XmlTextWriter(sw)

        khs2xml(pMap, wr)
        wr.Close()

        Return sw.ToString()

    End Function

    Public Sub KH2File(ByVal pMap As AxMapXLib.AxMap, ByVal pFileName As String)
        Dim sw As New StreamWriter(pFileName)
        Dim wr As XmlTextWriter = New XmlTextWriter(sw)

        khs2xml(pMap, wr)

        wr.Close()

    End Sub

    Private Sub khs2xml(ByVal pMap As AxMapXLib.AxMap, ByRef wr As XmlTextWriter)
        Dim i As Integer

        'Dim mPart As GraphicObject
        Dim mType As OBJECTTYPE  'String
        Dim mShapeObj As ShapeGraphic
        Dim mTextObj As TextGraphic
        Dim mTableObj As TableGraphic

        Dim mImageObj As EmbeddedImageGraphic

        'Dim mKH As CSymbol 'CKyHieu
        'Dim mNode As CNODE

        wr.WriteStartElement("KyHieus")
        wr.WriteAttributeString("CX", pMap.CenterX.ToString("#.0000"))
        wr.WriteAttributeString("CY", pMap.CenterY.ToString("#.0000"))
        wr.WriteAttributeString("Zoom", pMap.Zoom.ToString)

        For Each mKH As CSymbol In list
            wr.WriteStartElement("KyHieu")
            If mKH.Description.Length > 0 Then
                wr.WriteAttributeString("Desc", mKH.Description)
            End If
            If mKH.Blinking Then
                wr.WriteAttributeString("Blink", mKH.Blinking.ToString)
            End If
            wr.WriteAttributeString("Zoom", mKH.Zoom.ToString)
            wr.WriteAttributeString("MWi", mKH.MWidth.ToString)
            wr.WriteAttributeString("GocX", mKH.GocX.ToString("#.0000"))
            wr.WriteAttributeString("GocY", mKH.GocY.ToString("#.0000"))
            i = 0

            For Each mPart As GraphicObject In mKH.GObjs '.MapParts
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
                ElseIf mType = OBJECTTYPE.Table Then
                    mTableObj = CType(mPart, TableGraphic)

                    wr.WriteStartElement("TBL")

                    wr.WriteAttributeString("X", mTableObj.X.ToString)
                    wr.WriteAttributeString("Y", mTableObj.Y.ToString)
                    wr.WriteAttributeString("W", mTableObj.Width.ToString)
                    wr.WriteAttributeString("H", mTableObj.Height.ToString)
                    wr.WriteAttributeString("A", mTableObj.Rotation.ToString)

                    wr.WriteAttributeString("Cols", mTableObj.ColsNo.ToString)
                    wr.WriteAttributeString("Rows", mTableObj.RowsNo.ToString)
                    wr.WriteAttributeString("BColor", mTableObj.BorderColor.ToArgb)
                    wr.WriteAttributeString("BWidth", mTableObj.BorderWidth.ToString)
                    wr.WriteAttributeString("LColor", mTableObj.LineColor.ToArgb)
                    wr.WriteAttributeString("LWidth", mTableObj.LineWidth.ToString)
                    wr.WriteAttributeString("FiColor", mTableObj.FiColor.ToArgb)

                    Dim str1 As String = mTableObj.AWidth(0)
                    For i = 1 To mTableObj.ColsNo - 1
                        str1 &= "|" & mTableObj.AWidth(i)
                    Next
                    wr.WriteAttributeString("AWS", str1)

                    str1 = mTableObj.AHeight(0)
                    For i = 1 To mTableObj.RowsNo - 1
                        str1 &= "|" & mTableObj.AHeight(i)
                    Next
                    wr.WriteAttributeString("AHS", str1)

                    i = 0
                    For Each mCell As CCell In mTableObj.Cells
                        i += 1
                        wr.WriteStartElement("Cell")
                        wr.WriteAttributeString("iR", mCell.iRow.ToString)
                        wr.WriteAttributeString("iC", mCell.iCol.ToString)
                        wr.WriteAttributeString("RNo", mCell.RowsNo.ToString)
                        wr.WriteAttributeString("CNo", mCell.ColsNo.ToString)
                        wr.WriteAttributeString("Text", mCell.Text)
                        wr.WriteAttributeString("FName", mCell.Font.Name)
                        wr.WriteAttributeString("FSize", mCell.Font.Size.ToString)
                        wr.WriteAttributeString("FStyle", mCell.Font.Style.ToString)
                        wr.WriteAttributeString("Color", mCell.Color.ToArgb)
                        wr.WriteElementString("i", i.ToString)
                        wr.WriteEndElement()
                    Next

                    wr.WriteEndElement()

                ElseIf mType = OBJECTTYPE.EmbeddedImage Then
                    mImageObj = CType(mPart, EmbeddedImageGraphic)
                    wr.WriteAttributeString("ITYPE", mImageObj.ImageType)
                    wr.WriteAttributeString("IMAGEW", mImageObj.Width.ToString)
                    wr.WriteAttributeString("IMAGEH", mImageObj.Height.ToString)

                    Dim strImage As String = ""
                    Select Case mImageObj.ImageType
                        Case "wmf", "emf", "kro"
                            Try
                                Dim mFileName = "tmp2.kro"
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
                        'MsgBox(mShapeObj.StyleWidth.ToString)
                        wr.WriteAttributeString("Style", mShapeObj.LineStyle.ToString)
                        wr.WriteAttributeString("SWidth", mShapeObj.StyleWidth.ToString)
                    End If

                    If mShapeObj.Line2Width > 0 Then
                        wr.WriteAttributeString("Color2", mShapeObj.Line2Color.ToArgb)
                        wr.WriteAttributeString("Width2", mShapeObj.Line2Width.ToString)
                    End If
                    'If Not mPart.DValues Is Nothing Then
                    If mShapeObj.DValues.Length > 6 Then
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

            Next
            wr.WriteEndElement()
        Next

        wr.WriteEndElement()

    End Sub

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

End Class


