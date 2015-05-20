Imports System.Xml

Public Class currentProjectClass
    Public Property projectName As String
    Public Property projectPath As String

    Public Sub CreateDefaultConfig()
        ' Create XmlWriterSettings.
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        ' Create XmlWriter.
        Using writer As XmlWriter = XmlWriter.Create(projectPath + "/extremeStudio.config", settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement("ProjectMainConfig")
            writer.WriteElementString("ProjectName", projectName)
            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub

    Public Sub EditProjectConfig(key As String, value As String)

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