Public Class Form1
    Dim steps As New Queue
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Visible = False
        Label6.Visible = False


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n1 As Integer = Val(TextBox1.Text)
        Dim n2 As Integer = Val(TextBox2.Text)
        steps.Clear()
        If (Not (n1 >= 11 And n1 <= 19 And n2 >= 11 And n2 <= 19)) = True Then
            If (Not (n1 >= 21 And n1 <= 29 And n2 >= 21 And n2 <= 29)) = True Then
                MsgBox("被乘數與乘數的十位數需相同")
                Exit Sub
            End If
        End If

        Dim ans As Integer = n1 * n2
        Dim n3 As Integer = Val(TextBox3.Text)

        Dim v1 As Integer : Dim v2 As Integer
        v1 = Mid(n1, n1.ToString.Length, 1)
        v2 = Mid(n2, n2.ToString.Length, 1)

        steps.Enqueue("(1) " & n1 & "+" & v2 & "=" & (n1 + v2))
        steps.Enqueue("(2) " & (n1 + v2) & "X" & "10" & "=" & ((n1 + v2) * 10))

        steps.Enqueue("(3) " & v1 & "X" & v2 & "=" & v1 * v2)
        steps.Enqueue("(4) " & ((n1 + v2) * 10) & "+" & (v1 * v2) & "=" & (((n1 + v2) * 10) + (v1 * v2)))
        If ans <> n3 Then
            Label5.Text = "is wrong"
            Label6.Text = String.Join(vbNewLine, steps.ToArray)
        Else
            Label5.Text = "Very Good!"
            Label6.Text = ""
        End If
        Label5.Visible = True
        Label6.Visible = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Label5.Text = ""
        Label6.Text = ""
        Label5.Visible = False
        Label6.Visible = False
    End Sub
End Class
