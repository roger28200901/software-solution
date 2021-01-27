Public Class Form1
    Dim N As Integer = 6
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = "10 30 50 60 80 100"
        N = 6
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim X = TextBox1.Text.Split(" ").ToList.ConvertAll(Function(item) Int(item))
        Dim ave = X.Average(Function(item) Int(item))

        Dim maxV = X.Max()
        Dim minV = X.Min()
        Dim standardDelta As Double = Math.Sqrt((X.Sum(Function(item) (Int(item) - ave) ^ 2)) / X.Count)
        Label2.Text = "平均值 = " & ave
        Label3.Text = "最大值 = " & maxV
        Label4.Text = "最小值 = " & minV
        Label5.Text = "標準差 = " & standardDelta
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        Label2.Text = "平均值 = "
        Label3.Text = "最大值 = "
        Label4.Text = "最小值 = "
        Label5.Text = "標準差 = "
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub
End Class
