Public Class Form1
    Dim btn(9) As Button
    Dim sequence = 1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim player1 As player = New player(TextBox1.Text)
        Dim player2 As player = New player(TextBox2.Text)
        For i = 1 To 9
            btn(i) = Controls("Button" & i)
        Next
    End Sub
    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click

        If sender.text <> "" Then
            Exit Sub
        End If
        If sequence = 1 Then
            '確認甲方 英文
            If checkIsEnglish(TextBox1.Text) = False Then
                MsgBox("輸入的符號無效")
                Exit Sub
            End If
            sender.Text = TextBox1.Text
        Else
            If checkIsEnglish(TextBox2.Text) = False Then
                MsgBox("輸入的符號無效")
                Exit Sub
            End If
            sender.Text = TextBox2.Text
        End If

        If checkGameOver() = True Then
            If sequence = 1 Then
                Label3.Text = "甲方獲勝"
            Else
                Label3.Text = "乙方獲勝"
            End If

            Exit Sub
        End If
        If checkNoWin() Then
            Label3.Text = "和局"
            Exit Sub
        End If

        If sequence = 1 Then
            sequence = 2
        Else
            sequence = 1
        End If


    End Sub
    Private Function checkNoWin()
        Dim map(3, 3) As Button
        Dim k As Integer = 1
        For i = 1 To 3
            For j = 1 To 3
                map(i, j) = btn(k)
                k += 1
            Next
        Next
        Dim count = 0
        For i = 1 To 3
            For j = 1 To 3
                If map(i, j).Text <> "" Or map(i, j).Text <> Nothing Then
                    count += 1
                End If
            Next
        Next
        If count = 9 Then
            Return True
        End If
    End Function
    Private Function checkIsEnglish(ByVal s As String)
        s = s.ToUpper
        If Asc(s) >= 65 And Asc(s) < 90 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function checkGameOver()
        If sequence = 1 Then
            Dim map(3, 3) As Button
            Dim k As Integer = 1
            For i = 1 To 3
                For j = 1 To 3
                    map(i, j) = btn(k)
                    k += 1
                Next
            Next
            For i = 1 To 3
                Dim count = 0
                For j = 1 To 3
                    If map(i, j).Text = TextBox1.Text Then
                        count += 1
                    End If
                Next
                If count = 3 Then
                    Return True
                End If
            Next
            For i = 1 To 3
                Dim count = 0
                For j = 1 To 3
                    If map(j, i).Text = TextBox1.Text Then
                        count += 1
                    End If
                    If count = 3 Then
                        Return True
                    End If
                Next
            Next

            Dim count1 = 0
            For i = 1 To 3
                If map(i, i).Text = TextBox1.Text Then
                    count1 += 1
                End If
            Next
            If count1 = 3 Then
                Return True
            End If

            For i = 1 To 3
                If map(i, i).Text = TextBox1.Text Then
                    count1 += 1
                End If
            Next

            Dim count2 = 0
            For i = -1 To 1
                If map(i + 2, i + 2).Text = TextBox1.Text Then
                    count2 += 1
                End If
            Next

            If count1 = 3 Then
                Return True
            End If
            If count2 = 3 Then
                Return True
            End If
        Else
            Dim map(3, 3) As Button
            Dim k As Integer = 1
            For i = 1 To 3
                For j = 1 To 3
                    map(i, j) = btn(k)
                    k += 1
                Next
            Next
            For i = 1 To 3
                Dim count = 0
                For j = 1 To 3
                    If map(i, j).Text = TextBox2.Text Then
                        count += 1
                    End If
                Next
                If count = 3 Then
                    Return True
                End If
            Next
            For i = 1 To 3
                Dim count = 0
                For j = 1 To 3
                    If map(j, i).Text = TextBox2.Text Then
                        count += 1
                    End If
                    If count = 3 Then
                        Return True
                    End If
                Next
            Next

            Dim count1 = 0
            For i = 1 To 3
                If map(i, i).Text = TextBox2.Text Then
                    count1 += 1
                End If
            Next
            If count1 = 3 Then
                Return True
            End If

            For i = 1 To 3
                If map(i, i).Text = TextBox2.Text Then
                    count1 += 1
                End If
            Next

            Dim count2 = 0
            For i = -1 To 1
                If map(i + 2, i + 2).Text = TextBox2.Text Then
                    count2 += 1
                End If
            Next

            If count1 = 3 Then
                Return True
            End If
            If count2 = 3 Then
                Return True
            End If
        End If


    End Function
End Class
Class player
    Public shape As String
    Public Sub New(ByVal s As String)
        Me.shape = s
    End Sub
End Class
