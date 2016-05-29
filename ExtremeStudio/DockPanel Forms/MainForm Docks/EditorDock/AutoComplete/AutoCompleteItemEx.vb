Imports AutocompleteMenuNS
Imports ExtremeParser
Imports ExtremeStudio.My.Resources

'This is a custom AutoCompleteItem to store all info about a certain item here.
'Like PawnDoc.

Public Class AutoCompleteItemEx
    Inherits AutocompleteItem

    Private _pFuncPars As FunctionParameters = Nothing
    Public ReadOnly Property Parameters As FunctionParameters
        Get
            Return _pFuncPars
        End Get
    End Property

    Private _pType As AutoCompeleteTypes
    Public ReadOnly Property Type As AutoCompeleteTypes
        Get
            Return _pType
        End Get
    End Property

    Public Enum AutoCompeleteTypes
        TypeFunction 'It equals ZERO which means that it will be the functions icon in the image index.
        TypeDefine 'It equals ONE which means that it will be the define icon in the image index.
    End Enum

    Public Sub New(type As AutoCompeleteTypes, funcName As String, toolTip As String)
        'First of all set the the main stuff like text and icon.
        Text = funcName
        ImageIndex = type

        'Setup the tooltip.
        ToolTipTitle = translations.AutoCompleteItemEx_PawnDocHelp
        ToolTipText = toolTip

        'Save the type.
        _pType = type
    End Sub

    Public Function AutoTab(str As String) As String
        If str Is Nothing Then Return Nothing

        AutoTab = vbTab
        AutoTab += str.Replace(vbCrLf, vbCrLf + vbTab)
        Return AutoTab
    End Function

    Public Sub New(type As AutoCompeleteTypes, func As FunctionsStruct)
        'First of all set the the main stuff like text and icon.
        Text = func.FuncName
        ImageIndex = type

        'Setup the tooltip.
        ToolTipTitle = translations.AutoCompleteItemEx_New_PawnDocHelp

        'If there is pawnDoc, use it.
        If func.FuncPawnDoc IsNot Nothing Then
            Dim allText As String = ""

            'Do the remarks
            allText += translations.AutoCompleteItemEx_New_Remarks + vbCrLf + AutoTab(func.FuncPawnDoc.Remarks) + vbCrLf + vbCrLf

            'Do the Parameters. (HARDEST ONE)
            allText += translations.AutoCompleteItemEx_New_Parameters + vbCrLf

            For Each itm As KeyValuePair(Of String, String) In func.FuncPawnDoc.Parameters
                Dim par As String = itm.Key
                Dim desc As String = itm.Value

                Dim parType As String = func.FuncParameters.GetParameterType(par, FunctionParameters.returnType.AsString)

                allText += vbTab + "(" + parType + ") " + par + ": " + desc + vbCrLf
            Next
            allText += vbCrLf

            'Do the returns.
            allText += translations.AutoCompleteItemEx_New_Returns + vbCrLf + AutoTab(func.FuncPawnDoc.Returns) + vbCrLf + vbCrLf

            'Then simply set it.
            ToolTipText = allText

            'Save the stuff.
            _pType = type
            _pFuncPars = func.FuncParameters
        Else
            'there is no PawnDoc.. Setup our own.
            Dim allText As String = translations.AutoCompleteItemEx_New_FunctionName + func.FuncName + vbCrLf
            allText += translations.AutoCompleteItemEx_New_Parameters + func.FuncParameters.paramsText + vbCrLf
            allText += translations.AutoCompleteItemEx_New_ReturnTag + func.ReturnTag + vbCrLf

            ToolTipText = allText

            'Save the stuff.
            _pType = type
            _pFuncPars = func.FuncParameters
        End If
    End Sub
End Class
