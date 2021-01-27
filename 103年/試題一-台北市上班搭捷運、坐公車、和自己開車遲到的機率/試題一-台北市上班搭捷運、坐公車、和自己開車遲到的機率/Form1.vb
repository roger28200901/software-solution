Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a, b, c, d, r, f
        a = Val(TextBox1.Text)
        b = Val(TextBox2.Text)
        c = Val(TextBox3.Text)
        d = Val(TextBox4.Text)
        r = Val(TextBox5.Text)
        f = Val(TextBox6.Text)
        If a > 1 Or b > 1 Or c > 1 Or d > 1 Or r > 1 Or f > 1 Then
            TextBox7.Text = "無解"
        Else
            TextBox7.Text = "在台北市的上班族遲到的機率為:" & (a * d) + (b * r) + (c * f)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a, b, c, d, r, f
        a = TextBox1.Text
        b = TextBox2.Text
        c = TextBox3.Text
        d = TextBox4.Text
        r = TextBox5.Text
        f = TextBox6.Text
        If a > 1 Or b > 1 Or c > 1 Or d > 1 Or r > 1 Or f > 1 Then
            TextBox7.Text = "無解"
        Else
            TextBox7.Text = "如果已知有一個人上班遲到，那他是自己開車的機率為何?:" & ((c * f) / ((a * d) + (b * r) + (c * f)))
        End If
    End Sub
End Class
