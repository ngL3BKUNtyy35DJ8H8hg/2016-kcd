Imports System.Windows.Forms

Public Class dlgGetName
    Private names As List(Of String) '= New List(Of String)

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgGetName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        names = GetNames()
        Me.lstNames.DataSource = names
    End Sub

    Private Function GetNames() As List(Of String)
        Dim names As List(Of String) = New List(Of String)
        'Dim subdirs = My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.CurrentDirectory) 'myResourcePath
        Select Case Me.txtNameType.Text
            Case "Dir"
                Dim subdir As String
                Dim dirName As String
                For Each subdir In My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.CurrentDirectory)
                    Dim i As Integer = subdir.LastIndexOf("\")
                    If i > -1 Then
                        dirName = subdir.Substring(i + 1)
                    Else
                        dirName = subdir
                    End If
                    names.Add(dirName)
                Next
            Case "Sound"
                Dim mName As String
                Dim mPath As String
                For Each mPath In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.CurrentDirectory & "\sounds", FileIO.SearchOption.SearchTopLevelOnly, "*.wav")
                    Dim i As Integer = mPath.LastIndexOf("\")
                    If i > -1 Then
                        mName = mPath.Substring(i + 1)
                    Else
                        mName = mPath
                    End If
                    names.Add(mName)
                Next
            Case "Image"
                Dim mName As String
                Dim mPath As String
                For Each mPath In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.CurrentDirectory & "\images", FileIO.SearchOption.SearchTopLevelOnly, "*.bmp")
                    Dim i As Integer = mPath.LastIndexOf("\")
                    If i > -1 Then
                        mName = mPath.Substring(i + 1)
                    Else
                        mName = mPath
                    End If
                    names.Add(mName)
                Next
        End Select

        Return names
    End Function

    Private Sub lstNames_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstNames.DoubleClick
        If Not IsNothing(Me.lstNames.SelectedItem) Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub lstNames_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstNames.SelectedIndexChanged
        Me.txtName.Text = names(Me.lstNames.SelectedIndex)
    End Sub
End Class
