Public Class Form1
    Dim NowOp As String = Nothing
    Dim v1 As String = Nothing
    Dim v2 As String = Nothing
    Dim start As Boolean = True
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        For i = 1 To 16
            Controls("Button" & i).Enabled = True
        Next
        TextBox1.Text = ""
        v1 = Nothing
        v2 = Nothing
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If start = True Then
            Return
        End If
        For i = 1 To 10
            Controls("Button" & i).Enabled = True
        Next
        For j = 11 To 16
            Controls("Button" & j).Enabled = False
        Next
        TextBox1.Text = ""
        v1 = Nothing
        v2 = Nothing
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        For i = 1 To 8
            Controls("Button" & i).Enabled = True
        Next
        For j = 9 To 16
            Controls("Button" & j).Enabled = False
        Next
        TextBox1.Text = ""
        v1 = Nothing
        v2 = Nothing
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        For i = 1 To 2
            Controls("Button" & i).Enabled = True
        Next
        For j = 3 To 16
            Controls("Button" & j).Enabled = False
        Next
        TextBox1.Text = ""
        v1 = Nothing
        v2 = Nothing
    End Sub
    Private Sub B_0_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text &= "0"
    End Sub

    Private Sub B_2_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text &= "2"
    End Sub

    Private Sub B_3_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text &= "3"
    End Sub

    Private Sub B_1_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text &= "1"
    End Sub

    Private Sub B_7_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Text &= "7"
    End Sub

    Private Sub B_6_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text &= "6"
    End Sub

    Private Sub B_5_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text &= "5"
    End Sub

    Private Sub B_4_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text &= "4"
    End Sub

    Private Sub B_11_Click(sender As Object, e As EventArgs) Handles Button12.Click
        TextBox1.Text &= "B"
    End Sub

    Private Sub B_10_Click(sender As Object, e As EventArgs) Handles Button11.Click
        TextBox1.Text &= "A"
    End Sub

    Private Sub B_9_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox1.Text &= "9"
    End Sub

    Private Sub B_8_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox1.Text &= "8"
    End Sub

    Private Sub B_12_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextBox1.Text &= "C"
    End Sub

    Private Sub B_13_Click(sender As Object, e As EventArgs) Handles Button14.Click
        TextBox1.Text &= "D"
    End Sub

    Private Sub B_14_Click(sender As Object, e As EventArgs) Handles Button15.Click
        TextBox1.Text &= "E"
    End Sub

    Private Sub B_15_Click(sender As Object, e As EventArgs) Handles Button16.Click
        TextBox1.Text &= "F"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button_d.Click '/
        NowOp = "/"
        If v1 = Nothing Then
            v1 = TextBox1.Text
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button_m.Click '*
        NowOp = "*"
        If v1 = Nothing Then
            v1 = TextBox1.Text
            TextBox1.Text = ""
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button_l.Click '-
        NowOp = "-"
        If v1 = Nothing Then
            v1 = TextBox1.Text
            TextBox1.Text = ""
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button_p.Click '+
        NowOp = "+"
        If v1 = Nothing Then
            v1 = TextBox1.Text
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button_e.Click
        v2 = TextBox1.Text
        Dim v3 As String = ""
        If RadioButton1.Checked = True Then ' 16進制
            v1 = Convert.ToInt32(v1, 16)
            v2 = Convert.ToInt32(v2, 16)
            v3 = D2(cal(v1, v2, NowOp), 16)
        ElseIf RadioButton3.Checked = True Then '8
            v1 = Convert.ToInt32(v1, 8)
            v2 = Convert.ToInt32(v2, 8)
            v3 = D2(cal(v1, v2, NowOp), 8)
        ElseIf RadioButton4.Checked = True Then '2
            v1 = Convert.ToInt32(v1, 2)
            v2 = Convert.ToInt32(v2, 2)
            v3 = Convert.ToString(cal(v1, v2, NowOp), 2)
        End If
        If v3.Length > 16 Then
            TextBox1.Text = "溢位"
        Else
            TextBox1.Text = v3
        End If

        v1 = Nothing
        v2 = Nothing
        NowOp = Nothing
    End Sub
    Function D2(ByVal n As Integer, ByVal base As Integer)
        Dim c = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, "A", "B", "C", "D", "E", "F"}
        Dim ans As String = ""
        Do Until n \ base = 0
            Dim m = n Mod base
            ans = c(m) & ans
            n \= base
        Loop
        ans = c(n) & ans
        Return ans
    End Function
    Function cal(ByVal v1 As Integer, ByVal v2 As Integer, ByVal nowOp As String)
        Select Case nowOp
            Case "+"
                Return v1 + v2
            Case "-"
                Return v1 - v2
            Case "*"
                Return v1 * v2
            Case "/"
                Return v1 / v2
        End Select
    End Function

    Private Sub Button_AC_Click(sender As Object, e As EventArgs) Handles Button_AC.Click
        TextBox1.Text = ""
        v1 = Nothing
        v2 = Nothing
        NowOp = Nothing
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        start = False
    End Sub
End Class
