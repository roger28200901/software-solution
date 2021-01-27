Public Class Form1
    Dim p As New List(Of Point)
    Dim Tm, Tc

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        '30 30
        g.DrawLine(Pens.Black, New Point(30, PictureBox1.Height - 30), New Point(30, 0))
        g.DrawLine(Pens.Black, New Point(30, PictureBox1.Height - 30), New Point(PictureBox1.Width, PictureBox1.Height - 30))
        Dim deltaX = (PictureBox1.Width - 30) / (65 / 5)
        For x = 0 To 65 Step 5
            If x <> 65 Then
                g.DrawString(x, New Font("標楷體", 8), Brushes.Black, New Point(30 + (x / 5) * deltaX, PictureBox1.Height - 30))
            End If
        Next
        Dim deltaY = (PictureBox1.Height - 30) / (65 / 5)
        For y = 0 To 65 Step 5
            If y <> 65 Then
                g.DrawString(y.ToString.PadLeft(2, " "), New Font("標楷體", 8), Brushes.Black, New Point(10, -10 + (PictureBox1.Height - 30) - (y / 5 * deltaY)))
            End If
        Next
        p.Clear()

        p.Add(New Point(Val(TextBox1.Text), Val(TextBox4.Text)))
        p.Add(New Point(Val(TextBox2.Text), Val(TextBox5.Text)))
        p.Add(New Point(Val(TextBox3.Text), Val(TextBox6.Text)))
        Dim everyX = (PictureBox1.Width - 30) / 65
        Dim everyY = (PictureBox1.Height - 30) / 65
        For i = 0 To p.Count - 1
            g.DrawEllipse(Pens.Red, CSng(30 + Val(p(i).X) * everyX - 4), CSng(270 - Val(p(i).Y) * everyY - 4), 4, 4)
        Next

    End Sub
    Function _M(ByVal p As List(Of Point))
        Dim value = 0
        For i = 1 To 3
            value += Val(p(i - 1).X) * Val(p(i - 1).Y)
        Next
        value *= 3
        Dim x = 0
        For i = 1 To 3
            x += Val(p(i - 1).X)
        Next
        Dim y = 0
        For j = 1 To 3
            y += Val(p(j - 1).Y)
        Next
        Dim x2 = 0
        For i = 1 To 3
            x2 += Val(p(i - 1).X) ^ 2
        Next
        x2 *= 3
        Dim x3 = 0
        For i = 1 To 3
            x3 += Val(p(i - 1).X)
        Next
        x3 = x3 ^ 2
        Dim m
        m = (value - x * y) / (x2 - x3)
        Return m
    End Function
    Function _C(ByVal p As List(Of Point))
        Dim c
        c = (p.Sum(Function(item) item.X ^ 2) * p.Sum(Function(item) item.Y) - p.Sum(Function(item) item.X) * p.Sum(Function(item) item.X * item.Y)) / (3 * (p.Sum(Function(item) item.X ^ 2)) - (p.Sum(Function(item) item.X)) ^ 2)
        Return c
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim m, c
        Dim sum = 0
        m = _M(p)
        c = _C(p)
        Label10.Text = "m=" & m
        Label11.Text = "c=" & c
        Tm = m
        Tc = c
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim m = Tm
        Dim c = Tc
        Dim everyX = (PictureBox1.Width - 30) / 65
        Dim everyY = (PictureBox1.Height - 30) / 65
        Dim p2 As New List(Of Point)
        For y = 0 To 65
            Dim x As Decimal = (y - c) / m
            p2.Add(New Point(30 + x * everyX, 270 - y * everyY))
        Next
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.DrawLines(Pens.Blue, p2.ToArray)

    End Sub
End Class
