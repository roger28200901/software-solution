Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim value1 As String = TextBox1.Text
        TextBox2.Text = ""
        Dim N As Integer = value1.Length

        If checkInput(value1) = False Then
            TextBox2.Text = "欲傳遞的訊息應是0或1"
            Exit Sub
        End If

        If N >= 11 Then
            TextBox2.Text = "欲傳遞的訊息長度不超過11位元"
            Exit Sub
        End If

        Dim k As Integer = 0
        Do Until 2 ^ k >= N + k + 1
            k += 1
        Loop

        Dim hammingCode As Integer = N + k

        Dim S As New Stack
        Dim Ans(hammingCode) As String
        Dim t As Integer = hammingCode
        For i = 1 To N
Start:
            Dim c = Mid(value1, i, 1)

            If checkIsTwo(t) = True Then
                t -= 1
                GoTo Start
            End If
            If c = "1" Then
                S.Push(t)
            End If
            Ans(t) = c
            t -= 1
        Next
        Dim m3 As Byte
        Do Until S.Count = 1
            Dim m1 As Byte = S.Pop
            Dim m2 As Byte = S.Pop
            m3 = m1 Xor m2
            S.Push(m3)
        Loop
        Dim insertStr = Convert.ToString(CInt(m3), 2).PadLeft(k, "0")
        Dim count = 0
        For p = hammingCode To 1 Step -1
            If checkIsTwo(p) Then
                Ans(p) = insertStr(count)
                count += 1
            End If
        Next

        For i = hammingCode To 1 Step -1
            TextBox2.Text &= Ans(i)
        Next

    End Sub
    Private Function checkIsTwo(ByVal i As Integer)
        Dim kk As Integer = 0
        Do Until 2 ^ kk >= i
            kk += 1
        Loop
        If 2 ^ kk = i Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function checkInput(ByVal s As String)
        For i = 0 To s.Length - 1
            Dim c = Mid(s, i + 1, 1)
            If (c <> "0" And c <> "1") = True Then
                Return False
            End If
        Next
        Return True
    End Function
End Class
