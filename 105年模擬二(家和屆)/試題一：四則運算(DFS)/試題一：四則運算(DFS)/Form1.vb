Public Class Form1
    Dim finalDeep As Integer
    Dim opsDFS As New Queue
    Dim ops = {"+", "-", "*", "/"}
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input = TextBox1.Text
        Dim datas = input.Split(" ")
        Dim ans = Val(TextBox2.Text)



        finalDeep = datas.Count - 1
        For i = 0 To 3
            opsDFS.Enqueue(DFS(New Stack, ops(i), 1))
        Next

        For Each item As Stack In opsDFS
            If IsNothing(item) Then Continue For
            Dim str = ""
            For i = 0 To UBound(datas)
                Dim opplus = ""
                If item.Count <> 0 Then
                    opplus = item.Pop
                End If
                str &= datas(i) & opplus
            Next
            If checkAnswer(str, ans) = True Then
                Label3.Text = "運算式結果：" & str & "=" & ans
                Exit For
            Else
                Label3.Text = "NO EXPRESSION"
            End If
        Next


    End Sub
    Private Function checkAnswer(ByVal str As String, ByVal ans As Integer)
        Dim ob = CreateObject("ScriptControl")
        ob.language = "VBScript"
        Dim val = ob.eval(str)
        If val = ans Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function DFS(ByVal s As Stack, ByVal op As String, ByVal deep As Integer)
        s.Push(op)
        If deep = finalDeep Then
            Dim temp As New Stack
            temp = s.Clone
            opsDFS.Enqueue(temp)
            s.Pop()
            Return False
        End If

        For i = 0 To 3
            DFS(s, ops(i), deep + 1)
        Next
        s.Pop()


    End Function
End Class
