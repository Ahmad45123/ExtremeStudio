Imports System.Drawing

Public Class ColorChoose

    Public Event onColorChange()

    Public Property Color As Color
        Set(value As Color)
            PictureBox1.BackColor = value
        End Set
        Get
            Return PictureBox1.BackColor
        End Get
    End Property

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If ColorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox1.BackColor = ColorDialog.Color

            RaiseEvent onColorChange()
        End If
    End Sub
End Class
