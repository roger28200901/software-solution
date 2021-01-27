Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim search = TextBox2.Text
        Dim startindex = 0
        Dim find As Boolean = False
        Dim t As String = RichTextBox1.Text
        Dim temp As String = RichTextBox1.Text
        t = t.Replace(vbLf, " ")
        RichTextBox1.Text = t
        Dim d
        Do
            d = RichTextBox1.Find(search, startindex, RichTextBox1.Text.Length, RichTextBoxFinds.MatchCase)
            If d = -1 Then
                find = False
                Exit Do
            Else
                find = True
                Exit Do
            End If
        Loop

        d += 1
        RichTextBox1.Text = temp
        If find = True Then
            TextBox3.Text = d
        Else
            TextBox3.Text = "未找到" & search & "字串"
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim txt = My.Computer.FileSystem.ReadAllText(TextBox1.Text)
        RichTextBox1.Text = txt
        TextBox3.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim txt = My.Computer.FileSystem.ReadAllText(TextBox1.Text)
            RichTextBox1.Text = txt
        Catch ex As Exception
            RichTextBox1.Text = ""
        End Try
    End Sub
End Class
