Imports System.IO
Imports System.Security.Cryptography

Public Module FileHash
    Public Function GetFileHash(fileName As String) As String
        Dim sha = SHA1.Create()

        If File.Exists(fileName) = False Then
            Return False
        End If

        'To skipe file being used shit.
        Dim fle As Byte() = File.ReadAllBytes(fileName)
        Return Convert.ToBase64String(sha.ComputeHash(fle))
    End Function
End Module