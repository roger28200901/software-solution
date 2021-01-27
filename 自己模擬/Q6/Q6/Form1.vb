Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txt = TextBox2.Text
        Dim lines = Split(Trim(txt), vbCrLf)
        For i = 0 To lines.Count - 1
            Dim datas = lines(i).Split(",")
            Dim value = datas(0)
            Dim v1 = datas(1)
            Dim v2 = datas(2)

            Dim q As New Queue
            q = swap(value, "", q)
            Array.Sort(q.ToArray)

            Dim sum = Val(q(v1 - 1)) + Val(q(v2 - 1))
            TextBox3.Text &= sum & vbNewLine
        Next
    End Sub
    Function swap(ByVal a As String, ByVal b As String, ByVal q As Queue)
        If a.Count = b.Count Then
            q.Enqueue(b)
            Return q
        End If
        For i = 1 To a.Length
            Dim word As Boolean = False
            For j = 1 To b.Length
                If Mid(a, i, 1) = Mid(b, j, 1) Then
                    word = True
                End If
            Next
            If word = False Then
                swap(a, b & Mid(a, i, 1), q)
            End If
        Next
        Return q
    End Function
End Class
