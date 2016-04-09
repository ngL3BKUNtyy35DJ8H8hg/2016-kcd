<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgChangeSymbol
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.picLineColor = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lstLineColor = New System.Windows.Forms.ListBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.nudLineWidth = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.lstLineWidth = New System.Windows.Forms.ListBox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.nudAlpha = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.picFillColor = New System.Windows.Forms.PictureBox
        Me.lstFillColor = New System.Windows.Forms.ListBox
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.lstLineStyle = New System.Windows.Forms.ListBox
        Me.cboStyle = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.picLineColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.nudLineWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.nudAlpha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFillColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(155, 250)
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(8, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(297, 229)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.picLineColor)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lstLineColor)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(289, 203)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Mầu nét vẽ"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'picLineColor
        '
        Me.picLineColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.picLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picLineColor.Location = New System.Drawing.Point(191, 63)
        Me.picLineColor.Name = "picLineColor"
        Me.picLineColor.Size = New System.Drawing.Size(30, 25)
        Me.picLineColor.TabIndex = 2
        Me.picLineColor.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(153, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "="
        '
        'lstLineColor
        '
        Me.lstLineColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstLineColor.FormattingEnabled = True
        Me.lstLineColor.ItemHeight = 20
        Me.lstLineColor.Location = New System.Drawing.Point(8, 8)
        Me.lstLineColor.Name = "lstLineColor"
        Me.lstLineColor.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstLineColor.Size = New System.Drawing.Size(128, 184)
        Me.lstLineColor.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.nudLineWidth)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.lstLineWidth)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(289, 203)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Độ dầy nét"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'nudLineWidth
        '
        Me.nudLineWidth.Location = New System.Drawing.Point(198, 62)
        Me.nudLineWidth.Maximum = New Decimal(New Integer() {36, 0, 0, 0})
        Me.nudLineWidth.Name = "nudLineWidth"
        Me.nudLineWidth.Size = New System.Drawing.Size(41, 21)
        Me.nudLineWidth.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(166, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "="
        '
        'lstLineWidth
        '
        Me.lstLineWidth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstLineWidth.FormattingEnabled = True
        Me.lstLineWidth.ItemHeight = 20
        Me.lstLineWidth.Location = New System.Drawing.Point(8, 8)
        Me.lstLineWidth.Name = "lstLineWidth"
        Me.lstLineWidth.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstLineWidth.Size = New System.Drawing.Size(128, 184)
        Me.lstLineWidth.TabIndex = 3
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.nudAlpha)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.picFillColor)
        Me.TabPage3.Controls.Add(Me.lstFillColor)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(289, 203)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Mầu tô"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'nudAlpha
        '
        Me.nudAlpha.Location = New System.Drawing.Point(204, 100)
        Me.nudAlpha.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudAlpha.Name = "nudAlpha"
        Me.nudAlpha.Size = New System.Drawing.Size(45, 21)
        Me.nudAlpha.TabIndex = 7
        Me.nudAlpha.Value = New Decimal(New Integer() {255, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(157, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Độ mờ:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(166, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "="
        '
        'picFillColor
        '
        Me.picFillColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.picFillColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFillColor.Location = New System.Drawing.Point(204, 63)
        Me.picFillColor.Name = "picFillColor"
        Me.picFillColor.Size = New System.Drawing.Size(30, 25)
        Me.picFillColor.TabIndex = 5
        Me.picFillColor.TabStop = False
        '
        'lstFillColor
        '
        Me.lstFillColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstFillColor.FormattingEnabled = True
        Me.lstFillColor.ItemHeight = 20
        Me.lstFillColor.Location = New System.Drawing.Point(8, 8)
        Me.lstFillColor.Name = "lstFillColor"
        Me.lstFillColor.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstFillColor.Size = New System.Drawing.Size(128, 184)
        Me.lstFillColor.TabIndex = 3
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lstLineStyle)
        Me.TabPage4.Controls.Add(Me.cboStyle)
        Me.TabPage4.Controls.Add(Me.Label4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(289, 203)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Kiểu nét"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lstLineStyle
        '
        Me.lstLineStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstLineStyle.FormattingEnabled = True
        Me.lstLineStyle.ItemHeight = 30
        Me.lstLineStyle.Location = New System.Drawing.Point(8, 8)
        Me.lstLineStyle.Name = "lstLineStyle"
        Me.lstLineStyle.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstLineStyle.Size = New System.Drawing.Size(120, 184)
        Me.lstLineStyle.TabIndex = 3
        '
        'cboStyle
        '
        Me.cboStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboStyle.DropDownHeight = 136
        Me.cboStyle.FormattingEnabled = True
        Me.cboStyle.IntegralHeight = False
        Me.cboStyle.ItemHeight = 30
        Me.cboStyle.Location = New System.Drawing.Point(145, 65)
        Me.cboStyle.Name = "cboStyle"
        Me.cboStyle.Size = New System.Drawing.Size(136, 36)
        Me.cboStyle.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(133, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "="
        '
        'dlgChangeSymbol
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(313, 291)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgChangeSymbol"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Đổi các thuộc tính"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.picLineColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.nudLineWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.nudAlpha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFillColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents picLineColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstLineColor As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstLineWidth As System.Windows.Forms.ListBox
    Friend WithEvents picFillColor As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstFillColor As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lstLineStyle As System.Windows.Forms.ListBox
    Friend WithEvents nudLineWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudAlpha As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboStyle As System.Windows.Forms.ComboBox

End Class
