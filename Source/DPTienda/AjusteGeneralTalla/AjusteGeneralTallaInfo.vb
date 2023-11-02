Public Class AjusteGeneralTallaInfo

    Private oParent As AjusteGeneralTallaManager

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As AjusteGeneralTallaManager)

        oParent = Parent
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
    Private m_strUsuario As String
    Private m_strAlmacen As String
    Private m_strFolioSAP As String
    Private m_dsDetalle As New DataTable
    '----------------------------------
    Private m_strCodigo As String
    Private m_strTalla_S As String
    Private m_strTalla_E As String
    Private m_intCantidad As Integer
    Private m_strFolioFactura As String

#End Region

#Region "Properties"

    Public Property Codigo() As String
        Get
            Return m_strCodigo
        End Get
        Set(ByVal Value As String)
            m_strCodigo = Value
        End Set
    End Property

    Public Property FolioFacturaSAP() As String
        Get
            Return m_strFolioFactura
        End Get
        Set(ByVal Value As String)
            m_strFolioFactura = Value
        End Set
    End Property

    Public Property Talla_S() As String
        Get
            Return m_strTalla_S
        End Get
        Set(ByVal Value As String)
            m_strTalla_S = Value
        End Set
    End Property

    Public Property Talla_E() As String
        Get
            Return m_strTalla_E
        End Get
        Set(ByVal Value As String)
            m_strTalla_E = Value
        End Set
    End Property

    Public Property Cantidad() As Integer
        Get
            Return m_intCantidad
        End Get
        Set(ByVal Value As Integer)
            m_intCantidad = Value
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

    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
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
        Me.m_strFolioSAP = String.Empty
        '----------------------------------
        m_strCodigo = String.Empty
        m_strTalla_S = String.Empty
        m_strTalla_E = String.Empty
        m_intCantidad = 0
        m_strFolioFactura = String.Empty
        m_strUsuario = UCase(oParent.ApplicationContext.Security.CurrentUser.SessionLoginName)

        oParent.LoadInto(0, Me)

        SetFlagNew()
        ResetFlagDirty()

    End Sub

#End Region

End Class
