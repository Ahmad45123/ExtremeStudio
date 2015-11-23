Imports System.Text.RegularExpressions

Public Class versionReader

    Public pMajor As Integer
    Public pMinor As Integer
    Public pPatch As Integer
    Public Sub New(versionText As String)
        Dim mtch As Match = Regex.Match(versionText, "([0-9]+)\.([0-9]+)\.([0-9]+)")
        pMajor = Convert.ToInt16(mtch.Groups(1).Value)
        pMinor = Convert.ToInt16(mtch.Groups(2).Value)
        pPatch = Convert.ToInt16(mtch.Groups(3).Value)
    End Sub


    Public Enum CompareVersionResult
        VERSION_NEW
        VERSION_OLD
        VERSION_SAME
    End Enum
    Public Shared Function CompareVersions(mainV As String, newV As String) As CompareVersionResult
        Dim mainVC As New versionReader(mainV)
        Dim newVC As New versionReader(newV)

        If newVC.pMajor > mainVC.pMajor Then
            Return CompareVersionResult.VERSION_NEW
        ElseIf newVC.pMinor > mainVC.pMinor
            Return CompareVersionResult.VERSION_NEW
        ElseIf newVC.pPatch > mainVC.pPatch
            Return CompareVersionResult.VERSION_NEW
        Else
            If newVC.pMajor = mainVC.pMajor And newVC.pMinor = mainVC.pMinor And newVC.pPatch = mainVC.pPatch Then
                Return CompareVersionResult.VERSION_SAME
            Else
                Return CompareVersionResult.VERSION_OLD
            End If
        End If
    End Function
End Class
