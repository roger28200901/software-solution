Module Module1

    Sub Main()
        Dim dic As New Dictionary(Of String, Integer)


        Console.Write("輸入：")
        Dim inputStr = Console.ReadLine()
        For i = 0 To inputStr.Length - 1

            If dic.ContainsKey(inputStr(i)) = False Then
                dic.Add(inputStr(i), 1)
            Else
                dic(inputStr(i)) += 1
            End If

        Next
        'sort
        Dim sort(1, dic.Count)
        Dim sortCount = 1
        For Each item In dic
            sort(0, sortCount) = item.Key
            sort(1, sortCount) = item.Value
            sortCount += 1
        Next

        For i = 1 To sortCount - 1
            For j = i To sortCount - 1
                If sort(1, i) > sort(1, j) Then
                    Dim temp1 = sort(1, j)
                    sort(1, j) = sort(1, i)
                    sort(1, i) = temp1
                    Dim temp2 = sort(0, j)
                    sort(0, j) = sort(0, i)
                    sort(0, i) = temp2
                End If
            Next
        Next
        dic.Clear()

        For i = sortCount - 1 To 1 Step -1
            dic.Add(sort(0, i), sort(1, i))
        Next

        Console.Write("輸出：")
        Dim count = 1
        For Each item In dic
            Dim str As String = ""
            If count = dic.Count Then
                str = Chr(34) & item.Key & Chr(34) & "=" & item.Value
            Else
                str = Chr(34) & item.Key & Chr(34) & "=" & item.Value & ";"
            End If
            Console.Write(str)
            If count Mod 7 = 0 Then
                Console.WriteLine()
                Console.Write("　　　")
            End If
            count += 1
        Next
        Console.ReadKey()

    End Sub

End Module
