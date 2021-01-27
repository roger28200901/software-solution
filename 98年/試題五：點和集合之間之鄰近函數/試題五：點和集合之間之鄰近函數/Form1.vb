Public Class Form1
    Dim tboxX(1, 7) As TextBox
    Dim lab(7) As Label
    Dim Lp As New List(Of vector)
    Dim nx As Integer
    Dim er As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim n As Integer = Val(TextBox1.Text)
        nx = n
        If n >= 1 And n <= 8 Then
            For x = 0 To 1
                For i = 0 To n - 1
                    tboxX(x, i) = New TextBox
                    If x = 0 Then
                        lab(i) = New Label
                        With lab(i)
                            .Location = New Point(30, 70 + i * 30)
                            .Text = "第x" & (i + 1) & "點座標"
                            .Visible = True
                            GroupBox1.Controls.Add(lab(i))
                        End With
                    End If

                    With tboxX(x, i)
                        .Location = New Point(150 + x * 80, 70 + i * 30)
                        .Size = New Size(50, 20)
                        .Visible = True
                        GroupBox1.Controls.Add(tboxX(x, i))
                    End With
                Next
            Next
        Else
            MsgBox("範圍只能1～8")
            Exit Sub
        End If

        GroupBox1.Visible = True
        GroupBox2.Visible = True
        GroupBox1.Text = "請輸入" & n & "個點座標(x,y)"

    End Sub
    Private Sub readXY()

        For j = 0 To nx - 1
            If tboxX(0, j).Text = "" Or tboxX(1, j).Text = "" Then
                MsgBox("填寫不正確")
                er = True
                Exit Sub
            End If
            Dim p As vector = New vector(Val(tboxX(0, j).Text), Val(tboxX(1, j).Text))
            Lp.Add(p)
        Next
        er = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call readXY()
        If er = True Then
            Exit Sub
        End If
        Dim testP As New vector(Val(testX.Text), Val(testY.Text))

        Dim deltaList As New List(Of Double)

        For Each item In Lp
            Dim delta = Math.Sqrt((((testP.X - item.X) ^ 2) + ((testP.Y - item.Y) ^ 2)))
            deltaList.Add(delta)
        Next


        Dim max As Double = deltaList.Max
        TextBox2.Text = max

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call readXY()
        If er = True Then
            Exit Sub
        End If
        Dim testP As New Point(Val(testX.Text), Val(testY.Text))

        Dim deltaList As New List(Of Double)

        For Each item In Lp
            Dim delta = Math.Sqrt((((testP.X - item.x) ^ 2) + ((testP.Y - item.y) ^ 2)))
            deltaList.Add(delta)
        Next


        Dim min As Double = deltaList.Min
        TextBox3.Text = min
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call readXY()
        If er = True Then
            Exit Sub
        End If
        Dim testP As New Point(Val(testX.Text), Val(testY.Text))

        Dim deltaList As New List(Of Double)

        For Each item In Lp
            Dim delta = Math.Sqrt((((testP.X - item.x) ^ 2) + ((testP.Y - item.y) ^ 2)))
            deltaList.Add(delta)
        Next


        Dim ave As Double = deltaList.Average

        TextBox4.Text = ave
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call readXY()
        If er = True Or nx = 0 Then
            Exit Sub
        End If
        Chart1.Visible = True
        For Each item In Lp
            Chart1.Series(0).Points.AddXY(item.x, item.y)
        Next
        Chart1.Series.Add("未知點")

        Chart1.Series("未知點").ChartType = DataVisualization.Charting.SeriesChartType.Point

        Chart1.Series(1).Points.AddXY(Val(testX.Text), Val(testY.Text))
        Chart1.Series(1).Color = Color.Red


    End Sub
End Class

Class vector
    Public x As Double
    Public y As Double
    Public Sub New(ByVal x As Double, ByVal y As Double)
        Me.x = x
        Me.y = y
    End Sub
End Class