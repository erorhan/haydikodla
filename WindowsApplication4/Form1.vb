Public Class Form1
    Dim tm = New System.Windows.Forms.Timer()
    Dim counter As Integer = 0
    Dim PUSULA As String
    Dim E As Integer

    Private Sub Form1_Load(sender As Object, e1 As EventArgs) Handles MyBase.Load
        'PictureBox1.BackColor = Color.Transparent
        'PictureBox1.BackColor = Color.FromArgb(0, 0, 0, 0)
        PUSULA = "E"
        Label2.Text = PUSULA
    End Sub



    Sub onTick(sender As Object, e1 As EventArgs)
        Label1.Text = RichTextBox1.Lines(counter)
        counter += 1
        If counter >= RichTextBox1.Lines.Count Then
            counter = 0
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e1 As EventArgs) Handles Button2.Click
        Me.RichTextBox1.Lines = Me.RichTextBox1.Text.Split(New Char() {ControlChars.Lf},
                                                       StringSplitOptions.RemoveEmptyEntries)



        For i = 0 To RichTextBox1.Lines.Count - 1
            TextBox1.Text = RichTextBox1.Lines(i)
            'PictureBox1.Location = PictureBox1.Location + New Point(1, PictureBox1.Location.Y)
            E = PictureBox1.Left
            For i2 As Integer = 0 To TextBox1.Lines.Count - 1
                Dim tmp_split_bol As String() = TextBox1.Lines(i2).Split(" ")

                If tmp_split_bol(0) = "git" Then
                    TextBox2.Text = tmp_split_bol(1) * 50
                    If PUSULA = "E" Then
                        PictureBox1.Left = PictureBox1.Left + TextBox2.Text
                    ElseIf PUSULA = "N" Then
                        PictureBox1.Top = PictureBox1.Top - TextBox2.Text
                    ElseIf PUSULA = "W" Then
                        PictureBox1.Left = PictureBox1.Left - TextBox2.Text
                    ElseIf PUSULA = "S" Then
                        PictureBox1.Top = PictureBox1.Top + TextBox2.Text
                    End If
                    Label2.Text = PUSULA
                End If


                If tmp_split_bol(0) = "dön" And tmp_split_bol(1) = "sağ" Then
                    TextBox2.Text = tmp_split_bol(1)
                    PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    If PUSULA = "E" Then
                        PUSULA = "S"
                    ElseIf PUSULA = "S" Then
                        PUSULA = "W"
                    ElseIf PUSULA = "W" Then
                        PUSULA = "N"
                    ElseIf PUSULA = "N" Then
                        PUSULA = "E"
                    End If
                End If

                If tmp_split_bol(0) = "dön" And tmp_split_bol(1) = "sol" Then
                    TextBox2.Text = tmp_split_bol(1)
                    PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipXY)
                    If PUSULA = "E" Then
                        PUSULA = "N"
                    ElseIf PUSULA = "N" Then
                        PUSULA = "W"
                    ElseIf PUSULA = "W" Then
                        PUSULA = "S"
                    ElseIf PUSULA = "S" Then
                        PUSULA = "E"
                    End If
                    Label2.Text = PUSULA
                End If

                If PictureBox1.Location.X > 220 And PictureBox1.Location.Y > 220 Then

                    Form2.Show()
                End If

            Next

            'PictureBox1.Left = PictureBox1.Left + TextBox2.Text

            wait(1000)

        Next



    End Sub
    Private Sub wait(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds <interval
            ' Allows UI to remain responsive
                    Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Private Sub Button1_Click(sender As Object, e1 As EventArgs) Handles Button1.Click
        Dim countrt1 As String
        countrt1 = RichTextBox1.Lines.Count
        Label1.Text = countrt1
    End Sub

    Private Sub Button3_Click(sender As Object, e1 As EventArgs) Handles Button3.Click
        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)

        If PUSULA = "E" Then
            PUSULA = "S"
        ElseIf PUSULA = "S" Then
            PUSULA = "W"
        ElseIf PUSULA = "W" Then
            PUSULA = "N"
        ElseIf PUSULA = "N" Then
            PUSULA = "E"
        End If


        Label2.Text = PUSULA


    End Sub

    Private Sub Button4_Click(sender As Object, e1 As EventArgs) Handles Button4.Click
        PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipXY)

        If PUSULA = "E" Then
            PUSULA = "N"
        ElseIf PUSULA = "N" Then
            PUSULA = "W"
        ElseIf PUSULA = "W" Then
            PUSULA = "S"
        ElseIf PUSULA = "S" Then
            PUSULA = "E"
        End If


        Label2.Text = PUSULA
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Controls.Clear() 'removes all the controls on the form
        InitializeComponent() 'load all the controls again
        Form1_Load(e, e) 'Load everything in your form load event again
        Me.Refresh()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RichTextBox1.Text = RichTextBox1.Text & "git 1" & vbNewLine
        PictureBox1.Refresh()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RichTextBox1.Text = RichTextBox1.Text & "dön sol" & vbNewLine
        PictureBox1.Refresh()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        RichTextBox1.Text = RichTextBox1.Text & "dön sağ" & vbNewLine
        PictureBox1.Refresh()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form2.Show()
    End Sub
End Class
