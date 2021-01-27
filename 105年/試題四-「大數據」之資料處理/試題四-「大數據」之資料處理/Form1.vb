Imports System.IO
Public Class Form1
    Dim datas As List(Of String) = New List(Of String)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Text Files|*.txt"
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim filename = OpenFileDialog1.FileName
        Dim text = My.Computer.FileSystem.ReadAllText(filename, System.Text.Encoding.Default)

        'Dim stringReader = New StreamReader(filename)
        TextBox1.Text = ""
        TextBox2.Text = ""
        datas.Clear()

        TextBox1.Text = text
        Dim r = Process(text)
        TextBox2.Text = r
    End Sub

    Private Function Process(ByVal text As String)


        Dim c As Char() = {" "}
        Dim temp = text.Split(c, StringSplitOptions.RemoveEmptyEntries)
        Dim result As String = ""

        For i = 0 To UBound(temp)
            If temp(i).Contains("??") Then
                temp(i) = temp(i).Replace("?", "")
            End If
            If temp(i).Contains("：：") Then '87美國
                temp(i) = temp(i).Remove(temp(i).IndexOf("："))
            End If

            '87課程
            If strCount(temp(i), "/") = 4 Then
                '移除)
                temp(i) = temp(i).Remove(temp(i).Length - 1, 1)
                '移除(
                Dim index = temp(i).LastIndexOf("(")
                temp(i) = temp(i).Remove(index, 1)
                temp(i) = temp(i).Insert(index, vbNewLine)
                temp(i) = temp(i).Replace("/", vbNewLine)
                result &= temp(i)
            End If
            If i + 1 < temp.Length Then
                '1-40
                If i + 1 < temp.Length And temp(i + 1).Contains("：") Then
                    result &= temp(i) & vbNewLine
                    Continue For
                End If
            End If



            result &= temp(i) & " "
        Next

        Return result
    End Function
    Function strCount(ByVal str As String, ByVal i As String)
        Dim count = 0
        Dim startIndex = 0
        Dim index = str.IndexOf(i, startIndex)
        While index <> -1 '當有找到的時候
            count += 1
            startIndex = index + i.Length
            index = str.IndexOf(i, startIndex)
        End While
        Return count
    End Function
End Class
