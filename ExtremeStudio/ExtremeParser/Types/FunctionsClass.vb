Imports System.Text.RegularExpressions
Imports ExtremeParser

Public Class FunctionsClass
    Private _funcName As String
    Public ReadOnly Property FuncName As String
        Get
            Return _funcName
        End Get
    End Property

    Private _funcParameters As FunctionParameters
    Public ReadOnly Property FuncParameters As FunctionParameters
        Get
            Return _funcParameters
        End Get
    End Property

    Private _funcMatch As Match
    Public ReadOnly Property FuncRegexMatch As Match
        Get
            Return _funcMatch
        End Get
    End Property

    Private _funcPawnDoc As PawnDoc
    Public ReadOnly Property FuncPawnDoc As PawnDoc
        Get
            Return _funcPawnDoc
        End Get
    End Property

    Private _returnTag As String
    Public ReadOnly Property ReturnTag As String
        Get
            Return _returnTag
        End Get
    End Property

    Public Sub New(funcName As String, funcPars As String, funcRegexMatch As Match, ret As String, pwnDoc As PawnDoc)
        _funcName = funcName
        _funcParameters = New FunctionParameters(funcPars)
        _funcMatch = funcRegexMatch
        _funcPawnDoc = pwnDoc
        _returnTag = ret
    End Sub

End Class
