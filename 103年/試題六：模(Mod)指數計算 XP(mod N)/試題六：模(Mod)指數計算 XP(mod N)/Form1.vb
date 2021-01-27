Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Visible = False
        Button3.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x = Val(TextBox1.Text)
        Dim p = Val(TextBox2.Text)
        Dim n = Val(TextBox3.Text)
        If x < 2 Or x > 100 Or p < 0 Or p > 3000 Or n <= 0 Or n > 200 Then
            MsgBox("請確認輸入範圍")
            Exit Sub
        End If
        Dim ans As Integer = 1

        For i = 1 To p
            ans = (ans * x) Mod n
        Next



        Label4.Text = "餘數= " & ans
        Button2.Visible = True
        Button3.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Label4.Text = "餘數="
        Button2.Visible = False
        Button3.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
End Class
