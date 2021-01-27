Module Module1

    Sub Main()
        Console.WriteLine("日期系列:")
        Dim x = Console.ReadLine().Split(" ")
        Console.WriteLine("價格系列:")
        Dim y = Console.ReadLine().Split(" ")

        Console.WriteLine("直線斜率b:")

        For n = 1 To x.Length
            If n <= 9 Then
                Console.Write("0.0" & " ".PadLeft(4, " "))
            Else
                Dim from = n - 10

                Dim xBar As Double = sum(n - 1, x, from) / 10
                Dim yBar As Double = sum(n - 1, y, from) / 10
                Dim b As Double = sum2(n - 1, x, y, xBar, yBar, from)



                Console.Write(Format(b, "0.0") & " ".PadLeft(4, " "))
            End If
        Next
        Console.WriteLine()
        Dim price As New Queue
        price.Enqueue(0)
        For n = 1 To y.Length
            If n <= 9 Then
                Dim b As Double = 0
                price.Enqueue(0)
            Else
                Dim from = n - 10
                Dim xBar As Double = sum(n - 1, x, from) / 10
                Dim yBar As Double = sum(n - 1, y, from) / 10

                Dim b As Double = sum2(n - 1, x, y, xBar, yBar, from)
                Dim a As Double = yBar - b * xBar
                Dim yt As Double = a + b * (n + 1)
                price.Enqueue(yt)
            End If
        Next
        Console.WriteLine("價格預測:")
        For i = 0 To price.Count - 2
            Console.Write(Format(price(i), "0.0") & " ".PadLeft(4, " "))
        Next
        Console.ReadKey()

    End Sub
    Function sum(ByVal n As Integer, ByVal xy As Array, ByVal from As Integer)
        Dim value As Double = 0
        For i = from To n
            value += Val(xy(i))
        Next
        Return value
    End Function
    Function sum2(ByVal n As Integer, ByVal x As Array, ByVal y As Array, ByVal xBar As Double, ByVal yBar As Double, ByVal from As Integer)
        Dim value As Double = 0
        Dim up As Double = 0
        Dim down As Double = 0
        For i = from To n
            Dim dx = (Val(x(i)) - xBar)
            Dim dy = (Val(y(i)) - yBar)
            up += dx * dy
            down += (dx * dx)
        Next
        value = up / down
        Return value
    End Function

End Module
