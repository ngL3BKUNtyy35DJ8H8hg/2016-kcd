Imports System.Windows.Forms
Imports System.Drawing

Public Class dlgGetColor
    Public SeleColor As Color
    Private myRect As New Rectangle

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgGetColor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 0 To 31
            Me.Controls("txtColor" & (i + 1).ToString("00")).BackColor = myColor(i)
            If Me.Controls("txtColor" & (i + 1).ToString("00")).BackColor = SeleColor Then
                Me.Controls("txtColor" & (i + 1).ToString("00")).Select()
            End If
        Next
    End Sub

    Private Sub txtColor01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        txtColor01.DoubleClick, txtColor02.DoubleClick, txtColor03.DoubleClick, txtColor04.DoubleClick _
        , txtColor05.DoubleClick, txtColor06.DoubleClick, txtColor07.DoubleClick, txtColor08.DoubleClick _
        , txtColor09.DoubleClick, txtColor10.DoubleClick, txtColor11.DoubleClick, txtColor12.DoubleClick _
        , txtColor13.DoubleClick, txtColor14.DoubleClick, txtColor15.DoubleClick, txtColor16.DoubleClick _
        , txtColor17.DoubleClick, txtColor18.DoubleClick, txtColor19.DoubleClick, txtColor20.DoubleClick _
        , txtColor21.DoubleClick, txtColor22.DoubleClick, txtColor23.DoubleClick, txtColor24.DoubleClick _
        , txtColor25.DoubleClick, txtColor26.DoubleClick, txtColor27.DoubleClick, txtColor28.DoubleClick _
        , txtColor29.DoubleClick, txtColor30.DoubleClick, txtColor31.DoubleClick, txtColor32.DoubleClick
        Dim txtbox As TextBox = sender
        SeleColor = txtbox.BackColor
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtColor01_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    txtColor01.GotFocus, txtColor02.GotFocus, txtColor03.GotFocus, txtColor04.GotFocus _
    , txtColor05.GotFocus, txtColor06.GotFocus, txtColor07.GotFocus, txtColor08.GotFocus _
    , txtColor09.GotFocus, txtColor10.GotFocus, txtColor11.GotFocus, txtColor12.GotFocus _
    , txtColor13.GotFocus, txtColor14.GotFocus, txtColor15.GotFocus, txtColor16.GotFocus _
    , txtColor17.GotFocus, txtColor18.GotFocus, txtColor19.GotFocus, txtColor20.GotFocus _
    , txtColor21.GotFocus, txtColor22.GotFocus, txtColor23.GotFocus, txtColor24.GotFocus _
    , txtColor25.GotFocus, txtColor26.GotFocus, txtColor27.GotFocus, txtColor28.GotFocus _
    , txtColor29.GotFocus, txtColor30.GotFocus, txtColor31.GotFocus, txtColor32.GotFocus
        Dim txtbox As TextBox = sender
        myRect.X = txtbox.Left
        myRect.Y = txtbox.Top
        myRect.Width = txtbox.Width
        myRect.Height = txtbox.Height
        Me.Invalidate()
    End Sub

    Private Sub drawRectangle(ByVal g As Graphics)
        Dim mPen As New Pen(Color.Black, 2)
        g.DrawRectangle(mPen, myRect)
        mPen.Dispose()
    End Sub

    Private Sub dlgGetColor_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        drawRectangle(e.Graphics)
    End Sub
End Class
