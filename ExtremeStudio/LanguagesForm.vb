Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Threading
Imports System.Deployment
Imports System.Net

<Localizable(False)>
Public Class LanguagesForm
    Private Sub LangsListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LangsListBox.MouseDoubleClick
        If LangsListBox.SelectedIndex <> -1 Then
            Acceptbtn.PerformClick()
        End If
    End Sub

    Private Sub Done()
        StartupForm.Show()
        Close()
    End Sub

    Private Sub Acceptbtn_Click(sender As Object, e As EventArgs) Handles Acceptbtn.Click
        If LangsListBox.SelectedIndex <> -1 Then
            If LangsListBox.SelectedItem = "English"
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("en")
                My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "\configs\lang.cfg", "en", False)
            ElseIf LangsListBox.SelectedItem = "Portuguese, Brazillian"Then
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("pt-BR")
                My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "\configs\lang.cfg", "pt-BR", False)
            ElseIf LangsListBox.SelectedItem = "Croatian"Then
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("hr")
                My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "\configs\lang.cfg", "hr", False)
            ElseIf LangsListBox.SelectedItem = "Spanish"Then
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("es")
                My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "\configs\lang.cfg", "es", False)
            ElseIf LangsListBox.SelectedItem = "Hungarian"Then
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("hu")
                My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "\configs\lang.cfg", "hu", False)
            End If
            Done()
        End If
    End Sub

    Private Sub LanguagesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'We will want to set/know the settings folder first.
        If My.Settings("SAVE_FOLDER") <> Nothing Then
            If Directory.Exists(My.Settings("SAVE_FOLDER")) Then
                MainForm.ApplicationFiles = My.Settings("SAVE_FOLDER")
            Else
                GoTo RESET_FOLDER
            End If
        Else
RESET_FOLDER:
            Dim fldr As New FolderBrowserDialog With {
.RootFolder = Environment.SpecialFolder.MyComputer,
.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
.Description = "Choose Folder To Save ExtremeStudio's Settings And Cache" + vbCrLf + "Can be a pre-existing folder with settings or cache already." + vbCrLf + "NOTE: A new folder will be created named ""ExtremeStudio"" inside the target folder."
            }
            If fldr.ShowDialog() = DialogResult.OK Then
                My.Settings("SAVE_FOLDER") = fldr.SelectedPath + "\ExtremeStudio"
                My.Settings.Save()
                MainForm.ApplicationFiles = My.Settings("SAVE_FOLDER")
                If Not Directory.Exists(MainForm.ApplicationFiles) Then Directory.CreateDirectory(MainForm.ApplicationFiles)
            Else
                Close()
            End If
        End If


        'CHECK IF NO SUPPORT ANYMORE
        Try
            Dim t as New WebClient()
            Dim out = t.DownloadString("https://github.com/Ahmad45123/ExtremeStudio/blob/master/isOldRunning.txt")
            If out = "false"
                MsgBox("ExtremeStudio got a MAJOR update which adds several new features and changes a bunch of stuff." + vbCrLf +"The changes include the way we handle updates so this version won't be getting any more updates. Make sure to visit the below link to download the newest version along with the newest updater." + vbCrLf + vbCrLf + "http://forum.sa-mp.com/showthread.php?t=608037", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information)
            End If
        Catch ex As WebException
            MsgBox("ExtremeStudio got a MAJOR update which adds several new features and changes a bunch of stuff." + vbCrLf +"The changes include the way we handle updates so this version won't be getting any more updates. Make sure to visit the below link to download the newest version along with the newest updater." + vbCrLf + vbCrLf + "http://forum.sa-mp.com/showthread.php?t=608037", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information)
        End Try


        If Not Directory.Exists(MainForm.ApplicationFiles + "\configs") Then Directory.CreateDirectory(MainForm.ApplicationFiles + "\configs")

        If File.Exists(MainForm.ApplicationFiles + "\configs\lang.cfg") Then
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(File.ReadAllText(MainForm.ApplicationFiles + "\configs\lang.cfg"))
            Done()
        End If
    End Sub
End Class