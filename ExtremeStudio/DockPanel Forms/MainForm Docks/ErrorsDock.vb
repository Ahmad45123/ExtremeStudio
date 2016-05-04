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


    Public ErrorWarningList As New List(Of ScriptErrorInfo)
    Public Sub RefreshErrorWarnings()

    End Sub

End Class