Public Class Form1
    Private Sub Button1_Click(sender As Object, ev As EventArgs) Handles Button1.Click
        'C = M^E mod N
        Dim E As Long = Val(TextBox1.Text)
        Dim N As Long = Val(TextBox2.Text)
        Dim M As Long
        Dim ans As String = ""
        For j = 1 To TextBox3.Text.Length
            Dim ch As Char = Mid(TextBox3.Text, j, 1)
            M = Asc(ch)
            If M < 0 Then
                M += 65536
            End If
            Dim C As Long = 1
            Dim binary As String = decimalToBinary(E)

            For i = 0 To binary.Length - 1
                C = C ^ 2 Mod N
                If binary(i) = "1" Then
                    C = (M * C) Mod N
                End If
            Next
            ans &= C
        Next

        'S = A^B mod C


        TextBox4.Text = ans

    End Sub


    Private Function decimalToBinary(ByVal b As Integer)

        '123456
        Dim ans As String = ""
        Do Until b \ 2 = 0
            Dim m = b Mod 2
            ans = m & ans
            b \= 2
        Loop

        Return b & ans
    End Function
    Private Sub Button2_Click(sender As Object, ev As EventArgs) Handles Button2.Click
        'C = M^E mod N
        'M = C^D mod N
        Dim D As Long = Val(TextBox5.Text)
        Dim N As Long = Val(TextBox6.Text)
        Dim C As String
        Dim ans As String = ""
        Dim count = 0
        Dim times = TextBox8.Text.Length \ 5



        For ti = 1 To times
            Dim str = ""
            For t = count * 5 + 1 To count * 5 + 5
                Str &= Mid(TextBox8.Text, t, 1)
            Next
            C = str

            Dim binary As String = decimalToBinary(D)
            Dim M As Long = 1
            For i = 0 To binary.Length - 1
                M = M ^ 2 Mod N
                If binary(i) = "1" Then
                    M = (C * M) Mod N
                End If
            Next
            If M > 122 Or M < 48 Then
                M -= 65536
            End If
            ans &= Chr(M)
            count += 1
        Next


        TextBox7.Text = ans
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If sender.checked Then
            Panel1.Visible = True
            Panel2.Visible = False
        Else
            Panel2.Visible = True
            Panel1.Visible = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Visible = True
    End Sub
End Class
