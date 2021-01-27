Public Class Form1
    Dim minus As Boolean = False
    Dim count As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Timer1.Enabled = False Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub
    Private Function getnewpoint(ByVal length As Integer, ByVal angle As Integer, ByVal point As Point)
        Dim p As Point : Dim x As Integer : Dim y As Integer
        x = Math.Cos(angle * Math.PI / 180) * length + point.X
        y = Math.Sin(angle * Math.PI / 180) * length + point.Y
        p = New Point(x, y)
        Return p
    End Function
    Private Sub draw(Optional round As Integer = 1)
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim pen1 As Pen = Pens.Violet
        Dim pen2 As Pen = Pens.Violet
        Dim pen3 As Pen = Pens.Violet

        If round = 2 Then
            pen1 = Pens.Blue
        End If
        If round = 3 Then
            pen1 = Pens.Blue
            pen2 = Pens.Blue
        End If
        If round = 4 Then
            pen1 = Pens.Blue
            pen2 = Pens.Blue
            pen3 = Pens.Blue
        End If
        Dim newpoint, newpoint2, newpoint3 As Point
        Dim b1(10), b2(20), b3(40)
        Dim point As New Point(250, 250)
        For i = 1 To 10
            Dim angle = i * 360 / 10
            newpoint = getnewpoint(50, angle, point)
            g.DrawLine(pen1, point, newpoint)
            For j = -1 To 1 Step 2
                newpoint2 = getnewpoint(75, angle + j * 15, newpoint)
                g.DrawLine(pen2, newpoint, newpoint2)
                For k = -1 To 1 Step 2
                    newpoint3 = getnewpoint(50, angle + k * 15, newpoint2)
                    g.DrawLine(pen3, newpoint2, newpoint3)
                Next
            Next
        Next

        '第一圈 長度50
        g.DrawEllipse(Pens.Brown, 200, 200, 100, 100)
        '第二圈 長度125
        g.DrawEllipse(Pens.Brown, 125, 125, 250, 250)
        '第三圈 長度175
        g.DrawEllipse(Pens.Brown, 75, 75, 350, 350)
        PictureBox1.Image = bmp
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call draw(False)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If minus = False Then
            count += 1
        Else
            count -= 1
        End If
        If count = 3 Then
            minus = True
        End If
        If count = 0 Then
            minus = False
        End If
        If count = 0 Then
            Call draw(1)
        End If
        If count = 1 Then
            Call draw(2)
        End If
        If count = 2 Then
            Call draw(3)
        End If
        If count = 3 Then
            Call draw(4)
        End If

    End Sub
End Class
