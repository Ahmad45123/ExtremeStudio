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
        If RefreshWorker.IsBusy = False Then RefreshWorker.RunWorkerAsync(Editor.Text)
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
        Editor.Styles(Style.Cpp.CommentLineDoc).ForeColor = Color.FromArgb(128, 128, 128)
        Editor.Styles(Style.Cpp.Number).ForeColor = Color.Olive
        Editor.Styles(Style.Cpp.Word).ForeColor = Color.Blue
        Editor.Styles(Style.Cpp.Word2).ForeColor = Color.Blue
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
        Editor.SetProperty("fold.compact", "1")

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

        'Set the PAWN language keywords.
        Editor.SetKeywords(0, "break case continue do else false for foreach goto public stock if is new null return sizeof switch true using while forward native")
        Editor.SetKeywords(1, "enum")
    End Sub

    Public codeParts As Parser
    Private Sub RefreshWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles RefreshWorker.DoWork
        If Editor.IsHandleCreated Then
            Dim parsed As New Parser(e.Argument)
            e.Result = parsed
        End If
    End Sub

    Private Sub RefreshWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshWorker.RunWorkerCompleted
        codeParts = e.Result
        If ProjExplorerDock.Visible Then
            ProjExplorerDock.Includes = codeParts.Includes
            ProjExplorerDock.RefreshIncludes()
        End If
    End Sub

    Private Sub EditorDock_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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
            If Editor.Lines(curLine).Text.Trim() = "}" Then
                SetIndent(Editor, curLine, GetIndent(Editor, curLine) - 4)
            End If
        End If
    End Sub
End Class