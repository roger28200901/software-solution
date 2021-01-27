Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = infixToPrefix(TextBox2.Text)
        TextBox3.Text = infixToPostpix(TextBox2.Text)

    End Sub
    Function infixToPrefix(ByVal txt As String)
        Dim ans As String = ""
        Dim ops = {"+", "-", "*", "/"}
        Dim s As New Stack
        s.Push(-1)
        txt = StrReverse(txt)
        For i = 0 To Len(txt) - 1
            If ops.Contains(txt(i)) = True Then
                If opW(txt(i)) > opW(s.Peek) Then
                    s.Push(txt(i))
                Else
                    ans &= s.Pop()
                    s.Push(txt(i))
                End If
            Else
                ans &= txt(i)
            End If
        Next
        Do Until s.Count = 1
            ans &= s.Pop
        Loop
        Return StrReverse(ans)

    End Function
    Function infixToPostpix(ByVal txt As String)
        Dim ans As String = ""
        Dim ops = {"+", "-", "*", "/"}
        Dim s As New Stack
        s.Push(-1)
        For i = 0 To Len(txt) - 1
            If ops.Contains(txt(i)) = True Then
                If opW(txt(i)) > opW(s.Peek) Then
                    s.Push(txt(i))
                Else
                    Do Until opW(txt(i)) > opW(s.Peek)
                        ans &= s.Pop()
                    Loop
                    s.Push(txt(i))
                End If
            Else
                ans &= txt(i)
            End If
        Next
        Do Until s.Count = 1
            ans &= s.Pop
        Loop
        Return ans

    End Function
    Function opW(ByVal s As String)
        Select Case s
            Case "+", "-"
                Return 1
            Case "*", "/"
                Return 2
        End Select
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = prefixToInfix(TextBox1.Text)
        TextBox3.Text = infixToPostpix(TextBox2.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox2.Text = postfixToInfix(TextBox3.Text)
        TextBox1.Text = infixToPrefix(TextBox2.Text)
    End Sub
    Function postfixToInfix(ByVal str As String)
        '後續
        'ab*+cd*+
        Dim ops = {"+", "-", "*", "/"}
        Dim ans As String = ""
        Dim s As New Stack
        s.Push(-1)
        For i = 0 To Len(str) - 1
            If ops.Contains(str(i)) = True Then
                Dim v1 = s.Pop()
                Dim v2 = s.Pop()
                s.Push(v1 & str(i) & v2)
            Else
                s.Push(str(i))
            End If
        Next
        ans = s.Pop
        Return StrReverse(ans)
    End Function
    Function prefixToInfix(ByVal str As String)
        str = StrReverse(str)
        Dim ops = {"+", "-", "*", "/"}
        Dim ans As String = ""
        Dim s As New Stack
        s.Push(-1)
        For i = 0 To Len(str) - 1
            If ops.Contains(str(i)) = True Then
                Dim v1 = s.Pop()
                Dim v2 = s.Pop()
                s.Push(v1 & str(i) & v2)
            Else
                s.Push(str(i))
            End If
        Next
        ans = s.Pop
        Return ans
    End Function
End Class
