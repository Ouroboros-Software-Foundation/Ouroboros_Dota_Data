Imports System.IO

Public Class Form1
    WithEvents wb As New WebBrowser

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox(Application.StartupPath & "\w.html")
        wb.ScriptErrorsSuppressed = True
        'wb.Url = New Uri($"https://dota2.gamepedia.com/Emoticons")
        'wb.Url = New Uri("https://www.baidu.com")
        wb.Url = New Uri("file:///" & Application.StartupPath & "\w.html")
    End Sub

    Private Sub wbDC() Handles wb.DocumentCompleted
        MsgBox("cplt")
        Dim dtR(4) As DataTable
        Dim c As HtmlElementCollection = wb.Document.GetElementsByTagName("table")
        Dim aGIF() As String
        For Each e As HtmlElement In c
            Dim t As String = e.GetAttribute("CLASSNAME")
            If t.Contains("wikitable") Then
                MsgBox("1")
                '    dtI += 1
                '    dtR(dtI) = New DataTable
                '    Dim eTH As HtmlElementCollection = e.GetElementsByTagName("thead")(0).GetElementsByTagName("th")
                '    For dhI = 0 To eTH.Count - 1
                '        dtR(dtI).Columns.Add(eTH(dhI).InnerText)
                '    Next
                '    dtR(dtI).Columns.Add("img")
                '    'MsgBox(dtR(dtI).Columns.Count)
                '    Dim eTR As HtmlElementCollection = e.GetElementsByTagName("tbody")(0).GetElementsByTagName("tr")
                '    For drI = 0 To eTR.Count - 1
                '        dtR(dtI).Rows.Add()
                '        Dim eTD As HtmlElementCollection = eTR(drI).GetElementsByTagName("td")
                '        For dcI = 0 To eTD.Count - 1
                '            dtR(dtI)(drI)(dcI) = eTD(dcI).InnerText
                '        Next
                '        Dim src As String = eTD(0).GetElementsByTagName("img")(0).GetAttribute("src").Split("/"c).Last.Split("."c).First
                '        Dim srcA() As String = src.Split("_"c)
                '        src = vbNullString
                '        For j = 0 To srcA.Length - 2
                '            src &= "_" & srcA(j)
                '        Next
                '        dtR(dtI)(drI)("img") = src.Substring(1)
                '    Next
            End If
        Next
        wb.Dispose()
    End Sub


End Class
