Public Class ObjectExplorerDock
    Dim nodeState As ExtremeCore.treeNodeStateSaving = New ExtremeCore.treeNodeStateSaving

    Public Sub refreshTreeView(parser As ExtremeParser.Parser)
        nodeState.SaveTreeState(treeView.Nodes) 'Save states
        treeView.Nodes.Clear() 'Clear all

        Dim defines = treeView.Nodes.Add("Defines")
        Dim macros = treeView.Nodes.Add("Macros")
        Dim publics = treeView.Nodes.Add("Publics")
        Dim stocks = treeView.Nodes.Add("Stocks")
        Dim natives = treeView.Nodes.Add("Natives")

        For Each key As String In parser.Defines.Keys
            Dim nde = defines.Nodes.Add(key)
            nde.Tag = parser.Defines(key)
        Next
        For Each key As String In parser.Macros.Keys
            Dim nde = macros.Nodes.Add(key)
            nde.Tag = parser.Macros(key)
        Next
        For Each key As String In parser.Publics.Keys
            Dim nde = publics.Nodes.Add(key)
            nde.Tag = parser.Publics(key)
        Next
        For Each key As String In parser.Stocks.Keys
            Dim nde = stocks.Nodes.Add(key)
            nde.Tag = parser.Stocks(key)
        Next
        For Each key As String In parser.Natives.Keys
            Dim nde = natives.Nodes.Add(key)
            nde.Tag = parser.Natives(key)
        Next

        nodeState.RestoreTreeState(treeView) 'Restore
    End Sub
End Class