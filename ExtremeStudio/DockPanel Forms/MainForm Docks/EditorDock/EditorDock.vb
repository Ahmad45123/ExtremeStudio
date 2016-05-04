Imports ScintillaNET
Imports ExtremeParser
Imports System.Text.RegularExpressions
Imports ExtremeStudio.AutoCompleteItemEx
Imports ExtremeCore
Imports System.Text

Public Class EditorDock

    'Global Vars
    Public Enum IndicatorIDs
        IndicatorParserError = 50 'Start from 50
        IndicatorPawndocError
        IndicatorSearchItem
    End Enum
    Public CodeParts As New CodeParts

    Dim _autoCompleteList As New List(Of AutoCompleteItemEx)

    Public IsFirstParse As Boolean = True

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
        _idleTimer.Stop()

        If RefreshWorker.IsBusy Then MainForm.statusLabel.Text = "Idle."
    End Sub

    #Region "Key Handling"
    Protected Overrides Function ProcessCmdKey(Byref msg As Message, keyData As Keys) As Boolean
        If (keyData = (Keys.Control Or Keys.S)) Or (keyData = ((keys.Control Or Keys.Shift) Or Keys.S)) Then
            MainForm.SaveFile(Editor)
            Editor.SetSavePoint()
            If keyData And Keys.Shift Then 'If he has shift pressed also.
                MainForm.SaveAllFiles(Me, EventArgs.Empty)
            End If
            Return True

        ElseIf keyData = (Keys.Control Or Keys.G) Then
            GotoForm = Nothing 'Resets the form
            GotoForm.Show()
            Return True

        ElseIf keyData = (Keys.Control Or Keys.F) Then
            SearchReplaceForm = Nothing
            SearchReplaceForm.Show()
            SearchReplaceForm.TabControl1.SelectTab(0) 'Search Tab.
            SearchReplaceForm.searchFindText.Select()
            Return True

        ElseIf keyData = (Keys.Control Or Keys.H) Then
            SearchReplaceForm = Nothing
            SearchReplaceForm.Show()
            SearchReplaceForm.TabControl1.SelectTab(1) 'Replace Tab.
            Return True

        ElseIf keyData = ((keys.Control Or Keys.Shift) Or Keys.N) Then
            If SearchReplaceForm.travelList.Count > 1 Then
                Dim nearestNext As Long = 999999999999999999
                Dim nearestID As Integer = 0
                For i As Integer = 0 To SearchReplaceForm.travelList.Count - 1
                    If SearchReplaceForm.travelList(i).Key > Editor.CurrentPosition And SearchReplaceForm.travelList(i).Key < nearestNext Then
                        nearestNext = SearchReplaceForm.travelList(i).Key
                        nearestID = i
                    End If
                Next
                Editor.SetSelection(SearchReplaceForm.travelList(nearestID).Key, SearchReplaceForm.travelList(nearestID).Value)
                Editor.ScrollCaret()
            End If
            Return True

        ElseIf keyData = ((keys.Control Or Keys.Shift) Or Keys.B) Then
            If SearchReplaceForm.travelList.Count > 1 Then
                Dim nearestNext As Long = 0
                Dim nearestID As Integer = 0
                For i As Integer = 0 To SearchReplaceForm.travelList.Count - 1
                    If SearchReplaceForm.travelList(i).Key < Editor.CurrentPosition And SearchReplaceForm.travelList(i).Key > nearestNext Then
                        nearestNext = SearchReplaceForm.travelList(i).Key
                        nearestID = i
                    End If
                Next
                Editor.SetSelection(SearchReplaceForm.travelList(nearestID).Key, SearchReplaceForm.travelList(nearestID).Value)
                Editor.ScrollCaret()
            End If
            Return True

        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
    #End Region

    'All modules are here.
#Region "Styles Handlers"
    Private Sub SetBackColor(clr As Color)
        For Each stle As Style In Editor.Styles
            stle.BackColor = clr
        Next

        Editor.SetFoldMarginColor(True, clr)
        Editor.SetFoldMarginHighlightColor(True, clr)
    End Sub

    Private Sub DoStyle(style As Integer, clr As StyleItem)
        Editor.Styles(style).ForeColor = IIf(clr.ForeColor = Color.Transparent, nothing, clr.ForeColor)
        Editor.Styles(style).BackColor = IIf(clr.BackColor = Color.Transparent, nothing, clr.BackColor)

        If clr.Font Isnot Nothing
            Editor.Styles(style).Font = clr.Font?.FontFamily.Name
            Editor.Styles(style).Size = clr.Font?.Size
            Editor.Styles(style).Bold = clr.Font?.Bold
            Editor.Styles(style).Underline = clr.Font?.Underline
            Editor.Styles(style).Italic = clr.Font?.Italic
            Editor.Styles(style).Underline = clr.Font?.Underline
        End If
    End Sub
    Public Sub OnSetsChange()
        'Setup font.
        Editor.StyleResetDefault()
        Editor.StyleClearAll()

        'Setup Default CPP similar Colors: 
        DoStyle(Style.Cpp.Default, SettingsForm.ColorsInfo.SDefault)
        DoStyle(Style.Cpp.Number, SettingsForm.ColorsInfo.SInteger)
        DoStyle(Style.Cpp.String, SettingsForm.ColorsInfo.SString)
        DoStyle(Style.Cpp.Character, SettingsForm.ColorsInfo.SString)
        DoStyle(Style.Cpp.Operator, SettingsForm.ColorsInfo.SSymbols)
        DoStyle(Style.Cpp.CommentLine, SettingsForm.ColorsInfo.SSlComments)
        DoStyle(Style.Cpp.Comment, SettingsForm.ColorsInfo.SMlComments)
        DoStyle(Style.Cpp.CommentDoc, SettingsForm.ColorsInfo.SPawnDoc)
        DoStyle(Style.Cpp.Preprocessor, SettingsForm.ColorsInfo.SPawnPre)
        DoStyle(Style.Cpp.Word, SettingsForm.ColorsInfo.SPawnKeys)
        Editor.SetKeywords(0, "static break case enum continue do else false for goto public stock if is new null return sizeof switch true while forward native")

        DoStyle(Styles.Functions, SettingsForm.ColorsInfo.SFunctions)
        DoStyle(Styles.Publics, SettingsForm.ColorsInfo.SPublics)
        DoStyle(Styles.Stocks, SettingsForm.ColorsInfo.SStocks)
        DoStyle(Styles.Natives, SettingsForm.ColorsInfo.SNatives)
        DoStyle(Styles.Defines, SettingsForm.ColorsInfo.SDefines)
        DoStyle(Styles.Macros, SettingsForm.ColorsInfo.SMacros)
        DoStyle(Styles.Enums, SettingsForm.ColorsInfo.SEnums)
        DoStyle(Styles.PublicVars, SettingsForm.ColorsInfo.SGlobalVars)

        Editor.IndentationGuides = IndentView.LookBoth

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
        Editor.Indicators(IndicatorIDs.IndicatorParsererror).Style = IndicatorStyle.Squiggle
        Editor.Indicators(IndicatorIDs.IndicatorParsererror).ForeColor = Color.DarkGreen
        Editor.Indicators(IndicatorIDs.IndicatorParsererror).Under = True

        Editor.Indicators(IndicatorIDs.IndicatorSearchItem).Style = IndicatorStyle.FullBox
        Editor.Indicators(IndicatorIDs.IndicatorSearchItem).ForeColor = Color.Green
        
        'Set up auto-complete.
        AutoCompleteMenu.TargetControlWrapper = New ScintillaWrapper(Editor)
    End Sub
    Private Sub EditorDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Add handler.
        AddHandler SettingsForm.OnColorsSettingsChange, AddressOf OnSetsChange

        'ReLoad data.
        If SettingsForm.HasColorsBeenLoadedBefore = False Then
            SettingsForm.ReloadInfoAll()
        End If

        'Call the function.
        OnSetsChange()
    End Sub
#End Region

#Region "TextChangedDelayed WITH VISIBLE Setup Code"
    'Variables to save parsing offsets.
    'Will be -1 if done.
    Private _offsetStart As Integer = -1
    Private _offsetLength As Integer = -1

    Private WithEvents _idleTimer As New Timer
    Private _oldVisible As String = "" 'This is just a key that I am going to use as empty!..

    Private Sub CheckIfDefines(ByRef code As String, line As Integer)
        'Get all the visible If's and ends.
        Dim allIfs As Integer = Regex.Matches(code, "#if\s+defined").Cast(Of Object)().Count()
        Dim allEnds As Integer = Regex.Matches(code, "#endif").Cast(Of Object)().Count()

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

    Private Sub idleTimer_Tick(sender As Object, e As EventArgs) Handles _idleTimer.Tick
        _idleTimer.Stop()
        Dim newCode As String = Editor.GetTextRange(_offsetStart, _offsetLength)

        'Make sure the current code is valid from if defines.
        CheckIfDefines(newCode, Editor.LineFromPosition(_offsetStart + _offsetLength))

        'Get the new visible text and call the func.
        scintilla_TextChangedDelayed(_oldVisible, newCode)

        'Reset: 
        _oldVisible = "" : _offsetStart = -1 : _offsetLength = -1
    End Sub
    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles Me.Load
        With _idleTimer
            .Enabled = True
            .Interval = 1000
        End With
    End Sub
    Private Sub TextChangedDelayed_Editor_TextChanged(sender As Object, e As EventArgs) Handles Editor.TextChanged
        _idleTimer.Stop()
        _idleTimer.Start()
    End Sub

    'This for on first time.
    Private Sub BeforeTextChangedDelayed_Timer(sender As Object, e As BeforeModificationEventArgs) Handles Editor.BeforeDelete, Editor.BeforeInsert
        If e.Text IsNot Nothing Then
            If _offsetStart = -1 And _offsetLength = -1 Then
                'Get positions of visible text and store them.
                _offsetStart = Editor.Lines(Editor.FirstVisibleLine).Position
                _offsetLength = (Editor.Lines(Editor.FirstVisibleLine + Editor.LinesOnScreen).EndPosition) - _offsetStart

                'Store the text.
                _oldVisible = Editor.GetTextRange(_offsetStart, _offsetLength)

                'Make sure its valid.
                CheckIfDefines(_oldVisible, Editor.LineFromPosition(_offsetStart + _offsetLength))
            End If
        End If
    End Sub

    'Adding and minusing to length.
    Private Sub OnAdd(sender As Object, e As BeforeModificationEventArgs) Handles Editor.BeforeInsert
        If e.Text IsNot Nothing Then
            If _offsetLength <> -1 And _offsetStart <> -1 Then
                Dim len As Integer = e.Text.Length
                'Dim newEndPos As Integer = e.Position + len
                'Dim OffsetEnd As Integer = OffsetStart + OffsetLength

                'If e.Position < OffsetStart Then
                '    OffsetStart += len : OffsetLength += len
                'ElseIf e.Position > OffsetStart Then
                _offsetLength += len
                'End If
            End If
        End If
    End Sub
    Private Sub OnRemove(sender As Object, e As BeforeModificationEventArgs) Handles Editor.BeforeDelete
        If e.Text IsNot Nothing Then
            If _offsetLength <> -1 And _offsetStart <> -1 Then
                Dim len As Integer = e.Text.Length
                'Dim newEndPos As Integer = e.Position + len
                'Dim oldEndPos As Integer = OffsetStart + OffsetLength

                'If e.Position < OffsetStart Then
                '    OffsetStart -= len : OffsetLength -= len
                'ElseIf e.Position > OffsetStart Then
                _offsetLength -= len
                'End If

                'TO MAKE SURE THIS IS GOING TO BE REMOVED: 
                _oldVisible += vbCrLf + vbCrLf + e.Text + vbCrLf + vbCrLf
            End If
        End If
    End Sub
#End Region

#Region "LineNumbers Calculation"
    Private _maxLineNumberCharLength As Integer
    Private Sub Editor_TextChanged(sender As Object, e As EventArgs) Handles Editor.TextChanged
        Dim maxLineNumberCharLength = Editor.Lines.Count.ToString().Length
        If maxLineNumberCharLength = Me._maxLineNumberCharLength Then
            Return
        End If

        Const padding As Integer = 2
        Editor.Margins(0).Width = Editor.TextWidth(Style.LineNumber, New String("9"c, maxLineNumberCharLength + 1)) + padding
        Me._maxLineNumberCharLength = maxLineNumberCharLength
    End Sub
#End Region

#Region "Refresh Worker Codes"
    Public Sub scintilla_TextChangedDelayed(oldcode As String, newcode As String)
        If RefreshWorker.IsBusy = False Then
            RefreshWorker.RunWorkerAsync({oldcode, newcode, Editor.Tag, MainForm.CurrentProject.ProjectPath})
            MainForm.statusLabel.Text = "Parsing Code."
        End If
    End Sub
    Private Sub RefreshWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles RefreshWorker.DoWork
        If Editor.IsHandleCreated Then
            'Parse old.
            Dim null = New Parser(CodeParts, e.Argument(0), e.Argument(2), e.Argument(3), False)

            'Save the new to the result.
            e.Result = New Parser(CodeParts, e.Argument(1), e.Argument(2), e.Argument(3), True)
        End If
    End Sub

    Private Sub ParseCodeParts(ByRef autoList As List(Of AutoCompleteItemEx))
        For Each part In CodeParts.FlattenIncludes
            For Each stock In part.Stocks
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TypeFunction, stock)
                autoList.Add(newitm)
            Next
            For Each publicFunc In part.Publics
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TypeFunction, publicFunc)
                autoList.Add(newitm)
            Next
            For Each func In part.Functions
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TypeFunction, func)
                autoList.Add(newitm)
            Next
            For Each native In part.Natives
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TypeFunction, native)
                autoList.Add(newitm)
            Next
            For Each def In part.Defines
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TypeDefine, def.DefineName, def.DefineValue)
                autoList.Add(newitm)
            Next
            For Each parentEnm In part.Enums
                For Each enm In parentEnm.EnumContents
                    Dim type As String = ""

                    If enm.Type = FunctionParameters.VarTypes.TypeArray Then
                        type = "array/string"
                    ElseIf enm.Type = FunctionParameters.VarTypes.TypeFloat Then
                        type = "float"
                    ElseIf enm.Type = FunctionParameters.VarTypes.TypeInteger Then
                        type = "integer"
                    ElseIf enm.Type = FunctionParameters.VarTypes.TypeFloat Then
                        type = "tagged"
                    End If

                    Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TypeDefine, enm.Content, "This is an enum item with the type: `" + type + "` that is in the enum: `" + parentEnm.EnumName + "`")
                    autoList.Add(newitm)
                Next
            Next
            For Each var In part.PublicVariables
                Dim newitm As New AutoCompleteItemEx(AutoCompeleteTypes.TypeDefine, var.VarName, "This is a global variable declared in one of the includes.")
                autoList.Add(newitm)
            Next
        Next
    End Sub

    Private Sub RefreshWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshWorker.RunWorkerCompleted
        If Me.IsDisposed Then Exit Sub

        MainForm.statusLabel.Text = "Idle."
        ErrorsDock.parserErrors.Rows.Clear()

#Region "Error Showing"
        Dim errors As ExceptionsList = DirectCast(e.Result, Parser).Errors
        For Each obj In errors.exceptionsList
            If TypeOf (obj) Is IncludeNotFoundException Then
                Dim tmpObj = DirectCast(obj, IncludeNotFoundException)
                Dim msg As String = "The include `" + tmpObj.IncludeName + "` is not found, Please make sure it exists."
                ErrorsDock.parserErrors.Rows.Add({msg, tmpObj.IncludeName})
            ElseIf TypeOf (obj) Is ParserException
                Dim tmpObj = DirectCast(obj, ParserException)
                ErrorsDock.parserErrors.Rows.Add({tmpObj.Message, tmpObj.Iden})
            End If
        Next
#End Region

#Region "AutoComplete Refresh."
        _autoCompleteList.Clear()

        ParseCodeParts(_autoCompleteList)

        AutoCompleteMenu.SetAutocompleteItems(_autoCompleteList)
#End Region

        'Update Visible Style: 
        Editor_UpdateStyle(Me, New UpdateUIEventArgs(New UpdateChange()))

        If ObjectExplorerDock.Visible Then
            ObjectExplorerDock.RefreshTreeView(CodeParts)
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

    Private _lastCaretPos As Integer
    Private Sub Editor_UpdateUI(sender As Object, e As UpdateUIEventArgs) Handles Editor.UpdateUI
        ' Has the caret changed position?
        Dim caretPos = Editor.CurrentPosition
        If _lastCaretPos <> caretPos Then
            _lastCaretPos = caretPos
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
    Dim _isCallTipShown As Boolean = False
    Dim _currentCallTipItm As AutoCompleteItemEx

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
        Dim wholeFunc As String = itm.Parameters.ParamsText

        Dim currentCommas As Integer = StringSearcher.CountChar(currentWrite, ",")
        Dim allCommads As Integer = StringSearcher.CountChar(wholeFunc, ",")

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

        If itm.Type = AutoCompeleteTypes.TypeFunction Then
            Editor.CallTipShow(Editor.CurrentPosition, itm.Text + "(" + itm.Parameters.ParamsText + ")")
            _isCallTipShown = True
            _currentCallTipItm = itm

            CallTipMarkCurrentPar(_currentCallTipItm)
        End If
    End Sub

    Private Sub CallTip_Editor_CharAdded(sender As Object, e As CharAddedEventArgs) Handles Editor.CharAdded
        If e.Char = 44 Then  'The ',' char.
            If _isCallTipShown And TypeOf (_currentCallTipItm) Is AutoCompleteItemEx Then
                CallTipMarkCurrentPar(_currentCallTipItm)
            End If
        ElseIf e.Char = 13 Then 'If he presses enter, Hide the calltip.
            If _isCallTipShown Then
                _isCallTipShown = False
                _currentCallTipItm = Nothing
            End If
        End If
    End Sub

    Private Sub CallTip_Editor_BeforeDelete(sender As Object, e As ModificationEventArgs) Handles Editor.Delete
        If _isCallTipShown And TypeOf (_currentCallTipItm) Is AutoCompleteItemEx Then
            If e.Text.Contains(",") Then
                CallTipMarkCurrentPar(_currentCallTipItm)
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
            For Each itm As AutoCompleteItemEx In _autoCompleteList
                If itm.Text = funcText Then
                    'Found one.. Now if its a function.. Show it. :)
                    If itm.Type = AutoCompeleteTypes.TypeFunction Then
                        Editor.CallTipShow(Editor.CurrentPosition, itm.Text + "(" + itm.Parameters.ParamsText + ")")
                        _isCallTipShown = True
                        _currentCallTipItm = itm

                        CallTipMarkCurrentPar(_currentCallTipItm)
                    End If
                End If
            Next
        End If
    End Sub
#End Region

#Region "WordSet Colorizer"
    Private Enum Styles
        Functions = 100
        Publics
        Stocks
        Natives
        Defines
        Macros
        Enums
        PublicVars
    End Enum
    Private Sub DoColor(startPos As Integer, ByVal code As String, rgx As String, style As Styles, Optional isMultiLine As Boolean = False)
        For Each mtch As Match In Regex.Matches(code, rgx, IIf(isMultiLine, RegexOptions.Multiline, Nothing))
            Editor.StartStyling(mtch.Index + startPos)
            Editor.SetStyling(mtch.Length, style)
        Next
    End Sub
    Private Sub ReColorize(startPos As Integer, endPos As Integer)
        'Setup vars: 
        Dim code As String = Editor.GetTextRange(startPos, endPos - startPos)

        Dim rgx As New StringBuilder()
        'Functions: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To CodeParts.Functions.Count - 1
            rgx.Append(Regex.Escape(CodeParts.Functions(i).FuncName))
            If (i < CodeParts.Functions.Count - 1) Then rgx.Append("|")
        Next
        If CodeParts.Functions.Count Then rgx.Append(")\b") : DoColor(startPos, code, rgx.ToString, Styles.Functions)

        'Publics: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To CodeParts.Publics.Count - 1
            rgx.Append(Regex.Escape(CodeParts.Publics(i).FuncName))
            If (i < CodeParts.Publics.Count - 1) Then rgx.Append("|")
        Next
        If CodeParts.Publics.Count Then rgx.Append(")\b") : DoColor(startPos, code, rgx.ToString, Styles.Publics)

        'Stocks: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To CodeParts.Stocks.Count - 1
            rgx.Append(Regex.Escape(CodeParts.Stocks(i).FuncName))
            If (i < CodeParts.Stocks.Count - 1) Then rgx.Append("|")
        Next
        If CodeParts.Stocks.Count Then rgx.Append(")\b") : DoColor(startPos, code, rgx.ToString, Styles.Stocks)

        'Natives: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To CodeParts.Natives.Count - 1
            rgx.Append(Regex.Escape(CodeParts.Natives(i).FuncName))
            If (i < CodeParts.Natives.Count - 1) Then rgx.Append("|")
        Next
        If CodeParts.Natives.Count Then rgx.Append(")\b") : DoColor(startPos, code, rgx.ToString, Styles.Natives)

        'Defines: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To CodeParts.Defines.Count - 1
            rgx.Append(Regex.Escape(CodeParts.Defines(i).DefineName))
            If (i < CodeParts.Defines.Count - 1) Then rgx.Append("|")
        Next
        If CodeParts.Defines.Count Then rgx.Append(")\b") : DoColor(startPos, code, rgx.ToString, Styles.Defines)

        'Macros: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To CodeParts.Macros.Count - 1
            rgx.Append(Regex.Escape(CodeParts.Macros(i).DefineName))
            If (i < CodeParts.Macros.Count - 1) Then rgx.Append("|")
        Next
        If CodeParts.Macros.Count Then rgx.Append(")\b") : DoColor(startPos, code, rgx.ToString, Styles.Macros)

        'Enums: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To CodeParts.Enums.Count - 1
            For Each cntn In CodeParts.Enums(i).EnumContents
                rgx.Append(Regex.Escape(cntn.Content))
                If (i < CodeParts.Enums.Count - 1) Then rgx.Append("|")
            Next
        Next
        If CodeParts.Enums.Count Then rgx.Append(")\b") : DoColor(startPos, code, rgx.ToString, Styles.Enums)

        'Public Variables: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To CodeParts.PublicVariables.Count - 1
            rgx.Append(Regex.Escape(CodeParts.PublicVariables(i).VarName))
            If (i < CodeParts.PublicVariables.Count - 1) Then rgx.Append("|")
        Next
        If CodeParts.PublicVariables.Count Then rgx.Append(")\b") : DoColor(startPos, code, rgx.ToString, Styles.PublicVars)
    End Sub

    Private Sub Editor_UpdateStyle(sender As Object, e As UpdateUIEventArgs) Handles Editor.UpdateUI
        Dim startPos = Editor.Lines(Editor.FirstVisibleLine).Position
        Dim endPos = Editor.Lines(Editor.FirstVisibleLine + Editor.LinesOnScreen).EndPosition
        ReColorize(startPos, endPos)
    End Sub
#End Region
End Class