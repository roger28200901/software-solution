Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics()
        Dim pen1 = New Pen(Color.Red)
        Dim pen2 = New Pen(Color.Blue)
        Dim m1, m2
        m1 = TextBox2.Text : m2 = TextBox1.Text
        m1 = StrDup(2 - Len(m1), "0") & m1
        m2 = StrDup(2 - Len(m2), "0") & m2
        Dim p As Pen = New Pen(Brushes.Black)
        p.DashStyle = Drawing2D.DashStyle.Dash
        p.Width = 2
        g.Clear(Color.White)
        Dim sx, sy, r
        For i = 0 To 1
            If i = 0 Then
                sx = 50 : sy = 150 : r = 250
            Else
                sx = 110 : sy = 90 : r = 250
            End If
            Dim k = Val(m1(i))
            If k = 0 Then
                p.Brush = Brushes.Blue
                If k = 1 Then
                    sx += 50 : sy -= 50
                End If
                g.DrawLine(p, CInt(sx), CInt(sy), CInt(sx + r), CInt(sy + r))
            End If
            For j = 0 To k - 1
                g.DrawLine(Pens.Blue, CInt(sx + (10 * j)), CInt(sy - (10 * j)), CInt(sx + (10 * j) + r), CInt(sy - (10 * j) + r))
            Next
        Next
        For i = 0 To 1
            If i = 0 Then
                sx = 250 : sy = 10 : r = 200
            Else
                sx = 350 : sy = 110 : r = 200
            End If
            Dim k = Val(m2(i))
            If k = 0 Then
                p.Brush = Brushes.Red
                g.DrawLine(p, CInt(sx), CInt(sy), CInt(sx - r), CInt(sy + r))
            End If
            For j = 0 To k - 1
                g.DrawLine(Pens.Red, CInt(sx + (10 * j)), CInt(sy + (10 * j)), CInt(sx + (10 * j) - r), CInt(sy + (10 * j) + r))
            Next
        Next
        'Dim m1, m2
        'm1 = TextBox1.Text : m2 = TextBox2.Text
        'm1 = StrDup(2 - Len(m1), "0") & m1
        'm2 = StrDup(2 - Len(m2), "0") & m2
        'Dim p As Pen = New Pen(Brushes.Black)
        'p.DashStyle = Drawing2D.DashStyle.Dash
        'p.Width = 2
        'Dim g As Graphics = PictureBox1.CreateGraphics
        'g.Clear(Color.White)
        'Dim sx, sy, r
        'For i = 0 To 1
        '    If i = 0 Then
        '        sx = 50 : sy = 150 : r = 250
        '    Else
        '        sx = 110 : sy = 90 : r = 250
        '    End If
        '    Dim k = Val(m1(i))
        '    If k = 0 Then
        '        p.Brush = Brushes.Blue
        '        If k = 1 Then
        '            sx += 50 : sy -= 50
        '        End If
        '        g.DrawLine(p, CInt(sx), CInt(sy), CInt(sx + r), CInt(sy + r))
        '    End If
        '    For j = 0 To k - 1
        '        g.DrawLine(Pens.Blue, CInt(sx + (10 * j)), CInt(sy - (10 * j)), CInt(sx + (10 * j) + r), CInt(sy - (10 * j) + r))
        '    Next
        'Next
        'For i = 0 To 1
        '    If i = 0 Then
        '        sx = 250 : sy = 10 : r = 200
        '    Else
        '        sx = 350 : sy = 110 : r = 200
        '    End If
        '    Dim k = Val(m1(i))
        '    If k = 0 Then
        '        p.Brush = Brushes.Red
        '        g.DrawLine(p, CInt(sx), CInt(sy), CInt(sx - r), CInt(sy + r))
        '    End If
        '    For j = 0 To k - 1
        '        g.DrawLine(Pens.Red, CInt(sx + (10 * j)), CInt(sy + (10 * j)), CInt(sx + (10 * j) - r), CInt(sy + (10 * j) + r))
        '    Next
        'Next

    End Sub
End Class
