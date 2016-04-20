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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.findCloseBtn = New System.Windows.Forms.Button()
        Me.searchFindAllBtn = New System.Windows.Forms.Button()
        Me.FindAllInAllBtn = New System.Windows.Forms.Button()
        Me.searchCountBtn = New System.Windows.Forms.Button()
        Me.searchFindBtn = New System.Windows.Forms.Button()
        Me.searchFindText = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.replaceReplaceText = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.replaceCloseBtn = New System.Windows.Forms.Button()
        Me.replaceReplaceAllDocsBtn = New System.Windows.Forms.Button()
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.directionDownRadio = New System.Windows.Forms.RadioButton()
        Me.directionUpRadio = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.SuspendLayout
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(-3, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(496, 223)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.findCloseBtn)
        Me.TabPage1.Controls.Add(Me.searchFindAllBtn)
        Me.TabPage1.Controls.Add(Me.FindAllInAllBtn)
        Me.TabPage1.Controls.Add(Me.searchCountBtn)
        Me.TabPage1.Controls.Add(Me.searchFindBtn)
        Me.TabPage1.Controls.Add(Me.searchFindText)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(488, 197)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Search"
        Me.TabPage1.UseVisualStyleBackColor = true
        '
        'findCloseBtn
        '
        Me.findCloseBtn.Location = New System.Drawing.Point(395, 159)
        Me.findCloseBtn.Name = "findCloseBtn"
        Me.findCloseBtn.Size = New System.Drawing.Size(87, 23)
        Me.findCloseBtn.TabIndex = 12
        Me.findCloseBtn.Text = "Close"
        Me.findCloseBtn.UseVisualStyleBackColor = true
        '
        'searchFindAllBtn
        '
        Me.searchFindAllBtn.Location = New System.Drawing.Point(395, 67)
        Me.searchFindAllBtn.Name = "searchFindAllBtn"
        Me.searchFindAllBtn.Size = New System.Drawing.Size(87, 41)
        Me.searchFindAllBtn.TabIndex = 11
        Me.searchFindAllBtn.Text = "Find All In Current Doc"
        Me.searchFindAllBtn.UseVisualStyleBackColor = true
        '
        'FindAllInAllBtn
        '
        Me.FindAllInAllBtn.Location = New System.Drawing.Point(395, 114)
        Me.FindAllInAllBtn.Name = "FindAllInAllBtn"
        Me.FindAllInAllBtn.Size = New System.Drawing.Size(87, 39)
        Me.FindAllInAllBtn.TabIndex = 10
        Me.FindAllInAllBtn.Text = "Find All In All Opened Docs"
        Me.FindAllInAllBtn.UseVisualStyleBackColor = true
        '
        'searchCountBtn
        '
        Me.searchCountBtn.Location = New System.Drawing.Point(395, 38)
        Me.searchCountBtn.Name = "searchCountBtn"
        Me.searchCountBtn.Size = New System.Drawing.Size(87, 23)
        Me.searchCountBtn.TabIndex = 9
        Me.searchCountBtn.Text = "Count"
        Me.searchCountBtn.UseVisualStyleBackColor = true
        '
        'searchFindBtn
        '
        Me.searchFindBtn.Location = New System.Drawing.Point(395, 9)
        Me.searchFindBtn.Name = "searchFindBtn"
        Me.searchFindBtn.Size = New System.Drawing.Size(87, 23)
        Me.searchFindBtn.TabIndex = 8
        Me.searchFindBtn.Text = "Find Next"
        Me.searchFindBtn.UseVisualStyleBackColor = true
        '
        'searchFindText
        '
        Me.searchFindText.Location = New System.Drawing.Point(55, 11)
        Me.searchFindText.Name = "searchFindText"
        Me.searchFindText.Size = New System.Drawing.Size(338, 20)
        Me.searchFindText.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(1, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Find what: "
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.replaceReplaceText)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.replaceCloseBtn)
        Me.TabPage2.Controls.Add(Me.replaceReplaceAllDocsBtn)
        Me.TabPage2.Controls.Add(Me.replaceReplaceAllBtn)
        Me.TabPage2.Controls.Add(Me.replaceReplaceBtn)
        Me.TabPage2.Controls.Add(Me.replaceFindNextBtn)
        Me.TabPage2.Controls.Add(Me.replaceFindText)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(488, 197)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Replace"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'replaceReplaceText
        '
        Me.replaceReplaceText.Location = New System.Drawing.Point(46, 45)
        Me.replaceReplaceText.Name = "replaceReplaceText"
        Me.replaceReplaceText.Size = New System.Drawing.Size(347, 20)
        Me.replaceReplaceText.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(1, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Replace: "
        '
        'replaceCloseBtn
        '
        Me.replaceCloseBtn.Location = New System.Drawing.Point(395, 138)
        Me.replaceCloseBtn.Name = "replaceCloseBtn"
        Me.replaceCloseBtn.Size = New System.Drawing.Size(87, 23)
        Me.replaceCloseBtn.TabIndex = 14
        Me.replaceCloseBtn.Text = "Close"
        Me.replaceCloseBtn.UseVisualStyleBackColor = true
        '
        'replaceReplaceAllDocsBtn
        '
        Me.replaceReplaceAllDocsBtn.Location = New System.Drawing.Point(395, 96)
        Me.replaceReplaceAllDocsBtn.Name = "replaceReplaceAllDocsBtn"
        Me.replaceReplaceAllDocsBtn.Size = New System.Drawing.Size(87, 36)
        Me.replaceReplaceAllDocsBtn.TabIndex = 13
        Me.replaceReplaceAllDocsBtn.Text = "Replace All In Opened Docs"
        Me.replaceReplaceAllDocsBtn.UseVisualStyleBackColor = true
        '
        'replaceReplaceAllBtn
        '
        Me.replaceReplaceAllBtn.Location = New System.Drawing.Point(395, 67)
        Me.replaceReplaceAllBtn.Name = "replaceReplaceAllBtn"
        Me.replaceReplaceAllBtn.Size = New System.Drawing.Size(87, 23)
        Me.replaceReplaceAllBtn.TabIndex = 12
        Me.replaceReplaceAllBtn.Text = "Replace All"
        Me.replaceReplaceAllBtn.UseVisualStyleBackColor = true
        '
        'replaceReplaceBtn
        '
        Me.replaceReplaceBtn.Location = New System.Drawing.Point(395, 38)
        Me.replaceReplaceBtn.Name = "replaceReplaceBtn"
        Me.replaceReplaceBtn.Size = New System.Drawing.Size(87, 23)
        Me.replaceReplaceBtn.TabIndex = 11
        Me.replaceReplaceBtn.Text = "Replace"
        Me.replaceReplaceBtn.UseVisualStyleBackColor = true
        '
        'replaceFindNextBtn
        '
        Me.replaceFindNextBtn.Location = New System.Drawing.Point(395, 9)
        Me.replaceFindNextBtn.Name = "replaceFindNextBtn"
        Me.replaceFindNextBtn.Size = New System.Drawing.Size(87, 23)
        Me.replaceFindNextBtn.TabIndex = 10
        Me.replaceFindNextBtn.Text = "Find Next"
        Me.replaceFindNextBtn.UseVisualStyleBackColor = true
        '
        'replaceFindText
        '
        Me.replaceFindText.Location = New System.Drawing.Point(55, 11)
        Me.replaceFindText.Name = "replaceFindText"
        Me.replaceFindText.Size = New System.Drawing.Size(338, 20)
        Me.replaceFindText.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(1, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Find what: "
        '
        'matchWholeWordCheck
        '
        Me.matchWholeWordCheck.AutoSize = true
        Me.matchWholeWordCheck.Location = New System.Drawing.Point(12, 230)
        Me.matchWholeWordCheck.Name = "matchWholeWordCheck"
        Me.matchWholeWordCheck.Size = New System.Drawing.Size(117, 17)
        Me.matchWholeWordCheck.TabIndex = 1
        Me.matchWholeWordCheck.Text = "Match Whole Word"
        Me.matchWholeWordCheck.UseVisualStyleBackColor = true
        '
        'matchCaseCheck
        '
        Me.matchCaseCheck.AutoSize = true
        Me.matchCaseCheck.Location = New System.Drawing.Point(12, 253)
        Me.matchCaseCheck.Name = "matchCaseCheck"
        Me.matchCaseCheck.Size = New System.Drawing.Size(82, 17)
        Me.matchCaseCheck.TabIndex = 2
        Me.matchCaseCheck.Text = "Match Case"
        Me.matchCaseCheck.UseVisualStyleBackColor = true
        '
        'inSelCheck
        '
        Me.inSelCheck.AutoSize = true
        Me.inSelCheck.Location = New System.Drawing.Point(12, 276)
        Me.inSelCheck.Name = "inSelCheck"
        Me.inSelCheck.Size = New System.Drawing.Size(82, 17)
        Me.inSelCheck.TabIndex = 3
        Me.inSelCheck.Text = "In Selection"
        Me.inSelCheck.UseVisualStyleBackColor = true
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.searchRegexRadio)
        Me.GroupBox1.Controls.Add(Me.searchNormalRadio)
        Me.GroupBox1.Location = New System.Drawing.Point(135, 230)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 63)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Search Mode"
        '
        'searchRegexRadio
        '
        Me.searchRegexRadio.AutoSize = true
        Me.searchRegexRadio.Location = New System.Drawing.Point(6, 40)
        Me.searchRegexRadio.Name = "searchRegexRadio"
        Me.searchRegexRadio.Size = New System.Drawing.Size(117, 17)
        Me.searchRegexRadio.TabIndex = 1
        Me.searchRegexRadio.TabStop = true
        Me.searchRegexRadio.Text = "Regular Expression"
        Me.searchRegexRadio.UseVisualStyleBackColor = true
        '
        'searchNormalRadio
        '
        Me.searchNormalRadio.AutoSize = true
        Me.searchNormalRadio.Checked = true
        Me.searchNormalRadio.Location = New System.Drawing.Point(6, 19)
        Me.searchNormalRadio.Name = "searchNormalRadio"
        Me.searchNormalRadio.Size = New System.Drawing.Size(58, 17)
        Me.searchNormalRadio.TabIndex = 0
        Me.searchNormalRadio.TabStop = true
        Me.searchNormalRadio.Text = "Normal"
        Me.searchNormalRadio.UseVisualStyleBackColor = true
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.directionDownRadio)
        Me.GroupBox2.Controls.Add(Me.directionUpRadio)
        Me.GroupBox2.Location = New System.Drawing.Point(400, 230)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(93, 63)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Direction"
        '
        'directionDownRadio
        '
        Me.directionDownRadio.AutoSize = true
        Me.directionDownRadio.Checked = true
        Me.directionDownRadio.Location = New System.Drawing.Point(6, 40)
        Me.directionDownRadio.Name = "directionDownRadio"
        Me.directionDownRadio.Size = New System.Drawing.Size(52, 17)
        Me.directionDownRadio.TabIndex = 1
        Me.directionDownRadio.TabStop = true
        Me.directionDownRadio.Text = "Down"
        Me.directionDownRadio.UseVisualStyleBackColor = true
        '
        'directionUpRadio
        '
        Me.directionUpRadio.AutoSize = true
        Me.directionUpRadio.Location = New System.Drawing.Point(6, 19)
        Me.directionUpRadio.Name = "directionUpRadio"
        Me.directionUpRadio.Size = New System.Drawing.Size(38, 17)
        Me.directionUpRadio.TabIndex = 0
        Me.directionUpRadio.TabStop = true
        Me.directionUpRadio.Text = "Up"
        Me.directionUpRadio.UseVisualStyleBackColor = true
        '
        'SearchReplaceForm
        '
        Me.AcceptButton = Me.searchFindBtn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 304)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.inSelCheck)
        Me.Controls.Add(Me.matchCaseCheck)
        Me.Controls.Add(Me.matchWholeWordCheck)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "SearchReplaceForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search & Replace"
        Me.TopMost = true
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents directionDownRadio As RadioButton
    Friend WithEvents directionUpRadio As RadioButton
    Friend WithEvents findCloseBtn As Button
    Friend WithEvents searchFindAllBtn As Button
    Friend WithEvents FindAllInAllBtn As Button
    Friend WithEvents searchCountBtn As Button
    Friend WithEvents searchFindBtn As Button
    Friend WithEvents searchFindText As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents replaceFindText As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents replaceFindNextBtn As Button
    Friend WithEvents replaceReplaceAllDocsBtn As Button
    Friend WithEvents replaceReplaceAllBtn As Button
    Friend WithEvents replaceReplaceBtn As Button
    Friend WithEvents replaceCloseBtn As Button
    Friend WithEvents replaceReplaceText As TextBox
    Friend WithEvents Label3 As Label
End Class
