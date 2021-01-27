Imports System.Linq
Public Class Form1
    Dim A5(30)
    Dim A20(30)
    Dim A5l20(30)
    Dim Future(30)
    Dim datas
    Dim l As New List(Of String)
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input = My.Computer.FileSystem.ReadAllText(TextBox1.Text)

        datas = input.Split(" ")
        '20日 index = 19
        '30 29 
        l.AddRange(datas)
        Call Ave5()
        Call Ave20()
        Call dsV()
        Call FutureV()

        For i = 19 To 29
            TextBox4.Text &= A5(i) & " "
            TextBox5.Text &= A20(i) & " "
            TextBox6.Text &= A5l20(i) & " "
            TextBox7.Text &= Future(i) & " "
        Next

        For i = 1 To 4
            TextBox4.Text &= "00.00" & " "
            TextBox5.Text &= "00.00" & " "
            TextBox6.Text &= "00.00" & " "
            TextBox7.Text &= "00.00" & " "
        Next

    End Sub
    Private Sub Ave5()
        For i = 15 To 25
            Dim sum = Math.Round((CDec(datas(i)) + CDec(datas(i + 1)) + CDec(datas(i + 2)) + CDec(datas(i + 3)) + CDec(datas(i + 4))) / 5, 2)
            A5(i + 4) = sum
        Next
    End Sub
    Private Sub Ave20()
        For i = 0 To 10
            Dim sum As Decimal = 0
            l.Skip(i).Take(20).Sum(Function(x)
                                       Dim n = CDec(x)
                                       sum += n
                                   End Function)
            sum /= 20
            A20(i + 19) = Format(sum, "00.00")
        Next
    End Sub
    Private Sub dsV()
        For i = 19 To 29
            A5l20(i) = Format(CDec(A5(i) - A20(i)), "00.00")
        Next
    End Sub
    Private Sub FutureV()
        For i = 19 To 29
            Future(i) = Format((CDec(l(i - 4)) * 4 - CDec(l(i - 19))) / 3, "00.00")
        Next
    End Sub
End Class
