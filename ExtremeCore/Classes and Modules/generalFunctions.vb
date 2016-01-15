Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports ScintillaNET
Imports Ionic.Zip

Public Module GeneralFunctions
    Function FilenameIsOk(ByVal fileName As String,
                                        Optional ByVal allowPathDefinition As Boolean = False,
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
                        OrElse
                        directory.Intersect(Path.GetInvalidPathChars()).Any())
        End If
    End Function

    Public Function IsNetAvailable() As Boolean 'Custom function due to a bug in my.computer.network.isavailable.
        Dim webClient As New WebClient
        Try
            Dim fileText As String = webClient.DownloadString("http://johnymac.github.io/esfiles/serverPackages.xml")
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetAllFolders(ByVal directory As String) As String()
        Dim fi As New IO.DirectoryInfo(directory)
        Dim path() As String = {}
        For Each subfolder As IO.DirectoryInfo In fi.GetDirectories()
            Array.Resize(path, path.Length + 1)
            path(path.Length - 1) = subfolder.FullName
            For Each s As String In GetAllFolders(subfolder.FullName)
                Array.Resize(path, path.Length + 1)
                path(path.Length - 1) = s
            Next
        Next
        Return path
    End Function

    Dim _getAllFilesTreeNode As TreeNode
    Public Function GetAllFilesInFolders(ByVal dir As String, Optional ByVal extension As String = "", Optional ByRef parentNode As TreeNode = Nothing) As TreeNode
        Dim currentDir As TreeNode

        If parentNode Is Nothing Then
            _getAllFilesTreeNode = New TreeNode
        End If

        Dim dirs() As String = Directory.GetDirectories(dir)

        For Each str As String In dirs
            If parentNode Is Nothing Then
                currentDir = _getAllFilesTreeNode.Nodes.Add(str.Remove(0, str.LastIndexOf("\") + 1))
                currentDir.Tag = "Folder"
            Else
                currentDir = parentNode.Nodes.Add(str.Remove(0, str.LastIndexOf("\") + 1))
                currentDir.Tag = "Folder"
            End If

            'Get all directories.
            For Each strb As String In Directory.GetDirectories(str)
                Dim tmpDir As TreeNode = currentDir.Nodes.Add(strb.Remove(0, strb.LastIndexOf("\") + 1))
                tmpDir.Tag = "Folder"

                For Each stra As String In Directory.GetFiles(strb)
                    If Not extension = "" Then
                        If Not stra.EndsWith(extension) Then
                            Continue For
                        End If
                    End If

                    Dim node = tmpDir.Nodes.Add(Path.GetFileName(stra))
                    node.ImageIndex = 1
                    node.Tag = "File"
                Next
                GetAllFilesInFolders(strb, extension, tmpDir)
            Next

            'Get files.
            For Each stra As String In Directory.GetFiles(str)
                If Not extension = "" Then
                    If Not stra.EndsWith(extension) Then
                        Continue For
                    End If
                End If

                Dim node = currentDir.Nodes.Add(Path.GetFileName(stra))
                node.ImageIndex = 1
                node.Tag = "File"
            Next

        Next
        Return _getAllFilesTreeNode
    End Function

    Public Function IsValidExtremeProject(path As String)
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

    Public Function GetLinesFromRange(scin As Scintilla, ByVal startPos As Integer, ByVal endPos As Integer) As List(Of Integer)
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

    Public Sub GetFilesInZip(pathtoZip As String, ByRef files As List(Of String), ByRef folders As List(Of String))
        'Make the temp folder ready.
        Dim tmpPath As String = My.Computer.FileSystem.SpecialDirectories.Temp + "/" + Path.GetFileNameWithoutExtension(pathtoZip)
        My.Computer.FileSystem.CreateDirectory(tmpPath)

        'Extract the files.
        FastZipUnpack(pathtoZip, tmpPath)

        'Get all files and folders and put them in the lists.
        For Each filePath In Directory.GetFiles(tmpPath)
            files.Add(Path.GetFileName(filePath))
        Next
        For Each folderPath In Directory.GetDirectories(tmpPath)
            folders.Add(Path.GetDirectoryName(folderPath))
        Next

        'Clean.
        My.Computer.FileSystem.DeleteDirectory(tmpPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
    End Sub

    Public Sub FastZipUnpack(ByVal zipToUnpack As String, ByVal targetDir As String)
        Using zip1 As ZipFile = ZipFile.Read(zipToUnpack)
            Dim e As ZipEntry
            For Each e In zip1
                e.Extract(targetDir, ExtractExistingFileAction.OverwriteSilently)
            Next
        End Using
    End Sub
End Module
