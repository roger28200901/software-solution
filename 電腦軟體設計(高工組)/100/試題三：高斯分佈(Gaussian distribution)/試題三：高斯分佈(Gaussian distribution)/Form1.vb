Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Xmin = Val(TextBox1.Text)
        Dim Xmax = Val(TextBox2.Text)
        Dim mean = Val(TextBox3.Text)
        Dim variance = Val(TextBox4.Text)
        Dim deltaX = 580 / (Xmax - Xmin)
        Dim deltaY = 300 / (1 - (-0.1))
        Dim p As New List(Of Point)
        Dim sp As Decimal = 0.01 '精準度
        Dim x As Decimal = 0
        For x = Xmin To Xmax Step sp
            Dim y = (Math.Exp(-((x - mean) ^ 2) / (2 * variance))) / (Math.Sqrt(2 * Math.PI) * Math.Sqrt(variance))
            p.Add(New Point(20 + (x + Math.Abs(Xmin)) * deltaX, 0.9 * deltaY - y * deltaY))
        Next
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)


        For x = Xmin To Xmax
            g.DrawString(x, New Font("標楷體", 8), Brushes.Black, New Point(10 + (x - Xmin) * deltaX, 283))
        Next


        For y = -0.1 To 1 Step 0.1
            If y <> 1 Then
                g.DrawString(y.ToString.PadLeft(3, " "), New Font("標楷體", 8), Brushes.Black, New Point(-3, -28 + (1 - y) * deltaY))
            End If
        Next
        If RadioButton1.Checked Then
            g.DrawLines(Pens.Blue, p.ToArray)
        Else
            g.DrawLines(Pens.Red, p.ToArray)
        End If


        g.DrawLine(Pens.Black, New Point(20, 280), New Point(20, 0))
        g.DrawLine(Pens.Black, New Point(20, 280), New Point(600, 280))

    End Sub
End Class
