Imports System.IO
Imports System.Net
Imports System.Xml

Public Class EsPluginsForm
    Dim _plugins As New List(Of EsPluginData)
    Dim _isThereInteret As Boolean = True

    Private Sub RefreshList()
        PluginList.Items.Clear()
        For Each plug In _plugins
            PluginList.Items.Add(plug.PluginName)
        Next
    End Sub

    Private Function IsPluginInstalled(plug as EsPluginData)
        Dim file As String = Path.GetFileName(plug.PluginPath)
        If My.Computer.FileSystem.FileExists(Mainform.ApplicationFiles + "/plugins/" + file)
            Return True
        Else
            Return False
        End If
    End Function
    Private Function IsPluginDifferent(plug As EsPluginData)
        Dim file As String = Path.GetFileName(plug.PluginPath)
        Dim oldHash As String = ExtremeCore.GetFileHash(Mainform.ApplicationFiles + "/plugins/" + file)
        If oldHash = plug.PluginSha
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub EsPluginsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _plugins.Clear()

        If ExtremeCore.isNetAvailable() Then 'Download latest from internet if there is internet.
            Dim webClient As New WebClient
            Dim xmlFile As New XmlDocument()
            Dim fileText As String = webClient.DownloadString("http://johnymac.github.io/esfiles/esplugins.xml")
            xmlFile.LoadXml(fileText)

            For Each cs As XmlNode In xmlFile.SelectNodes("xml/plugin")
                Dim plug As New EsPluginData
                plug.PluginName = cs("name").InnerText.Trim
                plug.PluginDesc = cs("desc").InnerText.Trim
                plug.PluginPath = cs("download").InnerText.Trim
                plug.PluginSha = cs("hash").InnerText.Trim
                _plugins.Add(plug)
            Next
        Else
            _isThereInteret = False
            For Each file In Directory.GetFiles(MainForm.ApplicationFiles + "/plugins", "*.dll")
                _plugins.Add(New EsPluginData() With { .PluginName = Path.GetFileName(file) })
            Next
        End If

        RefreshList()
    End Sub

    Private Sub PluginList_Click(sender As Object, e As EventArgs) Handles PluginList.Click
            If PluginList.SelectedIndex <> - 1 Then
                If _isThereInteret Then
                    For Each plug In _plugins
                        If plug.PluginName = PluginList.SelectedItem
                            PluginNameText.Text = plug.PluginName
                            PluginDescText.Text = plug.PluginDesc
                            If IsPluginInstalled(plug)
                                installBtn.Text = "ReInstall Plugin"
                                installBtn.Enabled = True
                                deleteBtn.Visible = True
                                If IsPluginDifferent(plug)
                                    updateLabel.Visible = True
                                End If
                            Else
                                installBtn.Text = "Install Plugin"
                                installBtn.Enabled = True
                                deleteBtn.Visible = False
                                updateLabel.Visible = False
                            End If
                        End If
                    Next
                Else 
                    installBtn.Text = ""
                    installBtn.Enabled = False
                    deleteBtn.Visible = True
                    updateLabel.Visible = False
                End If
            Else
                installBtn.Text = ""
                installBtn.Enabled = False
                deleteBtn.Visible = False
                updateLabel.Visible = False
            End If

    End Sub

    Private Sub installBtn_Click(sender As Object, e As EventArgs) Handles installBtn.Click
        If _isThereInteret
            If PluginList.SelectedIndex <> -1
                Dim plugPath As String = Nothing
                For Each plug In _plugins
                    If plug.PluginName = PluginList.SelectedItem Then
                        plugPath = Mainform.ApplicationFiles + "/plugins/" + Path.GetFileName(plug.PluginPath)
                        If File.Exists(plugPath) Then File.Delete(plugPath)
                        Dim web As New WebClient
                        web.DownloadFile(plug.PluginPath, plugPath)
                        EsPluginsForm_Load(Me, Nothing)
                        PluginList_Click(Me, Nothing)
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click
        If _isThereInteret
            If PluginList.SelectedIndex <> -1
                Dim plugPath As String = Nothing
                For Each plug In _plugins
                    If plug.PluginName = PluginList.SelectedItem Then
                        plugPath = Mainform.ApplicationFiles + "/plugins/" + Path.GetFileName(plug.PluginPath)
                        If File.Exists(plugPath) Then File.Delete(plugPath)
                        EsPluginsForm_Load(Me, Nothing)
                        PluginList_Click(Me, Nothing)
                        Exit For
                    End If
                Next
            End If
        Else
            File.Delete(Mainform.ApplicationFiles + "/plugins/" + PluginList.SelectedItem)
            EsPluginsForm_Load(Me, Nothing)
            PluginList_Click(Me, Nothing)
        End If
    End Sub
End Class

Public Class EsPluginData
    Public Property PluginName As String
    Public Property PluginDesc As String
    Public Property PluginPath As String
    Public Property PluginSha As String
End Class