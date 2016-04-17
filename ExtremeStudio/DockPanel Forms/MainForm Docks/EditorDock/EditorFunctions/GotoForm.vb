Public Class GotoForm
    Private isClosing as Boolean = False
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        isClosing = True
        Me.Close()
    End Sub

    Private Sub linenumberRadio_CheckedChanged(sender As Object, e As EventArgs) Handles linenumberRadio.CheckedChanged
        theLabel.Text = "Line Number: "
        maxLabel.Text = "Maximum: " + MainForm.CurrentScintilla?.Lines.Count.ToString()
        curLabel.Text = "Current: " + (MainForm.CurrentScintilla?.CurrentLine + 1).ToString()
        valueTextBox.Select()
    End Sub

    Private Sub positionRadio_CheckedChanged(sender As Object, e As EventArgs) Handles positionRadio.CheckedChanged
        theLabel.Text = "Position: "
        maxLabel.Text = "Maximum: " + MainForm.CurrentScintilla?.Lines(MainForm.CurrentScintilla?.Lines.Count - 1).EndPosition.ToString()
        curLabel.Text = "Current: " + (MainForm.CurrentScintilla?.CurrentPosition + 1).ToString()
        valueTextBox.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        if valueTextBox.Text = "" Or IsNumeric(valueTextBox.Text) = False Then Exit Sub

        If linenumberRadio.Checked then
            if Convert.ToInt32(valueTextBox.Text) > 0 And Convert.ToInt32(valueTextBox.Text) <= MainForm.CurrentScintilla.Lines.Count then
                MainForm.CurrentScintilla.Lines(Convert.ToInt32(valueTextBox.Text) - 1).Goto()
                isClosing = True
                Close()

            Else
                MsgBox("Please check your value, It seems to be wrong.")
            End If 

        Else If positionRadio.Checked Then
                if Convert.ToInt32(valueTextBox.Text) > 0 And Convert.ToInt32(valueTextBox.Text) <= MainForm.CurrentScintilla.Lines(MainForm.CurrentScintilla.Lines.Count - 1).EndPosition then
                MainForm.CurrentScintilla.GotoPosition(Convert.ToInt32(valueTextBox.Text) - 1)
                isClosing = True
                Close()
                
            Else
                MsgBox("Please check your value, It seems to be wrong.")
            End If

        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(Byref msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            isClosing = True
            Close()
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub GotoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        linenumberRadio_CheckedChanged(Me, Nothing)
    End Sub

    Private Sub GotoForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Opacity = 1.00
    End Sub
    Private Sub GotoForm_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        If isClosing = False Then Opacity = 0.50
    End Sub

    Private Sub GotoForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        isClosing = True
    End Sub
End Class