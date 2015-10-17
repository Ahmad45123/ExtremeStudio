Imports System.Text.RegularExpressions

Public Class defineReplacer
    Public Shared Sub Replace(ByRef Code As String, ByVal defineName As String, ByVal defineReplace As String)
        'First start building the regex for the find.
        Dim findRegex As String = Regex.Escape(defineName)

        'Now replace all the %'s for the findRegex.
        findRegex = Regex.Replace(findRegex, "%([1-9])", "(.*)")

        'Find all. (We don't use Regex.Matches here cuz the codes are changed.)
        findRegex = "(?<!#.*)\b(" + findRegex + ")\b"
        While (Regex.IsMatch(Code, findRegex, RegexOptions.Multiline))
            Dim Mtch As Match = Regex.Match(Code, findRegex, RegexOptions.Multiline)

            'Now build the replace code.
            Dim tmpDefineReplace As String = defineReplace
            If tmpDefineReplace.Contains("%") Then
                For i As Integer = 1 To Mtch.Groups.Count - 1
                    tmpDefineReplace = tmpDefineReplace.Replace("%" + i.ToString, Mtch.Groups(i + 1).Value)
                Next
            End If

            'Now replace actually.
            Code = Code.Remove(Mtch.Groups(1).Index, Mtch.Groups(1).Length)
            Code = Code.Insert(Mtch.Groups(1).Index, tmpDefineReplace)
        End While
    End Sub
End Class
