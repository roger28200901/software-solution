Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim datas = TextBox1.Text.Split({","}, StringSplitOptions.RemoveEmptyEntries).ToList
        datas.Sort()
        Dim n = datas.Count
        Dim Median = 0 : Dim Max = 0 : Dim Min = 0 : Dim MaxRange = 0 : Dim IQR = 0
        Dim Q3 = 0 : Dim Q1 = 0 : Dim MinRange = 0 : Dim Outlier As New List(Of Integer)
        If n Mod 2 = 0 Then '偶數
            Median = (Val(datas(n \ 2)) + Val(datas(n \ 2 - 1))) / 2
        Else
            Median = Val(datas(Math.Floor(n / 2)))
        End If

        Dim l(100) '樣本
        For p = 1 To 100
            Dim i = p / 100 * n
            If i <> Fix(i) Then
                i = Math.Ceiling(i)
            Else
                i = (i + i + 1) / 2
            End If
            l(p) = i
        Next
        Q1 = CInt(datas(l(25) - 1))
        Q3 = CInt(datas(l(75) - 1))
        IQR = Q3 - Q1
        MinRange = Q1 - IQR
        MaxRange = Q3 + IQR
        Max = datas.Max
        Min = datas.Min
        For i = 0 To datas.Count - 1
            If datas(i) < MinRange Or datas(i) > MaxRange Then
                Outlier.Add(datas(i))
            End If
        Next

        'show value
        TextBox2.Text = Max
        TextBox3.Text = MaxRange
        TextBox4.Text = IQR
        TextBox5.Text = Q3
        TextBox6.Text = Median
        TextBox7.Text = Q1
        TextBox8.Text = MinRange
        TextBox9.Text = String.Join(" ", Outlier.ToArray)
        'draw
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        Dim delta = 260 / (Max - Min)
        For y = Max To Min Step -2
            g.DrawLine(Pens.Black, New Point(0, 20 + (Max - y) * delta), New Point(10, 20 + (Max - y) * delta))
            g.DrawString(y, New Font("標楷體", 10), Brushes.Black, New Point(10, 15 + (Max - y) * delta))
        Next

        '最大上限和下限畫出黑色實線(寬度 10)
        g.DrawLine(Pens.Black, New Point(PictureBox1.Width / 2 - 5, 20 + (Max - MaxRange) * delta), New Point(PictureBox1.Width / 2 + 5, 20 + (Max - MaxRange) * delta))
        g.DrawLine(Pens.Black, New Point(PictureBox1.Width / 2 - 5, 20 + (Max - MinRange) * delta), New Point(PictureBox1.Width / 2 + 5, 20 + (Max - MinRange) * delta))
        'IQR 畫黑色虛線
        Dim pen As New Pen(Color.Black)
        pen.DashStyle = Drawing2D.DashStyle.Dash
        g.DrawLine(pen, New Point(PictureBox1.Width / 2, 20 + (Max - MaxRange) * delta), New Point(PictureBox1.Width / 2, 20 + (Max - MinRange) * delta))
        'Q1 和 Q3 之間的矩形(寬度 20)，用藍色實線畫
        g.FillRectangle(Brushes.White, CInt(PictureBox1.Width / 2) - 10, 20 + CInt((Max - Q3) * delta), 20, CInt((Q3 - Q1) * delta))
        g.DrawRectangle(Pens.Blue, CInt(PictureBox1.Width / 2) - 10, 20 + CInt((Max - Q3) * delta), 20, CInt((Q3 - Q1) * delta))
        'Median 畫紅色實線(寬度 20)
        g.DrawLine(Pens.Red, New Point(PictureBox1.Width / 2 - 10, 20 + (Max - Median) * delta), New Point(PictureBox1.Width / 2 + 10, 20 + (Max - Median) * delta))
        '畫+
        g.DrawString("A", New Font("標楷體", 12), Brushes.Red, New Point(PictureBox1.Width / 2 - 6, 20 + (Max - Outlier.Min) * delta))
    End Sub
End Class
