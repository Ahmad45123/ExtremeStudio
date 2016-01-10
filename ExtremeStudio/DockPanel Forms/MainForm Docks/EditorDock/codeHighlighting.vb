Imports System.Text
Imports System.Text.RegularExpressions
Imports ExtremeParser
Imports ScintillaNET

Public Class codeHighlighting

    'NOTE: The order of the highlighting IS IMPORTANT, For example, Highliting the " as a symbol only if it wasn't a string.

    Public Enum Styles
        [Default]
        [Integer]
        [String]
        [Symbols]
        [SingleLineComment]
        [MultiLineComment]
        [PawnDOC]
        [PawnPre]
        [PAWNKeywords]
        [Functions]
        [Publics]
        [Stocks]
        [Natives]
        [Defines]
        [Macros]
        [Enums]
        [PublicVars]
    End Enum

    Private Shared Regexs As New Dictionary(Of String, Object)
    Private Shared RegexString As String

    Shared Sub New()
        'Fill
        Regexs.Add("\/\*([^*]*(?:\*(?!\/)[^*]*)*)\*\/", Styles.MultiLineComment)
        Regexs.Add("//.*", Styles.SingleLineComment)
        Regexs.Add("^\s*#(?:(?!//|/\*).)+", Styles.PawnPre) 'Except comments.
        Regexs.Add("\/\*\*([^*]*(?:\*(?!\/)[^*]*)*)\*\/", Styles.PawnDOC)
        Regexs.Add(Chr(34) + "[^" + Chr(34) + "\\]*(?:\\[^\n\r\x85\u2028\u2029][^" + Chr(34) + "\\]*)*" + Chr(34), Styles.String)
        Regexs.Add("[0-9]+", Styles.Integer)
        Regexs.Add("\b(?:static|break|case|enum|continue|do|else|false|for|goto|public|stock|if|is|new|null|return|sizeof|switch|true|while|forward|native)\b", Styles.PAWNKeywords)

        'Regex Setup
        Dim rgx As New StringBuilder("(")
        For Each argx In Regexs
            rgx.Append(argx.Key + "|")
        Next
        rgx.Remove(rgx.Length - 1, 1)
        rgx.Append(")")
        RegexString = rgx.ToString
    End Sub

    Public Shared Sub Highlight(ByRef Editor As Scintilla, parts As CodeParts, startPos As Integer, endPos As Integer)
        Dim tst As New Stopwatch() : tst.Start()
        'Get code there.
        Dim code As String = Editor.GetTextRange(startPos, (endPos - startPos))

        'Colorize
        Editor.StartStyling(startPos)
        Dim lastIndex As Integer = 0
        For Each match As Match In Regex.Matches(code, RegexString, RegexOptions.Multiline)
            'Get the corrent style by testing.
            For Each argx In Regexs
                If Regex.IsMatch(match.Value, argx.Key) Then
                    'Set default depending on last.
                    Editor.SetStyling(match.Index - lastIndex, Styles.Default) : lastIndex = match.Index + match.Length

                    'Set current.
                    Editor.SetStyling(match.Length, argx.Value)

                    Exit For
                End If
            Next
        Next

        tst.Stop()
        My.Computer.FileSystem.WriteAllText("D:/Gasser.txt", tst.ElapsedMilliseconds.ToString + vbCrLf, True)
    End Sub

    Private Shared Sub DoColor(ByRef Editor As Scintilla, startPos As Integer, ByVal code As String, rgx As String, style As Styles, Optional isMultiLine As Boolean = False)
        Dim last As Integer = 0
        Editor.StartStyling(startPos)
        For Each mtch As Match In Regex.Matches(code, rgx, IIf(isMultiLine, RegexOptions.Multiline, Nothing))
            Editor.SetStyling(mtch.Length, style)
            last = mtch.Index + mtch.Length


        Next
    End Sub

    Private Shared Sub ColorizeCodeParts(parts As CodeParts, ByRef Editor As Scintilla, startPos As Integer, ByVal code As String)
        Dim rgx As New StringBuilder()

        'Functions: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To parts.Functions.Count - 1
            rgx.Append(Regex.Escape(parts.Functions(i).FuncName))
            If (i < parts.Functions.Count - 1) Then rgx.Append("|")
        Next
        If parts.Functions.Count Then rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Functions)

        'Publics: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To parts.Publics.Count - 1
            rgx.Append(Regex.Escape(parts.Publics(i).FuncName))
            If (i < parts.Publics.Count - 1) Then rgx.Append("|")
        Next
        If parts.Publics.Count Then rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Publics)

        'Stocks: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To parts.Stocks.Count - 1
            rgx.Append(Regex.Escape(parts.Stocks(i).FuncName))
            If (i < parts.Stocks.Count - 1) Then rgx.Append("|")
        Next
        If parts.Stocks.Count Then rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Stocks)

        'Natives: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To parts.Natives.Count - 1
            rgx.Append(Regex.Escape(parts.Natives(i).FuncName))
            If (i < parts.Natives.Count - 1) Then rgx.Append("|")
        Next
        If parts.Natives.Count Then rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Natives)

        'Defines: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To parts.Defines.Count - 1
            rgx.Append(Regex.Escape(parts.Defines(i).DefineName))
            If (i < parts.Defines.Count - 1) Then rgx.Append("|")
        Next
        If parts.Defines.Count Then rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Defines)

        'Macros: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To parts.Macros.Count - 1
            rgx.Append(Regex.Escape(parts.Macros(i).DefineName))
            If (i < parts.Macros.Count - 1) Then rgx.Append("|")
        Next
        If parts.Macros.Count Then rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Macros)

        'Enums: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To parts.Enums.Count - 1
            For Each cntn In parts.Enums(i).EnumContents
                rgx.Append(Regex.Escape(cntn.Content))
                If (i < parts.Enums.Count - 1) Then rgx.Append("|")
            Next
        Next
        If parts.Enums.Count Then rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Enums)

        'Public Variables: 
        rgx.Clear() : rgx.Append("\b(?:")
        For i As Integer = 0 To parts.publicVariables.Count - 1
            rgx.Append(Regex.Escape(parts.publicVariables(i).VarName))
            If (i < parts.publicVariables.Count - 1) Then rgx.Append("|")
        Next
        If parts.publicVariables.Count Then rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.PublicVars)
    End Sub
End Class
