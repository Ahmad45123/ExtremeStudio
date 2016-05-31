Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports ExtremeCore
Imports ExtremeStudio.My.Resources
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization

Public Class SettingsForm

    Dim _configDirPath As String = Nothing

    'A function for external execution.
    Public Sub ReloadInfoAll()
        If IsGlobal Then serverCFGTabPage.Enabled = False Else serverCFGTabPage.Enabled = True

        CheckPath()

        LoadColors()
        LoadCompiler()
        LoadServerCfg()
    End Sub

    <Localizable(False)>
    Private Sub CheckPath()
        'Just make sure the _configDirPath is not null.
        If Directory.Exists(_configDirPath) = False Then
            _configDirPath = MainForm.CurrentProject.ProjectPath + "/configs/"
        End If
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadInfoAll()
    End Sub

    Dim _isGlobal As Boolean
    Public Property IsGlobal As Boolean
        Set
            If Value = True Then
                _isGlobal = True
                _configDirPath = MainForm.ApplicationFiles + "/configs/"
                Me.Text = translations.SettingsForm_IsGlobal_SettingsGLOBAL
                ReloadInfoAll()
            Else
                _isGlobal = False
                _configDirPath = MainForm.CurrentProject.ProjectPath + "/configs/"
                Me.Text = translations.SettingsForm_IsGlobal_SettingsPROJECT
                ReloadInfoAll()
            End If
        End Set
        Get
            Return _isGlobal
        End Get
    End Property

#Region "Colorizer Stuff"
    'The main colors info: 
    Public ColorsInfo As New SyntaxInfo

    'This is to avoid to Reload the colors when its already loaded and no mods are done.. 
    Public ReadOnly Property HasColorsBeenLoadedBefore As Boolean
        Get
            Return _hasColorsFinished
        End Get
    End Property
    Dim _hasColorsFinished As Boolean = False

    Public Event OnColorsSettingsChange()

    Private Sub SettingsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim configHandler As New ConfigsHandler(_configDirPath + "/themeInfo.json")
        configHandler("Colors") = ColorsInfo
        configHandler.Save()
    End Sub

    Private Sub colorsSettings_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles colorsSettings.PropertyValueChanged
        RaiseEvent OnColorsSettingsChange()
    End Sub

    Private Sub exportBtn_Click(sender As Object, e As EventArgs) Handles exportBtn.Click
        Dim dlg As New SaveFileDialog()
        dlg.Title = translations.SettingsForm_exportBtn_Click_OpenFileDialogTitle
        dlg.Filter = "ExtremeStudio Theme (*.estheme) |*.estheme"

        If dlg.ShowDialog() = DialogResult.OK
            Dim configHandler As New ConfigsHandler(dlg.FileName)
            configHandler("Colors") = ColorsInfo
            configHandler.Save()
            MsgBox(translations.SettingsForm_exportBtn_Click_ExporteSuccess, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub importBtn_Click(sender As Object, e As EventArgs) Handles importBtn.Click
        Dim dlg As New OpenFileDialog()
        dlg.Title = translations.SettingsForm_importBtn_Click_OpenFileDialogTitle
        dlg.Filter = "ExtremeStudio Theme (*.estheme) |*.estheme"

        If dlg.ShowDialog() = DialogResult.OK
            Dim configHandler As New ConfigsHandler(dlg.FileName)
            ColorsInfo = configHandler("Colors").ToObject(Of SyntaxInfo)
            colorsSettings.SelectedObject = ColorsInfo
        End If
    End Sub

    Private Sub resetBtn_Click(sender As Object, e As EventArgs) Handles resetBtn.Click
        If MsgBox(translations.SettingsForm_resetBtn_Click_ResetDefaultSettings, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) Then
            'Delete Old: 
            My.Computer.FileSystem.DeleteFile(_configDirPath + "/themeInfo.json")

            'Get New
            Dim configHandler As New ConfigsHandler(_configDirPath + "/themeInfo.json", My.Resources.defaultThemeInfo)
            ColorsInfo = configHandler("Colors").ToObject(Of SyntaxInfo)
            colorsSettings.SelectedObject = ColorsInfo
        End If
    End Sub

    <Localizable(False)>
    Private Sub LoadColors()
        CheckPath()

        Dim configHandler As New ConfigsHandler(_configDirPath + "/themeInfo.json", My.Resources.defaultThemeInfo)
        ColorsInfo = configHandler("Colors").ToObject(Of SyntaxInfo)
        colorsSettings.SelectedObject = ColorsInfo
        If _hasColorsFinished = False Then _hasColorsFinished = True
        RaiseEvent OnColorsSettingsChange()
    End Sub
#End Region

#Region "Compiler Stuff"

    Private Sub reportGenCheck_CheckedChanged(sender As Object, e As EventArgs) Handles reportGenCheck.CheckedChanged
        reportGenDirText.Enabled = reportGenCheck.Checked
    End Sub

    <Localizable(False)>
    Private Sub FormClosingCompiler(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        Dim configHandler As New ConfigsHandler(_configDirPath + "/compiler.json")
        configHandler("activeDir") = activeDirText.Text
        configHandler("includesDir") = includesDirText.Text
        configHandler("ouputDir") = ouputDirText.Text
        configHandler("reportGenCheck") = reportGenCheck.Checked
        configHandler("reportGenDir") = reportGenDirText.Text
        configHandler("debugLevel") = debugLevelUpDown.Value
        configHandler("optiLevel") = optiLevelUpDown.Value
        configHandler("tabSize") = tabSizeUpDown.Value
        configHandler("skipLines") = skipLinesUpDown.Value
        configHandler("parentheses") = parenthesesCheck.Checked
        configHandler("semicolon") = semiColonCheck.Checked
        configHandler("customArgs") = customArgsText.Text
        configHandler.Save()
    End Sub

    <Localizable(False)>
    Private Sub LoadCompiler()
        CheckPath()

        'Basically, If its not been found, We will set the boxes with the default ourselves.
        Try
            Dim configHandler As New ConfigsHandler(_configDirPath + "/compiler.json")
            activeDirText.Text = configHandler("activeDir")
            includesDirText.Text = configHandler("includesDir")
            ouputDirText.Text = configHandler("ouputDir")
            reportGenCheck.Checked = configHandler("reportGenCheck")
            reportGenDirText.Text = configHandler("reportGenDir")
            debugLevelUpDown.Value = configHandler("debugLevel")
            Try 'For version 1.0.0.1 when the default was 2.
            optiLevelUpDown.Value = configHandler("optiLevel")
            Catch ex As ArgumentOutOfRangeException
                optiLevelUpDown.Value = 1
            End Try
            tabSizeUpDown.Value = configHandler("tabSize")
            skipLinesUpDown.Value = configHandler("skipLines")
            parenthesesCheck.Checked = configHandler("parentheses")
            semiColonCheck.Checked = configHandler("semicolon")
            customArgsText.Text = configHandler("customArgs")
        Catch ex as KeyNotFoundException
            ResetDefaultCompiler(Me, Nothing)
            FormClosingCompiler(Me, Nothing)
        End Try
    End Sub

    Private Sub ResetDefaultCompiler(sender As Object, e As EventArgs) Handles Button1.Click
            activeDirText.Text = ""
            includesDirText.Text = ""
            ouputDirText.Text = ""
            reportGenCheck.Checked = False
            reportGenDirText.Text = ""
            debugLevelUpDown.Value = 0.0
            optiLevelUpDown.Value = 1.0
            tabSizeUpDown.Value = 4.0
            skipLinesUpDown.Value = 0.0
            parenthesesCheck.Checked = True
            semiColonCheck.Checked = True
            customArgsText.Text = ""
    End Sub

    <Localizable(False)>
    Public Function GetCompilerArgs()
        LoadCompiler()

        Dim allArgs As New StringBuilder
        If activeDirText.Text <> "" Then
            allArgs.Append(Space(1) + "-D=" + """" + activeDirText.Text + """")
        End If
        If includesDirText.Text <> "" Then
            allArgs.Append(Space(1) + "-i=" + """" + includesDirText.Text + """")
        End If
        If ouputDirText.Text <> "" Then
            allArgs.Append(Space(1) + "-o=" + """" + ouputDirText.Text + """")
        End If
        If reportGenCheck.Checked Then
            allArgs.Append(Space(1) + "-r=" + """" + reportGenDirText.Text + """")
        End If
        allArgs.Append(Space(1) + "-d=" + debugLevelUpDown.Text)
        allArgs.Append(Space(1) + "-O=" + optiLevelUpDown.Text)
        allArgs.Append(Space(1) + "-t=" + tabSizeUpDown.Text)
        allArgs.Append(Space(1) + "-s=" + skipLinesUpDown.Text)
        If parenthesesCheck.Checked Then
            allArgs.Append(Space(1) + "-(+")
        Else
            allArgs.Append(Space(1) + "-(-")
        End If
        If semiColonCheck.Checked Then
            allArgs.Append(Space(1) + "-;+")
        Else
            allArgs.Append(Space(1) + "-;-")
        End If
        allArgs.Append(Space(1) + customArgsText.Text)

        Return allArgs.ToString()
    End Function

#End Region

#Region "Server.CFG"

    <Localizable(False)>
    Sub LoadServerCfg()
        serverCfgGrid.Rows.Clear()

        Dim textLine As String
        If IO.File.Exists(Mainform.CurrentProject.projectPath + "/server.cfg") = True Then
            Dim objReader As New System.IO.StreamReader(Mainform.CurrentProject.projectPath + "/server.cfg")
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                Dim values() As String = TextLine.Split(" ", 2, StringSplitOptions.None)
                If values.Length = 2 Then
                    If values(0).Trim = "" And values(1).Trim = "" Then Continue Do
                    serverCfgGrid.Rows.Add(New Object() {values(0).Trim, values(1).Trim})
                End If
            Loop

            objReader.Close()
        End If
    End Sub

    <Localizable(False)>
    Private Sub ServerCfgFormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If IsGlobal Then Exit Sub

        Dim allStr As New StringBuilder()
        For Each row As DataGridViewRow In serverCfgGrid.Rows
            allStr.Append(row.Cells(0).Value + " " + row.Cells(1).Value + vbCrLf)
        Next
        My.Computer.FileSystem.WriteAllText(Mainform.CurrentProject.projectPath + "/server.cfg", allStr.ToString(), False)
    End Sub

    Private Sub ResetLangBtn_Click(sender As Object, e As EventArgs) Handles ResetLangBtn.Click
        If File.Exists(MainForm.ApplicationFiles + "\configs\lang.cfg") Then 
            File.Delete(MainForm.ApplicationFiles + "\configs\lang.cfg")
            MsgBox(translations.SettingsForm_ResetLangBtn_Click_LocalizationSettingsDeleted)
        End If
    End Sub
#End Region
End Class

#Region "Syntax Colorizing Stuff"
#Region "NoTypeConverterJsonConverter"
Public Class NoTypeConverterJsonConverter(Of T)
    Inherits JsonConverter
    Shared ReadOnly resolver As IContractResolver = New NoTypeConverterContractResolver()

    Private Class NoTypeConverterContractResolver
        Inherits DefaultContractResolver
        Protected Overrides Function CreateContract(objectType As Type) As JsonContract
            If GetType(T).IsAssignableFrom(objectType) Then
                Dim contract = Me.CreateObjectContract(objectType)
                contract.Converter = Nothing
                ' Also null out the converter to prevent infinite recursion.
                Return contract
            End If
            Return MyBase.CreateContract(objectType)
        End Function
    End Class

    Public Overrides Function CanConvert(objectType As Type) As Boolean
        Return GetType(T).IsAssignableFrom(objectType)
    End Function

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        Return JsonSerializer.CreateDefault(New JsonSerializerSettings() With {.ContractResolver = resolver}).Deserialize(reader, objectType)
    End Function

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        JsonSerializer.CreateDefault(New JsonSerializerSettings() With {.ContractResolver = resolver}).Serialize(writer, value)
    End Sub
End Class
#End Region
<TypeConverter(GetType(ExpandableObjectConverter))>
<JsonConverter(GetType(NoTypeConverterJsonConverter(of StyleItem)))>
Public Class StyleItem
    Public Property Font As Font = Nothing
    Public Property ForeColor As Color = Color.Transparent
    Public Property BackColor As Color = Color.Transparent
End Class
Public Class SyntaxInfo
    <DisplayName("Default"), Category("Language Syntax Highlighting")>
    Public Property SDefault As New StyleItem()
    <DisplayName("Integers"), Category("Language Syntax Highlighting")>
    Public Property SInteger As New StyleItem()
    <DisplayName("Strings"), Category("Language Syntax Highlighting")>
    Public Property SString As New StyleItem()
    <DisplayName("Symbols"), Category("Language Syntax Highlighting")>
    Public Property SSymbols As New StyleItem()
    <DisplayName("SingleLine Comments"), Category("Language Syntax Highlighting")>
    Public Property SSlComments As New StyleItem()
    <DisplayName("MultiLine Comments"), Category("Language Syntax Highlighting")>
    Public Property SMlComments As New StyleItem()
    <DisplayName("PawnDoc"), Category("Language Syntax Highlighting")>
    Public Property SPawnDoc As New StyleItem()
    <DisplayName("Pawn PreProcessor"), Category("Language Syntax Highlighting")>
    Public Property SPawnPre As New StyleItem()
    <DisplayName("Pawn KeyWords"), Category("Language Syntax Highlighting")>
    Public Property SPawnKeys As New StyleItem()

    <DisplayName("Functions"), Category("WordSets Syntax Highlighting")>
    Public Property SFunctions As New StyleItem()
    <DisplayName("Publics"), Category("WordSets Syntax Highlighting")>
    Public Property SPublics As New StyleItem()
    <DisplayName("Stocks"), Category("WordSets Syntax Highlighting")>
    Public Property SStocks As New StyleItem()
    <DisplayName("Natives"), Category("WordSets Syntax Highlighting")>
    Public Property SNatives As New StyleItem()
    <DisplayName("Defines"), Category("WordSets Syntax Highlighting")>
    Public Property SDefines As New StyleItem()
    <DisplayName("Macros"), Category("WordSets Syntax Highlighting")>
    Public Property SMacros As New StyleItem()
    <DisplayName("Enums"), Category("WordSets Syntax Highlighting")>
    Public Property SEnums As New StyleItem()
    <DisplayName("Global Variables"), Category("WordSets Syntax Highlighting")>
    Public Property SGlobalVars As New StyleItem()
End Class
#End Region