<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjExplorerDock
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gamemode Parts")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Filterscripts")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Includes")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjExplorerDock))
        Me.treeView = New System.Windows.Forms.TreeView()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.mouseRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mouseRightClick.SuspendLayout()
        Me.SuspendLayout()
        '
        'treeView
        '
        Me.treeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeView.ImageIndex = 0
        Me.treeView.ImageList = Me.ImageList
        Me.treeView.LabelEdit = True
        Me.treeView.Location = New System.Drawing.Point(0, 0)
        Me.treeView.Name = "treeView"
        TreeNode1.Name = "Node0"
        TreeNode1.Text = "Gamemode Parts"
        TreeNode2.Name = "Node2"
        TreeNode2.Text = "Filterscripts"
        TreeNode3.Name = "Node1"
        TreeNode3.Text = "Includes"
        Me.treeView.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Me.treeView.SelectedImageIndex = 2
        Me.treeView.Size = New System.Drawing.Size(254, 382)
        Me.treeView.TabIndex = 0
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "dirs_projexplorer.png")
        Me.ImageList.Images.SetKeyName(1, "file_projexplorer.png")
        Me.ImageList.Images.SetKeyName(2, "correct_projexplorer.png")
        '
        'mouseRightClick
        '
        Me.mouseRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenameToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.NewFileToolStripMenuItem, Me.NewDirectoryToolStripMenuItem})
        Me.mouseRightClick.Name = "mouseRightClick"
        Me.mouseRightClick.Size = New System.Drawing.Size(153, 120)
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'NewFileToolStripMenuItem
        '
        Me.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem"
        Me.NewFileToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NewFileToolStripMenuItem.Text = "New File"
        '
        'NewDirectoryToolStripMenuItem
        '
        Me.NewDirectoryToolStripMenuItem.Name = "NewDirectoryToolStripMenuItem"
        Me.NewDirectoryToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NewDirectoryToolStripMenuItem.Text = "New Directory"
        '
        'ProjExplorerDock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 382)
        Me.Controls.Add(Me.treeView)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "ProjExplorerDock"
        Me.Text = "Project Explorer"
        Me.mouseRightClick.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents treeView As System.Windows.Forms.TreeView
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents mouseRightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
