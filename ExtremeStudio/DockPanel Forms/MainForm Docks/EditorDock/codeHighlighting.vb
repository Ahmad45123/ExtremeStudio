Imports System.Text
Imports System.Text.RegularExpressions
Imports ExtremeParser
Imports ScintillaNET

Public Class codeHighlighting

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

    'States
    Public Enum States
        Unknown
        Number
        [String]
        Comment
    End Enum

    'Global State Variables: 
    Shared gState As States
    Shared commentState As Integer '0 = / | 1 = comment multiline | 2 = comment single line.
    Shared stringState As Integer '0 = out | 1 = in

    Public Shared Sub Highlight(ByRef Editor As Scintilla, parts As CodeParts, startPos As Integer, endPos As Integer)
        'Some needed var: 
        Dim length As Integer = 0

        'Loop: 
        Editor.StartStyling(startPos)
        While startPos < endPos
            Dim c As Char = ChrW(Editor.GetCharAt(startPos))

ReProcess:
            Select Case (gState)
                Case States.Unknown
                    If Char.IsDigit(c) Then
                        gState = States.Number
                        GoTo ReProcess
                    Else
                        Editor.SetStyling(1, Styles.Default)
                    End If

                Case States.Number
                    If Char.IsDigit(c) Then
                        length += 1
                    Else
                        Editor.SetStyling(length, Styles.Integer)
                        gState = States.Unknown
                        length = 0
                        GoTo ReProcess
                    End If

            End Select

            startPos += 1
        End While
    End Sub
End Class
