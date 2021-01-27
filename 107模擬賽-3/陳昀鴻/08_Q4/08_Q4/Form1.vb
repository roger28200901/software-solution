Public Class Form1
    Dim choose As Bitmap
    Dim pb(36) As PictureBox
    Dim map(6, 6) As direction
    Dim colorMap(6, 6) As Boolean
    Dim selectMap(6, 6) As Integer
    Dim bmp1, bmp2, bmp3, bmp4, bmp5 As Bitmap
    Dim bmp1B, bmp2B, bmp3B, bmp4B, bmp5B As Bitmap
    Dim visit As New Queue
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 6
            For j = 1 To 6
                Dim k As Integer = (i - 1) * 6 + j
                pb(k) = Controls("PictureBox" & k)
                map(i, j) = New direction(False, False, False, False)
                colorMap(i, j) = False
                selectMap(i, j) = -1
                AddHandler(pb(k).Click), AddressOf map_Click
            Next
        Next
        drawChoose()

    End Sub
    Private Sub drawChoose()
        'a
        bmp1 = New Bitmap(a.Width, a.Height)
        bmp1B = New Bitmap(a.Width, a.Height)
        Dim g1 As Graphics = Graphics.FromImage(bmp1)
        Dim g1b As Graphics = Graphics.FromImage(bmp1B)
        g1.FillRectangle(Brushes.LightGreen, New Rectangle(0, 20, 50, 10))
        g1b.FillRectangle(Brushes.Blue, New Rectangle(0, 20, 50, 10))

        a.Image = bmp1
        'b
        bmp2 = New Bitmap(b.Width, b.Height)
        bmp2B = New Bitmap(b.Width, b.Height)
        Dim g2 As Graphics = Graphics.FromImage(bmp2)
        Dim g2B As Graphics = Graphics.FromImage(bmp2B)
        g2.FillRectangle(Brushes.LightGreen, New Rectangle(0, 20, 50, 10))
        g2.FillRectangle(Brushes.LightGreen, New Rectangle(20, 0, 10, 50))
        g2B.FillRectangle(Brushes.Blue, New Rectangle(0, 20, 50, 10))
        g2B.FillRectangle(Brushes.Blue, New Rectangle(20, 0, 10, 50))

        b.Image = bmp2
        'c
        bmp3 = New Bitmap(c.Width, c.Height)
        bmp3B = New Bitmap(c.Width, c.Height)
        Dim g3 As Graphics = Graphics.FromImage(bmp3)
        Dim g3B As Graphics = Graphics.FromImage(bmp3B)
        g3.FillRectangle(Brushes.LightGreen, New Rectangle(20, 0, 10, 50))
        g3B.FillRectangle(Brushes.Blue, New Rectangle(20, 0, 10, 50))
        c.Image = bmp3
        'd
        bmp4 = New Bitmap(d.Width, d.Height)
        bmp4B = New Bitmap(d.Width, d.Height)
        Dim g4 As Graphics = Graphics.FromImage(bmp4)
        Dim g4B As Graphics = Graphics.FromImage(bmp4B)
        g4.FillRectangle(Brushes.LightGreen, New Rectangle(0, 20, 30, 10))
        g4.FillRectangle(Brushes.LightGreen, New Rectangle(20, 20, 10, 30))
        g4B.FillRectangle(Brushes.Blue, New Rectangle(0, 20, 30, 10))
        g4B.FillRectangle(Brushes.Blue, New Rectangle(20, 20, 10, 30))
        d.Image = bmp4
        'e
        bmp5 = New Bitmap(e.Width, e.Height)
        bmp5B = New Bitmap(e.Width, e.Height)
        Dim g5 As Graphics = Graphics.FromImage(bmp5)
        Dim g5B As Graphics = Graphics.FromImage(bmp5B)
        g5.FillRectangle(Brushes.LightGreen, New Rectangle(0, 20, 30, 10))
        g5.FillRectangle(Brushes.LightGreen, New Rectangle(20, 0, 10, 30))
        g5B.FillRectangle(Brushes.Blue, New Rectangle(0, 20, 30, 10))
        g5B.FillRectangle(Brushes.Blue, New Rectangle(20, 0, 10, 30))
        e.Image = bmp5
    End Sub
    Private Sub map_Click(sender As Object, e As EventArgs)
        If IsNothing(choose) = True Then
            Return
        End If
        Dim obj As PictureBox = sender
        obj.Image = choose
        pipeMap()
        resetColor()
        waterCheck(1, 1)
        changeColor()
    End Sub
    Private Sub resetColor()
        For i = 1 To 6
            For j = 1 To 6
                colorMap(i, j) = False
            Next
        Next
    End Sub
    Private Sub changeColor()
        Label2.ForeColor = Color.Black
        Label3.ForeColor = Color.Black
        For i = 1 To 6
            For j = 1 To 6
                Dim k As Integer = (i - 1) * 6 + j
                If colorMap(i, j) = True Then '可水流
                    If i = 1 And j = 6 And map(i, j).right = True Then
                        Label2.ForeColor = Color.Blue
                    End If
                    If i = 6 And j = 6 And map(i, j).right = True Then
                        Label3.ForeColor = Color.Blue
                    End If
                    Select Case selectMap(i, j)
                        Case 1
                            pb(k).Image = bmp1B
                        Case 2
                            pb(k).Image = bmp2B
                        Case 3
                            pb(k).Image = bmp3B
                        Case 4
                            pb(k).Image = bmp4B
                        Case 5
                            pb(k).Image = bmp5B
                    End Select
                Else  '不可水流
                    Select Case selectMap(i, j)
                        Case 1
                            pb(k).Image = bmp1
                        Case 2
                            pb(k).Image = bmp2
                        Case 3
                            pb(k).Image = bmp3
                        Case 4
                            pb(k).Image = bmp4
                        Case 5
                            pb(k).Image = bmp5
                    End Select
                End If
            Next
        Next
    End Sub
    Private Sub PictureBox_Click(sender As Object, e As EventArgs) Handles a.Click, b.Click, c.Click, d.Click, e.Click

        Select Case sender.name
            Case "a"
                choose = bmp1
            Case "b"
                choose = bmp2
            Case "c"
                choose = bmp3
            Case "d"
                choose = bmp4
            Case "e"
                choose = bmp5
        End Select
    End Sub
    Private Sub pipeMap()
        For i = 1 To 6
            For j = 1 To 6
                Dim k As Integer = (i - 1) * 6 + j
                If IsNothing(pb(k).Image) = True Then
                    Continue For
                End If
                If pb(k).Image.Equals(bmp1) = True Or pb(k).Image.Equals(bmp1B) Then
                    map(i, j) = New direction(False, False, True, True)
                    selectMap(i, j) = 1
                End If
                If pb(k).Image.Equals(bmp2) = True Or pb(k).Image.Equals(bmp2B) Then
                    map(i, j) = New direction(True, True, True, True)
                    selectMap(i, j) = 2
                End If
                If pb(k).Image.Equals(bmp3) = True Or pb(k).Image.Equals(bmp3B) Then
                    map(i, j) = New direction(True, True, False, False)
                    selectMap(i, j) = 3
                End If
                If pb(k).Image.Equals(bmp4) = True Or pb(k).Image.Equals(bmp4B) Then
                    map(i, j) = New direction(False, True, True, False)
                    selectMap(i, j) = 4
                End If
                If pb(k).Image.Equals(bmp5) = True Or pb(k).Image.Equals(bmp5B) Then
                    map(i, j) = New direction(True, False, True, False)
                    selectMap(i, j) = 5
                End If
            Next
        Next
    End Sub
    Private Sub waterCheck(ByVal x As Integer, ByVal y As Integer)
        visit.Enqueue(map(x, y))
        '垂直x 水平y

        If x = 1 And y = 1 Then
            If IsNothing(pb(1).Image) = True Then
                Return
            End If
            If pb(1).Image.Equals(bmp3) = True Then
                Return
            Else
                colorMap(1, 1) = True
            End If
        End If

        If x < 6 Then
            If map(x + 1, y).up = True And map(x, y).down = True And visit.Contains(map(x + 1, y)) = False Then
                colorMap(x + 1, y) = True
                waterCheck(x + 1, y)
            End If
        End If
        If x > 1 Then
            If map(x - 1, y).down = True And map(x, y).up = True And visit.Contains(map(x - 1, y)) = False Then
                colorMap(x - 1, y) = True
                waterCheck(x - 1, y)
            End If
        End If
        If y < 6 Then
            If map(x, y + 1).left = True And map(x, y).right = True And visit.Contains(map(x, y + 1)) = False Then
                colorMap(x, y + 1) = True
                waterCheck(x, y + 1)
            End If
        End If
        If y > 1 Then
            If map(x, y - 1).right = True And map(x, y).left = True And visit.Contains(map(x, y - 1)) = False Then
                colorMap(x, y - 1) = True
                waterCheck(x, y - 1)
            End If
        End If
    End Sub
End Class
Class direction
    Public up As Boolean
    Public down As Boolean
    Public left As Boolean
    Public right As Boolean
    Public Sub New(ByVal ups As Boolean, ByVal downs As Boolean, ByVal lefts As Boolean, ByVal rights As Boolean)
        Me.up = ups
        Me.down = downs
        Me.left = lefts
        Me.right = rights
    End Sub
End Class
