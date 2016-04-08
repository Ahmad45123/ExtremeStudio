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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.resetBtn = New System.Windows.Forms.Button()
        Me.importBtn = New System.Windows.Forms.Button()
        Me.exportBtn = New System.Windows.Forms.Button()
        Me.colorsSettings = New System.Windows.Forms.PropertyGrid()
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.SuspendLayout
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(367, 462)
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
        Me.TabPage1.Size = New System.Drawing.Size(359, 436)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Theme And Colors"
        '
        'resetBtn
        '
        Me.resetBtn.Location = New System.Drawing.Point(268, 405)
        Me.resetBtn.Name = "resetBtn"
        Me.resetBtn.Size = New System.Drawing.Size(88, 23)
        Me.resetBtn.TabIndex = 44
        Me.resetBtn.Text = "Reset Default"
        Me.resetBtn.UseVisualStyleBackColor = true
        '
        'importBtn
        '
        Me.importBtn.Location = New System.Drawing.Point(87, 405)
        Me.importBtn.Name = "importBtn"
        Me.importBtn.Size = New System.Drawing.Size(75, 23)
        Me.importBtn.TabIndex = 43
        Me.importBtn.Text = "Import"
        Me.importBtn.UseVisualStyleBackColor = true
        '
        'exportBtn
        '
        Me.exportBtn.Location = New System.Drawing.Point(6, 405)
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
        Me.colorsSettings.Size = New System.Drawing.Size(353, 396)
        Me.colorsSettings.TabIndex = 41
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 462)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "SettingsForm"
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Public WithEvents TabControl1 As TabControl
    Public WithEvents TabPage1 As TabPage
    Friend WithEvents colorsSettings As PropertyGrid
    Friend WithEvents exportBtn As Button
    Friend WithEvents resetBtn As Button
    Friend WithEvents importBtn As Button
End Class
