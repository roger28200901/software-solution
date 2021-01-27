Public Class Form1
    Dim a As New Queue({9, 12, 33, 47, 53, 67, 78, 92})
    Dim b As New Queue({48, 81})
    Dim c As New Queue({13, 41, 62})
    Dim d As New Queue({1, 3, 45, 79})
    Dim ee As New Queue({14, 16, 24, 44, 46, 55, 57, 64, 74, 82, 87, 98})
    Dim f As New Queue({10, 31})
    Dim g As New Queue({6, 25})
    Dim h As New Queue({23, 39, 50, 56, 65, 68})
    Dim i As New Queue({32, 70, 73, 83, 88, 93})
    Dim j As New Queue({15})
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim t1 = TextBox1.Text
        Dim ans As New Queue
        For n = 0 To Len(t1) - 1
            Dim cc = t1(n)
            Dim encode As String = ""
            Select Case cc
                Case "a"
                    encode = a.Dequeue
                Case "b"
                    encode = b.Dequeue
                Case "c"
                    encode = c.Dequeue
                Case "d"
                    encode = d.Dequeue
                Case "e"
                    encode = ee.Dequeue
                Case "f"
                    encode = f.Dequeue
                Case "g"
                    encode = g.Dequeue
                Case "h"
                    encode = h.Dequeue
                Case "i"
                    encode = i.Dequeue
                Case "j"
                    encode = j.Dequeue
            End Select
            Call check()

            ans.Enqueue(encode.ToString.PadLeft(2, "0"))
        Next

        TextBox2.Text = String.Join(" ", ans.ToArray)
    End Sub
    Private Sub check()
        If a.Count = 0 Then
            Dim aa As New Queue({9, 12, 33, 47, 53, 67, 78, 92})
            a = aa.Clone

        End If
        If b.Count = 0 Then
            Dim bb As New Queue({48, 81})
            b = bb.Clone

        End If
        If c.Count = 0 Then
            Dim cc As New Queue({13, 41, 62})
            c = cc.Clone

        End If
        If d.Count = 0 Then
            Dim dd As New Queue({1, 3, 45, 79})
            d = dd.Clone

        End If
        If ee.Count = 0 Then
            Dim eee As New Queue({14, 16, 24, 44, 46, 55, 57, 64, 74, 82, 87, 98})
            ee = eee.Clone
        End If
        If f.Count = 0 Then
            Dim ff As New Queue({10, 31})
            f = ff.Clone

        End If
        If g.Count = 0 Then
            Dim gg As New Queue({6, 25})
            g = gg.Clone

        End If
        If h.Count = 0 Then
            Dim hh As New Queue({23, 39, 50, 56, 65, 68})
            h = hh.Clone

        End If
        If i.Count = 0 Then
            Dim ii As New Queue({32, 70, 73, 83, 88, 93})
            i = ii.Clone

        End If
        If j.Count = 0 Then
            Dim jj As New Queue({15})
            j = jj.Clone

        End If
    End Sub
End Class
