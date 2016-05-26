Imports System.ComponentModel.Composition
Imports ExtremeCore

Public Class PluginBootstrapper
    <ImportMany>
    Public Plugins As IEnumerable(Of IExtremePlugin)
End Class
