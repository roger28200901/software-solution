Public Class Form1

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        end
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim o As String = New String("0", 36)
        Randomize()

        For i = 1 To 4
            Dim index As Integer = Rnd() * o.Length
            o = o.Substring(0, index) & "1" & o.Substring(index)
        Next

        TextBox1.Text = o
    End Sub
    Function D2B(ByVal a As Integer) As String
        Return Convert.ToString(a, 2)
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a As String() = Split(TextBox1.Text, "1")
        Dim o As String = ""
        For i = 0 To UBound(a)
            o &= D2B(a(i).Length) & " "
        Next
        'o = Mid(o, 1, o.Length - 1)
        o = o.Substring(0, o.Length - 1)
        TextBox2.Text = o
        TextBox3.Text = Format(o.Length / TextBox1.Text.Length, "###.#%")
    End Sub
    Function D2C(ByVal a As Integer) As String
        Dim b = 65
        If a > 25 Then
            b += 6
        End If

        Return Chr(a + b)
    End Function
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim a As String() = Split(TextBox1.Text, "1")
        Dim o As String = ""
        For i = 0 To UBound(a)
            o &= D2C(a(i).Length)
        Next
        TextBox2.Text = o

    End Sub
End Class
