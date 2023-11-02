Public Class ZdproPedidos

#Region "Variable"

    Private m_IdPedido As Integer
    Private m_Identificador As String
    Private m_DocMaterial As String
    Private m_PedidoSAP As String
    Private m_Proveedor As String
    Private m_ProveedorDesc As String
    Private m_CodAlmacen As String
    Private m_AlmacenDesc As String
    Private m_CodArticulo As String
    Private m_ArticuloDesc As String
    Private m_TipoArticulo As String
    Private m_CantidadRecibida As Integer
    Private m_CantidadLecturada As Integer
    Private m_CodUpc As String
    Private m_CodVendedor As String
    Private m_Responsable As String
    Private m_Referencia As String
    Private m_Serie As String
    Private m_TotalPedido As Integer
    Private m_TotalRecibido As Integer
    Private m_Sobrante As Integer
    Private m_Fecha As DateTime
    Private m_Tipo As String
    Private TraspasoEntradaMgr As TraspasosEntradaManager


#End Region

#Region "Propiedades"

    Public Property IdPedido As Integer
        Get
            Return m_IdPedido
        End Get
        Set(ByVal value As Integer)
            m_IdPedido = value
        End Set
    End Property

    Public Property Identificador As String
        Get
            Return m_Identificador
        End Get
        Set(ByVal value As String)
            m_Identificador = value
        End Set
    End Property

    Public Property DocMaterial As String
        Get
            Return m_DocMaterial
        End Get
        Set(ByVal value As String)
            m_DocMaterial = value
        End Set
    End Property

    Public Property PedidoSAP As String
        Get
            Return m_PedidoSAP
        End Get
        Set(ByVal value As String)
            m_PedidoSAP = value
        End Set
    End Property

    Public Property Proveedor As String
        Get
            Return m_Proveedor
        End Get
        Set(ByVal value As String)
            m_Proveedor = value
        End Set
    End Property

    Public Property ProveedorDesc As String
        Get
            Return m_ProveedorDesc
        End Get
        Set(ByVal value As String)
            m_ProveedorDesc = value
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

    Public Property AlmacenDesc As String
        Get
            Return m_AlmacenDesc
        End Get
        Set(ByVal value As String)
            m_AlmacenDesc = value
        End Set
    End Property

    Public Property CodArticulo As String
        Get
            Return m_CodArticulo
        End Get
        Set(ByVal value As String)
            m_CodArticulo = value
        End Set
    End Property

    Public Property ArticuloDesc As String
        Get
            Return m_ArticuloDesc
        End Get
        Set(ByVal value As String)
            m_ArticuloDesc = value
        End Set
    End Property

    Public Property TipoArticulo As String
        Get
            Return m_TipoArticulo
        End Get
        Set(ByVal value As String)
            m_TipoArticulo = value
        End Set
    End Property

    Public Property CantidadRecibida As Integer
        Get
            Return m_CantidadRecibida
        End Get
        Set(ByVal value As Integer)
            m_CantidadRecibida = value
        End Set
    End Property

    Public Property CantidadLecturada As Integer
        Get
            Return m_CantidadLecturada
        End Get
        Set(ByVal value As Integer)
            m_CantidadLecturada = value
        End Set
    End Property

    Public Property CodUpc As String
        Get
            Return m_CodUpc
        End Get
        Set(ByVal value As String)
            m_CodUpc = value
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

    Public Property Responsable As String
        Get
            Return m_Responsable
        End Get
        Set(ByVal value As String)
            m_Responsable = value
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

    Public Property Serie As String
        Get
            Return m_Serie
        End Get
        Set(ByVal value As String)
            m_Serie = value
        End Set
    End Property

    Public Property TotalPedido As Integer
        Get
            Return m_TotalPedido
        End Get
        Set(ByVal value As Integer)
            m_TotalPedido = value
        End Set
    End Property

    Public Property TotalRecibido As Integer
        Get
            Return m_TotalRecibido
        End Get
        Set(ByVal value As Integer)
            m_TotalRecibido = value
        End Set
    End Property

    Public Property Sobrante As Integer
        Get
            Return m_Sobrante
        End Get
        Set(value As Integer)
            m_Sobrante = value
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

    Public Property Tipo As String
        Get
            Return m_Tipo
        End Get
        Set(ByVal value As String)
            m_Tipo = value
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New(ByVal TraspasoEntradaMgr As TraspasosEntradaManager)
        m_IdPedido = 0
        m_DocMaterial = ""
        m_PedidoSAP = ""
        m_Proveedor = ""
        m_ProveedorDesc = ""
        m_CodAlmacen = ""
        m_AlmacenDesc = ""
        m_CodArticulo = ""
        m_ArticuloDesc = ""
        m_TipoArticulo = ""
        m_CantidadRecibida = 0
        m_CantidadLecturada = 0
        m_CodUpc = ""
        m_CodVendedor = ""
        m_Responsable = ""
        m_Referencia = ""
        m_Serie = ""
        m_TotalPedido = 0
        m_TotalRecibido = 0
        m_Fecha = DateTime.Now
        m_Tipo = ""
        Me.TraspasoEntradaMgr = TraspasoEntradaMgr
    End Sub

    Public Sub New(ByVal IdPedido As Integer, ByVal TraspasoEntradaMgr As TraspasosEntradaManager)
        Me.TraspasoEntradaMgr = TraspasoEntradaMgr
        Me.IdPedido = IdPedido
        Me.TraspasoEntradaMgr.GetZdpproPedidoById(Me)
    End Sub

#End Region

#Region "Metodos y funciones"

    Public Function Save() As Boolean
        Dim valido As Boolean = False
        valido = Me.TraspasoEntradaMgr.SaveZdproPedido(Me)
        Return valido
    End Function

#End Region

    
End Class
