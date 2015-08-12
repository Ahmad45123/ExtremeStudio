Imports ScintillaNET
Imports ExtremeParser
Imports System.Text.RegularExpressions

Public Class EditorDock

#Region "TextChangedDelayed Setup Code"
    Private WithEvents idleTimer As New Timer
    Public Event TextChangedDelayed As EventHandler
    Private Sub idleTimer_Tick(sender As Object, e As EventArgs) Handles idleTimer.Tick
        idleTimer.Stop()
        RaiseEvent TextChangedDelayed(Editor, EventArgs.Empty)
    End Sub
    Private Sub TextChangedDelayed_Editor_TextChanged(sender As Object, e As EventArgs) Handles Editor.TextChanged
        idleTimer.Stop()
        idleTimer.Start()
    End Sub
#End Region
    Private Sub scintilla_TextChangedDelayed(sender As Object, e As EventArgs)
        If RefreshWorker.IsBusy = False Then RefreshWorker.RunWorkerAsync({Editor.Tag, MainForm.currentProject.projectPath}) : MainForm.statusLabel.Text = "Parsing Code."
    End Sub

#Region "CodeIndent Handlers"
    Const SCI_SETLINEINDENTATION As Integer = 2126
    Const SCI_GETLINEINDENTATION As Integer = 2127
    Private Sub SetIndent(scin As ScintillaNET.Scintilla, line As Integer, indent As Integer)
        scin.DirectMessage(SCI_SETLINEINDENTATION, New IntPtr(line), New IntPtr(indent))
    End Sub
    Private Function GetIndent(scin As ScintillaNET.Scintilla, line As Integer) As Integer
        Return (scin.DirectMessage(SCI_GETLINEINDENTATION, New IntPtr(line), Nothing).ToInt32)
    End Function
#End Region

    Private maxLineNumberCharLength As Integer
    Private Sub Editor_TextChanged(sender As Object, e As EventArgs) Handles Editor.TextChanged
        Dim maxLineNumberCharLength = Editor.Lines.Count.ToString().Length
        If maxLineNumberCharLength = Me.maxLineNumberCharLength Then
            Return
        End If

        Const padding As Integer = 2
        Editor.Margins(0).Width = Editor.TextWidth(Style.LineNumber, New String("9"c, maxLineNumberCharLength + 1)) + padding
        Me.maxLineNumberCharLength = maxLineNumberCharLength
    End Sub

    Private Shared Function IsBrace(c As Integer) As Boolean
        Select Case c
            Case AscW("("), AscW(")"), AscW("["), AscW("]"), AscW("{"), AscW("}")
                Return True
        End Select
        Return False
    End Function


    Enum indicatorIDs
        INDICATOR_PARSERERROR = 50 'Start from 50
        INDICATOR_CODEERROR
        INDICATOR_PHPDOCERROR
    End Enum
    Private Sub EditorDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TextChangedDelayed Event
        AddHandler TextChangedDelayed, AddressOf scintilla_TextChangedDelayed
        With idleTimer
            .Enabled = True
            .Interval = 1000
        End With

        'Set-Up the syntax highlighting.
        Editor.StyleResetDefault()
        Editor.Styles(Style.[Default]).Font = "Consolas"
        Editor.Styles(Style.[Default]).Size = 10
        Editor.StyleClearAll()

        'Set the code part styles.
        Editor.Styles(Style.Cpp.[Default]).ForeColor = Color.Black
        Editor.Styles(Style.Cpp.Comment).ForeColor = Color.FromArgb(0, 128, 0)
        Editor.Styles(Style.Cpp.CommentLine).ForeColor = Color.FromArgb(0, 128, 0)
        Editor.Styles(Style.Cpp.CommentLineDoc).ForeColor = Color.Red
        Editor.Styles(Style.Cpp.Number).ForeColor = Color.Olive
        Editor.Styles(Style.Cpp.Word).ForeColor = Color.Blue
        Editor.Styles(Style.Cpp.Word2).ForeColor = Color.CadetBlue
        Editor.Styles(Style.Cpp.[String]).ForeColor = Color.FromArgb(163, 21, 21)
        Editor.Styles(Style.Cpp.Character).ForeColor = Color.FromArgb(163, 21, 21)
        Editor.Styles(Style.Cpp.Verbatim).ForeColor = Color.FromArgb(163, 21, 21)
        Editor.Styles(Style.Cpp.StringEol).BackColor = Color.Pink
        Editor.Styles(Style.Cpp.[Operator]).ForeColor = Color.Purple
        Editor.Styles(Style.Cpp.Preprocessor).ForeColor = Color.Maroon
        Editor.Styles(Style.BraceLight).BackColor = Color.LightGray
        Editor.Styles(Style.BraceLight).ForeColor = Color.BlueViolet
        Editor.Styles(Style.BraceBad).ForeColor = Color.Red
        Editor.IndentationGuides = IndentView.LookBoth

        Editor.Lexer = Lexer.Cpp

        'Set the folding configs.
        Editor.SetProperty("fold", "1")
        Editor.SetProperty("fold.compact", "0")

        ' Configure a margin to display folding symbols.
        Editor.Margins(2).Type = MarginType.Symbol
        Editor.Margins(2).Mask = Marker.MaskFolders
        Editor.Margins(2).Sensitive = True
        Editor.Margins(2).Width = 20

        ' Set colors for all folding markers.
        For i As Integer = 25 To 31
            Editor.Markers(i).SetForeColor(SystemColors.ControlLightLight)
            Editor.Markers(i).SetBackColor(SystemColors.ControlDark)
        Next

        ' Configure folding markers with respective symbols.
        Editor.Markers(Marker.Folder).Symbol = MarkerSymbol.BoxPlus
        Editor.Markers(Marker.FolderOpen).Symbol = MarkerSymbol.BoxMinus
        Editor.Markers(Marker.FolderEnd).Symbol = MarkerSymbol.BoxPlusConnected
        Editor.Markers(Marker.FolderMidTail).Symbol = MarkerSymbol.TCorner
        Editor.Markers(Marker.FolderOpenMid).Symbol = MarkerSymbol.BoxMinusConnected
        Editor.Markers(Marker.FolderSub).Symbol = MarkerSymbol.VLine
        Editor.Markers(Marker.FolderTail).Symbol = MarkerSymbol.LCorner

        ' Enable automatic folding.
        Editor.AutomaticFold = (AutomaticFold.Show Or AutomaticFold.Click Or AutomaticFold.Change)

        'Setup the indicators
        Editor.Indicators(indicatorIDs.INDICATOR_PARSERERROR).Style = IndicatorStyle.Squiggle
        Editor.Indicators(indicatorIDs.INDICATOR_PARSERERROR).ForeColor = Color.DarkGreen
        Editor.Indicators(indicatorIDs.INDICATOR_PARSERERROR).Under = True

        'Set the PAWN language keywords.
        Editor.SetKeywords(0, "break case enum continue do else false for goto public stock if is new null return sizeof switch true while forward native")
    End Sub

    Public codeParts As Parser
    Private Sub RefreshWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles RefreshWorker.DoWork
        If Editor.IsHandleCreated Then
            e.Result = New Parser(e.Argument(0), e.Argument(1))
        End If
    End Sub

    Private Sub RefreshWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshWorker.RunWorkerCompleted
        MainForm.statusLabel.Text = "Idle."
        ErrorsDock.parserErrors.Rows.Clear()

        codeParts = DirectCast(e.Result, Parser)

#Region "Error Showing"
        For Each obj In codeParts.errors.exceptionsList
            If TypeOf (obj) Is IncludeNotFoundException Then
                Dim tmpObj = DirectCast(obj, IncludeNotFoundException)
                Dim Msg As String = "The include `" + tmpObj.includeName + "` is not found, Please make sure it exists."
                ErrorsDock.parserErrors.Rows.Add({Msg, tmpObj.includeName})
            ElseIf TypeOf (obj) Is ParserException
                Dim tmpObj = DirectCast(obj, ParserException)
                ErrorsDock.parserErrors.Rows.Add({tmpObj.Message, tmpObj.iden})
            End If
        Next
#End Region

#Region "Refresh Key Word Set"
        Dim setString As String = ""
            For Each key As String In codeParts.Stocks.Keys
                setString += " " + key
            Next
            For Each key As String In codeParts.Publics.Keys
                setString += " " + key
            Next
            For Each key As String In codeParts.Functions.Keys
                setString += " " + key
            Next
            For Each key As String In codeParts.Natives.Keys
                setString += " " + key
            Next
            For Each key As String In codeParts.Defines.Keys
                setString += " " + key
            Next
            For Each key As String In codeParts.Enums.Keys
                setString += " " + key
            Next
            For Each includeParser As Parser In codeParts.Includes.Values
                For Each key As String In includeParser.Stocks.Keys
                    setString += " " + key
                Next
                For Each key As String In includeParser.Publics.Keys
                    setString += " " + key
                Next
                For Each key As String In includeParser.Functions.Keys
                    setString += " " + key
                Next
                For Each key As String In includeParser.Natives.Keys
                    setString += " " + key
                Next
                For Each key As String In includeParser.Defines.Keys
                    setString += " " + key
                Next
                For Each key As String In includeParser.Enums.Keys
                    setString += " " + key
                Next
            Next
            setString = setString.Remove(0, 1) 'Remove the starting space.
            Editor.SetKeywords(1, setString)
#End Region

        If ProjExplorerDock.Visible Then
            ProjExplorerDock.Includes = codeParts.Includes.Keys
            ProjExplorerDock.RefreshIncludes()
        End If
        If ObjectExplorerDock.Visible Then
            ObjectExplorerDock.refreshTreeView(codeParts)
        End If
    End Sub

    Private Sub EditorDock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Editor.Modified Then
            Dim res = MsgBox("The file contains un-saved content, Would you like to save it ?", MsgBoxStyle.YesNoCancel)
            If res = MsgBoxResult.Yes Then
                MainForm.SaveFile(Editor)
            ElseIf res = MsgBoxResult.Cancel Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        idleTimer.Stop()
    End Sub

    Private lastCaretPos As Integer
    Private Sub Editor_UpdateUI(sender As Object, e As UpdateUIEventArgs) Handles Editor.UpdateUI
        ' Has the caret changed position?
        Dim caretPos = Editor.CurrentPosition
        If lastCaretPos <> caretPos Then
            lastCaretPos = caretPos
            Dim bracePos1 = -1
            Dim bracePos2 = -1

            ' Is there a brace to the left or right?
            If caretPos > 0 AndAlso IsBrace(Editor.GetCharAt(caretPos - 1)) Then
                bracePos1 = (caretPos - 1)
            ElseIf IsBrace(Editor.GetCharAt(caretPos)) Then
                bracePos1 = caretPos
            End If

            If bracePos1 >= 0 Then
                ' Find the matching brace
                bracePos2 = Editor.BraceMatch(bracePos1)
                If bracePos2 = Scintilla.InvalidPosition Then
                    Editor.BraceBadLight(bracePos1)
                    Editor.HighlightGuide = 0
                Else
                    Editor.BraceHighlight(bracePos1, bracePos2)
                    Editor.HighlightGuide = Editor.GetColumn(bracePos1)
                End If
            Else
                ' Turn off brace matching
                Editor.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition)
                Editor.HighlightGuide = 0
            End If
        End If
    End Sub

    Private Sub Editor_InsertCheck(sender As Object, e As InsertCheckEventArgs) Handles Editor.InsertCheck
        If (e.Text.EndsWith("" & vbCr) OrElse e.Text.EndsWith("" & vbLf)) Then
            Dim startPos As Integer = Editor.Lines(Editor.LineFromPosition(Editor.CurrentPosition)).Position
            Dim endPos As Integer = e.Position
            Dim curLineText As String = Editor.GetTextRange(startPos, (endPos - startPos)) 'Text until the caret.
            Dim indent As Match = Regex.Match(curLineText, "^[ \t]*")
            e.Text = (e.Text + indent.Value)
            If Regex.IsMatch(curLineText, "{\s*$") Then
                e.Text = (e.Text + vbTab)
            End If
        End If
    End Sub

    Private Sub Editor_CharAdded(sender As Object, e As CharAddedEventArgs) Handles Editor.CharAdded
        If e.Char = 125 Then  'The '}' char.
            Dim curLine As Integer = Editor.LineFromPosition(Editor.CurrentPosition)
            If Editor.Lines(curLine).Text.Trim() = "}" Then 'Check whether the bracket is the only thing on the line.. For cases like "if() { }".
                SetIndent(Editor, curLine, GetIndent(Editor, curLine) - 4)
            End If
        End If
    End Sub

    Private Sub Editor_SavePointReached(sender As Object, e As EventArgs) Handles Editor.SavePointReached
        Me.TabText = Me.Text
    End Sub
    Private Sub Editor_SavePointLeft(sender As Object, e As EventArgs) Handles Editor.SavePointLeft
        If Me.Text = "" Then Exit Sub
        Me.TabText = "* " + Me.Text
    End Sub

    Private Sub Editor_KeyDown(sender As Object, e As KeyEventArgs) Handles Editor.KeyDown
        If e.Control = True And e.KeyCode = Keys.S Then
            MainForm.SaveFile(Editor)
            Editor.SetSavePoint()
            If e.Shift = True Then 'If he has shift pressed also.
                MainForm.SaveAllFiles(Me, EventArgs.Empty)
            End If

            e.SuppressKeyPress = True
        End If
    End Sub
End Class