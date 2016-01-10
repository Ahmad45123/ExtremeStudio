Imports System.IO
Imports System.Text.RegularExpressions
Imports ExtremeCore

Public Class Includes
    Public Shared Sub Parse(ByRef code As String, filePath As String, prjPath As String, ByRef parts As CodeParts, ByRef errors As ExceptionsList, Optional add As Boolean = True)
        For Each Match As Match In Regex.Matches(code, "\#include[ \t]+([^\s]+)", RegexOptions.Multiline)
            Dim text As String = Match.Groups(1).Value
            Dim fullPath As String = ""

            Dim type = text.Substring(0, 1)

            If type = Chr(34) Then
                'Remove the quotes.
                Try
                    text = text.Remove(text.IndexOf(Chr(34)), 1)
                    text = text.Remove(text.IndexOf(Chr(34)), 1)
                Catch ex As Exception
                    Continue For
                End Try

                fullPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(filePath)), text)
                If Not fullPath.EndsWith(".inc") Then fullPath += ".inc"
            ElseIf type = "<"
                'Remove the brackets.
                Try
                    text = text.Remove(text.IndexOf("<"), 1)
                    text = text.Remove(text.IndexOf(">"), 1)
                Catch ex As Exception
                    Continue For
                End Try

                fullPath = prjPath + "\pawno\include\" + text
                If Not fullPath.EndsWith(".inc") Then fullPath += ".inc"
            Else
                fullPath = prjPath + "\pawno\include\" + text
                If Not fullPath.EndsWith(".inc") Then fullPath += ".inc"
            End If
            Try

                'Create a new codeparts object for the includes cause they are needed.
                If add Then
                    'Check if was already parsed or not.
                    If Parser.IsParsed(parts.RootInclude, fullPath) Then
                        Continue For
                    End If

                    'Else: 
                    'Check if exists or not: 
                    If (File.Exists(fullPath)) Then
                        Dim part As New CodeParts

                        'Setup and add to list.
                        part.FilePath = fullPath
                        parts.AddInclude(part)

                        Dim prs As New Parser(part, My.Computer.FileSystem.ReadAllText(fullPath), fullPath, prjPath, True)
                        errors.exceptionsList.AddRange(prs.errors.exceptionsList)
                    Else
                        errors.exceptionsList.Add(New IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)))
                    End If

                Else
                    Try
                        'Here if the include is REMOVED, There is no need to parse it all again cause we already know that we just need to remove the whole include.
                        parts.RemoveIncludeByHash(getFileHash(fullPath))
                    Catch ex As Exception
                    End Try
                End If

                'Exceptions.
            Catch ex As DirectoryNotFoundException
                errors.exceptionsList.Add(New IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)))
            Catch ex As FileNotFoundException
                errors.exceptionsList.Add(New IncludeNotFoundException(Path.GetFileNameWithoutExtension(fullPath)))
            End Try
        Next
    End Sub
End Class
