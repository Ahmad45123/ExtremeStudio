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

        For Each key As ExtremeParser.DefinesClass In parser.Defines
            Dim nde = defines.Nodes.Add(key.DefineName)
            nde.Tag = key.DefineValue
        Next

        'Create the custom Roots (Must be done before the Functions so its used inside it.)
        Dim listCustom As New List(Of TreeNode)
        For Each itm In MainForm.currentProject.objectExplorerItems
            Dim bla = treeView.Nodes.Add(itm.Name) : bla.Tag = itm.Identifier 'Here I set its tag to the identifer temporarly, It will be changed to `Root` again in Functions loop.
            listCustom.Add(bla)
        Next

        For Each funcs In parser.Functions
            Dim done As Boolean = False

            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If funcs.FuncName.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(funcs.FuncName)
                    node.Tag = funcs.FuncParameters
                    done = True 'To skip the `Else if it wasn't used.`
                    Exit For
                End If
            Next

            If done = True Then Continue For

            'Else if it wasn't used.
            Dim nde = functions.Nodes.Add(funcs.FuncName)
            nde.Tag = funcs.FuncParameters
        Next
        'Set the Root tags.
        For Each itm In listCustom
            itm.Tag = "Root"
        Next

        For Each publicFunc In parser.Publics
            Dim nde = publics.Nodes.Add(publicFunc.FuncName)
            nde.Tag = publicFunc.FuncParameters
        Next
        For Each stock In parser.Stocks
            Dim nde = stocks.Nodes.Add(stock.FuncName)
            nde.Tag = stock.FuncParameters
        Next
        For Each native In parser.Natives
            Dim nde = natives.Nodes.Add(native.FuncName)
            nde.Tag = native.FuncParameters
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