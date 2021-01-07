Imports System.IO
Imports System.Data.SQLite

Public Class ItemIfm
    Dim sp() As List(Of String)
    'Dim ni() As List(Of String)
    Dim spT() As String
    Dim aST() As String = {"consumables", "attributes", "weapons_armor", "misc", "secretshop", "basics", "support", "magics", "defense", "weapons", "artifacts", "neutral1", "neutral2", "neutral3", "neutral4", "neutral5"}
    Dim dtI As New DataTable

    Private Sub ItemIfm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Not File.Exists("file\shops.txt") Then
        '    MessageBox.Show($"找不到商店文件,将采用内置的v{DotaVer}商店文件{vbCrLf}请参照说明文件将最新的商店文件解压到file文件夹下", "商店文件缺失")
        '    Dim swi As New StreamWriter("file\shops.txt")
        '    swi.Write(My.Resources.shops)
        '    swi.Close()
        'End If
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT * FROM item", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader()
        dtI.Load(dr)
        dr.Close()
        If dtI.Rows.Count = 0 Then
            cn.Close()
            MessageBox.Show("请更新数据")
            Upd.Show()
            Close()
        End If
        rdSHOP()
        rdNITEM()
        'For z = 0 To spT.Length - 1
        '    MsgBox(spT(z))
        'Next
        For i = 0 To aST.Length - 1
            'MsgBox(aST(i))
            Dim n As Integer = 0
            For k = 0 To spT.Length - 1
                If spT(k) = aST(i) Then '寻找sp()中的序号
                    n = k
                    Exit For
                End If
            Next
            For j = 0 To sp(n).Count - 1
                Dim b As New Button
                Dim c As Integer = i + 1
                If c > 5 Then c += 1
                If c > 12 Then c += 1
                tlpL.Controls.Add(b, c, j + 1)
                With b
                    .Dock = DockStyle.Fill
                    .Name = sp(n)(j)
                    .Tag = .Name
                    .Margin = New Padding(0, 0, 0, 0)
                    If File.Exists($"pic\item\{ .Name}.png") Then
                        .Image = New Bitmap(Image.FromFile($"pic\item\{ .Name}.png"), .Size)
                    Else
                        If DicCK("DOTA_TOOLTIP_ABILITY_ITEM_" & .Name) Then
                            .TextImageRelation = TextImageRelation.Overlay
                            .ForeColor = Color.White
                            .Font = New Font("宋体", 7)
                            .Text = DicV("DOTA_TOOLTIP_ABILITY_ITEM_" & .Name)
                        End If
                        .Image = New Bitmap(My.Resources.img_uk_i, .Size)
                    End If
                    AddHandler .GotFocus, AddressOf iIfm
                End With
            Next
        Next
    End Sub

    Private Sub rdSHOP()
        'Dim srS As New StringReader(My.Resources.shops)
        Dim srS As New StreamReader("file\shops.txt")
        srS.ReadLine()
        srS.ReadLine()
        Dim n As Integer = -1 '标签序号
        Do
            Dim l As String = srS.ReadLine.Replace(vbTab, vbNullString)
            If l.Contains("}") Then Exit Do '全部商店标签读取完毕
            If l = vbNullString OrElse l.First <> """"c Then Continue Do
            n += 1
            ReDim Preserve spT(n)
            spT(n) = l.Split(""""c)(1)
            ReDim Preserve sp(n)
            sp(n) = New List(Of String)
            srS.ReadLine() '读出{
            Do '单个标签逐行读取开始
                Dim ll As String = srS.ReadLine.Replace(vbTab, vbNullString).Replace(" ", vbNullString)
                If ll.Contains("}") Then Exit Do '单个技能读取完毕
                If ll = vbNullString OrElse ll.First <> """"c Then Continue Do
                Dim m() As String = ll.Split(""""c) '(1)固定为"item"
                If m(3).Length > 17 AndAlso m(3).Substring(0, 18) = "item_river_painter" Then Continue Do
                sp(n).Add(m(3).Substring(5))
            Loop '单个标签逐行读取结束
        Loop '商店文件读取结束
    End Sub

    Private Sub rdNITEM()
        Dim srNI As New StreamReader("file\neutral_items.txt")
        Do
        Loop Until srNI.ReadLine.Contains("neutral_items")
        Do Until srNI.EndOfStream
            Dim l As String = srNI.ReadLine.Replace(vbTab, vbNullString).Replace(" ", vbNullString)
            If l = vbNullString OrElse l.First = "/"c Then Continue Do
            If l.Contains("}") Then Exit Do '全文件读取完毕
            If Not l.Contains("""") Then Continue Do
            Dim lNI As Integer = Convert.ToInt32(l.Split(""""c)(1)) '级别
            ReDim Preserve spT(spT.Length)
            spT(spT.Length - 1) = $"neutral{lNI}"
            'ReDim Preserve ni(lNI - 1)
            'ni(lNI - 1) = New List(Of String)
            ReDim Preserve sp(sp.Length)
            sp(sp.Length - 1) = New List(Of String)
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
                Dim nin As String = li.Split(""""c)(1)
                If nin.Length > 5 Then sp(sp.Length - 1).Add(nin.Substring(5))
            Loop
        Loop
    End Sub


    Private Sub iIfm(sender As Object, e As EventArgs)
        Dim dr As DataRow = dtI.Select($"inm='{sender.Tag}'")(0)
        Dim nIu As String = dr("inm").ToString.ToUpper
        lIN.Text = dr("inc")
        lIC.Text = dr("ic")
        If File.Exists($"pic\item\{sender.Tag}.png") Then
            pI.Image = Image.FromFile($"pic\item\{sender.Tag}.png")
        Else
            pI.Image = My.Resources.img_uk_i
        End If
        Dim sDS As String = vbNullString
        Dim kid As String = $"DOTA_TOOLTIP_ABILITY_ITEM_{nIu}_DESCRIPTION"
        Dim NoDes As Boolean = True            '慧光没有描述，但是有两个bouns需要显示
        If DicCK(kid) AndAlso DicV(kid) <> vbNullString Then
            NoDes = False
            Dim sDS0 As String = DicV(kid).Replace("%%", "%").Replace("\n", vbCrLf).Replace("</h1>", vbCrLf).Replace(vbCrLf & vbCrLf, vbCrLf).Replace("<h1>", vbCrLf)
            For i = 0 To sDS0.Length - 1
                If sDS0(i) = "<" Then
                    Dim n As Integer = i + 1
                    Do
                        If sDS0(n) = ">" Then
                            i = n
                            Exit Do
                        End If
                        n += 1
                    Loop
                Else
                    sDS &= sDS0(i)
                End If
            Next
            sDS = sDS
        End If
        Dim sBNS As String = vbNullString
        If Not IsDBNull(dr("bonus")) Then
            Dim bns() As String = dr("bonus").ToString.Split(";"c)
            For i = 0 To bns.GetUpperBound(0)
                Dim b() As String = bns(i).Split(","c)
                b(1) = b(1).Replace("-"c, vbNullString)
                sBNS &= $"{IIf(b(1).First = "%"c, b(1)(1) & b(2) & "%", b(1).First & b(2))}{DicV($"DOTA_ABILITY_VARIABLE_{b(1).Split("$"c)(1)}".ToUpper)}{vbCrLf}".Replace(" "c, "/"c)
                If Not IsNothing(sDS) Then sDS = sDS.Replace($"%{b(0)}%", b(2))
            Next
        End If
        For i = 1 To 15
            If IsDBNull(dr("s" & i.ToString)) Then
                Exit For
            Else
                Dim sp() As String = dr("s" & i.ToString).ToString.Split(":"c)
                sp(1) = sp(1).Replace("-"c, vbNullString)
                If Not IsNothing(sDS) Then sDS = sDS.Replace($"%{sp(0)}%", sp(1).Replace(" "c, "/"c))
                If NoDes Then
                    Dim kbs As String = $"DOTA_TOOLTIP_ABILITY_ITEM_{nIu}_{sp(0).ToUpper}"
                    If DicCK(kbs) Then
                        Dim bs As String = DicV(kbs)
                        sBNS &= $"{IIf(bs.First = "%"c, $"{bs(1)}{sp(1)}%{bs.Substring(2)}", bs(0) & sp(1) & bs.Substring(1))}{vbCrLf}"
                    End If
                End If
            End If
        Next
        Dim sNT As String = vbNullString
        For i = 0 To 5
            Dim kNT As String = $"DOTA_TOOLTIP_ABILITY_ITEM_{nIu}_NOTE{i.ToString}"
            If DicCK(kNT) Then sNT &= DicV(kNT) & vbCrLf
        Next
        If sNT <> vbNullString Then sNT = "--------------------" & vbCrLf & sNT
        tbIFM.Text = sBNS & sDS & vbCrLf & sNT
        'If dC.ContainsKey($"DOTA_TOOLTIP_ABILITY_ITEM_{nIu}_LORE") Then
        '    lLORE.Text = dC($"DOTA_TOOLTIP_ABILITY_ITEM_{nIu}_LORE").Replace("\n", ",")
        'End If
        lLORE.Text = vbNullString
        Dim kLORE As String = $"DOTA_TOOLTIP_ABILITY_ITEM_{nIu}_LORE"
        If DicCK(kLORE) Then lLORE.Text = DicV(kLORE).Replace("\n", ",")
        Dim rh As Integer = 0
        If Not IsDBNull(dr("iamc")) Then
            Dim mcS() As String = dr("iamc").ToString.Split(" "c)
            Dim mc(mcS.GetUpperBound(0)) As Integer
            For i = 0 To mcS.GetUpperBound(0)
                mc(i) = Convert.ToInt32(mcS(i))
                mcS(i) = mc(i).ToString
            Next
            If mc.Sum > 0 Then
                rh = 30
                pMC.Visible = True
                lMC.Visible = True
                If mc.Sum = mc(0) * mc.Length Then
                    lMC.Text = mc(0).ToString
                Else
                    lMC.Text = Join(mcS, "/")
                End If
            Else
                pMC.Visible = False
                lMC.Visible = False
            End If
        End If
        If Not IsDBNull(dr("iacd")) Then
            Dim cdS() As String = dr("iacd").ToString.Split(" "c)
            Dim cd(cdS.GetUpperBound(0)) As Decimal
            For i = 0 To cdS.GetUpperBound(0)
                cd(i) = Convert.ToDecimal(cdS(i))
                cdS(i) = cd(i).ToString
            Next
            If cd.Sum > 0 Then
                rh = 30
                pCD.Visible = True
                lCD.Visible = True
                If cd.Sum = cd(0) * cd.Length Then
                    lCD.Text = cd(0).ToString
                Else
                    lCD.Text = Join(cdS, "/")
                End If
            Else
                pCD.Visible = False
                pMC.Visible = False
            End If
        End If
        tlpR.RowStyles(3).Height = rh
        Dim lIR() As Label = {lIR0, lIR1, lIR2, lIR3}
        Dim pIR() As PictureBox = {pIR0, pIR1, pIR2, pIR3, pIR4}
        For i = 0 To 3
            lIR(i).Visible = False
            pIR(i + 1).Visible = False
        Next
        pIR(0).Visible = False
        If Not IsDBNull(dr("ir")) Then
            pIR0.Visible = True
            pIR0.Image = sender.Image
            Dim ir() As String = dr("ir").ToString.Split(";"c)(0).Split(","c)
            Dim ub As Integer = ir.GetUpperBound(0)
            For i = 0 To ub
                lIR(i).Visible = True
                pIR(i + 1).Visible = True
                Dim irn As String = dtI.Select("iid= " & ir(i).ToString)(0)("inm")
                pIR(i + 1).Tag = irn
                If File.Exists($"pic\item\{irn}.png") Then
                    pIR(i + 1).Image = Image.FromFile($"pic\item\{irn}.png")
                Else
                    pIR(i + 1).Image = My.Resources.img_uk_i
                    ''Dim g As Graphics = pIR(i + 1).CreateGraphics
                    ''g.DrawLine(New Pen(Color.White), 0, 0, 10, 10)
                    ''g.DrawString(DicV("DOTA_TOOLTIP_ABILITY_ITEM_" & irn), New Font("宋体", 8), New SolidBrush(Color.White), New RectangleF(0, 0, 45, 34), New StringFormat(StringAlignment.Center))
                    'If DicCK("DOTA_TOOLTIP_ABILITY_ITEM_" & irn) Then
                    '    '.TextImageRelation = TextImageRelation.Overlay
                    '    '.ForeColor = Color.White
                    '    '.Font = New Font("宋体", 7)
                    '    '.Text = DicV("DOTA_TOOLTIP_ABILITY_ITEM_" & irn)
                    '    pIR(i + 1).CreateGraphics.DrawString(DicV("DOTA_TOOLTIP_ABILITY_ITEM_" & irn), New Font("宋体", 8), New SolidBrush(Color.White), New RectangleF(0, 0, 45, 34), New StringFormat(StringAlignment.Center))
                    '    pIR(i + 1).Update()
                    'End If
                End If
                'AddHandler pIR(i + 1).Click, AddressOf iIfm 'bug,连续触发
            Next
            If Not IsDBNull(dr("irc")) AndAlso dr("irc") > 0 Then
                lIR(ub + 1).Visible = True
                pIR(ub + 2).Visible = True
                pIR(ub + 2).Image = My.Resources.img_recipe
                'RemoveHandler pIR(ub + 2).Click, AddressOf iIfm
            End If
        End If

    End Sub

    Private Sub ItemIfm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        StartUp.Show()
    End Sub

End Class