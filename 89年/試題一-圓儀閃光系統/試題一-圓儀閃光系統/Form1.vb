Imports System.Drawing
Imports System.Threading

Public Class Form1
    Dim count As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call drawPicture(PictureBox1, 0)
    End Sub
    Function getNewPoint(ByVal point As Point, ByVal angle As Integer, ByVal length As Integer)
        point.X += Math.Cos(angle / 180 * Math.PI) * length
        point.Y += Math.Sin(angle / 180 * Math.PI) * length
        Return point
    End Function
    Public Sub drawPicture(ByVal pc As PictureBox, ByVal maxnumber As String)
        Dim bmp As Bitmap = New Bitmap(pc.Width, pc.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)

        Dim pen1 As New Pen(Color.Violet)
        Dim pen2 As New Pen(Color.Blue)
        Dim pen As Pen = pen1

        Dim point As Point = New Point(250, 250)
        Dim newpoint, newpoint2, newpoint3 As Point
        Dim r As Integer

        Dim nr, n1, n2, n3 As Integer
        Dim b1(12), b2(24), b3(48) As Integer

        If maxnumber <> "*" Then
            For i = 1 To Math.Min(3, CInt(maxnumber))
                nr = CInt(Math.Floor(Rnd() * 48))
                If (b3(Math.Floor(nr))) = 1 Then
                    i -= 1
                End If
                b1(Math.Floor(nr / 4)) = 1
                b2(Math.Floor(nr / 2)) = 1
                b3(nr) = 1
            Next
        End If

        For i = 1 To 12
            pen = IIf(b1(n1) = 1 Or maxnumber = "*", pen2, pen1)
            r = i * 360 / 12
            n1 += 1
            newpoint = getNewPoint(point, r, 100)
            g.DrawLine(pen, point, newpoint)
            For j = -1 To 1 Step 2
                pen = IIf(b2(n2) = 1 Or maxnumber = "*", pen2, pen1)
                n2 += 1
                newpoint2 = getNewPoint(newpoint, r + 15 * j, 80)
                g.DrawLine(pen, newpoint, newpoint2)
                For k = -1 To 1 Step 2
                    pen = IIf(b3(n3) = 1 Or maxnumber = "*", pen2, pen1)
                    n3 += 1
                    newpoint3 = getNewPoint(newpoint2, r + j * 15 + k * 15, 60)
                    g.DrawLine(pen, newpoint2, newpoint3)
                Next
            Next
        Next

        g.DrawEllipse(Pens.Brown, point.X - 100, point.Y - 100, 200, 200)
        g.DrawEllipse(Pens.Brown, point.X - 180, point.Y - 180, 360, 360)
        g.DrawEllipse(Pens.Brown, point.X - 240, point.Y - 240, 480, 480)
        pc.Image = bmp

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Timer1.Enabled = Not Timer1.Enabled
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        count += 1
        Console.Write(count)
        If (count = 10) Then
            Call drawPicture(PictureBox1, TextBox1.Text)
            count = 0
        Else
            Call drawPicture(PictureBox1, 0)
        End If
        
    End Sub
End Class
