Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim t1 = TextBox1.Text

    

        'Dim n = t1.Length
        'n = 10
        'n = n - 1
        'Dim find As Boolean = False
        'Dim k = 0
        'Dim sum = 1
        'Do Until find = True
        '    sum = 2 ^ k
        '    If sum > n Then
        '        find = True
        '        Exit Do
        '    End If
        '    k += 1
        'Loop

        'Dim s = n + k
        'Dim c(t1.Length)
        'For i = 1 To t1.Length
        '    c(t1.Length + 1 - i) = Mid(t1, i, 1)
        'Next
        'Dim x As Byte = c(t1.Length - 1) * t1.Length
        'Dim y As Byte = c(t1.Length - 1) * (t1.Length - 1)
        'Dim q = x Xor y
        'For l = t1.Length - 2 To 1 Step -1
        '    Dim t As Byte = c(l) * l
        '    q = q Xor t
        'Next

        Dim t1 = TextBox1.Text

        If t1.Length < 1 And t1.Length > 11 Then
            MsgBox("欲傳遞的訊息(1bit 到 11bits之間)")
            Exit Sub
        End If

        For i = 1 To t1.Length
            If Mid(t1, i, 1) <> "1" And Mid(t1, i, 1) <> "0" Then
                MsgBox("欲傳遞的訊息的值應是0或1")
                Exit Sub
            End If
        Next

        Dim n = t1.Length
        Dim find As Boolean = False
        Dim k = 0
        Do While find = False
            If k <= (2 ^ k) - n - 1 Then
                Exit Do
            Else
                k += 1
            End If
        Loop
        'k

        Dim h = k + n

        Dim kt = k
        Dim c(h)
        Dim z As Byte
        For i = 1 To n
            Dim x = Mid(t1, i, 1)
            Dim b = (t1.Length + 1 - i) + k
            If b = 2 ^ (k - 1) Then
                k -= 1
                b -= 1
                z = x * b
                c(i) = z
                Continue For
            End If
            z = x * b
            c(i) = z
            b -= 1
        Next

        Dim b1 As Byte = c(1)
        Dim b2 As Byte = c(2)

        Dim sum As Byte = b1 Xor b2

        For x = 3 To n
            sum = sum Xor c(x)
        Next
        Dim xx As String = D2B(sum, kt)

        '11011 101 1 
        '0011
        For i = 1 To xx.Length
            Dim o = Mid(xx, i, 1)
            Dim delta = h - 2 ^ (xx.Length - i)
            t1 = t1.Insert(delta, o)
        Next

        TextBox2.Text = t1
    End Sub
    Function D2B(ByVal d, ByVal k)
        Return Convert.ToString(CInt(d), 2).PadLeft(k, "0")
    End Function
   
End Class
