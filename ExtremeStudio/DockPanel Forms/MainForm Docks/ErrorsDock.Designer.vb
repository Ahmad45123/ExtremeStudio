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
        Me.showWarnsCheck = New System.Windows.Forms.CheckBox()
        Me.showErrorsCheck = New System.Windows.Forms.CheckBox()
        Me.errorsWarnsGrid = New System.Windows.Forms.DataGridView()
        Me.typeColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.fileColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lineColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.errNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.errortextColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.parserErrors = New System.Windows.Forms.DataGridView()
        Me.ErrorMsg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        CType(Me.errorsWarnsGrid,System.ComponentModel.ISupportInitialize).BeginInit
        Me.TabPage3.SuspendLayout
        CType(Me.parserErrors,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
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
        Me.TabPage1.Controls.Add(Me.showWarnsCheck)
        Me.TabPage1.Controls.Add(Me.showErrorsCheck)
        Me.TabPage1.Controls.Add(Me.errorsWarnsGrid)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(660, 137)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Script Errors & Warnings"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'showWarnsCheck
        '
        Me.showWarnsCheck.Appearance = System.Windows.Forms.Appearance.Button
        Me.showWarnsCheck.AutoSize = true
        Me.showWarnsCheck.Checked = true
        Me.showWarnsCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.showWarnsCheck.Location = New System.Drawing.Point(89, 6)
        Me.showWarnsCheck.Name = "showWarnsCheck"
        Me.showWarnsCheck.Size = New System.Drawing.Size(91, 23)
        Me.showWarnsCheck.TabIndex = 4
        Me.showWarnsCheck.Text = "Show Warnings"
        Me.showWarnsCheck.UseVisualStyleBackColor = true
        '
        'showErrorsCheck
        '
        Me.showErrorsCheck.Appearance = System.Windows.Forms.Appearance.Button
        Me.showErrorsCheck.AutoSize = true
        Me.showErrorsCheck.Checked = true
        Me.showErrorsCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.showErrorsCheck.Location = New System.Drawing.Point(8, 6)
        Me.showErrorsCheck.Name = "showErrorsCheck"
        Me.showErrorsCheck.Size = New System.Drawing.Size(75, 23)
        Me.showErrorsCheck.TabIndex = 3
        Me.showErrorsCheck.Text = "Show Errors"
        Me.showErrorsCheck.UseVisualStyleBackColor = true
        '
        'errorsWarnsGrid
        '
        Me.errorsWarnsGrid.AllowUserToAddRows = false
        Me.errorsWarnsGrid.AllowUserToDeleteRows = false
        Me.errorsWarnsGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.errorsWarnsGrid.BackgroundColor = System.Drawing.Color.White
        Me.errorsWarnsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.errorsWarnsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.errorsWarnsGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.typeColumn, Me.fileColumn, Me.lineColumn, Me.errNumberColumn, Me.errortextColumn})
        Me.errorsWarnsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.errorsWarnsGrid.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.errorsWarnsGrid.Location = New System.Drawing.Point(0, 35)
        Me.errorsWarnsGrid.MultiSelect = false
        Me.errorsWarnsGrid.Name = "errorsWarnsGrid"
        Me.errorsWarnsGrid.ReadOnly = true
        Me.errorsWarnsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.errorsWarnsGrid.Size = New System.Drawing.Size(660, 102)
        Me.errorsWarnsGrid.TabIndex = 2
        '
        'typeColumn
        '
        Me.typeColumn.HeaderText = "Type"
        Me.typeColumn.Name = "typeColumn"
        Me.typeColumn.ReadOnly = true
        '
        'fileColumn
        '
        Me.fileColumn.HeaderText = "File"
        Me.fileColumn.Name = "fileColumn"
        Me.fileColumn.ReadOnly = true
        '
        'lineColumn
        '
        Me.lineColumn.HeaderText = "Line Number"
        Me.lineColumn.Name = "lineColumn"
        Me.lineColumn.ReadOnly = true
        '
        'errNumberColumn
        '
        Me.errNumberColumn.HeaderText = "Error Number"
        Me.errNumberColumn.Name = "errNumberColumn"
        Me.errNumberColumn.ReadOnly = true
        '
        'errortextColumn
        '
        Me.errortextColumn.HeaderText = "Error Text"
        Me.errortextColumn.Name = "errortextColumn"
        Me.errortextColumn.ReadOnly = true
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.parserErrors)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(660, 137)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Parser Errors"
        Me.TabPage3.UseVisualStyleBackColor = true
        '
        'parserErrors
        '
        Me.parserErrors.AllowUserToAddRows = false
        Me.parserErrors.AllowUserToDeleteRows = false
        Me.parserErrors.BackgroundColor = System.Drawing.Color.White
        Me.parserErrors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.parserErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.parserErrors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ErrorMsg, Me.Column1})
        Me.parserErrors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.parserErrors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.parserErrors.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.parserErrors.Location = New System.Drawing.Point(0, 0)
        Me.parserErrors.MultiSelect = false
        Me.parserErrors.Name = "parserErrors"
        Me.parserErrors.ReadOnly = true
        Me.parserErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.parserErrors.Size = New System.Drawing.Size(660, 137)
        Me.parserErrors.TabIndex = 1
        '
        'ErrorMsg
        '
        Me.ErrorMsg.HeaderText = "Message"
        Me.ErrorMsg.Name = "ErrorMsg"
        Me.ErrorMsg.ReadOnly = true
        '
        'Column1
        '
        Me.Column1.HeaderText = "Error Identifier"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = true
        '
        'ErrorsDock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 163)
        Me.Controls.Add(Me.TabControl1)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom),WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Font = New System.Drawing.Font("Tahoma", 8!)
        Me.Name = "ErrorsDock"
        Me.Text = "Warnings & Errors"
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        CType(Me.errorsWarnsGrid,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabPage3.ResumeLayout(false)
        CType(Me.parserErrors,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents parserErrors As System.Windows.Forms.DataGridView
    Friend WithEvents ErrorMsg As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents errorsWarnsGrid As DataGridView
    Friend WithEvents showWarnsCheck As CheckBox
    Friend WithEvents showErrorsCheck As CheckBox
    Friend WithEvents typeColumn As DataGridViewImageColumn
    Friend WithEvents fileColumn As DataGridViewTextBoxColumn
    Friend WithEvents lineColumn As DataGridViewTextBoxColumn
    Friend WithEvents errNumberColumn As DataGridViewTextBoxColumn
    Friend WithEvents errortextColumn As DataGridViewTextBoxColumn
End Class
