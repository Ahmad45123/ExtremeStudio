Imports System.Windows.Forms

Public Interface extremePlugin

    'This list should be filled in the 'OnPluginInit' function.
    Property ToolStripButtons As List(Of ToolStripButton)

    'To be called as a class.. All available functions are the "funcsHandler" in the ExtremeStudio project.
    Property extremeStudioFuncs As Object

    'This is meant to be used to fill the list above with needed buttons which will be added to the tool-strip.
    Sub OnPluginInit() 'NOTE: Any other stuff can be done here too...

    Sub OnButtonPress(ByVal listid As Integer) 'listid = id in the ToolStripButtons list.

End Interface
