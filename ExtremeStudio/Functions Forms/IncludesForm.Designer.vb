<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IncludesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncludesForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.includesList = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.includeDesc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.includeVersion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.includeName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.includeInstalledLabel = New System.Windows.Forms.Label()
        Me.actionsGroup = New System.Windows.Forms.GroupBox()
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
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'includesList
        '
        resources.ApplyResources(Me.includesList, "includesList")
        Me.includesList.FormattingEnabled = true
        Me.includesList.Name = "includesList"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.includeDesc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.includeVersion)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.includeName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = false
        '
        'includeDesc
        '
        resources.ApplyResources(Me.includeDesc, "includeDesc")
        Me.includeDesc.Name = "includeDesc"
        Me.includeDesc.ReadOnly = true
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'includeVersion
        '
        resources.ApplyResources(Me.includeVersion, "includeVersion")
        Me.includeVersion.Name = "includeVersion"
        Me.includeVersion.ReadOnly = true
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'includeName
        '
        resources.ApplyResources(Me.includeName, "includeName")
        Me.includeName.Name = "includeName"
        Me.includeName.ReadOnly = true
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'includeInstalledLabel
        '
        resources.ApplyResources(Me.includeInstalledLabel, "includeInstalledLabel")
        Me.includeInstalledLabel.Name = "includeInstalledLabel"
        '
        'actionsGroup
        '
        resources.ApplyResources(Me.actionsGroup, "actionsGroup")
        Me.actionsGroup.Controls.Add(Me.Button2)
        Me.actionsGroup.Name = "actionsGroup"
        Me.actionsGroup.TabStop = false
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'updateAvilableLabel
        '
        resources.ApplyResources(Me.updateAvilableLabel, "updateAvilableLabel")
        Me.updateAvilableLabel.Name = "updateAvilableLabel"
        '
        'showInstalledOnlyCheck
        '
        resources.ApplyResources(Me.showInstalledOnlyCheck, "showInstalledOnlyCheck")
        Me.showInstalledOnlyCheck.Name = "showInstalledOnlyCheck"
        Me.showInstalledOnlyCheck.UseVisualStyleBackColor = true
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'IncludesForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
        Me.MaximizeBox = false
        Me.Name = "IncludesForm"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.actionsGroup.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

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
End Class
