Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a, b, c
        a = TextBox1.Text
        b = InStr(a, "/")
        c = Mid(a, b + 1, Len(a) - b)

        c = Val(c) '/ 後
        a = Mid(a, 1, b - 1) '/ 前 
        '''''以上學長的想法

        Dim IpAdress() As String = Split(a, ".")
        Dim data2() = Split(a, ".")


        '網路位址
        Dim IpAdressString As String
        For i = 0 To UBound(IpAdress)
            IpAdressString &= Convert.ToString(Int32.Parse(IpAdress(i)), 2).PadLeft(8, "0")
        Next

        Dim temp As String

        For i = 1 To c
            temp &= Mid(IpAdressString, i, 1)
        Next
        temp = temp.PadRight(32, "0")

        Dim t As String
        For j = 0 To 3
            For q = 1 To 8
                t &= Mid(temp, q + j * 8, 1)
            Next
            t = binaryToDecimal(t)
            IpAdress(j) = t
            t = ""
        Next
        TextBox2.Text = Join(IpAdress, ".")


        '廣播位址
        Dim m As String
        For z = c To IpAdressString.Length
            m &= Mid(IpAdressString, z + 1, 1)
        Next

        Dim broadcastAdressString As String
        For z = 1 To m.Length
            Dim ch As String = Mid(m, z, 1)
            If ch = "0" Then ch = 1
            broadcastAdressString &= ch
        Next
        broadcastAdressString = broadcastAdressString.PadLeft(32, "0")


        Dim broadcastAdress() As String
        ReDim broadcastAdress(3)
        Dim ts As String
        For x = 0 To 3
            For y = 1 To 8
                ts &= Mid(broadcastAdressString, y + x * 8, 1)
            Next
            ts = binaryToDecimal(ts)
            broadcastAdress(x) = ts
            ts = ""
            Dim byte1 As Byte = broadcastAdress(x)
            Dim byte2 As Byte = IpAdress(x)
            broadcastAdress(x) = byte1 Or byte2

        Next
        TextBox3.Text = String.Join(".", broadcastAdress)

        Dim ips As String = Math.Pow(2, (IpAdressString.Length - c)) - 2

        TextBox4.Text = ips


    End Sub
    Private Function binaryToDecimal(ByVal b As String) As String
        Dim times = 0
        Dim t As Integer
        For i = b.Length To 1 Step -1
            t += Mid(b, i, 1) * Math.Pow(2, times)
            times += 1
        Next

        Return t
    End Function
End Class
