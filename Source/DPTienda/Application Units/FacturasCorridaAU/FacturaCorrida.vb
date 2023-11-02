
Public Class FacturaCorrida

    Private oParent As FacturaCorridaManager

#Region "Fields"

#Region "Fields Data Storage"

    Private m_intCorridaFacturaID As Integer
    Private m_strCorridaCodArticulo As String
    Private m_decCorridaCantidad As Decimal
    Private m_decCorridaNumero As String
    Private m_decCorridaCostoUnitario As Decimal
    Private m_decCorridaPrecioUnitario As Decimal
    Private m_decCorridaPrecioOferta As Decimal
    Private m_decCorridaTotal As Decimal
    Private m_strCorridaCodTipoDescuento As String
    Private m_decCorridaDescuento As Decimal
    Private m_decCorridaDescuentoSistema As Decimal
    Private m_decCorridaCantDescuentoSistema As Decimal
    Private m_bCorridaDip As Boolean
    Private m_strCorridaUsuario As String
    Private m_datCorridaFecha As Date
    Private m_bCorridaStatusRegistro As Boolean

    Private oMovimiento As New FacturaCorridaMovimiento

    '---------------------------------------------------------
    'JNAVA (05.12.2014): Venta de Electronicos
    '---------------------------------------------------------
    Private m_strNumeroSerie As String
    Private m_strIMEI As String

#End Region

#Region "Fields Accessors"

    Public Property Movimiento() As FacturaCorridaMovimiento
        Get
            Return oMovimiento
        End Get
        Set(ByVal Value As FacturaCorridaMovimiento)
            oMovimiento = Value
        End Set
    End Property

    Public Property FacturaID() As Integer
        Get
            Return m_intCorridaFacturaID
        End Get
        Set(ByVal Value As Integer)
            m_intCorridaFacturaID = Value
        End Set
    End Property

    Public Property CodArticulo() As String
        Get
            Return m_strCorridaCodArticulo
        End Get
        Set(ByVal Value As String)
            m_strCorridaCodArticulo = Value
        End Set
    End Property

    Public Property Cantidad() As Decimal
        Get
            Return m_decCorridaCantidad
        End Get
        Set(ByVal Value As Decimal)
            m_decCorridaCantidad = Value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return m_decCorridaNumero
        End Get
        Set(ByVal Value As String)
            m_decCorridaNumero = Value
        End Set
    End Property

    Public Property CostoUnitario() As Decimal
        Get
            Return m_decCorridaCostoUnitario
        End Get
        Set(ByVal Value As Decimal)
            m_decCorridaCostoUnitario = Value
        End Set
    End Property

    Public Property PrecioUnitario() As Decimal
        Get
            Return m_decCorridaPrecioUnitario
        End Get
        Set(ByVal Value As Decimal)
            m_decCorridaPrecioUnitario = Value
        End Set
    End Property

    Public Property PrecioOferta() As Decimal
        Get
            Return m_decCorridaPrecioOferta
        End Get
        Set(ByVal Value As Decimal)
            m_decCorridaPrecioOferta = Value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return m_decCorridaTotal
        End Get
        Set(ByVal Value As Decimal)
            m_decCorridaTotal = Value
        End Set
    End Property

    Public Property CodTipoDescuento() As String
        Get
            Return m_strCorridaCodTipoDescuento
        End Get
        Set(ByVal Value As String)
            m_strCorridaCodTipoDescuento = Value
        End Set
    End Property

    Public Property Descuento() As Decimal
        Get
            Return m_decCorridaDescuento
        End Get
        Set(ByVal Value As Decimal)
            m_decCorridaDescuento = Value
        End Set
    End Property

    Public Property DescuentoSistema() As Decimal
        Get
            Return m_decCorridaDescuentoSistema
        End Get
        Set(ByVal Value As Decimal)
            m_decCorridaDescuentoSistema = Value
        End Set
    End Property

    Public Property CantDescuentoSistema() As Decimal
        Get
            Return m_decCorridaCantDescuentoSistema
        End Get
        Set(ByVal Value As Decimal)
            m_decCorridaCantDescuentoSistema = Value
        End Set
    End Property

    Public Property Dip() As Boolean
        Get
            Return m_bCorridaDip
        End Get
        Set(ByVal Value As Boolean)
            m_bCorridaDip = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_strCorridaUsuario
        End Get
        Set(ByVal Value As String)
            m_strCorridaUsuario = Value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return m_datCorridaFecha
        End Get
        Set(ByVal Value As Date)
            m_datCorridaFecha = Value
        End Set
    End Property

    Public Property StatusRegistro() As Boolean
        Get
            Return m_bCorridaStatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bCorridaStatusRegistro = Value
        End Set
    End Property

    Public Property NumeroSerie() As String
        Get
            Return m_strNumeroSerie
        End Get
        Set(ByVal Value As String)
            m_strNumeroSerie = Value
        End Set
    End Property


    Public Property IMEI() As String
        Get
            Return m_strIMEI
        End Get
        Set(ByVal Value As String)
            m_strIMEI = Value
        End Set
    End Property

#End Region

#End Region

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As FacturaCorridaManager)

        MyBase.New()

        oParent = Parent

        Clearfields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Sub Clearfields()

        m_intCorridaFacturaID = 0
        m_strCorridaCodArticulo = String.Empty
        m_decCorridaCantidad = 0
        m_decCorridaNumero = 0
        m_decCorridaCostoUnitario = 0
        m_decCorridaPrecioUnitario = 0
        m_decCorridaPrecioOferta = 0
        m_decCorridaTotal = 0
        m_strCorridaCodTipoDescuento = String.Empty
        m_decCorridaDescuento = 0
        m_decCorridaDescuentoSistema = 0
        m_decCorridaCantDescuentoSistema = 0
        m_bCorridaDip = 0
        m_strCorridaUsuario = String.Empty
        m_datCorridaFecha = Date.Today
        m_bCorridaStatusRegistro = 1

        m_strNumeroSerie = String.Empty
        m_strIMEI = String.Empty

    End Sub

#End Region

End Class
