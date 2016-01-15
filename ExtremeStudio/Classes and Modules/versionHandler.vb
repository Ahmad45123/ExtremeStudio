Public Class VersionHandler
    Public Property CurrentVersion As String = "1.0.0"

    Public Sub DoIfUpdateNeeded(project As currentProjectClass)
        project.projectVersion = currentVersion
    End Sub
End Class
