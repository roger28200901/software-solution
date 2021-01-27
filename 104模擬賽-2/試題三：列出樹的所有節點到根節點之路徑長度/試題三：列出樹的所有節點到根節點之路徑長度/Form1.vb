Imports System.Threading
Public Class Form1
    Dim Bucket(9)
    Dim array As New List(Of String)
    Dim Bucket1(9)
    Dim Bucket2(9)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ReDim Bucket(9)
        Dim array As New List(Of String)
        For i = 1 To 10
            Dim r As Integer = Rnd() * 99 + 1
            array.Add(r.ToString.PadLeft(2, "0"))
        Next

        TextBox1.Text = String.Join(",", array)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        ReDim Bucket(9)
        ReDim Bucket1(9)
        ReDim Bucket2(9)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sortArray()
        Timer1.Start()

    End Sub
    Private Sub sortArray()
        array.AddRange({"73", "22", "93", "43", "55", "14", "28", "65", "39", "81"})
        For i = 0 To array.Count - 1
            Dim str = array(i)
            Dim c = Val(Mid(str, str.Length, 1))
            If Bucket(c) <> Nothing Then
                Bucket(c) = Bucket(c) & "," & str
            Else
                Bucket(c) = str
            End If
        Next
        array.Clear()
        For i = 0 To Bucket.Count - 1
            If Bucket(i) <> Nothing Then
                Dim str = Bucket(i)
                Dim Temp() = Split(Trim(str), ",")
                For j = 0 To UBound(Temp)
                    array.Add(Temp(j))
                Next
            End If
        Next
        Bucket1 = Bucket.Clone
        ReDim Bucket(10)
        For i = 0 To array.Count - 1
            Dim str = array(i)
            Dim c = Val(Mid(str, 1, 1))
            If Bucket(c) <> Nothing Then
                Bucket(c) = Bucket(c) & "," & str
            Else
                Bucket(c) = str
            End If
        Next
        Bucket2 = Bucket.Clone
        array.Clear()
        For i = 0 To Bucket.Count - 1
            If Bucket(i) <> Nothing Then
                Dim str = Bucket(i)
                Dim Temp() = Split(Trim(str), ",")
                For j = 0 To UBound(Temp)
                    array.Add(Temp(j))
                Next
            End If
        Next

        Debug.Print(123)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        'For x = 0 To 9
        '    g.DrawEllipse(Pens.Black, x * 50, 20, 50, 20)
        '    g.DrawString(x, New Font("標楷體", 12), Brushes.Red, New Point(x * 50 + 25, 20))
        '    Dim str = ""
        '    If IsNothing(Bucket1(x)) = False Then
        '        str = Bucket1(x).ToString
        '    End If

        '    Dim Temp() = str.Split({","}, StringSplitOptions.RemoveEmptyEntries)

        '    For y = 0 To UBound(Temp)
        '        g.DrawRectangle(Pens.Black, x * 50, 50 + y * 20, 50, 20)
        '        g.DrawString(Temp(y), New Font("標楷體", 12), Brushes.Red, New Point(x * 50, 50 + y * 20))
        '    Next

        'Next

        'g.Clear(Color.White)
        'For x = 0 To 9
        '    g.DrawEllipse(Pens.Black, x * 50, 20, 50, 20)
        '    g.DrawString(x, New Font("標楷體", 12), Brushes.Red, New Point(x * 50 + 25, 20))
        '    Dim str = ""
        '    If IsNothing(Bucket2(x)) = False Then
        '        str = Bucket2(x).ToString
        '    End If

        '    Dim Temp() = str.Split({","}, StringSplitOptions.RemoveEmptyEntries)

        '    For y = 0 To UBound(Temp)
        '        g.DrawRectangle(Pens.Black, x * 50, 50 + y * 20, 50, 20)
        '        g.DrawString(Temp(y), New Font("標楷體", 12), Brushes.Red, New Point(x * 50, 50 + y * 20))
        '    Next

        'Next

        Timer1.Stop()
        'Thread.Sleep(3000)

    End Sub
End Class
