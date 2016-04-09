Module myModule
    Declare Function MoveWindow Lib "user32" _
    (ByVal hWnd As Integer, _
    ByVal x As Integer, ByVal y As Integer, _
    ByVal nWidth As Integer, ByVal nHeight As Integer, _
    ByVal bRepaint As Integer) As Integer

    Public Declare Function GetVolumeInformation Lib "kernel32" Alias "GetVolumeInformationA" ( _
    ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, _
    ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, _
    ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, _
    ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer

    'Public fMain As frmMain

    'Public fActions As dlgActions

    'Friend fCallForm As Form

    Public RegisterOK As Boolean = False

    'Public myKHConnStr As String

    Public myMapGst As String = "BanDo.gst"
    Public myMapNhoGst As String = "BanDoNho.gst"
    Public myHienDanhSach As Boolean = True
    Public myCoordSysType As Integer = 1

    Friend fBanDoNho As dlgBanDoNho
    Friend intMonitorW, intMonitorH As Integer

    Friend Function toUnicode(ByVal t1) As String
        Dim KQ As String = ""
        'If IsNull(t1) Then
        Try
            If t1 Is Nothing Then
                t1 = ""
            Else
                t1 = CType(t1, String)
            End If
            Dim aViet() As String = {"Ă", "Â", "Ê", "Ô", "Ơ", "Ư", "Đ", "ă", "â", "ê", "ô", _
          "ơ", "ư", "đ", "*", "*", "*", "*", "*", "*", "à", "ả", "ã", "á", "ạ", _
          "*", "ằ", "ẳ", "ẵ", "ắ", "*", "*", "*", "*", "*", "*", "*", "ặ", "ầ", _
          "ẩ", "ẫ", "ấ", "ậ", "è", "*", "ẻ", "ẽ", "é", "ẹ", "ề", "ể", "ễ", "ế", _
          "ệ", "ì", "ỉ", "*", "*", "*", "ĩ", "í", "ị", "ò", "à", "ỏ", "õ", "ó", "ọ", _
          "ồ", "ổ", "ỗ", "ố", "ộ", "ờ", "ở", "ỡ", "ớ", "ợ", "ù", "*", "ủ", "ũ", _
          "ú", "ụ", "ừ", "ử", "ữ", "ứ", "ự", "ỳ", "ỷ", "ỹ", "ý", "ỵ", "*"}
            Dim t2 As String = ""
            Dim i, j As Integer
            For i = 1 To Len(t1)
                j = Asc(Mid(t1, i, 1)) - 161
                If j < 0 Then
                    t2 = t2 + Mid(t1, i, 1)
                Else
                    If Mid(t1, j, 1) = "*" Then
                        t2 = t2 + Mid(t1, i, 1)
                    Else
                        t2 = t2 + aViet(j)
                    End If
                End If
            Next
            KQ = t2
        Catch
        End Try
        Return KQ
    End Function

End Module
