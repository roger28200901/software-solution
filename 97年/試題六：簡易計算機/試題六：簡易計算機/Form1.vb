Public Class Form1
    Dim opration = Nothing
    Dim q As New Queue(Of String)
    Dim finish As Boolean = False
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        clear()
    End Sub
    Private Sub clear()
        q.Clear()
        opration = Nothing
        TextBox1.Text = 0
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        If finish = True Then
            clear()
            finish = False
        End If
        If opration <> Nothing And opration <> "log" Then
            q.Enqueue(TextBox1.Text)
            q.Enqueue(opration)
            TextBox1.Text = 0
            opration = Nothing

        End If
        If TextBox1.Text = 0 Then
            TextBox1.Text = sender.text
        Else
            TextBox1.Text &= sender.text
        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If TextBox1.Text.Contains(".") = False Then
            TextBox1.Text &= "."
        Else
            Return
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If TextBox1.Text = 0 Then Return
        Dim d As Decimal
        d = TextBox1.Text
        d = -d
        TextBox1.Text = d
    End Sub
    'log
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        q.Clear()
        TextBox1.Text = Math.Log10(TextBox1.Text)
        opration = Nothing
    End Sub
    '+
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If q.Count >= 2 Then
            equalsQ()
        End If
        opration = "+"
    End Sub
    '-
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If q.Count >= 2 Then
            equalsQ()
        End If
        opration = "-"
    End Sub
    '*
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If q.Count >= 2 Then
            equalsQ()
        End If
        opration = "*"
    End Sub
    '/
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If q.Count >= 2 Then
            equalsQ()
        End If
        opration = "/"
    End Sub
    '=
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        equalsQ()
        finish = True

    End Sub
    Private Sub equalsQ()
        '利用VBScript 做到中序運算式
        Dim str As String = ""
        q.Enqueue(TextBox1.Text)
        For Each item In q
            str &= item
        Next
        Dim obj = CreateObject("ScriptControl")
        obj.language = "VBScript"
        Dim ans As Decimal
        ans = obj.eval(str)
        TextBox1.Text = ans
        q.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 9
            AddHandler Controls("Button" & i).Click, AddressOf Button_Click
        Next
        '0
        AddHandler Controls("Button11").Click, AddressOf Button_Click
    End Sub
End Class
