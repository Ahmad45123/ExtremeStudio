Imports ScintillaNET
Imports ExtremeParser

Public Class EditorDock

#Region "TextChangedDelayed Setup Code"
    Private WithEvents idleTimer As New Timer
    Public Event TextChangedDelayed As EventHandler
    Private Sub idleTimer_Tick(sender As Object, e As EventArgs) Handles idleTimer.Tick
        idleTimer.Stop()
        RaiseEvent TextChangedDelayed(Editor, EventArgs.Empty)
    End Sub
    Private Sub Editor_TextChanged(sender As Object, e As EventArgs) Handles Editor.TextChanged
        idleTimer.Stop()
        idleTimer.Start()
    End Sub
#End Region
    Private Sub scintilla_TextChangedDelayed(sender As Object, e As EventArgs)
        If RefreshWorker.IsBusy = False Then RefreshWorker.RunWorkerAsync(Editor.Text)
    End Sub


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

        Editor.Styles(Style.Cpp.[Default]).ForeColor = Color.Silver
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

        Editor.Lexer = Lexer.Cpp

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
End Class