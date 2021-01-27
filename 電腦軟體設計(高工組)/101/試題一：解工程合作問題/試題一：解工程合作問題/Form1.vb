Public Class Form1
    Private Sub Button1_Click(sender As Object, ev As EventArgs) Handles Button1.Click
        Dim N1 = Val(TextBox1.Text)
        Dim N2 = Val(TextBox2.Text)
        Dim N3 = Val(TextBox3.Text)
        Dim N4 = Val(TextBox4.Text)
        Try
            Dim a = N1
            Dim b = N1
            Dim c = 1
            Dim d = N2 + N3
            Dim e = N2 + N4
            Dim f = 1
            Dim delta = a * e - b * d
            Dim deltaX = c * e - f * b
            Dim deltaY = a * f - c * d

            Dim x = 1 / (deltaX / delta)
            Dim y = 1 / (deltaY / delta)
            If x <> Fix(x) Or y <> Fix(y) Or N3 = N4 Then
                TextBox5.Text = "無解"
            Else
                TextBox5.Text = "X = " & x & " Y = " & y
            End If
        Catch ex As Exception
            TextBox5.Text = "無解"
        End Try



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
