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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FolderBrowserDialog1 = New ExtremeCore.FolderBrowserButton()
        Me.locTextBox = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
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
        Me.pathTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FolderBrowserButton1 = New ExtremeCore.FolderBrowserButton()
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
        Me.TabControl1.Location = New System.Drawing.Point(12, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(775, 212)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.FolderBrowserDialog1)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.locTextBox)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.verListBox)
        Me.TabPage1.Controls.Add(Me.nameTextBox)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(767, 186)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Create new project"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Location = New System.Drawing.Point(698, 124)
        Me.FolderBrowserDialog1.Name = "FolderBrowserDialog1"
        Me.FolderBrowserDialog1.Size = New System.Drawing.Size(63, 21)
        Me.FolderBrowserDialog1.TabIndex = 8
        Me.FolderBrowserDialog1.TextControl = Me.locTextBox
        '
        'locTextBox
        '
        Me.locTextBox.Location = New System.Drawing.Point(90, 124)
        Me.locTextBox.Name = "locTextBox"
        Me.locTextBox.Size = New System.Drawing.Size(602, 20)
        Me.locTextBox.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(9, 151)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(752, 30)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Create Project"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(6, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Project location: "
        '
        'verListBox
        '
        Me.verListBox.FormattingEnabled = true
        Me.verListBox.Location = New System.Drawing.Point(90, 36)
        Me.verListBox.Name = "verListBox"
        Me.verListBox.Size = New System.Drawing.Size(671, 82)
        Me.verListBox.TabIndex = 3
        '
        'nameTextBox
        '
        Me.nameTextBox.Location = New System.Drawing.Point(90, 10)
        Me.nameTextBox.Name = "nameTextBox"
        Me.nameTextBox.Size = New System.Drawing.Size(671, 20)
        Me.nameTextBox.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(6, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "SA-MP Version: "
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Project Name: "
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.loadProjectBtn)
        Me.TabPage2.Controls.Add(Me.projectVersion)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.projectName)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.pathTextBox)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.FolderBrowserButton1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(767, 174)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Load project"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'loadProjectBtn
        '
        Me.loadProjectBtn.Enabled = false
        Me.loadProjectBtn.Location = New System.Drawing.Point(9, 134)
        Me.loadProjectBtn.Name = "loadProjectBtn"
        Me.loadProjectBtn.Size = New System.Drawing.Size(752, 49)
        Me.loadProjectBtn.TabIndex = 7
        Me.loadProjectBtn.Text = "Load Project"
        Me.loadProjectBtn.UseVisualStyleBackColor = true
        '
        'projectVersion
        '
        Me.projectVersion.AutoSize = true
        Me.projectVersion.Location = New System.Drawing.Point(87, 91)
        Me.projectVersion.Name = "projectVersion"
        Me.projectVersion.Size = New System.Drawing.Size(32, 13)
        Me.projectVersion.TabIndex = 6
        Me.projectVersion.Text = "None"
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(6, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Project Version: "
        '
        'projectName
        '
        Me.projectName.AutoSize = true
        Me.projectName.Location = New System.Drawing.Point(79, 53)
        Me.projectName.Name = "projectName"
        Me.projectName.Size = New System.Drawing.Size(32, 13)
        Me.projectName.TabIndex = 4
        Me.projectName.Text = "None"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(6, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Project Name: "
        '
        'pathTextBox
        '
        Me.pathTextBox.Location = New System.Drawing.Point(106, 10)
        Me.pathTextBox.Name = "pathTextBox"
        Me.pathTextBox.ReadOnly = true
        Me.pathTextBox.Size = New System.Drawing.Size(581, 20)
        Me.pathTextBox.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(6, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Project directory: "
        '
        'FolderBrowserButton1
        '
        Me.FolderBrowserButton1.Location = New System.Drawing.Point(693, 10)
        Me.FolderBrowserButton1.Name = "FolderBrowserButton1"
        Me.FolderBrowserButton1.Size = New System.Drawing.Size(68, 20)
        Me.FolderBrowserButton1.TabIndex = 2
        Me.FolderBrowserButton1.TextControl = Me.pathTextBox
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Controls.Add(Me.Button1)
        Me.TabPage3.Controls.Add(Me.recentListBox)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(767, 174)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Recent"
        Me.TabPage3.UseVisualStyleBackColor = true
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(660, 35)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Delete Selected"
        Me.Button3.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(660, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Load Selected"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'recentListBox
        '
        Me.recentListBox.FormattingEnabled = true
        Me.recentListBox.HorizontalScrollbar = true
        Me.recentListBox.Location = New System.Drawing.Point(6, 6)
        Me.recentListBox.Name = "recentListBox"
        Me.recentListBox.Size = New System.Drawing.Size(648, 173)
        Me.recentListBox.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenGlobalSettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(799, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OpenGlobalSettingsToolStripMenuItem
        '
        Me.OpenGlobalSettingsToolStripMenuItem.Name = "OpenGlobalSettingsToolStripMenuItem"
        Me.OpenGlobalSettingsToolStripMenuItem.Size = New System.Drawing.Size(130, 20)
        Me.OpenGlobalSettingsToolStripMenuItem.Text = "Open Global Settings"
        '
        'StartupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 249)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "StartupForm"
        Me.Text = "Load / Create Project"
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
    Friend WithEvents locTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As ExtremeCore.FolderBrowserButton
    Friend WithEvents FolderBrowserButton1 As ExtremeCore.FolderBrowserButton
    Friend WithEvents pathTextBox As System.Windows.Forms.TextBox
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
End Class
