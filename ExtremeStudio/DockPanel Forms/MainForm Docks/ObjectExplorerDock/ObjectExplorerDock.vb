Imports System.IO
Imports ExtremeParser

Public Class ObjectExplorerDock
    Dim _nodeState As ExtremeCore.treeNodeStateSaving = New ExtremeCore.treeNodeStateSaving

#Region "Funcs"
    Public Function GetTreeViewPart(parser As ExtremeParser.CodeParts, searchTerm As String)
        If parser Is Nothing Then Return Nothing

        Dim mainNode As New TreeNode With {
            .Text = Path.GetFileNameWithoutExtension(parser.FilePath)
        }

        Dim defines = mainNode.Nodes.Add("Defines") : defines.Tag = "Root"
        Dim macros = mainNode.Nodes.Add("Macros") : macros.Tag = "Root"
        Dim functions = mainNode.Nodes.Add("Functions") : functions.Tag = "Root"
        Dim publics = mainNode.Nodes.Add("Publics") : publics.Tag = "Root"
        Dim stocks = mainNode.Nodes.Add("Stocks") : stocks.Tag = "Root"
        Dim natives = mainNode.Nodes.Add("Natives") : natives.Tag = "Root"

        Dim filename As String = Path.GetFileNameWithoutExtension(MainForm.CurrentScintilla.Tag)

        'Create the custom Roots.
        Dim listCustom As New List(Of TreeNode)
        For Each itm In MainForm.currentProject.objectExplorerItems
            Dim bla = mainNode.Nodes.Add(itm.Name) : bla.Tag = itm.Identifier 'Here I set its tag to the identifer temporarly, It will be changed to `Root` again in Functions loop.
            listCustom.Add(bla)
        Next

        'Start
        For Each key In parser.Defines.FindAll(Function(x) x.DefineName.Contains(searchTerm))
            Dim nde = defines.Nodes.Add(key.DefineName)
            nde.ToolTipText = "Define Value: " + vbCrLf + key.DefineValue
        Next

        For Each key In parser.Macros.FindAll(Function(x) x.DefineName.Contains(searchTerm))
            Dim nde = macros.Nodes.Add(key.DefineName)
            nde.ToolTipText = "Define Value: " + vbCrLf + key.DefineValue
        Next

        For Each funcs In parser.Functions.FindAll(Function(x) x.FuncName.Contains(searchTerm))
            Dim done As Boolean = False

            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If funcs.FuncName.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(funcs.FuncName)
                    node.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, funcs).ToolTipText
                    done = True 'To skip the `Else if it wasn't used.`
                    Exit For
                End If
            Next

            If done = True Then Continue For

            'Else if it wasn't used.
            Dim nde = functions.Nodes.Add(funcs.FuncName)
            nde.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, funcs).ToolTipText
        Next

        For Each publicFunc In parser.Publics.FindAll(Function(x) x.FuncName.Contains(searchTerm))
            Dim done As Boolean = False

            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If publicFunc.FuncName.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(publicFunc.FuncName)
                    node.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, publicFunc).ToolTipText
                    done = True 'To skip the `Else if it wasn't used.`
                    Exit For
                End If
            Next

            If done = True Then Continue For

            'Else if it wasn't used.
            Dim nde = publics.Nodes.Add(publicFunc.FuncName)
            nde.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, publicFunc).ToolTipText
        Next

        For Each stock In parser.Stocks.FindAll(Function(x) x.FuncName.Contains(searchTerm))
            Dim done As Boolean = False

            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If stock.FuncName.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(stock.FuncName)
                    node.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, stock).ToolTipText
                    done = True 'To skip the `Else if it wasn't used.`
                    Exit For
                End If
            Next

            If done = True Then Continue For

            'Else if it wasn't used.
            Dim nde = stocks.Nodes.Add(stock.FuncName)
            nde.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, stock).ToolTipText
        Next

        For Each native In parser.Natives.FindAll(Function(x) x.FuncName.Contains(searchTerm))
            Dim done As Boolean = False

            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If native.FuncName.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(native.FuncName)
                    node.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, native).ToolTipText
                    done = True 'To skip the `Else if it wasn't used.`
                    Exit For
                End If
            Next

            If done = True Then Continue For

            'Else if it wasn't used.
            Dim nde = natives.Nodes.Add(native.FuncName)
            nde.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, native).ToolTipText
        Next

        'Set the Root tags.
        For Each itm In listCustom
            itm.Tag = "Root"
        Next
        Return mainNode
    End Function

    Public Sub RefreshTreeView(parts As CodeParts)
        'Save.
        _nodeState.SaveTreeState(treeView.Nodes)

        'Clear All.
        treeView.Nodes.Clear()

        'Start by adding the current file.
        Dim node As TreeNode = getTreeViewPart(parts, SearchTextBox.Text)
        node.Text = "Current File"
        treeView.Nodes.Add(node)

        'Loop through all includes and put them.
        Dim parentNode As New TreeNode With {
            .Text = "Includes"
        }
        Dim allIncs = parts.FlattenIncludes
        For i As Integer = 1 To allIncs.Count - 1 'Loop through all skipping ID 0.
            parentNode.Nodes.Add(getTreeViewPart(allIncs(i), SearchTextBox.Text))
        Next

        'Add to list.
        treeView.Nodes.Add(parentNode)

        _nodeState.RestoreTreeState(treeView) 'Restore
    End Sub
#End Region

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

    Private Sub SearchTextBox_Changed(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged
        If SearchTextBox.Text = "" Then
            Label1.Visible = True
        Else
            Label1.Visible = False
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        SearchTextBox.Focus()
    End Sub

    Private Sub SearchTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SearchTextBox.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            refreshTreeView(MainForm.CurrentEditor.codeParts)
            e.Handled = True
        End If
    End Sub
End Class