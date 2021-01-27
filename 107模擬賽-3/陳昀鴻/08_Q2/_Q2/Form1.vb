Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim t1 = TextBox1.Text
        Dim obj = CreateObject("ScriptControl")
        obj.Language = "VBScript"
        TextBox2.Text = ""
        Dim ans = obj.eval(t1)
        TextBox2.Text = Math.Round(ans, 4)
    End Sub
End Class
