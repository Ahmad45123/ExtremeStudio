Imports System.Net
Imports System.Xml
Imports System.IO
Imports System.IO.Compression
Imports ExtremeCore
Imports Newtonsoft.Json

Public Class StartupForm

    ''' <summary>
    ''' To know whether to extract the SQL files or not.
    ''' </summary>
    Public IsFirst As Boolean = True

    Private _isClosedProgram As Boolean = False

#Region "RecentCode"
    Public Recent As New List(Of String)
    Const MaxListItems = 30
    Public Sub AddNewRecent(path As String)
        For Each str As String In Recent
            If str = path Then
                Recent.Remove(str)
                Exit For
            End If
        Next
        Recent.Insert(0, path) 'Inset it at the very start
        If Recent.Count - 1 = MaxListItems Then 'Remove the new added stuff
            Recent.RemoveAt(MaxListItems)
        End If
        My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "/configs/recent.json", JsonConvert.SerializeObject(Recent), False)
    End Sub

    Public Sub RemoveRecent(path As String)
        For Each str As String In Recent
            If str = path Then
                Recent.Remove(str)
                Exit For
            End If
        Next
        My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "/configs/recent.json", JsonConvert.SerializeObject(Recent), False)
    End Sub
#End Region

    Dim _versionHandler As New VersionHandler

    Private Sub StartupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'If the interop files don't exist, Extract the files.
        If IsFirst And (Not My.Computer.FileSystem.FileExists(Application.StartupPath + "/x64/SQLite.Interop.dll") Or Not My.Computer.FileSystem.FileExists(MainForm.ApplicationFiles + "/x86/SQLite.Interop.dll")) Then
            'Remove old.
            If My.Computer.FileSystem.FileExists(Application.StartupPath + "/x64/SQLite.Interop.dll") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath + "/x64/SQLite.Interop.dll")
            If My.Computer.FileSystem.FileExists(Application.StartupPath + "/x86/SQLite.Interop.dll") Then My.Computer.FileSystem.DeleteFile(Application.StartupPath + "/x86/SQLite.Interop.dll")

            'Extract New
            My.Computer.FileSystem.WriteAllBytes(Application.StartupPath + "/interop.zip", My.Resources.SQLite_Interop, False) 'Write the file.
            ExtremeCore.FastZipUnpack(Application.StartupPath + "/interop.zip", Application.StartupPath) 'Extract it.
            My.Computer.FileSystem.DeleteFile(Application.StartupPath + "/interop.zip") 'Delete the temp file.
        End If

        'Create needed folders and files.
        If Not My.Computer.FileSystem.DirectoryExists(MainForm.ApplicationFiles + "/cache") Then
            My.Computer.FileSystem.CreateDirectory(MainForm.ApplicationFiles + "/cache")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(MainForm.ApplicationFiles + "/cache/serverPackages") Then
            My.Computer.FileSystem.CreateDirectory(MainForm.ApplicationFiles + "/cache/serverPackages")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(MainForm.ApplicationFiles + "/cache/includes") Then
            My.Computer.FileSystem.CreateDirectory(MainForm.ApplicationFiles + "/cache/includes")
        End If

        If Not My.Computer.FileSystem.DirectoryExists(MainForm.ApplicationFiles + "/configs") Then
            My.Computer.FileSystem.CreateDirectory(MainForm.ApplicationFiles + "/configs")
            My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "/configs/recent.json", "", False)
        End If

        'Load all the recent.
        If My.Computer.FileSystem.FileExists(MainForm.ApplicationFiles + "/configs/recent.json") Then
            Try
                Recent = JsonConvert.DeserializeObject(Of List(Of String))(My.Computer.FileSystem.ReadAllText(MainForm.ApplicationFiles + "/configs/recent.json"))
            Catch ex As Exception
            End Try
        End If

        'Load samp versions into list.
        Dim str As New List(Of String)
        verListBox.Tag = str
        If ExtremeCore.IsNetAvailable() Then 'Download latest from internet if there is internet.
            Dim webClient As New WebClient
            Dim xmlFile As New XmlDocument()
            Dim fileText As String = webClient.DownloadString("http://johnymac.github.io/esfiles/serverPackages.xml")
            xmlFile.LoadXml(fileText)

            For Each cs As XmlNode In xmlFile.SelectNodes("serverPackages/samp")
                Dim newList As Integer = verListBox.Items.Add(cs("name").InnerText)
                verListBox.Tag.Add(cs("download").InnerText)
            Next
        Else 'Load existing from folder.
            For Each pth As String In Directory.GetFiles(MainForm.ApplicationFiles + "/cache/serverPackages")
                Dim newList As Integer = verListBox.Items.Add(Path.GetFileNameWithoutExtension(pth))
                verListBox.Tag.Add(pth)
            Next
        End If
    End Sub

    Private Sub nameTextBox_TextChanged(sender As Object, e As EventArgs) Handles nameTextBox.TextChanged
        If nameTextBox.Text = "" Then Exit Sub

        If FilenameIsOk(nameTextBox.Text) Then
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
                If My.Computer.FileSystem.FileExists(MainForm.ApplicationFiles + "/cache/serverPackages/" + verListBox.SelectedItem + ".zip") Then 'check if that version is existing
                    FastZipUnpack(MainForm.ApplicationFiles + "/cache/serverPackages/" + verListBox.SelectedItem + ".zip", locTextBox.Text) 'Extract the zip to project folder.
                Else 'Download from net if not exist.
                    Dim client As New WebClient 'For downloading the selected file.
                    client.DownloadFile(verListBox.Tag(verListBox.SelectedIndex), My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip") 'Download the zip file.
                    FastZipUnpack(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip", locTextBox.Text) 'Extract the zip.
                    My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip", MainForm.ApplicationFiles + "/cache/serverPackages/" + verListBox.SelectedItem + ".zip") 'Copy the file to be used instead of downloading
                    My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip") 'Delete the file from temp.
                End If
                My.Computer.FileSystem.WriteAllText(locTextBox.Text + "/gamemodes/" + nameTextBox.Text + ".pwn", My.Resources.newfileTemplate, False)
                MainForm.CurrentProject.ProjectName = nameTextBox.Text
                MainForm.CurrentProject.ProjectPath = locTextBox.Text
                MainForm.CurrentProject.ProjectVersion = _versionHandler.CurrentVersion
                MainForm.CurrentProject.CreateTables() 'Create the tables of the db.
                MainForm.CurrentProject.SaveInfo() 'Write the default extremeStudio config.
                MainForm.CurrentProject.CopyGlobalConfig()
                AddNewRecent(MainForm.CurrentProject.ProjectPath) 'Add it to the recent list.
                MainForm.Show()
                _isClosedProgram = True : Close()
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

        If IsValidExtremeProject(pathTextBox.Text) Then
            MainForm.CurrentProject.ProjectPath = pathTextBox.Text
            MainForm.CurrentProject.ReadInfo()
            If My.Computer.FileSystem.FileExists(pathTextBox.Text + "/gamemodes/" + MainForm.CurrentProject.ProjectName + ".pwn") Then
                projectName.Text = MainForm.CurrentProject.ProjectName

                Dim projVersion As String = MainForm.CurrentProject.ProjectVersion
                Dim progVersion As String = _versionHandler.CurrentVersion

                Dim versionCompare As VersionReader.CompareVersionResult = VersionReader.CompareVersions(projVersion, progVersion)
                If versionCompare = VersionReader.CompareVersionResult.VersionSame Then
                    projectVersion.Text = "Project version is the same as ExtremeStudio's version, No converion is needed."
                    loadProjectBtn.Enabled = True
                ElseIf versionCompare = VersionReader.CompareVersionResult.VersionNew Then
                    projectVersion.Text = "Project older then ExtremeStudio, Conversion will be done however it may bug with older versions so its recommended to not try."
                    loadProjectBtn.Enabled = True
                ElseIf versionCompare = VersionReader.CompareVersionResult.VersionOld Then
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
        AddNewRecent(MainForm.CurrentProject.ProjectPath) 'Add it to the recent list.
        _versionHandler.DoIfUpdateNeeded(MainForm.CurrentProject)
        MainForm.Show()
        _isClosedProgram = True : Close()
    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        If e.TabPageIndex = 2 Then
            recentListBox.Items.Clear()

            'Get recent list.
            For Each str As String In Recent
                If str Is Nothing Then Continue For
                recentListBox.Items.Add(str)
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

    Private Sub StartupForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If _isClosedProgram = False Then
            Application.Exit()
        End If
    End Sub

    Private Sub OpenGlobalSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenGlobalSettingsToolStripMenuItem.Click
        SettingsForm.IsGlobal = True
        SettingsForm.ShowDialog()
    End Sub
End Class