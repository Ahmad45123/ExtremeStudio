Imports System.IO
Imports System.Net
Imports System.Xml

Public Class IncludesForm
    Public Includes As New List(Of IncludeData)


    Public Sub RefreshList(Optional searchPattern As String = "", Optional isInstalledOnly As Boolean = False)
        includesList.Items.Clear()

        'Show the list.
        For Each include As IncludeData In Includes
            If include.Name.ToLower.StartsWith(searchPattern.ToLower) Then
                If isInstalledOnly Then
                    If include.isInstalled Then
                        includesList.Items.Add(include.Name)
                    End If
                Else
                    includesList.Items.Add(include.Name)
                End If
            End If
        Next
    End Sub

    Private Sub IncludesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Download list.
        If ExtremeCore.isNetAvailable() Then 'Download latest from internet if there is internet.
            Dim webClient As New WebClient
            Dim xmlFile As New XmlDocument()
            Dim fileText As String = webClient.DownloadString("http://johnymac.github.io/esfiles/includes.xml")
            xmlFile.LoadXml(fileText)

            For Each cs As XmlNode In xmlFile.SelectNodes("xml/include")
                Dim include As New IncludeData
                include.Name = cs("name").InnerText.Trim
                include.relatedPlugin = cs("plugin").InnerText.Trim
                include.Desc = cs("desc").InnerText.Trim
                include.Version = cs("version").InnerText.Trim
                include.Download = cs("download").InnerText.Trim
                Includes.Add(include)
            Next
        Else 'List all available cached includes.
            For Each file In Directory.GetDirectories(MainForm.ApplicationFiles + "/cache/includes")
                Dim inc As New IncludeData
                inc.Name = Path.GetFileNameWithoutExtension(file)
                inc.Download = "local"
                inc.Desc = "The include is cached, No description is available."
                inc.relatedPlugin = ""
                inc.Version = My.Computer.FileSystem.ReadAllText(file + "/version.cfg")
                Includes.Add(inc)
            Next
        End If

        'Set `isInstalled` to true in all installed includes.
        For Each inc In Includes
            If MainForm.currentProject.IncludeExists(inc.Name) Then
                inc.isInstalled = True
            End If
        Next

        refreshList(TextBox1.Text, showInstalledOnlyCheck.Checked)
    End Sub

    Private Function GetIncludeInfo(name As String) As IncludeData
        For Each include As IncludeData In Includes
            If include.Name = name Then
                Return include
            End If
        Next
        Return Nothing
    End Function

    Private Sub includesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles includesList.SelectedIndexChanged
        If includesList.SelectedIndex = -1 Then Exit Sub

        Dim sel = getIncludeInfo(includesList.SelectedItem)
        If sel Is Nothing Then Exit Sub

        includeName.Text = sel.Name
        includeVersion.Text = sel.Version
        includeDesc.Text = sel.Desc

        'Check for updates if already installed.
        If sel.isInstalled Then
            'Set as already installed.
            includeInstalledLabel.Visible = True
            Button1.Text = "Reinstall Include"
            actionsGroup.Visible = True

            Dim curVer As String = MainForm.CurrentProject.IncludeVersion(sel.Name)
            Dim res = ExtremeCore.versionReader.CompareVersions(curVer, includeVersion.Text)
            If res = ExtremeCore.versionReader.CompareVersionResult.VersionNew Then
                updateAvilableLabel.Visible = True
            End If
        Else
            includeInstalledLabel.Visible = False
            updateAvilableLabel.Visible = False
            Button1.Text = "Install Include"
            actionsGroup.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Get the include info.
        Dim inc = getIncludeInfo(includeName.Text)
        If inc Is Nothing Then Exit Sub

        'Setup the paths.
        Dim incFolder As String = MainForm.ApplicationFiles + "/cache/includes/" + Path.GetFileNameWithoutExtension(inc.Download)
        Dim incFile As String = incFolder + "/" + Path.GetFileName(inc.Download)

        Dim web As New WebClient
        If ExtremeCore.isNetAvailable Then 'Check if there is internet.
            If My.Computer.FileSystem.DirectoryExists(incFolder) And My.Computer.FileSystem.FileExists(incFile) And My.Computer.FileSystem.FileExists(incFolder + "/version.cfg") Then 'Check if there is a version in the cache.
                'If there is a version in the cache, Compare the versions and download if neceseary.
                Dim curVer As String = My.Computer.FileSystem.ReadAllText(incFolder + "/version.cfg")
                Dim res = ExtremeCore.versionReader.CompareVersions(curVer, includeVersion.Text)
                If res = ExtremeCore.versionReader.CompareVersionResult.VersionNew Then
                    'If new download: 
                    web.DownloadFile(inc.Download, incFile)
                    My.Computer.FileSystem.WriteAllText(incFolder + "/version.cfg", includeVersion.Text, False)
                End If
            Else 'If he doesn't have an exisitng cahe, Then just download latest.
                My.Computer.FileSystem.CreateDirectory(incFolder)
                web.DownloadFile(inc.Download, incFile)
                My.Computer.FileSystem.WriteAllText(incFolder + "/version.cfg", includeVersion.Text, False)
            End If
        End If

        'Check is the file doesn't exist to prevent exceptions.. For example the user lost interent after he got the includes list.
        If Not My.Computer.FileSystem.FileExists(incFile) Then
            MsgBox("The include can't be found in the cache.")
            Exit Sub
        End If


        If Path.GetExtension(inc.Download) = ".inc" Then 'if its just a .inc file, Just copy it.
            'No need to delete here as it will automaticly get replaced.
            My.Computer.FileSystem.CopyFile(incFile, MainForm.currentProject.projectPath + "pawno/include/" + Path.GetFileName(inc.Download))
        ElseIf Path.GetExtension(inc.Download) = ".zip" 'If its a ZIP file, Extract it.

            'Remove existing first.
            Dim files As New List(Of String)
            Dim folders As New List(Of String)
            ExtremeCore.GetFilesInZip(incFile, files, folders) 'ByRef to the var files and the var folders.
            For Each fldr In folders
                My.Computer.FileSystem.DeleteDirectory(MainForm.currentProject.projectPath + "/pawno/include/" + fldr, FileIO.DeleteDirectoryOption.DeleteAllContents) 'Delete all dirs.
            Next
            For Each fls In files
                If My.Computer.FileSystem.FileExists(MainForm.currentProject.projectPath + "/pawno/include/" + fls) Then My.Computer.FileSystem.DeleteFile(MainForm.currentProject.projectPath + "/pawno/include/" + fls) 'Delete all files.
            Next

            'Now extract
            ExtremeCore.FastZipUnpack(incFile, MainForm.currentProject.projectPath + "/pawno/include")
        End If
        MainForm.currentProject.AddInclude(includeName.Text, includeVersion.Text) 'Save Include to DB.

        'Show/hide stuff.
        inc.isInstalled = True
        updateAvilableLabel.Visible = False
        includeInstalledLabel.Visible = True
        actionsGroup.Visible = True

        MsgBox("The include '" + includeName.Text + "' has been successfully installed.")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Get the include info.
        Dim inc = getIncludeInfo(includeName.Text)
        If inc Is Nothing Then Exit Sub

        'Remove the include.
        If Path.GetExtension(inc.Download) = ".inc" Then
            My.Computer.FileSystem.DeleteFile(MainForm.currentProject.projectPath + "pawno/include/" + Path.GetFileName(inc.Download))
        ElseIf Path.GetExtension(inc.Download) = ".zip" 'If its a ZIP file, Extract it.
            'Setup the paths to ZIP.
            Dim incFolder As String = MainForm.ApplicationFiles + "/cache/includes/" + Path.GetFileNameWithoutExtension(inc.Download)
            Dim incFile As String = incFolder + "/" + Path.GetFileName(inc.Download)

            'Remove existing first.
            Dim files As New List(Of String)
            Dim folders As New List(Of String)
            ExtremeCore.GetFilesInZip(incFile, files, folders) 'ByRef to the var files and the var folders.
            For Each fldr In folders
                If My.Computer.FileSystem.DirectoryExists(MainForm.currentProject.projectPath + "/pawno/include/" + fldr) Then My.Computer.FileSystem.DeleteDirectory(MainForm.currentProject.projectPath + "/pawno/include/" + fldr, FileIO.DeleteDirectoryOption.DeleteAllContents) 'Delete all dirs.
            Next
            For Each fls In files
                If My.Computer.FileSystem.FileExists(MainForm.currentProject.projectPath + "/pawno/include/" + fls) Then My.Computer.FileSystem.DeleteFile(MainForm.currentProject.projectPath + "/pawno/include/" + fls) 'Delete all files.
            Next
        End If

        'Remove include from DB.
        MainForm.currentProject.RemoveInclude(inc.Name)

        'Hide stuff.
        inc.isInstalled = False
        updateAvilableLabel.Visible = False
        includeInstalledLabel.Visible = False
        actionsGroup.Visible = False
        Button1.Text = "Install Include"
    End Sub

    Private Sub showInstalledOnlyCheck_CheckedChanged(sender As Object, e As EventArgs) Handles showInstalledOnlyCheck.CheckedChanged
        refreshList(TextBox1.Text, showInstalledOnlyCheck.Checked)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        refreshList(TextBox1.Text, showInstalledOnlyCheck.Checked)
    End Sub
End Class

Public Class IncludeData
    Public Property Name As String
    Public Property Desc As String
    Public Property Version As String
    Public Property Download As String
    Public Property RelatedPlugin As String
    Public Property IsInstalled As Boolean
End Class