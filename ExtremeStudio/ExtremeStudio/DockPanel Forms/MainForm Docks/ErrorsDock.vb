Public Class ErrorsDock

    Private Sub parserErrors_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles parserErrors.CellMouseDoubleClick
        If e.RowIndex = -1 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim startPos As Integer = parserErrors.Rows(e.RowIndex).Cells(1).Value
            MainForm.CurrentScintilla.GotoPosition(startPos)
        End If
    End Sub
End Class