Imports System.Windows.Forms
Imports DBiGraphicObjs.DBiGraphicObjects
Imports System.Drawing.Drawing2D
Imports System.Drawing

Public Class dlgChangePie
    Dim myHStyle As Integer = 0

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgChangePie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtHStyle.Select()
        'SendKeys.Send(txtHStyle.Text & "{ENTER}")
    End Sub

    Private Sub txtBrushColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBrushColor.DoubleClick
        txtBrushColor.BackColor = GetMau(txtBrushColor.BackColor)
    End Sub

    Private Sub txtColor2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColor2.DoubleClick
        txtColor2.BackColor = GetMau(txtColor2.BackColor)
    End Sub

    Private Sub txtColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColor.DoubleClick
        txtColor.BackColor = GetMau(txtColor.BackColor)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        XemThu()

    End Sub

    Private Sub txtHStyle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHStyle.TextChanged
        XemThu()
    End Sub

    Private Sub XemThu()
        Dim mPen1 As Pen = New Pen(txtColor.BackColor, nudPenWidth.Value)
        Dim mPen2 As Pen = New Pen(txtColor2.BackColor, nudPenWidth2.Value)
        mPen2.Alignment = PenAlignment.Inset
        Dim DValues As String
        Dim strDValues() As String
        Dim mDashValues() As Single

        Dim mColor As New Color
        mColor = Color.FromArgb(Me.nudAlpha.Value, txtBrushColor.BackColor.R, txtBrushColor.BackColor.G, txtBrushColor.BackColor.B)
        Dim r As Rectangle = New Rectangle(3, 3, PictureBox1.Width - 9, PictureBox1.Height - 9)

        DValues = Me.txtDashValues.Text.ToString
        If DValues.Length > 2 Then

            strDValues = DValues.Split(",")
            Dim i, iMax As Integer
            'Dim mDValue As Single
            'Dim strDValue As String
            'i = -1
            'For Each strDValue In strDValues
            '    If Val(strDValue) > 0 Then
            '        i += 1
            '        ReDim dashValues(i)
            '        dashValues(i) = Val(strDValue)
            '    Else
            '        Exit For
            '    End If
            'Next
            For i = 0 To strDValues.GetUpperBound(0)
                If Val(strDValues(i)) > 0 Then
                    iMax = i
                    ReDim Preserve mDashValues(i)
                    mDashValues(i) = Val(strDValues(i))
                Else
                    Exit For
                End If
            Next i

            If iMax > 1 Then
                mPen1.DashPattern = mDashValues
                mPen2.DashPattern = mDashValues
            End If
        End If

        myHStyle = Val(txtHStyle.Text)
        PictureBox1.CreateGraphics.Clear(Color.White)
        Try
            If chkBrush.Checked Then
                Dim hBrush As New HatchBrush( _
                     myHStyle, _
                    txtHatchColor.BackColor, _
                    mColor)
                PictureBox1.CreateGraphics.FillRectangle(hBrush, r)
            End If
            PictureBox1.CreateGraphics.DrawRectangle(mPen2, r)
            PictureBox1.CreateGraphics.DrawRectangle(mPen1, r)
        Catch
            'MsgBox("Khong style nay.")
            txtHStyle.Text = "-1"
            If chkBrush.Checked Then
                Dim sBrush As New SolidBrush(mColor)
                PictureBox1.CreateGraphics.FillRectangle(sBrush, r)
            End If
            PictureBox1.CreateGraphics.DrawRectangle(mPen2, r)
            PictureBox1.CreateGraphics.DrawRectangle(mPen1, r)
        End Try

    End Sub

    Private Sub txtHatchColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHatchColor.DoubleClick
        txtHatchColor.BackColor = GetMau(txtHatchColor.BackColor)
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        'If myHStyle > 50 Then
        'myHStyle = 0
        'Else
        myHStyle += 1
        'End If
        txtHStyle.Text = myHStyle

    End Sub

    Private Sub chkArc_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkArc.CheckedChanged
        XemThu()
    End Sub
End Class
