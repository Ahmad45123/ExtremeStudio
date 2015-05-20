<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FolderBrowserDialog
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
        Me.FolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'Button
        '
        Me.Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button.Location = New System.Drawing.Point(0, 0)
        Me.Button.Name = "Button"
        Me.Button.Size = New System.Drawing.Size(90, 37)
        Me.Button.TabIndex = 0
        Me.Button.Text = "..."
        Me.Button.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button)
        Me.Name = "FolderBrowserDialog"
        Me.Size = New System.Drawing.Size(90, 37)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents FolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Public WithEvents Button As System.Windows.Forms.Button

End Class
