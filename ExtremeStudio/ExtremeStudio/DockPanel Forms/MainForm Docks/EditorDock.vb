Imports ScintillaNET
Imports ExtremeParser

Public Class EditorDock

    Public codeParts As Parser

    Private Sub EditorDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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

        Editor.SetKeywords(0, "break case continue do else false for foreach goto public stock if is new null return sizeof switch true using while")
        Editor.SetKeywords(1, "enum")
    End Sub

    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        If RefreshWorker.IsBusy = False Then RefreshWorker.RunWorkerAsync()
    End Sub

    Private Sub RefreshWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles RefreshWorker.DoWork
        If Editor.IsHandleCreated Then
            Editor.Invoke(DirectCast(Sub()
                                         codeParts = New Parser(Editor.Text)
                                     End Sub, MethodInvoker))
        End If
    End Sub
End Class