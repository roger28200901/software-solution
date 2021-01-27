Module Module1
    Dim students As New List(Of student)
    Sub Main()
start:
        Console.WriteLine("請選擇操作項目：")
        Console.WriteLine("     <1>批次輸入：")
        Console.WriteLine("     <2>選手查詢：")
        Console.WriteLine("     <3>刪除：")
        Console.WriteLine("     <4>逐筆輸入：")
        Console.WriteLine("     <5>顯示所有資料：")
        Console.Write("請選擇：")
        Dim s = Val(Console.ReadLine())
        If s = 1 Then
            Console.Write("請輸入檔名：")
            Dim filename = Console.ReadLine
            If My.Computer.FileSystem.FileExists(filename) = False Then
                Console.Write("查無此檔案，重新再試。")
                GoTo start
            Else
                Dim txt = My.Computer.FileSystem.ReadAllText(filename, System.Text.Encoding.Default)
                Dim data = txt.Split({" ", vbLf}, StringSplitOptions.RemoveEmptyEntries)
                Dim count = data.Count
                Dim times = count / 5
                For t = 1 To times
                    Dim q As New Queue
                    q.Clone()
                    For i = 0 To 4
                        q.Enqueue(data(i + (t - 1) * 5))
                    Next
                    Dim v1 = q.Dequeue
                    Dim v2 = q.Dequeue
                    Dim v3 = q.Dequeue
                    Dim v4 = q.Dequeue
                    Dim v5 = q.Dequeue
                    students.Add(New student(v1, v2, v3, v4, v5))
                Next
                Console.WriteLine("讀取成功。")
                GoTo start
            End If
        ElseIf s = 2 Then
            search()
        ElseIf s = 3 Then
            deleteData()
        ElseIf s = 4 Then
            inputData()
        ElseIf s = 5 Then
            showData()
        End If
        Console.Write("繼續：請按1，結束：請按0：")
        Dim con = Console.ReadLine()
        If con = 1 Then
            GoTo start
        Else
            Exit Sub
        End If
        Console.ReadKey()

    End Sub
    Public Sub search()
        Console.WriteLine("選手查詢，")
        Console.Write("請輸入  班級、學號、姓名：")
        Dim input = Console.ReadLine()
        Dim s = input.Split(" ")
        For Each item In students
            If item.grade = s(0) And item.number = s(1) And item.name = s(2) Then
                Console.WriteLine(item.grade & " " & item.number & " " & item.name & " " & item.sex & " " & item.game)
            End If
        Next
    End Sub
    Public Sub deleteData()
        Console.WriteLine("刪除資料，")
        Console.Write("請輸入 班級、學號、姓名及報名項目：")
        Dim input = Console.ReadLine()
        Dim s = input.Split(" ")
        For Each item In students
            If item.grade = s(0) And item.number = s(1) And item.name = s(2) And item.game = s(3) Then
                Console.WriteLine("被刪除的選手資料：" & item.grade & " " & item.number & " " & item.name & " " & item.game)
                students.Remove(item)
                Exit For
            End If
        Next
    End Sub
    Public Sub inputData()
        Console.WriteLine("逐步輸入，")
        Console.Write("請輸入  班級、學號、姓名及性別：")
        Dim input = Console.ReadLine()

        Console.WriteLine("報名項目：")
        Console.WriteLine("a：大隊接力")
        Console.WriteLine("b：一顆球的距離")
        Console.WriteLine("c：天旋地轉")
        Console.WriteLine("d：滾大球袋鼠跳")
        Console.WriteLine("e：牽手同心")
        Console.WriteLine("f：100公尺")
        Console.WriteLine("g：400公尺接力")
        Console.WriteLine("h：800公尺")
        Console.WriteLine("i：跳高")
        Console.Write("請選擇：")
        Dim t = Console.ReadLine()
        Select Case t
            Case "a"
                t = "大隊接力"
            Case "b"
                t = "一顆球的距離"
            Case "c"
                t = "天旋地轉"
            Case "d"
                t = "滾大球袋鼠跳"
            Case "e"
                t = "牽手同心"
            Case "f"
                t = "100公尺"
            Case "g"
                t = "400公尺接力"
            Case "h"
                t = "800公尺"
            Case "i"
                t = "跳高"
        End Select
        input = input & " " & t
        Dim s = input.Split(" ")
        Console.WriteLine("輸入班級：" & s(0) & "、" & "學號：" & s(1) & "、" & "姓名：" & s(2) & "、" & "性別：" & s(3) & "、" & "報名項目：" & s(4))

        Dim groupTeam = 0
        Dim selfTeam = 0
        Dim insertTeam = -1
        For Each item In students
            If item.grade = s(0) And item.number = s(1) And item.name = s(2) And item.sex = s(3) Then
                Console.WriteLine(item.grade & " " & item.number & " " & item.name & " " & item.sex & " " & item.game)
                If item.game = "100公尺" Or item.game = "400公尺接力" Or item.game = "800公尺" Or item.game = "跳高" Then
                    selfTeam += 1
                End If
                If item.game = "大隊接力" Or item.game = "一顆心的距離" Or item.game = "天旋地轉" Or item.game = "滾大球袋鼠跳" Or item.game = "牽手同心" Then
                    groupTeam += 1
                End If
            End If
        Next

        If s(4) = "100公尺" Or s(4) = "400公尺接力" Or s(4) = "800公尺" Or s(4) = "跳高" Then
            insertTeam = 1
        ElseIf s(4) = "大隊接力" Or s(4) = "一顆心的距離" Or s(4) = "天旋地轉" Or s(4) = "滾大球袋鼠跳" Or s(4) = "牽手同心" Then
            insertTeam = 2
        End If

        If insertTeam = 1 Then
            If groupTeam > 0 Then
                Console.WriteLine("已報名團體賽不可再報名個人賽。")
                Exit Sub
            End If
            If selfTeam > 2 Then
                Console.WriteLine("選手可報名參加至多2項個人賽。")
                Exit Sub
            End If
            students.Add(New student(s(0), s(1), s(2), s(3), s(4)))
        ElseIf insertTeam = 2 Then
            If groupTeam > 2 Then
                Console.WriteLine("選手可報名參加至多 2 項團體賽 ")
                Exit Sub
            End If
            If selfTeam > 0 Then
                Console.WriteLine("已報名團體賽不可再報名個人賽。")
                Exit Sub
            End If
            students.Add(New student(s(0), s(1), s(2), s(3), s(4)))
        Else
            students.Add(New student(s(0), s(1), s(2), s(3), s(4)))
        End If
        Console.WriteLine("新增成功。")
    End Sub
    Public Sub showData()
        For Each item In students
            Console.WriteLine(item.grade & " " & item.number & " " & item.name & " " & item.sex & " " & item.game)
        Next
    End Sub
End Module
Class student
    Public grade As String
    Public number As String
    Public name As String
    Public sex As String
    Public game As String

    Public Sub New(ByVal g As String, ByVal n As String, ByVal na As String, ByVal s As String, ByVal ga As String)
        Me.grade = g
        Me.number = n
        Me.name = na
        Me.sex = s
        Me.game = ga
    End Sub

End Class
