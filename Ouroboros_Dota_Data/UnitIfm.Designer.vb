<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnitIfm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lU = New System.Windows.Forms.ListView()
        Me.ckC = New System.Windows.Forms.CheckBox()
        Me.ckB = New System.Windows.Forms.CheckBox()
        Me.ckN = New System.Windows.Forms.CheckBox()
        Me.ckO = New System.Windows.Forms.CheckBox()
        Me.tF = New System.Windows.Forms.TextBox()
        Me.bF = New System.Windows.Forms.Button()
        Me.lUN = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lU
        '
        Me.lU.Location = New System.Drawing.Point(12, 39)
        Me.lU.Name = "lU"
        Me.lU.Size = New System.Drawing.Size(164, 330)
        Me.lU.TabIndex = 0
        Me.lU.UseCompatibleStateImageBehavior = False
        Me.lU.View = System.Windows.Forms.View.List
        '
        'ckC
        '
        Me.ckC.AutoSize = True
        Me.ckC.Location = New System.Drawing.Point(12, 375)
        Me.ckC.Name = "ckC"
        Me.ckC.Size = New System.Drawing.Size(48, 16)
        Me.ckC.TabIndex = 1
        Me.ckC.Text = "小兵"
        Me.ckC.UseVisualStyleBackColor = True
        '
        'ckB
        '
        Me.ckB.AutoSize = True
        Me.ckB.Location = New System.Drawing.Point(12, 397)
        Me.ckB.Name = "ckB"
        Me.ckB.Size = New System.Drawing.Size(48, 16)
        Me.ckB.TabIndex = 1
        Me.ckB.Text = "建筑"
        Me.ckB.UseVisualStyleBackColor = True
        '
        'ckN
        '
        Me.ckN.AutoSize = True
        Me.ckN.Location = New System.Drawing.Point(98, 375)
        Me.ckN.Name = "ckN"
        Me.ckN.Size = New System.Drawing.Size(48, 16)
        Me.ckN.TabIndex = 1
        Me.ckN.Text = "野怪"
        Me.ckN.UseVisualStyleBackColor = True
        '
        'ckO
        '
        Me.ckO.AutoSize = True
        Me.ckO.Location = New System.Drawing.Point(98, 397)
        Me.ckO.Name = "ckO"
        Me.ckO.Size = New System.Drawing.Size(48, 16)
        Me.ckO.TabIndex = 1
        Me.ckO.Text = "其他"
        Me.ckO.UseVisualStyleBackColor = True
        '
        'tF
        '
        Me.tF.Location = New System.Drawing.Point(12, 12)
        Me.tF.Name = "tF"
        Me.tF.Size = New System.Drawing.Size(103, 21)
        Me.tF.TabIndex = 2
        '
        'bF
        '
        Me.bF.Location = New System.Drawing.Point(121, 10)
        Me.bF.Name = "bF"
        Me.bF.Size = New System.Drawing.Size(55, 23)
        Me.bF.TabIndex = 3
        Me.bF.Text = "搜索"
        Me.bF.UseVisualStyleBackColor = True
        '
        'lUN
        '
        Me.lUN.Font = New System.Drawing.Font("微软雅黑", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lUN.Location = New System.Drawing.Point(182, 12)
        Me.lUN.Name = "lUN"
        Me.lUN.Size = New System.Drawing.Size(267, 39)
        Me.lUN.TabIndex = 4
        Me.lUN.Text = "单位名字单位名字"
        Me.lUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(455, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 36)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "等级99"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(511, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 36)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "类型类型"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(587, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 34)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "能否支配"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'UnitIfm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 445)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lUN)
        Me.Controls.Add(Me.bF)
        Me.Controls.Add(Me.tF)
        Me.Controls.Add(Me.ckO)
        Me.Controls.Add(Me.ckN)
        Me.Controls.Add(Me.ckB)
        Me.Controls.Add(Me.ckC)
        Me.Controls.Add(Me.lU)
        Me.Name = "UnitIfm"
        Me.Text = "UnitIfm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lU As ListView
    Friend WithEvents ckC As CheckBox
    Friend WithEvents ckB As CheckBox
    Friend WithEvents ckN As CheckBox
    Friend WithEvents ckO As CheckBox
    Friend WithEvents tF As TextBox
    Friend WithEvents bF As Button
    Friend WithEvents lUN As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
