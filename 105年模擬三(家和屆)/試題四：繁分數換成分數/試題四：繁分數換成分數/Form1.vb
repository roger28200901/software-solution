
Public Class Form1
    Dim sum As Decimal = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input = TextBox1.Text
        input = input.Replace(vbCrLf, "/")
        Dim datas = input.Split("/")
        sum = 0
        Dim q As New Queue
        For i = 0 To UBound(datas)
            q.Enqueue(datas(i))
        Next
        Dim up As String = ""
        Dim down As String = "1"

        Dim ans As Decimal = 0
        ans = process(q, q.Count - 1)
        Dim str = ans.ToString.Split(".")
        Dim strSpl = str(1)

        up = strSpl
        For i = 1 To strSpl.Length
            down &= "0"
        Next
        Dim large = gcd(up, down)

        up = up / large
        down = down / large
        TextBox2.Text = up
        TextBox3.Text = down
    End Sub
    Private Function gcd(ByVal a As Integer, ByVal b As Integer)
        If b = 0 Then
            Return a
        Else
            Return gcd(b, a Mod b)
        End If
    End Function
    Private Function process(ByVal q As Queue, ByVal u As Integer)
        Dim value As Decimal = 1 / (q(u) + sum)
        If u = 0 Then
            sum = value
            Return sum
        Else
            sum = value
            process(q, u - 1)
        End If
        Return sum
    End Function
End Class
