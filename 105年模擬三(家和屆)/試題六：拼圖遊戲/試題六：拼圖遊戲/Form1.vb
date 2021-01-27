Public Class Form1
    Dim pb() As PictureBox
    Dim bm() As Bitmap
    Dim difficult
    Dim steps As Integer = 0
    Dim n As Integer = 0
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        resetAll()
    End Sub
    'bm 1 對應 pb 1就是正解
    Private Function checkAnswer(ByVal resetOrNot As Boolean)
        Dim answerCheck = 0
        If difficult = 1 Then
            For i = 1 To 3
                If IsNothing(pb(i).Image) = True Then
                    Return False
                End If
                If pb(i).Image.Equals(bm(i)) = True Then
                    answerCheck += 1
                End If
            Next
            If answerCheck = 3 Then
                If resetOrNot = True Then
                    Return True
                End If
                MsgBox("恭喜完成", MsgBoxStyle.OkOnly, "拼圖遊戲程式")
                Label3.Text = "共走了" & steps & "步"
                Return True
            End If
        Else
            For i = 1 To 8
                If IsNothing(pb(i).Image) = True Then
                    Return False
                End If
                If pb(i).Image.Equals(bm(i)) = True Then
                    answerCheck += 1
                End If
            Next
            If answerCheck = 8 Then
                If resetOrNot = True Then
                    Return True
                End If
                MsgBox("恭喜完成", MsgBoxStyle.OkOnly, "拼圖遊戲程式")
                Label3.Text = "共走了" & steps & "步"
                Return True
            End If
        End If
    End Function
    Private Sub resetAll()
S:
        steps = 0
        Label3.Text = ""
        ReDim pb(0), bm(0)

        For i = 1 To 9
            Me.Controls.Remove(Controls("PictureBox" & i))
        Next
        Button1.Enabled = True
        Button2.Enabled = False
        Dim number = ComboBox1.SelectedItem

        Select Case number
            Case "2*2"
                n = 4
                difficult = 1
                ReDim pb(4), bm(4)
                For i = 1 To 2
                    For j = 1 To 2
                        Dim k As Integer = (i - 1) * 2 + j
                        Dim pic As New PictureBox
                        With pic
                            .Location = New Point(90 + (j - 1) * 200, 150 + (i - 1) * 150)
                            .Size = New Size(200, 150)
                            .Visible = True
                            .Name = "PictureBox" & k
                            .BackColor = Color.White
                            .SizeMode = PictureBoxSizeMode.Zoom
                        End With
                        pb(k) = pic
                        AddHandler pb(k).Click, AddressOf PictureBox_Click
                        Me.Controls.Add(pic)
                    Next
                Next
            Case "3*3"
                n = 9
                difficult = 2
                ReDim pb(9), bm(9)
                For i = 1 To 3
                    For j = 1 To 3
                        Dim k As Integer = (i - 1) * 3 + j
                        Dim pic As New PictureBox
                        With pic
                            .Location = New Point(90 + (j - 1) * 200, 150 + (i - 1) * 150)
                            .Size = New Size(200, 150)
                            .Visible = True
                            .Name = "PictureBox" & k
                            .SizeMode = PictureBoxSizeMode.Zoom
                        End With
                        pb(k) = pic
                        AddHandler pb(k).Click, AddressOf PictureBox_Click
                        Me.Controls.Add(pic)
                    Next
                Next

        End Select

        setImage()
        randomImage()

        Dim callback = checkAnswer(True)
        If callback = True Then
            GoTo S
        End If
    End Sub
    Private Sub PictureBox_Click(sender As Object, e As EventArgs)
        Dim obj As PictureBox = sender

        If IsNothing(obj.Image) Then
            Return
        End If

        Dim getImage As Bitmap = obj.Image
        If difficult = 1 Then
            For i = 1 To 4
                If IsNothing(pb(i).Image) = True Then
                    pb(i).Image = getImage
                    obj.Image = Nothing
                End If
            Next
        Else
            For i = 1 To 9
                If IsNothing(pb(i).Image) = True Then
                    pb(i).Image = getImage
                    obj.Image = Nothing
                End If
            Next
        End If


        steps += 1

        If checkAnswer(False) = True Then
            For i = 1 To n
                pb(i).Image = bm(i)
            Next
        End If

    End Sub
    Private Sub randomImage()
        If difficult = 1 Then
            Dim sequence As New List(Of Integer)
            sequence.Add(1) : sequence.Add(2) : sequence.Add(3) : sequence.Add(4)

            For i = 1 To 3
                Dim r2 As Integer = Rnd() * 3 + 1
                Do Until sequence.IndexOf(r2) <> -1
                    r2 = Rnd() * 3 + 1
                Loop
                sequence.Remove(r2)

                pb(r2).Image = bm(i)
            Next
        Else
            Dim sequence As New List(Of Integer)
            sequence.Add(1) : sequence.Add(2) : sequence.Add(3) : sequence.Add(4)
            sequence.Add(5) : sequence.Add(6) : sequence.Add(7) : sequence.Add(8)
            sequence.Add(9)
            For i = 1 To 8
                Dim r2 As Integer = Rnd() * 8 + 1
                Do Until sequence.IndexOf(r2) <> -1
                    r2 = Rnd() * 8 + 1
                Loop
                sequence.Remove(r2)

                pb(r2).Image = bm(i)
            Next
        End If
    End Sub
    Private Sub setImage()
        If difficult = 1 Then
            For i = 1 To 2
                For j = 1 To 2
                    Dim k As Integer = (i - 1) * 2 + j

                    Dim resizeImage As Bitmap = rightPic.Image
                    Dim w As Integer = resizeImage.Width / 2 - 1
                    Dim h As Integer = resizeImage.Height / 2 - 1
                    Dim b As Bitmap = New Bitmap(w, h)

                    Dim nx As Integer = 0
                    Dim ny As Integer = 0
                    For x = (j - 1) * w To w + (j - 1) * w - 1
                        For y = (i - 1) * h To h + (i - 1) * h - 1
                            Dim p As Color = resizeImage.GetPixel(x, y)
                            b.SetPixel(nx, ny, p)
                            ny += 1
                        Next
                        ny = 0
                        nx += 1
                    Next
                    bm(k) = b
                Next
            Next
        Else
            For i = 1 To 3
                For j = 1 To 3
                    Dim k As Integer = (i - 1) * 3 + j

                    Dim resizeImage As Bitmap = rightPic.Image
                    Dim w As Integer = resizeImage.Width / 3
                    Dim h As Integer = resizeImage.Height / 3
                    Dim b As Bitmap = New Bitmap(w, h)

                    Dim nx As Integer = 0
                    Dim ny As Integer = 0
                    For x = (j - 1) * w To w + (j - 1) * w - 1
                        For y = (i - 1) * h To h + (i - 1) * h - 1
                            Dim p As Color = resizeImage.GetPixel(x, y)
                            b.SetPixel(nx, ny, p)
                            ny += 1
                        Next
                        ny = 0
                        nx += 1
                    Next
                    bm(k) = b
                Next
            Next
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        resetAll()
    End Sub
End Class
