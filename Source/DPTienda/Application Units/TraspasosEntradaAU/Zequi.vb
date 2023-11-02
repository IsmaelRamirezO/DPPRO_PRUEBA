Public Class Zequi

#Region "Variables"

    Private m_IdZequi As Integer
    Private m_CodArticulo As String
    Private m_Serie As String
    Private m_NoPedido As String
    Private m_CentroOrigen As String
    Private m_CentroDestino As String
    Private m_Proveedor As String
    Private m_DocMaterial As String
    Private m_ClaseMovimiento As String
    Private m_SOBKZ As String
    Private m_SHKZG As String
    Private m_BEWTP As String
    Private TraspasoEntradaMgr As TraspasosEntradaManager

#End Region

#Region "Propiedades"

    Public Property IdZequi As Integer
        Get
            Return m_IdZequi
        End Get
        Set(ByVal value As Integer)
            m_IdZequi = value
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

    Public Property Serie As String
        Get
            Return m_Serie
        End Get
        Set(ByVal value As String)
            m_Serie = value
        End Set
    End Property

    Public Property NoPedido As String
        Get
            Return m_NoPedido
        End Get
        Set(ByVal value As String)
            m_NoPedido = value
        End Set
    End Property

    Public Property CentroOrigen As String
        Get
            Return m_CentroOrigen
        End Get
        Set(ByVal value As String)
            m_CentroOrigen = value
        End Set
    End Property

    Public Property CentroDestino As String
        Get
            Return m_CentroDestino
        End Get
        Set(ByVal value As String)
            m_CentroDestino = value
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

    Public Property DocMaterial As String
        Get
            Return m_DocMaterial
        End Get
        Set(ByVal value As String)
            m_DocMaterial = value
        End Set
    End Property

    Public Property ClaseMovimiento As String
        Get
            Return m_ClaseMovimiento
        End Get
        Set(ByVal value As String)
            m_ClaseMovimiento = value
        End Set
    End Property

    Public Property SOBKZ As String
        Get
            Return m_SOBKZ
        End Get
        Set(ByVal value As String)
            m_SOBKZ = value
        End Set
    End Property

    Public Property SHKZG As String
        Get
            Return m_SHKZG
        End Get
        Set(ByVal value As String)
            m_SHKZG = value
        End Set
    End Property

    Public Property BEWTP As String
        Get
            Return m_BEWTP
        End Get
        Set(ByVal value As String)
            m_BEWTP = value
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New(ByVal TraspasoEntradaMgr As TraspasosEntradaManager)
        Me.m_IdZequi = 0
        Me.m_CodArticulo = ""
        Me.m_Serie = ""
        Me.m_NoPedido = ""
        Me.m_CentroOrigen = ""
        Me.m_CentroDestino = ""
        Me.m_Proveedor = ""
        Me.m_DocMaterial = ""
        Me.m_ClaseMovimiento = ""
        Me.m_SOBKZ = ""
        Me.m_SHKZG = ""
        Me.m_BEWTP = ""
        Me.TraspasoEntradaMgr = TraspasoEntradaMgr
    End Sub

    Public Sub New(ByVal IdZequi As Integer, ByVal TraspasoEntradaMgr As TraspasosEntradaManager)
        Me.TraspasoEntradaMgr = TraspasoEntradaMgr
        Me.IdZequi = IdZequi
        Me.TraspasoEntradaMgr.GetZequiById(Me)
    End Sub

#End Region

#Region "Metodos y funciones"

    Public Function Save() As Boolean
        Dim valido As Boolean = False
        valido = Me.TraspasoEntradaMgr.SaveZequi(Me)
        Return valido
    End Function

#End Region

    
End Class
