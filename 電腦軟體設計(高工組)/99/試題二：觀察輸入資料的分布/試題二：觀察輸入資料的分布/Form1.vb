Public Class Form1
    Dim Datas As New List(Of SaveDatas)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofs As New OpenFileDialog
        ofs.Filter = "Text Files|*.txt"

        Try
            ofs.ShowDialog()
            Dim txt = My.Computer.FileSystem.ReadAllText(ofs.FileName)
            Dim lines = Split(Trim(txt), vbCrLf)
            For i = 0 To UBound(lines)
                Dim Temp() = lines(i).Split(" ")

                Dim n = Val(Temp(1))
                Dim count = 2


                For j = 1 To n
                    Datas.Add(New SaveDatas(Temp(count), Temp(count + 1), Temp(count + 2)))
                    count += 3
                Next
            Next

        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub
    Public Sub drawMap()
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        Dim maxX = Datas.Max(Function(item) item.horizontal)
        Dim deltaX = 300 / maxX
        For x = 0 To maxX Step 50
            If x Mod 50 = 0 Then
                g.DrawString(x, New Font("標楷體", 8), Brushes.Black, New Point(20 + x * deltaX, 320))
            End If
        Next
        Dim minY = Datas.Min(Function(item) item.vertival)
        minY = minY - Mid(minY, minY.ToString.Length, 1)
        Dim maxY = Datas.Max(Function(item) item.vertival)
        Dim deltaY = 300 / (maxY - minY)
        For y = minY To maxY Step 10
            If y Mod 10 = 0 Then
                g.DrawString(y, New Font("標楷體", 8), Brushes.Black, New Point(0, 300 - deltaY * (y - minY)))
            End If
        Next
        For i = 0 To Datas.Count - 1
            Dim h = Datas(i).horizontal
            Dim v = Datas(i).vertival
            Dim c = Datas(i).orderClass
            g.DrawString(IIf(c = 1, "o", "*"), New Font("標楷體", 6), IIf(c = 1, Brushes.Red, Brushes.Blue), New Point(20 + h * deltaX, 320 - (v - minY) * deltaY))
        Next
        '原點20 320
        g.DrawLine(Pens.Black, New Point(20, 0), New Point(20, 320))
        g.DrawLine(Pens.Black, New Point(20, 320), New Point(PictureBox1.Width, 320))


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        drawMap()
    End Sub
End Class
Class SaveDatas
    Public horizontal As Integer
    Public vertival As Integer
    Public orderClass As Integer
    Public Sub New(ByVal v1 As Integer, ByVal v2 As Integer, ByVal v3 As Integer)
        Me.horizontal = v1
        Me.vertival = v2
        Me.orderClass = v3
    End Sub
End Class
