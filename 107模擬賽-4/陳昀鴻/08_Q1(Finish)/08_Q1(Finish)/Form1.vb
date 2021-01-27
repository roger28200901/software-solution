Public Class Form1
    Dim map(20, 30) As String
    Dim wayMap(3, 3) As Integer
    Dim Cat, mouseX, mouseY, mouseZ As Point
    Dim min As Integer = 1000000000.0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str = TextBox1.Text
        Dim lines = Split(Trim(str), vbCrLf)
        Dim l As New List(Of Point)
        Dim c As New List(Of String)
        For y = 0 To UBound(lines)
            Dim line = lines(y)
            For x = 0 To Len(line) - 1
                map(x, y) = line(x)
                If map(x, y) = "C" Then
                    Cat = New Point(x, y)
                    l.Add(Cat)
                    c.Add("C")
                ElseIf map(x, y) = "X" Then
                    mouseX = New Point(x, y)
                    l.Add(mouseX)
                    c.Add("X")
                ElseIf map(x, y) = "Y" Then
                    mouseY = New Point(x, y)
                    l.Add(mouseY)
                    c.Add("Y")
                ElseIf map(x, y) = "Z" Then
                    mouseZ = New Point(x, y)
                    l.Add(mouseZ)
                    c.Add("Z")
                End If
            Next
        Next
        For y = 0 To 30
            For x = 0 To 20
                If map(x, y) = "" Then
                    map(x, y) = 1
                End If
            Next
        Next
        ReDim wayMap(l.Count - 1, l.Count - 1)
        run(map, l)

        Dim m As Integer = l.IndexOf(Cat)

        Dim visit As New List(Of Point)
        Dim counter As Integer = 0
        Dim ans As String = ""
        Do Until counter = l.Count - 1
            Dim index As Integer = -1
            min = 1000000000.0
            Do
                For i = 0 To l.Count - 1
                    If i = m Or visit.Contains(New Point(m, i)) = True Or visit.Contains(New Point(i, m)) = True Then Continue For
                    If min > wayMap(m, i) Then
                        min = wayMap(m, i)
                        index = i
                    End If
                    wayMap(m, i) = 1000000000.0
                    wayMap(i, m) = 1000000000.0
                Next

                visit.Add(New Point(m, index))
                visit.Add(New Point(index, m))
                m = index
                Exit Do
            Loop
            If min > 5000 Then
                ans = "無解"
                Exit Do
            Else
                ans &= min & c(index)
            End If
            counter += 1
        Loop
        TextBox2.Text = ans
    End Sub
    Private Sub run(ByVal map As String(,), ByVal l As List(Of Point))
        For i = 0 To l.Count - 1
            For j = 0 To l.Count - 1
                If i = j Then Continue For
                Dim ans = findPath(l(i), l(j))
                wayMap(i, j) = ans
            Next
        Next
    End Sub
    Private Function findPath(ByVal s As Point, ByVal t As Point)
        Dim w As Integer = 2 '起始從2開始

        Dim q As Queue = New Queue

        Dim tmap = map.Clone
        tmap(s.X, s.Y) = 2
        tmap(t.X, t.Y) = 0
        q.Enqueue(New Point(s.X, s.Y))

        Do Until tmap(t.X, t.Y) <> 0 Or w = 20 * 30
            Dim q2 As Queue = New Queue 'insert search point
            Do While q.Count > 0 'q is for your serach choice
                Dim p As Point = q.Dequeue()
                If p.X > 0 Then If tmap(p.X - 1, p.Y) = "0" Then tmap(p.X - 1, p.Y) = w + 1 : q2.Enqueue(New Point(p.X - 1, p.Y))
                If p.X < 20 Then If tmap(p.X + 1, p.Y) = "0" Then tmap(p.X + 1, p.Y) = w + 1 : q2.Enqueue(New Point(p.X + 1, p.Y))
                If p.Y > 0 Then If tmap(p.X, p.Y - 1) = "0" Then tmap(p.X, p.Y - 1) = w + 1 : q2.Enqueue(New Point(p.X, p.Y - 1))
                If p.Y < 30 Then If tmap(p.X, p.Y + 1) = "0" Then tmap(p.X, p.Y + 1) = w + 1 : q2.Enqueue(New Point(p.X, p.Y + 1))
            Loop
            w += 1
            q = q2.Clone()
        Loop

        If w = 600 Then '無解
            Return 1000000000.0
        End If

        Dim minV As Integer = tmap(t.X, t.Y) - tmap(s.X, s.Y)
        Return minV - 1
    End Function
End Class
