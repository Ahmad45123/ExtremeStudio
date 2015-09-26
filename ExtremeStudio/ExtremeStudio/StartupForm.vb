Imports System.Net
Imports System.Xml
Imports System.IO
Imports System.IO.Compression
Imports ExtremeCore

Public Class StartupForm

#Region "RecentCode"
    Public Recent As New List(Of String)
    Const MAX_LIST_ITEMS = 30
    Public Sub AddNewRecent(path As String)
        For Each Str As String In Recent
            If Str = path Then
                Recent.Remove(Str)
                Exit For
            End If
        Next
        Recent.Insert(0, path) 'Inset it at the very start
        If Recent.Count - 1 = MAX_LIST_ITEMS Then 'Remove the new added stuff
            Recent.RemoveAt(MAX_LIST_ITEMS)
        End If
        My.Computer.FileSystem.WriteAllText(MainForm.APPLICATION_FILES + "/configs/recent.xml", ExtremeCore.ObjectSerializer.Serialize(Recent), False)
    End Sub

    Public Sub RemoveRecent(path As String)
        For Each Str As String In Recent
            If Str = path Then
                Recent.Remove(Str)
                Exit For
            End If
        Next
        My.Computer.FileSystem.WriteAllText(MainForm.APPLICATION_FILES + "/configs/recent.xml", ExtremeCore.ObjectSerializer.Serialize(Recent), False)
    End Sub
#End Region

    Dim versionHandler As New versionHandler

    Private Sub StartupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If the interop files don't exist, Extract the files.
        If Not My.Computer.FileSystem.FileExists(Application.StartupPath + "/x64/SQLite.Interop.dll") Or Not My.Computer.FileSystem.FileExists(MainForm.APPLICATION_FILES + "/x86/SQLite.Interop.dll") Then
            'Remove old.
            If My.Computer.FileSystem.FileExists(Application.StartupPath + "/x64/SQLite.Interop.dll") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath + "/x64/SQLite.Interop.dll")
            If My.Computer.FileSystem.FileExists(Application.StartupPath + "/x86/SQLite.Interop.dll") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath + "/x86/SQLite.Interop.dll")

            'Extract New
            My.Computer.FileSystem.WriteAllBytes(Application.StartupPath + "/interop.zip", My.Resources.SQLiteInterop, False) 'Write the file.
            ExtremeCore.FastZipUnpack(Application.StartupPath + "/interop.zip", Application.StartupPath) 'Extract it.
            My.Computer.FileSystem.DeleteFile(Application.StartupPath + "/interop.zip") 'Delete the temp file.
        End If


        'Create needed folders and files.
        If Not My.Computer.FileSystem.DirectoryExists(MainForm.APPLICATION_FILES + "/cache") Then
            My.Computer.FileSystem.CreateDirectory(MainForm.APPLICATION_FILES + "/cache")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(MainForm.APPLICATION_FILES + "/cache/serverPackages") Then
            My.Computer.FileSystem.CreateDirectory(MainForm.APPLICATION_FILES + "/cache/serverPackages")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(MainForm.APPLICATION_FILES + "/cache/includes") Then
            My.Computer.FileSystem.CreateDirectory(MainForm.APPLICATION_FILES + "/cache/includes")
        End If

        If Not My.Computer.FileSystem.DirectoryExists(MainForm.APPLICATION_FILES + "/configs") Then
            My.Computer.FileSystem.CreateDirectory(MainForm.APPLICATION_FILES + "/configs")
            My.Computer.FileSystem.WriteAllText(MainForm.APPLICATION_FILES + "/configs/recent.xml", "", False)
        End If


        'Load all the recent.
        If My.Computer.FileSystem.FileExists(MainForm.APPLICATION_FILES + "/configs/recent.xml") Then
            Try
                Recent = ExtremeCore.ObjectSerializer.Deserialize(Of List(Of String))(My.Computer.FileSystem.ReadAllText(MainForm.APPLICATION_FILES + "/configs/recent.xml"))
            Catch ex As Exception
            End Try
        End If

        'Load samp versions into list.
        Dim str As New List(Of String)
        verListBox.Tag = str
        If ExtremeCore.isNetAvailable() Then 'Download latest from internet if there is internet.
            Dim webClient As New WebClient
            Dim xmlFile As New XmlDocument()
            Dim fileText As String = webClient.DownloadString("http://johnymac.github.io/esfiles/serverPackages.xml")
            xmlFile.LoadXml(fileText)

            For Each cs As XmlNode In xmlFile.SelectNodes("serverPackages/samp")
                Dim newList As Integer = verListBox.Items.Add(cs("name").InnerText)
                verListBox.Tag.Add(cs("download").InnerText)
            Next
        Else 'Load existing from folder.
            For Each pth As String In Directory.GetFiles(MainForm.APPLICATION_FILES + "/cache/serverPackages")
                Dim newList As Integer = verListBox.Items.Add(Path.GetFileNameWithoutExtension(pth))
                verListBox.Tag.Add(pth)
            Next
        End If

    End Sub

    Private Sub nameTextBox_TextChanged(sender As Object, e As EventArgs) Handles nameTextBox.TextChanged
        If nameTextBox.Text = "" Then Exit Sub

        If FilenameIsOK(nameTextBox.Text) Then
        Else
            Beep()

            'Replace invalid chars.
            nameTextBox.Text = nameTextBox.Text.Replace("\", "")
            nameTextBox.Text = nameTextBox.Text.Replace("/", "")
            nameTextBox.Text = nameTextBox.Text.Replace(":", "")
            nameTextBox.Text = nameTextBox.Text.Replace("*", "")
            nameTextBox.Text = nameTextBox.Text.Replace("?", "")
            nameTextBox.Text = nameTextBox.Text.Replace(Chr(34), "")
            nameTextBox.Text = nameTextBox.Text.Replace("<", "")
            nameTextBox.Text = nameTextBox.Text.Replace(">", "")
            nameTextBox.Text = nameTextBox.Text.Replace("|", "")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Check if entered path exist.
        If My.Computer.FileSystem.DirectoryExists(locTextBox.Text) Or My.Computer.FileSystem.FileExists(locTextBox.Text + "/extremeStudio.config") Then
            If Not verListBox.SelectedIndex = -1 Then
                If My.Computer.FileSystem.FileExists(MainForm.APPLICATION_FILES + "/cache/serverPackages/" + verListBox.SelectedItem + ".zip") Then 'check if that version is existing
                    FastZipUnpack(MainForm.APPLICATION_FILES + "/cache/serverPackages/" + verListBox.SelectedItem + ".zip", locTextBox.Text) 'Extract the zip to project folder.
                Else 'Download from net if not exist.
                    Dim client As New WebClient 'For downloading the selected file.
                    client.DownloadFile(verListBox.Tag(verListBox.SelectedIndex), My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip") 'Download the zip file.
                    FastZipUnpack(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip", locTextBox.Text) 'Extract the zip.
                    My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip", MainForm.APPLICATION_FILES + "/cache/serverPackages/" + verListBox.SelectedItem + ".zip") 'Copy the file to be used instead of downloading
                    My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip") 'Delete the file from temp.
                End If
                My.Computer.FileSystem.WriteAllText(locTextBox.Text + "/gamemodes/" + nameTextBox.Text + ".pwn", My.Resources.newfileTemplate, False)
                MainForm.currentProject.projectName = nameTextBox.Text
                MainForm.currentProject.projectPath = locTextBox.Text
                MainForm.currentProject.projectVersion = versionHandler.currentVersion
                MainForm.currentProject.CreateTables() 'Create the tables of the db.
                MainForm.currentProject.SaveInfo() 'Write the default extremeStudio config.
                AddNewRecent(MainForm.currentProject.projectPath) 'Add it to the recent list.
                MainForm.Show()
                Me.Hide()
            Else
                MsgBox("You haven't selected a SAMP version to use.")
            End If
        Else
            MsgBox("That directory doesn't exist or contains a project.")
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles pathTextBox.TextChanged
        loadProjectBtn.Enabled = False
        projectName.Text = "None"
        projectVersion.Text = "None"

        If isValidExtremeProject(pathTextBox.Text) Then
            MainForm.currentProject.projectPath = pathTextBox.Text
            MainForm.currentProject.ReadInfo()
            If My.Computer.FileSystem.FileExists(pathTextBox.Text + "/gamemodes/" + MainForm.currentProject.projectName + ".pwn") Then
                projectName.Text = MainForm.currentProject.projectName

                Dim projVersion As String = MainForm.currentProject.projectVersion
                Dim progVersion As String = versionHandler.currentVersion

                Dim versionCompare As versionReader.CompareVersionResult = versionReader.CompareVersions(projVersion, progVersion)
                If versionCompare = versionReader.CompareVersionResult.VERSION_SAME Then
                    projectVersion.Text = "Project version is the same as ExtremeStudio's version, No converion is needed."
                    loadProjectBtn.Enabled = True
                ElseIf versionCompare = versionReader.CompareVersionResult.VERSION_NEW Then
                    projectVersion.Text = "Project older then ExtremeStudio, Conversion will be done however it may bug with older versions so its recommended to not try."
                    loadProjectBtn.Enabled = True
                ElseIf versionCompare = versionReader.CompareVersionResult.VERSION_OLD Then
                    projectVersion.Text = "Project version is newer then ExtremeStudio's version, Please download latest ExtremeStudio package."
                End If
            Else
                MsgBox("The main .pwn file is either renamed or deleted, Please manually create it or rename it back.")
            End If
        Else
            MsgBox("ERROR: That folder isn't a valid ExtremeStudio project." + vbCrLf + "Make sure you haven't deleted or modified any file manually.")
        End If
    End Sub

    Private Sub loadProjectBtn_Click(sender As Object, e As EventArgs) Handles loadProjectBtn.Click
        AddNewRecent(MainForm.currentProject.projectPath) 'Add it to the recent list.
        versionHandler.doIfUpdateNeeded(MainForm.currentProject)
        MainForm.Show()
        Hide()
    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        If e.TabPageIndex = 2 Then
            recentListBox.Items.Clear()

            'Get recent list.
            For Each Str As String In Recent
                If Str Is Nothing Then Continue For
                recentListBox.Items.Add(Str)
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If recentListBox.SelectedIndex = -1 Then Exit Sub
        pathTextBox.Text = recentListBox.SelectedItem
        If loadProjectBtn.Enabled = True Then
            If Not projectVersion.Text.StartsWith("Project version is the same") Then
                If MsgBox(projectVersion.Text + vbCrLf + vbCrLf + "Would you like to continue ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    loadProjectBtn_Click(loadProjectBtn, EventArgs.Empty) 'Click `Load Project` button.
                End If
            Else
                loadProjectBtn_Click(loadProjectBtn, EventArgs.Empty) 'Click `Load Project` button.
            End If
        Else
            If Not projectVersion.Text.StartsWith("Project version is the same") Then
                MsgBox(projectVersion.Text)
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If recentListBox.SelectedIndex = -1 Then Exit Sub
        RemoveRecent(recentListBox.SelectedItem)
        TabControl1_Selected(TabControl1, New TabControlEventArgs(TabPage3, 2, TabControlAction.Selected)) 'Fire the selected event to refresh the list.
    End Sub

    Private Sub recentListBox_DoubleClick(sender As Object, e As EventArgs) Handles recentListBox.DoubleClick
        Button1.PerformClick() 'Press the load button.
    End Sub
End Class