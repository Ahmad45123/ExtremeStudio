Imports System.Windows.Forms

Public Class TreeNodeStateSaving
    Dim _nodeStates
    Public Sub SaveTreeState(nodes As TreeNodeCollection, Optional newFunc As Boolean = True)
        If newFunc = True Then _nodeStates = New List(Of String)
        For Each node As TreeNode In nodes
            If node.IsExpanded Then
                _nodeStates.Add(node.Text)
                SaveTreeState(node.Nodes, False)
            End If
        Next
    End Sub
    Public Sub RestoreTreeState(tree As TreeView)
        For Each nodeName As String In _nodeStates
            RecurseNodes(tree, NodeName)
        Next
        _nodeStates = Nothing 'Clear
    End Sub

    Private Sub RecurseNodes(treeView As TreeView, ByVal searchValue As String)
        For Each tn As TreeNode In treeView.Nodes
            If tn.Text = searchValue Then
                tn.Expand()
                Exit For
            End If
            If tn.Nodes.Count > 0 Then
                For Each cTn As TreeNode In tn.Nodes
                    recurseChildren(cTn, searchValue)
                Next
            End If
        Next
    End Sub
    Private Sub RecurseChildren(ByVal tn As TreeNode, ByVal searchValue As String)
        If tn.Text = searchValue Then
            tn.Expand()
            Exit Sub
        End If
        If tn.Nodes.Count > 0 Then
            For Each tnC As TreeNode In tn.Nodes
                recurseChildren(tnC, searchValue)
            Next
        End If
    End Sub
End Class
