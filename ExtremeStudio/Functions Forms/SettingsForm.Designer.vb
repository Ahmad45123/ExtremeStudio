<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.resetBtn = New System.Windows.Forms.Button()
        Me.importBtn = New System.Windows.Forms.Button()
        Me.exportBtn = New System.Windows.Forms.Button()
        Me.colorsSettings = New System.Windows.Forms.PropertyGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.customArgsText = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.parenthesesCheck = New System.Windows.Forms.CheckBox()
        Me.semiColonCheck = New System.Windows.Forms.CheckBox()
        Me.skipLinesUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tabSizeUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.optiLevelUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.debugLevelUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.reportGenDirText = New ExtremeCore.PathTextBox()
        Me.reportGenCheck = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ouputDirText = New ExtremeCore.PathTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.includesDirText = New ExtremeCore.PathTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.activeDirText = New ExtremeCore.PathTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.serverCFGTabPage = New System.Windows.Forms.TabPage()
        Me.serverCfgGrid = New System.Windows.Forms.DataGridView()
        Me.nameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valueColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTipHandler = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        CType(Me.skipLinesUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tabSizeUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.optiLevelUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.debugLevelUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        Me.serverCFGTabPage.SuspendLayout
        CType(Me.serverCfgGrid,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.serverCFGTabPage)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.ToolTipHandler.SetToolTip(Me.TabControl1, resources.GetString("TabControl1.ToolTip"))
        '
        'TabPage1
        '
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.resetBtn)
        Me.TabPage1.Controls.Add(Me.importBtn)
        Me.TabPage1.Controls.Add(Me.exportBtn)
        Me.TabPage1.Controls.Add(Me.colorsSettings)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage1.Name = "TabPage1"
        Me.ToolTipHandler.SetToolTip(Me.TabPage1, resources.GetString("TabPage1.ToolTip"))
        '
        'resetBtn
        '
        resources.ApplyResources(Me.resetBtn, "resetBtn")
        Me.resetBtn.Name = "resetBtn"
        Me.ToolTipHandler.SetToolTip(Me.resetBtn, resources.GetString("resetBtn.ToolTip"))
        Me.resetBtn.UseVisualStyleBackColor = true
        '
        'importBtn
        '
        resources.ApplyResources(Me.importBtn, "importBtn")
        Me.importBtn.Name = "importBtn"
        Me.ToolTipHandler.SetToolTip(Me.importBtn, resources.GetString("importBtn.ToolTip"))
        Me.importBtn.UseVisualStyleBackColor = true
        '
        'exportBtn
        '
        resources.ApplyResources(Me.exportBtn, "exportBtn")
        Me.exportBtn.Name = "exportBtn"
        Me.ToolTipHandler.SetToolTip(Me.exportBtn, resources.GetString("exportBtn.ToolTip"))
        Me.exportBtn.UseVisualStyleBackColor = true
        '
        'colorsSettings
        '
        resources.ApplyResources(Me.colorsSettings, "colorsSettings")
        Me.colorsSettings.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.colorsSettings.Name = "colorsSettings"
        Me.ToolTipHandler.SetToolTip(Me.colorsSettings, resources.GetString("colorsSettings.ToolTip"))
        '
        'TabPage2
        '
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.customArgsText)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.parenthesesCheck)
        Me.TabPage2.Controls.Add(Me.semiColonCheck)
        Me.TabPage2.Controls.Add(Me.skipLinesUpDown)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.tabSizeUpDown)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.optiLevelUpDown)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.debugLevelUpDown)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.reportGenDirText)
        Me.TabPage2.Controls.Add(Me.reportGenCheck)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.ouputDirText)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.includesDirText)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.activeDirText)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Name = "TabPage2"
        Me.ToolTipHandler.SetToolTip(Me.TabPage2, resources.GetString("TabPage2.ToolTip"))
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.ToolTipHandler.SetToolTip(Me.Button1, resources.GetString("Button1.ToolTip"))
        Me.Button1.UseVisualStyleBackColor = true
        '
        'customArgsText
        '
        resources.ApplyResources(Me.customArgsText, "customArgsText")
        Me.customArgsText.Name = "customArgsText"
        Me.ToolTipHandler.SetToolTip(Me.customArgsText, resources.GetString("customArgsText.ToolTip"))
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        Me.ToolTipHandler.SetToolTip(Me.Label9, resources.GetString("Label9.ToolTip"))
        '
        'parenthesesCheck
        '
        resources.ApplyResources(Me.parenthesesCheck, "parenthesesCheck")
        Me.parenthesesCheck.Name = "parenthesesCheck"
        Me.ToolTipHandler.SetToolTip(Me.parenthesesCheck, resources.GetString("parenthesesCheck.ToolTip"))
        Me.parenthesesCheck.UseVisualStyleBackColor = true
        '
        'semiColonCheck
        '
        resources.ApplyResources(Me.semiColonCheck, "semiColonCheck")
        Me.semiColonCheck.Name = "semiColonCheck"
        Me.ToolTipHandler.SetToolTip(Me.semiColonCheck, resources.GetString("semiColonCheck.ToolTip"))
        Me.semiColonCheck.UseVisualStyleBackColor = true
        '
        'skipLinesUpDown
        '
        resources.ApplyResources(Me.skipLinesUpDown, "skipLinesUpDown")
        Me.skipLinesUpDown.Name = "skipLinesUpDown"
        Me.ToolTipHandler.SetToolTip(Me.skipLinesUpDown, resources.GetString("skipLinesUpDown.ToolTip"))
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        Me.ToolTipHandler.SetToolTip(Me.Label8, resources.GetString("Label8.ToolTip"))
        '
        'tabSizeUpDown
        '
        resources.ApplyResources(Me.tabSizeUpDown, "tabSizeUpDown")
        Me.tabSizeUpDown.Name = "tabSizeUpDown"
        Me.ToolTipHandler.SetToolTip(Me.tabSizeUpDown, resources.GetString("tabSizeUpDown.ToolTip"))
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        Me.ToolTipHandler.SetToolTip(Me.Label7, resources.GetString("Label7.ToolTip"))
        '
        'optiLevelUpDown
        '
        resources.ApplyResources(Me.optiLevelUpDown, "optiLevelUpDown")
        Me.optiLevelUpDown.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.optiLevelUpDown.Name = "optiLevelUpDown"
        Me.ToolTipHandler.SetToolTip(Me.optiLevelUpDown, resources.GetString("optiLevelUpDown.ToolTip"))
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        Me.ToolTipHandler.SetToolTip(Me.Label5, resources.GetString("Label5.ToolTip"))
        '
        'debugLevelUpDown
        '
        resources.ApplyResources(Me.debugLevelUpDown, "debugLevelUpDown")
        Me.debugLevelUpDown.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.debugLevelUpDown.Name = "debugLevelUpDown"
        Me.ToolTipHandler.SetToolTip(Me.debugLevelUpDown, resources.GetString("debugLevelUpDown.ToolTip"))
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        Me.ToolTipHandler.SetToolTip(Me.Label4, resources.GetString("Label4.ToolTip"))
        '
        'reportGenDirText
        '
        resources.ApplyResources(Me.reportGenDirText, "reportGenDirText")
        Me.reportGenDirText.Description = "Select Save Location For The Report"
        Me.reportGenDirText.Filter = "XML File (*.xml) | *.xml"
        Me.reportGenDirText.Name = "reportGenDirText"
        Me.reportGenDirText.PathType = ExtremeCore.PathTextBox.PathTypes.FileSave
        Me.ToolTipHandler.SetToolTip(Me.reportGenDirText, resources.GetString("reportGenDirText.ToolTip"))
        '
        'reportGenCheck
        '
        resources.ApplyResources(Me.reportGenCheck, "reportGenCheck")
        Me.reportGenCheck.Name = "reportGenCheck"
        Me.ToolTipHandler.SetToolTip(Me.reportGenCheck, resources.GetString("reportGenCheck.ToolTip"))
        Me.reportGenCheck.UseVisualStyleBackColor = true
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        Me.ToolTipHandler.SetToolTip(Me.Label6, resources.GetString("Label6.ToolTip"))
        '
        'ouputDirText
        '
        resources.ApplyResources(Me.ouputDirText, "ouputDirText")
        Me.ouputDirText.Description = "Select The Output Directory"
        Me.ouputDirText.Filter = Nothing
        Me.ouputDirText.Name = "ouputDirText"
        Me.ouputDirText.PathType = ExtremeCore.PathTextBox.PathTypes.Folder
        Me.ToolTipHandler.SetToolTip(Me.ouputDirText, resources.GetString("ouputDirText.ToolTip"))
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        Me.ToolTipHandler.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'includesDirText
        '
        resources.ApplyResources(Me.includesDirText, "includesDirText")
        Me.includesDirText.Description = "Select The Includes Directory"
        Me.includesDirText.Filter = Nothing
        Me.includesDirText.Name = "includesDirText"
        Me.includesDirText.PathType = ExtremeCore.PathTextBox.PathTypes.Folder
        Me.ToolTipHandler.SetToolTip(Me.includesDirText, resources.GetString("includesDirText.ToolTip"))
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.ToolTipHandler.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        '
        'activeDirText
        '
        resources.ApplyResources(Me.activeDirText, "activeDirText")
        Me.activeDirText.Description = "Select The Active Directory"
        Me.activeDirText.Filter = Nothing
        Me.activeDirText.Name = "activeDirText"
        Me.activeDirText.PathType = ExtremeCore.PathTextBox.PathTypes.Folder
        Me.ToolTipHandler.SetToolTip(Me.activeDirText, resources.GetString("activeDirText.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.ToolTipHandler.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'serverCFGTabPage
        '
        resources.ApplyResources(Me.serverCFGTabPage, "serverCFGTabPage")
        Me.serverCFGTabPage.Controls.Add(Me.serverCfgGrid)
        Me.serverCFGTabPage.Name = "serverCFGTabPage"
        Me.ToolTipHandler.SetToolTip(Me.serverCFGTabPage, resources.GetString("serverCFGTabPage.ToolTip"))
        Me.serverCFGTabPage.UseVisualStyleBackColor = true
        '
        'serverCfgGrid
        '
        resources.ApplyResources(Me.serverCfgGrid, "serverCfgGrid")
        Me.serverCfgGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.serverCfgGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.serverCfgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.serverCfgGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nameColumn, Me.valueColumn})
        Me.serverCfgGrid.Name = "serverCfgGrid"
        Me.ToolTipHandler.SetToolTip(Me.serverCfgGrid, resources.GetString("serverCfgGrid.ToolTip"))
        '
        'nameColumn
        '
        resources.ApplyResources(Me.nameColumn, "nameColumn")
        Me.nameColumn.Name = "nameColumn"
        '
        'valueColumn
        '
        resources.ApplyResources(Me.valueColumn, "valueColumn")
        Me.valueColumn.Name = "valueColumn"
        '
        'ToolTipHandler
        '
        Me.ToolTipHandler.AutomaticDelay = 0
        Me.ToolTipHandler.AutoPopDelay = 10000
        Me.ToolTipHandler.InitialDelay = 100
        Me.ToolTipHandler.ReshowDelay = 100
        Me.ToolTipHandler.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipHandler.ToolTipTitle = "Help"
        '
        'SettingsForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "SettingsForm"
        Me.ToolTipHandler.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        CType(Me.skipLinesUpDown,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tabSizeUpDown,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.optiLevelUpDown,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.debugLevelUpDown,System.ComponentModel.ISupportInitialize).EndInit
        Me.serverCFGTabPage.ResumeLayout(false)
        CType(Me.serverCfgGrid,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Public WithEvents TabControl1 As TabControl
    Public WithEvents TabPage1 As TabPage
    Friend WithEvents colorsSettings As PropertyGrid
    Friend WithEvents exportBtn As Button
    Friend WithEvents resetBtn As Button
    Friend WithEvents importBtn As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents reportGenCheck As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents optiLevelUpDown As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents debugLevelUpDown As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents tabSizeUpDown As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents skipLinesUpDown As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents semiColonCheck As CheckBox
    Friend WithEvents parenthesesCheck As CheckBox
    Friend WithEvents customArgsText As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolTipHandler As ToolTip
    Friend WithEvents reportGenDirText As ExtremeCore.PathTextBox
    Friend WithEvents ouputDirText As ExtremeCore.PathTextBox
    Friend WithEvents includesDirText As ExtremeCore.PathTextBox
    Friend WithEvents activeDirText As ExtremeCore.PathTextBox
    Friend WithEvents serverCFGTabPage As TabPage
    Friend WithEvents serverCfgGrid As DataGridView
    Friend WithEvents nameColumn As DataGridViewTextBoxColumn
    Friend WithEvents valueColumn As DataGridViewTextBoxColumn
End Class
