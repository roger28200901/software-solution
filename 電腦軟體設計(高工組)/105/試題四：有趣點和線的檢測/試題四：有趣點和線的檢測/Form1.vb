Public Class Form1
    Dim bmp, gray, horizontal, vertical, horizontalPow, verticalPow, HV As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim op As New OpenFileDialog
        op.Filter = "Image Files|*.bmp;*.jpeg;*.png"
        Try
            op.ShowDialog()
            Dim fn = op.FileName
            bmp = New Bitmap(fn)
            PictureBox1.Image = bmp
        Catch ex As Exception
            MsgBox("讀檔錯誤")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            gray = bmp.Clone
        Catch ex As Exception
            MsgBox("尚未讀取檔案")
        End Try

        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim p As Color = bmp.GetPixel(x, y)
                Dim g = C2G(p)
                Dim c As Color = Color.FromArgb(g, g, g)
                gray.SetPixel(x, y, c)
            Next
        Next
        PictureBox2.Image = gray
    End Sub


    Function C2G(ByVal c As Color)
        Dim g As Integer
        g = Val(c.R) * 0.2125 + Val(c.G) * 0.7154 + Val(c.B) * 0.0721
        Return g
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            horizontal = gray.Clone
        Catch ex As Exception
            MsgBox("尚未讀取檔案")
        End Try
        For x = 1 To bmp.Width - 2
            For y = 1 To bmp.Height - 2
                Dim k As Double = 0
                k += gray.GetPixel(x - 1, y - 1).R
                k += gray.GetPixel(x, y - 1).R
                k += gray.GetPixel(x + 1, y - 1).R
                k -= gray.GetPixel(x - 1, y + 1).R
                k -= gray.GetPixel(x, y + 1).R
                k -= gray.GetPixel(x + 1, y + 1).R
                k /= 6 : k = Math.Abs(k)
                horizontal.SetPixel(x, y, Color.FromArgb(k, k, k))
            Next
        Next
        PictureBox2.Image = horizontal
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            vertical = gray.Clone
        Catch ex As Exception
            MsgBox("尚未讀取檔案")
        End Try
        For x = 1 To bmp.Width - 2
            For y = 1 To bmp.Height - 2
                Dim k As Double = 0
                k += gray.GetPixel(x - 1, y - 1).R
                k += gray.GetPixel(x - 1, y).R
                k += gray.GetPixel(x - 1, y + 1).R
                k -= gray.GetPixel(x + 1, y - 1).R
                k -= gray.GetPixel(x + 1, y).R
                k -= gray.GetPixel(x + 1, y + 1).R
                k /= 6 : k = Math.Abs(k)
                vertical.SetPixel(x, y, Color.FromArgb(k, k, k))
            Next
        Next
        PictureBox2.Image = vertical
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            horizontalPow = horizontal.Clone
        Catch ex As Exception
            MsgBox("尚未讀取檔案")
        End Try
        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim k As Double = 0
                k = Math.Pow(horizontal.GetPixel(x, y).R, 2)
                horizontalPow.SetPixel(x, y, Color.FromArgb(k Mod 255, k Mod 255, k Mod 255))
            Next
        Next
        PictureBox2.Image = horizontalPow

    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            verticalPow = vertical.Clone
        Catch ex As Exception
            MsgBox("尚未讀取檔案")
        End Try
        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim k As Double = 0
                k = Math.Pow(vertical.GetPixel(x, y).R, 2)
                verticalPow.SetPixel(x, y, Color.FromArgb(k Mod 255, k Mod 255, k Mod 255))
            Next
        Next
        PictureBox2.Image = verticalPow
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            HV = gray.Clone
        Catch ex As Exception
            MsgBox("尚未讀取檔案")
        End Try
        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim k1 As Double = vertical.GetPixel(x, y).R
                Dim k2 As Double = horizontal.GetPixel(x, y).R
                Dim sum As Double = k1 * k2
                HV.SetPixel(x, y, Color.FromArgb(sum Mod 255, sum Mod 255, sum Mod 255))
            Next
        Next
        PictureBox2.Image = HV
    End Sub
End Class
