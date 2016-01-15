Public Class IncludeNotFoundException
    Inherits Exception

    Public Sub New(name As String)
        includeName = name
    End Sub

    Public Property IncludeName As String


End Class
