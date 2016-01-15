Public Class StringSearcher
    Public Shared Function CountChar(src As String, chr As Char) As Integer
        Return src.Count(Function(fChr) fChr = chr)
    End Function
End Class
