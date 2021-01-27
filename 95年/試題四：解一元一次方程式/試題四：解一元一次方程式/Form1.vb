Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim A As Integer = Val(TextBox1.Text)
        Dim B As Integer = Val(TextBox2.Text)
        Dim C As Integer = Val(TextBox3.Text)

        If A = 0 And B = 0 And C <> 0 Then
            TextBox4.Text = "無解"
            Label4.Text = "(" & A & ")X2" & "+" & "(" & B & ")X" & "+" & "(" & C & ")" & "= 0"
        ElseIf A = 0 And B = 0 And C = 0 Then
            TextBox4.Text = "無限多解"
            Label4.Text = "(" & A & ")X2" & "+" & "(" & B & ")X" & "+" & "(" & C & ")" & "= 0"
        ElseIf A = 0 And B <> 0 Then
            TextBox4.Text = -(C / B)
            TextBox5.Text = "只有一解"
            Label4.Text = "(" & A & ")X2" & "+" & "(" & B & ")X" & "+" & "(" & C & ")" & "= 0"
        ElseIf A <> 0 And B <> 0 And B ^ 2 - 4 * A * C = 0 Then
            TextBox4.Text = (-B / (2 * A))
            TextBox5.Text = "重根"
            Label4.Text = "(" & A & ")X2" & "+" & "(" & B & ")X" & "+" & "(" & C & ")" & "= 0"
        ElseIf A <> 0 And B <> 0 And B ^ 2 - 4 * A * C > 0 Then
            Dim x1 = ((-1 * B) + Math.Sqrt(B ^ 2 - 4 * A * C)) / (2 * A)
            Dim x2 = ((-1 * B) - Math.Sqrt(B ^ 2 - 4 * A * C)) / (2 * A)
            TextBox4.Text = x1
            TextBox5.Text = x2
            Label4.Text = "(" & A & ")X2" & "+" & "(" & B & ")X" & "+" & "(" & C & ")" & "= 0"
        ElseIf A <> 0 And B <> 0 And B ^ 2 - 4 * A * C < 0 Then
            Dim x1 = Math.Round((-1 * B) / (2 * A), 2)
            Dim x1i = Math.Round(Math.Sqrt(4 * A * C - B ^ 2) / (2 * A), 2) & "i"
            TextBox4.Text = x1 & " + " & x1i
            TextBox5.Text = x1 & " - " & x1i
            Label4.Text = "(" & A & ")X2" & "+" & "(" & B & ")X" & "+" & "(" & C & ")" & "= 0"
        End If
    End Sub
End Class
