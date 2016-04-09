'Option Strict On
Option Explicit On

Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports DBiGraphicObjs.DBiGraphicObjects
Imports System.Windows.Forms

Public Class CThumbNail
    Private mValue As String
    Private mID As Integer
    Private mSymbols As String
    Private mVanToc As Integer = 4

    Public Sub New(ByVal strValue As String, ByVal intID As Integer, ByVal strSymbols As String)
        mValue = strValue
        mID = intID
        mSymbols = strSymbols
    End Sub

    Public Sub New(ByVal strValue As String, ByVal intID As Integer, ByVal strSymbols As String, ByVal intVanToc As Integer)
        mValue = strValue
        mID = intID
        mSymbols = strSymbols
        mVanToc = intVanToc
    End Sub

    Public Sub New()
        mValue = ""
        mID = 0
        mSymbols = ""
    End Sub

    Property ID() As Integer
        Get
            Return mID
        End Get
        Set(ByVal Value As Integer)
            mID = Value
        End Set
    End Property

    Property Value() As String
        Get
            Return mValue
        End Get
        Set(ByVal Value As String)
            mValue = Value
        End Set
    End Property

    Property Symbols() As String
        Get
            Return mSymbols
        End Get
        Set(ByVal Value As String)
            mSymbols = Value
        End Set
    End Property

    Property VanToc() As Integer
        Get
            Return mVanToc
        End Get
        Set(ByVal Value As Integer)
            mVanToc = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return mValue
    End Function

End Class

Public Class CThumbNails
    Inherits System.Collections.CollectionBase

    Public Event SelectedIndexChanged(ByVal e As System.EventArgs)

    Private WithEvents m_PicBox As PictureBox

    Private currentTopLeftItem As Integer = 0

    Private m_SelectedIndex As Integer = -1
    Private m_GenericImage As String = ""

    Private x As Integer = 10
    Private y As Integer = 32 '16
    Private h As Integer = 40
    Private w As Integer = 80 '40
    Private rowsPerPage As Integer = 0
    Private colsPerPage As Integer = 0

    Public Property HorizontalSpacing() As Integer
        Get
            Return x
        End Get
        Set(ByVal Value As Integer)
            x = Value
            CalculateRowsAndColumns()
        End Set
    End Property

    Public Property VerticalSpacing() As Integer
        Get
            Return y
        End Get
        Set(ByVal Value As Integer)
            y = Value
            CalculateRowsAndColumns()
        End Set
    End Property

    Public Property ImageHeight() As Integer
        Get
            Return h
        End Get
        Set(ByVal Value As Integer)
            h = Value
            CalculateRowsAndColumns()
        End Set
    End Property

    Public Property ImageWidth() As Integer
        Get
            Return w
        End Get
        Set(ByVal Value As Integer)
            w = Value
            CalculateRowsAndColumns()
        End Set
    End Property

    Public Property SelectedIndex() As Integer
        Get
            Return m_SelectedIndex
        End Get
        Set(ByVal Value As Integer)
            'm_SelectedIndex = Value
            Dim myList As IList
            myList = List
            If Not myList Is Nothing Then
                Dim currentPosition As Integer
                Dim oldTopLeftItem, oldValue As Integer
                oldTopLeftItem = currentTopLeftItem
                oldValue = m_SelectedIndex
                If Value < 0 Then
                    m_SelectedIndex = Value
                ElseIf Value >= 0 And Value < myList.Count Then
                    'Me.DataManager.Position = Value
                    currentPosition = Value
                    If (currentPosition - currentTopLeftItem) >= (rowsPerPage * colsPerPage) Then
                        Do
                            currentTopLeftItem += (rowsPerPage * colsPerPage)
                        Loop Until (currentPosition - currentTopLeftItem) < (rowsPerPage * colsPerPage)
                    ElseIf (currentPosition - currentTopLeftItem) < 0 Then
                        Do
                            currentTopLeftItem -= (rowsPerPage * colsPerPage)
                        Loop Until (currentPosition - currentTopLeftItem) >= 0
                    End If
                    If currentTopLeftItem < 0 Then currentTopLeftItem = 0

                    If oldValue <> Value Then
                        m_SelectedIndex = Value
                        'Me.DataManager.Position = m_SelectedIndex
                        RaiseEvent SelectedIndexChanged(New System.EventArgs)
                        If oldTopLeftItem <> currentTopLeftItem Then
                            m_PicBox.Invalidate() 'redraw the whole thing
                        Else
                            Me.RefreshItem(oldValue)
                            Me.RefreshItem(Value)
                        End If
                    End If
                End If
            End If
        End Set
    End Property

    Public Sub Add(ByVal aThumbNail As CThumbNail)
        List.Add(aThumbNail)
    End Sub

    Public Function GetCount() As Integer
        Return List.Count
    End Function

    Public Sub InsertAt(ByVal index As Integer, ByVal aThumbNail As CThumbNail)
        If index > Count Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        ElseIf index = Count Then
            List.Add(aThumbNail)
        Else
            List.Insert(index, aThumbNail)
        End If
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            System.Windows.Forms.MessageBox.Show("Index not valid!")
        Else
            List.RemoveAt(index)
        End If
    End Sub

    Public Sub Remove(ByVal aThumbNail As CThumbNail)
        Me.List.Remove(aThumbNail)
    End Sub

    Default Public ReadOnly Property Item(ByVal index As Integer) As CThumbNail
        Get
            Return CType(List.Item(index), CThumbNail)
        End Get
    End Property

    Public Function GetItemByID(ByVal pId As Integer) As CThumbNail
        'Dim aThumbNail As CThumbNail
        For Each aThumbNail As CThumbNail In List
            If aThumbNail.ID = pId Then
                Return aThumbNail
                Exit For
            End If
        Next
        Return Nothing
    End Function

    Public Function MoveItem(ByVal pItemId As Integer, ByVal pDestItemID As Integer) As Integer
        Dim i As Integer = -1
        Dim pItem As CThumbNail = GetItemByID(pItemId)
        Remove(pItem)
        For Each aThumbNail As CThumbNail In List
            i += 1
            If aThumbNail.ID = pDestItemID Then
                InsertAt(i, pItem)
                Return i
                Exit For
            End If
        Next
        Return -1
    End Function

    Public Function GetMaxID() As Integer
        Dim iMax As Integer = 0
        For Each aThumbNail As CThumbNail In List
            If aThumbNail.ID > iMax Then
                iMax = aThumbNail.ID
            End If
        Next
        Return iMax
    End Function

    Private Sub m_PicBox_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_PicBox.MouseWheel
        Dim oldSelectedIndex As Integer = m_SelectedIndex
        If e.Delta > 0 Then
            If oldSelectedIndex > 0 Then
                SelectedIndex = oldSelectedIndex - 1
            End If
        ElseIf e.Delta < 0 Then
            If oldSelectedIndex < (List.Count - 1) Then
                SelectedIndex = oldSelectedIndex + 1
            End If
        End If
    End Sub

    Private Sub m_PicBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles m_PicBox.Paint
        Dim myList As IList
        Dim gr As Graphics = e.Graphics
        gr.SmoothingMode = SmoothingMode.AntiAlias
        'gr.Clear(Color.White)
        myList = List
        If Not myList Is Nothing Then 'if there is any data
            If myList.Count > 0 Then
                Dim itemCount As Integer
                itemCount = myList.Count

                Dim itemsDisplayed As Integer 'current position in the list
                itemsDisplayed = currentTopLeftItem

                Dim i, j As Integer 'loop indexes
                'Dim height, width As Integer

                For i = 0 To rowsPerPage - 1
                    For j = 0 To colsPerPage - 1
                        If itemsDisplayed < itemCount Then
                            DrawOneItem(itemsDisplayed, i, j, gr)
                            itemsDisplayed += 1
                        End If
                    Next
                Next

                'draw page down / page up indicators
                Dim webdingsFont As New Font("Webdings", 20, FontStyle.Regular, GraphicsUnit.Pixel)
                Dim textBrush As New SolidBrush(m_PicBox.ForeColor)

                If itemsDisplayed < itemCount - 1 Then
                    'draw down arrow
                    gr.DrawString("6", webdingsFont, textBrush, 0, m_PicBox.Height - 24)
                End If

                If currentTopLeftItem > 0 Then
                    'draw down arrow
                    gr.DrawString("5", webdingsFont, textBrush, 0, 0)
                End If
                webdingsFont.Dispose()
                textBrush.Dispose()
            End If
        End If

    End Sub

    Private Sub DrawOneItem(ByVal index As Integer, ByVal row As Integer, ByVal col As Integer, ByVal gr As Graphics)
        Dim textFont As Font = m_PicBox.Font
        Dim textBrush As New SolidBrush(m_PicBox.ForeColor)
        Dim Height, Width As Integer

        Dim myStringFormat As StringFormat = New StringFormat
        myStringFormat.Alignment = StringAlignment.Center
        myStringFormat.FormatFlags = StringFormatFlags.LineLimit

        Dim aThumbNail As CThumbNail = CType(List.Item(index), CThumbNail)
        Dim strKyHieu As String = aThumbNail.Symbols
        Dim mdrawingObjects As CGraphicObjs = CGraphicObjs.Str2Objects(strKyHieu, 0, 0) 'Str2Objects(strKyHieu)
        Dim mSiZe As Size = mdrawingObjects.GetSize

        'scale image to fit into defined size
        With mSiZe
            If .Height > h Then
                Height = h
                Width = CInt((h / .Height) * .Width)
            Else
                Height = .Height
                Width = .Width
            End If
            If Width > w Then
                Height = CInt((w / Width) * Height)
                Width = w
            End If
        End With

        Dim mRect _
            As New Rectangle((2 * x) + (col * ((2 * x) + w)), _
            (1 * y) + (row * ((2 * y) + h)), _
            w, h)
        gr.FillRectangle(New SolidBrush(Color.LightGray), mRect)

        Dim imageRect _
            As New Rectangle((2 * x) + (col * ((2 * x) + w)) + ((w - Width) \ 2), _
            (1 * y) + (row * ((2 * y) + h)) + ((h - Height) \ 2), _
            Width, Height)

        DrawThumbNail(gr, mdrawingObjects, imageRect)

        Dim myNewPen As Pen
        'If index = Me.DataManager.Position Then  'selected
        If index = m_SelectedIndex Then   'selected
            myNewPen = New Pen(Color.Yellow)
            'myNewPen = New Pen(Color.Gray)
            myNewPen.Width = 4
            gr.DrawRectangle(myNewPen, mRect)
            myNewPen.Dispose()
        End If
        'End If

        Dim textHeight As Integer = y * 2
        gr.DrawString(aThumbNail.Value, _
            textFont, textBrush, _
            New RectangleF((x) + (col * ((2 * x) + w)), _
                2 + (1 * y) + h + (row * ((2 * y) + h)), _
                w + (2 * x), textHeight), myStringFormat)

        mdrawingObjects = Nothing
    End Sub

    Private Sub DrawThumbNail(ByVal g As Graphics, ByVal mObjs As CGraphicObjs, ByVal imageRect As Rectangle)
        'Dim drawObj As MapObjects.GraphicObject
        Dim Scale As Single
        Dim ImageW As Single = mObjs.GetSize.Width
        If ImageW > 0 Then
            Scale = imageRect.Width / ImageW
        Else
            Scale = 1
        End If
        'Dim Scale As Single = imageRect.Width / mObjs.GetSize.Width

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(imageRect.X, imageRect.Y)
        g.ScaleTransform(Scale, Scale)
        For Each drawObj As GraphicObject In mObjs
            If Not drawObj.GetObjType = OBJECTTYPE.Text Then
                drawObj.Draw(g)
            End If
        Next
        g.EndContainer(gCon)
    End Sub

    Public Sub CalculateRowsAndColumns()
        Dim new_rowsPerPage As Integer = (m_PicBox.Height - y) \ ((2 * y) + h)
        Dim new_colsPerPage As Integer = m_PicBox.Width \ ((2 * x) + w)
        If (new_rowsPerPage <> rowsPerPage) OrElse (new_colsPerPage <> colsPerPage) Then
            rowsPerPage = new_rowsPerPage
            colsPerPage = new_colsPerPage
        End If
    End Sub

    Private Function GetItemRect(ByVal index As Integer) As Rectangle
        Dim selectedRow, selectedColumn As Integer
        selectedRow = CInt(System.Math.Floor((index - currentTopLeftItem) / colsPerPage))
        selectedColumn = (index - currentTopLeftItem) Mod colsPerPage
        Dim itemRect As New Rectangle((x) + (selectedColumn * ((2 * x) + w)), _
                                    (1 * y) + (selectedRow * ((2 * y) + h)), _
                                    w + (2 * x), h + (y * 2))
        Return itemRect
    End Function

    Private Sub m_PicBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_PicBox.Resize
        CalculateRowsAndColumns()
        m_PicBox.Invalidate()
    End Sub

    Public Sub New(ByVal pPicBox As PictureBox)
        m_PicBox = pPicBox
        w = defaImageWidth
        h = defaImageHeight
        x = defaHorizontalSpacing
        y = defaVerticalSpacing

        CalculateRowsAndColumns()
        SelectedIndex = 0 '-1
    End Sub

    Private Function HitTest(ByVal loc As Point) As Integer
        Dim i As Integer
        Dim found As Boolean = False
        i = 0
        Do While i < List.Count And Not found
            If GetItemRect(i).Contains(loc) Then
                found = True
            Else
                i += 1
            End If
        Loop
        If found Then
            Return i
        Else
            Return -1
        End If
    End Function

    Protected Sub RefreshItem(ByVal index As Integer)
        Debug.WriteLine(String.Format("Refreshing {0}", index))
        Dim itemRect As Rectangle = GetItemRect(index)
        itemRect.Inflate(5, 5)
        m_PicBox.Invalidate(itemRect)
    End Sub

    Private Sub m_PicBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles m_PicBox.MouseUp
        'If e.Button = MouseButtons.Left Then
        'End If
        Dim mouseLoc As Point = New Point(e.X, e.Y) ' m_PicBox.PointToClient(m_PicBox.MousePosition)   'Me.PointToClient(Me.MousePosition())
        Dim itemHit As Integer = HitTest(mouseLoc)
        If itemHit <> -1 Then
            SelectedIndex = itemHit
        Else
            SelectedIndex = -1
        End If
        'm_PicBox.Focus()
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If SelectedIndex > -1 Then
                fCacKyHieu.cmnuKyHieu.Show(fCacKyHieu.picThumbNails, New Point(e.X, e.Y))
            Else
                fCacKyHieu.cmnuThumbNail.Show(fCacKyHieu.picThumbNails, New Point(e.X, e.Y))
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then
            If SelectedIndex > -1 Then
                fMain.myBando.ChuanBiNhanKH()
            Else
                fMain.myBando.NhanKHXong()
            End If
        End If

        m_PicBox.Invalidate()

    End Sub

End Class
