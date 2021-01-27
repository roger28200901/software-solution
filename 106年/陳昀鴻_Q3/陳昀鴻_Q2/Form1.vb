Public Class Form1
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As New Random
        '0. 0.9999
        '0 - 6
        '實際有 1 - 7
        Dim n = CInt(Rnd() * 7)
        Dim enC = {"a", "b", "c", "d", "e", "f", "g"}
        For j = 0 To 6
            Controls("button_" & enC(j)).BackColor = Color.White
        Next
        For i = 0 To n
            Dim l As Integer = Rnd() * 6
            Controls("button_" & enC(l)).BackColor = Color.Red
        Next
        checkNumber()
    End Sub

    Private Sub button_a_Click(sender As Object, e As EventArgs) Handles button_a.Click
        If button_a.BackColor = Color.Red Then
            button_a.BackColor = Color.White
        Else
            button_a.BackColor = Color.Red
        End If
    End Sub
    Private Sub button_b_Click(sender As Object, e As EventArgs) Handles button_b.Click
        If button_b.BackColor = Color.Red Then
            button_b.BackColor = Color.White
        Else
            button_b.BackColor = Color.Red
        End If
    End Sub
    Private Sub button_c_Click(sender As Object, e As EventArgs) Handles button_c.Click
        If button_c.BackColor = Color.Red Then
            button_c.BackColor = Color.White
        Else
            button_c.BackColor = Color.Red
        End If
    End Sub
    Private Sub button_d_Click(sender As Object, e As EventArgs) Handles button_d.Click
        If button_d.BackColor = Color.Red Then
            button_d.BackColor = Color.White
        Else
            button_d.BackColor = Color.Red
        End If
    End Sub
    Private Sub button_e_Click(sender As Object, e As EventArgs) Handles button_e.Click
        If button_e.BackColor = Color.Red Then
            button_e.BackColor = Color.White
        Else
            button_e.BackColor = Color.Red
        End If
    End Sub
    Private Sub button_f_Click(sender As Object, e As EventArgs) Handles button_f.Click
        If button_f.BackColor = Color.Red Then
            button_f.BackColor = Color.White
        Else
            button_f.BackColor = Color.Red
        End If
    End Sub
    Private Sub button_g_Click(sender As Object, e As EventArgs) Handles button_g.Click
        If button_g.BackColor = Color.Red Then
            button_g.BackColor = Color.White
        Else
            button_g.BackColor = Color.Red
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        checkNumber()
    End Sub
    Private Sub checkNumber()
        Dim enC = {"a", "b", "c", "d", "e", "f", "g"}
        Dim number(12)
        Dim numberToReallyNumber = {0, 1, 1, 2, 3, 4, 5, 6, 6, 7, 8, 9, 9}

        number(0) = {"a", "b", "c", "d", "e", "f"}
        number(1) = {"b", "c"}
        number(2) = {"f", "e"}
        number(3) = {"a", "b", "g", "e", "d"}
        number(4) = {"a", "b", "c", "d", "g"}
        number(5) = {"f", "b", "g", "c"}
        number(6) = {"a", "f", "g", "c", "d"}
        number(7) = {"a", "c", "d", "e", "f", "g"}
        number(8) = {"c", "d", "e", "f", "g"}
        number(9) = {"a", "b", "c"}
        number(10) = {"a", "b", "c", "d", "e", "f", "g"}
        number(11) = {"a", "b", "c", "d", "f", "g"}
        number(12) = {"a", "b", "c", "f", "g"}

        Dim checkEn As New ArrayList
        For j = 0 To 6
            If (Controls("button_" & enC(j)).BackColor = Color.Red) Then
                checkEn.Add(enC(j))
            End If
        Next


        For i = 0 To 9
            Dim index = -1
            For j = 0 To 12
                Dim s = number(j)

                If (UBound(s) + 1) = checkEn.Count Then
                    Dim b As Boolean = True

                    For x = 0 To checkEn.Count - 1
                        '當number陣列當中有這個代表繼續
                        Dim na As New ArrayList
                        For Each e In number(j)
                            na.Add(e)
                        Next

                        If na.Contains(checkEn(x)) = True Then
                            Continue For
                        Else
                            b = False
                            Exit For
                        End If
                    Next
                    If b = True Then
                        index = j
                        Exit For
                    End If
                Else
                    Continue For
                End If
            Next
            If index <> -1 Then
                TextBox1.Text = numberToReallyNumber(index)
            Else
                TextBox1.Text = "非數字"
            End If
        Next

    End Sub
End Class
