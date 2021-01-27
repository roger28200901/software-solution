Public Class Form1
    Dim GameStart As Boolean = False
    Dim map(3, 3) As Button
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()

        For y = 1 To 3
            For x = 1 To 3
                Dim k As Integer = (y - 1) * 3 + x
                map(x, y) = Controls("Button" & k)
            Next
        Next
    End Sub
    Private Sub Button_click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        If GameStart = False Then
            If CheckInput() = False Then
                MsgBox("輸入符號無效!")
                Exit Sub
            Else
                TextBox1.Enabled = False
                TextBox2.Enabled = False
            End If
        End If

        Dim obj As Button = sender
        obj.Text = TextBox1.Text
        obj.Enabled = False
        If checkGameOver("甲方", obj.Text) = True Then
            Label3.Text = "甲方獲勝"
            setAll()
            Exit Sub
        End If
        If checkNoWin() = True Then
            Label3.Text = "和局"
            setAll()
            Exit Sub
        End If
        computerPlay(TextBox2.Text)
        If checkGameOver("乙方", TextBox2.Text) = True Then
            Label3.Text = "乙方獲勝"
            setAll()
            Exit Sub
        End If

    End Sub
    Private Sub setAll()
        For i = 1 To 3
            For j = 1 To 3
                map(i, j).Enabled = False
            Next
        Next
    End Sub
    Private Function checkNoWin()
        Dim count = 0
        For i = 1 To 9
            If Controls("Button" & i).Enabled = False Then
                count += 1
            End If
        Next
        If count = 9 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function checkGameOver(ByVal f As String, ByVal o As String)
        '橫向
        For y = 1 To 3
            Dim count = 0
            For x = 1 To 3
                If map(x, y).Text = o Then
                    count += 1
                End If
            Next
            If count = 3 Then
                Return True
            End If
        Next
        '直向
        For x = 1 To 3
            Dim count = 0
            For y = 1 To 3
                If map(x, y).Text = o Then
                    count += 1
                End If
            Next
            If count = 3 Then
                Return True
            End If
        Next

        '斜線
        Dim count2 As Integer = 0
        For y = 1 To 3
            For x = y To y
                If map(x, y).Text = o Then
                    count2 += 1
                End If
            Next
        Next

        If count2 = 3 Then
            Return True
        End If
        count2 = 0

        If map(2, 2).Text = o Then
            count2 += 1
        End If
        For y = -1 To 1 Step 2
            If map(2 + y, 2 - y).Text = o Then
                count2 += 1
            End If
        Next

        If count2 = 3 Then
            Return True
        End If
        Return False
    End Function
    Private Function CheckInput()
        Dim player1 = TextBox1.Text
        Dim player2 = TextBox2.Text


        '65- 97
        '97-122
        If player1.Count <> 1 Or player2.Count <> 1 Then
            Return False
        End If
        If Not ((Asc(Mid(player1, 1, 1)) >= 65 And Asc(Mid(player1, 1, 1)) <= 97) Or (Asc(Mid(player1, 1, 1)) >= 97 And Asc(Mid(player1, 1, 1)) <= 122)) = True Then
            Return False
        End If
        If Not ((Asc(Mid(player2, 1, 1)) >= 65 And Asc(Mid(player2, 1, 1)) <= 97) Or (Asc(Mid(player2, 1, 1)) >= 97 And Asc(Mid(player2, 1, 1)) <= 122)) = True Then
            Return False
        End If
        Return True
    End Function
    Function computerPlay(ByVal o As String)
        Dim k = CInt(Rnd() * 8 + 1)
        Do While Controls("Button" & k).Enabled = False
            k = CInt(Rnd() * 8 + 1)
        Loop
        Controls("Button" & k).Text = o
        Controls("Button" & k).Enabled = False
    End Function
End Class
