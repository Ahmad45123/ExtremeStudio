Public Class ObjectExplorerDock
    Private Class ValAndLineInfoCombine
        Public value
        Public lineInfo As ExtremeParser.lineInfo

        Public Sub New(Newvalue As Object, NewlineInfo As ExtremeParser.lineInfo)
            value = Newvalue
            lineInfo = NewlineInfo
        End Sub
    End Class

    Dim nodeState As ExtremeCore.treeNodeStateSaving = New ExtremeCore.treeNodeStateSaving

    Public Sub refreshTreeView(parser As ExtremeParser.Parser)
        If parser Is Nothing Then Exit Sub

        nodeState.SaveTreeState(treeView.Nodes) 'Save states
        treeView.Nodes.Clear() 'Clear all

        Dim defines = treeView.Nodes.Add("Defines") : defines.Tag = "Root"
        Dim macros = treeView.Nodes.Add("Macros") : macros.Tag = "Root"
        Dim functions = treeView.Nodes.Add("Functions") : functions.Tag = "Root"
        Dim publics = treeView.Nodes.Add("Publics") : publics.Tag = "Root"
        Dim stocks = treeView.Nodes.Add("Stocks") : stocks.Tag = "Root"
        Dim natives = treeView.Nodes.Add("Natives") : natives.Tag = "Root"

        For Each key As String In parser.Defines.Keys
            Dim nde = defines.Nodes.Add(key)
            nde.Tag = New ValAndLineInfoCombine(parser.Defines(key), parser.Defines.Tag(key))
        Next
        For Each key As String In parser.Macros.Keys
            Dim nde = macros.Nodes.Add(key)
            nde.Tag = New ValAndLineInfoCombine(parser.Macros(key), parser.Macros.Tag(key))
        Next
        For Each key As String In parser.Functions.Keys
            Dim nde = functions.Nodes.Add(key)
            nde.Tag = New ValAndLineInfoCombine(parser.Functions(key), parser.Functions.Tag(key))
        Next
        For Each key As String In parser.Publics.Keys
            Dim nde = publics.Nodes.Add(key)
            nde.Tag = New ValAndLineInfoCombine(parser.Publics(key), parser.Publics.Tag(key))
        Next
        For Each key As String In parser.Stocks.Keys
            Dim nde = stocks.Nodes.Add(key)
            nde.Tag = New ValAndLineInfoCombine(parser.Stocks(key), parser.Stocks.Tag(key))
        Next
        For Each key As String In parser.Natives.Keys
            Dim nde = natives.Nodes.Add(key)
            nde.Tag = New ValAndLineInfoCombine(parser.Natives(key), parser.Natives.Tag(key))
        Next

        nodeState.RestoreTreeState(treeView) 'Restore
    End Sub

    Private Sub treeView_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles treeView.NodeMouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If e.Node.Tag IsNot "Root" Then
                If MainForm.CurrentScintilla IsNot Nothing Then
                    Dim info = DirectCast(e.Node.Tag, ValAndLineInfoCombine).lineInfo
                    MainForm.CurrentScintilla.GotoPosition(info.Position)
                End If
            End If
        End If
    End Sub

    Private Sub ObjectExplorerDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MainForm.CurrentEditor IsNot Nothing Then
            refreshTreeView(MainForm.CurrentEditor.codeParts)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class