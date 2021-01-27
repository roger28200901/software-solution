Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p As New List(Of tryPoint)
        p.Add(New tryPoint(TextBox1.Text, TextBox2.Text))
        p.Add(New tryPoint(TextBox3.Text, TextBox4.Text))
        p.Add(New tryPoint(TextBox5.Text, TextBox6.Text))

        Dim length As New List(Of Double)
        '座標1到座標2
        Dim l1 As Double = Math.Sqrt((p(0).X - p(1).X) ^ 2 + (p(0).Y - p(1).Y) ^ 2)
        Dim l2 As Double = Math.Sqrt((p(1).X - p(2).X) ^ 2 + (p(1).Y - p(2).Y) ^ 2)
        Dim l3 As Double = Math.Sqrt((p(2).X - p(0).X) ^ 2 + (p(2).Y - p(0).Y) ^ 2)
        length.Add(l1) : length.Add(l2) : length.Add(l3)
        Label7.Text = "座標1~座標2 邊長=" & Math.Round(length(0), 3)
        Label8.Text = "座標2~座標1 邊長=" & Math.Round(length(1), 3)
        Label9.Text = "座標3~座標1 邊長=" & Math.Round(length(2), 3)
        For i = 0 To 2
            length(i) = Math.Round(length(i), 3)
        Next

        '有相同座標
        '座標1 = 座標2
        If TextBox1.Text = TextBox3.Text And TextBox2.Text = TextBox4.Text Then
            Label10.Text = "有相同座標"
            Exit Sub
        End If
        '座標2 = 座標3
        If TextBox3.Text = TextBox5.Text And TextBox4.Text = TextBox6.Text Then
            Label10.Text = "有相同座標"
            Exit Sub
        End If
        '座標3 = 座標1
        If TextBox5.Text = TextBox1.Text And TextBox6.Text = TextBox2.Text Then
            Label10.Text = "有相同座標"
            Exit Sub
        End If

        '三點為一直線 判斷斜率
        Dim m1 As Double = (TextBox1.Text - TextBox3.Text) / (TextBox2.Text - TextBox4.Text)
        Dim m2 As Double = (TextBox3.Text - TextBox5.Text) / (TextBox4.Text - TextBox6.Text)
        Dim m3 As Double = (TextBox5.Text - TextBox1.Text) / (TextBox6.Text - TextBox2.Text)
        If m1 = m2 And m2 = m3 And m1 = m3 Then
            Label10.Text = "此為三點一直線"
            Exit Sub
        End If
        '判斷三角形
        length.Sort() '小排到大
        '兩編之和大於最長邊
        If length(0) + length(1) > length(2) Then
            '正三角形
            If length(0) = length(1) And length(1) = length(2) And length(2) = length(0) Then
                Label10.Text = "此為正三角形"
                Exit Sub
            End If
            If length(0) = length(1) Then
                Label10.Text = "此為等腰直角三角形"
                Exit Sub
            End If
            If length(1) = length(2) Then
                Label10.Text = "此為等腰三角形"
                Exit Sub
            End If
            If length(0) ^ 2 + length(1) ^ 2 = length(2) ^ 2 Then
                Label10.Text = "此為直角三角形"
                Exit Sub
            End If
            '兩邊平方和 小於 最長邊平方 鈍角三角形
            If length(0) ^ 2 + length(1) ^ 2 < length(2) ^ 2 Then
                Label10.Text = "此為鈍角三角形"
                Exit Sub
            End If
            '兩邊平方和 大於 最長邊平方 銳角三角形
            If length(0) ^ 2 + length(1) ^ 2 > length(2) ^ 2 Then
                Label10.Text = "此為銳角三角形"
                Exit Sub
            End If
        End If
    End Sub

End Class
Class tryPoint
    Public x As Double
    Public y As Double
    Public Sub New(ByVal xx As Double, ByVal yy As Double)
        Me.x = xx
        Me.y = yy
    End Sub
End Class