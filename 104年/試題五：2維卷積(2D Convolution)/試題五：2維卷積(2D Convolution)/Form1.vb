Public Class Form1
    Dim input(6, 6)
    Dim k(2, 2)
    Dim output(6, 6)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        readMap()
        setMap()
        solveThree()
    End Sub
    Private Sub solveThree()
        Dim H As Integer = 6
        Dim W As Integer = 6
        Dim MSE As Double = 0
        Dim MAE As Double = 0
        Dim PSNR As Double = 0
        For y = 0 To 6
            For x = 0 To 6
                MSE += ((input(x, y) - output(x, y)) ^ 2)
                MAE += Math.Abs((input(x, y) - output(x, y)))

            Next
        Next
        MSE /= 49
        MAE /= 49
        PSNR = 10 * Math.Log10(255 * 255 / MSE)
        output1.Text = MSE
        output2.Text = MAE
        output3.Text = PSNR

    End Sub
    Private Sub setMap()
        For m = 0 To 6
            For n = 0 To 6
                Dim q As Integer = (m * 7) + (50 + n)
                GroupBox3.Controls("TextBox" & q).Text = output(n, m)
            Next
        Next
    End Sub
    Private Sub readMap()
        'input
        Dim n As Integer = 1

        For i = 0 To 6
            For j = 0 To 6
                Dim q As Integer = (i * 7) + (j + 1)
                input(j, i) = GroupBox1.Controls("TextBox" & q).Text
            Next
        Next

        'k 107 - 99
        For i = 0 To 2
            For j = 0 To 2
                Dim q As Integer = (107 - j) - (i * 3)
                k(i, j) = GroupBox2.Controls("TextBox" & q).Text
            Next
        Next

        'output
        For m = 0 To 6
            For n = 0 To 6
                Dim value = 0
                If m = 0 Or n = 0 Or m = 6 Or n = 6 Then
                    value = 0
                    output(m, n) = value
                    Continue For
                End If
                value = sumMap(m, n)
                output(m, n) = value
            Next
        Next


    End Sub
    Function sumMap(ByVal m As Integer, ByVal n As Integer)

        Dim value = 0
        Dim x1 As Integer = m - 1
        Dim y1 As Integer = n - 1
        For x = 0 To 2
            For y = 0 To 2
                value += k(x, y) * input(x1, y1)
                x1 += 1
            Next
            x1 = m - 1
            y1 += 1
        Next
        Return value
    End Function
End Class
