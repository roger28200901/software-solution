Public Class Form1
    Dim choose As Char = "A"
    Dim A As customer
    Dim B As customer
    Private Sub GroupBox1_MouseHover(sender As Object, e As EventArgs) Handles GroupBox1.MouseHover
        GroupBox1.Cursor = Cursors.Hand
    End Sub

    Private Sub GroupBox2_MouseHover(sender As Object, e As EventArgs) Handles GroupBox2.MouseHover
        GroupBox2.Cursor = Cursors.Hand
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        A = New customer(0, 0, 0, 0, Label1)
        B = New customer(0, 0, 0, 0, Label2)
    End Sub
    Private Sub GroupBox1_Click(sender As Object, e As EventArgs) Handles GroupBox1.Click
        choose = "A"
    End Sub

    Private Sub GroupBox2_Click(sender As Object, e As EventArgs) Handles GroupBox2.Click
        choose = "B"
    End Sub

    Private Sub 番茄雞肉義大利麵ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 番茄雞肉義大利麵ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal1 = 75
            Label3.Text = "番茄雞肉義大利麵"
        Else
            B.meal1 = 75
            Label7.Text = "番茄雞肉義大利麵"
        End If
        A.sum()
        B.sum()

    End Sub

    Private Sub 羅勒海鮮義大利麵ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 羅勒海鮮義大利麵ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal1 = 70
            Label3.Text = "羅勒海鮮義大利麵"
        Else
            B.meal1 = 70
            Label7.Text = "羅勒海鮮義大利麵"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 奶油燻雞義大利麵ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 奶油燻雞義大利麵ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal1 = 65
            Label3.Text = "奶油燻雞義大利麵"
        Else
            B.meal1 = 65
            Label7.Text = "奶油燻雞義大利麵"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 白酒蛤蠣義大利麵ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 白酒蛤蠣義大利麵ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal1 = 80
            Label3.Text = "白酒蛤蠣義大利麵"
        Else
            B.meal1 = 80
            Label7.Text = "白酒蛤蠣義大利麵"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 水果優格沙拉ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 水果優格沙拉ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal2 = 45
            Label4.Text = "水果優格沙拉"
        Else
            B.meal2 = 45
            Label8.Text = "水果優格沙拉"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 生春捲沙拉ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 生春捲沙拉ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal2 = 40
            Label4.Text = "生春捲沙拉"
        Else
            B.meal2 = 40
            Label8.Text = "生春捲沙拉"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 筊白筍青蔬沙拉ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 筊白筍青蔬沙拉ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal2 = 50
            Label4.Text = "筊白筍青蔬沙拉"
        Else
            B.meal2 = 50
            Label8.Text = "筊白筍青蔬沙拉"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 牛番茄沙拉ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 牛番茄沙拉ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal2 = 40
            Label4.Text = "牛番茄沙拉"
        Else
            B.meal2 = 40
            Label8.Text = "牛番茄沙拉"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 大蒜蛤蠣湯ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 大蒜蛤蠣湯ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal3 = 45
            Label5.Text = "大蒜蛤蠣湯"
        Else
            B.meal3 = 45
            Label9.Text = "大蒜蛤蠣湯"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 番茄海鮮湯ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 番茄海鮮湯ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal3 = 40
            Label5.Text = "番茄海鮮湯"
        Else
            B.meal3 = 40
            Label9.Text = "番茄海鮮湯"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 吟釀味噌湯ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 吟釀味噌湯ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal3 = 40
            Label5.Text = "吟釀味噌湯"
        Else
            B.meal3 = 40
            Label9.Text = "吟釀味噌湯"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 元氣牛肉湯ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 元氣牛肉湯ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal3 = 50
            Label5.Text = "元氣牛肉湯"
        Else
            B.meal3 = 50
            Label9.Text = "元氣牛肉湯"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 原燒冰淇淋ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 原燒冰淇淋ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal4 = 40
            Label6.Text = "原燒冰淇淋"
        Else
            B.meal4 = 40
            Label10.Text = "原燒冰淇淋"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 桂花紅豆湯ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 桂花紅豆湯ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal4 = 45
            Label6.Text = "桂花紅豆湯"
        Else
            B.meal4 = 45
            Label10.Text = "桂花紅豆湯"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 白玉紫米ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 白玉紫米ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal4 = 40
            Label6.Text = "白玉紫米"
        Else
            B.meal4 = 40
            Label10.Text = "白玉紫米"
        End If
        A.sum()
        B.sum()
    End Sub

    Private Sub 黑糖奶酪ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 黑糖奶酪ToolStripMenuItem.Click
        If choose = "A" Then
            A.meal4 = 35
            Label6.Text = "黑糖奶酪"
        Else
            B.meal4 = 35
            Label10.Text = "黑糖奶酪"
        End If
        A.sum()
        B.sum()
    End Sub

End Class
Class customer
    Public meal1 As Integer
    Public meal2 As Integer
    Public meal3 As Integer
    Public meal4 As Integer
    Public la As Label
    Public Sub New(ByVal m As Integer, ByVal n As Integer, ByVal c As Integer, ByVal d As Integer, ByVal l As Label)
        Me.meal1 = m
        Me.meal2 = n
        Me.meal3 = c
        Me.meal4 = d
        Me.la = l
    End Sub
    Public Function sum()
        Me.la.Text = meal1+meal2+meal3+meal4
    End Function
End Class
