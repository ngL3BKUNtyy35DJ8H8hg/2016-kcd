Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports DBiGraphicObjs.DBiGraphicObjects
Imports System.Drawing

Public Class dlgChangeColor
    Private m_drawingObjects As New CGraphicObjs
    Private m_Scale As Single = 1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgChangeColor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim mBound As RectangleF = myObj.GetBounds
        m_Scale = 1 '(Me.PictureBox1.Width - 20) / mBound.Width
        'myObj.Move(New PointF(mBound.X, mBound.Y), New PointF(10, 10))
        'm_drawingObjects.Add(myObj)
        AddNewObj()

        Me.nudHStyle.Maximum = 52
        ThuDoiTT()

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

    Private Sub txtHStyle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ThuDoiTT()
    End Sub

    Private Sub txtHatchColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHatchColor.DoubleClick
        txtHatchColor.BackColor = GetMau(txtHatchColor.BackColor)
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        m_drawingObjects.DrawObjects(e.Graphics, m_Scale)
    End Sub

    Private Sub AddNewObj()
        Dim gObj As GraphicObject

        Dim myEllipse As New EllipseGraphic( _
        15, 10, Me.PictureBox1.Width - 30, Me.PictureBox1.Height - 20, 0)

        myEllipse.LineWidth = 1
        myEllipse.LineColor = Color.Red
        gObj = myEllipse
        If Not gObj Is Nothing Then
            m_drawingObjects.Add(gObj)
        End If

    End Sub

    Private Sub nudLineStyle_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudLineStyle.ValueChanged
        ThuDoiTT()
    End Sub

    Private Sub ThuDoiTT()
        Dim mObj As GraphicObject

        For Each mObj In m_drawingObjects
            Dim myObj As ShapeGraphic = CType(mObj, ShapeGraphic)
            myObj.LineStyle = nudLineStyle.Value

            myObj.LineColor = txtColor.BackColor
            myObj.LineWidth = nudPenWidth.Value
            myObj.Line2Color = txtColor2.BackColor
            myObj.Line2Width = nudPenWidth2.Value
            myObj.DValues = Me.txtDashValues.Text
            myObj.LineStyle = Me.nudLineStyle.Value
            myObj.StyleWidth = Me.nudStyleWidth.Value

            If chkBrush.Checked Then
                myObj.Fill = True
                myObj.FillColor = Color.FromArgb(nudAlpha.Value, txtBrushColor.BackColor)
                myObj.HatchColor = txtHatchColor.BackColor
                myObj.HatchStyle = nudHStyle.Value
            Else
                myObj.Fill = False
            End If
        Next
        PictureBox1.Invalidate()
    End Sub

    Private Sub nudPenWidth_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudPenWidth.ValueChanged
        ThuDoiTT()
    End Sub

    Private Sub nudAlpha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudAlpha.ValueChanged
        ThuDoiTT()
    End Sub

    Private Sub nudPenWidth2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudPenWidth2.ValueChanged
        ThuDoiTT()
    End Sub

    Private Sub txtDashValues_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDashValues.TextChanged
        ThuDoiTT()
    End Sub

    Private Sub txtBrushColor_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBrushColor.BackColorChanged
        ThuDoiTT()
    End Sub

    Private Sub txtHatchColor_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHatchColor.BackColorChanged
        ThuDoiTT()
    End Sub

    Private Sub txtColor_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColor.BackColorChanged
        ThuDoiTT()
    End Sub

    Private Sub txtColor2_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColor2.BackColorChanged
        ThuDoiTT()
    End Sub

    Private Sub chkBrush_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBrush.CheckedChanged
        ThuDoiTT()
    End Sub

    Private Sub nudHStyle_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudHStyle.ValueChanged
        ThuDoiTT()
    End Sub

    Private Sub nudStyleWidth_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudStyleWidth.ValueChanged
        ThuDoiTT()
    End Sub
End Class
