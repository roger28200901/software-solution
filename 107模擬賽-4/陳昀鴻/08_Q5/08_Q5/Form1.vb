Public Class Form1
    Dim map(3, 3) As TextBox
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For i = 1 To 3
            For j = 1 To 3
                map(i, j).Visible = True
                map(i, j).BackColor = Color.Black
            Next
        Next
    End Sub
    Private Sub TextBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click, TextBox2.Click, TextBox3.Click, TextBox4.Click, TextBox5.Click, TextBox6.Click, TextBox7.Click, TextBox8.Click, TextBox9.Click
        Dim obj As TextBox = sender
        Dim name = sender.name

        Dim x As Integer
        Dim y As Integer

        For i = 1 To 3
            For j = 1 To 3
                If map(i, j).Name = name Then
                    x = i
                    y = j
                End If
            Next
        Next
        '自己
        If map(x, y).BackColor = Color.Black Then
            map(x, y).BackColor = Color.Yellow
        Else
            map(x, y).BackColor = Color.Black
        End If
        '右邊
        If x >= 1 And x < 3 Then
            If map(x + 1, y).BackColor = Color.Black Then
                map(x + 1, y).BackColor = Color.Yellow
            Else
                map(x + 1, y).BackColor = Color.Black
            End If
        End If
        '左邊
        If x <= 3 And x > 1 Then
            If map(x - 1, y).BackColor = Color.Black Then
                map(x - 1, y).BackColor = Color.Yellow
            Else
                map(x - 1, y).BackColor = Color.Black
            End If
        End If
        '上面
        If y <= 3 And y > 1 Then
            If map(x, y - 1).BackColor = Color.Black Then
                map(x, y - 1).BackColor = Color.Yellow
            Else
                map(x, y - 1).BackColor = Color.Black
            End If
        End If
        '下面
        If y >= 1 And y < 3 Then
            If map(x, y + 1).BackColor = Color.Black Then
                map(x, y + 1).BackColor = Color.Yellow
            Else
                map(x, y + 1).BackColor = Color.Black
            End If
        End If
        gameover()

    End Sub
    Private Sub gameover()
        Dim ans = 0
        For i = 1 To 3
            For j = 1 To 3
                If map(i, j).BackColor = Color.Yellow Then
                    ans += 1
                End If
            Next
        Next
        If ans = 9 Then
            MsgBox("遊戲結束")
            End
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 1 To 3
            For j = 1 To 3
                Dim k As Integer = (i - 1) * 3 + j
                map(j, i) = Me.Controls("TextBox" & k)
            Next
        Next
    End Sub
End Class
