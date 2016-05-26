Imports System.IO
Imports System.Security.Cryptography

Public Module FileHash
    Public Function GetFileHash(fileName As String) As String
        Dim sha = SHA1.Create()

        If File.Exists(fileName) = False Then
            Return False
        End If

        Using fs As FileStream = File.Open(fileName, FileMode.Open)
            Return Convert.ToBase64String(sha.ComputeHash(fs))
        End Using
    End Function
End Module