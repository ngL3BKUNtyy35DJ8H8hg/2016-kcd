Imports System.Windows.Forms
Imports System.Drawing

Public Class dlgOptions
    Dim myBanDo As CBanDo
    Dim myRect As New Rectangle

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If fCallForm Is fMain Then
            myBanDo = fMain.myBando
        End If
        Me.nudGrid.Value = myBanDo.myGridWidth
        'General
        Me.txtColor.BackColor = defaGenPen1C
        Me.txtColor2.BackColor = defaGenPen2C
        Me.nudPenWidth.Value = defaGenPen1W
        Me.nudPenWidth2.Value = defaGenPen2W
        Me.nudLineStyle.Value = defaGenLineStyle

        Me.chkBrush.Checked = defaGenFill
        'If Me.chkBrush.Checked Then
        txtBrushColor.BackColor = Color.FromArgb(255, defaGenFillC.R, defaGenFillC.G, defaGenFillC.B)
        Me.nudAlpha.Value = defaGenFillC.A
        'End If

        'Songsong
        Me.nudSSSize.Value = defaSongSongSize
        Me.nudSSLinesNo.Value = defaSongSongLinesNo
        Me.txtSS1Color.BackColor = defaSongSongPen1C
        Me.txtSS2Color.BackColor = defaSongSongPen2C
        Me.nudSSPen1W.Value = defaSongSongPen1W
        Me.nudSSPen2W.Value = defaSongSongPen2W

        'MuiTen
        Me.txtMT1Color.BackColor = defaMuiTenPen1C
        Me.txtMT2Color.BackColor = defaMuiTenPen2C
        Me.nudMTPen1W.Value = defaMuiTenPen1W
        Me.nudMTPen2W.Value = defaMuiTenPen2W
        Me.txtMTDoRong.Text = defaMuiTenDoRong

        Me.chkMTFill.Checked = defaMuiTenFill
        'If Me.chkMTFill.Checked Then
        Me.txtMTFillColor.BackColor = Color.FromArgb(255, defaMuiTenFillC.R, defaMuiTenFillC.G, defaMuiTenFillC.B)
        Me.nudMTAlpha.Value = defaMuiTenFillC.A
        'End If

        'MuiTenDac
        Me.txtMTD1Color.BackColor = defaMuiTenDacPen1C
        Me.txtMTD2Color.BackColor = defaMuiTenDacPen2C
        Me.nudMTDPen1W.Value = defaMuiTenDacPen1W
        Me.nudMTDPen2W.Value = defaMuiTenDacPen2W
        Me.txtMTDDoRong.Text = defaMuiTenDacDoRong
        Me.txtMTDDoDai.Text = defaMuiTenDacDoDai

        Me.chkMTDFill.Checked = defaMuiTenDacFill
        'If Me.chkMTFill.Checked Then
        Me.txtMTDFillColor.BackColor = Color.FromArgb(255, defaMuiTenDacFillC.R, defaMuiTenDacFillC.G, defaMuiTenDacFillC.B)
        Me.nudMTDAlpha.Value = defaMuiTenDacFillC.A
        'End If

        'Table
        Me.nudTblRowsNo.Value = defaTableRowsNo
        Me.nudTblColsNo.Value = defaTableColsNo
        Me.txtTblBorderColor.BackColor = defaTableBorderC
        Me.txtTblLineColor.BackColor = defaTableLineC
        Me.nudTblBorderW.Value = defaTableBorderW
        Me.nudTblLineW.Value = defaTableLineW
        Me.txtTblFillColor.BackColor = Color.FromArgb(255, defaTableFillC.R, defaTableFillC.G, defaTableFillC.B)
        Me.nudTblAlpha.Value = defaTableFillC.A
        Me.txtTableFont.Font = defaTableTFont 'New Font(defaTableTFontName, defaTableTFontSize, defaTableTFontStyle, GraphicsUnit.Point) 'defaTableTFont
        Me.txtTableFont.ForeColor = defaTableTextC
        'Text
        Me.txtTextFont.Font = defaTextFont 'New Font(defaTextFontName, defaTextFontSize, defaTextFontStyle, GraphicsUnit.Point) '
        Me.txtTextFont.ForeColor = defaTextC
        'Undo
        Me.nudUndosNo.Value = defaUndosNo

        'Bang Mau
        Me.txtQuanDoColor.BackColor = QuanDoColor
        Me.txtQuanXanhColor.BackColor = QuanXanhColor
        For i As Integer = 0 To 31
            Me.GroupBox1.Controls("txtColor" & (i + 1).ToString("00")).BackColor = myColor(i)
        Next
        'MsgBox("Me.Controls.Count=" & Me.Controls.Count)
        'MsgBox("Me.TabControl1.Controls.Count=" & Me.GroupBox1.Controls.Count)
    End Sub

    Private Sub txtColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColor.DoubleClick
        txtColor.BackColor = GetMau(txtColor.BackColor)
    End Sub

    Private Sub txtBrushColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBrushColor.DoubleClick
        txtBrushColor.BackColor = GetMau(txtBrushColor.BackColor)
    End Sub

    Private Sub txtColor2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColor2.DoubleClick
        txtColor2.BackColor = GetMau(txtColor2.BackColor)
    End Sub

    Private Sub txtMT1Color_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMT1Color.DoubleClick
        txtMT1Color.BackColor = GetMau(txtMT1Color.BackColor)
    End Sub

    Private Sub txtMT2Color_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMT2Color.DoubleClick
        txtMT2Color.BackColor = GetMau(txtMT2Color.BackColor)
    End Sub

    Private Sub txtMTFillColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMTFillColor.DoubleClick
        txtMTFillColor.BackColor = GetMau(txtMTFillColor.BackColor)
    End Sub

    Private Sub txtMTD1Color_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMTD1Color.DoubleClick
        txtMTD1Color.BackColor = GetMau(txtMTD1Color.BackColor)
    End Sub

    Private Sub txtMTD2Color_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMTD2Color.DoubleClick
        txtMTD2Color.BackColor = GetMau(txtMTD2Color.BackColor)
    End Sub

    Private Sub txtMTDFillColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMTDFillColor.DoubleClick
        txtMTDFillColor.BackColor = GetMau(txtMTDFillColor.BackColor)
    End Sub

    Private Sub txtSS1Color_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSS1Color.DoubleClick
        txtSS1Color.BackColor = GetMau(txtSS1Color.BackColor)
    End Sub

    Private Sub txtSS2Color_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSS2Color.DoubleClick
        txtSS2Color.BackColor = GetMau(txtSS2Color.BackColor)
    End Sub

    Private Sub txtTblBorderColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTblBorderColor.DoubleClick
        txtTblBorderColor.BackColor = GetMau(txtTblBorderColor.BackColor)
    End Sub

    Private Sub txtTblFillColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTblFillColor.DoubleClick
        txtTblFillColor.BackColor = GetMau(txtTblFillColor.BackColor)
    End Sub

    Private Sub txtTblLineColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTblLineColor.DoubleClick
        txtTblLineColor.BackColor = GetMau(txtTblLineColor.BackColor)
    End Sub

    Private Sub txtTextFont_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTextFont.DoubleClick
        Dim fontDialog1 As FontDialog = New FontDialog
        fontDialog1.Font = Me.txtTextFont.Font
        fontDialog1.Color = Me.txtTextFont.ForeColor
        fontDialog1.ShowColor = True
        If fontDialog1.ShowDialog() <> DialogResult.Cancel Then
            Me.txtTextFont.Font = fontDialog1.Font
            Me.txtTextFont.ForeColor = fontDialog1.Color
        End If
    End Sub

    Private Sub txtTableFont_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTableFont.DoubleClick
        Dim fontDialog1 As FontDialog = New FontDialog
        fontDialog1.Font = Me.txtTableFont.Font
        fontDialog1.Color = Me.txtTableFont.ForeColor
        fontDialog1.ShowColor = True
        If fontDialog1.ShowDialog() <> DialogResult.Cancel Then
            Me.txtTableFont.Font = fontDialog1.Font
            Me.txtTableFont.ForeColor = fontDialog1.Color
        End If
    End Sub

    Private Sub frmOptions_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ChangeDefa()
    End Sub

    Private Sub ChangeDefa()
        'Grid
        myBanDo.myGridWidth = Me.nudGrid.Value
        'General
        defaGenPen1C = txtColor.BackColor
        defaGenPen1W = nudPenWidth.Value
        defaGenPen2C = txtColor2.BackColor
        defaGenPen2W = nudPenWidth2.Value
        defaGenLineStyle = Me.nudLineStyle.Value

        If chkBrush.Checked Then
            defaGenFill = True
        Else
            defaGenFill = False
        End If
        defaGenFillC = Color.FromArgb(nudAlpha.Value, txtBrushColor.BackColor)

        'MuiTen
        defaMuiTenPen1C = Me.txtMT1Color.BackColor
        defaMuiTenPen1W = Me.nudMTPen1W.Value
        defaMuiTenPen2C = Me.txtMT2Color.BackColor
        defaMuiTenPen2W = Me.nudMTPen2W.Value
        defaMuiTenDoRong = Val(Me.txtMTDoRong.Text)

        If Me.chkMTFill.Checked Then
            defaMuiTenFill = True
        Else
            defaMuiTenFill = False
        End If
        defaMuiTenFillC = Color.FromArgb(Me.nudMTAlpha.Value, Me.txtMTFillColor.BackColor)

        'MuiTenDac
        defaMuiTenDacPen1C = Me.txtMTD1Color.BackColor
        defaMuiTenDacPen1W = Me.nudMTDPen1W.Value
        defaMuiTenDacPen2C = Me.txtMTD2Color.BackColor
        defaMuiTenDacPen2W = Me.nudMTDPen2W.Value
        defaMuiTenDacDoRong = Val(Me.txtMTDDoRong.Text)
        defaMuiTenDacDoDai = Val(Me.txtMTDDoDai.Text)

        If Me.chkMTDFill.Checked Then
            defaMuiTenDacFill = True
        Else
            defaMuiTenDacFill = False
        End If
        defaMuiTenDacFillC = Color.FromArgb(Me.nudMTDAlpha.Value, Me.txtMTDFillColor.BackColor)

        'SongSong
        defaSongSongSize = Me.nudSSSize.Value
        defaSongSongLinesNo = Me.nudSSLinesNo.Value
        defaSongSongPen1C = Me.txtSS1Color.BackColor
        defaSongSongPen2C = Me.txtSS2Color.BackColor
        defaSongSongPen1W = Me.nudSSPen1W.Value
        defaSongSongPen2W = Me.nudSSPen2W.Value
        'Table
        defaTableRowsNo = Me.nudTblRowsNo.Value
        defaTableColsNo = Me.nudTblColsNo.Value
        defaTableBorderC = Me.txtTblBorderColor.BackColor
        defaTableLineC = Me.txtTblLineColor.BackColor
        defaTableBorderW = Me.nudTblBorderW.Value
        defaTableLineW = Me.nudTblLineW.Value
        defaTableFillC = Color.FromArgb(Me.nudTblAlpha.Value, Me.txtTblFillColor.BackColor)

        defaTableTFontName = Me.txtTableFont.Font.Name
        defaTableTFontSize = Me.txtTableFont.Font.Size
        defaTableTFontStyle = Me.txtTableFont.Font.Style
        defaTableTFont = Me.txtTableFont.Font
        defaTableTextC = Me.txtTableFont.ForeColor
        'Text
        defaTextFontName = Me.txtTextFont.Font.Name
        defaTextFontSize = Me.txtTextFont.Font.Size
        defaTextFontStyle = Me.txtTextFont.Font.Style
        defaTextFont = Me.txtTextFont.Font
        defaTextC = Me.txtTextFont.ForeColor

        'Undo
        If Me.nudUndosNo.Value <> defaUndosNo Then
            defaUndosNo = Me.nudUndosNo.Value
            fMain.myBando.XoaUndoStack()
        End If

        QuanDoColor = Me.txtQuanDoColor.BackColor
        QuanXanhColor = Me.txtQuanXanhColor.BackColor
        For i As Integer = 0 To 31
            myColor(i) = Me.GroupBox1.Controls("txtColor" & (i + 1).ToString("00")).BackColor
        Next

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'ChangeDefa()
        'Defa2File(myDefaFileName)
        'Me.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

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
        txtbox.BackColor = GetMauGoc(txtbox.BackColor)
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
        Me.GroupBox1.Invalidate()
    End Sub

    Private Sub drawRectangle(ByVal g As Graphics)
        Dim mPen As New Pen(Color.Black, 2)
        g.DrawRectangle(mPen, myRect)
        mPen.Dispose()
    End Sub

    Private Sub GroupBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox1.Paint
        drawRectangle(e.Graphics)
    End Sub

    Private Sub txtQuanDoColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuanDoColor.DoubleClick
        txtQuanDoColor.BackColor = GetMau(txtQuanDoColor.BackColor)
    End Sub

    Private Sub txtQuanXanhColor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuanXanhColor.DoubleClick
        txtQuanXanhColor.BackColor = GetMau(txtQuanXanhColor.BackColor)
    End Sub
End Class
