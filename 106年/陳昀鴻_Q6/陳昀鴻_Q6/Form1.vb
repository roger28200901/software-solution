Imports System.Numerics
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txt = TextBox1.Text
        txt = txt.Replace(vbCrLf, "/")
        Dim datas = txt.Split("/")
        TextBox2.Text = ""
        For i = 0 To UBound(datas)
            Dim v1 As BigInteger = sum(datas(i))
            Dim v2 = 0
            For j = 1 To v1.ToString.Length
                v2 += Mid(v1.ToString, j, 1)
            Next
            Dim v3 As New Stack
            Dim v3c As New ArrayList
            v3.Clear()
            v3c.Clear()

            Dim x As BigInteger = v1
            Dim m As BigInteger = 2
            Do Until m > x
                '如果整除
                If x Mod m = 0 Then
                    x = BigInteger.Divide(x, m)
                    If v3.Contains(m) = False Then
                        v3.Push(m)
                        v3c.Add(1)
                    Else
                        Dim index = v3.ToArray.ToList.IndexOf(m)
                        v3c(index) += 1
                    End If
                Else
                    m += 1
                End If
            Loop
            Dim vv3 As Integer = 0
            For q = 0 To v3c.Count - 1
                vv3 += v3c(q)
            Next
            TextBox2.Text &= v1.ToString & vbNewLine & v2 & vbNewLine & vv3 & vbNewLine & vbNewLine
        Next
    End Sub
    Function sum(ByVal a As Integer)
        Dim value As BigInteger = 1
        For i = 1 To a
            value *= i
        Next
        Return value
    End Function

End Class
