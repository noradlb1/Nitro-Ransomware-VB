Imports System
Imports System.IO

Namespace NitroRansomware
	Friend Class Logs
		Private save As String
		Private filename As String
		Private config As String
		Private type As Integer
		Public Sub New(ByVal configType As String, ByVal outType As Integer)
			save = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
			filename = "\logs.txt"
			config = configType
			type = outType
		End Sub
		Private Sub Write(ByVal append As String, ByVal message As String)
			If type = 1 Then
				Using w As StreamWriter = File.AppendText(save & filename)
					Dim intro As String = String.Format("{0} {1} - ", Date.Now.ToString("[hh:mm:ss]"), append)
					w.Write(intro & message)
					w.Write(ControlChars.Lf)
				End Using
			ElseIf type = 0 Then
				Dim intro As String = String.Format("{0} {1} - ", Date.Now.ToString("[hh:mm:ss]"), append)
				Console.Write(intro & message)
				Console.Write(ControlChars.Lf)
			Else
				Using w As StreamWriter = File.AppendText(save & filename)
					Dim intro As String = String.Format("{0} {1} - ", Date.Now.ToString("[hh:mm:ss]"), append)
					w.Write(intro & message)
					w.Write(ControlChars.Lf)
				End Using
				Dim consoleIntro As String = String.Format("{0} {1} - ", Date.Now.ToString("[hh:mm:ss]"), append)
				Console.Write(consoleIntro & message)
				Console.Write(ControlChars.Lf)
			End If
		End Sub
		Public Sub Debug(ByVal message As String)
			If config = "DEBUG" Then
				Write("DEBUG", message)
			End If
		End Sub
		Public Sub Info(ByVal message As String)
			If config = "DEBUG" Then
				Write("INFO", message)

			ElseIf config = "INFO" Then
				Write("INFO", message)
			End If
		End Sub
		Public Sub Warning(ByVal message As String)
			If config <> "ERROR" Then
				Write("WARNING", message)
			End If
		End Sub
		Public Sub [Error](ByVal message As String)
			Write("ERROR", message)
		End Sub
	End Class
End Namespace
