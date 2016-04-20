Imports ScintillaNET

Public Class SearchReplaceForm

#Region "General"
    Private isClosing As Boolean = False
    Private Sub findCloseBtn_Click(sender As Object, e As EventArgs) Handles findCloseBtn.Click, replaceCloseBtn.Click
        isClosing = True
        Me.Close()
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
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

    Sub ResetSettings()
        'Set targets.
        If inSelCheck.Checked = False Then
            MainForm.CurrentScintilla?.TargetWholeDocument()
        Else
            MainForm.CurrentScintilla?.TargetFromSelection()
        End If

        'Set configs.
        MainForm.CurrentScintilla.SearchFlags = SearchFlags.None
        If searchNormalRadio.Checked = False And searchRegexRadio.Checked = True Then
            MainForm.CurrentScintilla.SearchFlags = SearchFlags.Regex
        End If
        If matchWholeWordCheck.Checked Then
            MainForm.CurrentScintilla.SearchFlags = MainForm.CurrentScintilla.SearchFlags Or SearchFlags.WholeWord
        End If
        If matchCaseCheck.Checked Then
            MainForm.CurrentScintilla.SearchFlags = MainForm.CurrentScintilla.SearchFlags Or SearchFlags.MatchCase
        End If
    End Sub

    Private Sub searchCountBtn_Click(sender As Object, e As EventArgs) Handles searchCountBtn.Click
        ResetSettings()

        Dim numberOfTimes As Integer = 0
        While MainForm.CurrentScintilla?.SearchInTarget(searchFindText.Text) <> -1
            numberOfTimes += 1

            MainForm.CurrentScintilla.TargetStart = MainForm.CurrentScintilla.TargetEnd 'Start from the last end and continue to end.
            MainForm.CurrentScintilla.TargetEnd = MainForm.CurrentScintilla.TextLength
        End While

        MsgBox("Number of items found are: " + numberOfTimes.ToString())
    End Sub

    Private Sub seachFindBtn_Click(sender As Object, e As EventArgs) Handles seachFindBtn.Click

    End Sub
End Class