Imports System.Windows.Forms

Public Class dlgZoomTo
    Dim myBanDo As CBanDo

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        myBanDo.myMap.ZoomTo(CDbl(Me.txtZoomLevel.Text), CDbl(Me.txtLon.Text), CDbl(Me.txtLat.Text))
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgZoomTo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myBanDo = fMain.myBando

        Me.txtZoomLevel.Text = myBanDo.myMap.Zoom
        Me.txtLon.Text = myBanDo.myMap.CenterX
        Me.txtLat.Text = myBanDo.myMap.CenterY

    End Sub
End Class
