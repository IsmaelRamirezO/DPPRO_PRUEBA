
Public Class InicioCaja

    Private oParent As InicioCajaManager

#Region "Fields"

#Region "Fields Data Storage"

    Private m_intInicioCajaID As Integer
    Private m_intInicioDiaID As Integer
    Private m_strCodCaja As String
    Private m_datFechaInicio As Date
    Private m_intFolioFactura As Integer
    Private m_intFolioApartado As Integer
    Private m_intFolioNotaCredito As Integer
    Private m_intFolioAbono As Integer
    Private m_decFondo As Decimal
    Private m_decRetiro As Decimal
    Private m_decRetiroAutomatico As Decimal
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bStatusRegistro As Boolean
    Private m_intFolioNotaVentaManual As Integer

#End Region

#Region "Fields Change Notificators"

    Public Event InicioCajaIDChanged As EventHandler
    Public Event InicioDiaIDChanged As EventHandler
    Public Event CodCajaChanged As EventHandler
    Public Event FechaInicioChanged As EventHandler
    Public Event FolioFacturaChanged As EventHandler
    Public Event FolioApartadoChanged As EventHandler
    Public Event FolioNotaCreditoChanged As EventHandler
    Public Event FolioAbonoChanged As EventHandler
    Public Event FondoChanged As EventHandler
    Public Event RetiroChanged As EventHandler
    Public Event RetiroAutomaticoChanged As EventHandler
    Public Event UsuarioChanged As EventHandler
    Public Event FechaChanged As EventHandler
    Public Event StatusRegistroChanged As EventHandler
    Public Event EventFolioNotaVentaManual As EventHandler

#End Region

#Region "Fields Accessors"

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

    Public Property RetiroAutomatico() As Decimal
        Get
            Return m_decRetiroAutomatico
        End Get
        Set(ByVal Value As Decimal)
            m_decRetiroAutomatico = Value
            RaiseEvent RetiroAutomaticoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Retiro() As Decimal
        Get
            Return m_decRetiro
        End Get
        Set(ByVal Value As Decimal)
            m_decRetiro = Value
            RaiseEvent RetiroChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Fondo() As Decimal
        Get
            Return m_decFondo
        End Get
        Set(ByVal Value As Decimal)
            m_decFondo = Value
            RaiseEvent FondoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FolioAbono() As Integer
        Get
            Return m_intFolioAbono
        End Get
        Set(ByVal Value As Integer)
            m_intFolioAbono = Value
            RaiseEvent FolioAbonoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FolioNotaCredito() As Integer
        Get
            Return m_intFolioNotaCredito
        End Get
        Set(ByVal Value As Integer)
            m_intFolioNotaCredito = Value
            RaiseEvent FolioNotaCreditoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FolioApartado() As Integer
        Get
            Return m_intFolioApartado
        End Get
        Set(ByVal Value As Integer)
            m_intFolioApartado = Value
            RaiseEvent FolioApartadoChanged(Me, EventArgs.Empty)
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

    Public Property FechaInicio() As Date
        Get
            Return m_datFechaInicio
        End Get
        Set(ByVal Value As Date)
            m_datFechaInicio = Value
            RaiseEvent FechaInicioChanged(Me, EventArgs.Empty)
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

    Public Property InicioDiaID() As Integer
        Get
            Return m_intInicioDiaID
        End Get
        Set(ByVal Value As Integer)
            m_intInicioDiaID = Value
            RaiseEvent InicioDiaIDChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property InicioCajaID() As Integer
        Get
            Return m_intInicioCajaID
        End Get
        Set(ByVal Value As Integer)
            m_intInicioCajaID = Value
            RaiseEvent InicioCajaIDChanged(Me, EventArgs.Empty)
        End Set
    End Property
    
    Public Property FolioNotaVentaManual() As Integer
        Get
            Return m_intFolioNotaVentaManual
        End Get
        Set(ByVal Value As Integer)
            m_intFolioNotaVentaManual = Value
            RaiseEvent EventFolioNotaVentaManual(Me, EventArgs.Empty)
        End Set
    End Property
#End Region

#Region "Field Static"

    Private m_strCodAlmacen As String

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
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

#Region "Constructors / Destructors"

    Friend Sub New(ByVal Parent As InicioCajaManager)

        MyBase.New()

        oParent = Parent

        ClearFields()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Sub ClearFields()

        m_intInicioCajaID = 0
        m_intInicioDiaID = 0
        m_strCodCaja = String.Empty
        m_datFechaInicio = Date.Today
        m_intFolioFactura = 0
        m_intFolioApartado = 0
        m_intFolioNotaCredito = 0
        m_intFolioAbono = 0
        m_decFondo = 0
        m_decRetiro = 0
        m_decRetiroAutomatico = 0
        m_strUsuario = String.Empty
        m_datFecha = Date.Today
        m_bStatusRegistro = True
        m_intFolioNotaVentaManual = 0

        m_strCodAlmacen = oParent.ApplicationContext.ApplicationConfiguration.Almacen

        Me.SetFlagNew()
        Me.ResetFlagDirty()

    End Sub

#End Region


End Class
