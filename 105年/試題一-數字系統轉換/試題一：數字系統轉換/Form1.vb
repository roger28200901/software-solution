Public Class Form1
    Dim indexC As Char() = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H"}
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim d = Val(TextBox1.Text)
        Dim b = Val(TextBox2.Text)
        Dim ans = ""
        TextBox3.Text = ""
        If (TextBox1.Text = "" Or Not IsNumeric(TextBox1.Text) Or Not IsNumeric(TextBox2.Text)) Then
            MsgBox("錯誤")
            Return
        End If
        Dim s As New Stack
        s = Process(d, b)
        For i = 0 To s.Count - 1
            ans &= indexC(s(i)) & " "
        Next
        TextBox3.Text = ans
    End Sub
    Private Function Process(ByVal d As Integer, ByVal b As Integer)
        Dim s As New Stack
        While d <> 0
            If d < 0 AndAlso b < 0 Then
                Dim m = solve(d, b)
                s.Push(m)
                d = solve2(d, b)
            Else
                Dim m = d Mod b
                s.Push(m)
                d \= b
            End If
        End While
        Return s
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
    Function solve(ByVal d As Integer, ByVal b As Integer)

        Dim r As Integer
        For i = 1 To 99999
            r = b * i
            If r <= d Then
                Exit For
            End If
        Next
        '回傳餘數
        Return d - r
    End Function
    Function solve2(ByVal d As Integer, ByVal b As Integer)

        Dim r As Integer
        For i = 1 To 99999
            r = b * i
            If r <= d Then
                Return i
            End If
        Next
        '回傳餘數

    End Function

End Class
