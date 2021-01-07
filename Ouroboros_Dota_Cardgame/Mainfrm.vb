Imports LuaInterface

Public Class Mainfrm

    Private Sub Mainfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim newlua As New Lua
        newlua.RegisterFunction("testmsg", sender, sender.GetType().GetMethod("testmsg"))
        newlua.DoFile("script\test.lua")
        newlua.GetFunction("testf").Call()
    End Sub

    Public Sub testmsg(ByVal s As String)
        MsgBox(s)
    End Sub

End Class
