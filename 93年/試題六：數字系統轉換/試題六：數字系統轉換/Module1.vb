Module Module1
    Dim base16 = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"}
    Dim er As Boolean = False
    Sub Main()
S:
        Console.WriteLine("1.輸入基底：")
        Dim base = Val(Console.ReadLine())
        Console.WriteLine("2.輸入數值：")
        Dim value = Console.ReadLine
        inputError(base, value)
        If er = True Then
            er = False
            GoTo S
        End If

        Dim output = numberSystem(value, base)
        Console.WriteLine("輸出：" & output)
        Console.Write("繼續請按1")
        If Console.ReadLine() = "1" Then
            GoTo S
        End If

    End Sub
    Private Function numberSystem(ByVal s As String, ByVal b As Integer)
        Dim out As Integer
        Dim count As Integer = 0
        Dim k As Decimal
        For i = Len(s) - 1 To 0 Step -1
            Dim ch = s(i)
            Dim c As Integer

            Dim index As Integer = 0
                For Each item In base16
                    Dim value = index
                    If item = ch Then
                        c = value
                        Exit For
                    End If
                    index += 1
                Next

            k += Val(c) * b ^ count
            count += 1
        Next
        Return k
    End Function
    Private Sub inputError(ByVal base As Integer, ByVal value As String)

        Dim findEr As Boolean = False
        For i = 0 To Len(value) - 1
            findEr = False
            Dim c = value(i)
            For j = 0 To base - 1
                Dim c2 As Char = base16(j)
                If c = c2 Then
                    findEr = False
                    Exit For
                Else
                    findEr = True
                End If
            Next
            If findEr = True Then
                Console.WriteLine("輸入錯誤")
                er = True
                Exit Sub
            End If
        Next

    End Sub
End Module
