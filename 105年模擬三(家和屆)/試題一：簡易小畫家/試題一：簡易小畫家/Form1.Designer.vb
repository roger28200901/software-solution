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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.檔案ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.載入圖檔LToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.建立新畫布NToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.儲存圖片SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.畫筆ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.顏色ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.大小ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.圖形樣式ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.直線ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.矩形ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.橢圓ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.檔案ToolStripMenuItem, Me.畫筆ToolStripMenuItem, Me.圖形樣式ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(646, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '檔案ToolStripMenuItem
        '
        Me.檔案ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.載入圖檔LToolStripMenuItem, Me.建立新畫布NToolStripMenuItem, Me.儲存圖片SToolStripMenuItem})
        Me.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem"
        Me.檔案ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.檔案ToolStripMenuItem.Text = "檔案"
        '
        '載入圖檔LToolStripMenuItem
        '
        Me.載入圖檔LToolStripMenuItem.Name = "載入圖檔LToolStripMenuItem"
        Me.載入圖檔LToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.載入圖檔LToolStripMenuItem.Text = "載入圖檔(L)"
        '
        '建立新畫布NToolStripMenuItem
        '
        Me.建立新畫布NToolStripMenuItem.Name = "建立新畫布NToolStripMenuItem"
        Me.建立新畫布NToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.建立新畫布NToolStripMenuItem.Text = "建立新畫布(N)"
        '
        '儲存圖片SToolStripMenuItem
        '
        Me.儲存圖片SToolStripMenuItem.Name = "儲存圖片SToolStripMenuItem"
        Me.儲存圖片SToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.儲存圖片SToolStripMenuItem.Text = "儲存圖片(S)"
        '
        '畫筆ToolStripMenuItem
        '
        Me.畫筆ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.顏色ToolStripMenuItem, Me.大小ToolStripMenuItem})
        Me.畫筆ToolStripMenuItem.Name = "畫筆ToolStripMenuItem"
        Me.畫筆ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.畫筆ToolStripMenuItem.Text = "畫筆"
        '
        '顏色ToolStripMenuItem
        '
        Me.顏色ToolStripMenuItem.Name = "顏色ToolStripMenuItem"
        Me.顏色ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.顏色ToolStripMenuItem.Text = "顏色"
        '
        '大小ToolStripMenuItem
        '
        Me.大小ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.大小ToolStripMenuItem.Name = "大小ToolStripMenuItem"
        Me.大小ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.大小ToolStripMenuItem.Text = "大小"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem2.Text = "2"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem3.Text = "4"
        '
        '圖形樣式ToolStripMenuItem
        '
        Me.圖形樣式ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.直線ToolStripMenuItem, Me.矩形ToolStripMenuItem, Me.橢圓ToolStripMenuItem})
        Me.圖形樣式ToolStripMenuItem.Name = "圖形樣式ToolStripMenuItem"
        Me.圖形樣式ToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.圖形樣式ToolStripMenuItem.Text = "圖形樣式"
        '
        '直線ToolStripMenuItem
        '
        Me.直線ToolStripMenuItem.Name = "直線ToolStripMenuItem"
        Me.直線ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.直線ToolStripMenuItem.Text = "直線"
        '
        '矩形ToolStripMenuItem
        '
        Me.矩形ToolStripMenuItem.Name = "矩形ToolStripMenuItem"
        Me.矩形ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.矩形ToolStripMenuItem.Text = "矩形"
        '
        '橢圓ToolStripMenuItem
        '
        Me.橢圓ToolStripMenuItem.Name = "橢圓ToolStripMenuItem"
        Me.橢圓ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.橢圓ToolStripMenuItem.Text = "橢圓"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(622, 375)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 414)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 檔案ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 載入圖檔LToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 建立新畫布NToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 儲存圖片SToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 畫筆ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 顏色ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 大小ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents 圖形樣式ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 直線ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 矩形ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 橢圓ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
End Class
