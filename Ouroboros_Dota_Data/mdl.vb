Imports System.Data.SQLite
Imports System.IO

Module mdl
    Public DotaVer As String = "7.18"
    Public cn As SQLiteConnection = New SQLiteConnection("Data Source=Dota2Data.ddb")
    'Public fp As String = vbNullString
    Public dRole As Dictionary(Of String, String)
    Public dQlt As Dictionary(Of String, String)
    Public dLen As New Dictionary(Of String, String)
    Public dLchs As New Dictionary(Of String, String)
    'Public dLcht As New Dictionary(Of String, String)
    Public saR() As String = {"diff", "cryl", "disl", "intl", "jgll", "sptl", "drbl", "nukl", "pshl", "espl"}
    Public saRC() As String = {"难度", "核心", "控制", "先手", "打野", "支援", "耐久", "爆发", "推进", "逃生"}

    Private Sub DicInt()
        dRole.Add("Carry", "核心")
        dRole.Add("Disabler", "控制")
        dRole.Add("Initiator", "先手")
        dRole.Add("Jungler", "打野")
        dRole.Add("Support", "支援")
        dRole.Add("Durable", "耐久")
        dRole.Add("Nuker", "爆发")
        dRole.Add("Pusher", "推进")
        dRole.Add("Escape", "逃生")
        dQlt.Add("consumable", "消耗品")
        dQlt.Add("component", "部件")
        dQlt.Add("common", "普通")
        dQlt.Add("rare", "稀有")
        dQlt.Add("epic", "史诗")
        dQlt.Add("artifact", "圣器")
        dQlt.Add("secret_shop", "神秘商店")
    End Sub

    Public Sub LangDic(ByVal d As Dictionary(Of String, String), ByVal fn As String, Optional ByVal ap As Boolean = True)
        'AbilityDamage
        'AbilityDuration 
        'DOTA_ToolTip_
        'DOTA_HeroRole_
        If Not ap Then d.Clear()
        Dim sr As New StreamReader($"file\{fn}.txt")
        'Do
        'Loop Until sr.ReadLine.Contains("{")
        'Do
        'Loop Until sr.ReadLine.Contains("{")
        Dim k As String = vbNullString
        Do Until sr.EndOfStream
            Dim l As String = sr.ReadLine.Replace(vbTab, vbNullString)
            If l = vbNullString Then
                Continue Do
            End If
            If l.First = "{" Then Continue Do
            If l.First = "}" Then Exit Do
            If l.Contains(""""c) Then 'l.First = """"c
                Dim m() As String = l.Split(""""c)
                If m.Length < 4 OrElse m(3) = Nothing Then Continue Do
                k = m(1).ToUpper
                If k.First = "["c Then Continue Do
                'If k.Length > 13 AndAlso k.Substring(0, 13) <> "DOTA_TOOLTIP_" Then Continue Do
                If d.ContainsKey(k) Then Continue Do
                'm(3) = Replace(m(3), "<br><br>", vbNullString)
                m(3) = m(3).Replace("<br>", vbCrLf).Replace("\n", vbCrLf)
                If m.GetUpperBound(0) > 3 Then
                    For i = 4 To m.GetUpperBound(0) - 1
                        m(3) &= """" & m(i)
                    Next
                End If
                If m(3).Contains("<font") Then
                    m(3) = m(3).Replace("</font>", vbNullString)
                    Dim st As String = vbNullString
                    Dim j As Integer = 0
                    Do Until j = m(3).Length
                        If m(3)(j) = "<"c Then
                            Do While m(3)(j) <> ">"c
                                j += 1
                            Loop
                        Else
                            st &= m(3)(j)
                        End If
                        j += 1
                    Loop
                    m(3) = st
                End If
                d.Add(k, m(3))
            ElseIf l.First <> "/"c Then
                'l = Replace(l, "<br><br>", vbNullString)
                l = l.Replace("<br>", vbCrLf)
                If d.ContainsKey(k) Then d(k) &= l.Substring(0, l.Length - 1)
            End If
        Loop
        sr.Close()
    End Sub

    Public Function DicCK(ByVal k As String) As Boolean
        k = k.ToUpper
        If dLchs.ContainsKey(k) OrElse dLen.ContainsKey(k) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function DicV(ByVal k As String) As String
        k = k.ToUpper
        If dLchs.ContainsKey(k) Then
            Return dLchs(k)
        ElseIf dLen.ContainsKey(k) Then
            Return dLen(k)
        Else
            Return vbNullString
        End If
    End Function

    'Function fpSEL() As Boolean
    '    Dim fbd As New FolderBrowserDialog
    '    With fbd
    '        .Description = "请选择dota 2 beta文件夹"
    '        .ShowNewFolderButton = False
    '        Do
    '            Dim dr As DialogResult = .ShowDialog()
    '            If dr = DialogResult.OK Then
    '                Dim sp() As String = .SelectedPath.Split("\"c)
    '                If sp.Last = "dota 2 beta" Then
    '                    '需要检查文件是否存在
    '                    fp = .SelectedPath
    '                    Dim sr As New StreamWriter("config.ini")
    '                    sr.Write(fp)
    '                    sr.Close()
    '                    Return True
    '                End If
    '            ElseIf dr = DialogResult.Cancel Then
    '                Return False
    '            End If
    '        Loop
    '    End With
    'End Function

End Module
