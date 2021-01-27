Public Class Form1
    Dim locationX = 530
    Dim locationY = 20
    Dim k As Integer = 1
    Dim fuc As New List(Of String)
    Dim path As New List(Of List(Of Point))
    Dim g As Graphics
    Dim obj = CreateObject("ScriptControl")

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim text As New TextBox
        locationY += 30
        With text
            .Location = New Point(locationX, locationY)
            .Size = New Size(300, 20)
            .Visible = True
            .Name = "TextBox" & k
        End With
        Me.Controls.Add(text)
        AddHandler (text.KeyDown), AddressOf tb_k
        k += 1
    End Sub

    Private Sub tb_k(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim obj As TextBox = sender
        If e.KeyCode = 13 Then
            fuc.Add(obj.Text)
            obj.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        g = PictureBox1.CreateGraphics
        '500 500
        g.Clear(Color.White)

        Dim n As Integer = 0
        For x = -10 To 10 Step 5
            If x = 0 Then
                n += 1
                Continue For
            End If
            g.DrawString(x, Me.Font, Brushes.Black, New Point(0 + (n * 120) + 3, 250))
            n += 1
        Next
        n = 0
        For y = -10 To 10 Step 5
            g.DrawString(y, Me.Font, Brushes.Black, New Point(235, 500 - n * 120 - 10))
            n += 1
        Next

        '500/20 = 25
        For x = -10 To 10
            g.DrawLine(Pens.LightGray, New Point((x + 10) * 25, 0), New Point((x + 10) * 25, 500))
        Next
        For y = -10 To 10
            g.DrawLine(Pens.LightGray, New Point(0, (y + 10) * 25), New Point(500, (y + 10) * 25))
        Next

        'x y 
        g.DrawLine(Pens.Black, New Point(250, 0), New Point(250, 500))
        g.DrawLine(Pens.Black, New Point(0, 250), New Point(500, 250))
        For i = 0 To fuc.Count - 1
            Dim datas = fuc(i).Split("=")

            drawFunc(datas(0), datas(1))
        Next

    End Sub
    Private Function drawFunc(ByVal T As String, ByVal str As String)

        Dim ops = {"+", "-", "*", "/", "^", "sin", "cos", "x", "y"}

        Dim l As New List(Of Point)
        Dim v As Decimal = 0
        Dim n As Decimal
        For n = -10 To 10 Step 0.1
            Dim temp = str.Replace(IIf(T = "x", "y", "x"), n)
            ' y = 5x
            ' y = x^2 +x^3
            'v = obj.eval(temp)
            v = checkIs(T, str, n)
            If T = "y" Then

                l.Add(New Point((n + 10) * 25, (10 - v) * 25))
            Else
                l.Add(New Point((v + 10) * 25, (10 - n) * 25))
            End If
        Next

        Dim pen As New Pen(Color.FromArgb(Rnd() * 255, Rnd() * 255, Rnd() * 255))
        pen.Width = 1.8
        g.DrawLines(pen, l.ToArray)

    End Function
    Function checkIs(ByVal T As String, ByVal str As String, ByVal n As Decimal)
        Dim v As Decimal = 0
        Dim ops = {"+", "-", "*", "/", "^", "c", "s", "x", "y"}
        str = str.Replace("sinx", "s")
        str = str.Replace("cosx", "c")
        str = str.Replace("siny", "s")
        str = str.Replace("cosy", "c")
        Dim temp = str.Replace(IIf(T = "x", "y", "x"), n)
        'y = 5x
        'y = 1234x
        '+空白
        Dim s As String = ""

        For i = 0 To Len(str) - 1
            '左或右是數字的話 不加上space
            If ops.Contains(str(i)) = True Then
                s &= " " & str(i) & " "
            Else
                s &= str(i)
            End If

        Next
        '一格60度 x = 1 => 60度
        Dim datas = s.Split(" ")
        Dim q As New Queue
        For i = 0 To UBound(datas)
            If datas(i) = "" Then Continue For
            If datas(i) = "x" Or datas(i) = "y" Then
                q.Enqueue(n)
            ElseIf datas(i) = "s" Then
                q.Enqueue(Math.Sin(n / 3 * 180 * Math.PI / 180))
            ElseIf datas(i) = "c" Then
                q.Enqueue(Math.Cos(n / 3 * 180 * Math.PI / 180))
            Else
                q.Enqueue(datas(i))
            End If
        Next

        Dim ans As New Queue
        Dim twoNumber As Integer = 0
        Do Until q.Count = 0
            If ans.Count = 0 Then ans.Enqueue(q.Dequeue) : Continue Do
            If IsNumeric(ans(ans.Count - 1)) = True And IsNumeric(q.Peek) = True Then
                ans.Enqueue("*")
                ans.Enqueue(q.Dequeue)
            Else
                ans.Enqueue(q.Dequeue)
            End If
        Loop
        v = obj.eval(String.Join("", ans.ToArray))
        Return v
    End Function
    Function cal(ByVal v1 As Double, ByVal v2 As Double, ByVal os As String)
        Select Case os
            Case "+"
                Return v1 + v2
            Case "-"
                Return v1 - v2
            Case "*"
                Return v1 * v2
            Case "/"
                Return v1 / v2
            Case "^"
                Return v1 ^ v2
        End Select

    End Function
    Function checkW(ByVal o As String)
        Select Case o
            Case "+", "-"
                Return 1
            Case "*", "/"
                Return 2
            Case "^"
                Return 3
            Case -1
                Return -1
        End Select
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        obj.language = "VBScript"
    End Sub
End Class
