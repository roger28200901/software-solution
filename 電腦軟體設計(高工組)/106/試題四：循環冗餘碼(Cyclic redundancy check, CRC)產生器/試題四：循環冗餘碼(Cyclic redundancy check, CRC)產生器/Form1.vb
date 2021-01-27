Imports System.Numerics
Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txt = TextBox1.Text
        Dim lines = Split(Trim(txt), vbCrLf)
        TextBox2.Text = ""
        Dim G = 34943
        For i = 0 To UBound(lines)
            If lines(i) = "" Then
                TextBox2.Text &= "00 00" & vbNewLine
            Else
                Dim str = lines(i)
                Dim m = ""
                For j = 0 To str.Length - 1
                    Dim buffer = AscW(str(j))

                    Dim c = Hex(buffer)
                    m &= c
                Next

                Dim m2 = ""
                For j = 0 To G
                    m2 = m & Hex(j)
                    'Globaliztion 轉16進 太大十進位會變成負數
                    Dim m2D As BigInteger = H2B(m2)

                    If m2D Mod G = 0 Then
                        Exit For
                    End If
                Next

                Dim CRC As String = Mid(m2, m2.Length - 3, 2) & " " & Mid(m2, m2.Length - 1, 2)
        TextBox2.Text &= CRC & vbNewLine
        End If
        Next
    End Sub
    Function H2B(ByVal m2 As String)

        Dim sum As BigInteger
        m2 = StrReverse(m2)
        For i = 0 To m2.Length - 1
            sum += Convert.ToInt16(m2(i), 16) * (16 ^ i)
        Next
        Return sum
    End Function
End Class
