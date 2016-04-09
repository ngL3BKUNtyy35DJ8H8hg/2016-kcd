Imports System.Windows.Forms

Public Class dlgCopyKH

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.txtLoaiKH_ID.Text > 0 Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Chưa chọn Nhóm ký hiệu ...")
            Exit Sub
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgCopyKH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Copy ký hiệu"
        With Me.DBiTraDM1
            .KhoiDong(0)
        End With
    End Sub

    Private Sub DBiTraDM1_DaChon(ByVal IdValue As Long, ByVal TxtValue As String, ByVal MaValue As String) Handles DBiTraDM1.DaChon
        Me.txtLoaiKH_ID.Text = IdValue
        Me.Label1.Text = "Copy vào nhóm '" & TxtValue & "'?"
    End Sub
End Class
