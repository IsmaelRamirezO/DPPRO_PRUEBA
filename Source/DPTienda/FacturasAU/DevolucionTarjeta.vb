Public Class DevolucionTarjeta

#Region "Variables de instancia"

    Private m_DevolucionTarjetaId As Integer
    Private m_NotaCreditoID As Integer
    Private m_FormaPagoID As Integer
    Private m_CodAlmacen As String
    Private m_CodCaja As String
    Private m_CodTipoVenta As String
    Private m_CodFormasPago As String
    Private m_CodTipoTarjeta As String
    Private m_CodVendedor As String
    Private m_CodBanco As String
    Private m_NumeroTarjeta As String
    Private m_NumeroAutorizacion As String
    Private m_NoAfiliacion As String
    Private m_MontoPago As Decimal
    Private m_Fecha As DateTime
    Private m_Referencia As String
    Private m_FacturaId As Integer
    Private m_PedidoId As Integer
    Private m_Compensado As Boolean
    Private FacturaMgr As FacturaManager

#End Region

#Region "Propiedades"

    Public Property DevolucionTarjetaId As Integer
        Get
            Return m_DevolucionTarjetaId
        End Get
        Set(ByVal value As Integer)
            m_DevolucionTarjetaId = value
        End Set
    End Property

    Public Property NotaCreditoID As Integer
        Get
            Return m_NotaCreditoID
        End Get
        Set(ByVal value As Integer)
            m_NotaCreditoID = value
        End Set
    End Property

    Public Property FormaPagoID As Integer
        Get
            Return m_FormaPagoID
        End Get
        Set(ByVal value As Integer)
            m_FormaPagoID = value
        End Set
    End Property

    Public Property CodAlmacen As String
        Get
            Return m_CodAlmacen
        End Get
        Set(ByVal value As String)
            m_CodAlmacen = value
        End Set
    End Property

    Public Property CodCaja As String
        Get
            Return m_CodCaja
        End Get
        Set(ByVal value As String)
            m_CodCaja = value
        End Set
    End Property

    Public Property CodTipoVenta As String
        Get
            Return m_CodTipoVenta
        End Get
        Set(ByVal value As String)
            m_CodTipoVenta = value
        End Set
    End Property

    Public Property CodFormasPago As String
        Get
            Return m_CodFormasPago
        End Get
        Set(ByVal value As String)
            m_CodFormasPago = value
        End Set
    End Property

    Public Property CodTipoTarjeta As String
        Get
            Return m_CodTipoTarjeta
        End Get
        Set(ByVal value As String)
            m_CodTipoTarjeta = value
        End Set
    End Property

    Public Property CodVendedor As String
        Get
            Return m_CodVendedor
        End Get
        Set(ByVal value As String)
            m_CodVendedor = value
        End Set
    End Property

    Public Property CodBanco As String
        Get
            Return m_CodBanco
        End Get
        Set(ByVal value As String)
            m_CodBanco = value
        End Set
    End Property

    Public Property NumeroTarjeta As String
        Get
            Return m_NumeroTarjeta
        End Get
        Set(ByVal value As String)
            m_NumeroTarjeta = value
        End Set
    End Property

    Public Property NumeroAutorizacion As String
        Get
            Return m_NumeroAutorizacion
        End Get
        Set(ByVal value As String)
            m_NumeroAutorizacion = value
        End Set
    End Property

    Public Property NoAfiliacion As String
        Get
            Return m_NoAfiliacion
        End Get
        Set(ByVal value As String)
            m_NoAfiliacion = value
        End Set
    End Property

    Public Property MontoPago As Decimal
        Get
            Return m_MontoPago
        End Get
        Set(ByVal value As Decimal)
            m_MontoPago = value
        End Set
    End Property

    Public Property Fecha As DateTime
        Get
            Return m_Fecha
        End Get
        Set(ByVal value As DateTime)
            m_Fecha = value
        End Set
    End Property

    Public Property Referencia As String
        Get
            Return m_Referencia
        End Get
        Set(ByVal value As String)
            m_Referencia = value
        End Set
    End Property

    Public Property FacturaId As Integer
        Get
            Return m_FacturaId
        End Get
        Set(ByVal value As Integer)
            m_FacturaId = value
        End Set
    End Property

    Public Property PedidoId As Integer
        Get
            Return m_PedidoId
        End Get
        Set(ByVal value As Integer)
            m_PedidoId = value
        End Set
    End Property

    Public Property Compensado As Boolean
        Get
            Return m_Compensado
        End Get
        Set(ByVal value As Boolean)
            m_Compensado = value
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New(ByVal FacturaMgr As FacturaManager)
        Me.DevolucionTarjetaId = 0
        Me.NotaCreditoID = 0
        Me.FormaPagoID = 0
        Me.CodAlmacen = ""
        Me.CodCaja = ""
        Me.CodTipoVenta = ""
        Me.CodFormasPago = ""
        Me.CodTipoTarjeta = ""
        Me.CodVendedor = ""
        Me.CodBanco = ""
        Me.NumeroTarjeta = ""
        Me.NumeroAutorizacion = ""
        Me.NoAfiliacion = ""
        Me.MontoPago = 0
        Me.Fecha = DateTime.Now
        Me.Referencia = ""
        Me.FacturaId = 0
        Me.PedidoId = 0
        Me.Compensado = False
        Me.FacturaMgr = FacturaMgr
    End Sub


#End Region

#Region "Metodos y Funciones"

    Public Function Save() As Boolean
        Dim valido As Boolean = False
        valido = Me.FacturaMgr.SaveDevolucionTarjeta(Me)
        Return valido
    End Function

#End Region

End Class
