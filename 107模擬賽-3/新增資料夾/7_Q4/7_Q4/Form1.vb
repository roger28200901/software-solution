Public Class Form1
    Dim a, n(6, 6) As Integer
    Dim bmp(10) As Bitmap
    Dim s(6, 6) As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 1 To 6
            For j = 1 To 6
                s(i, j) = "PictureBox" & (i - 1) * 6 + j
            Next
        Next
        For i = 1 To 10
            bmp(i) = New Bitmap(36, 30)
        Next

        Dim p As New Pen(Color.Green, 3)
        Dim g As Graphics
        g = Graphics.FromImage(bmp(1))
        g.Clear(Color.White)
        g.DrawLine(p, 0, 15, 36, 15)
        PictureBox37.Image = bmp(1)


        g = Graphics.FromImage(bmp(2))
        g.Clear(Color.White)
        g.DrawLine(p, 0, 15, 36, 15)
        g.DrawLine(p, 18, 0, 18, 30)
        PictureBox38.Image = bmp(2)


        g = Graphics.FromImage(bmp(3))
        g.Clear(Color.White)
        g.DrawLine(p, 18, 0, 18, 30)
        PictureBox39.Image = bmp(3)


        g = Graphics.FromImage(bmp(4))
        g.Clear(Color.White)
        g.DrawLine(p, 0, 15, 18, 15)
        g.DrawLine(p, 18, 15, 18, 30)
        PictureBox40.Image = bmp(4)


        g = Graphics.FromImage(bmp(5))
        g.Clear(Color.White)
        g.DrawLine(p, 0, 15, 18, 15)
        g.DrawLine(p, 18, 15, 18, 0)
        PictureBox41.Image = bmp(5)
        '-----------------------------------
        p = New Pen(Color.Blue, 3)
        g = Graphics.FromImage(bmp(6))
        g.Clear(Color.White)
        g.DrawLine(p, 0, 15, 36, 15)



        g = Graphics.FromImage(bmp(7))
        g.Clear(Color.White)
        g.DrawLine(p, 0, 15, 36, 15)
        g.DrawLine(p, 18, 0, 18, 30)



        g = Graphics.FromImage(bmp(8))
        g.Clear(Color.White)
        g.DrawLine(p, 18, 0, 18, 30)



        g = Graphics.FromImage(bmp(9))
        g.Clear(Color.White)
        g.DrawLine(p, 0, 15, 18, 15)
        g.DrawLine(p, 18, 15, 18, 30)



        g = Graphics.FromImage(bmp(10))
        g.Clear(Color.White)
        g.DrawLine(p, 0, 15, 18, 15)
        g.DrawLine(p, 18, 15, 18, 0)


    End Sub

    Private Sub PictureBox37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox37.Click
        a = 1
    End Sub

    Private Sub PictureBox38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox38.Click
        a = 2
    End Sub

    Private Sub PictureBox39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox39.Click
        a = 3
    End Sub

    Private Sub PictureBox40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox40.Click
        a = 4
    End Sub

    Private Sub PictureBox41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox41.Click
        a = 5
    End Sub

   

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click, PictureBox3.Click, PictureBox2.Click, PictureBox4.Click, PictureBox5.Click, PictureBox6.Click, PictureBox7.Click, PictureBox8.Click, PictureBox9.Click, PictureBox10.Click, PictureBox11.Click, PictureBox12.Click, PictureBox13.Click, PictureBox14.Click, PictureBox15.Click, PictureBox16.Click, PictureBox17.Click, PictureBox18.Click, PictureBox19.Click, PictureBox20.Click, PictureBox21.Click, PictureBox22.Click, PictureBox23.Click, PictureBox24.Click, PictureBox25.Click, PictureBox26.Click, PictureBox27.Click, PictureBox28.Click, PictureBox29.Click, PictureBox30.Click, PictureBox31.Click, PictureBox32.Click, PictureBox33.Click, PictureBox34.Click, PictureBox35.Click, PictureBox36.Click

        For i = 1 To 6
            For j = 1 To 6
                If s(i, j) = sender.name Then
                    n(i, j) = a
                End If
                If n(i, j) <> 0 Then
                    Controls(s(i, j)).BackgroundImage = bmp(n(i, j))
                End If
            Next
        Next
        Dim b As Boolean = False

        If n(1, 1) <> 0 Then
            For i = 1 To 6
                For j = 1 To 6
                    If n(i, j) <> 0 Then
                        go(i, j, n)
                    Else
                        
                    End If
                Next
                
            Next
        End If




    End Sub

    Sub go(ByVal y As Integer, ByVal x As Integer, ByVal m(,) As Integer)

        If m(y, x) <> 0 And m(y, x) < 6 Then
            Controls(s(y, x)).BackgroundImage = bmp((m(y, x) + 5))
            '  n(y, x) += 5
            m(y, x) += 5
        End If

        Select Case m(y, x)

            Case 1, 6
                If x < 6 Then
                    If m(y, x + 1) <> 0 Then
                        go(y, x + 1, m)
                    End If
                End If

            Case 2, 7
                If x < 6 Then
                    If m(y, x + 1) <> 0 Then
                        go(y, x + 1, m)
                    End If
                End If
                If x > 1 Then
                    If m(y, x - 1) <> 6 And m(y, x - 1) <> 0 And m(y, x - 1) <> 7 Then
                        go(y, x - 1, m)
                    End If
                End If
                If y < 6 Then
                    If m(y + 1, x) <> 0 Then
                        go(y + 1, x, m)
                    End If
                End If
                If y > 1 Then
                    If m(y - 1, x) <> 0 And m(y - 1, x) < 6 Then
                        go(y - 1, x, m)
                    End If
                End If

            Case 3, 8
                If y < 6 Then
                    If m(y + 1, x) <> 0 Then
                        go(y + 1, x, m)
                    End If
                End If
                If y > 1 Then
                    If m(y - 1, x) <> 0 And m(y - 1, x) < 6 Then
                        go(y - 1, x, m)
                    End If
                End If

            Case 4, 9
                If y < 6 Then
                    If m(y + 1, x) <> 0 Then
                        go(y + 1, x, m)
                    End If
                End If

            Case 5, 10
                If x > 1 Then
                    If m(y, x - 1) <> 6 And m(y, x - 1) <> 0 Then
                        go(y, x - 1, m)
                    End If
                End If
        End Select

        If n(1, 6) > 5 Then
            Label1.ForeColor = Color.Blue
            Exit Sub
        End If
        If n(6, 6) > 5 Then
            Label2.ForeColor = Color.Blue
            Exit Sub
        End If
    End Sub

End Class
