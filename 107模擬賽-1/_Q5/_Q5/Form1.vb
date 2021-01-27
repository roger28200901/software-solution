Imports System.String
Public Class Form1
    Dim a(), b(), c()
    Dim q As New Queue
    Dim pera As  ArrayList

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim n = Val(TextBox1.Text)
        Dim temp = TextBox2.Text
        temp = temp.Replace(vbCrLf, "/")
        Dim datas = temp.Split("/")
        ReDim a(datas.Length), b(datas.Length), c(datas.Length)
        For i = 0 To UBound(datas)
            q.Clear()

            Dim t = datas(i).Split(",")
            a(i) = t(0).ToString
            b(i) = t(1).ToString
            c(i) = t(2).ToString

            sortR(a(i))
            arSort()
            Dim v1 = Val(q(b(i) - 1))
            Dim v2 = Val(q(c(i) - 1))
            Dim sum = v1 + v2
            TextBox3.Text &= sum & vbNewLine
        Next



    End Sub
    Function arSort()
        Dim x = q.ToArray()
        Dim min = 1000000000.0

        For i = 0 To UBound(x) - 1
            For j = 0 To UBound(x) - 1
                If x(j + 1) < x(j) Then
                    Dim temp = x(j)
                    x(j) = x(j + 1)
                    x(j + 1) = x(j)
                End If
            Next
        Next
    End Function
    Function sortR(ByVal a As String, Optional ByVal b As String = "")
        If Len(a) = Len(b) Then
            q.Enqueue(b)
        Else
            For i = 1 To Len(a)
                Dim word As Boolean = False
                For j = 1 To Len(b)
                    If Mid(b, j, 1) = Mid(a, i, 1) Then
                        word = True
                    End If
                Next
                If word = False Then
                    Call sortR(a, b & Mid(a, i, 1))
                End If
            Next
        End If
    End Function
    Function swap(ByVal original As String, Optional ByVal change As String = "")
        For i = 1 To Len(original)
            For j = 1 To Len(original)

            Next
        Next
    End Function

End Class
