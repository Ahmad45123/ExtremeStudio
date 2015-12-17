﻿Imports System.IO
Imports System.Security.Cryptography

Public Module fileHash
    Public Function getFileHash(fileName As String) As String
        Dim sha = SHA256.Create()

        Using fs As FileStream = File.Open(fileName, FileMode.Open)
            Return Convert.ToBase64String(sha.ComputeHash(fs))
        End Using
    End Function
End Module