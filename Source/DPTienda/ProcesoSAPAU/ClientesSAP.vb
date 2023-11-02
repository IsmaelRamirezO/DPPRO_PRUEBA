Public Class ClientesSAP

#Region "Variables"
    Private m_strNumeroInterior As String = ""
    Private m_strNumeroExterior As String = ""
    Private m_intclienteid As String
    Private m_strNombre As String
    Private m_strApellidos As String
    Private m_chrSexo As Char
    Private m_strEstadocivil As String
    Private m_strDomicilio As String
    Private m_strEstado As String
    Private m_strCiudad As String
    Private m_strColonia As String
    Private m_strCp As String
    Private m_strTelefono As String
    Private m_dtFechanac As Date
    Private m_strEmail As String
    Private m_strCodalmacen As String
    Private m_strCodPlaza As String
    Private m_strUsuario As String
    Private m_dtFecha As Date
    Private m_bStatusregistro As Boolean
    Private m_strRFC As String
    Private m_strTipoVenta As String
    Private m_strClaveAnterior As String
    Private m_strPlayer As String
    Private m_IDCLIENTE As String
    Private m_claveelector As String
    Private m_Status As Integer


#End Region

#Region "Fields Accessors"

    Public Property NumeroExterior() As String
        Get
            Return m_strNumeroExterior
        End Get
        Set(ByVal Value As String)
            m_strNumeroExterior = Value
        End Set
    End Property

    Public Property NumeroInterior() As String
        Get
            Return m_strNumeroInterior
        End Get
        Set(ByVal Value As String)
            m_strNumeroInterior = Value
        End Set
    End Property

    Public Property Player() As String
        Get
            Return m_strPlayer
        End Get
        Set(ByVal Value As String)
            m_strPlayer = Value
        End Set
    End Property

    Public Property ClaveAnterior() As String
        Get
            Return m_strClaveAnterior
        End Get
        Set(ByVal Value As String)
            m_strClaveAnterior = Value
        End Set
    End Property

    Public Property RFC() As String
        Get
            Return m_strRFC
        End Get
        Set(ByVal Value As String)
            m_strRFC = Value
        End Set
    End Property

    Public Property TipoVenta()
        Get
            Return m_strTipoVenta
        End Get
        Set(ByVal Value)
            m_strTipoVenta = Value
        End Set
    End Property


    Public Property Clienteid() As String
        Get
            Return m_intclienteid
        End Get
        Set(ByVal Value As String)
            m_intclienteid = Value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return m_strNombre
        End Get
        Set(ByVal Value As String)
            m_strNombre = Value
        End Set
    End Property

    Public Property Apellidos() As String
        Get
            Return m_strApellidos
        End Get
        Set(ByVal Value As String)
            m_strApellidos = Value
        End Set
    End Property

    Public Property Sexo() As Char
        Get
            Return m_chrSexo
        End Get
        Set(ByVal Value As Char)
            m_chrSexo = Value
        End Set
    End Property

    Public Property Estadocivil() As String
        Get
            Return m_strEstadocivil
        End Get
        Set(ByVal Value As String)
            m_strEstadocivil = Value
        End Set
    End Property

    Public Property Domicilio() As String
        Get
            Return m_strDomicilio
        End Get
        Set(ByVal Value As String)
            m_strDomicilio = Value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return m_strEstado
        End Get
        Set(ByVal Value As String)
            m_strEstado = Value
        End Set
    End Property

    Public Property Ciudad() As String
        Get
            Return m_strCiudad
        End Get
        Set(ByVal Value As String)
            m_strCiudad = Value
        End Set
    End Property

    Public Property Colonia() As String
        Get
            Return m_strColonia
        End Get
        Set(ByVal Value As String)
            m_strColonia = Value
        End Set
    End Property

    Public Property Cp() As String
        Get
            Return m_strCp
        End Get
        Set(ByVal Value As String)
            m_strCp = Value
        End Set
    End Property

    Public Property Telefono() As String
        Get
            Return m_strTelefono
        End Get
        Set(ByVal Value As String)
            m_strTelefono = Value
        End Set
    End Property

    Public Property Fechanac() As Date
        Get
            Return m_dtFechanac
        End Get
        Set(ByVal Value As Date)
            m_dtFechanac = Value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return m_strEmail
        End Get
        Set(ByVal Value As String)
            m_strEmail = Value
        End Set
    End Property

    Public Property Codalmacen() As String
        Get
            Return m_strCodalmacen
        End Get
        Set(ByVal Value As String)
            m_strCodalmacen = Value
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

    Public Property Usuario() As String
        Get
            Return m_strUsuario
        End Get
        Set(ByVal Value As String)
            m_strUsuario = Value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return m_dtFecha
        End Get
        Set(ByVal Value As Date)
            m_dtFecha = Value
        End Set
    End Property

    Public Property Statusregistro() As Boolean
        Get
            Return m_bStatusregistro
        End Get
        Set(ByVal Value As Boolean)
            m_bStatusregistro = Value
        End Set
    End Property

    Public Property IDCLIENTE() As String
        Get
            Return m_IDCLIENTE
        End Get
        Set(ByVal Value As String)
            m_IDCLIENTE = Value
        End Set
    End Property

    Public Property claveelector() As String
        Get
            Return m_claveelector
        End Get
        Set(ByVal Value As String)
            m_claveelector = Value
        End Set
    End Property

    Public Property Status As Integer
        Get
            Return m_Status
        End Get
        Set(ByVal value As Integer)
            m_Status = value
        End Set
    End Property

#End Region

End Class
