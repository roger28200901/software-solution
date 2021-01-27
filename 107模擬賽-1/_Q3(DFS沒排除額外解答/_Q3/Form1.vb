Public Class Form1
    Dim map(,)
    Dim g As Graphics
    Dim ansQ As New Queue
    Dim ans As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ansQ.Clear()
        ComboBox1.Items.Clear()

        Dim n As Integer = Val(TextBox1.Text)
        If n < 4 Or n > 10 Then
            MsgBox("皇后數範圍4<=n<=10")
            Exit Sub
        End If
        g = PictureBox1.CreateGraphics
        ReDim map(n, n)
        Dim gray As Boolean
        For y = 1 To n
            If y Mod 2 = 0 Then
                gray = False
            Else
                gray = True
            End If

            For x = 1 To n
                If gray = True Then
                    map(x, y) = 2
                    gray = False
                Else
                    gray = True
                    map(x, y) = 1
                End If
            Next
        Next

        initMap(n)
        For x = 1 To n
            For y = 1 To n
                N_queen(n, x, y, New Queue)
            Next
        Next
        ans = ansQ.Count
        For i = 1 To ansQ.Count
            ComboBox1.Items.Add(i)
        Next
        Label1.Text = "共有" & ans & "種解答"

    End Sub

    Private Function N_queen(ByVal n As Integer, ByVal x As Integer, ByVal y As Integer, ByVal q As Queue)
        If x < 1 Or y < 1 Or x > n Or y > n Then
            Return False
        End If
        Dim map(n, n) As Boolean
        For Each item As Point In q
            map(item.X, item.Y) = True
        Next
        If checkQ(n, x, y, map) = False Then
            Return False
        End If
        q.Enqueue(New Point(x, y))
        If q.Count = n Then
            'If checkHasOtherAns(q) = False Then ansQ.Enqueue(q)
            ansQ.Enqueue(q)
            Return True
            Exit Function
        End If





        If y < n Then
            For i = 1 To n
                Dim tempQ = q.Clone
                N_queen(n, i, y + 1, tempQ)
            Next
        End If


    End Function
    Function checkHasOtherAns(ByVal q As Queue)
        Dim Amap(q.Count, q.Count) As Boolean


        Dim n As Integer = q.Count

        For Each item In ansQ
            Dim count = 0
            For Each p As Point In item
                'If q.Contains(New Point(p.Y, p.X)) = True Then
                '    count += 1
                'End If
                Amap(p.X, p.Y) = True '答案的地圖
            Next
            'If count = n Then '先看對稱有沒有
            '    Return True
            'End If

            '對稱x1
            Dim tempQ As New Queue
            For Each p As Point In item
                Dim np As New Point(p.X, n + 1 - p.Y)
                tempQ.Enqueue(np)
            Next
            count = 0
            For Each p As Point In item
                If tempQ.Contains(p) = True Then
                    count += 1
                End If
            Next
            If count = n Then
                Return True
            End If
            ''''''''''''''''''''''''''''''' 對稱x2
            Dim tempQQ As New Queue
            For Each p As Point In tempQ
                Dim np As New Point(n + 1 - p.X, p.Y)
                tempQQ.Enqueue(np)
            Next
            count = 0
            For Each p As Point In item
                If tempQQ.Contains(p) = True Then
                    count += 1
                End If
            Next
            If count = n Then
                Return True
            End If
            '''''''''''''''''''''''

            Dim Bmap(q.Count, q.Count) As Boolean '現在的地圖
            For Each p As Point In q
                Bmap(p.X, p.Y) = True
            Next


            '旋轉
            For t = 0 To 4
                If t <> 0 Then
                    For i = 1 To n
                        For j = 1 To n
                            Dim temp = Bmap(i, j)
                            Bmap(i, j) = Bmap(j, i)
                            Bmap(j, i) = temp
                        Next
                    Next
                End If
                count = 0
                For x = 1 To n
                    For y = 1 To n
                        If Amap(x, y) = True And Bmap(x, y) = True Then
                            count += 1
                        End If
                    Next
                Next
                If count = n Then
                    Return True
                End If
            Next
        Next

        Return False
    End Function
    Function checkQ(ByVal n As Integer, ByVal x As Integer, ByVal y As Integer, ByVal map(,) As Boolean)
        '如果看行列中有皇后 就回傳不行
        'x
        For i = 1 To n
            If map(i, y) = True Then
                Return False
            End If
        Next

        'y
        For i = 1 To n
            If map(x, i) = True Then
                Return False
            End If
        Next



        Dim c As Integer = 0
        Do While x + c <= n And y + c <= n
            If map(x + c, y + c) = True Then
                Return False
            End If
            c += 1
        Loop
        c = 0
        Do While x - c >= 1 And y - c >= 1
            If map(x - c, y - c) = True Then
                Return False
            End If
            c += 1
        Loop
        c = 0
        Do While x + c <= n And y - c >= 1
            If map(x + c, y - c) = True Then
                Return False
            End If
            c += 1
        Loop
        c = 0
        Do While x - c >= 1 And y + c <= n
            If map(x - c, y + c) = True Then
                Return False
            End If
            c += 1
        Loop



        Return True
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim v As Integer = CInt(ComboBox1.SelectedIndex)
        Dim q = ansQ(v)
        initMap(q.count)
        Dim n = q.count
        Dim w As Integer = Val(500 \ n)
        Dim h As Integer = Val(500 \ n)
        Dim delta As Integer = 500 \ n

        For Each p As Point In q
            g.FillEllipse(Brushes.Black, (p.X - 1) * w, (p.Y - 1) * h, delta, delta)
        Next

    End Sub

    Private Sub initMap(ByVal n As Integer)

        g.Clear(Color.White)


        Dim white = Brushes.White
        Dim gray = Brushes.Gray
        Dim w As Integer = Val(500 \ n)
        Dim h As Integer = Val(500 \ n)
        Dim delta As Integer = 500 \ n
        For y = 1 To n
            For x = 1 To n
                If map(x, y) = 1 Then
                    g.FillRectangle(white, 0 + (x - 1) * delta, 0 + (y - 1) * delta, w, h)
                Else
                    g.FillRectangle(gray, 0 + (x - 1) * delta, 0 + (y - 1) * delta, w, h)
                End If
            Next
        Next


    End Sub
End Class
