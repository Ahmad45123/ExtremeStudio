Public Class MainForm

    'Global variables that are used through the whole program: 
    Public currentProject As New currentProjectClass

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim newEditor As New EditorDock
        Me.Text = "ExtremeStudio - " + currentProject.projectName
        newEditor.Text = currentProject.projectName + ".pwn"
        newEditor.Editor.Text = My.Computer.FileSystem.ReadAllText(currentProject.projectPath + "/gamemodes/" + currentProject.projectName + ".pwn")
        newEditor.Show(MainDock)
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