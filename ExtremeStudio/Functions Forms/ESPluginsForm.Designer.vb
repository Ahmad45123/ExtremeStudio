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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EsPluginsForm))
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
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'PluginList
        '
        resources.ApplyResources(Me.PluginList, "PluginList")
        Me.PluginList.FormattingEnabled = true
        Me.PluginList.Name = "PluginList"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.PluginDescText)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.PluginNameText)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = false
        '
        'PluginDescText
        '
        resources.ApplyResources(Me.PluginDescText, "PluginDescText")
        Me.PluginDescText.Name = "PluginDescText"
        Me.PluginDescText.ReadOnly = true
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'PluginNameText
        '
        resources.ApplyResources(Me.PluginNameText, "PluginNameText")
        Me.PluginNameText.Name = "PluginNameText"
        Me.PluginNameText.ReadOnly = true
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'installBtn
        '
        resources.ApplyResources(Me.installBtn, "installBtn")
        Me.installBtn.Name = "installBtn"
        Me.installBtn.UseVisualStyleBackColor = true
        '
        'deleteBtn
        '
        resources.ApplyResources(Me.deleteBtn, "deleteBtn")
        Me.deleteBtn.Name = "deleteBtn"
        Me.deleteBtn.UseVisualStyleBackColor = true
        '
        'updateLabel
        '
        resources.ApplyResources(Me.updateLabel, "updateLabel")
        Me.updateLabel.Name = "updateLabel"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'EsPluginsForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
