Imports System.Text.RegularExpressions

Public Class globalVariables
    Public Shared Sub Parse(ByRef code As String, fileName As String, ByRef parts As CodeParts, Optional add As Boolean = True)
        For Each match As Match In Regex.Matches(code, "(?:\s?stock\s+static|\s?static\s+stock|\s?new\s+stock|\s?new|\s?static|\s?stock)\s*([\s\S]*?);", RegexOptions.Multiline)
            Dim varName As String = match.Groups(1).Value

            'Remove all whitespace.
            varName = varName.Replace(" ", "")
            varName = varName.Replace(vbTab, "")

            'Now if there is multiple variables in one.. Split it.
            Dim allVars As String()

            If varName.Contains(",") Then
                allVars = varName.Split(",")
            Else
                allVars = {varName}
            End If

            'Loop through all.
            For Each str As String In allVars
                'Get tag and remove.
                Dim tag As String = ""
                If str.Contains(":") Then
                    tag = str.Substring(0, str.IndexOf(":") + 1)
                    str = str.Remove(0, str.IndexOf(":") + 1)
                End If

                'Get and Remove all arrays.
                Dim arrays As New List(Of String)
                For Each mtch As Match In Regex.Matches(str, "(?<=\[)(?>[^\[\]]+|\[(?<DEPTH>)|\](?<-DEPTH>))*(?(DEPTH)(?!))(?=\])")
                    arrays.Add(mtch.Value)
                Next
                str = Regex.Replace(str, "\[(?<=\[)(?>[^\[\]]+|\[(?<DEPTH>)|\](?<-DEPTH>))*(?(DEPTH)(?!))(?=\])\]", "")

                'Get then Remove default
                Dim def As String = ""
                If str.Contains("=") Then
                    def = str.Substring(str.IndexOf("="), str.Length - str.IndexOf("="))
                    str = str.Remove(str.IndexOf("="), str.Length - str.IndexOf("="))
                End If

                'Add
                If add Then
                    parts.publicVariables.Add(New KeyValuePair(Of String, VarStruct)(fileName, New VarStruct(str, tag, def, arrays)))
                Else
                    parts.publicVariables.RemoveAll(Function(x) x.Key = fileName And x.Value.VarName = str)
                End If
            Next
        Next
    End Sub
End Class
