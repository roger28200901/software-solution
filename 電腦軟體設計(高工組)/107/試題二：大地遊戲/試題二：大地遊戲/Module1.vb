Module Module1

    Sub Main()
S:
        Console.WriteLine("請輸入N人數：")
        Dim n As Integer = Console.ReadLine
        If n < 1 And n > 100 Then
            Console.WriteLine("N請介於1~100")
            GoTo S
        End If
        Console.WriteLine("請輸入M人數：")
        Dim m As Integer = Console.ReadLine
        If m < 1 And m > 100 Then
            Console.WriteLine("M請介於1~100")
            GoTo S
        End If
        Dim l As New List(Of Integer)
        Dim ansList As New List(Of Integer)
        For i = 1 To n
            l.Add(i)
        Next
        '   1 2 X 4 5 6 7 8 9 10
        'id:0 1 2 3 4 5 6 7 8 9 
        'm=3
        Dim counter As Integer = m
        Dim index As Integer = 0

        Do Until l.Count = 1

            index = index + m - 1
            If index > l.Count - 1 Then
                index = -1 + index - (l.Count - 1)
            End If
            If l.Count = 2 And index > l.Count - 1 Then
                index = index Mod 2
            End If
            Dim item = l(index)
            ansList.Add(item)
            l.RemoveAt(index)

        Loop
        Console.WriteLine("淘汰順序：" & String.Join(" ", ansList.ToArray))
        Console.WriteLine("最後贏家：" & l(0))
        Console.ReadKey()

    End Sub

End Module
