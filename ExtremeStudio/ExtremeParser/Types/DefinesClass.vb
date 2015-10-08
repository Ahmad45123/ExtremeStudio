Imports System.Text.RegularExpressions

Public Class DefinesClass

    Private _defineName As String
    Public ReadOnly Property DefineName As String
        Get
            Return _defineName
        End Get
    End Property

    Private _defineValue As String
    Public ReadOnly Property DefineValue As String
        Get
            Return _defineValue
        End Get
    End Property

    Private _regexMatch As Match
    Public ReadOnly Property RegexMatch As Match
        Get
            Return _regexMatch
        End Get
    End Property

    Public Sub New(defineName As String, defineValue As String, RegexMatch As Match)
        _defineName = defineName
        _defineValue = defineValue
        _regexMatch = RegexMatch
    End Sub

    Public Shared Operator =(ByVal first As DefinesClass, second As DefinesClass)
        If first.DefineName = second.DefineName And first.DefineValue = second.DefineValue Then
            Return True
        End If
        Return False
    End Operator
    Public Shared Operator <>(ByVal first As DefinesClass, second As DefinesClass)
        If first = second Then
            Return False
        Else
            Return True
        End If
    End Operator
End Class
