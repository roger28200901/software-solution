Public Class Form1
    Dim map(,)

    Dim col
    Dim diag1(), diag2() As Boolean
    Dim board(,) As String
    Dim list As New List(Of Array)
    Dim g As Graphics
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Queen As Integer = Val(TextBox1.Text)
        If Queen < 4 Or Queen > 10 Then
            MsgBox("皇后數範圍4<=n<=10")
            Exit Sub
        End If
        g = PictureBox1.CreateGraphics
        ReDim map(Queen, Queen)
        ReDim board(Queen, Queen)
        ReDim col(Queen - 1)
        ReDim diag1(2 * Queen - 1) : ReDim diag2(2 * Queen - 1)

        Dim gray As Boolean
        For y = 1 To Queen
            If y Mod 2 = 0 Then
                gray = False
            Else
                gray = True
            End If

            For x = 1 To Queen
                If gray = True Then
                    map(x, y) = 2
                    gray = False
                Else
                    gray = True
                    map(x, y) = 1
                End If
            Next
        Next

        initMap(Queen)
        Dim l = solveNqueens(Queen - 1)

    End Sub
    Public Function solveNqueens(ByVal n As Integer)


        nqueens(n, 0)
        Return list
    End Function
    Function nqueens(ByVal n As Integer, ByVal y As Integer)
        If y = n Then
            Debug.Print("end")
            list.Add(board)
            Return False
        End If
        For x = 0 To n
            If available(x, y, n) = False Then
                Continue For
            Else
                updateBoard(x, y, n, True)
                nqueens(n, y + 1)
                updateBoard(x, y, n, False)
            End If
        Next
    End Function
    Function available(ByVal x As Integer, ByVal y As Integer, ByVal n As Integer)
        If col(x) = False And diag1(x + y) = False And diag2(x - y + n - 1) = False Then
            Return True
        Else
            Return False
        End If
    End Function
    Function updateBoard(ByVal x As Integer, ByVal y As Integer, ByVal n As Integer, ByVal is_input As Boolean)
        col(x) = is_input '1不能走 0能走
        diag1(x + y) = is_input
        diag2(x - y + n - 1) = is_input
        board(x, y) = IIf(is_input, "Q", ".")
    End Function
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

        For i = 0 To n - 1
            col(i) = False
        Next
        Dim k = 2 * n - 1

        For j = 0 To k
            diag1(j) = False
            diag2(j) = False
        Next

        For x = 0 To n - 1
            For y = 0 To n - 1
                board(x, y) = "."
            Next
        Next
    End Sub
End Class
