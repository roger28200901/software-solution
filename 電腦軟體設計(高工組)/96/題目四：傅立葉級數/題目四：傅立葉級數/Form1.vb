Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'draw
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)

        g.DrawLine(Pens.Black, New Point(50, 250), New Point(550, 250))
        g.DrawLine(Pens.Black, New Point(50, 250), New Point(50, 50))
        Dim deltaX = (550 - 50) / 6
        Dim deltaY = (250 - 50) / 2
        Dim x As Decimal = 0
        For x = -3 To 3 Step 0.5
            g.DrawString(x, New Font("標楷體", 8), Brushes.Black, New Point(50 + deltaX * (3 + x), 250))
        Next
        Dim y As Decimal = 0
        For y = -0.5 To 1.5 Step 0.5
            g.DrawString(y.ToString.PadLeft(4, " "), New Font("標楷體", 8), Brushes.Black, New Point(25, 250 - Math.Abs((-0.5 - y)) * deltaY - 5))
        Next

        '
        '原點 y = 200
        '

        Dim N = Int(TextBox1.Text)
        Dim stepPlus = CDec(TextBox2.Text)
        Dim Yn As New List(Of Point)
        Dim M As Integer = 0
        If N Mod 2 = 0 Then
            M = N - 1
        Else
            M = N
        End If
        Dim t As Decimal = 0
        For t = -3 To 3 Step stepPlus
            Dim sum As Decimal = 0
            For k = 1 To M Step 2
                sum += 2 / (k * Math.PI) * Math.Cos(k * Math.PI * t + ((-1) ^ ((k - 1) / 2) - 1) * Math.PI / 2)
            Next
            sum += 0.5
            Yn.Add(New Point(50 + deltaX * (3 + t), 250 - Math.Abs((-0.5 - sum)) * deltaY))
        Next
        'g.DrawLines(Pens.Blue, Yn.ToArray)
        'drawlines
        Dim lastX As Integer = CInt(Yn(0).X)
        Dim lastY As Integer = CInt(Yn(0).Y)
        For x = 1 To Yn.Count - 1
            g.DrawLine(Pens.Blue, New Point(lastX, lastY), New Point(Yn(x).X, Yn(x).Y))
            lastX = Yn(x).X
            lastY = Yn(x).Y
        Next
    End Sub
End Class
