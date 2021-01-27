Module Module1

    Sub Main()
S:
        Console.Write("輸入格式：")
        Dim R = Val(Console.ReadLine())
        Dim l As New List(Of point)
        Dim X = 1 : Dim Y = 1
        Do Until X ^ 2 > R
            Y = 1
            Dim sum As Integer = 0

            Do Until Y ^ 2 > R
                sum = X ^ 2 + Y ^ 2
                If sum = R Then
                    Dim p As point = New point(X, Y)
                    l.Add(p)
                End If
                Y += 1
            Loop
            X += 1
        Loop
        Console.WriteLine("count　Ｘ　Ｙ")
        For i = 0 To l.Count - 1
            Console.WriteLine("　" & (i + 1) & "　" & l(i).x & "　" & l(i).y)
        Next
        If l.Count <> 0 Then
            Console.WriteLine("There are " & l.Count & "  possible answers")
        Else
            Console.WriteLine()
            Console.WriteLine("Sorry,No answer found")
        End If
        Console.Write("繼續請按1：")
        If Console.ReadLine() = "1" Then
            GoTo S
        End If
    End Sub
    Class point
        Public x As Integer
        Public y As Integer
        Public Sub New(ByVal xx As Integer, ByVal yy As Integer)
            Me.x = xx
            Me.y = yy
        End Sub
    End Class
End Module
