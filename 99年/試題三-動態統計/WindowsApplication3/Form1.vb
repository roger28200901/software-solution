Public Class Form1
    Dim total As Integer = 0
    Dim Data As New ArrayList
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim inputValue = Val(TextBox2.Text)
        
        AllRow(inputValue)
        Label2.Text = "請輸入第" & Data.Count + 1 & "筆資料"
        If Data.Count >= total Then
            Button1.Visible = False
        End If
    End Sub
    Private Sub AllRow(ByVal input As Double)
        Data.Add(input)

        Dim sum1, sum2, sum3, sum4 As Double
        sum3 = 1
        For Each value In Data
            sum1 += value
            sum2 += value ^ 2
            sum3 *= value
            sum4 += 1 / value
        Next
        Dim r(5) As Double
        Dim n = Data.Count
        r(1) = sum1 / n
        If n = 1 Then
            r(2) = 0
        Else
            r(2) = Math.Sqrt((n * sum2 - Math.Pow(sum1, 2)) / (n * (n - 1)))
        End If

        r(3) = Math.Pow(sum3, 1 / n)
        r(4) = Math.Sqrt(sum2 / n)
        r(5) = n / sum4
        DataGridView1.Rows.Add(n, input, floor(r(1), 2), floor(r(2), 3), floor(r(3), 3), floor(r(4), 3), floor(r(5), 3))
    End Sub
    Function floor(ByVal n As Double, ByVal much As Integer)
        
        Dim s As String = n.ToString
        Dim dot As Boolean = False
        For i = 1 To s.Length
            If Mid(s, i, 1) = "." Then
                dot = True
            End If
        Next

        If dot = True Then
            Dim a = s.Split(".")
            a(1) = Mid(a(1), 1, much)
            s = a(0) & "." & a(1) & New String("0", much - a(1).Length)
        Else
            s &= "." & New String("0", much)
        End If

        Return s
    End Function
    'The other way to sum (function)
    'Function sum(ByVal arr As ArrayList)
    '    Dim total As Double
    '    For i = 0 To arr.Count
    '        total += arr(i)
    '    Next
    '    Return total
    'End Function
    'Function average()
    '    Dim s As Double
    '    Dim q = Data.Count * sum(Data)
    '    s = Math.Sqrt()
    'End Function 
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            total = Val(TextBox1.Text)
            Panel1.Visible = True
            DataGridView1.Visible = True
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class
