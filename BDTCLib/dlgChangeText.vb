Imports System.Windows.Forms
Imports DBiGraphicObjs.DBiGraphicObjects
Imports System.Drawing

Public Class dlgChangeText

    Private m_TextObj As TextGraphic
    Private m_Pos As Point

    Property TextObj() As TextGraphic
        Get
            Return m_TextObj
        End Get
        Set(ByVal Value As TextGraphic)
            m_TextObj = Value
        End Set
    End Property

    Property Pos() As Point
        Get
            Return m_Pos
        End Get
        Set(ByVal Value As Point)
            m_Pos = Value
        End Set
    End Property

    Private Sub dlgChangeText_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        m_TextObj.Text = Me.txtLabel.Text
        m_TextObj.Font = Me.txtLabel.Font
        m_TextObj.Color = Me.txtLabel.ForeColor
    End Sub


    Private Sub dlgChangeText_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = m_Pos

        'If fCallForm Is fMainForm Then
        'myBanDo = fMainForm.myBando
        'End If

        'If fCallForm Is fCacKyHieu Then
        'myObj = CType(fCacKyHieu.SelectedObject, TextGraphic)
        'Else
        '    myObj = CType(myBanDo.SelectedObject, TextGraphic)
        'End If

        Me.txtLabel.Text = m_TextObj.Text
        Me.txtLabel.Font = m_TextObj.Font
        Me.txtLabel.ForeColor = m_TextObj.Color

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
