Imports AutocompleteMenuNS
Imports ExtremeParser

'This is a custom AutoCompleteItem to store all info about a certain item here.
'Like PawnDoc.

Public Class AutoCompleteItemEx
    Inherits AutocompleteItem

    Private p_funcPars As FunctionParameters = Nothing
    Public ReadOnly Property Parameters As FunctionParameters
        Get
            Return p_funcPars
        End Get
    End Property

    Private p_type As AutoCompeleteTypes
    Public ReadOnly Property Type As AutoCompeleteTypes
        Get
            Return p_type
        End Get
    End Property

    Public Enum AutoCompeleteTypes
        TYPE_FUNCTION 'It equals ZERO which means that it will be the functions icon in the image index.
        TYPE_DEFINE 'It equals ONE which means that it will be the define icon in the image index.
    End Enum

    Public Sub New(type As AutoCompeleteTypes, funcName As String, toolTip As String)
        'First of all set the the main stuff like text and icon.
        Text = funcName
        ImageIndex = type

        'Setup the tooltip.
        ToolTipTitle = "PawnDoc Help: "
        ToolTipText = toolTip

        'Save the type.
        p_type = type
    End Sub

    Public Function AutoTab(str As String) As String
        AutoTab = vbTab
        AutoTab += str.Replace(vbCrLf, vbCrLf + vbTab)
        Return AutoTab
    End Function

    Public Sub New(type As AutoCompeleteTypes, func As FunctionsStruct)
        'First of all set the the main stuff like text and icon.
        Text = func.FuncName
        ImageIndex = type

        'Setup the tooltip.
        ToolTipTitle = "PawnDoc Help: "

        'If there is pawnDoc, use it.
        If func.FuncPawnDoc IsNot Nothing Then
            Dim allText As String = ""

            'Do the remarks
            allText += "Remarks: " + vbCrLf + AutoTab(func.FuncPawnDoc.Remarks) + vbCrLf + vbCrLf

            'Do the Parameters. (HARDEST ONE)
            allText += "Parameters :" + vbCrLf

            For Each itm As KeyValuePair(Of String, String) In func.FuncPawnDoc.Parameters
                Dim par As String = itm.Key
                Dim desc As String = itm.Value

                Dim parType As String = func.FuncParameters.GetParameterType(par, FunctionParameters.returnType.AS_STRING)

                allText += vbTab + "(" + parType + ") " + par + ": " + desc + vbCrLf
            Next
            allText += vbCrLf

            'Do the returns.
            allText += "Returns: " + vbCrLf + AutoTab(func.FuncPawnDoc.Returns) + vbCrLf + vbCrLf

            'Then simply set it.
            ToolTipText = allText

            'Save the stuff.
            p_type = type
            p_funcPars = func.FuncParameters
        Else
            'there is no PawnDoc.. Setup our own.
            Dim allText As String = "Function Name: " + func.FuncName + vbCrLf
            allText += "Parameters: " + func.FuncParameters.paramsText + vbCrLf
            allText += "Return Tag: " + func.ReturnTag + vbCrLf

            ToolTipText = allText

            'Save the stuff.
            p_type = type
            p_funcPars = func.FuncParameters
        End If
    End Sub
End Class
