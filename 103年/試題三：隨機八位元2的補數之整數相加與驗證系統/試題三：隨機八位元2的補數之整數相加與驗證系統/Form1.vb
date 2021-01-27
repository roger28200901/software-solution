Public Class Form1
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        end
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Randomize()
        Dim t1 As String = ""
        Dim t2 As String = ""
        For i = 1 To 8
            Dim r1 As Integer = Rnd()
            Dim r2 As Integer = Rnd()
            t1 &= r1
            t2 &= r2
        Next
        TextBox1.Text = "" : TextBox5.Text = ""
        TextBox2.Text = "" : TextBox6.Text = ""
        TextBox3.Text = "" : TextBox7.Text = ""
        TextBox4.Text = "" : TextBox8.Text = ""
        TextBox1.Text = t1
        TextBox2.Text = t2
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a = TextBox1.Text
        Dim b = TextBox2.Text

        '正

        Dim s = Convert.ToInt32(a, 2) + Convert.ToInt32(b, 2)
        Dim sum As String = Convert.ToString(s, 2).PadRight(8, "0")
        TextBox3.Text = sum.Substring(sum.Length - 8, 8)
        If TextBox1.Text(0) = "1" And TextBox2.Text(0) = "1" And TextBox3.Text(0) = "0" Then
            TextBox4.Text = "underflow"
        ElseIf TextBox1.Text(0) = "0" And TextBox2.Text(0) = "0" And TextBox3.Text(0) = "1" Then
            TextBox4.Text = "overflow"
        End If
    End Sub
    Private Function twoComplement(ByVal s As String)
        If s(0) = "0" Then
            Return s
        End If
        Dim find As Boolean = False
        Dim count = s.Length
        Dim index = -1
        Do Until count = 1
            Dim m As String = Mid(s, count, 1)
            If m = "1" Then
                index = count - 1
                Exit Do
            Else
                count -= 1
            End If
        Loop
        Dim back As String = s.Substring(index, s.Length - index)
        Dim front As String = ""
        For i = 0 To index - 1
            If s(i) = "1" Then
                front = front & "0"
            Else
                front = front & "1"
            End If
        Next
        Dim t As String = front & back
        Return t
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim a = TextBox1.Text
        Dim b = TextBox2.Text
        Dim c = TextBox3.Text
        Dim a1 = 1 : Dim b1 = 1 : Dim c1 = 1
        If a(0) = "1" Then
            a1 = -1
        Else
            a1 = 1
        End If
        If b(0) = "1" Then
            b1 = -1
        Else
            b1 = 1
        End If
        If c(0) = "1" Then
            c1 = -1
        Else
            c1 = 1
        End If
        a = twoComplement(a)
        b = twoComplement(b)
        c = twoComplement(c)




        Dim n1 = a1 * Convert.ToInt32(a, 2)
        Dim n2 = b1 * Convert.ToInt32(b, 2)
        Dim n3 = c1 * Convert.ToInt32(c, 2)

        Dim che = n1 + n2
        If che < -128 Then
            TextBox8.Text = "不足位"
        ElseIf c > 127 Then
            TextBox8.Text = "溢位"
        End If
        TextBox5.Text = n1
        TextBox6.Text = n2
        TextBox7.Text = n3
    End Sub
End Class
