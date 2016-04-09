Imports System.Windows.Forms
Imports System.Drawing
Imports DBiGraphicObjs.DBiGraphicObjects

Public Class dlgChangeTable

    Private Enum myTableTools
        CellChange
        WChange
        HChange
    End Enum

    Private pointTL As Point

    Public myScale As Integer = 4
    'Public myGridWidth As Integer = 2
    Public myWidth As Integer = 100
    Public myHeight As Integer = 80

    Dim myTool As myTableTools = myTableTools.CellChange
    Dim myPrevPt, myPrevPt0 As New Point

    Dim myBanDo As CBanDo
    Dim myTable As TableGraphic
    Dim curCol, curRow As Integer
    'Dim curCellW, curCellH As Integer
    Dim icurCell As Integer

    Dim SeleCell As CCell

    Dim savRotation As Single

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgChangeTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If fCallForm Is fMain Then
            myBanDo = fMain.myBando
        End If

        'Dim mColor As New Color
        Dim myObj As TableGraphic
        If fCallForm Is fCacKyHieu Then
            myObj = CType(fCacKyHieu.SelectedObject, TableGraphic)
        Else
            myObj = CType(myBanDo.SelectedObject, TableGraphic)
        End If

        savRotation = myObj.Rotation
        myTable = myObj.Clone
        myTable.Rotation = 0

        myWidth = myTable.Width + 4
        myHeight = myTable.Height + 4
        myScale = 1
        pointTL = New Point(0, 0)
        'Me.PictureBox1.Location = pointTL
        'Me.PictureBox1.Size = New Size(myWidth * myScale, myHeight * myScale)
        DisplayScrollBars()
        'PictureBox1.Invalidate()

        txtColor.BackColor = myTable.BorderColor
        txtColor2.BackColor = myTable.LineColor

        Me.nudPenWidth.Value = myTable.BorderWidth
        Me.nudPenWidth2.Value = myTable.LineWidth

        txtBrushColor.BackColor = Color.FromArgb(255, myTable.FiColor.R, myTable.FiColor.G, myTable.FiColor.B)
        Me.nudAlpha.Value = myTable.FiColor.A

        'Me.TextBox1.Font = myTable.Font
        'Me.TextBox1.Font = New Font(myTable.Font.FontFamily, myTable.Font.Size - 2, myTable.Font.Style)
        'Me.TextBox1.ForeColor = myTable.Color

        curCol = 0
        curRow = 0

        SeleCell = myTable.Cells(0)
        PopulateCellInfo()

        PictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow

        Me.TextBox1.ContextMenu = Me.ContextMenu1
    End Sub

    Private Sub txtBrushColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBrushColor.DoubleClick
        txtBrushColor.BackColor = GetMau(txtBrushColor.BackColor)
        'myTable.FillColor = txtBrushColor.BackColor
        myTable.FiColor = Color.FromArgb(nudAlpha.Value, txtBrushColor.BackColor)
        Me.PictureBox1.Invalidate()
    End Sub

    Private Sub txtColor2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColor2.DoubleClick
        txtColor2.BackColor = GetMau(txtColor2.BackColor)
        myTable.LineColor = txtColor2.BackColor
        Me.PictureBox1.Invalidate()
    End Sub

    Private Sub txtColor_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColor.DoubleClick
        txtColor.BackColor = GetMau(txtColor.BackColor)
        myTable.BorderColor = txtColor.BackColor
        Me.PictureBox1.Invalidate()
    End Sub

    Private Sub PictureBox1_Paint1(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        'myTable.Draw(e.Graphics)

        Dim g As Graphics = e.Graphics
        'Dim Scale As Single = m_Zoom / pMap.Zoom
        'Scale *= IIf(m_MWidth > 0, (pMap.MapScreenWidth / m_MWidth), 1)
        Dim mX, mY As Single
        'pMap.ConvertCoord(mX, mY, m_GocX, m_GocY, MapXLib.ConversionConstants.miMapToScreen)
        mX = -myTable.X '+ pointTL.X
        mY = -myTable.Y '+ pointTL.Y

        Dim gCon As Drawing2D.GraphicsContainer
        gCon = g.BeginContainer
        g.TranslateTransform(mX, mY)
        'g.ScaleTransform(Scale, Scale)
        myTable.Draw(g)
        g.EndContainer(gCon)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            'myTable.AText(curRow * myTable.ColsNo + curCol) = TextBox1.Text
            SeleCell.Text = TextBox1.Text
            Me.PictureBox1.Invalidate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PopulateCellInfo()
        If Not IsNothing(SeleCell) Then
            Dim rect As Rectangle = GetCellBounds(SeleCell)

            TextBox1.Left = rect.X + pointTL.X
            TextBox1.Top = rect.Y + pointTL.Y
            TextBox1.Width = rect.Width + 2  'myTable.AWidth(curCol) + 2
            TextBox1.Height = rect.Height + 2  'myTable.AHeight(curRow) + 2

            Me.TextBox1.Font = SeleCell.Font
            Me.TextBox1.ForeColor = SeleCell.Color
            TextBox1.Text = SeleCell.Text 'myTable.AText(curRow * myTable.ColsNo + curCol)

            curCol = SeleCell.iCol + SeleCell.ColsNo - 1
            curRow = SeleCell.iRow + SeleCell.RowsNo - 1

        End If

        Me.PictureBox1.Invalidate()

        UpdateScrollBars()
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If myTool = myTableTools.CellChange Then
            If e.X = Me.TextBox1.Left + Me.TextBox1.Width - pointTL.X Then
                PictureBox1.Cursor = System.Windows.Forms.Cursors.SizeWE
            ElseIf e.Y = Me.TextBox1.Top + Me.TextBox1.Height - pointTL.Y Then
                PictureBox1.Cursor = System.Windows.Forms.Cursors.SizeNS
            Else
                PictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow
            End If
        ElseIf myTool = myTableTools.HChange Then
            'MovingHLine(e.Y)
            Dim mDy As Integer = e.Y - myPrevPt.Y
            If myTable.AHeight(curRow) + mDy > 0 Then
                Try
                    myTable.Height += mDy
                    myTable.AHeight(curRow) += mDy
                    myHeight = myTable.Height + 4
                    'DisplayScrollBars()
                    'Me.PictureBox1.Height = myHeight * myScale
                    'UpdateScrollBars()
                    Me.PictureBox1.Invalidate()
                    Me.TextBox1.Height = myTable.AHeight(curRow)
                Catch ex As Exception

                End Try
            End If
            myPrevPt.Y = e.Y '+ pointTL.Y
        ElseIf myTool = myTableTools.WChange Then
            'MovingVLine(e.X)
            Dim mDx As Integer = e.X - myPrevPt.X
            If myTable.AWidth(curCol) + mDx > 0 Then
                Try
                    myTable.Width += mDx
                    myTable.AWidth(curCol) += mDx
                    myWidth = myTable.Width + 4
                    'DisplayScrollBars()
                    'Me.PictureBox1.Width = myWidth * myScale
                    'UpdateScrollBars()
                    Me.PictureBox1.Invalidate()
                    Me.TextBox1.Width = myTable.AWidth(curCol)
                Catch ex As Exception

                End Try
            End If
            myPrevPt.X = e.X '+ pointTL.X
        End If

    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If Me.PictureBox1.Cursor Is System.Windows.Forms.Cursors.SizeWE Then
            myTool = myTableTools.WChange
            myPrevPt0.X = e.X
            myPrevPt.X = e.X '+ pointTL.X
            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.SizeWE
            Me.TextBox1.Visible = False
        ElseIf Me.PictureBox1.Cursor Is System.Windows.Forms.Cursors.SizeNS Then
            myTool = myTableTools.HChange
            myPrevPt0.Y = e.Y
            myPrevPt.Y = e.Y '+ pointTL.Y
            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.SizeNS
            Me.TextBox1.Visible = False
        Else
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If myTool = myTableTools.WChange Then
            UpdateScrollBars()
            Me.TextBox1.Visible = True
            myTool = myTableTools.CellChange
            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow
            If Not IsNothing(SeleCell) Then
                PopulateCellInfo()
            End If
        ElseIf myTool = myTableTools.HChange Then
            UpdateScrollBars()
            Me.TextBox1.Visible = True
            myTool = myTableTools.CellChange
            Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow
            If Not IsNothing(SeleCell) Then
                PopulateCellInfo()
            End If
        Else 'If Me.PictureBox1.Cursor Is System.Windows.Forms.Cursors.Default Then
            SeleCell = FindCellAtPoint(New PointF(e.X, e.Y))
            If Not IsNothing(SeleCell) Then
                PopulateCellInfo()
            End If
        End If
    End Sub

    Private Sub mnuInsertRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsertRow.Click
        If Not IsNothing(SeleCell) Then
            myTable.InsertRow(SeleCell)

            myHeight = myTable.Height + 4
            UpdateScrollBars()
            Me.PictureBox1.Invalidate()
        End If
    End Sub

    Private Sub mnuDeleteRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDeleteRow.Click
        If myTable.RowsNo > 1 Then
            'Chi xoa neu SeleCell.RowsNo=1
            If SeleCell.RowsNo = 1 Then
                myTable.DeleteRow(curRow)
                If curRow > myTable.RowsNo - 1 Then
                    curRow = myTable.RowsNo - 1
                Else
                    curRow = 0
                End If
                SeleCell = myTable.GetCell(curRow, curCol)
                PopulateCellInfo()
            Else
                MsgBox("Chi xoa khi O nay co 1 dong.")
            End If
        End If
    End Sub

    Private Sub mnuInsertCol_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsertCol.Click
        If Not IsNothing(SeleCell) Then
            'MsgBox(myTable.Cells.Count)
            myTable.InsertCol(SeleCell)
            'MsgBox(myTable.Cells.Count)

            myWidth = myTable.Width + 4
            UpdateScrollBars()

            Me.PictureBox1.Invalidate()

        End If
    End Sub

    Private Sub mnuDeleteCol_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuDeleteCol.Click
        If myTable.ColsNo > 1 Then
            'Chi xoa neu SeleCell.ColsNo=1
            If SeleCell.ColsNo = 1 Then
                myTable.DeleteCol(curCol)
                If curCol > myTable.ColsNo - 1 Then
                    curCol = myTable.ColsNo - 1
                Else
                    curCol = 0
                End If
                SeleCell = myTable.GetCell(curRow, curCol)
                PopulateCellInfo()
            Else
                MsgBox("Chi xoa khi O nay co 1 cot.")
            End If
        End If
    End Sub

    Private Sub nudAlpha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudAlpha.ValueChanged
        Try
            myTable.FiColor = Color.FromArgb(nudAlpha.Value, txtBrushColor.BackColor)
            Me.PictureBox1.Invalidate()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub nudPenWidth_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudPenWidth.ValueChanged
        Try
            myTable.BorderWidth = nudPenWidth.Value
            Me.PictureBox1.Invalidate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub nudPenWidth2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudPenWidth2.ValueChanged
        Try
            myTable.LineWidth = nudPenWidth2.Value
            Me.PictureBox1.Invalidate()
        Catch ex As Exception

        End Try

    End Sub

    Private Function FindCellAtPoint(ByVal pt As PointF) As CCell
        Dim objCell As CCell
        'If Not myTable.Cells.Count > 0 Then
        For Each mCell As CCell In myTable.Cells
            If HitTest(mCell, pt) Then
                Return mCell
                Exit For
            End If
        Next
        'End If
        Return Nothing
    End Function

    Private Function HitTest(ByVal mCell As CCell, ByVal pt As System.Drawing.PointF) As Boolean
        Dim gp As New Drawing2D.GraphicsPath

        Dim rect As Rectangle = GetCellBounds(mCell)

        gp.AddRectangle(rect)
        Return gp.IsVisible(pt)
    End Function

    Private Function GetCellBounds(ByVal pCell As CCell) As Rectangle
        Dim mX, mY As Single
        Dim mW, mH As Single
        mX = 0
        If pCell.iCol > 0 Then
            For i As Integer = 0 To pCell.iCol - 1
                mX += myTable.AWidth(i) * myScale
            Next
        End If
        mW = 0
        For i As Integer = 0 To pCell.ColsNo - 1
            mW += myTable.AWidth(pCell.iCol + i) * myScale
        Next

        mY = 0
        If pCell.iRow > 0 Then
            For i As Integer = 0 To pCell.iRow - 1
                mY += myTable.AHeight(i) * myScale
            Next
        End If
        mH = 0
        For i As Integer = 0 To pCell.RowsNo - 1
            mH += myTable.AHeight(pCell.iRow + i) * myScale
        Next

        'Dim rect As New Rectangle(mX, mY, mW, mH)
        Return New Rectangle(mX, mY, mW, mH)

    End Function

    Private Sub mnuLinkRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuLinkRight.Click
        If Not IsNothing(SeleCell) Then
            'MsgBox(myTable.Cells.Count)
            myTable.LinkCellRight(SeleCell)
            'MsgBox(myTable.Cells.Count)
            'Me.PictureBox1.Invalidate()
            PopulateCellInfo()
        End If
    End Sub

    Private Sub mnuLinkDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuLinkDown.Click
        If Not IsNothing(SeleCell) Then
            myTable.LinkCellDown(SeleCell)
            PopulateCellInfo()
        End If
    End Sub

    Private Sub mnuTextFont_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTextFont.Click
        If Not IsNothing(SeleCell) Then
            Dim fontDialog1 As FontDialog = New FontDialog
            fontDialog1.Font = SeleCell.Font
            fontDialog1.Color = SeleCell.Color
            fontDialog1.ShowColor = True
            If fontDialog1.ShowDialog() <> DialogResult.Cancel Then
                SeleCell.Font = fontDialog1.Font
                SeleCell.Color = fontDialog1.Color
                PopulateCellInfo()
            End If
        End If
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If Not IsNothing(myBanDo) Then
            myBanDo.PopUndo()
        End If

        Dim myObj As TableGraphic
        If fCallForm Is fCacKyHieu Then
            myObj = CType(fCacKyHieu.SelectedObject, TableGraphic)
        Else
            myObj = CType(myBanDo.SelectedObject, TableGraphic)
        End If

        myObj.AHeight = myTable.AHeight
        myObj.AWidth = myTable.AWidth
        myObj.BorderColor = myTable.BorderColor
        myObj.BorderWidth = myTable.BorderWidth
        myObj.Cells = myTable.Cells
        myObj.ColsNo = myTable.ColsNo
        myObj.FiColor = myTable.FiColor
        myObj.Height = myTable.Height
        myObj.LineColor = myTable.LineColor
        myObj.LineWidth = myTable.LineWidth
        myObj.RowsNo = myTable.RowsNo
        myObj.Width = myTable.Width

        myObj.Rotation = savRotation

        Me.Close()

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

    Public Sub UpdateScrollBars()
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
    End Sub

    Private Sub HScrollBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HScrollBar1.ValueChanged
        'Me.StatusBar1.Panels(1).Text = "hScrollBar Value:(OnValueChanged Event) " & HScrollBar1.Value.ToString()
        pointTL.X = -HScrollBar1.Value
        Me.PictureBox1.Location = pointTL
        PopulateCellInfo()
    End Sub

    Private Sub VScrollBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VScrollBar1.ValueChanged
        'Me.StatusBar1.Panels(1).Text = "vScrollBar Value:(OnValueChanged Event) " & VScrollBar1.Value.ToString()
        pointTL.Y = -VScrollBar1.Value
        Me.PictureBox1.Location = pointTL
        PopulateCellInfo()
    End Sub

    Private Sub Panel2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Resize
        UpdateScrollBars()
    End Sub
End Class
