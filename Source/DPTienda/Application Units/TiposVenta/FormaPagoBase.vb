Public Class FormaPagoBase

    Protected strID As String
    Protected strDescription As String

    Public Sub New()
        strID = String.Empty
        strDescription = String.Empty
    End Sub

    Public ReadOnly Property ID() As String
        Get
            Return strID
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return strDescription
        End Get
    End Property

End Class