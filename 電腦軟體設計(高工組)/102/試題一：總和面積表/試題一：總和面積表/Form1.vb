Public Class Form1
    Dim map(,)
    Dim S(,)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OFD As New OpenFileDialog
        Dim n As Integer
        OFD.Filter = "Text Files|*.txt"
        Try
            OFD.ShowDialog()
            Dim txt = My.Computer.FileSystem.ReadAllText(OFD.FileName)
            Dim lines = Split(Trim(txt), vbCrLf)
            n = UBound(lines)
            ReDim map(UBound(lines), UBound(lines))
            ReDim S(n + 1, n + 1)
            For i = 0 To UBound(lines)
                Dim line = lines(i).Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                For j = 0 To UBound(line)
                    map(i, j) = line(j)
                Next
            Next
        Catch ex As Exception
            MsgBox("Error")
        End Try
        For i = 0 To n
            For j = 0 To n
                TextBox5.Text &= map(i, j).ToString.PadRight(6 - map(i, j).ToString.Length, " ")
            Next
            TextBox5.Text &= vbNewLine
        Next



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim n As Integer = UBound(map)
        For x = 0 To n + 1
            For y = 0 To n + 1
                If x = 0 Or y = 0 Then
                    S(x, y) = 0
                Else
                    S(x, y) = map(x - 1, y - 1) + S(x - 1, y) + S(x, y - 1) - S(x - 1, y - 1)
                End If
            Next
        Next

        For i = 0 To n + 1
            For j = 0 To n + 1
                TextBox6.Text &= S(i, j).ToString.PadRight(6 - S(i, j).ToString.Length, " ")
            Next
            TextBox6.Text &= vbNewLine
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim xL As Integer = TextBox1.Text : Dim xR As Integer = TextBox3.Text
        Dim yT As Integer = TextBox2.Text : Dim yB As Integer = TextBox4.Text
        Dim ans

        For x = xL To xR
            For y = yT To yB
                ans += S(y, x) - S(y, x - 1) - S(y - 1, x) + S(y - 1, x - 1)
            Next
        Next
        TextBox7.Text = ans

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim deltaX = Math.Abs(TextBox1.Text - TextBox3.Text) + 1
        Dim deltaY = Math.Abs(TextBox2.Text - TextBox4.Text) + 1
        Dim ans = Val(TextBox7.Text) / (deltaX * deltaY)
        TextBox8.Text = Format(ans, "0.000000")
    End Sub
End Class
