Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim find As Boolean = False
        Dim times = 0

        Dim up, down As Integer
        Dim n1, n2 As Double
        Dim accuracy As Integer = Val(TextBox3.Text)

        n2 = Val(TextBox2.Text)
        n1 = Val(TextBox1.Text)

        Dim vector = (n2 - n1) * Math.Pow(10, accuracy)

        Do Until find = True
            times += 1
            If Math.Pow(2, times) > vector Then
                find = True
                up = times
                down = up - 2
            End If
        Loop

        Dim r As String = TextBox4.Text


        Dim x As Double

        If r.IndexOf(".") = -1 Then
            '二進位
            r = binaryToDecimal(r)
            x = Math.Round(n1 + r * (n2 - n1) / (Math.Pow(2, up) - 1), accuracy)
            anslabel.Text = "Ans=" & x
        Else
            '實數
            x = Val(r)

            x = Math.Round((x - n1) * (Math.Pow(2, up) - 1) / (n2 - n1))
            Dim xp = decimalToBinary(x)
            anslabel.Text = "Ans=" & xp
        End If
    End Sub
    Private Function binaryToDecimal(ByVal r As String)
        Dim times = 0
        Dim t As Integer
        For i = r.Length To 1 Step -1
            t += Mid(r, i, 1) * Math.Pow(2, times)
            times += 1
        Next
        Return t
    End Function
    Private Function decimalToBinary(ByVal r As String)
        Dim t As String
      
        Do Until r \ 2 = 0
            Dim k = r Mod 2
            t = k & t
            r = r \ 2
        Loop
        t = 1 & t

        Return t
    End Function
End Class
