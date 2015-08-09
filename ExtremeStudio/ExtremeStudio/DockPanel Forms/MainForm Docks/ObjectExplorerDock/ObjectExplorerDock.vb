Public Class ObjectExplorerDock
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
            nde.Tag = parser.Defines(key)
        Next
        For Each key As String In parser.Macros.Keys
            Dim nde = macros.Nodes.Add(key)
            nde.Tag = parser.Macros(key)
        Next
        For Each key As String In parser.Functions.Keys
            Dim nde = functions.Nodes.Add(key)
            nde.Tag = parser.Functions(key)
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

    Private Sub ObjectExplorerDock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MainForm.CurrentEditor IsNot Nothing Then
            refreshTreeView(MainForm.CurrentEditor.codeParts)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub EditItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditItemsToolStripMenuItem.Click
        ObjectExplorerDockItems.ShowDialog()
    End Sub
End Class