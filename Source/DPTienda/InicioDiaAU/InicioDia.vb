
Public Class InicioDia

    Private oParent As InicioDiaManager

#Region "Fields"

#Region "Fields Data Storage"

    Private m_decTot_Dia As Decimal
    Private m_decRetiros As Decimal
    Private m_datFechaInicioDia As Date
    Private m_strCodAlmacen As String
    Private m_intInicioDiaID As Integer
    Private m_decDiferenciaEnCaja As Decimal
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bStatusRegistro As Boolean

#End Region

#Region "Fields Change Notificators"

    Public Event StatusRegistroChanged As EventHandler
    Public Event FechaChanged As EventHandler
    Public Event UsuarioChanged As EventHandler
    Public Event DiferenciaEnCajaChanged As EventHandler
    Public Event Tot_DiaChanged As EventHandler
    Public Event RetirosChanged As EventHandler
    Public Event FechaInicioDiaChanged As EventHandler
    Public Event CodAlmacenChanged As EventHandler
    Public Event InicioDiaIDChanged As EventHandler

#End Region

#Region "Fields Accessors"

    Public Property InicioDiaID() As Integer
        Get
            Return m_intInicioDiaID
        End Get
        Set(ByVal Value As Integer)
            m_intInicioDiaID = Value
            RaiseEvent InicioDiaIDChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodAlmacen() As String
        Get
            Return m_strCodAlmacen
        End Get
        Set(ByVal Value As String)
            m_strCodAlmacen = Value
            RaiseEvent CodAlmacenChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FechaInicioDia() As Date
        Get
            Return m_datFechaInicioDia
        End Get
        Set(ByVal Value As Date)
            m_datFechaInicioDia = Value
            RaiseEvent FechaInicioDiaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Retiros() As Decimal
        Get
            Return m_decRetiros
        End Get
        Set(ByVal Value As Decimal)
            m_decRetiros = Value
            RaiseEvent RetirosChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Tot_Dia() As Decimal
        Get
            Return m_decTot_Dia
        End Get
        Set(ByVal Value As Decimal)
            m_decTot_Dia = Value
            RaiseEvent Tot_DiaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DiferenciaEnCaja() As Decimal
        Get
            Return m_decDiferenciaEnCaja
        End Get
        Set(ByVal Value As Decimal)
            m_decDiferenciaEnCaja = Value
            RaiseEvent DiferenciaEnCajaChanged(Me, EventArgs.Empty)
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

    Public Property Fecha() As Date
        Get
            Return m_datFecha
        End Get
        Set(ByVal Value As Date)
            m_datFecha = Value
            RaiseEvent FechaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property StatusRegistro() As Boolean
        Get
            Return m_bStatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStatusRegistro = Value
            RaiseEvent StatusRegistroChanged(Me, EventArgs.Empty)
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

    Friend Sub New(ByVal Parent As InicioDiaManager)

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

        m_intInicioDiaID = 0
        m_strCodAlmacen = oParent.ApplicationContext.ApplicationConfiguration.Almacen
        'm_datFechaInicioDia = Date.Today
        m_datFechaInicioDia = oParent.GetDateBeginDay
        m_decRetiros = 0
        m_decTot_Dia = 0
        m_decDiferenciaEnCaja = 0
        m_strUsuario = String.Empty
        m_datFecha = Date.Today
        m_bStatusRegistro = True

        Me.SetFlagNew()
        Me.ResetFlagDirty()

    End Sub

#End Region

End Class
