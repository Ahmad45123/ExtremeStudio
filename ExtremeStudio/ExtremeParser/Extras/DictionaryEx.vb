Public Class DictionaryEx(Of TKey, TValue)
    Inherits Dictionary(Of TKey, TValue)

    Private tags As New Dictionary(Of TKey, Object)
    Public Property Tag(id As TKey) As Object
        Get
            Return tags.Item(id)
        End Get
        Set(value As Object)
            tags.Remove(id) 'Remove if exist
            tags.Add(id, value)
        End Set
    End Property
End Class
