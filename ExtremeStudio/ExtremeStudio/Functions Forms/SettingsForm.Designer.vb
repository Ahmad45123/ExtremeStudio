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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FontDialog = New System.Windows.Forms.FontDialog()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.caretColor = New ExtremeCore.ColorChoose()
        Me.lineNumberColor = New ExtremeCore.ColorChoose()
        Me.backgroundColor = New ExtremeCore.ColorChoose()
        Me.preproccessColor = New ExtremeCore.ColorChoose()
        Me.operatorColor = New ExtremeCore.ColorChoose()
        Me.stringColor = New ExtremeCore.ColorChoose()
        Me.definesColor = New ExtremeCore.ColorChoose()
        Me.functionsColor = New ExtremeCore.ColorChoose()
        Me.pawnColor = New ExtremeCore.ColorChoose()
        Me.commentColor = New ExtremeCore.ColorChoose()
        Me.numberColor = New ExtremeCore.ColorChoose()
        Me.defaultColor = New ExtremeCore.ColorChoose()
        Me.pawndocColor = New ExtremeCore.ColorChoose()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(642, 267)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.caretColor)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.lineNumberColor)
        Me.TabPage1.Controls.Add(Me.backgroundColor)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.preproccessColor)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.operatorColor)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.stringColor)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.definesColor)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.functionsColor)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.pawnColor)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.commentColor)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.numberColor)
        Me.TabPage1.Controls.Add(Me.defaultColor)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.pawndocColor)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(634, 241)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Theme And Colors"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(50, 180)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Change"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 185)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Font: "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(404, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Preprocesser: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Operator: "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(404, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Strings: "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Defines, Enums And Global Vars: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(404, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Functions And Natives: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 13)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Default PAWN Keywords: "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(404, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Comment: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Default: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(404, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Numbers: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "PawnDoc: "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(248, 13)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Help Note: Click on the color to change it."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(404, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 13)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Background Color: "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 219)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(105, 13)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Line Numbers Color: "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(404, 219)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Caret Color: "
        '
        'caretColor
        '
        Me.caretColor.Color = System.Drawing.Color.Black
        Me.caretColor.Location = New System.Drawing.Point(475, 219)
        Me.caretColor.Name = "caretColor"
        Me.caretColor.Size = New System.Drawing.Size(98, 13)
        Me.caretColor.TabIndex = 40
        '
        'lineNumberColor
        '
        Me.lineNumberColor.Color = System.Drawing.Color.Black
        Me.lineNumberColor.Location = New System.Drawing.Point(121, 219)
        Me.lineNumberColor.Name = "lineNumberColor"
        Me.lineNumberColor.Size = New System.Drawing.Size(98, 13)
        Me.lineNumberColor.TabIndex = 37
        '
        'backgroundColor
        '
        Me.backgroundColor.Color = System.Drawing.Color.Black
        Me.backgroundColor.Location = New System.Drawing.Point(508, 185)
        Me.backgroundColor.Name = "backgroundColor"
        Me.backgroundColor.Size = New System.Drawing.Size(98, 13)
        Me.backgroundColor.TabIndex = 36
        '
        'preproccessColor
        '
        Me.preproccessColor.Color = System.Drawing.Color.Black
        Me.preproccessColor.Location = New System.Drawing.Point(485, 152)
        Me.preproccessColor.Name = "preproccessColor"
        Me.preproccessColor.Size = New System.Drawing.Size(98, 13)
        Me.preproccessColor.TabIndex = 31
        '
        'operatorColor
        '
        Me.operatorColor.Color = System.Drawing.Color.Black
        Me.operatorColor.Location = New System.Drawing.Point(70, 152)
        Me.operatorColor.Name = "operatorColor"
        Me.operatorColor.Size = New System.Drawing.Size(98, 13)
        Me.operatorColor.TabIndex = 29
        '
        'stringColor
        '
        Me.stringColor.Color = System.Drawing.Color.Black
        Me.stringColor.Location = New System.Drawing.Point(455, 122)
        Me.stringColor.Name = "stringColor"
        Me.stringColor.Size = New System.Drawing.Size(98, 13)
        Me.stringColor.TabIndex = 27
        '
        'definesColor
        '
        Me.definesColor.Color = System.Drawing.Color.Black
        Me.definesColor.Location = New System.Drawing.Point(182, 122)
        Me.definesColor.Name = "definesColor"
        Me.definesColor.Size = New System.Drawing.Size(98, 13)
        Me.definesColor.TabIndex = 25
        '
        'functionsColor
        '
        Me.functionsColor.Color = System.Drawing.Color.Black
        Me.functionsColor.Location = New System.Drawing.Point(530, 93)
        Me.functionsColor.Name = "functionsColor"
        Me.functionsColor.Size = New System.Drawing.Size(98, 13)
        Me.functionsColor.TabIndex = 23
        '
        'pawnColor
        '
        Me.pawnColor.Color = System.Drawing.Color.Black
        Me.pawnColor.Location = New System.Drawing.Point(148, 93)
        Me.pawnColor.Name = "pawnColor"
        Me.pawnColor.Size = New System.Drawing.Size(98, 13)
        Me.pawnColor.TabIndex = 21
        '
        'commentColor
        '
        Me.commentColor.Color = System.Drawing.Color.Black
        Me.commentColor.Location = New System.Drawing.Point(467, 38)
        Me.commentColor.Name = "commentColor"
        Me.commentColor.Size = New System.Drawing.Size(97, 13)
        Me.commentColor.TabIndex = 19
        '
        'numberColor
        '
        Me.numberColor.Color = System.Drawing.Color.Black
        Me.numberColor.Location = New System.Drawing.Point(467, 68)
        Me.numberColor.Name = "numberColor"
        Me.numberColor.Size = New System.Drawing.Size(97, 13)
        Me.numberColor.TabIndex = 5
        '
        'defaultColor
        '
        Me.defaultColor.Color = System.Drawing.Color.Black
        Me.defaultColor.Location = New System.Drawing.Point(63, 38)
        Me.defaultColor.Name = "defaultColor"
        Me.defaultColor.Size = New System.Drawing.Size(97, 13)
        Me.defaultColor.TabIndex = 1
        '
        'pawndocColor
        '
        Me.pawndocColor.Color = System.Drawing.Color.Black
        Me.pawndocColor.Location = New System.Drawing.Point(73, 68)
        Me.pawndocColor.Name = "pawndocColor"
        Me.pawndocColor.Size = New System.Drawing.Size(97, 13)
        Me.pawndocColor.TabIndex = 3
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 267)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "SettingsForm"
        Me.Text = "Settings"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents TabControl1 As TabControl
    Public WithEvents TabPage1 As TabPage
    Public WithEvents Label1 As Label
    Public WithEvents defaultColor As ExtremeCore.ColorChoose
    Public WithEvents commentColor As ExtremeCore.ColorChoose
    Public WithEvents Label10 As Label
    Public WithEvents numberColor As ExtremeCore.ColorChoose
    Public WithEvents Label3 As Label
    Public WithEvents pawndocColor As ExtremeCore.ColorChoose
    Public WithEvents Label2 As Label
    Public WithEvents Label4 As Label
    Public WithEvents pawnColor As ExtremeCore.ColorChoose
    Public WithEvents functionsColor As ExtremeCore.ColorChoose
    Public WithEvents Label5 As Label
    Public WithEvents definesColor As ExtremeCore.ColorChoose
    Public WithEvents Label6 As Label
    Public WithEvents stringColor As ExtremeCore.ColorChoose
    Public WithEvents Label7 As Label
    Public WithEvents operatorColor As ExtremeCore.ColorChoose
    Public WithEvents Label8 As Label
    Public WithEvents preproccessColor As ExtremeCore.ColorChoose
    Public WithEvents Label9 As Label
    Public WithEvents Button1 As Button
    Public WithEvents Label11 As Label
    Public WithEvents FontDialog As FontDialog
    Friend WithEvents Label12 As Label
    Public WithEvents backgroundColor As ExtremeCore.ColorChoose
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lineNumberColor As ExtremeCore.ColorChoose
    Friend WithEvents caretColor As ExtremeCore.ColorChoose
    Friend WithEvents Label15 As Label
End Class
