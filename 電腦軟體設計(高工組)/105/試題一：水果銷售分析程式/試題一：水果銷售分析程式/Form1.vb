Public Class Form1
    Dim fruit As New SortedList
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim op As New OpenFileDialog
        fruit.Clear()

        op.Filter = "Text Files|*.txt"
        op.ShowDialog()
        Try
            Dim fileName = op.FileName
            Dim txt = My.Computer.FileSystem.ReadAllText(fileName, System.Text.Encoding.Default)
            Dim lines = Split(Trim(txt), vbCrLf)

            For i = 0 To lines.Count - 1
                Dim datas = lines(i).Split("、")
                For j = 0 To datas.Count - 1
                    If fruit.ContainsKey(datas(j)) = False Then
                        fruit.Add(datas(j), 1)
                    Else
                        fruit(datas(j)) += 1
                    End If
                Next
            Next

            Dim count(fruit.Count - 1)
            fruit.Values.CopyTo(count, 0)

            Array.Sort(count)
            Array.Reverse(count)
            Dim first = fruit.GetKey(fruit.IndexOfValue(count(0)))
            Dim second = fruit.GetKey(fruit.IndexOfValue(count(1)))
            Dim third = fruit.GetKey(fruit.IndexOfValue(count(2)))
            Dim fourth = fruit.GetKey(fruit.IndexOfValue(count(3)))
            Dim last = fruit.GetKey(fruit.IndexOfValue(count(UBound(count))))
            TextBox1.Text = first
            TextBox2.Text = second
            TextBox3.Text = third
            TextBox4.Text = fourth
            TextBox5.Text = last
        Catch ex As Exception
            MsgBox("開檔錯誤")
        End Try



    End Sub
End Class
