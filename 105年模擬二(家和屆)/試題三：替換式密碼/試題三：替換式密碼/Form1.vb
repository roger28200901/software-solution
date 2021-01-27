Public Class Form1
    Dim code(25)
    Dim table(9)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input = TextBox1.Text
        For i = 0 To Len(input) - 1
            code(i) = input(i)
        Next
        ''input A-Z
        Dim index As Integer = Len(input)
        For i = 1 To 26
            Dim c As Char = Chr(64 + i)
            While code.Contains(c) = False
                code(index) = c
                index += 1
            End While
        Next


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim newEncode = TextBox2.Text
        Dim codeStr As String = ""
        Dim number As String = ""
        For i = 0 To Len(newEncode) - 1
            codeStr &= newEncode(i)
            Dim c = check(codeStr)
            If c = -1 Then
                Continue For
            Else
                number &= c
                codeStr = ""
            End If
        Next
        Label3.Text = "解碼結果為：" & code(Val(number) - 1)
    End Sub
    Private Function check(ByVal newEncode As String)
        For i = 0 To 9
            If newEncode = table(i) Then
                Return i
            End If
        Next
        Return -1
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        table(0) = "00"
        table(1) = "01"
        table(2) = "100"
        table(3) = "101"
        table(4) = "1100"
        table(5) = "1101"
        table(6) = "11100"
        table(7) = "11101"
        table(8) = "111100"
        table(9) = "111101"
    End Sub
End Class
