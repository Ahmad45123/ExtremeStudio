Imports System.Net
Imports System.Xml
Imports System.IO
Imports System.IO.Compression

Public Class StartupForm

    Dim versionHandler As New versionHandler

    Private Sub StartupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Create needed folders and files.
        If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath + "/cache") Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "/cache")
        End If

        'Load samp versions into list.
        Dim str As New List(Of String)
        verListBox.Tag = str
        If ExtremeCore.isNetAvailable() Then 'Download latest from internet if there is internet.
            Dim webClient As New WebClient
            Dim xmlFile As New XmlDocument()
            Dim fileText As String = webClient.DownloadString("http://5.231.50.158/ExtremeStudio/serverPackages.xml")
            xmlFile.LoadXml(fileText)

            For Each cs As XmlNode In xmlFile.SelectNodes("serverPackages/samp")
                Dim newList As Integer = verListBox.Items.Add(cs("name").InnerText)
                verListBox.Tag.Add(cs("download").InnerText)
            Next
        Else 'Load existing from folder.
            For Each pth As String In Directory.GetFiles(Application.StartupPath + "/cache/serverPackages")
                Dim newList As Integer = verListBox.Items.Add(Path.GetFileNameWithoutExtension(pth))
                verListBox.Tag.Add(pth)
            Next
        End If

    End Sub

    Private Sub nameTextBox_TextChanged(sender As Object, e As EventArgs) Handles nameTextBox.TextChanged
        If nameTextBox.Text = "" Then Exit Sub

        If ExtremeCore.FilenameIsOK(nameTextBox.Text) Then
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
                If My.Computer.FileSystem.FileExists(Application.StartupPath + "/cache/serverPackages/" + verListBox.SelectedItem + ".zip") Then 'check if that version is existing
                    ZipFile.ExtractToDirectory(Application.StartupPath + "/cache/serverPackages/" + verListBox.SelectedItem + ".zip", locTextBox.Text) 'Extract the zip to project folder.
                Else 'Download from net if not exist.
                    Dim client As New WebClient 'For downloading the selected file.
                    client.DownloadFile(verListBox.Tag(verListBox.SelectedIndex), My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip") 'Download the zip file.
                    ZipFile.ExtractToDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip", locTextBox.Text) 'Extract the zip.
                    My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip", Application.StartupPath + "/cache/serverPackages/" + verListBox.SelectedItem + ".zip") 'Copy the file to be used instead of downloading
                    My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip") 'Delete the file from temp.
                End If
                My.Computer.FileSystem.WriteAllText(locTextBox.Text + "/gamemodes/" + nameTextBox.Text + ".pwn", "", False)
                MainForm.currentProject.projectName = nameTextBox.Text
                MainForm.currentProject.projectPath = locTextBox.Text
                MainForm.currentProject.projectVersion = versionHandler.currentVersion
                MainForm.currentProject.SaveInfo() 'Write the default extremeStudio config.
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

        If ExtremeCore.isValidExtremeProject(pathTextBox.Text) Then
            MainForm.currentProject.projectPath = pathTextBox.Text
            MainForm.currentProject.ReadInfo()
            If My.Computer.FileSystem.FileExists(pathTextBox.Text + "/gamemodes/" + MainForm.currentProject.projectName + ".pwn") Then
                projectName.Text = MainForm.currentProject.projectName

                Dim projVersion As Integer = MainForm.currentProject.projectVersion
                Dim progVersion As Integer = versionHandler.currentVersion

                If projVersion = progVersion Then
                    projectVersion.Text = "Project version is the same as ExtremeStudio's version, No conversation is needed."
                    loadProjectBtn.Enabled = True
                ElseIf projVersion < progVersion Then
                    projectVersion.Text = "Project older then ExtremeStudio, Conversion will be done and won't be able to work on older versions again."
                    loadProjectBtn.Enabled = True
                ElseIf projVersion > progVersion Then
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
        MainForm.Show()
        Me.Hide()
    End Sub
End Class