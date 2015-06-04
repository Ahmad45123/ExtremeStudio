Imports System.IO

Public Class ProjExplorerDock

    Public Includes As List(Of String)

    Public Sub RefreshList()
        treeView.Nodes(0).Nodes.Clear()
        treeView.Nodes(1).Nodes.Clear()

        'Root
        For Each stra As String In Directory.GetFiles(MainForm.currentProject.projectPath + "\gamemodes")
            If Not stra.EndsWith("pwn") Then Continue For
            stra = stra.Replace(MainForm.currentProject.projectPath + "\gamemodes\", "")
            treeView.Nodes(0).Nodes.Add(stra)
        Next
        For Each stra As String In Directory.GetFiles(MainForm.currentProject.projectPath + "\filterscripts")
            If Not stra.EndsWith("pwn") Then Continue For
            stra = stra.Replace(MainForm.currentProject.projectPath + "\filterscripts\", "")
            treeView.Nodes(1).Nodes.Add(stra)
        Next

        'Sub dirs
        Dim gameModesFolder As String() = ExtremeCore.getAllFolders(MainForm.currentProject.projectPath + "\gamemodes")
        Dim filterScriptsFolder As String() = ExtremeCore.getAllFolders(MainForm.currentProject.projectPath + "\filterscripts")

        For Each Str As String In gameModesFolder
            Dim rootFolder As TreeNode = treeView.Nodes(0).Nodes.Add(Path.GetDirectoryName(Str))
            Dim files() As String = Directory.GetFiles(Str)
            For Each stra As String In files
                If Not stra.EndsWith("pwn") Then Continue For
                stra = stra.Replace(Path.GetDirectoryName(stra) + "\", "")
                rootFolder.Nodes.Add(stra)
            Next
        Next

        For Each Str As String In filterScriptsFolder
            Dim rootFolder As TreeNode = treeView.Nodes(1).Nodes.Add(Path.GetDirectoryName(Str))
            Dim files() As String = Directory.GetFiles(Str)
            For Each stra As String In files
                If Not stra.EndsWith("pwn") Then Continue For
                stra = stra.Replace(Path.GetDirectoryName(stra) + "\", "")
                rootFolder.Nodes.Add(stra)
            Next
        Next
    End Sub
    Public Sub RefreshIncludes()
        treeView.Nodes(2).Nodes.Clear()
        For Each Str As String In Includes
            treeView.Nodes(2).Nodes.Add(Str)
        Next
    End Sub

    Private Sub ProjExplorerDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class