Imports System.Text.RegularExpressions
Public Class Form1

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Randomize()

        Dim rand = Fix(Rnd() * Math.Pow(10, 10)) / Math.Pow(10, 6)

        TextBox1.Text = rand


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim d As Double = Val(TextBox1.Text)
        If d < 0 Or d > 9999.999999 Or d.ToString.Length > 11 Then
            MsgBox("實數值範圍於0.0~9999.999999之間")
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim d As Decimal = Val(TextBox1.Text)

        Dim b As String = decimalToBinary(d)
        TextBox2.Text = b

    End Sub
    Function decimalToBinary(ByVal d As Decimal)

        Dim l As Decimal
        Dim i = Split(d, ".")(0)
        If InStr(d, ".") <> 0 Then
            l = Split(d, ".")(1)
            l = l / Math.Pow(10,l.ToString.Length)
        End If


        Dim front, back As String
        front = ""
        back = ""
        Do Until i \ 2 = 0
            front = (i Mod 2) & front
            i \= 2
        Loop
        front = "1" & front

        Do Until l = 0 Or back.Length = 10
            Dim se As Decimal = Math.Floor(l * 2)
            back = back & se
            Debug.Print(1.122 - 1.0)
            l = (l * 2) - se
        Loop

        TextBox3.Text = front & "." & fixBinary(back)

        Return front & "." & back


    End Function
    Function fixBinary(ByVal binary As String)

        Dim back As String
        Dim find As Boolean = False
        For i = binary.Length To 1 Step -1
            If Mid(binary, i, 1) = 0 Then
                back = Mid(binary, 1, i - 1)
                find = True
                Continue For
            Else
                Exit For
            End If
        Next
        If find = False Then
            Return binary
        End If
        Return back
    End Function
End Class
