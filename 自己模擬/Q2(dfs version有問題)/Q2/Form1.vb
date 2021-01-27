Public Class Form1
    Dim map(,)
    Dim cat As Point
    Dim mousex As Point
    Dim mousey As Point
    Dim mousez As Point
    Dim min = 1000000000.0
    Dim xMax As Integer : Dim yMax As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str = TextBox1.Text
        Dim lines = Split(Trim(str), vbCrLf)
        ReDim map(lines(0).Length - 1, lines.Length - 1)
        xMax = lines(0).Length - 1 : yMax = lines.Length - 1
        For y = 0 To UBound(lines)
            Dim line = lines(y)
            For x = 0 To Len(line) - 1
                map(x, y) = line(x)
                If map(x, y) = "C" Then
                    cat = New Point(x, y)
                ElseIf map(x, y) = "X" Then
                    mousex = New Point(x, y)
                ElseIf map(x, y) = "Y" Then
                    mousey = New Point(x, y)
                ElseIf map(x, y) = "Z" Then
                    mousez = New Point(x, y)
                End If
            Next
        Next

        Dim sequence As New List(Of Point)
        sequence.AddRange({cat, mousex, mousey, mousez})
        '0 c 1 x 2 y 3 z
        Dim wayMap(3, 3)
        For i = 0 To 3
            For j = 0 To 3
                If i = j Then
                    wayMap(i, j) = 1000000000.0
                    Continue For
                End If
                min = 1000000000.0
                wayMap(j, i) = go(sequence(j), sequence(j), sequence(i), 0, New ArrayList)
            Next
        Next
        Dim ans As String = ""

        Dim mouseNumber As Integer = 3
        If mousex = Nothing Then
            For i = 0 To 3 ' x = 1
                wayMap(1, i) = 1000000000.0
                wayMap(i, 1) = 1000000000.0
            Next
            mouseNumber -= 1
        End If
        If mousey = Nothing Then
            For i = 0 To 3 ' x = 1
                wayMap(2, i) = 1000000000.0
                wayMap(i, 2) = 1000000000.0
            Next
            mouseNumber -= 1
        End If
        If mousez = Nothing Then
            For i = 0 To 3 ' x = 1
                wayMap(3, i) = 1000000000.0
                wayMap(i, 3) = 1000000000.0
            Next
            mouseNumber -= 1
        End If
        '有一個到不了就是無解
        Dim checkNumber As Integer = 0
        For j = 1 To 3
            If wayMap(0, j) >= 1000000000.0 Then
                checkNumber += 1
            End If
        Next
        If checkNumber = mouseNumber Then
            TextBox2.Text = "無解"
            Exit Sub
        End If

        Dim f As Integer = 0
        Dim t As Integer = -1
        Dim t2 As Integer = -1
        Dim findNumber = 0

        Dim txt = {"C", "X", "Y", "Z"}
        Do Until findNumber = 3
            min = 1000000000.0
            For i = 0 To 3
                If i = f Or i = t2 Then Continue For
                If wayMap(f, i) <= min Then
                    min = wayMap(f, i)
                    t = i
                End If
            Next
            ans &= min & txt(t)
            findNumber += 1
            t2 = f
            f = t
        Loop

        TextBox2.Text = ans

    End Sub
    Private Function go(ByVal n As Point, ByVal f As Point, ByVal t As Point, ByVal count As Integer, ByVal l As ArrayList)

        If l.Contains(n) = False Then
            l.Add(n)
        End If
        If n.X = t.X And n.Y = t.Y Then
            If count < min Then
                min = count - 1
                Return min
            End If
            Exit Function
        End If
        Dim x As Integer : Dim y As Integer
        x = n.X
        y = n.Y
        Dim tmap = map.Clone
        tmap(t.X, t.Y) = "0"
        'right
        If x < xMax Then
            If tmap(x + 1, y) = "0" And l.Contains(New Point(x + 1, y)) = False Then
                Dim tempL As New ArrayList
                tempL = l.Clone
                go(New Point(x + 1, y), f, t, count + 1, tempL)
            End If
        End If
        'down
        If y < yMax Then
            If tmap(x, y + 1) = "0" And l.Contains(New Point(x, y + 1)) = False Then
                Dim tempL As New ArrayList
                tempL = l.Clone
                go(New Point(x, y + 1), f, t, count + 1, tempL)
            End If
        End If


        If x > 0 Then
            If tmap(x - 1, y) = "0" And l.Contains(New Point(x - 1, y)) = False Then
                Dim tempL As New ArrayList
                tempL = l.Clone
                go(New Point(x - 1, y), f, t, count + 1, tempL)
            End If
        End If
        If y > 0 Then
            If tmap(x, y - 1) = "0" And l.Contains(New Point(x, y - 1)) = False Then
                Dim tempL As New ArrayList
                tempL = l.Clone
                go(New Point(x, y - 1), f, t, count + 1, tempL)
            End If
        End If

        Return min

    End Function
End Class
