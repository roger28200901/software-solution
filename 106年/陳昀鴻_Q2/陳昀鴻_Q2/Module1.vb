Module Module1

    Sub Main()
A:
        Console.Write("請輸入行程processes數量(MAX 5):")
        Dim n As Integer = Console.ReadLine()
        If n > 5 Then
            GoTo A
        End If

        Console.WriteLine("請輸入每個行程的執行時間burrst_time...")
        Dim burrst As New ArrayList

        For i = 1 To n
            Console.Write("P" & i & ":")
            burrst.Add(Val(Console.ReadLine()))
        Next
        Dim tsum As Integer = timesum(burrst)
        Console.WriteLine("請輸入時間配額(time_quantime)")
        Dim quantime = Console.ReadLine()

        Dim sequence As New Stack
        Dim sequenceCounter As New Stack



        Dim sum = timesum(burrst)
        Dim counter = 0
        Dim totaltime = 0
        Do Until sum = 0

            If burrst(counter) <= 0 Then
                counter += 1
                If counter >= n Then
                    counter = 0
                End If
                Continue Do
            Else '大於要扣除的時間
                burrst(counter) -= quantime
                Dim sc = quantime
                If burrst(counter) < 0 Then
                    sc += burrst(counter)
                    burrst(counter) = 0
                End If

                sequence.Push(counter)
                sequenceCounter.Push(sc)
            End If
            counter += 1
            If counter >= n Then
                counter = 0
            End If
            sum = timesum(burrst)
        Loop

        Console.WriteLine("各行程processes執行順序為")


        Dim z = 0
        For i = sequence.Count - 1 To 0 Step -1
            Dim rank = "P"
            Console.Write(Format(z, "00") & ":" & rank & (sequence(i) + 1) & " ")
            z += sequenceCounter(i)
        Next
        z -= sequence(0)
        If tsum - z <> quantime Then
            Console.Write(tsum)
        End If
        Console.WriteLine()

        Dim delayTime(n - 1)
        For i = 0 To n - 1
            Dim max = findIndexMax(sequence, i)
            Dim delay = delaySum(sequence, sequenceCounter, max, i)
            delayTime(i) = delay
        Next
        For j = 0 To UBound(delayTime)
            Console.Write("P" & (j + 1) & "等待時間:" & delayTime(j) & " ")
        Next

        Console.ReadKey()

    End Sub
    Function timesum(ByVal burrst As ArrayList)
        Dim sum As Integer
        For i = 0 To burrst.Count - 1
            sum += burrst(i)
        Next
        Return sum
    End Function
    Function findIndexMax(ByVal sequence As Stack, ByVal i As Integer)
        For x = 0 To sequence.Count - 1
            If sequence(x) = i Then
                Return x
            End If
        Next
    End Function
    Function delaySum(ByVal sequence As Stack, ByVal sequenceCounter As Stack, ByVal max As Integer, ByVal x As Integer)
        Dim sumtime = 0
        For y = sequence.Count - 1 To max Step -1
            If sequence(y) = sequence(max) Then
                Continue For
            Else
                sumtime += sequenceCounter(y)
            End If
        Next
        Return sumtime
    End Function
End Module
