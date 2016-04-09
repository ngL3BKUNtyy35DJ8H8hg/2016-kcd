<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgBanDoNho
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgBanDoNho))
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MnuArrow = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MnuPan = New System.Windows.Forms.MenuItem
        Me.MnuZoomIn = New System.Windows.Forms.MenuItem
        Me.MnuZoomOut = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MnuLayers = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MnuSaveGeoSet = New System.Windows.Forms.MenuItem
        Me.AxMap1 = New AxMapXLib.AxMap
        CType(Me.AxMap1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuArrow, Me.MenuItem1, Me.MnuPan, Me.MnuZoomIn, Me.MnuZoomOut, Me.MenuItem4, Me.MnuLayers, Me.MenuItem7, Me.MnuSaveGeoSet})
        '
        'MnuArrow
        '
        Me.MnuArrow.Index = 0
        Me.MnuArrow.Text = "Mũi tên"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "-"
        '
        'MnuPan
        '
        Me.MnuPan.Index = 2
        Me.MnuPan.Text = "Trượt"
        '
        'MnuZoomIn
        '
        Me.MnuZoomIn.Index = 3
        Me.MnuZoomIn.Text = "Phóng to"
        '
        'MnuZoomOut
        '
        Me.MnuZoomOut.Index = 4
        Me.MnuZoomOut.Text = "Thu nhỏ"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 5
        Me.MenuItem4.Text = "-"
        '
        'MnuLayers
        '
        Me.MnuLayers.Index = 6
        Me.MnuLayers.Text = "Các lớp Bản đồ"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 7
        Me.MenuItem7.Text = "-"
        '
        'MnuSaveGeoSet
        '
        Me.MnuSaveGeoSet.Index = 8
        Me.MnuSaveGeoSet.Text = "Lưu cấu hình Bản đồ"
        '
        'AxMap1
        '
        Me.AxMap1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxMap1.Enabled = True
        Me.AxMap1.Location = New System.Drawing.Point(0, 0)
        Me.AxMap1.Name = "AxMap1"
        Me.AxMap1.OcxState = CType(resources.GetObject("AxMap1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxMap1.Size = New System.Drawing.Size(231, 240)
        Me.AxMap1.TabIndex = 1
        '
        'dlgBanDoNho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(231, 240)
        Me.Controls.Add(Me.AxMap1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgBanDoNho"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BanDoNho"
        Me.TopMost = True
        CType(Me.AxMap1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MnuArrow As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuPan As System.Windows.Forms.MenuItem
    Friend WithEvents MnuZoomIn As System.Windows.Forms.MenuItem
    Friend WithEvents MnuZoomOut As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuLayers As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuSaveGeoSet As System.Windows.Forms.MenuItem
    Friend WithEvents AxMap1 As AxMapXLib.AxMap

End Class
