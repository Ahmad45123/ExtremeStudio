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

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        If e.TabPageIndex = 0 Then
            searchFindText.Select()
            AcceptButton = searchFindBtn
        ElseIf e.TabPageIndex = 1 Then
            replaceFindText.Select()
            AcceptButton = replaceFindNextBtn
        End If
    End Sub

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
        If searchFindText.Text = "" Then Exit Sub

        ResetSettings()

        Dim numberOfTimes As Integer = 0
        While MainForm.CurrentScintilla?.SearchInTarget(searchFindText.Text) <> -1
            numberOfTimes += 1

            'Prepare For Next.
            MainForm.CurrentScintilla.TargetStart = MainForm.CurrentScintilla.TargetEnd 'Start from the last end and continue to end.
            MainForm.CurrentScintilla.TargetEnd = MainForm.CurrentScintilla.TextLength
        End While

        MsgBox("Number of items found are: " + numberOfTimes.ToString())
    End Sub

    Dim isAlreadySearching As Boolean = False
    Private Sub searchFindText_TextChanged(sender As Object, e As EventArgs) Handles searchFindText.TextChanged
        'New search is being done: 
        isAlreadySearching = False
    End Sub
    Private Sub seachFindBtn_Click(sender As Object, e As EventArgs) Handles searchFindBtn.Click
        If searchFindText.Text = "" Then Exit Sub

        'Only reset the settings if its new, or else: 
        'If its old, Just go with old settings to find literally next.
        If isAlreadySearching = False Then ResetSettings()

        'No WHILE because we don't want to get all but just the next.
        If MainForm.CurrentScintilla?.SearchInTarget(searchFindText.Text) <> -1
            'First set the selection: 
            MainForm.CurrentScintilla?.SetSelection(MainForm.CurrentScintilla?.TargetStart, MainForm.CurrentScintilla?.TargetEnd)
            'Scroll to it: 
            MainForm.CurrentScintilla?.ScrollCaret()
            'Prepare For Next.
            MainForm.CurrentScintilla.TargetStart = MainForm.CurrentScintilla.TargetEnd 'Start from the last end and continue to end.
            MainForm.CurrentScintilla.TargetEnd = MainForm.CurrentScintilla.TextLength
            'Set the var to true: 
            isAlreadySearching = True
        Else
            MsgBox("Reached End Of Document, Resetting.", MsgBoxStyle.Information)
            isAlreadySearching = False
            seachFindBtn_Click(Me, Nothing)
        End If
    End Sub
End Class