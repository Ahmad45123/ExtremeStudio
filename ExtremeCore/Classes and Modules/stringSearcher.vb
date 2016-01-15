Public Class StringSearcher
    Public Shared Function CountChar(src As String, chr As Char) As Integer
        Dim num As Integer = 0

        For Each fChr As Char In src
            If fChr = chr Then
                num += 1
            End If
        Next

        Return num
    End Function
End Class
