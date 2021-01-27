Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hasDash As Boolean = TextBox1.Text.Contains("-")
        TextBox2.Text = ""
        TextBox3.Text = ""
        If IsNumeric((TextBox1.Text)) = False Then
            TextBox2.Text = "號碼不對"
            TextBox3.Text = "號碼不對"
            Exit Sub
        End If
        If TextBox1.Text.Length <> 9 Then
            MsgBox("長度不對")
            Exit Sub
        End If
        Dim input = TextBox1.Text.Split("-")
            Dim ISBN As String = String.Join("", input)
        Dim ISBN10 As String = ""
        Dim ISBN13 As String = ""
        'isbn10
        Dim S
        Dim count = 10
        For i = 1 To ISBN.Length
            Dim n = Val(Mid(ISBN, i, 1))
            S += n * count
            count -= 1
        Next
        Dim M = S Mod 11
        Dim deltaN = 11 - M
        Dim checkCode = ""
        If deltaN = 10 Then
            checkCode = "X"
        ElseIf deltaN = 11 Then
            checkCode = 0
        Else
            checkCode = deltaN
        End If

        For i = 1 To ISBN.Length
            ISBN10 &= Mid(ISBN, i, 1) & IIf(i Mod 3 = 0, "-", "")
        Next
        TextBox2.Text = ISBN10 & checkCode
        'isbn13
        ISBN13 = "978" & ISBN
        Dim c = 1
        Dim sum = 0
        For i = 1 To ISBN13.Length
            sum += Val(Mid(ISBN13, i, 1)) * IIf(c Mod 2 = 0, 3, 1)
            c += 1
        Next
        Dim checkCode2 = ""
        If sum Mod 10 = 0 Then
            checkCode2 = 0
        Else
            checkCode2 = 10 - (sum Mod 10)
        End If

        For i = 1 To ISBN13.Length
            If hasDash = True Then
                TextBox3.Text &= Mid(ISBN13, i, 1) & IIf((i Mod 3 = 0), "-", "")
            Else
                TextBox3.Text &= Mid(ISBN13, i, 1) & IIf((i Mod 3 = 0 And i <> 9) Or i = 10, "-", "")
            End If

        Next
        TextBox3.Text &= checkCode2

    End Sub
End Class
