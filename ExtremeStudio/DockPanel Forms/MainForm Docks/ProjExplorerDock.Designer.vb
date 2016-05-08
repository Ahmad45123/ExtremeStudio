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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjExplorerDock))
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.mouseRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.filesList = New ExtremeCore.FilesListBox()
        Me.mouseRightClick.SuspendLayout
        Me.SuspendLayout
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "dirs_projexplorer.png")
        Me.ImageList.Images.SetKeyName(1, "file_projexplorer.png")
        Me.ImageList.Images.SetKeyName(2, "correct_projexplorer.png")
        '
        'mouseRightClick
        '
        Me.mouseRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.ToolStripSeparator1, Me.RenameToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem1, Me.NewFileToolStripMenuItem, Me.NewDirectoryToolStripMenuItem})
        Me.mouseRightClick.Name = "mouseRightClick"
        Me.mouseRightClick.Size = New System.Drawing.Size(150, 126)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(146, 6)
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(146, 6)
        '
        'NewFileToolStripMenuItem
        '
        Me.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem"
        Me.NewFileToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.NewFileToolStripMenuItem.Text = "New File"
        '
        'NewDirectoryToolStripMenuItem
        '
        Me.NewDirectoryToolStripMenuItem.Name = "NewDirectoryToolStripMenuItem"
        Me.NewDirectoryToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.NewDirectoryToolStripMenuItem.Text = "New Directory"
        '
        'filesList
        '
        Me.filesList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.filesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.filesList.FileIconSize = ExtremeCore.IconSize.Small
        Me.filesList.FormattingEnabled = true
        Me.filesList.ItemHeight = 16
        Me.filesList.Location = New System.Drawing.Point(0, 0)
        Me.filesList.MainDir = "C:/"
        Me.filesList.Name = "filesList"
        Me.filesList.Size = New System.Drawing.Size(254, 382)
        Me.filesList.TabIndex = 1
        '
        'ProjExplorerDock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(254, 382)
        Me.Controls.Add(Me.filesList)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom),WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8!)
        Me.Name = "ProjExplorerDock"
        Me.Text = "Project Explorer"
        Me.mouseRightClick.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents mouseRightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents filesList As ExtremeCore.FilesListBox
End Class
