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
End Class
