<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.resetBtn = New System.Windows.Forms.Button()
        Me.importBtn = New System.Windows.Forms.Button()
        Me.exportBtn = New System.Windows.Forms.Button()
        Me.colorsSettings = New System.Windows.Forms.PropertyGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.TabPage2.SuspendLayout
        CType(Me.NumericUpDown4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.NumericUpDown3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.NumericUpDown2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(367, 459)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.resetBtn)
        Me.TabPage1.Controls.Add(Me.importBtn)
        Me.TabPage1.Controls.Add(Me.exportBtn)
        Me.TabPage1.Controls.Add(Me.colorsSettings)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(359, 433)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Theme And Colors"
        '
        'resetBtn
        '
        Me.resetBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.resetBtn.Location = New System.Drawing.Point(268, 404)
        Me.resetBtn.Name = "resetBtn"
        Me.resetBtn.Size = New System.Drawing.Size(88, 23)
        Me.resetBtn.TabIndex = 44
        Me.resetBtn.Text = "Reset Default"
        Me.resetBtn.UseVisualStyleBackColor = true
        '
        'importBtn
        '
        Me.importBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.importBtn.Location = New System.Drawing.Point(87, 404)
        Me.importBtn.Name = "importBtn"
        Me.importBtn.Size = New System.Drawing.Size(75, 23)
        Me.importBtn.TabIndex = 43
        Me.importBtn.Text = "Import"
        Me.importBtn.UseVisualStyleBackColor = true
        '
        'exportBtn
        '
        Me.exportBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.exportBtn.Location = New System.Drawing.Point(6, 404)
        Me.exportBtn.Name = "exportBtn"
        Me.exportBtn.Size = New System.Drawing.Size(75, 23)
        Me.exportBtn.TabIndex = 42
        Me.exportBtn.Text = "Export"
        Me.exportBtn.UseVisualStyleBackColor = true
        '
        'colorsSettings
        '
        Me.colorsSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.colorsSettings.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.colorsSettings.Location = New System.Drawing.Point(3, 3)
        Me.colorsSettings.Name = "colorsSettings"
        Me.colorsSettings.Size = New System.Drawing.Size(353, 395)
        Me.colorsSettings.TabIndex = 41
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.TextBox4)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.CheckBox4)
        Me.TabPage2.Controls.Add(Me.CheckBox3)
        Me.TabPage2.Controls.Add(Me.CheckBox2)
        Me.TabPage2.Controls.Add(Me.NumericUpDown4)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.NumericUpDown3)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.NumericUpDown2)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.NumericUpDown1)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.TextBox6)
        Me.TabPage2.Controls.Add(Me.CheckBox1)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(359, 406)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Compiler"
        Me.TabPage2.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 410)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 23)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Reset Defaults"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(11, 354)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(340, 20)
        Me.TextBox4.TabIndex = 25
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(3, 338)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Extra Custom Args: "
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = true
        Me.CheckBox4.Location = New System.Drawing.Point(11, 263)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(166, 17)
        Me.CheckBox4.TabIndex = 23
        Me.CheckBox4.Text = "Functions need parentheses."
        Me.CheckBox4.UseVisualStyleBackColor = true
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = true
        Me.CheckBox3.Location = New System.Drawing.Point(11, 286)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(182, 17)
        Me.CheckBox3.TabIndex = 22
        Me.CheckBox3.Text = "Lines must end with a semicolon."
        Me.CheckBox3.UseVisualStyleBackColor = true
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = true
        Me.CheckBox2.Location = New System.Drawing.Point(11, 240)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(138, 17)
        Me.CheckBox2.TabIndex = 21
        Me.CheckBox2.Text = "Generate Assembly File"
        Me.CheckBox2.UseVisualStyleBackColor = true
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Location = New System.Drawing.Point(130, 195)
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(221, 20)
        Me.NumericUpDown4.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(8, 197)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Number of lines to skip: "
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.Location = New System.Drawing.Point(68, 169)
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(283, 20)
        Me.NumericUpDown3.TabIndex = 18
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(8, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Tab Size: "
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(107, 143)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(244, 20)
        Me.NumericUpDown2.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(8, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Optimization Level: "
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(107, 117)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(244, 20)
        Me.NumericUpDown1.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(8, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Debugging Level: "
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(130, 91)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(221, 20)
        Me.TextBox6.TabIndex = 12
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = true
        Me.CheckBox1.Location = New System.Drawing.Point(109, 94)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.UseVisualStyleBackColor = true
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(8, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Report Generation: "
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(74, 62)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(277, 20)
        Me.TextBox3.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(8, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Output Dir: "
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(74, 36)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(277, 20)
        Me.TextBox2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(8, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Includes Dir: "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(74, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(277, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Active Dir: "
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 459)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "SettingsForm"
        Me.Text = "Settings [Project]"
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        CType(Me.NumericUpDown4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.NumericUpDown3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.NumericUpDown2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Public WithEvents TabControl1 As TabControl
    Public WithEvents TabPage1 As TabPage
    Friend WithEvents colorsSettings As PropertyGrid
    Friend WithEvents exportBtn As Button
    Friend WithEvents resetBtn As Button
    Friend WithEvents importBtn As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
End Class
