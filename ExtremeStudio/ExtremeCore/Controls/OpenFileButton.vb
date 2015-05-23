Imports System.Windows.Forms

Public Class OpenFileButton
    Public Property TargetControl As Control
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            TargetControl.Text = OpenFileDialog.FileName
        End If
    End Sub
End Class
