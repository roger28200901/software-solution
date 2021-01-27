Public Class Form1
    Dim selectText

    Dim map(5, 5)
    Dim colorMap(5, 5)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '1白色
        selectText.backColor = Color.White

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '2黑色
        selectText.BackColor = Color.Black

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        selectText = TextBox1
        For y = 1 To 5
            For x = 1 To 5
                Dim k As Integer = (y - 1) * 5 + x
                map(x, y) = Controls("TextBox" & k)
                colorMap(x - 1, y - 1) = IIf(map(x, y).backColor = Color.White, 1, 2)
            Next
        Next

    End Sub


    Private Sub TextBox_Click(sender As Object, e As EventArgs) Handles TextBox1.Click, TextBox2.Click, TextBox3.Click,
            TextBox4.Click, TextBox5.Click, TextBox6.Click, TextBox7.Click, TextBox8.Click, TextBox9.Click, TextBox10.Click, TextBox11.Click,
            TextBox12.Click, TextBox13.Click, TextBox14.Click, TextBox15.Click, TextBox16.Click, TextBox17.Click, TextBox18.Click, TextBox19.Click,
            TextBox20.Click, TextBox21.Click, TextBox22.Click, TextBox23.Click, TextBox24.Click, TextBox25.Click

        selectText = sender

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Anrold()
    End Sub
    Private Sub Anrold()

        For y = 1 To 5
            For x = 1 To 5
                Dim k As Integer = (y - 1) * 5 + x
                map(x, y) = Controls("TextBox" & k)
                colorMap(x - 1, y - 1) = IIf(map(x, y).backColor = Color.White, 1, 2)
            Next
        Next

        Dim newColorMap(5, 5)

        newColorMap = colorMap.Clone

        For y = 0 To 4
            For x = 0 To 4
                Dim newX = (1 * x + 1 * y) Mod 5
                Dim newY = (1 * x + 2 * y) Mod 5
                newColorMap(newX, newY) = colorMap(x, y)
            Next
        Next

        colorMap = newColorMap.Clone


        For i = 1 To 5
            For j = 1 To 5
                map(i, j).backColor = IIf(colorMap(i - 1, j - 1) = 1, Color.White, Color.Black)
            Next
        Next
    End Sub
End Class
