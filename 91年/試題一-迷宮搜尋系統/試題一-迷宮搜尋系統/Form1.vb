Public Class Form1
    Dim map(10, 10), obmap(10, 10) As Integer
    Dim s, t As Point
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'reset rand seed

        Randomize()
        initMap()
        showMap()
    End Sub
    Public Sub initMap()
        s = New Point(0, 0)
        t = New Point(0, 0)
        For i = 1 To 9
            For j = 1 To 9
                map(i, j) = 0
            Next
        Next
        obmap = map.Clone()
    End Sub
    Public Sub showMap()
        Dim k As Integer
        For i = 1 To 9
            For j = 1 To 9
                k = (i - 1) * 9 + j
                Controls("TextBox" & k).Text = ""
                If map(i, j) = 0 Or map(i, j) = -2 Then
                    Controls("TextBox" & k).BackColor = Color.White
                ElseIf map(i, j) = -1 Then
                    Controls("TextBox" & k).BackColor = Color.Black
                ElseIf map(i, j) = -3 Then
                    Controls("TextBox" & k).BackColor = Color.Gray
                Else
                    Controls("TextBox" & k).Text = map(i, j)
                End If
            Next
        Next

        k = (s.X - 1) * 9 + s.Y
        If k >= 1 And k <= 81 Then
            Controls("TextBox" & k).Text = "S"
        End If

        k = (t.X - 1) * 9 + t.Y
        If k >= 1 And k <= 81 Then
            Controls("TextBox" & k).Text = "T"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        initMap()
        showMap()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        initMap()


        Dim max, i, x, y As Integer
        max = Rnd() * 30 + 20

        Label5.Text = max
        Do While (i < max)
            x = Rnd() * 8 + 1
            y = Rnd() * 8 + 1
            If map(x, y) = 0 Then
                i += 1
                map(x, y) = -1
            End If
        Loop
        showMap()
        obmap = map.Clone()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        map = obmap.Clone()

        s = getRandPoint()
        map(s.X, s.Y) = -2
        t = getRandPoint()
        map(t.X, t.Y) = -2

        showMap()
    End Sub
    Public Function getRandPoint()

    Dim find As Boolean = False
        Dim x, y As Integer

        Do While (Not find)
            x = Rnd() * 8 + 1
            y = Rnd() * 8 + 1
            If map(x, y) = 0 Then
                Return New Point(x, y)
            End If
        Loop

        Return New Point(0, 0)


    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        findPath()
        showMap()
    End Sub
    Public Sub findPath()
        Dim noPath As Boolean = False
        Dim yesPath As Boolean = False
        Dim noAns As Boolean = False
        Dim q As Queue = New Queue

        Dim w As Integer = 1
        map(s.X, s.Y) = w
        map(t.X, t.Y) = 0
        q.Enqueue(s)
        'If s.X > 1 AndAlso s.X < 10 Then If map(s.X - 1, s.Y) = 0 Then map(s.X - 1, s.Y) = w + 1

        Do Until noPath = True Or yesPath = True
            Dim q2 As Queue = New Queue
            Do While q.Count > 0

                Dim p = q.Dequeue()
                Dim check = 0
                If p.X > 1 Then If map(p.X - 1, p.Y) = 0 Then map(p.X - 1, p.Y) = w + 1 : q2.Enqueue(New Point(p.X - 1, p.Y)) : check += 1
                If p.X < 9 Then If map(p.X + 1, p.Y) = 0 Then map(p.X + 1, p.Y) = w + 1 : q2.Enqueue(New Point(p.X + 1, p.Y)) : check += 1
                If p.Y > 1 Then If map(p.X, p.Y - 1) = 0 Then map(p.X, p.Y - 1) = w + 1 : q2.Enqueue(New Point(p.X, p.Y - 1)) : check += 1
                If p.Y < 10 Then If map(p.X, p.Y + 1) = 0 Then map(p.X, p.Y + 1) = w + 1 : q2.Enqueue(New Point(p.X, p.Y + 1)) : check += 1
                If map(t.X, t.Y) > 0 Then
                    noPath = True
                ElseIf check = 0 Then
                    noPath = True
                    noAns = True
                End If
            Loop
            q = q2.Clone()
            w += 1
        Loop


        'check answer or not
        

        Dim x = t.X
        Dim y = t.Y
        If noAns = True Then
            Label6.Text = "No"
            Return
        End If
        Do Until w < 1
            'showMap()
            'Threading.Thread.Sleep(100)
            'Application.DoEvents()

            If (x = s.X And y = s.Y) Then
                map(x, y) = -3
                yesPath = True
                Exit Do
            End If

            If map(x - 1, y) = w - 1 Then
                map(x, y) = -3
                x -= 1
                w -= 1
            End If
            If map(x + 1, y) = w - 1 Then
                map(x, y) = -3
                x += 1
                w -= 1
            End If
            If map(x, y - 1) = w - 1 Then
                map(x, y) = -3
                y -= 1
                w -= 1
            End If
            If map(x, y + 1) = w - 1 Then
                map(x, y) = -3
                y += 1
                w -= 1
            End If
        Loop

        If yesPath = True Then
            Label6.Text = "Yes"
        Else
            Label6.Text = "No"
        End If
    End Sub
End Class
