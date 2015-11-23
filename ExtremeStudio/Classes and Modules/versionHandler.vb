Public Class versionHandler
    Public Property currentVersion As String = "1.0.0"

    Public Sub doIfUpdateNeeded(project As currentProjectClass)
        project.projectVersion = currentVersion
    End Sub
End Class
