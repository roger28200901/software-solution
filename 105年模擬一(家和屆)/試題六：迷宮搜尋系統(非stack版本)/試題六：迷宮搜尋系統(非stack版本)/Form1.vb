Public Class Form1
    Dim map(9, 9)
    Dim obmap(9, 9)
    Dim S As Point : Dim T As Point
    Dim pathAnswer As New Queue(Of Queue(Of Point))
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '-1黑色
        '0白色 -2終點
        '-3最短
        initMap()
        readMap()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        initMap()

        Dim r As Integer = Rnd() * 31 + 20
        Label2.Text = "Obstacles(20~50)：" & r
        '直到找到這個
        Dim i, x, y As Integer
        i = 0

        Do While (i < r)
            x = Rnd() * 8 + 1
            y = Rnd() * 8 + 1
            If map(x, y) = 0 Then
                i += 1
                map(x, y) = -1 '障礙
            End If
        Loop

        readMap()
        obmap = map.Clone

    End Sub
    Private Sub initMap()
        For i = 1 To 9
            For j = 1 To 9
                Dim k As Integer = (i - 1) * 9 + j
                Dim text As New TextBox
                With text
                    .Location = New Point(110 + (j - 1) * 30, 50 + (i - 1) * 30)
                    .Size = New Size(30, 30)
                    .Multiline = True
                    .Name = "TextBox" & k
                    .Visible = True
                    .TextAlign = HorizontalAlignment.Center
                    .Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold)
                End With
                Me.Controls.Add(text)
                map(i, j) = 0
            Next
        Next
        S = New Point(0, 0)
        T = New Point(0, 0)
    End Sub
    Private Sub readMap()
        Dim k As Integer
        For i = 1 To 9
            For j = 1 To 9
                k = (i - 1) * 9 + j
                Controls("TextBox" & k).Text = ""
                If map(i, j) = -2 Or map(i, j) = 0 Then
                    Controls("TextBox" & k).BackColor = Color.White
                ElseIf map(i, j) = -1 Then
                    Controls("TextBox" & k).BackColor = Color.Black
                ElseIf map(i, j) = -3 Then
                    Controls("TextBox" & k).BackColor = Color.Gray
                End If
            Next
        Next
        k = (S.X - 1) * 9 + S.Y
        If k >= 1 And k <= 81 Then
            Controls("TextBox" & k).Text = "S"
        End If
        k = (T.X - 1) * 9 + T.Y
        If k >= 1 And k <= 81 Then
            Controls("TextBox" & k).Text = "T"
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        map = obmap.Clone

        S = getRandPoint()
        map(S.X, S.Y) = -2
        T = getRandPoint()
        map(T.X, T.Y) = 2

        readMap()
    End Sub
    Private Function getRandPoint()
        Dim find As Boolean = False
        Dim x, y As Integer

        Do While find = False
            x = Rnd() * 8 + 1
            y = Rnd() * 8 + 1
            If map(x, y) = 0 Then
                Return New Point(x, y)
            End If
        Loop

        Return New Point(0, 0)

    End Function
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        findPath()
        readMap()

    End Sub
    Private Sub findPath()
        Dim w As Integer = 1
        Dim x, y As Integer
        map(S.X, S.Y) = w 'S為1
        map(T.X, T.Y) = 0 'T為0
        Do Until map(T.X, T.Y) > 0 Or w > 81
            For x = 1 To 9
                For y = 1 To 9
                    If map(x, y) <> w Then '如果目前x,y座標 不等於 目前的w 那麼 繼續迴圈 否則 跳脫迴圈
                        Continue For
                    End If
                    If x > 1 Then If map(x - 1, y) = 0 Then map(x - 1, y) = w + 1 '
                    If x < 9 Then If map(x + 1, y) = 0 Then map(x + 1, y) = w + 1
                    If y > 1 Then If map(x, y - 1) = 0 Then map(x, y - 1) = w + 1
                    If y < 9 Then If map(x, y + 1) = 0 Then map(x, y + 1) = w + 1
                Next
            Next
            w += 1
        Loop
        x = T.X
        y = T.Y
        If map(T.X, T.Y) = 0 Then
            Label6.Text = "no"
            Return
        End If

        Do Until w < 1
            If (S.X = x) And (S.Y = y) Then
                map(x, y) = -3
                Label6.Text = "yes"
                Return
            End If
            If x > 1 Then
                If map(x - 1, y) = w - 1 Then
                    map(x, y) = -3
                    x -= 1
                    w -= 1
                End If
            End If
            If y > 1 Then
                If map(x, y - 1) = w - 1 Then
                    map(x, y) = -3
                    y -= 1
                    w -= 1
                End If
            End If

            If x < 9 Then
                If map(x + 1, y) = w - 1 Then
                    map(x, y) = -3
                    x += 1
                    w -= 1
                End If
            End If



            If y < 9 Then
                If map(x, y + 1) = w - 1 Then
                    map(x, y) = -3
                    y += 1
                    w -= 1
                End If
            End If

        Loop
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        End
    End Sub
End Class
