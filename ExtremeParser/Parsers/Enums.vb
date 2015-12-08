Imports System.Text.RegularExpressions

Public Class Enums
    Public Shared Sub Parse(ByRef code As String, fileName As String, ByRef parts As CodeParts, Optional add As Boolean = True)
        For Each Match As Match In Regex.Matches(code, "enum\s+([^\n;\(\)\{\}\s]*)\s+(?:(?:[{])([^}]+)(?:[}]))")
            Dim enumds As String() = Match.Groups(2).Value.Split(",")

            'Variable to store the enums contents.
            Dim enumStuff As New List(Of EnumsContentsClass)

            For Each enuma As String In enumds
                'Check if empty
                If enuma Is Nothing Or enuma.Trim = "" Then Continue For

                Dim length As Integer = enuma.Length + 1
                enuma = enuma.Trim
                Dim type = FunctionParameters.getVarType(enuma)

                'Do what needs to be changed
                If type = FunctionParameters.varTypes.TYPE_FLOAT Then
                    enuma = enuma.Remove(0, 6)
                ElseIf type = FunctionParameters.varTypes.TYPE_ARRAY Then
                    enuma = enuma.Remove(enuma.IndexOf("["), (enuma.IndexOf("]") - enuma.IndexOf("[")) + 1)
                ElseIf type = FunctionParameters.varTypes.TYPE_TAGGED Then
                    enuma = enuma.Remove(0, enuma.IndexOf(":") + 1)
                End If

                Try
                    enumStuff.Add(New EnumsContentsClass(enuma, type))
                Catch ex As Exception
                End Try
            Next

            'Now add it to the actual list.
            If add Then
                parts.Enums.Add(New EnumsStruct(Match.Groups(1).Value.Trim, enumStuff))
            Else
                parts.Enums.RemoveAll(Function(x) x.EnumName = Match.Groups(1).Value.Trim)
            End If
        Next
    End Sub
End Class
