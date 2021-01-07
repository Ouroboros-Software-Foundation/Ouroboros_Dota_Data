Imports System.IO
Imports System.Diagnostics

Public Class StartUp

    Private Sub StartUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).GetUpperBound(0) > 0 Then
            MessageBox.Show("禁止运行多个程序实例", "提示")
            End
        End If
        sslV.Text = $"Ver {My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}.{My.Application.Info.Version.Revision}_beta"
        'MessageBox.Show("本程序处于测试阶段，此版本将于2017-09-01自动失效，请及时获取新版本" & vbCrLf & "如果遇到bug请及时练联系开发者QQ1160671498")
        'If Now > "2017-09-01" Then
        '    Application.Exit()
        'End If
        If Not File.Exists("Dota2Data.ddb") Then
            Dim b() As Byte = My.Resources.Dota2Data
            Dim s As Stream = File.Create("Dota2Data.ddb")
            s.Write(b, 0, b.Length)
            s.Close()
        End If
        If (Not File.Exists("file\dota_english.txt")) OrElse (Not File.Exists("file\dota_schinese.txt")) OrElse (Not File.Exists("file\abilities_english.txt")) OrElse (Not File.Exists("file\abilities_schinese.txt")) OrElse (Not File.Exists("file\hero_lore_english.txt")) OrElse (Not File.Exists("file\hero_lore_schinese.txt")) Then
            MessageBox.Show("字符串文件缺失，请更新数据", "文件缺失")
            Upd.Show()
            Close()
            Exit Sub
        End If
        LangDic(dLen, "dota_english", False)
        LangDic(dLen, "abilities_english")
        LangDic(dLen, "hero_lore_english")
        LangDic(dLchs, "dota_schinese", False)
        LangDic(dLchs, "abilities_schinese")
        LangDic(dLchs, "hero_lore_schinese")
    End Sub

    Private Sub bHERO_Click(sender As Object, e As EventArgs) Handles bHERO.Click
        HeroSel.Show()
        Hide()
    End Sub

    Private Sub bITEM_Click(sender As Object, e As EventArgs) Handles bITEM.Click
        ItemIfm.Show()
        Hide()
    End Sub

    Private Sub bUPD_Click(sender As Object, e As EventArgs) Handles bUPD.Click
        Upd.Show()
        Close()
    End Sub
    Private Sub bGAME_Click(sender As Object, e As EventArgs) Handles bGAME.Click
        Invoker.Show()
    End Sub

    Private Sub bQUIZ_Click(sender As Object, e As EventArgs) Handles bQUIZ.Click
        ItemQuiz.Show()
        Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        HeroGame.Show()
        Hide()
    End Sub
End Class