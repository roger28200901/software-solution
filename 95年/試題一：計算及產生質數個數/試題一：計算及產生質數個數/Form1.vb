Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n As Integer = Val(TextBox1.Text)
        Dim primeStack As New Stack
        For i = 2 To n
            Dim b As Boolean = primeNuber(i)
            If b = True Then
                primeStack.Push(i)
            End If
        Next

        Dim c As Integer = primeStack.Count

        Label2.Text = "質數個數　" & c
        Dim m1 As Integer = primeStack.Pop
        Dim m2 As Integer = primeStack.Pop
        Dim m3 As Integer = primeStack.Pop

        Label3.Text = "最大的三個質數　" & m3 & " " & m2 & " " & m1

    End Sub
    Private Function primeNuber(ByVal i As Integer)
        Dim count = 0
        For j = 1 To i
            If i Mod j = 0 Then
                count += 1
            End If
        Next

        If count = 2 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
