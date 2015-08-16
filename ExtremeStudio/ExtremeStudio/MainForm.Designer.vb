<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

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
        Dim DockPanelSkin1 As WeifenLuo.WinFormsUI.Docking.DockPanelSkin = New WeifenLuo.WinFormsUI.Docking.DockPanelSkin()
        Dim AutoHideStripSkin1 As WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin = New WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin()
        Dim DockPanelGradient1 As WeifenLuo.WinFormsUI.Docking.DockPanelGradient = New WeifenLuo.WinFormsUI.Docking.DockPanelGradient()
        Dim TabGradient1 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim DockPaneStripSkin1 As WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin = New WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin()
        Dim DockPaneStripGradient1 As WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient = New WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient()
        Dim TabGradient2 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim DockPanelGradient2 As WeifenLuo.WinFormsUI.Docking.DockPanelGradient = New WeifenLuo.WinFormsUI.Docking.DockPanelGradient()
        Dim TabGradient3 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim DockPaneStripToolWindowGradient1 As WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient = New WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient()
        Dim TabGradient4 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim TabGradient5 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim DockPanelGradient3 As WeifenLuo.WinFormsUI.Docking.DockPanelGradient = New WeifenLuo.WinFormsUI.Docking.DockPanelGradient()
        Dim TabGradient6 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim TabGradient7 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MainDock = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ProjectExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObjectExplorerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorsAndWarningsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainDock
        '
        Me.MainDock.ActiveAutoHideContent = Nothing
        Me.MainDock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainDock.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.MainDock.DockBackColor = System.Drawing.SystemColors.Control
        Me.MainDock.Location = New System.Drawing.Point(0, 53)
        Me.MainDock.Name = "MainDock"
        Me.MainDock.Size = New System.Drawing.Size(938, 384)
        DockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight
        DockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight
        AutoHideStripSkin1.DockStripGradient = DockPanelGradient1
        TabGradient1.EndColor = System.Drawing.SystemColors.Control
        TabGradient1.StartColor = System.Drawing.SystemColors.Control
        TabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark
        AutoHideStripSkin1.TabGradient = TabGradient1
        DockPanelSkin1.AutoHideStripSkin = AutoHideStripSkin1
        TabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight
        TabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight
        TabGradient2.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripGradient1.ActiveTabGradient = TabGradient2
        DockPanelGradient2.EndColor = System.Drawing.SystemColors.Control
        DockPanelGradient2.StartColor = System.Drawing.SystemColors.Control
        DockPaneStripGradient1.DockStripGradient = DockPanelGradient2
        TabGradient3.EndColor = System.Drawing.SystemColors.ControlLight
        TabGradient3.StartColor = System.Drawing.SystemColors.ControlLight
        TabGradient3.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripGradient1.InactiveTabGradient = TabGradient3
        DockPaneStripSkin1.DocumentGradient = DockPaneStripGradient1
        TabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption
        TabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        TabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption
        TabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        DockPaneStripToolWindowGradient1.ActiveCaptionGradient = TabGradient4
        TabGradient5.EndColor = System.Drawing.SystemColors.Control
        TabGradient5.StartColor = System.Drawing.SystemColors.Control
        TabGradient5.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripToolWindowGradient1.ActiveTabGradient = TabGradient5
        DockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight
        DockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight
        DockPaneStripToolWindowGradient1.DockStripGradient = DockPanelGradient3
        TabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption
        TabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        TabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption
        TabGradient6.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripToolWindowGradient1.InactiveCaptionGradient = TabGradient6
        TabGradient7.EndColor = System.Drawing.Color.Transparent
        TabGradient7.StartColor = System.Drawing.Color.Transparent
        TabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark
        DockPaneStripToolWindowGradient1.InactiveTabGradient = TabGradient7
        DockPaneStripSkin1.ToolWindowGradient = DockPaneStripToolWindowGradient1
        DockPanelSkin1.DockPaneStripSkin = DockPaneStripSkin1
        Me.MainDock.Skin = DockPanelSkin1
        Me.MainDock.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator2, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripSeparator1, Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(938, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(938, 25)
        Me.ToolStrip2.TabIndex = 7
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(938, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLabel
        '
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(26, 17)
        Me.statusLabel.Text = "Idle"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.ExtremeStudio.My.Resources.Resources.new_file_toolstrip
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "New File"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.ExtremeStudio.My.Resources.Resources.save_file_toolstrip
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Save"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.ExtremeStudio.My.Resources.Resources.saveall_file_toolstrip
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Save All"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProjectExplorerToolStripMenuItem, Me.ObjectExplorerToolStripMenuItem, Me.ErrorsAndWarningsToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripDropDownButton1.Text = "View"
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'ProjectExplorerToolStripMenuItem
        '
        Me.ProjectExplorerToolStripMenuItem.Name = "ProjectExplorerToolStripMenuItem"
        Me.ProjectExplorerToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ProjectExplorerToolStripMenuItem.Text = "Project Explorer"
        '
        'ObjectExplorerToolStripMenuItem
        '
        Me.ObjectExplorerToolStripMenuItem.Name = "ObjectExplorerToolStripMenuItem"
        Me.ObjectExplorerToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ObjectExplorerToolStripMenuItem.Text = "Object Explorer"
        '
        'ErrorsAndWarningsToolStripMenuItem
        '
        Me.ErrorsAndWarningsToolStripMenuItem.Name = "ErrorsAndWarningsToolStripMenuItem"
        Me.ErrorsAndWarningsToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ErrorsAndWarningsToolStripMenuItem.Text = "Errors And Warnings"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.ExtremeStudio.My.Resources.Resources.includes_icon_toolstrip
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Includes"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = Global.ExtremeStudio.My.Resources.Resources.plugins_icon_toolstrip
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Plugins"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 462)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MainDock)
        Me.IsMdiContainer = True
        Me.Name = "MainForm"
        Me.Text = "Extreme Studio - Project"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainDock As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ProjectExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ObjectExplorerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorsAndWarningsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
End Class
