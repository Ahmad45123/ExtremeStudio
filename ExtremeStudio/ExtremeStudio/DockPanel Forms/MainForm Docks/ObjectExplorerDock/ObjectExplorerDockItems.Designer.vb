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
        Me.itemsList = New System.Windows.Forms.ListBox()
        Me.selinfo = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.infoIden = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.infoName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.addIden = New System.Windows.Forms.TextBox()
        Me.addName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.selinfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'itemsList
        '
        Me.itemsList.FormattingEnabled = True
        Me.itemsList.Location = New System.Drawing.Point(12, 12)
        Me.itemsList.Name = "itemsList"
        Me.itemsList.Size = New System.Drawing.Size(207, 342)
        Me.itemsList.TabIndex = 0
        '
        'selinfo
        '
        Me.selinfo.Controls.Add(Me.Button1)
        Me.selinfo.Controls.Add(Me.infoIden)
        Me.selinfo.Controls.Add(Me.Label3)
        Me.selinfo.Controls.Add(Me.infoName)
        Me.selinfo.Controls.Add(Me.Label1)
        Me.selinfo.Location = New System.Drawing.Point(225, 12)
        Me.selinfo.Name = "selinfo"
        Me.selinfo.Size = New System.Drawing.Size(229, 84)
        Me.selinfo.TabIndex = 1
        Me.selinfo.TabStop = False
        Me.selinfo.Text = "Selected Info"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(203, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'infoIden
        '
        Me.infoIden.AutoSize = True
        Me.infoIden.Location = New System.Drawing.Point(70, 55)
        Me.infoIden.Name = "infoIden"
        Me.infoIden.Size = New System.Drawing.Size(25, 13)
        Me.infoIden.TabIndex = 3
        Me.infoIden.Text = "Null"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Identifier: "
        '
        'infoName
        '
        Me.infoName.AutoSize = True
        Me.infoName.Location = New System.Drawing.Point(49, 28)
        Me.infoName.Name = "infoName"
        Me.infoName.Size = New System.Drawing.Size(25, 13)
        Me.infoName.TabIndex = 1
        Me.infoName.Text = "Null"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name: "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.addIden)
        Me.GroupBox1.Controls.Add(Me.addName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(225, 254)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(229, 100)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New: "
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(148, 71)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Add"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'addIden
        '
        Me.addIden.Location = New System.Drawing.Point(70, 45)
        Me.addIden.Name = "addIden"
        Me.addIden.Size = New System.Drawing.Size(153, 20)
        Me.addIden.TabIndex = 3
        '
        'addName
        '
        Me.addName.Location = New System.Drawing.Point(52, 23)
        Me.addName.Name = "addName"
        Me.addName.Size = New System.Drawing.Size(171, 20)
        Me.addName.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Identifier: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Name: "
        '
        'ObjectExplorerDockItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 372)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.selinfo)
        Me.Controls.Add(Me.itemsList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ObjectExplorerDockItems"
        Me.Text = "Object Explorer Items"
        Me.selinfo.ResumeLayout(False)
        Me.selinfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents itemsList As System.Windows.Forms.ListBox
    Friend WithEvents selinfo As System.Windows.Forms.GroupBox
    Friend WithEvents infoName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents infoIden As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents addIden As System.Windows.Forms.TextBox
    Friend WithEvents addName As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
