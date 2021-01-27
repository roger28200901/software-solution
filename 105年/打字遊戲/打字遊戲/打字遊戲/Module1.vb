Imports System.Threading
Module Module1

    Sub Main()
        Dim datas(,) As String
        Dim over As Boolean = False
        Dim c As Boolean = False
        Dim counter As Integer = 0
        Dim x = 1
        Dim y = 1
        Dim max = 25
        ReDim datas(25, 25)
        Dim ch = "a"
        initArray(datas)
        datas(x, y) = ch

        Console.Write("開始遊戲請按1:")
        If Console.ReadLine() = "1" Then c = True
        Do While (c)

            If counter Mod 100 = 0 AndAlso counter <> 0 Then
                counter = 0
                datas(x, y) = "-"
                y += 1
                If y > 25 Then
                    y = 1
                    x += 1
                    If x > 25 Then c = False
                    datas(x, y) = ch
                Else
                    datas(x, y) = ch
                End If
            End If
            Console.Clear()
            drawDatas(datas)

            counter += 100
            ''read char
            Thread.Sleep(100)
        Loop
        Console.Write("Game Over")
    End Sub
    Function drawDatas(ByVal datas(,) As String)
        For y = 1 To UBound(datas)
            For x = 1 To UBound(datas)
                Console.Write(datas(x, y))
            Next
            Console.WriteLine()
        Next
    End Function
    Function initArray(ByVal datas(,) As String)
        For i = 0 To UBound(datas)
            For j = 0 To UBound(datas)
                datas(i, j) = "-"
            Next
        Next
    End Function
End Module
