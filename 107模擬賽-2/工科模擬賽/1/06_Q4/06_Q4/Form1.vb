Public Class Form1
    Dim gray As Long
    Dim bm As Bitmap
    Dim c As Color

    Private Sub 載入圖檔ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 載入圖檔ToolStripMenuItem.Click, Button1.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
        bm = PictureBox1.Image
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 灰階化ToolStripMenuItem.Click, Button2.Click
        For i = 0 To bm.Width - 1
            For j = 0 To bm.Height - 1
                c = bm.GetPixel(i, j)
                g()
                bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray))
            Next
        Next
        PictureBox1.Image = bm
    End Sub
    Private Sub 反白ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 反白ToolStripMenuItem.Click, Button3.Click
        For i = 0 To bm.Width - 1
            For j = 0 To bm.Height - 1
                c = bm.GetPixel(i, j)
                g()
                gray = 255 - gray
                bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray))
            Next
        Next
        PictureBox1.Image = bm
    End Sub
    Private Sub 對比拉伸ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 對比拉伸ToolStripMenuItem.Click, Button4.Click
        Dim max As Single = 0, min As Single = 1000
        For i = 0 To bm.Width - 1
            For j = 0 To bm.Height - 1
                c = bm.GetPixel(i, j)
                Dim a As Single = 0.299 * c.R + 0.587 * c.G + 0.114 * c.B
                If a > max Then max = a
                If a < min Then min = a
            Next
        Next

        For i = 0 To bm.Width - 1
            For j = 0 To bm.Height - 1
                c = bm.GetPixel(i, j)
                g()
                gray = (gray - min) / (max - min) * 255
                bm.SetPixel(i, j, Color.FromArgb(gray, gray, gray))
            Next
        Next

        PictureBox1.Image = bm
        Label3.Text = "Max     " & max
        Label4.Text = "Min     " & min
    End Sub


    Function g()
        gray = 0.299 * c.R + 0.587 * c.G + 0.114 * c.B
    End Function


End Class
