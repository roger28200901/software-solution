Public Class Form1
    Dim q() As Integer = {0, 0, 0, 0, 35, 128}
    Dim tbox(5)
    Dim lastNumber = 6
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As Integer = Rnd() * 1000
S:
        Dim full As Boolean = False

        For i = 0 To UBound(q)
            If q(i) = 0 Or q(i) = Nothing Then
                q(i) = r
                textt.Text = "Added  " & r
                Exit For
            End If
            If i = UBound(q) Then
                full = True
            End If
        Next

        If full = True Then
            Array.Resize(q, (UBound(q) + 7))
            Array.Resize(tbox, UBound(tbox) + 7)
            insertNewTextBox()
            GoTo S
        End If

        For j = 0 To UBound(tbox)
            If q(j) <> 0 Then
                tbox(j).text = q(j)
            Else
                tbox(j).text = ""
            End If
        Next

    End Sub
    Private Sub insertNewTextBox()
        '156 192 delta = 36
        Dim lastPointX = Controls("TextBox" & lastNumber).location.x
        Dim lastPointY = Controls("TextBox" & lastNumber).location.y
        For i = 1 To 6
            Dim t As New TextBox

            lastNumber += 1
            With t
                .Location = New Point(lastPointX + i * 36, lastPointY)
                .Size = New Size(30, 30)
                .Visible = True
                .Multiline = True
                .Name = "TextBox" & lastNumber
            End With
            Me.Controls.Add(t)
        Next
        Dim count = 0
        For i = 0 To UBound(tbox)
            tbox(i) = Controls("TextBox" & i + 1)
        Next


    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        For i = 1 To 6
            tbox(i - 1) = Controls("TextBox" & i)
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim empty As Boolean = False
        For i = 0 To UBound(q)
            If q(i) <> 0 Then
                Dim temp = q(i)
                q(i) = 0
                textt.Text = "Removed  " & temp
                Exit For
            End If
            If i = UBound(q) Then
                empty = True
                Exit For
            End If
        Next

        For j = 0 To UBound(tbox)
            If q(j) <> 0 Then
                tbox(j).text = q(j)
            Else
                tbox(j).text = ""
            End If
        Next

        If empty = True Then
            textt.Text = "Queue is empty"
        End If
    End Sub
End Class
