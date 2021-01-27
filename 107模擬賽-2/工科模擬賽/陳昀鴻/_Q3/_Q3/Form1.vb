Public Class Form1
    Dim op = {"+", "-", "*", "/"}
    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim txt = TextBox1.Text
        Dim figure
        Dim ans = Val(TextBox2.Text)
        Dim datas = txt.Split(" ")
        Dim ops = {"+", "-", "*", "/"}
        Dim qe As New Queue

        Dim n = datas.Count - 1

        For i = 0 To UBound(datas)
            qe.Enqueue(datas(i))
        Next
        'abc


        '總共兩個運算元
        Dim st As New Stack
        '搭配的陣列
        Dim pk(n, 4)

        '跑兩次
        Dim c As Integer = 0
        For q = 1 To 4
            For i = 1 To n
                For j = 1 To 4
                    If i = 1 Then
                        pk(i, j) = ops(c)
                    Else
                        pk(i, j) = ops(j - 1)
                    End If
                Next
            Next


            For y = 1 To 4
                Dim opp As New Stack
                For x = 1 To n


                    For z = 1 To n
                        opp.Push(pk(x, z))
                    Next
                    Dim sss As New Queue
                    Dim qeq = qe.Clone
                    Do Until qeq.Count = 0
                        sss.Enqueue(qeq.Dequeue)
                    Loop
                    Do While opp.Count > 0 Or sss.Count > 1
                        Select Case opp.Peek()
                            Case "+"
                                Dim n1 As Integer = sss.Dequeue()
                                Dim n2 As Integer = sss.Dequeue()
                                Dim sum = n1 + n2
                                sss.Enqueue(sum)
                            Case "-"
                                Dim n1 As Integer = sss.Dequeue()
                                Dim n2 As Integer = sss.Dequeue()
                                Dim sum = n1 - n2
                                sss.Enqueue(sum)
                            Case "*"
                                Dim n1 As Integer = sss.Dequeue()
                                Dim n2 As Integer = sss.Dequeue()
                                Dim sum = n1 * n2
                                sss.Enqueue(sum)
                            Case "/"
                                Dim n1 As Integer = sss.Dequeue()
                                Dim n2 As Integer = sss.Dequeue()
                                Dim sum = n1 / n2
                                sss.Enqueue(sum)
                        End Select
                        opp.Pop()
                    Loop






                Next
            Next


            c += 1
        Next







    End Sub

End Class
