Imports System.Text.RegularExpressions

Public Class Functions
    ''' <summary>
    ''' This is a list of the PAWN language keywords that look like functions.
    ''' Keywords must be seperated with a `|`
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property FuncLikeKeywords As String = "do|for|switch|while|if|foreach|else"

    Public Shared Sub Parse(ByRef code As String, fileName As String, ByRef parts As CodeParts, Optional add As Boolean = True)
        'Publics.
        For Each match As Match In Regex.Matches(code, "public[ \t]+([a-zA-Z1-3_@: \t]+)[ \t]*\((.*)\)\s*{", RegexOptions.Multiline)
            Dim funcName As String = Regex.Replace(match.Groups(1).Value, "\s", "")
            Dim funcParams As String = Regex.Replace(match.Groups(2).Value, "\s", "")
            Try
                'Get the tag if exists.
                Dim tag As String = ""
                If funcName.Contains(":") Then
                    tag = funcName.Substring(0, funcName.IndexOf(":", StringComparison.Ordinal) + 1)
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDocParser = Nothing
                If parts.PawnDocs IsNot Nothing Then
                    pwndoc = parts.PawnDocs.Find(Function(x) x.Summary = funcName)
                End If

                If add Then
                    parts.Publics.Add(New FunctionsStruct(funcName, funcParams, tag, pwndoc))
                Else
                    parts.Publics.RemoveAll(Function(x) x.FuncName = funcName)
                End If
            Catch ex As Exception
            End Try
        Next

        'Stocks
        For Each match As Match In Regex.Matches(code, "stock[ \t]+([a-zA-Z1-3_@: \t]+)[ \t]*\((.*)\)\s*{", RegexOptions.Multiline)
            Dim funcName As String = Regex.Replace(Match.Groups(1).Value, "\s", "")
            Dim funcParams As String = Regex.Replace(Match.Groups(2).Value, "\s", "")
            Try
                'Get the tag if exists.
                Dim tag As String = ""
                If funcName.Contains(":") Then
                    tag = funcName.Substring(0, funcName.IndexOf(":") + 1)
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDocParser = Nothing
                If parts.pawnDocs IsNot Nothing Then
                    pwndoc = parts.pawnDocs.Find(Function(x) x.Summary = funcName)
                End If

                If add Then
                    parts.Stocks.Add(New FunctionsStruct(funcName, funcParams, tag, pwndoc))
                Else
                    parts.Stocks.RemoveAll(Function(x) x.FuncName = funcName)
                End If
            Catch ex As Exception
            End Try
        Next

        'Functions in General.
        For Each match As Match In Regex.Matches(code, "^[ \t]*(?!" + funcLikeKeywords + ")(?:\sstatic\s+stock\s+|\sstock\s+static\s+|\sstatic\s+)?([a-zA-Z1-3_@:]+)\((.*)\)(?!;)\s*{", RegexOptions.Multiline)
            Dim funcName As String = Regex.Replace(Match.Groups(1).Value, "\s", "")
            Dim funcParams As String = Regex.Replace(Match.Groups(2).Value, "\s", "")
            Try
                'Get the tag if exists.
                Dim tag As String = ""
                If funcName.Contains(":") Then
                    tag = funcName.Substring(0, funcName.IndexOf(":") + 1)
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDocParser = Nothing
                If parts.pawnDocs IsNot Nothing Then
                    pwndoc = parts.pawnDocs.Find(Function(x) x.Summary = funcName)
                End If

                If add Then
                    parts.Functions.Add(New FunctionsStruct(funcName, funcParams, tag, pwndoc))
                Else
                    parts.Functions.RemoveAll(Function(x) x.FuncName = funcName)
                End If
            Catch ex As Exception
            End Try
        Next

        'Natives
        For Each match As Match In Regex.Matches(code, "native[ \t]+([a-zA-Z1-3_@: \t]+)[ \t]*?\((.*)\);", RegexOptions.Multiline)
            Dim funcName As String = Regex.Replace(Match.Groups(1).Value, "\s", "")
            Dim funcParams As String = Regex.Replace(Match.Groups(2).Value, "\s", "")
            Try
                'Get the tag if exists.
                Dim tag As String = ""
                If funcName.Contains(":") Then
                    tag = funcName.Substring(0, funcName.IndexOf(":") + 1)
                    funcName = funcName.Remove(0, funcName.IndexOf(":") + 1)
                End If

                'Get the PawnDoc for it.
                Dim pwndoc As PawnDocParser = Nothing
                If parts.pawnDocs IsNot Nothing Then
                    pwndoc = parts.pawnDocs.Find(Function(x) x.Summary = funcName)
                End If

                If add Then
                    parts.Natives.Add(New FunctionsStruct(funcName, funcParams, tag, pwndoc))
                Else
                    parts.Natives.RemoveAll(Function(x) x.FuncName = funcName)
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub
End Class
