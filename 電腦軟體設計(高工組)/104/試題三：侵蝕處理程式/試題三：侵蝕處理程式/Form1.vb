Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bmp As Bitmap = PictureBox1.Image
        Dim visit(bmp.Width - 1, bmp.Height - 1) As Boolean
        For i = 0 To bmp.Width - 1
            For j = 0 To bmp.Height - 1
                bmp = colorSub(bmp, i, j, visit)
            Next
        Next
        PictureBox1.Image = bmp
    End Sub
    Private Function colorSub(ByVal bmp As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal visit(,) As Boolean)
        Dim c As Color = bmp.GetPixel(x, y)

        Dim insert As Boolean = True
        Dim count = 0
        If (Val(c.R) + Val(c.G) + Val(c.B)) / 3 <> 0 And visit(x, y) = False And (Val(c.R) + Val(c.G) + Val(c.B)) / 3 <> 255 Then
            visit(x, y) = True
            Dim n As Color = Color.White
            If y <> 0 Then
                If visit(x, y - 1) = True Then
                    count += 1
                    insert = False
                End If
            End If
            If y <> bmp.Height - 1 Then
                If visit(x, y + 1) = True Then
                    count += 1
                    insert = False
                End If
            End If
            If x <> 0 And y <> 0 Then
                If visit(x - 1, y - 1) = True Then
                    count += 1
                    insert = False
                End If
            End If
            If x <> 0 And y <> bmp.Height - 1 Then
                If visit(x - 1, y + 1) = True Then
                    count += 1
                    insert = False
                End If
            End If
            If x <> bmp.Width - 1 And y <> 0 Then
                If visit(x + 1, y - 1) = True Then
                    count += 1
                    insert = False
                End If
            End If
            If x <> bmp.Width - 1 And y <> bmp.Height - 1 Then
                If visit(x + 1, y + 1) = True Then
                    count += 1
                    insert = False
                End If
            End If
            If x <> 0 Then
                If visit(x - 1, y) = True Then
                    count += 1
                    insert = False
                End If
            End If
            If x <> bmp.Width - 1 Then
                If visit(x + 1, y) = True Then
                    count += 1
                    insert = False
                End If
            End If
            If count > 1 Then
                insert = False
            Else
                insert = True
            End If
            If insert = True Then
                bmp.SetPixel(x, y, n)
            End If
        End If
        Return bmp
    End Function
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim fileName = OpenFileDialog1.FileName
        Dim bmp As New Bitmap(fileName)

        PictureBox1.Image = bmp
    End Sub
End Class
