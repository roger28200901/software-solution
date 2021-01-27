Public Class Form1
    Dim g As Graphics
    Dim Game As Tetris
    Dim map(10, 20)
    Dim time
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Randomize()
        resetAll()
        Timer1.Start()
    End Sub

    Private Sub resetAll()
        g = PictureBox1.CreateGraphics
        Dim delta = 30
        g.FillRectangle(Brushes.Black, 30, 0, 300, 600)
        For y = 0 To 21
            g.FillRectangle(Brushes.LightGray, 0, y * delta, 30, 30)
            g.DrawRectangle(Pens.Black, 0, y * delta, 30, 30)
            g.FillRectangle(Brushes.LightGray, 330, y * delta, 30, 30)
            g.DrawRectangle(Pens.Black, 330, y * delta, 30, 30)
        Next
        For x = 0 To 12
            g.FillRectangle(Brushes.LightGray, x * 30, 600, 30, 30)
            g.DrawRectangle(Pens.Black, x * 30, 600, 30, 30)
        Next
        Game = New Tetris()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        redrawMap()
        If Game.AppearMatrix = False Then
            Game.randomMatrix()
        End If
        For y = 0 To 15
            If Game.nowMatrix(y) <> 0 Then
                Dim plusY = y \ 4
                Dim plusX = y Mod 4
                g.FillRectangle(Brushes.Red, (Game.x + plusX) * 30, (Game.y + plusY) * 30, 30, 30)
            End If
        Next
        time += 10
        If time Mod 1000 = 0 Then
            Game.y += 1
            time = 0
        End If


    End Sub
    Private Function Collide()

    End Function
    Private Function GameOver()

    End Function
    Private Sub redrawMap() '寬12 高 21 格
        g.FillRectangle(Brushes.Black, 30, 0, 300, 600)
    End Sub
    Class Tetris
        Property AppearMatrix As Boolean = False
        Property x As Integer = 4
        Property y As Integer = 0
        Property Point As Integer = 0
        Property nowMatrix As Array
        Dim M = {
                 {
                 1, 1, 1, 1,
                 0, 0, 0, 0,
                 0, 0, 0, 0,
                 0, 0, 0, 0
                 },
                 {
                 0, 0, 0, 0,
                 0, 0, 0, 0,
                 2, 0, 0, 0,
                 2, 2, 2, 0
                 },
                 {
                 0, 0, 0, 0,
                 0, 0, 0, 0,
                 0, 0, 0, 3,
                 0, 3, 3, 3
                 },
                {
                 0, 0, 0, 0,
                 0, 0, 0, 0,
                 4, 4, 0, 0,
                 4, 4, 0, 0
                },
                {
                 0, 0, 0, 0,
                 0, 0, 0, 0,
                 0, 5, 5, 0,
                 5, 5, 0, 0
                },
                {
                 0, 0, 0, 0,
                 0, 0, 0, 0,
                 0, 6, 0, 0,
                 6, 6, 6, 0
                },
                {
                 0, 0, 0, 0,
                 0, 0, 0, 0,
                 7, 7, 0, 0,
                 0, 7, 7, 0
                }
        }

        Public Sub randomMatrix()
            Dim r = Int(Rnd() * 7)
            Dim list(15)
            For i = 0 To 15
                list(i) = M(5, i)
            Next
            nowMatrix = list
        End Sub

    End Class

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        '37 38 39 40
        If e.KeyValue = 37 Then
            Game.x -= 1
        ElseIf e.KeyValue = 38 Then
            'rotate
        ElseIf e.KeyValue = 39 Then
            Game.x += 1
        ElseIf e.KeyValue = 40 Then
            Game.y += 1
        End If
    End Sub

End Class
