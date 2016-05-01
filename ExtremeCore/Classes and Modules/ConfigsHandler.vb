Imports System.IO
Imports Newtonsoft.Json

Public Class ConfigsHandler
    Private _values As New Dictionary(Of String, Object)
    Private ReadOnly _autoSave As Boolean
    Private ReadOnly _dataFile As String

    Public Sub New(filePath As String, Optional defaultData As String = "", Optional isAutoSave As Boolean = False)
        _autoSave = isAutoSave
        _dataFile = filePath

        If File.Exists(_dataFile) = False And defaultData <> "" Then
            My.Computer.FileSystem.WriteAllText(_dataFile, defaultData, False)
        End If

        If File.Exists(_dataFile) = True Then
            Load()
        End If
    End Sub

    Public Default Property Item(key As String) As Object
        Get
            Return _values(key)
        End Get
        Set
            _values(key) = Value

            If _autoSave Then
                Save()
            End If
        End Set
    End Property

    Public Sub Save()
        Dim json As String = JsonConvert.SerializeObject(_values, Formatting.Indented)
        File.WriteAllText(_dataFile, json)
    End Sub

    Public Sub Delete(key As String)
        _values.Remove(key)

        If _autoSave Then
            Save()
        End If
    End Sub

    Private Sub Load()
        Dim json As String = File.ReadAllText(_dataFile)
        _values = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(json)
    End Sub
End Class