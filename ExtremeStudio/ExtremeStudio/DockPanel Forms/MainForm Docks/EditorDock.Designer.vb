<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorDock
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Me.Scintilla1 = New ScintillaNET.Scintilla()
        Me.SuspendLayout()
        '
        'Scintilla1
        '
        Me.Scintilla1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Scintilla1.Location = New System.Drawing.Point(0, 0)
        Me.Scintilla1.Name = "Scintilla1"
        Me.Scintilla1.Size = New System.Drawing.Size(566, 417)
        Me.Scintilla1.TabIndex = 0
        Me.Scintilla1.Text = "Scintilla1"
        '
        'EditorDock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 417)
        Me.Controls.Add(Me.Scintilla1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "EditorDock"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Scintilla1 As ScintillaNET.Scintilla
End Class
