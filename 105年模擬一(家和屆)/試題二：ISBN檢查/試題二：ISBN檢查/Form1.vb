Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim B(7) : B(1) = 157 : B(2) = 204 : B(3) = 421 : B(4) = 442
        B(5) = 7198 : B(6) = 7323 : B(7) = 8573
        Dim input = TextBox1.Text
        If input.Contains("-") Then
            input = input.Replace("-", "")
        End If
        'isbn-10
        Dim sum As Integer = 0
        Dim count As Integer = 10
        For i = 0 To Len(input) - 1
            sum += Val(input(i)) * count
            count -= 1
        Next
        Dim M As Integer = 0
        M = sum Mod 11
        Dim N As Integer = 0
        N = 11 - M
        Dim digitalISBN10 As String
        If N = 10 Then
            digitalISBN10 = "X"
        ElseIf N = 11 Then
            digitalISBN10 = "0"
        Else
            digitalISBN10 = N.ToString
        End If
        Dim isbn10 As String = input & digitalISBN10

        Dim numberDash As Integer = 3
        For Each item In B
            If item = Nothing Then Continue For
            If isbn10.Substring(3, 3) = item.ToString.Substring(0, 3) Then
                numberDash = item.ToString.Length
            End If
        Next
        TextBox2.Text = isbn10.Substring(0, 3) & "-" & isbn10.Substring(3, numberDash) & "-" & isbn10.Substring(3 + numberDash, 6 - numberDash) & "-" & isbn10.Substring(9)
        'isbn13
        Dim isbn13 As String = "978" & isbn10.Substring(0, 9)
        Dim sum2 As Integer = 0
        For i = 0 To Len(isbn13) - 1
            sum2 += IIf(i Mod 2 = 0, 1, 3) * Val(isbn13(i))
        Next
        Dim digitalISBN13 = 10 - (sum2 Mod 10)
        isbn13 &= digitalISBN13

        For Each item In B
            If item = Nothing Then Continue For
            If isbn13.Substring(6, 3) = item.ToString.Substring(0, 3) Then
                numberDash = item.ToString.Length
            End If
        Next
        TextBox3.Text = isbn13.Substring(0, 3) & "-" & isbn13.Substring(3, 3) & "-" & isbn13.Substring(6, numberDash) & "-" & isbn13.Substring(6 + numberDash, 6 - numberDash) & "-" & isbn13.Substring(12)
    End Sub
End Class
