Namespace NitroRansomware
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
			Me.label1 = New System.Windows.Forms.Label()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.panel2 = New System.Windows.Forms.Panel()
			Me.label4 = New System.Windows.Forms.Label()
			Me.button1 = New System.Windows.Forms.Button()
			Me.label5 = New System.Windows.Forms.Label()
			Me.textBox3 = New System.Windows.Forms.TextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.button2 = New System.Windows.Forms.Button()
			Me.textBox2 = New System.Windows.Forms.TextBox()
			Me.textBox4 = New System.Windows.Forms.TextBox()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.textBox5 = New System.Windows.Forms.TextBox()
			Me.panel3 = New System.Windows.Forms.Panel()
			Me.label10 = New System.Windows.Forms.Label()
			Me.panel2.SuspendLayout()
			Me.panel3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label1.ForeColor = System.Drawing.Color.Red
			Me.label1.Location = New System.Drawing.Point(25, 19)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(579, 37)
			Me.label1.TabIndex = 2
			Me.label1.Text = " Oh no! Your files have been encrypted."
			' 
			' textBox1
			' 
			Me.textBox1.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(35)))), (CInt((CByte(39)))), (CInt((CByte(42)))))
			Me.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.textBox1.Font = New System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.textBox1.ForeColor = System.Drawing.SystemColors.MenuBar
			Me.textBox1.Location = New System.Drawing.Point(404, 134)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.ReadOnly = True
			Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.textBox1.Size = New System.Drawing.Size(370, 289)
			Me.textBox1.TabIndex = 3
			Me.textBox1.TabStop = False
			Me.textBox1.Text = resources.GetString("textBox1.Text")
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Font = New System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label2.ForeColor = System.Drawing.SystemColors.Control
			Me.label2.Location = New System.Drawing.Point(553, 96)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(45, 25)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Info"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Font = New System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label3.ForeColor = System.Drawing.SystemColors.Control
			Me.label3.Location = New System.Drawing.Point(127, 96)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(147, 25)
			Me.label3.TabIndex = 6
			Me.label3.Text = "Time Remaining"
			' 
			' panel1
			' 
			Me.panel1.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(35)))), (CInt((CByte(39)))), (CInt((CByte(42)))))
			Me.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
			Me.panel1.Location = New System.Drawing.Point(-1, -4)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(807, 32)
			Me.panel1.TabIndex = 4
			' 
			' panel2
			' 
			Me.panel2.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(35)))), (CInt((CByte(39)))), (CInt((CByte(42)))))
			Me.panel2.Controls.Add(Me.label1)
			Me.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
			Me.panel2.Location = New System.Drawing.Point(87, -1)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(613, 67)
			Me.panel2.TabIndex = 7
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Font = New System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label4.ForeColor = System.Drawing.SystemColors.Control
			Me.label4.Location = New System.Drawing.Point(84, 454)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(151, 13)
			Me.label4.TabIndex = 9
			Me.label4.Text = "Enter Discord Nitro giftcode"
			' 
			' button1
			' 
			Me.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
			Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
			Me.button1.Location = New System.Drawing.Point(258, 480)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(75, 23)
			Me.button1.TabIndex = 10
			Me.button1.Text = "Get Key"
			Me.button1.UseVisualStyleBackColor = False
'			Me.button1.Click += New System.EventHandler(Me.button1_Click)
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Font = New System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label5.ForeColor = System.Drawing.SystemColors.Control
			Me.label5.Location = New System.Drawing.Point(84, 526)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(122, 13)
			Me.label5.TabIndex = 11
			Me.label5.Text = "Your Decryption key is:"
			' 
			' textBox3
			' 
			Me.textBox3.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(35)))), (CInt((CByte(39)))), (CInt((CByte(42)))))
			Me.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.textBox3.ForeColor = System.Drawing.SystemColors.Window
			Me.textBox3.Location = New System.Drawing.Point(71, 545)
			Me.textBox3.Name = "textBox3"
			Me.textBox3.ReadOnly = True
			Me.textBox3.Size = New System.Drawing.Size(203, 20)
			Me.textBox3.TabIndex = 12
			Me.textBox3.TabStop = False
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Font = New System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label6.ForeColor = System.Drawing.SystemColors.Control
			Me.label6.Location = New System.Drawing.Point(550, 448)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(84, 19)
			Me.label6.TabIndex = 13
			Me.label6.Text = "Decrypt files"
			' 
			' button2
			' 
			Me.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight
			Me.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
			Me.button2.Location = New System.Drawing.Point(657, 516)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(75, 23)
			Me.button2.TabIndex = 15
			Me.button2.Text = "Decrypt files"
			Me.button2.UseVisualStyleBackColor = False
'			Me.button2.Click += New System.EventHandler(Me.button2_Click)
			' 
			' textBox2
			' 
			Me.textBox2.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(35)))), (CInt((CByte(39)))), (CInt((CByte(42)))))
			Me.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.textBox2.ForeColor = System.Drawing.SystemColors.Window
			Me.textBox2.Location = New System.Drawing.Point(49, 482)
			Me.textBox2.Name = "textBox2"
			Me.textBox2.Size = New System.Drawing.Size(203, 20)
			Me.textBox2.TabIndex = 8
			Me.textBox2.TabStop = False
			Me.textBox2.Text = "discord.gift/example"
			' 
			' textBox4
			' 
			Me.textBox4.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(35)))), (CInt((CByte(39)))), (CInt((CByte(42)))))
			Me.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.textBox4.ForeColor = System.Drawing.SystemColors.Window
			Me.textBox4.Location = New System.Drawing.Point(448, 516)
			Me.textBox4.Name = "textBox4"
			Me.textBox4.Size = New System.Drawing.Size(203, 20)
			Me.textBox4.TabIndex = 17
			Me.textBox4.TabStop = False
			Me.textBox4.Text = "send discord nitro to get key"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Font = New System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label7.ForeColor = System.Drawing.SystemColors.Control
			Me.label7.Location = New System.Drawing.Point(445, 485)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(236, 13)
			Me.label7.TabIndex = 16
			Me.label7.Text = "Warning: Do not try guessing the password."
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Font = New System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label9.ForeColor = System.Drawing.SystemColors.Control
			Me.label9.Location = New System.Drawing.Point(174, 329)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(32, 19)
			Me.label9.TabIndex = 19
			Me.label9.Text = "Log"
			' 
			' textBox5
			' 
			Me.textBox5.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(35)))), (CInt((CByte(39)))), (CInt((CByte(42)))))
			Me.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
			Me.textBox5.Font = New System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.textBox5.ForeColor = System.Drawing.SystemColors.MenuBar
			Me.textBox5.Location = New System.Drawing.Point(35, 364)
			Me.textBox5.Multiline = True
			Me.textBox5.Name = "textBox5"
			Me.textBox5.ReadOnly = True
			Me.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.textBox5.Size = New System.Drawing.Size(347, 59)
			Me.textBox5.TabIndex = 20
			Me.textBox5.TabStop = False
			' 
			' panel3
			' 
			Me.panel3.BackColor = System.Drawing.Color.Crimson
			Me.panel3.Controls.Add(Me.label10)
			Me.panel3.Location = New System.Drawing.Point(35, 134)
			Me.panel3.Name = "panel3"
			Me.panel3.Size = New System.Drawing.Size(347, 178)
			Me.panel3.TabIndex = 21
			' 
			' label10
			' 
			Me.label10.AutoSize = True
			Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight
			Me.label10.Location = New System.Drawing.Point(23, 47)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(293, 76)
			Me.label10.TabIndex = 22
			Me.label10.Text = "00:00:00"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(44)))), (CInt((CByte(47)))), (CInt((CByte(51)))))
			Me.ClientSize = New System.Drawing.Size(800, 600)
			Me.ControlBox = False
			Me.Controls.Add(Me.panel3)
			Me.Controls.Add(Me.textBox5)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.textBox4)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.textBox3)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.textBox2)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.panel2)
			Me.Controls.Add(Me.panel1)
			Me.ForeColor = System.Drawing.SystemColors.ControlText
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
			Me.Name = "Form1"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load)
			Me.panel2.ResumeLayout(False)
			Me.panel2.PerformLayout()
			Me.panel3.ResumeLayout(False)
			Me.panel3.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private backgroundWorker1 As System.ComponentModel.BackgroundWorker
		Private label1 As System.Windows.Forms.Label
		Private textBox1 As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private panel1 As System.Windows.Forms.Panel
		Private panel2 As System.Windows.Forms.Panel
		Private label4 As System.Windows.Forms.Label
		Private WithEvents button1 As System.Windows.Forms.Button
		Private label5 As System.Windows.Forms.Label
		Private textBox3 As System.Windows.Forms.TextBox
		Private label6 As System.Windows.Forms.Label
		Private WithEvents button2 As System.Windows.Forms.Button
		Private textBox2 As System.Windows.Forms.TextBox
		Private textBox4 As System.Windows.Forms.TextBox
		Private label7 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private textBox5 As System.Windows.Forms.TextBox
		Private panel3 As System.Windows.Forms.Panel
		Private label10 As System.Windows.Forms.Label
	End Class
End Namespace