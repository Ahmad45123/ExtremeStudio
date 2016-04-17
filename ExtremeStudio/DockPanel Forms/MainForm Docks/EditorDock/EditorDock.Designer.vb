<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditorDock
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorDock))
        Me.Editor = New ScintillaNET.Scintilla()
        Me.RefreshWorker = New System.ComponentModel.BackgroundWorker()
        Me.AutoCompleteMenu = New AutocompleteMenuNS.AutocompleteMenu()
        Me.ACImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.colorizingWorker = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout
        '
        'Editor
        '
        Me.Editor.AdditionalSelectionTyping = true
        Me.Editor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Editor.Lexer = ScintillaNET.Lexer.Cpp
        Me.Editor.Location = New System.Drawing.Point(0, 0)
        Me.Editor.MouseDwellTime = 1000
        Me.Editor.MouseSelectionRectangularSwitch = true
        Me.Editor.MultiPaste = ScintillaNET.MultiPaste.[Each]
        Me.Editor.MultipleSelection = true
        Me.Editor.Name = "Editor"
        Me.Editor.Size = New System.Drawing.Size(566, 417)
        Me.Editor.TabIndex = 0
        Me.Editor.UseTabs = false
        Me.Editor.VirtualSpaceOptions = ScintillaNET.VirtualSpace.RectangularSelection
        '
        'RefreshWorker
        '
        Me.RefreshWorker.WorkerReportsProgress = true
        Me.RefreshWorker.WorkerSupportsCancellation = true
        '
        'AutoCompleteMenu
        '
        Me.AutoCompleteMenu.Colors = CType(resources.GetObject("AutoCompleteMenu.Colors"),AutocompleteMenuNS.Colors)
        Me.AutoCompleteMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!)
        Me.AutoCompleteMenu.ImageList = Me.ACImageList
        Me.AutoCompleteMenu.Items = New String() {"null"}
        Me.AutoCompleteMenu.TargetControlWrapper = Nothing
        Me.AutoCompleteMenu.ToolTipDuration = 10000000
        '
        'ACImageList
        '
        Me.ACImageList.ImageStream = CType(resources.GetObject("ACImageList.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ACImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ACImageList.Images.SetKeyName(0, "Functions")
        Me.ACImageList.Images.SetKeyName(1, "Defines")
        '
        'EditorDock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 417)
        Me.Controls.Add(Me.Editor)
        Me.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document
        Me.Font = New System.Drawing.Font("Tahoma", 8!)
        Me.Name = "EditorDock"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents RefreshWorker As System.ComponentModel.BackgroundWorker
    Public WithEvents Editor As ScintillaNET.Scintilla
    Friend WithEvents AutoCompleteMenu As AutocompleteMenuNS.AutocompleteMenu
    Friend WithEvents ACImageList As ImageList

    Public Sub New()
        'Opt in the fix for the bug with DockPanelSuite.
        ScintillaNET.Scintilla.SetDestroyHandleBehavior(True)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Friend WithEvents colorizingWorker As System.ComponentModel.BackgroundWorker
End Class
