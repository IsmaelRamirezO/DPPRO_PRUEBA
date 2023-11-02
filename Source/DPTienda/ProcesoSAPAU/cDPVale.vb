Public Class cDPVale




#Region "Variables"

    Private strINUMVA As String = String.Empty
    Private strEEXIST As String = String.Empty
    Private strESTATU As String = String.Empty
    Private strEPLAZA As String = String.Empty
    Private strI_RUTA As String = String.Empty
    Private strBorrar As String = String.Empty
    Private decLimiteCredito As Decimal = 0
    Private dtInfoDPVALE As DataTable
    Private m_strCongelado As String = String.Empty
    Private m_decLimiteCreditoPrestamo As Decimal = 0
    Private m_strEstatusPrestamo As String = String.Empty
    '---------------------------------------------------------------------
    'FLIZARRAGA 18/09/2017: Configuracion de Vale Electronico
    '---------------------------------------------------------------------
    Private m_MontoElectronico As Decimal = 0
    Private m_EsElectronico As Boolean = False
    Private m_EsCalzado As Boolean = False
    Private m_PromocionValeElectronico As Integer

#End Region

#Region "Fields Accessors"

    Public Property I_RUTA() As String
        Get
            Return strI_RUTA
        End Get
        Set(ByVal Value As String)
            strI_RUTA = Value
        End Set
    End Property

    Public Property BORRAR() As String
        Get
            Return strBorrar
        End Get
        Set(ByVal Value As String)
            strBorrar = Value
        End Set
    End Property

    Public Property LimiteCredito() As Decimal
        Get
            Return decLimiteCredito
        End Get
        Set(ByVal Value As Decimal)
            decLimiteCredito = Value
        End Set
    End Property

    Public Property EPLAZA() As String
        Get
            Return strEPLAZA
        End Get
        Set(ByVal Value As String)
            strEPLAZA = Value
        End Set
    End Property

    Public Property EEXIST() As String
        Get
            Return strEEXIST
        End Get
        Set(ByVal Value As String)
            strEEXIST = Value
        End Set
    End Property

    Public Property ESTATU() As String
        Get
            Return strESTATU
        End Get
        Set(ByVal Value As String)
            strESTATU = Value
        End Set
    End Property

    Public Property INUMVA() As String
        Get
            Return strINUMVA
        End Get
        Set(ByVal Value As String)
            strINUMVA = Value
        End Set
    End Property

    Public Property InfoDPVALE() As DataTable
        Get
            Return dtInfoDPVALE
        End Get
        Set(ByVal Value As DataTable)
            dtInfoDPVALE = Value
        End Set
    End Property

    Public Property Congelado() As String
        Get
            Return m_strCongelado
        End Get
        Set(ByVal Value As String)
            m_strCongelado = Value
        End Set
    End Property

    Public Property LimiteCreditoPrestamo() As Decimal
        Get
            Return m_decLimiteCreditoPrestamo
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCreditoPrestamo = Value
        End Set
    End Property

    Public Property FlagPrestamo() As String
        Get
            Return m_strEstatusPrestamo
        End Get
        Set(ByVal Value As String)
            m_strEstatusPrestamo = Value
        End Set
    End Property

    Public Property EsElectronico As Boolean
        Get
            Return m_EsElectronico
        End Get
        Set(ByVal value As Boolean)
            m_EsElectronico = value
        End Set
    End Property

    Public Property MontoElectronico As Decimal
        Get
            Return m_MontoElectronico
        End Get
        Set(ByVal value As Decimal)
            m_MontoElectronico = value
        End Set
    End Property

    Public Property EsCalzado As Boolean
        Get
            Return m_EsCalzado
        End Get
        Set(ByVal value As Boolean)
            m_EsCalzado = value
        End Set
    End Property

    Public Property PromocionValeElectronico As Integer
        Get
            Return m_PromocionValeElectronico
        End Get
        Set(ByVal value As Integer)
            m_PromocionValeElectronico = value
        End Set
    End Property

    

#End Region

End Class

