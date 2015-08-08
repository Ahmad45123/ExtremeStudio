Public Class ObjectExplorerDockItems

    Private Sub Ref()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class

Public Class objectExplorerItem
    Public Sub New(name As String, iden As String)
        Me.Name = name
        Identifier = iden
    End Sub

    Public Property Name As String
    Public Property Identifier As String
End Class