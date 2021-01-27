Public Class Form1
    Dim datas(,) As Boolean
    Dim bmp As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Image Files|*.jpg;*.gif;*.png;*.bmp"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

        Dim filename = OpenFileDialog1.FileName
        bmp = New Bitmap(filename)
        PictureBox1.Image = bmp
        Button2.Enabled = True
        Button3.Enabled = True
        readImage()
    End Sub
    Private Sub readImage()
        bmp = PictureBox1.Image
        ReDim datas(bmp.Width, bmp.Height)
        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim p = bmp.GetPixel(x, y)
                datas(x, y) = checkWhiteDot(p)
            Next
        Next
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim max = -1 : Dim min = 1000000000.0
        For x = 0 To (bmp.Width - 1) / 2
            Dim count = 0
            For y = 0 To bmp.Height - 1
                If datas(x, y) = False Then
                    If y < min Then
                        min = y
                    End If
                    If y > max Then
                        max = y
                    End If
                Else
                    count += 1
                    Continue For
                End If
            Next
            If count = bmp.Height And max <> -1 And min <> 1000000000.0 Then
                Exit For
            End If
        Next
        Dim delta1 As Double = Math.Abs(max - min)


        max = -1 : min = 1000000000.0
        For x = (bmp.Width - 1) / 2 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                If datas(x, y) = False Then
                    If y > max Then
                        max = y
                    End If
                    If y < min Then
                        min = y
                    End If
                Else
                    Continue For
                End If
            Next
        Next
        Dim delta2 As Double = max - min
        Dim value2 = (delta2 * 830) / delta1

        TextBox1.Text = value2

    End Sub
    Function checkWhiteDot(ByVal c As Color)
        Dim colorValue
        colorValue = c.R * 0.3 + c.G * 0.59 + c.B * 0.11
        If colorValue > 200 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim max = -1 : Dim min = 1000000000.0
        For x = 0 To (bmp.Width - 1) / 2
            Dim count = 0
            For y = 0 To bmp.Height - 1
                If datas(x, y) = False Then
                    If y > max Then
                        max = y
                    End If
                    If y < min Then
                        min = y
                    End If
                Else
                    count += 1
                    Continue For
                End If
            Next
            If count = bmp.Height And max <> -1 And min <> 1000000000.0 Then
                Exit For
            End If
        Next
        Dim delta1 As Double = Math.Abs(max - min)


        max = -1 : min = 1000000000.0
        For x = (bmp.Width - 1) / 2 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                If datas(x, y) = False Then
                    If x > max Then
                        max = x
                    End If
                    If x < min Then
                        min = x
                    End If
                Else
                    Continue For
                End If
            Next
        Next

        Dim delta2 As Double = Math.Abs(max - min)

        Dim value2 = (delta2 * 830) / delta1


        TextBox2.Text = format(value2,"00.00")

    End Sub
End Class
