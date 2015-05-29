<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabelButton
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Button = New System.Windows.Forms.Button()
        Me.Label = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button
        '
        Me.Button.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button.Location = New System.Drawing.Point(3, 3)
        Me.Button.Name = "Button"
        Me.Button.Size = New System.Drawing.Size(55, 48)
        Me.Button.TabIndex = 0
        Me.Button.UseVisualStyleBackColor = True
        '
        'Label
        '
        Me.Label.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label.Location = New System.Drawing.Point(3, 54)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(55, 13)
        Me.Label.TabIndex = 1
        Me.Label.Text = "Label1"
        Me.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelButton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.Button)
        Me.Name = "LabelButton"
        Me.Size = New System.Drawing.Size(61, 71)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label As System.Windows.Forms.Label
    Public WithEvents Button As System.Windows.Forms.Button

End Class
