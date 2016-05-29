<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LanguagesForm
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
        Me.LangsListBox = New System.Windows.Forms.ListBox()
        Me.Acceptbtn = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'LangsListBox
        '
        Me.LangsListBox.FormattingEnabled = true
        Me.LangsListBox.Items.AddRange(New Object() {"English"})
        Me.LangsListBox.Location = New System.Drawing.Point(12, 12)
        Me.LangsListBox.Name = "LangsListBox"
        Me.LangsListBox.Size = New System.Drawing.Size(302, 316)
        Me.LangsListBox.TabIndex = 0
        '
        'Acceptbtn
        '
        Me.Acceptbtn.Location = New System.Drawing.Point(12, 334)
        Me.Acceptbtn.Name = "Acceptbtn"
        Me.Acceptbtn.Size = New System.Drawing.Size(302, 23)
        Me.Acceptbtn.TabIndex = 1
        Me.Acceptbtn.Text = "Choose Language"
        Me.Acceptbtn.UseVisualStyleBackColor = true
        '
        'LanguagesForm
        '
        Me.AcceptButton = Me.Acceptbtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 365)
        Me.Controls.Add(Me.Acceptbtn)
        Me.Controls.Add(Me.LangsListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = false
        Me.Name = "LanguagesForm"
        Me.Text = "Choose UI Language"
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents LangsListBox As ListBox
    Friend WithEvents Acceptbtn As Button
End Class
