Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a, b, c, d, r, f As Double
        a = Convert.ToDouble(TextBox1.Text)
        b = Convert.ToDouble(TextBox2.Text)
        c = Convert.ToDouble(TextBox3.Text)
        d = Convert.ToDouble(TextBox4.Text)
        r = Convert.ToDouble(TextBox5.Text)
        f = Convert.ToDouble(TextBox6.Text)
        Dim x As Double = 1.4
        Dim y As Double = 3
        Debug.Print(x * y)
        If a > 1 Or b > 1 Or c > 1 Or d > 1 Or r > 1 Or f > 1 Then
            TextBox7.Text = "無解"
        Else
            TextBox7.Text = "在台北市的上班族遲到的機率為:" & (a * d) + (b * r) + (c * f)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a, b, c, d, r, f As Double
        a = Convert.ToDouble(TextBox1.Text)
        b = Convert.ToDouble(TextBox2.Text)
        c = Convert.ToDouble(TextBox3.Text)
        d = Convert.ToDouble(TextBox4.Text)
        r = Convert.ToDouble(TextBox5.Text)
        f = Convert.ToDouble(TextBox6.Text)
        If a > 1 Or b > 1 Or c > 1 Or d > 1 Or r > 1 Or f > 1 Then
            TextBox7.Text = "無解"
        Else
            TextBox7.Text = "如果已知有一個人上班遲到，那他是自己開車的機率為何?:" & ((c * f) / ((a * d) + (b * r) + (c * f)))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
End Class
