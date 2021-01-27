Public Class Form1
    Dim change As Boolean = False
    Private Sub RGB() 'RGB->HSL
        change = True
        Dim R, G, B
        Dim H, S, L
        R = Val(TextBox1.Text)
        G = Val(TextBox2.Text)
        B = Val(TextBox3.Text)

        Dim Rply = R / 255
        Dim Gply = G / 255
        Dim Bply = B / 255

        Dim C As New List(Of Double)
        C.Add(Rply) : C.Add(Gply) : C.Add(Bply)
        Dim Cmax = C.Max
        Dim Cmin = C.Min

        Dim delta = Cmax - Cmin

        If delta = 0 Then
            H = 0
        ElseIf Cmax = Rply Then
            H = 60 * (((Gply - Bply) / delta) Mod 6)
        ElseIf Cmax = Gply Then
            H = 60 * (((Bply - Rply) / delta) + 2)
        ElseIf Cmax = Bply Then
            H = 60 * (((Rply - Gply) / delta) + 4)
        End If
        If H < 0 Then
            H += 360
        End If
        L = (Cmax + Cmin) / 2
        If delta = 0 Then
            S = 0
        Else
            S = delta / (1 - Math.Abs(2 * L - 1))
        End If
        Dim g1 As Graphics = PictureBox2.CreateGraphics
        Dim g2 As Graphics = PictureBox3.CreateGraphics
        Dim g3 As Graphics = PictureBox4.CreateGraphics
        Dim g4 As Graphics = PictureBox1.CreateGraphics
        g4.Clear(Color.FromArgb(R, G, B))
        g1.Clear(Color.FromArgb(R, 0, 0))
        g2.Clear(Color.FromArgb(0, G, 0))
        g3.Clear(Color.FromArgb(0, 0, B))



        If R = G And G = B And R = B Then
            L = Math.Round(L * 100)
        Else
            L = Math.Round(L * 100, 1)
        End If

        TextBox4.Text = CInt(H)
        TextBox5.Text = Math.Round(S * 100)
        TextBox6.Text = L

    End Sub
    Private Sub HSL() 'HSL->RGB
        change = True
        Dim R, G, B
        Dim H, S, L
        Dim C As Decimal = 0
        Dim X As Decimal = 0
        Dim M As Decimal = 0
        H = Val(TextBox4.Text)
        S = Val(TextBox5.Text)
        L = Val(TextBox6.Text)
        If S = 0 Then

            R = L / 100 * 255
            G = L / 100 * 255
            B = L / 100 * 255
            TextBox1.Text = Math.Ceiling(R)
            TextBox2.Text = Math.Ceiling(G)
            TextBox3.Text = Math.Ceiling(B)
        Else
            H = Val(TextBox4.Text)
            S = Val(TextBox5.Text) / 100
            L = Val(TextBox6.Text) / 100
            C = (1 - Math.Abs(2 * L - 1)) * S
            X = C * (1 - Math.Abs((H / 60) Mod 2 - 1))
            M = L - C / 2
            Dim Rply, Gply, Bply
            If H >= 0 And H < 60 Then
                Rply = C
                Gply = X
                Bply = 0
            ElseIf H >= 60 And H < 120 Then
                Rply = X
                Gply = C
                Bply = 0
            ElseIf H >= 120 And H < 180 Then
                Rply = 0
                Gply = C
                Bply = X
            ElseIf H >= 180 And H < 240 Then
                Rply = 0
                Gply = X
                Bply = C
            ElseIf H >= 240 And H < 300 Then
                Rply = X
                Gply = 0
                Bply = C
            ElseIf H >= 300 And H < 360 Then
                Rply = C
                Gply = 0
                Bply = X
            End If
            R = (Rply + M) * 255
            G = (Gply + M) * 255
            B = (Bply + M) * 255
            TextBox1.Text = Math.Round(R)
            TextBox2.Text = Math.Round(G)
            TextBox3.Text = Math.Round(B)
        End If
        Dim g1 As Graphics = PictureBox2.CreateGraphics
        Dim g2 As Graphics = PictureBox3.CreateGraphics
        Dim g3 As Graphics = PictureBox4.CreateGraphics
        Dim g4 As Graphics = PictureBox1.CreateGraphics
        g4.Clear(Color.FromArgb(R, G, B))
        g1.Clear(Color.FromArgb(R, 0, 0))
        g2.Clear(Color.FromArgb(0, G, 0))
        g3.Clear(Color.FromArgb(0, 0, B))

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If change = True Then
            Return
        End If
        RGB()
        change = False
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If change = True Then
            Return
        End If
        RGB()
        change = False
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If change = True Then
            Return
        End If
        RGB()
        change = False
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If change = True Then
            Return
        End If
        HSL()
        change = False
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If change = True Then
            Return
        End If
        HSL()
        change = False
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If change = True Then
            Return
        End If
        HSL()
        change = False
    End Sub
End Class
