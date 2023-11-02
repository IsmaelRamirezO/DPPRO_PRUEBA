Imports DportenisPro.DPTienda.Core

Public Class AjusteGeneralInfo

    Private oParent As AjusteGeneralManager

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As AjusteGeneralManager, ByVal strTipoAjuste As String)

        oParent = Parent
        Me.TipoAjuste = strTipoAjuste
        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

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

    Public Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Fields"

    Private m_intFolioAjuste As Integer
    Private m_datFechaAjuste As Date
    Private m_intTotalCodigos As Integer
    Private m_strObservaciones As String
    Private m_decCostoTotal As Decimal
    Private m_strUsuario As String
    Private m_strFolioSAP As String
    Private m_strAlmacen As String
    Private m_strTipoAjuste As String
    Private m_dsDetalle As New DataTable
    Private m_strTEOrigen As String = ""
    Private m_strClaseMov As String = ""
    Private m_strMotivo As String = ""

#End Region

#Region "Properties"
    '--------------------------------------------------------------------------------
    'rgermain 08/10/2016: Nuevas propiedades para SAP Retail
    '--------------------------------------------------------------------------------
    Public Property ClaseMov() As String
        Get
            Return m_strClaseMov
        End Get
        Set(ByVal Value As String)
            m_strClaseMov = Value
        End Set
    End Property

    Public Property Motivo() As String
        Get
            Return m_strMotivo
        End Get
        Set(ByVal Value As String)
            m_strMotivo = Value
        End Set
    End Property
    '--------------------------------------------------------------------------------
    Public Property TEOrigen() As String
        Get
            Return m_strTEOrigen
        End Get
        Set(ByVal Value As String)
            m_strTEOrigen = Value
        End Set
    End Property

    Public Property FolioAjuste() As Integer
        Get
            Return m_intFolioAjuste
        End Get
        Set(ByVal Value As Integer)
            m_intFolioAjuste = Value
        End Set
    End Property

    Public Property FechaAjuste() As Date
        Get
            Return m_datFechaAjuste
        End Get
        Set(ByVal Value As Date)
            m_datFechaAjuste = Value
        End Set
    End Property

    Public Property TotalCodigos() As Integer
        Get
            Return m_intTotalCodigos
        End Get
        Set(ByVal Value As Integer)
            m_intTotalCodigos = Value
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return m_strObservaciones
        End Get
        Set(ByVal Value As String)
            m_strObservaciones = Value
        End Set
    End Property

    Public Property CostoTotal() As Decimal
        Get
            Return m_decCostoTotal
        End Get
        Set(ByVal Value As Decimal)
            m_decCostoTotal = Value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
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

    Public Property Almacen() As String
        Get
            Return m_strAlmacen
        End Get
        Set(ByVal Value As String)
            m_strAlmacen = Value
        End Set
    End Property

    Public Property TipoAjuste() As String
        Get
            Return m_strTipoAjuste
        End Get
        Set(ByVal Value As String)
            m_strTipoAjuste = Value
        End Set
    End Property

    Public Property Detalle() As DataTable
        Get
            Return m_dsDetalle
        End Get
        Set(ByVal Value As DataTable)
            m_dsDetalle = Value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub ClearFields()

        m_intFolioAjuste = 0
        m_datFechaAjuste = Date.Now
        m_intTotalCodigos = 0
        m_strObservaciones = String.Empty
        m_decCostoTotal = 0
        m_strTEOrigen = ""
        m_strClaseMov = ""
        m_strMotivo = ""

        m_strUsuario = UCase(oParent.ApplicationContext.Security.CurrentUser.SessionLoginName)

        oParent.LoadInto(0, Me)

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region

End Class
