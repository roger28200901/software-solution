Public Class Form1
    Dim str As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        str = TextBox1.Text
        Dim n, m As Integer
        For i = 1 To Len(str)
            If Mid(str, i, 1) = "(" Then
                n = i
                While Mid(str, i, 1) <> ")"
                    If Mid(str, i, 1) = "(" Then
                        n = i
                    End If
                    i += 1
                End While
                m = i
                str = Mid(str, 1, n - 1) & nm(Mid(str, n + 1, m - n - 1)) & Mid(str, m + 1)
                i = 0
            End If
        Next
        'If n <> 0 And m <> 0 Then
        '    str = Mid(str, 1, n - 1) & nm(Mid(str, n + 1, m - n - 1)) & Mid(str, m + 1)
        'End If
        TextBox2.Text = "=" & nm(str)


    End Sub

    Function nm(ByVal s As String)
        Dim ma1, am1 As Integer
        Dim ma(Len(s)) As Double
        Dim am(Len(s)) As String
        am1 = 0
        ma1 = 0
        Dim g As String
        For i = 1 To Len(s)
            Select Case Mid(s, i, 1)
                Case "+", "-", "*", "/"
                    am(am1 + 1) = Mid(s, i, 1)
                    am1 += 1
                    ma(ma1 + 1) = g
                    ma1 += 1
                    g = ""
                Case Else
                    g &= Mid(s, i, 1)
                    '     ma1 += 1
            End Select
        Next
        ma(ma1 + 1) = g
        ma1 += 1

        For i = 1 To am1
            Dim l, j As Integer
            If am(i) = "*" Or am(i) = "/" Then
                l = i
                While ma(l) = 0 And l >= 1
                    l -= 1
                End While
                j = i + 1
                While ma(j) = 0 And j <= am1
                    j += 1
                End While
                ma(l) = add(ma(l), ma(j), am(i))
                am(i) = -1
                ma(j) = 0
            End If
        Next
        For i = 1 To am1
            Dim l, j As Integer
            If am(i) = "-" Or am(i) = "+" Then
                l = i
                While ma(l) = 0 And l >= 1
                    l -= 1
                End While
                j = i + 1
                While ma(j) = 0 And j <= am1
                    j += 1
                End While
                ma(l) = add(ma(l), ma(j), am(i))
                am(i) = -1
                ma(j) = 0
            End If
        Next
        For i = 1 To ma1
            If ma(i) <> 0 Then
                Return Math.Round(ma(i) * 10000) / 10000
            End If

        Next
        Return 0

    End Function

    Function add(ByVal x As Double, ByVal y As Double, ByVal s As String)
        Select Case s
            Case "*"
                Return x * y
            Case "/"
                Return x / y
            Case "+"
                Return x + y
            Case "-"
                Return x - y
        End Select
        Return 0
    End Function
End Class
