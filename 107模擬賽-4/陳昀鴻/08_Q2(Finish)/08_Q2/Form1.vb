Public Class Form1
    Dim bmp As Bitmap
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim OFS As New OpenFileDialog
        'OFS.Filter = "Image Files|*.bmp;*.jpeg,*.png"
        Try
            OFS.ShowDialog()
            bmp = New Bitmap(OFS.FileName)
            PictureBox1.Image = bmp
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim encode = TextBox1.Text
        Dim count = 0
        Dim n As Integer = 0
        Dim save As Boolean = False
        Dim over As Boolean = False
        Dim b

        Dim nbmp As New Bitmap(bmp.Width, bmp.Height)
        For i = 0 To bmp.Height - 1
            For j = 0 To bmp.Width - 1
                Dim p = bmp.GetPixel(j, i)
                Dim c

                If n > Len(encode) - 1 Then
                    save = False
                Else
                    save = True
                    Dim ts = Asc(encode(n))
                    If ts < 0 Then
                        ts += 65536
                    End If
                    c = Convert.ToString(ts, 2).PadLeft(8, "0")
                    End If

                    If save = True Then
                        Dim nr As String = Convert.ToString(p.R, 2).PadLeft(8, "0").Substring(0, 7) & "1"
                        Dim ng As String = Convert.ToString(p.G, 2).PadLeft(8, "0").Substring(0, 7) & c(count)
                        '存有訊息的
                        nbmp.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(nr, 2), Convert.ToInt32(ng, 2), p.B))
                    Else
                        Dim r As String = Convert.ToString(p.R, 2).PadLeft(8, "0").Substring(0, 7) & "0"
                        nbmp.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(r, 2), p.G, p.B))
                    End If
                    count += 1
                If count >= c.length Then
                    count = 0
                    n += 1
                    Dim r As String = Convert.ToString(p.R, 2).PadLeft(8, "0").Substring(0, 7) & "0"
                    j += 1
                    If j >= bmp.Width - 1 Then
                        Continue For
                    End If
                    nbmp.SetPixel(j, i, Color.FromArgb(Convert.ToInt32(r, 2), p.G, p.B))

                    save = False
                End If

            Next
        Next
        Dim SFD As New SaveFileDialog

        Try
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
            saveFileDialog1.Title = "Save an Image File"
            saveFileDialog1.ShowDialog()

            Dim fileName = saveFileDialog1.FileName
            bmp = nbmp
            PictureBox1.Image = nbmp
            PictureBox2.Image = nbmp
            PictureBox2.Image.Save(fileName)

        Catch ex As Exception
            MsgBox("Error")
        End Try


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim getbmp = bmp
        Dim count = 0
        Dim l As New List(Of Integer)
        Dim decode As String = ""
        For i = 0 To getbmp.Height - 1
            For j = 0 To getbmp.Width - 1
                Dim p = getbmp.GetPixel(j, i)
                Dim r As String = Convert.ToString(p.R, 2).PadLeft(8, "0")
                Dim g As String = Convert.ToString(p.G, 2).PadLeft(8, "0")
                If Mid(r, 8, 1) = "1" Then
                    count += 1
                    l.Add(Mid(g, 8, 1))
                Else
                    If count <> 0 Then
                        count = 0
                        Dim s = String.Join("", l)
                        Dim a = Chr(Convert.ToInt32(s, 2))
                        decode &= a
                        count = 0
                        l.Clear()
                    End If
                End If
            Next
        Next
        TextBox2.Text = decode


    End Sub
End Class
