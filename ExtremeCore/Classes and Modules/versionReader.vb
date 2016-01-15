Imports System.Text.RegularExpressions

Public Class VersionReader

    Public PMajor As Integer
    Public PMinor As Integer
    Public PPatch As Integer
    Public Sub New(versionText As String)
        Dim mtch As Match = Regex.Match(versionText, "([0-9]+)\.([0-9]+)\.([0-9]+)")
        pMajor = Convert.ToInt16(mtch.Groups(1).Value)
        pMinor = Convert.ToInt16(mtch.Groups(2).Value)
        pPatch = Convert.ToInt16(mtch.Groups(3).Value)
    End Sub


    Public Enum CompareVersionResult
        VersionNew
        VersionOld
        VersionSame
    End Enum
    Public Shared Function CompareVersions(mainV As String, newV As String) As CompareVersionResult
        Dim mainVc As New versionReader(mainV)
        Dim newVc As New versionReader(newV)

        If newVC.pMajor > mainVC.pMajor Then
            Return CompareVersionResult.VersionNew
        ElseIf newVC.pMinor > mainVC.pMinor
            Return CompareVersionResult.VersionNew
        ElseIf newVC.pPatch > mainVC.pPatch
            Return CompareVersionResult.VersionNew
        Else
            If newVC.pMajor = mainVC.pMajor And newVC.pMinor = mainVC.pMinor And newVC.pPatch = mainVC.pPatch Then
                Return CompareVersionResult.VersionSame
            Else
                Return CompareVersionResult.VersionOld
            End If
        End If
    End Function
End Class
