Module Module1

    Sub Main()

        Console.Write("請輸入逕向距離(r)=")
        Dim r As Double = Val(Console.ReadLine())

        Dim n As Double = -1
        Do While n < 0
            Console.Write("請輸入逕向多項式的次數距離(n)=")
            n = Val(Console.ReadLine())
            If n < 0 Then
                Console.WriteLine("請輸入一個非負整數")
            End If
        Loop
        Dim m As Integer = 0
        While m <= n
            If (n - Math.Abs(m)) Mod 2 = 0 AndAlso Math.Abs(m) <= n Then
                Console.WriteLine("計算逕向多項式(radial polynomials) ...,r={0},n={1},m={2}", r, n, m)
                Console.WriteLine("所求知逕向多項式為 = {0}", _R(r, n, m))
            End If
            m += 1
        End While

        Console.WriteLine("計算完畢")
        Console.Write("請按任意鍵繼續")
        Console.ReadKey()


    End Sub
    ' N! = n * (n-1)
    '3! = 3*2

    Function factor(ByVal n As Integer) As Decimal
        Dim sum As Decimal = 1
        For i = 2 To n
            sum *= i
        Next
        Return sum
    End Function
    Function _R(ByVal r As Double, ByVal n As Double, ByVal m As Double)
        Dim sum As Decimal = 0
        For s = 0 To (n - Math.Abs(m)) / 2
            sum += (-1) ^ s * factor(n - s) * (r ^ (n - 2 * s)) /
                (factor(s) * factor((((n + Math.Abs(m)) / 2) - s)) * factor((((n - Math.Abs(m)) / 2) - s)))
        Next
        Return sum
    End Function
End Module
