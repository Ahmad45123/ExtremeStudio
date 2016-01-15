Public Class ParserException
    Inherits Exception

    Public Iden As String

    Public Sub New(message As String, idenB As String)
        MyBase.New(message)
        iden = idenB
    End Sub
End Class
