Public Class Form1
    Dim ans As New Queue(Of String)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = TextBox1.Text
        change(str, "")
        TextBox2.Text = ans.Count
        TextBox3.Text = String.Join(vbNewLine, ans.ToArray)
    End Sub
    Private Function change(ByVal a As String, ByVal b As String)
        If b.Length = a.Length Then
            ans.Enqueue(b)
        End If
        For i = 1 To a.Length
            Dim word As Boolean = False
            For j = 1 To b.Length
                If Mid(b, j, 1) = Mid(a, i, 1) Then
                    word = True
                End If
            Next
            If word = False Then
                change(a, b & Mid(a, i, 1))
            End If
        Next
    End Function
End Class
