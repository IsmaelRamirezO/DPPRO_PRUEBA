Public Class rptFacturaInfo


#Region "Fields"

    Private m_decDeudaFacilito As Decimal

    Private m_strvNombreClienteAsociado As String

    Private m_strNombreAsociado As String

    Private m_bDisponible As Boolean

    Private m_intFacturaID As Integer

    Private m_strModuloID As String

    Private m_intFolioDPVale As String

    Private m_PedidoID As Integer

    Private m_TipoVoucher As Integer = 0

    Public Property ModuloID() As String
        Get
            Return m_strModuloID
        End Get
        Set(ByVal Value As String)
            m_strModuloID = Value
        End Set
    End Property

    Public Property FacturaID() As Integer
        Get
            Return m_intFacturaID
        End Get
        Set(ByVal Value As Integer)
            m_intFacturaID = Value
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

    Public Property TipoVoucher() As Integer
        Get
            Return m_TipoVoucher
        End Get
        Set(ByVal Value As Integer)
            m_TipoVoucher = Value
        End Set
    End Property

    Public Property Disponible() As Boolean
        Get
            Return m_bDisponible
        End Get
        Set(ByVal Value As Boolean)
            m_bDisponible = Value
        End Set
    End Property

    Public Property NombreAsociado() As String
        Get
            Return m_strNombreAsociado
        End Get
        Set(ByVal Value As String)
            m_strNombreAsociado = Value
        End Set
    End Property

    Public Property vNombreClienteAsociado() As String
        Get
            Return m_strvNombreClienteAsociado
        End Get
        Set(ByVal Value As String)
            m_strvNombreClienteAsociado = Value
        End Set
    End Property

    Public Property DeudaFacilito() As Decimal
        Get
            Return m_decDeudaFacilito
        End Get
        Set(ByVal Value As Decimal)
            m_decDeudaFacilito = Value
        End Set
    End Property

    Public Property FolioDPVale() As String
        Get
            Return m_intFolioDPVale
        End Get
        Set(ByVal Value As String)
            m_intFolioDPVale = Value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub New()

        Me.Clear()

    End Sub

    Private Sub Clear()

        m_decDeudaFacilito = 0

        m_strvNombreClienteAsociado = String.Empty

        m_strNombreAsociado = String.Empty

        m_bDisponible = False

        m_intFacturaID = 0

        m_strModuloID = String.Empty

        m_intFolioDPVale = 0

        'm_strFolioSAP = String.Empty

    End Sub

#End Region


End Class
