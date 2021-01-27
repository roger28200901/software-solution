Class ManagementProcess
    Public Pn As Integer
    Public Mn As String
    Public Ms As Integer
    Public need As Integer
    Public Sub New(ByVal p As Integer, ByVal n As String, ByVal s As Integer, ByVal ned As Integer)
        Me.Pn = p
        Me.Mn = n
        Me.Ms = s
        Me.need = ned
    End Sub
End Class
Module Module1
    Dim visit As New Queue
    Dim memory As New List(Of Integer)
    Dim process As New List(Of Integer)
    Dim processAfter As New List(Of ManagementProcess)
    Sub Main()
        memory.Clear()
        process.Clear()

        Console.WriteLine("記憶體管理程式-最適配置法(Best Fit)")
        Console.Write("請輸入記憶體區塊數<6：")
        Dim memoryNumber As Integer = Console.ReadLine()
        Console.Write("請輸入程序數(<6)：")
        Dim processNumber As Integer = Console.ReadLine()
        Console.WriteLine()
        Console.WriteLine("請輸入個區塊大小(<10)---")
        For i = 1 To memoryNumber
            Console.Write("區塊" & i & "：")
            Dim value = Console.ReadLine().Split(",")
            memory.Add(value(0))
            processAfter.Add(New ManagementProcess(0, i, value(0), 0))
        Next

        Console.WriteLine()
        Console.WriteLine("請輸入各程序所需的大小(<10)---")
        For j = 1 To processNumber
            Console.Write("程序" & j & "：")
            Dim value = Console.ReadLine().Split(",")
            process.Add(value(0))
        Next
        Console.WriteLine()
        Console.WriteLine("程序編號     所需大小     區塊編號       區塊大小     剩餘空間")
        For q = 1 To processNumber
            Dim Pnumber = q
            Dim Psize = process(q - 1)
            Dim Mnumber, Msize
            Mnumber = findCloseValue(Psize, True)
            If Mnumber = 0 Then
                Mnumber = "未分配記憶體區塊"
                Msize = ""
            Else
                Msize = findCloseValue(Psize, False)
            End If
            Dim self
            If Msize.ToString = "" Then
                self = ""
            Else
                self = Msize - Psize
            End If

            For Each item In processAfter
                If item.Mn = Mnumber Then
                    item.Pn = Pnumber
                    item.need = Psize
                End If
            Next
            Console.WriteLine(Pnumber.ToString.PadRight(7, "　") & Psize.ToString.PadRight(7, "　") & Mnumber.ToString.PadRight(8, "　") & Msize.ToString.PadRight(7, "　") & self)
        Next
        Console.WriteLine()
        Console.Write("　　　　　■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim str As String = ""
            str = str.PadLeft(nm, "■")
            Console.Write(str & "■")
        Next
        Console.WriteLine()
        Console.Write("　　　　　■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim str As String = ""
            str = str.PadLeft(nm, "　")
            Console.Write(str & "■")
        Next
        Console.WriteLine()
        Console.Write("配置程序前■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim str As String = ""
            str = str.PadLeft(nm, "　")
            Console.Write(str & "■")
        Next
        Console.WriteLine()
        Console.Write("　　　　　■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim str As String = ""
            str = str.PadLeft(nm, "　")
            Console.Write(str & "■")
        Next
        Console.WriteLine()
        Console.Write("　　　　　■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim str As String = ""
            str = str.PadLeft(nm, "■")
            Console.Write(str & "■")
        Next
        Console.WriteLine()
        Console.Write("　　　　　  ")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim minus As New List(Of String)
            For x = 1 To nm
                minus.Add(x)
            Next
            Dim str As String = ""
            str = String.Join("-", minus.ToArray) & "-" & "　"
            Console.Write(str)
        Next
        Console.WriteLine()
        '''''
        Console.Write("　　　　　■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim str As String = ""
            str = str.PadLeft(nm, "■")
            Console.Write(str & "■")
        Next
        Console.WriteLine()
        Console.Write("　　　　　■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim str As String = ""
            str = str.PadLeft(nm, "　")
            Console.Write(str & "■")
        Next
        Console.WriteLine()
        Console.Write("程序配置後■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim obj As ManagementProcess
            For Each item In processAfter
                If item.Ms = memory(s - 1) Then
                    obj = item
                    Exit For
                End If
            Next

            Dim str As String = ""
            str &= "P" & obj.Pn
            Dim strE As String = ""
            strE = str.PadRight(obj.need * 2, "==")
            str = strE
            str = str.PadRight(nm * 2, " ")
            Console.Write(str & "■")
        Next
        Console.WriteLine()
        Console.Write("　　　　　■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim str As String = ""
            str = str.PadLeft(nm, "　")
            Console.Write(str & "■")
        Next
        Console.WriteLine()
        Console.Write("　　　　　■")
        For s = 1 To memory.Count
            Dim nm As Integer = memory(s - 1)
            Dim str As String = ""
            str = str.PadLeft(nm, "■")
            Console.Write(str & "■")
        Next
        Console.WriteLine()

        Console.Write("請按任意鍵繼續...")
        Console.ReadKey()

    End Sub
    Private Function findCloseValue(ByVal value As Integer, ByVal indexOrNot As Boolean)
        Dim delta = 1000000000.0, index = -1
        For i = 0 To memory.Count - 1
            If memory(i) - value < delta And memory(i) >= value And visit.Contains(i) = False Then
                delta = memory(i) - value
                index = i
            End If
        Next
        If indexOrNot = True Then

            Return index + 1
        Else
            visit.Enqueue(index)
            Return memory(index)
        End If

    End Function

End Module
