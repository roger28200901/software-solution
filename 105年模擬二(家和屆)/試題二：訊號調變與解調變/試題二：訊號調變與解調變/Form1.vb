Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t = Val(TextBox1.Text)
        Dim fi = Val(TextBox2.Text)
        Dim fl = Val(TextBox3.Text)
        Dim A = Val(TextBox4.Text)

        Dim g As Graphics = PictureBox1.CreateGraphics

        g.Clear(Color.White)
        Dim w = PictureBox1.Width
        Dim h = PictureBox1.Height
        Dim margin = 20

        g.DrawLine(Pens.Black, New Point(margin, (h - margin) / 2), New Point(w, (h - margin) / 2))
        g.DrawLine(Pens.Black, New Point(margin, 0), New Point(margin, h - margin))
        g.DrawLine(Pens.Black, New Point(w, h - margin), New Point(margin, h - margin))
        Dim x As New Queue(Of Decimal)
        Dim y As New Queue(Of Decimal)
        '0秒到2秒 間隔0.001秒

        For i = 0 To 16 Step t
            y.Enqueue(A * Math.Cos(fi * i) * Math.Cos(fl * i))
        Next

        Dim lastXY = New Point(margin, 0)

        For i = 0 To y.Count - 1
            Dim deltaY = (h - margin) / A / 2


            Dim xL = margin + i * (w - margin) / y.Count
            Dim yL = (((h - margin) / 2) - (y(i)) * deltaY)
            Dim drawPoint = New Point(xL, yL)
            g.DrawLine(Pens.Black, lastXY, drawPoint)
            lastXY = drawPoint
        Next


    End Sub
End Class
