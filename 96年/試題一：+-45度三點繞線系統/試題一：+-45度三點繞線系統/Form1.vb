Public Class Form1
    Dim p As New Stack(Of Point)
    Dim node As New ArrayList
    Dim node1 As Point : Dim node2 As Point

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        p.Clear()
        node.Clear()

        Dim node1 As Point
        Dim node2 As Point



        For i = 1 To 3
            Dim x As Integer = Rnd() * 260 + 20
            Dim y As Integer = Rnd() * 160 + 20
            p.push(New Point(x, y))
        Next

        For Each item In p
            node.Add(item)
        Next


        '畫出三個點
        For i = 0 To 2
            g.FillEllipse(Brushes.Black, p(i).X - 3, p(i).Y - 3, 6, 6)
            'g.FillPie(Brushes.Black, p(i).X, p(i).Y, 5, 5, 0, 360)
        Next

        Dim visit As New ArrayList


        '找到垂直中間的點 並且sort陣列回傳
        Dim nowNode As Point = findVerticalCenterPoint(node)


        node1 = New Point(node(0).x, nowNode.Y)
        node2 = New Point(node(2).x, nowNode.Y)
        node.Add(node1) : node.Add(node2)

        Dim LenList As New List(Of Integer)
        For i = 0 To node.Count - 1
            Dim a As Point = node(i)
            For j = 0 To node.Count - 1
                If a.Equals(node(j)) = False Then
                    Dim b As Point = node(j)
                    If a.X = b.X Or a.Y = b.Y Then
                        g.DrawLine(Pens.Black, a, b)
                        Dim lengthDelta As Integer = Math.Sqrt((a.X - b.X) ^ 2 + (a.Y - b.Y) ^ 2)
                        If LenList.Contains(lengthDelta) = False Then LenList.Add(lengthDelta)
                    End If
                End If
            Next
        Next

        Dim l = LenList.Sum()
        TextBox1.Text = l


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
    End Sub
    Private Function findVerticalCenterPoint(ByVal ar As ArrayList)
        For i = 0 To 2
            Dim a As Point = ar(i)
            For j = 0 To 2
                Dim b As Point = ar(j)
                If a.Y > b.Y Then
                    Dim temp = ar(i)
                    ar(i) = ar(j)
                    ar(j) = temp
                End If
            Next
        Next
        Return ar(1)
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim g As Graphics = PictureBox1.CreateGraphics

        Dim nodeRoute As New ArrayList
        nodeRoute.Add(node(1))


        If node(1).x < node(0).x And node(1).x < node(2).x And node(0).x > node(2).x Then '1 2 0
            '''''上面的點
            Dim up As Point = node(2)
            Dim delta = Math.Abs(up.Y - node(1).y)
            Dim newPoint As New Point(up.X, up.Y)
            Dim newNode As New Point(up.X - delta, node(1).y)

            nodeRoute.Add(newPoint)
            nodeRoute.Add(newNode)

            '下面的點
            up = node(0)
            delta = Math.Abs(up.Y - node(1).y)

            newPoint = New Point(up.X, up.Y)
            newNode = New Point(up.X - delta, node(1).y)

            nodeRoute.Add(newPoint)
            nodeRoute.Add(newNode)

            g.DrawLine(Pens.Red, nodeRoute(1), nodeRoute(2)) ' 第一條
            g.DrawLine(Pens.Red, nodeRoute(0), nodeRoute(4)) ' 直線全部
            g.DrawLine(Pens.Red, nodeRoute(3), nodeRoute(4)) ' 第二條

            Dim l As New List(Of Integer)
            l.Add(Math.Sqrt((nodeRoute(1).x - nodeRoute(2).x) ^ 2 + (nodeRoute(1).y - nodeRoute(2).y) ^ 2))
            l.Add(Math.Sqrt((nodeRoute(3).x - nodeRoute(4).x) ^ 2 + (nodeRoute(3).y - nodeRoute(4).y) ^ 2))
            l.Add(Math.Sqrt((nodeRoute(0).x - nodeRoute(4).x) ^ 2 + (nodeRoute(0).y - nodeRoute(4).y) ^ 2))
            Dim sum = l.Sum()
            TextBox2.Text = sum

        ElseIf node(1).x < node(0).x And node(1).x > node(2).x And node(2).x < node(0).x Then '2 1 0
            Dim up As Point = node(2)
            Dim delta = Math.Abs(up.Y - node(1).y)
            Dim newPoint As New Point(up.X, up.Y)
            Dim newNode As New Point(up.X + delta, node(1).y)

            nodeRoute.Add(newPoint)
            nodeRoute.Add(newNode)

            '下面的點
            up = node(0)
            delta = Math.Abs(up.Y - node(1).y)

            newPoint = New Point(up.X, up.Y)
            newNode = New Point(up.X - delta, node(1).y)

            nodeRoute.Add(newPoint)
            nodeRoute.Add(newNode)

            g.DrawLine(Pens.Red, nodeRoute(1), nodeRoute(2)) ' 第一條
            g.DrawLine(Pens.Red, nodeRoute(2), nodeRoute(4)) ' 直線全部
            g.DrawLine(Pens.Red, nodeRoute(3), nodeRoute(4)) ' 第二條

            Dim l As New List(Of Integer)
            l.Add(Math.Sqrt((nodeRoute(1).x - nodeRoute(2).x) ^ 2 + (nodeRoute(1).y - nodeRoute(2).y) ^ 2))
            l.Add(Math.Sqrt((nodeRoute(3).x - nodeRoute(4).x) ^ 2 + (nodeRoute(3).y - nodeRoute(4).y) ^ 2))
            l.Add(Math.Sqrt((nodeRoute(2).x - nodeRoute(4).x) ^ 2 + (nodeRoute(2).y - nodeRoute(4).y) ^ 2))
            Dim sum = l.Sum()
            TextBox2.Text = sum

        ElseIf node(0).x > node(2).x And node(0).x < node(1).x And node(1).x > node(2).x Then ' 2 0 1
            Dim up As Point = node(2)
            Dim delta = Math.Abs(up.Y - node(1).y)
            Dim newPoint As New Point(up.X, up.Y)
            Dim newNode As New Point(up.X + delta, node(1).y)

            nodeRoute.Add(newPoint)
            nodeRoute.Add(newNode)
            nodeRoute.Add(node(3))
            '下面的點
            nodeRoute.Add(node(0))
            g.DrawLine(Pens.Red, nodeRoute(1), nodeRoute(2)) ' 第一條
            g.DrawLine(Pens.Red, nodeRoute(2), nodeRoute(0)) ' 直線全部
            g.DrawLine(Pens.Red, nodeRoute(3), nodeRoute(4)) ' 第二條

            Dim l As New List(Of Integer)
            l.Add(Math.Sqrt((nodeRoute(1).x - nodeRoute(2).x) ^ 2 + (nodeRoute(1).y - nodeRoute(2).y) ^ 2))
            l.Add(Math.Sqrt((nodeRoute(3).x - nodeRoute(4).x) ^ 2 + (nodeRoute(3).y - nodeRoute(4).y) ^ 2))
            l.Add(Math.Sqrt((nodeRoute(2).x - nodeRoute(0).x) ^ 2 + (nodeRoute(2).y - nodeRoute(0).y) ^ 2))
            Dim sum = l.Sum()
            TextBox2.Text = sum
        End If

        saving()

    End Sub
    Private Sub saving()
        Dim v1 = Val(TextBox1.Text)
        Dim v2 = Val(TextBox2.Text)
        Dim sum = (v1 - v2) / v2
        TextBox3.Text = Format(sum, "0.0%")
    End Sub
End Class
