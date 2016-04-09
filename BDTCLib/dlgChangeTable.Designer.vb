<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgChangeTable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnChange = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtBrushColor = New System.Windows.Forms.TextBox
        Me.txtColor2 = New System.Windows.Forms.TextBox
        Me.txtColor = New System.Windows.Forms.TextBox
        Me.nudAlpha = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.nudPenWidth2 = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.nudPenWidth = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.mnuInsertCol = New System.Windows.Forms.MenuItem
        Me.mnuInsertRow = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuDeleteCol = New System.Windows.Forms.MenuItem
        Me.mnuDeleteRow = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuLinkRight = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuLinkDown = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.mnuTextFont = New System.Windows.Forms.MenuItem
        Me.Panel1.SuspendLayout()
        CType(Me.nudAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPenWidth2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnChange)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtBrushColor)
        Me.Panel1.Controls.Add(Me.txtColor2)
        Me.Panel1.Controls.Add(Me.txtColor)
        Me.Panel1.Controls.Add(Me.nudAlpha)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.nudPenWidth2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.nudPenWidth)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(152, 278)
        Me.Panel1.TabIndex = 1
        '
        'btnChange
        '
        Me.btnChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChange.Location = New System.Drawing.Point(68, 244)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(72, 24)
        Me.btnChange.TabIndex = 72
        Me.btnChange.Text = "Thay đổi"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Mầu tô:"
        '
        'txtBrushColor
        '
        Me.txtBrushColor.BackColor = System.Drawing.Color.Red
        Me.txtBrushColor.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtBrushColor.Location = New System.Drawing.Point(88, 72)
        Me.txtBrushColor.Name = "txtBrushColor"
        Me.txtBrushColor.Size = New System.Drawing.Size(24, 21)
        Me.txtBrushColor.TabIndex = 66
        '
        'txtColor2
        '
        Me.txtColor2.BackColor = System.Drawing.SystemColors.Highlight
        Me.txtColor2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtColor2.Location = New System.Drawing.Point(88, 40)
        Me.txtColor2.Name = "txtColor2"
        Me.txtColor2.Size = New System.Drawing.Size(24, 21)
        Me.txtColor2.TabIndex = 64
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.Color.Red
        Me.txtColor.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtColor.Location = New System.Drawing.Point(88, 16)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(24, 21)
        Me.txtColor.TabIndex = 61
        '
        'nudAlpha
        '
        Me.nudAlpha.Location = New System.Drawing.Point(88, 96)
        Me.nudAlpha.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudAlpha.Name = "nudAlpha"
        Me.nudAlpha.Size = New System.Drawing.Size(48, 21)
        Me.nudAlpha.TabIndex = 69
        Me.nudAlpha.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Độ mờ:"
        '
        'nudPenWidth2
        '
        Me.nudPenWidth2.Location = New System.Drawing.Point(112, 40)
        Me.nudPenWidth2.Maximum = New Decimal(New Integer() {72, 0, 0, 0})
        Me.nudPenWidth2.Name = "nudPenWidth2"
        Me.nudPenWidth2.Size = New System.Drawing.Size(32, 21)
        Me.nudPenWidth2.TabIndex = 65
        Me.nudPenWidth2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Đường kẻ:"
        '
        'nudPenWidth
        '
        Me.nudPenWidth.Location = New System.Drawing.Point(112, 16)
        Me.nudPenWidth.Maximum = New Decimal(New Integer() {72, 0, 0, 0})
        Me.nudPenWidth.Name = "nudPenWidth"
        Me.nudPenWidth.Size = New System.Drawing.Size(32, 21)
        Me.nudPenWidth.TabIndex = 62
        Me.nudPenWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Viền ngoài:"
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(152, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 278)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.VScrollBar1)
        Me.Panel2.Controls.Add(Me.HScrollBar1)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(155, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(413, 278)
        Me.Panel2.TabIndex = 3
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar1.Location = New System.Drawing.Point(394, 0)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(16, 271)
        Me.VScrollBar1.TabIndex = 84
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.HScrollBar1.Location = New System.Drawing.Point(0, 259)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(344, 16)
        Me.HScrollBar1.TabIndex = 83
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(130, 111)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(152, 56)
        Me.TextBox1.TabIndex = 86
        Me.TextBox1.Text = "TextBox1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.PictureBox1.Location = New System.Drawing.Point(40, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(336, 240)
        Me.PictureBox1.TabIndex = 71
        Me.PictureBox1.TabStop = False
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuInsertCol, Me.mnuInsertRow, Me.MenuItem5, Me.mnuDeleteCol, Me.mnuDeleteRow, Me.MenuItem1, Me.mnuLinkRight, Me.MenuItem2, Me.mnuLinkDown, Me.MenuItem3, Me.mnuTextFont})
        '
        'mnuInsertCol
        '
        Me.mnuInsertCol.Index = 0
        Me.mnuInsertCol.Text = "Thêm cột"
        '
        'mnuInsertRow
        '
        Me.mnuInsertRow.Index = 1
        Me.mnuInsertRow.Text = "Thêm dòng"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 2
        Me.MenuItem5.Text = "-"
        '
        'mnuDeleteCol
        '
        Me.mnuDeleteCol.Index = 3
        Me.mnuDeleteCol.Text = "Xóa cột"
        '
        'mnuDeleteRow
        '
        Me.mnuDeleteRow.Index = 4
        Me.mnuDeleteRow.Text = "Xóa dòng"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 5
        Me.MenuItem1.Text = "-"
        '
        'mnuLinkRight
        '
        Me.mnuLinkRight.Index = 6
        Me.mnuLinkRight.Text = "Nối với ô phải"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 7
        Me.MenuItem2.Text = "-"
        '
        'mnuLinkDown
        '
        Me.mnuLinkDown.Index = 8
        Me.mnuLinkDown.Text = "Nối với ô dưới"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 9
        Me.MenuItem3.Text = "-"
        '
        'mnuTextFont
        '
        Me.mnuTextFont.Index = 10
        Me.mnuTextFont.Text = "Font, mầu chữ"
        '
        'dlgChangeTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 278)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgChangeTable"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cập nhật Bảng"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPenWidth2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnChange As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBrushColor As System.Windows.Forms.TextBox
    Friend WithEvents txtColor2 As System.Windows.Forms.TextBox
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents nudAlpha As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudPenWidth2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuInsertCol As System.Windows.Forms.MenuItem
    Friend WithEvents mnuInsertRow As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeleteCol As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeleteRow As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLinkRight As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLinkDown As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTextFont As System.Windows.Forms.MenuItem

End Class
