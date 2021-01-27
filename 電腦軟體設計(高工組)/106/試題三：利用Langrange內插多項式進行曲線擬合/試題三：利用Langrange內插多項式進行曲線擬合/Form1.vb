Public Class Form1
    Dim bmp As Bitmap = Nothing
    Dim g As Graphics = Nothing
    Dim map As New List(Of Point)
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        drawLine(False)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        map.Clear()
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
        g = PictureBox1.CreateGraphics
        g.Clear(Color.White)
    End Sub
    Private Sub drawLine(ByVal clear As Boolean)

        If CheckBox1.Checked = True Then
            g.Clear(Color.White)
            If clear = True Then
                map.Clear()
            End If
            For i = 0 To bmp.Width - 1 Step 10
                g.DrawLine(Pens.Black, New Point(i, 0), New Point(i, bmp.Height))
            Next
            For j = 0 To bmp.Height - 1 Step 10
                g.DrawLine(Pens.Black, New Point(0, j), New Point(bmp.Width, j))
            Next
            drawDot()
        Else
            If clear = True Then
                g.Clear(Color.White)
                map.Clear()
            Else
                '畫點
                g.Clear(Color.White)
                drawDot()
            End If
        End If
    End Sub
    Private Sub drawDot()
        For i = 0 To map.Count - 1
            Dim p As Point = map(i)
            g.DrawEllipse(Pens.Blue, 0 + p.X * 10 - 3, 880 - p.Y * 10 - 3, 6, 6)
        Next
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        drawLine(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OFD As New OpenFileDialog
        OFD.Filter = "Text Files|*.txt"
        map.Clear()
        Try
            OFD.ShowDialog()
            Dim txt = My.Computer.FileSystem.ReadAllText(OFD.FileName)
            Dim datas = txt.Split(" ")
            For i = 0 To UBound(datas)
                Dim position = datas(i).Split(",")
                map.Add(New Point(position(0), position(1)))
            Next
        Catch ex As Exception
            MsgBox("Error")
        End Try
        drawLine(False)
    End Sub
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Dim x = e.X
        Dim y = e.Y
        y = 880 - y
        Me.Text = x & "," & y & " 利用Langrage內插多項式進行曲線縫合"
    End Sub
    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        Dim x = e.X
        Dim y = e.Y
        y = 880 - y
        x /= 10
        y /= 10
        map.Add(New Point(x, y))
        drawLine(False)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        drawLine(False)
        Dim Pn As New List(Of Point)

        For x = 0 To 1660
            Dim sum As Double = 0
            For j = 0 To map.Count - 1
                sum += L(j, x) * map(j).Y
            Next
            sum = Math.Abs(sum) Mod 880
            Pn.Add(New Point(x * 10, 880 - sum * 10))
            If sum = map(map.Count - 1).Y Then
                Exit For
            End If
        Next
        g.DrawLines(Pens.Red, Pn.ToArray)
    End Sub
    Function L(ByVal j As Integer, ByVal x As Integer)
        Dim sum As Double
        Dim updown As Double = 1

        For n = 0 To map.Count - 1
            If n = j Then
                Continue For
            Else
                updown *= (x - map(n).X) / (map(j).X - map(n).X)
            End If
        Next
        sum = updown
        Return sum
    End Function
End Class
