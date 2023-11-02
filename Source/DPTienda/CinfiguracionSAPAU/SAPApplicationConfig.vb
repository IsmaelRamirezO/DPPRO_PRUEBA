Public Class SAPApplicationConfig

    Private m_boleHub As Boolean
    Private m_strTicket As Integer
    Private m_strPlaza As String
    Private m_bolPrestamos As Boolean
    Private descargaManual As Boolean = False
    Private m_strApplicationServer As String
    Private m_strGroupName As String
    Private m_strSystem As String
    Private m_strClient As String
    Private m_strUser As String
    Private m_strPassword As String
    Private m_strLanguage As String
    Private m_bolTdaNueva As Boolean
    Private m_bolDPValeSAP As Boolean

    '------------------------------------------------------
    ' JNAVA (14.04.2016): Configuración para DPVale AFS
    '------------------------------------------------------
    Private m_strApplicationServerDPVale As String = "10.200.3.36"
    Private m_strGroupNameDPVale As String = "PRD"
    Private m_strSystemDPVale As String = "00"
    Private m_strClientDPVale As String = "300"
    Private m_strUserDPVale As String = "MB"
    Private m_strPasswordDPVale As String = "BROKER"
    Private m_strLanguageDPVale As String = "ES"

    '------------------------------------------------------
    ' JNAVA (14.04.2016): Configuración para Timeout SAP
    '------------------------------------------------------
    Private m_intTimeout As Integer = 900000


    '-------------------------------------------------------
    ' MLVARGAS (10.08.2021): Configuración para SAP CAR
    '-------------------------------------------------------
    Private m_bolFact As Boolean
    Private m_bolSiHay As Boolean = True
    Private m_bolInventario As Boolean = True
    Private m_bolDevoluciones As Boolean = False
    Private m_bolCambioTalla As Boolean

    Private m_strServerCar As String = "https://sapcarapp.grupodp.com.mx"
    Private m_strPortCar As Long = 44300
    Private m_strUserCar As String = "S77POS"
    Private m_strPwdCar As String = "S77POSPRD"
    Private m_strIdCanal As String = "SHYCC"
    Private m_strClientCAR As String = "300"
    Private m_strVersionCAR As String = "SiHayDPT"

    Private m_strBuscarCAR As String = "V1"
    Private m_strReemplazarCAR As String = String.Empty

#Region "Methods"

    Public Sub New()

        Me.Create()

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

    End Sub

    Private Sub Create()

        m_strApplicationServer = String.Empty
        m_strGroupName = String.Empty
        m_strSystem = String.Empty
        m_strClient = String.Empty
        m_strUser = String.Empty
        m_strPassword = String.Empty
        m_strLanguage = String.Empty
        m_bolTdaNueva = False
        m_bolDPValeSAP = False
        m_strPlaza = String.Empty

    End Sub

    Public Function GetConnectionString() As String

        Dim cnnStr As String = String.Empty

        cnnStr = "ashost=" & Me.ApplicationServer & " " & _
                    "sysnr=" & Me.System & " " & _
                    "client=" & Me.Client & " " & _
                    "user=" & Me.User & " " & _
                    "passwd=" & Me.Password

        Return cnnStr

    End Function

#End Region

#Region "Properties"

    Public Property DPValeSAP() As Boolean
        Get
            Return m_bolDPValeSAP
        End Get
        Set(ByVal Value As Boolean)
            m_bolDPValeSAP = Value
        End Set
    End Property

    Public Property TdaNueva() As Boolean
        Get
            Return m_bolTdaNueva
        End Get
        Set(ByVal Value As Boolean)
            m_bolTdaNueva = Value
        End Set
    End Property

    Public Property ApplicationServer() As String
        Get
            Return m_strApplicationServer
        End Get
        Set(ByVal Value As String)
            m_strApplicationServer = Value
        End Set
    End Property

    Public Property GroupName() As String
        Get
            Return m_strGroupName
        End Get
        Set(ByVal Value As String)
            m_strGroupName = Value
        End Set
    End Property

    Public Property System() As String
        Get
            Return m_strSystem
        End Get
        Set(ByVal Value As String)
            m_strSystem = Value
        End Set
    End Property

    Public Property Client() As String
        Get
            Return m_strClient
        End Get
        Set(ByVal Value As String)
            m_strClient = Value
        End Set
    End Property

    Public Property User() As String
        Get
            Return m_strUser
        End Get
        Set(ByVal Value As String)
            m_strUser = Value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return m_strPassword
        End Get
        Set(ByVal Value As String)
            m_strPassword = Value
        End Set
    End Property

    Public Property Language() As String
        Get
            Return m_strLanguage
        End Get
        Set(ByVal Value As String)
            m_strLanguage = Value
        End Set
    End Property

#End Region

    Public Property eHub() As Boolean
        Get
            Return m_boleHub
        End Get
        Set(ByVal Value As Boolean)
            m_boleHub = Value
        End Set
    End Property

    Public Property Prestamos() As Boolean
        Get
            Return m_bolPrestamos
        End Get
        Set(ByVal Value As Boolean)
            m_bolPrestamos = Value
        End Set
    End Property

    Public Property Plaza() As String
        Get
            Return m_strPlaza
        End Get
        Set(ByVal Value As String)
            m_strPlaza = Value
        End Set
    End Property

    Public Property Ticket() As Integer
        Get
            Return m_strTicket
        End Get
        Set(ByVal Value As Integer)
            m_strTicket = Value
        End Set
    End Property

    Public Property Timeout() As Integer
        Get
            Return m_intTimeout
        End Get
        Set(ByVal Value As Integer)
            m_intTimeout = Value
        End Set
    End Property
    Public Property DercargaManual() As Boolean
        Get
            Return descargaManual
        End Get
        Set(ByVal Value As Boolean)
            descargaManual = Value
        End Set
    End Property


    Public Property Facturacion() As Boolean
        Get
            Return m_bolFact
        End Get
        Set(ByVal Value As Boolean)
            m_bolFact = Value
        End Set
    End Property

    Public Property SiHay() As Boolean
        Get
            Return m_bolSiHay
        End Get
        Set(ByVal Value As Boolean)
            m_bolSiHay = Value
        End Set
    End Property

    Public Property Inventario() As Boolean
        Get
            Return m_bolInventario
        End Get
        Set(ByVal Value As Boolean)
            m_bolInventario = Value
        End Set
    End Property

    Public Property Devoluciones() As Boolean
        Get
            Return m_bolDevoluciones
        End Get
        Set(ByVal Value As Boolean)
            m_bolDevoluciones = Value
        End Set
    End Property

    Public Property CambioTalla() As Boolean
        Get
            Return m_bolCambioTalla
        End Get
        Set(ByVal Value As Boolean)
            m_bolCambioTalla = Value
        End Set
    End Property

    Public Property ServerCAR() As String
        Get
            Return m_strServerCar
        End Get
        Set(ByVal Value As String)
            m_strServerCar = Value
        End Set
    End Property

    Public Property PuertoCAR() As Long
        Get
            Return m_strPortCar
        End Get
        Set(ByVal Value As Long)
            m_strPortCar = Value
        End Set
    End Property

    Public Property ClienteCAR() As String
        Get
            Return m_strClientCAR
        End Get
        Set(ByVal Value As String)
            m_strClientCAR = Value
        End Set
    End Property

    Public Property VersionCAR() As String
        Get
            Return m_strVersionCAR
        End Get
        Set(ByVal Value As String)
            m_strVersionCAR = Value
        End Set
    End Property


    Public Property UserCAR() As String
        Get
            Return m_strUserCar
        End Get
        Set(ByVal Value As String)
            m_strUserCar = Value
        End Set
    End Property

    Public Property PwdCAR() As String
        Get
            Return m_strPwdCar
        End Get
        Set(ByVal Value As String)
            m_strPwdCar = Value
        End Set
    End Property

    Public Property IdCanalCAR() As String
        Get
            Return m_strIdCanal
        End Get
        Set(ByVal Value As String)
            m_strIdCanal = Value
        End Set
    End Property

    Public Property BuscarCAR() As String
        Get
            Return m_strBuscarCAR
        End Get
        Set(ByVal Value As String)
            m_strBuscarCAR = Value
        End Set
    End Property

    Public Property ReemplazarCAR() As String
        Get
            Return m_strReemplazarCAR
        End Get
        Set(ByVal Value As String)
            m_strReemplazarCAR = Value
        End Set
    End Property
#Region "DPVale AFS"
    Public Property ApplicationServerDPVale() As String
        Get
            Return m_strApplicationServerDPVale
        End Get
        Set(ByVal Value As String)
            m_strApplicationServerDPVale = Value
        End Set
    End Property

    Public Property GroupNameDPVale() As String
        Get
            Return m_strGroupNameDPVale
        End Get
        Set(ByVal Value As String)
            m_strGroupNameDPVale = Value
        End Set
    End Property

    Public Property SystemDPVale() As String
        Get
            Return m_strSystemDPVale
        End Get
        Set(ByVal Value As String)
            m_strSystemDPVale = Value
        End Set
    End Property

    Public Property ClientDPVale() As String
        Get
            Return m_strClientDPVale
        End Get
        Set(ByVal Value As String)
            m_strClientDPVale = Value
        End Set
    End Property

    Public Property UserDPVale() As String
        Get
            Return m_strUserDPVale
        End Get
        Set(ByVal Value As String)
            m_strUserDPVale = Value
        End Set
    End Property

    Public Property PasswordDPVale() As String
        Get
            Return m_strPasswordDPVale
        End Get
        Set(ByVal Value As String)
            m_strPasswordDPVale = Value
        End Set
    End Property

    Public Property LanguageDPVale() As String
        Get
            Return m_strLanguageDPVale
        End Get
        Set(ByVal Value As String)
            m_strLanguageDPVale = Value
        End Set
    End Property
#End Region



End Class
