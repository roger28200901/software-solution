Public Class Form1
    Dim bmp1 As Bitmap
    Dim gray As Bitmap
    Dim rbmp As Bitmap
    Dim gbmp As Bitmap
    Dim bbmp As Bitmap
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim openfile = New OpenFileDialog
        Try
            openfile.Filter = "Image Files|*bmp;*.jpg;*.png"
            openfile.ShowDialog()
            Dim filename = openfile.FileName
            bmp1 = New Bitmap(filename)
            PictureBox1.Image = bmp1
        Catch ex As Exception
            MsgBox("讀取檔案錯誤")
            Exit Sub
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If IsNothing(bmp1) = True Then
            MsgBox("尚未讀取圖檔")
            Exit Sub
        End If
        gbmp = New Bitmap(bmp1.Width, bmp1.Height)
        For i = 0 To bmp1.Width - 1
            For j = 0 To bmp1.Height - 1
                Dim p As Color = bmp1.GetPixel(i, j)
                Dim gary = c2g(p)
                gbmp.SetPixel(i, j, Color.FromArgb(gary, gary, gary))
            Next
        Next
        PictureBox2.Image = gbmp
    End Sub
    Private Function c2g(ByVal c As Color)
        Dim gary As Integer
        gary = Val(c.R) * 0.3 + Val(c.G) * 0.59 + Val(c.B) * 0.11
        Return gary
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If IsNothing(bmp1) = True Then
            MsgBox("尚未讀取圖檔")
            Exit Sub
        End If
        '只保留紅色
        rbmp = New Bitmap(bmp1.Width, bmp1.Height)
        For i = 0 To bmp1.Width - 1
            For j = 0 To bmp1.Height - 1
                Dim p As Color = bmp1.GetPixel(i, j)
                rbmp.SetPixel(i, j, Color.FromArgb(p.R, 0, 0))
            Next
        Next
        '只保留綠色
        gbmp = New Bitmap(bmp1.Width, bmp1.Height)
        For i = 0 To bmp1.Width - 1
            For j = 0 To bmp1.Height - 1
                Dim p As Color = bmp1.GetPixel(i, j)
                gbmp.SetPixel(i, j, Color.FromArgb(0, p.G, 0))
            Next
        Next
        '只保留藍色
        bbmp = New Bitmap(bmp1.Width, bmp1.Height)
        For i = 0 To bmp1.Width - 1
            For j = 0 To bmp1.Height - 1
                Dim p As Color = bmp1.GetPixel(i, j)
                bbmp.SetPixel(i, j, Color.FromArgb(0, 0, p.B))
            Next
        Next

        PictureBox3.Image = rbmp
        PictureBox4.Image = gbmp
        PictureBox5.Image = bbmp
    End Sub
End Class
