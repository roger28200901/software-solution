Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a = Val(TextBox1.Text) : Dim b = Val(TextBox2.Text)
        Dim c = Val(TextBox3.Text) : Dim d = Val(TextBox4.Text)

        If a > 1 Or a < 0 Or b > 1 Or b < 0 Or c > 1 Or c < 0 Or d > 1 Or d < 0 Then
            TextBox5.Text = "無解"
        Else
            TextBox5.Text = "通道輸出為1的機率：" & (a * c) + (b * (1 - d))
        End If



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a = Val(TextBox1.Text) : Dim b = Val(TextBox2.Text)
        Dim c = Val(TextBox3.Text) : Dim d = Val(TextBox4.Text)

        If a > 1 Or a < 0 Or b > 1 Or b < 0 Or c > 1 Or c < 0 Or d > 1 Or d < 0 Then
            TextBox5.Text = "無解"
        Else
            TextBox5.Text = "假設我們已經觀察到通道輸出為1，這時候通道輸入為1的機率為何：" & (b * (1 - d)) / ((a * c) + (b * (1 - d)))
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
End Class
