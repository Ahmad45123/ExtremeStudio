<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObjectExplorerDock
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
        Me.components = New System.ComponentModel.Container()
        Me.treeView = New System.Windows.Forms.TreeView()
        Me.MenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'treeView
        '
        Me.treeView.ContextMenuStrip = Me.MenuStrip
        Me.treeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeView.Location = New System.Drawing.Point(0, 0)
        Me.treeView.Name = "treeView"
        Me.treeView.Size = New System.Drawing.Size(245, 402)
        Me.treeView.TabIndex = 0
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditItemsToolStripMenuItem})
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(127, 26)
        '
        'EditItemsToolStripMenuItem
        '
        Me.EditItemsToolStripMenuItem.Name = "EditItemsToolStripMenuItem"
        Me.EditItemsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditItemsToolStripMenuItem.Text = "Edit Items"
        '
        'ObjectExplorerDock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(245, 402)
        Me.Controls.Add(Me.treeView)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "ObjectExplorerDock"
        Me.Text = "Object Explorer"
        Me.MenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents treeView As System.Windows.Forms.TreeView
    Friend WithEvents MenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
