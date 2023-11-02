Public Class CuponDescuento

    Private m_tableFormasDePago As DataTable
    Private m_datFechaVigencia As Date = Today
    Private m_strFolio As String = ""
    Private m_decLimiteDescuento As Decimal = 0
    Private m_decMaximo As Decimal = 0
    Private m_decMinimo As Decimal = 0
    Private m_decDescuento As Decimal = 0
    Private m_strTipoDescuento As String = ""
    Private m_strDescripcion As String = ""
    Private m_zcupones As New Hashtable

    Public Property InfoCupon() As Hashtable
        Get
            Return m_zcupones
        End Get
        Set(ByVal Value As Hashtable)
            m_zcupones = Value
        End Set
    End Property

    Public Property FormasPago() As DataTable
        Get
            Return m_tableFormasDePago
        End Get
        Set(ByVal Value As DataTable)
            m_tableFormasDePago = Value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return m_strDescripcion
        End Get
        Set(ByVal Value As String)
            m_strDescripcion = Value
        End Set
    End Property

    Public Property TipoDescuento() As String
        Get
            Return m_strTipoDescuento
        End Get
        Set(ByVal Value As String)
            m_strTipoDescuento = Value
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

    Public Property Minimo() As Decimal
        Get
            Return m_decMinimo
        End Get
        Set(ByVal Value As Decimal)
            m_decMinimo = Value
        End Set
    End Property

    Public Property Maximo() As Decimal
        Get
            Return m_decMaximo
        End Get
        Set(ByVal Value As Decimal)
            m_decMaximo = Value
        End Set
    End Property

    Public Property LimiteDescuento() As Decimal
        Get
            Return m_decLimiteDescuento
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteDescuento = Value
        End Set
    End Property

    Public Property Folio() As String
        Get
            Return m_strFolio
        End Get
        Set(ByVal Value As String)
            m_strFolio = Value
        End Set
    End Property

    Public Property FechaVigencia() As Date
        Get
            Return m_datFechaVigencia
        End Get
        Set(ByVal Value As Date)
            m_datFechaVigencia = Value
        End Set
    End Property

End Class
