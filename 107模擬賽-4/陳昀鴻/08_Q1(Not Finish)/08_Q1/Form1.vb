Public Class Form1
    Dim map(20, 30) As String
    Dim cat As Point '0
    Dim mouse1 As Point '1
    Dim mouse2 As Point '2
    Dim mouse3 As Point '3
    Dim wayMap(3, 3) ' 有向圖
    Dim cz As New List(Of Integer)
    Dim visit As New List(Of Point)
    Dim lowCount As Integer = 1000000000.0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim text = TextBox1.Text
        Dim lines = Split(Trim(text), vbCrLf)
        For x = 0 To UBound(lines)
            Dim length = lines(x).Length
            For y = 0 To length - 1
                map(x, y) = lines(x)(y)
                If map(x, y) = "C" Then
                    cat = New Point(x, y)
                ElseIf map(x, y) = "X" Then
                    mouse1 = New Point(x, y)
                ElseIf map(x, y) = "Y" Then
                    mouse2 = New Point(x, y)
                ElseIf map(x, y) = "Z" Then
                    mouse3 = New Point(x, y)
                End If
            Next
        Next
        For i = 0 To 20
            For j = 0 To 30
                If map(i, j) = "" Then
                    map(i, j) = 1
                End If
            Next
        Next
        'ctox
        findPath(cat.X, cat.Y, mouse1, New List(Of Point), 0, cat.X, cat.Y)
        Dim ctox = lowCount - 1
        'ctoy
        findPath(cat.X, cat.Y, mouse2, New List(Of Point), 0, cat.X, cat.Y)
        Dim ctoy = lowCount - 1
        'ctoz
        findPath(cat.X, cat.Y, mouse3, New List(Of Point), 0, cat.X, cat.Y)
        Dim ctoz = lowCount - 1
    End Sub
    Private Function findPath(ByVal fx As Integer, ByVal fy As Integer, ByVal mouse As Point, ByVal v As List(Of Point), ByVal count As Integer, ByVal x As Integer, ByVal y As Integer)
        map(mouse.X, mouse.Y) = 0
        Dim tempV As New List(Of Point)
        For i = 0 To v.Count - 1
            tempV.Add(v(i))
        Next
        If x = mouse.X And y = mouse.Y Then
            If lowCount > count Then
                lowCount = count
            End If
            Exit Function
        End If
        '下走
        If x < 20 Then
            If map(x + 1, y) = "0" And v.Contains(New Point(x + 1, y)) = False Then
                tempV.Add(New Point(x + 1, y))
                findPath(fx, fy, mouse, tempV, count + 1, x + 1, y)
            End If
        End If
        '左走
        If y > 0 Then
            If map(x, y - 1) = "0" And v.Contains(New Point(x, y - 1)) = False Then
                tempV.Add(New Point(x, y - 1))
                findPath(fx, fy, mouse, tempV, count + 1, x, y - 1)
            End If
        End If
        
        '右走
        If y < 30 Then
            If map(x, y + 1) = "0" And v.Contains(New Point(x, y + 1)) = False Then
                tempV.Add(New Point(x, y + 1))
                findPath(fx, fy, mouse, tempV, count + 1, x, y + 1)
            End If
        End If
        '上走
        If x > 0 Then
            If map(x - 1, y) = "0" And v.Contains(New Point(x - 1, y)) = False Then
                tempV.Add(New Point(x - 1, y))
                findPath(fx, fy, mouse, tempV, count + 1, x - 1, y)
            End If
        End If
       
        

    End Function
End Class
