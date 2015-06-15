Imports System.Xml

Public Class currentProjectClass
    Public Property projectName As String
    Public Property projectVersion As Integer
    Public Property projectPath As String

    'Will only work if the projectPath is set to valid ExtremeStudio project.
    Public Sub ReadInfo()
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        m_xmld = New XmlDocument()
        m_xmld.Load(projectPath + "/extremeStudio.config")
        m_nodelist = m_xmld.SelectNodes("ProjectMainConfig")
        For Each m_node In m_nodelist
            projectName = m_node.ChildNodes.Item(0).InnerText 'ProjectName
            projectVersion = m_node.ChildNodes.Item(1).InnerText 'ProjectVersion
        Next
    End Sub
    Public Sub SaveInfo() 'Will only work if the projectPath is set to valid ExtremeStudio project.
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        Using writer As XmlWriter = XmlWriter.Create(projectPath + "/extremeStudio.config", settings)
            writer.WriteStartDocument()
            writer.WriteStartElement("ProjectMainConfig")
            writer.WriteElementString("ProjectName", projectName)
            writer.WriteElementString("ProjectVersion", projectVersion.ToString)
            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub

    Public Sub EditSAMPConfig(key As String, value As String)
        'Variables
        Dim allInfo As New List(Of String)

        'Reading
        Dim TextLine As String
        If System.IO.File.Exists(projectPath + "/server.cfg") = True Then
            Dim objReader As New System.IO.StreamReader(projectPath + "/server.cfg")
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                allInfo.Add(TextLine)
            Loop
        End If

        'Editing
        Dim allText As String = Nothing 'To short the loops :P
        For Each Str As String In allInfo
            Dim values() As String = Str.Split(" ", 2, StringSplitOptions.None)
            If values(0) = key Then
                values(1) = value
                Str = values(0) + " " + values(1)
                allText = Str + vbCrLf
                Exit For
            End If
            allText = Str + vbCrLf
        Next

        'Writing
        My.Computer.FileSystem.WriteAllText(projectPath + "/server.cfg", allText, False)
    End Sub

    Public Function GetSAMPConfig(key As String)
        Dim TextLine As String
        If System.IO.File.Exists(projectPath + "/server.cfg") = True Then
            Dim objReader As New System.IO.StreamReader(projectPath + "/server.cfg")
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                Dim values() As String = TextLine.Split(" ", 2, StringSplitOptions.None)
                If values(0) = key Then
                    Return values(1)
                End If
            Loop
        End If
        Return -1
    End Function
End Class