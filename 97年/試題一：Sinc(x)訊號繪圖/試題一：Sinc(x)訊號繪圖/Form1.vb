Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim minX = Val(TextBox1.Text)
        Dim maxX = Val(TextBox2.Text)

        Dim x(maxX - minX) As Point
        Dim x2(maxX - minX) As Point

        Dim sin(maxX - minX) As Point


        '邊界 10
        Dim delta = Val((PictureBox1.Width - 20) / UBound(x))
        For i = 0 To UBound(x)
            x(i) = New Point(10 + i * delta, PictureBox1.Height / 2 - 2)
        Next

        For i = 0 To UBound(x)
            x2(i) = New Point(10 + i * delta, PictureBox1.Height / 2 + 2)
        Next

        For i = 0 To UBound(x)
            x(i) = New Point(10 + i * delta, PictureBox1.Height / 2 - 2)
        Next

        For i = 0 To UBound(x)
            x2(i) = New Point(10 + i * delta, PictureBox1.Height / 2 + 2)
        Next

        'y點
        Dim hei = PictureBox1.Height * 1.2 / 2
        Dim c = 0
        For i = -0.2 To 1 Step 0.2
            If i <> 0 Then
                g.DrawString(i, Me.Font, Brushes.Black, New Point(PictureBox1.Width / 2 + 10, hei + c * 30))
            End If
            c -= 1
        Next


        'X軸
        g.DrawLine(Pens.Black, New Point(0, PictureBox1.Height / 2), New Point(3 + PictureBox1.Width, PictureBox1.Height / 2))
        'Y軸
        g.DrawLine(Pens.Black, New Point(PictureBox1.Width / 2, 0), New Point(PictureBox1.Width / 2, PictureBox1.Height))

        'X點
        For i = minX To maxX
            If i Mod 5 = 0 Then
                g.DrawString(i, Me.Font, Brushes.Black, New Point((i - minX) * delta, PictureBox1.Height / 2 + 10))
            End If
            g.DrawLine(Pens.Black, x(i - minX), x2(i - minX))
        Next

        'sincX
        For i = minX To maxX
            sin(i - minX) = New Point(10 + (i - minX) * delta, (1 - Sinc(i)) * PictureBox1.Height / 2)
        Next

        g.DrawLines(Pens.Red, sin)

    End Sub
    Function Sinc(ByVal x As Double)
        If x = 0 Then
            Return 1
        Else
            Return Math.Sin(x) / x
        End If


    End Function
End Class
