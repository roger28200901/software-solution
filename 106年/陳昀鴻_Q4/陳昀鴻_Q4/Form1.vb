Public Class Form1
    Dim xDatas As New List(Of Queue)
    Dim yDatas As New List(Of Integer)
    Dim wDatas As New List(Of Queue)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim txt = TextBox1.Text
        txt = txt.Replace(vbCrLf, "/")
        Dim lines = txt.Split("/")
        Dim datas As Array
        xDatas.Clear()
        yDatas.Clear()
        wDatas.Clear()

        '讀取輸入x,y

        For i = 0 To UBound(lines) - 1
            Do
                If InStr(1, lines(i), "  ") > 0 Then
                    lines(i) = lines(i).Replace("  ", " ")
                Else
                    Exit Do
                End If
            Loop
            datas = lines(i).Split(" ")
            Dim q As New Queue
            Dim q2 As New Queue
            q.Enqueue(Val(datas(0)))
            q.Enqueue(Val(datas(1)))
            q.Enqueue(Val(datas(2)))


            xDatas.Add(q)
            yDatas.Add(Val(datas(3)))
        Next
        '讀取w
        Dim txt2 = TextBox4.Text

        Dim f As New List(Of Double)
        Dim temp = txt2.Split(";")
        Dim q3 As New Queue
        For i = 0 To UBound(temp)
            q3.Enqueue(Val(temp(i)))
        Next


        Dim n = Val(TextBox3.Text)
        wDatas.Add(q3)
        Dim Er As Double = 0
        '小l
        Dim sk = 0
        '大k
        Dim dk = 0
        Dim K = xDatas.Count - 1
        Dim maxTime = Val(TextBox2.Text)
        Dim count = 1
        Do While sk < K And maxTime >= count
            For i = 0 To xDatas.Count - 1
                Dim sign = fs(wDatas, xDatas, wDatas.Count - 1, i)
                ' 1 <> Y1 
                If sign <> yDatas(i) Then
                    'w1 = w0 + n(y- sign)*x1
                    Dim qq As New Queue
                    For j = 0 To wDatas(0).Count - 1
                        Dim w1 = wDatas(dk + i)(j) + n * (yDatas(i) - sign) * xDatas(i)(j)
                        qq.Enqueue(w1)
                    Next
                    wDatas.Add(qq)
                Else
                    Dim q As New Queue
                    For j = 0 To wDatas(i).Count - 1
                        Dim w = wDatas(i + dk)(j)
                        q.Enqueue(w)
                    Next
                    wDatas.Add(q)
                End If 'E =E + 0.5 * ||yk- o(xk)||2 
                Er = Er + 0.5 * Math.Pow(Math.Abs(yDatas(i) - sign), 2)
            Next
            count += 1
            If Er > 0 Then
                Er = 0
                sk = 1
                dk += 3
                Continue Do
            Else
                Exit Do
            End If
            sk += 1
        Loop

        TextBox5.Text = ""
        For x = 0 To wDatas(wDatas.Count - 1).Count - 1
            If x <> wDatas(wDatas.Count - 1).Count - 1 Then
                TextBox5.Text &= Format(wDatas(wDatas.Count - 1)(x), "0.00") & ";"
            Else
                TextBox5.Text &= Format(wDatas(wDatas.Count - 1)(x), "0.00")
            End If
        Next
        Dim xk = TextBox6.Text.Split(";")
        Dim qqq As New Queue
        For i = 0 To UBound(xk)
            qqq.Enqueue(xk(i))
        Next
        xDatas.Add(qqq)



    End Sub
    Function fs(ByVal w As List(Of Queue), ByVal x As List(Of Queue), ByVal k As Integer, ByVal n As Integer)
        Dim ff As Double = 0
        For i = 0 To 2
            ff += Val(w(k)(i)) * Val(x(n)(i))
        Next
        Dim o = IIf(ff >= 0, 1, -1)
        Return o
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim signO = fs(wDatas, xDatas, wDatas.Count - 1, xDatas.Count - 1)
        If signO = -1 Then
            Label8.Text = "機器人向:" & signO & "右"
        Else
            Label8.Text = "機器人向:" & signO & "左"
        End If
    End Sub
End Class
