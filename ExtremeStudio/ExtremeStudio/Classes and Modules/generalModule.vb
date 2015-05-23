Imports System.IO
Imports System.Net

Module generalModule
    Function FilenameIsOK(ByVal fileName As String, _
                                        Optional ByVal allowPathDefinition As Boolean = False, _
                                        Optional ByRef firstCharIndex As Integer = Nothing) As Boolean

        Dim file As String = String.Empty
        Dim directory As String = String.Empty

        If allowPathDefinition Then
            file = Path.GetFileName(fileName)
            directory = Path.GetDirectoryName(fileName)
        Else
            file = fileName
        End If

        If Not IsNothing(firstCharIndex) Then
            Dim f As IEnumerable(Of Char)
            f = file.Intersect(Path.GetInvalidFileNameChars())
            If f.Any Then
                firstCharIndex = Len(directory) + file.IndexOf(f.First)
                Return False
            End If

            f = directory.Intersect(Path.GetInvalidPathChars())
            If f.Any Then
                firstCharIndex = directory.IndexOf(f.First)
                Return False
            Else
                Return True
            End If
        Else
            Return Not (file.Intersect(Path.GetInvalidFileNameChars()).Any() _
                        OrElse _
                        directory.Intersect(Path.GetInvalidPathChars()).Any())
        End If
    End Function

    Public Function isNetAvailable() As Boolean 'Custom function due to a bug in my.computer.network.isavailable.
        Dim webClient As New WebClient
        Try
            Dim fileText As String = webClient.DownloadString("http://5.231.50.158/ExtremeStudio/serverPackages.xml")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
