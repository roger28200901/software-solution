Public Class Form1
    Dim MSEs As New List(Of Double)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mathT.Text = ""
        englishT.Text = ""
        group.Text = ""

        Dim r As New Random
        Randomize()
        Dim n = Val(Nt.Text)
        Dim q = Val(Qt.Text)
        For i = 0 To n - 1
            mathT.Text &= r.Next(101) & " "
            englishT.Text &= r.Next(101) & " "
        Next



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim mathDatas : Dim englishDatas
        Randomize()

        MSEs = New List(Of Double)

        mathDatas = mathT.Text.Split(" ")
        englishDatas = englishT.Text.Split(" ")
        Dim n As Integer = Val(Nt.Text)
        Dim q = Val(Qt.Text)
        Dim students(n)
        For j = 0 To n - 1
            students(j) = New student(mathDatas(j), englishDatas(j), j)
        Next


        Dim r As New Random
        Dim r1 = r.Next(n)
        Dim r2 = r.Next(n)
        While r1 = r2
            r2 = r.Next(n)
        End While

        Dim heavy1 As student = New student(mathDatas(r1), englishDatas(r1), 999)
        Dim heavy2 As student = New student(mathDatas(r2), englishDatas(r2), 999)
        Dim p = 0


        Dim group1 As ArrayList
        Dim group2 As ArrayList
        While p < q

            group1 = New ArrayList
            group2 = New ArrayList

            For i = 0 To n - 1
                Dim d1 As Double = Math.Sqrt(Math.Pow(students(i).maths - heavy1.maths, 2) + Math.Pow(students(i).englishs - heavy1.englishs, 2))
                Dim d2 As Double = Math.Sqrt(Math.Pow(students(i).maths - heavy2.maths, 2) + Math.Pow(students(i).englishs - heavy2.englishs, 2))
                If d1 <= d2 Then
                    group1.Add(students(i))
                Else
                    group2.Add(students(i))
                End If
            Next
            Dim MSE As Double = 0
            Dim gSum1 As Double = 0
            Dim gSum2 As Double = 0
            For Each g In group1
                gSum1 += Math.Sqrt(Math.Pow(g.maths - heavy1.maths, 2) + Math.Pow(g.englishs - heavy2.englishs, 2))
            Next
            For Each g In group2
                gSum2 += Math.Sqrt(Math.Pow(g.maths - heavy1.maths, 2) + Math.Pow(g.englishs - heavy2.englishs, 2))
            Next
            MSE = gSum1 + gSum2
            MSE = MSE / n

            Dim avM1 As Double = 0 : Dim avE1 As Double = 0
            Dim avM2 As Double = 0 : Dim avE2 As Double = 0

            For Each v1 In group1
                avM1 += v1.maths
                avE1 += v1.englishs
            Next

            For Each v2 In group2
                avM2 += v2.maths
                avE2 += v2.englishs
            Next

            avM1 /= group1.Count
            avE1 /= group1.Count

            avM2 /= group2.Count
            avE2 /= group2.Count


            heavy1.sets(avM1, avE1)
            heavy2.sets(avM2, avE2)
            MSEs.Add(MSE)
            p = p + 1
        End While

        group.Text = ""
        For i = 0 To n - 1
            Dim d As Boolean = False
            For Each g1 In group1
                If g1.index = i Then
                    d = True
                    Exit For
                End If
            Next

            If d = True Then
                group.Text &= "1" & " "
            Else
                group.Text &= "2" & " "
            End If
        Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Chart1.Series(0).Points.Clear()
        Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        Chart1.ChartAreas(0).AxisX.Title = "疊代次數"
        Chart1.ChartAreas(0).AxisY.Title = "MSE"
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.ChartAreas(0).AxisX.Maximum = Val(Qt.Text) - 1
        Chart1.ChartAreas(0).AxisX.Minimum = 0
        Chart1.ChartAreas(0).AxisY.Maximum = Val(MSEs.Max + 3)
        Chart1.ChartAreas(0).AxisY.Interval = 2
        For i = 0 To MSEs.Count - 1
            Dim y As Double = MSEs(i)
            Chart1.Series(0).Points.AddXY(i, y)
        Next
        Dim a As Long = 4

    End Sub
End Class
Public Class student
    Public maths As Integer
    Public englishs As Integer
    Public index As Integer
    Public Sub New(ByVal m As Integer, ByVal e As Integer, ByVal i As Integer)
        Me.maths = m
        Me.englishs = e
        Me.index = i
    End Sub
    Public Sub sets(ByVal m As Integer, ByVal e As Integer)
        Me.maths = m
        Me.englishs = e
    End Sub
End Class
