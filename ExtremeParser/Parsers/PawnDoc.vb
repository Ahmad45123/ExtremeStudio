Imports System.Text.RegularExpressions

Public Class PawnDoc
    Public Shared Sub Parse(ByRef code As String, fileName As String, ByRef parts As CodeParts, Optional add As Boolean = True)
        For Each Match As Match In Regex.Matches(code, "/\*\*([\s\S]*?)\*/")
            Dim val As String = Match.Groups(1).Value 'Group 0 which contains only the internal text without the start and the end.

            If Not val.Contains("<summary>") Or Not val.Contains("</summary>") Then Continue For

            Try
                Dim pwn = New PawnDocParser(val)
                If add Then
                    parts.pawnDocs.Add(pwn)
                Else
                    parts.pawnDocs.RemoveAll(Function(x) x.Summary = pwn.Summary)
                End If
            Catch ex As ParserException
                Throw New ParserException(ex.Message, "")
            End Try
        Next
    End Sub
End Class
