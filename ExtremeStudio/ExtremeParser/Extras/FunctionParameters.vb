Public Class FunctionParameters

    Public ReadOnly Property paramsText
        Get
            Return paramText
        End Get
    End Property

    Public Integers As New Dictionary(Of String, String)
    Public Arrays As New Dictionary(Of String, String)
    Public Floats As New Dictionary(Of String, String)
    Public pawnDoc As PawnDoc

    Private OthersVar As New Dictionary(Of String, String) 'A function is created to handle this.
    Private paramText As String

    Public Enum varTypes
        TYPE_FLOAT
        TYPE_INTEGER
        TYPE_ARRAY
        TYPE_OTHER
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
            If Str = "" Or Str = Nothing Then Continue For

            Dim def As String = ""
            If Str.Contains("=") Then def = Str.Substring(Str.IndexOf("=")).Trim()

            If getVarType(Str) = varTypes.TYPE_FLOAT Then
                Str = Str.Remove(0, 6)
                Floats.Add(Str, def)
            ElseIf getVarType(Str) = varTypes.TYPE_ARRAY Then

                Dim done As Boolean = False
                While done = False
                    If Str.Contains("[") And Str.Contains("]") Then
                        Str = Str.Remove(Str.IndexOf("["), (Str.IndexOf("]") - Str.IndexOf("[")) + 1)
                    Else
                        done = True
                    End If
                End While

                Arrays.Add(Str, def)
            ElseIf getVarType(Str) = varTypes.TYPE_TAGGED Then
                OthersVar.Add(Str, def)
            Else 'Its an integer obv..
                Integers.Add(Str, def)
            End If
        Next
    End Sub

    Public Function Others(tag As String) As List(Of String)
        Dim lst As New List(Of String)
        For Each Str As String In OthersVar.Keys
            Dim vars As String() = OthersVar(Str).Split(":", 2, StringSplitOptions.None)
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
    Public Function GetParameterType(paramName As String, returnType As returnType)
        For Each Str As String In Integers.Keys
            If Integers(Str) = paramName Then
                If returnType = FunctionParameters.returnType.AS_STRING Then
                    Return "Integer"
                ElseIf returnType = FunctionParameters.returnType.AS_ENUM Then
                    Return varTypes.TYPE_INTEGER
                End If
            End If
        Next
        For Each Str As String In Arrays.Keys
            If Arrays(Str) = paramName Then
                If returnType = FunctionParameters.returnType.AS_STRING Then
                    Return "Array"
                ElseIf returnType = FunctionParameters.returnType.AS_ENUM Then
                    Return varTypes.TYPE_ARRAY 
                End If
            End If
        Next
        For Each Str As String In Floats.Keys
            If Floats(Str) = paramName Then
                If returnType = FunctionParameters.returnType.AS_STRING Then
                    Return "Float"
                ElseIf returnType = FunctionParameters.returnType.AS_ENUM Then
                    Return varTypes.TYPE_FLOAT
                End If
            End If
        Next

        If returnType = FunctionParameters.returnType.AS_STRING Then
            Return "Other"
        ElseIf returnType = FunctionParameters.returnType.AS_ENUM Then
            Return varTypes.TYPE_OTHER
        End If
        Return Nothing
    End Function
End Class
