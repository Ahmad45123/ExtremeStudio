<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IncludesForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.includesList = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.includeName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.includeVersion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.includeDesc = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.includeInstalledLabel = New System.Windows.Forms.Label()
        Me.actionsGroup = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.updateAvilableLabel = New System.Windows.Forms.Label()
        Me.showInstalledOnlyCheck = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.actionsGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Includes List: "
        '
        'includesList
        '
        Me.includesList.FormattingEnabled = True
        Me.includesList.Location = New System.Drawing.Point(15, 51)
        Me.includesList.Name = "includesList"
        Me.includesList.Size = New System.Drawing.Size(221, 355)
        Me.includesList.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.includeDesc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.includeVersion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.includeName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(242, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 160)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Include Info: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Include Name: "
        '
        'includeName
        '
        Me.includeName.Location = New System.Drawing.Point(97, 22)
        Me.includeName.Name = "includeName"
        Me.includeName.ReadOnly = True
        Me.includeName.Size = New System.Drawing.Size(219, 20)
        Me.includeName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Version: "
        '
        'includeVersion
        '
        Me.includeVersion.Location = New System.Drawing.Point(66, 48)
        Me.includeVersion.Name = "includeVersion"
        Me.includeVersion.ReadOnly = True
        Me.includeVersion.Size = New System.Drawing.Size(250, 20)
        Me.includeVersion.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Description: "
        '
        'includeDesc
        '
        Me.includeDesc.Location = New System.Drawing.Point(84, 74)
        Me.includeDesc.Multiline = True
        Me.includeDesc.Name = "includeDesc"
        Me.includeDesc.ReadOnly = True
        Me.includeDesc.Size = New System.Drawing.Size(232, 80)
        Me.includeDesc.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(433, 185)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Add Include To Script"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'includeInstalledLabel
        '
        Me.includeInstalledLabel.AutoSize = True
        Me.includeInstalledLabel.Location = New System.Drawing.Point(242, 188)
        Me.includeInstalledLabel.Name = "includeInstalledLabel"
        Me.includeInstalledLabel.Size = New System.Drawing.Size(154, 13)
        Me.includeInstalledLabel.TabIndex = 4
        Me.includeInstalledLabel.Text = "The include is already installed."
        Me.includeInstalledLabel.Visible = False
        '
        'actionsGroup
        '
        Me.actionsGroup.Controls.Add(Me.Button2)
        Me.actionsGroup.Location = New System.Drawing.Point(339, 312)
        Me.actionsGroup.Name = "actionsGroup"
        Me.actionsGroup.Size = New System.Drawing.Size(120, 59)
        Me.actionsGroup.TabIndex = 5
        Me.actionsGroup.TabStop = False
        Me.actionsGroup.Text = "Actions: "
        Me.actionsGroup.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(105, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "ReInstall Include"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'updateAvilableLabel
        '
        Me.updateAvilableLabel.AutoSize = True
        Me.updateAvilableLabel.Location = New System.Drawing.Point(305, 294)
        Me.updateAvilableLabel.Name = "updateAvilableLabel"
        Me.updateAvilableLabel.Size = New System.Drawing.Size(198, 13)
        Me.updateAvilableLabel.TabIndex = 6
        Me.updateAvilableLabel.Text = "An update is available, Reinstall to get it."
        Me.updateAvilableLabel.Visible = False
        '
        'showInstalledOnlyCheck
        '
        Me.showInstalledOnlyCheck.AutoSize = True
        Me.showInstalledOnlyCheck.Location = New System.Drawing.Point(239, 390)
        Me.showInstalledOnlyCheck.Name = "showInstalledOnlyCheck"
        Me.showInstalledOnlyCheck.Size = New System.Drawing.Size(162, 17)
        Me.showInstalledOnlyCheck.TabIndex = 7
        Me.showInstalledOnlyCheck.Text = "Show Installed Includes Only"
        Me.showInstalledOnlyCheck.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 25)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(140, 20)
        Me.TextBox1.TabIndex = 8
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(161, 23)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Search"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'IncludesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 419)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.showInstalledOnlyCheck)
        Me.Controls.Add(Me.updateAvilableLabel)
        Me.Controls.Add(Me.actionsGroup)
        Me.Controls.Add(Me.includeInstalledLabel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.includesList)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "IncludesForm"
        Me.Text = "Includes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.actionsGroup.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents includesList As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents includeName As TextBox
    Friend WithEvents includeVersion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents includeDesc As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents includeInstalledLabel As Label
    Friend WithEvents actionsGroup As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents updateAvilableLabel As Label
    Friend WithEvents showInstalledOnlyCheck As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
End Class
