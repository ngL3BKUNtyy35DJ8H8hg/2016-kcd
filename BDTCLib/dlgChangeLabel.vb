Imports System.Windows.Forms

Public Class dlgChangeLabel

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgChangeLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtLabel_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLabel.DoubleClick
        Dim fontDialog1 As FontDialog = New FontDialog
        fontDialog1.Font = txtLabel.Font
        fontDialog1.Color = txtLabel.ForeColor
        fontDialog1.ShowColor = True
        If fontDialog1.ShowDialog() <> DialogResult.Cancel Then
            txtLabel.Font = fontDialog1.Font
            txtLabel.ForeColor = fontDialog1.Color
        End If
    End Sub

End Class
