Imports System.Net
Imports System.Xml
Imports System.IO
Imports System.IO.Compression


Public Class StartupForm

    Private Sub StartupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Create needed folders and files.
        If Not My.Computer.FileSystem.DirectoryExists(Application.StartupPath + "/sampPackages") Then
            My.Computer.FileSystem.CreateDirectory(Application.StartupPath + "/sampPackages")
        End If

        'Load samp versions into list.
        Dim str As New List(Of String)
        verListBox.Tag = str
        If My.Computer.Network.IsAvailable Then 'Download latest from internet if there is internet.
            Dim webClient As New WebClient
            Dim xmlFile As New XmlDocument()
            Dim fileText As String = webClient.DownloadString("http://5.231.50.158/ExtremeStudio/serverPackages.xml")
            xmlFile.LoadXml(fileText)

            For Each cs As XmlNode In xmlFile.SelectNodes("serverPackages/samp")
                Dim newList As Integer = verListBox.Items.Add(cs("name").InnerText)
                verListBox.Tag.Add(cs("download").InnerText)
            Next
        Else 'Load existing from folder.
            'TODO: add code here for loading servers from folder.
        End If

    End Sub

    Private Sub nameTextBox_TextChanged(sender As Object, e As EventArgs) Handles nameTextBox.TextChanged
        If nameTextBox.Text = "" Then Exit Sub

        'Only a-zA-Z0-9.
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
                If My.Computer.FileSystem.FileExists(Application.StartupPath + "/serverPackages/" + verListBox.SelectedItem + ".zip") Then 'check if that version is existing
                    ZipFile.ExtractToDirectory(Application.StartupPath + "/serverPackages/" + verListBox.SelectedItem + ".zip", locTextBox.Text) 'Extract the zip to project folder.

                Else 'Download from net if not exist.
                    Dim client As New WebClient 'For downloading the selected file.
                    client.DownloadFile(verListBox.Tag(verListBox.SelectedIndex), My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip") 'Download the zip file.
                    ZipFile.ExtractToDirectory(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip", locTextBox.Text) 'Extract the zip.
                    My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip", Application.StartupPath + "/serverPackages/" + verListBox.SelectedItem + ".zip") 'Copy the file to be used instead of downloading
                    My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Temp + "/" + nameTextBox.Text + ".zip") 'Delete the file from temp.

                End If

            Else
                MsgBox("You haven't selected a SAMP version to use.")
            End If
        Else
            MsgBox("That directory doesn't exist or contains a project.")
        End If
    End Sub
End Class