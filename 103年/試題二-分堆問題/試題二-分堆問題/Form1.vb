Public Class Form1
    Dim w(), h()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        OpenFileDialog1.Filter = "txt (*.txt)|*.txt"
        Dim filename = OpenFileDialog1.FileName

        FileOpen(1, filename, OpenMode.Input)
        Dim datasLength = LineInput(1).Split(" ")(0)
        ReDim w(datasLength) : ReDim h(datasLength)
        Dim i As Integer
        For i = 0 To datasLength - 1
            Dim temp = LineInput(1).Split(" ")
            w(i) = temp(0)
            h(i) = temp(1)
            ListBox1.Items.Add(i & "   " & w(i) & "   " & h(i))
        Next


        FileClose(1)
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim n = ListBox1.Items.Count
        Dim nh(n)
        Dim nw(n)
        Dim s0, s1, s2 As New Stack
        For i = 0 To n - 1
            nh(i) = Val((h(i) - Sum(i, n, h)) / (sigma(i, n, h) / n))
            nw(i) = Val((w(i) - Sum(i, n, w)) / (sigma(i, n, w) / n))

            If i = 0 Then
                s0.Push(nh(i) & "," & nw(i))
            ElseIf i = 1 Then
                s1.Push(nh(i) & "," & nw(i))
            ElseIf i = 2 Then
                s2.Push(nh(i) & "," & nw(i))
            Else
                Randomize()
                Dim r As Integer = Rnd() * 2
                If r = 0 Then
                    s0.Push(nh(i) & "," & nw(i))
                ElseIf r = 1 Then
                    s1.Push(nh(i) & "," & nw(i))
                ElseIf r = 2 Then
                    s2.Push(nh(i) & "," & nw(i))
                End If
            End If
        Next
    End Sub

    Function Sum(ByVal i As Integer, ByVal n As Integer, ByVal t As Array)
        Dim value

        For i = i To n - 1
            value += Val(t(i))
        Next
        Return value
    End Function
    Function sigma(ByVal i As Integer, ByVal n As Integer, ByVal t As Array)
        Dim value

        For i = i To n - 1
            value += (Val(t(i)) - Sum(i, n, t)) ^ 2
        Next

        Return value

    End Function
End Class
