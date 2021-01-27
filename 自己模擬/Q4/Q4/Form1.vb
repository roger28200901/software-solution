Public Class Form1
    Dim locationX As Integer = 540
    Dim locationY As Integer = 40
    Dim k As Integer = 1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txt As New TextBox
        With txt
            .Location = New Point(locationX, locationY)
            .Size = New Size(200, 20)
            .Visible = True
            .Name = "TextBox" & k
        End With
        Me.Controls.Add(txt)
        locationY += 30
        k += 1

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        drawMap()
        drawFunc()
    End Sub
    Private Sub drawFunc()
        For i = 1 To k - 1
            Dim txt = Me.Controls("TextBox" & i).Text
            Dim datas = txt.Split("=")
            If datas(0) <> "" And datas(1) <> "" Then
                inputFunc(datas(0), datas(1))
            End If
        Next
    End Sub
    Private Sub inputFunc(ByVal T As String, ByVal T2 As String)
        Dim T3 As String
        T2 = T2.Replace("cosx", "c") : T2 = T2.Replace("sinx", "s")

        For i = 0 To Len(T2) - 1
            If IsNumeric(T2(i)) = True Or T2(i) = "." Then
                T3 &= T2(i)
            Else
                T3 &= " " & T2(i) & " "
            End If
        Next
        Dim sData = T3.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim q As New Queue
        Dim twoNumber As Integer = 0
        For i = 0 To UBound(sData)
            If IsNumeric(sData(i)) = True Or sData(i) = "x" Or sData(i) = "y" Then
                twoNumber += 1
            Else
                twoNumber = 0
            End If
            q.Enqueue(sData(i))
            If twoNumber = 2 Then
                q.Enqueue("*")
                twoNumber = 0
            End If
        Next
        Dim p As New List(Of Point)

        Dim pen As New Pen(Color.FromArgb(CInt(Rnd() * 256), CInt(Rnd() * 256), CInt(Rnd() * 256)))
        Dim xx As Decimal = 0
        For xx = -10 To 10 Step 0.1
            Dim v = infixToPosifix(q, xx)
            If T = "x" Then
                p.Add(New Point((10 + v) * 25, (10 - xx) * 25))
            Else
                p.Add(New Point((10 + xx) * 25, (10 - v) * 25))
            End If
        Next
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.DrawLines(pen, p.ToArray)

    End Sub
    Function infixToPosifix(ByVal q As Queue, ByVal n As Decimal)
        Dim s As New Stack
        s.Push(0)
        Dim ans As New Queue
        For i = 0 To q.Count - 1
            If q(i) = "x" Or q(i) = "y" Then
                ans.Enqueue(n)
                Continue For
            ElseIf IsNumeric(q(i)) = True Then
                ans.Enqueue(q(i))
                Continue For
            ElseIf q(i) = "s" Then
                Dim sin = Math.Sin(n / 3 * 180 / 180 * Math.PI)
                ans.Enqueue(sin)
                Continue For
            ElseIf q(i) = "c" Then
                Dim cos = Math.Cos(n / 3 * 180 / 180 * Math.PI)
                ans.Enqueue(cos)
                Continue For
            End If
            If weight(s.Peek) < weight(q(i)) Then
                s.Push(q(i))
            Else
                Do Until weight(s.Peek) < weight(q(i))
                    ans.Enqueue(s.Pop())
                Loop
                s.Push(q(i))
            End If
        Next
        Do Until s.Count = 1
            ans.Enqueue(s.Pop)
        Loop
        'infix to cal
        Dim s2 As New Stack
        Dim ops = {"+", "-", "*", "/", "^","s","c"}
        For i = 0 To ans.Count - 1
            If ops.Contains(ans(i)) Then
                Dim v2 = s2.Pop()
                Dim v1 = s2.Pop()
                Dim v = cal(v1, v2, ans(i))
                s2.Push(v)
            Else
                s2.Push(ans(i))
            End If
        Next

        Return s2.Pop

    End Function
    Function cal(ByVal v1 As Double, ByVal v2 As Double, ByVal o As String)
        Select Case o
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
    Function weight(ByVal s As String)
        Select Case s
            Case "+", "-"
                Return 1
            Case "*", "/"
                Return 2
            Case "^"
                Return 3
        End Select
    End Function
    Private Sub drawMap()
        Dim g As Graphics = PictureBox1.CreateGraphics

        g.Clear(Color.White)



        For x = -10 To 10
            g.DrawLine(Pens.LightGray, New Point((10 + x) * 25, 0), New Point((10 + x) * 25, 500))
        Next

        For y = -10 To 10
            g.DrawLine(Pens.LightGray, New Point(0 * 25, (10 - y) * 25), New Point(500, (10 - y) * 25))
        Next
        'x軸
        g.DrawLine(Pens.Black, New Point(0, 250), New Point(500, 250))
        'y軸
        g.DrawLine(Pens.Black, New Point(250, 0), New Point(250, 500))
        For x = -10 To 10
            If x Mod 5 = 0 Then
                g.DrawString(x, New Font("標楷體", 12), Brushes.Black, New Point((10 + x) * 24, 250))
            End If
        Next
        For y = -10 To 10
            If y Mod 5 = 0 And y <> 0 Then
                g.DrawString(y.ToString.PadLeft(3, " "), New Font("標楷體", 12), Brushes.Black, New Point(220, (10 - y) * 24))
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
    End Sub
End Class
