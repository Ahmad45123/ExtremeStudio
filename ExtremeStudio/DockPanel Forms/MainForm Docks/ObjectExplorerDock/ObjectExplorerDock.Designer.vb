<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ObjectExplorerDock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ObjectExplorerDock))
        Me.treeView = New System.Windows.Forms.TreeView()
        Me.MenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip.SuspendLayout
        Me.SuspendLayout
        '
        'treeView
        '
        resources.ApplyResources(Me.treeView, "treeView")
        Me.treeView.ContextMenuStrip = Me.MenuStrip
        Me.treeView.Name = "treeView"
        Me.treeView.ShowNodeToolTips = true
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator1, Me.EditItemsToolStripMenuItem})
        Me.MenuStrip.Name = "MenuStrip"
        resources.ApplyResources(Me.MenuStrip, "MenuStrip")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'EditItemsToolStripMenuItem
        '
        Me.EditItemsToolStripMenuItem.Name = "EditItemsToolStripMenuItem"
        resources.ApplyResources(Me.EditItemsToolStripMenuItem, "EditItemsToolStripMenuItem")
        '
        'SearchTextBox
        '
        resources.ApplyResources(Me.SearchTextBox, "SearchTextBox")
        Me.SearchTextBox.Name = "SearchTextBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Label1.ForeColor = System.Drawing.Color.DarkGray
        Me.Label1.Name = "Label1"
        '
        'ObjectExplorerDock
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SearchTextBox)
        Me.Controls.Add(Me.treeView)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom),WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Name = "ObjectExplorerDock"
        Me.MenuStrip.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents treeView As System.Windows.Forms.TreeView
    Friend WithEvents MenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SearchTextBox As TextBox
    Friend WithEvents Label1 As Label
End Class
