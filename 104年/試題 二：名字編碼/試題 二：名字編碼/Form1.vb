Public Class Form1
    Dim Datas
    Dim soundex(6) As Array
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txt = TextBox1.Text
        txt = txt.Replace(vbCrLf, "/")
        Datas = txt.Split("/")

        process()

    End Sub
    Public Sub process()
        For i = 0 To UBound(Datas)
            Dim txt As String = Datas(i)
            Dim ans = ""
            Dim l = 4
            ans &= Mid(txt, 1, 1)
            txt = txt.Substring(1)

            For j = 1 To Len(txt)
                Dim c = Mid(txt, j, 1)
                Dim e = check(c)

                Dim r = ans.IndexOf(e)
                Dim rr = ans.IndexOf("/")
                '
                If r = -1 And rr = -1 Then
                    ans &= e
                    Continue For
                End If
                If r <> -1 And rr <> -1 Then
                    '2x2
                    If rr - r = 1 Then
                        ans = ans.Remove(rr)
                        ans &= e
                    Else
                        ans &= e
                    End If
                    Continue For
                End If
                ans &= e
            Next

            ans = fixAll(ans, l)


            TextBox2.Text &= ans & vbNewLine
        Next
    End Sub
    Function fixAll(ByVal ans As String, ByVal l As Integer)
        Dim index = ans.IndexOf("/")
        Do While index <> -1
            ans = ans.Remove(index, 1)
            index = ans.IndexOf("/")
        Loop

        Dim s As New ArrayList

        'S22
        If Len(ans) > 2 Then
            Dim x1 = Mid(ans, 1, 1)
            Dim x2 = Mid(ans, 2, 1)
            If x1 = x2 Then
                ans = x1 & ans.Substring(2)
            End If
        End If


        For i = 2 To Len(ans)
            Dim x = Mid(ans, i, 1)
            If s.IndexOf(x) = -1 Then
                s.Add(x)
            End If
        Next

        ans = Mid(ans, 1, 1) & String.Join("", s.ToArray)


        ans = ans.PadRight(4, "0")
        ans = ans.Substring(0, 4)
        Return ans
    End Function
    Private Function check(ByVal c As String)

        For i = 0 To UBound(soundex)
            Dim l = soundex(i).Length
            For j = 0 To l - 1
                If soundex(i)(j) = c Then
                    If i = 0 Then
                        Return "/"
                    Else
                        Return i
                    End If
                End If
            Next
        Next
        Return -1
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        soundex(0) = {"A", "E", "I", "O", "U", "Y", "W", "H"}
        soundex(1) = {"B", "P", "F", "V"}
        soundex(2) = {"C", "S", "K", "G", "J", "Q", "X", "Z"}
        soundex(3) = {"D", "T"}
        soundex(4) = {"L"}
        soundex(5) = {"M", "N"}
        soundex(6) = {"R"}
    End Sub
End Class
