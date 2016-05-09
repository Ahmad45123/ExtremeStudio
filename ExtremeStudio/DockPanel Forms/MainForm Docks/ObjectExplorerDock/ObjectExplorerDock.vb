Imports System.IO
Imports System.Text.RegularExpressions
Imports ExtremeParser
Imports ScintillaNET

Public Class ObjectExplorerDock
    Dim _nodeState As ExtremeCore.treeNodeStateSaving = New ExtremeCore.treeNodeStateSaving

#Region "Funcs"
    Private Function GetTreeViewPart(parser As ExtremeParser.CodeParts, searchTerm As String, tag as String)
        If parser Is Nothing Then Return Nothing

        Dim mainNode As New TreeNode With {
            .Text = Path.GetFileNameWithoutExtension(parser.FilePath)
        }

        Dim defines As TreeNode
        Dim macros As TreeNode
        Dim functions As TreeNode
        Dim publics As TreeNode
        Dim stocks As TreeNode
        Dim natives As TreeNode

        If parser.Defines.FindAll(Function(x) x.DefineName.Contains(searchTerm)).Count > 0 Then defines = mainNode.Nodes.Add("Defines")
        If parser.Macros.FindAll(Function(x) x.DefineName.Contains(searchTerm)).Count > 0 Then macros = mainNode.Nodes.Add("Macros")
        If parser.Functions.FindAll(Function(x) x.FuncName.Contains(searchTerm)).Count > 0 Then functions = mainNode.Nodes.Add("Functions")
        If parser.Publics.FindAll(Function(x) x.FuncName.Contains(searchTerm)).Count > 0 Then publics = mainNode.Nodes.Add("Publics")
        If parser.Stocks.FindAll(Function(x) x.FuncName.Contains(searchTerm)).Count > 0 Then stocks = mainNode.Nodes.Add("Stocks")
        If parser.Natives.FindAll(Function(x) x.FuncName.Contains(searchTerm)).Count > 0 Then natives = mainNode.Nodes.Add("Natives")

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
            nde.Tag = "define|" + tag
        Next

        For Each key In parser.Macros.FindAll(Function(x) x.DefineName.Contains(searchTerm))
            Dim nde = macros.Nodes.Add(key.DefineName)
            nde.ToolTipText = "Define Value: " + vbCrLf + key.DefineValue
            nde.Tag = "define|" + tag
        Next

        For Each funcs In parser.Functions.FindAll(Function(x) x.FuncName.Contains(searchTerm))
            Dim done As Boolean = False

            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If funcs.FuncName.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(funcs.FuncName)
                    node.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, funcs).ToolTipText
                    done = True 'To skip the `Else if it wasn't used.`
                    node.Tag = "function|" + tag
                    Exit For
                End If
            Next

            If done = True Then Continue For

            'Else if it wasn't used.
            Dim nde = functions.Nodes.Add(funcs.FuncName)
            nde.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, funcs).ToolTipText
            nde.Tag = "function|" + tag
        Next

        For Each publicFunc In parser.Publics.FindAll(Function(x) x.FuncName.Contains(searchTerm))
            Dim done As Boolean = False

            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If publicFunc.FuncName.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(publicFunc.FuncName)
                    node.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, publicFunc).ToolTipText
                    done = True 'To skip the `Else if it wasn't used.`
                    node.Tag = "public|" + tag
                    Exit For
                End If
            Next

            If done = True Then Continue For

            'Else if it wasn't used.
            Dim nde = publics.Nodes.Add(publicFunc.FuncName)
            nde.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, publicFunc).ToolTipText
            nde.Tag = "public|" + tag
        Next

        For Each stock In parser.Stocks.FindAll(Function(x) x.FuncName.Contains(searchTerm))
            Dim done As Boolean = False

            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If stock.FuncName.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(stock.FuncName)
                    node.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, stock).ToolTipText
                    done = True 'To skip the `Else if it wasn't used.`
                    node.Tag = "stock|" + tag
                    Exit For
                End If
            Next

            If done = True Then Continue For

            'Else if it wasn't used.
            Dim nde = stocks.Nodes.Add(stock.FuncName)
            nde.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, stock).ToolTipText
            nde.Tag = "stock|" + tag
        Next

        For Each native In parser.Natives.FindAll(Function(x) x.FuncName.Contains(searchTerm))
            Dim done As Boolean = False

            'Check if it crosponds to a custom one first.
            For Each itm In listCustom
                If native.FuncName.StartsWith(itm.Tag) Then
                    Dim node = itm.Nodes.Add(native.FuncName)
                    node.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, native).ToolTipText
                    done = True 'To skip the `Else if it wasn't used.`
                    node.Tag = "native|" + tag
                    Exit For
                End If
            Next

            If done = True Then Continue For

            'Else if it wasn't used.
            Dim nde = natives.Nodes.Add(native.FuncName)
            nde.ToolTipText = New AutoCompleteItemEx(AutoCompleteItemEx.AutoCompeleteTypes.TypeFunction, native).ToolTipText
            nde.Tag = "native|" + tag
        Next
        Return mainNode
    End Function

    Public Sub RefreshTreeView(parts As CodeParts)
        'Save.
        _nodeState.SaveTreeState(treeView.Nodes)

        'Clear All.
        treeView.Nodes.Clear()

        'Start by adding the current file.
        Dim node As TreeNode = getTreeViewPart(parts, SearchTextBox.Text, "current")
        node.Text = "Current File"
        If node.Nodes.Count > 0 Then treeView.Nodes.Add(node)

        'Loop through all includes and put them.
        Dim parentNode As New TreeNode With {
            .Text = "Includes"
        }
        Dim allIncs = parts.FlattenIncludes
        For i As Integer = 1 To allIncs.Count - 1 'Loop through all skipping ID 0.
            Dim nds = getTreeViewPart(allIncs(i), SearchTextBox.Text, allIncs(i).FilePath)
            If nds.Nodes.Count > 0 Then parentNode.Nodes.Add(nds)
        Next

        'Add to list.
        If parentNode.Nodes.Count > 0 Then treeView.Nodes.Add(parentNode)

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

    Private Sub FindAndGoto(rgx As string)
        If Mainform.CurrentScintilla Is Nothing Then Exit Sub
        Dim match = Regex.Match(Mainform.CurrentScintilla.GetTextRange(0, Mainform.CurrentScintilla.TextLength), rgx, RegexOptions.Multiline)
        If match.Index <> 0 And match.Length <> 0 Then
            MainForm.CurrentScintilla.SetSelection(match.Index, match.Index + match.Length)
            Mainform.CurrentScintilla.ScrollCaret()
        End If
        'I could have just used ScintillaNEts regex here but it for some reason doesn't provide multiline regex which is needed for accurancy.
    End Sub

    Private Sub treeView_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles treeView.NodeMouseDoubleClick
        If e.Node.Tag = Nothing Then Exit Sub

        Dim filepath As String = e.Node.Tag.Split("|")(1)
        If filepath <> "current" Then
            'First, Loop throuhg all opened tabs and see if its already opened there.
            Dim isFound as Boolean = False
            For Each doc In Mainform.MainDock.Documents
                If doc.DockHandler.Form.Controls("Editor").Tag = filepath Then
                    doc.DockHandler.Activate()
                    isFound = True
                End If
            Next

            If isFound = False Then
                'If not found, Open that file.
                Mainform.OpenFile(filepath)
            End If
        End If

        If e.Node.Tag.StartsWith("define") Then
            FindAndGoto("^[ \t]*[#]define[ \t]+" + Regex.Escape(e.Node.Text) + "[ \t]+(?:\\\s+)?(?>(?<value>[^\\\n\r]+)[ \t]*(?:\\\s+)?)*")
        ElseIf e.Node.Tag.StartsWith("function") Then
            FindAndGoto("^[ \t]*(?:\sstatic\s+stock\s+|\sstock\s+static\s+|\sstatic\s+)?" + Regex.Escape(e.Node.Text) + "\((.*)\)(?!;)\s*{")
        ElseIf e.Node.Tag.StartsWith("public") Then
            FindAndGoto("public[ \t]+" + Regex.Escape(e.Node.Text) + "[ \t]*\((.*)\)\s*{")
        ElseIf e.Node.Tag.StartsWith("stock") Then
            FindAndGoto("stock[ \t]+" + Regex.Escape(e.Node.Text) + "[ \t]*\((.*)\)\s*{")
        ElseIf e.Node.Tag.StartsWith("native") Then
            FIndAndGoto("native[ \t]+" + Regex.Escape(e.Node.Text) + "[ \t]*?\((.*)\);")
        End If
    End Sub
End Class