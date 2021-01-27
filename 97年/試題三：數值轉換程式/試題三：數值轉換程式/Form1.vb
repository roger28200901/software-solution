Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s = 0
        Dim rn As Decimal = Convert.ToDecimal(TextBox1.Text)
        If rn > 0 Then
            s = 0
        Else
            s = 1
        End If
        rn = Math.Abs(rn)
        TextBox2.Text = ""
        Dim range = 2 ^ 15
        If rn < -range Or rn > range Then
            TextBox2.Text = "overflow"
            Exit Sub
        End If
        Dim frontInt As Integer = Math.Floor(rn)
        Dim frontString = Convert.ToString(frontInt, 2).PadLeft(15, "0")
        Dim backLittle As Decimal = rn - frontInt
        Dim backString = convertFraction(backLittle.ToString)
        Dim ans As String = IIf(s = 0, "", "1") & frontString & "." & backString
        TextBox2.Text = ans
    End Sub
    Function convertFraction(ByVal s As String)
        Dim ret As String = ""
        Dim count As Decimal = 0
        Dim n As Integer = 1
        Do Until count = Val(s)
            count += (1 / (2 ^ n))
            n += 1
        Loop
        For x = 1 To n
            ret &= "1"
        Next
        ret = ret.PadRight(8, "0")
        Return ret
    End Function
End Class
