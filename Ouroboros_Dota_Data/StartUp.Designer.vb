<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StartUp
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartUp))
        Me.bHERO = New System.Windows.Forms.Button()
        Me.bITEM = New System.Windows.Forms.Button()
        Me.bUPD = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bQUIZ = New System.Windows.Forms.Button()
        Me.bGAME = New System.Windows.Forms.Button()
        Me.bUNIT = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sslV = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bHERO
        '
        Me.bHERO.Location = New System.Drawing.Point(20, 100)
        Me.bHERO.Margin = New System.Windows.Forms.Padding(4)
        Me.bHERO.Name = "bHERO"
        Me.bHERO.Size = New System.Drawing.Size(160, 50)
        Me.bHERO.TabIndex = 0
        Me.bHERO.Text = "英雄资料"
        Me.bHERO.UseVisualStyleBackColor = True
        '
        'bITEM
        '
        Me.bITEM.Location = New System.Drawing.Point(199, 100)
        Me.bITEM.Margin = New System.Windows.Forms.Padding(4)
        Me.bITEM.Name = "bITEM"
        Me.bITEM.Size = New System.Drawing.Size(160, 50)
        Me.bITEM.TabIndex = 1
        Me.bITEM.Text = "物品资料"
        Me.bITEM.UseVisualStyleBackColor = True
        '
        'bUPD
        '
        Me.bUPD.Location = New System.Drawing.Point(20, 225)
        Me.bUPD.Margin = New System.Windows.Forms.Padding(4)
        Me.bUPD.Name = "bUPD"
        Me.bUPD.Size = New System.Drawing.Size(160, 50)
        Me.bUPD.TabIndex = 2
        Me.bUPD.Text = "数据更新"
        Me.bUPD.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(379, 75)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "本程序处于测试阶段" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "如果遇到bug请及时报告" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "作者qq：1160671498"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bQUIZ
        '
        Me.bQUIZ.Location = New System.Drawing.Point(199, 162)
        Me.bQUIZ.Margin = New System.Windows.Forms.Padding(4)
        Me.bQUIZ.Name = "bQUIZ"
        Me.bQUIZ.Size = New System.Drawing.Size(160, 50)
        Me.bQUIZ.TabIndex = 1
        Me.bQUIZ.Text = "物品测试"
        Me.bQUIZ.UseVisualStyleBackColor = True
        '
        'bGAME
        '
        Me.bGAME.Location = New System.Drawing.Point(199, 225)
        Me.bGAME.Margin = New System.Windows.Forms.Padding(4)
        Me.bGAME.Name = "bGAME"
        Me.bGAME.Size = New System.Drawing.Size(160, 50)
        Me.bGAME.TabIndex = 1
        Me.bGAME.Text = "卡尔练习器"
        Me.bGAME.UseVisualStyleBackColor = True
        '
        'bUNIT
        '
        Me.bUNIT.Enabled = False
        Me.bUNIT.Location = New System.Drawing.Point(20, 162)
        Me.bUNIT.Margin = New System.Windows.Forms.Padding(4)
        Me.bUNIT.Name = "bUNIT"
        Me.bUNIT.Size = New System.Drawing.Size(160, 50)
        Me.bUNIT.TabIndex = 0
        Me.bUNIT.Text = "单位资料"
        Me.bUNIT.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslV})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 353)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(379, 26)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sslV
        '
        Me.sslV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.sslV.Name = "sslV"
        Me.sslV.Size = New System.Drawing.Size(39, 20)
        Me.sslV.Text = "版本"
        Me.sslV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StartUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 379)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bUPD)
        Me.Controls.Add(Me.bQUIZ)
        Me.Controls.Add(Me.bGAME)
        Me.Controls.Add(Me.bITEM)
        Me.Controls.Add(Me.bUNIT)
        Me.Controls.Add(Me.bHERO)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "StartUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dota2资料集"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bHERO As Button
    Friend WithEvents bITEM As Button
    Friend WithEvents bUPD As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bQUIZ As Button
    Friend WithEvents bGAME As Button
    Friend WithEvents bUNIT As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sslV As ToolStripStatusLabel
End Class
