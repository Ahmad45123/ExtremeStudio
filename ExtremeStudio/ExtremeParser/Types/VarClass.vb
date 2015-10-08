Public Class VarClass

    Private _varName As String
    Public ReadOnly Property VarName As String
        Get
            Return _varName
        End Get
    End Property

    Private _varTag As String
    Public ReadOnly Property VarTag As String
        Get
            Return _varTag
        End Get
    End Property

    Private _varArrays As List(Of String)
    Public ReadOnly Property VarArrays As List(Of String)
        Get
            Return _varArrays
        End Get
    End Property

    Private _defaultValue As String
    Public ReadOnly Property DefaultValue As String
        Get
            Return _defaultValue
        End Get
    End Property

    Public Sub New(name As String, tag As String, def As String, arrays As List(Of String))
        _varName = name
        _varTag = tag
        _varArrays = arrays
        _defaultValue = def
    End Sub

    Public Shared Operator =(ByVal first As VarClass, second As VarClass)
        If first.VarName = second.VarName And first.VarTag = second.VarTag And first.DefaultValue = second.DefaultValue Then
            Return True
        End If
        Return False
    End Operator
    Public Shared Operator <>(ByVal first As VarClass, second As VarClass)
        If first = second Then
            Return False
        Else
            Return True
        End If
    End Operator

End Class
