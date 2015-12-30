Imports ScintillaNET
Imports ExtremeParser
Imports System.Text.RegularExpressions
Imports ExtremeStudio.AutoCompleteItemEx
Imports ExtremeCore
Imports System.Text

Public Class EditorDock

    'Global Vars
    Enum indicatorIDs
        INDICATOR_PARSERERROR = 50 'Start from 50
        INDICATOR_CODEERROR
        INDICATOR_PHPDOCERROR
    End Enum
    Public codeParts As New CodeParts

    Dim autoCompleteList As New List(Of AutoCompleteItemEx)

    Public isFirstParse As Boolean = True

    'UnRelated events here.
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

        If RefreshWorker.IsBusy Then MainForm.statusLabel.Text = "Idle."
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

    'All modules are here.
#Region "Styles Handlers"
    Private Sub SetBackColor(clr As Color)
        For Each stle As Style In Editor.Styles
            stle.BackColor = clr
        Next

        Editor.SetFoldMarginColor(True, clr)
        Editor.SetFoldMarginHighlightColor(True, clr)
    End Sub

    Private Sub Editor_StyleNeeded(sender As Object, e As StyleNeededEventArgs) Handles Editor.StyleNeeded
        'Call the func.
        codeHighlighting.Highlight(Editor, codeParts, Editor.Lines(Editor.LineFromPosition(Editor.GetEndStyled())).Position, e.Position)
    End Sub

    Public Sub OnSetsChange()
        'Setup font.
        Editor.StyleResetDefault()
        Editor.Styles(Style.[Default]).Font = SettingsForm.FontDialog.Font.FontFamily.Name
        Editor.Styles(Style.[Default]).Size = SettingsForm.FontDialog.Font.Size
        Editor.StyleClearAll()

        'Setup Colors: 
        'TODO: Add to set the colors after doing the new settings.

        Editor.IndentationGuides = IndentView.LookBoth

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

        'Set the CallTip color.
        Editor.CallTipSetForeHlt(Color.Black)

        'Setup the indicators
        Editor.Indicators(indicatorIDs.INDICATOR_PARSERERROR).Style = IndicatorStyle.Squiggle
        Editor.Indicators(indicatorIDs.INDICATOR_PARSERERROR).ForeColor = Color.DarkGreen
        Editor.Indicators(indicatorIDs.INDICATOR_PARSERERROR).Under = True

        'Set the PAWN language keywords.
        Editor.SetKeywords(0, "static break case enum continue do else false for goto public stock if is new null return sizeof switch true while forward native")

        'Set up auto-complete.
        AutoCompleteMenu.TargetControlWrapper = New ScintillaWrapper(Editor)
    End Sub
    Private Sub EditorDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Add handler.
        AddHandler SettingsForm.OnSettingsChange, AddressOf OnSetsChange

        'ReLoad data.
        If SettingsForm.hasBeenLoadedBefore = False Then
            SettingsForm.ReloadInfo()
        End If

        'Call the function.
        OnSetsChange()
    End Sub
#End Region

#Region "TextChangedDelayed WITH VISIBLE Setup Code"
    'Variables to save parsing offsets.
    'Will be -1 if done.
    Private OffsetStart As Integer = -1
    Private OffsetLength As Integer = -1

    Private WithEvents idleTimer As New Timer
    Private oldVisible As String = "" 'This is just a key that I am going to use as empty!..

    Private Sub checkIfDefines(ByRef code As String, line As Integer)
        'Get all the visible If's and ends.
        Dim allIfs As Integer = 0
        Dim allEnds As Integer = 0
        For Each mtch In Regex.Matches(code, "#if\s+defined")
            allIfs += 1
        Next
        For Each mtch In Regex.Matches(code, "#endif")
            allEnds += 1
        Next

        'Check if the ifs are more then the ends.
        If allIfs > allEnds Then
            'Aslong as they're not equal, Keep going!
            While (allIfs <> allEnds And Editor.Lines.Count > line)
                line += 1

                Dim newLine As String = Editor.Lines(line).Text
                code += newLine

                If Regex.IsMatch(newLine, "#endif") Then allEnds += 1
            End While
        ElseIf allEnds > allIfs
            'Aslong as they're not equal, Keep going!
            While (allIfs <> allEnds And Editor.Lines.Count > line)
                line += 1

                Dim newLine As String = Editor.Lines(line).Text
                code += newLine

                If Regex.IsMatch(newLine, "#if\s+defined") Then allIfs += 1
            End While
        End If
    End Sub

    Private Sub idleTimer_Tick(sender As Object, e As EventArgs) Handles idleTimer.Tick
        idleTimer.Stop()
        Dim newCode As String = Editor.GetTextRange(OffsetStart, OffsetLength)

        'Make sure the current code is valid from if defines.
        checkIfDefines(newCode, Editor.LineFromPosition(OffsetStart + OffsetLength))

        'Get the new visible text and call the func.
        scintilla_TextChangedDelayed(oldVisible, newCode)

        'Reset: 
        oldVisible = "" : OffsetStart = -1 : OffsetLength = -1
    End Sub
    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles Me.Load
        With idleTimer
            .Enabled = True
            .Interval = 1000
        End With
    End Sub
    Private Sub TextChangedDelayed_Editor_TextChanged(sender As Object, e As EventArgs) Handles Editor.TextChanged
        idleTimer.Stop()
        idleTimer.Start()
    End Sub

    'This for on first time.
    Private Sub BeforeTextChangedDelayed_Timer(sender As Object, e As BeforeModificationEventArgs) Handles Editor.BeforeDelete, Editor.BeforeInsert
        If e.Text IsNot Nothing Then
            If OffsetStart = -1 And OffsetLength = -1 Then
                'Get positions of visible text and store them.
                OffsetStart = Editor.Lines(Editor.FirstVisibleLine).Position
                OffsetLength = (Editor.Lines(Editor.FirstVisibleLine + Editor.LinesOnScreen).EndPosition) - OffsetStart

                'Store the text.
                oldVisible = Editor.GetTextRange(OffsetStart, OffsetLength)

                'Make sure its valid.
                checkIfDefines(oldVisible, Editor.LineFromPosition(OffsetStart + OffsetLength))
            End If
        End If
    End Sub

    'Adding and minusing to length.
    Private Sub OnAdd(sender As Object, e As BeforeModificationEventArgs) Handles Editor.BeforeInsert
        If e.Text IsNot Nothing Then
            If OffsetLength <> -1 And OffsetStart <> -1 Then
                Dim len As Integer = e.Text.Length
                'Dim newEndPos As Integer = e.Position + len
                'Dim OffsetEnd As Integer = OffsetStart + OffsetLength

                'If e.Position < OffsetStart Then
                '    OffsetStart += len : OffsetLength += len
                'ElseIf e.Position > OffsetStart Then
                OffsetLength += len
                'End If
            End If
        End If
    End Sub
    Private Sub OnRemove(sender As Object, e As BeforeModificationEventArgs) Handles Editor.BeforeDelete
        If e.Text IsNot Nothing Then
            If OffsetLength <> -1 And OffsetStart <> -1 Then
                Dim len As Integer = e.Text.Length
                'Dim newEndPos As Integer = e.Position + len
                'Dim oldEndPos As Integer = OffsetStart + OffsetLength

                'If e.Position < OffsetStart Then
                '    OffsetStart -= len : OffsetLength -= len
                'ElseIf e.Position > OffsetStart Then
                OffsetLength -= len
                'End If

                'TO MAKE SURE THIS IS GOING TO BE REMOVED: 
                oldVisible += vbCrLf + vbCrLf + e.Text + vbCrLf + vbCrLf
            End If
        End If
    End Sub
#End Region

#Region "LineNumbers Calculation"
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
#End Region

#Region "Refresh Worker Codes"
    Public Sub scintilla_TextChangedDelayed(oldcode As String, newcode As String)
        If RefreshWorker.IsBusy = False Then
            RefreshWorker.RunWorkerAsync({oldcode, newcode, Editor.Tag, MainForm.currentProject.projectPath})
            MainForm.statusLabel.Text = "Parsing Code."
        End If
    End Sub
    Private Sub RefreshWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles RefreshWorker.DoWork
        If Editor.IsHandleCreated Then
            'Parse old.
            Dim null = New Parser(codeParts, e.Argument(0), e.Argument(2), e.Argument(3), False)

            'Save the new to the result.
            e.Result = New Parser(codeParts, e.Argument(1), e.Argument(2), e.Argument(3), True)
        End If
    End Sub

    Private Sub parseCodeParts(ByRef autoList As List(Of AutoCompleteItemEx))
        For Each part In codeParts.FlattenIncludes
            For Each stock In part.Stocks
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TYPE_FUNCTION, stock)
                autoList.Add(newitm)
            Next
            For Each publicFunc In part.Publics
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TYPE_FUNCTION, publicFunc)
                autoList.Add(newitm)
            Next
            For Each func In part.Functions
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TYPE_FUNCTION, func)
                autoList.Add(newitm)
            Next
            For Each native In part.Natives
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TYPE_FUNCTION, native)
                autoList.Add(newitm)
            Next
            For Each def In part.Defines
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TYPE_DEFINE, def.DefineName, def.DefineValue)
                autoList.Add(newitm)
            Next
            For Each parentEnm In part.Enums
                For Each enm In parentEnm.EnumContents
                    Dim type As String = ""

                    If enm.Type = FunctionParameters.varTypes.TYPE_ARRAY Then
                        type = "array/string"
                    ElseIf enm.Type = FunctionParameters.varTypes.TYPE_FLOAT Then
                        type = "float"
                    ElseIf enm.Type = FunctionParameters.varTypes.TYPE_INTEGER Then
                        type = "integer"
                    ElseIf enm.Type = FunctionParameters.varTypes.TYPE_FLOAT Then
                        type = "tagged"
                    End If

                    Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TYPE_DEFINE, enm.Content, "This is an enum item with the type: `" + type + "` that is in the enum: `" + parentEnm.EnumName + "`")
                    autoList.Add(newitm)
                Next
            Next
            For Each var In part.publicVariables
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TYPE_DEFINE, var.VarName, "This is a global variable declared in one of the includes.")
                autoList.Add(newitm)
            Next
        Next
    End Sub

    Private Sub RefreshWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshWorker.RunWorkerCompleted
        If Me.IsDisposed Then Exit Sub

        MainForm.statusLabel.Text = "Idle."
        ErrorsDock.parserErrors.Rows.Clear()

#Region "Error Showing"
        Dim errors As ExceptionsList = DirectCast(e.Result, Parser).errors
        For Each obj In errors.exceptionsList
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

#Region "AutoComplete Refresh."
        autoCompleteList.Clear()

        parseCodeParts(autoCompleteList)

        AutoCompleteMenu.SetAutocompleteItems(autoCompleteList)
#End Region

            If ObjectExplorerDock.Visible Then
            ObjectExplorerDock.refreshTreeView(codeParts)
        End If
    End Sub
#End Region

#Region "Brace Highlighting"
    Private Shared Function IsBrace(c As Integer) As Boolean
        Select Case c
            Case AscW("("), AscW(")"), AscW("["), AscW("]"), AscW("{"), AscW("}")
                Return True
        End Select
        Return False
    End Function

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
#End Region

#Region "AutoIndent of new lines"
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
                Editor.Lines(curLine).Indentation -= 4
            End If
        End If
    End Sub
#End Region

#Region "SavePoints"
    Private Sub Editor_SavePointReached(sender As Object, e As EventArgs) Handles Editor.SavePointReached
        Me.TabText = Me.Text
    End Sub
    Private Sub Editor_SavePointLeft(sender As Object, e As EventArgs) Handles Editor.SavePointLeft
        If Me.Text = "" Then Exit Sub
        Me.TabText = "* " + Me.Text
    End Sub
#End Region

#Region "CallTip Codes"
    Dim isCallTipShown As Boolean = False
    Dim currentCallTipItm As AutoCompleteItemEx

    Private Sub CallTipMarkCurrentPar(itm As AutoCompleteItemEx)
        Dim currentLineText As String = Editor.Lines(Editor.CurrentLine).Text
        Dim funcOnly As Match = Regex.Match(currentLineText, itm.Text + "\(([^\n\r\);]*)")
        Dim currentWrite As String
        If funcOnly.Success Then
            currentWrite = funcOnly.Captures(0).Value
        Else
            currentWrite = currentLineText
        End If

        Dim extraCount As Integer = itm.Text.Length + 1 '1 for the ( and )
        Dim wholeFunc As String = itm.Parameters.paramsText

        Dim currentCommas As Integer = stringSearcher.CountChar(currentWrite, ",")
        Dim allCommads As Integer = stringSearcher.CountChar(wholeFunc, ",")

        If currentCommas > allCommads Then Exit Sub

        Dim allPars As String() = wholeFunc.Split(",")

        Dim startPos As Integer = extraCount
        For i As Integer = 0 To allPars.Count - 1
            If i = currentCommas Then
                Exit For
            Else
                startPos += allPars(i).Length + 1 '1 for the comma.
            End If
        Next
        Dim endPos As Integer = startPos + allPars(currentCommas).Length

        Editor.CallTipSetHlt(startPos, endPos)
    End Sub

    Private Sub AutoCompleteMenu_Selected(sender As Object, e As AutocompleteMenuNS.SelectedEventArgs) Handles AutoCompleteMenu.Selected
        Dim itm As AutoCompleteItemEx = DirectCast(e.Item, AutoCompleteItemEx)

        If itm.Type = AutoCompeleteTypes.TYPE_FUNCTION Then
            Editor.CallTipShow(Editor.CurrentPosition, itm.Text + "(" + itm.Parameters.paramsText + ")")
            isCallTipShown = True
            currentCallTipItm = itm

            CallTipMarkCurrentPar(currentCallTipItm)
        End If
    End Sub

    Private Sub CallTip_Editor_CharAdded(sender As Object, e As CharAddedEventArgs) Handles Editor.CharAdded
        If e.Char = 44 Then  'The ',' char.
            If isCallTipShown And TypeOf (currentCallTipItm) Is AutoCompleteItemEx Then
                CallTipMarkCurrentPar(currentCallTipItm)
            End If
        ElseIf e.Char = 13 Then 'If he presses enter, Hide the calltip.
            If isCallTipShown Then
                isCallTipShown = False
                currentCallTipItm = Nothing
            End If
        End If
    End Sub

    Private Sub CallTip_Editor_BeforeDelete(sender As Object, e As ModificationEventArgs) Handles Editor.Delete
        If isCallTipShown And TypeOf (currentCallTipItm) Is AutoCompleteItemEx Then
            If e.Text.Contains(",") Then
                CallTipMarkCurrentPar(currentCallTipItm)
            End If
        End If
    End Sub

    Private Sub CallTip_Editor_Insert(sender As Object, e As ModificationEventArgs) Handles Editor.Insert
        If e.Text = "(" Then 'Which will be used to show the calltip.
            'First of all get the funcName.
            Dim funcText As String = ""
            Dim pos As Integer = e.Position

            While (pos > 0)
                pos -= 1

                Dim txt As String = Editor.GetTextRange(pos, 1)
                If txt = " " Or txt = vbLf Or txt = "(" Or txt = ")" Or txt = "{" Or txt = "}" Or txt = ";" Then Exit While

                funcText = funcText.Insert(0, txt)
            End While

            'Now check if there is an AutoCompleteItem matching that.
            For Each itm As AutoCompleteItemEx In autoCompleteList
                If itm.Text = funcText Then
                    'Found one.. Now if its a function.. Show it. :)
                    If itm.Type = AutoCompeleteTypes.TYPE_FUNCTION Then
                        Editor.CallTipShow(Editor.CurrentPosition, itm.Text + "(" + itm.Parameters.paramsText + ")")
                        isCallTipShown = True
                        currentCallTipItm = itm

                        CallTipMarkCurrentPar(currentCallTipItm)
                    End If
                End If
            Next
        End If
    End Sub
#End Region

End Class