<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartupForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartupForm))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.preExistCheck = New System.Windows.Forms.CheckBox()
        Me.CreateProjectBtn = New System.Windows.Forms.Button()
        Me.locTextBox = New ExtremeCore.PathTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.verListBox = New System.Windows.Forms.ListBox()
        Me.nameTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.loadProjectBtn = New System.Windows.Forms.Button()
        Me.projectVersion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.projectName = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pathTextBox = New ExtremeCore.PathTextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.recentListBox = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OpenGlobalSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        Me.TabPage3.SuspendLayout
        Me.MenuStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.preExistCheck)
        Me.TabPage1.Controls.Add(Me.CreateProjectBtn)
        Me.TabPage1.Controls.Add(Me.locTextBox)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.verListBox)
        Me.TabPage1.Controls.Add(Me.nameTextBox)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'preExistCheck
        '
        resources.ApplyResources(Me.preExistCheck, "preExistCheck")
        Me.preExistCheck.Name = "preExistCheck"
        Me.preExistCheck.UseVisualStyleBackColor = true
        '
        'CreateProjectBtn
        '
        resources.ApplyResources(Me.CreateProjectBtn, "CreateProjectBtn")
        Me.CreateProjectBtn.Name = "CreateProjectBtn"
        Me.CreateProjectBtn.UseVisualStyleBackColor = true
        '
        'locTextBox
        '
        Me.locTextBox.Description = "Select the folder where to create the project."
        Me.locTextBox.Filter = Nothing
        resources.ApplyResources(Me.locTextBox, "locTextBox")
        Me.locTextBox.Name = "locTextBox"
        Me.locTextBox.PathType = ExtremeCore.PathTextBox.PathTypes.Folder
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'verListBox
        '
        Me.verListBox.FormattingEnabled = true
        resources.ApplyResources(Me.verListBox, "verListBox")
        Me.verListBox.Name = "verListBox"
        '
        'nameTextBox
        '
        resources.ApplyResources(Me.nameTextBox, "nameTextBox")
        Me.nameTextBox.Name = "nameTextBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.loadProjectBtn)
        Me.TabPage2.Controls.Add(Me.projectVersion)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.projectName)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.pathTextBox)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'loadProjectBtn
        '
        resources.ApplyResources(Me.loadProjectBtn, "loadProjectBtn")
        Me.loadProjectBtn.Name = "loadProjectBtn"
        Me.loadProjectBtn.UseVisualStyleBackColor = true
        '
        'projectVersion
        '
        resources.ApplyResources(Me.projectVersion, "projectVersion")
        Me.projectVersion.Name = "projectVersion"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'projectName
        '
        resources.ApplyResources(Me.projectName, "projectName")
        Me.projectName.Name = "projectName"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'pathTextBox
        '
        Me.pathTextBox.Description = "Select the project's folder."
        Me.pathTextBox.Filter = Nothing
        resources.ApplyResources(Me.pathTextBox, "pathTextBox")
        Me.pathTextBox.Name = "pathTextBox"
        Me.pathTextBox.PathType = ExtremeCore.PathTextBox.PathTypes.Folder
        Me.pathTextBox.ReadOnly = true
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.recentListBox)
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = true
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        Me.Button3.UseVisualStyleBackColor = true
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'recentListBox
        '
        Me.recentListBox.FormattingEnabled = true
        resources.ApplyResources(Me.recentListBox, "recentListBox")
        Me.recentListBox.Name = "recentListBox"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenGlobalSettingsToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'OpenGlobalSettingsToolStripMenuItem
        '
        Me.OpenGlobalSettingsToolStripMenuItem.Name = "OpenGlobalSettingsToolStripMenuItem"
        resources.ApplyResources(Me.OpenGlobalSettingsToolStripMenuItem, "OpenGlobalSettingsToolStripMenuItem")
        '
        'StartupForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "StartupForm"
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        Me.TabPage3.ResumeLayout(false)
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents verListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CreateProjectBtn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents projectName As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents projectVersion As System.Windows.Forms.Label
    Friend WithEvents loadProjectBtn As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents recentListBox As System.Windows.Forms.ListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OpenGlobalSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents locTextBox As ExtremeCore.PathTextBox
    Friend WithEvents pathTextBox As ExtremeCore.PathTextBox
    Friend WithEvents preExistCheck As CheckBox
End Class
