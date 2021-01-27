Public Class Form1
    Dim bmp1 As Bitmap
    Dim bmp2 As Bitmap
    Dim bmp3 As Bitmap
    Dim uR = 3.95 : Dim uG = 3.97 : Dim uB = 4
    Dim x0 As Decimal = Nothing
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofs As New OpenFileDialog
        ofs.Filter = "Image Files|*.bmp;*.jpeg;*.png;*.jpg"
        Try
            ofs.ShowDialog()
            bmp1 = New Bitmap(ofs.FileName)
            PictureBox1.Image = bmp1
            TextBox1.Text = ofs.FileName
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If IsNothing(bmp1) = True Then
            MsgBox("請讀取圖檔")
            Return
        End If
        x0 = Val(TextBox2.Text)
        bmp2 = New Bitmap(bmp1)
        For y = 0 To bmp2.Height - 1
            For x = 0 To bmp2.Width - 1
                Dim p As Color = bmp2.GetPixel(x, y)
                Dim v1 As Integer = 255 * (uR * x0 * (1 - x0))
                Dim v2 As Integer = 255 * (uG * x0 * (1 - x0))
                Dim v3 As Integer = 255 * (uB * x0 * (1 - x0))
                Dim r As Integer = Val(p.R) Xor v1
                Dim g As Integer = Val(p.G) Xor v2
                Dim b As Integer = Val(p.B) Xor v3
                bmp2.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next
        Next
        PictureBox2.Image = bmp2
        bmp2.Save("./bmp2.bmp")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ofs As New OpenFileDialog
        ofs.Filter = "Image Files|*.bmp;*.jpeg;*.png"
        Try
            ofs.ShowDialog()
            bmp1 = New Bitmap(ofs.FileName)
            PictureBox1.Image = bmp1
            TextBox3.Text = ofs.FileName
        Catch ex As Exception
            MsgBox("Error")
        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If IsNothing(bmp1) = True Then
            MsgBox("請讀取圖檔")
            Return
        End If
        x0 = Val(TextBox4.Text)
        bmp3 = New Bitmap(bmp1)
        For y = 0 To bmp3.Height - 1
            For x = 0 To bmp3.Width - 1
                Dim p As Color = bmp3.GetPixel(x, y)
                Dim v1 As Integer = 255 * (uR * x0 * (1 - x0))
                Dim v2 As Integer = 255 * (uG * x0 * (1 - x0))
                Dim v3 As Integer = 255 * (uB * x0 * (1 - x0))
                Dim r As Integer = Val(p.R) Xor v1
                Dim g As Integer = Val(p.G) Xor v2
                Dim b As Integer = Val(p.B) Xor v3
                bmp3.SetPixel(x, y, Color.FromArgb(r, g, b))
            Next
        Next
        PictureBox3.Image = bmp3
    End Sub
End Class
