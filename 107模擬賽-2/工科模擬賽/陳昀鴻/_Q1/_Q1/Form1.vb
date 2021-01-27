Imports System.Text
Imports System.Numerics
Public Class Form1

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim input = TextBox1.Text
        Dim t As Integer = TextBox2.Text
        Dim s As String
        Dim ans As String
        Dim crc As Integer
        For i = 0 To input.Length - 1
            s &= Convert.ToString(AscW(input(i)), 16)
        Next
        s &= "0000"
        For i = 1 To t
            Dim x As Integer = i
            If x = 13020 Then
                Debug.Print("")
            End If
            Dim a = sixteen(s)
            If (a + x) Mod t = 0 Then
                crc = i
                Exit For
            End If
        Next
        '4150500000
        '8EFD

        ans = Convert.ToString(crc, 16)




        ans = ans.ToUpper

        TextBox3.Text = ans.Substring(0, 2) & " " & ans.Substring(2)


    End Sub
    '16-> 10
    Function sixteen(ByVal s As String)
        '4150501
        '1050514

        s = StrReverse(s)
        Dim sum As biginteger

        For i = 0 To Len(s) - 1
            sum += Convert.ToInt64(s(i), 16) * (16 ^ i)
        Next

        Return sum

    End Function

End Class

