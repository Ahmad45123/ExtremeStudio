Imports System.IO
Imports WeifenLuo.WinFormsUI.Docking

Public Class MainForm

#Region "Functions"
    Public Sub CreateTab(ByVal targetPath As String)
        Dim newEditor As New EditorDock
        newEditor.Text = Path.GetFileName(targetPath)
        newEditor.Editor.Text = My.Computer.FileSystem.ReadAllText(targetPath)
        newEditor.Show(MainDock)
    End Sub
#End Region

    'Global variables that are used through the whole program: 
    Public currentProject As New currentProjectClass

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "ExtremeStudio - " + currentProject.projectName
        CreateTab(currentProject.projectPath + "/gamemodes/" + currentProject.projectName + ".pwn")
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'TODO: Whatever saving code here.
        StartupForm.Show()
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
#End Region

#Region "DocksSavingLoading"
    Dim m_deserlise As DeserializeDockContent
    Private Function GetContentFromPersistString(ByVal persistString As String) As IDockContent
        If persistString = GetType(ProjExplorerDock).ToString Then
            Return ProjExplorerDock
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

End Class