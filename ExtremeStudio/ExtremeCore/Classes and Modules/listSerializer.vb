Imports System.IO
Imports System.Xml.Serialization

Public Class listSerializer
    Public Shared Function Serialize(Of T)(ByVal obj As T) As String
        Dim xml As New System.Xml.Serialization.XmlSerializer(GetType(T))
        Dim ns As New System.Xml.Serialization.XmlSerializerNamespaces()
        ns.Add("", "") 'No namespaces needed.
        Dim sw As New IO.StringWriter()
        xml.Serialize(sw, obj, ns)

        If sw IsNot Nothing Then
            Return sw.ToString()
        Else
            Return ""
        End If
    End Function
    Public Shared Function Deserialize(Of T)(ByVal serializedXml As String) As T
        Dim xml As New System.Xml.Serialization.XmlSerializer(GetType(T))
        Dim sr As New IO.StringReader(serializedXml)
        Dim obj As T = CType(xml.Deserialize(sr), T)

        Return obj
    End Function
End Class
