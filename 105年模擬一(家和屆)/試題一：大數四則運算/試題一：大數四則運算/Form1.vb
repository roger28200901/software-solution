Imports System.Numerics
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim input = TextBox1.Text
        input = input.Replace(",", "")
        Dim vb = CreateObject("ScriptControl")
        vb.language = "VBScript"
        Dim sum = vb.eval(input)
        TextBox2.Text = Format(sum, "#,#")
    End Sub
End Class
