Public Class Form1
    Dim path As New Queue
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n = Val(TextBox1.Text)
        MsgBox(Process(n))

    End Sub
    Private Function Process(ByVal n As Integer)
        Dim m As Integer = 1

        While func1(n, m) <> 13
            m += 1
        End While
        Dim temp
        For Each value In path
            temp &= value & ","
        Next

        Return m & " " & temp
    End Function
    Function func1(ByVal n As Integer, ByVal m As Integer) As Integer
        Dim i As Integer = 0
        Dim arr, log As New ArrayList
        '1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17
        '
        'm = 5
        'i = 0+5-1=4
        '4 mod 17
        '
        For j As Integer = 1 To n
            arr.Add(j)
        Next
        While arr.Count > 0
            log.Add(arr(i))
            arr.RemoveAt(i)
            If arr.Count > 0 Then i = (i + m - 1) Mod arr.Count
        End While
        For Each v In log
            'path.Enqueue()
        Next
        Return log(n - 1)
    End Function

    Private Function Process1(ByVal n As Integer)
        Dim m As Integer = 1

        While func2(n, m) <> 13
            m += 1
           
        End While
        Dim temp
        
    End Function
    Function func2(ByVal n As Integer, ByVal m As Integer) As Integer
        Dim arr(n) As Boolean
        Dim log As New Queue

        For i = 1 To n
            arr(i) = False
        Next

        Dim index As Integer = 1
        Dim counter As Boolean = False

        Do Until counter = True
            If arr(index) = False Then
                arr(index) = True
                index = (index + m + 1) Mod arr.Count
                Continue Do
            Else
                index += (m - 1)
            End If
        Loop

        End Function

End Class
