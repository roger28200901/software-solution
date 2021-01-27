Public Class Form1
    Dim rans As Integer
    Private Sub frand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles frand.Click
        Randomize()


        Dim f1 As Integer = (Rnd() * 36) + 16
        Dim f2 As Byte = (Rnd() * 7) + 1

        TextBox1.Text = f1
        TextBox2.Text = f2 & "B"

        
    End Sub

    Private Sub fconv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fconv.Click
        Dim f1, f2 As Integer

        f1 = TextBox1.Text
        Dim temp() = TextBox2.Text.Split("B")
        f2 = temp(0)
        Dim f3 As Integer = f1 * f2
        Dim pow As Integer
        Dim powString As String


        Select Case f1
            Case 11 To 19
                pow = f1 - 10
                powString = "KB"
            Case 21 To 29
                pow = f1 - 20
                powString = "MB"
            Case 31 To 39
                pow = f1 - 30
                powString = "GB"
            Case 41 To 49
                pow = f1 - 40
                powString = "TB"
            Case 51 To 52
                pow = f1 - 40
                powString = "TB"
            Case Else
                Dim powCheck = {"KB", "MB", "GB", "TB", "TB"}
                pow = f1 \ 10 - 1
                powString = powCheck(pow)
        End Select

        f3 = Math.Pow(2, pow)
        TextBox3.Text = f3 * f2 & powString
    End Sub

    Private Sub rrand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rrand.Click
        Randomize()

        Dim f1, f2, f3 As Integer
        ' K M G T
        f1 = (Rnd() * 36) + 16
        f2 = (Rnd() * 7) + 1

        Dim pow As Integer
        Dim powString As String
        Select Case f1
            Case 11 To 19
                pow = f1 - 10
                powString = "KB"
            Case 21 To 29
                pow = f1 - 20
                powString = "MB"
            Case 31 To 39
                pow = f1 - 30
                powString = "GB"
            Case 41 To 49
                pow = f1 - 40
                powString = "TB"
            Case 51 To 52
                pow = f1 - 40
                powString = "TB"
            Case Else
                Dim powCheck = {"KB", "MB", "GB", "TB", "TB"}

                pow = f1 \ 10 - 1
                powString = powCheck(pow)
        End Select

        Dim sf1 = Math.Pow(2, pow) * f2 & powString
        rans = Math.Pow(2, pow)


        TextBox4.Text = sf1
        TextBox5.Text = f2 & "B"
    End Sub

    Private Sub rconv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rconv.Click
        Dim sperators = {"KB", "MB", "GB", "TB"}

        Dim t = TextBox4.Text.Split(sperators, StringSplitOptions.RemoveEmptyEntries)(0)

        Dim pow = t(1)

        Dim f1 = Val(t(0))
        Dim f2 = TextBox5.Text.Split("B")(0)

        'no good way to recursive




    End Sub
End Class
