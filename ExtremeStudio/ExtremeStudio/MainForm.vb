Imports System.IO

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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Dim newFile As New NewProjectFile
        newFile.ShowDialog()
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        'TODO: Whatever saving code here.

        StartupForm.Show()
    End Sub
End Class