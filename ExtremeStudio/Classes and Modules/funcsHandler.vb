Imports ExtremeCore
Imports ScintillaNET

Public Class FuncsHandler
    Implements IPluginContext

    Public ReadOnly Property CurrentEditor As Scintilla Implements IPluginContext.CurrentEditor
        Get
            Return MainForm.CurrentScintilla
        End Get
    End Property
End Class
