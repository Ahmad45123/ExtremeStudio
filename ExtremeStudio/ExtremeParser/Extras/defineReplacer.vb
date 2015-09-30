Imports System.Text.RegularExpressions

Public Class defineReplacer
    Public Shared Sub Replace(ByRef Code As String, ByVal defineName As String, ByVal defineReplace As String)
        'First start building the regex for the find.
        Dim findRegex As String = Regex.Escape(defineName)

        'Now replace all the %'s for the findRegex.
        findRegex = Regex.Replace(findRegex, "%([1-9])", "(.*)")

        'Find all. (We don't use Regex.Matches here cuz the codes are changed.)
        While (Regex.IsMatch(Code, "\s" + findRegex + "\s"))
            Dim Mtch As Match = Regex.Match(Code, findRegex)

            'Now build the replace code.
            Dim tmpDefineReplace As String = defineReplace
            For i As Integer = 1 To Mtch.Groups.Count - 1
                tmpDefineReplace = tmpDefineReplace.Replace("%" + i.ToString, Mtch.Groups(i).Value)
            Next

            'Now replace actually.
            Code = Code.Remove(Mtch.Index, Mtch.Length)
            Code = Code.Insert(Mtch.Index, tmpDefineReplace)
        End While
    End Sub
End Class
