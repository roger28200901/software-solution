Module Module1

    Sub Main()
S:
        Console.WriteLine("某通訊公司提供以下三種計費方案：")
        Console.WriteLine("　實用商務型：月租費600元(不可抵通話費)，以分計算，每分鐘5元")
        Console.WriteLine("　超值經濟型：月租費200元(可抵通話費)，以秒計算，每秒0.15元")
        Console.WriteLine("　精算得利型：月租費66元(可抵通話費)，以秒計算，再送300秒免費秒數，每秒0.2元")

        Console.Write("輸入格式：計費代碼(半形空一個)總通話分鐘數：")
        Dim input = Console.ReadLine().Split(" ")

        Dim chooseCase = input(0)
        Dim min = input(1)
        Dim price As Decimal
        Select Case chooseCase
            Case 1
                price = 5 * min + 600
                If price < 600 Then
                    price = 600
                End If
            Case 2
                price = 0.15 * min * 60 - 200
                If price < 200 Then
                    price = 200
                End If
            Case 3
                price = 0.2 * (min * 60 - 300) - 66
                If price < 66 Then
                    price = 66
                End If
        End Select
        Console.WriteLine("輸出：" & price)
        Console.WriteLine("繼續請按1")
        If Console.ReadLine() = "1" Then
            GoTo S
        End If
    End Sub

End Module
