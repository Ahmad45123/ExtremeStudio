Imports System.Text.RegularExpressions
Imports ExtremeParser

Public Structure FunctionsStruct
    Public FuncName As String
    Public FuncParameters As FunctionParameters
    Public FuncPawnDoc As PawnDocParser
    Public ReturnTag As String

    Public Sub New(funcNam As String, funcPars As String, ret As String, pwnDoc As PawnDocParser)
        FuncName = funcNam
        FuncParameters = New FunctionParameters(funcPars)
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
