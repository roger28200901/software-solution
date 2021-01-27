Module Module1
    Dim sequence()
    Dim uplimit()
    Dim centerlimit()
    Dim lowlimit()
    Dim dataSequence()
    Dim sumclose As Double = 0
    Sub Main()
S:
        Console.WriteLine("請選擇操作項目：")
        Console.WriteLine("     <1>輸入模型資料：")
        Console.WriteLine("     <2>計算平均相似度：")
        Console.WriteLine("     <3>顯示各資料相似度：")
        Console.Write("請選擇：")
        Dim s As Integer = Console.ReadLine()
        Select Case s
            Case 1
                Console.Write("輸入模型資料，總筆數為：")
                Dim n As Integer = Val(Console.ReadLine())
                ReDim sequence(n - 1)
                ReDim uplimit(n - 1)
                ReDim centerlimit(n - 1)
                ReDim lowlimit(n - 1)

                Console.Write("　　序列(x軸):")
                Dim t1 = Console.ReadLine()
                sequence = t1.Split(" ")
                Console.Write("數值串列(上限):")
                Dim t2 = Console.ReadLine()
                uplimit = t2.Split(" ")
                Console.Write("數值串列(中心):")
                Dim t3 = Console.ReadLine()
                centerlimit = t3.Split(" ")
                Console.Write("數值串列(下限):")
                Dim t4 = Console.ReadLine()
                lowlimit = t4.Split(" ")
            Case 2
                Console.Write("請輸入「資料串列」檔名:")
                Dim searchFileName = Console.ReadLine()
                sumclose = 0
                If My.Computer.FileSystem.FileExists(searchFileName) = False Then
                    Console.WriteLine("並無此檔案，請重新再試。")
                    GoTo S
                Else
                    Dim txt = My.Computer.FileSystem.ReadAllText(searchFileName, System.Text.Encoding.Default)
                    dataSequence = txt.Split(" ")
                    For i = 0 To UBound(dataSequence)
                        Dim v1 = Val(uplimit(i))
                        Dim v2 = Val(centerlimit(i))
                        Dim v3 = Val(lowlimit(i))
                        Dim close As Double = 0
                        If Val(dataSequence(i)) < v3 Or Val(dataSequence(i)) > v1 Then
                            close = 0
                        Else
                            '資料 小於 中間
                            If Val(dataSequence(i)) < v2 Then
                                sumclose += (Val(dataSequence(i)) - v3) / (v2 - v3)
                            Else
                                sumclose += (1 - ((Val(dataSequence(i)) - v2)) / (v1 - v2))
                            End If
                        End If


                    Next
                    sumclose /= dataSequence.Length

                    Console.WriteLine("平均相似度為：" & Format(sumclose, "0.000000"))
                End If
            Case 3

        End Select

        Console.Write("繼續:請按1，結束:請按0:")
        Dim read = Console.ReadLine()
        If read = 1 Then
            GoTo S
        Else
            Exit Sub
        End If
    End Sub

End Module
