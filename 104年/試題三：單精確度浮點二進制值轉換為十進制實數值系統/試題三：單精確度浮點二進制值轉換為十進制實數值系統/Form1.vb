Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Randomize()

        Dim v1 As String
        Dim v2 As String
        Dim v3 As String
        Dim r As Integer = Rnd() * 1
        v1 = r
        For i = 1 To 8
            r = Rnd() * 1
            v2 &= r
        Next
        For i = 1 To 23
            r = Rnd() * 1
            v3 &= r
        Next
        TextBox2.Text = v1
        TextBox3.Text = v2
        TextBox4.Text = v3

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim exponent = TextBox3.Text
        Dim d As Decimal = Convert.ToInt32(exponent, 2)
        Dim Epow As Integer = d - 127
        Dim sign = IIf(Val(TextBox2.Text) = 1, -1, 1)
        Dim s As String = TextBox4.Text

        s = binaryToDecimal(s)

        Dim r = (1 + Val(s)) * Math.Pow(2, Epow) * sign
        TextBox1.Text = r
    End Sub
    Function binaryToDecimal(ByVal s As String)
        Dim count = 1
        Dim m = 1 / 2
        Dim sum As Double
        Do Until count = s.Length
            Dim md = Mid(s, count, 1)
            sum += md * m
            m /= 2
            count += 1
        Loop
        Return sum
    End Function
    Private Function nomalization(ByVal ss As String)
        ss = "1." & ss
        Return ss
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
End Class
