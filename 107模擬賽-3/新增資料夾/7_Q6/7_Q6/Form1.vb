Public Class Form1
    Dim str As Integer = 1

    Sub rgb(ByVal rr As Double, ByVal gg As Double, ByVal bb As Double)
        Dim r, g, b, min, max, tt, h, s, l As Double
        r = rr / 255
        g = gg / 255
        b = bb / 255
        PictureBox1.BackColor = Color.FromArgb(rr, gg, bb)
        PictureBox2.BackColor = Color.FromArgb(rr, 0, 0)
        PictureBox3.BackColor = Color.FromArgb(0, gg, 0)
        PictureBox4.BackColor = Color.FromArgb(0, 0, bb)
        max = Math.Max(r, g)
        max = Math.Max(b, max)
        min = Math.Min(r, g)
        min = Math.Min(b, min)
        tt = max - min
        h = 0
        s = 0
        l = (max + min) / 2
        If tt <> 0 Then
            Select Case max

                Case r
                    h = 60 * (((g - b) / tt) Mod 6)
                Case g
                    h = 60 * (((b - r) / tt) + 2)
                Case b
                    h = 60 * (((r - g) / tt) + 4)
            End Select
            s = tt / (1 - Math.Abs(2 * l - 1))
        End If
        TextBox4.Text = Fix(h)
        TextBox5.Text = Math.Round(s * 1000) / 10
        TextBox6.Text = Math.Round(l * 1000) / 10
        str = 1

    End Sub

    Sub shl(ByVal hh As Double, ByVal ss As Double, ByVal ll As Double)

        Dim r, g, b, m, x, c, h, s, l As Double
        h = hh
        s = ss / 100
        l = ll / 100
        If s = 0 Then
            r = l / 100 * 255
            g = r
            b = r
        Else
            c = (1 - Math.Abs(2 * l - 1)) * s
            x = c * (1 - Math.Abs((h / 60) Mod 2 - 1))
            m = l - (c / 2)
            If h >= 0 And h < 60 Then
                r = c
                g = x
                b = 0

            End If
            If h >= 60 And h < 120 Then
                r = x
                g = c
                b = 0

            End If
            If h >= 120 And h < 180 Then
                r = 0
                g = c
                b = x

            End If
            If h >= 180 And h < 240 Then
                r = 0
                g = x
                b = c

            End If
            If h >= 240 And h < 300 Then
                r = x
                g = 0
                b = c

            End If
            If h >= 300 And h < 360 Then
                r = c
                g = 0
                b = x
            End If
            r = (r + m) * 255
            g = (g + m) * 255
            b = (b + m) * 255
        End If
        TextBox1.Text = Math.Round(r)
        TextBox2.Text = Math.Round(g)
        TextBox3.Text = Math.Round(b)
        PictureBox1.BackColor = Color.FromArgb(Val(TextBox1.Text), Val(TextBox2.Text), Val(TextBox3.Text))
        PictureBox2.BackColor = Color.FromArgb(Val(TextBox1.Text), 0, 0)
        PictureBox3.BackColor = Color.FromArgb(0, Val(TextBox2.Text), 0)
        PictureBox4.BackColor = Color.FromArgb(0, 0, Val(TextBox3.Text))
        str = -1

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged, TextBox3.TextChanged, TextBox2.TextChanged ', TextBox4.TextChanged, TextBox6.TextChanged, TextBox5.TextChanged
        If str = -1 Then
            Exit Sub
        End If
        Dim r, g, b As Double
        r = 0
        g = 0
        b = 0
        If TextBox1.Text <> "" Then
            r = TextBox1.Text

        End If
        If TextBox2.Text <> "" Then
            g = TextBox2.Text
        End If
        If TextBox3.Text <> "" Then
            b = TextBox3.Text
        End If

        rgb(r, g, b)
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged, TextBox6.TextChanged, TextBox5.TextChanged
        If str = 1 Then
            Exit Sub
        End If
        Dim h, s, l As Double
        h = 0
        s = 0
        l = 0
        If TextBox4.Text <> "" Then
            h = TextBox4.Text
        End If
        If TextBox5.Text <> "" Then
            s = TextBox5.Text
        End If
        If TextBox6.Text <> "" Then
            l = TextBox6.Text
        End If
        shl(h, s, l)
    End Sub

    Private Sub TextBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.Click, TextBox5.Click, TextBox6.Click
        str = -1
    End Sub

    Private Sub TextBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.Click, TextBox3.Click, TextBox1.Click
        str = 1
    End Sub
End Class
