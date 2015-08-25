Imports System.IO
Imports WeifenLuo.WinFormsUI.Docking
Imports ScintillaNET
Imports System.Text

Public Class MainForm

    'Use `MainForm.MainDock.ActiveDocument` to get the current active tab.
    'It will return Nothing if there is none active.
    'And to access the editor control, Use the property `CurrentScintilla`.

#Region "Properties"
    Public ReadOnly Property CurrentScintilla As Scintilla
        Get
            If MainDock.ActiveDocument Is Nothing Then Return Nothing
            Return DirectCast(MainDock.ActiveDocument.DockHandler.Form.Controls("Editor"), Scintilla)
        End Get
    End Property
    Public ReadOnly Property CurrentEditor As EditorDock
        Get
            If MainDock.ActiveDocument Is Nothing Then Return Nothing
            Return DirectCast(MainDock.ActiveDocument.DockHandler.Form, EditorDock)
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

    'Global variables that are used through the whole program: 
    Public currentProject As New currentProjectClass

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "ExtremeStudio - " + currentProject.projectName
        OpenFile(currentProject.projectPath + "/gamemodes/" + currentProject.projectName + ".pwn")
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        currentProject.SaveInfo()
        StartupForm.Close()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim newFile As New NewProjectFile
        newFile.ShowDialog()
    End Sub

#Region "View Codes"
    Private Sub ProjectExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectExplorerToolStripMenuItem.Click
        If ProjExplorerDock.Visible = False Then
            ProjExplorerDock.Visible = True
            ProjExplorerDock.Show(MainDock)
        Else
            ProjExplorerDock.Close()
            ProjExplorerDock.Visible = False
        End If
    End Sub
    Private Sub ObjectExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObjectExplorerToolStripMenuItem.Click
        If ObjectExplorerDock.Visible = False Then
            ObjectExplorerDock.Visible = True
            ObjectExplorerDock.Show(MainDock)
        Else
            ObjectExplorerDock.Close()
            ObjectExplorerDock.Visible = False
        End If
    End Sub
    Private Sub ErrorsAndWarningsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ErrorsAndWarningsToolStripMenuItem.Click
        If ErrorsDock.Visible = False Then
            ErrorsDock.Visible = True
            ErrorsDock.Show(MainDock)
        Else
            ErrorsDock.Close()
            ErrorsDock.Visible = False
        End If
    End Sub
#End Region

#Region "DocksSavingLoading"
    Dim m_deserlise As DeserializeDockContent
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
        Try
            m_deserlise = New DeserializeDockContent(AddressOf GetContentFromPersistString)
            MainDock.LoadFromXml(Application.StartupPath + "/configs/docksInfo.xml", m_deserlise)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MainDock.SaveAsXml(Application.StartupPath + "/configs/docksInfo.xml")
    End Sub
#End Region

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If CurrentScintilla Is Nothing Then Exit Sub
        SaveFile(CurrentScintilla)
    End Sub

    Public Sub SaveAllFiles(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        For Each Dock As DockContent In MainDock.Documents
            SaveFile(Dock.Controls("Editor"))
        Next
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim frm As New IncludesForm
        frm.Show()
    End Sub
End Class