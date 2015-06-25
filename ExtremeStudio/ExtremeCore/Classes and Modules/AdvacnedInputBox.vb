Public Class AdvacnedInputBox
    Public Enum returnValue
        INPUT_RESULT_OK
        INPUT_RESULT_CANCEL
    End Enum

    Public resResult As returnValue
    Public resText As String

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
        resText = TextBox1.Text
        If resText = "" Then resResult = returnValue.INPUT_RESULT_CANCEL
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        resResult = returnValue.INPUT_RESULT_OK
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        resResult = returnValue.INPUT_RESULT_CANCEL
        Me.Close()
    End Sub
End Class