Imports System.Data
Imports System.Windows
Module Module1
    Dim input As New List(Of String())
    Dim output As New List(Of Integer)
    Sub Main()
        Console.WriteLine("輸入：")

        Do Until input.Count = 4
            Dim str = Console.ReadLine
            Dim spl = str.Split(" ")
            input.Add(spl)
        Loop
        For Each item In input
            Dim test = CreateObject("ScriptControl")
            test.language = "VBScript"
            Dim S = test.eval(item(0).ToString & "*" & item(1).ToString & "/" & item(2).ToString)
            output.Add(S)
        Next

        Console.WriteLine("輸出：")
        For Each item In output
            Console.WriteLine(item)
        Next

        Console.ReadKey()

    End Sub

End Module
