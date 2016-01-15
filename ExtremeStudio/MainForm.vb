Imports System.IO
Imports WeifenLuo.WinFormsUI.Docking
Imports ScintillaNET
Imports System.Text
Imports System.Environment

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
    Public Sub OpenFile(ByVal targetPath As String)
        Dim newEditor As New EditorDock
        newEditor.Text = Path.GetFileName(targetPath)
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

    'Global variables that are used through the whole program: 
    Public CurrentProject As New currentProjectClass

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "ExtremeStudio - " + currentProject.projectName
        OpenFile(currentProject.projectPath + "/gamemodes/" + currentProject.projectName + ".pwn")
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Save all info.
        currentProject.SaveInfo()

        If _isClosedProgrammitcly = False Then
            Application.Exit()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles newFileButton.Click
        Dim newFile As New NewProjectFile
        newFile.ShowDialog()
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

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles syntaxHighPanel.Click
        SettingsForm.ShowDialog()
    End Sub

    Private Sub MainDock_ActiveDocumentChanged(sender As Object, e As EventArgs) Handles MainDock.ActiveDocumentChanged
        'Update.
        If ObjectExplorerDock.Visible And CurrentEditor IsNot Nothing Then
            ObjectExplorerDock.refreshTreeView(CurrentEditor.codeParts)
        End If
    End Sub

    Private _isClosedProgrammitcly As Boolean = False
    Private Sub closeProjectButton_Click(sender As Object, e As EventArgs) Handles closeProjectButton.Click
        'Save
        currentProject.SaveInfo()

        'Then close ourself.
        _isClosedProgrammitcly = True : Close()

        'Open the form
        Dim str As New StartupForm
        str.isFirst = False
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
End Class