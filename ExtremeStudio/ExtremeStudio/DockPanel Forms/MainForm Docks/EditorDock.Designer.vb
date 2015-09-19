<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorDock
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorDock))
        Me.Editor = New ScintillaNET.Scintilla()
        Me.RefreshWorker = New System.ComponentModel.BackgroundWorker()
        Me.AutoCompleteMenu = New AutocompleteMenuNS.AutocompleteMenu()
        Me.SuspendLayout()
        '
        'Editor
        '
        Me.Editor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Editor.Location = New System.Drawing.Point(0, 0)
        Me.Editor.Name = "Editor"
        Me.Editor.Size = New System.Drawing.Size(566, 417)
        Me.Editor.TabIndex = 0
        Me.Editor.Text = "Scintilla1"
        Me.Editor.UseTabs = False
        '
        'RefreshWorker
        '
        '
        'AutoCompleteMenu
        '
        Me.AutoCompleteMenu.Colors = CType(resources.GetObject("AutoCompleteMenu.Colors"), AutocompleteMenuNS.Colors)
        Me.AutoCompleteMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.AutoCompleteMenu.ImageList = Nothing
        Me.AutoCompleteMenu.Items = New String(-1) {}
        Me.AutoCompleteMenu.TargetControlWrapper = Nothing
        '
        'EditorDock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 417)
        Me.Controls.Add(Me.Editor)
        Me.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "EditorDock"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RefreshWorker As System.ComponentModel.BackgroundWorker
    Public WithEvents Editor As ScintillaNET.Scintilla
    Friend WithEvents AutoCompleteMenu As AutocompleteMenuNS.AutocompleteMenu
End Class
