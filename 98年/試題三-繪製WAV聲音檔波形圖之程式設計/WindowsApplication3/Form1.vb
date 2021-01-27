Public Class Form1
    Dim data As Byte()
    Dim AF, NoC, SR, BPS, Nos As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        loadWav(TextBox1.Text)
    End Sub

    Sub loadWav(ByVal a As String)
        If Not My.Computer.FileSystem.FileExists(a) Then
            MsgBox("檔案路徑錯誤")
        End If

        data = My.Computer.FileSystem.ReadAllBytes(a)

        Dim b0003, b080E, b2427 As String

        b0003 = loadByte(0, 3)
        b080E = loadByte(8, &HE)
        b2427 = loadByte(&H24, &H27)

        AF = loadByte(&H14, &H15, False)
        NoC = loadByte(&H16, &H17, False)
        SR = loadByte(&H18, &H1B, False)
        BPS = loadByte(&H22, &H23, False)
        Nos = loadByte(&H28, &H2B, False)

        If AF <> 1 OrElse NoC <> 1 OrElse BPS <> 8 OrElse b2427 <> "data" OrElse b0003 <> "RIFF" OrElse b080E <> "WAVEfmt" Then
            MsgBox("輸入的檔案不是RIFF WAVEfmt PCM格式 8位元及單聲道", MsgBoxStyle.Critical, "輸入的檔案名稱:" & a)
        End If
        '3 -1 =2
        Dim dat(data.Length - &H2C) As Byte
        For i As Integer = &H2C To data.Length - 1
            dat(i - &H2C) = Math.Abs(Convert.ToInt32(data(i) - &H80))
        Next
        'Nos 放的是Byte 
        '所以輸出圖示Byte 組成
        Dim bmp As New Bitmap(Nos, 256)
        PictureBox1.Size = New Point(Nos, 256)

        '建立graphipcs
        Dim G As Graphics = Graphics.FromImage(bmp)
        G.DrawLine(Pens.Green, 0, 128, Nos, 128)

        For x = 0 To UBound(dat)
            G.DrawLine(Pens.Green, x, 128 - dat(x), x, 128 + dat(x))
        Next
        PictureBox1.Image = bmp
        TextBox3.Text = Math.Floor((Nos / SR) * (10 ^ 5)) / (10 ^ 5)
        HScrollBar1.Maximum = Nos - Me.Size.Width
        HScrollBar1.Value = 0

    End Sub
    Function loadByte(ByVal _from As Integer, ByVal _to As Integer, Optional ByVal getword As Boolean = True) As Object
        Dim a As New ArrayList
        For i = _from To _to
            a.Add(data(i))
        Next

        Dim bit As Byte() = a.ToArray(GetType(Byte))

        If getword Then
            Return System.Text.Encoding.UTF8.GetString(bit)
        Else
            Dim s As String = ""
            For i = bit.Length - 1 To 0 Step -1
                s &= Convert.ToString(bit(i), 16)
            Next
            Return Convert.ToInt32(s, 16)
        End If

    End Function

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Dim copybmp As Bitmap = PictureBox1.Image
        Dim now = HScrollBar1.Value
        PictureBox1.Left = -(now)
        Dim voiceL = Val(TextBox3.Text)

        Dim sec = voiceL * (now / HScrollBar1.Maximum)
        sec = Math.Floor((sec) * (10 ^ 5)) / (10 ^ 5)
        TextBox2.Text = sec
    End Sub
End Class
