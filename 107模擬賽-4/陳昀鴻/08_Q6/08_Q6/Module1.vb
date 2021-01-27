Module Module1

    Sub Main()
        Dim base32 As Array = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "2", "3", "4", "5", "6", "7", "8", "9"}
        Console.WriteLine("請輸入：")
        Dim str = Console.ReadLine()
        Dim encode As String = ""
        For i = 0 To Len(str) - 1
            Dim c As String = str(i)
            Dim a = Asc(c)
            encode &= Convert.ToString(a, 2).PadLeft(8, "0")
        Next
        Dim n = (encode.Length / 5)
        If encode.Length Mod 5 <> 0 Then
            n += 1
        End If
        Dim decode As String = ""
        For i = 1 To n
            Dim s = Mid(encode, 1 + (i - 1) * 5, 5).PadRight(5, "0")
            Dim value = Convert.ToInt32(s, 2)
            decode &= base32(value)
        Next

        Console.WriteLine("結果：" & decode)
        Console.ReadKey()

    End Sub

End Module
