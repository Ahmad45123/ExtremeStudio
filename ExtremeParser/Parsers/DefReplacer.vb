Public Class DefReplacer
    Public Shared Sub Parse(ByRef code As String, fileName As String, ByRef parts As CodeParts, Optional add As Boolean = True)
        For Each part In parts.Flatten
            For i As Integer = 0 To part.Defines.Count - 1
                defineReplacer.Replace(code, part.Defines(i).DefineName, part.Defines(i).DefineValue, False)
            Next
            For i As Integer = 0 To part.Macros.Count - 1
                defineReplacer.Replace(code, part.Macros(i).DefineName, part.Macros(i).DefineValue, True)
            Next
        Next
    End Sub
End Class
