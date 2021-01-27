Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim X = TextBox2.Text.Split(",")
        Dim Y = TextBox1.Text.Split(",")
        '0開始
        TextBox3.Text = ""
        Dim D(X.Count, Y.Count)

        For i = 1 To X.Count - 1
            For j = 1 To Y.Count - 1
                Dim distance As Integer
                If i = 1 And j = 1 Then
                    distance = Math.Abs(Val(X(i - 1)) - Val(Y(j - 1)))
                ElseIf i = 1 And j > 1 Then
                    distance = Math.Abs(Val(X(i - 1)) - Val(Y(j - 1))) + D(1, j - 1)
                ElseIf i > 1 And j = 1 Then
                    distance = Math.Abs(Val(X(i - 1)) - Val(Y(j - 1))) + D(i - 1, 1)
                ElseIf i > 1 And j > 1 Then
                    Dim l As New List(Of Integer)
                    l.Add(D(i - 1, j))
                    l.Add(D(i - 1, j - 1))
                    l.Add(D(i, j - 1))
                    distance = Math.Abs(Val(X(i - 1)) - Val(Y(j - 1))) + l.Min
                End If
                D(i, j) = distance.ToString
            Next
        Next

        D(0, 0) = 0
        For j = 1 To Y.Count
            D(0, j) = Y(j - 1)
        Next
        For i = 1 To X.Count
            D(i, 0) = X(i - 1)
        Next

        For i = 0 To X.Count - 1
            Dim str As New Queue
            For j = 0 To Y.Count - 1
                Dim n = D(i, j).ToString.Length
                TextBox3.Text &= D(i, j).ToString.PadRight(8 - n, " ")
            Next

            TextBox3.Text &= vbNewLine
        Next

    End Sub
End Class
