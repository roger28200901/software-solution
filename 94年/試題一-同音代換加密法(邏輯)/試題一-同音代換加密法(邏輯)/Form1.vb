Public Class Form1
    Dim a() = {"09", 12, 33, 47, 53, 67, 78, 92}
    Dim b() = {48, 81}
    Dim c() = {13, 41, 62}
    Dim d() = {"01", "03", 45, 79}
    Dim ee() = {14, 16, 24, 44, 46, 55, 57, 64, 74, 82, 87, 98}
    Dim f() = {10, 31}
    Dim g() = {"06", 25}
    Dim h() = {23, 39, 50, 56, 65, 68}
    Dim i() = {32, 70, 73, 83, 88, 93}
    Dim j() = {15}
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t As String = TextBox1.Text.ToLower
        Dim noA, noB, noC, noD, noE, noF, noG, noH, noI, noJ As Integer
        Dim ans As New Queue
        For x = 0 To Len(t) - 1
            Dim ch As String = t(x)
            Select Case ch
                Case "a"
                    Dim n = noA Mod a.Count
                    noA += 1
                    ans.Enqueue(a(n))
                Case "b"
                    Dim n = noB Mod b.Count
                    noB += 1
                    ans.Enqueue(b(n))
                Case "c"
                    Dim n = noC Mod c.Count
                    noC += 1
                    ans.Enqueue(c(n))
                Case "d"
                    Dim n = noD Mod d.Count
                    noD += 1
                    ans.Enqueue(d(n))
                Case "e"
                    Dim n = noE Mod ee.Count
                    noE += 1
                    ans.Enqueue(a(n))
                Case "f"
                    Dim n = noF Mod f.Count
                    noF += 1
                    ans.Enqueue(f(n))
                Case "g"
                    Dim n = noG Mod g.Count
                    noG += 1
                    ans.Enqueue(g(n))
                Case "h"
                    Dim n = noH Mod h.Count
                    noH += 1
                    ans.Enqueue(h(n))
                Case "i"
                    Dim n = noI Mod i.Count
                    noI += 1
                    ans.Enqueue(i(n))
                Case "j"
                    Dim n = noJ Mod j.Count
                    noJ += 1
                    ans.Enqueue(j(n))
            End Select
        Next

        Dim ansStr As String = String.Join(" ", ans.ToArray)
        TextBox2.Text = ansStr
    End Sub
End Class
