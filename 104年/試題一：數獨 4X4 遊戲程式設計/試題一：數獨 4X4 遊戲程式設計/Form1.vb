Public Class Form1
    Dim map(4, 4)
    Dim textBoxDatas(16)
    Dim t
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        readMap()
        showAns()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 16
            textBoxDatas(i) = Controls("TextBox" & i)
        Next
    End Sub
    Private Sub showAns()
        Dim a As Stack = New Stack
        '1
        For x = 1 To 4
            For y = 1 To 4
                Dim number As ArrayList = New ArrayList({"1", "2", "3", "4"})
                '排除掉不可能的數字
                If map(x, y) = "" Then
                    '垂直
                    For i = 1 To 4
                        If number.IndexOf(map(i, y)) <> -1 Then
                            Dim index = number.IndexOf(map(i, y))
                            number.RemoveAt(index)
                        End If
                    Next
                    '水平
                    For i = 1 To 4
                        If number.IndexOf(map(x, i)) <> -1 Then
                            Dim index = number.IndexOf(map(x, i))
                            number.RemoveAt(index)
                        End If
                    Next
                    '斜線
                    number = check(x, y, number)
                Else
                    Continue For
                End If
                Dim k = (x - 1) * 4 + y
                Controls("TextBox" & k).Text = String.Join(",", number.ToArray)
            Next
        Next

        'Do Until a.Count = 0
        '    Dim k = a.Pop
        '    Dim t = String.Join(",", number.ToArray)

        '    Controls("TextBox" & k).text = t
        'Loop

        'number = temp.Clone

    End Sub
    '斜線讀檔案
    Private Function check(ByVal x As Integer, ByVal y As Integer, ByVal number As ArrayList)
        '右下
        If x >= 1 And x <= 3 And y >= 1 And y <= 3 Then
            If number.IndexOf(map(x + 1, y + 1)) <> -1 Then
                Dim index = number.IndexOf(map(x + 1, y + 1))
                number.RemoveAt(index)
                number = check(x + 1, y + 1, number)
            End If
        ElseIf x >= 1 And x <= 3 And y >= 2 And y <= 4 Then
            If number.IndexOf(map(x + 1, y + -1)) <> -1 Then
                Dim index = number.IndexOf(map(x + 1, y + -1))
                number.RemoveAt(index)
                number = check(x + 1, y - 1, number)
            End If
        ElseIf x >= 2 And x <= 4 And y >= 2 And y <= 4 Then
            If number.IndexOf(map(x - 1, y - 1)) <> -1 Then
                Dim index = number.IndexOf(map(x - 1, y - 1))
                number.RemoveAt(index)
                number = check(x - 1, y - 1, number)
            End If
        ElseIf x >= 2 And x <= 4 And y >= 1 And y <= 3 Then
            If number.IndexOf(map(x - 1, y + 1)) <> -1 Then
                Dim index = number.IndexOf(map(x - 1, y + 1))
                number.RemoveAt(index)
                number = check(x - 1, y + 1, number)
            End If
        End If

        Return number

    End Function
    Private Sub readMap()
        For i = 1 To 4
            For j = 1 To 4
                Dim k = (i - 1) * 4 + j
                map(i, j) = Controls("TextBox" & k).Text
            Next
        Next
    End Sub

    ''1
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        textBoxDatas(t).text = "1"
    End Sub
    ''2
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        textBoxDatas(t).text = "2"
    End Sub
    ''3
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        textBoxDatas(t).text = "3"
    End Sub
    ''4
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        textBoxDatas(t).text = "4"
    End Sub
    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        t = 1
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        t = 2
    End Sub

    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles TextBox3.Click
        t = 3
    End Sub

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        t = 4
    End Sub

    Private Sub TextBox5_Click(sender As Object, e As EventArgs) Handles TextBox5.Click
        t = 5
    End Sub

    Private Sub TextBox6_Click(sender As Object, e As EventArgs) Handles TextBox6.Click
        t = 6
    End Sub

    Private Sub TextBox7_Click(sender As Object, e As EventArgs) Handles TextBox7.Click
        t = 7
    End Sub

    Private Sub TextBox8_Click(sender As Object, e As EventArgs) Handles TextBox8.Click
        t = 8
    End Sub

    Private Sub TextBox9_Click(sender As Object, e As EventArgs) Handles TextBox9.Click
        t = 9
    End Sub

    Private Sub TextBox10_Click(sender As Object, e As EventArgs) Handles TextBox10.Click
        t = 10
    End Sub

    Private Sub TextBox11_Click(sender As Object, e As EventArgs) Handles TextBox11.Click
        t = 11
    End Sub

    Private Sub TextBox12_Click(sender As Object, e As EventArgs) Handles TextBox12.Click
        t = 12
    End Sub

    Private Sub TextBox13_Click(sender As Object, e As EventArgs) Handles TextBox13.Click
        t = 13
    End Sub

    Private Sub TextBox14_Click(sender As Object, e As EventArgs) Handles TextBox14.Click
        t = 14
    End Sub

    Private Sub TextBox15_Click(sender As Object, e As EventArgs) Handles TextBox15.Click
        t = 15
    End Sub
    Private Sub TextBox16_Click(sender As Object, e As EventArgs) Handles TextBox16.Click
        t = 16
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim over As Boolean = answer()
        If over = True Then
            Label1.Text = "正確"
        Else
            Label1.Text = "錯誤"
        End If
    End Sub
    Private Function answer()
        readMap()

        '判斷每個點
        For x = 1 To 4
            For y = 1 To 4
                Dim horizontal As New ArrayList({"1", "2", "3", "4"})
                Dim vertical As New ArrayList({"1", "2", "3", "4"})

                For h = 1 To 4
                    If horizontal.indexof(map(x, h)) <> -1 Then
                        Dim index = horizontal.IndexOf(map(x, h))
                        horizontal.RemoveAt(index)
                    End If
                Next
                For v = 1 To 4
                    If vertical.IndexOf(map(v, y)) <> -1 Then
                        Dim index = vertical.IndexOf(map(v, y))
                        vertical.RemoveAt(index)
                    End If
                Next
                If vertical.Count <> 0 And horizontal.Count <> 0 Then
                    Return False
                End If
            Next
        Next


        Return True
    End Function
End Class
