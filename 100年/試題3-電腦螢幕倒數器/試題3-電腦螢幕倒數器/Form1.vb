Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.TextAlign = HorizontalAlignment.Center

        TextBox1.Font = New Font("Arial", 55)
        TextBox2.Font = New Font("Arial", 55)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim m As Integer = Val(TextBox1.Text)
        Dim s As Integer = Val(TextBox2.Text)

        s -= 1
        If (s = -1) Then
            s = 59
            If m > 0 Then
                m = m - 1
            End If
        End If

        TextBox1.Text = m
        TextBox2.Text = s

        If m = 0 And s = 0 Then
            Timer1.Enabled = False
            MsgBox("時間終了")
        End If
    End Sub
End Class
