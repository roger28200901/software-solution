Public Class Form1
    Dim op
    Dim tempValue As Double
    Dim x As Boolean = False
    Dim clearResult As Boolean = False

    Private Sub btn_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_0.Click
        setNumber("0")
    End Sub

    Private Sub btn_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1.Click
        setNumber("1")
    End Sub

    Private Sub btn_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_2.Click
        setNumber("2")
    End Sub

    Private Sub btn_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_3.Click
        setNumber("3")
    End Sub

    Private Sub btn_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_4.Click
        setNumber("4")
    End Sub

    Private Sub btn_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_5.Click
        setNumber("5")
    End Sub

    Private Sub btn_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_6.Click
        setNumber("6")
    End Sub

    Private Sub btn_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_7.Click
        setNumber("7")
    End Sub

    Private Sub btn_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_8.Click
        setNumber("8")
    End Sub

    Private Sub btn_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_9.Click
        setNumber("9")
    End Sub
    Private Sub btn_dot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_dot.Click
       
        setNumber(".")
    End Sub

    Private Function setNumber(ByVal n As String)
        If clearResult = True And op <> Nothing Then
            TextBox1.Text = 0
            op = Nothing
            tempValue = Nothing
            x = False
            clearResult = False
        End If
        For i = 1 To TextBox1.Text.Length
            If Mid(TextBox1.Text, i, 1) = "." And n = "." Then
                Return 0
            End If
        Next

        If TextBox1.Text = "0" And n <> "." Then
            TextBox1.Text = n
        Else
            TextBox1.Text &= n
        End If

    End Function
    Private Sub setOption(ByVal n As String)
        x = False
        op = n
        tempValue = Val(TextBox1.Text)
        TextBox2.Text = tempValue & op
        TextBox1.Text = "0"
    End Sub
    Private Sub btn_plus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_plus.Click
        setOption("+")
    End Sub

    Private Sub btn_less_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_less.Click
        setOption("-")
    End Sub

    Private Sub btn_mutiplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mutiplication.Click
        setOption("*")
    End Sub

    Private Sub btn_division_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_division.Click
        setOption("/")
    End Sub

    Private Sub btn_equals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_equals.Click
        Dim NowValue = Val(TextBox1.Text)
        clearResult = True
        TextBox2.Text = ""

        Dim equals As Double
        Select Case (op)
            Case "+"
                equals = Convert.ToDouble(tempValue) + Convert.ToDouble(NowValue)
            Case "-"
                equals = Convert.ToDouble(tempValue) - Convert.ToDouble(NowValue)
            Case "*"
                equals = Convert.ToDouble(tempValue) * Convert.ToDouble(NowValue)
            Case "/"
                equals = Convert.ToDouble(tempValue) / Convert.ToDouble(NowValue)
        End Select
        If x = False Then
            tempValue = NowValue
        Else
            tempValue = tempValue
        End If
        x = True


        TextBox1.Text = equals
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = "0"
    End Sub

    Private Sub btn_c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_c.Click
        TextBox1.Text = 0
        op = Nothing
        tempValue = Nothing
        x = False
    End Sub
End Class
