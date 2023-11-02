Public Class ZBapiAbonoCierreDia
    Private m_strFecha As String

    Private m_stri_Mode As String

    Private m_stri_FactDpPro As String

    Private m_strBanco As String

    Private m_strClaCobr As String

    Private m_strRef_Banco As String

    Private m_strDetalle As String

    Private m_strvBeln As String

    Private m_strImporte As String

    Private m_strCliente As String

    Private m_strTienda As String

    Private m_HKONT As String

    Private m_Gsberg As String

    Private m_MotivoPedido As String

    Private m_Devolucion As Boolean

    Private m_Documents As DataTable

    Private m_FormasPago As DataTable

    Private m_NotasCredito As DataTable

    '---------------------------------------------------------------------
    ' JNAVA (15.03.2017): Variable para determinar si es de Si HAY
    '---------------------------------------------------------------------
    Private m_SiHay As Boolean

    Public Property Tienda() As String
        Get
            Return m_strTienda
        End Get
        Set(ByVal Value As String)
            m_strTienda = Value
        End Set
    End Property

    Public Property Cliente() As String
        Get
            Return m_strCliente
        End Get
        Set(ByVal Value As String)
            m_strCliente = Value
        End Set
    End Property

    Public Property Importe() As String
        Get
            Return m_strImporte
        End Get
        Set(ByVal Value As String)
            m_strImporte = Value
        End Set
    End Property

    Public Property vBeln() As String
        Get
            Return m_strvBeln
        End Get
        Set(ByVal Value As String)
            m_strvBeln = Value
        End Set
    End Property

    Public Property Detalle() As String
        Get
            Return m_strDetalle
        End Get
        Set(ByVal Value As String)
            m_strDetalle = Value
        End Set
    End Property

    Public Property Ref_Banco() As String
        Get
            Return m_strRef_Banco
        End Get
        Set(ByVal Value As String)
            m_strRef_Banco = Value
        End Set
    End Property

    Public Property ClaCobr() As String
        Get
            Return m_strClaCobr
        End Get
        Set(ByVal Value As String)
            m_strClaCobr = Value
        End Set
    End Property

    Public Property Banco() As String
        Get
            Return m_strBanco
        End Get
        Set(ByVal Value As String)
            m_strBanco = Value
        End Set
    End Property

    Public Property i_FactDpPro() As String
        Get
            Return m_stri_FactDpPro
        End Get
        Set(ByVal Value As String)
            m_stri_FactDpPro = Value
        End Set
    End Property

    Public Property i_Mode() As String
        Get
            Return m_stri_Mode
        End Get
        Set(ByVal Value As String)
            m_stri_Mode = Value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return m_strFecha
        End Get
        Set(ByVal Value As String)
            m_strFecha = Value
        End Set
    End Property

    Public Property HKONT As String
        Get
            Return m_HKONT
        End Get
        Set(value As String)
            m_HKONT = value
        End Set
    End Property

    Public Property Gsberg As String
        Get
            Return m_Gsberg
        End Get
        Set(value As String)
            m_Gsberg = value
        End Set
    End Property

    Public Property MotivoPedido As String
        Get
            Return m_MotivoPedido
        End Get
        Set(value As String)
            m_MotivoPedido = value
        End Set
    End Property

    Public Property Devolucion As Boolean
        Get
            Return m_Devolucion
        End Get
        Set(value As Boolean)
            m_Devolucion = value
        End Set
    End Property

    Public Property Documents As DataTable
        Get
            Return m_Documents
        End Get
        Set(value As DataTable)
            m_Documents = value
        End Set
    End Property

    Public Property FormasPago As DataTable
        Get
            Return m_FormasPago
        End Get
        Set(value As DataTable)
            m_FormasPago = value
        End Set
    End Property

    Public Property NotasCredito As DataTable
        Get
            Return m_NotasCredito
        End Get
        Set(value As DataTable)
            m_NotasCredito = value
        End Set
    End Property

    Public Property SiHay As Boolean
        Get
            Return m_SiHay
        End Get
        Set(value As Boolean)
            m_SiHay = value
        End Set
    End Property

    Public Sub New()
        m_Documents = New DataTable()
        m_Documents.Columns.Add("BSTNK", GetType(String))
        m_Documents.AcceptChanges()
        m_FormasPago = New DataTable()
        m_FormasPago.Columns.Add("FPAGOID", GetType(String))
        m_FormasPago.Columns.Add("TPAGO", GetType(String))
        m_FormasPago.Columns.Add("CLCOB", GetType(String))
        m_FormasPago.Columns.Add("BANCO", GetType(String))
        m_FormasPago.Columns.Add("REFBA", GetType(String))
        m_FormasPago.Columns.Add("MONTO", GetType(Decimal))
        m_FormasPago.Columns.Add("RCAJA", GetType(String))
        m_FormasPago.Columns.Add("COMPE", GetType(String))
        m_FormasPago.Columns.Add("PAGEN", GetType(String))
        '-----------------------------------------------------------------------
        'FLIZARRAGA 05/07/2017: Se valida si el vale de caja pertenece a si hay
        '-----------------------------------------------------------------------
        m_FormasPago.Columns.Add("SIHAY", GetType(String))
        '-----------------------------------------------------------------------
        ' JNAVA (11.11.2016): Agregamos el campo BSTNK = Referencia de Factura
        '-----------------------------------------------------------------------
        m_FormasPago.Columns.Add("BSTNK", GetType(String))
        '-----------------------------------------------------------------------
        m_FormasPago.AcceptChanges()
        m_NotasCredito = New DataTable()
        m_NotasCredito.Columns.Add("NOTACREDITOID", GetType(String))

        '---------------------------------------------------------------------
        ' JNAVA (15.03.2017): Variable para determinar si es de Si HAY en Falso
        '---------------------------------------------------------------------
        m_SiHay = False

    End Sub
End Class
