Imports System.ComponentModel

Public Class FolderBrowserDialog

    <Description("Enter the name of the control to be used to enter the data. [.Text will be used]"), Category("Common Properties")>
    Public Property TextControl As Control

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button.Click
        If FolderBrowser.ShowDialog = DialogResult.OK Then
            TextControl.Text = FolderBrowser.SelectedPath
        End If
    End Sub
End Class
