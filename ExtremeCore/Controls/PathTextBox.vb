Imports System.Windows.Forms

Public Class PathTextBox
    Inherits TextBox

    Public Enum PathTypes
        Folder
        FileSave
        FileOpen
    End Enum
    Public Property PathType As PathTypes

    ''' <summary>
    ''' Will be used for .Description in folders and as .Title for Files.
    ''' </summary>
    ''' <returns></returns>
    Public Property Description As String

    ''' <summary>
    ''' Only useable if PathType is set to FileSave or FileOpen
    ''' </summary>
    ''' <returns></returns>
    Public Property Filter As String

    Private Sub i_OnDoubleClick(sender As Object, e As EventArgs) Handles MyBase.MouseDoubleClick
        If PathType = PathTypes.Folder Then
            Dim dlg As New FolderBrowserDialog()
            dlg.Description = Description
            If dlg.ShowDialog() = DialogResult.OK Then
                sender.Text = dlg.SelectedPath
            End If

        ElseIf PathType = PathTypes.FileOpen Then
            Dim dlg As New OpenFileDialog()
            dlg.Title = Description
            dlg.Filter = Filter
            If dlg.ShowDialog() = DialogResult.OK Then
                sender.Text = dlg.FileName
            End If

        ElseIf PathType = PathTypes.FileSave Then
            Dim dlg As New SaveFileDialog()
            dlg.Title = Description
            dlg.Filter = Filter
            If dlg.ShowDialog() = DialogResult.OK Then
                sender.Text = dlg.FileName
            End If

        End If
    End Sub

End Class
