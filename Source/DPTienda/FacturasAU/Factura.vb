
Public Class Factura

    Private m_bSeguroVidaDPVL As Boolean = False
    Private m_datdtMotivos As DataTable
    Private m_strNquincenas As Integer
    Private m_strFCancelacionFI As String
    Private m_strFCancelacionSD As String
    Private oParent As FacturaManager
    Private m_strFechaApartado As String
    Private m_SerialId As String
    Private m_MotivoPedido As String
    Private m_Referencia As String
    Private m_TipoCliente As String

    '--------------------------------------------------------------------
    ' JNAVA (15.09.2016): Obtiene el ID de la Venta en S2Credit
    '--------------------------------------------------------------------
    Private m_VentaS2CreditID As String = String.Empty

    Public Property FechaApartado() As String
        Get
            Return m_strFechaApartado
        End Get
        Set(ByVal Value As String)
            m_strFechaApartado = Value
        End Set
    End Property


#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As FacturaManager)

        MyBase.New()

        oParent = Parent

        ClearFields()

    End Sub


    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Fields"

#Region "Fields Data Storage"

    Private m_intFacturaID As Integer
    Private m_strCodAlmacen As String
    Private m_strCodCaja As String
    Private m_intFolioFactura As Integer
    Private m_intApartadoID As Integer
    Private m_intNotaCreditoID As Integer
    Private m_strStatusFactura As String
    Private m_strCodTipoVenta As String
    Private m_intClienteId As Integer
    Private m_strCodVendedor As String
    Private m_decDescTotal As Decimal
    Private m_decSubTotal As Decimal
    Private m_decIVA As Decimal
    Private m_decTotal As Decimal
    Private m_bImpresa As Boolean
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bStatusRegistro As Boolean
    Private m_strNumeroFacilito As String
    Private dsDetalle As DataSet
    Private dsFormaPago As DataSet
    Private m_strFolioSAP As String
    Private m_strFolioFISAP As String
    Private m_decDPesos As Decimal
    Private m_decSaldo As Decimal
    Private m_strRevale As String
    Private m_intFolioNotaVentaManual As Integer
    Private m_intClientePGID As Integer
    Private m_strRazonRechazo As String = ""
    Private m_strCodPlaza As String = ""
    Private m_intRazonRechazoID As Integer = 0
#Region "Facturacion SiHay"
    Private m_PedidoID As Integer = 0
    Private m_EdicionPedido As Boolean = False
    Private m_ExistenciaApartado As Decimal = 0
#End Region

#Region "DPCardPuntos"
    Private m_NoDPCardPuntos As String
    Private m_CodDPCardPunto As String
#End Region

#End Region

#Region "Fields Change Notificators"

    Public Event FacturaIDChanged As EventHandler
    Public Event CodCajaChanged As EventHandler
    Public Event CodAlmacenChanged As EventHandler
    Public Event FolioFacturaChanged As EventHandler
    Public Event ApartadoIDChanged As EventHandler
    Public Event NotaCreditoIDChanged As EventHandler
    Public Event StatusFacturaChanged As EventHandler
    Public Event CodTipoVentaChanged As EventHandler
    Public Event ClienteIdChanged As EventHandler
    Public Event CodVendedorChanged As EventHandler
    Public Event DescTotalChanged As EventHandler
    Public Event SubTotalChanged As EventHandler
    Public Event IVAChanged As EventHandler
    Public Event TotalChanged As EventHandler
    Public Event ImpresaChanged As EventHandler
    Public Event UsuarioChanged As EventHandler
    Public Event FechaChanged As EventHandler
    Public Event StatusRegistroChanged As EventHandler
    Public Event NumeroFacilitoChanged As EventHandler
    Public Event FolioSAPChanged As EventHandler
    Public Event FolioFISAPChanged As EventHandler
    Public Event DpesosChanged As EventHandler
    Public Event SaldoChanged As EventHandler
    Public Event FolioNotaVentaManualChanged As EventHandler

#End Region

#Region "Fields Accessors"

    Public Property Referencia As String
        Get
            Return m_Referencia
        End Get
        Set(value As String)
            m_Referencia = value
        End Set
    End Property

    Public Property RazonRechazoID() As Integer
        Get
            Return m_intRazonRechazoID
        End Get
        Set(ByVal Value As Integer)
            m_intRazonRechazoID = Value
        End Set
    End Property

    Public Property CodPlaza() As String
        Get
            Return m_strCodPlaza
        End Get
        Set(ByVal Value As String)
            m_strCodPlaza = Value
        End Set
    End Property

    Public Property RazonRechazo() As String
        Get
            Return m_strRazonRechazo
        End Get
        Set(ByVal Value As String)
            m_strRazonRechazo = Value
        End Set
    End Property

    Public Property ClientPGID() As Integer
        Get
            Return m_intClientePGID
        End Get
        Set(ByVal Value As Integer)
            m_intClientePGID = Value
        End Set
    End Property

    Public Property REVALE() As String
        Get
            Return m_strRevale
        End Get
        Set(ByVal Value As String)
            m_strRevale = Value
        End Set
    End Property

    Public Property StatusRegistro() As Boolean
        Get
            Return m_bStatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStatusRegistro = Value
            RaiseEvent StatusRegistroChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return m_datFecha
        End Get
        Set(ByVal Value As Date)
            m_datFecha = Value
            RaiseEvent FechaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
            RaiseEvent UsuarioChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Impresa() As Boolean
        Get
            Return m_bImpresa
        End Get
        Set(ByVal Value As Boolean)
            m_bImpresa = Value
            RaiseEvent ImpresaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return m_decTotal
        End Get
        Set(ByVal Value As Decimal)
            m_decTotal = Value
            RaiseEvent TotalChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property IVA() As Decimal
        Get
            Return m_decIVA
        End Get
        Set(ByVal Value As Decimal)
            m_decIVA = Value
            RaiseEvent IVAChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property SubTotal() As Decimal
        Get
            Return m_decSubTotal
        End Get
        Set(ByVal Value As Decimal)
            m_decSubTotal = Value
            RaiseEvent SubTotalChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DescTotal() As Decimal
        Get
            Return m_decDescTotal
        End Get
        Set(ByVal Value As Decimal)
            m_decDescTotal = Value
            RaiseEvent DescTotalChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodVendedor() As String
        Get
            Return m_strCodVendedor
        End Get
        Set(ByVal Value As String)
            m_strCodVendedor = Value
            RaiseEvent CodVendedorChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ClienteId() As Integer
        Get
            Return m_intClienteId
        End Get
        Set(ByVal Value As Integer)
            m_intClienteId = Value
            RaiseEvent ClienteIdChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodTipoVenta() As String
        Get
            Return m_strCodTipoVenta
        End Get
        Set(ByVal Value As String)
            m_strCodTipoVenta = Value
            RaiseEvent CodTipoVentaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property StatusFactura() As String
        Get
            Return m_strStatusFactura
        End Get
        Set(ByVal Value As String)
            m_strStatusFactura = Value
            RaiseEvent StatusFacturaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property NotaCreditoID() As Integer
        Get
            Return m_intNotaCreditoID
        End Get
        Set(ByVal Value As Integer)
            m_intNotaCreditoID = Value
            RaiseEvent NotaCreditoIDChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ApartadoID() As Integer
        Get
            Return m_intApartadoID
        End Get
        Set(ByVal Value As Integer)
            m_intApartadoID = Value
            RaiseEvent ApartadoIDChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FolioFactura() As Integer
        Get
            Return m_intFolioFactura
        End Get
        Set(ByVal Value As Integer)
            m_intFolioFactura = Value
            RaiseEvent FolioFacturaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
            RaiseEvent CodAlmacenChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodCaja() As String
        Get
            Return m_strCodCaja
        End Get
        Set(ByVal Value As String)
            m_strCodCaja = Value
            RaiseEvent CodCajaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FacturaID() As Integer
        Get
            Return m_intFacturaID
        End Get
        Set(ByVal Value As Integer)
            m_intFacturaID = Value
            RaiseEvent FacturaIDChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Detalle() As DataSet
        Get
            Return dsDetalle
        End Get
        Set(ByVal Value As DataSet)
            dsDetalle = Value
        End Set
    End Property

    Public Property FormasPago() As DataSet
        Get
            Return dsFormaPago
        End Get
        Set(ByVal Value As DataSet)
            dsFormaPago = Value
        End Set
    End Property

    Public Property NumeroFacilito() As String
        Get
            Return m_strNumeroFacilito
        End Get
        Set(ByVal Value As String)
            m_strNumeroFacilito = Value
            RaiseEvent NumeroFacilitoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FolioSAP() As String
        Get
            Return m_strFolioSAP
        End Get
        Set(ByVal Value As String)
            m_strFolioSAP = Value
            RaiseEvent FolioSAPChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FolioFISAP() As String
        Get
            Return m_strFolioFISAP
        End Get
        Set(ByVal Value As String)
            m_strFolioFISAP = Value
            RaiseEvent FolioFISAPChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DPesos() As Decimal
        Get
            Return m_decDPesos
        End Get
        Set(ByVal Value As Decimal)
            m_decDPesos = Value
            RaiseEvent DpesosChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Saldo() As Decimal
        Get
            Return m_decSaldo
        End Get
        Set(ByVal Value As Decimal)
            m_decSaldo = Value
            RaiseEvent SaldoChanged(Me, EventArgs.Empty)
        End Set
    End Property
    Public Property FolioNotaVentaManual() As Integer
        Get
            Return m_intFolioNotaVentaManual
        End Get
        Set(ByVal Value As Integer)
            m_intFolioNotaVentaManual = Value
            RaiseEvent FolioFacturaChanged(Me, EventArgs.Empty)
        End Set
    End Property

#End Region

#End Region

#Region "Object Status Flags"

    Private bolIsDirty As Boolean
    Private bolIsNew As Boolean

    Public Function IsDirty() As Boolean
        Return bolIsDirty
    End Function

    Public Function IsNew() As Boolean
        Return bolIsNew
    End Function

    Friend Sub SetFlagDirty()
        bolIsDirty = True
    End Sub

    Friend Sub SetFlagNew()
        bolIsNew = True
    End Sub

    Public Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Public Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Record Information"

    Public _strRecordCreatedBy As String
    Public _datRecordCreatedOn As Date
    Public _bolRecordEnabled As Boolean

    Public Event RecordCreatedByChanged As EventHandler
    Public Event RecordCreatedOnChanged As EventHandler
    Public Event RecordEnabledChanged As EventHandler

    Public Property RecordCreatedBy() As String
        Get
            Return _strRecordCreatedBy
        End Get
        Set(ByVal Value As String)
            _strRecordCreatedBy = Value
            RaiseEvent RecordCreatedByChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property RecordCreatedOn() As Date
        Get
            Return _datRecordCreatedOn
        End Get
        Set(ByVal Value As Date)
            _datRecordCreatedOn = Value
            RaiseEvent RecordCreatedOnChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property RecordEnabled() As Boolean
        Get
            Return _bolRecordEnabled
        End Get
        Set(ByVal Value As Boolean)
            _bolRecordEnabled = Value
            RaiseEvent RecordEnabledChanged(Me, EventArgs.Empty)
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub ClearFields()

        m_intFacturaID = 0
        m_strCodCaja = oParent.ApplicationContext.ApplicationConfiguration.NoCaja
        m_strCodAlmacen = oParent.ApplicationContext.ApplicationConfiguration.Almacen
        m_intFolioFactura = 0
        m_intApartadoID = 0
        m_intNotaCreditoID = 0
        m_strStatusFactura = String.Empty
        m_strCodTipoVenta = String.Empty
        m_intClienteId = 0
        m_strCodVendedor = String.Empty
        m_decDescTotal = 0
        m_decSubTotal = 0
        m_decIVA = 0
        m_decTotal = 0
        m_bImpresa = False
        m_strUsuario = String.Empty
        m_datFecha = Date.Today
        m_bStatusRegistro = True
        m_strFolioSAP = String.Empty
        m_strFolioFISAP = String.Empty
        m_decDPesos = 0
        m_intClientePGID = 0
        m_strRazonRechazo = ""
        m_intRazonRechazoID = 0
        m_strCodPlaza = ""

        'FolioNotaVentaManual
        m_intFolioNotaVentaManual = 0

        '----------------------------------------------------
        ' JNAVA(15.09.2016): ID de Venta en S2Credit
        '----------------------------------------------------
        m_VentaS2CreditID = String.Empty
        '----------------------------------------------------

        'Extended Fields
        m_decFacturaArticuloTallaAl = 0
        m_decFacturaArticuloTallaDel = 0
        m_decFacturaArticuloExistencia = 0

        m_strNumeroFacilito = String.Empty

        'Detalle
        dsDetalle = Nothing
        dsDetalle = New DataSet

        'Formas Pago
        dsFormaPago = Nothing
        dsFormaPago = New DataSet

        'dtMotivos
        m_datdtMotivos = Nothing
        m_datdtMotivos = New DataTable

        CreateDtMotivos()


        Me.SetFlagNew()
        Me.ResetFlagDirty()

    End Sub
    Private Sub CreateDtMotivos()

        Dim dCol As DataColumn
        Dim dRow As DataRow

        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "FolioFactura"
        dCol.Caption = "FolioFactura"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 10
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "Tienda"
        dCol.Caption = "Tienda"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 3
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "Articulo"
        dCol.Caption = "Articulo"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 30
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(String)
        dCol.ColumnName = "Talla"
        dCol.Caption = "Talla"
        dCol.DefaultValue = ""
        dCol.AllowDBNull = False
        dCol.MaxLength = 10
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(Integer)
        dCol.ColumnName = "IdMotivo"
        dCol.Caption = "IdMotivo"
        dCol.DefaultValue = 0
        dCol.AllowDBNull = False
        m_datdtMotivos.Columns.Add(dCol)

        dCol = Nothing
        dCol = New DataColumn
        dCol.DataType = GetType(Date)
        dCol.ColumnName = "Fecha"
        dCol.Caption = "Fecha"
        dCol.DefaultValue = Now.Date.ToShortDateString
        dCol.AllowDBNull = False
        m_datdtMotivos.Columns.Add(dCol)

        m_datdtMotivos.AcceptChanges()

    End Sub

#End Region

#Region "Extended Fields"

    Private m_decFacturaArticuloTallaAl As Decimal
    Private m_decFacturaArticuloTallaDel As Decimal
    Private m_decFacturaArticuloExistencia As Decimal

    Public Event FacturaArticuloTallaAlChanged As EventHandler
    Public Event FacturaArticuloTallaDelChanged As EventHandler
    Public Event FacturaArticuloExistenciaChanged As EventHandler


    Public Property FacturaArticuloTallaDel() As Decimal
        Get
            Return m_decFacturaArticuloTallaDel
        End Get
        Set(ByVal Value As Decimal)
            m_decFacturaArticuloTallaDel = Value
            RaiseEvent FacturaArticuloTallaDelChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FacturaArticuloTallaAl() As Decimal
        Get
            Return m_decFacturaArticuloTallaAl
        End Get
        Set(ByVal Value As Decimal)
            m_decFacturaArticuloTallaAl = Value
            RaiseEvent FacturaArticuloTallaAlChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FacturaArticuloExistencia() As Decimal
        Get
            Return m_decFacturaArticuloExistencia
        End Get
        Set(ByVal Value As Decimal)
            m_decFacturaArticuloExistencia = Value
            RaiseEvent FacturaArticuloExistenciaChanged(Me, EventArgs.Empty)
        End Set
    End Property

#End Region

#Region "Propiedades"

    Public Property VentaS2CreditID As String
        Get
            Return m_VentaS2CreditID
        End Get
        Set(ByVal Value As String)
            m_VentaS2CreditID = Value
        End Set
    End Property

    Public Property SerialId As String
        Get
            Return m_SerialId
        End Get
        Set(value As String)
            m_SerialId = value
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

    Public Property TipoCliente As String
        Get
            Return m_TipoCliente
        End Get
        Set(value As String)
            m_TipoCliente = value
        End Set
    End Property

    Public Property FCancelacionSD() As String
        Get
            Return m_strFCancelacionSD
        End Get
        Set(ByVal Value As String)
            m_strFCancelacionSD = Value
        End Set
    End Property

    Public Property FCancelacionFI() As String
        Get
            Return m_strFCancelacionFI
        End Get
        Set(ByVal Value As String)
            m_strFCancelacionFI = Value
        End Set
    End Property

    Public Property Nquincenas() As Integer
        Get
            Return m_strNquincenas
        End Get
        Set(ByVal Value As Integer)
            m_strNquincenas = Value
        End Set
    End Property

    Public Property dtMotivos() As DataTable
        Get
            Return m_datdtMotivos
        End Get
        Set(ByVal Value As DataTable)
            m_datdtMotivos = Value
        End Set
    End Property

    Public Property SeguroVidaSAPDPVL() As Boolean
        Get
            Return m_bSeguroVidaDPVL
        End Get
        Set(ByVal Value As Boolean)
            m_bSeguroVidaDPVL = Value
        End Set
    End Property

#Region "Facturacion SiHay"
    Public Property PedidoID() As Integer
        Get
            Return m_PedidoID
        End Get
        Set(ByVal Value As Integer)
            m_PedidoID = Value
        End Set
    End Property

    Public Property EdicionPedido() As Boolean
        Get
            Return m_EdicionPedido
        End Get
        Set(ByVal Value As Boolean)
            m_EdicionPedido = Value
        End Set
    End Property

    Public Property ExistenciaApartado() As Decimal
        Get
            Return m_ExistenciaApartado
        End Get
        Set(ByVal Value As Decimal)
            m_ExistenciaApartado = Value
        End Set
    End Property
#End Region

#Region "DPCard Puntos"
    Public Property NoDPCardPuntos() As String
        Get
            Return m_NoDPCardPuntos
        End Get
        Set(ByVal Value As String)
            m_NoDPCardPuntos = Value
        End Set
    End Property

    Public Property CodDPCardPunto() As String
        Get
            Return m_CodDPCardPunto
        End Get
        Set(ByVal Value As String)
            m_CodDPCardPunto = Value
        End Set
    End Property
#End Region

#End Region

End Class
