Imports ExtremeParser

Public Class CodeParts
    Public _fileName As String

    Public parentPart As CodeParts

    Public Defines As New List(Of DefinesStruct)
    Public Macros As New List(Of DefinesStruct)
    Public Functions As New List(Of FunctionsStruct)
    Public Stocks As New List(Of FunctionsStruct)
    Public Publics As New List(Of FunctionsStruct)
    Public Natives As New List(Of FunctionsStruct)
    Public Enums As New List(Of EnumsStruct)
    Public publicVariables As New List(Of VarStruct)
    Public pawnDocs As New List(Of PawnDocParser)

    'This just stores the name of includes.
    Public Includes As New List(Of CodeParts)

    'Helper Funcs.
    Public Sub IsAlreadyParsed(ByRef res As Boolean, ByVal str As String, Optional parts As CodeParts = Nothing)
        If parts Is Nothing Then parts = Me

        For Each inc In parts.Includes
            If inc._fileName = str Then res = True : Exit Sub

            If inc.Includes.Count <> 0 Then
                IsAlreadyParsed(res, str, inc)
            End If
        Next

    End Sub

End Class