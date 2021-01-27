Public Class Form1
    Dim datas As New List(Of String)
    Dim temps = {}
    Dim emaliEncode = {0, 7, 4, 1, 8, 5, 2, 9, 6, 3}
    Dim outputs As New List(Of String)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        datas.Clear()
        outputs.Clear()
        temps = {}
        Dim txt = TextBox3.Text
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then
            Dim v1 As Integer = Val(TextBox1.Text)
            Dim v2 As Integer = Val(TextBox2.Text)
            For i = v1 To v2
                Dim s = i.ToString
                Dim sum As Integer = 0
                For j = 0 To Len(s) - 1
                    sum += (j + 1) * Val(s(j))
                Next
                Dim m = sum Mod 10
                Dim outputString As String = s & emaliEncode(m) & "@antu.edu.tw"
                outputs.Add(outputString)
            Next
        End If
        temps = txt.Split({" ", ","}, StringSplitOptions.RemoveEmptyEntries)
        process()
        showDatas()
    End Sub
    Public Sub process()
        For i = 0 To UBound(temps)
            Dim s = temps(i)
            Dim sum As Integer = 0
            For j = 0 To Len(s) - 1
                sum += (j + 1) * Val(s(j))
            Next
            Dim m = sum Mod 10
            Dim outputString As String = s & emaliEncode(m) & "@antu.edu.tw"
            outputs.Add(outputString)
        Next
    End Sub
    Public Sub showDatas()
        TextBox4.Text = ""
        For i = 0 To outputs.Count - 1
            If i = outputs.Count - 1 Then
                TextBox4.Text &= outputs(i)
                Exit For
            End If

            If i Mod 3 = 2 Or i = 2 Then
                TextBox4.Text &= outputs(i) & ";" & vbNewLine
                Continue For
            Else
                TextBox4.Text &= outputs(i) & ";"
                Continue For
            End If

        Next

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox4.Multiline = True
        TextBox4.ScrollBars = ScrollBars.Vertical
    End Sub
End Class
