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

        'Create the custom Roots (Must be done before the Functions so its used inside it.)
        Dim listCustom As New List(Of TreeNode)
        For Each itm In MainForm.currentProject.objectExplorerItems
            Dim bla = treeView.Nodes.Add(itm.Name) : bla.Tag = itm.Identifier 'Here I set its tag to the identifer temporarly, It will be changed to `Root` again in Functions loop.
            listCustom.Add(bla)
        Next

        For Each key As String In parser.Functions.Keys
            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If key.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(key)
                    node.Tag = parser.Functions(key)
                    key = "" 'To skip the `Else if it wasn't used.`
                    Exit For
                End If
            Next

            If key = "" Then Continue For
            'Else if it wasn't used.
            Dim nde = functions.Nodes.Add(key)
            nde.Tag = parser.Functions(key)
        Next
        'Set the Root tags.
        For Each itm In listCustom
            itm.Tag = "Root"
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

    Private Sub EditItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditItemsToolStripMenuItem.Click
        ObjectExplorerDockItems.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        refreshTreeView(MainForm.CurrentEditor.codeParts)
    End Sub
End Class