Imports System.Windows.Forms

Public Class dlgChangeImage

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgChangeImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtTransparentColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransparentColor.DoubleClick
        Me.txtTransparentColor.BackColor = GetMau(Me.txtTransparentColor.BackColor)
    End Sub
End Class
