<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchReplaceForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchReplaceForm))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.findCloseBtn = New System.Windows.Forms.Button()
        Me.searchFindAllBtn = New System.Windows.Forms.Button()
        Me.searchCountBtn = New System.Windows.Forms.Button()
        Me.searchFindBtn = New System.Windows.Forms.Button()
        Me.searchFindText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.replaceReplaceText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.replaceCloseBtn = New System.Windows.Forms.Button()
        Me.replaceReplaceAllBtn = New System.Windows.Forms.Button()
        Me.replaceReplaceBtn = New System.Windows.Forms.Button()
        Me.replaceFindNextBtn = New System.Windows.Forms.Button()
        Me.replaceFindText = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.matchWholeWordCheck = New System.Windows.Forms.CheckBox()
        Me.matchCaseCheck = New System.Windows.Forms.CheckBox()
        Me.inSelCheck = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.searchRegexRadio = New System.Windows.Forms.RadioButton()
        Me.searchNormalRadio = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Controls.Add(Me.findCloseBtn)
        Me.TabPage1.Controls.Add(Me.searchFindAllBtn)
        Me.TabPage1.Controls.Add(Me.searchCountBtn)
        Me.TabPage1.Controls.Add(Me.searchFindBtn)
        Me.TabPage1.Controls.Add(Me.searchFindText)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'findCloseBtn
        '
        resources.ApplyResources(Me.findCloseBtn, "findCloseBtn")
        Me.findCloseBtn.Name = "findCloseBtn"
        Me.findCloseBtn.UseVisualStyleBackColor = true
        '
        'searchFindAllBtn
        '
        resources.ApplyResources(Me.searchFindAllBtn, "searchFindAllBtn")
        Me.searchFindAllBtn.Name = "searchFindAllBtn"
        Me.searchFindAllBtn.UseVisualStyleBackColor = true
        '
        'searchCountBtn
        '
        resources.ApplyResources(Me.searchCountBtn, "searchCountBtn")
        Me.searchCountBtn.Name = "searchCountBtn"
        Me.searchCountBtn.UseVisualStyleBackColor = true
        '
        'searchFindBtn
        '
        resources.ApplyResources(Me.searchFindBtn, "searchFindBtn")
        Me.searchFindBtn.Name = "searchFindBtn"
        Me.searchFindBtn.UseVisualStyleBackColor = true
        '
        'searchFindText
        '
        resources.ApplyResources(Me.searchFindText, "searchFindText")
        Me.searchFindText.Name = "searchFindText"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'TabPage2
        '
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Controls.Add(Me.replaceReplaceText)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.replaceCloseBtn)
        Me.TabPage2.Controls.Add(Me.replaceReplaceAllBtn)
        Me.TabPage2.Controls.Add(Me.replaceReplaceBtn)
        Me.TabPage2.Controls.Add(Me.replaceFindNextBtn)
        Me.TabPage2.Controls.Add(Me.replaceFindText)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'replaceReplaceText
        '
        resources.ApplyResources(Me.replaceReplaceText, "replaceReplaceText")
        Me.replaceReplaceText.Name = "replaceReplaceText"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'replaceCloseBtn
        '
        resources.ApplyResources(Me.replaceCloseBtn, "replaceCloseBtn")
        Me.replaceCloseBtn.Name = "replaceCloseBtn"
        Me.replaceCloseBtn.UseVisualStyleBackColor = true
        '
        'replaceReplaceAllBtn
        '
        resources.ApplyResources(Me.replaceReplaceAllBtn, "replaceReplaceAllBtn")
        Me.replaceReplaceAllBtn.Name = "replaceReplaceAllBtn"
        Me.replaceReplaceAllBtn.UseVisualStyleBackColor = true
        '
        'replaceReplaceBtn
        '
        resources.ApplyResources(Me.replaceReplaceBtn, "replaceReplaceBtn")
        Me.replaceReplaceBtn.Name = "replaceReplaceBtn"
        Me.replaceReplaceBtn.UseVisualStyleBackColor = true
        '
        'replaceFindNextBtn
        '
        resources.ApplyResources(Me.replaceFindNextBtn, "replaceFindNextBtn")
        Me.replaceFindNextBtn.Name = "replaceFindNextBtn"
        Me.replaceFindNextBtn.UseVisualStyleBackColor = true
        '
        'replaceFindText
        '
        resources.ApplyResources(Me.replaceFindText, "replaceFindText")
        Me.replaceFindText.Name = "replaceFindText"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'matchWholeWordCheck
        '
        resources.ApplyResources(Me.matchWholeWordCheck, "matchWholeWordCheck")
        Me.matchWholeWordCheck.Name = "matchWholeWordCheck"
        Me.matchWholeWordCheck.UseVisualStyleBackColor = true
        '
        'matchCaseCheck
        '
        resources.ApplyResources(Me.matchCaseCheck, "matchCaseCheck")
        Me.matchCaseCheck.Name = "matchCaseCheck"
        Me.matchCaseCheck.UseVisualStyleBackColor = true
        '
        'inSelCheck
        '
        resources.ApplyResources(Me.inSelCheck, "inSelCheck")
        Me.inSelCheck.Name = "inSelCheck"
        Me.inSelCheck.UseVisualStyleBackColor = true
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.searchRegexRadio)
        Me.GroupBox1.Controls.Add(Me.searchNormalRadio)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = false
        '
        'searchRegexRadio
        '
        resources.ApplyResources(Me.searchRegexRadio, "searchRegexRadio")
        Me.searchRegexRadio.Name = "searchRegexRadio"
        Me.searchRegexRadio.TabStop = true
        Me.searchRegexRadio.UseVisualStyleBackColor = true
        '
        'searchNormalRadio
        '
        resources.ApplyResources(Me.searchNormalRadio, "searchNormalRadio")
        Me.searchNormalRadio.Checked = true
        Me.searchNormalRadio.Name = "searchNormalRadio"
        Me.searchNormalRadio.TabStop = true
        Me.searchNormalRadio.UseVisualStyleBackColor = true
        '
        'SearchReplaceForm
        '
        Me.AcceptButton = Me.searchFindBtn
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.inSelCheck)
        Me.Controls.Add(Me.matchCaseCheck)
        Me.Controls.Add(Me.matchWholeWordCheck)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "SearchReplaceForm"
        Me.TopMost = true
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents matchWholeWordCheck As CheckBox
    Friend WithEvents matchCaseCheck As CheckBox
    Friend WithEvents inSelCheck As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents searchRegexRadio As RadioButton
    Friend WithEvents searchNormalRadio As RadioButton
    Friend WithEvents findCloseBtn As Button
    Friend WithEvents searchFindAllBtn As Button
    Friend WithEvents searchCountBtn As Button
    Friend WithEvents searchFindBtn As Button
    Friend WithEvents searchFindText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents replaceFindText As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents replaceFindNextBtn As Button
    Friend WithEvents replaceReplaceAllBtn As Button
    Friend WithEvents replaceReplaceBtn As Button
    Friend WithEvents replaceCloseBtn As Button
    Friend WithEvents replaceReplaceText As TextBox
    Friend WithEvents Label3 As Label
End Class
