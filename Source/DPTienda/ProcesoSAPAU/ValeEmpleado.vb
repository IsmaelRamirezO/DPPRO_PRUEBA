Public Class ValeEmpleado

    Private m_bEsRevale As Boolean = False
    Private m_intFolio As Integer = 0
    Private m_strSerie As String = ""
    Private m_decDescuento As Decimal = 0
    Private m_datFechaVig As Date = Date.Today
    Private m_strStatus As String = ""

    Public Property Folio() As Integer
        Get
            Return m_intFolio
        End Get
        Set(ByVal Value As Integer)
            m_intFolio = Value
        End Set
    End Property

    Public Property Serie() As String
        Get
            Return m_strSerie
        End Get
        Set(ByVal Value As String)
            m_strSerie = Value
        End Set
    End Property

    Public Property Descuento() As Decimal
        Get
            Return m_decDescuento
        End Get
        Set(ByVal Value As Decimal)
            m_decDescuento = Value
        End Set
    End Property

    Public Property FechaFinVigencia() As Date
        Get
            Return m_datFechaVig
        End Get
        Set(ByVal Value As Date)
            m_datFechaVig = Value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return m_strStatus
        End Get
        Set(ByVal Value As String)
            m_strStatus = Value
        End Set
    End Property

    Public Property EsRevale() As Boolean
        Get
            Return m_bEsRevale
        End Get
        Set(ByVal Value As Boolean)
            m_bEsRevale = Value
        End Set
    End Property

End Class
