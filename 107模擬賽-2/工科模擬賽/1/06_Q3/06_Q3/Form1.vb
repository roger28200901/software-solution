Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim count As Integer = 0
        For i = 1 To Len(TextBox1.Text)
            If Mid(TextBox1.Text, i, 1) Like " " Then count += 1
        Next

        Dim word(count) As String

        'For i = 0 To UBound(word)
        '    MsgBox(word(i))
        'Next
        Randomize()
        Dim t As Double = 0
        Dim ans(count + 1) As String
        Do
            test(word)
            t += 1
            For i = 1 To count
                Dim ran As Integer = Fix((4 - 1 + 1) * VBMath.Rnd + 1)
                Select Case ran
                    Case 1
                        word(i) = Val(word(i - 1)) + word(i)
                        ans(i) = "+"
                    Case 2
                        word(i) = Val(word(i - 1)) - word(i)
                        ans(i) = "-"
                    Case 3
                        word(i) = Val(word(i - 1)) * word(i)
                        ans(i) = "*"
                    Case 4
                        word(i) = Val(word(i - 1)) / word(i)
                        ans(i) = "/"
                End Select

            Next
            ' MsgBox(word(i))
            If word(count) = TextBox2.Text Then Exit Do
            If t = 100000 - 1 Then Labela.Text = "運算式結果 : NO EXPRESSION" : Exit Sub
        Loop Until t = 100000

        test(word)
        Dim st As String = ""
        For i = 0 To count
            st &= word(i) & ans(i + 1)
        Next
        st &= "=" & TextBox2.Text
        Labela.Text = "運算式結果 : " & st
    End Sub

    Sub test(ByRef word() As String)
        Dim str As String = TextBox1.Text & " "
        Dim count As Integer = 0
        Do
            word(count) = Mid(str, 1, InStr(str, " ") - 1)
            str = Mid(str, InStr(str, " ") + 1)
            count += 1
        Loop Until InStr(str, " ") = 0
    End Sub
End Class
