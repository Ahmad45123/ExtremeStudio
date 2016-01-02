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

    Public Shared Sub Highlight(ByRef Editor As Scintilla, parts As CodeParts, startPos As Integer, endPos As Integer)
        'Clear all styling.
        Editor.StartStyling(startPos)
        Editor.SetStyling((endPos - startPos), Styles.Default)

        'Get code there.
        Dim code As String = Editor.GetTextRange(startPos, (endPos - startPos))

        'Highlight Integers.
        DoColor(Editor, startPos, code, "[0-9]+", Styles.Integer)

        'Symbols: 
        DoColor(Editor, startPos, code, "(?:[_+\-\*\\\/\^!|<>%&#\(\);@$.,""'])+", Styles.Symbols)

        'Strings: 
        DoColor(Editor, startPos, code, "'[^'\\]*(?:\\[^\n\r\x85\u2028\u2029][^'\\]*)*", Styles.String)

        'Comments: 
        DoColor(Editor, startPos, code, "//.*", Styles.SingleLineComment)
        DoColor(Editor, startPos, code, "\/\*[\s\S]*?\*\/*", Styles.MultiLineComment, True)

        'PawnDoc: 
        DoColor(Editor, startPos, code, "/\*\*([\s\S]*?)\*/", Styles.PawnDOC)

        'Pawn Preprocessor: 
        DoColor(Editor, startPos, code, "\s*#.+", Styles.PawnPre)

        'PawnKeywords: 
        DoColor(Editor, startPos, code, "\b(?:static|break|case|enum|continue|do|else|false|for|goto|public|stock|if|is|new|null|return|sizeof|switch|true|while|forward|native)\b", Styles.PAWNKeywords)

        'CodeParts Highlighting: 
        For Each dat In parts.FlattenIncludes
            ColorizeCodeParts(dat, Editor, startPos, code)
        Next
    End Sub

    Private Shared Sub DoColor(ByRef Editor As Scintilla, startPos As Integer, ByVal code As String, rgx As String, style As Styles, Optional isMultiLine As Boolean = False)
        For Each mtch As Match In Regex.Matches(code, rgx, IIf(isMultiLine, RegexOptions.Multiline, Nothing))
            Editor.StartStyling(mtch.Index + startPos)
            Editor.SetStyling(mtch.Length, style)
        Next
    End Sub

    Private Shared Sub ColorizeCodeParts(parts As CodeParts, ByRef Editor As Scintilla, startPos As Integer, ByVal code As String)
        Dim rgx As New StringBuilder()

        'Functions: 
        rgx.Clear() : rgx.Append("\b(?:")
        For Each item In parts.Functions
            rgx.Append(item.FuncName + "|")
        Next
        rgx.Remove(rgx.Length - 1, 1) 'Remove the last |
        rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Functions)

        'Publics: 
        rgx.Clear() : rgx.Append("\b(?:")
        For Each item In parts.Publics
            rgx.Append(item.FuncName + "|")
        Next
        rgx.Remove(rgx.Length - 1, 1) 'Remove the last |
        rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Publics)

        'Stocks: 
        rgx.Clear() : rgx.Append("\b(?:")
        For Each item In parts.Stocks
            rgx.Append(item.FuncName + "|")
        Next
        rgx.Remove(rgx.Length - 1, 1) 'Remove the last |
        rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Stocks)

        'Natives: 
        rgx.Clear() : rgx.Append("\b(?:")
        For Each item In parts.Natives
            rgx.Append(item.FuncName + "|")
        Next
        rgx.Remove(rgx.Length - 1, 1) 'Remove the last |
        rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Natives)

        'Defines: 
        rgx.Clear() : rgx.Append("\b(?:")
        For Each item In parts.Defines
            rgx.Append(item.DefineName + "|")
        Next
        rgx.Remove(rgx.Length - 1, 1) 'Remove the last |
        rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Defines)

        'Macros: 
        rgx.Clear() : rgx.Append("\b(?:")
        For Each item In parts.Macros
            rgx.Append(item.DefineName + "|")
        Next
        rgx.Remove(rgx.Length - 1, 1) 'Remove the last |
        rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Macros)

        'Enums: 
        rgx.Clear() : rgx.Append("\b(?:")
        For Each item In parts.Enums
            For Each cntn In item.EnumContents
                rgx.Append(cntn.Content + "|")
            Next
        Next
        rgx.Remove(rgx.Length - 1, 1) 'Remove the last |
        rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.Enums)

        'Public Variables: 
        rgx.Clear() : rgx.Append("\b(?:")
        For Each item In parts.publicVariables
            rgx.Append(item.VarName + "|")
        Next
        rgx.Remove(rgx.Length - 1, 1) 'Remove the last |
        rgx.Append(")\b") : DoColor(Editor, startPos, code, rgx.ToString, Styles.PublicVars)
    End Sub
End Class
