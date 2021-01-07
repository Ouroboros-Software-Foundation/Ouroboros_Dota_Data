Imports System.IO
Imports System.Data.SQLite

Public Class UnitIfm
    Dim dtU0 As New DataTable
    Dim dtU() As DataTable
    Dim sUS() As String = {"creep_lane,creep_siege", "creep_neutral", "tower,filler,healer,building,fort"}
    Dim ckUS() As CheckBox

    Private Sub UnitIfm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ckUS = {ckC, ckN, ckB}
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cd As SQLiteCommand = New SQLiteCommand("SELECT * FROM unit", cn)
        Dim dr As SQLiteDataReader = cd.ExecuteReader()
        dtU0.Load(dr)
        dr.Close()
        If dtU0.Rows.Count = 0 Then
            cn.Close()
            MessageBox.Show("请更新数据")
            Upd.Show()
            Close()
        End If

    End Sub

End Class