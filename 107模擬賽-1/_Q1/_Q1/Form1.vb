Imports System.StringSplitOptions
Public Class Form1
    Dim maps(10, 10)
    Dim cmaps(10, 10)
    Dim bases(5)
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim s = Trim(map.Text).Split(" ")


        For i = 1 To 10
            For j = 1 To 10
                maps(i, j) = Mid(s(i - 1), j, 1)
            Next
        Next

        cmaps = maps.Clone()

        For i = 1 To 10
            For j = 1 To 10
                If cmaps(i, j) <> "1" And cmaps(i, j) <> "0" Then
                    cmaps(i, j) = 2
                End If
            Next
        Next

        Dim s2 = Trim(base.Text).Split(" ")

        For i = 1 To 5
            bases(i) = s2(i - 1)
        Next

        For x = 1 To 10
            '十次
            Dim delta = 0
            Dim sy = 0
            For i = 1 To 5
                Dim max = bases(i).length
                delta = 0
                Dim check = 0
                Dim ts = ""
                Do Until max + delta > 10
                    Dim t As String = ""
                    For p = 1 + delta To max + delta
                        t &= maps(x, p).ToString
                    Next

                    check = 0
                    For j = 1 To t.Length
                        If Mid(bases(i), j, 1) = Mid(t, j, 1) Or Mid(t, j, 1) = "0" Then
                            check += 1
                        End If
                    Next
                    If check = max Then
                        sy = delta + 1
                        ts = bases(i)
                        Exit Do
                    End If
                    delta += 1
                Loop

                If check = max Then
                    '22
                    Dim k = (x - 1) * 10 + sy
                    'x = 3
                    'y 2 -7
                    Dim tt = sy - (sy - 1)
                    For yy = sy To check + sy - 1
                        If cmaps(x, yy) <> 2 Then
                            cmaps(x, yy) = 3
                        End If
                        maps(x, yy) = Mid(ts, tt, 1)
                        tt += 1
                    Next
                End If


            Next

        Next

        For x = 1 To 10
            '十次
            Dim delta = 0
            Dim sy = 0
            For i = 1 To 5
                Dim max = bases(i).length
                delta = 0
                Dim check = 0
                Dim ts = ""
                Do Until max + delta > 10
                    Dim t As String = ""
                    For p = 1 + delta To max + delta
                        t &= maps(p, x).ToString
                    Next

                    check = 0
                    For j = 1 To t.Length
                        If Mid(bases(i), j, 1) = Mid(t, j, 1) Or Mid(t, j, 1) = "0" Then
                            check += 1
                        End If
                    Next
                    If check = max Then
                        sy = delta + 1
                        ts = bases(i)
                        Exit Do
                    End If
                    delta += 1
                Loop

                If check = max Then
                    '22
                    Dim k = (x - 1) * 10 + sy
                    'x = 3
                    'y 2 -7
                    Dim tt = sy - (sy - 1)
                    For yy = sy To check + sy - 1
                        If cmaps(yy, x) <> 2 Then
                            cmaps(yy, x) = 3
                        End If

                        maps(yy, x) = Mid(ts, tt, 1)
                        tt += 1
                    Next
                End If


            Next

        Next


        initMap()




    End Sub

    Sub initMap()
        For i = 1 To 10
            For j = 1 To 10
                If maps(i, j) = "1" Then
                    Dim k = (i - 1) * 10 + j
                    Controls("TextBox" & k).BackColor = Color.Black
                ElseIf maps(i, j) <> "0" Then
                    Dim k = (i - 1) * 10 + j
                    Controls("TextBox" & k).Text = maps(i, j)
                End If
                If cmaps(i, j) = "3" Then
                    Dim k = (i - 1) * 10 + j
                    Controls("TextBox" & k).ForeColor = Color.Red
                End If

            Next
        Next

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
