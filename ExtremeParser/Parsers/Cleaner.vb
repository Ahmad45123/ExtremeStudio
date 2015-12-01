Imports System.Text.RegularExpressions

Public Class Cleaner
    Public Shared Sub Parse(ByRef code As String, Optional sComments As Boolean = True, Optional mComments As Boolean = True, Optional braces As Boolean = True, Optional strings As Boolean = True)
        'Remove singleline comments from code.
        If sComments Then
            code = Regex.Replace(code, "//.*", "")
        End If

        'Remove multiline comments.
        If mComments Then
            code = Regex.Replace(code, "\/\*[\s\S]*?\*\/", "", RegexOptions.Multiline)
        End If

        'Remove child codes.
        If braces Then
            code = Regex.Replace(code, "(?<=\{)(?>[^{}]+|\{(?<DEPTH>)|\}(?<-DEPTH>))*(?(DEPTH)(?!))(?=\})", "")
        End If

        'Strings
        If strings Then
            code = Regex.Replace(code, "'[^'\\]*(?:\\[^\n\r\x85\u2028\u2029][^'\\]*)*'", "")
            code = Regex.Replace(code, Chr(34) + "[^" + Chr(34) + "\\]*(?:\\[^\n\r\x85\u2028\u2029][^" + Chr(34) + "\\]*)*" + Chr(34), "")
        End If
    End Sub
End Class
