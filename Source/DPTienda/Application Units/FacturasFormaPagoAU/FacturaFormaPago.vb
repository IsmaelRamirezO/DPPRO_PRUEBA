Imports DportenisPro.DPTienda.Core

Public Class FacturaFormaPago

    Dim oApplicationContext As ApplicationContext

    Public ReadOnly Property ApplicationContext() As ApplicationContext
        Get
            Return oApplicationContext
        End Get
    End Property

#Region "Constructors / Destructors"

    Public Sub New(ByVal ApplicationContext As ApplicationContext)

        oApplicationContext = ApplicationContext

    End Sub

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

    Friend Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Friend Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Fields"

    Private m_intFacturaFormaPagoID As Integer
    Private m_intDPValeID As String
    Private m_intFacturaID As Integer

    Private m_strFormaPagoID As String
    Private m_strBancoID As String
    Private m_strTipoTarjetaID As String
    Private m_strNumeroTarjeta As String
    Private m_strNumeroAutorización As String
    Private m_intNotaCreditoID As Integer
    Private m_decComisionBancaria As Decimal
    Private m_decIngersoComision As Decimal
    Private m_decIVAComision As Decimal

    Private m_decMonto As Decimal
    Private m_strRecordCreatedBy As String
    Private m_datRecordCreatedOn As Date
    Private m_bRecordStatus As Boolean
    Private m_strNoAfiliacion As String
    Private m_intID_Num_Promo As Integer

#Region "Facturacion SiHay"
    Private m_PedidoID As Integer
#End Region

    Public Event FacturaFormaPagoIDChanged As EventHandler
    Public Event FacturaIDChanged As EventHandler
    Public Event DPValeIDChanged As EventHandler
    Public Event FormaPagoIDChanged As EventHandler
    Public Event MontoChanged As EventHandler
    Public Event RecordCreatedByChanged As EventHandler
    Public Event RecordCreatedOnChanged As EventHandler
    Public Event RecordStatusChanged As EventHandler

    Public Event BancoIDChanged As EventHandler
    Public Event TipoTarjetaIDChanged As EventHandler
    Public Event NumeroTarjetaChanged As EventHandler
    Public Event NumeroAutorizaciónChanged As EventHandler
    Public Event NotaCreditoIDChanged As EventHandler
    Public Event ComisionBancariaChanged As EventHandler
    Public Event IngersoComisionChanged As EventHandler
    Public Event IVAComisionChanged As EventHandler



    Public Property FacturaFormaPagoID() As Integer
        Get
            Return m_intFacturaFormaPagoID
        End Get
        Set(ByVal Value As Integer)
            m_intFacturaFormaPagoID = Value

            RaiseEvent FacturaFormaPagoIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property FacturaID() As Integer
        Get
            Return m_intFacturaID
        End Get
        Set(ByVal Value As Integer)
            m_intFacturaID = Value

            RaiseEvent FacturaIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property PedidoID() As Integer
        Get
            Return m_PedidoID
        End Get
        Set(ByVal Value As Integer)
            m_PedidoID = Value
        End Set
    End Property

    Public Property FormaPagoID() As String
        Get
            Return m_strFormaPagoID
        End Get
        Set(ByVal Value As String)
            m_strFormaPagoID = Value

            RaiseEvent FormaPagoIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property BancoID() As String
        Get
            Return m_strBancoID
        End Get
        Set(ByVal Value As String)
            m_strBancoID = Value

            RaiseEvent BancoIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property TipoTarjetaID() As String
        Get
            Return m_strTipoTarjetaID
        End Get
        Set(ByVal Value As String)
            m_strTipoTarjetaID = Value

            RaiseEvent TipoTarjetaIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property NumeroTarjeta() As String
        Get
            Return m_strNumeroTarjeta
        End Get
        Set(ByVal Value As String)
            m_strNumeroTarjeta = Value

            RaiseEvent NumeroTarjetaChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property NumeroAutorización() As String
        Get
            Return m_strNumeroAutorización
        End Get
        Set(ByVal Value As String)
            m_strNumeroAutorización = Value

            RaiseEvent NumeroAutorizaciónChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property NotaCreditoID() As Integer
        Get
            Return m_intNotaCreditoID
        End Get
        Set(ByVal Value As Integer)
            m_intNotaCreditoID = Value

            RaiseEvent NotaCreditoIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property ComisionBancaria() As Decimal
        Get
            Return m_decComisionBancaria
        End Get
        Set(ByVal Value As Decimal)
            m_decComisionBancaria = Value

            RaiseEvent ComisionBancariaChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property IngresoComision() As Decimal
        Get
            Return m_decIngersoComision
        End Get
        Set(ByVal Value As Decimal)
            m_decIngersoComision = Value

            RaiseEvent IngersoComisionChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property IVAComision() As Decimal
        Get
            Return m_decIVAComision
        End Get
        Set(ByVal Value As Decimal)
            m_decIVAComision = Value

            RaiseEvent IVAComisionChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property Monto() As Decimal
        Get
            Return m_decMonto
        End Get
        Set(ByVal Value As Decimal)
            m_decMonto = Value

            RaiseEvent MontoChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property RecordCreatedBy() As String
        Get
            Return m_strRecordCreatedBy
        End Get
        Set(ByVal Value As String)
            m_strRecordCreatedBy = Value

            RaiseEvent RecordCreatedByChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property RecordCreatedOn() As Date
        Get
            Return m_datRecordCreatedOn
        End Get
        Set(ByVal Value As Date)
            m_datRecordCreatedOn = Value

            RaiseEvent RecordCreatedOnChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property RecordStatus() As Boolean
        Get
            Return m_bRecordStatus
        End Get
        Set(ByVal Value As Boolean)
            m_bRecordStatus = Value

            RaiseEvent RecordStatusChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property DPValeID() As String
        Get
            Return m_intDPValeID
        End Get
        Set(ByVal Value As String)

            m_intDPValeID = Value
            RaiseEvent DPValeIDChanged(Me, New EventArgs)

        End Set
    End Property

    Public Property NoAfiliacion() As String
        Get
            Return m_strNoAfiliacion
        End Get
        Set(ByVal Value As String)
            m_strNoAfiliacion = Value
        End Set
    End Property

    Public Property Promocion() As Integer

        Get
            Return m_intID_Num_Promo
        End Get
        Set(ByVal Value As Integer)
            m_intID_Num_Promo = Value
        End Set

    End Property

#End Region

#Region "Methods"

    Public Sub ClearFields()

        m_intFacturaFormaPagoID = 0
        m_intFacturaID = 0
        m_strFormaPagoID = String.Empty
        m_strBancoID = String.Empty
        m_strTipoTarjetaID = String.Empty
        m_strNumeroTarjeta = String.Empty
        m_strNumeroAutorización = String.Empty
        m_intNotaCreditoID = 0
        m_decComisionBancaria = 0
        m_decIngersoComision = 0
        m_decIVAComision = 0
        m_decMonto = 0
        m_strRecordCreatedBy = String.Empty
        m_datRecordCreatedOn = Date.Today
        m_bRecordStatus = 1
        m_strNoAfiliacion = String.Empty

    End Sub

    Public Sub Save()

        Dim oFacturaFormaPagoDG As FacturaFormaPagoDataGateway
        oFacturaFormaPagoDG = New FacturaFormaPagoDataGateway(Me)

        oFacturaFormaPagoDG.Insert(Me)

    End Sub

    Public Function Load(ByVal FacturaID As Integer) As DataSet

        Dim oFacturaFormaPagoDG As FacturaFormaPagoDataGateway
        oFacturaFormaPagoDG = New FacturaFormaPagoDataGateway(Me)

        Return oFacturaFormaPagoDG.SelectAll(FacturaID)

    End Function

    Public Function LoadRptCierre(ByVal FacturaID As Integer) As DataSet

        Dim oFacturaFormaPagoDG As FacturaFormaPagoDataGateway
        oFacturaFormaPagoDG = New FacturaFormaPagoDataGateway(Me)

        Return oFacturaFormaPagoDG.SelectAllReport(FacturaID)

    End Function

    Public Sub Update()
        Dim oFacturaFormaPagoDG As FacturaFormaPagoDataGateway
        oFacturaFormaPagoDG = New FacturaFormaPagoDataGateway(Me)

        oFacturaFormaPagoDG.Update(Me)

    End Sub
#End Region

#Region "Facturacion SiHay"
    Public Function LoadByPedidoID(ByVal PedidoID As Integer) As DataSet

        Dim oFacturaFormaPagoDG As FacturaFormaPagoDataGateway
        oFacturaFormaPagoDG = New FacturaFormaPagoDataGateway(Me)

        Return oFacturaFormaPagoDG.SelectAllByPedidoID(PedidoID)

    End Function

    Public Function LoadRptCierreByPedidoID(ByVal PedidoID As Integer) As DataSet

        Dim oFacturaFormaPagoDG As FacturaFormaPagoDataGateway
        oFacturaFormaPagoDG = New FacturaFormaPagoDataGateway(Me)

        Return oFacturaFormaPagoDG.SelectAllReportByPedidoID(PedidoID)

    End Function

    '-------------------------------------------------------------------------------------------
    'FLIZARRAGA 26/09/2014: Se cargan las formas de pagos del si hay y ecommerce
    '-------------------------------------------------------------------------------------------

    Public Function LoadRptCierrePedidosFacturadosByPedidoID(ByVal PedidoID As Integer) As DataSet
        Dim formaPago As New FacturaFormaPagoDataGateway(Me)
        Return formaPago.SelectPedidosFacturadosByPedidoID(PedidoID)
    End Function

    Public Function LoadRptCierrePedidosNoFacturadosByPedidoID(ByVal PedidoID As Integer) As DataSet
        Dim formaPago As New FacturaFormaPagoDataGateway(Me)
        Return formaPago.SelectPedidosNoFacturadosByPedidoID(PedidoID)
    End Function

    Public Function LoadRptCierrePagosEcommerceByOtrosPagosID(ByVal OtrosPagosID As Integer) As DataSet
        Dim formaPago As New FacturaFormaPagoDataGateway(Me)
        Return formaPago.SelectFormasPagosEcommerce(OtrosPagosID)
    End Function

    '---------------------------------------------------------------------------------------------------------------------------------
    'FLIZARRAGA 29/04/2013: Guarda las formas de Pago de la promoción del SiHay
    '---------------------------------------------------------------------------------------------------------------------------------

    Public Sub SavePedidoSH()

        Dim oFacturaFormaPagoDG As FacturaFormaPagoDataGateway
        oFacturaFormaPagoDG = New FacturaFormaPagoDataGateway(Me)

        oFacturaFormaPagoDG.InsertFormaPagoPedidoSH(Me)

    End Sub
#End Region

End Class
