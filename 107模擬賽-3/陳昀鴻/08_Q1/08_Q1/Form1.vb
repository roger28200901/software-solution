Public Class Form1

    Dim fromPoint As New List(Of Point)
    Dim toPoint As New List(Of Point)
    Dim dictionary As New Dictionary(Of Integer, Integer)
    Dim visit As New Queue
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        fromPoint.Clear()
        toPoint.Clear()
        dictionary.Clear()
        visit.Clear()

        Dim input = TextBox1.Text
        Dim lines = Split(Trim(input), vbCrLf)
        Dim datas
        For i = 0 To UBound(lines)
            If lines(i) = "" Then Continue For
            datas = lines(i).Split({" ", ","}, StringSplitOptions.RemoveEmptyEntries)

            Dim p1 As New Point(datas(0), datas(1))
            Dim p2 As New Point(datas(2), datas(3))

            fromPoint.Add(p1)
            toPoint.Add(p2)

        Next


        drawLine()
        If dictionary.Count = 0 Then
            Label1.Text = "結果：無解"
        Else
            Dim ans = "結果："
            For Each item In dictionary
                Dim key = item.Key
                Dim value = item.Value
                ans &= value & "個" & key & "角形" & "  "
            Next
            Label1.Text = ans
        End If
        g.DrawLine(Pens.Black, New Point(0, 300), New Point(600, 300))
        g.DrawLine(Pens.Black, New Point(300, 0), New Point(300, 600))

    End Sub
    Private Sub drawLine()
        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim centerX = 300
        Dim centerY = 300


        Dim i As Integer = 0
        Dim travel As New Queue
        Dim f As Integer = 0
        Do Until i = fromPoint.Count
            travel.Enqueue(fromPoint(i))
            g.DrawLine(Pens.Black, centerX + fromPoint(i).X, centerY - fromPoint(i).Y, centerX + toPoint(i).X, centerY - toPoint(i).Y)
            If travel.Contains(toPoint(i)) = True Then
                isShape(toPoint(i), f, i)
                f = i + 1
            End If

            i += 1
        Loop

    End Sub
    Private Sub isShape(ByVal p As Point, ByVal f As Integer, ByVal t As Integer)
        Dim find As Boolean = False

        Dim i As Integer = 0
        Dim counter = 0
        Dim fp = p
        Dim horizontal As Boolean = False
        Dim vertical As Boolean = False
        Dim lastP As Point = fromPoint(f)
        For i = 0 To t
            If visit.Contains(fromPoint(i)) Then
                lastP = fromPoint(i + 1)
                Continue For
            End If
            If fromPoint(i).X <> toPoint(i).X And fromPoint(i).Y <> toPoint(i).Y And fromPoint(i) = lastP Then
                counter += 1
                horizontal = False
                vertical = False
                lastP = toPoint(i)
                visit.Enqueue(fromPoint(i))
            End If
            If fromPoint(i).X = toPoint(i).X And fromPoint(i).Y <> toPoint(i).Y And fromPoint(i) = lastP Then
                If vertical = False Then
                    counter += 1
                    vertical = True
                    horizontal = False
                    lastP = toPoint(i)
                    visit.Enqueue(fromPoint(i))
                Else
                    lastP = toPoint(i)
                End If
            End If
            If fromPoint(i).X <> toPoint(i).X And fromPoint(i).Y = toPoint(i).Y And fromPoint(i) = lastP Then
                If horizontal = False Then
                    counter += 1
                    horizontal = True
                    vertical = False
                    lastP = toPoint(i)
                    visit.Enqueue(fromPoint(i))
                Else
                    lastP = toPoint(i)
                End If
            End If

            If lastP = toPoint(t) Then
                Exit For
            End If
        Next
        If dictionary.ContainsKey(counter) = True Then
            dictionary(counter) += 1
        Else
            dictionary.Add(counter, 1)
        End If


    End Sub
End Class
