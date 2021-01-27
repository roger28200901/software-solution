Public Class Form1
    Dim map(10, 20) As Boolean
    Dim move(10, 20) As Boolean
    Dim cho As Integer
    Dim key As Boolean = False
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Focus()
        Timer1.Enabled = True
        Randomize()
        cho = Fix((7 - 1 + 1) * VBMath.Rnd + 1)
        key = True
        Select Case cho
            Case 1
                For i = 4 To 7
                    map(i, 1) = True
                Next
            Case 2
                map(4, 1) = True
                For i = 4 To 6
                    map(i, 2) = True
                Next
            Case 3
                map(6, 1) = True
                For i = 4 To 6
                    map(i, 2) = True
                Next
            Case 4
                For i = 5 To 6
                    map(i, 1) = True
                    map(i, 2) = True
                Next
            Case 5
                For i = 4 To 5
                    map(i + 1, 1) = True
                    map(i, 2) = True
                Next
            Case 6
                map(5, 1) = True
                For i = 4 To 6
                    map(i, 2) = True
                Next
            Case 7
                For i = 6 To 7
                    map(i - 1, 1) = True
                    map(i, 2) = True
                Next
        End Select
    End Sub

    Private Sub Button1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If key Then
            For j = 1 To 19
                For i = 1 To 10
                    If map(i, j) = True Then move(i, j + 1) = True : map(i, j) = False
                Next
            Next

            For i = 1 To 10
                For j = 1 To 20
                    If i <> 1 And i <> 10 And j <> 20 Then Controls("TextBox" & turn(i, j)).BackColor = Color.Black
                    If move(i, j) = True Then drawblock(i, j) : map(i, j) = True
                    move(i, j) = False
                Next
            Next
        End If




    End Sub

    Sub drawblock(ByVal i As Integer, ByVal j As Integer) '化方塊
        Dim c As Color
        Select Case cho
            Case 1
                c = Color.LightBlue
            Case 2
                c = Color.DarkBlue
            Case 3
                c = Color.Orange
            Case 4
                c = Color.Yellow
            Case 5
                c = Color.Green
            Case 6
                c = Color.Purple
            Case 7
                c = Color.Red
        End Select
        Controls("TextBox" & turn(i, j)).BackColor = c
    End Sub
    Function turn(ByVal i As Integer, ByVal j As Integer) As Integer '座標轉數值
        Dim sum As Integer = 0
        For y = 1 To 20
            For x = 1 To 10
                sum += 1
                If x = i And y = j Then Return sum
            Next
        Next
    End Function








    Private Sub Button1_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox99.KeyDown, TextBox98.KeyDown, TextBox97.KeyDown, TextBox96.KeyDown, TextBox95.KeyDown, TextBox94.KeyDown, TextBox93.KeyDown, TextBox92.KeyDown, TextBox91.KeyDown, TextBox90.KeyDown, TextBox9.KeyDown, TextBox89.KeyDown, TextBox88.KeyDown, TextBox87.KeyDown, TextBox86.KeyDown, TextBox85.KeyDown, TextBox84.KeyDown, TextBox83.KeyDown, TextBox82.KeyDown, TextBox81.KeyDown, TextBox80.KeyDown, TextBox8.KeyDown, TextBox79.KeyDown, TextBox78.KeyDown, TextBox77.KeyDown, TextBox76.KeyDown, TextBox75.KeyDown, TextBox74.KeyDown, TextBox73.KeyDown, TextBox72.KeyDown, TextBox71.KeyDown, TextBox70.KeyDown, TextBox7.KeyDown, TextBox69.KeyDown, TextBox68.KeyDown, TextBox67.KeyDown, TextBox66.KeyDown, TextBox65.KeyDown, TextBox64.KeyDown, TextBox63.KeyDown, TextBox62.KeyDown, TextBox61.KeyDown, TextBox60.KeyDown, TextBox6.KeyDown, TextBox59.KeyDown, TextBox58.KeyDown, TextBox57.KeyDown, TextBox56.KeyDown, TextBox55.KeyDown, TextBox54.KeyDown, TextBox53.KeyDown, TextBox52.KeyDown, TextBox51.KeyDown, TextBox50.KeyDown, TextBox5.KeyDown, TextBox49.KeyDown, TextBox48.KeyDown, TextBox47.KeyDown, TextBox46.KeyDown, TextBox45.KeyDown, TextBox44.KeyDown, TextBox43.KeyDown, TextBox42.KeyDown, TextBox41.KeyDown, TextBox40.KeyDown, TextBox4.KeyDown, TextBox39.KeyDown, TextBox38.KeyDown, TextBox37.KeyDown, TextBox36.KeyDown, TextBox35.KeyDown, TextBox34.KeyDown, TextBox33.KeyDown, TextBox32.KeyDown, TextBox31.KeyDown, TextBox30.KeyDown, TextBox3.KeyDown, TextBox29.KeyDown, TextBox28.KeyDown, TextBox27.KeyDown, TextBox26.KeyDown, TextBox25.KeyDown, TextBox24.KeyDown, TextBox23.KeyDown, TextBox22.KeyDown, TextBox21.KeyDown, TextBox200.KeyDown, TextBox20.KeyDown, TextBox2.KeyDown, TextBox199.KeyDown, TextBox198.KeyDown, TextBox197.KeyDown, TextBox196.KeyDown, TextBox195.KeyDown, TextBox194.KeyDown, TextBox193.KeyDown, TextBox192.KeyDown, TextBox191.KeyDown, TextBox190.KeyDown, TextBox19.KeyDown, TextBox189.KeyDown, TextBox188.KeyDown, TextBox187.KeyDown, TextBox186.KeyDown, TextBox185.KeyDown, TextBox184.KeyDown, TextBox183.KeyDown, TextBox182.KeyDown, TextBox181.KeyDown, TextBox180.KeyDown, TextBox18.KeyDown, TextBox179.KeyDown, TextBox178.KeyDown, TextBox177.KeyDown, TextBox176.KeyDown, TextBox175.KeyDown, TextBox174.KeyDown, TextBox173.KeyDown, TextBox172.KeyDown, TextBox171.KeyDown, TextBox170.KeyDown, TextBox17.KeyDown, TextBox169.KeyDown, TextBox168.KeyDown, TextBox167.KeyDown, TextBox166.KeyDown, TextBox165.KeyDown, TextBox164.KeyDown, TextBox163.KeyDown, TextBox162.KeyDown, TextBox161.KeyDown, TextBox160.KeyDown, TextBox16.KeyDown, TextBox159.KeyDown, TextBox158.KeyDown, TextBox157.KeyDown, TextBox156.KeyDown, TextBox155.KeyDown, TextBox154.KeyDown, TextBox153.KeyDown, TextBox152.KeyDown, TextBox151.KeyDown, TextBox150.KeyDown, TextBox15.KeyDown, TextBox149.KeyDown, TextBox148.KeyDown, TextBox147.KeyDown, TextBox146.KeyDown, TextBox145.KeyDown, TextBox144.KeyDown, TextBox143.KeyDown, TextBox142.KeyDown, TextBox141.KeyDown, TextBox140.KeyDown, TextBox14.KeyDown, TextBox139.KeyDown, TextBox138.KeyDown, TextBox137.KeyDown, TextBox136.KeyDown, TextBox135.KeyDown, TextBox134.KeyDown, TextBox133.KeyDown, TextBox132.KeyDown, TextBox131.KeyDown, TextBox130.KeyDown, TextBox13.KeyDown, TextBox129.KeyDown, TextBox128.KeyDown, TextBox127.KeyDown, TextBox126.KeyDown, TextBox125.KeyDown, TextBox124.KeyDown, TextBox123.KeyDown, TextBox122.KeyDown, TextBox121.KeyDown, TextBox120.KeyDown, TextBox12.KeyDown, TextBox119.KeyDown, TextBox118.KeyDown, TextBox117.KeyDown, TextBox116.KeyDown, TextBox115.KeyDown, TextBox114.KeyDown, TextBox113.KeyDown, TextBox112.KeyDown, TextBox111.KeyDown, TextBox110.KeyDown, TextBox11.KeyDown, TextBox109.KeyDown, TextBox108.KeyDown, TextBox107.KeyDown, TextBox106.KeyDown, TextBox105.KeyDown, TextBox104.KeyDown, TextBox103.KeyDown, TextBox102.KeyDown, TextBox101.KeyDown, TextBox100.KeyDown, TextBox10.KeyDown, TextBox1.KeyDown, MyBase.KeyDown, Button1.KeyDown

        If e.KeyCode = Keys.Left Then
            For j = 1 To 19
                For i = 1 To 10
                    key = False
                    If map(i, j) = True Then move(i - 1, j) = True : map(i, j) = False ': map(i - 1, j) = True
                Next
            Next

            'For j = 1 To 19
            '    For i = 1 To 10
            '        key = False
            '        If move(i, j) = True Then move(i, j) = False : map(i, j) = True
            '    Next
            'Next
        End If
        '   key = True
    End Sub
End Class
