Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Threading

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
        If Not Directory.Exists(MainForm.ApplicationFiles + "\configs") Then Directory.CreateDirectory(MainForm.ApplicationFiles + "\configs")

        If File.Exists(MainForm.ApplicationFiles + "\configs\lang.cfg") Then
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(File.ReadAllText(MainForm.ApplicationFiles + "\configs\lang.cfg"))
            Done()
        End If
    End Sub
End Class