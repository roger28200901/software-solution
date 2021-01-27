Public Class Form1
    Dim bmp As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofs As New OpenFileDialog
        Try
            ofs.ShowDialog()
            Dim fn = ofs.FileName
            bmp = New Bitmap(fn)

            PictureBox1.Image = bmp
        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim txt = TextBox1.Text
        Dim nbmp As New Bitmap(bmp.Width, bmp.Height)
        For y = 0 To bmp.Height - 1
            For x = 0 To bmp.Width - 1
                Dim p As Color = bmp.GetPixel(x, y)
                Dim r As String = Convert.ToString(p.R, 2)
                r = r.PadLeft(8, "0").Substring(0, 7) & "0"
                nbmp.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(r, 2), p.G, p.B))
            Next
        Next

        Dim ny As Integer = 0
        Dim nx As Integer = 0
        For i = 0 To Len(txt) - 1
            Dim a = Asc(txt(i))
            If a < 0 Then
                a += 65536
            End If
            Dim b = Convert.ToString(a, 2)

            For j = 0 To Len(b) - 1
                Dim p As Color = nbmp.GetPixel(nx, ny)
                Dim r As String = Convert.ToString(p.R, 2).PadLeft(8, "0").Substring(0, 7) & "1"
                Dim g As String = Convert.ToString(p.G, 2).PadLeft(8, "0").Substring(0, 7) & b(j)
                nbmp.SetPixel(nx, ny, Color.FromArgb(Convert.ToInt32(r, 2), Convert.ToInt32(g, 2), p.B))
                nx += 1
            Next
            nx += 1
        Next

        Dim sfd As New SaveFileDialog
        Try
            sfd.ShowDialog()
            Dim fn = sfd.FileName
            nbmp.Save(fn)
            nbmp = New Bitmap(fn)
            PictureBox1.Image = nbmp
        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        bmp = PictureBox1.Image
        Dim l As New List(Of String)
        Dim ans As String = ""
        For y = 0 To bmp.Height - 1
            For x = 0 To bmp.Width - 1
                Dim p As Color = bmp.GetPixel(x, y)
                Dim r As String = Convert.ToString(p.R, 2)
                If r(r.Length - 1) = "1" Then
                    l.Add(Convert.ToString(p.G, 2))
                Else
                    Dim data = ""
                    For i = 0 To l.Count - 1
                        Dim lg = l(i)
                        data &= lg(lg.Length - 1)
                    Next
                    If data <> "" Then
                        ans &= Chr(Convert.ToInt64(data, 2))
                    End If
                    l.Clear()
                End If
            Next
        Next
        TextBox2.Text = ans
    End Sub
End Class
