Public Class Form1
    Dim errorTimes As Integer = 0
    Dim q As Boolean = False
    Dim k As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim N = TextBox1.Text
        Dim c As Boolean = checkError(N)
        TextBox2.Text = ""
        'false 錯誤三次
        'true 沒有錯誤三次
        '題意不明確
        If q = True Then
            TextBox2.Text = "???"
            Exit Sub
        End If

        If c = False Then
            If IsNumeric(N) = False Then
                Exit Sub
            End If
        Else
            If IsNumeric(N) = False Then
                Exit Sub
            End If
        End If
        Dim count = 0
        Dim i As Integer
        For i = 1 To N
            TextBox2.Text &= IIf(q, "?", N - count) & " "
            For j = 0 To i - 2
                TextBox2.Text &= IIf(q, "?", "1") & " "
            Next
            TextBox2.Text &= vbNewLine
            count += 1
        Next

    End Sub
    Private Sub clearError()
        errorTimes = 0
    End Sub
    Private Function checkError(ByVal n As String)
        If n = "***" Then
            errorTimes = 0
            TextBox1.ForeColor = Color.Black
            q = False
            Label1.Text = ""
            Return False
        End If
        'set error
        If Not (Val(n) >= 1 And Val(n) <= 10) Then
            errorTimes += 1
        Else
            errorTimes = 0
        End If
        If errorTimes >= 3 Then
            Label1.Text = "錯誤超過三次"
            TextBox1.ForeColor = Color.Red
            q = True
            Return False
        End If
        Return True
    End Function
End Class
