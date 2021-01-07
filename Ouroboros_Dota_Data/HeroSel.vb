Imports System.IO
Imports System.Data.SQLite

Public Class HeroSel
    Dim rdy As Boolean = False
    Dim tlp(2) As TableLayoutPanel
    Dim dHS As New Dictionary(Of String, Button)
    Dim ckR(9, 2) As CheckBox
    Dim sqlH As String = vbNullString

    Private Sub HeroSel_Load(sender As Object, e As EventArgs) Handles Me.Load
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT prim,hn,hnc FROM hero ORDER BY prim,hnc", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader() '数据库丢失的情况
        Dim dtP As New DataTable
        dtP.Load(dr)
        dr.Close()
        If dtP.Rows.Count = 0 Then
            cn.Close()
            MessageBox.Show("请更新数据")
            Upd.Show()
            Close()
        End If
        tlp = {tlpS, tlpA, tlpI}
        ckR = {{c00, c01, c02}, {c10, c11, c12}, {c20, c21, c22}, {c30, c31, c32}, {c40, c41, c42}, {c50, c51, c52}, {c60, c61, c62}, {c70, c71, c72}, {c80, c81, c82}, {c90, c91, c92}}
        dHS.Clear()
        For i = 0 To dtP.Rows.Count - 1
            Dim p As New Button
            tlp(dtP(i)("prim")).Controls.Add(p)
            With p
                .Dock = DockStyle.Fill
                .Name = dtP(i)("hn")
                .Margin = New Padding(0, 0, 0, 0)
                If File.Exists("pic\hero\" & .Name & ".png") Then
                    .Image = New Bitmap(Image.FromFile("pic\hero\" & .Name & ".png"), .Size) '锯齿问题
                Else
                    If DicCK("NPC_DOTA_HERO_" & .Name) Then
                        .TextImageRelation = TextImageRelation.Overlay
                        .ForeColor = Color.White
                        '.Font = New Font("宋体", 8)
                        .Text = DicV("NPC_DOTA_HERO_" & .Name)
                    End If
                    .Image = New Bitmap(My.Resources.img_uk_h, .Size)
                End If
            End With
            AddHandler p.Click, AddressOf nForm
            dHS.Add(p.Name, p)
        Next
        rdy = True
    End Sub

    Private Sub c_Checked(sender As CheckBox, e As EventArgs) Handles cA0.CheckedChanged, cA1.CheckedChanged, c00.CheckedChanged, c01.CheckedChanged, c02.CheckedChanged, c10.CheckedChanged, c11.CheckedChanged, c12.CheckedChanged, c20.CheckedChanged, c21.CheckedChanged, c22.CheckedChanged, c30.CheckedChanged, c31.CheckedChanged, c32.CheckedChanged, c40.CheckedChanged, c41.CheckedChanged, c42.CheckedChanged, c50.CheckedChanged, c51.CheckedChanged, c52.CheckedChanged, c60.CheckedChanged, c61.CheckedChanged, c62.CheckedChanged, c70.CheckedChanged, c71.CheckedChanged, c72.CheckedChanged, c80.CheckedChanged, c81.CheckedChanged, c82.CheckedChanged, c90.CheckedChanged, c91.CheckedChanged, c92.CheckedChanged, cNPE.CheckedChanged
        If Not rdy Then Exit Sub
        hFLT(sender.Name.Substring(1))
    End Sub

    Private Sub hFLT(Optional ByVal ncs As String = vbNullString)
        rdy = False
        For i = 0 To 2
            For Each b As Button In tlp(i).Controls
                If b.Enabled Then b.Enabled = False
            Next
        Next
        If cn.State = ConnectionState.Closed Then cn.Open()
        sqlH = vbNullString
        For j = 0 To 2
            If ckR(0, j).Checked Then
                sqlH &= " OR diff=" & (j + 1).ToString
            End If
        Next
        If sqlH <> vbNullString Then
            sqlH = "(" & sqlH.Substring(4) & ")"
        Else
            sqlH = "diff=0"
        End If
        Dim sW1 As String = vbNullString
        Dim ii, jj As Integer
        If IsNumeric(ncs) Then
            ii = Convert.ToInt32(ncs.First) - 48
            jj = Convert.ToInt32(ncs.Last) - 48
        End If
        For i = 1 To 9
            Dim sR As String = vbNullString
            If i = ii Then
                Select Case jj
                    Case 0
                        If ckR(i, 1).Checked Then ckR(i, 0).Checked = True
                        ckR(i, 1).Checked = False
                        ckR(i, 2).Checked = False
                    Case 1
                        ckR(i, 0).Checked = True
                        ckR(i, 1).Checked = True
                        ckR(i, 2).Checked = False
                    Case 2
                        ckR(i, 0).Checked = True
                        ckR(i, 1).Checked = True
                        ckR(i, 2).Checked = True
                End Select
                If ckR(i, jj).Checked Then sR &= $" OR {saR(i)}>={jj + 1}"
            Else
                For j = 2 To 0 Step -1
                    If ckR(i, j).Checked Then
                        sR &= $" OR {saR(i)}>={j + 1}"
                        Exit For
                    End If
                Next
            End If
            If sR <> vbNullString Then sW1 &= $" AND ({sR.Substring(4)})"
        Next
        sqlH &= sW1
        If cA0.Checked Then
            If Not cA1.Checked Then sqlH &= " AND cap=0"
        Else
            If cA1.Checked Then
                sqlH &= " AND cap=1"
            Else
                sqlH &= " AND cap=-1"
            End If
        End If
        If cNPE.Checked Then
            sqlH &= " AND npe=1"
        End If
        Dim cdF As SQLiteCommand = New SQLiteCommand($"SELECT hn FROM hero WHERE {sqlH} ORDER BY prim", cn)
        Dim drF As SQLiteDataReader = cdF.ExecuteReader()
        Dim dtF As New DataTable
        dtF.Load(drF)
        drF.Close()
        For i = 0 To dtF.Rows.Count - 1
            dHS(dtF(i)("hn")).Enabled = True
        Next
        bFR.Focus()
        rdy = True
    End Sub

    Private Sub bFR_Click(sender As Object, e As EventArgs) Handles bFR.Click
        rdy = False
        ckR(0, 0).Checked = True
        ckR(0, 1).Checked = True
        ckR(0, 2).Checked = True
        cA0.Checked = True
        cA1.Checked = True
        cNPE.Checked = False
        For i = 1 To 9
            For j = 0 To 2
                ckR(i, j).Checked = False
            Next
        Next
        rdy = True
        hFLT()
    End Sub

    Private Sub bRND_Click(sender As Object, e As EventArgs) Handles bRND.Click
        Dim sqlR As String = sqlH
        If sqlH <> vbNullString Then sqlR = "WHERE " & sqlH
        Dim cdR As SQLiteCommand = New SQLiteCommand($"SELECT hn FROM hero {sqlR} ORDER BY random() LIMIT 1", cn)
        Dim drR As SQLiteDataReader = cdR.ExecuteReader()
        Dim dtR As New DataTable
        dtR.Load(drR)
        drR.Close()
        Dim hR As String = dtR(0)(0).ToString
        dHS(hR).Select()
        Call nForm(dHS(hR), Nothing)
    End Sub

    Private Sub cBP_CheckedChanged(sender As Object, e As EventArgs) Handles cBP.CheckedChanged
        Dim c As Boolean = Not cBP.Checked
        Call bFR_Click(Nothing, Nothing)
        For i = 0 To 9
            For j = 0 To 2
                ckR(i, j).Enabled = c
            Next
        Next
        cA0.Enabled = c
        cA1.Enabled = c
        bFR.Enabled = c
    End Sub

    Private Sub nForm(sender As Button, e As EventArgs)
        If cBP.Checked Then
            sender.Enabled = Not sender.Enabled
            cBP.Focus()
        Else
            Dim hi As New HeroIfm
            hi.hn = sender.Name
            hi.Show()
        End If
    End Sub

    Private Sub HeroSel_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        StartUp.Show()
    End Sub

End Class

