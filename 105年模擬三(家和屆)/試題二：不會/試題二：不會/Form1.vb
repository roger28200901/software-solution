Public Class Form1
    Dim s As New Stack(Of stack)
    Dim ans As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n = Val(TextBox1.Text)
        ans = n & "="
        For i = 2 To n
            process(i, n)
        Next

    End Sub
    Private Function process(ByVal n As Integer, ByVal hope As Integer)
        Dim x As Integer = 0
        Dim st As New Stack
        Do Until st.Count = hope
            st.Push(1)
        Loop
        Do Until st.Count = 2
            Dim v1 = st.Pop()
            Dim v2 = st.Pop()
            st.Push(v1 + v2)
        Loop
        s.Push(st)
        Do Until hope = x And st.Count = n

        Loop

    End Function
End Class
