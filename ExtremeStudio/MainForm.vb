Imports System.ComponentModel
Imports System.IO
Imports WeifenLuo.WinFormsUI.Docking
Imports ScintillaNET
Imports System.Text
Imports System.Environment
Imports System.Text.RegularExpressions
Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports ExtremeCore
Imports ExtremeStudio.My.Resources

Public Class MainForm

    Public ReadOnly ApplicationFiles As String = Environment.GetFolderPath(SpecialFolder.ApplicationData) + "/ExtremeStudio"

#Region "Properties"
    Public ReadOnly Property CurrentScintilla As Scintilla
        Get
            If MainDock.ActiveDocument Is Nothing Then Return Nothing
            Return DirectCast(MainDock.ActiveDocument.DockHandler.Form.Controls("Editor"), Scintilla)
        End Get
    End Property
    Public ReadOnly Property CurrentEditor As EditorDock
        Get
            If CurrentScintilla Is Nothing Then Return Nothing
            Return DirectCast(CurrentScintilla.Parent, EditorDock)
        End Get
    End Property
#End Region
#Region "Functions"
    <Localizable(False)>
    Public Sub OpenFile(ByVal targetPath As String, Optional isExternal As Boolean = False)
        'We gotta make sure there is no file opened with that path first.
        For Each doc In MainDock.Documents
            If doc.DockHandler.Form.Controls("Editor").Tag = targetPath Then
                doc.DockHandler.Activate()
                Exit Sub
            End If
        Next

        Dim newEditor As New EditorDock
        newEditor.Text = Path.GetFileName(targetPath) + IIf(isExternal, " [EXTERNAL]", "")
        newEditor.Editor.Tag = targetPath
        newEditor.Editor.Text = My.Computer.FileSystem.ReadAllText(targetPath)
        newEditor.Show(MainDock)
        newEditor.Editor.SetSavePoint() 'Set that all data has been saved.
    End Sub
    Public Sub SaveFile(editor As Scintilla)
        File.WriteAllText(editor.Tag, editor.Text, New UTF8Encoding(False))
        editor.SetSavePoint() 'Set as un-modified.
    End Sub
#End Region
#Region "DocksSavingLoading"
    Dim _mDeserlise As DeserializeDockContent
    Private Function GetContentFromPersistString(ByVal persistString As String) As IDockContent
        If persistString = GetType(ProjExplorerDock).ToString Then
            Return ProjExplorerDock
        ElseIf persistString = GetType(ObjectExplorerDock).ToString Then
            Return ObjectExplorerDock
        ElseIf persistString = GetType(ErrorsDock).ToString Then
            Return ErrorsDock
        End If
        Return Nothing
    End Function

    Private Sub DockSavingLoading_Mainform_Load(sendr As Object, e As EventArgs) Handles MyBase.Load
        'Setup DockPanelSuite theme.
        'Has to be here so its applied before anything.
        Dim theme As New VS2012LightTheme
        MainDock.Theme = theme

        Try
            _mDeserlise = New DeserializeDockContent(AddressOf GetContentFromPersistString)
            Try
                MainDock.LoadFromXml(ApplicationFiles + "/configs/docksInfo.xml", _mDeserlise)
            Catch ex As Exception
                'Do nothing if there isn't any file.
                'Even though, A default one will be included.
            End Try
        Catch ex As Exception
            MsgBox("Error Loading Docks: " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MainDock.SaveAsXml(ApplicationFiles + "/configs/docksInfo.xml")
    End Sub
#End Region

#Region "StatusStripStuff"
    Public Sub ShowStatus(textToShow As String, msInterval As Integer, isBeep As Boolean)
        statusLabel.Text = textToShow
        If isBeep Then Beep()

        If msInterval <> -1 Then
            statusStripTimer.Interval = msInterval
            statusStripTimer.Stop() : statusStripTimer.Start()
        End If
    End Sub
    Private Sub statusStripTimer_Tick(sender As Object, e As EventArgs) Handles statusStripTimer.Tick
        statusStripTimer.Stop()
        statusLabel.Text = "Idle"
    End Sub
#End Region

    'Global variables that are used through the whole program: 
    Public CurrentProject As New CurrentProjectClass

    <Localizable(False)>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "ExtremeStudio - " + CurrentProject.ProjectName
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Save all info.
        CurrentProject.SaveInfo()

        If _isClosedProgrammitcly = False Then
            Application.Exit()
        End If
    End Sub

#Region "View Codes"
    Private Sub ProjectExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles prjExplrerView.Click
        If ProjExplorerDock.Visible = False Then
            ProjExplorerDock.Visible = True
            ProjExplorerDock.Show(MainDock)
        Else
            ProjExplorerDock.Close()
            ProjExplorerDock.Visible = False
        End If
    End Sub
    Private Sub ObjectExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles objExplorerView.Click
        If ObjectExplorerDock.Visible = False Then
            ObjectExplorerDock.Visible = True
            ObjectExplorerDock.Show(MainDock)
        Else
            ObjectExplorerDock.Close()
            ObjectExplorerDock.Visible = False
        End If
    End Sub
    Private Sub ErrorsAndWarningsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles errorsWarningsView.Click
        If ErrorsDock.Visible = False Then
            ErrorsDock.Visible = True
            ErrorsDock.Show(MainDock)
        Else
            ErrorsDock.Close()
            ErrorsDock.Visible = False
        End If
    End Sub
#End Region

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles saveFileButton.Click
        If CurrentScintilla Is Nothing Then Exit Sub
        SaveFile(CurrentScintilla)
    End Sub

    <Localizable(False)>
    Public Sub SaveAllFiles(sender As Object, e As EventArgs) Handles saveAllButton.Click
        For Each Dock As DockContent In MainDock.Documents
            SaveFile(Dock.Controls("Editor"))
        Next
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles includesButton.Click
        Dim frm As New IncludesForm
        frm.Show()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles pluginsButton.Click
        Dim frm As New PluginsForm
        frm.Show()
    End Sub

    Private Sub MainDock_ActiveDocumentChanged(sender As Object, e As EventArgs) Handles MainDock.ActiveDocumentChanged
        'Update.
        If ObjectExplorerDock.Visible And CurrentEditor IsNot Nothing Then
            ObjectExplorerDock.RefreshTreeView(CurrentEditor.CodeParts)
        End If
    End Sub

    Private _isClosedProgrammitcly As Boolean = False
    Private Sub closeProjectButton_Click(sender As Object, e As EventArgs) Handles closeProjectButton.Click
        'Save
        CurrentProject.SaveInfo()

        'Then close ourself.
        _isClosedProgrammitcly = True : Close()

        'Open the form
        Dim str As New StartupForm
        str.IsFirst = False
        str.Show()
    End Sub

    Private Sub cutButton_Click(sender As Object, e As EventArgs) Handles cutButton.Click
        CurrentScintilla.Cut()
    End Sub

    Private Sub copyButton_Click(sender As Object, e As EventArgs) Handles copyButton.Click
        CurrentScintilla.Copy()
    End Sub

    Private Sub pasteButton_Click(sender As Object, e As EventArgs) Handles pasteButton.Click
        CurrentScintilla.Paste()
    End Sub

    Private Sub gotoButton_Click(sender As Object, e As EventArgs) Handles gotoButton.Click
        GotoForm = Nothing 'Reset the form.
        GotoForm.Show()
    End Sub

    Private Sub searchButton_Click(sender As Object, e As EventArgs) Handles searchButton.Click
        SearchReplaceForm = Nothing 'Reset the form.
        SearchReplaceForm.Show()
        SearchReplaceForm.TabControl1.SelectTab(0) 'Search Tab.
        SearchReplaceForm.searchFindText.Select()
    End Sub

    Private Sub replaceButton_Click(sender As Object, e As EventArgs) Handles replaceButton.Click
        SearchReplaceForm = Nothing 'Reset the form.
        SearchReplaceForm.Show()
        SearchReplaceForm.TabControl1.SelectTab(1) 'Replace Tab.
    End Sub

    Private Sub RibbonButton1_Click(sender As Object, e As EventArgs) Handles RibbonButton1.Click
        SettingsForm.IsGlobal = False
        SettingsForm.ShowDialog()
    End Sub

    Private Sub compileScriptBtn_Click(sender As Object, e As EventArgs) Handles compileScriptBtn.Click
        If CurrentEditor Is Nothing Then Exit Sub

        If CompilerWorker.IsBusy Or CurrentEditor.RefreshWorker.IsBusy Then
            MsgBox(translations.MainForm_compileScriptBtn_Click_WaitForCompile)
        Else
            CompilerWorker.RunWorkerAsync({CurrentScintilla.Tag, SettingsForm.GetCompilerArgs()}) 'The file path is the parameter.
        End If
    End Sub

#Region "Compiler Stuff"
    Private Sub CompilerWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CompilerWorker.DoWork
        'First of all, Try and save all docs.
        Dim msgRslt = MsgBox(translations.MainForm_CompilerWorker_DoWork_WouldYouLikeToSaveFiles, MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Exclamation)
        If msgRslt = DialogResult.Cancel Then Exit Sub
        If msgRslt = DialogResult.Yes Then
            CompilerWorker.ReportProgress(1) 'Save all files.
        End If

        'Next, Create the compiler process.
        If File.Exists(CurrentProject.ProjectPath + "/pawno/pawncc.exe") Then
            'Start compilation process and wait till exit.
            Dim compiler As New Process()
            compiler.StartInfo.FileName = CurrentProject.ProjectPath + "/pawno/pawncc.exe"
            compiler.StartInfo.WorkingDirectory = CurrentProject.ProjectPath + "/gamemodes/"
            compiler.StartInfo.Arguments = """" + e.Argument(0).ToString().Replace("/", "\") + """" + Space(1) + e.Argument(1)
            compiler.StartInfo.CreateNoWindow = True
            compiler.StartInfo.RedirectStandardError = True
            compiler.StartInfo.UseShellExecute = False
            CompilerWorker.ReportProgress(2) 'Compiling
            compiler.Start()
            compiler.WaitForExit()

            'Now, Get the errors/warning then parse them and return.
            Dim errs As String = compiler.StandardError.ReadToEnd()
            If errs = "" Then
                CompilerWorker.ReportProgress(5) 'Done sucessfully.
                e.Result = New List(Of ErrorsDock.ScriptErrorInfo)
            Else
                'Parse the list for the errors and warnings first.
                Dim errorLevel = 0
                Dim errorList As New List(Of ErrorsDock.ScriptErrorInfo)
                For Each match As Match In Regex.Matches(errs, "(.*)\(([0-9]+)\)\s:\s(error|warning)\s([0-9]+):\s(.*)")
                    Dim err As New ErrorsDock.ScriptErrorInfo
                    err.FileName = Path.GetFileName(match.Groups(1).Value)
                    err.LineNumber = match.Groups(2).Value
                    If match.Groups(3).Value = "error" Then
                        err.ErrorType = ErrorsDock.ScriptErrorInfo.ErrorTypes.Error
                        errorLevel = 2
                    Else
                        err.ErrorType = ErrorsDock.ScriptErrorInfo.ErrorTypes.Warning
                        If errorLevel < 2 Then errorLevel = 1
                    End If
                    err.ErrorNumber = match.Groups(4).Value
                    err.ErrorMessage = match.Groups(5).Value

                    errorList.Add(err)
                Next

                'Set result as the list.
                e.Result = errorList

                'Report status.
                If errorLevel = 2 Then
                    CompilerWorker.ReportProgress(3) 'Failed with errors and possible warnings.
                ElseIf errorLevel = 1 Then
                    CompilerWorker.ReportProgress(4) 'Sucess but warnings..
                End If
            End If
        Else
            MsgBox(translations.MainForm_CompilerWorker_DoWork_PawnccNotFound +  " """ + CurrentProject.ProjectPath + "/pawno/pawncc.exe" + """" + vbCrLf + translations.MainForm_CompilerWorker_DoWork_VerifyPawnccIsThere)
        End If
    End Sub

    Private Sub CompilerWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles CompilerWorker.ProgressChanged
        'We will use the progress event to do stuff in the UI.

        '1 = Save
        If e.ProgressPercentage = 1 Then
            SaveAllFiles(Me, Nothing)
        End If

        '2 = Started Compiling
        If e.ProgressPercentage = 2 Then
            ShowStatus(translations.MainForm_CompilerWorker_ProgressChanged_Compiling, -1, False)

            '3 = Failed Compiling With Errors/Warnings.
        ElseIf e.ProgressPercentage = 3 Then
            ShowStatus(translations.MainForm_CompilerWorker_ProgressChanged_CompilingFailedWithErrors, 5000, True)

            '4 = Finished Compiling With Warnings.
        ElseIf e.ProgressPercentage = 4 Then
            ShowStatus(translations.MainForm_CompilerWorker_ProgressChanged_CompilingDoneWithWarnings, 5000, True)

            '5 = Finished Compiling.
        ElseIf e.ProgressPercentage = 5 Then
            ShowStatus(translations.MainForm_CompilerWorker_ProgressChanged_CompilingDoneWithNoErrorsWarnings, 5000, True)
        End If
    End Sub

    Private Sub CompilerWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles CompilerWorker.RunWorkerCompleted
        'Once done, Report result to ErrorsDock.
        ErrorsDock.ErrorWarningList = e.Result
        ErrorsDock.RefreshErrorWarnings()
    End Sub
#End Region

#Region "Plugin System"

    Dim _allPlugins As New PluginBootstrapper()

    <Localizable(False)>
    Private Sub OnFormLoadPlugin(sender As Object, e As EventArgs) Handles MyBase.Load
        'I've made a thing of my own that is just like shadow copying to make sure the DLL's are accessed easily while app is running.
        Dim tempPlugPath = Path.GetTempPath + "esplugins"
        If Directory.Exists(tempPlugPath) Then Directory.Delete(tempPlugPath, True)
        My.Computer.FileSystem.CopyDirectory(ApplicationFiles + "/plugins", tempPlugPath, True)

        'An aggregate catalog that combines multiple catalogs
        Dim catalog = New AggregateCatalog()
        catalog.Catalogs.Add(New DirectoryCatalog(tempPlugPath))

        'Create the CompositionContainer with the parts in the catalog
        Dim container = New CompositionContainer(catalog)

        'Fill the imports of this object
        Try
            container.ComposeParts(_allPlugins)
        Catch compositionException As CompositionException
	        Debug.WriteLine(compositionException.ToString())
        End Try

        'Intialize plugins.
        For Each plugin In _allPlugins.Plugins
            plugin.ExtremeStudioFuncs = New FuncsHandler()
            plugin.OnPluginInit()
            For Each btn In plugin.ToolStripButtons
                installedPlugins.Items.Add(btn)
            Next
        Next
    End Sub
#End Region

        Private Sub addIndentButton_Click(sender As Object, e As EventArgs) Handles addIndentButton.Click
        If CurrentScintilla IsNot Nothing Then
            If CurrentScintilla.SelectionStart = CurrentScintilla.SelectionEnd Then
                CurrentScintilla.Lines(CurrentScintilla.CurrentLine).Indentation += 4
            Else
                For Each line In GetLinesFromRange(CurrentScintilla, CurrentScintilla.SelectionStart, CurrentScintilla.SelectionEnd)
                    CurrentScintilla.Lines(line).Indentation += 4
                Next
            End If
        End If
    End Sub
    Private Sub removeIndentButton_Click(sender As Object, e As EventArgs) Handles removeIndentButton.Click
        If CurrentScintilla IsNot Nothing Then
            If CurrentScintilla.SelectionStart = CurrentScintilla.SelectionEnd Then
                If CurrentScintilla.Lines(CurrentScintilla.CurrentLine).Indentation >= 4 Then CurrentScintilla.Lines(CurrentScintilla.CurrentLine).Indentation -= 4
            Else
                For Each line In GetLinesFromRange(CurrentScintilla, CurrentScintilla.SelectionStart, CurrentScintilla.SelectionEnd)
                    If CurrentScintilla.Lines(line).Indentation >= 4 Then CurrentScintilla.Lines(line).Indentation -= 4
                Next
            End If
        End If
    End Sub

    Private Sub esPluginsManage_Click(sender As Object, e As EventArgs) Handles esPluginsManage.Click
        Dim dlg As New ESPluginsForm
        dlg.ShowDialog()
    End Sub
End Class