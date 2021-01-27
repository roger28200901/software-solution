Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim t1 = TextBox1.Text
        Dim t2 = TextBox3.Text
        Dim datas1 = t1.Split(" ")
        Dim datas2 = t2.Split(" ")
        Dim polynomial1(100) 'index是次方
        Dim polynomial2(100)
        Dim polynomial3(10000)

        For i = 0 To UBound(datas1) Step 2
            polynomial1(datas1(i + 1)) = datas1(i)
        Next

        For i = 0 To UBound(datas2) Step 2
            polynomial2(datas2(i + 1)) = datas2(i)
        Next

        Select Case TextBox2.Text
            Case "+"
                For i = 0 To 100
                    polynomial3(i) = Val(polynomial1(i)) + Val(polynomial2(i))
                Next
            Case "-"
                For i = 0 To 100
                    polynomial3(i) = Val(polynomial1(i)) - Val(polynomial2(i))
                Next
            Case "*"
                For i = 0 To 100
                    For j = 0 To 100
                        polynomial3(i + j) += Val(polynomial1(i)) * Val(polynomial2(j))
                    Next
                Next
        End Select
        TextBox4.Text = ""
        For i = 100 To 0 Step -1
            If polynomial3(i) <> 0 Then
                TextBox4.Text &= polynomial3(i) & " " & i & " "
            End If
        Next

    End Sub
End Class
