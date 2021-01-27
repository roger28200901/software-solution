Public Class Form1
    Dim shape(4)
    Dim bmp As Bitmap
    Dim selectObj = Nothing
    Dim startX : Dim startY
    Private Sub clearAll()
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.White)
    End Sub
    Private Sub drawAllShape()
        Dim g As Graphics = Graphics.FromImage(bmp)
        For i = 1 To 4
            If i = 1 Then
                g.FillPolygon(Brushes.Green, shape(i).toarray)
            ElseIf i = 2 Then
                g.FillPolygon(Brushes.Red, shape(i).toarray)
            ElseIf i = 3 Then
                g.FillPolygon(Brushes.Yellow, shape(i).toarray)
            ElseIf i = 4 Then
                g.FillPolygon(Brushes.Purple, shape(i).toarray)
            End If
        Next
    End Sub
    Private Sub drawBlock()
        Dim g As Graphics = Graphics.FromImage(bmp)
        For x = 0 To 360 Step 20
            g.DrawLine(Pens.Black, New Point(x, 0), New Point(x, 500))
        Next
        For y = 0 To 360 Step 20
            g.DrawLine(Pens.Black, New Point(0, y), New Point(500, y))
        Next
    End Sub
    Private Sub drawShape1()
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim p As New List(Of Point)
        p.Add(New Point(340, 60))
        p.Add(New Point(340, 100))
        p.Add(New Point(240, 100))
        shape(1) = p
        g.FillPolygon(Brushes.Green, p.ToArray)
    End Sub
    Private Sub drawShape2()
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim p As New List(Of Point)
        p.Add(New Point(20, 100))
        p.Add(New Point(180, 40))
        p.Add(New Point(180, 100))
        shape(2) = p
        g.FillPolygon(Brushes.Red, p.ToArray)
    End Sub
    Private Sub drawShape3()
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim p As New List(Of Point)
        p.Add(New Point(60, 180))
        p.Add(New Point(160, 180))
        p.Add(New Point(160, 200))
        p.Add(New Point(100, 200))
        p.Add(New Point(100, 220))
        p.Add(New Point(60, 220))
        shape(3) = p
        g.FillPolygon(Brushes.Yellow, p.ToArray)
    End Sub
    Private Sub drawShape4()
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim p As New List(Of Point)
        p.Add(New Point(280, 180))
        p.Add(New Point(340, 180))
        p.Add(New Point(340, 220))
        p.Add(New Point(240, 220))
        p.Add(New Point(240, 200))
        p.Add(New Point(280, 200))
        shape(4) = p
        g.FillPolygon(Brushes.Purple, p.ToArray)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call clearAll()

        Call drawShape1()
        Call drawShape2()
        Call drawShape3()
        Call drawShape4()
        Call drawBlock()
        PictureBox1.Refresh()

        Timer1.Stop()
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Dim c As Color = bmp.GetPixel(e.X, e.Y)

        If c.R = 0 And c.G = 128 And c.B = 0 Then ' shape1
            selectObj = shape(1)
            startX = e.X
            startY = e.Y
        ElseIf c.R = 255 And c.G = 0 And c.B = 0 Then
            selectObj = shape(2)
            startX = e.X
            startY = e.Y
        ElseIf c.R = 255 And c.G = 255 And c.B = 0 Then
            selectObj = shape(3)
            startX = e.X
            startY = e.Y
        ElseIf c.R = 128 And c.G = 0 And c.B = 128 Then
            selectObj = shape(4)
            startX = e.X
            startY = e.Y
        End If
    End Sub
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If IsNothing(selectObj) = True Then Exit Sub
        Dim objList = selectObj
        For i = 0 To objList.count - 1
            Dim x = objList(i).x + e.X - startX
            Dim y = objList(i).y + e.Y - startY
            Debug.Print(x)
            objList(i) = New Point(x, y)
        Next
        startX = e.X
        startY = e.Y
        Dim g As Graphics = Graphics.FromImage(bmp)
        clearAll()
        drawAllShape()
        drawBlock()
        PictureBox1.Refresh()
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        selectObj = Nothing
    End Sub
End Class
