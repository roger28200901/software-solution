Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = TextBox1.Text
        Dim str2 As String = ""
        Dim ops = {"+", "-", "*", "/", "(", ")"}
        '(1.5*3)*(1.369+3.631)
        Dim dd = str.Split({"+", "-", "*", "/", "(", ")"}, StringSplitOptions.RemoveEmptyEntries)
        Dim nd As Integer
        Dim insert As New Queue
        For i = 1 To Len(str)
            If ops.Contains(Mid(str, i, 1)) = True Then
                str2 &= String.Join("", insert.ToArray) & " " & Mid(str, i, 1) & " "
                insert.Clear()
            Else
                insert.Enqueue(Mid(str, i, 1))
            End If
        Next

        Dim datas = str2.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim s As New Stack
        s.Push(0)
        Dim ans As New Queue
        For i = 0 To UBound(datas)
            If IsNumeric(datas(i)) = True Then
                ans.Enqueue(datas(i))
                Continue For
            End If
            If datas(i) = "(" Then
                s.Push(datas(i))
                Continue For
            End If
            If opw(datas(i)) > opw(s.Peek) Then
                s.Push(datas(i))
            Else
                ans.Enqueue(s.Pop())
                s.Push(datas(i))
            End If

            If datas(i) = ")" Then
                s.Pop()
                Do Until s.Peek() = "("
                    ans.Enqueue(s.Pop())
                Loop
                s.Pop()
            End If
        Next
        Do Until s.Count = 1
            ans.Enqueue(s.Pop)
        Loop
        Dim st As New Stack
        For i = 0 To ans.Count - 1
            If IsNumeric(ans(i)) Then
                st.Push(ans(i))
            Else
                Dim v2 = st.Pop()
                Dim v1 = st.Pop()
                Dim op = ans(i)
                Dim v = cal(v1, v2, op)
                st.Push(v)
            End If
        Next
        Dim sum = st.Pop()
        Dim value = IIf(sum > 1, sum - CInt(sum), sum)
        Dim isLoopOrNot = checkIs(value)

        TextBox2.Text = IIf(isLoopOrNot = True, Math.Round(sum, 4), sum)
    End Sub
    Function checkIs(ByVal sum As String)
        '分母是2 的次方 或者 為5的次方 或者為
        Dim sum2 As Decimal
        Dim i As Integer = 0
        Do Until sum2 >= 1
            sum2 = sum * i
            i += 1
        Loop
        Return isLoop(sum)

    End Function
    Function isLoop(ByVal n As Integer) '確認是否為循環小數
        If n Mod 2 = 0 Then
            Return True
        ElseIf n Mod 5 = 0 Then
            Return True
        ElseIf n Mod 10 = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Function opw(ByVal s As String)
        Select Case s
            Case "+", "-"
                Return 1
            Case "*", "/"
                Return 2
            Case "("
                Return 0
            Case ")"
                Return 3
            Case Else
                Return -1
        End Select
    End Function
    Function cal(ByVal v1 As Double, ByVal v2 As Double, ByVal s As String)
        Select Case s
            Case "+"
                Return v1 + v2
            Case "-"
                Return v1 - v2
            Case "*"
                Return v1 * v2
            Case "/"
                Return v1 / v2
        End Select
    End Function
End Class
