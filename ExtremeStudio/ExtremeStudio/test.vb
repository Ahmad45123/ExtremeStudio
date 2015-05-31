Public Class test
    Implements ExtremeCore.extremePlugin

    Public Property extremeStudioFuncs As Object Implements ExtremeCore.extremePlugin.extremeStudioFuncs

    Public Sub OnButtonPress(listid As Integer) Implements ExtremeCore.extremePlugin.OnButtonPress
        extremeStudioFuncs.SendMsg("sds")
    End Sub

    Public Sub OnPluginInit() Implements ExtremeCore.extremePlugin.OnPluginInit

    End Sub

    Public Property ToolStripButtons As List(Of ToolStripButton) Implements ExtremeCore.extremePlugin.ToolStripButtons
End Class
