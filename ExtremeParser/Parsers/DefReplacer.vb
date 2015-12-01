Public Class DefReplacer
    Public Shared Sub Parse(ByRef code As String, fileName As String, ByRef parts As CodeParts, Optional add As Boolean = True)
        For i As Integer = 0 To parts.Defines.Count - 1
            defineReplacer.Replace(code, parts.Defines(i).Value.DefineName, parts.Defines(i).Value.DefineValue)
        Next
        For i As Integer = 0 To parts.Macros.Count - 1
            defineReplacer.Replace(code, parts.Macros(i).Value.DefineName, parts.Macros(i).Value.DefineValue)
        Next
    End Sub
End Class
