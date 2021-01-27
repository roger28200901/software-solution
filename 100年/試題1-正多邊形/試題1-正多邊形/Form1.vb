Imports System.Threading
Public Class Form1

    Dim gph As Graphics

    Dim tg As Graphics
    Dim gpen As New Pen(Color.Black)
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gph = PictureBox1.CreateGraphics()
        tg = PictureBox2.CreateGraphics()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '畫布為PictureBox
        'CreateGraphics 是將PictureBox Form.Control 直接建立成物件
        Dim g As Graphics = PictureBox1.CreateGraphics()

        'Pen物件
        Dim pen As New Pen(Color.Black)

        'Point物件
        Dim p1 As New Point(100, 100)
        Dim p2 As New Point(200, 200)

        g.DrawLine(pen, p1, p2)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim g As Graphics = PictureBox1.CreateGraphics()
        Dim pen As New Pen(Color.Black)

        Dim p As New Point(100, 100)
        Dim p1 As Point = getNewPoint(p, 0, 100)
        Dim p2 As Point = getNewPoint(p, 120, 100)
        Dim p3 As Point = getNewPoint(p, 240, 100)

        g.DrawLine(pen, p1, p2)
        g.DrawLine(pen, p2, p3)
        g.DrawLine(pen, p3, p1)
    End Sub
    Private Sub start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles start.Click

        Dim radius = 100
        Dim circlePoint As New Point(250, 250)
        Dim pointList As New List(Of Point)


        Dim n = TextBox1.Text

        If n = String.Empty Then
            MsgBox("不得為空")
            Return
        End If

        If n < 3 Then
            MsgBox("n介於3~10")
            Return
        ElseIf n > 10 Then
            MsgBox("n介於3~10")
            Return
        End If

        Dim p As New Point(250, 250)
        pointList = process(n, radius, pointList, p)

        Dim p1 = pointList(0)
        Dim p2 = pointList(1)
        Dim p3 = pointList(2)


        drawLine(pointList)


    End Sub
    Private Function getNewPoint(ByVal point As Point, ByVal angle As Integer, ByVal length As Integer)

        point.X = point.X + Math.Cos(angle / 180 * Math.PI) * length
        point.Y = point.Y + Math.Sin(angle / 180 * Math.PI) * length

        Return point
    End Function

    Function process(ByVal n As Integer, ByVal radius As Integer, ByVal pointList As List(Of Point), ByVal p As Point)

        Dim t As Integer = n
        Do Until t = 0
            Dim angle = 360 * t / n
            Dim x = radius * Math.Cos(angle / 180 * Math.PI) + p.X
            Dim y = radius * Math.Sin(angle / 180 * Math.PI) + p.Y
            Dim point As New Point(x, y)
            pointList.Add(point)
            t -= 1
        Loop

        Return pointList
    End Function

    Function drawLine(ByVal pointList As List(Of Point))


        ListBox1.Items.Clear()

        For i = 0 To pointList.Count - 1
            Dim p1 As Point = pointList(i)
            ListBox1.Items.Add(p1)
            For j = 0 To pointList.Count - 1
                Dim p2 As Point = pointList(j)
                gph.DrawLine(gpen, p1, p2)

                Thread.Sleep(100)
            Next
        Next

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        gpen.Color = Color.Red
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        gpen.Color = Color.Green
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        gpen.Color = Color.Blue
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim pen As New Pen(Color.Black)



        Dim hr = DateTime.Now.ToString("HH")
        Dim min = DateTime.Now.ToString("mm")
        Dim sec = DateTime.Now.ToString("ss")
        Dim tpoint As Point
        Dim hourPen As New Pen(Color.Red)
        Dim p As New Point(100, 100)
        tg.Clear(Color.White)
        tg.DrawEllipse(pen, 0, 0, 220, 220)


        Dim n As Integer = 12
        
        Dim fontList As New List(Of Point)

        fontList = process(n, 100, fontList, p)
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)


        Dim time() As String = {3, 2, 1, 12, 11, 10, 9, 8, 7, 6, 5, 4}
        For i = 0 To fontList.Count - 1
            Dim s As String = time(i)

            Dim font As New Font(TextBox1.Font.FontFamily, 14, FontStyle.Bold)
            Dim x As Single = fontList(i).X
            Dim y As Single = fontList(i).Y
            tg.DrawString(s, font, Brushes.Black, x, y)
            
        Next
        '
        Dim plusAngle = (min / 60) * 30


        tpoint.X = 60 * Math.Cos(((hr - 3) * 30 + plusAngle) / 180 * Math.PI) + 100
        tpoint.Y = 60 * Math.Sin(((hr - 3) * 30 + plusAngle) / 180 * Math.PI) + 100

        Dim mpoint As Point
        

        mpoint.X = 80 * Math.Cos((min - 15) * 6 / 180 * Math.PI) + 100
        mpoint.Y = 80 * Math.Sin((min - 15) * 6 / 180 * Math.PI) + 100

        Dim spoint As Point

        spoint.X = 100 * Math.Cos(sec * 6 / 180 * Math.PI) + 100
        spoint.Y = 100 * Math.Sin(sec * 6 / 180 * Math.PI) + 100


        tg.DrawLine(Pens.Pink, p, tpoint)
        tg.DrawLine(Pens.Blue, p, mpoint)
        tg.DrawLine(Pens.Green, p, spoint)

    End Sub
End Class
