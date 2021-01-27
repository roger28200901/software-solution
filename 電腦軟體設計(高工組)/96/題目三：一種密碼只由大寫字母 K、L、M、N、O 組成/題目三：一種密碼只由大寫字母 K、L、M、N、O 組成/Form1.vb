Public Class Form1
    Dim ansQ As New List(Of String)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If check1(TextBox1.Text) = True Then
            TextBox2.Text = TextBox1.Text & "是正確密碼文字"
        Else
            TextBox2.Text = TextBox1.Text & "不是正確密碼文字"
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If check2(TextBox3.Text) = -1 Then
            TextBox4.Text = TextBox3.Text & "是正確密碼"
        Else
            TextBox4.Text = TextBox3.Text & "無法滿足第" & check2(TextBox3.Text) & "條件"
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If check1(TextBox5.Text) = True Then
            TextBox6.Text = TextBox5.Text
        Else
            TextBox6.Text = check3(check2(TextBox5.Text), TextBox5.Text)
        End If
        If check1(TextBox7.Text) = True Then
            TextBox8.Text = TextBox7.Text
        Else
            TextBox8.Text = check3(check2(TextBox7.Text), TextBox7.Text)
        End If
    End Sub
    Private Function check1(ByVal txt As String)
        'rule1
        If txt.Length < 3 Then
            Return False
        End If
        'rule2
        If txt.Substring(0, 1) = "K" Then
            Return False
        End If
        'rule3
        If txt.Contains("L") = True Then
            Dim countL = 0
            For n = 0 To Len(txt) - 1
                If txt(n) = "L" Then
                    countL += 1
                End If
            Next
            If countL < 2 Then
                Return False
            End If
        End If

        'rule4
        If Mid(txt, txt.Length, 1) = "M" Or Mid(txt, txt.Length - 1, 1) = "M" Then
            Return False
        End If
        'rule5
        If txt.Contains("K") = True Then
            If txt.Contains("N") = False Then
                Return False
            End If
        End If
        'rule6
        If txt.Contains("L") = False Then
            If Mid(txt, txt.Length, 1) = "O" Then
                Return False
            End If
        End If
        Return True
    End Function
    Private Function check2(ByVal txt As String)
        'rule1
        If txt.Length < 3 Then
            Return 1
        End If
        'rule2
        If txt.Substring(0, 1) = "K" Then
            Return 2
        End If
        'rule3
        If txt.Contains("L") = True Then
            Dim countL = 0
            For n = 0 To Len(txt) - 1
                If txt(n) = "L" Then
                    countL += 1
                End If
            Next
            If countL < 2 Then
                Return 3
            End If
        End If
        'rule4
        If Mid(txt, txt.Length, 1) = "M" Or Mid(txt, txt.Length - 1, 1) = "M" Then
            Return 4
        End If
        'rule5
        If txt.Contains("K") = True Then
            If txt.Contains("N") = False Then
                Return 5
            End If
        End If
        'rule6
        If txt.Contains("L") = False Then
            If Mid(txt, txt.Length, 1) = "O" Then
                Return 6
            End If
        End If
        Return -1
    End Function
    Private Function check3(ByVal n As Integer, ByVal txt As String)
        Dim ans As String = txt
        Dim RandStr = {"K", "L", "M", "N", "O"}
        Do Until check1(ans) = True
            If n = 1 Then
                Do Until ans.Count >= 3
                    Dim r As Integer = Int(Rnd() * 6)
                    ans &= RandStr(r)
                Loop
            ElseIf n = 2 Then
                ans = ans.Substring(1) & ans.Substring(0, 1)
            ElseIf n = 3 Then
                If ans.Contains("X") = False Then
                    Return txt & "不是正確密碼"
                Else
                    ans = ans.Replace("X", "L")
                End If

            ElseIf n = 4 Then
                ans = ans.Substring(ans.Length - 2, 2) & ans.Substring(0, ans.Length - 2)
            ElseIf n = 5 Then
                If ans.Contains("X") = False Then
                    Return txt & "不是正確密碼"
                Else
                    ans = ans.Replace("X", "N")
                End If

            ElseIf n = 6 Then
                ans = Mid(ans, ans.Length, 1) & ans.Substring(0, ans.Length - 1)
            End If
            n = check2(ans)
        Loop

        Return ans
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim str = "LMNO"
        ansQ.Clear()

        Call abillity(str, "")
        TextBox9.Text = ansQ.Count
        TextBox10.Text = String.Join("、", ansQ)
    End Sub
    Function abillity(ByVal a As String, ByVal b As String)
        If b.Count = 3 Then
            If check1(b) = True Then
                ansQ.Add(b)
            End If
            Exit Function
        End If
        For i = 1 To 4
            Call abillity(a, b & Mid(a, i, 1))
        Next
    End Function
End Class
