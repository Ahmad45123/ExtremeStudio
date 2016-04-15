<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MainDock = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.mainRibbon = New System.Windows.Forms.Ribbon()
        Me.RibbonOrbMenuItem1 = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.RibbonOrbRecentItem1 = New System.Windows.Forms.RibbonOrbRecentItem()
        Me.closeProjectButton = New System.Windows.Forms.RibbonButton()
        Me.fileTab = New System.Windows.Forms.RibbonTab()
        Me.prjPanel = New System.Windows.Forms.RibbonPanel()
        Me.newFileButton = New System.Windows.Forms.RibbonButton()
        Me.saveFileButton = New System.Windows.Forms.RibbonButton()
        Me.saveAllButton = New System.Windows.Forms.RibbonButton()
        Me.downloadPanel = New System.Windows.Forms.RibbonPanel()
        Me.includesButton = New System.Windows.Forms.RibbonButton()
        Me.pluginsButton = New System.Windows.Forms.RibbonButton()
        Me.editTab = New System.Windows.Forms.RibbonTab()
        Me.clipboardPanel = New System.Windows.Forms.RibbonPanel()
        Me.cutButton = New System.Windows.Forms.RibbonButton()
        Me.copyButton = New System.Windows.Forms.RibbonButton()
        Me.pasteButton = New System.Windows.Forms.RibbonButton()
        Me.searchPanel = New System.Windows.Forms.RibbonPanel()
        Me.searchButton = New System.Windows.Forms.RibbonButton()
        Me.replaceButton = New System.Windows.Forms.RibbonButton()
        Me.gotoButton = New System.Windows.Forms.RibbonButton()
        Me.ideTab = New System.Windows.Forms.RibbonTab()
        Me.viewPanel = New System.Windows.Forms.RibbonPanel()
        Me.prjExplrerView = New System.Windows.Forms.RibbonButton()
        Me.objExplorerView = New System.Windows.Forms.RibbonButton()
        Me.errorsWarningsView = New System.Windows.Forms.RibbonButton()
        Me.syntaxHighPanel = New System.Windows.Forms.RibbonPanel()
        Me.RibbonButton1 = New System.Windows.Forms.RibbonButton()
        Me.customTab = New System.Windows.Forms.RibbonTab()
        Me.pluginManagePanel = New System.Windows.Forms.RibbonPanel()
        Me.esPluginsManage = New System.Windows.Forms.RibbonButton()
        Me.installedPlugins = New System.Windows.Forms.RibbonPanel()
        Me.StatusStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'MainDock
        '
        Me.MainDock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.MainDock.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.MainDock.DockBackColor = System.Drawing.SystemColors.Control
        Me.MainDock.Location = New System.Drawing.Point(0, 99)
        Me.MainDock.Name = "MainDock"
        Me.MainDock.Size = New System.Drawing.Size(610, 338)
        Me.MainDock.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 440)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(610, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLabel
        '
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(26, 17)
        Me.statusLabel.Text = "Idle"
        '
        'mainRibbon
        '
        Me.mainRibbon.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.mainRibbon.Location = New System.Drawing.Point(0, 0)
        Me.mainRibbon.Minimized = false
        Me.mainRibbon.Name = "mainRibbon"
        '
        '
        '
        Me.mainRibbon.OrbDropDown.BorderRoundness = 8
        Me.mainRibbon.OrbDropDown.Location = New System.Drawing.Point(0, 0)
        Me.mainRibbon.OrbDropDown.MenuItems.Add(Me.RibbonOrbMenuItem1)
        Me.mainRibbon.OrbDropDown.Name = ""
        Me.mainRibbon.OrbDropDown.RecentItems.Add(Me.RibbonOrbRecentItem1)
        Me.mainRibbon.OrbDropDown.Size = New System.Drawing.Size(527, 116)
        Me.mainRibbon.OrbDropDown.TabIndex = 0
        Me.mainRibbon.OrbImage = Nothing
        Me.mainRibbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013
        Me.mainRibbon.OrbText = "File"
        Me.mainRibbon.OrbVisible = false
        '
        '
        '
        Me.mainRibbon.QuickAcessToolbar.Items.Add(Me.closeProjectButton)
        Me.mainRibbon.RibbonTabFont = New System.Drawing.Font("Trebuchet MS", 9!)
        Me.mainRibbon.Size = New System.Drawing.Size(610, 100)
        Me.mainRibbon.TabIndex = 13
        Me.mainRibbon.Tabs.Add(Me.fileTab)
        Me.mainRibbon.Tabs.Add(Me.editTab)
        Me.mainRibbon.Tabs.Add(Me.ideTab)
        Me.mainRibbon.Tabs.Add(Me.customTab)
        Me.mainRibbon.TabsMargin = New System.Windows.Forms.Padding(12, 26, 20, 0)
        Me.mainRibbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue
        '
        'RibbonOrbMenuItem1
        '
        Me.RibbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.RibbonOrbMenuItem1.Image = CType(resources.GetObject("RibbonOrbMenuItem1.Image"),System.Drawing.Image)
        Me.RibbonOrbMenuItem1.SmallImage = CType(resources.GetObject("RibbonOrbMenuItem1.SmallImage"),System.Drawing.Image)
        Me.RibbonOrbMenuItem1.Text = "Project"
        '
        'RibbonOrbRecentItem1
        '
        Me.RibbonOrbRecentItem1.AltKey = ""
        Me.RibbonOrbRecentItem1.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_closeProject
        Me.RibbonOrbRecentItem1.SmallImage = CType(resources.GetObject("RibbonOrbRecentItem1.SmallImage"),System.Drawing.Image)
        Me.RibbonOrbRecentItem1.Text = "Close Current Project"
        '
        'closeProjectButton
        '
        Me.closeProjectButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_closeProject
        Me.closeProjectButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.closeProjectButton.SmallImage = Global.ExtremeStudio.My.Resources.Resources.ribbon_closeProject
        Me.closeProjectButton.Text = "RibbonButton4"
        Me.closeProjectButton.ToolTip = "Close Project"
        '
        'fileTab
        '
        Me.fileTab.Panels.Add(Me.prjPanel)
        Me.fileTab.Panels.Add(Me.downloadPanel)
        Me.fileTab.Text = "Project"
        '
        'prjPanel
        '
        Me.prjPanel.ButtonMoreVisible = false
        Me.prjPanel.Items.Add(Me.newFileButton)
        Me.prjPanel.Items.Add(Me.saveFileButton)
        Me.prjPanel.Items.Add(Me.saveAllButton)
        Me.prjPanel.Text = "Files"
        '
        'newFileButton
        '
        Me.newFileButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_newFile
        Me.newFileButton.SmallImage = CType(resources.GetObject("newFileButton.SmallImage"),System.Drawing.Image)
        Me.newFileButton.Text = ""
        Me.newFileButton.ToolTip = "New File"
        '
        'saveFileButton
        '
        Me.saveFileButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_saveFile
        Me.saveFileButton.SmallImage = CType(resources.GetObject("saveFileButton.SmallImage"),System.Drawing.Image)
        Me.saveFileButton.Text = ""
        Me.saveFileButton.ToolTip = "Save File"
        '
        'saveAllButton
        '
        Me.saveAllButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_saveFileAll
        Me.saveAllButton.SmallImage = CType(resources.GetObject("saveAllButton.SmallImage"),System.Drawing.Image)
        Me.saveAllButton.Text = ""
        Me.saveAllButton.ToolTip = "Save All Files"
        '
        'downloadPanel
        '
        Me.downloadPanel.ButtonMoreVisible = false
        Me.downloadPanel.Items.Add(Me.includesButton)
        Me.downloadPanel.Items.Add(Me.pluginsButton)
        Me.downloadPanel.Text = "Downloadables"
        '
        'includesButton
        '
        Me.includesButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_includes
        Me.includesButton.SmallImage = CType(resources.GetObject("includesButton.SmallImage"),System.Drawing.Image)
        Me.includesButton.Text = ""
        Me.includesButton.ToolTip = "Download SAMP Includes"
        '
        'pluginsButton
        '
        Me.pluginsButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_plugins
        Me.pluginsButton.SmallImage = CType(resources.GetObject("pluginsButton.SmallImage"),System.Drawing.Image)
        Me.pluginsButton.Text = ""
        Me.pluginsButton.ToolTip = "Download SAMP Plugins"
        '
        'editTab
        '
        Me.editTab.Panels.Add(Me.clipboardPanel)
        Me.editTab.Panels.Add(Me.searchPanel)
        Me.editTab.Text = "Edit"
        '
        'clipboardPanel
        '
        Me.clipboardPanel.ButtonMoreEnabled = false
        Me.clipboardPanel.ButtonMoreVisible = false
        Me.clipboardPanel.Items.Add(Me.cutButton)
        Me.clipboardPanel.Items.Add(Me.copyButton)
        Me.clipboardPanel.Items.Add(Me.pasteButton)
        Me.clipboardPanel.Text = "Clipboard"
        '
        'cutButton
        '
        Me.cutButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_cut
        Me.cutButton.SmallImage = CType(resources.GetObject("cutButton.SmallImage"),System.Drawing.Image)
        Me.cutButton.Text = ""
        Me.cutButton.ToolTip = "Cut"
        '
        'copyButton
        '
        Me.copyButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_copy
        Me.copyButton.SmallImage = CType(resources.GetObject("copyButton.SmallImage"),System.Drawing.Image)
        Me.copyButton.Text = ""
        Me.copyButton.ToolTip = "Copy"
        '
        'pasteButton
        '
        Me.pasteButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_paste
        Me.pasteButton.SmallImage = CType(resources.GetObject("pasteButton.SmallImage"),System.Drawing.Image)
        Me.pasteButton.Text = ""
        Me.pasteButton.ToolTip = "Paste"
        '
        'searchPanel
        '
        Me.searchPanel.ButtonMoreVisible = false
        Me.searchPanel.Items.Add(Me.searchButton)
        Me.searchPanel.Items.Add(Me.replaceButton)
        Me.searchPanel.Items.Add(Me.gotoButton)
        Me.searchPanel.Text = "Search & Replace"
        '
        'searchButton
        '
        Me.searchButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_search
        Me.searchButton.SmallImage = CType(resources.GetObject("searchButton.SmallImage"),System.Drawing.Image)
        Me.searchButton.Text = ""
        Me.searchButton.ToolTip = "Search"
        '
        'replaceButton
        '
        Me.replaceButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_searchAndReplace
        Me.replaceButton.SmallImage = CType(resources.GetObject("replaceButton.SmallImage"),System.Drawing.Image)
        Me.replaceButton.Text = ""
        Me.replaceButton.ToolTip = "Replace"
        '
        'gotoButton
        '
        Me.gotoButton.AltKey = ""
        Me.gotoButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_goto
        Me.gotoButton.SmallImage = CType(resources.GetObject("gotoButton.SmallImage"),System.Drawing.Image)
        Me.gotoButton.Text = ""
        Me.gotoButton.ToolTip = "GoTo"
        '
        'ideTab
        '
        Me.ideTab.Panels.Add(Me.viewPanel)
        Me.ideTab.Panels.Add(Me.syntaxHighPanel)
        Me.ideTab.Text = "IDE"
        '
        'viewPanel
        '
        Me.viewPanel.ButtonMoreVisible = false
        Me.viewPanel.Items.Add(Me.prjExplrerView)
        Me.viewPanel.Items.Add(Me.objExplorerView)
        Me.viewPanel.Items.Add(Me.errorsWarningsView)
        Me.viewPanel.Text = "View"
        '
        'prjExplrerView
        '
        Me.prjExplrerView.Image = Global.ExtremeStudio.My.Resources.Resources.dirs_projexplorer
        Me.prjExplrerView.SmallImage = CType(resources.GetObject("prjExplrerView.SmallImage"),System.Drawing.Image)
        Me.prjExplrerView.Text = ""
        Me.prjExplrerView.ToolTipTitle = "Project Explorer"
        '
        'objExplorerView
        '
        Me.objExplorerView.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_objectExplrer
        Me.objExplorerView.SmallImage = CType(resources.GetObject("objExplorerView.SmallImage"),System.Drawing.Image)
        Me.objExplorerView.Text = ""
        Me.objExplorerView.ToolTip = "Object Explorer"
        '
        'errorsWarningsView
        '
        Me.errorsWarningsView.Image = Global.ExtremeStudio.My.Resources.Resources.ribbob_errors
        Me.errorsWarningsView.SmallImage = CType(resources.GetObject("errorsWarningsView.SmallImage"),System.Drawing.Image)
        Me.errorsWarningsView.Text = ""
        Me.errorsWarningsView.ToolTip = "Errors & Warnings"
        '
        'syntaxHighPanel
        '
        Me.syntaxHighPanel.ButtonMoreVisible = false
        Me.syntaxHighPanel.Items.Add(Me.RibbonButton1)
        Me.syntaxHighPanel.Text = "Syntax Highlighting"
        '
        'RibbonButton1
        '
        Me.RibbonButton1.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_syntax
        Me.RibbonButton1.SmallImage = CType(resources.GetObject("RibbonButton1.SmallImage"),System.Drawing.Image)
        Me.RibbonButton1.Text = ""
        Me.RibbonButton1.ToolTip = "Modify Syntax Highlighting"
        '
        'customTab
        '
        Me.customTab.Panels.Add(Me.pluginManagePanel)
        Me.customTab.Panels.Add(Me.installedPlugins)
        Me.customTab.Text = "ES Plugins"
        '
        'pluginManagePanel
        '
        Me.pluginManagePanel.ButtonMoreVisible = false
        Me.pluginManagePanel.Items.Add(Me.esPluginsManage)
        Me.pluginManagePanel.Text = "Plugin Managment"
        '
        'esPluginsManage
        '
        Me.esPluginsManage.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_esPlugins
        Me.esPluginsManage.SmallImage = CType(resources.GetObject("esPluginsManage.SmallImage"),System.Drawing.Image)
        Me.esPluginsManage.Text = ""
        Me.esPluginsManage.ToolTip = "Manage ES Plugins"
        '
        'installedPlugins
        '
        Me.installedPlugins.ButtonMoreVisible = false
        Me.installedPlugins.Text = "Installed Plugins"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 462)
        Me.Controls.Add(Me.mainRibbon)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MainDock)
        Me.IsMdiContainer = true
        Me.Name = "MainForm"
        Me.Text = "ExtremeStudio - Project"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(false)
        Me.StatusStrip1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents MainDock As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mainRibbon As Ribbon
    Friend WithEvents editTab As RibbonTab
    Friend WithEvents clipboardPanel As RibbonPanel
    Friend WithEvents copyButton As RibbonButton
    Friend WithEvents RibbonOrbMenuItem1 As RibbonOrbMenuItem
    Friend WithEvents RibbonOrbRecentItem1 As RibbonOrbRecentItem
    Friend WithEvents cutButton As RibbonButton
    Friend WithEvents pasteButton As RibbonButton
    Friend WithEvents closeProjectButton As RibbonButton
    Friend WithEvents searchPanel As RibbonPanel
    Friend WithEvents searchButton As RibbonButton
    Friend WithEvents replaceButton As RibbonButton
    Friend WithEvents gotoButton As RibbonButton
    Friend WithEvents fileTab As RibbonTab
    Friend WithEvents prjPanel As RibbonPanel
    Friend WithEvents newFileButton As RibbonButton
    Friend WithEvents saveFileButton As RibbonButton
    Friend WithEvents saveAllButton As RibbonButton
    Friend WithEvents downloadPanel As RibbonPanel
    Friend WithEvents includesButton As RibbonButton
    Friend WithEvents pluginsButton As RibbonButton
    Friend WithEvents customTab As RibbonTab
    Friend WithEvents ideTab As RibbonTab
    Friend WithEvents syntaxHighPanel As RibbonPanel
    Friend WithEvents RibbonButton1 As RibbonButton
    Friend WithEvents viewPanel As RibbonPanel
    Friend WithEvents pluginManagePanel As RibbonPanel
    Friend WithEvents installedPlugins As RibbonPanel
    Friend WithEvents prjExplrerView As RibbonButton
    Friend WithEvents objExplorerView As RibbonButton
    Friend WithEvents errorsWarningsView As RibbonButton
    Friend WithEvents esPluginsManage As RibbonButton
End Class
