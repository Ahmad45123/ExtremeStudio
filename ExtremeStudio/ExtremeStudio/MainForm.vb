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
End Class