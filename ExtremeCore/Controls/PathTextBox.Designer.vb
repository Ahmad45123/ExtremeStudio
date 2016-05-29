<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PathTextBox
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
        Me.PathText = New System.Windows.Forms.TextBox()
        Me.BrowseBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'PathText
        '
        Me.PathText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.PathText.Location = New System.Drawing.Point(0, 0)
        Me.PathText.Name = "PathText"
        Me.PathText.Size = New System.Drawing.Size(395, 20)
        Me.PathText.TabIndex = 0
        '
        'BrowseBtn
        '
        Me.BrowseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.BrowseBtn.Location = New System.Drawing.Point(398, 0)
        Me.BrowseBtn.Name = "BrowseBtn"
        Me.BrowseBtn.Size = New System.Drawing.Size(49, 20)
        Me.BrowseBtn.TabIndex = 1
        Me.BrowseBtn.Text = "..."
        Me.BrowseBtn.UseVisualStyleBackColor = true
        '
        'PathTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BrowseBtn)
        Me.Controls.Add(Me.PathText)
        Me.Name = "PathTextBox"
        Me.Size = New System.Drawing.Size(447, 21)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Public WithEvents PathText As Windows.Forms.TextBox
    Public WithEvents BrowseBtn As Windows.Forms.Button
End Class
