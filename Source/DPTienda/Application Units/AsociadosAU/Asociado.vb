
Public Class Asociado

    Private oParent As AsociadosManager

#Region "Environment Var"

    Private m_intAsociadoID As Integer
    Private m_intClienteID As Integer
    Private m_bEsCreditoMayoreo As Boolean
    Private m_bEsCreditoDirectoTienda As Boolean
    Private m_bEsCreditoDPVale As Boolean
    Private m_decLimiteCreditoMayoreo As Decimal
    Private m_decLimiteCreditoDPVale As Decimal
    Private m_decLimiteCreditoDirectoTienda As Decimal
    Private m_decSaldoMayoreo As Decimal
    Private m_decSaldoDirectoTienda As Decimal
    Private m_decSaldoDPVale As Decimal
    Private m_decSaldoVencMayoreo As Decimal
    Private m_decSaldoVencDirectoTienda As Decimal
    Private m_decSaldoVencDPVale As Decimal
    Private m_bytFoto() As Byte
    Private m_strUsuario As String
    Private m_datFecha As Date
    Private m_bStatusRegistro As Boolean
    Private m_strTeleFonoTrabajo As String
    Private m_strTeleFonoOtro As String
    Private m_strObservaciones As String = " "
    Private m_strCodigoSAP As String = ""

    Public Event AsociadoIDChanged As EventHandler
    Public Event ClienteIDChanged As EventHandler
    Public Event EsCreditoMayoreoChanged As EventHandler
    Public Event EsCreditoDirectoTiendaChanged As EventHandler
    Public Event EsCreditoDPValeChanged As EventHandler
    Public Event LimiteCreditoMayoreoChanged As EventHandler
    Public Event LimiteCreditoDPValeChanged As EventHandler
    Public Event LimiteCreditoDirectoTiendaChanged As EventHandler
    Public Event SaldoMayoreoChanged As EventHandler
    Public Event SaldoDirectoTiendaChanged As EventHandler
    Public Event SaldoDPValeChanged As EventHandler
    Public Event SaldoVencMayoreoChanged As EventHandler
    Public Event SaldoVencDirectoTiendaChanged As EventHandler
    Public Event SaldoVencDPValeChanged As EventHandler
    Public Event FotoChanged As EventHandler
    Public Event UsuarioChanged As EventHandler
    Public Event FechaChanged As EventHandler
    Public Event StatusRegistroChanged As EventHandler

    Public Event TelefonoTrabajoChanged As EventHandler
    Public Event TelefonoOtroChanged As EventHandler

#End Region

#Region "Fields"

    Public Property AsociadoID() As Integer
        Get
            Return m_intAsociadoID
        End Get
        Set(ByVal Value As Integer)
            m_intAsociadoID = Value
            RaiseEvent AsociadoIDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property ClienteID() As Integer
        Get
            Return m_intClienteID
        End Get
        Set(ByVal Value As Integer)
            m_intClienteID = Value
            RaiseEvent ClienteIDChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property EsCreditoMayoreo() As Boolean
        Get
            Return m_bEsCreditoMayoreo
        End Get
        Set(ByVal Value As Boolean)
            m_bEsCreditoMayoreo = Value
            RaiseEvent EsCreditoMayoreoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property EsCreditoDirectoTienda() As Boolean
        Get
            Return m_bEsCreditoDirectoTienda
        End Get
        Set(ByVal Value As Boolean)
            m_bEsCreditoDirectoTienda = Value
            RaiseEvent EsCreditoDirectoTiendaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property EsCreditoDPVale() As Boolean
        Get
            Return m_bEsCreditoDPVale
        End Get
        Set(ByVal Value As Boolean)
            m_bEsCreditoDPVale = Value
            RaiseEvent EsCreditoDPValeChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property LimiteCreditoMayoreo() As Decimal
        Get
            Return m_decLimiteCreditoMayoreo
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCreditoMayoreo = Value
            RaiseEvent LimiteCreditoMayoreoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property LimiteCreditoDPVale() As Decimal
        Get
            Return m_decLimiteCreditoDPVale
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCreditoDPVale = Value
            RaiseEvent LimiteCreditoDPValeChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property LimiteCreditoDirectoTienda() As Decimal
        Get
            Return m_decLimiteCreditoDirectoTienda
        End Get
        Set(ByVal Value As Decimal)
            m_decLimiteCreditoDirectoTienda = Value
            RaiseEvent LimiteCreditoDirectoTiendaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property SaldoMayoreo() As Decimal
        Get
            Return m_decSaldoMayoreo
        End Get
        Set(ByVal Value As Decimal)
            m_decSaldoMayoreo = Value
            RaiseEvent SaldoMayoreoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property SaldoDirectoTienda() As Decimal
        Get
            Return m_decSaldoDirectoTienda
        End Get
        Set(ByVal Value As Decimal)
            m_decSaldoDirectoTienda = Value
            RaiseEvent SaldoDirectoTiendaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property SaldoDPVale() As Decimal
        Get
            Return m_decSaldoDPVale
        End Get
        Set(ByVal Value As Decimal)
            m_decSaldoDPVale = Value
            RaiseEvent SaldoDPValeChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property SaldoVencMayoreo() As Decimal
        Get
            Return m_decSaldoVencMayoreo
        End Get
        Set(ByVal Value As Decimal)
            m_decSaldoVencMayoreo = Value
            RaiseEvent SaldoVencMayoreoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property SaldoVencDirectoTienda() As Decimal
        Get
            Return m_decSaldoVencDirectoTienda
        End Get
        Set(ByVal Value As Decimal)
            m_decSaldoVencDirectoTienda = Value
            RaiseEvent SaldoVencDirectoTiendaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property SaldoVencDPVale() As Decimal
        Get
            Return m_decSaldoVencDPVale
        End Get
        Set(ByVal Value As Decimal)
            m_decSaldoVencDPVale = Value
            RaiseEvent SaldoVencDPValeChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Foto() As Byte()
        Get
            Return m_bytFoto
        End Get
        Set(ByVal Value As Byte())
            m_bytFoto = Value
            RaiseEvent FotoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
            RaiseEvent UsuarioChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return m_datFecha
        End Get
        Set(ByVal Value As Date)
            m_datFecha = Value
            RaiseEvent FechaChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property StatusRegistro() As Boolean
        Get
            Return m_bStatusRegistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStatusRegistro = Value
            RaiseEvent StatusRegistroChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property TeleFonoTrabajo() As String
        Get
            Return m_strTeleFonoTrabajo
        End Get
        Set(ByVal Value As String)
            m_strTeleFonoTrabajo = Value
            RaiseEvent TelefonoTrabajoChanged(Me, New EventArgs)
        End Set
    End Property

    Public Property TeleFonoOtro() As String
        Get
            Return m_strTeleFonoOtro
        End Get
        Set(ByVal Value As String)
            m_strTeleFonoOtro = Value
            RaiseEvent TelefonoOtroChanged(Me, New EventArgs)
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

    Public Property CodigoSAP() As String
        Get
            Return m_strCodigoSAP
        End Get
        Set(ByVal Value As String)
            m_strCodigoSAP = Value
        End Set
    End Property

#End Region

#Region "Constructors / Destructors"


    Friend Sub New(ByVal Parent As AsociadosManager)

        MyBase.New()

        oParent = Parent

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

    Public Sub SetFlagNew()
        bolIsNew = True
    End Sub

    Friend Sub ResetFlagDirty()
        bolIsDirty = False
    End Sub

    Public Sub ResetFlagNew()
        bolIsNew = False
    End Sub

#End Region

#Region "Methods"

    Public Shadows Sub Clear()

        m_intAsociadoID = 0
        m_intClienteID = 0
        m_bEsCreditoMayoreo = False
        m_bEsCreditoDirectoTienda = False
        m_bEsCreditoDPVale = False
        m_decLimiteCreditoMayoreo = 0
        m_decLimiteCreditoDPVale = 0
        m_decLimiteCreditoDirectoTienda = 0
        m_decSaldoMayoreo = 0
        m_decSaldoDirectoTienda = 0
        m_decSaldoDPVale = 0
        m_decSaldoVencMayoreo = 0
        m_decSaldoVencDirectoTienda = 0
        m_decSaldoVencDPVale = 0
        m_bytFoto = Nothing
        m_strUsuario = String.Empty
        m_datFecha = Date.Today
        m_bStatusRegistro = True
        m_strTeleFonoTrabajo = String.Empty
        m_strTeleFonoOtro = String.Empty
        m_strObservaciones = String.Empty
        m_strCodigoSAP = String.Empty

        Me.SetFlagNew()

    End Sub

#End Region

End Class
