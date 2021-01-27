Module Module1

    Sub Main()
S:
        Console.WriteLine("輸入格式：水費的度數（半形空一格）電費的度數")
        Dim input = Console.ReadLine()
        Dim degreeStr = input.Split(" ")
        Dim degree(UBound(degreeStr))
        Dim level As New Queue

        For i = 0 To 1
            degree(i) = Val(degreeStr(i))
        Next

        For i = 0 To 1
            If i = 0 Then '水費
                If degree(i) < 50 Then
                    level.Enqueue(1)
                ElseIf degree(i) >= 50 And degree(i) <= 100 Then
                    level.Enqueue(2)
                ElseIf degree(i) > 100 Then
                    level.Enqueue(3)
                End If
            Else ' 電費
                If degree(i) < 100 Then
                    level.Enqueue(1)
                ElseIf degree(i) >= 100 And degree(i) <= 200 Then
                    level.Enqueue(2)
                ElseIf degree(i) > 200 Then
                    level.Enqueue(3)
                End If
            End If
        Next
        Dim waterLevel = level.Dequeue
        Dim electronicLevel = level.Dequeue
        Dim price As Integer = 0
        If waterLevel = 1 And electronicLevel = 1 Then
            price = 5 * ((degree(0) + degree(1)) / 2) * 0.6
        ElseIf (waterLevel = 1 And electronicLevel = 2) Or (electronicLevel = 1 And waterLevel = 1) = True Then
            price = 5 * ((degree(0) + degree(1)) / 2) * 0.8
        ElseIf waterLevel = 3 And electronicLevel = 3 Then
            price = 5 * ((degree(0) + degree(1)) / 2) * 1.4
        ElseIf (waterLevel = 2 And electronicLevel = 3) Or (electronicLevel = 2 And waterLevel = 3) = True Then
            price = 5 * ((degree(0) + degree(1)) / 2) * 1.2
        Else
            price = 5 * ((degree(0) + degree(1)) / 2)
        End If
        Console.WriteLine("輸出：" & price)
        Console.Write("繼續請按1：")
        Dim c = Console.ReadLine()

        If c = "1" Then
            GoTo S
        Else
            Exit Sub
        End If
    End Sub

End Module
