Imports System.Text.RegularExpressions
Imports ScintillaNET

Public Class codeHighlighting

    Public Enum Styles
        [Default]
        [Integer]
    End Enum

    Public Shared Sub Highlight(ByRef Editor As Scintilla, startPos As Integer, endPos As Integer)
        'Clear all styling.
        Editor.StartStyling(startPos)
        Editor.SetStyling((endPos - startPos), Styles.Default)

        'Get code there.
        Dim code As String = Editor.GetTextRange(startPos, (endPos - startPos))

        'Highlight Integers.
        For Each mtch As Match In Regex.Matches(code, "[0-9]+")
            Editor.StartStyling(mtch.Index + startPos)
            Editor.SetStyling(mtch.Length, Styles.Integer)
        Next
    End Sub
End Class
