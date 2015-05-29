Public Class LabelButton
    Public Property LabelText As String
        Get
            Return Label.Text
        End Get
        Set(value As String)
            Label.Text = value
        End Set
    End Property
End Class
