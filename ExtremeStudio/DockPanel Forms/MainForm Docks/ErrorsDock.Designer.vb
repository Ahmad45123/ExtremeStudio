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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErrorsDock))
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
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Controls.Add(Me.showWarnsCheck)
        Me.TabPage1.Controls.Add(Me.showErrorsCheck)
        Me.TabPage1.Controls.Add(Me.errorsWarnsGrid)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'showWarnsCheck
        '
        resources.ApplyResources(Me.showWarnsCheck, "showWarnsCheck")
        Me.showWarnsCheck.Checked = true
        Me.showWarnsCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.showWarnsCheck.Name = "showWarnsCheck"
        Me.showWarnsCheck.UseVisualStyleBackColor = true
        '
        'showErrorsCheck
        '
        resources.ApplyResources(Me.showErrorsCheck, "showErrorsCheck")
        Me.showErrorsCheck.Checked = true
        Me.showErrorsCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.showErrorsCheck.Name = "showErrorsCheck"
        Me.showErrorsCheck.UseVisualStyleBackColor = true
        '
        'errorsWarnsGrid
        '
        resources.ApplyResources(Me.errorsWarnsGrid, "errorsWarnsGrid")
        Me.errorsWarnsGrid.AllowUserToAddRows = false
        Me.errorsWarnsGrid.AllowUserToDeleteRows = false
        Me.errorsWarnsGrid.BackgroundColor = System.Drawing.Color.White
        Me.errorsWarnsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.errorsWarnsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.errorsWarnsGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.typeColumn, Me.fileColumn, Me.lineColumn, Me.errNumberColumn, Me.errortextColumn})
        Me.errorsWarnsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.errorsWarnsGrid.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.errorsWarnsGrid.MultiSelect = false
        Me.errorsWarnsGrid.Name = "errorsWarnsGrid"
        Me.errorsWarnsGrid.ReadOnly = true
        Me.errorsWarnsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'typeColumn
        '
        resources.ApplyResources(Me.typeColumn, "typeColumn")
        Me.typeColumn.Name = "typeColumn"
        Me.typeColumn.ReadOnly = true
        '
        'fileColumn
        '
        resources.ApplyResources(Me.fileColumn, "fileColumn")
        Me.fileColumn.Name = "fileColumn"
        Me.fileColumn.ReadOnly = true
        '
        'lineColumn
        '
        resources.ApplyResources(Me.lineColumn, "lineColumn")
        Me.lineColumn.Name = "lineColumn"
        Me.lineColumn.ReadOnly = true
        '
        'errNumberColumn
        '
        resources.ApplyResources(Me.errNumberColumn, "errNumberColumn")
        Me.errNumberColumn.Name = "errNumberColumn"
        Me.errNumberColumn.ReadOnly = true
        '
        'errortextColumn
        '
        resources.ApplyResources(Me.errortextColumn, "errortextColumn")
        Me.errortextColumn.Name = "errortextColumn"
        Me.errortextColumn.ReadOnly = true
        '
        'TabPage3
        '
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Controls.Add(Me.parserErrors)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = true
        '
        'parserErrors
        '
        resources.ApplyResources(Me.parserErrors, "parserErrors")
        Me.parserErrors.AllowUserToAddRows = false
        Me.parserErrors.AllowUserToDeleteRows = false
        Me.parserErrors.BackgroundColor = System.Drawing.Color.White
        Me.parserErrors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        Me.parserErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.parserErrors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ErrorMsg, Me.Column1})
        Me.parserErrors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.parserErrors.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.parserErrors.MultiSelect = false
        Me.parserErrors.Name = "parserErrors"
        Me.parserErrors.ReadOnly = true
        Me.parserErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'ErrorMsg
        '
        resources.ApplyResources(Me.ErrorMsg, "ErrorMsg")
        Me.ErrorMsg.Name = "ErrorMsg"
        Me.ErrorMsg.ReadOnly = true
        '
        'Column1
        '
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = true
        '
        'ErrorsDock
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)  _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom),WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Name = "ErrorsDock"
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
