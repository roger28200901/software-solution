Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n As Integer = Val(TextBox1.Text)
        TextBox2.Text = ""

        Dim s As String = "1"
        TextBox2.Text &= s & vbNewLine
        For i = 1 To n


            If n = 1 Then
                TextBox2.Text &= "11 (注解：解讀上一行是1個1)"
                Exit For
            End If

            Dim a As New Queue ' 個數
            Dim b As New Queue ' 那個數字

            Do Until s.Length = 0



                Dim x As Integer = 1
                Dim c As Char = Mid(s, x, 1)
                Dim count = 1

                For y = 2 To s.Length
                    If Mid(s, y, 1) = c Then
                        count += 1
                    Else
                        Exit For
                    End If
                Next

                a.Enqueue(count)
                b.Enqueue(c)

                s = s.Substring(x - 1 + count)

            Loop

            For z = 0 To a.Count - 1
                s &= a(z) & b(z)
            Next
            TextBox2.Text &= s & " (注解：解讀上一行是"
            For z = 0 To a.Count - 1
                TextBox2.Text &= a(z) & "個" & b(z) & IIf(z = a.Count - 1, ")", ",")
            Next
            TextBox2.Text &= vbNewLine

        Next

    End Sub
End Class
