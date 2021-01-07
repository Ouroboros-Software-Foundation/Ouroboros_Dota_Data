Imports System.IO
Imports Microsoft.Win32
Imports System.Data.SQLite
Imports SteamDatabase

Public Class Upd
    Dim dAf As New Dictionary(Of String, String)
    Dim dHf As New Dictionary(Of String, String)
    Dim dHr As New Dictionary(Of String, String)
    Dim dUf As New Dictionary(Of String, String)
    Dim dIf As New Dictionary(Of String, String)
    Dim dcNI As New Dictionary(Of String, Integer) '物品名，级别
    Dim fp As String = vbNullString

    Private Sub Upd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists("config.ini") Then
            Dim sr As New StreamReader("config.ini")
            fp = sr.ReadLine
            sr.Close()
        Else
            Dim rcr As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Classes\dota2\shell\open\command")
            If Not IsNothing(rcr) Then
                fp = rcr.GetValue(String.Empty).ToString.Split(""""c)(1).Split("dota 2 beta")(0) & "dota 2 beta"
                Dim sr As New StreamWriter("config.ini")
                sr.Write(fp)
                sr.Close()
            End If
        End If
        DicAdd()
        If cn.State = ConnectionState.Closed Then cn.Open()
        KeyPreview = True
        tFP.Text = fp
        picI()
    End Sub

    Private Sub bOFD_Click(sender As Object, e As EventArgs) Handles bOFD.Click
        Dim fbd As New FolderBrowserDialog
        With fbd
            .Description = "请选择dota 2 beta文件夹"
            .ShowNewFolderButton = False
            Dim dr As DialogResult = .ShowDialog()
            If dr = DialogResult.OK Then
                fp = .SelectedPath
            End If
        End With
        tFP.Text = fp
    End Sub

    Private Sub bUPD_Click(sender As Object, e As EventArgs) Handles bUPD.Click
        If fp = vbNullString Then
            MessageBox.Show("请选择dota2路径", "提示")
            Exit Sub
        End If
        Dim fNPC As String = fp & "\game\dota\scripts\npc\"
        Dim aFNd() As String = {fNPC & "npc_abilities.txt", fNPC & "npc_heroes.txt", fNPC & "npc_units.txt", fp & "\game\dota\pak01_dir.vpk"} ', fp & "\game\dota\resource\dota_english.txt", fp & "\game\dota\resource\dota_schinese.txt"}
        For i = 0 To aFNd.Length - 1
            If Not File.Exists(aFNd(i)) Then
                MessageBox.Show($"找不到文件{aFNd(i)}，请重新选择dota2路径")
                Exit Sub
            End If
        Next
        bOFD.Enabled = False
        bUPD.Enabled = False
        Dim sw As New StreamWriter("config.ini")
        sw.Write(fp)
        sw.Close()
        If Not Directory.Exists("file\") Then Directory.CreateDirectory("file\")
        If Not Directory.Exists("pic\") Then Directory.CreateDirectory("pic\")
        tPG.AppendText($"[{Now}]正在更新数据文件{vbCrLf}")
        Dim aFN() As String = {"npc_abilities.txt", "npc_heroes.txt", "npc_units.txt"}
        For i = 0 To aFN.Length - 1
            File.Copy(aFNd(i), "file\" & aFN(i), True)
            tPG.AppendText($"[{Now}]{aFN(i)}已更新{vbCrLf}")
        Next
        Dim fVPK() As String = {"resource/localization/abilities_english.txt", "resource/localization/abilities_schinese.txt", "resource/localization/dota_english.txt", "resource/localization/dota_schinese.txt", "resource/localization/hero_lore_english.txt", "resource/localization/hero_lore_schinese.txt", "scripts/shops.txt", "scripts/npc/items.txt", "scripts/npc/neutral_items.txt"}
        Dim VPK As New ValvePak.Package
        VPK.Read(fp & "\game\dota\pak01_dir.vpk")
        tPG.AppendText($"[{Now}]game\dota\pak01_dir.vpk读取完毕{vbCrLf}")
        For i = 0 To fVPK.Length - 1
            Dim b As Byte() = Nothing
            VPK.ReadEntry(VPK.FindEntry(fVPK(i)), b)
            Dim fs As New FileStream($"file\{fVPK(i).Split("/"c).Last}", FileMode.Create)
            Dim bw As BinaryWriter = New BinaryWriter(fs)
            bw.Write(b)
            bw.Close()
            fs.Close()
            tPG.AppendText($"[{Now}]{fVPK(i).Split("/"c).Last}已更新{vbCrLf}")
        Next
        VPK.Dispose()
        LangDic(dLen, "dota_english", False)
        LangDic(dLen, "abilities_english")
        LangDic(dLen, "hero_lore_english")
        LangDic(dLchs, "dota_schinese", False)
        LangDic(dLchs, "abilities_schinese")
        LangDic(dLchs, "hero_lore_schinese")
        tPG.AppendText($"[{Now}]重建语言辞典完成{vbCrLf}")
        Dim dbt As SQLiteTransaction = cn.BeginTransaction(IsolationLevel.Serializable) '开始事务
        tPG.AppendText($"[{Now}]技能信息 更新开始{vbCrLf}")
        rdABLT()
        tPG.AppendText($"[{Now}]技能信息 更新完成{vbCrLf}[{Now}]英雄信息 更新开始{vbCrLf}")
        rdHERO()
        tPG.AppendText($"[{Now}]英雄信息 更新完成{vbCrLf}[{Now}]单位信息 更新开始{vbCrLf}")
        rdUNIT()
        tPG.AppendText($"[{Now}]单位信息 更新完成{vbCrLf}[{Now}]中立物品信息 更新开始{vbCrLf}")
        rdITEMn()
        tPG.AppendText($"[{Now}]中立物品信息 更新完成{vbCrLf}[{Now}]物品信息 更新开始{vbCrLf}")
        rdITEM()
        tPG.AppendText($"[{Now}]物品信息 更新完成{vbCrLf}")
        tPG.AppendText($"[{Now}]数据更新完成{vbCrLf}[{Now}]英雄图片 更新开始{vbCrLf}")
        picH()
        tPG.AppendText($"[{Now}]英雄图片 更新完成{vbCrLf}[{Now}]物品图片 更新开始{vbCrLf}")
        picI()
        tPG.AppendText($"[{Now}]物品图片 更新完成{vbCrLf}")
        Try
            dbt.Commit()
            MessageBox.Show("更新完成，请重启程序", "更新成功")
            Application.Exit()
        Catch ex As Exception
            MessageBox.Show($"更新失败，请将错误信息发送给开发者以便修改BUG{vbCrLf}{ex.ToString}", "更新失败")
            dbt.Rollback()
        Finally
            bOFD.Enabled = True
            bUPD.Enabled = True
        End Try
    End Sub

    Private Sub DicAdd()
        dAf.Add("ID", "aid")
        dAf.Add("HasScepterUpgrade", "hsu")
        dAf.Add("AbilityCastRange", "acr")
        dAf.Add("AbilityCastRangeBuffer", "acrb")
        dAf.Add("AbilityCastPoint", "acp")
        dAf.Add("AbilityChannelTime", "actd")
        dAf.Add("AbilityDuration", "actd")
        dAf.Add("AbilityCooldown", "acd")
        dAf.Add("AbilityDamage", "ad")
        dAf.Add("AbilityManaCost", "amc")
        dHf.Add("HeroID", "hid")
        dHf.Add("Complexity", "diff")
        dHf.Add("new_player_enable", "npe")
        dHf.Add("workshop_guide_name", "hne")
        dHf.Add("Legs", "leg")
        dHf.Add("ArmorPhysical", "amr")
        dHf.Add("MagicalResistance", "res")
        dHf.Add("AttackDamageMin", "amin")
        dHf.Add("AttackDamageMax", "amax")
        dHf.Add("AttackRate", "bat")
        dHf.Add("AttackAnimationPoint", "aap")
        dHf.Add("AttackAcquisitionRange", "aar")
        dHf.Add("AttackRange", "rng")
        dHf.Add("ProjectileSpeed", "ps")
        dHf.Add("AttributeBaseStrength", "strb")
        dHf.Add("AttributeStrengthGain", "strg")
        dHf.Add("AttributeBaseAgility", "agib")
        dHf.Add("AttributeAgilityGain", "agig")
        dHf.Add("AttributeBaseIntelligence", "intb")
        dHf.Add("AttributeIntelligenceGain", "intg")
        dHf.Add("MovementSpeed", "mov")
        dHf.Add("MovementTurnRate", "turn")
        dHf.Add("StatusHealthRegen", "hpr")
        dHf.Add("StatusManaRegen", "mpr")
        dHf.Add("VisionDaytimeRange", "vsd")
        dHf.Add("VisionNighttimeRange", "vsn")
        dHr.Add("Carry", "cryl")
        dHr.Add("Disabler", "disl")
        dHr.Add("Initiator", "intl")
        dHr.Add("Jungler", "jgll")
        dHr.Add("Support", "sptl")
        dHr.Add("Durable", "drbl")
        dHr.Add("Nuker", "nukl")
        dHr.Add("Pusher", "pshl")
        dHr.Add("Escape", "espl")
        dUf.Add("Level", "lvl")
        dUf.Add("IsAncient", "anct")
        dUf.Add("IsNeutralUnitType", "nut")
        dUf.Add("CanBeDominated", "cbd")
        dUf.Add("ArmorPhysical", "amr")
        dUf.Add("MagicalResistance", "res")
        dUf.Add("AttackDamageMin", "amin")
        dUf.Add("AttackDamageMax", "amax")
        dUf.Add("AttackRate", "bat")
        dUf.Add("AttackAnimationPoint", "aap")
        dUf.Add("AttackAcquisitionRange", "aar")
        dUf.Add("AttackRange", "rng")
        dUf.Add("ProjectileSpeed", "ps")
        dUf.Add("BountyXP", "xp")
        dUf.Add("BountyGoldMin", "gmin")
        dUf.Add("BountyGoldMax", "gmax")
        dUf.Add("MovementSpeed", "mov")
        dUf.Add("MovementTurnRate", "turn")
        dUf.Add("StatusHealth", "hp")
        dUf.Add("StatusHealthRegen", "hpr")
        dUf.Add("StatusMana", "mp")
        dUf.Add("StatusManaRegen", "mpr")
        dUf.Add("VisionDaytimeRange", "vsd")
        dUf.Add("VisionNighttimeRange", "vsn")
        dIf.Add("ID", "iid")
        dIf.Add("ItemIsNeutralDrop", "inil")
        dIf.Add("ItemCost", "ic")
        dIf.Add("ItemShopTags", "ist")
        dIf.Add("ItemQuality", "iq")
        dIf.Add("ItemSellable", "isl")
        dIf.Add("AbilityCastRange", "iacr")
        dIf.Add("AbilityCooldown", "iacd")
        dIf.Add("AbilityManaCost", "iamc")
    End Sub

    Private Sub rdABLT()
        Dim daA As SQLiteDataAdapter = New SQLiteDataAdapter("DELETE FROM ablt;SELECT * FROM ablt", cn)
        Dim dsA As New DataSet
        daA.Fill(dsA, "ablt")
        With dsA.Tables(0)
            Dim srA As New StreamReader("file\npc_abilities.txt")
            Do
            Loop Until srA.ReadLine.Replace(vbTab, vbNullString).Contains("""Version""")
            Dim n As Integer = 0 '技能序号  
            Do Until srA.EndOfStream
                Dim l As String = srA.ReadLine.Replace(vbTab, vbNullString).Replace(" ", vbNullString)
                'If l.Contains("}") Then Exit Do '全部技能读取完毕
                If l = vbNullString OrElse l.First = "/"c Then Continue Do '空行或注释行
                If l.First <> """"c Then Continue Do
                'If l.Contains("recipe") Then Continue Do
                Dim nA As String = l.Split(""""c)(1)
                .Rows.Add()
                .Rows(n)("an") = nA
                'Debug.Print(nA & vbCrLf)
                'If dC.ContainsKey("DOTA_TOOLTIP_ABILITY_" & nA.ToUpper) Then .Rows(n)("anc") = dC("DOTA_TOOLTIP_ABILITY_" & nA.ToUpper)
                .Rows(n)("anc") = DicV("DOTA_TOOLTIP_ABILITY_" & nA.ToUpper)
                srA.ReadLine() '读出{
                Do '单个技能逐行读取开始
                    Dim ll As String = srA.ReadLine.Replace(vbTab, vbNullString) '.Replace(" ", vbNullString)
                    If ll.Contains("}") Then Exit Do '单个技能读取完毕
                    'If ll = vbNullString OrElse ll.First <> """"c Then Continue Do
                    If ll = vbNullString OrElse (Not ll.Contains(""""c)) Then Continue Do
                    Dim m() As String = ll.Split(""""c)
                    If dAf.ContainsKey(m(1)) Then
                        .Rows(n)(dAf(m(1))) = Convert.ChangeType(m(3), .Columns(dAf(m(1))).DataType)
                    Else
                        Select Case m(1)
                            Case "AbilityType"
                                .Rows(n)("atp") = m(3).Substring(18)
                            Case "AbilityBehavior"
                                .Rows(n)("abh") = m(3).Replace("|"c, ","c).Replace(" ", vbNullString).Replace("DOTA_ABILITY_BEHAVIOR_", vbNullString)
                            Case "AbilityUnitTargetTeam"
                                .Rows(n)("autm") = m(3).Replace("|"c, ","c).Replace(" ", vbNullString).Replace("DOTA_UNIT_TARGET_TEAM_", vbNullString)
                            Case "AbilityUnitTargetType"
                                .Rows(n)("autp") = m(3).Replace("|"c, ","c).Replace(" ", vbNullString).Replace("DOTA_UNIT_TARGET_", vbNullString)
                            Case "AbilityUnitTargetFlags"
                                .Rows(n)("autf") = m(3).Replace("|"c, ","c).Replace(" ", vbNullString).Replace("DOTA_UNIT_TARGET_FLAG_", vbNullString)
                            Case "AbilityUnitDamageType"
                                .Rows(n)("audt") = m(3).Substring(12)
                            Case "SpellImmunityType"
                                .Rows(n)("sit") = m(3).Substring(15)
                            Case "SpellDispellableType"
                                .Rows(n)("sdt") = m(3).Substring(18)
                            Case "AbilitySpecial"  '技能独有属性
                                srA.ReadLine() '读出{
                                Do
                                    Dim ls As String = srA.ReadLine.Replace(vbTab, vbNullString) '.Replace(" ", vbNullString)
                                    If ls = vbNullString OrElse ls.First = "/"c Then Continue Do
                                    If ls.Contains("}") Then Exit Do '所有独有属性读取完毕
                                    'If ls.First <> """"c Then Continue Do
                                    If Not ls.Contains("""") Then Continue Do
                                    Dim sn() As String = ls.Split(""""c)
                                    If sn(0).Contains("//") Then Continue Do
                                    If Not IsNumeric(sn(1)) Then sn(1) = sn(1).Substring(0, sn(1).Length - 1)
                                    Dim ai As Integer = Convert.ToInt32(sn(1).Replace(""""c, vbNullString))
                                    srA.ReadLine()
                                    Do '单个特殊属性读取开始
                                        Dim lss As String = srA.ReadLine.Replace(vbTab, vbNullString) '.Replace(" ", vbNullString)
                                        If lss = vbNullString Then Continue Do
                                        If lss.Contains("}") Then Exit Do '单个独有属性读取完毕
                                        'If lss.First <> """"c Then Continue Do
                                        If Not ls.Contains("""") Then Continue Do
                                        Dim s() As String = lss.Split(""""c)
                                        If s(1) = "var_type" Then Continue Do ' OrElse s(1) = "LinkedSpecialBonus" OrElse s(1) = "LinkedSpecialBonusOperation"
                                        .Rows(n)("s" & ai) &= $";{s(1)}:{s(3)}"
                                    Loop
                                    .Rows(n)("s" & ai) = .Rows(n)("s" & ai).ToString.Substring(1)
                                Loop
                            Case "precache" '例外
                                Do
                                    Dim lp As String = srA.ReadLine.Replace(vbTab, vbNullString)
                                    If lp.Contains("}") Then Exit Do
                                Loop
                        End Select
                    End If
                Loop '单个技能逐行读取结束
                n += 1
            Loop '技能文件读取结束
            'Dim dlA() As String = {"default_attack", "attribute_bonus"} '不进表的技能名
            For i = .Rows.Count - 1 To 1 Step -1
                If IsDBNull(.Rows(i)("an")) Then Continue For
                'If IsDBNull(.Rows(i)("aid")) OrElse .Rows(i)("an") = "default_attack" OrElse .Rows(i)("an") = "attribute_bonus" Then
                'If IsDBNull(.Rows(i)("aid")) Then
                '    .Rows.RemoveAt(i)
                '    Continue For
                'End If
                For j = 0 To .Columns.Count - 1 '检查空值
                    If IsDBNull(.Rows(i)(j)) Then '检查是否为空
                        If Not IsDBNull(.Rows(0)(j)) Then '若有默认值
                            .Rows(i)(j) = .Rows(0)(j) '填充默认值
                        ElseIf .Columns(j).DataType <> String.Empty.GetType Then '数字型无默认值
                            .Rows(i)(j) = 0 '数字型无默认值填充0
                        End If
                    End If
                Next
            Next
            .Rows.RemoveAt(0)
        End With
        'DataGridView1.DataSource = dsA.Tables(0)
        Dim cb As New SQLiteCommandBuilder(daA)
        daA.Update(dsA.GetChanges, "ablt")
    End Sub

    Private Sub rdHERO()
        Dim daH As SQLiteDataAdapter = New SQLiteDataAdapter("DELETE FROM hero;SELECT * FROM hero", cn)
        Dim dsH As New DataSet
        daH.Fill(dsH, "hero")
        With dsH.Tables(0)
            Dim srH As New StreamReader("file\npc_heroes.txt")
            Do
            Loop Until srH.ReadLine.Replace(vbTab, vbNullString).Contains("""Version""")
            Dim n As Integer = 0 '英雄序号
            Do Until srH.EndOfStream
                Dim l As String = srH.ReadLine.Replace(vbTab, vbNullString).Replace(" ", vbNullString)
                If l = vbNullString OrElse l.First = "/"c Then Continue Do
                If l.Contains("}") Then Exit Do '全部英雄读取完毕
                If l.First <> """"c Then Continue Do
                Dim nH As String = l.Split(""""c)(1).Substring(14)
                .Rows.Add()
                .Rows(n)("hn") = nH
                'If dC.ContainsKey("NPC_DOTA_HERO_" & nH.ToUpper) Then .Rows(n)("hnc") = dC("NPC_DOTA_HERO_" & nH.ToUpper)
                .Rows(n)("hnc") = DicV("NPC_DOTA_HERO_" & nH.ToUpper)
                Dim r(), rl() As String
                Dim ha As String = vbNullString
                Dim hb As String = vbNullString
                srH.ReadLine() '读出{
                Do '英雄逐行读取开始
                    Dim ll As String = srH.ReadLine.Replace(vbTab, vbNullString).Replace(" ", vbNullString)
                    If ll.Contains("}") Then Exit Do '单个英雄读取完毕
                    If ll.Contains("{") Then '跳过无用内容
                        Dim b As Integer = 1
                        Do
                            Dim t As String = srH.ReadLine
                            If t.Contains("{") Then b += 1
                            If t.Contains("}") Then b -= 1
                            If b = 0 Then Exit Do
                        Loop
                    End If
                    If ll = vbNullString OrElse ll.First <> """"c Then Continue Do
                    Dim m() As String = ll.Split(""""c)
                    If dHf.ContainsKey(m(1)) Then
                        If m(3) = vbNullString Then Continue Do
                        .Rows(n)(dHf(m(1))) = Convert.ChangeType(m(3), .Columns(dHf(m(1))).DataType)
                    ElseIf m(1).Length > 7 AndAlso m(1).Substring(0, 7) = "Ability" AndAlso IsNumeric(m(1).Substring(7)) Then
                        If m(3) = vbNullString OrElse m(3) = "special_bonus_undefined" Then Continue Do
                        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT an,aid FROM ablt WHERE an=""" & m(3) & """", cn)
                        Dim dr As SQLiteDataReader = cd.ExecuteReader()
                        Dim dt As New DataTable
                        dt.Load(dr)
                        dr.Close()
                        Dim aid As Integer = dt(0)("aid")
                        If m(3).Length > 13 AndAlso m(3).Substring(0, 13) = "special_bonus" Then
                            hb &= "," & aid.ToString
                        Else
                            ha &= "," & aid.ToString
                        End If
                    Else
                        Select Case m(1)
                            Case "Team"
                                .Rows(n)("team") = IIf(m(3).ToUpper = "GOOD", 0, 1)
                            Case "CMEnabled"
                                .Rows(n)("cm") = IIf(m(3) = "1", True, False)
                            Case "AttackCapabilities"
                                Select Case m(3)
                                    Case "DOTA_UNIT_CAP_MELEE_ATTACK"
                                        .Rows(n)("cap") = 0
                                    Case "DOTA_UNIT_CAP_RANGED_ATTACK"
                                        .Rows(n)("cap") = 1
                                    Case Else
                                        .Rows(n)("cap") = -1
                                End Select
                            Case "AttributePrimary"
                                Select Case m(3)
                                    Case "DOTA_ATTRIBUTE_STRENGTH"
                                        .Rows(n)("prim") = 0
                                    Case "DOTA_ATTRIBUTE_AGILITY"
                                        .Rows(n)("prim") = 1
                                    Case "DOTA_ATTRIBUTE_INTELLECT"
                                        .Rows(n)("prim") = 2
                                End Select
                            Case "Role"
                                r = m(3).Split(","c)
                            Case "Rolelevels"
                                rl = m(3).Split(","c)
                                ReDim Preserve r(rl.Length - 1)
                                For i = 0 To rl.Length - 1
                                    .Rows(n)(dHr(r(i))) = Convert.ToInt32(rl(i))
                                Next
                        End Select
                    End If
                Loop '单个英雄主要信息逐行读取结束
                If ha <> vbNullString Then .Rows(n)("a") = ha.Substring(1)
                If hb <> vbNullString Then .Rows(n)("b") = hb.Substring(1)
                n += 1
            Loop '英雄文件读取结束
            'Dim dlH() As String = {"target_dummy"} '不进表的英雄名
            For i = .Rows.Count - 1 To 1 Step -1
                If .Rows(i)("hn") = "target_dummy" Then
                    .Rows.RemoveAt(i)
                    Continue For
                End If
                For j = 0 To .Columns.Count - 1 '检查空值
                    If IsDBNull(.Rows(i)(j)) Then '检查是否为空
                        If Not IsDBNull(.Rows(0)(j)) Then '若有默认值
                            .Rows(i)(j) = .Rows(0)(j) '填充默认值
                        ElseIf .Columns(j).DataType <> String.Empty.GetType Then '数字型无默认值
                            .Rows(i)(j) = 0 '数字型无默认值填充0
                        End If
                    End If
                Next
            Next
            .Rows.RemoveAt(0)
        End With
        Dim cb As New SQLiteCommandBuilder(daH)
        daH.Update(dsH.GetChanges, "hero")
    End Sub

    Private Sub rdUNIT()
        'bc,acap,mcap,cca,ccd
        Dim daU As SQLiteDataAdapter = New SQLiteDataAdapter("DELETE FROM unit;SELECT * FROM unit", cn)
        Dim dsU As New DataSet
        daU.Fill(dsU, "unit")
        With dsU.Tables(0)
            Dim srU As New StreamReader("file\npc_units.txt")
            Do
            Loop Until srU.ReadLine.Replace(vbTab, vbNullString).Contains("""Version""")
            Dim n As Integer = 0 '单位序号
            Do Until srU.EndOfStream
                Dim l As String = srU.ReadLine.Replace(vbTab, vbNullString)
                If l = vbNullString OrElse l.First = "/"c Then Continue Do
                If l.Contains("}") Then Exit Do '全部单位读取完毕
                If l.First <> """"c Then Continue Do
                Dim nU As String = l.Split(""""c)(1).Substring(9)
                .Rows.Add()
                .Rows(n)("uid") = n - 3
                .Rows(n)("un") = nU
                'If dC.ContainsKey("NPC_DOTA_" & nU.ToUpper) Then .Rows(n)("unc") = dC("NPC_DOTA_" & nU.ToUpper)
                .Rows(n)("unc") = DicV("NPC_DOTA_" & nU.ToUpper)
                Dim ua As String = vbNullString
                srU.ReadLine() '读出{
                Do '单位逐行读取开始
                    Dim ll As String = srU.ReadLine.Replace(vbTab, vbNullString)
                    If ll.Contains("}") Then Exit Do '单个英雄读取完毕
                    If ll = vbNullString OrElse ll.First <> """"c Then Continue Do
                    Dim m() As String = ll.Split(""""c)
                    If dUf.ContainsKey(m(1)) Then
                        If m(3) = vbNullString Then Continue Do
                        .Rows(n)(dUf(m(1))) = Convert.ChangeType(m(3), .Columns(dUf(m(1))).DataType)
                    ElseIf m(1).Length > 7 AndAlso m(1).Substring(0, 7) = "Ability" AndAlso IsNumeric(m(1).Substring(7)) Then
                        If m(3) = vbNullString Then Continue Do
                        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT an,aid FROM ablt WHERE an=""" & m(3) & """", cn)
                        Dim dr As SQLiteDataReader = cd.ExecuteReader()
                        Dim dt As New DataTable
                        dt.Load(dr)
                        dr.Close()
                        If dt.Rows.Count > 0 Then
                            Dim aid As Integer = dt(0)("aid")
                            ua &= "," & aid.ToString
                        End If
                    Else
                        Select Case m(1)
                            Case "BaseClass"
                                .Rows(n)("bc") = m(3).Substring(9)
                            Case "AttackCapabilities"
                                Select Case m(3)
                                    Case "DOTA_UNIT_CAP_NO_ATTACK"
                                        .Rows(n)("acap") = -1
                                    Case "DOTA_UNIT_CAP_MELEE_ATTACK"
                                        .Rows(n)("acap") = 0
                                    Case "DOTA_UNIT_CAP_RANGED_ATTACK"
                                        .Rows(n)("acap") = 1
                                End Select
                            Case "MovementCapabilities"
                                Select Case m(3)
                                    Case "DOTA_UNIT_CAP_MOVE_NONE"
                                        .Rows(n)("mcap") = -1
                                    Case "DOTA_UNIT_CAP_MOVE_GROUND"
                                        .Rows(n)("mcap") = 0
                                    Case "DOTA_UNIT_CAP_MOVE_FLY"
                                        .Rows(n)("mcap") = 1
                                End Select
                            Case "CombatClassAttack"
                                .Rows(n)("cca") = m(3).Substring(25)
                            Case "CombatClassDefend"
                                .Rows(n)("ccd") = m(3).Substring(25)
                        End Select
                    End If
                Loop '单个单位主要信息逐行读取结束
                If ua <> vbNullString Then .Rows(n)("a") = ua.Substring(1)
                n += 1
            Loop '单位文件读取结束
            Dim dlU() As String = {"loadout_generic", "companion", "thinker"} '不进表的单位名
            For i = .Rows.Count - 1 To 1 Step -1
                If dlU.Contains(.Rows(i)("un")) Then
                    .Rows.RemoveAt(i)
                    Continue For
                End If
                For j = 0 To .Columns.Count - 1 '检查空值
                    If IsDBNull(.Rows(i)(j)) Then '检查是否为空
                        If Not IsDBNull(.Rows(0)(j)) Then '若有默认值
                            .Rows(i)(j) = .Rows(0)(j) '填充默认值
                        ElseIf .Columns(j).DataType <> String.Empty.GetType Then '数字型无默认值
                            .Rows(i)(j) = 0 '数字型无默认值填充0
                        End If
                    End If
                Next
            Next
            .Rows.RemoveAt(0)
        End With
        Dim cb As New SQLiteCommandBuilder(daU)
        daU.Update(dsU.GetChanges, "unit")
    End Sub

    Private Sub rdITEMn()
        Dim srNI As New StreamReader("file\neutral_items.txt")
        Do
        Loop Until srni.ReadLine.Contains("neutral_items")
        Do Until srNI.EndOfStream
            Dim l As String = srNI.ReadLine.Replace(vbTab, vbNullString).Replace(" ", vbNullString)
            If l = vbNullString OrElse l.First = "/"c Then Continue Do
            If l.Contains("}") Then Exit Do '全文件读取完毕
            If Not l.Contains("""") Then Continue Do
            Dim lNI As Integer = Convert.ToInt32(l.Split(""""c)(1)) '级别
            Do
            Loop Until srNI.ReadLine.Contains("items") '找到物品列表起始
            Dim li As String = vbNullString
            Do '当前级别列表开始
                li = srNI.ReadLine().Replace(vbTab, vbNullString).Replace(" ", vbNullString)
                If li = vbNullString OrElse li.First = "/"c Then Continue Do
                If li.Contains("}") Then
                    Do
                    Loop Until srNI.ReadLine.Contains("}") '读出当前级别的结束}
                    Exit Do
                End If
                If Not li.Contains("""") Then Continue Do
                Dim ni() As String = li.Split(""""c)
                If ni(1).Length > 5 Then dcNI.Add(ni(1).Substring(5), lNI)
                'Debug.Print（ni(1) & " : " & lNI）
            Loop
        Loop
    End Sub

    Private Sub rdITEM()
        Dim daI As SQLiteDataAdapter = New SQLiteDataAdapter("DELETE FROM item;SELECT * FROM item", cn)
        Dim dsI As New DataSet
        daI.Fill(dsI, "item")
        With dsI.Tables(0)
            Dim srI As New StreamReader("file\items.txt")
            Do
            Loop Until srI.ReadLine.Replace(vbTab, vbNullString).Contains("""Version""")
            Dim dRCP As New Dictionary(Of String, String()) '"物品名",{"图纸价格","部件1,部件2;部件1,部件2……"}
            Do Until srI.EndOfStream
                Dim l As String = srI.ReadLine.Replace(vbTab, vbNullString).Replace(" ", vbNullString)
                If l = vbNullString OrElse l.First = "/"c Then Continue Do
                If l.Contains("}") Then Exit Do '全部物品读取完毕
                If l.First <> """"c Then Continue Do
                Dim nI As String = l.Split(""""c)(1).Substring(5)
                Dim rcp As Boolean = False
                Dim n As Integer = -1
                If nI.Length > 6 AndAlso nI.Substring(0, 6) = "recipe" Then
                    rcp = True
                    nI = nI.Substring(7)
                    dRCP.Add(nI, {vbNullString, vbNullString})
                Else
                    .Rows.Add()
                    n = .Rows.Count - 1
                    .Rows(n)("inm") = nI
                    If IsNumeric(nI.Last) Then
                        'If dC.ContainsKey("DOTA_TOOLTIP_ABILITY_ITEM_" & nI.ToUpper) Then .Rows(n)("inc") = $"{dC("DOTA_TOOLTIP_ABILITY_ITEM_" & nI.ToUpper)}（{nI.Last}级）"
                        .Rows(n)("inc") = $"{DicV("DOTA_TOOLTIP_ABILITY_ITEM_" & nI.ToUpper)}（{nI.Last}级）"
                    Else
                        'If dC.ContainsKey("DOTA_TOOLTIP_ABILITY_ITEM_" & nI.ToUpper) Then .Rows(n)("inc") = dC("DOTA_TOOLTIP_ABILITY_ITEM_" & nI.ToUpper)
                        .Rows(n)("inc") = DicV("DOTA_TOOLTIP_ABILITY_ITEM_" & nI.ToUpper)
                    End If
                End If
                srI.ReadLine() '读出{
                Do '单个物品逐行读取开始
                    Dim ll As String = srI.ReadLine.Replace(vbTab, vbNullString) '.Replace(" ", vbNullString)
                    If ll.Contains("}") Then Exit Do '单个物品读取完毕
                    If ll.Contains("{") Then '跳过无用内容
                        Dim b As Integer = 1
                        Do
                            Dim t As String = srI.ReadLine
                            If t.Contains("{") Then b += 1
                            If t.Contains("}") Then b -= 1
                            If b = 0 Then Exit Do
                        Loop
                    End If
                    If ll = vbNullString OrElse ll.First <> """"c Then Continue Do
                    Dim m() As String = ll.Split(""""c)
                    If (Not rcp) AndAlso dIf.ContainsKey(m(1)) Then
                        .Rows(n)(dIf(m(1))) = Convert.ChangeType(m(3), .Columns(dIf(m(1))).DataType)
                    Else
                        Select Case m(1)
                            Case "AbilityBehavior"
                                .Rows(n)("iabh") = m(3).Replace("|"c, ","c).Replace(" ", vbNullString).Replace("DOTA_ABILITY_BEHAVIOR_", vbNullString)
                            Case "AbilityUnitTargetTeam"
                                .Rows(n)("iautm") = m(3).Replace("|"c, ","c).Replace(" ", vbNullString).Replace("DOTA_UNIT_TARGET_TEAM_", vbNullString)
                            Case "AbilityUnitTargetType"
                                .Rows(n)("iautp") = m(3).Replace("|"c, ","c).Replace(" ", vbNullString).Replace("DOTA_UNIT_TARGET_", vbNullString)
                            Case "ItemCost"
                                dRCP(nI)(0) = m(3)'卷轴价格
                            Case "ItemRequirements" '配方
                                srI.ReadLine() '读出{
                                Dim ir As String = vbNullString
                                Do
                                    Dim lr As String = srI.ReadLine.Replace(vbTab, vbNullString).Replace(" ", vbNullString)
                                    If lr.Contains("}") Then Exit Do
                                    'If lr = vbNullString OrElse lr.First <> """"c Then Continue Do
                                    If lr = vbNullString OrElse (Not lr.Contains(""""c)) Then Continue Do
                                    Dim ra() As String = lr.Replace(";""", """").Split(""""c)
                                    ir &= ";" & ra(3).Replace(";"c, ","c).Replace("item_", vbNullString)
                                Loop
                                dRCP(nI)(1) = ir.Substring(1).Replace("*", vbNullString)'有的配方内物品被加了*
                            Case "ItemDisassembleRule"
                                Select Case m(3)
                                    Case "DOTA_ITEM_DISASSEMBLE_NEVER"
                                        .Rows(n)("idr") = -1
                                    Case "DOTA_ITEM_DISASSEMBLE_ALWAYS"
                                        .Rows(n)("idr") = 1
                                    Case Else
                                        .Rows(n)("idr") = -2
                                End Select
                            Case "AbilitySpecial"  '技能独有属性
                                srI.ReadLine() '读出{ 
                                Dim si As Integer = 0
                                Dim bonus As String = vbNullString
                                Do
                                    Dim ls As String = srI.ReadLine.Replace(vbTab, vbNullString).Replace(" ", vbNullString)
                                    If ls.Contains("}") Then
                                        If bonus <> vbNullString Then .Rows(n)("bonus") = bonus.Substring(1)
                                        Exit Do '所有独有属性读取完毕
                                    End If
                                    If ls = vbNullString OrElse ls.First <> """"c Then Continue Do
                                    Dim sn() As String = ls.Split(""""c)
                                    'Dim si As Integer = Convert.ToInt32(sn(1).Replace(""""c, vbNullString))
                                    srI.ReadLine()
                                    Do '单个特殊属性读取开始
                                        Dim lss As String = srI.ReadLine.Replace(vbTab, vbNullString) '.Replace(" ", vbNullString)
                                        If lss = vbNullString OrElse ls.First = "/"c Then Continue Do
                                        If lss.Contains("}") Then Exit Do '单个独有属性读取完毕
                                        If lss.First <> """"c Then Continue Do
                                        Dim s() As String = lss.Split(""""c)
                                        If s(1) = "var_type" Then Continue Do
                                        Dim iak As String = $"DOTA_TOOLTIP_ABILITY_ITEM_{nI}_{s(1)}".ToUpper
                                        'If dC.ContainsKey(iak) AndAlso dC(iak).Contains("$") AndAlso dC.ContainsKey($"DOTA_ABILITY_VARIABLE_{dC(iak).Split("$"c)(1)}".ToUpper) Then
                                        '    bonus &= $";{s(1)},{dC(iak)},{s(3)}"
                                        If DicCK(iak) AndAlso DicV(iak).Contains("$") AndAlso DicCK($"DOTA_ABILITY_VARIABLE_{DicV(iak).Split("$"c)(1)}".ToUpper) Then
                                            bonus &= $";{s(1)},{DicV(iak)},{s(3)}"

                                        Else
                                            si += 1
                                            .Rows(n)("s" & si) = s(1) & ":" & s(3)
                                        End If
                                    Loop
                                Loop
                        End Select
                    End If
                Loop '单个物品逐行读取结束
            Loop '物品文件读取结束
            For Each kvp As KeyValuePair(Of String, String()) In dRCP
                Dim ri As String = vbNullString
                If IsNothing(kvp.Value(1)) Then Continue For
                Dim r1() As String = kvp.Value(1).Split(";"c)
                For i = 0 To r1.GetUpperBound(0)
                    Dim r2() As String = r1(i).Split(","c)
                    For j = 0 To r2.GetUpperBound(0)
                        For k = 0 To .Rows.Count - 1
                            If .Rows(k)("inm") = r2(j) Then
                                ri &= .Rows(k)("iid").ToString
                                If j < r2.GetUpperBound(0) Then ri &= ","
                                Exit For
                            End If
                        Next
                    Next
                    If i < r1.GetUpperBound(0) Then ri &= ";"
                Next
                kvp.Value(1) = ri
            Next
            For i = .Rows.Count - 1 To 0 Step -1
                If IsDBNull(.Rows(i)("irc")) Then .Rows(i)("irc") = -1
                If IsDBNull(.Rows(i)("isl")) Then .Rows(i)("isl") = 1
                If IsDBNull(.Rows(i)("idr")) Then .Rows(i)("idr") = 0
                Dim inm As String = .Rows(i)("inm")
                If dRCP.ContainsKey(inm) Then
                    If dRCP(inm)(0).Length > 0 Then '文件中有的卷轴售价为空
                        .Rows(i)("irc") = dRCP(inm)(0)
                    End If
                    If Not IsNothing(dRCP(inm)(1)) Then .Rows(i)("ir") = dRCP(inm)(1) '.Replace("*", vbNullString)
                ElseIf inm.Length > 12 AndAlso inm.Substring(0, 13) = "river_painter" Then
                    .Rows.RemoveAt(i)
                End If
                If Not IsDBNull(.Rows(i)("inil")) Then
                    .Rows(i)("inil") = If(dcNI.ContainsKey(.Rows(i)("inm")), dcNI(.Rows(i)("inm")), -1)
                End If
            Next
        End With
        'DTtoCSV(dsI.Tables(0), "items")
        Dim cb As New SQLiteCommandBuilder(daI)
        daI.Update(dsI.GetChanges, "item")
    End Sub

    Private Sub picH()
        Dim lp As String = vbNullString
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT hn,hnc FROM hero", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader()
        Dim dtP As New DataTable
        dtP.Load(dr)
        dr.Close()
        If Not Directory.Exists("pic\hero\") Then
            Directory.CreateDirectory("pic\hero\")
        End If
        Dim w As New Net.WebClient
        For i = 0 To dtP.Rows.Count - 1
            Dim h As String = dtP(i)(0).ToString
            If Not File.Exists("pic\hero\" & h & ".png") Then
                Try
                    '    If File.Exists("https://www.dota2.com.cn/images/heroes/" & h & "_full.png") Then
                    w.DownloadFile("https://www.dota2.com.cn/images/heroes/" & h & "_full.png", "pic\hero\" & h & ".png")
                    '        '英文网页"http://cdn.dota2.com/apps/dota2/images/heroes/" & h & "_full.png", "pic\hero\" & h & ".png"
                    '    Else
                    '        lp &= vbCrLf & dtP(i)("hnc") & "（图片不存在）"
                    '    End If
                Catch ex As Exception
                    lp &= vbCrLf & dtP(i)("hnc") & " - 下载失败"
                End Try
            End If
        Next
        If lp <> vbNullString Then MessageBox.Show("以下图片下载失败：" & lp.Substring(1))
    End Sub

    Private Sub picI()
        Dim li As String = vbNullString
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT inm,inc FROM item", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader()
        Dim dtP As New DataTable
        dtP.Load(dr)
        dr.Close()
        If Not Directory.Exists("pic\item\") Then
            Directory.CreateDirectory("pic\item\")
        End If
        Dim w As New Net.WebClient
        For i = 0 To dtP.Rows.Count - 1
            Dim p As String = dtP(i)(0).ToString
            If Not File.Exists("pic\item\" & p & ".png") Then
                Try
                    'If File.Exists("http://www.dota2.com.cn/items/images/" & p & "_lg.png") Then
                    w.DownloadFile("http://www.dota2.com.cn/items/images/" & p & "_lg.png", "pic\item\" & p & ".png")
                    '    '英文网页"http://cdn.dota2.com/apps/dota2/images/items/" & p & "_lg.png", "pic\item\" & p & ".png"
                    'Else
                    '    li &= vbCrLf & dtP(i)("inc") & "（图片不存在）"
                    'End If
                Catch ex As Exception
                    li &= vbCrLf & dtP(i)("inc") & " - 下载失败"
                End Try
            End If
        Next
        If li <> vbNullString Then MessageBox.Show("以下图片下载失败：" & li.Substring(1))
        'If Not File.Exists("pic\item\recipe.png") Then
        '    w.DownloadFile("http://cdn.dota2.com/apps/dota2/images/items/recipe_lg.png", "pic\item\recipe.png")
        'End If
        'If Not File.Exists("pic\item\unknown.png") Then
        '    w.DownloadFile("http://media.steampowered.com/apps/dota2/images/quiz/item-slot-unknown.png", "pic\item\unkonwn.png")
        'End If
    End Sub

    Private Sub Upd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.D) Then
            DataTab.Show()
        End If
    End Sub

    Private Sub DTtoCSV(ByVal dt As DataTable, ByVal fn As String)
        Dim sw As New StreamWriter(fn & ".csv", False, System.Text.Encoding.UTF8)
        For i = 0 To dt.Rows.Count - 1
            Dim l As String = vbNullString
            For j = 0 To dt.Columns.Count - 1
                l &= "," & dt(i)(j)
            Next
            sw.WriteLine(l.Substring(1))
        Next
        sw.Close()
    End Sub

End Class

'WithEvents wb As New WebBrowser
'Private Sub bPDL_Click(sender As Object, e As EventArgs) Handles bPDL.Click
'    wb.Url = New Uri("http://www.dota2.com/heroes/?l=schinese")
'End Sub

'Private Sub wbDC() Handles wb.DocumentCompleted
'    Dim c As HtmlElementCollection = wb.Document.GetElementById("heroPickerInner").GetElementsByTagName("div")
'    For Each e As HtmlElement In c
'        Dim t As String = e.GetAttribute("CLASSNAME")
'        If t = "heroIcons" Then
'            Dim eH As HtmlElementCollection = e.GetElementsByTagName("a")
'            For i = 0 To eH.Count - 1
'                Dim h As String = eH(i).Children(1).GetAttribute("id").Substring(5)
'                Dim p As String = eH(i).Children(1).GetAttribute("src")
'                Dim fs As IO.Stream = Net.WebRequest.Create(p).GetResponse().GetResponseStream()
'                Dim ms As New MemoryStream
'                fs.CopyTo(ms)
'                Dim b(ms.Length - 1) As Byte
'                ms.Read(b, 0, b.Length)
'                Dim cd As New OleDbCommand("UPDATE hero SET pic=? WHERE hne='" & h & "'", cn)
'                cd.Parameters.Add("?", OleDbType.Binary)
'                cd.Parameters(0).Value = b
'                cd.ExecuteNonQuery()
'            Next
'        End If
'    Next
'    wb.Dispose()
'    MsgBox("end")
'End Sub

'If Not File.Exists("file\items.txt") Then
'    If MessageBox.Show($"找不到物品文件{vbCrLf}选择【是】采用内置的v{DotaVer}物品文件{vbCrLf}选择【否】将终止更新。{vbCrLf}你也可以使用以下方法从dota2数据包内解压最新的物品文件：{vbCrLf}1、用tool文件夹下的GCFScape.exe打开""{fp}\game\dota\pak01_dir.vpk""{vbCrLf}2、把""scripts\npc\items.txt""释放到file文件夹下", "物品文件缺失", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
'        Dim swi As New StreamWriter("file\items.txt")
'        swi.Write(My.Resources.items)
'        swi.Close()
'    Else
'        Exit Sub
'    End If
'End If

'Dim lPE As List(Of ValvePak.PackageEntry) = VPK.Entries("txt")
'For i = 0 To lPE.Count - 1
'    If fVPK.Contains(lPE(i).GetFullPath) Then
'        Dim b As Byte()
'        VPK.ReadEntry(PEi, b)
'        Dim fs As New FileStream("output.txt", FileMode.Create)
'        Dim bw As BinaryWriter = New BinaryWriter(fs)
'        bw.Write(b)
'        bw.Close()
'        fs.Close()
'    End If
'Next

'Private Sub picH()
'    Dim lp As String = vbNullString
'    Dim cd As SQLiteCommand = New SQLiteCommand("SELECT hn,hnc FROM hero", cn)
'    Dim dr As SQLiteDataReader = cd.ExecuteReader()
'    Dim dtP As New DataTable
'    dtP.Load(dr)
'    dr.Close()
'    If Not Directory.Exists("pic\hero\") Then
'        Directory.CreateDirectory("pic\hero\")
'    End If
'    Dim w As New Net.WebClient
'    For i = 0 To dtP.Rows.Count - 1
'        Dim h As String = dtP(i)(0).ToString
'        If Not File.Exists("pic\hero\" & h & ".png") Then
'            Try
'                If File.Exists("http://www.dota2.com.cn/images/heroes/" & h & "_full.png") Then
'                    w.DownloadFile("http://www.dota2.com.cn/images/heroes/" & h & "_full.png", "pic\hero\" & h & ".png")
'                    '英文网页"http://cdn.dota2.com/apps/dota2/images/heroes/" & h & "_full.png", "pic\hero\" & h & ".png"
'                Else
'                    lp &= vbCrLf & dtP(i)("hnc") & "（图片不存在）"
'                End If
'            Catch ex As Exception
'                lp &= vbCrLf & dtP(i)("hnc")
'            End Try
'        End If
'    Next
'    If lp <> vbNullString Then MessageBox.Show("以下图片下载失败：" & lp.Substring(1))
'End Sub

'Private Sub picI()
'    Dim li As String = vbNullString
'    Dim cd As SQLiteCommand = New SQLiteCommand("SELECT inm,inc FROM item", cn)
'    Dim dr As SQLiteDataReader = cd.ExecuteReader()
'    Dim dtP As New DataTable
'    dtP.Load(dr)
'    dr.Close()
'    If Not Directory.Exists("pic\item\") Then
'        Directory.CreateDirectory("pic\item\")
'    End If
'    Dim w As New Net.WebClient
'    For i = 0 To dtP.Rows.Count - 1
'        Dim p As String = dtP(i)(0).ToString
'        If Not File.Exists("pic\item\" & p & ".png") Then
'            Try
'                If File.Exists("http://www.dota2.com.cn/items/images/" & p & "_lg.png") Then
'                    w.DownloadFile("http://www.dota2.com.cn/items/images/" & p & "_lg.png", "pic\item\" & p & ".png")
'                    '英文网页"http://cdn.dota2.com/apps/dota2/images/items/" & p & "_lg.png", "pic\item\" & p & ".png"
'                Else
'                    li &= vbCrLf & dtP(i)("inc") & "（图片不存在）"
'                End If
'            Catch ex As Exception
'                li &= vbCrLf & dtP(i)("inc")
'            End Try
'        End If
'    Next
'    If li <> vbNullString Then MessageBox.Show("以下图片下载失败：" & li.Substring(1))
'    'If Not File.Exists("pic\item\recipe.png") Then
'    '    w.DownloadFile("http://cdn.dota2.com/apps/dota2/images/items/recipe_lg.png", "pic\item\recipe.png")
'    'End If
'    'If Not File.Exists("pic\item\unknown.png") Then
'    '    w.DownloadFile("http://media.steampowered.com/apps/dota2/images/quiz/item-slot-unknown.png", "pic\item\unkonwn.png")
'    'End If
'End Sub

