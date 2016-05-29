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
        resources.ApplyResources(Me.mouseRightClick, "mouseRightClick")
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        resources.ApplyResources(Me.RefreshToolStripMenuItem, "RefreshToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        resources.ApplyResources(Me.RenameToolStripMenuItem, "RenameToolStripMenuItem")
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        resources.ApplyResources(Me.DeleteToolStripMenuItem, "DeleteToolStripMenuItem")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'NewFileToolStripMenuItem
        '
        Me.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem"
        resources.ApplyResources(Me.NewFileToolStripMenuItem, "NewFileToolStripMenuItem")
        '
        'NewDirectoryToolStripMenuItem
        '
        Me.NewDirectoryToolStripMenuItem.Name = "NewDirectoryToolStripMenuItem"
        resources.ApplyResources(Me.NewDirectoryToolStripMenuItem, "NewDirectoryToolStripMenuItem")
        '
        'filesList
        '
        resources.ApplyResources(Me.filesList, "filesList")
        Me.filesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.filesList.FileIconSize = ExtremeCore.IconSize.Small
        Me.filesList.FormattingEnabled = true
        Me.filesList.MainDir = "C:/"
        Me.filesList.Name = "filesList"
        '
        'ProjExplorerDock
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.filesList)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom),WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Name = "ProjExplorerDock"
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
