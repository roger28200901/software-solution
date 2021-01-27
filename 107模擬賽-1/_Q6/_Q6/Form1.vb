Imports System.Text.RegularExpressions
Public Class Form1
    Dim a As New ArrayList
    Dim b As New ArrayList
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        a.Clear()
        b.Clear()
        RichTextBox1.SelectAll()

        RichTextBox1.SelectionColor = Color.Black
        TextBox3.Text = ""

        Dim t = RichTextBox1.Text

        Dim datas = t.Split({",", " ", "."}, StringSplitOptions.RemoveEmptyEntries)

        For i = 0 To UBound(datas)

            Dim index = a.IndexOf(datas(i).ToLower)
            If index = -1 Then
                a.Add(datas(i).ToLower)
                b.Add(1)
            Else
                b(index) += 1
            End If

        Next

        Dim n = Val(TextBox1.Text)

        Dim c As New Queue
        For x = 0 To b.Count - 1
            If b(x) = n Then
                c.Enqueue(a(x))
            End If
        Next

        For i = 0 To c.Count - 1
            TextBox3.Text &= c(i) & vbCrLf
        Next

        Dim k As Integer = 1

        RichTextBox1.Text = t
        'Dim startindex = 0
        For Each word In c
            Dim startindex = 0
            'startindex = RichTextBox1.Text.ToUpper.IndexOf(word.ToString.ToUpper, startindex)

            'Do Until startindex = -1
            '    Dim LeftIndex As String
            '    If startindex = 0 Then
            '        LeftIndex = -1
            '    Else
            '        LeftIndex = Mid(RichTextBox1.Text, startindex, 1)
            '    End If
            '    Dim RightIndex As String = Mid(RichTextBox1.Text, startindex + word.length + 1, 1)
            '    If Not Char.IsLetter(LeftIndex) And Not Char.IsLetter(RightIndex) Then
            '        RichTextBox1.SelectionStart = startindex
            '        RichTextBox1.SelectionLength = word.length
            '        RichTextBox1.SelectionColor = Color.Red
            '    End If

            '    startindex += word.length
            '    startindex = RichTextBox1.Text.ToUpper.IndexOf(word.ToString.ToUpper, startindex)
            'Loop
            'startindex = 0

            Do Until startindex >= RichTextBox1.Text.Length
                Dim index = RichTextBox1.Find(word, startindex, RichTextBox1.Text.Length, RichTextBoxFinds.WholeWord)
                If index <> -1 Then
                    RichTextBox1.Select(index, word.length)
                    RichTextBox1.SelectionColor = Color.Red
                End If
                startindex += word.length

            Loop
        Next





    End Sub
End Class
