Imports System.IO
Imports ExtremeParser

Public Class ProjExplorerDock

    Private nodeState As ExtremeCore.treeNodeStateSaving = New ExtremeCore.treeNodeStateSaving

    Public Includes As LinkedList(Of CodeParts)

    Public Sub RefreshList(Optional firstTime As Boolean = False)
        If firstTime = False Then nodeState.SaveTreeState(treeView.Nodes) 'Save current expanded nodes.

        treeView.Nodes(0).Nodes.Clear()
        treeView.Nodes(1).Nodes.Clear()
        treeView.Nodes(2).Nodes.Clear()
        treeView.Nodes(0).Tag = "Root"
        treeView.Nodes(1).Tag = "Root"
        treeView.Nodes(2).Tag = "Root"

        'Dirs
        Dim gameModesFolder As TreeNode = ExtremeCore.getAllFilesInFolders(MainForm.currentProject.projectPath + "\gamemodes", ".pwn")
        Dim filterScriptsFolder As TreeNode = ExtremeCore.getAllFilesInFolders(MainForm.currentProject.projectPath + "\filterscripts", ".pwn")
        Dim incsFolder As TreeNode = ExtremeCore.getAllFilesInFolders(MainForm.currentProject.projectPath + "\\pawno\include", ".inc")

        For Each nde As TreeNode In gameModesFolder.Nodes
            treeView.Nodes(0).Nodes.Add(nde)
        Next
        For Each nde As TreeNode In filterScriptsFolder.Nodes
            treeView.Nodes(1).Nodes.Add(nde)
        Next
        For Each nde As TreeNode In incsFolder.Nodes
            treeView.Nodes(2).Nodes.Add(nde)
        Next

        'Root Files.
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
        For Each stra As String In Directory.GetFiles(MainForm.currentProject.projectPath + "\pawno\include")
            If Not stra.EndsWith("inc") Then Continue For
            stra = stra.Replace(MainForm.currentProject.projectPath + "\pawno\include\", "")
            Dim node = treeView.Nodes(2).Nodes.Add(stra)
            node.Tag = "File"
            node.ImageIndex = 1
        Next

        If firstTime = False Then nodeState.RestoreTreeState(treeView) 'Load the last opened nodes.
    End Sub

    Private Sub treeView_BeforeLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles treeView.BeforeLabelEdit
        If e.Node.Tag = "Root" Then
            e.CancelEdit = True
        End If
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
        ElseIf path.StartsWith("Includes") Then
            path = path.Remove(0, 8)
            path = "pawno/include" + path
        End If
        oldPath += path

        If e.Node.Tag = "File" Then
            If (e.Label.EndsWith(".pwn") Or e.Label.EndsWith(".inc")) And ExtremeCore.FilenameIsOK(e.Label) Then
                My.Computer.FileSystem.RenameFile(oldPath, e.Label)
            Else
                e.CancelEdit = True
                Beep()
                MsgBox("Invalid name please use valid filename characters And make sure To has a .inc Or .pwn extension")
            End If
        ElseIf e.Node.Tag = "Folder" Then
            If ExtremeCore.FilenameIsOK(e.Label) Then
                My.Computer.FileSystem.RenameDirectory(oldPath, e.Label)
            Else
                e.CancelEdit = True
                Beep()
                MsgBox("Invalid name, Please use valid file-name characters And make sure To use a .inc Or .pwn extension")
            End If
        End If
    End Sub

    Private Sub treeView_KeyDown(sender As Object, e As KeyEventArgs) Handles treeView.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim selNode As TreeNode = treeView.SelectedNode
            If selNode.Tag = "Root" Then
                Exit Sub
            End If

            If MsgBox("Are you sure you want To delete this file/folder ?" + vbCrLf + vbCrLf + "NOTE: If it's a folder, All its contents will be deleted.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim oldPath As String = MainForm.currentProject.projectPath + "/"
                Dim path As String = selNode.FullPath

                If path.StartsWith("Gamemode Parts") Then
                    path = path.Remove(0, 14)
                    path = "gamemodes" + path
                ElseIf path.StartsWith("Includes") Then
                    path = path.Remove(0, 8)
                    path = "pawno/include" + path
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
        RefreshList(True)
    End Sub

    Private Sub treeView_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles treeView.NodeMouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If e.Node.Tag = "Root" Then
                Exit Sub
            End If

            If e.Node.Tag = "File" Or e.Node.Tag = "Include" Then
                Dim oldPath As String = MainForm.currentProject.projectPath + "/"
                Dim path As String = e.Node.FullPath

                If path.StartsWith("Gamemode Parts") Then
                    path = path.Remove(0, 14)
                    path = "gamemodes" + path
                ElseIf path.StartsWith("Includes") Then
                    path = path.Remove(0, 8)
                    path = "pawno/include" + path
                End If
                oldPath += path

                'Make sure include path is valid.
                If e.Node.Tag = "Include" Then
                    If Not oldPath.EndsWith(".pwn") And Not oldPath.EndsWith(".inc") Then
                        oldPath = oldPath + ".inc"
                    End If
                End If

                MainForm.OpenFile(oldPath)
            End If
        End If
    End Sub

    Private Sub treeView_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles treeView.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then

            'Setup the menu
            If e.Node.Tag = "File" Then
                NewFileToolStripMenuItem.Enabled = False
                NewDirectoryToolStripMenuItem.Enabled = False
            ElseIf e.Node.Tag = "Folder" Or e.Node.Tag = "Root" Then
                NewFileToolStripMenuItem.Enabled = True
                NewDirectoryToolStripMenuItem.Enabled = True
            End If
            If e.Node.Tag = "File" Or e.Node.Tag = "Folder" Then
                RenameToolStripMenuItem.Enabled = True
                DeleteToolStripMenuItem.Enabled = True
            Else
                RenameToolStripMenuItem.Enabled = False
                DeleteToolStripMenuItem.Enabled = False
            End If


            'Show the context menu.
            mouseRightClick.Show(treeView, e.X, e.Y)
        End If
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        treeView.SelectedNode.BeginEdit()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        treeView_KeyDown(treeView, New KeyEventArgs(Keys.Delete))
    End Sub

    Private Sub NewFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFileToolStripMenuItem.Click
        NewProjectFile.Show()

        Dim selNode As TreeNode = treeView.SelectedNode

        If selNode.Tag = "Folder" Or selNode.Tag = "Root" Then
            Dim path As String = selNode.FullPath
            If path.StartsWith("Gamemode Parts") Then
                path = path.Remove(0, 14)
                path = "gamemodes" + path
                NewProjectFile.RadioButton1.Checked = True
            ElseIf path.StartsWith("Includes") Then
                path = path.Remove(0, 8)
                path = "include" + path
                NewProjectFile.RadioButton2.Checked = True
            Else
                path = path.Remove(0, 13)
                path = "filterscripts" + path
                NewProjectFile.RadioButton3.Checked = True '<< Filter script.
            End If

            'Select the item after showing the form.
            NewProjectFile.FolderList.SelectedIndex = NewProjectFile.FolderList.Items.IndexOf(path)
        End If
    End Sub

    Private Sub NewDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewDirectoryToolStripMenuItem.Click
        Dim selNode = treeView.SelectedNode
        If selNode.Tag = "Folder" Or selNode.Tag = "Root" Then
            Dim path As String = selNode.FullPath
            If path.StartsWith("Gamemode Parts") Then
                path = path.Remove(0, 14)
                path = "gamemodes" + path
            ElseIf path.StartsWith("Includes") Then
                path = path.Remove(0, 8)
                path = "pawno/include" + path
            Else
                path = path.Remove(0, 13)
                path = "filterscripts" + path
            End If

            'Select the item after showing the form.
            Dim input As New ExtremeCore.AdvacnedInputBox("Folder Name", "Enter a name for the new folder: ")
            If input.resResult = ExtremeCore.AdvacnedInputBox.returnValue.INPUT_RESULT_OK Then
                If ExtremeCore.FilenameIsOK(input.resResult) Then
                    My.Computer.FileSystem.CreateDirectory(MainForm.currentProject.projectPath + "/" + path + "/" + input.resText)
                    RefreshList()
                Else
                    MsgBox("Invalid name, Please use valid filename characters.")
                End If
            End If
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshList()
    End Sub
End Class