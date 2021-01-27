Public Class Form1
    Dim g(0, 0)
    Dim min, max As Integer
    Dim log(255)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        'OpenFileDialog1.Filter = "*.bmp | *.gif"
        Dim filename = OpenFileDialog1.FileName

        Dim bmp As Bitmap = New Bitmap(filename)

        PictureBox1.Image = bmp


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim bmp As Bitmap = PictureBox1.Image
        min = 1000000000.0 : max = -1

        ReDim g(bmp.Width, bmp.Height)
        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim p = bmp.GetPixel(x, y)
                p = C2G(p, x, y)
                If p.R > max Then
                    max = p.R
                End If
                If p.R < min Then
                    min = p.R
                End If

                bmp.SetPixel(x, y, p)
            Next
        Next

        PictureBox1.Image = bmp
    End Sub
    Function C2G(ByVal c As Color, ByVal x As Integer, ByVal y As Integer)

        Dim t As Integer = 0.299 * c.R + 0.587 * c.G + 0.114 * c.B


        c = Color.FromArgb(t, t, t)


        Return c
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim bmp As Bitmap = PictureBox1.Image

        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim p = bmp.GetPixel(x, y)
                p = C2G(p, x, y)
                p = Color.FromArgb(255 - p.R, 255 - p.G, 255 - p.B)
                bmp.SetPixel(x, y, p)
            Next
        Next


        PictureBox1.Image = bmp
    End Sub
    Function resetlog()
        For i = 0 To 255
            log(i) = 0
        Next
    End Function
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim bmp As Bitmap = PictureBox1.Image
        resetlog()

        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim p = bmp.GetPixel(x, y)
                p = C2G(p, x, y)
                p = Color.FromArgb(255 - p.R, 255 - p.G, 255 - p.B)
                bmp.SetPixel(x, y, p)
                log(p.R) = 1
            Next
        Next

        For i = 255 To 0 Step -1
            If log(i) = 1 Then
                max = i
                Exit For
            End If
        Next
        For i = 0 To 255
            If log(i) = 1 Then
                min = i
                Exit For
            End If
        Next

        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim p = bmp.GetPixel(x, y)
                Dim ttt = (p.R - min) / (max - min) * 255
                p = Color.FromArgb(ttt, ttt, ttt)
                bmp.SetPixel(x, y, p)
            Next
        Next

        Label2.Text = "Max:" & max
        Label3.Text = "Min:" & min
        PictureBox1.Image = bmp
    End Sub
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
