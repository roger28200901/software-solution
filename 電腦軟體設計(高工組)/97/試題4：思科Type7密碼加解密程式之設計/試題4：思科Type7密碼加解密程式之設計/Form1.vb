Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim P As New List(Of Char)
        Dim t1 = TextBox1.Text
        If Len(t1) > 10 Then
            MsgBox("n<=10")
            Exit Sub
        End If


        For j = 0 To Len(t1) - 1
            P.Add(t1(j))
        Next
        Dim I = Int(TextBox2.Text)
        If I > 15 Or I < 0 Then
            MsgBox("Seed(0-15)")
            Exit Sub
        End If
        Dim encodeStr As String = ""
        encodeStr &= I.ToString.PadLeft(2, "0")
        Dim Seed() = {"64", "73", "66", "64", "3b", "6b", "66", "6f", "41", "2c", "2e", "69", "79",
"65", "77", "72", "6b", "6c", "64", "4a", "4b", "44", "48", "53", "55", "42"}

        Dim n As Integer = P.Count
        For j = 0 To n - 1
            Dim v1 = Convert.ToInt32(Seed(I), 16)
            Dim v2 = Asc(P(j))
            encodeStr &= Convert.ToString((v1 Xor v2), 16).ToUpper.PadLeft(2, "0")
            I += 1
        Next
        TextBox3.Text = encodeStr
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim encodeStr = TextBox3.Text
        Dim decodeStr As String = ""
        Dim Seed() = {"64", "73", "66", "64", "3b", "6b", "66", "6f", "41", "2c", "2e", "69", "79",
"65", "77", "72", "6b", "6c", "64", "4a", "4b", "44", "48", "53", "55", "42"}


        Dim I As Integer = 0
        Dim J As Integer = 1

        Dim strTwo = encodeStr.Substring(0, 2)
        I = CInt(strTwo)

        Dim n = encodeStr.Length \ 2

        For n = 2 To encodeStr.Length - 1 Step 2
            Dim xorValue = Convert.ToInt32(encodeStr.Substring(n, 2), 16)
            Dim v1 = Convert.ToInt32(Seed(I),16)
            Dim v2 = Convert.ToInt32(v1 Xor xorValue)
            Dim c = Chr(v2)
            decodeStr &= c
            I += 1
        Next
        If decodeStr = TextBox1.Text Then
            Label5.Text = decodeStr
        Else
            Label5.Text = "輸入值有誤"
        End If
    End Sub
End Class
