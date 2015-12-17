Imports System.Text.RegularExpressions

Public Class Defines
    Public Shared Sub Parse(ByRef code As String, fileName As String, ByRef parts As CodeParts, Optional add As Boolean = True)
        For Each Match As Match In Regex.Matches(code, "^[ \t]*[#]define[ \t]+(?<name>[^\s\\;]+)[ \t]*(?:\\\s+)?(?>(?<value>[^\\\n\r]+)[ \t]*(?:\\\s+)?)*", RegexOptions.Multiline)
            Dim defineName As String = Match.Groups(1).Value
            Dim defineValue As String = ""

            For Each capt As Capture In Match.Groups(2).Captures
                defineValue += capt.Value.Trim + vbCrLf
            Next

            Try
                If defineName.Contains("%") Then
                    If add Then
                        parts.Macros.Insert(0, New DefinesStruct(defineName.Trim, defineValue.Trim))
                    Else
                        parts.Macros.RemoveAll(Function(x) x.DefineName = defineName)
                    End If
                Else
                    If add Then
                        parts.Defines.Insert(0, New DefinesStruct(defineName.Trim, defineValue.Trim))
                    Else
                        parts.Defines.RemoveAll(Function(x) x.DefineName = defineName)
                    End If
                End If

            Catch ex As Exception
            End Try
        Next
    End Sub
End Class
