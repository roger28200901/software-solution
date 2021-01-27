Public Class Form1
    Dim ClassNet As New List(Of Byte)
    Dim o As New ArrayList({"A", "B", "C", "D", "E"})
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f1 As String
        If ComboBox1.Text = ComboBox1.Items(0) Then
            f1 = "input1.txt"
        ElseIf ComboBox1.Text = ComboBox1.Items(1) Then
            f1 = "input2.txt"
        Else
            f1 = "input3.txt"
        End If

        FileOpen(1, f1, OpenMode.Input)
        TextBox1.Text = ""

        ''

        Dim net As String
        Dim mask As String
        Dim netL As New List(Of Decimal)

        Dim s1 = ComboBox1.Text
        Dim s2 As String = ""
        For i = 1 To Val(ComboBox2.Text)
            s2 &= "1"
        Next
        s2 = s2.PadRight(32, "0")
        Dim n As Integer = 0
        For i = 1 To 3
            Dim ind As Integer = i * 8 + n
            s2 = s2.Insert(ind, ".")
            n += 1
        Next

        Dim ip2 = s2.Split(".")
        Dim ip1 = s1.Split(".")

        For q = 0 To 3
            ip2(q) = BTC(ip2(q))
        Next

        For q = 0 To 3
            netL.Add(ip1(q) And ip2(q))
        Next
        net = String.Join(".", netL)
        mask = String.Join(".", ip2)
        TextBox1.Text &= "Net:" & net & vbNewLine
        TextBox1.Text &= "Mask:" & mask & vbNewLine
        TextBox1.Text &= "--------------------------------------" & vbNewLine

        Do While Not EOF(1)
            Dim l = LineInput(1)
            Dim t = l.Split(",")
            Dim ips = t(1).Split(".")
            Dim op As String = t(0)
            Dim index = o.IndexOf(op)

            Dim v = ClassNet(index)
            If ips(0) <> v Then
                ips(0) = v
            End If

            For i = 0 To UBound(ips)
                If i <> UBound(ips) Then
                    TextBox1.Text &= ips(i) & "."
                Else
                    TextBox1.Text &= ips(i)
                End If
            Next
            TextBox1.Text &= "," & t(2) & vbNewLine
        Loop
        FileClose(1)

    End Sub
    Private Sub resetNet()
        For i = 0 To 4
            Dim n As Integer = i
            Dim s As String = ""
            Do Until n = 0
                s &= "1"
                n -= 1
            Loop
            s = s.PadRight(8, "0")
            Dim b As Byte = Convert.ToByte(BTC(s))
            ClassNet.Add(b)
        Next
    End Sub
    Private Function BTC(ByVal s As String)
        Dim sum As Decimal
        Dim count = 0
        For i = s.Length To 1 Step -1
            Dim c = Mid(s, i, 1)
            sum += c * 2 ^ count
            count += 1
        Next
        Return sum
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetNet()
    End Sub
End Class
