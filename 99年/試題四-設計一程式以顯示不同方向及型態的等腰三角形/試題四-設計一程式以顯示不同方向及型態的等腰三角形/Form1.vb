Public Class Form1
    Dim directPositive As Boolean = False
    Dim center As Boolean = False
    '正向
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        directPositive = True
    End Sub
    '中空
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        center = True

    End Sub
    '垂直反轉

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        directPositive = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim n = Val(TextBox1.Text)
        Label2.Text = "數值：" & n
        Label4.Text = "數值：" & n
        If Not (n >= 5 And n <= 19) Then
            MsgBox("從 5 至 19 為一合理操作範圍")
            Return
        End If

        Dim map(n - 1, n - 1)
        show.Text = ""
        show2.Text = ""
        '不正向
        If directPositive = False Then
            Label3.Text = "顯示方向：反向"

            For i = 1 To n
                For j = i To n - (i - 1)
                    show.Text &= "＊"
                Next
                show.Text &= vbNewLine
            Next

            If center = True Then
                Label5.Text = "顯示方向：反向"
                For i = 1 To n
                    Dim b As Boolean = False
                    Dim d1 As Integer = i
                    Dim d2 As Integer = n - (i - 1)
                    For j = 1 To n
                        If i = 1 Then
                            show2.Text &= "＊"
                            Continue For
                        End If
                        If j = d1 Or j = d2 Then
                            show2.Text &= "＊"
                        Else
                            show2.Text &= "　"
                        End If
                        If d1 = d2 Then
                            b = True
                        End If
                    Next

                    show2.Text &= vbNewLine
                    If b = True Then
                        Exit For
                    End If
                Next
            End If

        Else
            Label3.Text = "顯示方向：正向"

            For i = n To 1 Step -1
                For j = i To n - (i - 1)
                    show.Text &= "＊"
                Next
                show.Text &= vbNewLine
            Next

            If center = True Then
                Label5.Text = "顯示方向：正向"
                show2.Text = ""
                For i = 1 To n
                    Dim b As Boolean = False
                    Dim d1 As Integer = Math.Ceiling((n / 2) - (i - 1))
                    Dim d2 As Integer = Math.Ceiling((n / 2) + (i - 1))
                    For j = 1 To n
                        If d1 = 1 And d2 = n Then
                            b = True
                            show2.Text &= "＊"
                            Continue For
                        End If
                        If d1 = j Or d2 = j Then
                            show2.Text &= "＊"
                        Else
                            show2.Text &= "　"
                        End If
                    Next
                    show2.Text &= vbNewLine
                    If b = True Then
                        Exit For
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        End
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        show.Text = ""
        show2.Text = ""
        Label2.Text = "數值："
        Label2.Text = "數值："
        Label3.Text = "顯示方向："
        Label5.Text = "顯示方向："
    End Sub
End Class
