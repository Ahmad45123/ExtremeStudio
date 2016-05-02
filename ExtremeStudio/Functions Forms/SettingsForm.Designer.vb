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
        Me.reportGenDirText = New System.Windows.Forms.TextBox()
        Me.reportGenCheck = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ouputDirText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.includesDirText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.activeDirText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTipHandler = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        CType(Me.skipLinesUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tabSizeUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.optiLevelUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.debugLevelUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(367, 459)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.resetBtn)
        Me.TabPage1.Controls.Add(Me.importBtn)
        Me.TabPage1.Controls.Add(Me.exportBtn)
        Me.TabPage1.Controls.Add(Me.colorsSettings)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(359, 433)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Theme And Colors"
        '
        'resetBtn
        '
        Me.resetBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.resetBtn.Location = New System.Drawing.Point(268, 404)
        Me.resetBtn.Name = "resetBtn"
        Me.resetBtn.Size = New System.Drawing.Size(88, 23)
        Me.resetBtn.TabIndex = 44
        Me.resetBtn.Text = "Reset Default"
        Me.resetBtn.UseVisualStyleBackColor = true
        '
        'importBtn
        '
        Me.importBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.importBtn.Location = New System.Drawing.Point(87, 404)
        Me.importBtn.Name = "importBtn"
        Me.importBtn.Size = New System.Drawing.Size(75, 23)
        Me.importBtn.TabIndex = 43
        Me.importBtn.Text = "Import"
        Me.importBtn.UseVisualStyleBackColor = true
        '
        'exportBtn
        '
        Me.exportBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.exportBtn.Location = New System.Drawing.Point(6, 404)
        Me.exportBtn.Name = "exportBtn"
        Me.exportBtn.Size = New System.Drawing.Size(75, 23)
        Me.exportBtn.TabIndex = 42
        Me.exportBtn.Text = "Export"
        Me.exportBtn.UseVisualStyleBackColor = true
        '
        'colorsSettings
        '
        Me.colorsSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.colorsSettings.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.colorsSettings.Location = New System.Drawing.Point(3, 3)
        Me.colorsSettings.Name = "colorsSettings"
        Me.colorsSettings.Size = New System.Drawing.Size(353, 395)
        Me.colorsSettings.TabIndex = 41
        '
        'TabPage2
        '
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
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(359, 433)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Compiler"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(130, 402)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Reset Defaults"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'customArgsText
        '
        Me.customArgsText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.customArgsText.Location = New System.Drawing.Point(11, 354)
        Me.customArgsText.Name = "customArgsText"
        Me.customArgsText.Size = New System.Drawing.Size(340, 20)
        Me.customArgsText.TabIndex = 25
        Me.ToolTipHandler.SetToolTip(Me.customArgsText, "If there is some args that you want to compile with that aren't above, Write them"& _ 
        " here.")
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(3, 338)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Extra Custom Args: "
        '
        'parenthesesCheck
        '
        Me.parenthesesCheck.AutoSize = true
        Me.parenthesesCheck.Location = New System.Drawing.Point(11, 255)
        Me.parenthesesCheck.Name = "parenthesesCheck"
        Me.parenthesesCheck.Size = New System.Drawing.Size(166, 17)
        Me.parenthesesCheck.TabIndex = 23
        Me.parenthesesCheck.Text = "Functions need parentheses."
        Me.ToolTipHandler.SetToolTip(Me.parenthesesCheck, "If checked, parameters passed in a function must be enclosed in parentheses.")
        Me.parenthesesCheck.UseVisualStyleBackColor = true
        '
        'semiColonCheck
        '
        Me.semiColonCheck.AutoSize = true
        Me.semiColonCheck.Location = New System.Drawing.Point(11, 278)
        Me.semiColonCheck.Name = "semiColonCheck"
        Me.semiColonCheck.Size = New System.Drawing.Size(182, 17)
        Me.semiColonCheck.TabIndex = 22
        Me.semiColonCheck.Text = "Lines must end with a semicolon."
        Me.ToolTipHandler.SetToolTip(Me.semiColonCheck, "If checked, lines must end with a semi-colon.")
        Me.semiColonCheck.UseVisualStyleBackColor = true
        '
        'skipLinesUpDown
        '
        Me.skipLinesUpDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.skipLinesUpDown.Location = New System.Drawing.Point(130, 195)
        Me.skipLinesUpDown.Name = "skipLinesUpDown"
        Me.skipLinesUpDown.Size = New System.Drawing.Size(221, 20)
        Me.skipLinesUpDown.TabIndex = 20
        Me.ToolTipHandler.SetToolTip(Me.skipLinesUpDown, "Skip count: the number of lines to skip in the input ﬁle before starting to compi"& _ 
        "le; "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"for example, to skip a ““header”” in the source ﬁle which is not in a valid "& _ 
        "pawn syntax.")
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(8, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Number of lines to skip: "
        '
        'tabSizeUpDown
        '
        Me.tabSizeUpDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tabSizeUpDown.Location = New System.Drawing.Point(68, 169)
        Me.tabSizeUpDown.Name = "tabSizeUpDown"
        Me.tabSizeUpDown.Size = New System.Drawing.Size(283, 20)
        Me.tabSizeUpDown.TabIndex = 18
        Me.ToolTipHandler.SetToolTip(Me.tabSizeUpDown, "Tab size: the number of space characters to use for a tab character. "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Without th"& _ 
        "is option, the pawn parser will autodetect the tab.")
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(8, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Tab Size: "
        '
        'optiLevelUpDown
        '
        Me.optiLevelUpDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.optiLevelUpDown.Location = New System.Drawing.Point(107, 143)
        Me.optiLevelUpDown.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.optiLevelUpDown.Name = "optiLevelUpDown"
        Me.optiLevelUpDown.Size = New System.Drawing.Size(244, 20)
        Me.optiLevelUpDown.TabIndex = 16
        Me.ToolTipHandler.SetToolTip(Me.optiLevelUpDown, resources.GetString("optiLevelUpDown.ToolTip"))
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(8, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Optimization Level: "
        '
        'debugLevelUpDown
        '
        Me.debugLevelUpDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.debugLevelUpDown.Location = New System.Drawing.Point(107, 117)
        Me.debugLevelUpDown.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.debugLevelUpDown.Name = "debugLevelUpDown"
        Me.debugLevelUpDown.Size = New System.Drawing.Size(244, 20)
        Me.debugLevelUpDown.TabIndex = 14
        Me.ToolTipHandler.SetToolTip(Me.debugLevelUpDown, "Debug level: 0 = none, 1 = bounds checking and assertions only, "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"2 = full symbol"& _ 
        "ic information, 3 = full symbolic information and"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"optimizations disabled (same "& _ 
        "as the combination -d2 and -O0).")
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(8, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Debugging Level: "
        '
        'reportGenDirText
        '
        Me.reportGenDirText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.reportGenDirText.Enabled = false
        Me.reportGenDirText.Location = New System.Drawing.Point(130, 91)
        Me.reportGenDirText.Name = "reportGenDirText"
        Me.reportGenDirText.Size = New System.Drawing.Size(221, 20)
        Me.reportGenDirText.TabIndex = 12
        Me.ToolTipHandler.SetToolTip(Me.reportGenDirText, resources.GetString("reportGenDirText.ToolTip"))
        '
        'reportGenCheck
        '
        Me.reportGenCheck.AutoSize = true
        Me.reportGenCheck.Location = New System.Drawing.Point(109, 94)
        Me.reportGenCheck.Name = "reportGenCheck"
        Me.reportGenCheck.Size = New System.Drawing.Size(15, 14)
        Me.reportGenCheck.TabIndex = 11
        Me.reportGenCheck.UseVisualStyleBackColor = true
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(8, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Report Generation: "
        '
        'ouputDirText
        '
        Me.ouputDirText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ouputDirText.Location = New System.Drawing.Point(74, 62)
        Me.ouputDirText.Name = "ouputDirText"
        Me.ouputDirText.Size = New System.Drawing.Size(277, 20)
        Me.ouputDirText.TabIndex = 5
        Me.ToolTipHandler.SetToolTip(Me.ouputDirText, "Output ﬁle: set the name and path of the binary output ﬁle."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Set it to null for"& _ 
        " default.")
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(8, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Output Dir: "
        '
        'includesDirText
        '
        Me.includesDirText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.includesDirText.Location = New System.Drawing.Point(74, 36)
        Me.includesDirText.Name = "includesDirText"
        Me.includesDirText.Size = New System.Drawing.Size(277, 20)
        Me.includesDirText.TabIndex = 3
        Me.ToolTipHandler.SetToolTip(Me.includesDirText, "Include path: set the path where the compiler"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"can ﬁnd the include ﬁles."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Set i"& _ 
        "t to null for default.")
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(8, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Includes Dir: "
        '
        'activeDirText
        '
        Me.activeDirText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.activeDirText.Location = New System.Drawing.Point(74, 10)
        Me.activeDirText.Name = "activeDirText"
        Me.activeDirText.Size = New System.Drawing.Size(277, 20)
        Me.activeDirText.TabIndex = 1
        Me.ToolTipHandler.SetToolTip(Me.activeDirText, "Directory: the ““active”” directory, where the compiler"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"should search for its inpu"& _ 
        "t ﬁles and store its output ﬁles."&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Set it to null for default.")
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Active Dir: "
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 459)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "SettingsForm"
        Me.Text = "Settings [Project]"
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        CType(Me.skipLinesUpDown,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tabSizeUpDown,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.optiLevelUpDown,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.debugLevelUpDown,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Public WithEvents TabControl1 As TabControl
    Public WithEvents TabPage1 As TabPage
    Friend WithEvents colorsSettings As PropertyGrid
    Friend WithEvents exportBtn As Button
    Friend WithEvents resetBtn As Button
    Friend WithEvents importBtn As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents activeDirText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ouputDirText As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents includesDirText As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents reportGenDirText As TextBox
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
End Class
