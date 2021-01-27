Public Class Form1
    Dim RB As RadioButton

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
    Private Sub draw()
        'drawLine

        Dim center = (PictureBox1.Height - 1) / 2


        Dim g As Graphics = PictureBox1.CreateGraphics()
        Dim p1 As New Point(0, center)
        Dim p2 As New Point(PictureBox1.Width, center)



        Dim p(360) As Point
        If RB.Equals(RadioButton1) Then 'Sin
            For i = 0 To 360
                p(i).X = PictureBox1.Width / 360 * i
                p(i).Y = center * (1 - Math.Sin(i / 180 * Math.PI))
            Next
        Else 'Cos
            For i = 0 To 360
                p(i).X = PictureBox1.Width / 360 * i
                p(i).Y = center * (1 - Math.Cos(i / 180 * Math.PI))
            Next
        End If
        g.Clear(Color.White)
        g.DrawLine(Pens.Black, p1, p2)
        g.DrawLine(Pens.Black, New Point(0, 0), New Point(0, PictureBox1.Height))

        g.DrawLines(Pens.Black, p)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For Each item As Object In GroupBox1.Controls
            If item.GetType.ToString() = "System.Windows.Forms.RadioButton" Then
                RB = CType(item, RadioButton)
                If RB.Checked Then
                    draw()
                End If
            End If
        Next
    End Sub
End Class
