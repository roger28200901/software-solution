Module Module1

    Sub Main()
START:
        Dim temp_1, temp_2, temp_3 As String()
        Console.Write("請輸入「專業能力」對「通識素養」的指標比值<輸入2個數值>：")
        temp_1 = Split(Console.ReadLine(), " ")
        Console.Write("請輸入「專業能力」對「合群性」的指標比值<輸入2個數值>：")
        temp_2 = Split(Console.ReadLine(), " ")
        Console.Write("請輸入「通識素養」對「合群性」的指標比值<輸入2個數值>：")
        temp_3 = Split(Console.ReadLine(), " ")

        Dim a(3, 3), b(3, 3), z(3, 3) As Double

        a(1, 2) = temp_1(0) / temp_1(1) : a(2, 1) = 1 / temp_1(0) / temp_1(1)
        a(1, 3) = temp_2(0) / temp_2(1) : a(3, 1) = 1 / temp_2(0) / temp_2(1)
        a(2, 3) = temp_3(0) / temp_3(1) : a(3, 2) = 1 / temp_3(0) / temp_3(1)

        For i = 1 To 3
            a(i, i) = 1
        Next
        For x = 1 To 3
            For y = 1 To 3
                Console.Write(Format(a(x, y), "0.000") & vbTab)
            Next
            Console.Write(vbCrLf)
        Next

        For x = 1 To 3
            For y = 1 To 3
                Dim sum As Double = 0
                For i = 1 To 3
                    sum += a(i, y)
                Next
                b(x, y) = a(x, y) / sum
            Next
        Next
        Dim w(3) As Double
        For x = 1 To 3
            Dim sum As Double = 0
            For y = 1 To 3
                sum += b(x, y)
            Next
            'sum = Math.Round(sum / 3, 3)
            sum = sum / 3
            w(x) = sum
        Next
        Console.Write("顯示指標的權重:")
        For i = 1 To 3
            'Console.Write(vbTab & "w" & i & ":" & w(i))
            Console.Write(vbTab & "w" & i & ":" & Format(w(i), "0.000"))
            '用round也可以 但是後面算的數值不一樣
        Next
        Dim lundaMax As Double
        For j = 1 To 3
            Dim sum As Double = 0
            For i = 1 To 3
                sum += a(i, j)
            Next
            lundaMax += w(j) * sum
        Next
        Dim CR As Double = 0
        Dim RI As Double = 0.58
        CR = (lundaMax - 3) / (2 * RI)
        Console.WriteLine()
        Console.WriteLine("顯示最大特徵值 LundaMax=" & Format(lundaMax, "0.000"))

        If CR < 1 Then
            Console.WriteLine("顯示一致性比率: CR=" & Format(CR, "0.000") & "。CR小於1，符合一致性")
        Else
            Console.WriteLine("顯示一致性比率: CR=" & Format(CR, "0.000") & "。CR大於1，不符合一致性")
        End If
        Console.Write("繼續否?<y or n>:")
        If Console.ReadLine().ToUpper = "Y" Then
            GoTo START
        End If
    End Sub

End Module
