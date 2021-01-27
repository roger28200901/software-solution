Public Class Form1
    Dim map(,) As Integer
    Dim mt(,) As TextBox
    Dim counter As Integer = 1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n As Integer = tn.Text
        counter = 1

        If n < 3 Or n > 11 Or n Mod 2 = 0 Then
            er.Text = "錯誤"
            Exit Sub
        End If


        For Each item In Me.Controls
            If item.GetType() Is GetType(TextBox) Then
                If item.Name <> "er" And item.Name <> "tn" Then
                    Me.Controls.Remove(item)
                End If
            End If
        Next

        ReDim map(n, n)
        ReDim mt(n, n)

        For i = 1 To n
            For j = 1 To n
                Dim text As New TextBox
                Dim k As Integer = (i - 1) * n + j
                With text
                    .Name = "TextBox" & k
                    .Location = New Point(50 + (j - 1) * 30, 50 + (i - 1) * 30)
                    .Size = New Size(25, 25)
                    .Multiline = True
                    .Visible = True
                End With
                mt(i, j) = text
                Me.Controls.Add(text)
            Next
        Next

        Dim center = Math.Ceiling(n / 2)

        map(center, 1) = 1
        solve2(center, 1, n)

        For y = 1 To n
            For x = 1 To n
                Dim k As Integer = (y - 1) * n + x
                Me.Controls("TextBox" & k).Text = map(x, y)
            Next
        Next
        er.Text = "成功"

    End Sub
    Private Sub solve2(ByVal x As Integer, ByVal y As Integer, ByVal n As Integer)
        If counter = n ^ 2 Then
            Exit Sub
        End If
        Dim tx As Integer, ty As Integer
        If x - 1 = 0 Then
            tx = n
        Else
            tx = x - 1
        End If
        If y - 1 = 0 Then
            ty = n
        Else
            ty = y - 1
        End If

        '左一上一
        If map(tx, ty) = 0 Then
            counter += 1
            map(tx, ty) = counter
            solve2(tx, ty, n)
            Exit Sub
        Else '下一
            tx = x
            If y + 1 > n Then
                ty = 1
            Else
                ty = y + 1
            End If
            counter += 1
            map(tx, ty) = counter
            solve2(tx, ty, n)
        End If


    End Sub
End Class
