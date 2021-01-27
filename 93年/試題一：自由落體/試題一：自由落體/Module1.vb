Module Module1

    Sub Main()
S:
        Console.WriteLine("請輸入H D")
        Dim input = Console.ReadLine().Split(" ")
        Dim H = Val(input(0))
        Dim D = Val(input(1))

        Dim Hprime As New Queue
        Hprime.Enqueue(H)
        Do While H \ 2 - D / 5 > 0
            Dim tempH = H \ 2 - D / 5
            H = tempH
            Hprime.Enqueue(tempH)
        Loop
        Hprime.Enqueue(0)
        Dim Count As Integer = Hprime.Count - 2
        Console.WriteLine(String.Join(" ", Hprime.ToArray) & " " & Count)
        Console.WriteLine("繼續請按1")

        If Console.ReadLine() = "1" Then
            GoTo S
        End If

    End Sub

End Module
