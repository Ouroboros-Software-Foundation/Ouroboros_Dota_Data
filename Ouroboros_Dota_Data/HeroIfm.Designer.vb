<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HeroIfm
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("{0}最常用的物品", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("{0}最克制的对手", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("最克制{0}的对手", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("最适合{0}的队友", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("最不适合{0}的队友", System.Windows.Forms.HorizontalAlignment.Left)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HeroIfm))
        Me.lHN = New System.Windows.Forms.Label()
        Me.tbLV = New System.Windows.Forms.TrackBar()
        Me.tlpL = New System.Windows.Forms.TableLayoutPanel()
        Me.lHS = New System.Windows.Forms.Label()
        Me.lR = New System.Windows.Forms.Label()
        Me.tlpATB = New System.Windows.Forms.TableLayoutPanel()
        Me.pSTR = New System.Windows.Forms.PictureBox()
        Me.pAGI = New System.Windows.Forms.PictureBox()
        Me.pINT = New System.Windows.Forms.PictureBox()
        Me.lSTR = New System.Windows.Forms.Label()
        Me.lAGI = New System.Windows.Forms.Label()
        Me.lINT = New System.Windows.Forms.Label()
        Me.lATK = New System.Windows.Forms.Label()
        Me.lAMR = New System.Windows.Forms.Label()
        Me.lMOV = New System.Windows.Forms.Label()
        Me.pATK = New System.Windows.Forms.PictureBox()
        Me.pDEF = New System.Windows.Forms.PictureBox()
        Me.pMOV = New System.Windows.Forms.PictureBox()
        Me.pH = New System.Windows.Forms.PictureBox()
        Me.plP = New System.Windows.Forms.Panel()
        Me.pMP = New System.Windows.Forms.Label()
        Me.pHP = New System.Windows.Forms.Label()
        Me.plHN = New System.Windows.Forms.Panel()
        Me.lCAP = New System.Windows.Forms.Label()
        Me.lDIFF = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lHL = New System.Windows.Forms.Label()
        Me.tlpT = New System.Windows.Forms.TableLayoutPanel()
        Me.lT3 = New System.Windows.Forms.Label()
        Me.lB0 = New System.Windows.Forms.Label()
        Me.lT2 = New System.Windows.Forms.Label()
        Me.lBc = New System.Windows.Forms.Label()
        Me.lB2 = New System.Windows.Forms.Label()
        Me.lB1 = New System.Windows.Forms.Label()
        Me.lB4 = New System.Windows.Forms.Label()
        Me.lT0 = New System.Windows.Forms.Label()
        Me.lB6 = New System.Windows.Forms.Label()
        Me.lT1 = New System.Windows.Forms.Label()
        Me.lB3 = New System.Windows.Forms.Label()
        Me.lB7 = New System.Windows.Forms.Label()
        Me.lB5 = New System.Windows.Forms.Label()
        Me.tcA = New System.Windows.Forms.TabControl()
        Me.tpA = New System.Windows.Forms.TabPage()
        Me.lL = New System.Windows.Forms.Label()
        Me.rtAdes = New System.Windows.Forms.RichTextBox()
        Me.lCD = New System.Windows.Forms.Label()
        Me.lMC = New System.Windows.Forms.Label()
        Me.pCD = New System.Windows.Forms.PictureBox()
        Me.pMC = New System.Windows.Forms.PictureBox()
        Me.tlpR = New System.Windows.Forms.TableLayoutPanel()
        Me.tlp = New System.Windows.Forms.TableLayoutPanel()
        Me.lHYPE = New System.Windows.Forms.Label()
        Me.lvMAX = New System.Windows.Forms.ListView()
        CType(Me.tbLV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpL.SuspendLayout()
        Me.tlpATB.SuspendLayout()
        CType(Me.pSTR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pAGI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pINT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pATK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pDEF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pMOV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.plP.SuspendLayout()
        Me.plHN.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpT.SuspendLayout()
        Me.tcA.SuspendLayout()
        Me.tpA.SuspendLayout()
        CType(Me.pCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pMC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpR.SuspendLayout()
        Me.tlp.SuspendLayout()
        Me.SuspendLayout()
        '
        'lHN
        '
        Me.lHN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lHN.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lHN.Location = New System.Drawing.Point(0, 0)
        Me.lHN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lHN.Name = "lHN"
        Me.lHN.Size = New System.Drawing.Size(392, 37)
        Me.lHN.TabIndex = 1
        Me.lHN.Text = "英雄名"
        Me.lHN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbLV
        '
        Me.tbLV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbLV.Location = New System.Drawing.Point(4, 439)
        Me.tbLV.Margin = New System.Windows.Forms.Padding(4)
        Me.tbLV.Maximum = 25
        Me.tbLV.Minimum = 1
        Me.tbLV.Name = "tbLV"
        Me.tbLV.Size = New System.Drawing.Size(392, 36)
        Me.tbLV.TabIndex = 3
        Me.tbLV.Value = 1
        '
        'tlpL
        '
        Me.tlpL.AutoSize = True
        Me.tlpL.BackColor = System.Drawing.Color.Transparent
        Me.tlpL.ColumnCount = 1
        Me.tlpL.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
        Me.tlpL.Controls.Add(Me.lHS, 0, 8)
        Me.tlpL.Controls.Add(Me.lR, 0, 2)
        Me.tlpL.Controls.Add(Me.tlpATB, 0, 3)
        Me.tlpL.Controls.Add(Me.pH, 0, 0)
        Me.tlpL.Controls.Add(Me.plP, 0, 7)
        Me.tlpL.Controls.Add(Me.plHN, 0, 1)
        Me.tlpL.Controls.Add(Me.PictureBox1, 0, 4)
        Me.tlpL.Controls.Add(Me.tbLV, 0, 6)
        Me.tlpL.Controls.Add(Me.lHL, 0, 5)
        Me.tlpL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpL.Location = New System.Drawing.Point(13, 52)
        Me.tlpL.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpL.Name = "tlpL"
        Me.tlpL.RowCount = 9
        Me.tlpL.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 188.0!))
        Me.tlpL.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.tlpL.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.tlpL.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139.0!))
        Me.tlpL.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2.0!))
        Me.tlpL.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpL.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.tlpL.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpL.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpL.Size = New System.Drawing.Size(400, 687)
        Me.tlpL.TabIndex = 6
        '
        'lHS
        '
        Me.lHS.AutoSize = True
        Me.lHS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lHS.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.lHS.Location = New System.Drawing.Point(4, 529)
        Me.lHS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lHS.Name = "lHS"
        Me.lHS.Size = New System.Drawing.Size(392, 158)
        Me.lHS.TabIndex = 12
        Me.lHS.Text = "state"
        '
        'lR
        '
        Me.lR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lR.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.lR.Location = New System.Drawing.Point(4, 233)
        Me.lR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lR.Name = "lR"
        Me.lR.Size = New System.Drawing.Size(392, 31)
        Me.lR.TabIndex = 10
        Me.lR.Text = "定位"
        Me.lR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tlpATB
        '
        Me.tlpATB.ColumnCount = 4
        Me.tlpATB.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.tlpATB.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.tlpATB.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.tlpATB.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.tlpATB.Controls.Add(Me.pSTR, 0, 0)
        Me.tlpATB.Controls.Add(Me.pAGI, 0, 1)
        Me.tlpATB.Controls.Add(Me.pINT, 0, 2)
        Me.tlpATB.Controls.Add(Me.lSTR, 1, 0)
        Me.tlpATB.Controls.Add(Me.lAGI, 1, 1)
        Me.tlpATB.Controls.Add(Me.lINT, 1, 2)
        Me.tlpATB.Controls.Add(Me.lATK, 3, 0)
        Me.tlpATB.Controls.Add(Me.lAMR, 3, 1)
        Me.tlpATB.Controls.Add(Me.lMOV, 3, 2)
        Me.tlpATB.Controls.Add(Me.pATK, 2, 0)
        Me.tlpATB.Controls.Add(Me.pDEF, 2, 1)
        Me.tlpATB.Controls.Add(Me.pMOV, 2, 2)
        Me.tlpATB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpATB.Location = New System.Drawing.Point(4, 268)
        Me.tlpATB.Margin = New System.Windows.Forms.Padding(4)
        Me.tlpATB.Name = "tlpATB"
        Me.tlpATB.RowCount = 3
        Me.tlpATB.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.tlpATB.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.tlpATB.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.tlpATB.Size = New System.Drawing.Size(392, 131)
        Me.tlpATB.TabIndex = 7
        '
        'pSTR
        '
        Me.pSTR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pSTR.Image = Global.Ouroboros_Dota_Data.My.Resources.Resources.icon_str
        Me.pSTR.Location = New System.Drawing.Point(0, 0)
        Me.pSTR.Margin = New System.Windows.Forms.Padding(0)
        Me.pSTR.Name = "pSTR"
        Me.pSTR.Size = New System.Drawing.Size(53, 44)
        Me.pSTR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pSTR.TabIndex = 2
        Me.pSTR.TabStop = False
        '
        'pAGI
        '
        Me.pAGI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pAGI.Image = Global.Ouroboros_Dota_Data.My.Resources.Resources.icon_agi
        Me.pAGI.Location = New System.Drawing.Point(0, 44)
        Me.pAGI.Margin = New System.Windows.Forms.Padding(0)
        Me.pAGI.Name = "pAGI"
        Me.pAGI.Size = New System.Drawing.Size(53, 44)
        Me.pAGI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pAGI.TabIndex = 2
        Me.pAGI.TabStop = False
        '
        'pINT
        '
        Me.pINT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pINT.Image = Global.Ouroboros_Dota_Data.My.Resources.Resources.icon_int
        Me.pINT.Location = New System.Drawing.Point(0, 88)
        Me.pINT.Margin = New System.Windows.Forms.Padding(0)
        Me.pINT.Name = "pINT"
        Me.pINT.Size = New System.Drawing.Size(53, 44)
        Me.pINT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pINT.TabIndex = 2
        Me.pINT.TabStop = False
        '
        'lSTR
        '
        Me.lSTR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lSTR.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lSTR.Location = New System.Drawing.Point(57, 0)
        Me.lSTR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lSTR.Name = "lSTR"
        Me.lSTR.Size = New System.Drawing.Size(149, 44)
        Me.lSTR.TabIndex = 3
        Me.lSTR.Text = "00 + 0.00"
        Me.lSTR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lAGI
        '
        Me.lAGI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lAGI.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lAGI.Location = New System.Drawing.Point(57, 44)
        Me.lAGI.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lAGI.Name = "lAGI"
        Me.lAGI.Size = New System.Drawing.Size(149, 44)
        Me.lAGI.TabIndex = 3
        Me.lAGI.Text = "00 + 0.00"
        Me.lAGI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lINT
        '
        Me.lINT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lINT.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lINT.Location = New System.Drawing.Point(57, 88)
        Me.lINT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lINT.Name = "lINT"
        Me.lINT.Size = New System.Drawing.Size(149, 44)
        Me.lINT.TabIndex = 3
        Me.lINT.Text = "00 + 0.00"
        Me.lINT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lATK
        '
        Me.lATK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lATK.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.lATK.Location = New System.Drawing.Point(267, 0)
        Me.lATK.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lATK.Name = "lATK"
        Me.lATK.Size = New System.Drawing.Size(121, 44)
        Me.lATK.TabIndex = 3
        Me.lATK.Text = "000"
        Me.lATK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lAMR
        '
        Me.lAMR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lAMR.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.lAMR.Location = New System.Drawing.Point(267, 44)
        Me.lAMR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lAMR.Name = "lAMR"
        Me.lAMR.Size = New System.Drawing.Size(121, 44)
        Me.lAMR.TabIndex = 3
        Me.lAMR.Text = "000"
        Me.lAMR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lMOV
        '
        Me.lMOV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lMOV.Font = New System.Drawing.Font("微软雅黑", 12.0!)
        Me.lMOV.Location = New System.Drawing.Point(267, 88)
        Me.lMOV.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lMOV.Name = "lMOV"
        Me.lMOV.Size = New System.Drawing.Size(121, 44)
        Me.lMOV.TabIndex = 3
        Me.lMOV.Text = "000"
        Me.lMOV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pATK
        '
        Me.pATK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pATK.Image = Global.Ouroboros_Dota_Data.My.Resources.Resources.icon_atk
        Me.pATK.Location = New System.Drawing.Point(210, 0)
        Me.pATK.Margin = New System.Windows.Forms.Padding(0)
        Me.pATK.Name = "pATK"
        Me.pATK.Size = New System.Drawing.Size(53, 44)
        Me.pATK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pATK.TabIndex = 4
        Me.pATK.TabStop = False
        '
        'pDEF
        '
        Me.pDEF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pDEF.Image = Global.Ouroboros_Dota_Data.My.Resources.Resources.icon_def
        Me.pDEF.Location = New System.Drawing.Point(210, 44)
        Me.pDEF.Margin = New System.Windows.Forms.Padding(0)
        Me.pDEF.Name = "pDEF"
        Me.pDEF.Size = New System.Drawing.Size(53, 44)
        Me.pDEF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pDEF.TabIndex = 4
        Me.pDEF.TabStop = False
        '
        'pMOV
        '
        Me.pMOV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pMOV.Image = Global.Ouroboros_Dota_Data.My.Resources.Resources.icon_mov
        Me.pMOV.Location = New System.Drawing.Point(210, 88)
        Me.pMOV.Margin = New System.Windows.Forms.Padding(0)
        Me.pMOV.Name = "pMOV"
        Me.pMOV.Size = New System.Drawing.Size(53, 44)
        Me.pMOV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pMOV.TabIndex = 4
        Me.pMOV.TabStop = False
        '
        'pH
        '
        Me.pH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pH.Location = New System.Drawing.Point(4, 4)
        Me.pH.Margin = New System.Windows.Forms.Padding(4)
        Me.pH.Name = "pH"
        Me.pH.Size = New System.Drawing.Size(392, 180)
        Me.pH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pH.TabIndex = 0
        Me.pH.TabStop = False
        '
        'plP
        '
        Me.plP.Controls.Add(Me.pMP)
        Me.plP.Controls.Add(Me.pHP)
        Me.plP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plP.Location = New System.Drawing.Point(4, 483)
        Me.plP.Margin = New System.Windows.Forms.Padding(4)
        Me.plP.Name = "plP"
        Me.plP.Size = New System.Drawing.Size(392, 42)
        Me.plP.TabIndex = 13
        '
        'pMP
        '
        Me.pMP.BackColor = System.Drawing.Color.Blue
        Me.pMP.Dock = System.Windows.Forms.DockStyle.Right
        Me.pMP.Font = New System.Drawing.Font("宋体", 9.5!)
        Me.pMP.ForeColor = System.Drawing.Color.White
        Me.pMP.Location = New System.Drawing.Point(192, 0)
        Me.pMP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.pMP.Name = "pMP"
        Me.pMP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pMP.Size = New System.Drawing.Size(200, 42)
        Me.pMP.TabIndex = 1
        Me.pMP.Text = "0000+0.00"
        Me.pMP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pHP
        '
        Me.pHP.BackColor = System.Drawing.Color.Green
        Me.pHP.Dock = System.Windows.Forms.DockStyle.Left
        Me.pHP.Font = New System.Drawing.Font("宋体", 9.5!)
        Me.pHP.ForeColor = System.Drawing.Color.White
        Me.pHP.Location = New System.Drawing.Point(0, 0)
        Me.pHP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.pHP.Name = "pHP"
        Me.pHP.Size = New System.Drawing.Size(205, 42)
        Me.pHP.TabIndex = 0
        Me.pHP.Text = "0000+0.00"
        Me.pHP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plHN
        '
        Me.plHN.Controls.Add(Me.lCAP)
        Me.plHN.Controls.Add(Me.lDIFF)
        Me.plHN.Controls.Add(Me.lHN)
        Me.plHN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plHN.Location = New System.Drawing.Point(4, 192)
        Me.plHN.Margin = New System.Windows.Forms.Padding(4)
        Me.plHN.Name = "plHN"
        Me.plHN.Size = New System.Drawing.Size(392, 37)
        Me.plHN.TabIndex = 14
        '
        'lCAP
        '
        Me.lCAP.Dock = System.Windows.Forms.DockStyle.Right
        Me.lCAP.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.lCAP.Location = New System.Drawing.Point(312, 0)
        Me.lCAP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lCAP.Name = "lCAP"
        Me.lCAP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lCAP.Size = New System.Drawing.Size(80, 37)
        Me.lCAP.TabIndex = 3
        Me.lCAP.Text = "远近"
        Me.lCAP.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lDIFF
        '
        Me.lDIFF.Dock = System.Windows.Forms.DockStyle.Left
        Me.lDIFF.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.lDIFF.Location = New System.Drawing.Point(0, 0)
        Me.lDIFF.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lDIFF.Name = "lDIFF"
        Me.lDIFF.Size = New System.Drawing.Size(80, 37)
        Me.lDIFF.TabIndex = 2
        Me.lDIFF.Text = "难度"
        Me.lDIFF.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(3, 406)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(394, 1)
        Me.PictureBox1.TabIndex = 15
        Me.PictureBox1.TabStop = False
        '
        'lHL
        '
        Me.lHL.AutoSize = True
        Me.lHL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lHL.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.lHL.Location = New System.Drawing.Point(4, 405)
        Me.lHL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lHL.Name = "lHL"
        Me.lHL.Size = New System.Drawing.Size(392, 30)
        Me.lHL.TabIndex = 11
        Me.lHL.Text = "英雄名[等级00]"
        Me.lHL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'tlpT
        '
        Me.tlpT.ColumnCount = 3
        Me.tlpT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67.0!))
        Me.tlpT.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpT.Controls.Add(Me.lT3, 1, 1)
        Me.tlpT.Controls.Add(Me.lB0, 2, 4)
        Me.tlpT.Controls.Add(Me.lT2, 1, 2)
        Me.tlpT.Controls.Add(Me.lBc, 0, 0)
        Me.tlpT.Controls.Add(Me.lB2, 2, 3)
        Me.tlpT.Controls.Add(Me.lB1, 0, 4)
        Me.tlpT.Controls.Add(Me.lB4, 2, 2)
        Me.tlpT.Controls.Add(Me.lT0, 1, 4)
        Me.tlpT.Controls.Add(Me.lB6, 2, 1)
        Me.tlpT.Controls.Add(Me.lT1, 1, 3)
        Me.tlpT.Controls.Add(Me.lB3, 0, 3)
        Me.tlpT.Controls.Add(Me.lB7, 0, 1)
        Me.tlpT.Controls.Add(Me.lB5, 0, 2)
        Me.tlpT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpT.Location = New System.Drawing.Point(4, 4)
        Me.tlpT.Margin = New System.Windows.Forms.Padding(4)
        Me.tlpT.Name = "tlpT"
        Me.tlpT.RowCount = 5
        Me.tlpT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.tlpT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.tlpT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.tlpT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.tlpT.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpT.Size = New System.Drawing.Size(598, 180)
        Me.tlpT.TabIndex = 8
        '
        'lT3
        '
        Me.lT3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lT3.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lT3.Location = New System.Drawing.Point(269, 28)
        Me.lT3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lT3.Name = "lT3"
        Me.lT3.Size = New System.Drawing.Size(59, 38)
        Me.lT3.TabIndex = 7
        Me.lT3.Text = "25"
        Me.lT3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lB0
        '
        Me.lB0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lB0.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.lB0.Location = New System.Drawing.Point(336, 142)
        Me.lB0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lB0.Name = "lB0"
        Me.lB0.Size = New System.Drawing.Size(258, 38)
        Me.lB0.TabIndex = 7
        Me.lB0.Text = "天赋0"
        Me.lB0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lT2
        '
        Me.lT2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lT2.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lT2.Location = New System.Drawing.Point(269, 66)
        Me.lT2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lT2.Name = "lT2"
        Me.lT2.Size = New System.Drawing.Size(59, 38)
        Me.lT2.TabIndex = 7
        Me.lT2.Text = "20"
        Me.lT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lBc
        '
        Me.tlpT.SetColumnSpan(Me.lBc, 3)
        Me.lBc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lBc.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lBc.Location = New System.Drawing.Point(4, 0)
        Me.lBc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lBc.Name = "lBc"
        Me.lBc.Size = New System.Drawing.Size(590, 28)
        Me.lBc.TabIndex = 8
        Me.lBc.Text = "天赋树"
        Me.lBc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lB2
        '
        Me.lB2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lB2.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.lB2.Location = New System.Drawing.Point(336, 104)
        Me.lB2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lB2.Name = "lB2"
        Me.lB2.Size = New System.Drawing.Size(258, 38)
        Me.lB2.TabIndex = 7
        Me.lB2.Text = "天赋2"
        Me.lB2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lB1
        '
        Me.lB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lB1.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.lB1.Location = New System.Drawing.Point(4, 142)
        Me.lB1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lB1.Name = "lB1"
        Me.lB1.Size = New System.Drawing.Size(257, 38)
        Me.lB1.TabIndex = 7
        Me.lB1.Text = "天赋1"
        Me.lB1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lB4
        '
        Me.lB4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lB4.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.lB4.Location = New System.Drawing.Point(336, 66)
        Me.lB4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lB4.Name = "lB4"
        Me.lB4.Size = New System.Drawing.Size(258, 38)
        Me.lB4.TabIndex = 7
        Me.lB4.Text = "天赋4"
        Me.lB4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lT0
        '
        Me.lT0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lT0.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lT0.Location = New System.Drawing.Point(269, 142)
        Me.lT0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lT0.Name = "lT0"
        Me.lT0.Size = New System.Drawing.Size(59, 38)
        Me.lT0.TabIndex = 7
        Me.lT0.Text = "10"
        Me.lT0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lB6
        '
        Me.lB6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lB6.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.lB6.Location = New System.Drawing.Point(336, 28)
        Me.lB6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lB6.Name = "lB6"
        Me.lB6.Size = New System.Drawing.Size(258, 38)
        Me.lB6.TabIndex = 7
        Me.lB6.Text = "天赋6"
        Me.lB6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lT1
        '
        Me.lT1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lT1.Font = New System.Drawing.Font("微软雅黑", 15.0!, System.Drawing.FontStyle.Bold)
        Me.lT1.Location = New System.Drawing.Point(269, 104)
        Me.lT1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lT1.Name = "lT1"
        Me.lT1.Size = New System.Drawing.Size(59, 38)
        Me.lT1.TabIndex = 7
        Me.lT1.Text = "15"
        Me.lT1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lB3
        '
        Me.lB3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lB3.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.lB3.Location = New System.Drawing.Point(4, 104)
        Me.lB3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lB3.Name = "lB3"
        Me.lB3.Size = New System.Drawing.Size(257, 38)
        Me.lB3.TabIndex = 7
        Me.lB3.Text = "天赋3"
        Me.lB3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lB7
        '
        Me.lB7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lB7.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.lB7.Location = New System.Drawing.Point(4, 28)
        Me.lB7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lB7.Name = "lB7"
        Me.lB7.Size = New System.Drawing.Size(257, 38)
        Me.lB7.TabIndex = 7
        Me.lB7.Text = "天赋7"
        Me.lB7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lB5
        '
        Me.lB5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lB5.Font = New System.Drawing.Font("微软雅黑", 9.0!)
        Me.lB5.Location = New System.Drawing.Point(4, 66)
        Me.lB5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lB5.Name = "lB5"
        Me.lB5.Size = New System.Drawing.Size(257, 38)
        Me.lB5.TabIndex = 7
        Me.lB5.Text = "天赋5"
        Me.lB5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tcA
        '
        Me.tcA.Controls.Add(Me.tpA)
        Me.tcA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcA.Location = New System.Drawing.Point(4, 192)
        Me.tcA.Margin = New System.Windows.Forms.Padding(4)
        Me.tcA.Name = "tcA"
        Me.tcA.SelectedIndex = 0
        Me.tcA.Size = New System.Drawing.Size(598, 491)
        Me.tcA.TabIndex = 9
        '
        'tpA
        '
        Me.tpA.Controls.Add(Me.lL)
        Me.tpA.Controls.Add(Me.rtAdes)
        Me.tpA.Controls.Add(Me.lCD)
        Me.tpA.Controls.Add(Me.lMC)
        Me.tpA.Controls.Add(Me.pCD)
        Me.tpA.Controls.Add(Me.pMC)
        Me.tpA.Location = New System.Drawing.Point(4, 25)
        Me.tpA.Margin = New System.Windows.Forms.Padding(4)
        Me.tpA.Name = "tpA"
        Me.tpA.Padding = New System.Windows.Forms.Padding(4)
        Me.tpA.Size = New System.Drawing.Size(590, 462)
        Me.tpA.TabIndex = 0
        Me.tpA.Text = "技能模板"
        Me.tpA.UseVisualStyleBackColor = True
        '
        'lL
        '
        Me.lL.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lL.Location = New System.Drawing.Point(4, 427)
        Me.lL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lL.Name = "lL"
        Me.lL.Size = New System.Drawing.Size(582, 31)
        Me.lL.TabIndex = 10
        Me.lL.Text = "lore"
        Me.lL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtAdes
        '
        Me.rtAdes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtAdes.Dock = System.Windows.Forms.DockStyle.Top
        Me.rtAdes.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.rtAdes.Location = New System.Drawing.Point(4, 4)
        Me.rtAdes.Margin = New System.Windows.Forms.Padding(4)
        Me.rtAdes.Name = "rtAdes"
        Me.rtAdes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtAdes.Size = New System.Drawing.Size(582, 381)
        Me.rtAdes.TabIndex = 10
        Me.rtAdes.Text = "des"
        '
        'lCD
        '
        Me.lCD.Location = New System.Drawing.Point(361, 392)
        Me.lCD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lCD.Name = "lCD"
        Me.lCD.Size = New System.Drawing.Size(200, 30)
        Me.lCD.TabIndex = 1
        Me.lCD.Text = "cd"
        Me.lCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lMC
        '
        Me.lMC.Location = New System.Drawing.Point(48, 392)
        Me.lMC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lMC.Name = "lMC"
        Me.lMC.Size = New System.Drawing.Size(200, 30)
        Me.lMC.TabIndex = 1
        Me.lMC.Text = "mc"
        Me.lMC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pCD
        '
        Me.pCD.Image = Global.Ouroboros_Dota_Data.My.Resources.Resources.icon_cd
        Me.pCD.Location = New System.Drawing.Point(321, 392)
        Me.pCD.Margin = New System.Windows.Forms.Padding(4)
        Me.pCD.Name = "pCD"
        Me.pCD.Size = New System.Drawing.Size(32, 30)
        Me.pCD.TabIndex = 0
        Me.pCD.TabStop = False
        '
        'pMC
        '
        Me.pMC.Image = Global.Ouroboros_Dota_Data.My.Resources.Resources.icon_mana
        Me.pMC.Location = New System.Drawing.Point(8, 392)
        Me.pMC.Margin = New System.Windows.Forms.Padding(4)
        Me.pMC.Name = "pMC"
        Me.pMC.Size = New System.Drawing.Size(32, 30)
        Me.pMC.TabIndex = 0
        Me.pMC.TabStop = False
        '
        'tlpR
        '
        Me.tlpR.ColumnCount = 1
        Me.tlpR.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpR.Controls.Add(Me.tcA, 0, 1)
        Me.tlpR.Controls.Add(Me.tlpT, 0, 0)
        Me.tlpR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpR.Location = New System.Drawing.Point(413, 52)
        Me.tlpR.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpR.Name = "tlpR"
        Me.tlpR.RowCount = 2
        Me.tlpR.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 188.0!))
        Me.tlpR.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpR.Size = New System.Drawing.Size(606, 687)
        Me.tlpR.TabIndex = 10
        '
        'tlp
        '
        Me.tlp.ColumnCount = 5
        Me.tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400.0!))
        Me.tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 413.0!))
        Me.tlp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.tlp.Controls.Add(Me.tlpL, 1, 2)
        Me.tlp.Controls.Add(Me.tlpR, 2, 2)
        Me.tlp.Controls.Add(Me.lHYPE, 1, 1)
        Me.tlp.Controls.Add(Me.lvMAX, 3, 2)
        Me.tlp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp.Location = New System.Drawing.Point(0, 0)
        Me.tlp.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp.Name = "tlp"
        Me.tlp.RowCount = 4
        Me.tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.tlp.Size = New System.Drawing.Size(1445, 751)
        Me.tlp.TabIndex = 11
        '
        'lHYPE
        '
        Me.tlp.SetColumnSpan(Me.lHYPE, 3)
        Me.lHYPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lHYPE.Font = New System.Drawing.Font("宋体", 10.0!)
        Me.lHYPE.Location = New System.Drawing.Point(17, 12)
        Me.lHYPE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lHYPE.Name = "lHYPE"
        Me.lHYPE.Size = New System.Drawing.Size(1411, 40)
        Me.lHYPE.TabIndex = 11
        Me.lHYPE.Text = "hype"
        '
        'lvMAX
        '
        Me.lvMAX.Dock = System.Windows.Forms.DockStyle.Fill
        ListViewGroup1.Header = "{0}最常用的物品"
        ListViewGroup1.Name = "lvgITEM"
        ListViewGroup2.Header = "{0}最克制的对手"
        ListViewGroup2.Name = "lvgANTI1"
        ListViewGroup3.Header = "最克制{0}的对手"
        ListViewGroup3.Name = "lvgANTI2"
        ListViewGroup4.Header = "最适合{0}的队友"
        ListViewGroup4.Name = "lvgCOMB1"
        ListViewGroup5.Header = "最不适合{0}的队友"
        ListViewGroup5.Name = "lvgCOMB2"
        Me.lvMAX.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4, ListViewGroup5})
        Me.lvMAX.HideSelection = False
        Me.lvMAX.Location = New System.Drawing.Point(1023, 56)
        Me.lvMAX.Margin = New System.Windows.Forms.Padding(4)
        Me.lvMAX.Name = "lvMAX"
        Me.lvMAX.Size = New System.Drawing.Size(405, 679)
        Me.lvMAX.TabIndex = 12
        Me.lvMAX.UseCompatibleStateImageBehavior = False
        Me.lvMAX.View = System.Windows.Forms.View.SmallIcon
        '
        'HeroIfm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1445, 751)
        Me.Controls.Add(Me.tlp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "HeroIfm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HeroIfm"
        CType(Me.tbLV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpL.ResumeLayout(False)
        Me.tlpL.PerformLayout()
        Me.tlpATB.ResumeLayout(False)
        CType(Me.pSTR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pAGI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pINT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pATK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pDEF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pMOV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.plP.ResumeLayout(False)
        Me.plHN.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpT.ResumeLayout(False)
        Me.tcA.ResumeLayout(False)
        Me.tpA.ResumeLayout(False)
        CType(Me.pCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pMC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpR.ResumeLayout(False)
        Me.tlp.ResumeLayout(False)
        Me.tlp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pH As PictureBox
    Friend WithEvents lHN As Label
    Friend WithEvents pSTR As PictureBox
    Friend WithEvents pAGI As PictureBox
    Friend WithEvents pINT As PictureBox
    Friend WithEvents tbLV As TrackBar
    Friend WithEvents tlpL As TableLayoutPanel
    Friend WithEvents tlpATB As TableLayoutPanel
    Friend WithEvents lSTR As Label
    Friend WithEvents lAGI As Label
    Friend WithEvents lINT As Label
    Friend WithEvents lATK As Label
    Friend WithEvents lAMR As Label
    Friend WithEvents lMOV As Label
    Friend WithEvents pATK As PictureBox
    Friend WithEvents pDEF As PictureBox
    Friend WithEvents pMOV As PictureBox
    Friend WithEvents lB7 As Label
    Friend WithEvents lB5 As Label
    Friend WithEvents lB3 As Label
    Friend WithEvents lB1 As Label
    Friend WithEvents lT3 As Label
    Friend WithEvents lT2 As Label
    Friend WithEvents lT1 As Label
    Friend WithEvents lT0 As Label
    Friend WithEvents lB6 As Label
    Friend WithEvents lB4 As Label
    Friend WithEvents lB2 As Label
    Friend WithEvents lB0 As Label
    Friend WithEvents tlpT As TableLayoutPanel
    Friend WithEvents tcA As TabControl
    Friend WithEvents lR As Label
    Friend WithEvents tpA As TabPage
    Friend WithEvents lCD As Label
    Friend WithEvents lMC As Label
    Friend WithEvents pCD As PictureBox
    Friend WithEvents pMC As PictureBox
    Friend WithEvents rtAdes As RichTextBox
    Friend WithEvents lL As Label
    Friend WithEvents lBc As Label
    Friend WithEvents lHL As Label
    Friend WithEvents lHS As Label
    Friend WithEvents plP As Panel
    Friend WithEvents pMP As Label
    Friend WithEvents pHP As Label
    Friend WithEvents plHN As Panel
    Friend WithEvents lDIFF As Label
    Friend WithEvents lCAP As Label
    Friend WithEvents tlpR As TableLayoutPanel
    Friend WithEvents tlp As TableLayoutPanel
    Friend WithEvents lHYPE As Label
    Friend WithEvents lvMAX As ListView
    Friend WithEvents PictureBox1 As PictureBox
End Class
