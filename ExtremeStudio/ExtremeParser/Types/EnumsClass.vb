Imports ExtremeParser

Public Class EnumsClass
    Private _enumName As String
    Private _enumContents As List(Of EnumsContentsClass)

    Public Sub New(name As String, contents As List(Of EnumsContentsClass))
        _enumName = name
        _enumContents = contents
    End Sub

    Public ReadOnly Property EnumName As String
        Get
            Return _enumName
        End Get
    End Property

    Public ReadOnly Property EnumContents As List(Of EnumsContentsClass)
        Get
            Return _enumContents
        End Get
    End Property


End Class

Public Class EnumsContentsClass
    Private _content As String
    Public ReadOnly Property Content As String
        Get
            Return _content
        End Get
    End Property

    Private _type As FunctionParameters.varTypes
    Public ReadOnly Property Type As FunctionParameters.varTypes
        Get
            Return _type
        End Get
    End Property

    Public Sub New(cntn As String, tpe As FunctionParameters.varTypes)
        _content = cntn : _type = tpe
    End Sub
End Class