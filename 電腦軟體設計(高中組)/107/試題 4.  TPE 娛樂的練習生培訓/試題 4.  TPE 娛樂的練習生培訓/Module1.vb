Module Module1

    Sub Main()
        Console.WriteLine("請輸入：(N M T)")
        Dim line = Console.ReadLine()
        Dim datas = line.Split(" ")
        Dim N = datas(0) : Dim M = datas(1) : Dim T = datas(2)
        Dim V = C(N, M)
        Console.WriteLine(V * T)
        Console.ReadKey()

    End Sub
    Function C(ByVal n As Integer, ByVal k As Integer)
        Dim value As Integer = 0
        Dim Nfactorial = factorial(n)
        Dim Kfactorial = factorial(k)
        Dim NminusKfactorial = factorial(n - k)
        value = Nfactorial / (Kfactorial * NminusKfactorial)
        Return value
    End Function
    Function factorial(ByVal n As Integer)
        If n = 1 Then
            Return 1
        End If
        Return n * factorial(n - 1)
    End Function
End Module
