Module Module1

    Sub Main()
        Console.WriteLine("輸入電阻值R，單位為歐姆=")
        Dim R As Decimal = Convert.ToDecimal(Console.ReadLine())
        Console.WriteLine("輸入電容值C，單位為法拉=")
        Dim C As Decimal = Convert.ToDecimal(Console.ReadLine())
        Console.WriteLine("輸入頻率值f，單位為赫芝=")
        Dim f As Decimal = Convert.ToDecimal(Console.ReadLine())

        Dim vDelta = Math.Sqrt(1 ^ 2 / (1 + (2 * Math.PI * f * R * C) ^ 2))
        Dim z = Math.Round(20 * Math.Log10(Math.Abs(vDelta)), 3)
        Dim omega = 2 * Math.PI * f
        Dim Xc = 1 / Math.Sqrt((omega * C) ^ 2)
        'RC並聯 theta = 2 pi f r c -1
        Dim angle = Math.Round(-1 * Math.Atan2(R, Xc) * 180 / Math.PI, 3)
        Console.WriteLine("濾波器的大小Z={0}", z)
        Console.WriteLine("濾波器的相角θ={0}", angle)
        Console.ReadKey()
    End Sub

End Module
