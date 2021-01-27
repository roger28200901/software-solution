Public Class Form1


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '中序轉後序
        '中序轉前序
        TextBox3.Text = postfix(TextBox2.Text)
        TextBox1.Text = prefix(TextBox2.Text)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '後序轉中序先寫
        '中序轉前序
        TextBox2.Text = postfixreverse(TextBox3.Text)
        TextBox1.Text = prefix(TextBox2.Text)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '前序轉中序先寫(把後序轉中序 相反就會得到)
        '中序再轉後序
        TextBox2.Text = prefixreverse(TextBox1.Text)
        TextBox3.Text = postfix(TextBox2.Text)
    End Sub
    Private Function postfix(ByVal s As String)
        Dim st As New Stack
        st.Push(0)
        Dim ans As String = ""

        For i = 0 To Len(s) - 1

            If s(i) = "+" Or s(i) = "-" Or s(i) = "*" Or s(i) = "/" Then
A:
                Dim op1, op2 : op1 = 0 : op2 = 0
                If s(i) = "+" Or s(i) = "-" Then
                    op1 = 1
                ElseIf s(i) = "*" Or s(i) = "/" Then
                    op1 = 2
                End If
                If st.Peek().ToString = "+" Or st.Peek().ToString = "-" Then
                    op2 = 1
                ElseIf st.Peek().ToString = "*" Or st.Peek().ToString = "/" Then
                    op2 = 2
                End If
                If op2 >= op1 Then

                    ans = ans & st.Pop()
                    GoTo A
                End If
                st.Push(s(i))
            Else
                ans &= s(i)
            End If
        Next
        Do Until st.Count = 1
            ans &= st.Pop()
        Loop
        Return ans
    End Function
    Private Function prefix(ByVal s As String)
        '複製後序的做法
        '但是將字串先相反
        '最後回傳再相反1次
        s = StrReverse(s)
        Dim st As New Stack
        st.Push(0)
        Dim ans As String = ""

        For i = 0 To Len(s) - 1

            If s(i) = "+" Or s(i) = "-" Or s(i) = "*" Or s(i) = "/" Then
A:
                Dim op1, op2 : op1 = 0 : op2 = 0
                If s(i) = "+" Or s(i) = "-" Then
                    op1 = 1
                ElseIf s(i) = "*" Or s(i) = "/" Then
                    op1 = 2
                End If
                If st.Peek().ToString = "+" Or st.Peek().ToString = "-" Then
                    op2 = 1
                ElseIf st.Peek().ToString = "*" Or st.Peek().ToString = "/" Then
                    op2 = 2
                End If
                If op2 >= op1 Then

                    ans = ans & st.Pop()
                    GoTo A
                End If
                st.Push(s(i))
            Else
                ans &= s(i)
            End If
        Next
        Do Until st.Count = 1
            ans &= st.Pop()
        Loop
        Return StrReverse(ans)
    End Function
    Private Function postfixreverse(ByVal s As String)
        Dim st As New Stack
        st.Push(0)
        For i = 0 To Len(s) - 1
            If s(i) = "+" Or s(i) = "-" Or s(i) = "*" Or s(i) = "/" Then
                Dim temp = st.Pop()
                Dim temp2 = st.Pop()
                st.Push(temp & s(i) & temp2)
            Else
                st.Push(s(i))
            End If
        Next
        Return StrReverse(st.Pop())
    End Function
    Private Function prefixreverse(ByVal s As String)
        s = StrReverse(s)
        Dim st As New Stack
        st.Push(0)
        For i = 0 To Len(s) - 1
            If s(i) = "+" Or s(i) = "-" Or s(i) = "*" Or s(i) = "/" Then
                Dim temp = st.Pop()
                Dim temp2 = st.Pop()
                st.Push(temp & s(i) & temp2)
            Else
                st.Push(s(i))
            End If
        Next
        Return st.Pop

    End Function

End Class
