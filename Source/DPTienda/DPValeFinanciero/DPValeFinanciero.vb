Imports DportenisPro.DPTienda.Core

Public Class DPVFinanciero

    Dim oParent As DPValeFinancieroManager

#Region "Constructor"

    Friend Sub New(ByVal Parent As DPValeFinancieroManager)

        MyBase.New()

        oParent = Parent

        ClearFields()

    End Sub

#End Region

#Region "Methods"

    Private Sub ClearFields()

        m_intIDCliente = 0
        m_intSecFile = 0
        m_strNoCuentaAbono = String.Empty
        m_decImporte = 0
        m_decIntereses = 0
        m_datFecha = Date.Today
        m_intIDDPVF = 0
        m_strNoDPVale = ""
        m_intTipo = 0
        m_strCodAlmacen = ""

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region

#Region "Fields"

    Dim m_intIDCliente As Integer
    Dim m_intSecFile As Integer
    Dim m_strNoCuentaAbono As String
    Dim m_decImporte As Decimal
    Dim m_decIntereses As Decimal
    Dim m_datFecha As DateTime
    Dim m_intIDDPVF As Integer
    Dim m_strNoDPVale As String
    Dim m_intTipo As Integer
    Dim m_strCodAlmacen As String
    Dim m_strNumFact As String
    Dim m_intIDAsoc As Integer

#End Region

#Region "Propiedades"

    Public Property Asociado() As Integer
        Get
            Return m_intIDAsoc
        End Get
        Set(ByVal Value As Integer)
            m_intIDAsoc = Value
        End Set
    End Property

    Public Property NumFactura() As String
        Get
            Return m_strNumFact
        End Get
        Set(ByVal Value As String)
            m_strNumFact = Value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return m_intIDDPVF
        End Get
        Set(ByVal Value As Integer)
            m_intIDDPVF = Value
        End Set
    End Property

    Public Property IDCliente() As Integer
        Get
            Return m_intIDCliente
        End Get
        Set(ByVal Value As Integer)
            m_intIDCliente = Value
        End Set
    End Property

    Public Property SecuencialFile() As Integer
        Get
            Return m_intSecFile
        End Get
        Set(ByVal Value As Integer)
            m_intSecFile = Value
        End Set
    End Property

    Public Property NoCuentaAbono() As String
        Get
            Return m_strNoCuentaAbono
        End Get
        Set(ByVal Value As String)
            m_strNoCuentaAbono = Value
        End Set
    End Property

    Public Property Importe() As Decimal
        Get
            Return m_decImporte
        End Get
        Set(ByVal Value As Decimal)
            m_decImporte = Value
        End Set
    End Property

    Public Property Intereses() As Decimal
        Get
            Return m_decIntereses
        End Get
        Set(ByVal Value As Decimal)
            m_decIntereses = Value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return m_datFecha
        End Get
        Set(ByVal Value As DateTime)
            m_datFecha = Value
        End Set
    End Property

    Public Property NoDPVale() As String
        Get
            Return m_strNoDPVale
        End Get
        Set(ByVal Value As String)
            m_strNoDPVale = Value
        End Set
    End Property

    Public Property Tipo() As Integer
        Get
            Return m_intTipo
        End Get
        Set(ByVal Value As Integer)
            m_intTipo = Value
        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
        End Set
    End Property

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

End Class
