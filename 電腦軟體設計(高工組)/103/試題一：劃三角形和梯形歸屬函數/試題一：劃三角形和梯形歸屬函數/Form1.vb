Public Class Form1
    Dim a
    Dim m
    Dim b
    Dim UpX
    Dim u()

    Dim a1
    Dim b1
    Dim c1
    Dim d1
    Dim UpX2
    Dim u2()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        UpX = InputBox("輸入變數x之上限", "三角形歸屬圖", 10)
        a = InputBox("請分別輸入[a m b]", "三角形歸屬圖", 3)
        m = InputBox("請分別輸入[a m b]", "三角形歸屬圖", 6)
        b = InputBox("請分別輸入[a m b]", "三角形歸屬圖", 8)

        UpX2 = InputBox("輸入變數x之上限", "梯形歸屬圖", 20)
        a1 = InputBox("請分別輸入[a b c d]", "梯形歸屬圖", 1)
        b1 = InputBox("請分別輸入[a b c d]", "梯形歸屬圖", 7)
        c1 = InputBox("請分別輸入[a b c d]", "梯形歸屬圖", 14)
        d1 = InputBox("請分別輸入[a b c d]", "梯形歸屬圖", 20)
        ReDim u(UpX)
        ReDim u2(UpX2)
    End Sub
    Private Sub tri(ByVal u As Array, ByVal a As Integer, ByVal m As Integer, ByVal b As Integer)
        For x = 0 To UBound(u)
            Dim v
            If x <= a Then
                v = 0
            ElseIf x > a And x <= m Then
                v = (x - a) / (m - a)
            ElseIf x > m And x < b Then
                v = (b - x) / (b - m)
            ElseIf x >= b Then
                v = 0
            End If
            u(x) = v
        Next

        Dim g As Graphics = PictureBox1.CreateGraphics()


        'x軸 '原點10 240
        g.DrawLine(Pens.Black, 10, 240, 240, 240)
        'y軸
        g.DrawLine(Pens.Black, 10, 240, 10, 10)
        Dim count = 0

        For i = 1 To 0 Step CDec(-0.2)
            Dim delta = (240 - 10) / 5
            If i <> 0 Then g.DrawString(i, Me.Font, Brushes.Black, New Point(10, 10 + count * delta))
            count += 1
        Next

        Dim p(UBound(u)) As Point
        For i = 0 To UBound(p)
            p(i) = New Point(10 + i * 230 / UBound(u), 240 - u(i) * 5 * 46)
        Next

        For i = 1 To UBound(u)
            Dim delta = (240 - 10) / UBound(u)
            Dim y = u(i - 1)
            g.DrawLines(Pens.Purple, p)
            If a = i Then
                g.DrawString("a", Me.Font, Brushes.Black, New Point(p(i).X, 245))
            ElseIf m = i Then
                g.DrawString("m", Me.Font, Brushes.Black, New Point(p(i).X, 245))
            ElseIf b = i Then
                g.DrawString("b", Me.Font, Brushes.Black, New Point(p(i).X, 245))
            End If
            'g.DrawLine(Pens.Purple, New Point(10 + (i - 1) * delta, 240), New Point(10 + (i - 1) * delta, 240 - y * 5 * 46))
        Next


    End Sub
    Private Sub T(ByVal u As Array)
        For x = 0 To UBound(u)
            Dim v
            If x < a1 Or x > d1 Then
                v = 0
            ElseIf x >= a1 And x <= b1 Then
                v = (x - a1) / (b1 - a1)
            ElseIf x >= b1 And x <= c1 Then
                v = 1
            ElseIf x >= c1 And x <= d1 Then
                v = 1 - ((x - c1) / (d1 - c1))
            End If
            u(x) = v
        Next

        Dim g As Graphics = PictureBox2.CreateGraphics()


        'x軸 '原點10 240
        g.DrawLine(Pens.Black, 10, 240, 240, 240)
        'y軸
        g.DrawLine(Pens.Black, 10, 240, 10, 10)
        Dim count = 0

        For i = 1 To 0 Step CDec(-0.2)
            Dim delta = (240 - 10) / 5
            If i <> 0 Then g.DrawString(i, Me.Font, Brushes.Black, New Point(10, 10 + count * delta))
            count += 1
        Next

        Dim p(UBound(u)) As Point
        For i = 0 To UBound(p)
            p(i) = New Point(10 + i * 230 / UBound(u), 240 - u(i) * 5 * 46)
        Next

        For i = 1 To UBound(u)
            Dim delta = (240 - 10) / UBound(u)
            Dim y = u(i - 1)
            g.DrawLines(Pens.Purple, p)

            If a1 = i Then
                g.DrawString("a", Me.Font, Brushes.Black, New Point(p(i).X, 245))
            ElseIf b1 = i Then
                g.DrawString("b", Me.Font, Brushes.Black, New Point(p(i).X, 245))
            ElseIf c1 = i Then
                g.DrawString("c", Me.Font, Brushes.Black, New Point(p(i).X, 245))
            ElseIf d1 = i Then
                g.DrawString("d", Me.Font, Brushes.Black, New Point(p(i).X, 245))
            End If
            'g.DrawLine(Pens.Purple, New Point(10 + (i - 1) * delta, 240), New Point(10 + (i - 1) * delta, 240 - y * 5 * 46))
        Next


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Call tri(u, a, m, b)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call T(u2)
    End Sub
End Class
