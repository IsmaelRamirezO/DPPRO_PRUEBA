Public Class ZDP_PRODAPARTADO

#Region "Variables"

    Private m_strContrato As String
    Private m_strMatnr As String
    '------------------------------------------------------------------------------------------------
    'FLIZARRAGA 20/02/2018: Se agrega el número de serie para consignación.
    '------------------------------------------------------------------------------------------------
    Private m_Serie As String = ""
    Private m_iCantidad As Integer
    Private m_strTALLA As String
    Private m_MotivoDefectuoso As String
    Private m_ClaveConfirm As String
#End Region

#Region "Fields Accessors"

    Public Property Contrato()
        Get
            Return m_strContrato
        End Get
        Set(ByVal Value)
            m_strContrato = Value
        End Set
    End Property

    Public Property Matnr()
        Get
            Return m_strMatnr
        End Get
        Set(ByVal Value)
            m_strMatnr = Value
        End Set
    End Property

    Public Property Serie As String
        Get
            Return m_Serie
        End Get
        Set(ByVal value As String)
            m_Serie = value
        End Set
    End Property

    Public Property Cantidad()
        Get
            Return m_iCantidad
        End Get
        Set(ByVal Value)
            m_iCantidad = Value
        End Set
    End Property

    Public Property Talla()
        Get
            Return m_strTALLA
        End Get
        Set(ByVal Value)
            m_strTALLA = Value
        End Set
    End Property

    Public Property MotivoDefectuoso As String
        Get
            Return m_MotivoDefectuoso
        End Get
        Set(value As String)
            m_MotivoDefectuoso = value
        End Set
    End Property

    Public Property ClaveConfirm As String
        Get
            Return m_ClaveConfirm
        End Get
        Set(value As String)
            m_ClaveConfirm = value
        End Set
    End Property

#End Region

End Class

