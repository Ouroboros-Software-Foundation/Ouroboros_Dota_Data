Public Class Invoker
    Dim sec, qn, qc As Integer
    Dim qsi As Integer = -1 '题目的技能编号
    Dim qsi0 As Integer = 1 '上一道题
    Dim tKey() As TextBox
    Dim lSN(), lHINT(,), lHq(), lHw(), lHe() As Label
    Dim pSN()， pBall() As PictureBox
    Dim pBi(2) As Integer '3球的技能序号
    Dim pSi(1) As Integer '已切出的两个技能的序号
    Dim pS0(), pS() As Image
    Dim sNe(15), SK(15) As String
    Dim RDY As Boolean = False
    Dim KeyS As Boolean = False
    Dim RUN As Boolean = False
    Dim KeySi As Integer = -1
    Dim dSN As New Dictionary(Of Integer, String)
    Dim dSH As New Dictionary(Of Integer, Integer())
    Dim dSHr As New Dictionary(Of Integer, Integer)
    Dim Words(15) As String

    Private Sub Invoker_Load(sender As Object, e As EventArgs) Handles Me.Load
        tKey = {K0, K1, K2, K3, K4, K5, K6, K7, K8, K9, K10, K11, K12, K13, K14, K15}
        lSN = {SN0, SN1, SN2, SN3, SN4, SN5, SN6, SN7, SN8, SN9, SN10, SN11, SN12, SN13, SN14, SN15}
        pSN = {P0, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, P13, P14, P15}
        lHINT = {{L00, L01, L02}, {L10, L11, L12}, {L20, L21, L22}, {L30, L31, L32}, {L40, L41, L42}, {L50, L51, L52}, {L60, L61, L62}, {L70, L71, L72}, {L80, L81, L82}, {L90, L91, L92}}
        lHq = {L00, L01, L02, L10, L11, L20, L21, L42, L72, L90, Lq}
        lHw = {L12, L30, L31, L32, L40, L41, L50, L51, L82, L91, Lw}
        lHe = {L22, L52, L60, L61, L62, L70, L71, L80, L81, L92, Le}
        pBall = {Pb0, Pb1, Pb2}
        sNe = {"quas", "wex", "exort", "empty1", "empty2", "invoke", "ghost_walk", "ice_wall", "emp", "tornado", "alacrity", "sun_strike", "forge_spirit", "chaos_meteor", "deafening_blast"}
        pS0 = {My.Resources.invoker_quas_png, My.Resources.invoker_wex_png, My.Resources.invoker_exort_png, My.Resources.empty_skill, My.Resources.empty_skill, My.Resources.invoker_invoke_png, My.Resources.invoker_cold_snap_png, My.Resources.invoker_ghost_walk_png, My.Resources.invoker_ice_wall_png, My.Resources.invoker_emp_png, My.Resources.invoker_tornado_png, My.Resources.invoker_alacrity_png, My.Resources.invoker_sun_strike_png, My.Resources.invoker_forge_spirit_png, My.Resources.invoker_chaos_meteor_png, My.Resources.invoker_deafening_blast_png}
        pS = pS0
        Words(0) = "真知奥秘，唯我知晓！"
        Words(1) = "这个魔法令人失望……"
        Words(2) = "咒语记混了吗？"
        Words(3) = "记忆有误……"
        Words(6) = "塞卓昂的无尽战栗！"
        Words(7) = "米瑞特之阻碍！"
        Words(8) = "科瑞克斯的杀戮之墙！"
        Words(9) = "席美尔的精华脉冲！"
        Words(10) = "托纳鲁斯之爪！"
        Words(11) = "盖斯特之猛战号令！"
        Words(12) = "哈雷克之火葬魔咒！"
        Words(13) = "卡尔维因的至邪产物！"
        Words(14) = "塔拉克的天坠之火！"
        Words(15) = "布鲁冯特之无力声波！"
        dSN.Add(6, "急速冷却")
        dSN.Add(7, "幽灵漫步")
        dSN.Add(8, "寒冰之墙")
        dSN.Add(9, "电磁脉冲")
        dSN.Add(10, "强袭飓风")
        dSN.Add(11, "灵动迅捷")
        dSN.Add(12, "阳炎冲击")
        dSN.Add(13, "熔炉精灵")
        dSN.Add(14, "混沌陨石")
        dSN.Add(15, "超震声波")
        dSHr.Add(300, 6)
        dSHr.Add(210, 7)
        dSHr.Add(201, 8)
        dSHr.Add(30, 9)
        dSHr.Add(120, 10)
        dSHr.Add(21, 11)
        dSHr.Add(3, 12)
        dSHr.Add(102, 13)
        dSHr.Add(12, 14)
        dSHr.Add(111, 15)
        pBi = {-1, -1, -1}
        pSi = {-1, -1}
        SKl.Visible = False
        SKp.Visible = False
        For i = 0 To 15
            SK(i) = tKey(i).Text
        Next
        Lwords.Text = Words(0)
        pInvoker.Image = Image.FromFile("pic\hero\invoker.png")
        KeyPreview = True
        RDY = True
    End Sub

    Private Sub Invoker_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim k As String = e.KeyChar.ToString.ToUpper()
        If KeyS Then
            Bstart.Focus()
            If e.KeyChar = Chr(27) Then
                SKl.Visible = False
                SKl.Text = vbNullString
                KeyS = False
                Exit Sub
            End If
            Dim ub As Integer = IIf(ckOld.Checked, 15, 5)
            For i = 0 To ub
                If ckOld.Checked AndAlso (i = 3 Or i = 4) Then Continue For
                If SK(i) = k AndAlso KeySi <> i Then
                    MessageBox.Show($"{lSN(i).Text}已被设置为{k}")
                    SKl.Visible = False
                    SKl.Text = vbNullString
                    KeyS = False
                    Exit Sub
                End If
            Next
            SK(KeySi) = k
            tKey(KeySi).Text = k
            Select Case KeySi
                Case 0
                    For i = 0 To 10
                        lHq(i).Text = k
                    Next
                Case 1
                    For i = 0 To 10
                        lHw(i).Text = k
                    Next
                Case 2
                    For i = 0 To 10
                        lHe(i).Text = k
                    Next
                Case 3
                    Ls0.Text = k
                Case 4
                    Ls1.Text = k
                Case 5
                    Li.Text = k
            End Select
            SKl.Visible = False
            SKl.Text = vbNullString
            KeyS = False
        Else
            Select Case k
                Case SK(0)
                    pBi(0) = pBi(1)
                    pBi(1) = pBi(2)
                    pBi(2) = 0
                    pBall(0).BackgroundImage = pBall(1).BackgroundImage
                    pBall(1).BackgroundImage = pBall(2).BackgroundImage
                    pBall(2).BackgroundImage = pS(0)
                Case SK(1)
                    pBi(0) = pBi(1)
                    pBi(1) = pBi(2)
                    pBi(2) = 1
                    pBall(0).BackgroundImage = pBall(1).BackgroundImage
                    pBall(1).BackgroundImage = pBall(2).BackgroundImage
                    pBall(2).BackgroundImage = pS(1)
                Case SK(2)
                    pBi(0) = pBi(1)
                    pBi(1) = pBi(2)
                    pBi(2) = 2
                    pBall(0).BackgroundImage = pBall(1).BackgroundImage
                    pBall(1).BackgroundImage = pBall(2).BackgroundImage
                    pBall(2).BackgroundImage = pS(2)
                Case SK(5)
                    If Not Bi.Enabled Then Exit Sub '大招CD没好
                    Dim pBcA() As Integer = {0, 0, 0}
                    For i = 0 To 2
                        If pBi(i) = -1 Then '不足3球
                            Lwords.Text = Words(1)
                            If RUN Then
                                Ans(False)
                                Next_Skill()
                            End If
                            Exit Select
                        End If
                        pBcA(pBi(i)) += 1
                    Next
                    Dim pBc As Integer = pBcA(0) * 100 + pBcA(1) * 10 + pBcA(2)
                    Dim si As Int16 = dSHr(pBc) '技能序号
                    If si = pSi(0) Then '重复祈唤前一个技能
                        Lwords.Text = Words(2)
                        If Not ckSU.Checked Then
                            If RUN Then
                                Ans(si = qsi)
                                Next_Skill()
                            End If
                        End If
                        Exit Select
                    End If
                    pSi(1) = pSi(0)
                    pSi(0) = si
                    Bs1.BackgroundImage = Bs0.BackgroundImage
                    Bs0.BackgroundImage = pS(pSi(0))
                    If ckOld.Checked Then
                        Ls0.Text = SK(pSi(0))
                        If pSi(1) >= 0 Then Ls1.Text = SK(pSi(1))
                    End If
                    If Not ckSU.Checked Then
                        If RUN Then
                            Lwords.Text = Words(si)
                            Ans(si = qsi)
                            Next_Skill()
                        End If
                    End If
                    'CD处理
                Case SK(3)
                    If pSi(0) >= 0 AndAlso (Not ckOld.Checked) Then
                        Lwords.Text = Words(pSi(0))
                        If ckSU.Checked Then
                            If RUN Then
                                Ans(pSi(0) = qsi)
                                Next_Skill()
                            End If
                        End If
                    End If
                Case SK(4)
                    If pSi(1) >= 0 AndAlso (Not ckOld.Checked) Then
                        Lwords.Text = Words(pSi(1))
                        If ckSU.Checked Then
                            If RUN Then
                                Ans(pSi(1) = qsi)
                                Next_Skill()
                            End If
                        End If
                    End If
                Case SK(6), SK(7), SK(8), SK(9), SK(10), SK(11), SK(12), SK(13), SK(14), SK(15)
                    '按了没祈唤的技能不判错
                    If ckOld.Checked Then
                        Dim osi As Integer = -1
                        For i = 6 To 15
                            If SK(i) = k Then
                                osi = i '按键的技能编号
                                Exit For
                            End If
                        Next
                        If pSi.Contains(osi) Then '按键的技能已祈唤
                            Lwords.Text = Words(osi)
                        End If
                        If ckSU.Checked Then
                            If RUN Then
                                Ans(pSi.Contains(qsi) AndAlso k = SK(qsi))
                                Next_Skill()
                            End If
                        End If
                    End If
                Case Else
                    If ckOld.Checked And ckSU.Checked Then '传统模式+需要祈唤，按其他键判错
                        Lwords.Text = Words(3)
                        If RUN Then
                            Ans(False)
                            Next_Skill()
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub Next_Skill()
        Dim r As New Random
        Do
            qsi = r.Next(6, 16)
        Loop Until qsi <> qsi0
        qsi0 = qsi
        Dim lp As Integer = r.Next(100)
        If lp < 45 Then
            SKl.Visible = True
            SKp.Visible = False
            SKl.Text = dSN(qsi)
        Else
            SKl.Visible = False
            SKp.Visible = True
            SKp.Image = pS(qsi)
        End If
        qn += 1
    End Sub

    Private Sub Blog_Click(sender As Object, e As EventArgs) Handles Blog.Click
        MessageBox.Show("开发中……")
    End Sub

    Private Sub Ans(ByVal tf As Boolean)
        If tf Then
            qc += 1
        End If
        Lcplt.Text = $"{qc.ToString}/{qn.ToString}"
        Lrate.Text = $"{Math.Round((qc / qn) * 100, 1)}%"
    End Sub

    Private Sub tmS_Tick(sender As Object, e As EventArgs) Handles tmS.Tick
        sec += 1
        Ltime.Text = $"{(sec \ 60).ToString.PadLeft(2, "0"c)}:{(sec Mod 60).ToString.PadLeft(2, "0"c)}"
    End Sub

    Private Sub Bstart_Click(sender As Object, e As EventArgs) Handles Bstart.Click
        If RUN Then
            tmS.Stop()
            RUN = False
            Bstart.Text = "开始"
            Bitem.Enabled = True
            ckOld.Enabled = True
            cksN.Enabled = True
            ckSH.Enabled = True
            ckNoCD.Enabled = False '''''''''''''''''''''''
            ckSU.Enabled = True
            pBi = {-1, -1, -1}
            pSi = {-1, -1}
            Pb0.BackgroundImage = My.Resources.empty_skill
            Pb1.BackgroundImage = My.Resources.empty_skill
            Pb2.BackgroundImage = My.Resources.empty_skill
            Bs0.BackgroundImage = My.Resources.empty_skill
            Bs1.BackgroundImage = My.Resources.empty_skill
            SKl.Visible = False
            SKp.Visible = False
            For i = 0 To 15
                tKey(i).Enabled = True
            Next
            If ckOld.Checked Then
                Ls0.Text = vbNullString
                Ls1.Text = vbNullString
            Else
                Ls0.Text = tKey(3).Text
                Ls1.Text = tKey(4).Text
            End If
            Lwords.Text = Words(0)
            'MessageBox.Show("")
        Else '开始测试
            For i = 0 To 15
                SK(i) = tKey(i).Text
            Next
            pBi = {-1, -1, -1}
            pSi = {-1, -1}
            Pb0.BackgroundImage = My.Resources.empty_skill
            Pb1.BackgroundImage = My.Resources.empty_skill
            Pb2.BackgroundImage = My.Resources.empty_skill
            Bs0.BackgroundImage = My.Resources.empty_skill
            Bs1.BackgroundImage = My.Resources.empty_skill
            Bitem.Enabled = False
            ckOld.Enabled = False
            cksN.Enabled = False
            ckSH.Enabled = False
            ckNoCD.Enabled = False
            ckSU.Enabled = False
            For i = 0 To 15
                tKey(i).Enabled = False
            Next
            Ltime.Text = "00:00"
            Bstart.Text = "停止"
            RUN = True
            sec = 0
            qn = 0
            qc = 0
            tmS.Start()
            Next_Skill()
        End If
    End Sub

    Private Sub Key_Set(sender As TextBox, e As EventArgs) Handles K0.Click, K1.Click, K2.Click, K3.Click, K4.Click, K5.Click, K6.Click, K7.Click, K8.Click, K9.Click, K10.Click, K11.Click, K12.Click, K13.Click, K14.Click, K15.Click
        Dim i As Integer = Convert.ToInt32(sender.Name.Substring(1))
        SKl.Text = $"设定按键-{lSN(i).Text}{vbCrLf}（按Esc取消）"
        SKl.Visible = True
        KeySi = i
        KeyS = True
    End Sub

    Private Sub ckSH_CheckedChanged(sender As Object, e As EventArgs) Handles ckSH.CheckedChanged
        If Not RDY Then Exit Sub
        For i = 0 To 9
            For j = 0 To 2
                lHINT(i, j).Visible = Not lHINT(i, j).Visible
            Next
        Next
    End Sub

    Private Sub cksN_CheckedChanged(sender As Object, e As EventArgs) Handles cksN.CheckedChanged
        If Not RDY Then Exit Sub
        For i = 6 To 15
            lSN(i).Visible = Not lSN(i).Visible
        Next
    End Sub

    Private Sub ckOld_CheckedChanged(sender As Object, e As EventArgs) Handles ckOld.CheckedChanged
        For i = 3 To 15
            If i <> 5 Then
                tKey(i).Visible = Not tKey(i).Visible
            End If
        Next
        SN3.Visible = Not SN3.Visible
        SN4.Visible = Not SN4.Visible
        P3.Visible = Not P3.Visible
        P4.Visible = Not P4.Visible
        If ckOld.Checked Then
            Ls0.Text = vbNullString
            Ls1.Text = vbNullString
        Else
            Ls0.Text = tKey(3).Text
            Ls1.Text = tKey(4).Text
        End If
        SK = {"Q", "W", "E", "D", "F", "R", "Y", "V", "G", "C", "X", "Z", "T", "F", "D", "B"}
        For i = 0 To 15
            tKey(i).Text = SK(i)
        Next
        pSi = {-1, -1}
        Bs0.BackgroundImage = My.Resources.empty_skill
        Bs1.BackgroundImage = My.Resources.empty_skill
    End Sub

    Private Sub ckNoCD_CheckedChanged(sender As Object, e As EventArgs) Handles ckNoCD.CheckedChanged
        'ckAS.Enabled = Not ckAS.Enabled
    End Sub

    Private Sub Bitem_Click(sender As Object, e As EventArgs) Handles Bitem.Click
        MessageBox.Show("敬请期待")
    End Sub

End Class