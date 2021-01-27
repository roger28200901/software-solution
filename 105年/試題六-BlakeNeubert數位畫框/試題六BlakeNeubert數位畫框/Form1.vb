Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AllowDrop = True
        Button1.Enabled = False
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop

        Dim DragFilePath As String = CType(e.Data.GetData("FileNameW"), Array).GetValue(0)
        Dim bmp As Bitmap = New Bitmap(DragFilePath)
        Label1.Hide()

        Button1.Enabled = True
        PictureBox1.Image = bmp
        Button1.Text = "Reveal The Image Behind"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bmp As Bitmap = PictureBox1.Image
        Dim bbmp As Bitmap = bmp
        For x = 0 To bbmp.Width - 1
            For y = 0 To bbmp.Height - 1
                Dim p = bbmp.GetPixel(x, y)
                Dim c As Color = Color.FromArgb(p.A, IIf(p.R Mod 2 = 0, 235, 16), IIf(p.G Mod 2 = 0, 235, 16), IIf(p.B Mod 2 = 0, 235, 16))
                bbmp.SetPixel(x, y, c)
            Next
        Next
        PictureBox1.Image = bbmp

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        Label1.Hide()
        Button1.Enabled = True
        Button1.Text = "Reveal The Image Behind"
        Button1.Enabled = True
        
    End Sub
End Class
