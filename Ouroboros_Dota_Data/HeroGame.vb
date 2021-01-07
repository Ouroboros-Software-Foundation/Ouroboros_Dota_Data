Imports System.Data.SQLite

Public Class HeroGame
    Dim r As New Random
    Dim H As New DataTable
    Dim ord As New List(Of Integer)
    Dim HP(5) As Integer
    Dim pH(5), pP(5, 2) As PictureBox
    Dim pbH(5) As ProgressBar
    Dim lL(5), lP(5, 2) As Label
    Dim pAl() As Point = {New Point, New Point, New Point, New Point, New Point, New Point}
    Dim aPs() As String = {"str", "agi", "int"}
    Dim aPp(,) As Image = {{My.Resources.icon_str, My.Resources.icon_str_p}, {My.Resources.icon_agi, My.Resources.icon_agi_p}, {My.Resources.icon_int, My.Resources.icon_int_p}}

    Private Sub dtInt()
        H.Columns.Add("hn", String.Empty.GetType)
        H.Columns.Add("hnc", String.Empty.GetType)
        H.Columns.Add("lv", New Integer.GetType)
        H.Columns.Add("hp", New Integer.GetType)
        H.Columns.Add("amin", New Integer.GetType)
        H.Columns.Add("amax", New Integer.GetType)
        H.Columns.Add("spd", New Integer.GetType)
        H.Columns.Add("hpr", New Decimal.GetType)
        H.Columns.Add("dm", New Decimal.GetType)
        H.Columns.Add("dp", New Decimal.GetType)
    End Sub

    Private Sub HeroGame_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtInt()
        GameInt()
    End Sub

    Private Sub bRND_Click(sender As Object, e As EventArgs) Handles bRND.Click
        GameInt()
    End Sub

    Private Sub bSTART_Click(sender As Object, e As EventArgs) Handles bSTART.Click
        GameRound()
        bSTART.Enabled = False
        bRND.Enabled = False
    End Sub

    Private Sub GameInt()
        pH = {pH0, pH1, pH2, pH3, pH4, pH5}
        pbH = {pbH0, pbH1, pbH2, pbH3, pbH4, pbH5}
        lL = {lL0, lL1, lL2, lL3, lL4, lL5}
        pP = {{pP00, pP01, pP02}, {pP10, pP11, pP12}, {pP20, pP21, pP22}, {pP30, pP31, pP32}, {pP40, pP41, pP42}, {pP50, pP51, pP52}}
        lP = {{lP00, lP01, lP02}, {lP10, lP11, lP12}, {lP20, lP21, lP22}, {lP30, lP31, lP32}, {lP40, lP41, lP42}, {lP50, lP51, lP52}}
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT prim,hn,hnc,prim,strb,strg,agib,agig,intb,intg,amin,amax,amr,hpr,mov FROM hero ORDER BY RANDOM() LIMIT 6", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(dr)
        dr.Close()
        Dim l(5) As Integer
        For i = 0 To 2
            l(i) = r.Next(1, 26)
        Next
        Dim dv As Integer = 0
        Do
            For i = 3 To 5
                l(i) = r.Next(1, 26)
            Next
            dv = Math.Abs(l(0) + l(1) + l(2) - l(3) - l(4) - l(5))
        Loop Until dv < 4
        H.Clear()
        For i = 0 To 5
            H.Rows.Add()
            H(i)("hn") = dt(i)("hn")
            H(i)("hnc") = dt(i)("hnc")
            H(i)("lv") = l(i)
            pH(i).Image = Image.FromFile("pic\hero\" & H(i)("hn") & ".png")
            pH(i).Tag = True
            Dim p() As Integer = {0, 0, 0}
            For j = 0 To 2
                p(j) = Math.Round(dt(i)(aPs(j) & "b") + (l(i) - 1) * dt(i)(aPs(j) & "g"))
                lP(i, j).Text = p(j)
                If dt(i)("prim") = j Then
                    pP(i, j).Image = aPp(j, 1)
                    H(i)("amin") = dt(i)("amin") + p(j)
                    H(i)("amax") = dt(i)("amax") + p(j)
                Else
                    pP(i, j).Image = aPp(j, 0)
                End If
            Next
            H(i)("hp") = p(0) * 10
            HP(i) = H(i)("hp")
            H(i)("hpr") = dt(i)("hpr") + p(0) * 0.06
            H(i)("spd") = p(1)
            Dim amr As Decimal = dt(i)("amr") + p(1) / 7
            H(i)("dm") = Math.Round(1 - 0.06 * amr / (1 + Math.Abs(amr) * 0.06), 2)
            H(i)("dp") = Math.Round(p(2) / 5, 2)
            pbH(i).Maximum = H(i)("hp")
            pbH(i).Value = pbH(i).Maximum
            lL(i).Text = $"Lv{l(i)} {H(i)("hnc")}"
            pAl(i) = pH(i).Location - New Point(2, 2)
            ord.Add(i)
        Next
        For i = 0 To 2
            pH(i).Enabled = False
        Next
        '排列行动顺序
        For i = 0 To 4
            For j = i + 1 To 5
                If H(ord(i))("spd") < H(ord(j))("spd") Then
                    Dim tmp As Integer = ord(i)
                    ord(i) = ord(j)
                    ord(j) = tmp
                End If
            Next
        Next
        oi = -1
    End Sub

    Dim oi As Integer = -1
    Private Sub GameRound()
        oi += 1
        If oi = ord.Count Then oi = 0
        pA.Visible = True
        Dim hi As Integer = ord(oi)
        pA.Location = pAl(hi)
        If hi < 3 Then
            Application.DoEvents()
            Threading.Thread.Sleep(500)
            'AI开始
            Dim tgt As Integer = -1
            Do
                tgt = r.Next(3, 6)
            Loop Until ph(tgt).Tag = True
            Atk(hi, tgt)
            'AI结束
            GameRound()
        Else
            For i = 0 To 2
                pH(i).Enabled = True
            Next
        End If
    End Sub

    Private Sub pH_Click(sender As PictureBox, e As EventArgs) Handles pH0.Click, pH1.Click, pH2.Click
        Atk(ord(oi), Convert.ToInt32(sender.Name.Last) - 48)
        For i = 0 To 2
            pH(i).Enabled = True
        Next
        GameRound()
    End Sub

    Private Sub Atk(ByVal h1 As Integer, h2 As Integer)
        Dim a As Integer = r.Next(H(h1)("amin"), H(h1)("amax") + 1)
        Dim p As Integer = a * H(h1)("dp") / 100
        Dim dmg As Integer = Math.Round(a * H(h2)("dm")) + p
        HP(h2) -= dmg
        If HP(h2) < 0 Then HP(h2) = 0
        pbH(h2).Value = HP(h2)
        tbM.AppendText($"{H(h1)("hnc")}攻击{H(h2)("hnc")}造成{dmg}伤害{vbCrLf}基础伤害{a}增幅{p}{vbCrLf}")
        If HP(h2) = 0 Then
            pH(h2).Tag = False
            pH(h2).Enabled = False
            For i = 0 To ord.Count - 1
                If ord(i) = h2 Then
                    ord.RemoveAt(i)
                    Exit For
                End If
            Next
            pH(h2).Image = RGB2BW(pH(h2).Image)
        End If
    End Sub

    Private Function RGB2BW(ByVal bm As Image)
        Dim Height As Integer = bm.Height
        Dim Width As Integer = bm.Width
        Dim newBitmap As Bitmap = New Bitmap(Width, Height)
        Dim oldBitmap As Bitmap = bm
        Dim pixel As Color
        For x As Integer = 1 To Width - 1
            For y As Integer = 1 To Height - 1
                pixel = oldBitmap.GetPixel(x, y)
                Dim r, g, b As Integer, Result As Integer = 0
                r = pixel.R
                g = pixel.G
                b = pixel.B
                Result = 0.7 * r + 0.2 * g + 0.1 * b
                newBitmap.SetPixel(x, y, Color.FromArgb(Result, Result, Result))
            Next
        Next
        Return newBitmap
    End Function

End Class

'底片
'Private Function RGB2BW(ByVal PicFile As Image) As Bitmap
'    Dim Height As Integer = PicFile.Height, Width As Integer = PicFile.Width
'    Dim newbitmap As Bitmap = New Bitmap(Width, Height), oldbitmap As Bitmap = PicFile, pixel As Color
'    For x As Integer = 1 To Width - 1
'        For y As Integer = 1 To Height - 1
'            Dim r, g, b As Integer
'            pixel = oldbitmap.GetPixel(x, y)
'            r = 255 - pixel.R
'            g = 255 - pixel.G
'            b = 255 - pixel.B
'            newbitmap.SetPixel(x, y, Color.FromArgb(r, g, b))
'        Next
'    Next
'    Return newbitmap
'End Function