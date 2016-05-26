<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EsPluginsForm
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
        Me.PluginList = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PluginDescText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PluginNameText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.installBtn = New System.Windows.Forms.Button()
        Me.deleteBtn = New System.Windows.Forms.Button()
        Me.updateLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Plugins: "
        '
        'PluginList
        '
        Me.PluginList.FormattingEnabled = true
        Me.PluginList.Location = New System.Drawing.Point(12, 21)
        Me.PluginList.Name = "PluginList"
        Me.PluginList.Size = New System.Drawing.Size(195, 420)
        Me.PluginList.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PluginDescText)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PluginNameText)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(213, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 169)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Info: "
        '
        'PluginDescText
        '
        Me.PluginDescText.Location = New System.Drawing.Point(104, 52)
        Me.PluginDescText.Multiline = true
        Me.PluginDescText.Name = "PluginDescText"
        Me.PluginDescText.ReadOnly = true
        Me.PluginDescText.Size = New System.Drawing.Size(183, 108)
        Me.PluginDescText.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(8, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Plugin Description: "
        '
        'PluginNameText
        '
        Me.PluginNameText.Location = New System.Drawing.Point(79, 19)
        Me.PluginNameText.Name = "PluginNameText"
        Me.PluginNameText.ReadOnly = true
        Me.PluginNameText.Size = New System.Drawing.Size(208, 20)
        Me.PluginNameText.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(8, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Plugin Name: "
        '
        'installBtn
        '
        Me.installBtn.Enabled = false
        Me.installBtn.Location = New System.Drawing.Point(213, 196)
        Me.installBtn.Name = "installBtn"
        Me.installBtn.Size = New System.Drawing.Size(106, 23)
        Me.installBtn.TabIndex = 3
        Me.installBtn.UseVisualStyleBackColor = true
        '
        'deleteBtn
        '
        Me.deleteBtn.Location = New System.Drawing.Point(400, 196)
        Me.deleteBtn.Name = "deleteBtn"
        Me.deleteBtn.Size = New System.Drawing.Size(106, 23)
        Me.deleteBtn.TabIndex = 4
        Me.deleteBtn.Text = "Delete Plugin"
        Me.deleteBtn.UseVisualStyleBackColor = true
        Me.deleteBtn.Visible = false
        '
        'updateLabel
        '
        Me.updateLabel.AutoSize = true
        Me.updateLabel.Location = New System.Drawing.Point(221, 222)
        Me.updateLabel.Name = "updateLabel"
        Me.updateLabel.Size = New System.Drawing.Size(227, 13)
        Me.updateLabel.TabIndex = 6
        Me.updateLabel.Text = "This plugin has an update, reinstall to update."
        Me.updateLabel.Visible = false
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10!)
        Me.Label4.Location = New System.Drawing.Point(210, 425)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(299, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "NOTE: Restart ExtremeStudio to reload plugins."
        '
        'EsPluginsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 447)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.updateLabel)
        Me.Controls.Add(Me.deleteBtn)
        Me.Controls.Add(Me.installBtn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PluginList)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "EsPluginsForm"
        Me.Text = "ES Plugins Management."
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PluginList As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PluginDescText As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PluginNameText As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents installBtn As Button
    Friend WithEvents deleteBtn As Button
    Friend WithEvents updateLabel As Label
    Friend WithEvents Label4 As Label
End Class
