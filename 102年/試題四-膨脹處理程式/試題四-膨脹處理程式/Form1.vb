Public Class Form1
    Dim bmp As Bitmap
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Image Files|*.jpg,*.bmp,*.gif;*.png"
        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim filename = OpenFileDialog1.FileName
        bmp = New Bitmap(filename)
        PictureBox1.Image = bmp
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        bmp = PictureBox1.Image
        Dim newC(bmp.Width - 1, bmp.Height - 1) As Color
        Dim visit(bmp.Width - 1, bmp.Height - 1) As Boolean

        For i = 0 To bmp.Width - 1
            For j = 0 To bmp.Height - 1
                Dim r As Integer = bmp.GetPixel(i, j).R
                Dim g As Integer = bmp.GetPixel(i, j).G
                Dim b As Integer = bmp.GetPixel(i, j).B

                Dim c As Color = bmp.GetPixel(i, j)

                'If r = 255 And g = 255 And b = 255 Then
                '    newC(i, j) = bmp.GetPixel(i, j)
                'ElseIf r <> 255 Or g <> 255 Or b <> 255 And visit(i, j) <> True Then
                '    If i <> 0 And j <> 0 And i <> bmp.Width - 1 And j <> bmp.Height - 1 Then
                '        newC(i + 1, j + 1) = Color.Black
                '        newC(i + 1, j - 1) = Color.Black
                '        newC(i - 1, j + 1) = Color.Black
                '        newC(i - 1, j - 1) = Color.Black

                '        newC(i + 1, j) = Color.Black
                '        newC(i, j - 1) = Color.Black
                '        newC(i, j + 1) = Color.Black
                '        newC(i - 1, j) = Color.Black

                '        visit(i + 1, j + 1) = True
                '        visit(i + 1, j - 1) = True
                '        visit(i - 1, j + 1) = True
                '        visit(i - 1, j - 1) = True

                '        visit(i + 1, j) = True
                '        visit(i, j - 1) = True
                '        visit(i, j + 1) = True
                '        visit(i - 1, j) = True
                '    End If
                'End If
                If r = 0 And g = 0 And b = 0 Then
                    If i <> 0 And j <> 0 And i <> bmp.Width - 1 And j <> bmp.Height - 1 Then
                        newC(i + 1, j + 1) = Color.Black
                        newC(i + 1, j - 1) = Color.Black
                        newC(i - 1, j + 1) = Color.Black
                        newC(i - 1, j - 1) = Color.Black

                        newC(i + 1, j) = Color.Black
                        newC(i, j - 1) = Color.Black
                        newC(i, j + 1) = Color.Black
                        newC(i - 1, j) = Color.Black

                        visit(i + 1, j + 1) = True
                        visit(i + 1, j - 1) = True
                        visit(i - 1, j + 1) = True
                        visit(i - 1, j - 1) = True

                        visit(i + 1, j) = True
                        visit(i, j - 1) = True
                        visit(i, j + 1) = True
                        visit(i - 1, j) = True
                    End If
                ElseIf r <> 0 Or g <> 0 Or b <> 0 And visit(i, j) <> True Then
                    newC(i, j) = bmp.GetPixel(i, j)
                End If
            Next
        Next

        For i = 0 To bmp.Width - 1
            For j = 0 To bmp.Height - 1
                bmp.SetPixel(i, j, newC(i, j))
            Next
        Next

        PictureBox1.Image = bmp
    End Sub
End Class
