Public Class Form1
    Dim maps(,)
    Dim objectMap(,) As Integer
    Dim label As Integer = 1
    Dim number As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim op As New OpenFileDialog
        TextBox4.Text = ""
        TextBox5.Text = ""
        label = 1
        number = 0
        op.Filter = "Text Files|*.txt"
        op.ShowDialog()
        ReDim maps(TextBox1.Text - 1, TextBox2.Text - 1)
        ReDim objectMap(TextBox1.Text - 1, TextBox2.Text - 1)
        Try
            Dim fileName = op.FileName
            TextBox3.Text = fileName
            Dim txt = My.Computer.FileSystem.ReadAllText(fileName, System.Text.Encoding.Default)
            Dim lines = Split(Trim(txt), vbCrLf)
            For i = 0 To TextBox1.Text - 1
                Dim line = lines(i).Split(" ")
                For j = 0 To TextBox2.Text - 1
                    maps(i, j) = line(j)
                Next
            Next
        Catch ex As Exception
            MsgBox("讀檔有誤")
        End Try

        Dim x As Integer = TextBox1.Text - 1
        Dim y As Integer = TextBox2.Text - 1
        For i = 0 To x
            For j = 0 To y
                TextBox4.Text &= maps(i, j).ToString.PadRight(10 - maps(i, j).ToString.Length, " ")
            Next
            TextBox4.Text &= vbNewLine
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim x As Integer = TextBox1.Text - 1
        Dim y As Integer = TextBox2.Text - 1
        'i垂直 j水平
        For i = 0 To x
            For j = 0 To y
                If maps(i, j) = 0 Then Continue For
                Dim p, q, r, s As Integer : p = 0 : q = 0 : r = 0 : s = 0
                If i > 0 And j > 0 Then
                    p = maps(i - 1, j - 1)
                End If
                If i > 0 Then
                    q = maps(i - 1, j)
                End If
                If j < y And i > 0 Then
                    r = maps(i - 1, j + 1)
                End If
                If j > 0 Then
                    s = maps(i, j - 1)
                End If
                If p = 0 And q = 0 And r = 0 And s = 0 Then
                    objectMap(i, j) = label
                    label += 1
                End If
                Dim l As New List(Of Integer) : l.AddRange({p, q, r, s})
                Dim counter As Integer = 0
                For m = 0 To l.Count - 1
                    If l(m) = 255 Then
                        counter += 1
                    End If
                Next
                If counter = 1 Then
                    Dim index = l.IndexOf(255)
                    Select Case index
                        Case 0 ' p
                            objectMap(i, j) = objectMap(i - 1, j - 1)
                        Case 1 ' q
                            objectMap(i, j) = objectMap(i - 1, j)
                        Case 2 ' r
                            objectMap(i, j) = objectMap(i - 1, j + 1)
                        Case 3 ' s
                            objectMap(i, j) = objectMap(i, j - 1)
                    End Select
                ElseIf counter > 1 Then
                    Dim index = l.IndexOf(255)
                    Select Case index
                        Case 0 ' p
                            objectMap(i, j) = objectMap(i - 1, j - 1)
                        Case 1 ' q
                            objectMap(i, j) = objectMap(i - 1, j)
                        Case 2 ' r
                            objectMap(i, j) = objectMap(i - 1, j + 1)
                        Case 3 ' s
                            objectMap(i, j) = objectMap(i, j - 1)
                    End Select
                    l(index) = 0
                    index = l.IndexOf(255)
                    Do Until index = -1
                        Select Case index
                            Case 0 ' p
                                objectMap(i - 1, j - 1) = objectMap(i, j)
                            Case 1 ' q
                                objectMap(i - 1, j) = objectMap(i, j)
                            Case 2 ' r
                                objectMap(i - 1, j + 1) = objectMap(i, j)
                            Case 3 ' s
                                objectMap(i, j - 1) = objectMap(i, j)
                        End Select
                        l(index) = 0
                        index = l.IndexOf(255)
                    Loop
                End If
            Next
        Next

        Dim visit As New List(Of Integer)
        For i = 0 To x
            For j = 0 To y
                If visit.Contains(objectMap(i, j)) = False And objectMap(i, j) <> 0 Then
                    visit.Add(objectMap(i, j))
                    number += 1
                End If
                TextBox5.Text &= objectMap(i, j).ToString.PadRight(6 - objectMap(i, j).ToString.Length, " ")
            Next
            TextBox5.Text &= vbNewLine
        Next
        Label4.Text = "物件個數=" & number
    End Sub
End Class
