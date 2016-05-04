Public Class ErrorsDock
    Public Class ScriptErrorInfo

        Public Enum ErrorTypes
            [Error]
            Warning
        End Enum

        Public Property FileName As String
        Public Property LineNumber As String
        Public Property ErrorType As ErrorTypes
        Public Property ErrorNumber As String
        Public Property ErrorMessage As String
    End Class
    

    Public ErrorWarningList As List(Of ScriptErrorInfo)
    Public Sub RefreshErrorWarnings()
        errorsWarnsGrid.Rows.Clear()

        For Each err As ScriptErrorInfo In ErrorWarningList
            If err.ErrorType = ScriptErrorInfo.ErrorTypes.Error And showErrorsCheck.Checked = False Then Continue For
            If err.ErrorType = ScriptErrorInfo.ErrorTypes.Warning And showWarnsCheck.Checked = False Then Continue For

             errorsWarnsGrid.Rows.Add({ _
                    IIf(err.ErrorType = ScriptErrorInfo.ErrorTypes.Error, My.Resources.ribbob_errors, My.Resources.warning_icon), _
                    err.FileName, _
                    err.LineNumber, _
                    err.ErrorNumber, _
                    err.ErrorMessage _
                })
        Next
    End Sub

    Private Sub showWarnsCheck_CheckedChanged(sender As Object, e As EventArgs) Handles showWarnsCheck.CheckedChanged, showErrorsCheck.CheckedChanged
        RefreshErrorWarnings()
    End Sub
End Class