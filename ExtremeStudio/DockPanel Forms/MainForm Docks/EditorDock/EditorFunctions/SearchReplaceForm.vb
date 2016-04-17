Public Class SearchReplaceForm

    #Region "General"
    Private isClosing as Boolean = False
    Private Sub findCloseBtn_Click(sender As Object, e As EventArgs) Handles findCloseBtn.Click, replaceCloseBtn.Click
        isClosing = True
        Me.Close()
    End Sub
    Protected Overrides Function ProcessCmdKey(Byref msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            isClosing = True
            Close()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    Private Sub SearchReplaceForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Opacity = 1.00
    End Sub
    Private Sub SearchReplaceForm_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If isClosing = False Then Opacity = 0.50
    End Sub
    Private Sub SearchReplaceForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        isClosing = True
    End Sub
    #End Region


End Class