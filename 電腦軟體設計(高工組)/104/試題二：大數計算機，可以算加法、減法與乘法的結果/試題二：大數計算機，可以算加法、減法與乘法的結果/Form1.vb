Imports System.Numerics
Public Class Form1


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim v1 As BigInteger = BigInteger.Parse(TextBox1.Text)
        Dim v2 As BigInteger = BigInteger.Parse(TextBox2.Text)
        If v1.ToString.Length > 20 Then
            MsgBox("最長20個位數")
            Exit Sub
        End If
        If v2.ToString.Length > 20 Then
            MsgBox("最長20個位數")
            Exit Sub
        End If

        Dim sum As BigInteger = BigInteger.Add(v1, v2)
        TextBox3.Text = sum.ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim v1 As BigInteger = BigInteger.Parse(TextBox1.Text)
        Dim v2 As BigInteger = BigInteger.Parse(TextBox2.Text)
        If v1.ToString.Length > 20 Then
            MsgBox("最長20個位數")
            Exit Sub
        End If
        If v2.ToString.Length > 20 Then
            MsgBox("最長20個位數")
            Exit Sub
        End If
        Dim sum As BigInteger = v1 - v2
        TextBox3.Text = sum.ToString
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim v1 As BigInteger = BigInteger.Parse(TextBox1.Text)
        Dim v2 As BigInteger = BigInteger.Parse(TextBox2.Text)
        If v1.ToString.Length > 20 Then
            MsgBox("最長20個位數")
            Exit Sub
        End If
        If v2.ToString.Length > 20 Then
            MsgBox("最長20個位數")
            Exit Sub
        End If
        Dim sum As BigInteger = BigInteger.Multiply(v1, v2)
        TextBox3.Text = sum.ToString
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class
