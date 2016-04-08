Imports System.ComponentModel
Imports System.Drawing.Text
Imports System.Text
Imports ExtremeCore
Imports Newtonsoft.Json
Imports Newtonsoft.Json.JsonConverter
Imports Newtonsoft.Json.Serialization

Public Class SettingsForm

    'The main colors info: 
    Public ColorsInfo As New SyntaxInfo

    'This is to avoid to Reload the colors when its already loaded and no mods are done.. 
    Public ReadOnly Property HasBeenLoadedBefore As Boolean
        Get
            Return _hasFInished
        End Get
    End Property
    Dim _hasFInished As Boolean = False

    Public Event OnSettingsChange()

    Public Sub ReloadInfo()
        If Not My.Computer.FileSystem.FileExists(MainForm.ApplicationFiles + "/configs/themeInfo.json") Then
            My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "/configs/themeInfo.json", My.Resources.defaultThemeInfo, False)
        End If

        SyntaxInfo.LoadInfo(ColorsInfo, MainForm.ApplicationFiles + "/configs/themeInfo.json")

        colorsSettings.SelectedObject = ColorsInfo
        If _hasFInished = False Then _hasFInished = True
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadInfo()
    End Sub

    Private Sub SettingsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SyntaxInfo.SaveInfo(ColorsInfo, MainForm.ApplicationFiles + "/configs/themeInfo.json")
    End Sub

    Private Sub colorsSettings_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles colorsSettings.PropertyValueChanged
        RaiseEvent OnSettingsChange()
    End Sub
End Class

#Region "NoTypeConverterJsonConverter"
Public Class NoTypeConverterJsonConverter(Of T)
    Inherits JsonConverter
    Shared ReadOnly resolver As IContractResolver = New NoTypeConverterContractResolver()

    Private Class NoTypeConverterContractResolver
        Inherits DefaultContractResolver
        Protected Overrides Function CreateContract(objectType As Type) As JsonContract
            If GetType(T).IsAssignableFrom(objectType) Then
                Dim contract = Me.CreateObjectContract(objectType)
                contract.Converter = Nothing
                ' Also null out the converter to prevent infinite recursion.
                Return contract
            End If
            Return MyBase.CreateContract(objectType)
        End Function
    End Class

    Public Overrides Function CanConvert(objectType As Type) As Boolean
        Return GetType(T).IsAssignableFrom(objectType)
    End Function

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        Return JsonSerializer.CreateDefault(New JsonSerializerSettings() With { .ContractResolver = resolver }).Deserialize(reader, objectType)
    End Function

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        JsonSerializer.CreateDefault(New JsonSerializerSettings() With { .ContractResolver = resolver }).Serialize(writer, value)
    End Sub
End Class
#End Region
<TypeConverter(GetType(ExpandableObjectConverter))>
<JsonConverter(GetType(NoTypeConverterJsonConverter(of StyleItem)))>
Public Class StyleItem
    Public Property Font As Font = Nothing
    Public Property ForeColor As Color = Color.Transparent
    Public Property BackColor As Color = Color.Transparent
End Class
Public Class SyntaxInfo

    <DisplayName("Default"), Category("Language Syntax Highlighting")>
    Public Property SDefault As New StyleItem()
    <DisplayName("Integers"), Category("Language Syntax Highlighting")>
    Public Property SInteger As New StyleItem()
    <DisplayName("Strings"), Category("Language Syntax Highlighting")>
    Public Property SString As New StyleItem()
    <DisplayName("Symbols"), Category("Language Syntax Highlighting")>
    Public Property SSymbols As New StyleItem()
    <DisplayName("SingleLine Comments"), Category("Language Syntax Highlighting")>
    Public Property SSlComments As New StyleItem()
    <DisplayName("MultiLine Comments"), Category("Language Syntax Highlighting")>
    Public Property SMlComments As New StyleItem()
    <DisplayName("PawnDoc"), Category("Language Syntax Highlighting")>
    Public Property SPawnDoc As New StyleItem()
    <DisplayName("Pawn PreProcessor"), Category("Language Syntax Highlighting")>
    Public Property SPawnPre As New StyleItem()
    <DisplayName("Pawn KeyWords"), Category("Language Syntax Highlighting")>
    Public Property SPawnKeys As New StyleItem()

    <DisplayName("Functions"), Category("WordSets Syntax Highlighting")>
    Public Property SFunctions As New StyleItem()
    <DisplayName("Publics"), Category("WordSets Syntax Highlighting")>
    Public Property SPublics As New StyleItem()
    <DisplayName("Stocks"), Category("WordSets Syntax Highlighting")>
    Public Property SStocks As New StyleItem()
    <DisplayName("Natives"), Category("WordSets Syntax Highlighting")>
    Public Property SNatives As New StyleItem()
    <DisplayName("Defines"), Category("WordSets Syntax Highlighting")>
    Public Property SDefines As New StyleItem()
    <DisplayName("Macros"), Category("WordSets Syntax Highlighting")>
    Public Property SMacros As New StyleItem()
    <DisplayName("Enums"), Category("WordSets Syntax Highlighting")>
    Public Property SEnums As New StyleItem()
    <DisplayName("Global Variables"), Category("WordSets Syntax Highlighting")>
    Public Property SGlobalVars As New StyleItem()

    Public Shared Sub SaveInfo(ByRef obj As SyntaxInfo, path As String)
        My.Computer.FileSystem.WriteAllText(path, JsonConvert.SerializeObject(obj), False)
    End Sub
    Public Shared Sub LoadInfo(ByRef obj As SyntaxInfo, path As String)
        obj = JsonConvert.DeserializeObject(Of SyntaxInfo)(My.Computer.FileSystem.ReadAllText(path))
    End Sub
End Class