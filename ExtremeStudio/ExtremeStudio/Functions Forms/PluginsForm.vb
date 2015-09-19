Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Xml

Public Class PluginsForm
    Public Plugins As New List(Of PluginData)


    Public Sub refreshList(Optional searchPattern As String = "", Optional isInstalledOnly As Boolean = False)
        pluginsList.Items.Clear()

        'Show the list.
        For Each plugin As PluginData In Plugins
            If plugin.Name.ToLower.StartsWith(searchPattern.ToLower) Then
                If isInstalledOnly Then
                    If plugin.isInstalled Then
                        pluginsList.Items.Add(plugin.Name)
                    End If
                Else
                    pluginsList.Items.Add(plugin.Name)
                End If
            End If
        Next
    End Sub

    Private Sub PluginsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Download list.
        If ExtremeCore.isNetAvailable() Then 'Download latest from internet if there is internet.
            Dim webClient As New WebClient
            Dim xmlFile As New XmlDocument()
            Dim fileText As String = webClient.DownloadString("http://johnymac.github.io/esfiles/plugins.xml")
            xmlFile.LoadXml(fileText)

            For Each cs As XmlNode In xmlFile.SelectNodes("xml/plugin")
                Dim plug As New PluginData
                plug.Name = cs("name").InnerText.Trim
                plug.relatedInclude = cs("include").InnerText.Trim
                plug.Desc = cs("desc").InnerText.Trim
                plug.Version = cs("version").InnerText.Trim
                plug.Download = cs("download").InnerText.Trim
                Plugins.Add(plug)
            Next
        Else 'List all available cached includes.
            For Each file In Directory.GetDirectories(Application.StartupPath + "/cache/plugins")
                Dim plug As New PluginData
                plug.Name = Path.GetFileNameWithoutExtension(file)
                plug.Download = "local"
                plug.Desc = "The include is cached, No description is available."
                plug.relatedInclude = ""
                plug.Version = My.Computer.FileSystem.ReadAllText(file + "/version.cfg")
                Plugins.Add(plug)
            Next
        End If

        'Set `isInstalled` to true in all installed plugins.
        For Each plug In Plugins
            If MainForm.currentProject.PluginExists(plug.Name) Then
                plug.isInstalled = True
            End If
        Next

        refreshList(TextBox1.Text, showInstalledOnlyCheck.Checked)
    End Sub

    Private Function getPluginInfo(name As String) As PluginData
        For Each plug As PluginData In Plugins
            If plug.Name = name Then
                Return plug
            End If
        Next
        Return Nothing
    End Function

    Private Sub includesList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pluginsList.SelectedIndexChanged
        If pluginsList.SelectedIndex = -1 Then Exit Sub

        Dim sel = getPluginInfo(pluginsList.SelectedItem)
        If sel Is Nothing Then Exit Sub

        pluginName.Text = sel.Name
        pluginVersion.Text = sel.Version
        pluginDesc.Text = sel.Desc

        'Check for updates if already installed.
        If sel.isInstalled Then
            'Set as already installed.
            includeInstalledLabel.Visible = True
            Button1.Text = "Reinstall Plugin"
            actionsGroup.Visible = True

            Dim curVer As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "/cache/plugins/" + Path.GetFileNameWithoutExtension(sel.Download) + "/version.cfg")
            Dim res = ExtremeCore.versionReader.CompareVersions(curVer, pluginVersion.Text)
            If res = ExtremeCore.versionReader.CompareVersionResult.VERSION_NEW Then
                updateAvilableLabel.Visible = True
            End If

            If MainForm.currentProject.isPluginInServerCFG(Path.GetFileNameWithoutExtension(sel.Download)) Then
                serverCFGButton.Text = "Remove from server.cfg"
            Else
                serverCFGButton.Text = "Add to server.cfg"
            End If
        Else
                includeInstalledLabel.Visible = False
            updateAvilableLabel.Visible = False
            Button1.Text = "Install Plugin"
            actionsGroup.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Get the include info.
        Dim plug = getPluginInfo(pluginName.Text)
        If plug Is Nothing Then Exit Sub

        'Setup the paths.
        Dim plugFolder As String = Application.StartupPath + "/cache/plugins/" + Path.GetFileNameWithoutExtension(plug.Download)
        Dim plugFile As String = plugFolder + "/" + Path.GetFileName(plug.Download)

        Dim web As New WebClient
        If ExtremeCore.isNetAvailable Then 'Check if there is internet.
            If My.Computer.FileSystem.DirectoryExists(plugFolder) And My.Computer.FileSystem.FileExists(plugFile) And My.Computer.FileSystem.FileExists(plugFolder + "/version.cfg") Then 'Check if there is a version in the cache.
                'If there is a version in the cache, Compare the versions and download if neceseary.
                Dim curVer As String = My.Computer.FileSystem.ReadAllText(plugFolder + "/version.cfg")
                Dim res = ExtremeCore.versionReader.CompareVersions(curVer, pluginVersion.Text)
                If res = ExtremeCore.versionReader.CompareVersionResult.VERSION_NEW Then
                    'If new download: 
                    web.DownloadFile(plug.Download, plugFile)
                    My.Computer.FileSystem.WriteAllText(plugFolder + "/version.cfg", pluginVersion.Text, False)
                End If
            Else 'If he doesn't have an exisitng cahe, Then just download latest.
                My.Computer.FileSystem.CreateDirectory(plugFolder)
                web.DownloadFile(plug.Download, plugFile)
                My.Computer.FileSystem.WriteAllText(plugFolder + "/version.cfg", pluginVersion.Text, False)
            End If
        End If

        'Check is the file doesn't exist to prevent exceptions.. For example the user lost interent after he got the includes list.
        If Not My.Computer.FileSystem.FileExists(plugFile) Then
            MsgBox("The include can't be found in the cache.")
            Exit Sub
        End If

        'Remove existing first.
        Dim files As New List(Of String)
        Dim folders As New List(Of String)
        ExtremeCore.GetFilesInZip(plugFile, files, folders) 'ByRef to the var files and the var folders.
        For Each fldr In folders
            My.Computer.FileSystem.DeleteDirectory(MainForm.currentProject.projectPath + "/plugins/" + fldr, FileIO.DeleteDirectoryOption.DeleteAllContents) 'Delete all dirs.
        Next
        For Each fls In files
            If My.Computer.FileSystem.FileExists(MainForm.currentProject.projectPath + "/plugins/" + fls) Then My.Computer.FileSystem.DeleteFile(MainForm.currentProject.projectPath + "/plugins/" + fls) 'Delete all files.
        Next

        'Now extract
        ZipFile.ExtractToDirectory(plugFile, MainForm.currentProject.projectPath + "/plugins")

        'Save plugin to DB
        MainForm.currentProject.AddPlugin(pluginName.Text)

        'Edit the server.cfg automaticly.
        If Not MainForm.currentProject.isPluginInServerCFG(Path.GetFileNameWithoutExtension(plug.Download)) Then
            MainForm.currentProject.TogglePluginInServerCFG(Path.GetFileNameWithoutExtension(plug.Download))
            serverCFGButton.Text = "Remove from server.cfg"
        End If

        'Show/hide stuff.
        plug.isInstalled = True
        updateAvilableLabel.Visible = False
        includeInstalledLabel.Visible = True
        actionsGroup.Visible = True

        MsgBox("The plugin '" + pluginName.Text + "' has been successfully installed.")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Get the include info.
        Dim plug = getPluginInfo(pluginName.Text)
        If plug Is Nothing Then Exit Sub

        'Setup the paths to ZIP.plug
        Dim plugFolder As String = Application.StartupPath + "/cache/plugins/" + Path.GetFileNameWithoutExtension(plug.Download)
        Dim plugFile As String = plugFolder + "/" + Path.GetFileName(plug.Download)

        'Remove existing first.
        Dim files As New List(Of String)
        Dim folders As New List(Of String)
        ExtremeCore.GetFilesInZip(plugFile, files, folders) 'ByRef to the var files and the var folders.
        For Each fldr In folders
            If My.Computer.FileSystem.DirectoryExists(MainForm.currentProject.projectPath + "/plugins/" + fldr) Then My.Computer.FileSystem.DeleteDirectory(MainForm.currentProject.projectPath + "/plugins/" + fldr, FileIO.DeleteDirectoryOption.DeleteAllContents) 'Delete all dirs.
        Next
        For Each fls In files
            If My.Computer.FileSystem.FileExists(MainForm.currentProject.projectPath + "/plugins/" + fls) Then My.Computer.FileSystem.DeleteFile(MainForm.currentProject.projectPath + "/plugins/" + fls) 'Delete all files.
        Next

        'Remove plugin from DB.
        MainForm.currentProject.RemovePlugin(plug.Name)

        'Remove plugin from server.cfg if it was there.
        If MainForm.currentProject.isPluginInServerCFG(Path.GetFileNameWithoutExtension(plug.Download)) Then
            MainForm.currentProject.TogglePluginInServerCFG(Path.GetFileNameWithoutExtension(plug.Download))
        End If

        'Hide stuff.
        plug.isInstalled = False
        updateAvilableLabel.Visible = False
        includeInstalledLabel.Visible = False
        actionsGroup.Visible = False
        Button1.Text = "Install Plugin"
    End Sub

    Private Sub showInstalledOnlyCheck_CheckedChanged(sender As Object, e As EventArgs) Handles showInstalledOnlyCheck.CheckedChanged
        refreshList(TextBox1.Text, showInstalledOnlyCheck.Checked)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        refreshList(TextBox1.Text, showInstalledOnlyCheck.Checked)
    End Sub

    Private Sub serverCFGButton_Click(sender As Object, e As EventArgs) Handles serverCFGButton.Click
        'Get the include info.
        Dim plug = getPluginInfo(pluginName.Text)
        If plug Is Nothing Then Exit Sub

        MainForm.currentProject.TogglePluginInServerCFG(Path.GetFileNameWithoutExtension(plug.Download))
        If MainForm.currentProject.isPluginInServerCFG(Path.GetFileNameWithoutExtension(plug.Download)) Then
            serverCFGButton.Text = "Remove from server.cfg"
        Else
            serverCFGButton.Text = "Add to server.cfg"
        End If
    End Sub
End Class

Public Class PluginData
    Public Property Name As String
    Public Property Desc As String
    Public Property Version As String
    Public Property Download As String
    Public Property relatedInclude As String
    Public Property isInstalled As Boolean
End Class