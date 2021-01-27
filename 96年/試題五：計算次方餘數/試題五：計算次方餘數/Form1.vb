Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim A = Val(TextBox1.Text)
        Dim B = Val(TextBox2.Text)
        Dim C = Val(TextBox3.Text)

        Dim S As Integer = 1
        Dim binary As String = decimalToBinary(B)
        'S = A^B mod C
        For i = 0 To binary.Length - 1
            S = S ^ 2 Mod C
            If binary(i) = "1" Then
                S = (A * S) Mod C
            End If
        Next

        TextBox4.Text = S.ToString
    End Sub
    Private Function decimalToBinary(ByVal b As Integer)

        '123456
        Dim ans As String = ""
        Do Until b \ 2 = 0
            Dim m = b Mod 2
            ans = m & ans
            b \= 2
        Loop

        Return b & ans
    End Function

End Class
