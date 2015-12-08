Imports System.IO
Imports ExtremeParser

Public Class AddParser
    Implements IParser

    Public Property errors As New ExceptionsList Implements IParser.errors

    Public Sub New(ByRef codeParts As CodeParts, code As String, filePath As String, projectPath As String)
        'Make sure then code is not nothing.
        If code = Nothing Then Exit Sub

        'Get the name
        Dim name As String = Path.GetFileNameWithoutExtension(filePath)

        'Now exit if already parsed.
        If codeParts.parentPart IsNot Nothing Then
            Dim res As Boolean = False : codeParts.parentPart.IsAlreadyParsed(res, name)
            If res = True Then
                Exit Sub
            End If
        Else
            Dim res As Boolean = False : codeParts.IsAlreadyParsed(res, name)
            If Res = True Then
                Exit Sub
            End If
        End If

        'Remove singline comments.
        Cleaner.Parse(code, True, False, False, False)

        'Parse for pawndocs.
        PawnDoc.Parse(code, name, codeParts, True)

        'Remove multiline comments.
        Cleaner.Parse(code, False, True, False, False)

        'Parse for Enums.
        Enums.Parse(code, name, codeParts, True)

        'Now remove braces.
        Cleaner.Parse(code, False, False, True, False)

        'Parse for includes. (BEFORE REMOVING STRINGS)
        Includes.Parse(code, filePath, projectPath, codeParts, errors, True)

        'Remove strings
        Cleaner.Parse(code, False, False, False, True)

        'Parse defines and macros.
        Defines.Parse(code, name, codeParts, True)

        'Replace defines and macros.
        DefReplacer.Parse(code, name, codeParts, True)

        'Now parse funcs.
        Functions.Parse(code, name, codeParts, True)

        'Parse global vars.
        globalVariables.Parse(code, name, codeParts, True)

        'Parse if defines.
        IfDefines.Parse(code, filePath, projectPath, codeParts, True)
    End Sub
End Class
