Imports ExtremeCore
Imports ExtremeParser

Public Class CodeParts
    'The Object Itself: 
    Public FileName As String
    Public FilePath As String
    Public Defines As New List(Of DefinesStruct)
    Public Macros As New List(Of DefinesStruct)
    Public Functions As New List(Of FunctionsStruct)
    Public Stocks As New List(Of FunctionsStruct)
    Public Publics As New List(Of FunctionsStruct)
    Public Natives As New List(Of FunctionsStruct)
    Public Enums As New List(Of EnumsStruct)
    Public publicVariables As New List(Of VarStruct)
    Public pawnDocs As New List(Of PawnDocParser)

#Region "Includes Codes"
    'Properties.
    Public Property ParentInclude As CodeParts
    Public Property RootInclude As CodeParts
    Public Property Includes As ICollection(Of CodeParts)

    Public Sub New()
        Me.Includes = New LinkedList(Of CodeParts)()
        RootInclude = Me
    End Sub

    Public Sub AddInclude(child As CodeParts)
        child.ParentInclude = Me
        Me.Includes.Add(child)
    End Sub

    Public Function FlattenIncludes() As IEnumerable(Of CodeParts)
        Return {Me}.Union(Includes.SelectMany(Function(x) x.FlattenIncludes()))
    End Function

    Public Sub RemoveIncludeByName(inc As String)
        For Each part As CodeParts In FlattenIncludes()
            If part.FileName = inc Then
                Includes.Remove(part)
                Exit For
            End If
        Next
    End Sub
#End Region
End Class