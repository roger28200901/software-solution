Public Class Form1
    Dim tbox(3) As TextBox
    Dim btn(3) As Button
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        For i = 0 To 3
            Dim rs As String = ""
            For j = 1 To 8
                rs &= CInt(Rnd())
            Next
            tbox(i).Text = rs
        Next
        For i = 0 To 3
            btn(i).Text = "Ih"
        Next
    End Sub
    Private Sub button_click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click
        If sender.text = "Ih" Then
            sender.text = "Ld"
            Exit Sub
        End If
        If sender.text = "Ld" Then
            sender.text = "En"
            Exit Sub
        End If
        If sender.text = "En" Then
            sender.text = "Ih"
            Exit Sub
        End If

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()

        For i = 1 To 4
            tbox(i - 1) = Controls("TextBox" & i)
        Next
        For i = 1 To 4
            btn(i - 1) = Controls("Button" & i)
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim count As Integer = 0
        Dim index As Integer = -1
        For i = 0 To 3
            If btn(i).Text = "En" Then
                count += 1
                index = i
            End If
        Next

        If count <> 1 Then
            Exit Sub
        End If

        Dim trans = tbox(index).Text
        For i = 0 To 3
            If btn(i).Text = "Ld" Then
                tbox(i).Text = trans
            End If
        Next


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        End
    End Sub
End Class
