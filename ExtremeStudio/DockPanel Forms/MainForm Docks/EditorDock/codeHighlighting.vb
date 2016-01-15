Imports System.Text
Imports System.Text.RegularExpressions
Imports ExtremeParser
Imports ScintillaNET

Public Class CodeHighlighting

    Public Enum Styles
        [Default]
        [Integer]
        [String]
        [Symbols]
        [SingleLineComment]
        [MultiLineComment]
        PawnDoc
        [PawnPre]
        PawnKeywords
        [Functions]
        [Publics]
        [Stocks]
        [Natives]
        [Defines]
        [Macros]
        [Enums]
        [PublicVars]
    End Enum

    'States
    Public Enum States
        Unknown
        Number
        [String]
        Comment
    End Enum

    'Global State Variables: 
    Shared _gState As States
    Shared _commentState As Integer '0 = / | 1 = comment multiline | 2 = comment single line.
    Shared _stringState As Integer '0 = out | 1 = in

    Public Shared Sub Highlight(ByRef editor As Scintilla, parts As CodeParts, startPos As Integer, endPos As Integer)
        'Some needed var: 
        Dim length As Integer = 0

        'Loop: 
        editor.StartStyling(startPos)
        While startPos < endPos
            Dim c As Char = ChrW(editor.GetCharAt(startPos))

ReProcess:
            Select Case (_gState)
                Case States.Unknown
                    If Char.IsDigit(c) Then
                        _gState = States.Number
                        GoTo ReProcess
                    Else
                        editor.SetStyling(1, Styles.Default)
                    End If

                Case States.Number
                    If Char.IsDigit(c) Then
                        length += 1
                    Else
                        editor.SetStyling(length, Styles.Integer)
                        _gState = States.Unknown
                        length = 0
                        GoTo ReProcess
                    End If

            End Select

            startPos += 1
        End While
    End Sub
End Class
