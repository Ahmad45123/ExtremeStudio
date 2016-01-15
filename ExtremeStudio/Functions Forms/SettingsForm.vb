Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports System.Xml
Imports ExtremeCore

Public Class SettingsForm

    'The main colors info: 
    Public ColorsInfo As New syntaxInfo

    'This is to avoid to Reload the colors when its already loaded and no mods are done.. 
    Public ReadOnly Property HasBeenLoadedBefore As Boolean
        Get
            Return _hasFInished
        End Get
    End Property
    Dim _hasFInished As Boolean = False

    Public Event OnSettingsChange()

    Public Sub ReloadInfo()
        If Not My.Computer.FileSystem.FileExists(MainForm.ApplicationFiles + "/configs/themeInfo.xml") Then
            My.Computer.FileSystem.WriteAllText(MainForm.ApplicationFiles + "/configs/themeInfo.xml", My.Resources.defaultThemeInfo, False)
        End If

        colorsInfo.LoadInfo(MainForm.ApplicationFiles + "/configs/themeInfo.xml")

        colorsSettings.SelectedObject = colorsInfo
        If _hasFInished = False Then _hasFInished = True
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadInfo()
    End Sub

    Private Sub SettingsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        colorsInfo.SaveInfo(MainForm.ApplicationFiles + "/configs/themeInfo.xml")
    End Sub

    Private Sub colorsSettings_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles colorsSettings.PropertyValueChanged
        RaiseEvent OnSettingsChange()
    End Sub
End Class

Public Class SyntaxInfo

    <DisplayName("Code Font"), Category("Font Settings")>
    Public Property SFont As Font

    <DisplayName("Default"), Category("Language Syntax Highlighting")>
    Public Property SDefault As Color = Color.Black
    <DisplayName("Integers"), Category("Language Syntax Highlighting")>
    Public Property SInteger As Color = Color.Black
    <DisplayName("Strings"), Category("Language Syntax Highlighting")>
    Public Property SString As Color = Color.Black
    <DisplayName("Symbols"), Category("Language Syntax Highlighting")>
    Public Property SSymbols As Color = Color.Black
    <DisplayName("SingleLine Comments"), Category("Language Syntax Highlighting")>
    Public Property SSlComments As Color = Color.Black
    <DisplayName("MultiLine Comments"), Category("Language Syntax Highlighting")>
    Public Property SMlComments As Color = Color.Black
    <DisplayName("PawnDoc"), Category("Language Syntax Highlighting")>
    Public Property SPawnDoc As Color = Color.Black
    <DisplayName("Pawn PreProcessor"), Category("Language Syntax Highlighting")>
    Public Property SPawnPre As Color = Color.Black
    <DisplayName("Pawn KeyWords"), Category("Language Syntax Highlighting")>
    Public Property SPawnKeys As Color = Color.Black

    <DisplayName("Functions"), Category("WordSets Syntax Highlighting")>
    Public Property SFunctions As Color = Color.Black
    <DisplayName("Publics"), Category("WordSets Syntax Highlighting")>
    Public Property SPublics As Color = Color.Black
    <DisplayName("Stocks"), Category("WordSets Syntax Highlighting")>
    Public Property SStocks As Color = Color.Black
    <DisplayName("Natives"), Category("WordSets Syntax Highlighting")>
    Public Property SNatives As Color = Color.Black
    <DisplayName("Defines"), Category("WordSets Syntax Highlighting")>
    Public Property SDefines As Color = Color.Black
    <DisplayName("Macros"), Category("WordSets Syntax Highlighting")>
    Public Property SMacros As Color = Color.Black
    <DisplayName("Enums"), Category("WordSets Syntax Highlighting")>
    Public Property SEnums As Color = Color.Black
    <DisplayName("Global Variables"), Category("WordSets Syntax Highlighting")>
    Public Property SGlobalVars As Color = Color.Black

    Public Sub SaveInfo(path As String)
        Dim settings As New XmlWriterSettings()
        settings.Indent = True

        Dim writer = XmlWriter.Create(path, settings)
        writer.WriteStartDocument()
        writer.WriteStartElement("themeInfo")


        writer.WriteStartElement("FontInfo")
        writer.WriteElementString("FontName", sFont.FontFamily.Name)
        writer.WriteElementString("FontSize", sFont.Size)
        writer.WriteElementString("FontBold", sFont.Bold)
        writer.WriteEndElement()


        writer.WriteStartElement("LanguageSyntaxHighlighting")
        WriteColor(writer, NameOf(sDefault), sDefault)
        WriteColor(writer, NameOf(sInteger), sInteger)
        WriteColor(writer, NameOf(sString), sString)
        WriteColor(writer, NameOf(sSymbols), sSymbols)
        WriteColor(writer, NameOf(sSLComments), sSLComments)
        WriteColor(writer, NameOf(sMLComments), sMLComments)
        WriteColor(writer, NameOf(sPawnDoc), sPawnDoc)
        WriteColor(writer, NameOf(sPawnPre), sPawnPre)
        WriteColor(writer, NameOf(sPawnKeys), sPawnKeys)
        writer.WriteEndElement()


        writer.WriteStartElement("WordSetsSyntaxHighlighting")
        WriteColor(writer, NameOf(sFunctions), sFunctions)
        WriteColor(writer, NameOf(sPublics), sPublics)
        WriteColor(writer, NameOf(sStocks), sStocks)
        WriteColor(writer, NameOf(sNatives), sNatives)
        WriteColor(writer, NameOf(sDefines), sDefines)
        WriteColor(writer, NameOf(sMacros), sMacros)
        WriteColor(writer, NameOf(sEnums), sEnums)
        WriteColor(writer, NameOf(sGlobalVars), sGlobalVars)
        writer.WriteEndElement()


        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Flush()
        writer.Close()
    End Sub
    Private Sub WriteColor(ByRef writer As XmlWriter, name As String, clr As Color)
        writer.WriteStartElement(name)
        writer.WriteElementString("A", clr.A)
        writer.WriteElementString("R", clr.R)
        writer.WriteElementString("G", clr.G)
        writer.WriteElementString("B", clr.B)
        writer.WriteEndElement()
    End Sub

    Public Sub LoadInfo(path As String)
        Dim doc As New XmlDocument()
        doc.Load(path)

        'Font: 
        If doc.SelectSingleNode("/themeInfo/FontInfo/FontBold").InnerText = "True" Then
            sFont = New Font(New FontFamily(doc.SelectSingleNode("/themeInfo/FontInfo/FontName").InnerText), Convert.ToSingle(doc.SelectSingleNode("/themeInfo/FontInfo/FontSize").InnerText), FontStyle.Bold)
        Else
            sFont = New Font(New FontFamily(doc.SelectSingleNode("/themeInfo/FontInfo/FontName").InnerText), Convert.ToSingle(doc.SelectSingleNode("/themeInfo/FontInfo/FontSize").InnerText), FontStyle.Regular)
        End If

        'LanguageSyntaxHighlighting
        sDefault = GetColor(doc.SelectSingleNode("/themeInfo/LanguageSyntaxHighlighting/" + NameOf(sDefault)))
        sInteger = GetColor(doc.SelectSingleNode("/themeInfo/LanguageSyntaxHighlighting/" + NameOf(sInteger)))
        sString = GetColor(doc.SelectSingleNode("/themeInfo/LanguageSyntaxHighlighting/" + NameOf(sString)))
        sSymbols = GetColor(doc.SelectSingleNode("/themeInfo/LanguageSyntaxHighlighting/" + NameOf(sSymbols)))
        sSLComments = GetColor(doc.SelectSingleNode("/themeInfo/LanguageSyntaxHighlighting/" + NameOf(sSLComments)))
        sMLComments = GetColor(doc.SelectSingleNode("/themeInfo/LanguageSyntaxHighlighting/" + NameOf(sMLComments)))
        sPawnDoc = GetColor(doc.SelectSingleNode("/themeInfo/LanguageSyntaxHighlighting/" + NameOf(sPawnDoc)))
        sPawnPre = GetColor(doc.SelectSingleNode("/themeInfo/LanguageSyntaxHighlighting/" + NameOf(sPawnPre)))
        sPawnKeys = GetColor(doc.SelectSingleNode("/themeInfo/LanguageSyntaxHighlighting/" + NameOf(sPawnKeys)))

        'WordSetsSyntaxHighlighting
        sFunctions = GetColor(doc.SelectSingleNode("/themeInfo/WordSetsSyntaxHighlighting/" + NameOf(sFunctions)))
        sPublics = GetColor(doc.SelectSingleNode("/themeInfo/WordSetsSyntaxHighlighting/" + NameOf(sPublics)))
        sStocks = GetColor(doc.SelectSingleNode("/themeInfo/WordSetsSyntaxHighlighting/" + NameOf(sStocks)))
        sNatives = GetColor(doc.SelectSingleNode("/themeInfo/WordSetsSyntaxHighlighting/" + NameOf(sNatives)))
        sDefines = GetColor(doc.SelectSingleNode("/themeInfo/WordSetsSyntaxHighlighting/" + NameOf(sDefines)))
        sMacros = GetColor(doc.SelectSingleNode("/themeInfo/WordSetsSyntaxHighlighting/" + NameOf(sMacros)))
        sEnums = GetColor(doc.SelectSingleNode("/themeInfo/WordSetsSyntaxHighlighting/" + NameOf(sEnums)))
        sGlobalVars = GetColor(doc.SelectSingleNode("/themeInfo/WordSetsSyntaxHighlighting/" + NameOf(sGlobalVars)))
    End Sub

    Public Function GetColor(nde As XmlNode) As Color
        Return Color.FromArgb(Convert.ToInt32(nde.Item("A").InnerText), Convert.ToInt32(nde.Item("R").InnerText), Convert.ToInt32(nde.Item("G").InnerText), Convert.ToInt32(nde.Item("B").InnerText))
    End Function
End Class