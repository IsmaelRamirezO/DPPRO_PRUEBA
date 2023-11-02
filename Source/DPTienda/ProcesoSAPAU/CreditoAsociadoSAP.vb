Public Class CreditoAsociadoSAP

    Private m_chrBloqueado As Char
    Private m_decCredito As Decimal
    Private m_decLimiteCredito As Decimal
    Private m_strCodigoAsociadoSAP As String

    Public Property CodigoAsociadoSAP() As String
        Get
            Return m_strCodigoAsociadoSAP
        End Get
        Set(ByVal Value As String)
            m_strCodigoAsociadoSAP = Value
        End Set
    End Property

    Public Property LimiteCredito() As Decimal
        Get
            Return m_decLimiteCredito
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCredito = Value
        End Set
    End Property

    Public Property Credito() As Decimal
        Get
            Return m_decCredito
        End Get
        Set(ByVal Value As Decimal)
            m_decCredito = Value
        End Set
    End Property

    Public Property Bloqueado() As Char
        Get
            Return m_chrBloqueado
        End Get
        Set(ByVal Value As Char)
            m_chrBloqueado = Value
        End Set
    End Property

    Public Sub New()

        MyBase.New()
        ClearFields()

    End Sub

    Private Sub ClearFields()
        m_chrBloqueado = ""
        m_decCredito = 0
        m_decLimiteCredito = 0
        m_strCodigoAsociadoSAP = String.Empty
    End Sub

End Class
