Public Class Form1
    Dim tbox(1, 9) As TextBox
    Dim lab(9) As Label
    Dim smallK As Integer
    Dim l As New List(Of String)
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
                With tbox(i, j) '30 60
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
        Dim v As Integer = Val(TextBox1.Text)
        If v < 3 Or v > 10 Then
            MsgBox("輸入的矩陣數必須在3~10之間。", MsgBoxStyle.OkOnly, "提示")
            Exit Sub
        End If

        Dim M(v - 1) As Matrix

        For j = 0 To v - 1
            M(j).x = Val(tbox(0, j).Text)
            M(j).y = Val(tbox(1, j).Text)
        Next

        Dim index As Integer = 0
        Dim MDP(v - 1, v - 1)
        Dim KMDP(v - 1, v - 1)
        For i = 0 To v - 1
            For j = 0 To v - 1
                If i = j Then
                    MDP(i, j) = 0
                End If
            Next
        Next
        Dim p(v)

        p(0) = M(0).x
        p(1) = M(0).y
        'M(4)
        For i = 1 To v - 1
            If p(i) = M(i).x Then
                p(i + 1) = M(i).y
            End If
        Next

        Dim ii As Integer = 0
        Dim jj As Integer = 1
        For n = 1 To v - 1
            solve(MDP, p, ii, jj, KMDP)
            jj += 1
        Next
        Dim minum As Integer = MDP(0, v - 1)
        '0 - 4
        ' 0 - 1
        ' 2 - 4
        sequence(MDP, p, 0, v - 1, KMDP)

        Label2.Text = "矩陣相乘的次序為：<" & String.Join(" ", l) & ">"
        Label3.Text = "最少的乘法運算次數：" & minum
    End Sub
    Public Function sequence(ByVal MDP As Array, ByVal p As Array, ByVal i As Integer, ByVal j As Integer, ByVal KMDP As Array)
        If i = j Then
            l.Add("<m" & (i + 1) & ">")
            Exit Function
        End If
        If j - i = 1 Then
            l.Add("<m" & (i + 1) & " " & "m" & (j + 1) & ">")
        Else
            sequence(MDP, p, i, KMDP(i, j), KMDP)
            sequence(MDP, p, KMDP(i, j) + 1, j, KMDP)
        End If


    End Function
    Public Sub solve(ByVal MDP As Array, ByVal p As Array, ByVal i As Integer, ByVal j As Integer, ByVal KMDP As Array)
        ' i<=k<j
        For k = i To j - 1
            Dim value = MDP(i, k) + MDP(k + 1, j) + p(i) * p(k + 1) * p(j + 1)
            If value < MDP(i, j) Or MDP(i, j) = Nothing Then
                MDP(i, j) = value
                smallK = k
                KMDP(i, j) = smallK
            End If

            If j <> UBound(MDP) Then
                solve(MDP, p, i + 1, j + 1, KMDP)
            End If

        Next

    End Sub
End Class
Public Structure Matrix
    Public x As Integer
    Public y As Integer

End Structure
