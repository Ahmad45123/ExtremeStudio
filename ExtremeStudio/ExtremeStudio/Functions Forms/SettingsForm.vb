Imports System.Web.Script.Serialization
Imports ExtremeCore

Public Class SettingsForm

    'This is to avoid to Reload the colors when its already loaded and no mods are done.. 
    Public ReadOnly Property hasBeenLoadedBefore As Boolean
        Get
            Return hasFInished
        End Get
    End Property
    Dim hasFInished As Boolean = False

    Public Event OnSettingsChange()

    Public Sub ReloadInfo()
        If Not My.Computer.FileSystem.FileExists(MainForm.APPLICATION_FILES + "/configs/themeInfo.xml") Then
            My.Computer.FileSystem.WriteAllText(MainForm.APPLICATION_FILES + "/configs/themeInfo.xml", My.Resources.defaultThemeInfo, False)
        End If

        Dim allStuff As allStuffClass = ObjectSerializer.Deserialize(Of allStuffClass)(My.Computer.FileSystem.ReadAllText(MainForm.APPLICATION_FILES + "/configs/themeInfo.xml"))
#Region "Apply Stuff to the public controls."
        defaultColor.Color = allStuff.defaultColor.getColor
        pawndocColor.Color = allStuff.pawnDocColor.getColor
        pawnColor.Color = allStuff.pawnColor.getColor
        definesColor.Color = allStuff.definesColor.getColor
        operatorColor.Color = allStuff.operatorColor.getColor
        commentColor.Color = allStuff.commentColor.getColor
        numberColor.Color = allStuff.numbersColor.getColor
        functionsColor.Color = allStuff.functionsColor.getColor
        stringColor.Color = allStuff.stringsColor.getColor
        preproccessColor.Color = allStuff.preProcessColor.getColor
        backgroundColor.Color = allStuff.backGroundColor.getColor
        lineNumberColor.Color = allStuff.lineNumbersColor.getColor
        caretColor.Color = allStuff.caretColor.getColor

        FontDialog.Font = New Font(New FontFamily(allStuff.textFont), allStuff.textSize)
#End Region

        If hasFInished = False Then hasFInished = True
    End Sub

    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadInfo()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FontDialog.ShowDialog()
    End Sub

    Private Sub SettingsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim allStuff As New allStuffClass

#Region "Get Stuff From Public Controls"
        allStuff.defaultColor.setColor(defaultColor.Color)
        allStuff.pawnDocColor.setColor(pawndocColor.Color)
        allStuff.pawnColor.setColor(pawnColor.Color)
        allStuff.definesColor.setColor(definesColor.Color)
        allStuff.operatorColor.setColor(operatorColor.Color)
        allStuff.commentColor.setColor(commentColor.Color)
        allStuff.numbersColor.setColor(numberColor.Color)
        allStuff.functionsColor.setColor(functionsColor.Color)
        allStuff.stringsColor.setColor(stringColor.Color)
        allStuff.preProcessColor.setColor(preproccessColor.Color)
        allStuff.backGroundColor.setColor(backgroundColor.Color)
        allStuff.lineNumbersColor.setColor(lineNumberColor.Color)
        allStuff.caretColor.setColor(caretColor.Color)

        allStuff.textFont = FontDialog.Font.FontFamily.Name
        allStuff.textSize = FontDialog.Font.Size
#End Region

        'Serialize and save.
        Dim outPut As String = ObjectSerializer.Serialize(allStuff)
        My.Computer.FileSystem.WriteAllText(MainForm.APPLICATION_FILES + "/configs/themeInfo.xml", outPut, False)
    End Sub

    Private Sub defaultColor_onColorChange() Handles stringColor.onColorChange, preproccessColor.onColorChange, pawndocColor.onColorChange, pawnColor.onColorChange, operatorColor.onColorChange, numberColor.onColorChange, lineNumberColor.onColorChange, functionsColor.onColorChange, definesColor.onColorChange, defaultColor.onColorChange, commentColor.onColorChange, caretColor.onColorChange, backgroundColor.onColorChange
        RaiseEvent OnSettingsChange()
    End Sub
End Class

Public Class allStuffClass
    Public Property defaultColor As New serializeableColor
    Public Property pawnDocColor As New serializeableColor
    Public Property pawnColor As New serializeableColor
    Public Property definesColor As New serializeableColor
    Public Property operatorColor As New serializeableColor
    Public Property commentColor As New serializeableColor
    Public Property numbersColor As New serializeableColor
    Public Property functionsColor As New serializeableColor
    Public Property stringsColor As New serializeableColor
    Public Property preProcessColor As New serializeableColor
    Public Property backGroundColor As New serializeableColor
    Public Property lineNumbersColor As New serializeableColor
    Public Property caretColor As New serializeableColor

    Public Property textFont As String
    Public Property textSize As Integer
End Class