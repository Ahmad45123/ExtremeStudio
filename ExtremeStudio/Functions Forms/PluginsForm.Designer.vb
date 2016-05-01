<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PluginsForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pluginsList = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pluginDesc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pluginVersion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pluginName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.includeInstalledLabel = New System.Windows.Forms.Label()
        Me.actionsGroup = New System.Windows.Forms.GroupBox()
        Me.serverCFGButton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.updateAvilableLabel = New System.Windows.Forms.Label()
        Me.showInstalledOnlyCheck = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout
        Me.actionsGroup.SuspendLayout
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search: "
        '
        'pluginsList
        '
        Me.pluginsList.FormattingEnabled = true
        Me.pluginsList.Location = New System.Drawing.Point(15, 51)
        Me.pluginsList.Name = "pluginsList"
        Me.pluginsList.Size = New System.Drawing.Size(221, 355)
        Me.pluginsList.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pluginDesc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.pluginVersion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.pluginName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(242, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 160)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Plugin Info: "
        '
        'pluginDesc
        '
        Me.pluginDesc.Location = New System.Drawing.Point(84, 74)
        Me.pluginDesc.Multiline = true
        Me.pluginDesc.Name = "pluginDesc"
        Me.pluginDesc.ReadOnly = true
        Me.pluginDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.pluginDesc.Size = New System.Drawing.Size(232, 80)
        Me.pluginDesc.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(12, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Description: "
        '
        'pluginVersion
        '
        Me.pluginVersion.Location = New System.Drawing.Point(66, 48)
        Me.pluginVersion.Name = "pluginVersion"
        Me.pluginVersion.ReadOnly = true
        Me.pluginVersion.Size = New System.Drawing.Size(250, 20)
        Me.pluginVersion.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(12, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Version: "
        '
        'pluginName
        '
        Me.pluginName.Location = New System.Drawing.Point(97, 22)
        Me.pluginName.Name = "pluginName"
        Me.pluginName.ReadOnly = true
        Me.pluginName.Size = New System.Drawing.Size(219, 20)
        Me.pluginName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(12, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Plugin Name: "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(433, 185)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Install Plugin"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'includeInstalledLabel
        '
        Me.includeInstalledLabel.AutoSize = true
        Me.includeInstalledLabel.Location = New System.Drawing.Point(242, 195)
        Me.includeInstalledLabel.Name = "includeInstalledLabel"
        Me.includeInstalledLabel.Size = New System.Drawing.Size(148, 13)
        Me.includeInstalledLabel.TabIndex = 4
        Me.includeInstalledLabel.Text = "The plugin is already installed."
        Me.includeInstalledLabel.Visible = false
        '
        'actionsGroup
        '
        Me.actionsGroup.Controls.Add(Me.serverCFGButton)
        Me.actionsGroup.Controls.Add(Me.Button2)
        Me.actionsGroup.Location = New System.Drawing.Point(324, 260)
        Me.actionsGroup.Name = "actionsGroup"
        Me.actionsGroup.Size = New System.Drawing.Size(153, 80)
        Me.actionsGroup.TabIndex = 5
        Me.actionsGroup.TabStop = false
        Me.actionsGroup.Text = "Actions: "
        Me.actionsGroup.Visible = false
        '
        'serverCFGButton
        '
        Me.serverCFGButton.Location = New System.Drawing.Point(6, 48)
        Me.serverCFGButton.Name = "serverCFGButton"
        Me.serverCFGButton.Size = New System.Drawing.Size(138, 23)
        Me.serverCFGButton.TabIndex = 1
        Me.serverCFGButton.Text = "Add to server.cfg"
        Me.serverCFGButton.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(138, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Uninstall Plugin"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'updateAvilableLabel
        '
        Me.updateAvilableLabel.AutoSize = true
        Me.updateAvilableLabel.Location = New System.Drawing.Point(242, 211)
        Me.updateAvilableLabel.Name = "updateAvilableLabel"
        Me.updateAvilableLabel.Size = New System.Drawing.Size(198, 13)
        Me.updateAvilableLabel.TabIndex = 6
        Me.updateAvilableLabel.Text = "An update is available, Reinstall to get it."
        Me.updateAvilableLabel.Visible = false
        '
        'showInstalledOnlyCheck
        '
        Me.showInstalledOnlyCheck.AutoSize = true
        Me.showInstalledOnlyCheck.Location = New System.Drawing.Point(239, 390)
        Me.showInstalledOnlyCheck.Name = "showInstalledOnlyCheck"
        Me.showInstalledOnlyCheck.Size = New System.Drawing.Size(156, 17)
        Me.showInstalledOnlyCheck.TabIndex = 7
        Me.showInstalledOnlyCheck.Text = "Show Installed Plugins Only"
        Me.showInstalledOnlyCheck.UseVisualStyleBackColor = true
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 25)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(221, 20)
        Me.TextBox1.TabIndex = 8
        '
        'PluginsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 419)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.showInstalledOnlyCheck)
        Me.Controls.Add(Me.updateAvilableLabel)
        Me.Controls.Add(Me.actionsGroup)
        Me.Controls.Add(Me.includeInstalledLabel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pluginsList)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "PluginsForm"
        Me.Text = "Plugins"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.actionsGroup.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents pluginsList As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pluginName As TextBox
    Friend WithEvents pluginVersion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents pluginDesc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents includeInstalledLabel As Label
    Friend WithEvents actionsGroup As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents updateAvilableLabel As Label
    Friend WithEvents showInstalledOnlyCheck As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents serverCFGButton As Button
End Class
