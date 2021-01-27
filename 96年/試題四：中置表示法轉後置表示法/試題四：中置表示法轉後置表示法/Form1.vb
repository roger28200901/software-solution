Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim inputStr As String = TextBox1.Text
        Dim input = inputStr.Split(" ")
        Dim ans As String
        Dim s As New Stack
        s.Push(0)
        For i = 0 To UBound(input)
            If IsNumeric(input(i)) Then
                ans &= input(i) & " "
                Continue For
            Else
                If s.Count = 1 Then
                    s.Push(input(i))
                    Continue For
                End If

                While s.Contains("(")
                    s.Push(input(i))
                    If s.Peek() = ")" Then
                        s.Pop()
                        Dim op = s.Pop
                        s.Pop()
                        ans &= op & " "
                    End If
                    Continue For
                End While
                '*-/
                '只能大蓋小
                '*(大)
                If power(input(i)) > power(s.Peek) Then
                    s.Push((input(i)))
                Else
                    Do Until s.Count = 1
                        Dim op = s.Pop()
                        ans &= op & " "
                    Loop
                    s.Push(input(i))
                End If

            End If
        Next
        Do Until s.Count = 1
            ans &= s.Pop & " "
        Loop
        TextBox2.Text = ans
    End Sub
    Private Function power(ByVal op As String)
        Dim number = 0
        If op = "+" Or op = "-" Then
            number = 1
        End If
        If op = "*" Or op = "/" Then
            number = 2
        End If
        If op = "(" Then
            number = 3
        End If
        If op = ")" Then
            number = 4
        End If
        Return number
    End Function
End Class
