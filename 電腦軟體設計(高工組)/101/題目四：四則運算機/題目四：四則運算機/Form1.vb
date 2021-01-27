Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text &= 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text &= 2
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text &= 3
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text &= 4
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text &= 5
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text &= 6
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text &= 7
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Text &= 8
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox1.Text &= 9
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox1.Text &= 0
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        TextBox1.Text &= "."
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        TextBox1.Text &= "+"
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        TextBox1.Text &= "*"
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        TextBox1.Text &= "-"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        TextBox1.Text &= "/"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        TextBox1.Text &= "("
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        TextBox1.Text &= ")"
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click

        Dim txt = TextBox1.Text
        Dim checkChar = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ".", "+", "-", "*", "/", "(", ")", " "}
        For i = 0 To Len(txt) - 1
            If checkChar.Contains(txt(i)) = False Then
                TextBox1.Text = "運算式錯誤"
                Exit Sub
            End If
        Next

        Dim str As String = ""
        For i = 0 To Len(txt) - 1
            If IsNumeric(txt(i)) Or (txt(i)) = "." Then
                str &= txt(i)
            Else
                str &= " " & txt(i) & " "
            End If
        Next
        Dim datas = str.Split({" "}, StringSplitOptions.RemoveEmptyEntries)

        Dim s As New Stack
        Dim postfix As New Queue
        For j = 0 To UBound(datas)
            If IsNumeric(datas(j)) = True Then
                postfix.Enqueue(datas(j))
                Continue For
            End If
            If datas(j) = "(" OrElse s.Count = 0 OrElse weight(datas(j)) > weight(s.Peek) Then
                s.Push(datas(j))
                Continue For
            ElseIf datas(j) = ")" Then
                Do Until s.Peek = "("
                    postfix.Enqueue(s.Pop())
                Loop
                s.Pop()
                Continue For
            ElseIf weight(datas(j)) < weight(s.Peek) Then
                Do Until weight(s.Peek) < weight(datas(j))
                    postfix.Enqueue(s.Pop)
                Loop
                s.Push(datas(j))
                Continue For
            End If
        Next
        Do Until s.Count = 0
            postfix.Enqueue(s.Pop)
        Loop

        Dim s2 As New Stack
        Try
            For i = 0 To postfix.Count - 1
                If IsNumeric(postfix(i)) = True Then
                    s2.Push(postfix(i))
                Else
                    Dim v2 = s2.Pop
                    Dim v1 = s2.Pop
                    Dim op = postfix(i)
                    s2.Push(cal(v1, v2, op))
                End If
            Next
        Catch ex As Exception
            TextBox1.Text = "運算式錯誤"
        End Try

        Dim ans As String = IIf(s2.Peek = Fix(s2.Peek), Fix(s2.Peek), s2.Peek)
        Dim pr As String = TextBox1.Text & " = " & ans

        Dim file = My.Computer.FileSystem.OpenTextFileWriter("./b.txt", True)
        file.WriteLine(pr)
        file.Close()
        TextBox1.Text = ans

    End Sub
    Function cal(ByVal v1 As Decimal, ByVal v2 As Decimal, ByVal op As String)
        Select Case op
            Case "+"
                Return v1 + v2
            Case "-"
                Return v1 - v2
            Case "*"
                Return v1 * v2
            Case "/"
                Return v1 / v2
        End Select

    End Function
    Function weight(ByVal s As String)
        Select Case s
            Case "+", "-"
                Return 1
            Case "*", "/"
                Return 2
            Case "("
                Return 0
        End Select
    End Function
End Class
