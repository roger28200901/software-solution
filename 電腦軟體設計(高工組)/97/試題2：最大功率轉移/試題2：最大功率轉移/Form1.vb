Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim minR = Int(TextBox1.Text)
        Dim maxR = Int(TextBox2.Text)
        Dim deltaR = Int(TextBox3.Text)
        Dim V = Int(TextBox4.Text)
        Dim R1 = Int(TextBox5.Text)

        Dim maxP = (V / 2) ^ 2 / R1
        Dim maxY As Integer = 0
        If Mid(maxP, maxP.ToString.Length, 1) <> "0" Then
            maxY = maxP - Int(Mid(maxP, maxP.ToString.Length, 1)) + 10
        End If

        Dim deltaX = 260 / maxR
        Dim deltaY = 260 / maxY


        Dim g As Graphics = PictureBox1.CreateGraphics

        g.Clear(Color.Gray)
        g.FillRectangle(Brushes.White, 20, 20, 260, 260)
        g.DrawRectangle(Pens.Black, 20, 20, 260, 260)

        For x = 0 To maxR Step 10
            g.DrawString(x, New Font("標楷體", 8), Brushes.Black, New Point(10 + deltaX * x, 280))
        Next


        For y = 0 To maxY Step 10
            g.DrawString(y.ToString.PadLeft(2, " "), New Font("標楷體", 8), Brushes.Black, New Point(5, 280 - deltaY * y))
        Next


        Dim P As New List(Of Point)
        Dim Xm As New List(Of Double)
        Dim Ym As New List(Of Double)
        For R = minR To maxR Step deltaR
            Dim V2 As Double = V * (R / (R1 + R))
            Dim Pw As Double = V2 ^ 2 / R
            Xm.Add(R)
            Ym.Add(Pw)
            P.Add(New Point(20 + R * deltaX, 280 - Pw * deltaY))
        Next
        Dim my = Ym.Max
        Dim indexY = Ym.IndexOf(my)
        Dim YtX = Xm((indexY))


        g.DrawString("*", New Font("標楷體", 8), Brushes.Red, New Point(20 + YtX * deltaX - 4, 280 - my * deltaY - 4))


        g.DrawLines(Pens.Blue, P.ToArray)
    End Sub
End Class
