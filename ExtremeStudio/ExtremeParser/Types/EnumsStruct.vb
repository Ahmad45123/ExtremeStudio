Imports ExtremeParser

Public Structure EnumsStruct
    Public EnumName As String
    Public EnumContents As List(Of EnumsContentsClass)

    Public Sub New(name As String, contents As List(Of EnumsContentsClass))
        EnumName = name
        EnumContents = contents
    End Sub

    Public Shared Operator =(ByVal first As EnumsStruct, second As EnumsStruct)
        If first.EnumName = second.EnumName Then
            For Each enm In first.EnumContents
                For Each enma In second.EnumContents
                    If enm <> enma Then
                        Return False
                    End If
                Next
            Next

            Return True
        End If
        Return False
    End Operator
    Public Shared Operator <>(ByVal first As EnumsStruct, second As EnumsStruct)
        If first = second Then
            Return False
        Else
            Return True
        End If
    End Operator

End Structure

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

    Public Shared Operator =(ByVal first As EnumsContentsClass, second As EnumsContentsClass)
        If first.Content = second.Content And first.Type = second.Type Then
            Return True
        End If
        Return False
    End Operator
    Public Shared Operator <>(ByVal first As EnumsContentsClass, second As EnumsContentsClass)
        If first = second Then
            Return False
        Else
            Return True
        End If
    End Operator
End Class