Module Module1
    Dim datas()
    Dim max = -1
    Dim ans As New Stack
    Sub Main()

        Dim test = Console.ReadLine()
        ReDim datas(test)

        Do While test > 0
            test -= 1

            Dim n = Console.ReadLine()

            Dim map(n, n)
            Dim counter = 0
            'read map
            Do While n > 0
                counter += 1
                Dim x, y As Integer
                Dim txt = Console.ReadLine()
                Dim temp = txt.Split(" ")
                x = counter
                For y = 1 To temp.Count
                    map(y, x) = temp(y - 1)
                Next
                n -= 1
            Loop

            Dim br = (map.Length ^ (1 / 2)) - 1
            max = -1
            Dim s As New Stack
            Dim returnValue = 0
            s.Push(map(1, 1).ToString)
            For x = 1 To br
                For y = 1 To br
                    Call search(s, br, x, y, map)
                Next
            Next
            ans.Push(max)
        Loop

        For i = 0 To ans.Count - 1
            Console.WriteLine(ans(i))
        Next
        Console.ReadKey()

    End Sub
    Public Function search(ByVal s As Stack, ByVal br As Integer, ByVal x As Integer, ByVal y As Integer, ByVal map As Array)

        Dim run As Boolean = False
        If x < br Then
            If s.Contains(map(x + 1, y)) = False Then
                s.Push(map(x + 1, y))
                search(s, br, x + 1, y, map)
                run = True
            End If
        End If
        If x > 1 Then
            If s.Contains(map(x - 1, y)) = False Then
                s.Push(map(x - 1, y))
                search(s, br, x - 1, y, map)
                run = True
            End If
        End If
        If y < br Then
            If s.Contains(map(x, y + 1)) = False Then
                s.Push(map(x, y + 1))
                search(s, br, x, y + 1, map)
                run = True
            End If
        End If
        If y > 1 Then
            If s.Contains(map(x, y - 1)) = False Then
                s.Push(map(x, y - 1))
                search(s, br, x, y - 1, map)
                run = True
            End If
        End If
        If run = False Then
            If s.Count > max Then
                max = s.Count
            End If
        End If


    End Function
End Module
