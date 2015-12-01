Public Class PawnDocParser

#Region "Public Properties"
    Public ReadOnly Property Summary As String
        Get
            Return p_summary
        End Get
    End Property
    Public ReadOnly Property Parameters As List(Of KeyValuePair(Of String, String))
        Get
            Return p_params
        End Get
    End Property
    Public ReadOnly Property Returns As String
        Get
            Return p_returns
        End Get
    End Property
    Public ReadOnly Property Remarks As String
        Get
            Return p_remarks
        End Get
    End Property
#End Region

    Private p_summary As String
    Private p_params As New List(Of KeyValuePair(Of String, String))
    Private p_returns As String
    Private p_remarks As String

    Public Sub New(text As String)
        'Prepare the text for parsing.
        Dim lines As String() = text.Split(vbCrLf.ToCharArray) 'Cut it into multiple lines.

        'Check for posible errors.
        If text.Contains("<summary>") And Not text.Contains("</summary>") Then Throw New ParserException("The summary closing tag is missing.", "")
        If text.Contains("<returns>") And Not text.Contains("</returns>") Then Throw New ParserException("The returns closing tag is missing.", "")
        If text.Contains("<remarks>") And Not text.Contains("</remarks>") Then Throw New ParserException("The remarks closing tag is missing.", "")

        'Configs.
        Dim isInSummary As Boolean = False : Dim currentSummary As String = Nothing
        Dim isInAParam As Boolean = False : Dim currentParamName As String = Nothing : Dim currentParam As String = Nothing : Dim currentParamDesc As String = Nothing
        Dim isInReturn As Boolean = False : Dim currentReturn As String = Nothing
        Dim isInRemarks As Boolean = False : Dim currentRemark As String = Nothing

        For Each line As String In lines
            line = line.Trim 'Remove the whitespace.

            If isInSummary Then
                currentSummary = currentSummary + IIf(line = "", "", line + vbCrLf) 'Add the old one.
                If currentSummary.EndsWith("</summary>" + vbCrLf) Then
                    currentSummary = currentSummary.Replace("</summary>" + vbCrLf, "")
                    p_summary = currentSummary.Trim()
                    isInSummary = False
                End If
                Continue For
            ElseIf isInAParam Then
                currentParam = currentParam + IIf(line = "", "", line + vbCrLf) 'Add the old one.
                If currentParam.EndsWith("</param>" + vbCrLf) Then
                    currentParam = currentParam.Replace("</param>" + vbCrLf, "")
                    currentParamDesc = currentParam.Trim()
                    isInAParam = False

                    'Create the key
                    Parameters.Add(New KeyValuePair(Of String, String)(currentParamName, currentParamDesc))
                End If
                Continue For
            ElseIf isInReturn Then
                currentReturn = currentReturn + IIf(line = "", "", line + vbCrLf) 'Add the old one.
                If currentReturn.EndsWith("</returns>" + vbCrLf) Then
                    currentReturn = currentReturn.Replace("</returns>" + vbCrLf, "")
                    p_returns = currentReturn.Trim()
                    isInReturn = False
                End If
                Continue For
            ElseIf isInRemarks Then
                currentRemark = currentRemark + IIf(line = "", "", line + vbCrLf) 'Add the old one.
                If currentRemark.EndsWith("</remarks>" + vbCrLf) Then
                    currentRemark = currentRemark.Replace("</remarks>" + vbCrLf, "")
                    p_remarks = currentRemark.Trim()
                    isInRemarks = False
                End If
                Continue For
            End If

            If line.StartsWith("<summary>") Then
                line = line.Replace("<summary>", "")
                currentSummary = line + vbCrLf

                If line.EndsWith("</summary>") Then
                    line = line.Replace("</summary>", "")
                    p_summary = line.Trim()
                Else
                    isInSummary = True
                End If
                Continue For
            ElseIf line.StartsWith("<param name=" + Chr(34)) Then
                line = line.Replace("<param name=" + Chr(34), "")
                currentParamName = line.Substring(0, line.IndexOf(Chr(34)))
                line = line.Remove(0, line.IndexOf(">") + 1)

                currentParam = line + vbCrLf
                If line.EndsWith("</param>") Then
                    line = line.Replace("</param>", "")
                    currentParamDesc = line.Trim()

                    'Create the key
                    Parameters.Add(New KeyValuePair(Of String, String)(currentParamName, currentParamDesc))
                Else
                    isInAParam = True
                End If
            ElseIf line.StartsWith("<returns>") Then
                line = line.Replace("<returns>", "")
                currentReturn = line + vbCrLf

                If line.EndsWith("</returns>") Then
                    line = line.Replace("</rturns>", "")
                    p_returns = line.Trim()
                Else
                    isInReturn = True
                End If
                Continue For
            ElseIf line.StartsWith("<remarks>") Then
                line = line.Replace("<remarks>", "")
                currentRemark = line + vbCrLf

                If line.EndsWith("</remarks>") Then
                    line = line.Replace("</remarks>", "")
                    p_remarks = line.Trim()
                Else
                    isInRemarks = True
                End If
                Continue For
            End If
        Next
    End Sub
End Class
