Module Module1

    Sub Main()
S:
        Console.WriteLine("輸入格式：")
        Console.Write("A(X1,Y1)=")
        Dim inputA = Console.ReadLine().Split(" ")
        Console.Write("B(X2,Y2)=")
        Dim inputB = Console.ReadLine().Split(" ")
        Console.Write("C(X3,Y3)=")
        Dim inputC = Console.ReadLine().Split(" ")
        Console.Write("D(X4,Y4)=")
        Dim inputD = Console.ReadLine().Split(" ")

        Dim line1 As line : Dim line2 As line

        line1.p1.x = inputA(0) : line1.p1.y = inputA(1)
        line1.p2.x = inputB(0) : line1.p2.y = inputB(1)

        line2.p1.x = inputC(0) : line2.p1.y = inputC(1)
        line2.p2.x = inputD(0) : line2.p2.y = inputD(1)

        If (line2.p1.x <= line1.p1.x And line2.p1.x >= line1.p2.x And line2.p1.y <= line1.p1.y And line2.p1.y >= line1.p2.y) Or
              (line2.p2.x <= line1.p1.x And line2.p2.x >= line1.p2.x And line2.p2.y <= line1.p1.y And line2.p2.y >= line1.p2.y) Then
            Console.WriteLine("輸出格式：線有交叉")
        Else
            Console.WriteLine("輸出格式：線無交叉")
        End If
        Console.Write("繼續請按1")
        If Console.ReadLine() = "1" Then GoTo S

    End Sub
    Public Structure point
        Public x As Integer
        Public y As Integer
    End Structure
    Public Structure line
        Public p1 As point
        Public p2 As point
    End Structure
End Module
