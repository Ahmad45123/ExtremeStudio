Public Class FunctionParameters

    Public ReadOnly Property paramsText
        Get
            Return paramText
        End Get
    End Property

    Public Integers As New List(Of String)
    Public Arrays As New List(Of String)
    Public Floats As New List(Of String)
    Public pawnDoc As PawnDoc

    Private OthersVar As New List(Of String) 'A function is created to handle this.
    Private paramText As String

    Public Enum varTypes
        TYPE_FLOAT
        TYPE_INTEGER
        TYPE_ARRAY
        TYPE_TAGGED
    End Enum
    Public Shared Function getVarType(var As String) As varTypes
        If var.StartsWith("Float:") Then
            Return varTypes.TYPE_FLOAT
        ElseIf var.EndsWith("]") And var.Contains("[") Then
            Return varTypes.TYPE_ARRAY
        ElseIf var.Contains(":") Then
            Return varTypes.TYPE_TAGGED
        Else
            Return varTypes.TYPE_INTEGER
        End If
    End Function

    Public Sub New(params As String)
        Dim trimmedParams = params.Replace(" ", "")
        paramText = trimmedParams
        Dim prms As String() = trimmedParams.Split(",")
        For Each Str As String In prms
            If getVarType(Str) = varTypes.TYPE_FLOAT Then
                Str = Str.Remove(0, 6)
                Floats.Add(Str)
            ElseIf getVarType(Str) = varTypes.TYPE_ARRAY Then
                Str = Str.Remove(Str.IndexOf("["), (Str.IndexOf("]") - Str.IndexOf("[")) + 1)
                Arrays.Add(Str)
            ElseIf getVarType(Str) = varTypes.TYPE_TAGGED Then
                OthersVar.Add(Str)
            Else 'Its an integer obv..
                Integers.Add(Str)
            End If
        Next
    End Sub

    Public Function Others(tag As String) As List(Of String)
        Dim lst As New List(Of String)
        For Each Str As String In OthersVar
            Dim vars As String() = Str.Split(":", 2, StringSplitOptions.None)
            If vars(0) = tag Then
                lst.Add(vars(1))
            End If
        Next
        Return lst
    End Function

    Public Enum returnType
        AS_ENUM
        AS_STRING
    End Enum
    Public Enum paramTypes
        [INTEGER]
        ARRAY
        FLOAT
        OTHER
    End Enum
    Public Function GetParameterType(paramName As String, returnType As returnType)
        For Each Str As String In Integers
            If Str = paramName Then
                If returnType = FunctionParameters.returnType.AS_STRING Then
                    Return "Integer"
                ElseIf returnType = FunctionParameters.returnType.AS_ENUM Then
                    Return paramTypes.INTEGER
                End If
            End If
        Next
        For Each Str As String In Arrays
            If Str = paramName Then
                If returnType = FunctionParameters.returnType.AS_STRING Then
                    Return "Array"
                ElseIf returnType = FunctionParameters.returnType.AS_ENUM Then
                    Return paramTypes.ARRAY
                End If
            End If
        Next
        For Each Str As String In Floats
            If Str = paramName Then
                If returnType = FunctionParameters.returnType.AS_STRING Then
                    Return "Float"
                ElseIf returnType = FunctionParameters.returnType.AS_ENUM Then
                    Return paramTypes.FLOAT
                End If
            End If
        Next

        If returnType = FunctionParameters.returnType.AS_STRING Then
            Return "Other"
        ElseIf returnType = FunctionParameters.returnType.AS_ENUM Then
            Return paramTypes.OTHER
        End If
        Return Nothing
    End Function
End Class
