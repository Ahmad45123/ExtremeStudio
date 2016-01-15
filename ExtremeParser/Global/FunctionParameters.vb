Public Class FunctionParameters

    Public ReadOnly Property ParamsText
        Get
            Return _paramText
        End Get
    End Property

    Public Integers As New Dictionary(Of String, String)
    Public Arrays As New Dictionary(Of String, String)
    Public Floats As New Dictionary(Of String, String)
    Public PawnDoc As PawnDocParser

    Private _othersVar As New Dictionary(Of String, String) 'A function is created to handle this.
    Private _paramText As String

    Public Enum VarTypes
        TypeFloat
        TypeInteger
        TypeArray
        TypeOther
        TypeTagged
    End Enum
    Public Shared Function GetVarType(var As String) As varTypes
        If var.StartsWith("Float:") Then
            Return varTypes.TypeFloat
        ElseIf var.EndsWith("]") And var.Contains("[") Then
            Return varTypes.TypeArray
        ElseIf var.Contains(":") Then
            Return varTypes.TypeTagged
        Else
            Return varTypes.TypeInteger
        End If
    End Function

    Public Sub New(params As String)
        Dim trimmedParams = params.Replace(" ", "")
        _paramText = trimmedParams
        Dim prms As String() = trimmedParams.Split(",")
        For Each Str As String In prms
            If Str = "" Or Str = Nothing Then Continue For

            Dim def As String = ""
            If Str.Contains("=") Then def = Str.Substring(Str.IndexOf("=")).Trim()

            If getVarType(Str) = varTypes.TypeFloat Then
                Str = Str.Remove(0, 6)
                Floats.Add(Str, def)
            ElseIf getVarType(Str) = varTypes.TypeArray Then

                Dim done As Boolean = False
                While done = False
                    If Str.Contains("[") And Str.Contains("]") Then
                        Str = Str.Remove(Str.IndexOf("["), (Str.IndexOf("]") - Str.IndexOf("[")) + 1)
                    Else
                        done = True
                    End If
                End While

                Arrays.Add(Str, def)
            ElseIf getVarType(Str) = varTypes.TypeTagged Then
                _othersVar.Add(Str, def)
            Else 'Its an integer obv..
                Integers.Add(Str, def)
            End If
        Next
    End Sub

    Public Function Others(tag As String) As List(Of String)
        Dim lst As New List(Of String)
        For Each Str As String In _othersVar.Keys
            Dim vars As String() = _othersVar(Str).Split(":", 2, StringSplitOptions.None)
            If vars(0) = tag Then
                lst.Add(vars(1))
            End If
        Next
        Return lst
    End Function

    Public Enum ReturnType
        AsEnum
        AsString
    End Enum
    Public Function GetParameterType(paramName As String, returnType As returnType)
        Dim ret As varTypes = getVarType(paramName)

        If returnType = returnType.AsEnum Then
            Return ret
        Else
            If ret = varTypes.TypeArray Then
                Return "Array"
            ElseIf ret = varTypes.TypeFloat
                Return "Float"
            ElseIf ret = varTypes.TypeInteger
                Return "Integer"
            ElseIf ret = varTypes.TypeOther
                Return "Other"
            ElseIf ret = varTypes.TypeTagged
                Return "Tagged"
            End If
        End If
        Return Nothing
    End Function
End Class
