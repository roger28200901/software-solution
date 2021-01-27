Public Class Form1
    Public Structure line
        Public p1, p2 As Point
    End Structure
    Dim g As Graphics
    Dim pen As New Pen(Color.Black)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim line1 As line

        Dim x1 = Split(TextBox1.Text, ",")(0)
        Dim y1 = Split(TextBox1.Text, ",")(1)

        Dim x2 = Split(TextBox2.Text, ",")(0)
        Dim y2 = Split(TextBox2.Text, ",")(1)


        line1.p1 = New Point(400 + x1 * 10, IIf(y1 > 0, 300 - y1 * 10, 300 + Math.Abs(y1 * 10)))
        line1.p2 = New Point(400 + x2 * 10, IIf(y2 > 0, 300 - y2 * 10, 300 + Math.Abs(y2 * 10)))

        Dim lineX, lineY As line
        lineX.p1 = New Point(0, 300)
        lineX.p2 = New Point(800, 300)
        lineY.p1 = New Point(400, 0)
        lineY.p2 = New Point(400, 800)

        Dim line2 As line
        Dim tx1 = Split(TextBox3.Text, ",")(0)
        Dim ty1 = Split(TextBox3.Text, ",")(1)

        Dim tx2 = Split(TextBox4.Text, ",")(0)
        Dim ty2 = Split(TextBox4.Text, ",")(1)

        line2.p1 = New Point(400 + tx1 * 10, IIf(ty1 > 0, 300 - ty1 * 10, 300 + Math.Abs(ty1 * 10)))
        line2.p2 = New Point(400 + tx2 * 10, IIf(ty2 > 0, 300 - ty2 * 10, 300 + Math.Abs(ty2 * 10)))

        drawProcess(lineX)
        drawProcess(lineY)
        drawProcess(line1)
        drawProcess(line2)
        'draw
        line1.p1 = New Point(x1, y1)
        line1.p2 = New Point(x2, y2)
        line2.p1 = New Point(tx1, ty1)
        line2.p2 = New Point(tx2, ty2)
        Dim m1 = (line1.p1.Y - line1.p2.Y) / (line1.p1.X - line1.p2.X)
        Dim m2 = (line2.p1.Y - line2.p2.Y) / (line2.p1.X - line2.p2.X)

        If m1 <> m2 Then
            
            'Dim b = line1.p1.Y - m1 * line1.p1.X
            'Dim a = m1 * b * (-1)
            'Dim c = -(a * line1.p1.X) - (b * line1.p1.Y)
            'A-B線段
            Dim a = line1.p2.Y - line1.p1.Y
            Dim b = line1.p1.X - line1.p2.X
            Dim c = a * line1.p1.X + b * line1.p1.Y

            Dim d = line2.p2.Y - line2.p1.Y
            Dim es = line2.p1.X - line2.p2.X
            Dim f = d * line2.p1.X + es * line2.p1.Y

            Dim n = (c * es - b * f) / (a * es - b * d)
            Dim o = (c * d - a * f) / (b * d - a * es)
            Dim MaxX, MinX, MaxY, MinY
            Dim S As Boolean = False
            If line1.p1.X > line1.p2.X Then MaxX = line1.p1.X : MinX = line1.p2.X Else MaxX = line1.p2.X : MinX = line1.p1.X
            If line1.p1.Y > line1.p2.Y Then MaxY = line1.p1.Y : MinY = line1.p2.Y Else MaxY = line1.p2.Y : MinY = line1.p1.Y
            If n <= MaxX And n >= MinX And o >= MinY And o <= MaxY Then
                S = True
            Else
                S = False
            End If
            If line2.p1.X > line2.p2.X Then MaxX = line2.p1.X : MinX = line2.p2.X Else MaxX = line2.p2.X : MinX = line2.p1.X
            If line2.p1.Y > line2.p2.Y Then MaxY = line2.p1.Y : MinY = line2.p2.Y Else MaxY = line2.p2.Y : MinY = line2.p1.Y
            If n <= MaxX And n >= MinX And o >= MinY And o <= MaxY Then
                S = True
            Else
                S = False
            End If
            If S = True Then
                TextBox5.Text = "有相交"
                TextBox6.Text = String.Format("{0},{1}", Math.Floor(n * 100) / 100, Math.Floor(o * 100) / 100)
            Else
                TextBox5.Text = "未相交"
                TextBox6.Text = ""
            End If
        Else
            TextBox5.Text = "未相交"
            TextBox6.Text = ""
        End If

        For i = 0 To 6
            g.FillEllipse(Brushes.Black, 400, 50 + i * 100, 5, 5)
        Next
        For j = 0 To 8
            g.FillEllipse(Brushes.Black, j * 100, 300, 5, 5)
        Next
        

    End Sub

    Function drawProcess(ByVal line As line)
        g.DrawLine(pen, line.p1, line.p2)
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        g = PictureBox1.CreateGraphics()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        g.Clear(Color.White)
    End Sub
End Class
