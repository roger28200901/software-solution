Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '用CP去演算
        Dim weightLimit = Val(weightRange.Text)
        Dim l As New List(Of Product)
        For i = 1 To 5
            Dim name = Controls("product" & i).Text
            Dim p = Val(Controls("price" & i).Text)
            Dim w = Val(Controls("weight" & i).Text)
            l.Add(New Product(name, p, w))
        Next
        Dim stack As New Stack(Of String)
        Dim sum As Integer = 0
        Dim now

        Do
            Dim max = -1
            Dim obj As Product = Nothing
            For i = 0 To l.Count - 1
                If l(i).best > max And l(i).weight + now <= weightLimit Then
                    max = l(i).best
                    obj = l(i)
                End If
            Next
            If max = -1 Then Exit Do
            stack.Push(obj.name)
            sum += obj.price
            now += obj.weight
        Loop
        Label5.Text = "最佳組合 = " & String.Join(" + ", stack)
        Label6.Text = "合計價格 = " & sum

    End Sub
End Class
Class Product
    Public name As String = Nothing
    Public price As Integer = Nothing
    Public weight As Integer = Nothing
    Public best As Decimal = Nothing
    Public Sub New(ByVal v1 As String, ByVal v2 As Integer, ByVal v3 As Integer)
        Me.name = v1
        Me.price = v2
        Me.weight = v3
        Me.best = v2 / v3
    End Sub
End Class
