Public Class Form1
    Dim bmp1 As Bitmap
    Dim bmp2 As Bitmap
    Dim gray1 As Bitmap
    Dim gray2 As Bitmap
    Dim minusbmp As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim openfile1 As OpenFileDialog = New OpenFileDialog
        openfile1.Filter = "Image Files|*.bmp;*.jpg;*.png"
        Try
            openfile1.ShowDialog()
            Dim fileName = openfile1.FileName
            bmp1 = New Bitmap(fileName)
            PictureBox1.Image = bmp1
        Catch ex As Exception
            MsgBox("讀取錯誤，請重新再試。")
        End Try


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            gray1 = New Bitmap(bmp1.Width, bmp1.Height)
            For x = 0 To bmp1.Width - 1
                For y = 0 To bmp1.Height - 1
                    Dim p As Color = bmp1.GetPixel(x, y)
                    Dim c As Integer = (Val(p.R) + Val(p.G) + Val(p.B)) / 3
                    Dim gray As Color = Color.FromArgb(c, c, c)
                    gray1.SetPixel(x, y, gray)
                Next
            Next
            PictureBox2.Image = gray1
        Catch ex As Exception
            MsgBox("尚未讀取影像1")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openfile2 As OpenFileDialog = New OpenFileDialog
        openfile2.Filter = "Image Files|*.bmp;*.jpg;*.png"
        Try
            openfile2.ShowDialog()
            Dim fileName = openfile2.FileName
            bmp2 = New Bitmap(fileName)
            PictureBox3.Image = bmp2
        Catch ex As Exception
            MsgBox("讀取錯誤，請重新再試。")
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            gray2 = New Bitmap(bmp2.Width, bmp2.Height)
            For x = 0 To bmp2.Width - 1
                For y = 0 To bmp2.Height - 1
                    Dim p As Color = bmp2.GetPixel(x, y)
                    Dim c As Integer = (Val(p.R) + Val(p.G) + Val(p.B)) / 3
                    Dim gray As Color = Color.FromArgb(c, c, c)
                    gray2.SetPixel(x, y, gray)
                Next
            Next
            PictureBox4.Image = gray2
        Catch ex As Exception
            MsgBox("尚未讀取影像2")
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        minusbmp = New Bitmap(bmp1.Width, bmp1.Height)
        For x = 0 To minusbmp.Width - 1
            For y = 0 To minusbmp.Height - 1
                Dim p1 As Color = gray1.GetPixel(x, y)
                Dim p2 As Color = gray2.GetPixel(x, y)

                Dim r As Integer = Math.Abs(Val(p1.R) - Val(p2.R))
                Dim g As Integer = Math.Abs(Val(p1.G) - Val(p2.G))
                Dim b As Integer = Math.Abs(Val(p1.B) - Val(p2.B))
                If r = 0 And g = 0 And b = 0 Then
                    r = 255
                    g = 255
                    b = 255
                End If
                Dim nc As Color = Color.FromArgb(r, g, b)

                minusbmp.SetPixel(x, y, nc)
            Next
        Next
        PictureBox5.Image = minusbmp
    End Sub
End Class
