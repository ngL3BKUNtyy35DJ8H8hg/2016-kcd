<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgChangePie
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
        Me.chkArc = New System.Windows.Forms.CheckBox
        Me.nudSweepAngle = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.nudStartAngle = New System.Windows.Forms.NumericUpDown
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDashValues = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtHStyle = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtHatchColor = New System.Windows.Forms.TextBox
        Me.nudAlpha = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBrushColor = New System.Windows.Forms.TextBox
        Me.chkBrush = New System.Windows.Forms.CheckBox
        Me.nudPenWidth2 = New System.Windows.Forms.NumericUpDown
        Me.txtColor2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.nudPenWidth = New System.Windows.Forms.NumericUpDown
        Me.txtColor = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nudSweepAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudStartAngle, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(-1, 360)
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
        'chkArc
        '
        Me.chkArc.Location = New System.Drawing.Point(26, 66)
        Me.chkArc.Name = "chkArc"
        Me.chkArc.Size = New System.Drawing.Size(80, 24)
        Me.chkArc.TabIndex = 78
        Me.chkArc.Text = "Arc"
        '
        'nudSweepAngle
        '
        Me.nudSweepAngle.Increment = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nudSweepAngle.Location = New System.Drawing.Point(71, 34)
        Me.nudSweepAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.nudSweepAngle.Name = "nudSweepAngle"
        Me.nudSweepAngle.Size = New System.Drawing.Size(43, 21)
        Me.nudSweepAngle.TabIndex = 77
        Me.nudSweepAngle.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(26, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Sweep"
        '
        'nudStartAngle
        '
        Me.nudStartAngle.Increment = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nudStartAngle.Location = New System.Drawing.Point(72, 10)
        Me.nudStartAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.nudStartAngle.Name = "nudStartAngle"
        Me.nudStartAngle.Size = New System.Drawing.Size(42, 21)
        Me.nudStartAngle.TabIndex = 75
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(26, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Start"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(26, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "DashValues:"
        '
        'txtDashValues
        '
        Me.txtDashValues.Location = New System.Drawing.Point(26, 170)
        Me.txtDashValues.Name = "txtDashValues"
        Me.txtDashValues.Size = New System.Drawing.Size(88, 21)
        Me.txtDashValues.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(26, 274)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "HatchStyle"
        '
        'txtHStyle
        '
        Me.txtHStyle.Location = New System.Drawing.Point(90, 274)
        Me.txtHStyle.Name = "txtHStyle"
        Me.txtHStyle.Size = New System.Drawing.Size(24, 21)
        Me.txtHStyle.TabIndex = 70
        Me.txtHStyle.Text = "-1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(26, 250)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "HatchColor:"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(26, 298)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(88, 56)
        Me.PictureBox1.TabIndex = 68
        Me.PictureBox1.TabStop = False
        '
        'txtHatchColor
        '
        Me.txtHatchColor.BackColor = System.Drawing.SystemColors.Highlight
        Me.txtHatchColor.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtHatchColor.Location = New System.Drawing.Point(90, 250)
        Me.txtHatchColor.Name = "txtHatchColor"
        Me.txtHatchColor.Size = New System.Drawing.Size(24, 21)
        Me.txtHatchColor.TabIndex = 67
        '
        'nudAlpha
        '
        Me.nudAlpha.Location = New System.Drawing.Point(66, 226)
        Me.nudAlpha.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudAlpha.Name = "nudAlpha"
        Me.nudAlpha.Size = New System.Drawing.Size(48, 21)
        Me.nudAlpha.TabIndex = 66
        Me.nudAlpha.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(26, 226)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Alpha"
        '
        'txtBrushColor
        '
        Me.txtBrushColor.BackColor = System.Drawing.Color.Red
        Me.txtBrushColor.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtBrushColor.Location = New System.Drawing.Point(90, 202)
        Me.txtBrushColor.Name = "txtBrushColor"
        Me.txtBrushColor.Size = New System.Drawing.Size(24, 21)
        Me.txtBrushColor.TabIndex = 64
        '
        'chkBrush
        '
        Me.chkBrush.Location = New System.Drawing.Point(26, 202)
        Me.chkBrush.Name = "chkBrush"
        Me.chkBrush.Size = New System.Drawing.Size(87, 24)
        Me.chkBrush.TabIndex = 63
        Me.chkBrush.Text = "Fill color"
        '
        'nudPenWidth2
        '
        Me.nudPenWidth2.Location = New System.Drawing.Point(82, 130)
        Me.nudPenWidth2.Maximum = New Decimal(New Integer() {72, 0, 0, 0})
        Me.nudPenWidth2.Name = "nudPenWidth2"
        Me.nudPenWidth2.Size = New System.Drawing.Size(32, 21)
        Me.nudPenWidth2.TabIndex = 62
        '
        'txtColor2
        '
        Me.txtColor2.BackColor = System.Drawing.SystemColors.Highlight
        Me.txtColor2.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtColor2.Location = New System.Drawing.Point(66, 130)
        Me.txtColor2.Name = "txtColor2"
        Me.txtColor2.Size = New System.Drawing.Size(16, 21)
        Me.txtColor2.TabIndex = 61
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(26, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 16)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Pen2:"
        '
        'nudPenWidth
        '
        Me.nudPenWidth.Location = New System.Drawing.Point(82, 106)
        Me.nudPenWidth.Maximum = New Decimal(New Integer() {72, 0, 0, 0})
        Me.nudPenWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPenWidth.Name = "nudPenWidth"
        Me.nudPenWidth.Size = New System.Drawing.Size(32, 21)
        Me.nudPenWidth.TabIndex = 59
        Me.nudPenWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.Color.Red
        Me.txtColor.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtColor.Location = New System.Drawing.Point(66, 106)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(16, 21)
        Me.txtColor.TabIndex = 58
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(26, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Pen"
        '
        'dlgChangePie
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(148, 392)
        Me.Controls.Add(Me.chkArc)
        Me.Controls.Add(Me.nudSweepAngle)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.nudStartAngle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDashValues)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtHStyle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtHatchColor)
        Me.Controls.Add(Me.nudAlpha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBrushColor)
        Me.Controls.Add(Me.chkBrush)
        Me.Controls.Add(Me.nudPenWidth2)
        Me.Controls.Add(Me.txtColor2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.nudPenWidth)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgChangePie"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Pie"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.nudSweepAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudStartAngle, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents chkArc As System.Windows.Forms.CheckBox
    Friend WithEvents nudSweepAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudStartAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDashValues As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHStyle As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtHatchColor As System.Windows.Forms.TextBox
    Friend WithEvents nudAlpha As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBrushColor As System.Windows.Forms.TextBox
    Friend WithEvents chkBrush As System.Windows.Forms.CheckBox
    Friend WithEvents nudPenWidth2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtColor2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents nudPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
