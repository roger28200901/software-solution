<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.檔案FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.開啟彩色影像檔ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.結束離開ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.功能要求ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.彩色影像轉灰階影像ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.劃出灰階影像直方圖ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.求最小灰階和最大灰階ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.求出現最多之灰階和比機率ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.檔案FileToolStripMenuItem, Me.功能要求ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1328, 27)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '檔案FileToolStripMenuItem
        '
        Me.檔案FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.開啟彩色影像檔ToolStripMenuItem, Me.結束離開ExitToolStripMenuItem})
        Me.檔案FileToolStripMenuItem.Name = "檔案FileToolStripMenuItem"
        Me.檔案FileToolStripMenuItem.Size = New System.Drawing.Size(85, 23)
        Me.檔案FileToolStripMenuItem.Text = "檔案(File)"
        '
        '開啟彩色影像檔ToolStripMenuItem
        '
        Me.開啟彩色影像檔ToolStripMenuItem.Name = "開啟彩色影像檔ToolStripMenuItem"
        Me.開啟彩色影像檔ToolStripMenuItem.Size = New System.Drawing.Size(322, 24)
        Me.開啟彩色影像檔ToolStripMenuItem.Text = "開啟彩色影像檔(OpenCoolorImage)"
        '
        '結束離開ExitToolStripMenuItem
        '
        Me.結束離開ExitToolStripMenuItem.Name = "結束離開ExitToolStripMenuItem"
        Me.結束離開ExitToolStripMenuItem.Size = New System.Drawing.Size(322, 24)
        Me.結束離開ExitToolStripMenuItem.Text = "結束離開(Exit)"
        '
        '功能要求ToolStripMenuItem
        '
        Me.功能要求ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.彩色影像轉灰階影像ToolStripMenuItem, Me.劃出灰階影像直方圖ToolStripMenuItem, Me.求最小灰階和最大灰階ToolStripMenuItem, Me.求出現最多之灰階和比機率ToolStripMenuItem})
        Me.功能要求ToolStripMenuItem.Name = "功能要求ToolStripMenuItem"
        Me.功能要求ToolStripMenuItem.Size = New System.Drawing.Size(81, 23)
        Me.功能要求ToolStripMenuItem.Text = "功能要求"
        '
        '彩色影像轉灰階影像ToolStripMenuItem
        '
        Me.彩色影像轉灰階影像ToolStripMenuItem.Name = "彩色影像轉灰階影像ToolStripMenuItem"
        Me.彩色影像轉灰階影像ToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
        Me.彩色影像轉灰階影像ToolStripMenuItem.Text = "彩色影像轉灰階影像"
        '
        '劃出灰階影像直方圖ToolStripMenuItem
        '
        Me.劃出灰階影像直方圖ToolStripMenuItem.Name = "劃出灰階影像直方圖ToolStripMenuItem"
        Me.劃出灰階影像直方圖ToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
        Me.劃出灰階影像直方圖ToolStripMenuItem.Text = "劃出灰階影像直方圖"
        '
        '求最小灰階和最大灰階ToolStripMenuItem
        '
        Me.求最小灰階和最大灰階ToolStripMenuItem.Name = "求最小灰階和最大灰階ToolStripMenuItem"
        Me.求最小灰階和最大灰階ToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
        Me.求最小灰階和最大灰階ToolStripMenuItem.Text = "求最小灰階和最大灰階"
        '
        '求出現最多之灰階和比機率ToolStripMenuItem
        '
        Me.求出現最多之灰階和比機率ToolStripMenuItem.Name = "求出現最多之灰階和比機率ToolStripMenuItem"
        Me.求出現最多之灰階和比機率ToolStripMenuItem.Size = New System.Drawing.Size(258, 24)
        Me.求出現最多之灰階和比機率ToolStripMenuItem.Text = "求出現最多之灰階和比機率"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 399)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "最小灰階(亮度)為:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 418)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(123, 25)
        Me.TextBox1.TabIndex = 2
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(219, 418)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(123, 25)
        Me.TextBox2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 399)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "最大灰階(亮度)為:"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(484, 418)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(123, 25)
        Me.TextBox3.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(459, 399)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "出現最多之灰階(亮度)為:"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(778, 418)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(123, 25)
        Me.TextBox4.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(753, 399)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "最多灰階(亮度)之機率為:"
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(727, 30)
        Me.Chart1.Name = "Chart1"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "機率"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(506, 350)
        Me.Chart1.TabIndex = 9
        Me.Chart1.Text = "Chart1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(15, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(350, 350)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(371, 30)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(350, 350)
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1328, 472)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 檔案FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 開啟彩色影像檔ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 結束離開ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 功能要求ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 彩色影像轉灰階影像ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 劃出灰階影像直方圖ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 求最小灰階和最大灰階ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 求出現最多之灰階和比機率ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog

End Class
