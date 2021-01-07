Imports System.Data.SQLite
Imports System.IO

Public Class ItemQuiz
    Dim r As New Random
    Dim dt As New DataTable
    Dim dtU() As DataRow
    Dim sL As New List(Of Integer)
    Dim pP() As PictureBox
    Dim pS() As Button
    Dim chc, scr As Integer
    Dim tn As Date
    Dim cb As Integer

    Private Sub ItemQuiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show("本程序为Ouroboros Dota Data的附加小游戏" & vbCrLf & "如果遇到bug请及时在群里报告" & vbCrLf & "完整的Ouroboros Dota Data将稍后发布" & vbCrLf & "发布QQ群：Project LOLI（454133861）")
        pP = {p0, p1, p2, p3}
        pS = {bS0, bS1, bS2, bS3, bS4, bS5, bS6, bS7, bSr}
        bSr.Image = My.Resources.img_recipe
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT iid,inm,inc,ic,iq,ir,irc FROM item", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader()
        dt.Load(dr)
        dr.Close()
        If dt.Rows.Count = 0 Then
            cn.Close()
            MessageBox.Show("请更新数据")
            Upd.Show()
            Close()
        End If
        dt.Columns.Add("used", New Boolean.GetType)
        qInt()
        RndItem()
    End Sub

    Private Sub qInt()
        scr = 0
        chc = 3
        cb = 0
        lSCR.Text = scr.ToString
        lCHC.Text = chc.ToString
        lCB.Visible = False
        lANS.Text = vbNullString
        dtU = dt.Select("irc>-1")
        For i = 0 To dtU.Length - 1
            dtU(i)("used") = False
        Next
    End Sub

    Private Sub pP_Click(sender As PictureBox, e As EventArgs) Handles p0.Click, p1.Click, p2.Click, p3.Click
        If sender.Tag <> -99 Then
            pS(Math.Abs(sender.Tag) - 1).Enabled = True
            sender.Tag = -99
            sender.Image = My.Resources.img_uk_i
        Else
            Exit Sub
        End If
    End Sub

    Private Sub pS_Click(sender As Button, e As EventArgs) Handles bS0.Click, bS1.Click, bS2.Click, bS3.Click, bS4.Click, bS5.Click, bS6.Click, bS7.Click, bSr.Click
        p.Focus()
        For i = 0 To sL.Count - 1
            If pP(i).Tag = -99 Then
                sender.Enabled = False
                pP(i).Tag = sender.Tag
                pP(i).Image = sender.Image
                Exit For
            Else
                Continue For
            End If
        Next
        Dim TF As Boolean = True
        For i = 0 To sL.Count - 1
            If pP(i).Tag < 0 Then TF = False
            If pP(i).Tag = -99 Then
                Exit Sub
            ElseIf i = sL.Count - 1 Then
                If TF Then
                    cb += 1
                    Dim s As Integer = 60 - DateDiff(DateInterval.Second, tn, Now)
                    If s < 0 Then
                        s = 0
                        cb = 0
                    Else
                        s += 10 * (cb - 1)
                    End If
                    lCB.Text = "+" & s.ToString
                    scr += s
                    lSCR.Text = scr.ToString
                    lCB.Visible = True
                    pTF.Image = My.Resources.img_T
                    Application.DoEvents()
                    Threading.Thread.Sleep(500)
                    lCB.Visible = False
                    pTF.Image = Nothing
                    RndItem()
                Else
                    pTF.Image = My.Resources.img_F
                    cb = 0
                    chc -= 1
                    lCHC.Text = chc.ToString
                    lANS.Text = ans & vbCrLf
                    If chc = 0 Then
                        MessageBox.Show("你的得分是" & scr.ToString & vbCrLf & "点击【确定】重新开始", "物品测试")
                        qInt()
                    End If
                    Application.DoEvents()
                    Threading.Thread.Sleep(500)
                    pTF.Image = Nothing
                    RndItem()
                End If
            End If
        Next
    End Sub

    Dim ans As String = vbNullString

    Private Sub RndItem()
        Dim cplt As Boolean = True
        For i = 0 To dtU.Length - 1
            If dtU(i)("used") = False AndAlso (Not IsNumeric(dtU(i)("inm").ToString.Last)) Then
                cplt = False
                Exit For
            End If
        Next
        If cplt Then
            MessageBox.Show("恭喜通关， 你的得分是" & scr.ToString & vbCrLf & "点击【确定】重新开始", "物品测试")
            qInt()
        End If
        Dim Ii As Integer = 0
        Do
            Ii = r.Next(dtU.Length)
        Loop Until dtU(Ii)("used") = False AndAlso (Not IsNumeric(dtU(Ii)("inm").ToString.Last))
        dtU(Ii)("used") = True
        Dim Inm As String = dtU(Ii)("inm")
        If File.Exists($"pic\item\{Inm}.png") Then
            p.Image = Image.FromFile($"pic\item\{Inm}.png")
        Else
            'If DicCK("DOTA_TOOLTIP_ABILITY_ITEM_" & Inm) Then
            '    p.Text = DicV("DOTA_TOOLTIP_ABILITY_ITEM_" & Inm)
            'End If
            p.Image = My.Resources.img_uk_i
        End If
        lNAME.Text = dtU(Ii)("inc")
        If dtU(Ii)("inc") = "动力鞋" Then lNAME.Text &= "（力量）"
        lCOST.Text = dtU(Ii)("ic")
        'bSr.Text = "图纸"
        Dim piA() As String = dtU(Ii)("ir").ToString.Split(";"c)(0).Split(","c)
        For i = 0 To 3
            pP(i).Tag = -99
            pP(i).Image = Nothing
        Next
        sL.Clear()
        ans = vbNullString
        For i = 0 To piA.GetUpperBound(0)
            Dim drI As DataRow = dt.Select("iid= " & piA(i).ToString)(0)
            ans &= $"{drI("inc")}+"
            Dim si As Integer = 0
            Do
                si = r.Next(8)
            Loop Until Not sL.Contains(si)
            sL.Add(si)
            pP(i).Image = My.Resources.img_uk_i
            pS(si).Tag = si + 1
            pS(si).Text = drI("inc")
            If File.Exists($"pic\item\{drI("inm")}.png") Then
                pS(si).Image = Image.FromFile($"pic\item\{drI("inm")}.png")
            Else
                pS(si).Image = My.Resources.img_uk_i
            End If
        Next
        If dtU(Ii)("irc") > 0 Then
            ans &= "图纸+"
            sL.Add(8)
            bSr.Tag = 9
            pP(piA.Length).Image = My.Resources.img_uk_i
        Else
            bSr.Tag = -9
        End If
        ans = $"{lNAME.Text}={ans.Substring(0, ans.Length - 1)}"
        Dim dtB() As DataRow = dt.Select($"(iq='component' OR iq='secret_shop') AND (NOT iid IN({Join(piA, ",")}))")
        For i = 0 To 7
            pS(i).Enabled = True
            If sL.Contains(i) Then Continue For
            pS(i).Tag = 0 - i - 1
            Dim ib As Integer = r.Next(dtB.Length)
            pS(i).Text = dtB(ib)("inc")
            If File.Exists($"pic\item\{dtB(ib)("inm")}.png") Then
                pS(i).Image = Image.FromFile($"pic\item\{dtB(ib)("inm")}.png")
            Else
                pS(i).Image = My.Resources.img_uk_i
            End If
        Next
        bSr.Enabled = True
        tn = Now()
    End Sub

    Private Sub ItemQuiz_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        StartUp.Show()
    End Sub

End Class