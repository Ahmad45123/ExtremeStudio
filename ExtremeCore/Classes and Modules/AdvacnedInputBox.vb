Public Class AdvacnedInputBox
    Public Enum ReturnValue
        InputResultOk
        InputResultCancel
    End Enum

    Public ResResult As ReturnValue
    Public ResText As String

    Public Sub New(title As String, message As String, Optional cancelButton As String = "&Cancel", Optional okButton As String = "&Ok", Optional defaultText As String = "")

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = title
        Label1.Text = message
        Button1.Text = cancelButton
        Button2.Text = okButton
        TextBox1.Text = defaultText
        Me.ShowDialog()
        ResText = TextBox1.Text
        If ResText = "" Then ResResult = ReturnValue.InputResultCancel
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ResResult = ReturnValue.InputResultOk
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ResResult = ReturnValue.InputResultCancel
        Me.Close()
    End Sub
End Class