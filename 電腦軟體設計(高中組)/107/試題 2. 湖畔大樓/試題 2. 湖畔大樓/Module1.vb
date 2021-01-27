Module Module1
    Dim sequence As New List(Of String)
    Dim output As New List(Of Integer)
    Sub Main()
        FileOpen(1, "./test.txt", OpenMode.Input)
        Dim n As Integer = LineInput(1)
        For i = 1 To n
            Dim animalsNumber As Integer = LineInput(1)
            Dim datas
            Dim animals As New List(Of animal)
            '讀取所有動物
            For j = 1 To animalsNumber
                datas = LineInput(1).Split(" ")
                Dim obj As New animal(datas(0), datas(1))
                animals.Add(obj)
            Next

            '每一個動物都不同位置
            Dim strIndex As String = ""
            For x = 0 To n - 1
                strIndex &= x
            Next
            change(strIndex, "")

            Dim ansQ As New list(Of Integer)
            For r = 0 To sequence.Count - 1
                Dim str = sequence(r)
                Dim q As New Queue(Of animal)
                For m = 0 To Len(str) - 1
                    Dim index = Val(str(m))
                    q.Enqueue(animals(index))
                Next
                'A B C動物
                Dim ans As Integer = 0
                For k = 0 To q.Count - 1
                    Dim totalH As Integer = 0
                    For l = 0 To k
                        If l = k Then Exit For
                        totalH += q(l).liveHigh
                    Next
                    If totalH <= q(k).rangeHigh Then
                        ans += 1
                    End If
                Next
                ansQ.Add(ans)
            Next
            Dim max = ansQ.Max
            output.Add(max)
        Next
        Console.WriteLine(String.Join(vbNewLine, output.ToArray))
        Console.ReadKey()
    End Sub
    Function change(ByVal a As String, ByVal b As String)
        If a.Count = b.Count Then
            sequence.Add(b)
        End If
        For i = 1 To a.Count
            Dim word As Boolean = False
            For j = 1 To b.Count
                If Mid(b, j, 1) = Mid(a, i, 1) Then
                    word = True
                End If
            Next
            If word = False Then
                change(a, b & Mid(a, i, 1))
            End If
        Next
    End Function
End Module
Class animal
    Public liveHigh As Integer
    Public rangeHigh As Integer
    Public Sub New(ByVal i As Integer, ByVal j As Integer)
        Me.liveHigh = i
        Me.rangeHigh = j
    End Sub
End Class
