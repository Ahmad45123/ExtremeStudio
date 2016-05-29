<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObjectExplorerDockItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ObjectExplorerDockItems))
        Me.itemsList = New System.Windows.Forms.ListBox()
        Me.selinfo = New System.Windows.Forms.GroupBox()
        Me.deleteBtn = New System.Windows.Forms.Button()
        Me.infoIden = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.infoName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.addBtn = New System.Windows.Forms.Button()
        Me.addIden = New System.Windows.Forms.TextBox()
        Me.addName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.selinfo.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'itemsList
        '
        Me.itemsList.FormattingEnabled = true
        resources.ApplyResources(Me.itemsList, "itemsList")
        Me.itemsList.Name = "itemsList"
        '
        'selinfo
        '
        Me.selinfo.Controls.Add(Me.deleteBtn)
        Me.selinfo.Controls.Add(Me.infoIden)
        Me.selinfo.Controls.Add(Me.Label3)
        Me.selinfo.Controls.Add(Me.infoName)
        Me.selinfo.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.selinfo, "selinfo")
        Me.selinfo.Name = "selinfo"
        Me.selinfo.TabStop = false
        '
        'deleteBtn
        '
        resources.ApplyResources(Me.deleteBtn, "deleteBtn")
        Me.deleteBtn.Name = "deleteBtn"
        Me.deleteBtn.UseVisualStyleBackColor = true
        '
        'infoIden
        '
        resources.ApplyResources(Me.infoIden, "infoIden")
        Me.infoIden.Name = "infoIden"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'infoName
        '
        resources.ApplyResources(Me.infoName, "infoName")
        Me.infoName.Name = "infoName"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.addBtn)
        Me.GroupBox1.Controls.Add(Me.addIden)
        Me.GroupBox1.Controls.Add(Me.addName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = false
        '
        'addBtn
        '
        resources.ApplyResources(Me.addBtn, "addBtn")
        Me.addBtn.Name = "addBtn"
        Me.addBtn.UseVisualStyleBackColor = true
        '
        'addIden
        '
        resources.ApplyResources(Me.addIden, "addIden")
        Me.addIden.Name = "addIden"
        '
        'addName
        '
        resources.ApplyResources(Me.addName, "addName")
        Me.addName.Name = "addName"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'ObjectExplorerDockItems
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.selinfo)
        Me.Controls.Add(Me.itemsList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "ObjectExplorerDockItems"
        Me.selinfo.ResumeLayout(false)
        Me.selinfo.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents itemsList As System.Windows.Forms.ListBox
    Friend WithEvents selinfo As System.Windows.Forms.GroupBox
    Friend WithEvents infoName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents infoIden As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents deleteBtn As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents addIden As System.Windows.Forms.TextBox
    Friend WithEvents addName As System.Windows.Forms.TextBox
    Friend WithEvents addBtn As System.Windows.Forms.Button
End Class
