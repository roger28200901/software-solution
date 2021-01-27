Public Class Form1
    Dim map(7, 7) As Integer
    Dim q As New Queue
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txt = My.Computer.FileSystem.ReadAllText(TextBox1.Text)

        Dim datas = txt.Replace(vbCrLf, "/").Split("/")
        For i = 0 To UBound(datas)
            For j = 0 To datas(i).Length - 1
                map(i, j) = Val(datas(i)(j))
            Next
        Next

        Dim ansQ As New Queue
        Dim p As New Point(0, 0)
        ansQ.Enqueue(p)
        solve(0, 0, ansQ)
        Debug.Print("123")
        Dim collections As System.Collections.Queue
        Dim find As Boolean = False
        For Each item In q
            If find = True Then Exit For
            For Each item2 In item
                If item2.x = 7 And item2.y = 7 Then
                    collections = item
                    find = True
                End If
            Next
        Next
        For i = 0 To collections.Count - 1
            TextBox2.Text &= "(" & collections(i).x & "," & collections(i).y & ")"
        Next

    End Sub
    Public Sub solve(ByVal x As Integer, ByVal y As Integer, ByVal q2 As Queue)
        Dim noPath As Boolean = False
        Dim yesPath As Boolean = False

        Dim tempQ As New Queue
        tempQ = q2.Clone

        Do Until yesPath = True Or noPath = True
            '北
            If x <> 0 Then
                If map(x - 1, y) = 0 Then
                    map(x - 1, y) = 2
                    Dim p As New Point(x - 1, y)
                    q2.Enqueue(p)


                    solve(x - 1, y, q2)
                    noPath = False
                Else
                    noPath = True
                End If
            End If
            '東北
            If x <> 0 And y <> 7 Then
                If map(x - 1, y + 1) = 0 Then
                    map(x - 1, y + 1) = 2
                    Dim p As New Point(x - 1, y + 1)
                    q2.Enqueue(p)


                    solve(x - 1, y + 1, q2)
                    noPath = False
                Else
                    noPath = True
                End If
            End If
            '東
            If y <> 7 Then
                If map(x, y + 1) = 0 Then
                    map(x, y + 1) = 2
                    Dim p As New Point(x, y + 1)
                    q2.Enqueue(p)


                    solve(x, y + 1, q2)
                    noPath = False
                Else
                    noPath = True
                End If
            End If
            '東南
            If x <> 7 And y <> 7 Then
                If map(x + 1, y + 1) = 0 Then
                    map(x + 1, y + 1) = 2
                    Dim p As New Point(x + 1, y + 1)
                    q2.Enqueue(p)


                    solve(x + 1, y + 1, q2)
                    noPath = False
                Else
                    noPath = True
                End If
            End If
            '南
            If x <> 7 Then
                If map(x + 1, y) = 0 Then
                    map(x + 1, y) = 2
                    Dim p As New Point(x + 1, y)
                    q2.Enqueue(p)


                    solve(x + 1, y, q2)
                    noPath = False
                Else
                    noPath = True
                End If
            End If
            '西南
            If x <> 7 And y <> 0 Then
                If map(x + 1, y - 1) = 0 Then
                    map(x + 1, y - 1) = 2
                    Dim p As New Point(x + 1, y - 1)
                    q2.Enqueue(p)


                    solve(x + 1, y - 1, q2)
                    noPath = False
                Else
                    noPath = True
                End If
            End If
            '西
            If y <> 0 Then
                If map(x, y - 1) = 0 Then
                    map(x, y - 1) = 2
                    Dim p As New Point(x, y - 1)
                    q2.Enqueue(p)


                    solve(x, y - 1, q2)
                    noPath = False
                Else
                    noPath = True
                End If
            End If
            '西北
            If x <> 0 And y <> 0 Then
                If map(x - 1, y - 1) = 0 Then
                    map(x - 1, y - 1) = 2
                    Dim p As New Point(x - 1, y - 1)
                    q2.Enqueue(p)


                    solve(x - 1, x - 1, q2)
                    noPath = False
                Else
                    noPath = True
                End If
            End If
            If noPath = True Then
                q.Enqueue(tempQ)
                yesPath = True
            End If
        Loop


    End Sub
End Class
