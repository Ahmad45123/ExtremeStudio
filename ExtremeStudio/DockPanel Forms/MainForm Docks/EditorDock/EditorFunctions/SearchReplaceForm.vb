Imports ExtremeStudio.My.Resources
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
            Return True
        ElseIf keyData = (Keys.Control Or Keys.Space)
            replaceReplaceBtn.PerformClick()
            Return True
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

        MsgBox(translations.SearchReplaceForm_searchCountBtn_Click_NumberItemsFound + numberOfTimes.ToString())
    End Sub

    Dim _isAlreadySearching As Boolean = False
    Public Sub SearchAndMark(searchText As String, Optional opposite As Boolean = False)
        'Only reset the settings if its new, or else: 
        'If its old, Just go with old settings to find literally next.
        If _isAlreadySearching = False Then
            ResetSettings()
        Else
            'Prepare For Next: 
            If opposite = True Then
                MainForm.CurrentScintilla.TargetStart = Math.Min(MainForm.CurrentScintilla.CurrentPosition, MainForm.CurrentScintilla.AnchorPosition)
                MainForm.CurrentScintilla.TargetEnd = 0
            Else
                MainForm.CurrentScintilla.TargetStart = Math.Max(MainForm.CurrentScintilla.CurrentPosition, MainForm.CurrentScintilla.AnchorPosition)
                MainForm.CurrentScintilla.TargetEnd = MainForm.CurrentScintilla.TextLength
            End If
        End If

        'No WHILE because we don't want to get all but just the next.
        If MainForm.CurrentScintilla?.SearchInTarget(searchText) <> -1 Then
            'First set the selection: 
            MainForm.CurrentScintilla?.SetSelection(MainForm.CurrentScintilla?.TargetStart, MainForm.CurrentScintilla?.TargetEnd)

            'Scroll to it: 
            MainForm.CurrentScintilla?.ScrollCaret()
            'Set the var to true: 
            _isAlreadySearching = True
        Else
            MsgBox(translations.SearchReplaceForm_SearchAndMark_ReachedEndDocument, MsgBoxStyle.Information)
            _isAlreadySearching = False
        End If
    End Sub
    Private Sub searchFindText_TextChanged(sender As Object, e As EventArgs) Handles searchFindText.TextChanged
        'New search is being done: 
        _isAlreadySearching = False
    End Sub
    Private Sub seachFindBtn_Click(sender As Object, e As EventArgs) Handles searchFindBtn.Click
        If searchFindText.Text = "" Then Exit Sub
        SearchAndMark(searchFindText.Text)
    End Sub

    Public travelList As New List(Of KeyValuePair(Of Integer, Integer))
    Private Sub searchFindAllBtn_Click(sender As Object, e As EventArgs) Handles searchFindAllBtn.Click
        If searchFindText.Text = "" Then Exit Sub

        ResetSettings()
        MainForm.CurrentScintilla.IndicatorClearRange(0, MainForm.CurrentScintilla.TextLength)
        travelList.Clear()

        Dim numberOfTimes As Integer = 0
        While MainForm.CurrentScintilla?.SearchInTarget(searchFindText.Text) <> -1
            numberOfTimes += 1

            'Mark the found.
            MainForm.CurrentScintilla.IndicatorCurrent = EditorDock.IndicatorIDs.IndicatorSearchItem
            MainForm.CurrentScintilla.IndicatorFillRange(MainForm.CurrentScintilla.TargetStart, MainForm.CurrentScintilla.TargetEnd - MainForm.CurrentScintilla.TargetStart)

            'Add to the travel list to enable CTRL+SHIFT+N fast-travelling.
            travelList.Add(New KeyValuePair(Of Integer, Integer)(MainForm.CurrentScintilla.TargetStart, MainForm.CurrentScintilla.TargetEnd))

            'Prepare For Next.
            MainForm.CurrentScintilla.TargetStart = MainForm.CurrentScintilla.TargetEnd 'Start from the last end and continue to end.
            MainForm.CurrentScintilla.TargetEnd = MainForm.CurrentScintilla.TextLength
        End While

        MsgBox(translations.SearchReplaceForm_searchCountBtn_Click_NumberItemsFound + numberOfTimes.ToString() + vbCrLf + vbCrLf + translations.SearchReplaceForm_searchFindAllBtn_Click_UseKeysForTravel)
    End Sub

    Private Sub replaceFindNextBtn_Click(sender As Object, e As EventArgs) Handles replaceFindNextBtn.Click
        If replaceFindText.Text = "" Then Exit Sub
        SearchAndMark(replaceFindText.Text)
    End Sub

    Private Sub replaceFindText_replaceReplaceText_TextChanged(sender As Object, e As EventArgs) Handles replaceFindText.TextChanged, replaceReplaceText.TextChanged
        _isAlreadySearching = False
    End Sub

    Private Sub replaceReplaceBtn_Click(sender As Object, e As EventArgs) Handles replaceReplaceBtn.Click
        If _isAlreadySearching Then
            If searchRegexRadio.Checked Then
                MainForm.CurrentScintilla.ReplaceTargetRe(replaceReplaceText.Text)
            Else
                MainForm.CurrentScintilla.ReplaceTarget(replaceReplaceText.Text)
            End If
            replaceFindNextBtn.PerformClick()
        End If
    End Sub

    Private Sub replaceReplaceAllBtn_Click(sender As Object, e As EventArgs) Handles replaceReplaceAllBtn.Click
        If replaceFindText.Text = "" Then Exit Sub

        ResetSettings()

        Dim numberOfTimes As Integer = 0
        While MainForm.CurrentScintilla?.SearchInTarget(replaceFindText.Text) <> -1
            numberOfTimes += 1

            'Replace
            If searchRegexRadio.Checked Then
                MainForm.CurrentScintilla.ReplaceTargetRe(replaceReplaceText.Text)
            Else
                MainForm.CurrentScintilla.ReplaceTarget(replaceReplaceText.Text)
            End If

            'Prepare For Next.
            MainForm.CurrentScintilla.TargetStart = MainForm.CurrentScintilla.TargetEnd 'Start from the last end and continue to end.
            MainForm.CurrentScintilla.TargetEnd = MainForm.CurrentScintilla.TextLength
        End While

        MsgBox(translations.SearchReplaceForm_replaceReplaceAllBtn_Click_NumberItemsReplaced + numberOfTimes.ToString())
    End Sub
End Class