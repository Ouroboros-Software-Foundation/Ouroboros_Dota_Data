Imports System.Data.SQLite

Public Class DataTab
    Private Sub DataTab_Load(sender As Object, e As EventArgs) Handles Me.Load
        If cn.State = ConnectionState.Closed Then cn.Open()
    End Sub

    Dim colN() As String = {"hnc", "prims", "strb", "strg", "str25", "agib", "agig", "agi25", "intb", "intg", "int25", "atk1", "atk25", "atkd", "aap", "bat1", "bat25", "rng", "pspd", "amr1", "amr25", "res", "mov"}
    Dim tI As Type = New Integer.GetType
    Dim tD As Type = New Decimal.GetType
    Dim tS As Type = String.Empty.GetType
    Dim colT() As Type = {tS, tS, tI, tD, tI, tI, tD, tI, tI, tD, tI, tI, tI, tI, tD, tD, tD, tI, tI, tD, tD, tI, tI}
    Dim colS() As String = {"英雄名", "主属性", "初始力量", "力量成长", "满级力量", "初始敏捷", "敏捷成长", "满级敏捷", "初始智力", "智力成长", "满级智力", "初始攻击力", "满级攻击力", "攻击浮动", "攻击前摇", "初始攻击间隔", "满级攻击间隔", "射程", "弹道速度", "初始护甲", "满级护甲", "魔法抗性", "移动速度"}
    Dim prim() As String = {"str", "agi", "int"}
    Private Sub menuH_Click(sender As Object, e As EventArgs) Handles menuH.Click
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT * FROM hero", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(dr)
        dr.Close()
        Dim dtH As New DataTable
        For i = 0 To colN.GetUpperBound(0)
            dtH.Columns.Add(colN(i), colT(i))
        Next
        For r = 0 To dt.Rows.Count - 1
            dtH.Rows.Add()
            For c = 0 To colN.GetUpperBound(0)
                If dt.Columns.Contains(colN(c)) Then
                    dtH(r)(c) = dt(r)(colN(c))
                Else
                    Select Case colN(c)
                        Case "prims"
                            dtH(r)(c) = prim(dt(r)("prim"))
                        Case "str25", "agi25", "int25"
                            Dim p As String = colN(c).Substring(0, 3)
                            dtH(r)(c) = Math.Round(dt(r)(p & "b") + dt(r)(p & "g") * 24)
                        Case "atk1"
                            dtH(r)(c) = Math.Round((dt(r)("amin") + dt(r)("amax")) / 2) + dtH(r)(prim(dt(r)("prim")) & "b")
                        Case "atk25"
                            dtH(r)(c) = Math.Round((dt(r)("amin") + dt(r)("amax")) / 2) + dtH(r)(prim(dt(r)("prim")) & "25")
                        Case "atkd"
                            dtH(r)(c) = dt(r)("amax") - dt(r)("amin")
                        Case "bat1"
                            dtH(r)(c) = Math.Round((dt(r)("bat") * 170) / (dt(r)("agib") * dt(r)("bat") + 170), 2)
                        Case "bat25"
                            dtH(r)(c) = Math.Round((dt(r)("bat") * 170) / (dtH(r)("agi25") * dt(r)("bat") + 170), 2)
                        Case "pspd"
                            If dt(r)("cap") = 1 Then
                                dtH(r)(c) = dt(r)("ps")
                            End If
                        Case "amr1"
                            dtH(r)(c) = Math.Round(dt(r)("amr") + dt(r)("agib") / 7, 2)
                        Case "amr25"
                            dtH(r)(c) = Math.Round(dt(r)("amr") + dtH(r)("agi25") / 7, 2)
                    End Select
                End If
            Next
        Next
        dgv.DataSource = dtH
        dgv.Columns(0).Frozen = True
        For i = 0 To dtH.Columns.Count - 1
            dgv.Columns(i).HeaderText = colS(i)
        Next
    End Sub

    Private Sub menuA_Click(sender As Object, e As EventArgs) Handles menuA.Click
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT * FROM ablt", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(dr)
        dr.Close()
        dgv.DataSource = dt
    End Sub

    Private Sub menuI_Click(sender As Object, e As EventArgs) Handles menuI.Click
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT * FROM item", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(dr)
        dr.Close()
        dgv.DataSource = dt
    End Sub

End Class