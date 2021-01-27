Public Class Form1
    Dim bmp1 As Bitmap
    Dim bmp2 As Bitmap
    Dim grayBmp1 As Bitmap
    Dim grayBmp2 As Bitmap
    Dim bmp1Minusbmp2 As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog2.Filter = "Image Files|*.bmp;*.jpg;*.png"
        OpenFileDialog2.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim fileName = OpenFileDialog1.FileName
        Dim bmp As New Bitmap(fileName)
        bmp1 = bmp
        PictureBox1.Image = bmp1
    End Sub

    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        Dim fileName = OpenFileDialog2.FileName
        Dim bmp As New Bitmap(fileName)
        bmp2 = bmp
        PictureBox3.Image = bmp2
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        grayBmp1 = bmp1

        For i = 0 To bmp1.Width - 1
            For j = 0 To bmp1.Height - 1
                Dim c As Color = bmp1.GetPixel(i, j)
                Dim gray As Double = (Val(c.R) + Val(c.G) + Val(c.B)) / 3
                c = Color.FromArgb(gray, gray, gray)
                grayBmp1.SetPixel(i, j, c)
            Next
        Next
        PictureBox2.Image = grayBmp1
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        grayBmp2 = bmp2

        For i = 0 To bmp2.Width - 1
            For j = 0 To bmp2.Height - 1
                Dim c As Color = bmp2.GetPixel(i, j)
                Dim gray As Double = (Val(c.R) + Val(c.G) + Val(c.B)) / 3
                c = Color.FromArgb(gray, gray, gray)
                grayBmp2.SetPixel(i, j, c)
            Next
        Next
        PictureBox4.Image = grayBmp2
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        bmp1Minusbmp2 = grayBmp2
        For i = 0 To grayBmp1.Width - 1
            For j = 0 To grayBmp1.Height - 1
                Dim c1 As Color = grayBmp1.GetPixel(i, j)
                Dim c2 As Color = grayBmp2.GetPixel(i, j)

                Dim p1 As Double = Val(c1.R) + Val(c1.G) + Val(c1.B)
                Dim p2 As Double = Val(c2.R) + Val(c2.G) + Val(c2.B)

                Dim nC As Color
                If Math.Abs(p1 - p2) = 0 Then
                    nC = Color.FromArgb(255, 255, 255)
                Else
                    nC = c2
                End If

                bmp1Minusbmp2.SetPixel(i, j, nC)
            Next
        Next
        PictureBox5.Image = bmp1Minusbmp2

    End Sub
End Class
