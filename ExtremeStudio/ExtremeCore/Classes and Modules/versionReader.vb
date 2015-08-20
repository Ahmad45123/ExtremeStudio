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



    Public Shared Function newVersion(mainV As String, newV As String) As Boolean
        Dim mainVC As New versionReader(mainV)
        Dim newVC As New versionReader(newV)

        If newVC.pMajor > mainVC.pMajor Then
            Return True
        ElseIf newVC.pMinor > mainVC.pMinor
            Return True
        ElseIf newVC.pPatch > mainVC.pPatch
            Return True
        Else
            Return False
        End If
    End Function
End Class
