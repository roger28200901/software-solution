Public Class Form1
    Dim p As New List(Of Point)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n = Val(TextBox1.Text)
        For i = 1 To n
            Dim inx = InputBox("輸入x座標", "請輸入x" & i & "的x座標", i)
            Dim iny = InputBox("輸入y座標", "請輸入y" & i & "的x座標", i)
            p.Add(New Point(inx, iny))
        Next
        Dim m As Double = 0
        Dim sumX = p.Sum(Function(item) item.X)
        Dim averageX = p.Average(Function(item) item.X)
        Dim averageY = p.Average(Function(item) item.Y)
        m = (multplicationXY() - sumX * averageY) / (powSum() - sumX * averageX)
        Dim b As Double = 0
        b = averageY - m * averageX
        TextBox2.Text = "線性回歸(Linear Regression)" & vbNewLine
        TextBox2.Text &= "利用最小平方方法讓一條直線來逼近一些點" & vbNewLine
        TextBox2.Text &= "請輸入資料總點數：" & n & vbNewLine
        For i = 0 To n - 1
            TextBox2.Text &= "請輸入每一點資料的x,y座標[x y]： [" & p(i).X & " " & p(i).Y & "]" & vbNewLine
        Next
        TextBox2.Text &= "最小平方直線的迴歸係數：" & vbNewLine
        TextBox2.Text &= "斜率(m) = " & Format(m, "0.000") & vbNewLine
        TextBox2.Text &= "截距(b) = " & Format(b, "0.000") & vbNewLine
        TextBox2.Text &= "總資料點數 =" & n & vbNewLine

        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        Dim originDot As Point = New Point(20, 240)
        g.DrawLine(Pens.Black, New Point(20, 0), New Point(260, 0))
        g.DrawLine(Pens.Black, New Point(20, 0), New Point(20, 240))
        g.DrawLine(Pens.Black, New Point(20, 240), New Point(260, 240))
        g.DrawLine(Pens.Black, New Point(260, 0), New Point(260, 240))
        For i = 1 To 8
            g.DrawString(i, Me.Font, Brushes.Black, New Point(originDot.X + (i - 1) * 34, originDot.Y))
        Next
        For j = 1 To 8
            g.DrawString(j, Me.Font, Brushes.Black, New Point(originDot.X - 10, originDot.Y - (j - 1) * 34 - 3))
        Next
        Dim pen As New Pen(Color.Black)
        pen.DashStyle = Drawing2D.DashStyle.Dash
        For x = 1 To 6
            g.DrawLine(pen, New Point(originDot.X, originDot.Y - x * 34), New Point(260, originDot.Y - x * 34))
        Next
        For y = 1 To 6
            g.DrawLine(pen, New Point(originDot.X + y * 34, originDot.Y), New Point(originDot.X + y * 34, 0))
        Next
        '畫點
        For d = 0 To n - 1
            g.DrawEllipse(Pens.Blue, originDot.X + (p(d).X - 1) * 34 - 3, originDot.Y - (p(d).Y - 1) * 34 - 3, 6, 6)
        Next
        '畫線

        'y = mx + b
        Dim lines As New List(Of Point)
        For y = 0 To 240
            Dim x As Double = (y - b) / m
            lines.Add(New Point(originDot.X + x, originDot.Y - y))
        Next
        g.DrawLines(Pens.Red, lines.ToArray)

    End Sub
    Function multplicationXY()
        Dim value As Double = 0
        For i = 0 To p.Count - 1
            value += p(i).X * p(i).Y
        Next
        Return value
    End Function
    Function powSum()
        Dim value As Double = 0
        For i = 0 To p.Count - 1
            value += (p(i).X ^ 2)
        Next
        Return value
    End Function
End Class
