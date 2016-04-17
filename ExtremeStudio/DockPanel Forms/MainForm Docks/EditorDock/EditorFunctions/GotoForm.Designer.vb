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
        Me.linenumberRadio = New System.Windows.Forms.RadioButton()
        Me.positionRadio = New System.Windows.Forms.RadioButton()
        Me.theLabel = New System.Windows.Forms.Label()
        Me.valueTextBox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.curLabel = New System.Windows.Forms.Label()
        Me.maxLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'linenumberRadio
        '
        Me.linenumberRadio.AutoSize = true
        Me.linenumberRadio.Checked = true
        Me.linenumberRadio.Location = New System.Drawing.Point(12, 12)
        Me.linenumberRadio.Name = "linenumberRadio"
        Me.linenumberRadio.Size = New System.Drawing.Size(84, 17)
        Me.linenumberRadio.TabIndex = 0
        Me.linenumberRadio.TabStop = true
        Me.linenumberRadio.Text = "Line Number"
        Me.linenumberRadio.UseVisualStyleBackColor = true
        '
        'positionRadio
        '
        Me.positionRadio.AutoSize = true
        Me.positionRadio.Location = New System.Drawing.Point(277, 12)
        Me.positionRadio.Name = "positionRadio"
        Me.positionRadio.Size = New System.Drawing.Size(62, 17)
        Me.positionRadio.TabIndex = 1
        Me.positionRadio.TabStop = true
        Me.positionRadio.Text = "Position"
        Me.positionRadio.UseVisualStyleBackColor = true
        '
        'theLabel
        '
        Me.theLabel.AutoSize = true
        Me.theLabel.Location = New System.Drawing.Point(9, 36)
        Me.theLabel.Name = "theLabel"
        Me.theLabel.Size = New System.Drawing.Size(73, 13)
        Me.theLabel.TabIndex = 2
        Me.theLabel.Text = "Line Number: "
        '
        'valueTextBox
        '
        Me.valueTextBox.Location = New System.Drawing.Point(88, 33)
        Me.valueTextBox.Name = "valueTextBox"
        Me.valueTextBox.Size = New System.Drawing.Size(248, 20)
        Me.valueTextBox.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(7, 66)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&Go"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(261, 66)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "&Cancel"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'curLabel
        '
        Me.curLabel.AutoSize = true
        Me.curLabel.Location = New System.Drawing.Point(9, 111)
        Me.curLabel.Name = "curLabel"
        Me.curLabel.Size = New System.Drawing.Size(57, 13)
        Me.curLabel.TabIndex = 6
        Me.curLabel.Text = "Current: 0"
        '
        'maxLabel
        '
        Me.maxLabel.AutoSize = true
        Me.maxLabel.Location = New System.Drawing.Point(248, 111)
        Me.maxLabel.Name = "maxLabel"
        Me.maxLabel.Size = New System.Drawing.Size(64, 13)
        Me.maxLabel.TabIndex = 7
        Me.maxLabel.Text = "Maximum: 0"
        '
        'GotoForm
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(351, 134)
        Me.Controls.Add(Me.maxLabel)
        Me.Controls.Add(Me.curLabel)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.valueTextBox)
        Me.Controls.Add(Me.theLabel)
        Me.Controls.Add(Me.positionRadio)
        Me.Controls.Add(Me.linenumberRadio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "GotoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Goto"
        Me.TopMost = true
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents linenumberRadio As RadioButton
    Friend WithEvents positionRadio As RadioButton
    Friend WithEvents theLabel As Label
    Friend WithEvents valueTextBox As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents curLabel As Label
    Friend WithEvents maxLabel As Label
End Class
