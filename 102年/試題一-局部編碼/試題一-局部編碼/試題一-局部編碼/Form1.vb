Public Class Form1
    Dim map(6, 6)
    Dim weight(3, 3)
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call check()
    End Sub
    Private Sub check()

        Dim r1 = Val(c1.Text)
        Dim r2 = Val(c2.Text)

        For i = 1 To 6
            For j = 1 To 6
                Dim k = (i - 1) * 6 + j
                If GroupBox1.Controls("TextBox" & k).Text < 0 Then
                    MsgBox("這些資料要大於等於0，不可以小於0")
                    Exit Sub
                End If
                map(i - 1, j - 1) = GroupBox1.Controls("TextBox" & k).Text
            Next
        Next

        For i = 1 To 3
            For j = 1 To 3
                Dim k = (i - 1) * 3 + j
                Dim b As Byte = Val(GroupBox2.Controls("power" & k).Text)
               
                If (b And b - 1) <> 0 Then
                    MsgBox("3x3的權重必須是2的次方")
                    Exit Sub
                End If
                weight(i, j) = Val(GroupBox2.Controls("power" & k).Text)
            Next
        Next

        If r1 > 5 Or r1 < 0 Or r2 > 5 Or r2 < 0 Then
            MsgBox("超出座標範圍")
            Exit Sub
        End If

        Dim center = map(r1 + 1, r2 + 1)

        Dim response(3, 3)
        Dim px, py
        For x = r1 To r1 + 2
            px += 1
            For y = r2 To r2 + 2
                py += 1
                If map(x, y) > center Then
                    response(px, py) = 1
                Else
                    response(px, py) = 0
                End If
            Next
            py = 0
        Next

        Dim sum = 0
        For x = 1 To 3
            For y = 1 To 3
                response(x, y) = response(x, y) * weight(x, y)
                sum += response(x, y)
            Next
        Next
        success.Text = sum
    End Sub
End Class
