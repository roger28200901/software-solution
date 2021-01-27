Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Text Files|*.txt"
        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim filename = OpenFileDialog1.FileName
        Dim text = My.Computer.FileSystem.ReadAllText(filename, System.Text.Encoding.Default)
        RichTextBox1.Text = text

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim selectText = TextBox1.Text
        Dim startindex = 0
        If String.IsNullOrWhiteSpace(selectText) Then
            MsgBox("未輸入欲搜尋的字串")
            Exit Sub
        End If

        RichTextBox1.SelectAll()
        RichTextBox1.BackColor = Color.White
        Dim count = 0
        Do Until startindex > RichTextBox1.Text.Length
            Dim index = RichTextBox1.Find(selectText, startindex, RichTextBox1.Text.Length, RichTextBoxFinds.MatchCase)
            If index <> -1 Then
                RichTextBox1.Select(index, selectText.Length)
                RichTextBox1.SelectionBackColor = Color.Yellow
                count += 1
            End If
            startindex += index + selectText.Length

            Label3.Text = count
        Loop
    End Sub
End Class
