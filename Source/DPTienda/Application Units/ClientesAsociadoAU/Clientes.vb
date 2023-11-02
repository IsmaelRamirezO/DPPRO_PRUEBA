Imports DportenisPro.DPTienda.Core

Public Class Clientes

    Private oParent As ClientesManager

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

#Region "Fields"

#Region "Fields Data Storage"

    Private m_intClienteID As Integer
    Private m_strNombre As String
    Private m_strApellidoPaterno As String
    Private m_strApellidoMaterno As String
    Private m_strSexo As String
    Private m_strEstadoCivil As String
    Private m_strDomicilio As String
    Private m_strEstado As String
    Private m_strCiudad As String
    Private m_strColonia As String
    Private m_strCP As String
    Private m_strTelefono As String
    Private m_datFechaNac As Date
    Private m_strEmail As String
    Private m_strCodAlmacen As String
    Private m_strCodPlaza As String
    Private m_strCedulaFiscal As String
    Private m_strDFNombre As String
    Private m_strDFDireccion As String
    Private m_strDFColonia As String
    Private m_strDFCiudad As String
    Private m_strDFEstado As String
    Private m_strDFCP As String
    Private m_bFacturar As Boolean
    Private m_bEsAsociado As Boolean
    Private m_bEsSocioClubDP As Boolean
    Private m_bEsFacilito As Boolean
    Private m_bEsFonacot As Boolean
    Private m_intCreditoDPValeID As Integer

#End Region

#Region "Field Change Notificators"

    Public Event ClienteIDChanged As EventHandler
    Public Event NombreChanged As EventHandler
    Public Event ApellidoPaternoChanged As EventHandler
    Public Event ApellidoMaternoChanged As EventHandler
    Public Event SexoChanged As EventHandler
    Public Event EstadoCivilChanged As EventHandler
    Public Event DomicilioChanged As EventHandler
    Public Event EstadoChanged As EventHandler
    Public Event CiudadChanged As EventHandler
    Public Event ColoniaChanged As EventHandler
    Public Event CPChanged As EventHandler
    Public Event TelefonoChanged As EventHandler
    Public Event FechaNacChanged As EventHandler
    Public Event EmailChanged As EventHandler
    Public Event CodAlmacenChanged As EventHandler
    Public Event CodPlazaChanged As EventHandler
    Public Event CedulaFiscalChanged As EventHandler
    Public Event DFNombreChanged As EventHandler
    Public Event DFDireccionChanged As EventHandler
    Public Event DFColoniaChanged As EventHandler
    Public Event DFCiudadChanged As EventHandler
    Public Event DFEstadoChanged As EventHandler
    Public Event DFCPChanged As EventHandler
    Public Event FacturarChanged As EventHandler
    Public Event EsAsociadoChanged As EventHandler
    Public Event EsSocioClubDPChanged As EventHandler
    Public Event EsFacilitoChanged As EventHandler
    Public Event EsFonacotChanged As EventHandler
    Public Event CreditoDPValeIDChanged As EventHandler

#End Region

#Region "Field Accessors"

    Public Property CreditoDPValeID() As Integer
        Get
            Return m_intCreditoDPValeID
        End Get
        Set(ByVal Value As Integer)
            m_intCreditoDPValeID = Value
            RaiseEvent CreditoDPValeIDChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property EsFonacot() As Boolean
        Get
            Return m_bEsFonacot
        End Get
        Set(ByVal Value As Boolean)
            m_bEsFonacot = Value
            RaiseEvent EsFonacotChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property EsFacilito() As Boolean
        Get
            Return m_bEsFacilito
        End Get
        Set(ByVal Value As Boolean)
            m_bEsFacilito = Value
            RaiseEvent EsFacilitoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property EsSocioClubDP() As Boolean
        Get
            Return m_bEsSocioClubDP
        End Get
        Set(ByVal Value As Boolean)
            m_bEsSocioClubDP = Value
            RaiseEvent EsSocioClubDPChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property EsAsociado() As Boolean
        Get
            Return m_bEsAsociado
        End Get
        Set(ByVal Value As Boolean)
            m_bEsAsociado = Value
            RaiseEvent EsAsociadoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Facturar() As Boolean
        Get
            Return m_bFacturar
        End Get
        Set(ByVal Value As Boolean)
            m_bFacturar = Value
            RaiseEvent FacturarChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DFCP() As String
        Get
            Return m_strDFCP
        End Get
        Set(ByVal Value As String)
            m_strDFCP = Value
            RaiseEvent DFCPChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DFEstado() As String
        Get
            Return m_strDFEstado
        End Get
        Set(ByVal Value As String)
            m_strDFEstado = Value
            RaiseEvent DFEstadoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DFCiudad() As String
        Get
            Return m_strDFCiudad
        End Get
        Set(ByVal Value As String)
            m_strDFCiudad = Value
            RaiseEvent DFCiudadChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DFDireccion() As String
        Get
            Return m_strDFDireccion
        End Get
        Set(ByVal Value As String)
            m_strDFDireccion = Value
            RaiseEvent DFDireccionChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DFColonia() As String
        Get
            Return m_strDFColonia
        End Get
        Set(ByVal Value As String)
            m_strDFColonia = Value
            RaiseEvent DFColoniaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property DFNombre() As String
        Get
            Return m_strDFNombre
        End Get
        Set(ByVal Value As String)
            m_strDFNombre = Value
            RaiseEvent DFNombreChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CedulaFiscal() As String
        Get
            Return m_strCedulaFiscal
        End Get
        Set(ByVal Value As String)
            m_strCedulaFiscal = Value
            RaiseEvent CedulaFiscalChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CodPlaza() As String
        Get
            Return m_strCodPlaza
        End Get
        Set(ByVal Value As String)
            m_strCodPlaza = Value
            RaiseEvent CodPlazaChanged(Me, EventArgs.Empty)
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

    Public Property Email() As String
        Get
            Return m_strEmail
        End Get
        Set(ByVal Value As String)
            m_strEmail = Value
            RaiseEvent EmailChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property FechaNac() As Date
        Get
            Return m_datFechaNac
        End Get
        Set(ByVal Value As Date)
            m_datFechaNac = Value
            RaiseEvent FechaNacChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return m_strTelefono
        End Get
        Set(ByVal Value As String)
            m_strTelefono = Value
            RaiseEvent TelefonoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property CP() As String
        Get
            Return m_strCP
        End Get
        Set(ByVal Value As String)
            m_strCP = Value
            RaiseEvent CPChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Colonia() As String
        Get
            Return m_strColonia
        End Get
        Set(ByVal Value As String)
            m_strColonia = Value
            RaiseEvent ColoniaChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return m_strCiudad
        End Get
        Set(ByVal Value As String)
            m_strCiudad = Value
            RaiseEvent CiudadChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return m_strEstado
        End Get
        Set(ByVal Value As String)
            m_strEstado = Value
            RaiseEvent EstadoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Domicilio() As String
        Get
            Return m_strDomicilio
        End Get
        Set(ByVal Value As String)
            m_strDomicilio = Value
            RaiseEvent DomicilioChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property EstadoCivil() As String
        Get
            Return m_strEstadoCivil
        End Get
        Set(ByVal Value As String)
            m_strEstadoCivil = Value
            RaiseEvent EstadoCivilChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Sexo() As String
        Get
            Return m_strSexo
        End Get
        Set(ByVal Value As String)
            m_strSexo = Value
            RaiseEvent SexoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ApellidoMaterno() As String
        Get
            Return m_strApellidoMaterno
        End Get
        Set(ByVal Value As String)
            m_strApellidoMaterno = Value
            RaiseEvent ApellidoMaternoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ApellidoPaterno() As String
        Get
            Return m_strApellidoPaterno
        End Get
        Set(ByVal Value As String)
            m_strApellidoPaterno = Value
            RaiseEvent ApellidoPaternoChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return m_strNombre
        End Get
        Set(ByVal Value As String)
            m_strNombre = Value
            RaiseEvent NombreChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Property ClienteID() As Integer
        Get
            Return m_intClienteID
        End Get
        Set(ByVal Value As Integer)
            m_intClienteID = Value
            RaiseEvent ClienteIDChanged(Me, EventArgs.Empty)
        End Set
    End Property

#End Region

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

    Friend Sub New(ByVal Parent As ClientesManager)

        MyBase.New()

        oParent = Parent

    End Sub

    Protected Overrides Sub Finalize()

        MyBase.Finalize()

        oParent = Nothing

    End Sub

#End Region

#Region "Methods"

    Public Sub Clear()

        Me.ClienteID = 0
        Me.Nombre = String.Empty
        Me.ApellidoPaterno = String.Empty
        Me.ApellidoMaterno = String.Empty
        Me.Sexo = String.Empty
        Me.EstadoCivil = String.Empty
        Me.Domicilio = String.Empty
        Me.Estado = String.Empty
        Me.Ciudad = String.Empty
        Me.Colonia = String.Empty
        Me.CP = String.Empty
        Me.Telefono = String.Empty
        Me.FechaNac = Date.Today
        Me.Email = String.Empty
        Me.CodAlmacen = String.Empty
        Me.CodPlaza = String.Empty
        Me.CedulaFiscal = String.Empty
        Me.DFNombre = String.Empty
        Me.DFDireccion = String.Empty
        Me.DFColonia = String.Empty
        Me.DFCiudad = String.Empty
        Me.DFEstado = String.Empty
        Me.DFCP = String.Empty
        Me.Facturar = 0
        Me.EsAsociado = 0
        Me.EsSocioClubDP = 0
        Me.EsFacilito = 0
        Me.EsFonacot = 0
        Me.CreditoDPValeID = 0
        Me.RecordCreatedBy = oParent.ApplicationContext.Security.CurrentUser.Name
        Me.RecordCreatedOn = Now.ToShortDateString
        Me.RecordEnabled = 1

        ResetFlagDirty()
        SetFlagNew()

    End Sub

#End Region


End Class
