Public Class CodeParts
    'NOTE: The below KeyValuePairs is to store the filename of which the certain func is stored to.
    'Use this to access stuff in a certain include: 'Defines.FindAll(Function(x) x.Key = "FILE_NAME")'
    'And to access all available includes: Just use the list.
    Public Defines As New List(Of KeyValuePair(Of String, DefinesStruct))
    Public Macros As New List(Of KeyValuePair(Of String, DefinesStruct))
    Public Functions As New List(Of KeyValuePair(Of String, FunctionsStruct))
    Public Stocks As New List(Of KeyValuePair(Of String, FunctionsStruct))
    Public Publics As New List(Of KeyValuePair(Of String, FunctionsStruct))
    Public Natives As New List(Of KeyValuePair(Of String, FunctionsStruct))
    Public Enums As New List(Of KeyValuePair(Of String, EnumsStruct))
    Public publicVariables As New List(Of KeyValuePair(Of String, VarStruct))
    Public pawnDocs As New List(Of KeyValuePair(Of String, PawnDocParser))

    'This just stores the name of includes.
    Public Includes As New List(Of String)

    Public Sub RemoveFromAll(fileName As String)
        Defines.RemoveAll(Function(x) x.Key = fileName)
        Macros.RemoveAll(Function(x) x.Key = fileName)
        Functions.RemoveAll(Function(x) x.Key = fileName)
        Stocks.RemoveAll(Function(x) x.Key = fileName)
        Publics.RemoveAll(Function(x) x.Key = fileName)
        Natives.RemoveAll(Function(x) x.Key = fileName)
        Enums.RemoveAll(Function(x) x.Key = fileName)
        publicVariables.RemoveAll(Function(x) x.Key = fileName)
        pawnDocs.RemoveAll(Function(x) x.Key = fileName)
    End Sub
End Class
