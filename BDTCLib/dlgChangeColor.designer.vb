<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgChangeColor
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.nudStyleWidth = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.nudHStyle = New System.Windows.Forms.NumericUpDown
        Me.nudLineStyle = New System.Windows.Forms.NumericUpDown
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDashValues = New System.Windows.Forms.TextBox
        Me.txtHatchColor = New System.Windows.Forms.TextBox
        Me.txtBrushColor = New System.Windows.Forms.TextBox
        Me.txtColor2 = New System.Windows.Forms.TextBox
        Me.txtColor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.nudAlpha = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkBrush = New System.Windows.Forms.CheckBox
        Me.nudPenWidth2 = New System.Windows.Forms.NumericUpDown
        Me.Label8 = New System.Windows.Forms.Label
        Me.nudPenWidth = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nudStyleWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLineStyle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPenWidth2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(10, 408)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'nudStyleWidth
        '
        Me.nudStyleWidth.Location = New System.Drawing.Point(77, 92)
        Me.nudStyleWidth.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudStyleWidth.Name = "nudStyleWidth"
        Me.nudStyleWidth.Size = New System.Drawing.Size(40, 21)
        Me.nudStyleWidth.TabIndex = 77
        Me.nudStyleWidth.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(21, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Width"
        '
        'nudHStyle
        '
        Me.nudHStyle.Location = New System.Drawing.Point(69, 244)
        Me.nudHStyle.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudHStyle.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.nudHStyle.Name = "nudHStyle"
        Me.nudHStyle.Size = New System.Drawing.Size(40, 21)
        Me.nudHStyle.TabIndex = 75
        Me.nudHStyle.Value = New Decimal(New Integer() {1, 0, 0, -2147483648})
        '
        'nudLineStyle
        '
        Me.nudLineStyle.Location = New System.Drawing.Point(77, 68)
        Me.nudLineStyle.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.nudLineStyle.Name = "nudLineStyle"
        Me.nudLineStyle.Size = New System.Drawing.Size(40, 21)
        Me.nudLineStyle.TabIndex = 74
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(21, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Style"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(21, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "DashValues:"
        '
        'txtDashValues
        '
        Me.txtDashValues.Location = New System.Drawing.Point(21, 140)
        Me.txtDashValues.Name = "txtDashValues"
        Me.txtDashValues.Size = New System.Drawing.Size(88, 21)
        Me.txtDashValues.TabIndex = 71
        '
        'txtHatchColor
        '
        Me.txtHatchColor.BackColor = System.Drawing.SystemColors.Highlight
        Me.txtHatchColor.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtHatchColor.Location = New System.Drawing.Point(85, 220)
        Me.txtHatchColor.Name = "txtHatchColor"
        Me.txtHatchColor.Size = New System.Drawing.Size(24, 21)
        Me.txtHatchColor.TabIndex = 67
        '
        'txtBrushColor
        '
        Me.txtBrushColor.BackColor = System.Drawing.Color.Red
        Me.txtBrushColor.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtBrushColor.Location = New System.Drawing.Point(85, 172)
        Me.txtBrushColor.Name = "txtBrushColor"
        Me.txtBrushColor.Size = New System.Drawing.Size(24, 21)
        Me.txtBrushColor.TabIndex = 64
        '
        'txtColor2
        '
        Me.txtColor2.BackColor = System.Drawing.SystemColors.Highlight
        Me.txtColor2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtColor2.Location = New System.Drawing.Point(61, 36)
        Me.txtColor2.Name = "txtColor2"
        Me.txtColor2.Size = New System.Drawing.Size(24, 21)
        Me.txtColor2.TabIndex = 61
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.Color.Red
        Me.txtColor.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtColor.Location = New System.Drawing.Point(61, 12)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(24, 21)
        Me.txtColor.TabIndex = 58
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 244)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "HStyle"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "HatchColor:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(13, 268)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(140, 128)
        Me.PictureBox1.TabIndex = 68
        Me.PictureBox1.TabStop = False
        '
        'nudAlpha
        '
        Me.nudAlpha.Location = New System.Drawing.Point(61, 196)
        Me.nudAlpha.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudAlpha.Name = "nudAlpha"
        Me.nudAlpha.Size = New System.Drawing.Size(48, 21)
        Me.nudAlpha.TabIndex = 66
        Me.nudAlpha.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(21, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Alpha"
        '
        'chkBrush
        '
        Me.chkBrush.Location = New System.Drawing.Point(21, 172)
        Me.chkBrush.Name = "chkBrush"
        Me.chkBrush.Size = New System.Drawing.Size(87, 24)
        Me.chkBrush.TabIndex = 63
        Me.chkBrush.Text = "Fill color"
        '
        'nudPenWidth2
        '
        Me.nudPenWidth2.Location = New System.Drawing.Point(85, 36)
        Me.nudPenWidth2.Maximum = New Decimal(New Integer() {72, 0, 0, 0})
        Me.nudPenWidth2.Name = "nudPenWidth2"
        Me.nudPenWidth2.Size = New System.Drawing.Size(32, 21)
        Me.nudPenWidth2.TabIndex = 62
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(21, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 16)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Pen2:"
        '
        'nudPenWidth
        '
        Me.nudPenWidth.Location = New System.Drawing.Point(85, 12)
        Me.nudPenWidth.Maximum = New Decimal(New Integer() {72, 0, 0, 0})
        Me.nudPenWidth.Name = "nudPenWidth"
        Me.nudPenWidth.Size = New System.Drawing.Size(32, 21)
        Me.nudPenWidth.TabIndex = 59
        Me.nudPenWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Pen"
        '
        'dlgChangeColor
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(168, 449)
        Me.Controls.Add(Me.nudStyleWidth)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.nudHStyle)
        Me.Controls.Add(Me.nudLineStyle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDashValues)
        Me.Controls.Add(Me.txtHatchColor)
        Me.Controls.Add(Me.txtBrushColor)
        Me.Controls.Add(Me.txtColor2)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.nudAlpha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkBrush)
        Me.Controls.Add(Me.nudPenWidth2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.nudPenWidth)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgChangeColor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Color"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.nudStyleWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHStyle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLineStyle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPenWidth2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents nudStyleWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudHStyle As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudLineStyle As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDashValues As System.Windows.Forms.TextBox
    Friend WithEvents txtHatchColor As System.Windows.Forms.TextBox
    Friend WithEvents txtBrushColor As System.Windows.Forms.TextBox
    Friend WithEvents txtColor2 As System.Windows.Forms.TextBox
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents nudAlpha As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkBrush As System.Windows.Forms.CheckBox
    Friend WithEvents nudPenWidth2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
