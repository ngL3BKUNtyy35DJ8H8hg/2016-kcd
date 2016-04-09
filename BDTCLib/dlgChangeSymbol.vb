Imports System.Windows.Forms
Imports DBiGraphicObjs.DBiGraphicObjects
Imports System.Drawing

Public Class dlgChangeSymbol

    Private m_Symbols As CSymbols

    Private AColors() As Color
    Private LineColor As Color = Color.Black

    Private AFillColors() As Color
    Private FillColor As Color = Color.FromArgb(100, Color.Red)

    Private AWidths() As Integer
    Private LineWidth As Integer = 1

    Private AStyles() As Integer
    Private LineStyle As Integer = 0

    'Private MaxStyle As Integer = 9
    'Private ADStyles() As Integer

    Private m_drawingObjects As CGraphicObjs
    Private m_Scale As Single = 1

    Property Symbols() As CSymbols
        Get
            Return m_Symbols
        End Get
        Set(ByVal Value As CSymbols)
            m_Symbols = Value
        End Set
    End Property

    Private Sub Change1Color(ByVal SColor As Color, ByVal DColor As Color)
        For Each mSymbol As CSymbol In m_Symbols
            For Each mObj As GraphicObject In mSymbol.GObjs
                Select Case mObj.GetObjType
                    Case OBJECTTYPE.Text
                        Dim mText As TextGraphic = CType(mObj, TextGraphic)
                        If mText.Color.ToArgb = SColor.ToArgb Then
                            mText.Color = DColor
                        End If
                    Case OBJECTTYPE.Table
                        Dim mTable As TableGraphic = CType(mObj, TableGraphic)
                        If mTable.BorderColor.ToArgb = SColor.ToArgb Then
                            mTable.BorderColor = DColor
                        End If
                        If mTable.LineColor.ToArgb = SColor.ToArgb Then
                            mTable.LineColor = DColor
                        End If
                        For Each mCell As CCell In mTable.Cells
                            If mCell.Color.ToArgb = SColor.ToArgb Then
                                mCell.Color = DColor
                            End If
                        Next
                    Case Else
                        Dim mShape As ShapeGraphic = CType(mObj, ShapeGraphic)
                        If mShape.LineColor.ToArgb = SColor.ToArgb Then
                            mShape.LineColor = DColor
                        End If
                        If mShape.Line2Color.ToArgb = SColor.ToArgb Then
                            mShape.Line2Color = DColor
                        End If
                        If mShape.HatchColor.ToArgb = SColor.ToArgb Then
                            mShape.HatchColor = DColor
                        End If
                End Select
            Next
        Next

    End Sub

    Private Sub Change1FillColor(ByVal SColor As Color, ByVal DColor As Color)
        For Each mSymbol As CSymbol In m_Symbols
            For Each mObj As GraphicObject In mSymbol.GObjs
                Select Case mObj.GetObjType
                    Case OBJECTTYPE.Text
                    Case OBJECTTYPE.Table
                        Dim mTable As TableGraphic = CType(mObj, TableGraphic)
                        If mTable.FiColor.ToArgb = SColor.ToArgb Then
                            mTable.FiColor = DColor
                        End If
                    Case Else
                        Dim mShape As ShapeGraphic = CType(mObj, ShapeGraphic)
                        If mShape.FillColor.ToArgb = SColor.ToArgb Then
                            mShape.FillColor = DColor
                        End If
                End Select
            Next
        Next
    End Sub

    Private Sub Change1Style(ByVal SStyle As Integer, ByVal DStyle As Integer)
        For Each mSymbol As CSymbol In m_Symbols
            For Each mObj As GraphicObject In mSymbol.GObjs
                Select Case mObj.GetObjType
                    Case OBJECTTYPE.Text
                    Case OBJECTTYPE.Table
                    Case Else
                        Dim mShape As ShapeGraphic = CType(mObj, ShapeGraphic)
                        If mShape.LineStyle = SStyle Then
                            mShape.LineStyle = DStyle
                        End If
                End Select
            Next
        Next
    End Sub

    Private Sub Change1Width(ByVal SWidth As Integer, ByVal DWidth As Integer)
        For Each mSymbol As CSymbol In m_Symbols
            For Each mObj As GraphicObject In mSymbol.GObjs
                Select Case mObj.GetObjType
                    Case OBJECTTYPE.Text
                    Case OBJECTTYPE.Table
                    Case Else
                        Dim mShape As ShapeGraphic = CType(mObj, ShapeGraphic)
                        If mShape.LineWidth = SWidth Then
                            If DWidth > 0 Then
                                mShape.LineWidth = DWidth
                            Else
                                mShape.LineWidth = 1
                            End If
                        End If
                        If mShape.Line2Width = SWidth Then
                            mShape.Line2Width = DWidth
                        End If
                End Select
            Next
        Next
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If (Me.lstLineColor.SelectedItems.Count + Me.lstFillColor.SelectedItems.Count + _
        Me.lstLineWidth.SelectedItems.Count + Me.lstLineStyle.SelectedItems.Count) > 0 Then
            fMain.myBando.PopUndo()

            If Me.lstLineColor.SelectedItems.Count > 0 Then
                For i As Integer = 0 To Me.lstLineColor.SelectedItems.Count - 1
                    Dim SColor As Color = lstLineColor.SelectedItems(i)
                    Change1Color(SColor, LineColor)
                Next
            End If

            If Me.lstFillColor.SelectedItems.Count > 0 Then
                FillColor = Color.FromArgb(Me.nudAlpha.Value, FillColor)
                For i As Integer = 0 To Me.lstFillColor.SelectedItems.Count - 1
                    Dim SColor As Color = lstFillColor.SelectedItems(i)
                    Change1FillColor(SColor, FillColor)
                Next
            End If

            If Me.lstLineStyle.SelectedItems.Count > 0 Then
                For i As Integer = 0 To Me.lstLineStyle.SelectedItems.Count - 1
                    Dim SStyle As Integer = lstLineStyle.SelectedItems(i)
                    Change1Style(SStyle, Val(Me.cboStyle.SelectedItem))
                Next
            End If

            If Me.lstLineWidth.SelectedItems.Count > 0 Then
                For i As Integer = 0 To Me.lstLineWidth.SelectedItems.Count - 1
                    Dim SWidth As Integer = lstLineWidth.SelectedItems(i)
                    Change1Width(SWidth, Me.nudLineWidth.Value)
                Next
            End If

            fMain.myBando.RefreshMap()
            Me.Close()
        Else
            MsgBox("Chưa chọn cái cần đổi.")
        End If
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PopulationLists()
        ReDim AColors(-1)
        Dim i As Integer = -1
        ReDim AFillColors(-1)
        Dim iFill As Integer = -1
        ReDim AWidths(-1)
        Dim iWidth As Integer = -1
        ReDim AStyles(-1)
        Dim iStyle As Integer = -1

        For Each mSymbol As CSymbol In m_Symbols
            For Each mObj As GraphicObject In mSymbol.GObjs
                Select Case mObj.GetObjType
                    Case OBJECTTYPE.Text
                        Dim mText As TextGraphic = CType(mObj, TextGraphic)
                        If IsNewColor(mText.Color) Then
                            i += 1
                            ReDim Preserve AColors(i)
                            AColors(i) = mText.Color
                        End If

                    Case OBJECTTYPE.Table
                        Dim mTable As TableGraphic = CType(mObj, TableGraphic)
                        If IsNewColor(mTable.BorderColor) Then
                            i += 1
                            ReDim Preserve AColors(i)
                            AColors(i) = mTable.BorderColor
                        End If
                        If IsNewColor(mTable.LineColor) Then
                            i += 1
                            ReDim Preserve AColors(i)
                            AColors(i) = mTable.LineColor
                        End If
                        For Each mCell As CCell In mTable.Cells
                            If IsNewColor(mCell.Color) Then
                                i += 1
                                ReDim Preserve AColors(i)
                                AColors(i) = mCell.Color
                            End If
                        Next
                        If IsNewFillColor(mTable.FiColor) Then
                            iFill += 1
                            ReDim Preserve AFillColors(iFill)
                            AFillColors(iFill) = mTable.FiColor
                        End If

                        If IsNewWidth(mTable.LineWidth) Then
                            iWidth += 1
                            ReDim Preserve AWidths(iWidth)
                            AWidths(iWidth) = mTable.LineWidth
                        End If

                        If IsNewWidth(mTable.BorderWidth) Then
                            iWidth += 1
                            ReDim Preserve AWidths(iWidth)
                            AWidths(iWidth) = mTable.BorderWidth
                        End If

                    Case Else
                        Dim mShape As ShapeGraphic = CType(mObj, ShapeGraphic)
                        If IsNewColor(mShape.LineColor) Then
                            i += 1
                            ReDim Preserve AColors(i)
                            AColors(i) = mShape.LineColor
                        End If
                        If mShape.Line2Width > 0 Then
                            If IsNewColor(mShape.Line2Color) Then
                                i += 1
                                ReDim Preserve AColors(i)
                                AColors(i) = mShape.Line2Color
                            End If
                        End If
                        If mShape.Fill = True Then
                            If IsNewFillColor(mShape.FillColor) Then
                                iFill += 1
                                ReDim Preserve AFillColors(iFill)
                                AFillColors(iFill) = mShape.FillColor
                            End If
                            If IsNewColor(mShape.HatchColor) Then
                                i += 1
                                ReDim Preserve AColors(i)
                                AColors(i) = mShape.HatchColor
                            End If
                        End If

                        If IsNewWidth(mShape.LineWidth) Then
                            iWidth += 1
                            ReDim Preserve AWidths(iWidth)
                            AWidths(iWidth) = mShape.LineWidth
                        End If

                        If IsNewWidth(mShape.Line2Width) Then
                            iWidth += 1
                            ReDim Preserve AWidths(iWidth)
                            AWidths(iWidth) = mShape.Line2Width
                        End If

                        If IsNewStyle(mShape.LineStyle) Then
                            iStyle += 1
                            ReDim Preserve AStyles(iStyle)
                            AStyles(iStyle) = mShape.LineStyle
                        End If

                End Select
            Next
        Next

        For j As Integer = 0 To AColors.GetUpperBound(0)
            Me.lstLineColor.Items.Add(AColors(j))
        Next

        For j As Integer = 0 To AFillColors.GetUpperBound(0)
            Me.lstFillColor.Items.Add(AFillColors(j))
        Next

        For j As Integer = 0 To AWidths.GetUpperBound(0)
            Me.lstLineWidth.Items.Add(AWidths(j))
        Next

        For j As Integer = 0 To AStyles.GetUpperBound(0)
            Me.lstLineStyle.Items.Add(AStyles(j))
        Next
    End Sub

    Private Function IsNewColor(ByVal pColor As Color) As Boolean
        For i As Integer = 0 To AColors.GetUpperBound(0)
            If pColor.ToArgb = AColors(i).ToArgb Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function IsNewFillColor(ByVal pColor As Color) As Boolean
        For i As Integer = 0 To AFillColors.GetUpperBound(0)
            If pColor.ToArgb = AFillColors(i).ToArgb Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function IsNewWidth(ByVal pWidth As Integer) As Boolean
        For i As Integer = 0 To AWidths.GetUpperBound(0)
            If pWidth = AWidths(i) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function IsNewStyle(ByVal pStyle As Integer) As Boolean
        For i As Integer = 0 To AStyles.GetUpperBound(0)
            If pStyle = AStyles(i) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub dlgChangeSymbol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReDim ADStyles(MaxStyle)
        For j As Integer = 0 To ADStyles.GetUpperBound(0)
            ADStyles(j) = j
            Me.cboStyle.Items.Add(ADStyles(j))
        Next

        PopulationLists()
        Me.cboStyle.SelectedIndex = 0
    End Sub

    Private Sub lstLineColor_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstLineColor.DrawItem
        Dim brColor As Brush = Nothing

        Try
            Dim brText As Brush
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                brText = Brushes.White
            Else
                brText = Brushes.Black
            End If
            e.DrawBackground()
            Dim rct As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 15, 10)
            Dim penOutline As Pen = Pens.Black
            brColor = New SolidBrush(AColors(e.Index))
            e.Graphics.DrawRectangle(penOutline, rct)
            e.Graphics.FillRectangle(brColor, rct)
            e.Graphics.DrawString(AColors(e.Index).R.ToString & "," & AColors(e.Index).G.ToString & "," & AColors(e.Index).B.ToString, Me.lstLineColor.Font, brText, rct.Left + rct.Width + 5, e.Bounds.Y)

            e.DrawFocusRectangle()

        Catch ex As Exception
        Finally
            If Not brColor Is Nothing Then
                brColor.Dispose()
            End If
        End Try
    End Sub

    Private Sub picLineColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picLineColor.DoubleClick
        LineColor = GetMau(LineColor)
        picLineColor.Invalidate()
    End Sub

    Private Sub picFillColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picFillColor.DoubleClick
        FillColor = GetMau(FillColor)
        FillColor = Color.FromArgb(Me.nudAlpha.Value, FillColor)
        picFillColor.Invalidate()
    End Sub

    Private Sub picFillColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picFillColor.Paint
        Dim rct As New Rectangle(5, 5, 15, 10)
        Dim penOutline As Pen = Pens.Black
        Dim brColor = New SolidBrush(Color.FromArgb(255, FillColor.R, FillColor.G, FillColor.B))
        e.Graphics.DrawRectangle(penOutline, rct)
        e.Graphics.FillRectangle(brColor, rct)
    End Sub

    Private Sub lstFillColor_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstFillColor.DrawItem
        Dim brColor As Brush = Nothing

        Try
            Dim brText As Brush
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                brText = Brushes.White
            Else
                brText = Brushes.Black
            End If
            e.DrawBackground()
            Dim rct As New Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 15, 10)
            Dim penOutline As Pen = Pens.Black
            brColor = New SolidBrush(AFillColors(e.Index))
            e.Graphics.DrawRectangle(penOutline, rct)
            e.Graphics.FillRectangle(brColor, rct)
            e.Graphics.DrawString(AFillColors(e.Index).R.ToString & "," & AFillColors(e.Index).G.ToString & "," & AFillColors(e.Index).B.ToString & "|" & AFillColors(e.Index).A.ToString, Me.lstFillColor.Font, brText, rct.Left + rct.Width + 5, e.Bounds.Y)

            e.DrawFocusRectangle()

        Catch ex As Exception
        Finally
            If Not brColor Is Nothing Then
                brColor.Dispose()
            End If
        End Try

    End Sub

    Private Sub lstFillColor_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFillColor.SelectedValueChanged
        If lstFillColor.SelectedItems.Count > 0 Then
            FillColor = lstFillColor.SelectedItems(lstFillColor.SelectedItems.Count - 1)
            Me.nudAlpha.Value = FillColor.A
            Me.picFillColor.Invalidate()
        End If
    End Sub

    Private Sub lstLineStyle_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstLineStyle.DrawItem
        'Dim brColor As Brush
        Try
            Dim brText As Brush
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                brText = Brushes.White
            Else
                brText = Brushes.Black
            End If
            e.DrawBackground()
            'brColor = New SolidBrush(AColors(e.Index))
            e.Graphics.DrawString(AStyles(e.Index).ToString, Me.lstLineStyle.Font, brText, e.Bounds.X + 5, e.Bounds.Y + 10)
            m_drawingObjects = GetLineObj(e.Bounds.X + 20, e.Bounds.Y + 20, e.Bounds.X + e.Bounds.Width - 5, e.Bounds.Y + 20, 1, AStyles(e.Index))
            m_drawingObjects.DrawObjects(e.Graphics, m_Scale)

            e.DrawFocusRectangle()

        Catch ex As Exception
        Finally
            'If Not brColor Is Nothing Then
            'brColor.Dispose()
            'End If
        End Try
    End Sub

    Private Function GetLineObj(ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal width As Integer, ByVal style As Integer) As CGraphicObjs
        Dim mDrawingObjects As New CGraphicObjs
        Dim gObj As GraphicObject
        Dim mPts(1) As PointF
        mPts(0).X = x1
        mPts(0).Y = y1
        mPts(1).X = x2
        mPts(1).Y = y2

        Dim myLine As New LinesGraphic(mPts, 1, Color.Red)
        myLine.LineStyle = style
        myLine.StyleWidth = 10
        myLine.LineWidth = width
        gObj = myLine
        If Not gObj Is Nothing Then
            mDrawingObjects.Add(gObj)
        End If
        Return mDrawingObjects
    End Function

    Private Sub lstLineWidth_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstLineWidth.DrawItem
        Try
            Dim brText As Brush
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                brText = Brushes.White
            Else
                brText = Brushes.Black
            End If
            e.DrawBackground()
            e.Graphics.DrawString(AWidths(e.Index).ToString, Me.lstLineWidth.Font, brText, e.Bounds.X + 5, e.Bounds.Y)
            m_drawingObjects = GetLineObj(e.Bounds.X + 20, e.Bounds.Y + 10, e.Bounds.X + e.Bounds.Width - 25, e.Bounds.Y + 10, AWidths(e.Index), 0)
            m_drawingObjects.DrawObjects(e.Graphics, m_Scale)

            e.DrawFocusRectangle()

        Catch ex As Exception
        Finally
        End Try

    End Sub

    Private Sub cboStyle_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboStyle.DrawItem
        Try
            Dim brText As Brush
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                brText = Brushes.White
            Else
                brText = Brushes.Black
            End If
            e.DrawBackground()
            e.Graphics.DrawString(ADStyles(e.Index).ToString, Me.cboStyle.Font, brText, e.Bounds.X + 5, e.Bounds.Y + 10)
            m_drawingObjects = GetLineObj(e.Bounds.X + 20, e.Bounds.Y + 20, e.Bounds.X + e.Bounds.Width - 5, e.Bounds.Y + 20, 1, ADStyles(e.Index))
            m_drawingObjects.DrawObjects(e.Graphics, m_Scale)

            e.DrawFocusRectangle()

        Catch ex As Exception
        Finally
        End Try

    End Sub

    Private Sub picLineColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picLineColor.Paint
        Dim rct As New Rectangle(5, 5, 15, 10)
        Dim penOutline As Pen = Pens.Black
        Dim brColor = New SolidBrush(LineColor)
        e.Graphics.DrawRectangle(penOutline, rct)
        e.Graphics.FillRectangle(brColor, rct)
    End Sub
End Class
