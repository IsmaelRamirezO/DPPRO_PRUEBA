Public Class VentasFacturaSAP

#Region "Object construction/destruction"

    Public Sub New()

        MyBase.New()

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub

    Public Sub Dispose()

        Me.Finalize()

    End Sub

#End Region '(Object construction/destruction)

#Region "Fields"

    Private m_strFolSeg As String = ""
    Private m_decImpSeg As Decimal = 0
    Private m_strDPValeID As String = ""
    Private m_datFechaCobroDPVL As Date = Nothing
    Private m_strClasePedido As String
    Private m_strOficinaVentas As String
    Private m_strVendedor As String
    Private m_strCentro As String
    Private m_strCredito As String = "N"
    Private m_strCodigoCliente As String
    Private m_strZonaVenta As String
    Private m_objDetalle As DataTable
    Private m_strFolioFISAP As String
    Private m_strFolioSAP As String
    Private m_strNombreBAPI As String
    Private m_strTipoVenta As String
    Private m_strNumeroValeCaja As String
    Private m_decMontoDPVale As Decimal
    Private m_strClienteDistribuidor As String
    Private m_dtFechaMovimiento As Date
    Private m_strFacturaDP As String

    Private m_intNUMDE As Integer = 0                   '--Numero de Quincenas
    Private m_intPARES_PZAS As Integer = 0              '--Numero de Pares Piezas
    Private m_decMONTOUTILIZADO As Decimal = 0          '--Monto Utilizado
    Private m_bolREVALE As Boolean = False        '--TRUE si se ocupa Revale FALSE si no se necesita
    Private m_strRPARES_PZAS As Integer = 0             '--Pares Piezas de Revale
    Private m_strRMONTODPVALE As Decimal = 0            '--Monto de Revale
    Private m_strFOLIOREVALE As String = String.Empty        '--Numero de REVALE GENERADO


    Private m_strFechaApartado As String

    '------------------------------------------------------
    'JNAVA (06.02.2015): Seguros DPVale en Ventas
    '------------------------------------------------------
    Private m_bolSeguro As Boolean = False

    '------------------------------------------------------
    'JNAVA (09.06.2015): Division Plaza 
    '------------------------------------------------------
    Private m_strDivP As String

    '-----------------------------------------------------------------------------------------------
    ' JNAVA (02.07.2015): Motivo De No Generarse Seguro
    '-----------------------------------------------------------------------------------------------
    Private m_strRechazoSeguro As String

    '-----------------------------------------------------------------------------------------------
    'FLIZARRAGA 10/11/2015: I_ZSEG Validacion para seguro DPVL
    '-----------------------------------------------------------------------------------------------
    Private m_ZSEG As String

    Public Property FechaApartado() As String
        Get
            Return m_strFechaApartado
        End Get
        Set(ByVal Value As String)
            m_strFechaApartado = Value
        End Set
    End Property

    Public Property FOLIOREVALE() As String
        Get
            Return m_strFOLIOREVALE
        End Get
        Set(ByVal Value As String)
            m_strFOLIOREVALE = Value
        End Set
    End Property

    Public Property RMONTODPVALE() As String
        Get
            Return m_strRMONTODPVALE

        End Get
        Set(ByVal Value As String)
            m_strRMONTODPVALE = Value
        End Set
    End Property

    Public Property RPARES_PZAS() As Integer
        Get
            Return m_strRPARES_PZAS
        End Get
        Set(ByVal Value As Integer)
            m_strRPARES_PZAS = Value
        End Set
    End Property

    Public Property REVALE() As Boolean
        Get
            Return m_bolREVALE
        End Get
        Set(ByVal Value As Boolean)
            m_bolREVALE = Value
        End Set
    End Property

    Public Property MONTOUTILIZADO() As Decimal
        Get
            Return m_decMONTOUTILIZADO
        End Get
        Set(ByVal Value As Decimal)
            m_decMONTOUTILIZADO = Value
        End Set
    End Property

    Public Property PARES_PZAS() As Integer
        Get
            Return m_intPARES_PZAS
        End Get
        Set(ByVal Value As Integer)
            m_intPARES_PZAS = Value
        End Set
    End Property

    Public Property NUMDE() As Integer
        Get
            Return m_intNUMDE
        End Get
        Set(ByVal Value As Integer)
            m_intNUMDE = Value
        End Set
    End Property


    Public Property FacturaDP() As String
        Get
            Return m_strFacturaDP
        End Get
        Set(ByVal Value As String)
            m_strFacturaDP = Value
        End Set
    End Property

    Public Property FechaMovimiento() As Date
        Get
            Return m_dtFechaMovimiento
        End Get
        Set(ByVal Value As Date)
            m_dtFechaMovimiento = Value
        End Set
    End Property


    Public Property ClasePedido() As String
        Get
            Return m_strClasePedido
        End Get
        Set(ByVal Value As String)
            m_strClasePedido = Value
        End Set
    End Property

    Public Property OficinaVentas() As String
        Get
            Return m_strOficinaVentas
        End Get
        Set(ByVal Value As String)
            m_strOficinaVentas = Value
        End Set
    End Property

    Public Property Vendedor() As String
        Get
            Return m_strVendedor
        End Get
        Set(ByVal Value As String)
            m_strVendedor = Value
        End Set
    End Property

    Public Property Centro() As String
        Get
            Return m_strCentro
        End Get
        Set(ByVal Value As String)
            m_strCentro = Value
        End Set
    End Property

    Public Property Credito() As String
        Get
            Return m_strCredito
        End Get
        Set(ByVal Value As String)
            m_strCredito = Value
        End Set
    End Property

    Public Property CodigoCliente() As String
        Get
            Return m_strCodigoCliente
        End Get
        Set(ByVal Value As String)
            m_strCodigoCliente = Value
        End Set
    End Property

    Public Property ZonaVenta() As String
        Get
            Return m_strZonaVenta
        End Get
        Set(ByVal Value As String)
            m_strZonaVenta = Value
        End Set
    End Property

    Public Property Detalle() As DataTable
        Get
            Return m_objDetalle
        End Get
        Set(ByVal Value As DataTable)
            m_objDetalle = Value
        End Set
    End Property

    Public Property FolioSAP() As String
        Get
            Return m_strFolioSAP
        End Get
        Set(ByVal Value As String)
            m_strFolioSAP = Value
        End Set
    End Property

    Public Property FolioFISAP() As String
        Get
            Return m_strFolioFISAP
        End Get
        Set(ByVal Value As String)
            m_strFolioFISAP = Value
        End Set
    End Property

    Public Property NombreBAPI() As String
        Get
            Return m_strNombreBAPI
        End Get
        Set(ByVal Value As String)
            m_strNombreBAPI = Value
        End Set
    End Property

    Public Property TipoVenta() As String
        Get
            Return m_strTipoVenta
        End Get
        Set(ByVal Value As String)
            m_strTipoVenta = Value
        End Set
    End Property

    Public Property NumeroVale() As String
        Get
            Return m_strNumeroValeCaja
        End Get
        Set(ByVal Value As String)
            m_strNumeroValeCaja = Value
        End Set
    End Property

    Public Property MontoDPVale() As Decimal
        Get
            Return m_decMontoDPVale
        End Get
        Set(ByVal Value As Decimal)
            m_decMontoDPVale = Value
        End Set
    End Property

    Public Property ClienteDistribuidor() As String
        Get
            Return m_strClienteDistribuidor
        End Get
        Set(ByVal Value As String)
            m_strClienteDistribuidor = Value
        End Set
    End Property

    Public Property FechaCobroDPVL() As Date
        Get
            Return m_datFechaCobroDPVL
        End Get
        Set(ByVal Value As Date)
            m_datFechaCobroDPVL = Value
        End Set
    End Property

    Public Property DPValeVentaID() As String
        Get
            Return m_strDPValeID
        End Get
        Set(ByVal Value As String)
            m_strDPValeID = Value
        End Set
    End Property

    Public Property SeguroDPVL() As Boolean
        Get
            Return m_bolSeguro
        End Get
        Set(ByVal Value As Boolean)
            m_bolSeguro = Value
        End Set
    End Property

    Public Property ImpSegDPVL() As Decimal
        Get
            Return m_decImpSeg
        End Get
        Set(ByVal Value As Decimal)
            m_decImpSeg = Value
        End Set
    End Property

    Public Property FolSegDPVL() As String
        Get
            Return m_strFolSeg
        End Get
        Set(ByVal Value As String)
            m_strFolSeg = Value
        End Set
    End Property


    Public Property DivPDPVL() As String
        Get
            Return m_strDivP
        End Get
        Set(ByVal Value As String)
            m_strDivP = Value
        End Set
    End Property

    Public Property RechazoSeguro() As String
        Get
            Return m_strRechazoSeguro
        End Get
        Set(ByVal Value As String)
            m_strRechazoSeguro = Value
        End Set
    End Property

    Public Property ZSEG() As String
        Get
            Return m_ZSEG
        End Get
        Set(ByVal Value As String)
            m_ZSEG = Value
        End Set
    End Property

#End Region

#Region "S2Credit"

#Region "Variables"

    '------------------------------------------------------------
    ' JNAVA (04.04.2017): ID de la Promocion en S2Credit
    '------------------------------------------------------------
    Dim strPromocionID As String = String.Empty
    '------------------------------------------------------------

#End Region

#Region "Propiedades"

    Public Property PromocionID() As String
        Get
            Return strPromocionID
        End Get
        Set(ByVal Value As String)
            strPromocionID = Value
        End Set
    End Property

#End Region

#End Region


#Region "Methods"

    Private Sub ClearFields()

        m_strDPValeID = ""
        m_strClasePedido = String.Empty
        m_strOficinaVentas = String.Empty
        m_strVendedor = String.Empty
        m_strCentro = String.Empty
        m_strCredito = String.Empty
        m_strCodigoCliente = String.Empty
        m_strZonaVenta = String.Empty
        m_strFolioFISAP = String.Empty
        m_strFolioSAP = String.Empty
        m_strNombreBAPI = String.Empty
        m_strTipoVenta = String.Empty
        m_strNumeroValeCaja = String.Empty
        m_decMontoDPVale = 0
        m_strClienteDistribuidor = String.Empty
        m_strFacturaDP = String.Empty

        m_objDetalle = Nothing
        m_objDetalle = New DataTable

        m_intNUMDE = 0
        m_intPARES_PZAS = 0
        m_decMONTOUTILIZADO = 0
        m_bolREVALE = False
        m_strRPARES_PZAS = 0
        m_strRMONTODPVALE = 0
        m_strFOLIOREVALE = String.Empty

        m_bolSeguro = False

        m_strRechazoSeguro = String.Empty

    End Sub

#End Region

End Class
