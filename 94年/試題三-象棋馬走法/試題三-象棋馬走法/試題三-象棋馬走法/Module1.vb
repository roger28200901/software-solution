Imports System

Module Module1
    Public Structure point
        Dim x As Double, y As Double

        Sub New(ByVal x As Double, ByVal y As Double)
            Me.x = x
            Me.y = y
        End Sub

    End Structure
    Dim puz(9, 9) As Integer
    Dim horse As point
    Sub Main()
        Console.Write("馬目前位置與一些障礙物:")
        Dim a As String() = Split(Console.ReadLine(), " ")
        horse = New point(a(0), a(1))
        For i = 2 To a.Length - 1 Step 2
            puz(a(i), a(i + 1)) = 1
        Next
        drawMap()
        Console.Write("輸入移動數字鍵:" & vbTab)
        Dim input As Integer = Val(Console.ReadLine())
        While input <> 9
            Dim st As Integer = tryMove(input)
            drawMap()
            Dim s As String = "馬移動到新位置:" & vbTab & horse.x & " " & horse.y & vbTab
            If st = 0 Then
                Console.WriteLine(s)
            ElseIf st = 1 Then
                Console.WriteLine(s & "(因超出棋盤外而保持原座標)")
            ElseIf st = 2 Then
                Console.WriteLine(s & "(因馬腳捆住而保持原座標)")
            End If

            Console.Write("輸入移動數字鍵:" & vbTab)
            input = Val(Console.ReadLine())
        End While
    End Sub
    Function tryMove(ByVal type As Integer) As Integer
        '0 = ok 1 = overRange 2 = 被擋住

        Dim moveX As Integer = horse.x
        Dim moveY As Integer = horse.y


        'first
        Select Case type
            Case 0, 1
                moveY += 1
            Case 2, 3
                moveX -= 1
            Case 4, 5
                moveY -= 1
            Case 6, 7
                moveX += 1
        End Select
        If moveX > 8 OrElse moveX < 1 OrElse moveY > 8 OrElse moveY < 1 Then
            Return 1
        End If
        
        If puz(moveX, moveY) = 1 Then
            Return 2
        End If

        'second
        Select Case type
            Case 0, 1
                moveY += 1
            Case 2, 3
                moveX -= 1
            Case 4, 5
                moveY -= 1
            Case 6, 7
                moveX += 1
        End Select
        If moveX > 8 OrElse moveX < 1 OrElse moveY > 8 OrElse moveY < 1 Then
            Return 1
        End If

        'third
        Select Case type
            Case 0, 5
                moveX += 1
            Case 1, 4
                moveX -= 1
            Case 2, 7
                moveY += 1
            Case 3, 6
                moveY -= 1
        End Select
        If moveX > 8 OrElse moveX < 1 OrElse moveY > 8 OrElse moveY < 1 Then
            Return 1
        End If
        puz(moveX, moveY) = 0
        horse = New point(moveX, moveY)
        Return 0
    End Function
    Function drawMap()
        For i = 0 To UBound(puz)
            For j = 0 To UBound(puz)
                If i = 0 Or i = UBound(puz) Or j = UBound(puz) Or j = 0 Then
                    Console.Write("|")
                    Continue For
                End If
                If puz(i, j) = "1" Then
                    Console.Write("&")
                    Continue For
                End If
                If i = horse.x AndAlso j = horse.y Then
                    Console.Write("H")
                    Continue For
                End If
                Console.Write(" ")
            Next
            Console.WriteLine()
        Next
    End Function
End Module
