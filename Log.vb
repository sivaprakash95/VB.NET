Imports System.IO

Module Log
    Dim FileName As String = ""
    Dim DirInfo As String = ""
    Dim DateToday As String = ""
    Public Sub Main()
        Try
            WriteLog("Application Started")
            Dim i As Integer = 1
            WriteLog(i.ToString())
            Dim j As Integer = 0
            WriteLog(j.ToString())
            Dim r As Integer
            r = i / j
            WriteLog(r.ToString())
        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub

    Sub WriteLog(ByVal status As String)
        Try
            Dim fs As FileStream
            Dim objWriter As StreamWriter
            Dim chatlog As String
            
            DateToday = Today.ToString("yyyyMMdd")
            DirInfo = "C:\Common\Log\Log_" & DateToday

            If FileName = "" Then FileName = "Log_" & Now().ToString("HH_mm_ss") 'Now file created Second by second /Munite by Munite/Hour by Hour

            Dim DirPath As DirectoryInfo = New DirectoryInfo(DirInfo)

            If DirPath.Exists Then
            Else
                DirPath.Create()
            End If

            chatlog = DirInfo & "\" & FileName & ".txt"

            If File.Exists(chatlog) Then
            Else
                fs = New FileStream(chatlog, FileMode.Create, FileAccess.Write)
                fs.Close()
            End If

            objWriter = New System.IO.StreamWriter(chatlog, True)
            If status <> "" Then objWriter.WriteLine(Now().ToString() & " : " & status)
            objWriter.Close()

        Catch ex As Exception
            MsgBox("writelog :" + ex.ToString)
        End Try
    End Sub

End Module
