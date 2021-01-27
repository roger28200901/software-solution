Public Class Form1
    Dim x As Decimal = 0
    Dim y As Decimal = 0
    Dim rx As Integer = 0
    Dim ry As Integer = 0
    Dim r As Decimal = 0
    Dim theata As Decimal = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim datas = TextBox1.Text.Split({"(", ",", ")"}, StringSplitOptions.RemoveEmptyEntries)
        Dim p As New Point(datas(0), datas(1))

        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim delta = 250 / 25 '一格10
        '中心 125 125
        g.Clear(Color.White)
        g.DrawLine(Pens.Black, New Point(0, 125), New Point(250, 125))
        g.DrawLine(Pens.Black, New Point(125, 0), New Point(125, 250))

        '把x y 變成極座標
        Call check1(datas(0), datas(1))
        '把極座標 變成 x y
        Call check2(datas(0), datas(1))
        If Math.Round(Math.Abs(CInt(r))) = Math.Round(Math.Abs(y)) Then
            '極座標表示Blue
            TextBox2.Text = "輸出為X=" & rx & "，Y=" & ry
            g.DrawLine(Pens.Blue, New Point(125, 125), New Point(125 + rx * delta, 125 - ry * delta))
        Else

            '直角坐標表示Red

            TextBox2.Text = "輸出為r=" & r & "，theata=" & Format(theata, "0.0000")
            g.DrawLine(Pens.Red, New Point(125, 125), New Point(125 + x * delta, 125 - y * delta))
        End If


    End Sub
    Private Sub check1(ByVal x1 As Decimal, ByVal y1 As Decimal)
        r = (x1 ^ 2 + y1 ^ 2) ^ (1 / 2)
        theata = Math.Atan2(y1, x1)
        theata = theata * 180 / Math.PI

        x = x1
        y = y1

    End Sub
    Private Sub check2(ByVal r As Integer, ByVal t As Decimal)

        rx = r * Math.Cos(t / 180 * Math.PI)
        ry = r * Math.Sin(t / 180 * Math.PI)

    End Sub
End Class
