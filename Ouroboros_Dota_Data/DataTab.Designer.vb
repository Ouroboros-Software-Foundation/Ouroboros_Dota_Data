<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataTab
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataTab))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.menuDT = New System.Windows.Forms.MenuStrip()
        Me.menuH = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuA = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuI = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuDT.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(0, 25)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(772, 376)
        Me.dgv.TabIndex = 0
        '
        'menuDT
        '
        Me.menuDT.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuH, Me.menuA, Me.menuI})
        Me.menuDT.Location = New System.Drawing.Point(0, 0)
        Me.menuDT.Name = "menuDT"
        Me.menuDT.Size = New System.Drawing.Size(772, 25)
        Me.menuDT.TabIndex = 1
        Me.menuDT.Text = "MenuStrip1"
        '
        'menuH
        '
        Me.menuH.Name = "menuH"
        Me.menuH.Size = New System.Drawing.Size(80, 21)
        Me.menuH.Text = "英雄数据表"
        '
        'menuA
        '
        Me.menuA.Name = "menuA"
        Me.menuA.Size = New System.Drawing.Size(80, 21)
        Me.menuA.Text = "技能数据表"
        '
        'menuI
        '
        Me.menuI.Name = "menuI"
        Me.menuI.Size = New System.Drawing.Size(80, 21)
        Me.menuI.Text = "物品数据表"
        '
        'DataTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 401)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.menuDT)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuDT
        Me.Name = "DataTab"
        Me.Text = "DataTab"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuDT.ResumeLayout(False)
        Me.menuDT.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents menuDT As MenuStrip
    Friend WithEvents menuH As ToolStripMenuItem
    Friend WithEvents menuA As ToolStripMenuItem
    Friend WithEvents menuI As ToolStripMenuItem
End Class
