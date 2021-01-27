Public Class Form1
    Dim grapth As New List(Of DG)
    Dim Matrix(7, 7) As Integer
    Dim min = 1000000000.0
    Dim sequnce As New ArrayList
    Dim lineValue As New ArrayList
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        grapth.Clear()
        sequnce.Clear()
        lineValue.Clear()

        ReDim Matrix(7, 7)
        min = 1000000000.0

        Dim fileName, a, b, c, write
        For i = 1 To 7
            For j = 1 To 7
                Matrix(i, j) = 1000000000.0
            Next
        Next
        OpenFileDialog1.ShowDialog()
        fileName = OpenFileDialog1.FileName
        Dim txt = My.Computer.FileSystem.ReadAllText(fileName)
        TextBox1.Text = txt
        Dim lines = Split(Trim(txt), vbCrLf)
        For i = 0 To UBound(lines)
            Dim Temp() = lines(i).Split(" ")
            Matrix(Val(Temp(0)), Val(Temp(1))) = Val(Temp(2))
            grapth.Add(New DG(Temp(0), Temp(1), Temp(2)))
        Next
        Dim n As New ArrayList
        n.Add(1)
        DFS(1, 7, n)
        calLineValue(sequnce)
        TextBox2.Text = "最低成本值總和：" & min & vbNewLine & "路徑次序：" & String.Join(" ", sequnce.ToArray) & vbNewLine & "連線數值："
        TextBox2.Text &= String.Join(" ", lineValue.ToArray)

    End Sub
    Function DFS(ByVal f As Integer, ByVal t As Integer, ByVal visited As ArrayList)

        Dim objs = grapth.FindAll(Function(x) x.f = f)

        If f = 7 Then
            Dim value = calDirectedGrapth(visited)
            If min > value Then
                min = value
                sequnce = visited.Clone
            End If
        End If

        For Each obj In objs
            If visited.Contains(obj.t) = False Then
                Dim temp As New ArrayList
                temp = visited.Clone
                temp.Add(obj.t)
                DFS(obj.t, t, temp)
            End If
        Next
    End Function
    Function calLineValue(ByVal temp As ArrayList)
        Dim sum As Integer = 0
        lineValue.Add(0)
        For i = 0 To temp.Count - 2
            Dim obj = grapth.Where(Function(item) item.f = temp(i) And item.t = temp(i + 1)).First()
            lineValue.Add(obj.w)
        Next
    End Function
    Function calDirectedGrapth(ByVal temp As ArrayList)
        Dim sum As Integer = 0
        For i = 0 To temp.Count - 2
            Dim obj = grapth.Where(Function(item) item.f = temp(i) And item.t = temp(i + 1)).First()
            sum += obj.w
        Next
        Return sum
    End Function
End Class
Class DG
    Public f As Integer
    Public t As Integer
    Public w As Integer
    Public Sub New(ByVal v1 As Integer, ByVal v2 As Integer, ByVal v3 As Integer)
        Me.f = v1
        Me.t = v2
        Me.w = v3
    End Sub
End Class

