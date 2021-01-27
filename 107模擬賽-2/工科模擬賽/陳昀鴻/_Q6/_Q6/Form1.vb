Public Class Form1
    Dim map(4, 4) As String
    Dim AnsQ As New Queue
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AnsQ.clear
        ReDim map(4, 4)
        Dim insertL As New List(Of Point)
        For y = 1 To 4
            For x = 1 To 4
                Dim k As Integer = (y - 1) * 4 + x
                map(x, y) = Controls("TextBox" & k).Text
                If map(x, y) = "1" Then
                    insertL.Add(New Point(x, y))
                End If
            Next
        Next

        For y = 1 To 4
            For x = 1 To 4
                DFS(x, y, New Stack)
            Next
        Next
        'sort by count
        Dim A = AnsQ.ToArray().ToList()
        A.Sort(Function(item, item2) item.count.compareTo(item2.count))
        A.Reverse()


        Dim max = A(0).Count
        Dim collection = A.Where(Function(item) item.count <> 1)
        Dim ansStr As New List(Of List(Of String))
        For Each S As Stack In collection
            Dim ansL As New List(Of Point)
            For Each p As Point In S
                ansL.Add(New Point(p))
            Next

            Dim sx As New List(Of Integer)
            Dim sy As New List(Of Integer)

            For Each p As Point In ansL
                If p.X = 1 Then
                    If sx.Contains(0) = False Then
                        sx.Add(0)
                    End If
                ElseIf p.X = 2 Then
                    If sx.Contains(1) = False Then
                        sx.Add(1)
                    End If
                ElseIf p.X = 3 Then
                    If sx.Contains(3) = False Then
                        sx.Add(3)
                    End If
                ElseIf p.X = 4 Then
                    If sx.Contains(2) = False Then
                        sx.Add(2)
                    End If
                End If
                If p.Y = 1 Then
                    If sy.Contains(0) = False Then
                        sy.Add(0)
                    End If
                ElseIf p.Y = 2 Then
                    If sy.Contains(1) = False Then
                        sy.Add(1)
                    End If
                ElseIf p.Y = 3 Then
                    If sy.Contains(3) = False Then
                        sy.Add(3)
                    End If
                ElseIf p.Y = 4 Then
                    If sy.Contains(2) = False Then
                        sy.Add(2)
                    End If
                End If

            Next

            Dim ssx = sx.Aggregate(Function(o1, o2) o1 Xor o2)
            Dim ssy = sy.Aggregate(Function(o1, o2) o1 Xor o2)
            Dim product As New List(Of String)
            If ssx = 1 Then
                If ansL.Where(Function(item) item.X = 1 Or item.X = 2).Count <> 0 Then
                    product.Add("|A")
                    If sx.Count = 1 Then
                        product.Add("B")
                    End If
                Else
                    product.Add("A")
                    If sx.Count = 1 Then
                        product.Add("|B")
                    End If
                End If

            Else
                If ansL.Where(Function(item) item.X = 2 Or item.X = 3).Count <> 0 Then
                    If sx.Count = 1 Then
                        product.Add("|A")
                    End If
                    product.Add("B")
                Else
                    If sx.Count = 1 Then
                        product.Add("A")
                    End If
                    product.Add("|B")
                End If
            End If
            If ssy = 1 Then
                If ansL.Where(Function(item) item.Y = 1 Or item.Y = 2).Count <> 0 Then
                    product.Add("|C")
                    If sy.Count = 1 Then
                        product.Add("D")
                    End If
                Else
                    product.Add("C")
                    If sy.Count = 1 Then
                        product.Add("|D")
                    End If
                End If
            Else
                If ansL.Where(Function(item) item.Y = 2 Or item.Y = 3).Count <> 0 Then
                    If sy.Count = 1 Then
                        product.Add("|C")
                    End If
                    product.Add("D")
                Else
                    If sy.Count = 1 Then
                        product.Add("C")
                    End If
                    product.Add("|D")
                End If
            End If
            ansStr.Add(product)
        Next
        Label1.Text = ""

        For i = ansStr.Count - 1 To 0 Step -2
            Dim cc2 = 0
            For j = 0 To ansStr(i).Count - 1
                If j <> ansStr(i).Count - 1 Then Label1.Text &= ansStr(i)(j) & "*" Else Label1.Text &= ansStr(i)(j)
            Next
            If i - 2 > 0 Then Label1.Text &= "+"
        Next

    End Sub
    Function DFS(ByVal x As Integer, ByVal y As Integer, ByVal visit As Stack)

        visit.Push(New Point(x, y))
        If map(x, y) = 0 Then
            Return False
        End If


        '跨界

        If x - 1 = 0 And visit.Contains(New Point(4, y)) = False Then
            Dim temp = visit.Clone
            DFS(4, y, temp)
        End If
        If x + 1 > 4 And visit.Contains(New Point(0, y)) = False Then
            Dim temp = visit.Clone
            DFS(0, y, temp)
        End If
        If y - 1 = 0 And visit.Contains(New Point(x, 4)) = False Then
            Dim temp = visit.Clone
            DFS(x, 4, temp)
        End If
        If y + 1 > 4 And visit.Contains(New Point(x, 0)) = False Then
            Dim temp = visit.Clone
            DFS(x, 0, temp)
        End If
        If x > 1 And visit.Contains(New Point(x - 1, y)) = False Then
            Dim temp = visit.Clone
            DFS(x - 1, y, temp)
        End If
        If x < 4 And visit.Contains(New Point(x + 1, y)) = False Then
            Dim temp = visit.Clone
            DFS(x + 1, y, temp)
        End If
        If y > 1 And visit.Contains(New Point(x, y - 1)) = False Then
            Dim temp = visit.Clone
            DFS(x, y - 1, temp)
        End If
        If y < 4 And visit.Contains(New Point(x, y + 1)) = False Then
            Dim temp = visit.Clone
            DFS(x, y + 1, temp)
        End If

        Dim v = Math.Log(visit.Count, 2)

        If v = Fix(v) = True And checkIsCircle(visit) = True And checkHasThisAns(visit) = False Then
            Dim insert As Boolean = True
            For Each S As Stack In AnsQ
                Dim count = 0
                Dim count2 = 0
                For Each p As Point In S
                    If visit.Contains(New Point(p.Y, p.X)) = True Then
                        count += 1
                    End If
                    If visit.Contains(New Point(p.X, p.Y)) = True Then
                        count2 += 1
                    End If
                Next
                If count = visit.Count Then
                    insert = False
                End If
                If count2 = visit.Count Then
                    insert = False
                End If
            Next
            If insert = True Then AnsQ.Enqueue(visit)
            Return visit
        Else
            Return False
        End If


    End Function
    Function checkIsCircle(ByVal visit As Stack)
        Dim temp = visit.Clone
        Dim l As New List(Of Point)
        For i = visit.Count - 1 To 0 Step -1
            For j = visit.Count - 1 To i Step -1
                If i = j Then Continue For
                If checkIsNextToMe(New Point(visit(i).x, visit(i).y), New Point(visit(j).x, visit(j).y)) = False Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Function checkIsNextToMe(ByVal p1 As Point, ByVal p2 As Point)
        If p1.X - p2.X = 3 Or p1.Y - p2.Y = 3 Then
            Return True
        End If
        Dim v = Math.Sqrt((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2)
        If v = 1 Or v = Math.Sqrt(2) Then
            Return True
        Else
            Return False
        End If
    End Function
    Function checkHasThisAns(ByVal visit As Stack)
        If AnsQ.Count = 0 Then Return False
        For Each stack As Stack In AnsQ
            For Each item In stack
                If visit.Contains(item) = False Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function
End Class
