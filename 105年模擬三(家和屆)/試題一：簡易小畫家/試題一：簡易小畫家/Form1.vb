Public Class Form1
    Dim g As Graphics
    Dim bmp As Bitmap
    Dim p As Point
    Dim p2 As Point
    Dim pen As Pen = New Pen(Color.Black)
    Dim level = 1
    Private Sub 載入圖檔LToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 載入圖檔LToolStripMenuItem.Click
        Dim op As OpenFileDialog = New OpenFileDialog
        Try
            op.Filter = "Image Files|*.jpg;*.bmp"
            op.ShowDialog()
            bmp = New Bitmap(op.FileName)
            Dim fileName = op.FileName
            Dim gs As Graphics = PictureBox1.CreateGraphics
            gs.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height)
            PictureBox1.Image = bmp
            g = Graphics.FromImage(bmp)



        Catch ex As Exception
            MsgBox("讀取錯誤。")
        End Try

    End Sub

    Private Sub 建立新畫布NToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 建立新畫布NToolStripMenuItem.Click
        bmp = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmp
        g = Graphics.FromImage(bmp)

    End Sub

    Private Sub 儲存圖片SToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 儲存圖片SToolStripMenuItem.Click
        saveImage()
    End Sub
    Private Sub saveImage()
        Try
            Dim sa As SaveFileDialog = New SaveFileDialog
            sa.Filter = "Image Files|*.bmp;*.jpg"
            sa.ShowDialog()
            bmp.Save(sa.FileName)
        Catch ex As Exception
            MsgBox("儲存失敗。")
        End Try
    End Sub



    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        If IsNothing(bmp) = False Then
            p = New Point(e.X, e.Y)
        Else
            MsgBox("請先建立畫布。")
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        If IsNothing(bmp) = False Then
            p2 = New Point(e.X, e.Y)
            Select Case level
                Case 1
                    g.DrawLine(pen, p, p2)
                Case 2
                    g.DrawRectangle(pen, Math.Min(p.X, p2.X), Math.Min(p.Y, p2.Y), Math.Abs(p2.X - p.X), Math.Abs(p2.Y - p.Y))
                Case 3
                    g.DrawEllipse(pen, Math.Min(p.X, p2.X), Math.Min(p.Y, p2.Y), Math.Abs(p2.X - p.X), Math.Abs(p2.Y - p.Y))

            End Select
            PictureBox1.Refresh()
        Else
            MsgBox("請先建立畫布。")
        End If

    End Sub

    Private Sub 顏色ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 顏色ToolStripMenuItem.Click
        Dim cd As ColorDialog = New ColorDialog
        cd.ShowDialog()
        pen.Color = cd.Color
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        pen.Width = 2
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        pen.Width = 4
    End Sub

    Private Sub 直線ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 直線ToolStripMenuItem.Click
        level = 1
    End Sub

    Private Sub 矩形ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 矩形ToolStripMenuItem.Click
        level = 2
    End Sub

    Private Sub 橢圓ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 橢圓ToolStripMenuItem.Click
        level = 3
    End Sub
End Class
