Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txt As String = TextBox1.Text
        Dim bmp As New Bitmap(TextBox2.Text)
        Dim nbmp As New Bitmap(bmp)
        Dim count = 0
        Dim lengthByteString As String = Convert.ToString(txt.Length, 2)
        Dim c = 0
        Dim bs = 0
        Dim cs = 0
        For y = 0 To bmp.Height - 1
            For x = 0 To bmp.Width - 1
                Dim p As Color = bmp.GetPixel(x, y)
                If count >= 64 And count <= 95 Then
                    Dim r As String = Convert.ToString(CInt(p.R), 2).PadLeft(8, "0").Substring(0, 7) & IIf(c Mod 2 = 0, "0", "1")
                    Dim g As String = Convert.ToString(CInt(p.G), 2).PadLeft(8, "0").Substring(0, 7) & IIf(c Mod 2 = 0, "0", "1")
                    Dim b As String = Convert.ToString(CInt(p.B), 2).PadLeft(8, "0").Substring(0, 7) & IIf(c Mod 2 = 0, "0", "1")
                    nbmp.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(r, 2), Convert.ToInt32(g, 2), Convert.ToInt32(b, 2)))
                    c += 1
                ElseIf count >= 96 And count <= 111 Then
                    If bs <= lengthByteString.Length - 1 Then
                        For j = lengthByteString.Length To 1 Step -1
                            Dim r As String = Convert.ToString(CInt(p.R), 2).PadLeft(8, "0").Substring(0, 7) & Mid(lengthByteString, j, 1)
                            Dim g As String = Convert.ToString(CInt(p.G), 2).PadLeft(8, "0").Substring(0, 7) & Mid(lengthByteString, j, 1)
                            Dim b As String = Convert.ToString(CInt(p.B), 2).PadLeft(8, "0").Substring(0, 7) & Mid(lengthByteString, j, 1)
                            nbmp.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(r, 2), Convert.ToInt32(g, 2), Convert.ToInt32(b, 2)))
                            count += 1
                            bs += 1
                            x += 1
                        Next
                        x -= 1
                            Continue For
                    Else
                        Dim r As String = Convert.ToString(CInt(p.R), 2).PadLeft(8, "0").Substring(0, 7) & "0"
                        Dim g As String = Convert.ToString(CInt(p.G), 2).PadLeft(8, "0").Substring(0, 7) & "0"
                        Dim b As String = Convert.ToString(CInt(p.B), 2).PadLeft(8, "0").Substring(0, 7) & "0"
                        nbmp.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(r, 2), Convert.ToInt32(g, 2), Convert.ToInt32(b, 2)))
                    End If
                ElseIf count >= 112 And cs <= txt.Length - 1 Then
                    Dim characterASC = Asc(txt(cs))
                    If characterASC < 0 Then
                        characterASC += 65536
                    End If
                    Dim informationStr = Convert.ToString(characterASC, 2)
                    For j = informationStr.Length To 1 Step -1
                        Dim r As String = Convert.ToString(CInt(p.R), 2).PadLeft(8, "0").Substring(0, 7) & Mid(informationStr, j, 1)
                        Dim g As String = Convert.ToString(CInt(p.G), 2).PadLeft(8, "0").Substring(0, 7) & Mid(informationStr, j, 1)
                        Dim b As String = Convert.ToString(CInt(p.B), 2).PadLeft(8, "0").Substring(0, 7) & Mid(informationStr, j, 1)
                        nbmp.SetPixel(x, y, Color.FromArgb(Convert.ToInt32(r, 2), Convert.ToInt32(g, 2), Convert.ToInt32(b, 2)))
                        x += 1
                        count += 1
                    Next
                    x -= 1
                    cs += 1
                    Continue For
                Else
                    nbmp.SetPixel(x, y, Color.FromArgb(p.R, p.G, p.B))
                End If
                count += 1
            Next
        Next

        Dim filePath = TextBox3.Text
        nbmp.Save(filePath)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim bmp As New Bitmap(TextBox3.Text)
        Dim count = 0
        Dim c = 0
        Dim co = 1
        Dim checkHasInformation As Boolean = True
        Dim l As String = ""
        Dim length = 0
        Dim cl As String = ""
        Dim ans As String = ""
        For y = 0 To bmp.Height - 1
            For x = 0 To bmp.Width - 1
                Dim p As Color = bmp.GetPixel(x, y)
                If count >= 64 And count <= 95 Then
                    Dim r As String = Convert.ToString(CInt(p.R), 2).PadLeft(8, "0")
                    Dim g As String = Convert.ToString(CInt(p.G), 2).PadLeft(8, "0")
                    Dim b As String = Convert.ToString(CInt(p.B), 2).PadLeft(8, "0")
                    If c Mod 2 = 0 Then 'check 0
                        If Mid(r, 8, 1) <> 0 Or Mid(g, 8, 1) <> 0 Or Mid(b, 8, 1) <> 0 Then
                            checkHasInformation = False
                        End If
                    Else 'check 1
                        If Mid(r, 8, 1) <> 1 Or Mid(g, 8, 1) <> 1 Or Mid(b, 8, 1) <> 1 Then
                            checkHasInformation = False
                        End If
                    End If
                    c += 1
                ElseIf count >= 96 And count <= 111 And checkHasInformation = True Then
                    Dim r As String = Convert.ToString(CInt(p.R), 2).PadLeft(8, "0")
                    l = Mid(r, 8, 1) & l
                    If count = 111 Then
                        length = Convert.ToInt32(l, 2)
                    End If
                ElseIf count >= 112 And checkHasInformation = True Then

                    Dim r As String = Convert.ToString(CInt(p.R), 2).PadLeft(8, "0")
                    cl &= Mid(r, 8, 1)
                    If co Mod 8 = 0 And co <> 0 And length <> 0 Then
                        ans &= Chr(Convert.ToInt32(cl, 2))
                        cl = ""
                        length -= 1
                    End If
                    co += 1
                Else

                End If
                count += 1
            Next
        Next
    End Sub
End Class
