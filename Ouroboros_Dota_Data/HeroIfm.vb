Imports System.IO
Imports System.Data.SQLite

Public Class HeroIfm
    Public hn As String
    Dim H As DataRow
    Dim pa As Integer
    Dim lB() As Label
    Dim rule As String = "------------------------------------------------------------"
    WithEvents wb As New WebBrowser
    Dim ilMAX As New ImageList

    Private Sub HeroIfm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If File.Exists("pic\hero\" & hn & ".png") Then
            pH.Image = Image.FromFile("pic\hero\" & hn & ".png")
        Else
            pH.Image = My.Resources.img_uk_h
        End If
        lHYPE.Text = DicV($"NPC_DOTA_HERO_{hn.ToUpper}_HYPE")
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cdH As SQLiteCommand = New SQLiteCommand("SELECT * FROM hero WHERE hn='" & hn & "'", cn)
        Dim drH As SQLiteDataReader = cdH.ExecuteReader()
        Dim dtH As New DataTable
        dtH.Load(drH)
        drH.Close()
        H = dtH(0)
        Text = H("hnc").ToString
        lHN.Text = Text
        lDIFF.Text = "难度" & H("diff").ToString
        Select Case H("cap")
            Case 0
                lCAP.Text = "近战"
            Case 1
                lCAP.Text = "远程"
        End Select
        Dim rs As String = vbNullString
        For i = 1 To 9
            If H(saR(i)) > 0 Then
                rs &= "  " & saRC(i) & H(saR(i))
            End If
        Next
        lR.Text = rs.Substring(2)
        pa = H("prim")
        Select Case pa
            Case 0
                pSTR.Image = My.Resources.icon_str_p
            Case 1
                pAGI.Image = My.Resources.icon_agi_p
            Case 2
                pINT.Image = My.Resources.icon_int_p
        End Select
        lSTR.Text = H("strb").ToString & " + " & Math.Round(Convert.ToDecimal(H("strg")), 2).ToString
        lAGI.Text = H("agib").ToString & " + " & Math.Round(Convert.ToDecimal(H("agig")), 2).ToString
        lINT.Text = H("intb").ToString & " + " & Math.Round(Convert.ToDecimal(H("intg")), 2).ToString
        lATK.Text = H("amin").ToString & " ~ " & H("amax").ToString
        lAMR.Text = Math.Round(Convert.ToDecimal(H("amr"))).ToString
        lMOV.Text = H("mov").ToString & "(" & H("turn") & "s)"
        Dim cdA As SQLiteCommand = New SQLiteCommand("SELECT * FROM ablt WHERE aid IN (" & H("a").ToString & ")", cn)
        Dim drA As SQLiteDataReader = cdA.ExecuteReader()
        Dim dtA As New DataTable
        dtA.Load(drA)
        drA.Close()
        Dim a() As String = H("a").ToString.Split(","c)
        For i = 0 To a.GetUpperBound(0)
            Dim rA As DataRow = dtA.Select("aid=" & a(i))(0)
            With rA
                Dim an As String = .Item("an").ToString.ToUpper
                Dim tp As New TabPage
                tp.Name = "tpA" & i.ToString
                If DicCK("DOTA_TOOLTIP_ABILITY_" & an) Then
                    tp.Text = DicV("DOTA_TOOLTIP_ABILITY_" & an)
                Else
                    Continue For
                End If
                Dim tD As New RichTextBox
                tD.BorderStyle = BorderStyle.None
                tD.ReadOnly = True
                tD.ScrollBars = RichTextBoxScrollBars.Vertical
                tD.Location = rtAdes.Location
                tD.Size = rtAdes.Size
                tabAddCrl(tp, rA, "amc", pMC, lMC)
                tabAddCrl(tp, rA, "acd", pCD, lCD)
                Dim l3 As New Label
                l3.Location = lL.Location
                l3.Size = lL.Size
                l3.TextAlign = ContentAlignment.MiddleLeft
                l3.ForeColor = Color.Blue
                tp.Controls.Add(tD)
                tp.Controls.Add(l3)
                tcA.TabPages.Add(tp)
                Dim sAG As String = "技能："
                Dim bh() As String = .Item("abh").ToString.Split(","c)
                For j = 0 To bh.GetUpperBound(0)
                    Dim s As String = bh(j).Replace("_"c, vbNullString)
                    If s = "UNITTARGET" Then s = "TARGET"
                    If DicCK("DOTA_TOOLTIP_ABILITY_" & s) Then sAG &= DicV("DOTA_TOOLTIP_ABILITY_" & s) & "，"
                Next
                If sAG = "技能：" Then
                    sAG = vbNullString
                Else
                    sAG = sAG.Substring(0, sAG.Length - 1)
                End If
                If (Not IsDBNull(.Item("autm"))) AndAlso .Item("autm") <> "CUSTOM" Then
                    Dim auk As String = vbNullString
                    Dim utm() As String = .Item("autm").ToString.Split(","c)
                    Dim utp() As String = .Item("autp").ToString.Split(","c)
                    If utm.Contains("BOTH") OrElse (utm.Contains("ENEMY") AndAlso utm.Contains("FRIENDLY")) Then
                        auk = vbNullString
                    ElseIf utm.Contains("ENEMY") Then
                        auk = "ENEMY"
                    ElseIf utm.Contains("FRIENDLY") Then
                        auk = "ALLIED"
                    End If
                    If utp.Contains("HERO") AndAlso (utp.Contains("BASIC") OrElse utp.Contains("CREEP")) Then
                        auk &= "UNITS"
                    ElseIf utp.Contains("HERO") Then
                        If auk = vbNullString Then
                            auk = "ALL_HEROES"
                        ElseIf auk = "ENEMY" Then
                            auk &= "HERO"
                        Else
                            auk &= "HEROES"
                        End If
                    ElseIf utp.Contains("BASIC") OrElse utp.Contains("CREEP") Then
                        auk &= "CREEPS"
                    ElseIf utp.Contains("TREE") Then
                        autk = "TREES"
                    End If
                    If utp.Contains("BUILDING") Then auk &= "ANDBUILDINGS"
                    '目标的处理
                    Dim au As String = vbNullString
                    If DicCK("DOTA_TOOLTIP_TARGETING_" & auk) Then
                        au = DicV("DOTA_TOOLTIP_TARGETING_" & auk)
                    Else
                        au = auk ' "#目标字符串读取错误#"
                    End If
                    sAG &= vbCrLf & "影响：" & au
                End If
                If Not IsDBNull(.Item("audt")) Then
                    Select Case .Item("audt").ToString
                        Case "PHYSICAL"
                            sAG &= vbCrLf & "伤害类型：物理"
                        Case "MAGICAL"
                            sAG &= vbCrLf & "伤害类型：魔法"
                        Case "PURE"
                            sAG &= vbCrLf & "伤害类型：纯粹"
                        Case Else
                            sAG &= vbCrLf & "伤害类型：其他"
                    End Select
                End If
                If Not IsDBNull(.Item("sit")) Then
                    Select Case .Item("sit").ToString.Split("_").Last
                        Case "YES"
                            sAG &= vbCrLf & "无视魔免：是"
                        Case "NO"
                            sAG &= vbCrLf & "无视魔免：否"
                    End Select
                End If
                If Not IsDBNull(.Item("sdt")) Then
                    Select Case .Item("sdt").ToString
                        Case "NO"
                            sAG &= vbCrLf & "能否驱散：无法驱散"
                        Case "YES"
                            sAG &= vbCrLf & "能否驱散：可以驱散"
                        Case "YES_STRONG"
                            sAG &= vbCrLf & "能否驱散：仅强驱散"
                    End Select
                End If
                'If sAG <> vbNullString Then
                '    sAG &= vbCrLf
                'End If
                Dim spc(-1)() As String '技能独特属性（只读取第一个）
                For j = 1 To 20
                    If IsDBNull(.Item("s" & j.ToString)) Then
                        Exit For
                    Else
                        ReDim Preserve spc(j - 1)
                        spc(j - 1) = .Item("s" & j.ToString).ToString.Split(";"c)(0).Split(":"c)
                    End If
                Next
                Dim sDS As String = vbNullString
                If DicCK("DOTA_TOOLTIP_ABILITY_" & an & "_DESCRIPTION") Then
                    sDS = DicV("DOTA_TOOLTIP_ABILITY_" & an & "_DESCRIPTION").Replace("\n", vbCrLf).Replace("%%", "%")
                End If
                Dim sNT As String = vbNullString
                For j = 0 To 5
                    Dim kNT As String = "DOTA_TOOLTIP_ABILITY_" & an & "_NOTE" & j.ToString
                    If DicCK(kNT) Then sNT &= DicV(kNT) & vbCrLf
                Next
                If sNT <> vbNullString Then sNT = rule & vbCrLf & sNT.Substring(0, sNT.Length - 2) & vbCrLf & rule
                Dim sSP As String = vbNullString
                For j = 0 To spc.GetUpperBound(0)
                    sDS = sDS.Replace("%" & spc(j)(0) & "%", spc(j)(1).Replace(" "c, "/"c))
                    Dim sDK As String = "DOTA_TOOLTIP_ABILITY_" & an & "_" & spc(j)(0).ToUpper
                    If DicCK(sDK) Then
                        Dim sDV As String = DicV(sDK)
                        If sDV.First = "%"c Then
                            sDV = sDV.Substring(1)
                            spc(j)(1) = spc(j)(1).Replace(" ", "% ") & "%"
                        End If
                        sSP &= sDV & spc(j)(1).Replace(" ", " / ") & vbCrLf
                        'If Not sDS.Contains(vbCrLf & vbCrLf) Then sSP = vbCrLf & sSP
                    End If
                Next
                tD.Text = sAG & vbCrLf & sDS & vbCrLf & sNT & vbCrLf & sSP
                'tD.Text = sAG & vbCrLf & sDS & vbCrLf & rule & vbCrLf & sNT & vbCrLf & rule & vbCrLf & sSP
                l3.Text = DicV("DOTA_TOOLTIP_ABILITY_" & an & "_LORE")
            End With
        Next
        tcA.TabPages.RemoveAt(0)
        Dim cdB As SQLiteCommand = New SQLiteCommand("SELECT * FROM ablt WHERE aid IN (" & H("b").ToString & ")", cn)
        Dim drB As SQLiteDataReader = cdB.ExecuteReader()
        Dim dtB As New DataTable
        dtB.Load(drB)
        drB.Close()
        lB = {lB0, lB1, lB2, lB3, lB4, lB5, lB6, lB7}
        Dim b() As String = H("b").ToString.Split(","c)
        For i = 0 To b.GetUpperBound(0)
            Dim r As DataRow = dtB.Select($"aid={b(i)}")(0)
            Dim bs0 As String = r("anc")
            If bs0.Contains("{") AndAlso bs0.Contains("}") Then '处理字符串中的插值
                Dim ss As String = bs0.Substring(bs0.IndexOf("{") + 1, bs0.IndexOf("}") - bs0.IndexOf("{") - 1)
                Dim vn As String = ss.Split(":"c)(1) '插值变量名
                For j = 1 To 25
                    If IsDBNull(r($"s{j}")) Then Exit For
                    Dim sa As String() = r($"s{j}").ToString.Split(";"c)(0).Split(":"c)
                    If sa(0) = vn Then
                        bs0 = bs0.Replace($"{{{ss}}}", sa(1))
                    End If
                Next
            End If
            lB(i).Text = bs0
        Next
        Call tbLV_ValueChanged(Nothing, Nothing)
        Application.DoEvents()
        wb.ScriptErrorsSuppressed = True
        wb.Url = New Uri($"http://dotamax.com/hero/detail/{hn}/")
    End Sub

    Private Sub lHN_Click(sender As Object, e As EventArgs) Handles lHN.Click, pH.Click
        MessageBox.Show(DicV($"NPC_DOTA_HERO_{hn.ToUpper}_BIO"), H("hnc").ToString)
    End Sub

    Private Function numSimp(ByVal ns As String, Optional ByVal sc As Char = " "c) As String
        Dim nA() As String = ns.Split(sc)
        Dim n(nA.GetUpperBound(0)) As Integer
        For i = 0 To n.GetUpperBound(0)
            n(i) = Convert.ToInt32(nA(i))
            nA(i) = n(i).ToString
        Next
        If n.Sum = n(0) * n.Length Then
            Return nA(0)
        Else
            Return Join(nA, "/")
        End If
    End Function

    Private Sub tabAddCrl(ByVal tp As TabPage, ByVal dr As DataRow, ByVal s As String, ByVal p As PictureBox, ByVal l As Label)
        Dim nS() As String = dr(s).ToString.Split(" "c)
        Dim n(nS.GetUpperBound(0)) As Decimal
        For j = 0 To nS.GetUpperBound(0)
            n(j) = Convert.ToDecimal(nS(j))
            nS(j) = n(j).ToString
        Next
        If n.Sum > 0 Then
            Dim p1 As New PictureBox
            p1.Location = p.Location
            p1.Size = p.Size
            p1.Image = p.Image
            Dim l1 As New Label
            l1.Location = l.Location
            l1.Size = l.Size
            l1.TextAlign = ContentAlignment.MiddleLeft
            l1.Font = New Font(Font.FontFamily, 12)
            If n.Sum = n(0) * n.Length Then
                l1.Text = n(0).ToString
            Else
                l1.Text = Join(nS, "/")
            End If
            tp.Controls.Add(p1)
            tp.Controls.Add(l1)
        End If
    End Sub

    Private Sub tbLV_ValueChanged(sender As Object, e As EventArgs) Handles tbLV.ValueChanged
        Dim lv As Integer = tbLV.Value - 1
        lHL.Text = $"{Text}[等级{tbLV.Value,2}]"
        Dim str, agi, int, amin, amax, hp, mp, mov As Integer
        Dim hpr, mpr, amr, dmgm, bat, ias, samp, mres As Decimal
        str = H("strb") + lv * H("strg")
        agi = H("agib") + lv * H("agig")
        int = H("intb") + lv * H("intg")
        Dim p() As Integer = {str, agi, int}
        '攻击力
        amin = H("amin") + p(pa)
        amax = H("amax") + p(pa)
        'HP和MP
        hp = 200 + (str * 20) '* 18 * IIf(pa = 0, 1.25, 1)
        mp = 75 + (int * 12) '* 12 * IIf(pa = 2, 1.25, 1)
        hpr = Math.Round(H("hpr") + str * 0.1, 2)
        mpr = Math.Round(H("mpr") + int * 0.05, 2)
        pHP.Width = plP.Width * hp / (hp + mp)
        pHP.Text = $"{hp}{vbCrLf}(+{hpr})"
        pMP.Width = plP.Width - pHP.Width
        pMP.Text = $"{mp}{vbCrLf}({mpr}+)"

        '攻速和攻击间隔
        'ias = 170 / H("bat") + agi * IIf(pa = 1, 1.25, 1) '1Atks(1.25)
        ias = 170 / H("bat") + agi
        bat = Math.Round(H("bat") * 100 / ias, 2) 'bat≠1.7的有问题
        '与每秒攻击次数的差异：(1.7-bat)/bat
        ias = Math.Round(ias, 0)

        '护甲和伤害系数，伤害系数有细微差别
        'amr = H("amr") + agi * 0.16 * IIf(pa = 1, 1.25, 1) '0.16Amr(0.2)
        amr = H("amr") + agi / 7 'wiki说每点敏捷提供0.17护甲，这里使用每6点敏捷加1点护甲的方式
        'dmgm = Math.Round(amr * 5 / (1 + 0.05 * Math.Abs(amr)), 0) '物理抗性 = 0.05 × 护甲 ÷ (1 + 0.05 × |护甲|)
        'dmgm = Math.Round(amr * 5.2 / (0.9 + 0.048 * Math.Abs(amr)))
        dmgm = Math.Round(600 * amr / (6 * amr + 100), 2)
        amr = Math.Round(amr, 1)
        '魔法抗性：0.08%mRes(0.1%)有细微差别
        mres = H("res") 'Math.Round(100 - 100 * (1 - H("res") / 100) * (1 - int * IIf(pa = 0, 1.25, 1) / 1250), 0) '(1-(1-25%)*(1-12.4%))默认25%和属性加成
        '技能伤害增强：0.07%sAmp(0.087%)
        'samp = Math.Round(int * 0.07 * IIf(pa = 2, 1.25, 1), 2)
        '移速：0.05%Mov(0.062%)
        mov = H("mov")
        'mov = Math.Round(mov + mov * agi * 0.05 * IIf(pa = 1, 1.25, 1) / 100, 0)
        'lHS.Text = $"力量：{str.ToString.PadRight(3)} 敏捷：{agi.ToString.PadRight(3)} 智力：{int.ToString.PadRight(3)}  移速：{mov.ToString}{vbCrLf}攻击力：{amin.ToString.PadLeft(3)} - {amax.ToString.PadRight(3)}   攻速：{ias}({bat}s){vbCrLf}射程：{H("rng")}{IIf(H("cap") = 0, "      ", $"({H("ps")})".PadRight(6))}     攻击前摇：{H("aap")}s{vbCrLf}护甲：{amr.ToString.PadRight(5)}         物理抗性：{dmgm}%{vbCrLf}技能增强：{(samp.ToString & "%").PadRight(5)}     魔法抗性：{mres.ToString}%{vbCrLf}移速：{mov.ToString.PadRight(3)}           视野：{H("vsd").ToString.PadLeft(4)}/{H("vsn").ToString.PadRight(4)}"
        lHS.Text = $"力量：{str.ToString.PadRight(3)} 敏捷：{agi.ToString.PadRight(3)} 智力：{int.ToString.PadRight(3)}{vbCrLf}攻击力：{amin.ToString.PadLeft(3)} - {amax.ToString.PadRight(3)}   攻速：{ias}({bat}s){vbCrLf}射程：{H("rng")}{IIf(H("cap") = 0, "      ", $"({H("ps")})".PadRight(6))}     攻击前摇：{H("aap")}s{vbCrLf}护甲：{amr.ToString.PadRight(5)}         物理抗性：{dmgm}%{vbCrLf}技能增强：{(samp.ToString & "%").PadRight(5)}     魔法抗性：{mres.ToString}%{vbCrLf}移速：{mov.ToString.PadRight(3)}           视野：{H("vsd").ToString.PadLeft(4)}/{H("vsn").ToString.PadRight(4)}"
    End Sub

    Private Sub wbDC() Handles wb.DocumentCompleted
        Dim dtR(4) As DataTable
        Dim c As HtmlElementCollection = wb.Document.GetElementsByTagName("table")
        Dim dtI As Integer = -1
        For Each e As HtmlElement In c
            Dim t As String = e.GetAttribute("CLASSNAME")
            If t.Contains("table-hover") Then
                dtI += 1
                dtR(dtI) = New DataTable
                Dim eTH As HtmlElementCollection = e.GetElementsByTagName("thead")(0).GetElementsByTagName("th")
                For dhI = 0 To eTH.Count - 1
                    dtR(dtI).Columns.Add(eTH(dhI).InnerText)
                Next
                dtR(dtI).Columns.Add("img")
                'MsgBox(dtR(dtI).Columns.Count)
                Dim eTR As HtmlElementCollection = e.GetElementsByTagName("tbody")(0).GetElementsByTagName("tr")
                For drI = 0 To eTR.Count - 1
                    dtR(dtI).Rows.Add()
                    Dim eTD As HtmlElementCollection = eTR(drI).GetElementsByTagName("td")
                    For dcI = 0 To eTD.Count - 1
                        dtR(dtI)(drI)(dcI) = eTD(dcI).InnerText
                    Next
                    Dim src As String = eTD(0).GetElementsByTagName("img")(0).GetAttribute("src").Split("/"c).Last.Split("."c).First
                    Dim srcA() As String = src.Split("_"c)
                    src = vbNullString
                    For j = 0 To srcA.Length - 2
                        src &= "_" & srcA(j)
                    Next
                    dtR(dtI)(drI)("img") = src.Substring(1)
                Next
            End If
        Next
        wb.Dispose()
        For i = 0 To 4
            For j = 0 To dtR(i).Rows.Count - 1
                Dim imgN As String = dtR(i)(j)("img")
                If File.Exists($"pic\hero\{imgN}.png") Then
                    ilMAX.Images.Add(Image.FromFile($"pic\hero\{imgN}.png"))
                ElseIf File.Exists($"pic\item\{imgN}.png") Then
                    ilMAX.Images.Add(Image.FromFile($"pic\item\{imgN}.png"))
                Else
                    'MsgBox(imgN)
                    ilMAX.Images.Add(My.Resources.img_uk_h)
                End If
            Next
        Next
        ilMAX.ImageSize = New Size(31, 22)
        lvMAX.LargeImageList = ilMAX
        lvMAX.SmallImageList = ilMAX
        Dim k As Integer = 0
        For i = 0 To 4
            lvMAX.Groups(i).Header = lvMAX.Groups(i).Header.Replace("{0}", H("hnc").ToString)
            For j = 0 To dtR(i).Rows.Count - 1
                lvMAX.Items.Add(dtR(i)(j)(0), k)
                lvMAX.Items(k).Group = lvMAX.Groups(i)
                k += 1
            Next
        Next

    End Sub

End Class

'Private Sub tbLV_ValueChanged(sender As Object, e As EventArgs) Handles tbLV.ValueChanged
'    Dim lv As Integer = tbLV.Value - 1
'    lHL.Text = $"{Text}[等级{tbLV.Value,2}]"
'    Dim str, agi, int, amin, amax, hp, mp, mov As Integer
'    Dim hpr, mpr, amr, dmgm, bat, ias, samp, mres As Decimal
'    str = H("strb") + lv * H("strg")
'    agi = H("agib") + lv * H("agig")
'    int = H("intb") + lv * H("intg")
'    Dim p() As Integer = {str, agi, int}
'    '攻击力
'    amin = H("amin") + p(pa)
'    amax = H("amax") + p(pa)
'    'HP和MP
'    hp = 200 + str * 18 * IIf(pa = 0, 1.25, 1) '18HP(22.5)
'    mp = 75 + int * 12 * IIf(pa = 2, 1.25, 1) '12MP(15)
'    hpr = Math.Round(H("hpr") + str * 0.1, 2)
'    mpr = Math.Round(H("mpr") + int * 0.05, 2)
'    pHP.Width = plP.Width * hp / (hp + mp)
'    pHP.Text = $"{hp}{vbCrLf}(+{hpr})"
'    pMP.Width = plP.Width - pHP.Width
'    pMP.Text = $"{mp}{vbCrLf}({mpr}+)"
'    '攻速和攻击间隔
'    ias = 170 / H("bat") + agi * IIf(pa = 1, 1.25, 1) '1Atks(1.25)
'    bat = Math.Round(H("bat") * 100 / ias, 2) 'bat≠1.7的有问题
'    '与每秒攻击次数的差异：(1.7-bat)/bat
'    ias = Math.Round(ias, 0)
'    '护甲和伤害系数，伤害系数有细微差别
'    amr = H("amr") + agi * 0.16 * IIf(pa = 1, 1.25, 1) '0.16Amr(0.2)
'    'dmgm = Math.Round(amr * 5 / (1 + 0.05 * Math.Abs(amr)), 0) '物理抗性 = 0.05 × 护甲 ÷ (1 + 0.05 × |护甲|)
'    dmgm = Math.Round(amr * 5.2 / (0.9 + 0.048 * Math.Abs(amr)))
'    amr = Math.Round(amr, 1)
'    '魔法抗性：0.08%mRes(0.1%)有细微差别
'    mres = Math.Round(100 - 100 * (1 - H("res") / 100) * (1 - int * IIf(pa = 0, 1.25, 1) / 1250), 0) '(1-(1-25%)*(1-12.4%))默认25%和属性加成
'    '技能伤害增强：0.07%sAmp(0.087%)
'    samp = Math.Round(int * 0.07 * IIf(pa = 2, 1.25, 1), 2)
'    '移速：0.05%Mov(0.062%)
'    mov = H("mov")
'    mov = Math.Round(mov + mov * agi * 0.05 * IIf(pa = 1, 1.25, 1) / 100, 0)
'    'lHS.Text = $"力量：{str.ToString.PadRight(3)} 敏捷：{agi.ToString.PadRight(3)} 智力：{int.ToString.PadRight(3)}  移速：{mov.ToString}{vbCrLf}攻击力：{amin.ToString.PadLeft(3)} - {amax.ToString.PadRight(3)}   攻速：{ias}({bat}s){vbCrLf}射程：{H("rng")}{IIf(H("cap") = 0, "      ", $"({H("ps")})".PadRight(6))}     攻击前摇：{H("aap")}s{vbCrLf}护甲：{amr.ToString.PadRight(5)}         物理抗性：{dmgm}%{vbCrLf}技能增强：{(samp.ToString & "%").PadRight(5)}     魔法抗性：{mres.ToString}%{vbCrLf}移速：{mov.ToString.PadRight(3)}           视野：{H("vsd").ToString.PadLeft(4)}/{H("vsn").ToString.PadRight(4)}"
'    lHS.Text = $"力量：{str.ToString.PadRight(3)} 敏捷：{agi.ToString.PadRight(3)} 智力：{int.ToString.PadRight(3)}{vbCrLf}攻击力：{amin.ToString.PadLeft(3)} - {amax.ToString.PadRight(3)}   攻速：{ias}({bat}s){vbCrLf}射程：{H("rng")}{IIf(H("cap") = 0, "      ", $"({H("ps")})".PadRight(6))}     攻击前摇：{H("aap")}s{vbCrLf}护甲：{amr.ToString.PadRight(5)}         物理抗性：{dmgm}%{vbCrLf}技能增强：{(samp.ToString & "%").PadRight(5)}     魔法抗性：{mres.ToString}%{vbCrLf}移速：{mov.ToString.PadRight(3)}           视野：{H("vsd").ToString.PadLeft(4)}/{H("vsn").ToString.PadRight(4)}"
'End Sub
