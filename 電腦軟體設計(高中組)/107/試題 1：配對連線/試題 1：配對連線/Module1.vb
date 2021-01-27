Module Module1
    Dim q As New Queue(Of Integer)

    Dim ans As Integer = 0
    Sub Main()
        Console.WriteLine("請輸入n")
        Dim N As Integer = Console.ReadLine()
        q.Enqueue(0)
        N = N * 2
        For i = 1 To N
            q.Enqueue(i)
        Next

        solve(N)
        Console.WriteLine("輸出：" & ans)
        Console.ReadKey()


    End Sub
    Private Sub solve(ByVal N As Integer)
        Dim visit As New List(Of Integer)

        If N = 2 Or N = 0 Then
            ans += 1
            Exit Sub
        End If
        For w = 1 To N
            For m = 1 To N
                If w = m Or (visit.Contains(w) = True And visit.Contains(m) = True) Then Continue For
                Dim delta = Math.Abs(m - w - 1)
                Dim delta2 = N - Math.Abs(m + w - 1)
                If delta Mod 2 <> 0 Or delta2 Mod 2 <> 0 Then
                    Exit For
                Else
                    visit.Add(m) : visit.Add(w)
                    Dim newN As Integer = delta
                    Dim newN2 As Integer = delta2
                    If newN = 0 And newN2 = 0 Then
                        solve(newN)
                    Else
                        solve(newN)
                        solve(newN2)
                    End If


                End If
            Next
        Next
    End Sub
End Module
