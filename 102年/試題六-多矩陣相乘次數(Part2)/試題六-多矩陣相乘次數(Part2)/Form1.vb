Public Class Form1
    Dim tbox(1, 9) As TextBox
    Dim lab(9) As Label
    Dim opptunity As New Queue
    Dim opptunity2 As New Queue
    Dim steps As New Queue
    Dim costs As New Queue
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim v As Integer = Val(TextBox1.Text)
        If v >= 3 And v <= 10 Then
            For i = 0 To 1
                For j = 0 To v - 1
                    tbox(i, j).Visible = True
                Next
            Next
            For j = 0 To v - 1
                lab(j).Visible = True
            Next
        Else
            For i = 0 To 1
                For j = 0 To 9
                    tbox(i, j).Visible = False
                Next
            Next

            For j = 0 To 9
                lab(j).Visible = False
            Next
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 1
            For j = 0 To 9
                tbox(i, j) = New TextBox
                With tbox(i, j)
                    .Location = New Point(30 + 135 + i * 60, 30 + j * 30)
                    .Size = New Size(50, 22)
                    .Visible = False
                    Panel1.Controls.Add(tbox(i, j))
                End With
            Next
        Next

        For j = 0 To 9
            lab(j) = New Label
            With lab(j)
                .Location = New Point(30, 30 + j * 30)
                .Text = "m" & (j + 1) & "的矩陣大小："
                .Visible = False
                Panel1.Controls.Add(lab(j))
            End With
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        opptunity.Clear()
        steps.Clear()
        costs.Clear()

        Dim v As Integer = Val(TextBox1.Text)
        If v < 3 Or v > 10 Then
            MsgBox("輸入的矩陣數必須在3~10之間。", MsgBoxStyle.OkOnly, "提示")
            Exit Sub
        End If

        Dim M As New List(Of Matrix)

        For i = 0 To v - 1
            Dim ma As New Matrix
            ma.x = CInt(tbox(0, i).Text)
            ma.y = CInt(tbox(1, i).Text)
            ma.str = "m" & (i + 1)
            M.Add(ma)
        Next
        Dim s As String
        For i = 0 To M.Count - 1
            s &= i
        Next
        change(s, opptunity)

        For i = 0 To opptunity.Count - 1
            solve(M, opptunity, i)
        Next

        Dim minValue = 1000000000.0
        Dim index As Integer
        For i = 0 To costs.Count - 1
            If costs(i) < minValue Then
                minValue = costs(i)
                index = i
            End If
        Next

        Dim stepsString As String
        For Each item In steps(index)
            stepsString &= item
        Next

        Label2.Text = "矩陣相乘的次序為：<" & stepsString & ">"
        Label3.Text = "最少的乘法運算次數：" & minValue
    End Sub
    Function change(ByVal a As String, ByVal o As Queue, Optional ByVal b As String = "")
        If Len(a) = Len(b) Then
            o.Enqueue(b)
        Else
            For i = 1 To Len(a)
                Dim word As Boolean = False
                For j = 1 To Len(b)
                    If Mid(b, j, 1) = Mid(a, i, 1) Then
                        word = True
                    End If
                Next
                If word = False Then
                    Call change(a, o, b & Mid(a, i, 1))
                End If
            Next
        End If
    End Function
    Public Sub solve(ByVal M As List(Of Matrix), ByVal opp As Queue, ByVal index As Integer)
        Dim s As New Queue
        Dim q As New Queue
        s.Clear()
        q.Clear()

        Dim mm = opp(index)

        Dim z = Val(mm(0))

        Dim p As Ps
        For i = 1 To M.Count - 1
            If p.x = Nothing Then
                If M(z).x = M(Val(mm(i))).y Then
                    p.x = M(z).y
                    p.y = M(Val(mm(i))).x
                    p.sum = M(z).x
                    s.Enqueue("<" & M(z).str & " " & M(Val(mm(i))).str & ">")

                ElseIf M(z).y = M(Val(mm(i))).x Then
                    p.x = M(z).x
                    p.y = M(Val(mm(i))).y
                    p.sum = M(z).y
                    s.Enqueue("<" & M(z).str & " " & M(Val(mm(i))).str & ">")

                Else
                    Exit Sub
                End If
            Else
                If p.x = M(Val(mm(i))).y Then
                    p.sum = p.x
                    p.x = p.y
                    p.y = M(Val(mm(i))).x
                    s.Enqueue("<" & M(Val(mm(i))).str & ">")
                ElseIf p.y = M(Val(mm(i))).x Then
                    p.sum = p.y
                    p.x = p.x
                    p.y = M(Val(mm(i))).y
                    s.Enqueue("<" & M(Val(mm(i))).str & ">")
                Else
                    Exit Sub
                End If
            End If
            q.Enqueue(p.x * p.y * p.sum)
        Next
        Dim sum As Integer
        For Each item In q
            sum += item
        Next
        steps.Enqueue(s)
        costs.Enqueue(sum)
    End Sub
    Public Structure Ps
        Public x As Integer
        Public y As Integer
        Public sum As Integer
    End Structure
    Public Structure Matrix
        Public x As Integer
        Public y As Integer
        Public str As String
    End Structure
End Class
