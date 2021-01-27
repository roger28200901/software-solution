Public Class Form1
    Dim pic(5) As PictureBox
    Dim map(6, 6) As PictureBox
    Dim modeMap(6, 6) As electronic
    Dim mode = -1
    Dim visit As New ArrayList
    Dim vsD As New ArrayList
    Dim Ac As Boolean = False
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For i = 1 To 6
            For j = 1 To 6
                Dim k As Integer = (i - 1) * 6 + j
                Dim pc As New PictureBox
                With pc
                    .Location = New Point(10 + (j - 1) * 50, 10 + (i - 1) * 50)
                    .Size = New Size(50, 50)
                    .Visible = True
                    .Name = "Pc" & k
                    .BorderStyle = BorderStyle.FixedSingle
                End With
                Me.Controls.Add(pc)
                Dim bmp As New Bitmap(pc.Width, pc.Height)
                pc.Image = bmp
                Dim g As Graphics = Graphics.FromImage(bmp)
                g.Clear(Color.White)
                map(i, j) = pc
                modeMap(i, j) = New electronic(5)
                AddHandler map(i, j).Click, AddressOf map_click
            Next
        Next

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 0 To 5
            pic(i) = Me.Controls("PictureBox" & i + 1)
            pic(i).Image = drawImage(pic(i))
            AddHandler(pic(i).Click), AddressOf pic_click
        Next
    End Sub
    Private Sub map_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim obj As PictureBox = sender
        obj.Image = pic(mode - 1).Image
        Dim x, y As Integer
        For i = 1 To 6
            For j = 1 To 6
                If map(i, j).Name = obj.Name Then
                    x = i
                    y = j
                    Exit For
                End If
            Next
        Next

        Select Case mode
            Case 1
                modeMap(x, y) = New electronic(1)
                modeMap(x, y).mode1()
            Case 2
                modeMap(x, y) = New electronic(2)
                modeMap(x, y).mode2()
            Case 3
                modeMap(x, y) = New electronic(3)
                modeMap(x, y).mode3()
            Case 4
                modeMap(x, y) = New electronic(4)
                modeMap(x, y).mode4()
            Case 5
                modeMap(x, y) = New electronic(5)

            Case 6
                modeMap(x, y) = New electronic(6)
                modeMap(x, y).mode6()
        End Select

        checkLight()

    End Sub
    Private Sub checkLight()

        'reset
        For x = 1 To 6
            For y = 1 To 6
                map(x, y).Image = pic(modeMap(x, y).mode - 1).Image
                modeMap(x, y).reset()
            Next
        Next


        For xx = 1 To 6
            For yy = 1 To 6
                If modeMap(xx, yy).mode = 3 Then
                    visit.Clear()
                    vsD.Clear()
                    Ac = False
                    findAC(xx, yy, New ArrayList, New ArrayList)
                    If Ac = True Then
                        For i = 0 To visit.Count - 1
                            Dim p As Point = visit(i)
                            Dim dr As String = vsD(i)
                            Select Case dr
                                Case "u"
                                    modeMap(p.X, p.Y).upLight = True
                                Case "d"
                                    modeMap(p.X, p.Y).downLight = True
                                Case "l"
                                    modeMap(p.X, p.Y).leftLight = True
                                Case "r"
                                    modeMap(p.X, p.Y).rightLight = True
                            End Select
                        Next
                        'set
                        For x = 1 To 6
                            For y = 1 To 6
                                If modeMap(x, y).AC = True And modeMap(x, y).upLight = True And modeMap(x, y).downLight = True _
                                    And modeMap(x, y).leftLight = True And modeMap(x, y).right = True Then
                                    map(x, y).Image = PictureBox1.Image
                                ElseIf (modeMap(x, y).LED = True) And (modeMap(x, y).upLight = True Or modeMap(x, y).downLight = True Or
                                    modeMap(x, y).leftLight = True Or modeMap(x, y).right = True) = True Then
                                    Dim bmp As New Bitmap(map(x, y).Width, map(x, y).Height)
                                    Dim g As Graphics = Graphics.FromImage(bmp)
                                    g.Clear(Color.White)
                                    g.DrawString("LED", New Font("標楷體", 20), Brushes.Red, 1, 10)
                                    map(x, y).Image = bmp
                                ElseIf modeMap(x, y).line = True Then
                                    Dim bmp = New Bitmap(map(x, y).Width, map(x, y).Height)
                                    Dim g As Graphics = Graphics.FromImage(bmp)
                                    g.Clear(Color.White)

                                    If modeMap(x, y).up = True Then
                                        g.FillRectangle(Brushes.Black, 20, 0, 10, 30)
                                    End If
                                    If modeMap(x, y).down = True Then
                                        g.FillRectangle(Brushes.Black, 20, 20, 10, 30)
                                    End If
                                    If modeMap(x, y).right = True Then
                                        g.FillRectangle(Brushes.Black, 20, 20, 30, 10)
                                    End If
                                    If modeMap(x, y).left = True Then
                                        g.FillRectangle(Brushes.Black, 0, 20, 30, 10)
                                    End If



                                    If modeMap(x, y).up = True And modeMap(x, y).upLight = True Then
                                        g.FillRectangle(Brushes.Red, 20, 0, 10, 30)
                                    End If
                                    If modeMap(x, y).down = True And modeMap(x, y).downLight = True Then
                                        g.FillRectangle(Brushes.Red, 20, 20, 10, 30)
                                    End If
                                    If modeMap(x, y).right = True And modeMap(x, y).rightLight = True Then
                                        g.FillRectangle(Brushes.Red, 20, 20, 30, 10)
                                    End If
                                    If modeMap(x, y).left = True And modeMap(x, y).leftLight = True Then
                                        g.FillRectangle(Brushes.Red, 0, 20, 30, 10)
                                    End If
                                    map(x, y).Image = bmp
                                End If
                            Next
                        Next


                    End If
                End If
            Next
        Next




    End Sub
    Private Function findAC(ByVal x As Integer, ByVal y As Integer, ByVal v As ArrayList, ByVal v2 As ArrayList)


        If modeMap(x, y).mode = 1 Then
            visit = v
            vsD = v2
            Ac = True
        End If
        '上面
        If x > 1 Then
            If modeMap(x - 1, y).down = True And v.Contains(New Point(x - 1, y)) = False Then
                Dim tempV As ArrayList : Dim tempV2 As ArrayList
                tempV = v.Clone()
                tempV2 = v2.Clone()
                tempV.Add(New Point(x, y))
                tempV2.Add("u")
                tempV.Add(New Point(x - 1, y))
                tempV2.Add("d")
                findAC(x - 1, y, tempV, tempV2)
            End If
        End If
        '下面
        If x < 6 Then
            If modeMap(x + 1, y).up = True And v.Contains(New Point(x + 1, y)) = False Then
                Dim tempV As ArrayList : Dim tempV2 As ArrayList
                tempV = v.Clone()
                tempV2 = v2.Clone()

                tempV.Add(New Point(x, y))
                tempV2.Add("d")
                tempV.Add(New Point(x + 1, y))
                tempV2.Add("u")
                findAC(x + 1, y, tempV, tempV2)
            End If
        End If
        '右邊
        If y < 6 Then
            If modeMap(x, y + 1).left = True And v.Contains(New Point(x, y + 1)) = False Then
                Dim tempV As ArrayList : Dim tempV2 As ArrayList
                tempV = v.Clone()
                tempV2 = v2.Clone()

                tempV.Add(New Point(x, y))
                tempV2.Add("r")
                tempV.Add(New Point(x, y + 1))
                tempV2.Add("l")
                findAC(x, y + 1, tempV, tempV2)
            End If
        End If
        '左邊
        If y > 1 Then
            If modeMap(x, y - 1).right = True And v.Contains(New Point(x, y - 1)) = False Then
                Dim tempV As ArrayList : Dim tempV2 As ArrayList
                tempV = v.Clone()
                tempV2 = v2.Clone()

                tempV.Add(New Point(x, y))
                tempV2.Add("l")
                tempV.Add(New Point(x, y - 1))
                tempV2.Add("r")
                findAC(x, y - 1, tempV, tempV2)
            End If
        End If

    End Function
    Private Sub pic_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim obj As PictureBox = sender
        If obj.Name = "PictureBox1" Then
            mode = 1
        ElseIf obj.Name = "PictureBox2" Then
            mode = 2
        ElseIf obj.Name = "PictureBox3" Then
            mode = 3
        ElseIf obj.Name = "PictureBox4" Then
            mode = 4
        ElseIf obj.Name = "PictureBox5" Then
            mode = 5
        ElseIf obj.Name = "PictureBox6" Then
            mode = 6
        End If
    End Sub
    Private Function drawImage(ByVal pc As PictureBox)
        Dim bmp As New Bitmap(pc.Width, pc.Height)

        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.White)
        If pc.Name = "PictureBox1" Then
            g.DrawString("AC", New Font("標楷體", 20), Brushes.Black, 5, 10)
        ElseIf pc.Name = "PictureBox2" Then
            g.FillRectangle(Brushes.Black, 0, 20, 50, 10)
        ElseIf pc.Name = "PictureBox3" Then
            g.DrawString("LED", New Font("標楷體", 20), Brushes.Black, 1, 10)
        ElseIf pc.Name = "PictureBox4" Then
            g.FillRectangle(Brushes.Black, 20, 0, 10, 50)
        ElseIf pc.Name = "PictureBox5" Then

        ElseIf pc.Name = "PictureBox6" Then
            g.FillRectangle(Brushes.Black, 0, 20, 50, 10)
            g.FillRectangle(Brushes.Black, 20, 0, 10, 50)
        End If
        Return bmp
    End Function
End Class
Class electronic

    Public up As Boolean = False
    Public down As Boolean = False
    Public left As Boolean = False
    Public right As Boolean = False

    Public upLight As Boolean = False
    Public downLight As Boolean = False
    Public leftLight As Boolean = False
    Public rightLight As Boolean = False

    Public AC As Boolean = False
    Public LED As Boolean = False
    Public mode As Integer = Nothing
    Public line As Boolean = Nothing
    Public Sub New(ByVal m As Integer)
        Me.mode = m
    End Sub
    Public Sub mode1()
        Me.AC = True
        Me.left = True
        Me.right = True
        Me.up = True
        Me.down = True

    End Sub
    Public Sub mode2()
        Me.left = True
        Me.right = True
        Me.line = True
    End Sub
    Public Sub mode3()
        Me.LED = True

    End Sub
    Public Sub mode4()
        Me.up = True
        Me.down = True
        Me.line = True
    End Sub
    Public Sub mode6()
        Me.up = True
        Me.left = True
        Me.right = True
        Me.down = True
        Me.line = True
    End Sub
    Public Sub reset()
        Me.upLight = False
        Me.downLight = False
        Me.leftLight = False
        Me.rightLight = False
    End Sub
End Class
