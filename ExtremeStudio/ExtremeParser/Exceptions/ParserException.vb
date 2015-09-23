Public Class ParserException
    Inherits Exception

    Public iden As String

    Public Sub New(message As String, iden_b As String)
        MyBase.New(message)
        iden = iden_b
    End Sub
End Class
