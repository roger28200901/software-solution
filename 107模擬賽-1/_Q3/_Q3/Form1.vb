Public Class Form1
    Dim map(,)
    Dim qmaps(,) As Boolean
    Dim tempMap As New ArrayList
    Dim diag1(), diag2(), Xrow(), Ycol() As Boolean
    Dim tx, ty As New Stack
    Dim ansmap(,) As Boolean
    Dim g As Graphics
    Dim q As New Queue
    Dim ans As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n As Integer = Val(TextBox1.Text)
        If n < 4 Or n > 10 Then
            MsgBox("皇后數範圍4<=n<=10")
            Exit Sub
        End If
        g = PictureBox1.CreateGraphics
        ReDim map(n, n)
        ReDim qmaps(n, n)
        ReDim diag1(2 * n) : ReDim diag2(2 * n)
        ReDim Ycol(n) : ReDim Xrow(n)
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
        For i = 1 To n
            N_queen(n, i, 1)
        Next
        checkMapIsRepeat()
        MsgBox(ans)

    End Sub
    Function checkMapIsRepeat()


    End Function
    Private Function N_queen(ByVal n As Integer, ByVal x As Integer, ByVal y As Integer)
        If x > n Then
            Return False
        End If
        If checkQ(n, x, y) = False Then
            '如果當前x沒有到最後
            '那麼搜尋x+1可不可以
            '如果 x = n 回到 上一行 且 下一列 的搜尋
            If x <> n Then
                N_queen(n, x + 1, y)
            Else
                removequeen(n, tx.Peek, ty.Peek)
                If tx.Peek = 4 And ty.Peek <> 1 Then
                    tx.Pop()
                    ty.Pop()
                    removequeen(n, tx.Peek, ty.Peek)
                    N_queen(n, tx.Pop + 1, ty.Pop)
                Else
                    N_queen(n, tx.Pop + 1, ty.Pop)
                End If

            End If
        Else
            putqueen(n, x, y)
            tx.Push(x)
            ty.Push(y)
            If y = n Then
                ans += 1
                ansmap = qmaps.Clone()
                saveMap(ansmap)
                initMap(n)
            Else
                N_queen(n, 1, y + 1)
            End If

        End If

    End Function
    Function saveMap(ByVal map As Boolean(,))
        Dim temp = ""
        For i = 1 To UBound(map)
            For j = 1 To UBound(map)
                If j <> UBound(map) Then temp &= map(i, j) & ","
            Next
            temp &= "/"
        Next
        tempMap.Add(temp)
    End Function
    Function removequeen(ByVal n As Integer, ByVal x As Integer, ByVal y As Integer)
        qmaps(x, y) = False
        Dim k1 = x + y - 1
        Dim k2 = x - y + n
        diag1(k1) = False
        diag2(k2) = False

        Xrow(y) = False
        Ycol(x) = False
    End Function
    Function putqueen(ByVal n As Integer, ByVal x As Integer, ByVal y As Integer)
        qmaps(x, y) = True
        Dim k1 = x + y - 1
        Dim k2 = x - y + n
        diag1(k1) = True
        diag2(k2) = True

        Xrow(y) = True
        Ycol(x) = True

    End Function
    Function checkQ(ByVal n As Integer, ByVal x As Integer, ByVal y As Integer)
        '如果看行列中有皇后 就回傳不行
        'x

        If Xrow(y) = True Then
            Return False
        End If

        'y

        If Ycol(x) = True Then
            Return False
        End If


        Dim k1 = x + y - 1
        Dim k2 = x - y + n

        '左上-右下
        If diag1(k1) = True Then
            Return False
        End If
        '左下-右上
        If diag2(k2) = True Then
            Return False
        End If

        Return True
    End Function
    Private Sub initMap(ByVal n As Integer)

        g.Clear(Color.White)
        tx.Clear()
        ty.Clear()

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

        For x = 1 To n
            For y = 1 To n
                qmaps(x, y) = False

            Next
        Next

        For i = 1 To n
            Xrow(i) = False
            Ycol(i) = False
        Next

        Dim t = 2 * n - 1
        For j = 1 To t
            diag1(j) = False
            diag2(j) = False
        Next

    End Sub
End Class
