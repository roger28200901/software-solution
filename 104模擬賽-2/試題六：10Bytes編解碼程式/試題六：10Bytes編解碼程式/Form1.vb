Imports System.Numerics
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim encode As String = ""
        Dim ID = TextBox1.Text
        encode = Convert.ToString(Convert.ToInt32(ID.Substring(2)), 2).PadLeft(27, "0")
        encode = Mid(ID, 2, 1) & encode
        encode = Convert.ToString(Asc(Mid(ID, 1, 1)) - 65, 2).PadLeft(5, "0") & encode
        Dim Dates = TextBox2.Text
        encode = Convert.ToString(Convert.ToInt32(Dates.Substring(6)), 2).PadLeft(5, "0") & encode
        encode = Convert.ToString(Convert.ToInt32(Dates.Substring(4, 2)), 2).PadLeft(4, "0") & encode
        encode = Convert.ToString((Convert.ToInt32(Dates.Substring(0, 4)) - 1900), 2).PadLeft(7, "0") & encode
        Dim Marry = ComboBox1.Text
        If Marry = "未婚" Then
            encode = "0" & encode
        Else
            encode = "1" & encode
        End If
        Dim school = ComboBox2.Text
        Select Case school
            Case "博士"
                encode = "000" & encode
            Case "碩士"
                encode = "001" & encode
            Case "大學"
                encode = "010" & encode
            Case "專科"
                encode = "011" & encode
            Case "高中"
                encode = "100" & encode
            Case "國中"
                encode = "101" & encode
            Case "小學"
                encode = "110" & encode
            Case Else
                encode = "111" & encode
        End Select
        encode = Convert.ToString(Convert.ToInt32(TextBox3.Text.Substring(2)), 2).PadLeft(27, "0") & encode
        Dim ans = B2H(encode)
        TextBox4.Text = ans

    End Sub
    Function D2H(ByVal n As Integer)
        Dim ans As String = ""
        Dim c = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, "A", "B", "C", "D", "E", "F"}
        Do Until n \ 16 = 0
            Dim m = n Mod 16
            ans = c(m) & ans
            n \= 16
        Loop
        ans &= c(n)
        Return ans
    End Function
    Function B2H(ByVal s As String)
        Dim ans As String = ""

        For i = 0 To 79 Step 4
            ans &= D2H(Convert.ToInt32(s.Substring(i, 4), 2))
        Next

        Return ans
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ans = TextBox4.Text
        Dim b80 As String = decode(ans)
        Dim phone = ""
        For i = 1 To 27
            phone &= Mid(b80, i, 1)
        Next
        Dim phoneStr As String = ""

        phoneStr = "09" & Convert.ToInt64(phone.Substring(0, 27), 2) '79-53 ok

        Dim school = b80.Substring(27, 3) '52-50
        Dim schoolStr As String = ""
        Select Case school
            Case "000"
                schoolStr = "博士"
            Case "001"
                schoolStr = "碩士"
            Case "010"
                schoolStr = "大學"
            Case "011"
                schoolStr = "專科"
            Case "100"
                schoolStr = "高中"
            Case "101"
                schoolStr = "國中"
            Case "110"
                schoolStr = "國小"
            Case Else
                schoolStr = "未知"
        End Select
        Dim Marry = b80.Substring(30, 1)
        Dim marryStr As String = ""
        If Marry = "0" Then
            marryStr = "未婚"
        Else
            marryStr = "已婚"
        End If
        Dim year = b80.Substring(31, 7)
        Dim yearStr = Convert.ToInt32(year, 2) + 1900
        Dim month = b80.Substring(38, 4)
        Dim monthStr = Convert.ToInt32(month, 2).ToString.PadLeft(2, "0")
        Dim dates = b80.Substring(42, 5)
        Dim datesStr = Convert.ToInt32(dates, 2).ToString.PadLeft(2, "0")
        Dim ID = b80.Substring(47)
        Dim FirstC = Chr(Convert.ToInt32(ID.Substring(0, 5), 2) + 65)
        Dim manOrWoman = ID.Substring(5, 1)
        Dim code = Convert.ToInt64(ID.Substring(6), 2)
        '''''
        TextBox1.Text = FirstC & manOrWoman & code
        TextBox2.Text = yearStr & monthStr & datesStr
        ComboBox1.Text = marryStr
        ComboBox2.Text = schoolStr
        TextBox3.Text = phoneStr
    End Sub

    Function decode(ByVal s As String)
        Dim c As New List(Of String)
        c.AddRange({"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"})
        Dim ans As String = ""
        For i = 0 To s.Length - 1
            Dim index = c.IndexOf(s(i))
            ans = ans & Convert.ToString(index, 2).PadLeft(4, "0")
        Next
        Return ans

    End Function
End Class
