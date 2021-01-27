Public Class Form1
    Dim list1 As New List(Of String)
    Dim posfix
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim v = Val(TextBox1.Text)

        change(v, "")
        'check same answers
        Dim ans As String = ""
        For i = 0 To list1.Count - 1
            If i = 0 Then
                ans &= list1(i)
            ElseIf i = 1 Then
                ans &= "=" & list1(i) & vbNewLine
            Else
                ans &= "  =" & list1(i) & vbNewLine
            End If
        Next

        Label3.Text = ans

    End Sub
    Function change(ByVal a As Integer, ByVal b As String)
        posfix = CreateObject("ScriptControl")
        posfix.Language = "VBScript"
        Dim ans As String = ""
        If b <> "" Then
            If posfix.eval(b) > 1 Then
                If a > posfix.eval(b) Then list1.Add(a & "+" & posfix.eval(b))
            End If
            End If

        If a = 1 Then
            list1.Add(a & b)
        Else
            list1.Add(a & b)
            Call change(a - 1, b & "+" & 1)
        End If
    End Function
    Function change2(ByVal b As Integer, ByVal c As String)
        Dim str = ""
        If b = 1 Then
            str = b & c
            Return str
        Else
            str = change2(b - 1, c & "+" & 1)
        End If
    End Function
End Class
