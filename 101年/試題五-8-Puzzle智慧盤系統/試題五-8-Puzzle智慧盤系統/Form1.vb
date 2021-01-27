Public Class Form1
    Dim tb(9) As TextBox
    Dim tg(9) As TextBox
    Dim ans As String
    Dim hasAns As Boolean = False
    Dim current_step As Integer = 0
    '結束遊戲
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
    End Sub
    'Random
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rs As New Stack
        Do Until rs.Count = 9
            Dim r As Integer = Rnd() * 9
            If rs.Contains(r) = False Then
                rs.Push(r)
            End If
        Loop
        Dim r1(8) As Integer
        For i = 0 To rs.Count - 1
            r1(i) = rs(i)
        Next


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        GameStart()

    End Sub
    Private Sub GameStart()
        Dim initState(2, 2) As Integer
        Dim goalState(2, 2) As Integer


    End Sub
    Private Sub findAns()
        Dim start = New game(Input(tb), "")
        Dim goal = New game(input(tg), "")
        Dim b(999999999) As Boolean
        Dim q As New Queue(Of game)
        Dim c As Integer = 0
        For i = 1 To UBound(start.n)
            For j = 1 To UBound(start.n)
                If start.n(i) < start.n(j) Then
                    c += 1
                End If
            Next
        Next

        If c Mod 2 = 1 Then
            Label4.Text = "無解"
            Return
        End If

        q.Enqueue(start)

    End Sub
    Private Function input(ByVal textboxs As TextBox())
        Dim n(9) As Integer
        For i = 1 To UBound(textboxs)
            If textboxs(i).Text.Replace(" ", "") = "" Then
                n(i) = 0
            Else
                n(i) = Val(textboxs(i).Text)
            End If
        Next
        Return n
    End Function
    Private Sub readTextBox()
        For i = 1 To 9
            tb(i) = Controls("TextBox" & i)
        Next
        For i = 1 To 9
            tg(i) = Controls("TextBox" & (i + 10))
        Next
    End Sub
    Private Sub gogo()
        Label5.Text = "計算中"
        Application.DoEvents()
        Call readTextBox()

        Call findAns()

        If ans = "" Then
            Label5.Text = "不用解答"
        ElseIf hasAns Then
            Label5.Text = "解答中"
        Else
            Label5.Text = "無解"
        End If

        current_step = 0
        Timer1.Start()

    End Sub
    '快速
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Interval = 100
        gogo()

    End Sub
    '慢速
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Timer1.Interval = 1000
        gogo()

    End Sub
End Class
'遊戲類別
Class game
    Public steps As String = "" '步驟
    Public n As Integer() '盤
    Sub New(ByVal n As Integer(), ByVal steps As String)
        Me.n = n.Clone()
        Me.steps = steps

    End Sub
End Class
