Imports System.IO
Imports ExtremeParser

Public Class RemoveParser
    Implements IParser

    Public Property errors As New ExceptionsList Implements IParser.errors

    Public Sub New(ByRef codeParts As CodeParts, code As String, filePath As String, projectPath As String)
        'Make sure then code is not nothing.
        If code = Nothing Then Exit Sub

        'Get the name
        Dim name As String = Path.GetFileNameWithoutExtension(filePath)

        'Now exit if it was not actually parsed.
        If codeParts.Includes.Contains(name) = False Then
            Exit Sub
        Else
            'Else, Remove it to the list.
            codeParts.Includes.Remove(name)
        End If

        'Remove singline comments.
        Cleaner.Parse(code, True, False, False, False)

        'Parse for pawndocs.
        PawnDoc.Parse(code, name, codeParts, False)

        'Remove multiline comments.
        Cleaner.Parse(code, False, True, False, False)

        'Parse for Enums.
        Enums.Parse(code, name, codeParts, False)

        'Now remove braces.
        Cleaner.Parse(code, False, False, True, False)

        'Parse for includes. (BEFORE REMOVING STRINGS)
        Includes.Parse(code, filePath, projectPath, codeParts, errors, False)

        'Remove strings
        Cleaner.Parse(code, False, False, False, True)

        'Replace defines and macros.
        DefReplacer.Parse(code, name, codeParts, False)

        'Parse defines and macros.
        Defines.Parse(code, name, codeParts, False)

        'Now parse funcs.
        Functions.Parse(code, name, codeParts, False)

        'Parse global vars.
        globalVariables.Parse(code, name, codeParts, False)

        'Parse if defines.
        IfDefines.Parse(code, filePath, projectPath, codeParts, False)
    End Sub
End Class
