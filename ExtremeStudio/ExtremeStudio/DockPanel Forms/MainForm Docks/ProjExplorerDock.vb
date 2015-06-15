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
            node.Tag = "File"
            node.ImageIndex = 1
        Next
        For Each stra As String In Directory.GetFiles(MainForm.currentProject.projectPath + "\filterscripts")
            If Not stra.EndsWith("pwn") Then Continue For
            stra = stra.Replace(MainForm.currentProject.projectPath + "\filterscripts\", "")
            Dim node = treeView.Nodes(1).Nodes.Add(stra)
            node.Tag = "File"
            node.ImageIndex = 1
        Next

        'Sub dirs
        Dim gameModesFolder As TreeNode = ExtremeCore.getAllFilesInFolders(MainForm.currentProject.projectPath + "\gamemodes", ".pwn")
        Dim filterScriptsFolder As TreeNode = ExtremeCore.getAllFilesInFolders(MainForm.currentProject.projectPath + "\filterscripts", ".pwn")

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

    Private Sub treeView_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles treeView.AfterLabelEdit
        If e.Label Is Nothing Then
            Exit Sub
        Else
            If e.Label = e.Node.Text Then
                Exit Sub
            End If
        End If

        Dim oldPath As String = MainForm.currentProject.projectPath + "/"
        Dim path As String = e.Node.FullPath

        If path.StartsWith("Gamemode Parts") Then
            path = path.Remove(0, 14)
            path = "gamemodes" + path
        End If
        oldPath += path

        If e.Node.Tag = "File" Then
            If (e.Label.EndsWith(".pwn") Or e.Label.EndsWith(".inc")) And ExtremeCore.FilenameIsOK(e.Label) Then
                My.Computer.FileSystem.RenameFile(oldPath, e.Label)
            Else
                e.CancelEdit = True
                Beep()
                MsgBox("Invalid name please use valid filename characters and make sure to has a .inc or .pwn extension")
            End If
        ElseIf e.Node.Tag = "Folder" Then
            If ExtremeCore.FilenameIsOK(e.Label) Then
                My.Computer.FileSystem.RenameDirectory(oldPath, e.Label)
            Else
                e.CancelEdit = True
                Beep()
                MsgBox("Invalid name, Please use valid file-name characters and make sure to use a .inc or .pwn extension")
            End If
        End If
    End Sub

    Private Sub treeView_KeyDown(sender As Object, e As KeyEventArgs) Handles treeView.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim selNode As TreeNode = treeView.SelectedNode
            If selNode.Text = "Gamemode Parts" Or selNode.Text = "Filterscripts" Or selNode.Text = "Includes" Then
                Exit Sub
            End If
            For Each nde As TreeNode In treeView.Nodes(2).Nodes
                If nde.Text = selNode.Text Then
                    Exit Sub
                End If
            Next

            If MsgBox("Are you sure you want to delete this file/folder ?" + vbCrLf + vbCrLf + "NOTE: If it's a folder, All its contents will be deleted.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim oldPath As String = MainForm.currentProject.projectPath + "/"
                Dim path As String = selNode.FullPath

                If path.StartsWith("Gamemode Parts") Then
                    path = path.Remove(0, 14)
                    path = "gamemodes" + path
                End If
                oldPath += path

                If selNode.Tag = "File" Then
                    My.Computer.FileSystem.DeleteFile(oldPath)
                ElseIf selNode.Tag = "Folder" Then
                    My.Computer.FileSystem.DeleteDirectory(oldPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
                End If
                RefreshList()
            End If
        End If
    End Sub

    Private Sub ProjExplorerDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub
End Class