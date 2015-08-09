<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorsDock
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.parserErrors = New System.Windows.Forms.DataGridView()
        Me.ErrorMsg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.parserErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(668, 163)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(660, 137)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Script Errors"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(660, 137)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Script Warnings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.parserErrors)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(660, 137)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Parser Errors"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'parserErrors
        '
        Me.parserErrors.AllowUserToAddRows = False
        Me.parserErrors.AllowUserToDeleteRows = False
        Me.parserErrors.BackgroundColor = System.Drawing.Color.White
        Me.parserErrors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.parserErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.parserErrors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ErrorMsg, Me.Column1})
        Me.parserErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.parserErrors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.parserErrors.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.parserErrors.Location = New System.Drawing.Point(0, 0)
        Me.parserErrors.MultiSelect = False
        Me.parserErrors.Name = "parserErrors"
        Me.parserErrors.ReadOnly = True
        Me.parserErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.parserErrors.Size = New System.Drawing.Size(660, 137)
        Me.parserErrors.TabIndex = 1
        '
        'ErrorMsg
        '
        Me.ErrorMsg.HeaderText = "Message"
        Me.ErrorMsg.Name = "ErrorMsg"
        Me.ErrorMsg.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Error Identifier"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'ErrorsDock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 163)
        Me.Controls.Add(Me.TabControl1)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Name = "ErrorsDock"
        Me.Text = "Warnings & Errors"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.parserErrors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents parserErrors As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorMsg As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
