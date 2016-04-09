Imports System.Windows.Forms

Public Class dlgEditMenu

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Computer.FileSystem.WriteAllText(mySaBanDir & "\MyMenu.xml", Me.txtMenu.Text, False)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgEditMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(mySaBanDir & "\MyMenu.xml") Then
            Dim fileReader As String = My.Computer.FileSystem.ReadAllText(mySaBanDir & "\MyMenu.xml")
            Me.txtMenu.Text = fileReader
        Else
            MsgBox("Không thấy file: " & mySaBanDir & "\MyMenu.xml")
        End If
    End Sub
End Class
