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
        Me.components = New System.ComponentModel.Container()
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
        Me.indentPanel = New System.Windows.Forms.RibbonPanel()
        Me.addIndentButton = New System.Windows.Forms.RibbonButton()
        Me.removeIndentButton = New System.Windows.Forms.RibbonButton()
        Me.ideTab = New System.Windows.Forms.RibbonTab()
        Me.viewPanel = New System.Windows.Forms.RibbonPanel()
        Me.prjExplrerView = New System.Windows.Forms.RibbonButton()
        Me.objExplorerView = New System.Windows.Forms.RibbonButton()
        Me.errorsWarningsView = New System.Windows.Forms.RibbonButton()
        Me.syntaxHighPanel = New System.Windows.Forms.RibbonPanel()
        Me.RibbonButton1 = New System.Windows.Forms.RibbonButton()
        Me.BuildPanel = New System.Windows.Forms.RibbonPanel()
        Me.compileScriptBtn = New System.Windows.Forms.RibbonButton()
        Me.customTab = New System.Windows.Forms.RibbonTab()
        Me.pluginManagePanel = New System.Windows.Forms.RibbonPanel()
        Me.esPluginsManage = New System.Windows.Forms.RibbonButton()
        Me.installedPlugins = New System.Windows.Forms.RibbonPanel()
        Me.CompilerWorker = New System.ComponentModel.BackgroundWorker()
        Me.statusStripTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'MainDock
        '
        resources.ApplyResources(Me.MainDock, "MainDock")
        Me.MainDock.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.MainDock.DockBackColor = System.Drawing.SystemColors.Control
        Me.MainDock.Name = "MainDock"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'statusLabel
        '
        Me.statusLabel.Name = "statusLabel"
        resources.ApplyResources(Me.statusLabel, "statusLabel")
        '
        'mainRibbon
        '
        resources.ApplyResources(Me.mainRibbon, "mainRibbon")
        Me.mainRibbon.Minimized = false
        Me.mainRibbon.Name = "mainRibbon"
        '
        '
        '
        Me.mainRibbon.OrbDropDown.BorderRoundness = 8
        Me.mainRibbon.OrbDropDown.Location = CType(resources.GetObject("mainRibbon.OrbDropDown.Location"),System.Drawing.Point)
        Me.mainRibbon.OrbDropDown.MenuItems.Add(Me.RibbonOrbMenuItem1)
        Me.mainRibbon.OrbDropDown.Name = ""
        Me.mainRibbon.OrbDropDown.RecentItems.Add(Me.RibbonOrbRecentItem1)
        Me.mainRibbon.OrbDropDown.Size = CType(resources.GetObject("mainRibbon.OrbDropDown.Size"),System.Drawing.Size)
        Me.mainRibbon.OrbDropDown.TabIndex = CType(resources.GetObject("mainRibbon.OrbDropDown.TabIndex"),Integer)
        Me.mainRibbon.OrbImage = Nothing
        Me.mainRibbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013
        Me.mainRibbon.OrbText = "File"
        Me.mainRibbon.OrbVisible = false
        '
        '
        '
        Me.mainRibbon.QuickAcessToolbar.Items.Add(Me.closeProjectButton)
        Me.mainRibbon.RibbonTabFont = New System.Drawing.Font("Trebuchet MS", 9!)
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
        resources.ApplyResources(Me.RibbonOrbMenuItem1, "RibbonOrbMenuItem1")
        '
        'RibbonOrbRecentItem1
        '
        Me.RibbonOrbRecentItem1.AltKey = ""
        Me.RibbonOrbRecentItem1.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_closeProject
        Me.RibbonOrbRecentItem1.SmallImage = CType(resources.GetObject("RibbonOrbRecentItem1.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.RibbonOrbRecentItem1, "RibbonOrbRecentItem1")
        '
        'closeProjectButton
        '
        Me.closeProjectButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_closeProject
        Me.closeProjectButton.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact
        Me.closeProjectButton.SmallImage = Global.ExtremeStudio.My.Resources.Resources.ribbon_closeProject
        resources.ApplyResources(Me.closeProjectButton, "closeProjectButton")
        '
        'fileTab
        '
        Me.fileTab.Panels.Add(Me.prjPanel)
        Me.fileTab.Panels.Add(Me.downloadPanel)
        resources.ApplyResources(Me.fileTab, "fileTab")
        '
        'prjPanel
        '
        Me.prjPanel.ButtonMoreVisible = false
        Me.prjPanel.Items.Add(Me.saveFileButton)
        Me.prjPanel.Items.Add(Me.saveAllButton)
        resources.ApplyResources(Me.prjPanel, "prjPanel")
        '
        'saveFileButton
        '
        Me.saveFileButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_saveFile
        Me.saveFileButton.SmallImage = CType(resources.GetObject("saveFileButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.saveFileButton, "saveFileButton")
        '
        'saveAllButton
        '
        Me.saveAllButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_saveFileAll
        Me.saveAllButton.SmallImage = CType(resources.GetObject("saveAllButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.saveAllButton, "saveAllButton")
        '
        'downloadPanel
        '
        Me.downloadPanel.ButtonMoreVisible = false
        Me.downloadPanel.Items.Add(Me.includesButton)
        Me.downloadPanel.Items.Add(Me.pluginsButton)
        resources.ApplyResources(Me.downloadPanel, "downloadPanel")
        '
        'includesButton
        '
        Me.includesButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_includes
        Me.includesButton.SmallImage = CType(resources.GetObject("includesButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.includesButton, "includesButton")
        '
        'pluginsButton
        '
        Me.pluginsButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_plugins
        Me.pluginsButton.SmallImage = CType(resources.GetObject("pluginsButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.pluginsButton, "pluginsButton")
        '
        'editTab
        '
        Me.editTab.Panels.Add(Me.clipboardPanel)
        Me.editTab.Panels.Add(Me.searchPanel)
        Me.editTab.Panels.Add(Me.indentPanel)
        resources.ApplyResources(Me.editTab, "editTab")
        '
        'clipboardPanel
        '
        Me.clipboardPanel.ButtonMoreEnabled = false
        Me.clipboardPanel.ButtonMoreVisible = false
        Me.clipboardPanel.Items.Add(Me.cutButton)
        Me.clipboardPanel.Items.Add(Me.copyButton)
        Me.clipboardPanel.Items.Add(Me.pasteButton)
        resources.ApplyResources(Me.clipboardPanel, "clipboardPanel")
        '
        'cutButton
        '
        Me.cutButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_cut
        Me.cutButton.SmallImage = CType(resources.GetObject("cutButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.cutButton, "cutButton")
        '
        'copyButton
        '
        Me.copyButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_copy
        Me.copyButton.SmallImage = CType(resources.GetObject("copyButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.copyButton, "copyButton")
        '
        'pasteButton
        '
        Me.pasteButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_paste
        Me.pasteButton.SmallImage = CType(resources.GetObject("pasteButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.pasteButton, "pasteButton")
        '
        'searchPanel
        '
        Me.searchPanel.ButtonMoreVisible = false
        Me.searchPanel.Items.Add(Me.searchButton)
        Me.searchPanel.Items.Add(Me.replaceButton)
        Me.searchPanel.Items.Add(Me.gotoButton)
        resources.ApplyResources(Me.searchPanel, "searchPanel")
        '
        'searchButton
        '
        Me.searchButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_search
        Me.searchButton.SmallImage = CType(resources.GetObject("searchButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.searchButton, "searchButton")
        '
        'replaceButton
        '
        Me.replaceButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_searchAndReplace
        Me.replaceButton.SmallImage = CType(resources.GetObject("replaceButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.replaceButton, "replaceButton")
        '
        'gotoButton
        '
        Me.gotoButton.AltKey = ""
        Me.gotoButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_goto
        Me.gotoButton.SmallImage = CType(resources.GetObject("gotoButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.gotoButton, "gotoButton")
        '
        'indentPanel
        '
        Me.indentPanel.ButtonMoreVisible = false
        Me.indentPanel.Items.Add(Me.addIndentButton)
        Me.indentPanel.Items.Add(Me.removeIndentButton)
        resources.ApplyResources(Me.indentPanel, "indentPanel")
        '
        'addIndentButton
        '
        Me.addIndentButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_addIndent
        Me.addIndentButton.SmallImage = CType(resources.GetObject("addIndentButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.addIndentButton, "addIndentButton")
        '
        'removeIndentButton
        '
        Me.removeIndentButton.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_removeIndent
        Me.removeIndentButton.SmallImage = CType(resources.GetObject("removeIndentButton.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.removeIndentButton, "removeIndentButton")
        '
        'ideTab
        '
        Me.ideTab.Panels.Add(Me.viewPanel)
        Me.ideTab.Panels.Add(Me.syntaxHighPanel)
        Me.ideTab.Panels.Add(Me.BuildPanel)
        resources.ApplyResources(Me.ideTab, "ideTab")
        '
        'viewPanel
        '
        Me.viewPanel.ButtonMoreVisible = false
        Me.viewPanel.Items.Add(Me.prjExplrerView)
        Me.viewPanel.Items.Add(Me.objExplorerView)
        Me.viewPanel.Items.Add(Me.errorsWarningsView)
        resources.ApplyResources(Me.viewPanel, "viewPanel")
        '
        'prjExplrerView
        '
        Me.prjExplrerView.Image = Global.ExtremeStudio.My.Resources.Resources.dirs_projexplorer
        Me.prjExplrerView.SmallImage = CType(resources.GetObject("prjExplrerView.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.prjExplrerView, "prjExplrerView")
        Me.prjExplrerView.ToolTipTitle = "Project Explorer"
        '
        'objExplorerView
        '
        Me.objExplorerView.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_objectExplrer
        Me.objExplorerView.SmallImage = CType(resources.GetObject("objExplorerView.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.objExplorerView, "objExplorerView")
        '
        'errorsWarningsView
        '
        Me.errorsWarningsView.Image = Global.ExtremeStudio.My.Resources.Resources.ribbob_errors
        Me.errorsWarningsView.SmallImage = CType(resources.GetObject("errorsWarningsView.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.errorsWarningsView, "errorsWarningsView")
        '
        'syntaxHighPanel
        '
        Me.syntaxHighPanel.ButtonMoreVisible = false
        Me.syntaxHighPanel.Items.Add(Me.RibbonButton1)
        resources.ApplyResources(Me.syntaxHighPanel, "syntaxHighPanel")
        '
        'RibbonButton1
        '
        Me.RibbonButton1.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_settings
        Me.RibbonButton1.SmallImage = CType(resources.GetObject("RibbonButton1.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.RibbonButton1, "RibbonButton1")
        '
        'BuildPanel
        '
        Me.BuildPanel.ButtonMoreVisible = false
        Me.BuildPanel.Items.Add(Me.compileScriptBtn)
        resources.ApplyResources(Me.BuildPanel, "BuildPanel")
        '
        'compileScriptBtn
        '
        Me.compileScriptBtn.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_compile
        Me.compileScriptBtn.SmallImage = CType(resources.GetObject("compileScriptBtn.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.compileScriptBtn, "compileScriptBtn")
        '
        'customTab
        '
        Me.customTab.Panels.Add(Me.pluginManagePanel)
        Me.customTab.Panels.Add(Me.installedPlugins)
        resources.ApplyResources(Me.customTab, "customTab")
        '
        'pluginManagePanel
        '
        Me.pluginManagePanel.ButtonMoreVisible = false
        Me.pluginManagePanel.Items.Add(Me.esPluginsManage)
        resources.ApplyResources(Me.pluginManagePanel, "pluginManagePanel")
        '
        'esPluginsManage
        '
        Me.esPluginsManage.Image = Global.ExtremeStudio.My.Resources.Resources.ribbon_esPlugins
        Me.esPluginsManage.SmallImage = CType(resources.GetObject("esPluginsManage.SmallImage"),System.Drawing.Image)
        resources.ApplyResources(Me.esPluginsManage, "esPluginsManage")
        '
        'installedPlugins
        '
        Me.installedPlugins.ButtonMoreVisible = false
        resources.ApplyResources(Me.installedPlugins, "installedPlugins")
        '
        'CompilerWorker
        '
        Me.CompilerWorker.WorkerReportsProgress = true
        '
        'statusStripTimer
        '
        '
        'MainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.mainRibbon)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MainDock)
        Me.IsMdiContainer = true
        Me.Name = "MainForm"
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
    Friend WithEvents BuildPanel As RibbonPanel
    Friend WithEvents compileScriptBtn As RibbonButton
    Friend WithEvents CompilerWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents statusStripTimer As Timer
    Friend WithEvents indentPanel As RibbonPanel
    Friend WithEvents addIndentButton As RibbonButton
    Friend WithEvents removeIndentButton As RibbonButton
End Class
