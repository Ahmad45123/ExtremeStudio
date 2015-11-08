Public Structure VarStruct

    Public VarName As String
    Public VarTag As String
    Public VarArrays As List(Of String)
    Public DefaultValue As String

    Public Sub New(name As String, tag As String, def As String, arrays As List(Of String))
        VarName = name
        VarTag = tag
        VarArrays = arrays
        DefaultValue = def
    End Sub

    Public Shared Operator =(ByVal first As VarStruct, second As VarStruct)
        If first.VarName = second.VarName And first.VarTag = second.VarTag And first.DefaultValue = second.DefaultValue Then
            Return True
        End If
        Return False
    End Operator
    Public Shared Operator <>(ByVal first As VarStruct, second As VarStruct)
        If first = second Then
            Return False
        Else
            Return True
        End If
    End Operator

End Structure
