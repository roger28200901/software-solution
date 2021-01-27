Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim N As Integer = Int(TextBox1.Text)
        If N > 1000 Or N < 1 Then
            MsgBox("輸入範圍不正確")
            Exit Sub
        End If

        For i = 1 To N
            If checkIsPrimeNumber(i) = True Then
                ListBox1.Items.Add(i)
            End If
        Next
    End Sub
    Function checkIsPrimeNumber(ByVal n As Integer)
        Dim counter = 1
        Dim number = 0
        Do Until counter > n
            If n Mod counter = 0 Then
                number += 1
            End If
            counter += 1
        Loop
        If number = 2 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim v1 As Integer = Int(TextBox2.Text)
        Dim v2 As Integer = Int(TextBox3.Text)
        TextBox4.Text = "   " & v1 & "  " & v2 & vbNewLine & "-----------------------------------------" & vbNewLine
        Dim counter = 0
        Dim leftNumber = ListBox1.Items(counter)
        Do Until leftNumber > v1 Or leftNumber > v2
            If v1 Mod leftNumber = 0 And v2 Mod leftNumber = 0 Then
                v1 \= leftNumber
                v2 \= leftNumber
                TextBox4.Text &= leftNumber & "   " & v1 & "  " & v2 & vbNewLine & "-----------------------------------------" & vbNewLine
            Else
                counter += 1
                leftNumber = ListBox1.Items(counter)
            End If
        Loop

    End Sub
End Class
