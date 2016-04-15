Public Class GotoForm
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub linenumberRadio_CheckedChanged(sender As Object, e As EventArgs) Handles linenumberRadio.CheckedChanged
        theLabel.Text = "Line Number: "
        maxLabel.Text = "Maximum: " + MainForm.CurrentScintilla.Lines.Count.ToString()
        curLabel.Text = "Current: " + MainForm.CurrentScintilla.CurrentLine.ToString()
    End Sub

    Private Sub positionRadio_CheckedChanged(sender As Object, e As EventArgs) Handles positionRadio.CheckedChanged
        theLabel.Text = "Position: "
        maxLabel.Text = "Maximum: " + MainForm.CurrentScintilla.Lines(MainForm.CurrentScintilla.Lines.Count - 1).EndPosition.ToString()
        curLabel.Text = "Current: " + MainForm.CurrentScintilla.CurrentPosition.ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If linenumberRadio.Checked then
            if Char.IsNumber(valueTextBox.Text) And Convert.ToInt32(valueTextBox.Text) > 0 And Convert.ToInt32(valueTextBox.Text) <= MainForm.CurrentScintilla.Lines.Count then
                MainForm.CurrentScintilla.Lines(Convert.ToInt32(valueTextBox.Text) - 1).Goto()
                Me.Close()

            Else
                MsgBox("Please check your value, It seems to be wrong.")
            End If 

        Else If positionRadio.Checked Then
                if Char.IsNumber(valueTextBox.Text) And Convert.ToInt32(valueTextBox.Text) > 0 And Convert.ToInt32(valueTextBox.Text) <= MainForm.CurrentScintilla.Lines(MainForm.CurrentScintilla.Lines.Count - 1).EndPosition then
                MainForm.CurrentScintilla.GotoPosition(Convert.ToInt32(valueTextBox.Text) - 1)
                Me.Close()

            Else
                MsgBox("Please check your value, It seems to be wrong.")
            End If

        End If
    End Sub
End Class