Module Module1

    Sub Main()
S:
        Console.WriteLine("請輸入：W R C")
        Dim input = Console.ReadLine().Split(" ")
        Dim W = Val(input(0))
        Dim R = Val(input(1))
        Dim C = input(2)
        Dim dictionary As New Dictionary(Of String, Decimal)
        '彈性做法
        dictionary.Add("G", 10 ^ 9)
        dictionary.Add("M", 10 ^ 6)
        dictionary.Add("k", 10 ^ 3)
        dictionary.Add("m", 10 ^ -3)
        dictionary.Add("u", 10 ^ -6)
        dictionary.Add("n", 10 ^ -9)
        dictionary.Add("p", 10 ^ -12)

        For Each item In dictionary
            Dim index = item.Key
            Dim value = item.Value
            If C.Contains(index) = True Then
                C = C.Replace(index, "")
                C = Val(C)
                C *= value
            End If
        Next

        If W < 0 Then
            Console.WriteLine("W必須>=0")
            GoTo S
        End If
        If R < 200 Then
            Console.WriteLine("R必須>=200")
            GoTo S
        End If
        If C < 0.4 * 10 ^ -12 Then
            Console.WriteLine("C必須>=0.4p")
            GoTo S
        End If
        Dim Ro As Decimal = 350 : Dim CL As Decimal = 0.2 * (10 ^ -12)
        Dim TD As Decimal = 0 : Dim CB As Decimal = 0.04 * (10 ^ -12)
        Dim TB As Decimal = 350 * 10 ^ -12 : Dim RB As Decimal = 350
        If W = 0 Then
            TD = (Ro + R) * (C + CL)
        Else
            TD = (Ro + R / 2) * (C / 2 + W * CB) + TB + (RB / W + R / 2) * (C / 2 + CL)
        End If
        TD *= 10 ^ 12
        Console.WriteLine("輸出：" & TD & "ps")
        Console.WriteLine("繼續請按1")
        If Console.ReadLine() = "1" Then
            GoTo S
        End If
    End Sub

End Module
