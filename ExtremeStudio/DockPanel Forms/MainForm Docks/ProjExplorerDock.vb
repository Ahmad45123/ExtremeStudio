Imports System.IO
Imports ExtremeParser
Imports ExtremeCore
Imports ExtremeStudio.My.Resources

Public Class ProjExplorerDock

    Public Sub RefreshList()
        filesList.SelectedPath = filesList.SelectedPath
    End Sub

    Public Function IsProtected(pPath As String) As Boolean
        If pPath.StartsWith(Path.Combine(MainForm.CurrentProject.ProjectPath, "configs")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "gamemodes")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "pawno")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "pawno\libpawnc.dll")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "pawno\pawn.ico")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "pawno\pawnc.dll")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "pawno\pawncc.exe")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "pawno\include")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "plugins")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "extremeStudio.config")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "server.cfg")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "samp-server.exe")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "samp-npc.exe")) _
            Or pPath = (Path.Combine(MainForm.CurrentProject.ProjectPath, "announce.exe")) _
        Then
            Return True
        End If 
        Return False
    End Function

    Private Sub ProjExplorerDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Wont be called multiple times: 
        filesList.MainDir = MainForm.CurrentProject.ProjectPath
        filesList.SelectedPath = MainForm.CurrentProject.ProjectPath
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshList()
    End Sub

    Private Sub filesList_MouseDown(sender As Object, e As MouseEventArgs) Handles filesList.MouseDown
        If e.Button = MouseButtons.Right Then
            filesList.SelectedIndex = filesList.IndexFromPoint(e.Location)
            If filesList.SelectedItem <> Nothing AndAlso IsProtected(Path.Combine(filesList.SelectedPath, filesList.SelectedItem)) Then
                DeleteToolStripMenuItem.Enabled = False
                RenameToolStripMenuItem.Enabled = False
            Else
                DeleteToolStripMenuItem.Enabled = True
                RenameToolStripMenuItem.Enabled = True
            End If
            mouseRightClick.Show(MousePosition)
        End If
    End Sub

    Private Sub filesList_FileSelected(sender As Object, fse As ExtremeCore.FileSelectEventArgs) Handles filesList.FileSelected
        Dim ext = Path.GetExtension(fse.FileName)

        'Do different stuff depending on file type.
        If ext = ".inc" Or ext = ".pwn" Then
            MainForm.OpenFile(fse.FileName)
        Else
            MainForm.ShowStatus(translations.ProjExplorerDock_filesList_FileSelected_FileNotSupported, 5000, False)
            Process.Start(New ProcessStartInfo With { .WorkingDirectory = Path.GetDirectoryName(fse.FileName), .FileName = fse.FileName })
        End If
    End Sub

    Private Sub RenameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenameToolStripMenuItem.Click
        If Directory.Exists(filesList.SelectedFile) Then
            ResetFolder:
            Dim input As New AdvacnedInputBox(translations.ProjExplorerDock_RenameToolStripMenuItem_Click_EnterNewNameTitle, translations.ProjExplorerDock_RenameToolStripMenuItem_Click_PleaseEnterNewDirName)
            If input.ResResult = AdvacnedInputBox.ReturnValue.InputResultOk Then
                If FilenameIsOk(input.ResText) Then
                    Try
                        My.Computer.FileSystem.RenameDirectory(filesList.SelectedFile, input.ResText)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
                    End Try
                    RefreshList()
                Else
                    GoTo ResetFolder
                End If
            End If

        ElseIf File.Exists(filesList.SelectedFile) Then
            ResetFile:
            Dim input As New AdvacnedInputBox(translations.ProjExplorerDock_RenameToolStripMenuItem_Click_EnterNewNameTitle, translations.ProjExplorerDock_RenameToolStripMenuItem_Click_PleaseEnterNameForFile, defaultText:= Path.GetFileName(filesList.SelectedFile))
            If input.ResResult = AdvacnedInputBox.ReturnValue.InputResultOk Then
                If FilenameIsOk(input.ResText) Then
                    Try
                        My.Computer.FileSystem.RenameFile(filesList.SelectedFile, input.ResText)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
                    End Try
                    RefreshList()
                Else
                    GoTo ResetFile
                End If
            End If

        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If Directory.Exists(filesList.SelectedFile) Then
            Directory.Delete(filesList.SelectedFile)
            RefreshList()

        ElseIf File.Exists(filesList.SelectedFile) Then
            File.Delete(filesList.SelectedFile)
            RefreshList()

        End If
    End Sub

    Private Sub NewDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewDirectoryToolStripMenuItem.Click
        If Directory.Exists(filesList.SelectedFile) Then
            'Go inside the dir.
            filesList.SelectedPath = Path.Combine(filesList.SelectedPath, filesList.SelectedItem.ToString)
        End If

        ResetChoose:
            Dim input As New AdvacnedInputBox(translations.ProjExplorerDock_RenameToolStripMenuItem_Click_EnterNewNameTitle, translations.ProjExplorerDock_NewDirectoryToolStripMenuItem_Click_PleaseEnterNameForDir)
            If input.ResResult = AdvacnedInputBox.ReturnValue.InputResultOk Then
                If FilenameIsOk(input.ResText) Then
                    Try
                        My.Computer.FileSystem.CreateDirectory(Path.Combine(filesList.SelectedPath, input.ResText))
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
                    End Try
                    RefreshList()
                Else
                    GoTo ResetChoose
                End If
            End If
    End Sub

    Private Sub NewFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFileToolStripMenuItem.Click
        If Directory.Exists(filesList.SelectedFile) Then
            'Go inside the dir.
            filesList.SelectedPath = Path.Combine(filesList.SelectedPath, filesList.SelectedItem.ToString)
        End If

        ResetChoose:
            Dim input As New AdvacnedInputBox(translations.ProjExplorerDock_RenameToolStripMenuItem_Click_EnterNewNameTitle, translations.ProjExplorerDock_NewFileToolStripMenuItem_Click_PleaseEnterNameForFile, defaultText:= "example.pwn")
            If input.ResResult = AdvacnedInputBox.ReturnValue.InputResultOk Then
                If FilenameIsOk(input.ResText) Then
                    Try
                        My.Computer.FileSystem.WriteAllText(Path.Combine(filesList.SelectedPath, input.ResText), "", False)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
                    End Try
                    RefreshList()
                Else
                    GoTo ResetChoose
                End If
            End If
    End Sub

    Private Sub filesList_KeyDown(sender As Object, e As KeyEventArgs) Handles filesList.KeyDown
        If e.KeyCode = Keys.Delete Then
            If IsProtected(Path.Combine(filesList.SelectedPath, filesList.SelectedItem)) = False Then
                DeleteToolStripMenuItem_Click(Me, Nothing)
            End If
        End If
    End Sub
End Class