<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgOption
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
        Me.nudHeight = New System.Windows.Forms.NumericUpDown
        Me.nudWidth = New System.Windows.Forms.NumericUpDown
        Me.nudScale = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.nudGrid = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkSnap = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nudHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudGrid, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(11, 163)
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
        'nudHeight
        '
        Me.nudHeight.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudHeight.Location = New System.Drawing.Point(74, 46)
        Me.nudHeight.Maximum = New Decimal(New Integer() {1500, 0, 0, 0})
        Me.nudHeight.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudHeight.Name = "nudHeight"
        Me.nudHeight.Size = New System.Drawing.Size(48, 21)
        Me.nudHeight.TabIndex = 55
        Me.nudHeight.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'nudWidth
        '
        Me.nudWidth.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudWidth.Location = New System.Drawing.Point(74, 22)
        Me.nudWidth.Maximum = New Decimal(New Integer() {1500, 0, 0, 0})
        Me.nudWidth.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudWidth.Name = "nudWidth"
        Me.nudWidth.Size = New System.Drawing.Size(48, 21)
        Me.nudWidth.TabIndex = 54
        Me.nudWidth.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'nudScale
        '
        Me.nudScale.Location = New System.Drawing.Point(74, 94)
        Me.nudScale.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nudScale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudScale.Name = "nudScale"
        Me.nudScale.Size = New System.Drawing.Size(48, 21)
        Me.nudScale.TabIndex = 53
        Me.nudScale.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Scale:"
        '
        'nudGrid
        '
        Me.nudGrid.Location = New System.Drawing.Point(74, 70)
        Me.nudGrid.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nudGrid.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudGrid.Name = "nudGrid"
        Me.nudGrid.Size = New System.Drawing.Size(48, 21)
        Me.nudGrid.TabIndex = 51
        Me.nudGrid.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Grid:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Height:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Width:"
        '
        'chkSnap
        '
        Me.chkSnap.AutoSize = True
        Me.chkSnap.Checked = True
        Me.chkSnap.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSnap.Location = New System.Drawing.Point(37, 131)
        Me.chkSnap.Name = "chkSnap"
        Me.chkSnap.Size = New System.Drawing.Size(50, 17)
        Me.chkSnap.TabIndex = 56
        Me.chkSnap.Text = "Snap"
        Me.chkSnap.UseVisualStyleBackColor = True
        '
        'dlgOption
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(169, 204)
        Me.Controls.Add(Me.chkSnap)
        Me.Controls.Add(Me.nudHeight)
        Me.Controls.Add(Me.nudWidth)
        Me.Controls.Add(Me.nudScale)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nudGrid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgOption"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Option"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.nudHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents nudHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudGrid As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkSnap As System.Windows.Forms.CheckBox

End Class
