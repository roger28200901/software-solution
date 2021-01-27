Public Class Form1
    Dim g As Graphics
    Dim w As Integer
    Dim h As Integer
    Dim p(2) As Point
    Dim pa(2) As Point
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        drawXY()
    End Sub
    Private Sub drawXY()
        g = PictureBox1.CreateGraphics

        g.DrawLine(Pens.Black, New Point(0, h / 2), New Point(w, h / 2))
        g.DrawLine(Pens.Black, New Point(w / 2, 0), New Point(w / 2, h))
        For x = -10 To 10
            Dim delta = w / 20
            g.DrawString(x, Me.Font, Brushes.Black, New Point(w / 2 + delta * x, h / 2 + 5))
        Next
        For y = -10 To 10
            Dim delta = h / 20
            g.DrawString(y, Me.Font, Brushes.Black, New Point(w / 2 - 15, delta * y + h / 2))
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()

        w = PictureBox1.Width
        h = PictureBox1.Height - 20
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim txt = TextBox1.Text
        txt = txt.Replace(vbCrLf, "/")
        Dim datas = txt.Split("/")


        For i = 0 To 2
            Dim data = datas(i).Split(",")
            pa(i) = New Point(data(0), data(1))
            p(i) = New Point(250 + data(0) * 25, 250 - data(1) * 25)
        Next
        g = PictureBox1.CreateGraphics

        Dim ch = {"A", "B", "C"}
        For i = 0 To 2
            Dim point As Point = p(i)
            Dim b As New SolidBrush(Color.FromArgb(CInt(Rnd() * 256), CInt(Rnd() * 256), CInt(Rnd() * 256)))
            g.FillEllipse(b, point.X, point.Y, 5, 5)
            g.DrawString(ch(i), Me.Font, Brushes.Black, New Point(point.X - 10, point.Y + 5))
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        g = PictureBox1.CreateGraphics

        Dim firstPoint = p(0)
        Dim last = False
        Dim i As Integer = 1
        Do Until last = True
            If firstPoint.Equals(p(2)) = True Then
                i = 0
                last = True
            End If
            Dim pen As New Pen(Color.FromArgb(CInt(Rnd() * 256), CInt(Rnd() * 256), CInt(Rnd() * 256)))
            g.DrawLine(pen, firstPoint, p(i))
            firstPoint = p(i)
            i += 1
        Loop
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        g = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        drawXY()
        ReDim p(2), pa(2)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim area As Decimal
        area = Math.Abs(pa(0).X * pa(1).Y + pa(1).X * pa(2).Y + pa(2).X * pa(0).Y - pa(1).X * pa(0).Y - pa(2).X * pa(1).Y - pa(0).X * pa(2).Y) / 2
        Label2.Text = area
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        '0 1 2 A B C

        '1 - 2
        Dim a As Decimal = Math.Sqrt((pa(1).X - pa(2).X) ^ 2 + (pa(1).Y - pa(2).Y) ^ 2)
        '0 - 2
        Dim b As Decimal = Math.Sqrt((pa(0).X - pa(2).X) ^ 2 + (pa(0).Y - pa(2).Y) ^ 2)
        '0 - 1
        Dim c As Decimal = Math.Sqrt((pa(0).X - pa(1).X) ^ 2 + (pa(0).Y - pa(1).Y) ^ 2)


        Label3.Text = getAngle(b, c, a)

    End Sub
    Private Function getAngle(ByVal x As Decimal, ByVal y As Decimal, ByVal z As Decimal)
        Dim k As Decimal = (x ^ 2 + y ^ 2 - z ^ 2) / (2 * x * y)
        Dim angle = Math.Round(Math.Acos(k) * 180 / Math.PI)
        Return angle
    End Function

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        '0 1 2 A B C

        '1 - 2
        Dim a As Decimal = Math.Sqrt((pa(1).X - pa(2).X) ^ 2 + (pa(1).Y - pa(2).Y) ^ 2)
        '0 - 2
        Dim b As Decimal = Math.Sqrt((pa(0).X - pa(2).X) ^ 2 + (pa(0).Y - pa(2).Y) ^ 2)
        '0 - 1
        Dim c As Decimal = Math.Sqrt((pa(0).X - pa(1).X) ^ 2 + (pa(0).Y - pa(1).Y) ^ 2)

        Label4.Text = getAngle(c, a, b)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        '0 1 2 A B C

        '1 - 2
        Dim a As Decimal = Math.Sqrt((pa(1).X - pa(2).X) ^ 2 + (pa(1).Y - pa(2).Y) ^ 2)
        '0 - 2
        Dim b As Decimal = Math.Sqrt((pa(0).X - pa(2).X) ^ 2 + (pa(0).Y - pa(2).Y) ^ 2)
        '0 - 1
        Dim c As Decimal = Math.Sqrt((pa(0).X - pa(1).X) ^ 2 + (pa(0).Y - pa(1).Y) ^ 2)


        Label5.Text = getAngle(a, b, c)
    End Sub
End Class
