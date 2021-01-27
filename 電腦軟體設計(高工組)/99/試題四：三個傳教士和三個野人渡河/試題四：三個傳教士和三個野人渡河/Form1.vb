Public Class Form1
    Dim ansPath As New Queue
    Dim visted As New Stack
    Private Sub Button1_Click(sender As Object, ev As EventArgs) Handles Button1.Click
        Dim datas = TextBox1.Text.Split(",")
        'A: 表甲岸野人的人數;  B: 表甲岸傳教士的人數 C: 表甲岸的船數目; D: 表乙岸野人的人數 E: 表乙岸傳教士的人數;  F: 表乙岸的船數目
        Dim A = datas(0)
        Dim B = datas(1)
        Dim C = datas(2)
        Dim D = datas(3)
        Dim E = datas(4)
        Dim F = datas(5)

        DFS(A, B, C, D, E, F)
        ansPath.Enqueue("3,3,1,0,0,0")
        For i = ansPath.Count - 1 To 0 Step -1
            TextBox2.Text &= "(" & ansPath(i) & ")" & vbNewLine
        Next
    End Sub
    Function DFS(ByVal A As Integer, ByVal B As Integer, ByVal C As Integer, ByVal D As Integer, ByVal E As Integer, ByVal F As Integer)
        If A < 0 Or B < 0 Or D < 0 Or E < 0 Then '非法
            Return False
        End If
        If (A > B And B <> 0) Or (D > E And E <> 0) Then '如果野人比僧侶多
            Return False
        ElseIf D = 3 And E = 3 And F = 1 Then '結束
            Return True
        End If

        If visted.Contains(A & "," & B & "," & C & "," & D & "," & E & "," & F) = True Then '如果有這個狀態離開
            Return False
        End If

        visted.Push(A & "," & B & "," & C & "," & D & "," & E & "," & F)
        If C = 1 Then '船在左邊->右邊開
            If DFS(A - 2, B, 0, D + 2, E, 1) Then
                ansPath.Enqueue(A - 2 & "," & B & "," & 0 & "," & D + 2 & "," & E & "," & 1)
                Debug.Print("兩個野人過去")
                Return True
            ElseIf DFS(A - 1, B - 1, 0, D + 1, E + 1, 1) Then
                ansPath.Enqueue(A - 1 & "," & B - 1 & "," & 0 & "," & D + 1 & "," & E + 1 & "," & 1)
                Debug.Print("一個野人過去、一個僧侶過去")
                Return True
            ElseIf DFS(A, B - 2, 0, D, E + 2, 1) Then
                ansPath.Enqueue(A & "," & B - 2 & "," & 0 & "," & D & "," & E + 2 & "," & 1)
                Debug.Print("兩個僧侶過去")
                Return True
            ElseIf DFS(A - 1, B, 0, D + 1, E, 1) Then
                ansPath.Enqueue(A - 1 & "," & B & "," & 0 & "," & D + 1 & "," & E & "," & 1)
                Debug.Print("一個野人過去")
                Return True
            ElseIf DFS(A, B - 1, 0, D, E + 1, 1) Then
                ansPath.Enqueue(A & "," & B - 1 & "," & 0 & "," & D & "," & E + 1 & "," & 1)
                Debug.Print("一個野人過去、一個僧侶過去")
                Return True
            End If
        Else
            If DFS(A + 2, B, 1, D - 2, E, 0) Then
                ansPath.Enqueue(A + 2 & "," & B & "," & 1 & "," & D - 2 & "," & E & "," & 0)
                Debug.Print("兩個野人回來")
                Return True
            ElseIf DFS(A + 1, B + 1, 1, D - 1, E - 1, 0) Then
                ansPath.Enqueue(A + 1 & "," & B + 1 & "," & 1 & "," & D - 1 & "," & E - 1 & "," & 0)
                Debug.Print("一個野人回來、一個僧侶回來")
                Return True
            ElseIf DFS(A, B + 2, 1, D, E - 2, 0) Then
                ansPath.Enqueue(A & "," & B + 2 & "," & 1 & "," & D & "," & E - 2 & "," & 0)
                Debug.Print("兩個僧侶回來")
                Return True
            ElseIf DFS(A + 1, B, 1, D - 1, E, 0) Then
                ansPath.Enqueue(A + 1 & "," & B & "," & 1 & "," & D - 1 & "," & E & "," & 0)
                Debug.Print("一個野人回來")
                Return True
            ElseIf DFS(A, B + 1, 1, D, E - 1, 0) Then
                ansPath.Enqueue(A & "," & B + 1 & "," & 1 & "," & D & "," & E - 1 & "," & 0)
                Debug.Print("一個僧侶回來")
                Return True
            End If
        End If

        Return False
    End Function
End Class
