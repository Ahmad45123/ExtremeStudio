Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports ScintillaNET

Public Module generalFunctions
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

    Public Function getAllFolders(ByVal directory As String) As String()
        Dim fi As New IO.DirectoryInfo(directory)
        Dim path() As String = {}
        For Each subfolder As IO.DirectoryInfo In fi.GetDirectories()
            Array.Resize(path, path.Length + 1)
            path(path.Length - 1) = subfolder.FullName
            For Each s As String In getAllFolders(subfolder.FullName)
                Array.Resize(path, path.Length + 1)
                path(path.Length - 1) = s
            Next
        Next
        Return path
    End Function

    Dim getAllFiles_treeNode As TreeNode
    Public Function getAllFilesInFolders(ByVal dir As String, Optional ByVal extension As String = "", Optional ByVal parentNode As TreeNode = Nothing) As TreeNode
        Dim currentDir As TreeNode

        If parentNode Is Nothing Then
            getAllFiles_treeNode = New TreeNode
        End If

        Dim dirs() As String = Directory.GetDirectories(dir)

        For Each Str As String In dirs
            If parentNode Is Nothing Then
                currentDir = getAllFiles_treeNode.Nodes.Add(Str.Remove(0, Str.LastIndexOf("\") + 1))
                currentDir.Tag = "Folder"
            Else
                currentDir = parentNode.Nodes.Add(Str.Remove(0, Str.LastIndexOf("\") + 1))
                currentDir.Tag = "Folder"
            End If

            For Each stra As String In Directory.GetFiles(Str)
                If Not extension = "" Then
                    If Not stra.EndsWith(extension) Then
                        Continue For
                    End If
                End If

                Dim node = currentDir.Nodes.Add(Path.GetFileName(stra))
                node.ImageIndex = 1
                node.Tag = "File"
            Next

            Dim tmpDir As TreeNode = currentDir
            For Each Strb As String In Directory.GetDirectories(Str)
                currentDir = tmpDir.Nodes.Add(Strb.Remove(0, Strb.LastIndexOf("\") + 1))
                currentDir.Tag = "Folder"

                For Each stra As String In Directory.GetFiles(Strb)
                    If Not extension = "" Then
                        If Not stra.EndsWith(extension) Then
                            Continue For
                        End If
                    End If

                    Dim node = currentDir.Nodes.Add(Path.GetFileName(stra))
                    node.ImageIndex = 1
                    node.Tag = "File"
                Next
                getAllFilesInFolders(Strb, extension, currentDir)
            Next
        Next
        Return getAllFiles_treeNode
    End Function

    Public Function isValidExtremeProject(path As String)
        If Not My.Computer.FileSystem.DirectoryExists(path) Then Return False
        If Not My.Computer.FileSystem.DirectoryExists(path + "/filterscripts") Then Return False
        If Not My.Computer.FileSystem.DirectoryExists(path + "/gamemodes") Then Return False
        If Not My.Computer.FileSystem.DirectoryExists(path + "/pawno") Then Return False
        If Not My.Computer.FileSystem.DirectoryExists(path + "/pawno/include") Then Return False
        If Not My.Computer.FileSystem.DirectoryExists(path + "/plugins") Then Return False
        If Not My.Computer.FileSystem.FileExists(path + "/extremeStudio.config") Then Return False
        If Not My.Computer.FileSystem.FileExists(path + "/announce.exe") Then Return False
        If Not My.Computer.FileSystem.FileExists(path + "/samp-npc.exe") Then Return False
        If Not My.Computer.FileSystem.FileExists(path + "/samp-server.exe") Then Return False
        If Not My.Computer.FileSystem.FileExists(path + "/server.cfg") Then Return False
        If Not My.Computer.FileSystem.FileExists(path + "/pawno/libpawnc.dll") Then Return False
        If Not My.Computer.FileSystem.FileExists(path + "/pawno/pawnc.dll") Then Return False
        If Not My.Computer.FileSystem.FileExists(path + "/pawno/pawncc.exe") Then Return False
        Return True
    End Function

    Public Function getLinesFromRange(scin As Scintilla, ByVal startPos As Integer, ByVal endPos As Integer) As List(Of Integer)
        Dim lines As New List(Of Integer)

        For i = 0 To 1 Step 0
            Dim lne As Integer = scin.LineFromPosition(startPos)
            lines.Add(lne)
            startPos += scin.Lines(lne).Length

            If startPos = endPos Or startPos >= scin.CurrentPosition Then
                i = 1 'End the loop
            End If
        Next

        Return lines
    End Function
End Module
