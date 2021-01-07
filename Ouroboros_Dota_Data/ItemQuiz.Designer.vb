<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemQuiz
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemQuiz))
        Me.lNAME = New System.Windows.Forms.Label()
        Me.lCOST = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bS0 = New System.Windows.Forms.Button()
        Me.bS1 = New System.Windows.Forms.Button()
        Me.bS2 = New System.Windows.Forms.Button()
        Me.bS3 = New System.Windows.Forms.Button()
        Me.bS4 = New System.Windows.Forms.Button()
        Me.bS5 = New System.Windows.Forms.Button()
        Me.bS6 = New System.Windows.Forms.Button()
        Me.bS7 = New System.Windows.Forms.Button()
        Me.pTF = New System.Windows.Forms.PictureBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.p3 = New System.Windows.Forms.PictureBox()
        Me.p2 = New System.Windows.Forms.PictureBox()
        Me.p1 = New System.Windows.Forms.PictureBox()
        Me.p0 = New System.Windows.Forms.PictureBox()
        Me.p = New System.Windows.Forms.PictureBox()
        Me.lSCR = New System.Windows.Forms.Label()
        Me.lCHC = New System.Windows.Forms.Label()
        Me.lCB = New System.Windows.Forms.Label()
        Me.lANS = New System.Windows.Forms.Label()
        Me.bSr = New System.Windows.Forms.Button()
        CType(Me.pTF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.p, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lNAME
        '
        Me.lNAME.Font = New System.Drawing.Font("黑体", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lNAME.Location = New System.Drawing.Point(106, 15)
        Me.lNAME.Name = "lNAME"
        Me.lNAME.Size = New System.Drawing.Size(200, 30)
        Me.lNAME.TabIndex = 2
        Me.lNAME.Text = "物品名称物品名称"
        Me.lNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lCOST
        '
        Me.lCOST.Font = New System.Drawing.Font("宋体", 12.0!)
        Me.lCOST.Location = New System.Drawing.Point(137, 49)
        Me.lCOST.Name = "lCOST"
        Me.lCOST.Size = New System.Drawing.Size(169, 30)
        Me.lCOST.TabIndex = 3
        Me.lCOST.Text = "9999"
        Me.lCOST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(15, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(449, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "请从以下物品中选择正确的部件："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(325, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "答题得分："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(325, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "剩余机会："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bS0
        '
        Me.bS0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bS0.Location = New System.Drawing.Point(15, 193)
        Me.bS0.Name = "bS0"
        Me.bS0.Size = New System.Drawing.Size(93, 84)
        Me.bS0.TabIndex = 7
        Me.bS0.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bS0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bS0.UseVisualStyleBackColor = True
        '
        'bS1
        '
        Me.bS1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bS1.Location = New System.Drawing.Point(107, 193)
        Me.bS1.Name = "bS1"
        Me.bS1.Size = New System.Drawing.Size(93, 84)
        Me.bS1.TabIndex = 7
        Me.bS1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bS1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bS1.UseVisualStyleBackColor = True
        '
        'bS2
        '
        Me.bS2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bS2.Location = New System.Drawing.Point(199, 193)
        Me.bS2.Name = "bS2"
        Me.bS2.Size = New System.Drawing.Size(93, 84)
        Me.bS2.TabIndex = 7
        Me.bS2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bS2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bS2.UseVisualStyleBackColor = True
        '
        'bS3
        '
        Me.bS3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bS3.Location = New System.Drawing.Point(291, 193)
        Me.bS3.Name = "bS3"
        Me.bS3.Size = New System.Drawing.Size(93, 84)
        Me.bS3.TabIndex = 7
        Me.bS3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bS3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bS3.UseVisualStyleBackColor = True
        '
        'bS4
        '
        Me.bS4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bS4.Location = New System.Drawing.Point(15, 277)
        Me.bS4.Name = "bS4"
        Me.bS4.Size = New System.Drawing.Size(93, 84)
        Me.bS4.TabIndex = 7
        Me.bS4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bS4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bS4.UseVisualStyleBackColor = True
        '
        'bS5
        '
        Me.bS5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bS5.Location = New System.Drawing.Point(107, 277)
        Me.bS5.Name = "bS5"
        Me.bS5.Size = New System.Drawing.Size(93, 84)
        Me.bS5.TabIndex = 7
        Me.bS5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bS5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bS5.UseVisualStyleBackColor = True
        '
        'bS6
        '
        Me.bS6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bS6.Location = New System.Drawing.Point(199, 277)
        Me.bS6.Name = "bS6"
        Me.bS6.Size = New System.Drawing.Size(93, 84)
        Me.bS6.TabIndex = 7
        Me.bS6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bS6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bS6.UseVisualStyleBackColor = True
        '
        'bS7
        '
        Me.bS7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bS7.Location = New System.Drawing.Point(291, 277)
        Me.bS7.Name = "bS7"
        Me.bS7.Size = New System.Drawing.Size(93, 84)
        Me.bS7.TabIndex = 7
        Me.bS7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bS7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bS7.UseVisualStyleBackColor = True
        '
        'pTF
        '
        Me.pTF.Location = New System.Drawing.Point(412, 95)
        Me.pTF.Name = "pTF"
        Me.pTF.Size = New System.Drawing.Size(64, 64)
        Me.pTF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pTF.TabIndex = 5
        Me.pTF.TabStop = False
        '
        'PictureBox14
        '
        Me.PictureBox14.Image = Global.Ouroboros_Dota_Data.My.Resources.Resources.icon_gold
        Me.PictureBox14.Location = New System.Drawing.Point(106, 49)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(25, 30)
        Me.PictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox14.TabIndex = 1
        Me.PictureBox14.TabStop = False
        '
        'p3
        '
        Me.p3.Location = New System.Drawing.Point(288, 95)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(85, 64)
        Me.p3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.p3.TabIndex = 0
        Me.p3.TabStop = False
        '
        'p2
        '
        Me.p2.Location = New System.Drawing.Point(197, 95)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(85, 64)
        Me.p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.p2.TabIndex = 0
        Me.p2.TabStop = False
        '
        'p1
        '
        Me.p1.Location = New System.Drawing.Point(106, 95)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(85, 64)
        Me.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.p1.TabIndex = 0
        Me.p1.TabStop = False
        '
        'p0
        '
        Me.p0.Location = New System.Drawing.Point(15, 95)
        Me.p0.Name = "p0"
        Me.p0.Size = New System.Drawing.Size(85, 64)
        Me.p0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.p0.TabIndex = 0
        Me.p0.TabStop = False
        '
        'p
        '
        Me.p.Location = New System.Drawing.Point(15, 15)
        Me.p.Name = "p"
        Me.p.Size = New System.Drawing.Size(85, 64)
        Me.p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.p.TabIndex = 0
        Me.p.TabStop = False
        '
        'lSCR
        '
        Me.lSCR.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lSCR.Location = New System.Drawing.Point(416, 15)
        Me.lSCR.Name = "lSCR"
        Me.lSCR.Size = New System.Drawing.Size(60, 20)
        Me.lSCR.TabIndex = 6
        Me.lSCR.Text = "00000"
        Me.lSCR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lCHC
        '
        Me.lCHC.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lCHC.Location = New System.Drawing.Point(416, 59)
        Me.lCHC.Name = "lCHC"
        Me.lCHC.Size = New System.Drawing.Size(60, 20)
        Me.lCHC.TabIndex = 6
        Me.lCHC.Text = "0"
        Me.lCHC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lCB
        '
        Me.lCB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lCB.ForeColor = System.Drawing.Color.Green
        Me.lCB.Location = New System.Drawing.Point(416, 35)
        Me.lCB.Name = "lCB"
        Me.lCB.Size = New System.Drawing.Size(60, 20)
        Me.lCB.TabIndex = 6
        Me.lCB.Text = "+000"
        Me.lCB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lANS
        '
        Me.lANS.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.lANS.Location = New System.Drawing.Point(15, 370)
        Me.lANS.Name = "lANS"
        Me.lANS.Size = New System.Drawing.Size(461, 20)
        Me.lANS.TabIndex = 8
        Me.lANS.Text = "错误配方"
        Me.lANS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'bSr
        '
        Me.bSr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bSr.Location = New System.Drawing.Point(383, 232)
        Me.bSr.Name = "bSr"
        Me.bSr.Size = New System.Drawing.Size(93, 85)
        Me.bSr.TabIndex = 7
        Me.bSr.Text = "图纸"
        Me.bSr.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bSr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.bSr.UseVisualStyleBackColor = True
        '
        'ItemQuiz
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 401)
        Me.Controls.Add(Me.lCHC)
        Me.Controls.Add(Me.lCB)
        Me.Controls.Add(Me.lSCR)
        Me.Controls.Add(Me.bSr)
        Me.Controls.Add(Me.bS7)
        Me.Controls.Add(Me.bS6)
        Me.Controls.Add(Me.bS5)
        Me.Controls.Add(Me.bS4)
        Me.Controls.Add(Me.bS3)
        Me.Controls.Add(Me.bS2)
        Me.Controls.Add(Me.bS1)
        Me.Controls.Add(Me.bS0)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pTF)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lCOST)
        Me.Controls.Add(Me.lNAME)
        Me.Controls.Add(Me.PictureBox14)
        Me.Controls.Add(Me.p3)
        Me.Controls.Add(Me.p2)
        Me.Controls.Add(Me.p1)
        Me.Controls.Add(Me.p0)
        Me.Controls.Add(Me.p)
        Me.Controls.Add(Me.lANS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ItemQuiz"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "物品测试"
        CType(Me.pTF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.p, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents p As PictureBox
    Friend WithEvents p0 As PictureBox
    Friend WithEvents p1 As PictureBox
    Friend WithEvents p2 As PictureBox
    Friend WithEvents p3 As PictureBox
    Friend WithEvents PictureBox14 As PictureBox
    Friend WithEvents lNAME As Label
    Friend WithEvents lCOST As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pTF As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents bS0 As Button
    Friend WithEvents bS1 As Button
    Friend WithEvents bS2 As Button
    Friend WithEvents bS3 As Button
    Friend WithEvents bS4 As Button
    Friend WithEvents bS5 As Button
    Friend WithEvents bS6 As Button
    Friend WithEvents bS7 As Button
    Friend WithEvents lSCR As Label
    Friend WithEvents lCHC As Label
    Friend WithEvents lCB As Label
    Friend WithEvents lANS As Label
    Friend WithEvents bSr As Button
End Class
