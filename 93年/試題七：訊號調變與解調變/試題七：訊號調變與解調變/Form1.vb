Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t = Val(TextBox2.Text)
        Dim f1 = Val(TextBox1.Text)
        Dim f2 = Val(TextBox3.Text)
        Dim A = Val(TextBox4.Text)
        Dim x = PictureBox1.Width : Dim y = PictureBox1.Width
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        g.DrawLine(Pens.Black, New Point(20, 0), New Point(20, 220))
        g.DrawLine(Pens.Black, New Point(20, 219), New Point(400, 219))
        Dim p As New Queue(Of Point)
        For i = 0 To 10 Step t
            Dim k = Math.Cos(f1 * i) * A * Math.Cos(f2 * i)
            p.Enqueue(New Point(CInt(380 * i / 10 + 20), CInt(110 - (110 * Math.Cos(f1 * i) * Math.Cos(f2 * i)))))
        Next
        g.DrawLines(Pens.Black, p.ToArray)
    End Sub
End Class

