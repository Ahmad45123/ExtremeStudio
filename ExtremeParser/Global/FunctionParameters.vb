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
        For Each str As String In prms
            If str = "" Or str = Nothing Then Continue For

            Dim def As String = ""
            If str.Contains("=") Then def = str.Substring(str.IndexOf("=")).Trim()

            If GetVarType(str) = VarTypes.TypeFloat Then
                str = str.Remove(0, 6)
                Floats.Add(str, def)
            ElseIf GetVarType(str) = VarTypes.TypeArray Then

                Dim done As Boolean = False
                While done = False
                    If str.Contains("[") And str.Contains("]") Then
                        str = str.Remove(str.IndexOf("["), (str.IndexOf("]") - str.IndexOf("[")) + 1)
                    Else
                        done = True
                    End If
                End While

                Arrays.Add(str, def)
            ElseIf GetVarType(str) = VarTypes.TypeTagged Then
                _othersVar.Add(str, def)
            Else 'Its an integer obv..
                Integers.Add(str, def)
            End If
        Next
    End Sub

    Public Function Others(tag As String) As List(Of String)
        Return (From str In _othersVar.Keys Select vars = _othersVar(str).Split(":", 2, StringSplitOptions.None) Where vars(0) = tag Select vars(1)).ToList()
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
