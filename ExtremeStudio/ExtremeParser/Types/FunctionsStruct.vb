Imports System.Text.RegularExpressions
Imports ExtremeParser

Public Structure FunctionsStruct
    Public FuncName As String
    Public FuncParameters As FunctionParameters
    Public FuncRegexMatch As Match
    Public FuncPawnDoc As PawnDoc
    Public ReturnTag As String

    Public Sub New(funcNam As String, funcPars As String, _funcRegexMatch As Match, ret As String, pwnDoc As PawnDoc)
        FuncName = funcNam
        FuncParameters = New FunctionParameters(funcPars)
        FuncRegexMatch = _funcRegexMatch
        FuncPawnDoc = pwnDoc
        ReturnTag = ret
    End Sub

    Public Shared Operator =(ByVal first As FunctionsStruct, second As FunctionsStruct)
        If first.FuncName = second.FuncName And first.FuncParameters.paramsText = second.FuncParameters.paramsText Then
            Return True
        End If
        Return False
    End Operator
    Public Shared Operator <>(ByVal first As FunctionsStruct, second As FunctionsStruct)
        If first = second Then
            Return False
        Else
            Return True
        End If
    End Operator
End Structure
