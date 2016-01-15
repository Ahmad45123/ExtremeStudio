Imports System.Text.RegularExpressions

Public Structure DefinesStruct

    'No properties for speed.
    Public DefineName As String
    Public DefineValue As String

    Public Sub New(defName As String, defValue As String)
        DefineName = defName
        DefineValue = defValue
    End Sub

    Public Shared Operator =(ByVal first As DefinesStruct, second As DefinesStruct)
        If first.DefineName = second.DefineName And first.DefineValue = second.DefineValue Then
            Return True
        End If
        Return False
    End Operator
    Public Shared Operator <>(ByVal first As DefinesStruct, second As DefinesStruct)
        If first = second Then
            Return False
        Else
            Return True
        End If
    End Operator
End Structure
