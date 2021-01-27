Public Class Form1
    Dim cq As New List(Of Char)
    Dim nq As New List(Of Integer) ' 出現次數陣列
    Dim small1 As New List(Of Integer)
    Dim small2 As New List(Of Integer)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Randomize()
        cq.Clear() : nq.Clear()
        small1.Clear() : small2.Clear()

        For i = 1 To 4
            Dim r As Integer = Rnd() * 26 + 97
            Dim c As Char = Chr(r)
            cq.Add(c)
        Next
        For j = 1 To 4
            Dim r As Integer = Rnd() * 1000
            nq.Add(r)
        Next

        For i = 0 To cq.Count - 1
            Controls("TextBox" & (i + 1)).Text = cq(i)
            Controls("TextBox" & (i + 5)).Text = nq(i)
        Next

    End Sub
    Function findMin(ByVal nnq As List(Of Integer), ByVal small1 As List(Of Integer), ByVal small2 As List(Of Integer))
        Dim m As Integer = 1000000000.0

        Dim temp As New List(Of Integer)
        For Each item In small1
            temp.Add(nq(item))
        Next
        For Each item In small2
            temp.Add(nq(item))
        Next

        For Each item In nnq
            If temp.Contains(item) Then
                Continue For
            Else
                If item < m Then
                    m = item
                End If
            End If
        Next
        Return m
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim originalEncode As Integer
        For Each item In nq
            originalEncode += item
        Next
        originalEncode *= 2
        Dim sms As New Stack
        Dim nnq As New List(Of Integer)

        For Each item In nq
            nnq.Add(item)
        Next



        Do Until nnq.Count = 7
            Dim sum As Integer = 0

            Do Until sms.Count = 2
                Dim min As Integer = nnq.Min '20
                Dim index As Integer = nnq.IndexOf(min)

                Do While small1.Contains(index) Or small2.Contains(index)
                    min = findMin(nnq, small1, small2)
                    index = nnq.IndexOf(min)
                Loop

                sms.Push(min)

                If sms.Count = 1 Then
                    small1.Add(index)
                Else
                    small2.Add(index)
                End If

            Loop


            If sms.Count = 2 Then
                Do Until sms.Count = 0
                    sum += sms.Pop()
                Loop
            End If
            nq.Add(sum)
            nnq.Add(sum)
        Loop
        Dim encodeBits(nq.Count - 1) As Integer
        Dim power = 0
        Dim kk As Integer = 0
        For i = nq.Count - 1 To 0 Step -1
            If encodeBits(i).ToString = "" Or encodeBits(i) = Nothing Then
                encodeBits(i) = power
            Else
                Continue For
            End If

            Dim vIndex1 = small1(small1.Count - 1 - kk)
            Dim vIndex2 = small2(small2.Count - 1 - kk)
            kk += 1
            encodeBits(vIndex1) = power + kk
            encodeBits(vIndex2) = power + kk
        Next
        Dim afterEncode As Integer
        Dim n As Integer = 0
        For Each item In encodeBits
            afterEncode += nq(n) * item
            n += 1
            If n = 4 Then
                Exit For
            End If
        Next
        Dim compression As Double
        compression = originalEncode / afterEncode

        TextBox9.Text = originalEncode
        TextBox10.Text = afterEncode
        TextBox13.Text = Format(compression, "0.0000")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 3
            Dim n1 As Integer = Controls("TextBox" & (i + 5)).Text
            Dim c1 As Char = Controls("TextBox" & (i + 1)).Text
            cq.Add(c1)
            nq.Add(n1)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        end
    End Sub
End Class
