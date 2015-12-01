Imports System.IO
Imports ExtremeParser

Public Class IfDefinedParser
    Implements IParser

    Public Property errors As New ExceptionsList Implements IParser.errors

    Public Sub New(ByRef codeParts As CodeParts, code As String, filePath As String, projectPath As String, add As Boolean)
        'Make sure then code is not nothing.
        If code = Nothing Then Exit Sub

        'Get the name
        Dim name As String = Path.GetFileNameWithoutExtension(filePath)

        'Remove singline comments.
        Cleaner.Parse(code, True, False, False, False)

        'Parse for pawndocs.
        PawnDoc.Parse(code, name, codeParts, add)

        'Remove multiline comments.
        Cleaner.Parse(code, False, True, False, False)

        'Parse for Enums.
        Enums.Parse(code, name, codeParts, add)

        'Now remove braces.
        Cleaner.Parse(code, False, False, True, False)

        'Parse for includes. (BEFORE REMOVING STRINGS)
        Includes.Parse(code, filePath, projectPath, codeParts, errors, add)

        'Remove strings
        Cleaner.Parse(code, False, False, False, True)

        If add = False Then
            'Replace defines and macros.
            DefReplacer.Parse(code, name, codeParts, add)
        End If

        'Parse defines and macros.
        Defines.Parse(code, name, codeParts, add)

        If add = True Then
            'Replace defines and macros.
            DefReplacer.Parse(code, name, codeParts, add)
        End If

        'Now parse funcs.
        Functions.Parse(code, name, codeParts, add)

        'Parse global vars.
        globalVariables.Parse(code, name, codeParts, add)

        'Parse if defines.
        IfDefines.Parse(code, filePath, projectPath, codeParts, add)
    End Sub
End Class
