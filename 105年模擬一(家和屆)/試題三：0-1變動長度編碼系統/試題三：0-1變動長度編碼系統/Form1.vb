Public Class Form1
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim str As String
        For i = 1 To 36
            str &= "0"
        Next
        For j = 1 To 4
            Dim index = Rnd() * str.Length
            str = str.Insert(index, "1")
        Next
        TextBox1.Text = str
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim orData = TextBox1.Text
        Dim startIndex = 0
        Dim index = orData.IndexOf("1", startIndex)

        Dim ansEncode As New Queue(Of String)

        Do Until index = -1
            Dim str = orData.Substring(startIndex, index - startIndex)
            startIndex = index + 1
            index = TextBox1.Text.IndexOf("1", startIndex)
            Dim b As Integer = str.Length
            ansEncode.Enqueue(Convert.ToString(b, 2))
        Loop

        If orData.IndexOf("0", startIndex) <> -1 Then
            Dim l As Integer = orData.Substring(startIndex).Length
            ansEncode.Enqueue(Convert.ToString(l, 2))
        End If

        TextBox2.Text = String.Join(" ", ansEncode.ToArray)
        TextBox3.Text = Format(TextBox2.Text.Length / TextBox1.Text.Length, "##.#%")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub
End Class
