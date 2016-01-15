Imports System.IO
Imports ExtremeCore
Imports ExtremeParser

Public Class CodeParts
    Public FileName As String
    Public FilePath As String
    Public FileHash As String

    'The Object Itself: 
    Public Defines As New List(Of DefinesStruct)
    Public Macros As New List(Of DefinesStruct)
    Public Functions As New List(Of FunctionsStruct)
    Public Stocks As New List(Of FunctionsStruct)
    Public Publics As New List(Of FunctionsStruct)
    Public Natives As New List(Of FunctionsStruct)
    Public Enums As New List(Of EnumsStruct)
    Public PublicVariables As New List(Of VarStruct)
    Public PawnDocs As New List(Of PawnDocParser)

    Public Function Clone() As CodeParts
        Dim ret As New CodeParts
        ret.FileName = FileName
        ret.FilePath = FilePath
        ret.fileHash = fileHash
        ret.Defines = Defines.ToList
        ret.Macros = Macros.ToList
        ret.Functions = Functions.ToList
        ret.Stocks = Stocks.ToList
        ret.Publics = Publics.ToList
        ret.Natives = Natives.ToList
        ret.Enums = Enums.ToList
        ret.publicVariables = publicVariables.ToList
        ret.pawnDocs = pawnDocs.ToList

        Return ret
    End Function

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
        'Set its info.
        child.ParentInclude = Me
        child.RootInclude = Me.RootInclude
        child.FileName = Path.GetFileNameWithoutExtension(child.FilePath)
        child.fileHash = getFileHash(child.FilePath)

        Me.Includes.Add(child)
    End Sub

    Public Function FlattenIncludes() As IEnumerable(Of CodeParts)
        Return {Me}.Union(Includes.SelectMany(Function(x) x.FlattenIncludes()))
    End Function

    Public Sub RemoveIncludeByHash(incHash As String)
        For Each part As CodeParts In FlattenIncludes()
            If part.fileHash = incHash Then
                Includes.Remove(part)
                Exit For
            End If
        Next
    End Sub
#End Region
End Class