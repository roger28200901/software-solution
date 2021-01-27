Imports System.Text.RegularExpressions
Module Module1

    Sub Main()
        Dim c As Boolean = True
        Dim s As String()
        Dim datas As Boolean(,)
        Dim max As Integer = 1
        Dim temp As Boolean(,)
        Do While (c)

            max = 20
            Console.WriteLine("請選擇操作項目")
            Console.WriteLine("<1>輸入二點座標(x1,y1), (x2,y2)繪一線:")
            Console.WriteLine("<2>輸入三點座標(x1,y1), (x2,y2), (x3,y3)繪三角形:")
            Console.WriteLine("<3>上題三角形水平翻轉:")
            Console.Write("請選擇:")
            Dim choose = Console.ReadLine()
            Dim regxp As New Regex("\s+")
            Select Case choose
                Case 1
                    Console.Write("x1,y1, x2,y2:")
                    Dim input As String
                    input = regxp.Replace(Console.ReadLine(), " ")
                    s = Split(input, " ")
                    If s.Length <> 4 Then
                        Console.Write("輸入參數錯誤")
                        Continue Do
                    End If

                    max = (getMax(s, 0) + 1)
                    ReDim datas(max,max)
                    datas = getLine(Int(s(0)), Int(s(1)), Int(s(2)), Int(s(3)), max, datas)

                    drawDatas(max, datas)
                Case 2
                    Console.Write("x1,y1, x2,y2, x3,y3:")
                    Dim input As String
                    input = regxp.Replace(Console.ReadLine(), " ")
                    s = Split(input, " ")
                    If s.Length <> 6 Then
                        Console.Write("輸入參數錯誤")
                        Continue Do
                    End If
                    max = 30
                    ReDim datas(max, max)
                    datas = triangle(Int(s(0)), Int(s(1)), Int(s(2)), Int(s(3)), Int(s(4)), Int(s(5)), max, datas)
                    temp = datas.Clone()
                    drawDatas(max, datas)
                Case 3
                    max = 30
                    redrawDatas(max, temp)
                Case Else
                    Console.Write("請選擇正確選項")
            End Select

            Console.Write("結束請按0，繼續請按1:")
            If "0" = Console.ReadLine() Then
                c = False
            End If
        Loop
    End Sub
    Function triangle(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal x3 As Integer, ByVal y3 As Integer, ByVal max As Integer, ByVal datas As Boolean(,))
        Dim x As Integer, y As Integer
        Dim xd As Integer, yd As Integer
        xd = x2 - x1
        yd = y2 - y1

        max = Math.Abs(Math.Max(Math.Abs(xd), Math.Abs(yd)))
        For i = 0 To max
            x = x1 + Math.Ceiling(xd / max * i)
            y = y1 + Math.Floor(yd / max * i)
            datas(x, y) = True
        Next

        xd = x3 - x2
        yd = y3 - y2
        max = Math.Abs(Math.Max(Math.Abs(xd), Math.Abs(yd)))
        For i = 0 To max
            x = x2 + Math.Ceiling(xd / max * i)
            y = y2 + Math.Floor(yd / max * i)
            datas(x, y) = True
        Next

        xd = x3 - x1
        yd = y3 - y1
        max = Math.Abs(Math.Max(Math.Abs(xd), Math.Abs(yd)))
        For i = 0 To max
            x = x1 + Math.Ceiling(xd / max * i)
            y = y1 + Math.Floor(yd / max * i)
            datas(x, y) = True
        Next
        Return datas
    End Function
    Function getLine(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal max As Integer, ByVal datas As Boolean(,))
        Dim x As Integer, y As Integer
        Dim xd As Integer, yd As Integer

        xd = x2 - x1
        yd = y2 - y1
        max = Math.Abs(Math.Max(xd, yd))
        For i = 0 To max
            x = x1 + Math.Ceiling(xd / max * i)
            y = y1 + Math.Floor(yd / max * i)
            datas(x, y) = True
        Next
        Return datas
    End Function
    Function getMax(ByVal s, ByVal k)
        Dim max = k
        For Each element In s
            If Val(element) > max Then
                max = element
            End If
        Next
        Return max
    End Function

    Function drawDatas(ByVal max, ByVal datas)
        For i = max To 0 Step -1
            For j = 0 To max
                Console.Write(IIf(datas(j, i), "*", " "))
            Next
            Console.WriteLine()
        Next
    End Function
    Function redrawDatas(ByVal max, ByVal datas)
        For i = max To 0 Step -1
            For j = max To 0 Step -1
                Console.Write(IIf(datas(j, i), "*", " "))
            Next
            Console.WriteLine()
        Next
    End Function
End Module
