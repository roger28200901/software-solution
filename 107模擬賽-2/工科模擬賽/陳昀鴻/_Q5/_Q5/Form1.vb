Public Class Form1
    Dim map(10, 20)

    Private Sub resetMap()
        For x = 0 To 10
            For y = 0 To 20
                If x = 0 Or x = 10 Or y = 20 Then
                    map(x, y) = 0
                Else
                    map(x, y) = 1
                End If

            Next
        Next

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        resetMap()
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        redraw()
    End Sub
    Private Sub redraw()
        Dim bmp As Bitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)

        For x = 0 To 10
            For y = 0 To 20
                If map(x, y) = 0 Then
                    g.FillRectangle(Brushes.Gray, x * 30, y * 30, 30, 30)
                ElseIf map(x, y) = 1 Then
                    g.FillRectangle(Brushes.Black, x * 30, y * 30, 30, 30)
                End If
            Next
        Next

        PictureBox1.Image = bmp
    End Sub
End Class
