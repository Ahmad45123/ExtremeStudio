<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GotoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GotoForm))
        Me.linenumberRadio = New System.Windows.Forms.RadioButton()
        Me.positionRadio = New System.Windows.Forms.RadioButton()
        Me.theLabel = New System.Windows.Forms.Label()
        Me.valueTextBox = New System.Windows.Forms.TextBox()
        Me.GoBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.curLabel = New System.Windows.Forms.Label()
        Me.maxLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'linenumberRadio
        '
        resources.ApplyResources(Me.linenumberRadio, "linenumberRadio")
        Me.linenumberRadio.Checked = true
        Me.linenumberRadio.Name = "linenumberRadio"
        Me.linenumberRadio.TabStop = true
        Me.linenumberRadio.UseVisualStyleBackColor = true
        '
        'positionRadio
        '
        resources.ApplyResources(Me.positionRadio, "positionRadio")
        Me.positionRadio.Name = "positionRadio"
        Me.positionRadio.TabStop = true
        Me.positionRadio.UseVisualStyleBackColor = true
        '
        'theLabel
        '
        resources.ApplyResources(Me.theLabel, "theLabel")
        Me.theLabel.Name = "theLabel"
        '
        'valueTextBox
        '
        resources.ApplyResources(Me.valueTextBox, "valueTextBox")
        Me.valueTextBox.Name = "valueTextBox"
        '
        'GoBtn
        '
        resources.ApplyResources(Me.GoBtn, "GoBtn")
        Me.GoBtn.Name = "GoBtn"
        Me.GoBtn.UseVisualStyleBackColor = true
        '
        'CancelBtn
        '
        resources.ApplyResources(Me.CancelBtn, "CancelBtn")
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.UseVisualStyleBackColor = true
        '
        'curLabel
        '
        resources.ApplyResources(Me.curLabel, "curLabel")
        Me.curLabel.Name = "curLabel"
        '
        'maxLabel
        '
        resources.ApplyResources(Me.maxLabel, "maxLabel")
        Me.maxLabel.Name = "maxLabel"
        '
        'GotoForm
        '
        Me.AcceptButton = Me.GoBtn
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.maxLabel)
        Me.Controls.Add(Me.curLabel)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.GoBtn)
        Me.Controls.Add(Me.valueTextBox)
        Me.Controls.Add(Me.theLabel)
        Me.Controls.Add(Me.positionRadio)
        Me.Controls.Add(Me.linenumberRadio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "GotoForm"
        Me.TopMost = true
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents linenumberRadio As RadioButton
    Friend WithEvents positionRadio As RadioButton
    Friend WithEvents theLabel As Label
    Friend WithEvents valueTextBox As TextBox
    Friend WithEvents GoBtn As Button
    Friend WithEvents CancelBtn As Button
    Friend WithEvents curLabel As Label
    Friend WithEvents maxLabel As Label
End Class
