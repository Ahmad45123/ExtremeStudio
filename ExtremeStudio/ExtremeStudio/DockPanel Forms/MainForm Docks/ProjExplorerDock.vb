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
            Dim node = treeView.Nodes(0).Nodes.Add(stra)
            node.ImageIndex = 1
        Next
        For Each stra As String In Directory.GetFiles(MainForm.currentProject.projectPath + "\filterscripts")
            If Not stra.EndsWith("pwn") Then Continue For
            stra = stra.Replace(MainForm.currentProject.projectPath + "\filterscripts\", "")
            Dim node = treeView.Nodes(1).Nodes.Add(stra)
            node.ImageIndex = 1
        Next

        'Sub dirs
        Dim gameModesFolder As TreeNode = ExtremeCore.getAllFilesInFolders(MainForm.currentProject.projectPath + "\gamemodes")
        Dim filterScriptsFolder As TreeNode = ExtremeCore.getAllFilesInFolders(MainForm.currentProject.projectPath + "\filterscripts")

        For Each nde As TreeNode In gameModesFolder.Nodes
            treeView.Nodes(0).Nodes.Add(nde)
        Next
        For Each nde As TreeNode In filterScriptsFolder.Nodes
            treeView.Nodes(1).Nodes.Add(nde)
        Next
    End Sub
    Public Sub RefreshIncludes()
        treeView.Nodes(2).Nodes.Clear()
        For Each Str As String In Includes
            Dim nde As TreeNode = treeView.Nodes(2).Nodes.Add(Str)
            nde.ImageIndex = 1
        Next
    End Sub

    Private Sub treeView_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles treeView.BeforeLabelEdit
        If e.Node.Text = "Gamemode Parts" Or e.Node.Text = "Filterscripts" Or e.Node.Text = "Includes" Then
            e.CancelEdit = True
        End If

        For Each nde As TreeNode In treeView.Nodes(2).Nodes
            If nde.Text = e.Node.Text Then
                e.CancelEdit = True
                Exit For
            End If
        Next
    End Sub
End Class