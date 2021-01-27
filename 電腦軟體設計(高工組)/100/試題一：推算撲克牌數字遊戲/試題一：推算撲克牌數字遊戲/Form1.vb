Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim v1 = Val(TextBox1.Text) 'A and B
        Dim v2 = Val(TextBox2.Text) ' A and C
        Dim v3 = Val(TextBox3.Text)
        Dim L As New List(Of String)

        For i = 1 To v3 - 1
            For j = 1 To v3 - 1
                For k = 1 To v3 - 1
                    If 2 * i + j + k = v1 + v2 And i + j = v1 And i + k = v2 And i <> j And j <> k And i <> k Then
                        L.Add("A=" & i & " B=" & j & " C=" & k)
                    End If
                Next
            Next
        Next
        If L.Count = 0 Then
            L.Add("無解")
        End If
        TextBox4.Text = String.Join(vbNewLine, L)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub
End Class
