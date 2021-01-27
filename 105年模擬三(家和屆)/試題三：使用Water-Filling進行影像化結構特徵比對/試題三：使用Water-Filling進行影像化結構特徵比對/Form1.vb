Public Class Form1
    Dim map(,) As Boolean
    Dim wmap(,) As Integer
    Dim visit(,) As Boolean
    Dim max As Integer = 1
    Dim border As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input = TextBox1.Text
        Dim line = Split(Trim(input), vbCrLf)
        Dim n As Integer = line(0)
        ReDim map(n, n), visit(n, n), wmap(n, n)
        For y = 1 To n
            For x = 1 To n
                Dim l = line(y)
                Dim c = Mid(l, x, 1)
                map(x, y) = IIf(c = "1", True, False)
            Next
        Next
        border = n
        Dim w = 1
        Dim answerQueue As New Queue
        For y = 1 To n

            For x = 1 To n
                max = 1
                If map(x, y) = True And visit(x, y) = False Then
                    If wmap(x, y) <> 0 Then
                        w = wmap(x, y)
                    End If
                    Dim q As New Queue
                    q.Enqueue(New Point(x, y))
                    wmap(x, y) = w
                    waterFilling(q)
                    answerQueue.Enqueue(max)
                End If
            Next
        Next
        TextBox2.Text = answerQueue.Count & vbNewLine & String.Join(vbNewLine, answerQueue.ToArray)
    End Sub
    Private Function waterFilling(ByVal temp As Queue)

        Dim q As New Queue
        q = temp.Clone
        Do Until q.Count = 0
            Dim p As Point = q.Dequeue()
            Dim w As Integer = wmap(p.X, p.Y)
            If w > max Then
                max = w
            End If

            Dim find As Boolean = False
            If p.X < border Then
                If map(p.X + 1, p.Y) = True And visit(p.X + 1, p.Y) = False Then
                    q.Enqueue(New Point(p.X + 1, p.Y))
                    wmap(p.X + 1, p.Y) = w + 1
                    find = True
                End If
            End If
            If p.X > 1 Then
                If map(p.X - 1, p.Y) = True And visit(p.X - 1, p.Y) = False Then
                    q.Enqueue(New Point(p.X - 1, p.Y))
                    wmap(p.X - 1, p.Y) = w + 1
                    find = True
                End If
            End If
            If p.Y < border Then
                If map(p.X, p.Y + 1) = True And visit(p.X, p.Y + 1) = False Then
                    q.Enqueue(New Point(p.X, p.Y + 1))
                    wmap(p.X, p.Y + 1) = w + 1
                    find = True
                End If
            End If
            If p.Y > 1 Then
                If map(p.X, p.Y - 1) = True And visit(p.X, p.Y - 1) = False Then
                    q.Enqueue(New Point(p.X, p.Y - 1))
                    wmap(p.X, p.Y - 1) = w + 1
                    find = True
                End If
            End If

            visit(p.X, p.Y) = True
            If find = True Then
                waterFilling(q)
            Else
                waterFilling(q)
            End If
        Loop
    End Function
End Class
