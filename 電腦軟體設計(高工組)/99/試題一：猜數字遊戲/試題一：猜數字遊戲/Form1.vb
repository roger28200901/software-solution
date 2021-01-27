Imports Microsoft.VisualBasic.powerpacks
Imports System.ComponentModel
Public Class Form1
    Dim k(6)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bc = Val(bplusc.Text)
        Dim ab = Val(aplusb.Text)
        Dim cd = Val(cplusd.Text)
        Dim ad = Val(aplusd.Text)
        Dim bd = Val(bplusd.Text)
        Dim ac = Val(aplusc.Text)
        k(1) = bc : k(2) = ab : k(3) = cd : k(4) = ad : k(5) = bd : k(6) = ac
        For i = 1 To 6
            If k(i) > 20 Or k(i) < -20 Or k(i) <> Fix(k(i)) Then
                Label1.Text = "數字超過範圍"
                Exit Sub
            End If
        Next
        Try
            Dim aminusb = ac - bc
            Dim a = (ab + aminusb) / 2
            Dim b = ab - a
            Dim c = bc - b
            Dim d = cd - c
            If IsNumeric(a) = False Or IsNumeric(b) = False Or IsNumeric(c) = False Or IsNumeric(d) = False Or a <> Fix(a) Or b <> Fix(b) Or c <> Fix(c) Or d <> Fix(d) Then
                Label1.Text = "無解"
                TextBox1.Text = "a"
                TextBox2.Text = "b"
                TextBox3.Text = "c"
                TextBox4.Text = "d"
                Exit Sub
            End If
            TextBox1.Text = a
            TextBox2.Text = b
            TextBox3.Text = c
            TextBox4.Text = d
            Label1.Text = ""
        Catch ex As Exception
            Label1.Text = "無解"
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Dim g As Graphics = Me.CreateGraphics
        Dim pen As New Pen(Color.Black)
        g.DrawLine(pen, New Point(109 + 50, 96), New Point(190, 30 + 50))
        g.DrawLine(pen, New Point(109 + 50, 96 + 25), New Point(190, 96 + 25))
        g.DrawLine(pen, New Point(109, 152 + 25), New Point(190, 152 + 25))
        g.DrawLine(pen, New Point(109 + 50, 152 + 50), New Point(190, 235))
        g.DrawLine(pen, New Point(109 + 25, 152 + 50), New Point(109 + 25, 235))
        g.DrawLine(pen, New Point(53 + 25, 152 + 50), New Point(53 + 25, 235))
        g.Dispose()

    End Sub


End Class
