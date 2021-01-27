Imports System.Threading
Public Class Form1
    Dim Bucket(9)
    Dim array As New List(Of String)
    Dim Bucket1(9)
    Dim Bucket2(9)
    Dim Bucket3(9)
    Dim slow As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ReDim Bucket(9)
        array.Clear()

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
        ReDim Bucket3(9)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sortArray()
        slow = True
        Timer1.Start()

    End Sub
    Private Sub sortArray()
        ReDim Bucket(9)
        ReDim Bucket1(9)
        ReDim Bucket2(9)
        ReDim Bucket3(9)
        array.Clear()

        Dim datas = TextBox1.Text.Split(",")
        For i = 0 To UBound(datas)
            array.Add(datas(i))
        Next
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
        Bucket3 = array.ToArray.Clone
        Debug.Print(123)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.Clear(Color.White)
        For x = 0 To 9
            g.DrawEllipse(Pens.Black, x * 50, 20, 50, 20)
            g.DrawString(x, New Font("標楷體", 12), Brushes.Red, New Point(x * 50 + 25, 20))
            Dim str = ""
            If IsNothing(Bucket1(x)) = False Then
                str = Bucket1(x).ToString
            End If

            Dim Temp() = str.Split({","}, StringSplitOptions.RemoveEmptyEntries)

            For y = 0 To UBound(Temp)
                g.DrawRectangle(Pens.Black, x * 50, 50 + y * 20, 50, 20)
                g.DrawString(Temp(y), New Font("標楷體", 12), Brushes.Red, New Point(x * 50, 50 + y * 20))
            Next

        Next
        If slow = True Then
            Thread.Sleep(2000)
        Else
            Thread.Sleep(500)
        End If
        g.Clear(Color.White)
        For x = 0 To 9
            g.DrawEllipse(Pens.Black, x * 50, 20, 50, 20)
            g.DrawString(x, New Font("標楷體", 12), Brushes.Red, New Point(x * 50 + 25, 20))
            Dim str = ""
            If IsNothing(Bucket2(x)) = False Then
                str = Bucket2(x).ToString
            End If

            Dim Temp() = str.Split({","}, StringSplitOptions.RemoveEmptyEntries)

            For y = 0 To UBound(Temp)
                g.DrawRectangle(Pens.Black, x * 50, 50 + y * 20, 50, 20)
                g.DrawString(Temp(y), New Font("標楷體", 12), Brushes.Red, New Point(x * 50, 50 + y * 20))
            Next
        Next
        If slow = True Then
            Thread.Sleep(2000)
        Else
            Thread.Sleep(500)
        End If
        g.Clear(Color.White)
        For x = 0 To 9
            g.DrawEllipse(Pens.Black, x * 50, 20, 50, 20)
            g.DrawString(x, New Font("標楷體", 12), Brushes.Red, New Point(x * 50 + 25, 20))
            Dim str = ""
            If IsNothing(Bucket3(x)) = False Then
                str = Bucket3(x).ToString
            End If

            Dim Temp() = str.Split({","}, StringSplitOptions.RemoveEmptyEntries)

            For y = 0 To UBound(Temp)
                g.DrawRectangle(Pens.Black, x * 50, 50 + y * 20, 50, 20)
                g.DrawString(Temp(y), New Font("標楷體", 12), Brushes.Red, New Point(x * 50, 50 + y * 20))
            Next
        Next

        TextBox2.Text = String.Join(",", array)

        Timer1.Stop()
        'Thread.Sleep(3000)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sortArray()
        slow = False
        Timer1.Start()
    End Sub
End Class
