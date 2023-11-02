Imports DportenisPro.DPTienda.Core

Public Class DPVFinancieroDispersion

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
        m_strCodPlaza = ""
        m_strOficina = ""
        m_bolTarj = False
        m_strNumeroIFE = ""
        m_strFolioFISAPIntereses = ""
        m_strFolioFISAPMonto = ""
        '---------------------------------------------------------------
        'FLIZARRAGA 23/10/2017: Agregar RFC y Fecha de nacimiento
        '---------------------------------------------------------------
        m_rfc = ""
        m_fechNac = Date.Today
        m_Alta = False

        '---------------------------------------------------------------
        'FLIZARRAGA 02/03/2018: Agregar la fecha de registro
        '---------------------------------------------------------------
        m_FechaRegistro = DateTime.Now

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
    Dim m_strCodPlaza As String
    Dim m_strOficina As String
    Dim m_bolTarj As Boolean
    Dim m_strNumeroIFE As String
    Private m_strFolioFISAPMonto As String = ""
    Private m_strFolioFISAPIntereses As String = ""

    '-----------------------------------------------------------------------------------
    ' FLIZARRAGA 23/10/2017: Campos nuevos para Servicios Financieros
    '-----------------------------------------------------------------------------------
    Dim m_strBanco As String
    Dim m_strCelular As String
    Dim m_strCompañiaCelular As String
    Dim m_strClabe As String
    Dim m_bolTransfer As Boolean
    Dim m_strNumeroTarjeta As String
    Dim m_strServicioId As String
    Dim m_strCodigo As String
    Dim m_strNombreCliente As String
    '-----------------------------------------------------------------------------------
    ' FLIZARRAGA 23/10/2017 Campo CodigoSeguridad nuevo para Servicio de Celular
    '-----------------------------------------------------------------------------------
    Private m_strCodigoSeguridad As String
    '-----------------------------------------------------------------------------------

    '---------------------------------------------------------------
    'FLIZARRAGA 23/10/2017 Agregar RFC y Fecha de nacimiento
    '---------------------------------------------------------------
    Private m_rfc As String
    Private m_fechNac As Date

    Private m_Dispersion As Integer
    Private m_AccountNumber As String
    Private m_Microcredito As Boolean
    Private m_PlazoMicrocredito As String
    Private m_ClubDP As String
    Private m_Alta As Boolean
    '---------------------------------------------------------------
    'FLIZARRAGA 02/03/2018
    '---------------------------------------------------------------
    Private m_FechaRegistro As DateTime
    '---------------------------------------------------------------
    'FLIZARRAGA 04/04/2018: Se guarda transacción ID
    '---------------------------------------------------------------
    Private m_TransactionId As Integer

#End Region

#Region "Propiedades"

    Public Property NumeroIFE() As String
        Get
            Return m_strNumeroIFE
        End Get
        Set(ByVal Value As String)
            m_strNumeroIFE = Value
        End Set
    End Property

    Public Property AltaTarjeta() As Boolean
        Get
            Return m_bolTarj
        End Get
        Set(ByVal Value As Boolean)
            m_bolTarj = Value
        End Set
    End Property

    Public Property Oficina() As String
        Get
            Return m_strOficina
        End Get
        Set(ByVal Value As String)
            m_strOficina = Value
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

    Public Property FolioFISAPIntereses() As String
        Get
            Return m_strFolioFISAPIntereses
        End Get
        Set(ByVal Value As String)
            m_strFolioFISAPIntereses = Value
        End Set
    End Property

    Public Property FolioFISAPMonto() As String
        Get
            Return m_strFolioFISAPMonto
        End Get
        Set(ByVal Value As String)
            m_strFolioFISAPMonto = Value
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

    Public Property Celular() As String
        Get
            Return m_strCelular
        End Get
        Set(ByVal Value As String)
            m_strCelular = Value
        End Set
    End Property

    Public Property CompañiaCelular() As String
        Get
            Return m_strCompañiaCelular
        End Get
        Set(ByVal Value As String)
            m_strCompañiaCelular = Value
        End Set
    End Property

    Public Property CLABE() As String
        Get
            Return m_strClabe
        End Get
        Set(ByVal Value As String)
            m_strClabe = Value
        End Set
    End Property

    Public Property Transfer() As Boolean
        Get
            Return m_bolTransfer
        End Get
        Set(ByVal Value As Boolean)
            m_bolTransfer = Value
        End Set
    End Property

    Public Property NumeroTarjeta() As String
        Get
            Return m_strNumeroTarjeta
        End Get
        Set(ByVal Value As String)
            m_strNumeroTarjeta = Value
        End Set
    End Property

    Public Property ServicioID() As String
        Get
            Return m_strServicioId
        End Get
        Set(ByVal Value As String)
            m_strServicioId = Value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return m_strCodigo
        End Get
        Set(ByVal Value As String)
            m_strCodigo = Value
        End Set
    End Property

    Public Property NombreCliente() As String
        Get
            Return m_strNombreCliente
        End Get
        Set(ByVal Value As String)
            m_strNombreCliente = Value
        End Set
    End Property

    Public Property CodigoSeguridad() As String
        Get
            Return m_strCodigoSeguridad
        End Get
        Set(ByVal Value As String)
            m_strCodigoSeguridad = Value
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return m_rfc
        End Get
        Set(ByVal Value As String)
            m_rfc = Value
        End Set
    End Property

    Public Property FechNac() As Date
        Get
            Return m_fechNac
        End Get
        Set(ByVal Value As Date)
            m_fechNac = Value
        End Set
    End Property
    '---------------------------------------------------------------
    Public Property Dispersion() As Integer
        Get
            Return m_Dispersion
        End Get
        Set(ByVal Value As Integer)
            m_Dispersion = Value
        End Set
    End Property

    Dim m_strNoColaborador As String = String.Empty
    Public Property NoColaborador() As String
        Get
            Return m_strNoColaborador
        End Get
        Set(ByVal Value As String)
            m_strNoColaborador = Value
        End Set
    End Property

    Dim m_dateFechaDispersion As DateTime
    Public Property FechaDispersion() As DateTime
        Get
            Return m_dateFechaDispersion
        End Get
        Set(ByVal Value As DateTime)
            m_dateFechaDispersion = Value
        End Set
    End Property

    Public Property AccountNumber As String
        Get
            Return m_AccountNumber
        End Get
        Set(ByVal value As String)
            m_AccountNumber = value
        End Set
    End Property

    Public Property Microcredito As Boolean
        Get
            Return m_Microcredito
        End Get
        Set(ByVal value As Boolean)
            m_Microcredito = value
        End Set
    End Property

    Public Property PlazoMicrocredito As String
        Get
            Return m_PlazoMicrocredito
        End Get
        Set(ByVal value As String)
            m_PlazoMicrocredito = value
        End Set
    End Property

    Public Property ClubDP As String
        Get
            Return m_ClubDP
        End Get
        Set(ByVal value As String)
            m_ClubDP = value
        End Set
    End Property

    Public Property Alta As Boolean
        Get
            Return m_Alta
        End Get
        Set(ByVal value As Boolean)
            m_Alta = value
        End Set
    End Property

    Public Property FechaRegistro As DateTime
        Get
            Return m_FechaRegistro
        End Get
        Set(ByVal value As DateTime)
            m_FechaRegistro = value
        End Set
    End Property

    Public Property TransactionId As Integer
        Get
            Return m_TransactionId
        End Get
        Set(ByVal value As Integer)
            m_TransactionId = value
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
