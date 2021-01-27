Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim output As String = ""
        Dim b80 As String = ""
        b80 = Convert.ToString(Convert.ToInt32(TextBox1.Text.Substring(2, 8)), 2).ToString.PadLeft(27, "0") & b80
        b80 = IIf(TextBox1.Text.Substring(1, 1) = "1", "0", "1") & b80
        b80 = Convert.ToString(Convert.ToInt32(Asc(TextBox1.Text.Substring(0, 1)) - 65), 2).ToString.PadLeft(5, "0") & b80
        b80 = Convert.ToString(Convert.ToInt32(TextBox2.Text.Substring(6, 2)), 2).ToString.PadLeft(5, "0") & b80
        b80 = Convert.ToString(Convert.ToInt32(TextBox2.Text.Substring(4, 2)), 2).ToString.PadLeft(4, "0") & b80
        b80 = Convert.ToString(Convert.ToInt32(TextBox2.Text.Substring(0, 4)) - 1900, 2).ToString.PadLeft(7, "0") & b80
        If ComboBox1.Text = "未婚" Then
            b80 = "0" & b80
        Else
            b80 = "1" & b80
        End If
        If ComboBox2.Text = "博士" Then
            b80 = "000" & b80
        Else
            b80 = "111" & b80
        End If
        b80 = Convert.ToString(Convert.ToInt32(TextBox3.Text.Substring(2)), 2).ToString.PadLeft(27, "0") & b80
        For i = 0 To b80.Length - 1 Step 4
            Dim str = Convert.ToString(Convert.ToInt32(b80.Substring(i, 4), 2), 16).ToUpper
            output &= str
        Next
        TextBox4.Text = output
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Dim output As String = TextBox4.Text
        Dim b80 As String = ""
        For i = 0 To Len(output) - 1
            Dim c = output(i)
            b80 &= Convert.ToString(Convert.ToInt32(c, 16), 2).ToString.PadLeft(4, "0")
        Next
        TextBox3.Text = "09" & Convert.ToInt32(b80.Substring(0, 27), 2)
        If b80.Substring(27, 3) = "000" Then
            ComboBox2.Text = "博士"
        Else
            ComboBox2.Text = "未知"
        End If
        If b80.Substring(30, 1) = "0" Then
            ComboBox1.Text = "未婚"
        Else
            ComboBox1.Text = "已婚"
        End If
        TextBox2.Text &= Convert.ToInt32(b80.Substring(31, 7), 2) + 1900
        TextBox2.Text &= Convert.ToInt32(b80.Substring(38, 4), 2).ToString.PadLeft(2, "0")
        TextBox2.Text &= Convert.ToInt32(b80.Substring(42, 5), 2).ToString.PadLeft(2, "0")
        TextBox1.Text &= Chr(Convert.ToInt32(b80.Substring(47, 5), 2) + 65) & IIf(b80.Substring(52, 1) = "0", "1", "2") & Convert.ToInt32(b80.Substring(53), 2)
    End Sub
End Class