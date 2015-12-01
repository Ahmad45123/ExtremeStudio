Imports System.Text.RegularExpressions

Public Class IfDefines
    Public Shared Sub Parse(ByRef code As String, filePath As String, prjPath As String, ByRef parts As CodeParts, Optional add As Boolean = True)
        For Each match As Match In Regex.Matches(code, "\#if[ \t]+(!)?defined[ \t]+(.+)([\s\S]*?)\#endif", RegexOptions.Multiline)
            Dim isNt As Boolean = IIf(match.Groups(1).Value = "", False, True)
            Dim condition As String = ""
            Dim mainCode As String = ""
            Dim elseClode As String = " "

            'Start filling the vars.
            condition = match.Groups(2).Value.Trim

            If match.Groups(3).Value.Contains("#else") Then
                Dim s As String() = Split(match.Groups(3).Value, "#else")
                mainCode = s(0).Trim : elseClode = s(1).Trim
            Else
                mainCode = match.Groups(3).Value.Trim
            End If

            'The result of the parse will be saved here for deletion.
            Dim result As IfDefinedParser = Nothing

            'Now check which part needs to be parsed by seeing isNt and the else.
            If isNt = False Then
                'Here the thing should BE defined
                If isDefined(parts, condition) = False Then
                    'Parse the main.
                    result = New IfDefinedParser(parts, mainCode, filePath, prjPath, False)
                Else
                    'Parse the else.
                    result = New IfDefinedParser(parts, elseClode, filePath, prjPath, False)
                End If
            Else
                'It should NOT be defined.
                If isDefined(parts, condition) = True Then
                    'Parse the main.
                    result = New IfDefinedParser(parts, mainCode, filePath, prjPath, False)
                Else
                    'Parse the else.
                    result = New IfDefinedParser(parts, elseClode, filePath, prjPath, False)
                End If
            End If
        Next
    End Sub

    Private Shared Function isDefined(ByRef parts As CodeParts, str As String)
        If parts.Defines.FindIndex(Function(x) x.Value.DefineName = str) <> -1 Then Return True
        If parts.Macros.FindIndex(Function(x) x.Value.DefineName = str) <> -1 Then Return True
        If parts.Enums.FindIndex(Function(x) x.Value.EnumName = str) <> -1 Then Return True
        If parts.Publics.FindIndex(Function(x) x.Value.FuncName = str) <> -1 Then Return True
        If parts.Stocks.FindIndex(Function(x) x.Value.FuncName = str) <> -1 Then Return True
        If parts.Functions.FindIndex(Function(x) x.Value.FuncName = str) <> -1 Then Return True
        If parts.Natives.FindIndex(Function(x) x.Value.FuncName = str) <> -1 Then Return True
        If parts.publicVariables.FindIndex(Function(x) x.Value.VarName = str) <> -1 Then Return True

        Return False
    End Function
End Class
