'NOTE: This is not generally meant to be used for complex stuff, I'd rather you just fork the project and add your
'desired feature natively then open a pull request.. This plugin system is to be used for stuff that are a bit not IDE
'related like SAMP ID browser and such.
Imports System.Windows.Forms

Public Interface IExtremePlugin

    'Unique Plugin Name.
    ReadOnly Property PluginName As String

    'This list should be filled in the 'OnPluginInit' function.
    Property ToolStripButtons As List(Of RibbonButton)

    'To be called as a class.. All available functions are the "funcsHandler" in the ExtremeStudio project.
    Property ExtremeStudioFuncs As IPluginContext

    'This is meant to be used to fill the list above with needed buttons which will be added to the tool-strip.
    Sub OnPluginInit() 'NOTE: Any other stuff can be done here too...

End Interface
