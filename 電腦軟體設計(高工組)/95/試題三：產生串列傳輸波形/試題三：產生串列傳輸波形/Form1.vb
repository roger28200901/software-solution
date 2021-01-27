Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim datas As New List(Of Integer)
        For i = 1 To 4
            datas.Add(1) '高電位
        Next
        datas.Add(0) '起始位元
        Dim txt = StrReverse(TextBox1.Text)
        For i = 0 To Len(txt) - 1
            If txt(i) = "1" Then
                datas.Add(1)
            Else
                datas.Add(0)
            End If
        Next
        Dim result = datas.Where(Function(item) item = 1)
        If ComboBox1.Text = "奇同位" Then
            If result.Count Mod 2 = 0 Then
                datas.Add(1)
            Else
                datas.Add(0)
            End If
        Else
            If result.Count Mod 2 = 0 Then
                datas.Add(0)
            Else
                datas.Add(1)
            End If
        End If
        For i = 1 To Int(ComboBox2.Text)
            datas.Add(1)
        Next
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        Dim delta = 500 \ 16
        For x = 0 To datas.Count - 1
            g.FillRectangle(Brushes.Gray, x * delta, 100 - 50 * datas(x), delta - 2, 10)
        Next
    End Sub
End Class
