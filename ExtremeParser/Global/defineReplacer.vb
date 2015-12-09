Imports System.Text.RegularExpressions

Public Class defineReplacer
    Public Shared Sub Replace(ByRef Code As String, ByVal defineName As String, ByVal defineReplace As String, isMacro As Boolean)
        'First start building the regex for the find.
        Dim findRegex As String = Regex.Escape(defineName)

        'Setup find regex.
        findRegex = Regex.Replace(findRegex, "%([0-9])", "(.*)")
        findRegex = "(?<!#.*)\b" + findRegex
        If isMacro = False Then findRegex += "\b"

        'Setup replace regex.
        Dim replaceRegex As String = defineReplace
        If replaceRegex.Contains("%0") Then
            For i As Integer = 0 To 9
                replaceRegex = replaceRegex.Replace("%" + i.ToString, "$" + (i + 1).ToString)
            Next
        Else
            For i As Integer = 1 To 9
                replaceRegex = replaceRegex.Replace("%" + i.ToString, "$" + i.ToString)
            Next
        End If

        Code = Regex.Replace(Code, findRegex, replaceRegex)
    End Sub
End Class
