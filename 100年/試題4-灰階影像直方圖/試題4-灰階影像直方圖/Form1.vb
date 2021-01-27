Public Class Form1
    Dim log(255) As Long
    Private Sub 開啟彩色影像檔ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 開啟彩色影像檔ToolStripMenuItem.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        OpenFileDialog1.Filter = "Bitmap | *.bmp| JPG |*.jpg| GIF |*.gif| AllFiles |*.*"
        For i = 0 To 255
            log(i) = 0
        Next
        Dim image = OpenFileDialog1.FileName

        PictureBox1.ImageLocation = image
        PictureBox2.Image = Nothing



    End Sub
    Private Sub 結束離開ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 結束離開ExitToolStripMenuItem.Click
        End
    End Sub
    Private Sub 彩色影像轉灰階影像ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 彩色影像轉灰階影像ToolStripMenuItem.Click
        Dim bmp As Bitmap = PictureBox1.Image
        Dim n As New Bitmap(bmp.Width, bmp.Height)

        For x = 0 To bmp.Width - 1
            For y = 0 To bmp.Height - 1
                Dim c As Color = C2G(bmp.GetPixel(x, y))
                log(c.G) += 1
                n.SetPixel(x, y, c)
            Next
        Next

        PictureBox2.Image = n
    End Sub
    Private Function C2G(ByVal c As Color)
        Dim gray As Double = Fix(c.R * 0.3 + 0.59 * c.G + 0.11 * c.B)
        Dim color As Color = color.FromArgb(gray, gray, gray)
        Return color
    End Function

    Private Sub 求最小灰階和最大灰階ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 求最小灰階和最大灰階ToolStripMenuItem.Click
        Dim _Max, _Min As Long

        For i = 0 To 255
            If log(i) <> 0 Then
                _Min = i
                Exit For
            End If
        Next

        For j = 255 To 0 Step -1
            If log(j) <> 0 Then
                _Max = j
                Exit For
            End If
        Next

        TextBox1.Text = _Min
        TextBox2.Text = _Max

    End Sub

    Private Sub 劃出灰階影像直方圖ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 劃出灰階影像直方圖ToolStripMenuItem.Click

        Chart1.Series("機率").ChartType = DataVisualization.Charting.SeriesChartType.Line

        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False

        For i = 0 To 255
            Chart1.Series("機率").Points.Add(log(i))
        Next

    End Sub

    Private Sub 求出現最多之灰階和比機率ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 求出現最多之灰階和比機率ToolStripMenuItem.Click
        Dim sum As Long = 0
        Dim max As Long = -1

        For Each n As Long In log
            sum += n
            If n > max Then
                max = n
            End If
        Next
        Dim index = Array.IndexOf(log, max)
        TextBox3.Text = index
        TextBox4.Text = log(index) / sum
    End Sub
End Class
