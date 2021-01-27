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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.square1 = New System.Windows.Forms.TextBox()
        Me.square2 = New System.Windows.Forms.TextBox()
        Me.square3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.Label1.Location = New System.Drawing.Point(171, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "迷宮搜尋系統"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(41, 324)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 33)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Initialize 9x9 maze"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(41, 363)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(152, 34)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Attach Obstrcles into maze"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(41, 403)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(152, 36)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Attach S and T into maze"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(41, 445)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(152, 35)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Find shortest path"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(477, 445)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Exit"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.Label2.Location = New System.Drawing.Point(392, 312)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 22)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Obstacles(20~50)"
        '
        'square1
        '
        Me.square1.Location = New System.Drawing.Point(504, 100)
        Me.square1.Multiline = True
        Me.square1.Name = "square1"
        Me.square1.Size = New System.Drawing.Size(30, 30)
        Me.square1.TabIndex = 8
        '
        'square2
        '
        Me.square2.BackColor = System.Drawing.Color.Black
        Me.square2.Location = New System.Drawing.Point(504, 136)
        Me.square2.Multiline = True
        Me.square2.Name = "square2"
        Me.square2.Size = New System.Drawing.Size(30, 30)
        Me.square2.TabIndex = 9
        '
        'square3
        '
        Me.square3.BackColor = System.Drawing.Color.Gray
        Me.square3.Location = New System.Drawing.Point(504, 172)
        Me.square3.Multiline = True
        Me.square3.Name = "square3"
        Me.square3.Size = New System.Drawing.Size(30, 30)
        Me.square3.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.Label3.Location = New System.Drawing.Point(540, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 22)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "通路網格"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.Label4.Location = New System.Drawing.Point(540, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 22)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "障礙網格"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.Label5.Location = New System.Drawing.Point(540, 172)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 22)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "最短網格路徑"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("PMingLiU", 16.0!)
        Me.Label6.Location = New System.Drawing.Point(378, 443)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 22)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Answer"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 510)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.square3)
        Me.Controls.Add(Me.square2)
        Me.Controls.Add(Me.square1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents square1 As TextBox
    Friend WithEvents square2 As TextBox
    Friend WithEvents square3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
