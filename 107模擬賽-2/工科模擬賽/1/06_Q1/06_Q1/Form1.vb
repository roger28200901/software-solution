Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox3.Text = ""
        Dim word(Len(TextBox1.Text)) As String
        test(word)
        Dim ans As String = ""
        For i = 1 To UBound(word)
            Dim temp As Integer = AscW(word(i))
            ans &= Convert.ToString(temp, 16)

        Next

        Dim cc As Long = TextBox2.Text

        Dim crc As Integer
        For i = 1 To cc
            If six(ans & Convert.ToString(i, 16)) Mod TextBox2.Text = 0 Then crc = i : Exit For
        Next
        Dim crcst As String = Convert.ToString(crc, 16)
        Dim crcans(Len(crcst)) As String
        For i = 1 To UBound(crcans)
            crcans(i) = Mid(crcst, 1 + (i - 1) * 2, 2)
            TextBox3.Text &= UCase(crcans(i)) & " "
        Next
    End Sub
    Function six(ByVal st As String) As Double
        Dim sum As Double = 0
        st = StrReverse(st)
        For i = 1 To Len(st)
            Dim aaa As String = Mid(st, i, 1)

            sum += Convert.ToInt64(aaa, 16) * 16 ^ (i - 1)
        Next
        Return sum
    End Function
  

    Function test(ByRef word() As String)
        For i = 1 To Len(TextBox1.Text)
            word(i) = Mid(TextBox1.Text, i, 1)
        Next
        Return word
    End Function
End Class
