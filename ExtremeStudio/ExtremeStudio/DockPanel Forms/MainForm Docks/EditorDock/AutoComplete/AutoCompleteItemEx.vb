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
    Public Sub New(type As AutoCompeleteTypes, funcName As String, funcPars As FunctionParameters)
        'First of all set the the main stuff like text and icon.
        Text = funcName
        ImageIndex = type

        'Setup the tooltip.
        ToolTipTitle = "PawnDoc Help: "

        'If there is pawnDoc, use it.
        If funcPars.pawnDoc IsNot Nothing Then
            Dim allText As String = ""

            'Do the remarks
            allText += "Remarks: " + vbCrLf + vbTab + funcPars.pawnDoc.Remarks + vbCrLf + vbCrLf

            'Do the Parameters. (HARDEST ONE)
            allText += "Parameters :" + vbCrLf

            For Each par As String In funcPars.pawnDoc.Parameters.Keys
                Dim parType As String = funcPars.GetParameterType(par, FunctionParameters.returnType.AS_STRING)

                allText += vbTab + "(" + parType + ") " + par + ": " + funcPars.pawnDoc.Parameters(par) + vbCrLf
            Next
            allText += vbCrLf

            'Do the returns.
            allText += "Returns: " + vbCrLf + vbTab + funcPars.pawnDoc.Returns + vbCrLf + vbCrLf

            'Then simply set it.
            ToolTipText = allText

            'Save the stuff.
            p_type = type
            p_funcPars = funcPars
        Else
            'there is no PawnDoc.. Just show the parameters.
            ToolTipText = "Parameters: " + vbCrLf + funcPars.paramsText

            'Save the stuff.
            p_type = type
            p_funcPars = funcPars
        End If
    End Sub
End Class
